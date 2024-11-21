namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using Newtonsoft.Json;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;

	public partial class AdministrationService
	{
		/// <summary>
		/// SystemUserConnection for role which is created for portal users management
		/// without defined DB tables and views access through his UserConnection
		/// </summary>
		protected UserConnection SystemUserConnection {
			get {
				return UserConnection.AppConnection.SystemUserConnection;
			}
		}

		/// <summary>
		/// Creates records in "SysUserInRole" table for users
		/// </summary>
		/// <param name="userId">user Id</param>
		/// <param name="roleId">role Id</param>
		private void AddPortalUserInRole(object userId, object roleId) {
			List<object> listUsers = new List<object>();
			listUsers.Add(userId);
			CheckCanChangeUserData(Guid.Parse(userId.ToString()));
			AddPortalUsersInRole(listUsers, roleId);
		}

		private bool IsPortalUser(Guid userId) {
			var select = new Select(UserConnection).Column("Id").From("SysAdminUnit")
				.Where("ConnectionType").IsEqual(Column.Const(1)).And("Id").IsEqual(Column.Parameter(userId)) as Select;
			return select.ExecuteScalar<Guid>() == userId;
		}

		private void CheckCanChangeUserData(Guid userId) {
			if (!IsPortalUser(userId)) {
				throw new SecurityException(string.Format(
					new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Update"), "SysAdminUnit"));
			}
		}

		/// <summary>
		/// Creates records in "SysUserInRole" table for users
		/// </summary>
		/// <param name="userIds">List of user Id</param>
		/// <param name="roleId">role Id</param>
		private void AddPortalUsersInRole(List<object> userIds, object roleId) {
			EntitySchema tableSchema = SystemUserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
			foreach (object userId in userIds) {
				Entity sysUserInRole = tableSchema.CreateEntity(SystemUserConnection);
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
		/// Deletes user
		/// </summary>
		/// <param name="userId">user Id</param>
		private void DeletePortalUser(Guid userId) {
			CheckCanChangeUserData(userId);
			EntitySchema adminUnitSchema = SystemUserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity adminUnitEntity = adminUnitSchema.CreateEntity(SystemUserConnection);
			if (adminUnitEntity.FetchFromDB(userId)) {
				adminUnitEntity.Delete();
			}
		}

		/// <summary>
		/// Adds user package license.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="sysPackageId">Licensing package identifier.</param>
		private void AddPortalSysLicUser(Guid userId, Guid sysPackageId) {
			CheckCanChangeUserData(userId);
			UserConnection.AppConnection.LicManager.AddUserLicense(SystemUserConnection, userId, sysPackageId);
		}

		/// <summary>
		/// Deletes user package license.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="sysPackageId">Licensing package identifier.</param>
		private void DeletePortalSysLicUser(Guid userId, Guid sysPackageId) {
			CheckCanChangeUserData(userId);
			UserConnection.AppConnection.LicManager.DeleteUserLicense(SystemUserConnection, userId, sysPackageId);
		}

		/// <summary>
		/// Saves SysAdminUnit with PortalUser type.
		/// If it is a new user - adds him to defined role.
		/// </summary>
		/// <param name="roleId">Role Id for user.</param>
		protected void SavePortalUser(object roleId) {
			bool isNew = false;
			object primaryColumnValue;
			changedValues.TryGetValue("Id", out primaryColumnValue);
			EntitySchema entitySchema = SystemUserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity entity = entitySchema.CreateEntity(SystemUserConnection);
			isNew = !entity.FetchFromDB(primaryColumnValue);
			if (isNew) {
				entity.SetDefColumnValues();
			} else {
				CheckCanChangeUserData(Guid.Parse(primaryColumnValue.ToString()));
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
				AddPortalUserInRole(entity.PrimaryColumnValue, roleId);
			}
		}

		/// <summary>
		/// Creates or updates existing user.
		/// </summary>
		/// <param name="jsonObject">Serialized list of changed columns in "VwSysAdminUnit" schema.</param>
		/// <param name="roleId">Role Id for new user.</param>
		/// <returns>Exception message or empty string.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateOrCreatePortalUser", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateOrCreatePortalUser(string jsonObject, string roleId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanAdministratePortalUsers");
			string errorMessage = string.Empty;
			changedValues = Json.Deserialize<Dictionary<string, object>>(jsonObject);
			try {
				SavePortalUser(roleId);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// Check permission for CRUD operation on portal user record.
		/// </summary>
		/// <param name="userId">User record Id for portal user.</param>
		/// <returns>Exception message if user don't have permission
		/// or empty string if CRUD operation allowed.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CanChangePortalUserData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CanChangePortalUserData(string userId) {
			if (UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageUsers")) {
				return string.Empty;
			}
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanAdministratePortalUsers");
			string errorMessage = string.Empty;
			try {
				CheckCanChangeUserData(Guid.Parse(userId.ToString()));
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// Deletes users.
		/// </summary>
		/// <param name="userIds">Serealized list of userIds to delete.</param>
		/// <returns>Serealized object with Success, IsSecurityException and ExceptionMessage properties.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeletePortalUser", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeletePortalUser(string userId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanAdministratePortalUsers");
			string result = string.Empty;
			bool success = false;
			bool isSecurityException = false;
			string exceptionMessage = null;
			Guid userGuid = Guid.Parse(userId);
			try {
				DeletePortalUser(userGuid);
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
		/// Adds user in role.
		/// </summary>
		/// <param name="roleIds">Roles for user to add</param>
		/// <param name="userId">User identifier.</param>
		/// <returns>Exception message or empty string.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddPortalUserRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddPortalUserRoles(string roleIds, string userId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanAdministratePortalUsers");
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(roleIds);
			try {
				foreach (var roleId in roleIdList) {
					AddPortalUserInRole(userId, roleId);
				}
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// Deletes portal users from roles.
		/// </summary>
		/// <param name="roleIds">Serealized list of roleIds.</param>
		/// <param name="userIds">Serealized list of userIds.</param>
		/// <param name="recordIds">Serealized list of SysUserInRole record identifiers.</param>
		/// <returns>Serealized object with Success, IsSecurityException and ExceptionMessage properties.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemovePortalUsersInRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RemovePortalUsersInRoles(string roleIds, string userIds, string recordIds) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanAdministratePortalUsers");
			string exceptionMessage = string.Empty;
			bool success = false;
			List<object> userIdList = Json.Deserialize<List<object>>(userIds);
			List<object> roleIdList = Json.Deserialize<List<object>>(roleIds);
			List<object> recordIdList = Json.Deserialize<List<object>>(recordIds);
			List<Guid> guids = new List<Guid>();
			try {
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
		/// Updates users licenses.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="licenseItems">Serealized dictionary with license identifier as a key,
		/// and IsActive attribute as a value.</param>
		/// <returns>Exception message or empty string.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdatePortalLicenseInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdatePortalLicenseInfo(string userId, string licenseItems) {
			Dictionary<string, bool> licenses = Json.Deserialize<Dictionary<string, bool>>(licenseItems);
			var sb = new StringBuilder();
			foreach (KeyValuePair<string, bool> licItem in licenses) {
				var userGuid = new Guid(userId);
				var sysPackageGuid = new Guid(licItem.Key);
				bool userHasLicense = GetUserHasLicense(userGuid, sysPackageGuid);
				if (licItem.Value && !userHasLicense) {
					string errors = HasLicErrors(sysPackageGuid);
					if (errors.Length > 0) {
						sb.Append(errors);
					} else {
						AddPortalSysLicUser(userGuid, sysPackageGuid);
					}
				}
				if (!licItem.Value && userHasLicense) {
					DeletePortalSysLicUser(userGuid, sysPackageGuid);
				}
			}
			if (sb.Length > 0) {
				return string.Format(
					new LocalizableString("BPMSoft.WebApp.Loader", "LicManager.PaidLicenseCountExceededMessage"), sb);
			}
			return string.Empty;
		}
	}
}

