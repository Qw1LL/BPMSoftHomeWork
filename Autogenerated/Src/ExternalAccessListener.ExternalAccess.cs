namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Security;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.Messaging.Common;
	using CoreConfig = Core.Configuration;

	#region Class: ExternalAccessListener

	/// <summary>
	/// Listener for 'ExternalAccess' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "ExternalAccess")]
	public class ExternalAccessListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const string IdentityAddressSettingsName = "IdentityServerUrl";
		private const string ClientIdSettingsName = "IdentityServerClientId";
		private const string ClientSecretSettingsName = "IdentityServerClientSecret";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("ExternalAccess");

		#endregion

		#region Methods: Private

		private static void CheckSystemOperationRestrictedMode(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (userConnection.IsSystemOperationsRestricted) {
				throw new SystemOperationRestrictedException();
			}
		}

		private static void NotifyClientAboutException(UserConnection userConnection, Exception accessGrantException) {
			if (!MsgChannelManager.IsRunning) {
				return;
			}
			var channel = MsgChannelManager.Instance.FindItemByUId(userConnection.CurrentUser.Id);
			if (channel == null) {
				return;
			}
			var simpleMessage = new SimpleMessage {
				Body = accessGrantException?.InnerException ?? accessGrantException,
				Id = Guid.NewGuid()
			};
			simpleMessage.Header.BodyTypeName = "GrantingExternalAccess";
			simpleMessage.Header.Sender = nameof(ExternalAccessListener);
			channel.PostMessage(simpleMessage);
		}

		private Dictionary<string, string> CheckAndLoadRequiredSysSettings(UserConnection userConnection,
				string[] settings) {
			var values = settings.ToDictionary(
				code => code,
				code => CoreConfig.SysSettings.GetValue(userConnection, code, "")
			);
			List<string> emptySettings = values.Where(keyValue => keyValue.Value.IsNullOrWhiteSpace())
				.Select(keyValue => keyValue.Key).ToList();
			if (emptySettings.IsNotEmpty()) {
				var errorTemplate = new LocalizableString(userConnection.ResourceStorage, "ExternalAccessListener",
					"LocalizableStrings.EmptySettingsMessage.Value").ToString();
				var errorMessage = string.Format(errorTemplate, string.Join(", ", emptySettings));
				throw new ValidateException(errorMessage);
			}
			return values;
		}

		private ITempAccessProxy GetTempAccessProxy(Dictionary<string, string> requiredSettings) {
			var serverAddressArg = new ConstructorArgument("serverUrl", requiredSettings[IdentityAddressSettingsName]);
			var clientIdArg = new ConstructorArgument("clientId", requiredSettings[ClientIdSettingsName]);
			var clientSecretArg = new ConstructorArgument("clientSecret", requiredSettings[ClientSecretSettingsName]);
			var tempAccessProxy = ClassFactory.Get<ITempAccessProxy>(serverAddressArg, clientIdArg, clientSecretArg);
			return tempAccessProxy;
		}

		private (Guid Id, bool Active) LoadUserInfo(UserConnection userConnection, Guid contactId) {
			var select = (Select)new Select(userConnection)
				.From("SysAdminUnit")
				.Cols("Id", "Active")
				.Where("ContactId").IsEqual(Column.Parameter(contactId, "Guid"));
			select.ExecuteSingleRecord(reader => (
				reader.GetColumnValue<Guid>("Id"),
				reader.GetColumnValue<bool>("Active")
			), out var result);
			return result;
		}

		private void CheckGrantor(UserConnection userConnection, Guid userId, bool isActive) {
			if (userId != userConnection.CurrentUser.Id) {
				userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanDelegateExternalAccess");
			}
			if (!isActive) {
				var errorMessage = new LocalizableString(userConnection.ResourceStorage, "ExternalAccessListener",
					"LocalizableStrings.UserInactiveErrorMessage.Value").ToString();
				throw new SecurityException(errorMessage);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			base.OnInserting(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			Dictionary<string, string> requiredSettings = CheckAndLoadRequiredSysSettings(userConnection, new string[] {
				IdentityAddressSettingsName,
				ClientIdSettingsName,
				ClientSecretSettingsName
			});
			var resourceName = entity.PrimaryColumnValue.ToString();
			var expirationDate = entity.GetTypedColumnValue<DateTime>("DueDate");
			var endOfExpirationDateDay = expirationDate.Date.AddDays(1).AddTicks(-1);
			var userContactId = entity.GetTypedColumnValue<Guid>("GrantorId");
			(Guid userId, bool isActive) = LoadUserInfo(userConnection, userContactId);
			CheckGrantor(userConnection, userId, isActive);
			EntitySchemaColumn grantorColumn = entity.Schema.FindSchemaColumnByPath("Grantor");
			EntitySchemaColumn accessClientColumn = entity.Schema.FindSchemaColumnByPath("ExternalAccessClient");
			entity.LoadLookupDisplayValues(new EntitySchemaColumn[] { grantorColumn, accessClientColumn });
			string granteeClientId = entity.GetColumnDisplayValue(accessClientColumn);
			var userName = entity.GetColumnDisplayValue(grantorColumn);
			var reason = entity.GetTypedColumnValue<string>("AccessReason");
			var reasonMessage = $"Granted by: {userName}, reason: {reason}";
			ITempAccessProxy tempAccessProxy = GetTempAccessProxy(requiredSettings);
			string errorMessage = null;
			Exception accessGrantException = null;
			try {
				tempAccessProxy.GrantAccess(resourceName, reasonMessage, endOfExpirationDateDay, userId,
					new[] { granteeClientId });
				_log.Info($"Succesfully granted access by userId {userContactId} with reason: {reason}");
			} catch (OAuthIntegration.Exception.ApiServerException ex) {
				errorMessage = new LocalizableString(userConnection.ResourceStorage, "ExternalAccessListener",
					"LocalizableStrings.AccessServerErrorMessage.Value").ToString();
				accessGrantException = ex;
			} catch (OAuthIntegration.Exception.ApiServerConnectivityException ex) {
				var errorTemplate = new LocalizableString(userConnection.ResourceStorage, "ExternalAccessListener",
					"LocalizableStrings.ConnectivityErrorMessage.Value").ToString();
				errorMessage = string.Format(errorTemplate, requiredSettings[IdentityAddressSettingsName]);
				accessGrantException = ex;
			} catch (SecurityException ex) {
				errorMessage = ex.Message;
				accessGrantException = ex;
			} catch (Exception ex) {
				errorMessage = $"Unexpected error during grant access by userId {userContactId}";
				accessGrantException = ex;
			}
			if (accessGrantException != null) {
				e.IsCanceled = true;
				_log.Error($"Error during grant access by userId {userContactId}: {accessGrantException}");
				NotifyClientAboutException(userConnection, accessGrantException);
				throw new GrantExternalAccessException(errorMessage);
			}
		}

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="SystemOperationRestrictedException">Current user session is created using external access.
		/// </exception>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			CheckSystemOperationRestrictedMode(sender);
			base.OnSaving(sender, e);
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="SystemOperationRestrictedException">Current user session is created using external access.
		/// </exception>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckSystemOperationRestrictedMode(sender);
			base.OnDeleting(sender, e);
		}

		#endregion

	}

	#endregion

	#region Class: GrantExternalAccessException

	/// <summary>
	/// Exception thrown while granting external access.
	/// </summary>
	[Serializable]
	public class GrantExternalAccessException : Exception
	{

		#region Constructors: Public

		/// <inheritdoc/>
		public GrantExternalAccessException() {
		}

		/// <inheritdoc/>
		public GrantExternalAccessException(string message) : base(message) {
		}

		/// <inheritdoc/>
		public GrantExternalAccessException(string message, Exception innerException) : base(message, innerException) {
		}

		#endregion

		#region Constructors: Protected

		/// <inheritdoc/>
		protected GrantExternalAccessException(SerializationInfo info, StreamingContext context)
				: base(info, context) {
		}

		#endregion

	}

	#endregion

}

