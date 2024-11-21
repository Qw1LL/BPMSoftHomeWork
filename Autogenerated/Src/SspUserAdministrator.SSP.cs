namespace BPMSoft.Configuration.SSP
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: SspUserAdministrator

	/// <summary>
	/// Class for creating contact and users.
	/// </summary>
	internal class SspUserAdministrator : ISspUserAdministrator
	{

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; }

		private Guid _sspRootGroupId;

		/// <summary>
		/// All portal users group.
		/// </summary>
		protected Guid SspRootGroupId {
			get =>
				_sspRootGroupId != Guid.Empty
					? _sspRootGroupId
					: _sspRootGroupId = UserConnection.GetRootAdminUnitGroupId(UserType.SSP);
			set => _sspRootGroupId = value;
		}

		/// <summary>
		/// SysAdminUtilities class.
		/// </summary>
		protected SysAdminUtilities SysAdminUtilities { get; }

		#endregion

		#region Constructors: public

		/// <summary>
		/// Initializes a new instance of the <see cref="SspUserAdministrator"/> class.
		/// </summary>
		public SspUserAdministrator(UserConnection userConnection) {
			UserConnection = userConnection;
			SysAdminUtilities = new SysAdminUtilities();
		}

		#endregion

		#region Method: Private

		/// <summary>
		/// Creates <see cref="SysAdminUnit"/> record.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="name">User name.</param>
		/// <param name="accountGroupId">Account group identifier.</param>
		/// <returns>User identifier.</returns>
		private Guid CreateUser(Guid contactId, string name, Guid accountGroupId) {
			SysAdminUnit sysAdminUnit = GetNewUserSysAdminUnit(contactId, name, accountGroupId);
			sysAdminUnit.Save();
			return sysAdminUnit.Id;
		}

		private void CreateSysAdminUnitInRole(Guid userId, Guid roleId) {
			var sysAdminUserInRole = new SysAdminUnitInRole(UserConnection.AppConnection.SystemUserConnection);
			sysAdminUserInRole.SetDefColumnValues();
			sysAdminUserInRole.SysAdminUnitId = userId;
			sysAdminUserInRole.SysAdminUnitRoleId = roleId;
			sysAdminUserInRole.Save();
		}

		private void CreateAdminUnitGroups(Guid userId, Guid accountGroupId) {
			CreateSysUserInRole(userId, SspRootGroupId);
			CreateSysUserInRole(userId, accountGroupId);
			CreateSysAdminUnitInRole(userId, SspRootGroupId);
			CreateSysAdminUnitInRole(userId, userId);
			CreateSysAdminUnitInRole(userId, accountGroupId);
		}

		private Collection<string> GetLicPackagesName(SspUserInvite userInfo) {
			if (userInfo.LicenseName.IsNotNullOrEmpty()) {
				return new Collection<string> { userInfo.LicenseName };
			}
			return SysAdminUtilities.GetLicPackageNames(UserConnection, UserType.SSP);
		}

		#endregion

		#region Methods: Protected
		/// <summary>
		/// Get SysAdminUnit object of new user.
		/// </summary>
		/// <param name="contactId">Contact for new user.</param>
		/// <param name="name">Name of system administration object.</param>
		/// <param name="accountGroupId">Id of portal account.</param>
		/// <returns><see cref="SysAdminUnit"/> object of new user.</returns>
		protected virtual SysAdminUnit GetNewUserSysAdminUnit(Guid contactId, string name, Guid accountGroupId) {
			UserConnection systemUserConnection = UserConnection.AppConnection.SystemUserConnection;
			var sysAdminUnit = new SysAdminUnit(systemUserConnection);
			sysAdminUnit.SetDefColumnValues();
			sysAdminUnit.Name = name;
			sysAdminUnit.ContactId = contactId;
			sysAdminUnit.SysAdminUnitTypeValue = (int)SysAdminUnitType.User;
			sysAdminUnit.Active = true;
			sysAdminUnit.ConnectionType = (int)UserType.SSP;
			sysAdminUnit.SysCultureId = SystemSettings.GetValue(UserConnection, "PrimaryCulture", Guid.Empty);
			sysAdminUnit.PortalAccountId = accountGroupId;
			sysAdminUnit.AccountId = accountGroupId;
			int maxPasswordAge = SystemSettings.GetValue(systemUserConnection, "MaxPasswordAge", 0);
			if (maxPasswordAge > 0) {
				sysAdminUnit.PasswordExpireDate = DateTime.UtcNow.AddDays(maxPasswordAge);
			}
			return sysAdminUnit;
		}
		#endregion

		#region Method: Public

		/// <summary>
		/// Creates SysAdminUnit user.
		/// </summary>
		/// <param name="userInfo">New user creation data.</param>
		/// <returns>User identifier.</returns>
		public virtual Guid RegisterUser(SspUserInvite userInfo) {
			Guid userId = CreateUser(userInfo.ContactId, userInfo.UserName, userInfo.PortalAccountId);
			CreateAdminUnitGroups(userId, userInfo.AccountGroupId);
			CreateSysUserInRole(userId, userInfo.UserRoles);
			SysAdminUtilities.ReloadSysAdminUnitCache(UserConnection, userId);
			Collection<string> packageNames = GetLicPackagesName(userInfo);
			if (packageNames != null) {
				SysAdminUtilities.AddUserLicences(UserConnection.AppConnection.SystemUserConnection, userId,
					packageNames);
			}
			return userId;
		}

		/// <summary>
		/// Gets account group identifier.
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>Account group identifier.</returns>
		public virtual Guid GetGroupIdByAccountId(Guid accountId) {
			var sysAdminUnitSelect = new Select(UserConnection).Column("SAU", "Id").From("SysAdminUnit").As("SAU")
				.Where("SAU", "ConnectionType").IsEqual(Column.Const((int)UserType.SSP))
				.And("SAU", "SysAdminUnitTypeValue")
				.IsEqual(Column.Const((int)BPMSoft.Core.DB.SysAdminUnitType.Organisation))
				.And("SAU", "PortalAccountId").IsEqual(Column.Parameter(accountId)) as Select;
			return sysAdminUnitSelect.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Gets organization license name.
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>License name.</returns>
		public string GetLicenseName(Guid accountId) {
			var sysAdminUnitSelect = new Select(UserConnection)
				.Column("OP", "LicenseName")
				.From("SysAdminUnit").As("SAU")
				.InnerJoin("OrganizationProperty").As("OP")
				.On("OP", "SysAdminUnitId").IsEqual("SAU", "Id")
				.Where("SAU", "ConnectionType").IsEqual(Column.Const((int)UserType.SSP))
				.And("SAU", "SysAdminUnitTypeValue")
				.IsEqual(Column.Const((int)BPMSoft.Core.DB.SysAdminUnitType.Organisation))
				.And("SAU", "PortalAccountId").IsEqual(Column.Parameter(accountId)) as Select;
			return sysAdminUnitSelect.ExecuteScalar<string>();
		}

		/// <summary>
		/// Set PortalAccountId to SysAdminUnit record.
		/// </summary>
		/// <param name="adminUnitsToUpdate">SysAdminUnits names collection.</param>
		/// <param name="accountId">PortalAccount which will be connected to the record.</param>
		public void BindPortalAccountAndActivateUsersByName(List<string> adminUnitsToUpdate, Guid accountId) {
			if (adminUnitsToUpdate.Any()) {
				var sysAdminUnitUpdate = new Update(UserConnection, "SysAdminUnit").WithHints(new RowLockHint())
					.Set("PortalAccountId", Column.Parameter(accountId)).Set("Active", Column.Const(true)).Where("Name")
					.In(Column.Parameters(adminUnitsToUpdate)) as Update;
				sysAdminUnitUpdate.Execute();
			}
		}

		/// <summary>
		/// Activate Users by Ids.
		/// </summary>
		/// <param name="adminUnitsToUpdate">SysAdminUnits Ids collection.</param>
		public void ActivateUsersByIds(List<Guid> adminUnitsToUpdate) {
			if (adminUnitsToUpdate.Any()) {
				var sysAdminUnitUpdate = new Update(UserConnection, "SysAdminUnit").WithHints(new RowLockHint())
					.Set("Active", Column.Const(true))
					.Set("ForceChangePassword", Column.Const(false))
					.Where("Id").In(Column.Parameters(adminUnitsToUpdate)) as Update;
				sysAdminUnitUpdate.Execute();
			}
		}

		/// <summary>
		/// Check if SysAdminUnit exist.
		/// </summary>
		/// <param name="name">User name.</param>
		/// <returns>SysAdminUnit identifier.</returns>
		public virtual bool CheckIfUserNotExist(string name) {
			var sysAdminUnitSelect = new Select(UserConnection).Column("SAU", "Id").From("SysAdminUnit").As("SAU")
				.Where("SAU", "ConnectionType").IsEqual(Column.Const((int)UserType.SSP))
				.And("SAU", "SysAdminUnitTypeValue").IsEqual(Column.Const((int)BPMSoft.Core.DB.SysAdminUnitType.User))
				.And("SAU", "Name").IsEqual(Column.Parameter(name)) as Select;
			return sysAdminUnitSelect.ExecuteScalar<Guid>() == Guid.Empty;
		}

		/// <summary>
		/// Creates Contact user.
		/// </summary>
		/// <param name="email">email for creating contact.</param>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>Contact identifier.</returns>
		public virtual Guid CreateContactByEmail(string email, Guid accountId) {
			var contact = UserConnection.EntitySchemaManager.GetInstanceByName("Contact").CreateEntity(UserConnection);
			contact.SetDefColumnValues();
			contact.SetColumnValue("Email", email);
			contact.SetColumnValue("AccountId", accountId);
			contact.SetColumnValue("Name", email.LeftOfRightmostOf("@"));
			contact.SetColumnValue("Confirmed", false);
			contact.Save(false);
			return contact.PrimaryColumnValue;
		}

		/// <summary>
		/// Create role for user.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="userRole">User role.</param>
		public virtual void CreateSysUserInRole(Guid userId, Guid userRole) {
			CreateSysUserInRole(userId, new[] { userRole });
		}

		/// <summary>
		/// Creates roles for user.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="userRoles">User roles.</param>
		public virtual void CreateSysUserInRole(Guid userId, Guid[] userRoles) {
			foreach (Guid userRole in userRoles) {
				EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
				Entity sysUserInRole = tableSchema.CreateEntity(UserConnection);
				Dictionary<string, object> conditions = new Dictionary<string, object> {
					{ "SysUser", userId },
					{ "SysRole", userRole }
				};
				if (!sysUserInRole.FetchFromDB(conditions)) {
					sysUserInRole.SetDefColumnValues();
					sysUserInRole.UseAdminRights = false;
					EntitySchemaColumn userColumn = tableSchema.Columns.GetByName("SysUser");
					EntitySchemaColumn roleColumn = tableSchema.Columns.GetByName("SysRole");
					sysUserInRole.SetColumnValue(userColumn.ColumnValueName, userId);
					sysUserInRole.SetColumnValue(roleColumn.ColumnValueName, userRole);
					sysUserInRole.Save();
				}
			}
		}

		/// <summary>
		/// Delete role for user.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="userRole">User roles.</param>
		public virtual void DeleteSysUserInRole(Guid userId, Guid userRole) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
			Entity sysUserInRole = tableSchema.CreateEntity(UserConnection);
			sysUserInRole.UseAdminRights = false;
			Dictionary<string, object> conditions = new Dictionary<string, object> {
				{ "SysUser", userId },
				{ "SysRole", userRole }
			};
			if (sysUserInRole.FetchFromDB(conditions)) {
				sysUserInRole.Delete();
			}
		}

		/// <summary>
		/// Add Portal account to portal account group
		/// </summary>
		/// <param name="adminUnitsToUpdate">SysAdminUnits id`s collection</param>
		/// <param name="accountGroupId">PortalAccount group which will be connected to the record.</param>
		public void AddUsersToPortalAccountGroup(List<Guid> adminUnitsToUpdate, Guid accountGroupId) {
			foreach (var adminUnit in adminUnitsToUpdate) {
				CreateSysUserInRole(adminUnit, accountGroupId);
				CreateSysAdminUnitInRole(adminUnit, accountGroupId);
			}
		}

		/// <summary>
		/// Changes user activation status.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="isActive">New user activation status.</param>
		public void ChangeUserActivationStatus(Guid userId, bool isActive) {
			var update = new Update(UserConnection, "SysAdminUnit")
				.Set("Active", Column.Parameter(isActive)).Where("Id")
				.IsEqual(Column.Parameter(userId)) as Update;
			update.Execute();
		}

		#endregion

	}

	#endregion

}

