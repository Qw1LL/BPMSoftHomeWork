namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: ExternalAccessAppListener

	/// <inheritdoc/>
	public class ExternalAccessAppListener : AppEventListenerBase
	{

		#region Fields: Private

		private static readonly Guid _externalAccessSchemaUId = new Guid("F3858E46-EA38-412E-AF4A-2011F08718AE");

		#endregion

		#region Methods: Private

		private Guid GetExternalAccessGrantor(UserConnection userConnection, Guid externalAccessId) {
			var select = (Select)new Select(userConnection)
				.Cols("GrantorId")
				.From("ExternalAccess", "ea")
				.Where("ea", "Id").IsEqual(Column.Parameter(externalAccessId));
			select.ExecuteSingleRecord(reader => reader.GetColumnValue<Guid>("GrantorId"), out var grantorId);
			return grantorId;
		}

		private UserConnection GetUserConnection() {
			var httpContextAccessor = ClassFactory.Get<IHttpContextAccessor>();
			var httpContext = httpContextAccessor.GetInstance();
			return httpContext?.Session["UserConnection"] as UserConnection;
		}

		private void CreateRemindingForExternalAccess(string lczStringName) {
			UserConnection userConnection = GetUserConnection();
			if (userConnection == null) {
				return;
			}
			var externalAccessId = userConnection.ExternalAccessId;
			if (externalAccessId.IsEmpty()) {
				return;
			}
			if (!SysSettings.GetValue(userConnection, "ExternalAccessSessionNotificationEnabled", false)) {
				return;
			}
			Guid externalAccessGrantorId = GetExternalAccessGrantor(userConnection, externalAccessId);
			if (externalAccessGrantorId.IsEmpty()) {
				return;
			}
			string description = new LocalizableString(userConnection.ResourceStorage, "ExternalAccessAppListener",
				$"LocalizableStrings.{lczStringName}.Value");
			var remindingUtilities = ClassFactory.Get<RemindingUtilities>();
			remindingUtilities.CreateReminding(userConnection, new RemindingConfig(_externalAccessSchemaUId) {
				AuthorId = userConnection.CurrentUser.ContactId,
				ContactId = externalAccessGrantorId,
				SubjectId = externalAccessId,
				Description = description
			});
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override void OnSessionStart(AppEventContext context) {
			CreateRemindingForExternalAccess("ExternalAccessSessionStartedMessage");
		}

		/// <inheritdoc/>
		public override void OnSessionEnd(AppEventContext context) {
			CreateRemindingForExternalAccess("ExternalAccessSessionEndedMessage");
		}

		#endregion

	}

	#endregion

}

