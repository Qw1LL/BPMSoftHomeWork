namespace BPMSoft.Configuration.LDAP
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Linq;
	using System.Text;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.OrgStructure;
	using BPMSoft.Web.Common;
	
	#region class : LDAPLicenseInfo

	public class LDAPLicenseInfo
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public List<string> MissingLicenses { get; set; }
	}
	
	#endregion

	#region Class: SyncWithLDAPProcessHelper

	public class SyncWithLDAPProcessHelper
	{

		#region Fields: Private

		private static readonly object _lockObject = new object();
		private readonly UserConnection _userConnection;
		private readonly Guid _allEmployeesGroupId = new Guid("{A29A3BA5-4B0D-DE11-9A51-005056C00008}");
		private readonly Guid _sspUsersGroupId = new Guid("{720B771C-E7A7-4F31-9CFB-52CD21C3739F}");
		private readonly ILog _log = LogManager.GetLogger("LDAP");
		private List<string> _availableLicenseNames;
		private List<LDAPLicenseInfo> _usersWithoutLicenses;
		private List<string> _systemSettingLicenseNames;

		#endregion
		
		#region Properties: Protected

		/// <summary>
		/// Gets IOrgStructureManager instance.
		/// </summary>
		protected IOrgStructureManager OrgStructureManager { get; }

		#endregion

		#region Constructors: Public

		public SyncWithLDAPProcessHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_usersWithoutLicenses = new List<LDAPLicenseInfo>();
			OrgStructureManager = new OrgStructureManager(_userConnection);
		}

		#endregion

		#region Methods: Private

		private DateTime? GetMinModifiedDateOfNewUsers() {
			var getMinModifiedDateOfNewUsers = (Select)new Select(_userConnection)
				.Column(Func.Min("ModifiedOn"))
				.From("SysLDAPSynchUser")
				.Where().Not().Exists(new Select(_userConnection)
					.Column(Column.Const(1))
					.From("SysAdminUnit")
					.Where("SysAdminUnit", "LDAPEntryId").IsEqual("SysLDAPSynchUser", "Id")
				);
			DateTime result = getMinModifiedDateOfNewUsers.ExecuteScalar<DateTime>();
			return (result == DateTime.MinValue) ? default(DateTime?) : result;
		}

		private void CheckUsersInGroup(LdapGroup group, Guid groupId, Guid syncId, out DateTime? minModifiedDateOfNewUser) {
			try {
				int usersCount;
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					usersCount = ldapUtils.InsertMembersOfGroupToTable(group, syncId);
				}

				var ldapUsersInGroupSubSelect =
					new Select(_userConnection)
						.Column("Id")
					.From("SysLDAPSynchUser")
					.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId");
				if (syncId.IsNotEmpty()) {
					ldapUsersInGroupSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				var deleteRoles =
					new Delete(_userConnection)
					.From("SysUserInRole")
					.Where("SysRoleId").IsEqual(Column.Parameter(groupId))
					.And().Exists(
						new Select(_userConnection)
							.Column("Id")
						.From("SysAdminUnit")
						.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
						.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
						.And().Not().Exists(ldapUsersInGroupSubSelect) as Select);
				var operationsCount = deleteRoles.Execute();
				_log.InfoFormat("SyncID: {2}. {1} user(s) removed from folder {0}", group.Name, operationsCount, syncId);
				if (usersCount < 1) {
					minModifiedDateOfNewUser = DateTime.MaxValue;
					return;
				}
				var insertRoles =
					new InsertSelect(_userConnection)
					.Into("SysUserInRole")
						.Set("CreatedOn", "ModifiedOn", "SysRoleId", "SysUserId")
					.FromSelect(
						new Select(_userConnection)
							.Column(Column.Parameter(DateTime.Now))
							.Column(Column.Parameter(DateTime.Now))
							.Column(Column.Parameter(groupId))
							.Column("Id")
						.From("SysAdminUnit")
						.Where().Not().Exists(
							new Select(_userConnection)
								.Column("Id")
							.From("SysUserInRole").As("ur")
							.Where("ur", "SysUserId").IsEqual("SysAdminUnit", "Id")
							.And("ur", "SysRoleId").IsEqual(Column.Parameter(groupId)) as Select)
						.And().Exists(ldapUsersInGroupSubSelect)
						.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User)));
				operationsCount = insertRoles.Execute();
				_log.InfoFormat("SyncID: {2}. {1} user(s) added to folder {0}", group.Name, operationsCount, syncId);
				var manager = _userConnection.EntitySchemaManager;
				var query = new EntitySchemaQuery(manager, "LDAPElement") {
					UseAdminRights = false
				};
				var primaryColumnName = query.AddColumn(query.RootSchema.GetPrimaryColumnName()).Name;
				query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, "LDAPEntryId", group.Id));
				query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Type", (int)SysAdminUnitType.User));
				var collection = query.GetEntityCollection(_userConnection);
				if (collection.Any()) {
					var ldapGroupId = collection[0].GetTypedColumnValue<Guid>(primaryColumnName);
					var ldapUsersSubSelect =
						new Select(_userConnection)
							.Column("Id")
						.From("SysLDAPSynchUser")
						.Where("SysLDAPSynchUser", "Id").IsEqual("LDAPElement", "LDAPEntryId");
					if (syncId.IsNotEmpty()) {
						ldapUsersSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
					}
					var deleteLdapGroup =
						new Delete(_userConnection)
						.From("LDAPUserInLDAPGroup")
						.Where("LDAPGroupId").IsEqual(Column.Parameter(ldapGroupId))
						.And().Exists(
							new Select(_userConnection).
								Column("Id")
							.From("LDAPElement")
							.Where("LDAPUserInLDAPGroup", "LDAPUserId").IsEqual("LDAPElement", "Id")
							.And("LDAPElement", "Type").IsEqual(Column.Const((int)SysAdminUnitType.User))
							.And().Not().Exists(ldapUsersSubSelect));
					deleteLdapGroup.Execute();

					var insertSelectGroup = new InsertSelect(_userConnection)
					.Into("LDAPUserInLDAPGroup")
					.Set("CreatedOn", "ModifiedOn", "LDAPGroupId", "LDAPUserId")
					.FromSelect(new Select(_userConnection)
						.Column(Column.Parameter(DateTime.Now))
						.Column(Column.Parameter(DateTime.Now))
						.Column(Column.Parameter(ldapGroupId))
						.Column("Id")
						.From("LDAPElement")
						.Where().Not().Exists(new Select(_userConnection)
							.Column("Id")
							.From("LDAPUserInLDAPGroup").As("ug")
							.Where("ug", "LDAPUserId").IsEqual("LDAPElement", "Id")
							.And("ug", "LDAPGroupId").IsEqual(Column.Parameter(ldapGroupId)) as Select)
						.And().Exists(ldapUsersSubSelect)
						.And("LDAPElement", "Type").IsEqual(Column.Const((int)SysAdminUnitType.User)));
					insertSelectGroup.Execute();
				}

				minModifiedDateOfNewUser = GetMinModifiedDateOfNewUsers();
				if (minModifiedDateOfNewUser.HasValue) {
					_log.InfoFormat("SyncID: {2}. Minimal date of new users in group {0}: {1}", group.Name,
						minModifiedDateOfNewUser.Value, syncId);
				} else {
					_log.InfoFormat("SyncID: {1}. Group {0} doesn't have a new users", group.Name, syncId);
				}
			} finally {
				var delete = new Delete(_userConnection)
					.From("SysLDAPSynchUser");
				if (syncId.IsNotEmpty()) {
					delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				delete.Execute();
			}
		}

		private void AddLicForUser(Entity user) {
			string licenseNames = SysSettings.GetValue(_userConnection, "LdapUserLicPackages", string.Empty);
			var licenses = licenseNames.IsNullOrWhiteSpace() ? null : new Collection<string>(licenseNames.Split(';'));
			var grantedLicenses = _userConnection.LicHelper.AddUserAvailableLicences(user.PrimaryColumnValue, licenses);
			var missingLicenses = GetMissingLicenses(grantedLicenses, licenses);
			if (missingLicenses.Any()) {
				if (_usersWithoutLicenses.Count == 0) {
					_log.Warn(new LocalizableString(_userConnection.Workspace.ResourceStorage,
						"SyncWithLDAPProcessHelper","LocalizableStrings.LDAPLicenseLog.Value"));
				}
				LDAPLicenseInfo userWithMissingLicenses = GetUserWithMissingLicenses(user, missingLicenses);
				_usersWithoutLicenses.Add(userWithMissingLicenses);
				string logMessage = GetUserWithMissingLicensesLogMessage(user, missingLicenses);
				_log.Warn(logMessage);
			}
		}

		private List<string> GetMissingLicenses(Collection<Guid> grantedLicenses, IEnumerable<string> licenses) {
			var grantedLicenseNames = GetGrantedLicenseNames(grantedLicenses);
			var availableLicenseNames = licenses == null ? GetAvailableLicenseNames() : GetSystemSettingLicenseNames(licenses);
			var missingLicenses = GetMissingLicenses(grantedLicenseNames, availableLicenseNames);
			return missingLicenses;
		}

		private LDAPLicenseInfo GetUserWithMissingLicenses(Entity user, List<string> licenses) {
			var userName = user.GetTypedColumnValue<string>("Name");
			var result = new LDAPLicenseInfo {
				UserId = user.PrimaryColumnValue,
				UserName = userName,
				MissingLicenses = licenses
			};
			return result;
		}

		private IEnumerable<string> GetSystemSettingLicenseNames(IEnumerable<string> licenses) {
			if (!_systemSettingLicenseNames.IsNullOrEmpty()) {
				return _systemSettingLicenseNames;
			}
			var licenseNames = new List<string>();
			IEnumerable<QueryParameter> names =
				licenses.Select(name => new QueryParameter(name)).ToList();
			var select =
				new Select(_userConnection)
						.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where("SysLicPackage", "Name").In(names)
				.And("SysLicPackage", "Operations")
					.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
				as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			_systemSettingLicenseNames = licenseNames.Distinct().ToList();
			return _systemSettingLicenseNames;
		}
		
		private IEnumerable<string> GetAvailableLicenseNames() {
			if (!_availableLicenseNames.IsNullOrEmpty()) {
				return _availableLicenseNames;
			}
			DateTime currentDay = DateTime.UtcNow.Date;
			var licenseNames = new List<string>();
			var select = 
				new Select(_userConnection)
					.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where(Column.Parameter(currentDay))
					.IsBetween("SysLic", "StartDate")
						.And("SysLic", "DueDate")
					.And("SysLicPackage", "Operations")
						.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
					.OrderByAsc("SysLicPackage", "Name")
					as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			_availableLicenseNames = licenseNames;
			return licenseNames;
		}
		
		private List<string> GetGrantedLicenseNames(Collection<Guid> licenses) {
			var licenseNames = new List<string>();
			if (licenses.IsEmpty()) {
				return licenseNames;
			}
			IEnumerable<QueryParameter> uids =
				licenses.Select(id => new QueryParameter(id)).ToList();
			var select = 
				new Select(_userConnection)
					.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where("SysLicPackage", "Id").In(uids)
				.And("SysLicPackage", "Operations")
					.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
				.OrderByAsc("SysLicPackage", "Name")
				as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			return licenseNames;
		}

		private List<string> GetMissingLicenses(IEnumerable<string> grantedLicenses, IEnumerable<string> licenses) {
			return licenses.Except(grantedLicenses).ToList();
		}
		
		private string GetUserWithMissingLicensesLogMessage(Entity user, List<string> licenses) {
			var logMessage = new StringBuilder();
			var userName = user.GetTypedColumnValue<string>("Name");
			logMessage.Append($"(id: {user.PrimaryColumnValue}) | {userName} | ");
			string missingLicenses = string.Join(", ", licenses);
			logMessage.Append(missingLicenses);
			logMessage.Append(".");
			return logMessage.ToString();
		}
		
		private bool GetIsSSPUser(Guid userId) {
			Select isSSPUserSelect =
				new Select(_userConnection)
					.Column(Func.Count(Column.Const(1))).As("Count")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userId))
				.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter(Core.DB.SysAdminUnitType.User))
				.And("ConnectionType").IsEqual(Column.Parameter(UserType.SSP)) as Select;
			bool isSSPUser = isSSPUserSelect.ExecuteScalar<int>() > 0;
			return isSSPUser;
		}

		private void AddLicForSSPUser(Guid userId) {
			SysAdminUtilities sysAdminUtilities = new SysAdminUtilities();
			Collection<string> packageNames = sysAdminUtilities.GetLicPackageNames(_userConnection, UserType.SSP);
			if (packageNames != null) {
				sysAdminUtilities.AddUserLicences(_userConnection, userId, packageNames);
			}
		}

		private void AddLicForSSPOrGeneralUser(Entity user) {
			if (GetIsSSPUser(user.PrimaryColumnValue)) {
				AddLicForSSPUser(user.PrimaryColumnValue);
			} else {
				AddLicForUser(user);
			}
		}

		private Guid? GetIdByName(string name, string entityName, bool createNewIfNotFound) {
			if (string.IsNullOrEmpty(name)) {
				return null;
			}
			var select = new Select(_userConnection).
				Column("Id").
				From(entityName).
				Where("Name").IsEqual(Column.Parameter(name)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						return dataReader.GetColumnValue<Guid>("Id");
					}
				}
			}
			if (createNewIfNotFound) {
				//todo find out is it necessary
			}
			return null;
		}

		private void ActualizeAdminUnitInRole() => OrgStructureManager.ActualizeSysAdminUnitInRole();

		private void ImportUsers(DateTime? minModifiedDateOfNewUser, Guid syncId, out DateTime? maxModificationDateOfLDAPEntry) {
			_usersWithoutLicenses.Clear();
			var createUsersAutomaticallyWhenLdapSynchronize = SysSettings.GetValue(_userConnection,
				"CreateUsersAutomaticallyWhenLdapSynchronize", false);
			if (!createUsersAutomaticallyWhenLdapSynchronize) {
				maxModificationDateOfLDAPEntry = default(DateTime?);
				return;
			}
			int users = 0;
			int errors = 0;

			#region GroupsLoad

			var groupSelect =
				new Select(_userConnection)
					.Column("LDAPEntryId")
					.Column("LDAPEntry")
					.Column("LDAPEntryDN")
				.From("SysAdminUnit")
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And("LDAPEntryId").Not().IsNull() as Select;
			var groupList = new List<LdapGroup>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = groupSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						string groupId = dr.GetValue(0).ToString();
						string groupName = dr.GetValue(1).ToString();
						string groupDn = dr.GetValue(2).ToString();
						groupList.Add(new LdapGroup(groupId, groupName, groupDn));
					}
				}
			}

			#endregion

			#region ExistingUsersLoad

			Select existedUsersSelect =
				new Select(_userConnection)
					.Column("Name")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").IsEqual(Column.Parameter(4)) as Select;
			var existingUsers = new List<string>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = existedUsersSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						existingUsers.Add(dr.GetValue(0).ToString());
					}
				}
			}

			#endregion

			#region ExistingJobsLoad

			var jobs = new Dictionary<Guid, string>();
			var jobsSelect =
				new Select(_userConnection)
					.Column("Id")
					.Column("Name")
				.From("Job");
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = jobsSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var id = dr.GetColumnValue<Guid>("Id");
						var name = dr.GetColumnValue<string>("Name");
						jobs.Add(id, name);
					}
				}
			}

			#endregion

			_log.InfoFormat("SyncID: {0}. Start user import.", syncId);
			var groupCount = 0;
			var newUserIds = new List<Entity>();
			_log.InfoFormat("SyncID: {1}. Found {0} LDAP group(s) to synchronize.", groupList.Count, syncId);
			var cultureSelect =
				new Select(_userConnection)
					.Column("Id")
				.From("SysCulture")
				.Where("Default").IsEqual(Column.Parameter(true)) as Select;
			Guid defaultSysCultureId = cultureSelect.ExecuteScalar<Guid>();
			DateTime lastUserModifiedOn = DateTime.MinValue;
			foreach (var groupItem in groupList) {
				Guid groupId;
				UserType connectionType;
				Select groupPropertiesSelect = new Select(_userConnection)
					.Column("Id")
					.Column("ConnectionType")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").Not().IsEqual(Column.Const((int)SysAdminUnitType.User))
					.And("LDAPEntry").IsEqual(Column.Parameter(groupItem.Name)) as Select;
				using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
					using (IDataReader dataReader = groupPropertiesSelect.ExecuteReader(dbExecutor)) {
						if (dataReader.Read()) {
							groupId = dataReader.GetColumnValue<Guid>("Id");
							connectionType = dataReader.GetColumnValue<UserType>("ConnectionType");
						} else {
							_log.ErrorFormat("SyncID: {1}. Organizational role not found for LDAP group '{0}'",
								groupItem.Name, syncId);
							continue;
						}
					}
				}
				List<LdapUser> ldapUsers;
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					ldapUsers = ldapUtils.GetMembersOfGroup(groupItem, minModifiedDateOfNewUser);
				}
				_log.InfoFormat("SyncID: {2}. Found {0} LDAP users to synchronize in LDAP group {1}", ldapUsers.Count,
					groupItem.Name, syncId);
				var sysAdminUnitSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysAdminUnit");
				var employeeSchema = _userConnection.EntitySchemaManager.FindInstanceByName("Employee");
				var contactSchema = _userConnection.EntitySchemaManager.FindInstanceByName("Contact");
				var usersCount = 0;
				foreach (var user in ldapUsers) {
					/*todo search in existing employees*/
					if (string.IsNullOrEmpty(user.FullName)) {
						continue;
					}
					if (lastUserModifiedOn < user.ModifiedOn) {
						lastUserModifiedOn = user.ModifiedOn;
					}
					Guid contactId;
					Guid accountId = GetAccountId(user);
					var ldapElementId = Guid.Empty;
					var ldapElementSchema = _userConnection.EntitySchemaManager.GetInstanceByName("LDAPElement");
					var ldapElementEntity = ldapElementSchema.CreateEntity(_userConnection);
					ldapElementEntity.UseAdminRights = false;
					var conditions = new Dictionary<string, object> {
						{ "LDAPEntryId", user.Id },
						{ "Type", (int)SysAdminUnitType.User }
					};
					if (ldapElementEntity.FetchFromDB(conditions)) {
						ldapElementId = ldapElementEntity.GetTypedColumnValue<Guid>("Id");
						ldapElementEntity.SetColumnValue("IsActive", user.IsActive);
						ldapElementEntity.Save();
					}

					var sysAdminUnitQuery = new EntitySchemaQuery(sysAdminUnitSchema);
					sysAdminUnitQuery.UseAdminRights = false;
					sysAdminUnitQuery.AddAllSchemaColumns();
					var contactNameColumn = sysAdminUnitQuery.AddColumn("Contact.Name");
					var contactAccountIdColumn = sysAdminUnitQuery.AddColumn("Contact.Account.Id");
					var entryIdFilter = sysAdminUnitQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
						"LDAPEntryId", user.Id);
					var userTypeFilter = sysAdminUnitQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
						"SysAdminUnitTypeValue", (int)SysAdminUnitType.User);
					sysAdminUnitQuery.Filters.Add(entryIdFilter);
					sysAdminUnitQuery.Filters.Add(userTypeFilter);
					var sysAdminUnitCollection = sysAdminUnitQuery.GetEntityCollection(_userConnection);
					var sysAdminUnit = sysAdminUnitCollection.FirstOrDefault();
					if (sysAdminUnit != null) {
						sysAdminUnit.SetColumnValue("LDAPEntryId", user.Id);
						sysAdminUnit.SetColumnValue("LDAPEntry", user.Name);
						sysAdminUnit.SetColumnValue("LDAPEntryDN", user.Dn);
						sysAdminUnit.SetColumnValue("Name", user.Name);
						sysAdminUnit.SetColumnValue("Active", user.IsActive);
						sysAdminUnit.SetColumnValue("SynchronizeWithLDAP", true);
						sysAdminUnit.SetColumnValue("UserPassword", string.Empty);
						if (ldapElementId != Guid.Empty) {
							sysAdminUnit.SetColumnValue("LDAPElementId", ldapElementId);
						}
						sysAdminUnit.Save();
						Guid userId = sysAdminUnit.GetTypedColumnValue<Guid>(sysAdminUnitSchema.PrimaryColumn.Name);
						string contactName = sysAdminUnit.GetTypedColumnValue<string>(contactNameColumn.Name);
						Guid contactAccountId = sysAdminUnit.GetTypedColumnValue<Guid>(contactAccountIdColumn.Name);
						if (contactName != user.FullName || accountId != contactAccountId) {
							contactId = sysAdminUnit.GetTypedColumnValue<Guid>("ContactId");
							var contact = contactSchema.CreateEntity(_userConnection);
							if (contact.FetchFromDB(contactId)) {
								contact.SetColumnValue("Name", user.FullName);
								contact.SetColumnValue("AccountId", accountId);
								contact.Save();
							}
						}

						AddUserToRolesIfNotExist(userId, groupId, connectionType);

						_log.InfoFormat("SyncID: {1}. LDAP user {0} saved", user.Name, syncId);
						usersCount++;
						_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
							ldapUsers.Count, syncId);
						continue;
					}

					if (!user.IsActive) {
						_log.InfoFormat("SyncID: {1}. User AD {0} - deactivated", user.Name, syncId);
						continue;
					}

					if (existingUsers.Any(x => x == user.Name)) {
						_log.InfoFormat("SyncID: {1}. Existing user has the LDAP username - {0}", user.Name, syncId);
						usersCount++;
						_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
							ldapUsers.Count, syncId);
						errors++;
						continue;
					}

					contactId = Guid.NewGuid();

					#region FindExistingContact
					bool empl = true;
					List<Guid> contactIds = LdapUtilities.GetExistingContactIds(_userConnection, user.FullName,
						user.Phone, user.Email);

					if (contactIds.Count > 1) {
						_log.InfoFormat("SyncID: {1}. Several contacts found that can be duplicates of user {0}",
							user.Name, syncId);
						usersCount++;
						_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount, ldapUsers.Count, syncId);
						errors++;
						continue;
					} else if (contactIds.Count == 1) {
						contactId = contactIds.First();
						empl = false;
					}

					#endregion

					#region SkipCreateUserAndRoleIfContactAlreadyHaveUser

					if (contactIds.Any()) {
						using (var ldapUtils = new LdapUtilities(_userConnection)) {
							List<Guid> userIds = ldapUtils.GetUserIdsByContactId(contactId);
							if (userIds.Any()) {
								_log.InfoFormat("SyncID: {1}. User is already created for the found contact ({0})",
									user.FullName, syncId);
								usersCount++;
								_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
									ldapUsers.Count, syncId);
								errors++;
								continue;
							}
						}
					}

					#endregion

					#region CreateUser

					if (empl) {
						var contact = contactSchema.CreateEntity(_userConnection);
						contact.SetDefColumnValues();
						contact.SetColumnValue("Id", contactId);
						contact.SetColumnValue(employeeSchema.PrimaryColumn.Name, contactId);
						contact.SetColumnValue("Name", user.FullName);
						contact.SetColumnValue("AccountId", accountId);
						contact.SetColumnValue("Email", user.Email);
						contact.SetColumnValue("Phone", user.Phone);
						string jobTitle = user.JobTitle;
						Guid? jobId = GetJobIdByName(jobs, jobTitle);
						contact.SetColumnValue("JobId", jobId);
						contact.SetColumnValue("JobTitle", jobTitle);
						contact.Save();
					}
					Guid newUserId = Guid.NewGuid();
					lock (_lockObject) {
						sysAdminUnit = sysAdminUnitSchema.CreateEntity(_userConnection);
						var userConditions = new Dictionary<string, object> {
							{ "Name", user.Name },
							{ "SynchronizeWithLDAP", true }
						};
						if (sysAdminUnit.FetchFromDB(userConditions)) {
							_log.InfoFormat("SyncID: {1}. LDAP user {0} already added", user.Name, syncId);
							usersCount++;
							_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
								ldapUsers.Count, syncId);
							continue;
						}
						sysAdminUnit.SetDefColumnValues();
						sysAdminUnit.SetColumnValue(sysAdminUnitSchema.PrimaryColumn.Name, newUserId);
						sysAdminUnit.SetColumnValue("SysAdminUnitTypeValue", (int)SysAdminUnitType.User);
						sysAdminUnit.SetColumnValue("ContactId", contactId);
						sysAdminUnit.SetColumnValue("LDAPEntryId", user.Id);
						sysAdminUnit.SetColumnValue("LDAPEntry", user.Name);
						sysAdminUnit.SetColumnValue("Name", user.Name);
						sysAdminUnit.SetColumnValue("SynchronizeWithLDAP", true);
						sysAdminUnit.SetColumnValue("Active", true);
						sysAdminUnit.SetColumnValue("UserPassword", string.Empty);
						sysAdminUnit.SetColumnValue("ConnectionType", connectionType);
						if (defaultSysCultureId != Guid.Empty) {
							sysAdminUnit.SetColumnValue("SysCultureId", defaultSysCultureId);
						}
						if (ldapElementId != Guid.Empty) {
							sysAdminUnit.SetColumnValue("LDAPElementId", ldapElementId);
						}
						try {
							sysAdminUnit.Save();
							newUserIds.Add(sysAdminUnit);
						} catch (Exception e) {
							_log.ErrorFormat("SyncID: {1}. {0}", e, e.Message, syncId);
							throw;
						}
					}

					#endregion

					AddUserToRolesIfNotExist(newUserId, groupId, connectionType);

					_log.InfoFormat("SyncID: {1}. LDAP user {0} saved", user.Name, syncId);
					usersCount++;
					_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
						ldapUsers.Count, syncId);
					users++;
				}
				_log.InfoFormat("SyncID: {1}. LDAP group {0} processed", groupItem.Name, syncId);
				groupCount++;
				_log.InfoFormat("SyncID: {2}. Progress: {0} groups processed from {1}", groupCount, groupList.Count, syncId);
			}

			#region Update users in all groups

			var sel =
				new Select(_userConnection)
					.Column("LDAPEntryId")
					.Column("LDAPEntry")
					.Column("LDAPEntryDN")
					.Column("Id")
					.Column("Name")
				.From("SysAdminUnit").Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = sel.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var ldapEntryId = dr.GetValue(0).ToString();
						var ldapEntry = dr.GetValue(1).ToString();
						var ldapEntryDn = dr.GetValue(2).ToString();
						var groupId = new Guid(dr.GetValue(3).ToString());
						var ldapGroup = new LdapGroup(ldapEntryId, ldapEntry, ldapEntryDn);
						CheckUsersInGroup(ldapGroup, groupId, syncId, out _);
					}
				}
			}

			#endregion

			if (_userConnection.GetIsFeatureEnabled("ControlLicenseDistributionDuringLDAPSync")) {
				if (SysSettings.GetValue(_userConnection, "LDAPAllowLicenseDistributionDuringLDAPSync", true)) {
					foreach (var newUser in newUserIds) {
						AddLicForSSPOrGeneralUser(newUser);
					}
				}
			} else {
				foreach (var newUser in newUserIds) {
					AddLicForSSPOrGeneralUser(newUser);
				}
			}

			if (users > 0) {
				ActualizeAdminUnitInRole();
			}

			maxModificationDateOfLDAPEntry = lastUserModifiedOn > DateTime.MinValue ? lastUserModifiedOn :
				default(DateTime?);
			string syncResult = "LDAP synchronization completed";
			if (users > 0) {
				syncResult += string.Format(" Users added: {0}", users);
			}
			if (errors > 0) {
				syncResult += string.Format(" Errors: {0}", errors);
			}
			_log.InfoFormat("SyncID: {1}. User import finished! SyncResult: {0}", syncResult, syncId);
		}

		private Guid GetAccountId(LdapUser user) {
			return GetIdByName(user.Company, "Account", false) ?? AccountConsts.OurCompanyAccountId;
		}

		private void AddUserToRolesIfNotExist(Guid userId, Guid groupId, UserType connectionType) {
			Guid mainGroupId = connectionType == UserType.SSP ? _sspUsersGroupId : _allEmployeesGroupId;
			AddUserToRoleIfNotExist(userId, mainGroupId);
			AddUserToRoleIfNotExist(userId, groupId);
		}

		private void AddUserToRoleIfNotExist(Guid userId, Guid groupId) {
			var userInRoleSelect =
				(Select)new Select(_userConnection)
					.Column(Func.Count(Column.Const(1)))
					.From("SysUserInRole")
					.Where("SysUserId").IsEqual(Column.Parameter(userId))
					.And("SysRoleId").IsEqual(Column.Parameter(groupId));
			int recordCount = userInRoleSelect.ExecuteScalar<int>();
			if (recordCount == 0) {
				var sysUserInRoleSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysUserInRole");
				Entity sysUserInRole = sysUserInRoleSchema.CreateEntity(_userConnection);
				sysUserInRole.UseAdminRights = false;
				sysUserInRole.SetDefColumnValues();
				sysUserInRole.SetColumnValue("SysUserId", userId);
				sysUserInRole.SetColumnValue("SysRoleId", groupId);
				sysUserInRole.Save();
			}
		}

		private void CheckAllLDAPUsersInEverySyncGroup(Guid syncId, out DateTime? minModifiedDateOfNewUser) {
			var delete = new Delete(_userConnection)
				.From("SysLDAPSynchGroup");
			if (syncId.IsNotEmpty()) {
				delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			delete.Execute();

			minModifiedDateOfNewUser = default(DateTime?);

			using (var ldapUtils = new LdapUtilities(_userConnection)) {
				int groupsCount = ldapUtils.InsertGroupsToTable(syncId);
				if (groupsCount < 1) {
					return;
				}
			}
			if(_userConnection.GetIsFeatureEnabled("DeactivateExcludedLdapUsers")) {
				var groupExistsSubSelect =
					new Select(_userConnection)
						.Column("Id")
					.From("SysLDAPSynchGroup")
					.Where("SysLDAPSynchGroup", "Id").IsEqual("AdminRole", "LDAPEntryId");
				if (syncId.IsNotEmpty()) {
					groupExistsSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				var updateUsers =
					new Update(_userConnection, "SysAdminUnit")
						.Set("Active", Column.Parameter(false))
					.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
					.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
					.And().Exists(
						new Select(_userConnection)
							.Column("Id")
						.From("SysUserInRole")
						.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And().Exists(
							new Select(_userConnection)
								.Column("Id")
							.From("SysAdminUnit").As("AdminRole")
							.Where("AdminRole", "Id").IsEqual("SysUserInRole", "SysRoleId")
							.And("AdminRole", "SysAdminUnitTypeValue")
								.Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
							.And("AdminRole", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
							.And().Not().Exists(groupExistsSubSelect)))
					.And().Not().Exists(
						new Select(_userConnection)
							.Column("Id")
						.From("SysUserInRole")
						.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And().Exists(
							new Select(_userConnection)
								.Column("Id")
							.From("SysAdminUnit").As("AdminRole")
							.Where("AdminRole", "Id").IsEqual("SysUserInRole", "SysRoleId")
							.And("AdminRole", "SysAdminUnitTypeValue")
								.Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
							.And("AdminRole", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
							.And().Exists(groupExistsSubSelect)));
				var deactivatedUsers = updateUsers.Execute();
				_log.InfoFormat("SyncID: {1}. {0} users from deleted groups were deactivated", deactivatedUsers, syncId);
			}
			var update =
				new Update(_userConnection, "SysAdminUnit")
					.Set("SynchronizeWithLDAP", Column.Parameter(false))
					.Set("LDAPEntryId", Column.Parameter(string.Empty))
					.Set("LDAPEntry", Column.Parameter(string.Empty))
					.Set("LDAPEntryDN", Column.Parameter(string.Empty))
					.Set("LDAPElementId", Column.Parameter(null, "Guid"))
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("Id")
					.From("SysLDAPSynchGroup")
					.Where("SysLDAPSynchGroup", "Id").IsEqual("SysAdminUnit", "LDAPEntryId"));
			int operationsCount = update.Execute();

			var adminUnitExistsSubSelect =
				new Select(_userConnection)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("SysLDAPSynchGroup", "Id").IsEqual("SysAdminUnit", "LDAPEntryId")
				.And("SysLDAPSynchGroup", "Name").IsEqual("SysAdminUnit", "LDAPEntry")
				.And("SysLDAPSynchGroup", "Dn").IsEqual("SysAdminUnit", "LDAPEntryDN")
				.And("SysAdminUnit", "SysAdminUnitTypeValue").Not()
					.IsEqual(Column.Parameter((int)SysAdminUnitType.User));
			if (syncId.IsNotEmpty()) {
				adminUnitExistsSubSelect.And("SysLDAPSynchGroup", "LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			Query adminUnitNotExistsSubSelect =
				new Select(_userConnection)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("SysLDAPSynchGroup", "Id").IsEqual("SysAdminUnit", "LDAPEntryId")
				.And("SysAdminUnit", "SysAdminUnitTypeValue").Not()
					.IsEqual(Column.Parameter((int)SysAdminUnitType.User));
			if (syncId.IsNotEmpty()) {
				adminUnitNotExistsSubSelect.And("SysLDAPSynchGroup", "LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			delete =
				(Delete)new Delete(_userConnection)
				.From("SysLDAPSynchGroup");
			if (syncId.IsEmpty()) {
				delete.Where().Exists(adminUnitExistsSubSelect)
					.Or().Not().Exists(adminUnitNotExistsSubSelect);
			} else {
				delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId))
					.And().Exists(adminUnitExistsSubSelect)
					.Or().Not().Exists(adminUnitNotExistsSubSelect);
				QueryCondition where = delete.Condition;
				QueryCondition existsCondition = delete.Condition[1];
				QueryCondition notExistsCondition = delete.Condition[2];
				existsCondition.WrapBlock();
				existsCondition.Add(notExistsCondition);
				where.Remove(notExistsCondition);
			}
			delete.Execute();

			Select selectGroupProperties =
				new Select(_userConnection)
					.Column("Id")
					.Column("Name")
					.Column("Dn")
				.From("SysLDAPSynchGroup");
			if (syncId.IsNotEmpty()) {
				selectGroupProperties.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = selectGroupProperties.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var ldapEntryId = dataReader.GetValue(0).ToString();
						var ldapEntry = dataReader.GetValue(1).ToString();
						var ldapEntryDn = dataReader.GetValue(2).ToString();
						update = new Update(_userConnection, "SysAdminUnit")
							.Set("LDAPEntry", Column.Parameter(ldapEntry))
							.Set("LDAPEntryDN", Column.Parameter(ldapEntryDn))
							.Where("LDAPEntryId").IsEqual(Column.Parameter(ldapEntryId))
							.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Const((int)SysAdminUnitType.User));
						update.Execute();
						operationsCount++;
					}
				}
			}
			_log.InfoFormat("SyncID: {1}. LDAP fields have been updated for {0} group(s)", operationsCount, syncId);

			delete = new Delete(_userConnection)
				.From("SysLDAPSynchGroup");
			if (syncId.IsNotEmpty()) {
				delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			delete.Execute();

			var selectAdminRoles =
				new Select(_userConnection)
					.Column("LDAPEntryId")
					.Column("LDAPEntry")
					.Column("LDAPEntryDN")
					.Column("Id")
					.Column("Name")
				.From("SysAdminUnit")
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = selectAdminRoles.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var ldapEntryId = dataReader.GetColumnValue<string>("LDAPEntryId");
						var ldapEntry = dataReader.GetColumnValue<string>("LDAPEntry");
						var ldapEntryDn = dataReader.GetColumnValue<string>("LDAPEntryDN");
						var groupId = dataReader.GetColumnValue<Guid>("Id");
						CheckUsersInGroup(new LdapGroup(ldapEntryId, ldapEntry, ldapEntryDn), groupId, syncId,
							out DateTime? minModifiedDate);
						if (minModifiedDate.HasValue && (!minModifiedDateOfNewUser.HasValue ||
								minModifiedDateOfNewUser.Value > minModifiedDate.Value)) {
							minModifiedDateOfNewUser = minModifiedDate;
						}
					}
				}
			}
		}

		private void DeactivateDeletedAdUsers(Guid syncId) {
			if (!_userConnection.GetIsFeatureEnabled("DeactivateDeletedAdUsers")) {
				return;
			}
			try {
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					ldapUtils.InsertUsersIdsToTableByFilter(syncId);
					Select ldapUserIdsSelect =
						new Select(_userConnection)
							.Column("Id")
						.From("SysLDAPSynchUser");
					if (syncId.IsNotEmpty()) {
						ldapUserIdsSelect.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
					}
					var update = 
						new Update(_userConnection, "SysAdminUnit")
							.Set("Active", Column.Parameter(false))
						.Where("LDAPEntryId")
							.Not().In(ldapUserIdsSelect)
						.And("SysAdminUnit", "SysAdminUnitTypeValue")
							.IsEqual(Column.Parameter((int)SysAdminUnitType.User))
						.And("Active")
							.IsEqual(Column.Parameter(true))
						.And("SynchronizeWithLDAP")
							.IsEqual(Column.Parameter(true));
					int deactivatedUsersCount = update.Execute();
					_log.InfoFormat("SyncID: {1}. {0} user(s) were deactivated in system, because they were deleted from AD.",
						deactivatedUsersCount, syncId);
				}
			} finally {
				var delete = new Delete(_userConnection)
					.From("SysLDAPSynchUser");
				if (syncId.IsNotEmpty()) {
					delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				delete.Execute();
			}
		}

		private void DeactivateExcludedUsers(Guid syncId) {
			var synchronizeOnlyGroups = _userConnection.GetIsFeatureEnabled("DeactivateExcludedLdapUsers")
				&& SysSettings.GetValue<bool>(_userConnection, "LDAPSynchronizeOnlyGroups", false);
			if (!synchronizeOnlyGroups) {
				return;
			}
			var update =
				new Update(_userConnection, "SysAdminUnit")
					.Set("Active", Column.Parameter(false))
				.Where("SysAdminUnit", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("SysUserInRole", "Id")
					.From("SysUserInRole")
					.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
					.And().Exists(
						new Select(_userConnection)
							.Column("SysAdminRole", "Id")
						.From("SysAdminUnit").As("SysAdminRole")
						.Where("SysAdminRole", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
						.And("SysAdminRole", "SysAdminUnitTypeValue")
							.IsNotEqual(Column.Parameter((int)SysAdminUnitType.User))
						.And("SysAdminRole", "Id").IsEqual("SysUserInRole", "SysRoleId")));
			var updateResult = update.Execute();
			_log.InfoFormat("SyncID: {1}. {0} users were deactivated", updateResult, syncId);
		}

		#endregion

		#region Methods: Internal

		internal void UpdateLDAPUsersWhichCanBeSynchronized(Guid syncId) {
			try {
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					int usersCount = ldapUtils.InsertUsersToTable(syncId);
					if (usersCount < 1) {
						return;
					}
					var delete =
						new Delete(_userConnection)
						.From("SysLDAPSynchUser")
						.Where().Not().Exists(
							new Select(_userConnection)
								.Column("Id")
							.From("SysAdminUnit")
							.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId"));
					if (syncId.IsNotEmpty()) {
						delete.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
					}
					delete.Execute();
					var synchronizeOnlyGroups = _userConnection.GetIsFeatureEnabled("DeactivateExcludedLdapUsers")
						&& SysSettings.GetValue<bool>(_userConnection, "LDAPSynchronizeOnlyGroups", false);
					if (!synchronizeOnlyGroups) {
						var isActiveSubSelect = new Select(_userConnection)
							.Column("IsActive")
						.From("SysLDAPSynchUser")
						.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId");
						if (syncId.IsNotEmpty()) {
							isActiveSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						Query existingUsersSubSelect
							= new Select(_userConnection)
								.Column("Id")
							.From("SysLDAPSynchUser")
							.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId");
						if (syncId.IsNotEmpty()) {
							existingUsersSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						var update =
							new Update(_userConnection, "SysAdminUnit")
								.Set("Active", isActiveSubSelect)
							.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
							.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
							.And().Exists(existingUsersSubSelect);
						var updateResult = update.Execute();
						_log.InfoFormat("SyncID: {1}. {0} users became active", updateResult, syncId);
						var currentUser = _userConnection.CurrentUser;
						DateTime currentDateTime = currentUser.GetCurrentDateTime();
						var select =
							new Select(_userConnection)
								.Column("Name")
							.From("SysLDAPSynchUser")
							.Where("Id").IsEqual("SysAdminUnit", "LDAPEntryId")
							.And("SysLDAPSynchUser", "Name").IsNotEqual("SysAdminUnit", "LDAPEntry");
						if (syncId.IsNotEmpty()) {
							select.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						update =
							new Update(_userConnection, "SysAdminUnit")
								.Set("ModifiedOn", Column.Parameter(currentDateTime))
								.Set("ModifiedById", Column.Parameter(currentUser.Id))
								.Set("LDAPEntry", select)
							.Where().Exists(select)
							.And("SysAdminUnitTypeValue").IsEqual(Column.Const((int)SysAdminUnitType.User)) as Update;
						update.Execute();
					}
					if (ldapUtils.IsPhoneNeedUpdate || ldapUtils.IsEmailNeedUpdate || ldapUtils.IsJobTitleNeedUpdate) {
						var operationCount = 0;
						var jobs = new Dictionary<Guid, string>();
						var jobsSelect =
							new Select(_userConnection)
								.Column("Id")
								.Column("Name")
							.From("Job");
						var contactQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Contact");
						contactQuery.AddAllSchemaColumns();
						EntitySchemaQueryColumn ldapEntryColumn = contactQuery.AddColumn("[SysAdminUnit:Contact].LDAPEntryId");
						contactQuery.UseAdminRights = false;
						string ldapEntryColumnName = ldapEntryColumn.Name;
						contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
							"[SysAdminUnit:Contact].Active", true));
						contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.IsNotNull,
							"[SysAdminUnit:Contact].LDAPEntryId"));
						contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
							"[SysAdminUnit:Contact].SysAdminUnitTypeValue", (int)SysAdminUnitType.User));
						EntityCollection contacts = contactQuery.GetEntityCollection(_userConnection);
						var ldapUsersSelect =
							new Select(_userConnection)
								.Column("Id")
								.Column("Email")
								.Column("Phone")
								.Column("JobTitle")
							.From("SysLDAPSynchUser");
						if (syncId.IsNotEmpty()) {
							ldapUsersSelect.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
							using (IDataReader dr = jobsSelect.ExecuteReader(dbExecutor)) {
								while (dr.Read()) {
									var id = dr.GetColumnValue<Guid>("Id");
									var name = dr.GetColumnValue<string>("Name");
									jobs.Add(id, name);
								}
							}
							using (IDataReader dr = ldapUsersSelect.ExecuteReader(dbExecutor)) {
								while (dr.Read()) {
									var ldapEntryId = dr.GetColumnValue<string>("Id");
									var email = dr.GetColumnValue<string>("Email");
									var phone = dr.GetColumnValue<string>("Phone");
									var jobTitle = dr.GetColumnValue<string>("JobTitle");
									Entity contact = contacts.Find(entity =>
										entity.GetTypedColumnValue<string>(ldapEntryColumnName) == ldapEntryId);
									if (contact == null) {
										_log.InfoFormat("SyncID: {1}. Could not find contact for ldapEntryId={0}",
											ldapEntryId, syncId);
										continue;
									}
									if (ldapUtils.IsEmailNeedUpdate) {
										contact.SetColumnValue("Email", email);
									}
									if (ldapUtils.IsPhoneNeedUpdate) {
										contact.SetColumnValue("Phone", phone);
									}
									if (ldapUtils.IsJobTitleNeedUpdate) {
										Guid? jobId = GetJobIdByName(jobs, jobTitle);
										contact.SetColumnValue("JobId", jobId);
										contact.SetColumnValue("JobTitle", jobTitle);
									}
									contact.Save();
									operationCount++;
								}
							}
						}
						_log.InfoFormat("SyncID: {1}. LDAP fields have been updated for {0} user(s)", operationCount, syncId);
					}
				}
			} catch (Exception e) {
				_log.ErrorFormat("SyncID: {1}. {0}", e, e.Message, syncId);
				throw;
			} finally {
				var delete = new Delete(_userConnection)
					.From("SysLDAPSynchUser");
				if (syncId.IsNotEmpty()) {
					delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				delete.Execute();
			}
		}

		#endregion

		#region Methods: Public

		public void SetEntryMaxModifiedOn(DateTime synchronizationDate) {
			if (GlobalAppSettings.FeatureUseSysSettingsEngine) {
				if (SysSettings.Exists(_userConnection, "LDAPEntryMaxModifiedOn")) {
					SysSettings.SetDefValue(_userConnection, "LDAPEntryMaxModifiedOn", synchronizationDate);
				}
			} else {
				var settings = new SysSettings(_userConnection);
				if (!settings.FetchFromDB("Code", "LDAPEntryMaxModifiedOn")) {
					return;
				}
				var updateSettingsValue = new Update(_userConnection, "SysSettingsValue")
					.Set("DateTimeValue", Column.Parameter(synchronizationDate))
					.Where("SysSettingsId").IsEqual(Column.Parameter(settings.GetColumnValue("Id")))
					.And("IsDef").IsEqual(Column.Parameter(true));
				updateSettingsValue.Execute();
			}
		}

		public Guid? GetJobIdByName(Dictionary<Guid, string> jobs, string name) {
			if (string.IsNullOrEmpty(name)) {
				return null;
			}
			foreach (KeyValuePair<Guid, string> item in jobs) {
				if (item.Value.Equals(name, StringComparison.InvariantCulture)) {
					return item.Key;
				}
			}
			var job = new Job(_userConnection);
			job.SetDefColumnValues();
			job.Name = name;
			job.Save();
			Guid jobId = job.Id;
			jobs.Add(jobId, name);
			return jobId;
		}

		[Obsolete("7.18.2. Use UpdateLDAPUsersWhichCanBeSynchronized(Guid)")]
		public void CheckLDAPUsersWhichCanBeSynchronized() {
			UpdateLDAPUsersWhichCanBeSynchronized(Guid.Empty);
		}	

		public void SyncWithLDAP() {
			try {
				var useLdapSyncId = _userConnection.GetIsFeatureEnabled("UseLDAPSyncId");
				var syncId = useLdapSyncId
					? Guid.NewGuid()
					: Guid.Empty;
				_log.InfoFormat("Starting LDAP synchonization with id {0}", syncId);

				// Update synchronized users
				UpdateLDAPUsersWhichCanBeSynchronized(syncId);

				// Checking if the LDAP users are part of the synchronized business units
				CheckAllLDAPUsersInEverySyncGroup(syncId, out DateTime ? minModifiedDateOfNewUser);

				// Import users automatically
				ImportUsers(minModifiedDateOfNewUser, syncId, out DateTime? maxModificationDateOfLDAPEntry);

				DeactivateDeletedAdUsers(syncId);

				DeactivateExcludedUsers(syncId);

				if (maxModificationDateOfLDAPEntry.HasValue) {
					SetEntryMaxModifiedOn(maxModificationDateOfLDAPEntry.Value);
				}
				
			} catch (Exception e) {
				_log.Error(e.Message, e);
				throw;
			}
		}

		public List<LDAPLicenseInfo> GetUsersWithMissingLicenses() {
			return _usersWithoutLicenses;
		}

		#endregion

	}

	#endregion

}
