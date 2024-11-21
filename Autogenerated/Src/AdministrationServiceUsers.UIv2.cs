namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using Newtonsoft.Json;
	using BPMSoft.Web.Common;

	#region Class: AdministrationService
	public partial class AdministrationService
	{
		#region Fields: Private

		/// <summary>
		/// ####### ########## ####### ##### ####### "VwSysAdminUnit".
		/// #### - ### ######## ####### #######, ######## - ### ######## #######.
		/// </summary>
		private Dictionary<string, object> changedValues;

		/// <summary>
		/// ############# #### ######### ###############.
		/// </summary>
		private readonly Guid sysAdminsRoleId = new Guid("83a43ebc-f36b-1410-298d-001e8c82bcad");

		#endregion Fields: Private

		#region Methods: Private
		/// <summary>
		/// ####### ###### # ####### "SysUserInRole" ### ########## ############ # ####.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <param name="roleId">############# ####.</param>
		private void AddUserInRole(object userId, object roleId) {
			List<object> listUsers = new List<object>();
			listUsers.Add(userId);
			AddUsersInRole(listUsers, roleId);
		}

		/// <summary>
		/// ########## ########## ######### ###############.
		/// </summary>
		/// <returns>########## ############### # #######.</returns>
		private int GetSysAdminsCount() {
			var sysUserInRoleQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			EntitySchemaQueryColumn countColumn = sysUserInRoleQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem roleFilter = sysUserInRoleQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysRole", sysAdminsRoleId);
			sysUserInRoleQuery.Filters.Add(roleFilter);
			Entity summary = sysUserInRoleQuery.GetSummaryEntity(UserConnection);
			return summary != null ? summary.GetTypedColumnValue<int>(countColumn.Name) : 0;
		}

		/// #########, ###### ## ############ # ###### ######### ###############.
		/// #### ##, ## ######## ##### CheckCanRemoveUserFromRole ### #### ###. ###############.
		/// </summary>
		/// <param name="userId"></param>
		private void CheckCanDeleteUser(Guid userId) {
			var sysUserInRoleQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			EntitySchemaQueryColumn countColumn = sysUserInRoleQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem userFilter = sysUserInRoleQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysUser", userId);
			IEntitySchemaQueryFilterItem roleFilter = sysUserInRoleQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysRole", sysAdminsRoleId);
			sysUserInRoleQuery.Filters.Add(userFilter);
			sysUserInRoleQuery.Filters.Add(roleFilter);
			Entity summary = sysUserInRoleQuery.GetSummaryEntity(UserConnection);
			if (summary != null && summary.GetTypedColumnValue<int>(countColumn.Name) > 0) {
				CheckCanRemoveUserFromRole(sysAdminsRoleId);
			}
		}

		/// <summary>
		/// #########, ######## ## ############ ####### ############# ############## #######,
		/// # #### ### ###, ########## ########## <see cref="SecurityException"/>.
		/// </summary>
		/// <param name="roleId">############# ####.</param>
		private void CheckCanRemoveUserFromRole(Guid roleId) {
			if (roleId != sysAdminsRoleId) {
				return;
			}
			if (GetSysAdminsCount() == 1) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.CannotRemoveLastUserFromSysAdminsExceptionMessage.Value"));
			}
		}

		/// <summary>
		/// ####### ###### # ####### "SysUserInRole" ### ########## ############# # ####.
		/// </summary>
		/// <param name="recordId">############# ########## ######.</param>
		/// <param name="userId">############# ############.</param>
		/// <param name="roleId">############# ####.</param>
		private void ChangeUserInRole(object recordId, object roleId, object userId) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
			Entity sysUserInRole = tableSchema.CreateEntity(UserConnection);
			if (sysUserInRole.FetchFromDB(recordId)) {
				EntitySchemaColumn userColumn = tableSchema.Columns.GetByName("SysUser");
				EntitySchemaColumn roleColumn = tableSchema.Columns.GetByName("SysRole");
				sysUserInRole.SetColumnValue(userColumn.ColumnValueName, userId);
				sysUserInRole.SetColumnValue(roleColumn.ColumnValueName, roleId);
				sysUserInRole.Save();
			}
		}

		/// <summary>
		/// ####### ###### # ####### "SysUserInRole" ### ########## ############# # ####.
		/// </summary>
		/// <param name="userIds">###### ############### #############.</param>
		/// <param name="roleId">############# ####.</param>
		private void AddUsersInRole(List<object> userIds, object roleId) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
			foreach (object userId in userIds) {
				Entity sysUserInRole = tableSchema.CreateEntity(UserConnection);
				Dictionary<string, object> conditions = new Dictionary<string, object> {
					{ "SysUser", userId },
					{ "SysRole", roleId }
				};
				if (!sysUserInRole.FetchFromDB(conditions)) {
					sysUserInRole.SetDefColumnValues();
					EntitySchemaColumn userColumn = tableSchema.Columns.GetByName("SysUser");
					EntitySchemaColumn roleColumn = tableSchema.Columns.GetByName("SysRole");
					sysUserInRole.SetColumnValue(userColumn.ColumnValueName, userId);
					sysUserInRole.SetColumnValue(roleColumn.ColumnValueName, roleId);
					sysUserInRole.Save();
				}
			}
		}

		/// <summary>
		/// ####### ###### # ####### "SysFuncRoleInOrgRole".
		/// </summary>
		/// <param name="orgRoleId">############### ####.</param>
		/// <param name="funcRoleId">############## ####.</param>
		private void AddFuncRoleInOrgRole(object orgRoleId, object funcRoleId) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysFuncRoleInOrgRole");
			Entity sysFuncRoleInOrgRole = tableSchema.CreateEntity(UserConnection);
			Dictionary<string, object> conditions = new Dictionary<string, object> {
				{ "FuncRole", funcRoleId },
				{ "OrgRole", orgRoleId }
			};
			if (!sysFuncRoleInOrgRole.FetchFromDB(conditions)) {
				sysFuncRoleInOrgRole.SetDefColumnValues();
				EntitySchemaColumn funcRoleColumn = tableSchema.Columns.GetByName("FuncRole");
				EntitySchemaColumn orgRoleColumn = tableSchema.Columns.GetByName("OrgRole");
				sysFuncRoleInOrgRole.SetColumnValue(funcRoleColumn.ColumnValueName, funcRoleId);
				sysFuncRoleInOrgRole.SetColumnValue(orgRoleColumn.ColumnValueName, orgRoleId);
				sysFuncRoleInOrgRole.Save();
			}
		}

		/// <summary>
		/// Remove user from all roles.
		/// </summary>
		/// <param name="userId">User Id.</param>
		private void RemoveUserInAllRoles(object userId) {
			var schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			schemaQuery.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem userFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysUser", userId);
			schemaQuery.Filters.Add(userFilter);
			EntityCollection collection = schemaQuery.GetEntityCollection(UserConnection);
			var roleIds = collection.Select(x => (object)x.GetTypedColumnValue<Guid>("SysRoleId")).ToList();
			if (roleIds.Count > 0) {
				RemoveUserInRoles(userId, roleIds);
			}
		}

		/// <summary>
		/// ####### ############ ## ###### ######### #####.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <param name="roleIds">###### ############### #####.</param>
		/// <param name="guids">###### ############### ######### #######.</param>
		private void RemoveUserInRoles(object userId, List<object> roleIds, List<Guid> guids = null) {
			SecurityException ex = null;
			EntitySchemaQuery schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			schemaQuery.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem roleFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysRole", roleIds);
			IEntitySchemaQueryFilterItem userFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysUser", userId);
			schemaQuery.Filters.Add(roleFilter);
			schemaQuery.Filters.Add(userFilter);
			EntityCollection collection = schemaQuery.GetEntityCollection(UserConnection);
			foreach (Entity entity in collection.ToList()) {
				try {
					CheckCanRemoveUserFromRole(entity.GetTypedColumnValue<Guid>("SysRoleId"));
					entity.Delete();
					if (guids != null) {
						guids.Add(entity.GetTypedColumnValue<Guid>("SysUserId"));
					}
				} catch (SecurityException e) {
					ex = e;
				}
			}
			if (ex != null) {
				throw ex;
			}
		}

		/// <summary>
		/// ####### ############# ## ###### ######### #####.
		/// </summary>
		/// <param name="recordIds">###### ############### #######.</param>
		/// <param name="guids">###### ############### ######### #######.</param>
		private void RemoveUserInRoles(List<object> recordIds, List<Guid> guids) {
			SecurityException ex = null;
			EntitySchemaQuery schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			schemaQuery.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem primaryColumnFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				schemaQuery.RootSchema.PrimaryColumn.Name, recordIds);
			schemaQuery.Filters.Add(primaryColumnFilter);
			EntityCollection collection = schemaQuery.GetEntityCollection(UserConnection);
			foreach (Entity entity in collection.ToList()) {
				try {
					CheckCanRemoveUserFromRole(entity.GetTypedColumnValue<Guid>("SysRoleId"));
					entity.Delete();
					guids.Add(entity.PrimaryColumnValue);
				} catch (SecurityException e) {
					ex = e;
				}
			}
			if (ex != null) {
				throw ex;
			}
		}

		/// <summary>
		/// ####### ############# ## ###### ######### #####.
		/// </summary>
		/// <param name="userIds">###### #####.</param>
		/// <param name="roleIds">###### #############.</param>
		/// <param name="guids">###### ############### ######### #######.</param>
		private void RemoveUsersInRoles(List<object> userIds, List<object> roleIds, List<Guid> guids) {
			foreach (object userId in userIds) {
				RemoveUserInRoles(userId, roleIds, guids);
			}
		}

		/// <summary>
		/// ####### ############.
		/// </summary>
		/// <param name="userId">############# ############</param>
		private void DeleteUser(Guid userId) {
			EntitySchema adminUnitSchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity adminUnitEntity = adminUnitSchema.CreateEntity(UserConnection);
			if (adminUnitEntity.FetchFromDB(userId)) {
				var delete = new Delete(UserConnection)
					.From("SysUserInRole")
					.Where("SysUserId").IsEqual(Column.Parameter(userId));
				delete.Execute();
				adminUnitEntity.Delete();
			}
		}

		/// <summary>
		/// Return true if user connection type is General.
		/// </summary>
		/// <param name="connectionType">User connection type 0 - General, 1 - SSP.</param>
		/// <returns>true if user connection type is General, false - other.</returns>
		private bool IsUserConnectionTypeGeneral(int connectionType) {
			return connectionType.Equals((int)UserType.General);
		}

		/// <summary>
		/// Return parent role by user connection type.
		/// </summary>
		/// <param name="connectionType">User connection type 0 - General, 1 - SSP.</param>
		/// <returns>User role Id.</returns>
		private Guid GetParentRoleByConnectionType(int connectionType) {
			return IsUserConnectionTypeGeneral(connectionType) ?
				BaseConsts.AllEmployersSysAdminUnitUId : BaseConsts.PortalUsersSysAdminUnitUId;
		}

		/// <summary>
		/// Returns array of primary column values from filters.
		/// </summary>
		/// <param name="filterConfigs">Serialized filters config.</param>
		/// <returns>Array of primary column values.</returns>
		private Guid[] InnerGetUserIds(string filterConfigs) { 
			var select = new BPMSoft.Nui.ServiceModel.DataContract.SelectQuery {
				RootSchemaName = "SysAdminUnit"
			};
			if (!string.IsNullOrEmpty(filterConfigs)) {
				var filters =
					JsonConvert.DeserializeObject<BPMSoft.Nui.ServiceModel.DataContract.Filters>(filterConfigs);
				select.Filters = filters;
			}
			var esq = select.BuildEsq(UserConnection);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysAdminUnitTypeValue", BPMSoft.Core.DB.SysAdminUnitType.User));
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			return entities.Select(x => x.PrimaryColumnValue).ToArray();
		}

		#endregion Methods: Private

		#region Methods: Protected
		/// <summary>
		/// ######### ###### ################# # ##### "############" #, #### 
		/// ### ##### ############, ######### ### # ######### ####.
		/// </summary>
		/// <param name="roleId">####, # ####### ##### ######## ##### ############.</param>
		protected void SaveUser(object roleId) {
			bool isNew = false;
			object primaryColumnValue;
			changedValues.TryGetValue("Id", out primaryColumnValue);
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity entity = entitySchema.CreateEntity(UserConnection);
			isNew = !entity.FetchFromDB(primaryColumnValue);
			if (isNew) {
				entity.SetDefColumnValues();
			}
			foreach (KeyValuePair<string, object> item in changedValues) {
				EntitySchemaColumn column = entitySchema.Columns.GetByName(item.Key);
				object columnValue = item.Value;
				if ((column.DataValueType is DateTimeDataValueType) && (item.Value != null)) {
					columnValue = DataTypeUtilities.ValueAsType<DateTime>(item.Value);
				}
				entity.SetColumnValue(column.ColumnValueName, columnValue);
			}
			entity.Save();
			if (isNew) {
				AddUserInRole(entity.PrimaryColumnValue, roleId);
			}
		}
		#endregion Methods: Protected

		#region Methods: Public

		/// <summary>
		/// ######### ##### ###. ##### # ############## #####.
		/// </summary>
		/// <param name="orgRoleIds">############### ####.</param>
		/// <param name="funcRoleId">############## ####.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddFuncRoleInOrgRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddFuncRoleInOrgRoles(string orgRoleIds, string funcRoleId) {
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(orgRoleIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				foreach (var roleId in roleIdList) {
					AddFuncRoleInOrgRole(roleId, funcRoleId);
				}
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### ##### ############## ##### # ###. #####.
		/// </summary>
		/// <param name="orgRoleId">############### ####.</param>
		/// <param name="funcRoleIds">############### ###### ############### ############## #####.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddFuncRolesInOrgRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddFuncRolesInOrgRole(string orgRoleId, string funcRoleIds) {
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(funcRoleIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				foreach (var roleId in roleIdList) {
					AddFuncRoleInOrgRole(orgRoleId, roleId);
				}
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### ############ # ####.
		/// </summary>
		/// <param name="roleIds">####, # ####### ##### ######## ############.</param>
		/// <param name="userId">############# ############.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddUserRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddUserRoles(string roleIds, string userId) {
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(roleIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				foreach (var roleId in roleIdList) {
					AddUserInRole(userId, roleId);
				}
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ####### ### ######## ############.
		/// </summary>
		/// <param name="jsonObject">############### ###### ########## ####### ##### "VwSysAdminUnit".</param>
		/// <param name="roleId">####, # ####### ##### ######## ##### ############.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateOrCreateUser", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateOrCreateUser(string jsonObject, string roleId) {
			string errorMessage = string.Empty;
			changedValues = Json.Deserialize<Dictionary<string, object>>(jsonObject);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				SaveUser(roleId);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### ############# # ####.
		/// </summary>
		/// <param name="roleId">####, # ####### ##### ######## ############.</param>
		/// <param name="userIds">############### ###### ############### #############,
		/// ####### ########## ######## # ######### ####.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddUsersInRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddUsersInRole(string roleId, string userIds) {
			string errorMessage = string.Empty;
			List<object> userIdList = Json.Deserialize<List<object>>(userIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				AddUsersInRole(userIdList, roleId);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### #### ############.
		/// </summary>
		/// <param name="recordId">############# ########## ######.</param>
		/// <param name="roleId">####, # ####### ##### ######## ############.</param>
		/// <param name="userId">############# ############.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveUsersInRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SaveUsersInRole(string recordId, string roleId, string userId) {
			string errorMessage = string.Empty;
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				if (string.IsNullOrEmpty(recordId)) {
					AddUserInRole(userId, roleId);
				} else {
					ChangeUserInRole(recordId, roleId, userId);
				}
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ####### ############# ## ####.
		/// </summary>
		/// <param name="roleIds">############### ###### ############### #####,
		/// ## ####### ########## ####### #############.</param>
		/// <param name="userIds">############### ###### ############### #############,
		/// ####### ########## ####### ## ######### #####.</param>
		/// <param name="recordIds">############### ###### ############### ####### SysUserInRole.</param>
		/// <returns>############### ######, ## ########## Success, DeletedItems # ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemoveUsersInRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RemoveUsersInRoles(string roleIds, string userIds, string recordIds) {
			string exceptionMessage = string.Empty;
			bool success = false;
			List<object> userIdList = Json.Deserialize<List<object>>(userIds);
			List<object> roleIdList = Json.Deserialize<List<object>>(roleIds);
			List<object> recordIdList = Json.Deserialize<List<object>>(recordIds);
			List<Guid> guids = new List<Guid>();
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				if (recordIdList != null && recordIdList.Count > 0) {
					RemoveUserInRoles(recordIdList, guids);
				} else {
					RemoveUsersInRoles(userIdList, roleIdList, guids);
				}
				success = true;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				DeletedItems = guids,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// Modify user connection type on specified.
		/// </summary>
		/// <param name="userId">User Id.</param>
		/// <param name="connectionType">User connection type 0 - General, 1 - SSP.</param>
		/// <returns>Serialized object with properties Success, ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ChangeUserConnectionType", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string ChangeUserConnectionType(string userId, string connectionType) {
			var exceptionMessage = string.Empty;
			var success = false;
			try {
				var connectionTypeValue = Int32.Parse(connectionType);
				var userIdValue = Guid.Parse(userId);
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				RemoveUserInAllRoles(userIdValue);
				AddUserInRole(userIdValue, GetParentRoleByConnectionType(connectionTypeValue));
				changedValues = new Dictionary<string, object>
				{
					{ "Id", userIdValue },
					{ "ConnectionType", connectionTypeValue },
				};
				if (IsUserConnectionTypeGeneral(connectionTypeValue)) {
					changedValues.Add("Active", false);
				}
				SaveUser(null);
				success = true;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// ####### #############.
		/// </summary>
		/// <param name="userIds">############### ###### ############### ############# ### ########</param>
		/// <returns>############### ######, ## ########## Success, IsSecurityException # ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteUser", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeleteUser(string userId) {
			string result = string.Empty;
			bool success = false;
			bool isSecurityException = false;
			string exceptionMessage = null;
			Guid userGuid = Guid.Parse(userId);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				CheckCanDeleteUser(userGuid);
				DeleteUser(userGuid);
				success = true;
			} catch (SecurityException e) {
				isSecurityException = true;
				exceptionMessage = e.Message;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				IsSecurityException = isSecurityException,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// Returns user identifiers by query filters.
		/// </summary>
		/// <param name="filterConfigs">Serialized filters config.</param>
		/// <returns>User identifiers.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUserIds", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetUserIds(string filtersConfig = null) {
			Guid[] primaryColumnValues = new Guid[0];
			string exceptionMessage = string.Empty;
			bool success = false;
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				primaryColumnValues = InnerGetUserIds(filtersConfig);
				success = true;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				UserIds = primaryColumnValues,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		
		/// <summary>
		/// Returns if the user is blocked.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <returns>True if user is blocked, otherwise - false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIsUserBlocked", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetIsUserBlocked(string userId) {
			Guid userGuid = Guid.Parse(userId);
			var blockedUserSelect =
				new Select(SystemUserConnection)
					.Column(Column.Parameter(1))
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userGuid))
				.And("UnblockTime").IsGreater(Column.Parameter(DateTime.UtcNow)) as Select;
			using (DBExecutor dbExecutor = SystemUserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = blockedUserSelect.ExecuteReader(dbExecutor)) {
					return dataReader.Read();
				}
			}
		}

		/// <summary>
		/// Unblocks user, blocked after several unsuccessful password attempts.
		/// </summary>
		/// <param name="userIds">User identifier</param>
		/// <returns>Serialized object, with properties Success, IsSecurityException # ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UnblockUser", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UnblockUser(string userId) {
			string result = string.Empty;
			bool success = false;
			bool isSecurityException = false;
			string exceptionMessage = null;
			try {
				Guid userGuid = Guid.Parse(userId);
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				new Update(UserConnection, "SysAdminUnit")
					.Set("UnblockTime", Column.Parameter(null, "DateTime"))
					.Where("Id").IsEqual(Column.Parameter(userGuid)).Execute();
				success = true;
			} catch (SecurityException e) {
				isSecurityException = true;
				exceptionMessage = e.Message;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				IsSecurityException = isSecurityException,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		#endregion Methods: Public

	}

	#endregion Class: AdministrationService

}
