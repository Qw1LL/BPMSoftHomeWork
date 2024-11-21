namespace BPMSoft.Configuration.SSP
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Security;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: SspUserManagementServiceHelper

	/// <summary>
	/// User management helper for working with user roles and invites.
	/// </summary>
	public class SspUserManagementServiceHelper
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="SspUserManagementServiceHelper"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public SspUserManagementServiceHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// instance of the <see cref="SspUserCreator"/> class.
		/// </summary>
		protected SspUserCreator SspUserCreator { get; set; }

		/// <summary>
		/// instance of the <see cref="SspUserInviter"/> class.
		/// </summary>
		protected SspUserInviter SspUserInviter { get; set; }

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; }

		#endregion

		#region Methods: Private

		private Guid GetUsersSspAccount(Guid userId) {
			return GetUsersSspAccounts(new List<Guid>() {
				userId
			}).First();
		}

		private IEnumerable<Guid> GetUsersSspAccounts(List<Guid> userIds) {
			Select select = new Select(UserConnection).Distinct().Column("PortalAccountId").From("SysAdminUnit")
				.Where("Id").In(Column.Parameters(userIds)) as Select;
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(executor)) {
					while (dataReader.Read()) {
						yield return dataReader.GetColumnValue<Guid>("PortalAccountId");
					}
				}
			}
		}

		private Select GetSspLicPackageSelectQuery() {
			return new Select(UserConnection)
					.Column("licPackage", "Id")
					.Column("licPackage", "Name")
					.Column("LicType")
					.From("SysLic").As("lic")
					.InnerJoin("SysLicPackage").As("licPackage")
					.On("lic", "SysLicPackageId")
					.IsEqual("licPackage", "Id")
					.Where(Column.Parameter(DateTime.Now.Date)).IsBetween("StartDate").And("DueDate")
					.And("licPackage", "IsSsp").IsEqual(Column.Parameter(true)) as Select;
		}

		#endregion

		#region Methods: Protected

		protected virtual Select GetAppliedOptionalFuncRolesForUser(List<Guid> userIds) {
			var select = new Select(UserConnection).Column("User", "Id").As("UserId").Column("Role", "Id").As("RoleId")
				.From("SysAdminUnit").As("User").InnerJoin("SysAdminUnit").As("PortalAccountRole")
				.On("User", "PortalAccountId").IsEqual("PortalAccountRole", "PortalAccountId")
				.InnerJoin("SysUserInRole").As("UserRoles").On("User", "Id").IsEqual("UserRoles", "SysUserId")
				.InnerJoin("SysAdminUnit").As("Role").On("Role", "Id").IsEqual("UserRoles", "SysRoleId")
				.InnerJoin("OptionalFuncSspRole").As("OptionalRoles").On("OptionalRoles", "FuncRoleId")
				.IsEqual("Role", "Id").And("OptionalRoles", "OrgRoleId").IsEqual("PortalAccountRole", "ParentRoleId")
				.Where("PortalAccountRole", "ConnectionType").IsEqual(Column.Const(1))
				.And("PortalAccountRole", "SysAdminUnitTypeValue").IsEqual(Column.Const(0))
				.And("Role", "SysAdminUnitTypeValue").IsEqual(Column.Const(6)).And("Role", "ConnectionType")
				.IsEqual(Column.Const(1)).And("User", "Id").In(Column.Parameters(userIds)) as Select;
			return select;
		}

		protected virtual Select GetSspAccountInfoSelect(Guid userId) {
			var select = new Select(UserConnection).Column("UserAdminUnit", "PortalAccountId")
				.Column("SspAccountAdminUnit", "Id").As("SspAccountAdminUnitId").From("SysAdminUnit")
				.As("UserAdminUnit").LeftOuterJoin("SysAdminUnit").As("SspAccountAdminUnit")
				.On("UserAdminUnit", "PortalAccountId").IsEqual("SspAccountAdminUnit", "PortalAccountId")
				.And("SspAccountAdminUnit", "ConnectionType").IsEqual(Column.Const(1))
				.And("SspAccountAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Const(0))
				.Where("UserAdminUnit", "Id").IsEqual(Column.Parameter(userId)) as Select;
			return select;
		}

		protected virtual Select GetSspAccountOptionalFuncRolesSelect(Guid sspAccountId) {
			var select = new Select(UserConnection).Column("OFSR", "FuncRoleId").As("RoleId").Column("SAUFR", "Name")
				.As("RoleName").From("SysAdminUnit").As("SAU").InnerJoin("OptionalFuncSspRole").As("OFSR")
				.On("SAU", "ParentRoleId").IsEqual("OFSR", "OrgRoleId").InnerJoin("SysAdminUnit").As("SAUFR")
				.On("SAUFR", "Id").IsEqual("OFSR", "FuncRoleId").Where("SAU", "ConnectionType").IsEqual(Column.Const(1))
				.And("SAU", "SysAdminUnitTypeValue").IsEqual(Column.Const(0)).And("SAU", "PortalAccountId")
				.IsEqual(Column.Parameter(sspAccountId)) as Select;
			return select;
		}

		protected virtual Select GetRolesAvailableAsParentRoleSelect() {
			var select = new Select(UserConnection).Column("SAU", "Id").As("RoleId").Column("SAU", "Name")
				.As("RoleName").From("SysAdminUnit").As("SAU")
				.Where("SAU", "ConnectionType").IsEqual(Column.Const(1))
				.And("SAU", "SysAdminUnitTypeValue").IsEqual(Column.Const(0)).And("SAU", "PortalAccountId")
				.IsNull() as Select;
			return select;
		}

		protected virtual void CheckValidityUserAccountData(List<Guid> usersAccounts) {
			if (UserConnection is SSPUserConnection) {
				if (usersAccounts.Count != 1) {
					throw new SecurityException();
				}
				Guid currentUserSspAccount = GetUsersSspAccount(UserConnection.CurrentUser.Id);
				if (!usersAccounts.First().Equals(currentUserSspAccount)) {
					throw new SecurityException();
				}
			}
		}

		protected virtual Dictionary<Guid, string> GetRoleDictionaryFromQuery(Select rolesSelect) {
			Dictionary<Guid, string> rolesList = new Dictionary<Guid, string>();
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = rolesSelect.ExecuteReader(executor)) {
					while (dataReader.Read()) {
						rolesList[dataReader.GetColumnValue<Guid>("RoleId")] =
							dataReader.GetColumnValue<string>("RoleName");
					}
				}
			}
			return rolesList;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Apply roles for users.
		/// </summary>
		/// <param name="usersInRoles">List of User-Role pairs with role application flag.</param>
		public void ApplyOptionalFuncRolesForUsers(List<UserInRolePair> usersInRoles) {
			UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
			List<Guid> usersAccounts = GetUsersSspAccounts(usersInRoles.Select(uir => uir.UserId).ToList()).ToList();
			CheckValidityUserAccountData(usersAccounts);
			var optionalRolesList = GetOptionalFuncRolesList(usersAccounts.First());
			if (usersInRoles.Any(uir => !optionalRolesList.ContainsKey(uir.RoleId))) {
				throw new SecurityException();
			}
			SspUserAdministrator sspAdministrator = new SspUserAdministrator(UserConnection);
			usersInRoles.ForEach(uir => {
				if (uir.IsRoleApplied) {
					sspAdministrator.CreateSysUserInRole(uir.UserId, uir.RoleId);
				} else {
					sspAdministrator.DeleteSysUserInRole(uir.UserId, uir.RoleId);
				}
			});
		}

		/// <summary>
		/// Checks if the roles <see cref="roles"/> match the available account roles.
		/// </summary>
		/// <param name="roles">Roles to check.</param>
		/// <param name="sspAccountId">Identifier of portal account to get data for.</param>
		/// <exception cref="SecurityException">Throws when roles <see cref="roles"/>
		/// do not match available roles for the account <see cref="sspAccountId"/></exception>
		public void CheckCanAddRoles(Guid[] roles, Guid sspAccountId) {
			if (roles == null) {
				return;
			}
			Guid[] availableRoles = GetOptionalFuncRolesList(sspAccountId).Keys.ToArray();
			var result = roles.Intersect(availableRoles);
			if (result.Count() != roles.Length) {
				throw new SecurityException();
			}
		}

		/// <summary>
		/// Check portal account group existence.
		/// </summary>
		/// <param name="accountId">Account which must be checked.</param>
		public bool CheckIfAccountGroupExist(Guid accountId) {
			var sspUserInvitation = SspUserCreator ?? new SspUserCreator(UserConnection, accountId);
			return sspUserInvitation.AccountGroupId != Guid.Empty;
		}

		/// <summary>
		/// Get enabled functional roles from optional roles list for ssp user.
		/// </summary>
		/// <param name="userIds">Ids of portal account to get data for.</param>
		public List<UserInRolePair> GetEnabledFuncRolesForUser(List<Guid> userIds) {
			UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
			List<Guid> usersAccounts = GetUsersSspAccounts(userIds).ToList();
			CheckValidityUserAccountData(usersAccounts);
			Dictionary<Guid, string> optionalFuncRolesList = GetOptionalFuncRolesList(usersAccounts.First());
			var rolesSelect = GetAppliedOptionalFuncRolesForUser(userIds);
			var optionalRoles = new List<(Guid UserId, Guid RoleId)>();
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = rolesSelect.ExecuteReader(executor)) {
					while (dataReader.Read()) {
						optionalRoles.Add((UserId: dataReader.GetColumnValue<Guid>("UserId"),
							RoleId: dataReader.GetColumnValue<Guid>("RoleId")));
					}
				}
			}
			List<UserInRolePair> result = new List<UserInRolePair>();
			foreach (var userId in userIds) {
				foreach (Guid funcRole in optionalFuncRolesList.Keys) {
					result.Add(new UserInRolePair() {
						UserId = userId,
						RoleId = funcRole,
						IsRoleApplied = optionalRoles.Any(r => r.RoleId == funcRole && r.UserId == userId)
					});
				}
			}
			return result;
		}

		/// <summary>
		/// Get optional functional roles for ssp account.
		/// </summary>
		/// <param name="sspAccountId">Id of portal account to get data for.</param>
		public Dictionary<Guid, string> GetOptionalFuncRolesList(Guid sspAccountId) {
			var rolesSelect = GetSspAccountOptionalFuncRolesSelect(sspAccountId);
			return GetRoleDictionaryFromQuery(rolesSelect);
		}

		/// <summary>
		/// Get roles available as parent role when Organization creating.
		/// </summary>
		public Dictionary<Guid, string> GetRolesAvailableAsParentRole() {
			var rolesSelect = GetRolesAvailableAsParentRoleSelect();
			return GetRoleDictionaryFromQuery(rolesSelect);
		}

		/// <summary>
		/// Get information about portal account.
		/// </summary>
		/// <param name="userId">User of portal account to get data for.</param>
		public Dictionary<string, object> GetSspAccountInfo(Guid userId) {
			var infoSelect = GetSspAccountInfoSelect(userId);
			Dictionary<string, object> sspAccountInfo = new Dictionary<string, object>();
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = infoSelect.ExecuteReader(executor)) {
					if (dataReader.Read()) {
						sspAccountInfo["PortalAccountId"] = dataReader.GetColumnValue<Guid>("PortalAccountId");
						sspAccountInfo["SspAccountAdminUnitId"] =
							dataReader.GetColumnValue<Guid>("SspAccountAdminUnitId");
					}
				}
			}
			return sspAccountInfo;
		}

		/// <summary>
		/// Creates portal users by emails.
		/// </summary>
		/// <param name="request">Service request.</param>
		/// <returns>Information about users created by email.</returns>
		public List<ISspUserInvitation> CreateUsersByEmails(SspUserManagementServiceRequest request) {
			var emails = request.Emails.Split(' ', ',', ';');
			var sspUserCreator = SspUserCreator ?? new SspUserCreator(UserConnection, request.AccountId);
			foreach (var email in emails) {
				if (email.Trim() != "") {
					sspUserCreator.AddInvite(new SspUserInvite {
						Email = email,
						UserRoles = request.UserRoles
					});
				}
			}
			return sspUserCreator.CreateUsersByEmails();
		}

		/// <summary>
		/// Create portal user by ContactIds.
		/// </summary>
		/// <param name="request">Service request.</param>
		/// <returns>Information about created users.</returns>
		public List<ISspUserInvitation> CreateUsersByContactIds(CreateUsersByContactsServiceRequest request) {
			var sspUserCreator = SspUserCreator ?? new SspUserCreator(UserConnection, request.AccountId);
			foreach (var contactId in request.ContactIds) {
				sspUserCreator.AddInvite(new SspUserInvite {
					ContactId = contactId,
					UserRoles = request.UserRoles
				});
			}
			return sspUserCreator.CreateUsersByContacts();
		}

		/// <summary>
		/// Invite portal user by SysAdminUnitUIds.
		/// </summary>
		/// <param name="request">Service request.</param>
		/// <returns>Information about the invitation of users.</returns>
		public List<ISspUserInvitation> InviteUsers(InviteServiceRequest request) {
			List<Guid> usersAccounts = GetUsersSspAccounts(request.SysAdminUnitIds).ToList();
			CheckValidityUserAccountData(usersAccounts);
			var sspUserInviter = SspUserInviter ?? new SspUserInviter(UserConnection);
			foreach (var sysAdminUnitIdId in request.SysAdminUnitIds) {
				sspUserInviter.AddInvite(new SspUserInvite {
					SysAdminUnitId = sysAdminUnitIdId
				});
			}
			return sspUserInviter.InviteUsers();
		}

		/// <summary>
		/// Changes user activation status.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="isActive">New user activation status.</param>
		public void ChangeUserActivationStatus(Guid userId, bool isActive) {
			new SspUserAdministrator(UserConnection).ChangeUserActivationStatus(userId, isActive);
		}

		/// <summary>
		/// Gets names of ssp licenses.
		/// </summary>
		/// <returns>List of ssp licenses names.</returns>
		public List<string> GetSspLicNames() {
			Select select = GetSspLicPackageSelectQuery();
			return select.ExecuteEnumerable(reader => reader.GetColumnValue<string>("Name")).ToList();
		}

		/// <summary>
		/// Returns name of default ssp license.
		/// </summary>
		/// <returns>Default license name.</returns>
		public string GetDefaultSspLicName() {
			return UserConnection.AppConnection.SspUserRegistrationLicPackage;
		}

		#endregion

	}

	#endregion

}

