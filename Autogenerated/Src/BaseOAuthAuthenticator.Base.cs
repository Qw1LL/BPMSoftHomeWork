namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Social.OAuth;

	#region Class: BaseOAuthAuthenticator

	/// <summary>
	/// Class provides base OAuth authentification flow methods for existing synchronizations.
	/// </summary>
	public abstract class BaseOAuthAuthenticator : OAuthAuthenticator
	{

		#region Fields: Private

		/// <summary>
		/// Saved <see cref="MailboxSyncSettings"/> instance unique identifier. 
		/// Filled in <see cref="CreateNewMailboxSyncSettings"/> method.
		/// </summary>
		private Guid _mailboxSyncSettingsId;

		/// <summary>
		/// Saved <see cref="MailboxSyncSettings.SysAdminUnit"/> column value. 
		/// Filled in <see cref="GetMailboxOwner"/> method.
		/// </summary>
		private Guid _mailboxOwnerId = Guid.Empty;

		#endregion

		#region Constructors: Public

		/// <summary><see cref="OAuthAuthenticator(UserConnection)"/></summary>
		public BaseOAuthAuthenticator(UserConnection userConnection) : base(userConnection) {
		}

		/// <summary><see cref="OAuthAuthenticator()"/></summary>
		public BaseOAuthAuthenticator() : base() {
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates mailbox check select body.
		/// </summary>
		/// <param name="columnPath">Selecting column path string.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		private Select GetCheckMailboxSelectBody(string columnPath) {
			return new Select(UserConnection).Top(1)
				.Column(columnPath)
				.From("MailboxSyncSettings");
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks that mailbox already exists in bpmcrm.
		/// <see cref="MailboxSyncSettings.SenderEmailAddress"/> used for validation.
		/// </summary>
		/// <param name="credentials"><see cref="OAuthUserCredentials"/> instance.</param>
		/// <returns> <see cref="MailboxSyncSettings.SysAdminUnitId"/> column value when mailbax exists, 
		/// <c>Guid.Empty</c> otherwise.</returns>
		protected virtual Guid GetMailboxOwner(OAuthUserCredentials credentials) {
			if (_mailboxOwnerId.IsNotEmpty()) {
				return _mailboxOwnerId;
			}
			var existingMailboxSelect = GetCheckMailboxSelectBody("SysAdminUnitId")
				.Where("SenderEmailAddress").IsEqual(Column.Parameter(credentials.UserLogin)) as Select;
			_mailboxOwnerId = existingMailboxSelect.ExecuteScalar<Guid>();
			return _mailboxOwnerId;
		}

		/// <summary>
		/// Sets existing user mailbox identifier to <see cref="_mailboxSyncSettingsId"/> field.
		/// When field already set, value would not be changed.
		/// </summary>
		/// <param name="credentials"><see cref="OAuthUserCredentials"/> instance.</param>
		protected virtual void SetExistingMailboxId(OAuthUserCredentials credentials) {
			if (_mailboxSyncSettingsId.IsNotEmpty()) {
				return;
			}
			var existingMailboxSelect = GetCheckMailboxSelectBody("Id")
				.Where("SenderEmailAddress").IsEqual(Column.Parameter(credentials.UserLogin))
				.And("SysAdminUnitId").IsEqual(Column.Parameter(UserConnection.CurrentUser.Id)) as Select;
			_mailboxSyncSettingsId = existingMailboxSelect.ExecuteScalar<Guid>();
			
		}

		/// <summary>
		/// Checks if current user has default mailbox for send.
		/// </summary>
		/// <returns><c>True</c> if current user has default mailbox for send, <c>false</c> otherwise.</returns>
		protected virtual bool CheckDefaultMailboxExists() {
			var existingMailboxSelect = GetCheckMailboxSelectBody("Id")
				.Where("IsDefault").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitId").IsEqual(Column.Parameter(UserConnection.CurrentUser.Id)) as Select;
			return existingMailboxSelect.ExecuteScalar<Guid>().IsNotEmpty();
		}

		/// <summary>
		/// Creates a new <see cref="BPMSoft.Configuration.MailboxSyncSettings"/> record in the DB.
		/// </summary>
		/// <param name="userLogin">User OAuth login.</param>
		/// <param name="tokenStorageId">OAuth token storage identifier.</param>
		/// <returns><see cref="Guid"/> idenifier of <see cref="BPMSoft.Configuration.MailboxSyncSettings"/>.</returns>
		protected virtual Guid CreateNewMailboxSyncSettings(string userLogin, Guid tokenStorageId) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
			Entity mailbox = entitySchema.CreateEntity(UserConnection);
			mailbox.SetDefColumnValues();
			mailbox.SetColumnValue("MailboxName", userLogin);
			mailbox.SetColumnValue("UserName", userLogin);
			mailbox.SetColumnValue("SenderEmailAddress", userLogin);
			mailbox.SetColumnValue("MailServerId", new Guid((string)State["MailServerId"]));
			mailbox.SetColumnValue("OAuthTokenStorageId", tokenStorageId);
			mailbox.SetColumnValue("AutomaticallyAddNewEmails", true);
			mailbox.SetColumnValue("EnableMailSynhronization", false);
			mailbox.SetColumnValue("LoadAllEmailsFromMailBox", true);
			mailbox.SetColumnValue("SendEmailsViaThisAccount", true);
			mailbox.SetColumnValue("IsDefault", !CheckDefaultMailboxExists());
			mailbox.Save();
			_mailboxSyncSettingsId = mailbox.PrimaryColumnValue;
			return mailbox.PrimaryColumnValue;
		}

		/// <summary>
		///<see cref="OAuthAuthenticator.ProcessSavingCredentialsFinish(Guid)"/>
		/// </summary>
		protected override void ProcessSavingCredentialsFinish(Guid tokenStorageId) {
			if (_mailboxSyncSettingsId.IsNotEmpty()) {
				EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
				Entity mailbox = entitySchema.CreateEntity(UserConnection);
				if (mailbox.FetchFromDB(_mailboxSyncSettingsId) && mailbox.GetTypedColumnValue<Guid>("OAuthTokenStorageId").IsEmpty()
						&& tokenStorageId.IsNotEmpty()) {
					mailbox.SetColumnValue("OAuthTokenStorageId", tokenStorageId);
					mailbox.Save();
				}
			}
		}

		/// <summary>
		/// Create a new <see cref="BPMSoft.Configuration.ContactCommunication"/> record for the specific OAuth user login.
		/// </summary>
		/// <param name="userLogin">OAuth user login.</param>
		protected virtual void CreateNewContactCommunications(string userLogin) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactCommunication");
			Entity contactCommunication = entitySchema.CreateEntity(UserConnection);
			if (contactCommunication.FetchFromDB(new Dictionary<string, object> {
					{ "Number", userLogin },
					{ "CommunicationType", CommunicationTypeConsts.EmailId},
					{ "Contact", UserConnection.CurrentUser.ContactId}})) {
				return;
			}
			contactCommunication.SetDefColumnValues();
			contactCommunication.SetColumnValue("CommunicationTypeId", CommunicationTypeConsts.EmailId);
			contactCommunication.SetColumnValue("ContactId", UserConnection.CurrentUser.ContactId);
			contactCommunication.SetColumnValue("Number", userLogin);
			contactCommunication.Save();
		}

		/// <summary>
		/// Returns mailbox synchronization job interval from system settings.
		/// </summary>
		/// <returns>Mailbox synchronization job interval.</returns>
		protected virtual int GetSyncInterval() {
			return BPMSoft.Core.Configuration.SysSettings.GetValue<int>(UserConnection, "MailboxSyncInterval", 1);
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.GetSuccessResultObject"/>
		/// </summary>
		protected override JObject GetSuccessResultObject(OAuthUserCredentials credentials) {
			var mailServerId = new Guid((string)State["MailServerId"]);
			return new JObject {
				{ "SenderEmailAddress", credentials.UserLogin },
				{ "MailBoxServerId", mailServerId},
				{ "MailboxSyncSettingsId", _mailboxSyncSettingsId.ToString()},
				{ "MailboxSyncInterval", GetSyncInterval()},
				{ "AutomaticallyAddNewEmails", true },
				{ "AllowEmailDownloading", GetAllowEmailDownloading(mailServerId)},
				{ "AddMode", GetIsAddingMailboxSyncSettings()}
			};
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.SaveCredentials"/> 
		/// </summary>
		/// <remarks>Throws <see cref="InvalidObjectStateException"/> when <paramref name="credentials"/> contains
		/// existing mailbox credentials.</remarks>
		protected override void SaveCredentials(OAuthUserCredentials credentials) {
			Guid ownerId = GetMailboxOwner(credentials);
			if (ownerId.IsNotEmpty() && !ownerId.Equals(UserConnection.CurrentUser.Id)) {
				throw new InvalidObjectStateException(string.Format("Mailbox {0} already exists!", 
					credentials.UserLogin));
			}
			base.SaveCredentials(credentials);
		}

		/// <summary>
		/// <see cref="OAuthAuthenticator.ValidateCredentials"/>
		/// </summary>
		protected override bool ValidateCredentials(OAuthUserCredentials credentials) {
			Guid ownerId = GetMailboxOwner(credentials);
			bool currentUserMailbox = ownerId.Equals(UserConnection.CurrentUser.Id);
			if (currentUserMailbox) {
				SetExistingMailboxId(credentials);
			}
			return !currentUserMailbox;
		}

		/// <summary>
		/// Checks is related <see cref="MailServer"/> allows email downloading.
		/// </summary>
		/// <param name="mailServerId">Mail server unique identifier.</param>
		/// <returns><c>True</c> if mail server allows email downloading. Otherwise returns <c>false</c>.</returns>
		protected bool GetAllowEmailDownloading(Guid mailServerId) {
			var select = new Select(UserConnection).Top(1)
				.Column("AllowEmailDownloading")
				.From("MailServer")
				.Where("Id").IsEqual(Column.Parameter(mailServerId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		/// <summary>
		/// Checks is current <see cref="MailboxSyncSettings"/> is adding.
		/// </summary>
		/// <returns><c>True</c> if current mailbox is adding. Otherwise returns <c>false</c>.</returns>
		protected bool GetIsAddingMailboxSyncSettings() {
			var select = new Select(UserConnection).Top(1)
				.Column("ErrorCodeId")
				.From("MailboxSyncSettings")
				.Where("Id").IsEqual(Column.Parameter(_mailboxSyncSettingsId)) as Select;
			var errorCodeId = select.ExecuteScalar<Guid>();
			return errorCodeId.IsEmpty();
		}

		#endregion

	}

	#endregion

}
