namespace BPMSoft.Configuration.SSP
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: SspUserCreator

	/// <summary>
	/// Class which creates portal users.
	/// </summary>
	public class SspUserCreator
	{
		#region Delegate: CustomSelectQuery

		protected delegate Select CustomSelectQuery(List<string> emails);

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection {
			get;
		}

		/// <summary>
		/// All entities will be connected ot this Account.
		/// </summary>
		protected Guid AccountId;

		/// <summary>
		/// Class which work with SysAdminUnit<see cref="ISspUserAdministrator"/> class.
		/// </summary>
		protected ISspUserAdministrator SspUserAdministrator { get; set; }

		#endregion

		#region Properties: Public

		private Guid _accountGroupId;
		/// <summary>
		/// Unique-identifier of Group in SysAdminUnit connected to AccountId.
		/// </summary>
		public Guid AccountGroupId => _accountGroupId == Guid.Empty 
				? _accountGroupId = SspUserAdministrator.GetGroupIdByAccountId(AccountId) 
				: _accountGroupId;

		private string _licenseName;
		/// <summary>
		/// Unique-identifier of Group in SysAdminUnit connected to AccountId.
		/// </summary>
		public string LicenseName => _licenseName.IsNullOrEmpty()
			? _licenseName = SspUserAdministrator.GetLicenseName(AccountId)
			: _licenseName;

		/// <summary>
		/// Collection of portal invites, instances of the<see cref="ISspUserInvitation"/> class.
		/// </summary>
		public List<ISspUserInvitation> UsersToCreate;

		#endregion

		#region Constructors: public

		/// <summary>
		/// Initializes a new instance of the <see cref="SspUserCreator"/> class.
		/// </summary>
		public SspUserCreator(UserConnection userConnection, Guid accountId) {
			UsersToCreate = new List<ISspUserInvitation>();
			UserConnection = userConnection;
			SspUserAdministrator = new SspUserAdministrator(userConnection);
			AccountId = accountId;
		}

		#endregion

		#region Methods: Private

		private void CheckContactEmails() {
			UsersToCreate.Where(x => x.ContactId != Guid.Empty && string.IsNullOrEmpty(x.Email)).ForEach(x => {
				x.Success = false;
				x.Error = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SspUserCreator", "LocalizableStrings.ContactHasNoEmail.Value");
			});
		}

		private void SetUserAlreadyExistError(ISspUserInvitation user) {
			user.Error = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"SspUserCreator", "LocalizableStrings.UserAlreadyExist.Value");
			user.Success = false;
		}

		private Select GetContactQuery(List<Guid> contacts) {
			return new Select(UserConnection)
				.Column("c", "Id").As("ContactId")
				.Column("c", "Email")
				.Column("c", "Name")
				.Column("c", "AccountId")
				.Column("sd", "Id").As("SysAdminUnitId")
				.Column("sd", "Name").As("SysAdminUnitName")
				.Column("sd", "PortalAccountId")
				.Column("sd", "ConnectionType")
				.Column("sd", "Active")
				.From("Contact", "c")
				.LeftOuterJoin("SysAdminUnit").As("sd")
				.On("sd", "ContactId").IsEqual("c", "Id")
				.Where("c", "AccountId").IsEqual(Column.Parameter(AccountId))
				.And("c", "Id").In(Column.Parameters(contacts)) as Select;
		}

		private void ReadDataFromQuery(CustomSelectQuery query) {
			List<string> emails = GetEmailsWithoutContact();
			if (emails.Any()) {
				var contactSelectQuery = query(emails);
				using (DBExecutor dbExec = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = contactSelectQuery.ExecuteReader(dbExec)) {
						while (reader.Read()) {
							FillInviteData(reader);
						}
					}
				}
			}
		}

		private void ReadAndFillContactData() {
			List<Guid> contacts = UsersToCreate.Where(x => x.ContactId != Guid.Empty).
				Select(user => user.ContactId).ToList();
			if (contacts.Any()) {
				var contactSelectQuery = GetContactQuery(contacts);
				using (DBExecutor dbExec = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = contactSelectQuery.ExecuteReader(dbExec)) {
						while (reader.Read()) {
							FillInviteData(reader);
						}
					}
				}
			}
		}

		private void FillInviteData(IDataReader reader) {
			string email = reader.GetColumnValue<string>("Email");
			Guid contactId = reader.GetColumnValue<Guid>("ContactId");
			var user = UsersToCreate.Find(x => (string.IsNullOrEmpty(x.Email) 
				? x.ContactId == contactId : x.Email == email) 
					&& x.SysAdminUnitId == Guid.Empty);
			if (user != null) {
				var sysAdminUnitId = reader.GetColumnValue<Guid>("SysAdminUnitId");
				user.ContactId = contactId;
				user.Email = email;
				user.Name = reader.GetColumnValue<string>("Name");
				if (sysAdminUnitId != Guid.Empty) {
					var isPortal = reader.GetColumnValue<bool>("ConnectionType");
					bool isContactConnectedAccount = reader.GetColumnValue<Guid>("AccountId") == AccountId;
					if (!isPortal || !isContactConnectedAccount) {
						SetUserAlreadyExistError(user);
					} else {
						SetSysAdminUnitAndContactInInvite(reader, user);
					}
				}
			}
		}

		private void DeactivatePortalUsersConnectedToOtherOrganization() {
			var usersToDeactivate = UsersToCreate.Where(x => x.SysAdminUnitId != Guid.Empty && x.Success &&
				 x.PortalAccountId != AccountId);
			usersToDeactivate.ForEach(user => SspUserAdministrator
				.ChangeUserActivationStatus(user.SysAdminUnitId, false));
		}
		
		private void ConnectAdminUnitsToPortalAccount() {
			var usersToConnect = UsersToCreate.Where(x => x.SysAdminUnitId != Guid.Empty && x.Success &&
				(x.PortalAccountId == Guid.Empty || x.PortalAccountId == AccountId));
			SspUserAdministrator.BindPortalAccountAndActivateUsersByName(usersToConnect
				.Select(user => user.UserName).ToList(), AccountId);
			SspUserAdministrator.AddUsersToPortalAccountGroup(usersToConnect
				.Select(user => user.SysAdminUnitId).ToList(), AccountGroupId);
			usersToConnect.ForEach(user => SspUserAdministrator
				.CreateSysUserInRole(user.SysAdminUnitId, user.UserRoles));
		}

		private void SetSysAdminUnitAndContactInInvite(IDataReader reader, ISspUserInvitation user) {
			user.ContactId = reader.GetColumnValue<Guid>("ContactId");
			user.PortalAccountId = reader.GetColumnValue<Guid>("PortalAccountId");
			user.SysAdminUnitId = reader.GetColumnValue<Guid>("SysAdminUnitId"); ;
			user.UserName = reader.GetColumnValue<string>("SysAdminUnitName");
			user.IsUserActive = reader.GetColumnValue<bool>("Active");
		}

		private Select CreateContactSelect(List<string> emails) {
			return new Select(UserConnection)
				.Column("cc", "ContactId")
				.Column("cc", "Number").As("Email")
				.Column("sd", "Id").As("SysAdminUnitId")
				.Column("sd", "Name").As("SysAdminUnitName")
				.Column("sd", "PortalAccountId")
				.Column("c", "AccountId")
				.Column("c", "Name")
				.Column("sd", "ConnectionType")
				.Column("sd", "Active")
				.From("ContactCommunication", "cc")
				.InnerJoin("Contact").As("c")
				.On("c", "Id").IsEqual("cc", "ContactId")
				.LeftOuterJoin("SysAdminUnit").As("sd")
				.On("sd", "ContactId").IsEqual("cc", "ContactId")
				.Where("cc", "Number").In(Column.Parameters(emails)) as Select;
		}

		private Select CreateSysAdminUnitQuery(List<string> emails) {
			return new Select(UserConnection)
				.Column("c", "AccountId")
				.Column("c", "Name")
				.Column("sd", "ContactId")
				.Column("sd", "Name").As("SysAdminUnitName")
				.Column("sd", "Name").As("Email")
				.Column("sd", "Id").As("SysAdminUnitId")
				.Column("sd", "ConnectionType")
				.Column("sd", "PortalAccountId")
				.Column("sd", "Active")
				.From("SysAdminUnit", "sd")
				.LeftOuterJoin("Contact").As("c")
				.On("sd", "ContactId").IsEqual("c", "Id")
				.Where("sd", "Name").In(Column.Parameters(emails)) as Select;
		}

		private List<string> GetEmailsWithoutContact() {
			return UsersToCreate.Where(x => x.ContactId == Guid.Empty).Select(user => user.Email).ToList();
		}

		private void CheckUserNames() {
			List<string> emails = UsersToCreate.Where(x => !string.IsNullOrEmpty(x.Email) 
					&& x.SysAdminUnitId == Guid.Empty).Select(user => user.Email).ToList();
			if (emails.Any()) {
				var checkNamesSelectQuery = CreateSysAdminUnitCheckingNamesQuery(emails);
				using (DBExecutor dbExec = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = checkNamesSelectQuery.ExecuteReader(dbExec)) {
						while (reader.Read()) {
							var email =  reader.GetColumnValue<string>("SysAdminUnitName");
							var user = UsersToCreate.Find(x => x.Email == email);
							if (user != null) {
								SetUserAlreadyExistError(user);
							}
						}
					}
				}
			}
		}

		private Select CreateSysAdminUnitCheckingNamesQuery(List<string> emails) {
			return new Select(UserConnection)
				.Column("sd", "Id").As("SysAdminUnitId")
				.Column("sd", "Name").As("SysAdminUnitName")
				.From("SysAdminUnit", "sd")
				.Where("sd", "Name").In(Column.Parameters(emails)) as Select;
		}

		private void CreateUsers() {
			var invitesWithoutUsers = UsersToCreate.Where(x => ((x.SysAdminUnitId == Guid.Empty || (x.SysAdminUnitId != Guid.Empty
				&& (x.PortalAccountId != AccountId && x.PortalAccountId != Guid.Empty))) && x.Success));
			foreach (var invite in invitesWithoutUsers) {
				invite.SysAdminUnitId = SspUserAdministrator.RegisterUser(new SspUserInvite {
					ContactId = invite.ContactId,
					UserName = invite.Email,
					PortalAccountId = AccountId,
					AccountGroupId = AccountGroupId,
					UserRoles = invite.UserRoles,
					LicenseName = LicenseName
				});
				invite.UserName = invite.Email;
			}
		}

		private void CreateContacts() {
			var invitesWithoutContacts = UsersToCreate.Where(x => x.ContactId == Guid.Empty && x.Success);
			foreach (var invite in invitesWithoutContacts) {
				invite.ContactId = SspUserAdministrator.CreateContactByEmail(invite.Email, AccountId);
			}
		}

		private void FindActiveUsersConnectedToOtherOrganization() {
			var usersWithWrongConnection = UsersToCreate.Where(x => x.SysAdminUnitId != Guid.Empty && x.Success &&
				(x.PortalAccountId != Guid.Empty && x.PortalAccountId != AccountId) && x.IsUserActive == true);
			usersWithWrongConnection.ForEach(user => SetUserAlreadyExistError(user));

		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Add portal invite to portal invites collection.
		/// </summary>
		/// <param name="invite">Portal user invite.<see cref="ISspUserInvitation"/></param>
		public void AddInvite(ISspUserInvitation invite) {
			UsersToCreate.Add(invite);
		}

		/// <summary>
		/// Creates portal user which are in PortalInvites property.
		/// </summary>
		public virtual List<ISspUserInvitation> CreateUsersByEmails() {
			ReadDataFromQuery(CreateSysAdminUnitQuery);
			ReadDataFromQuery(CreateContactSelect);
			FindActiveUsersConnectedToOtherOrganization();
			ConnectAdminUnitsToPortalAccount();
			DeactivatePortalUsersConnectedToOtherOrganization();
			CreateContacts();
			CreateUsers();
			return UsersToCreate;
		}

		/// <summary>
		/// Creates portal users by ContactId.
		/// </summary>
		public virtual List<ISspUserInvitation> CreateUsersByContacts() {
			ReadAndFillContactData();
			CheckUserNames();
			ConnectAdminUnitsToPortalAccount();
			DeactivatePortalUsersConnectedToOtherOrganization();
			CheckContactEmails();
			CreateUsers();
			return UsersToCreate;
		}

		#endregion

	}

	#endregion
}
