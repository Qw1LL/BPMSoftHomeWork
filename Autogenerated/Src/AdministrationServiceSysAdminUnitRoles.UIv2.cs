namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: AdministrationService

	public partial class AdministrationService
	{

		#region Constants: Public

		public const int FunctionalRoleTypeValue = 6;
		#endregion Constants: Public

		#region Fields: Private

		private static ConcurrentDictionary<int, string> Cache = new ConcurrentDictionary<int, string>();

		#endregion Fields: Private

		#region Properties: Private
		private string FunctionalRoleTypeId {
			get { 
				return GetTypeIdByValue(FunctionalRoleTypeValue);
			}
		}

		#endregion Properties: Private

		#region Methods: Private
		/// <summary>
		/// ########## ######## ############### # ############ # ##### #######
		/// </summary>
		/// <param name="column">####### ##### ######## ### ####### ########## ########.</param>
		/// <param name="value">############# ########.</param>
		/// <returns>############### ########.</returns>
		private static object GetColumnValue(EntitySchemaColumn column, object value) {
			if (column.DataValueType is DateTimeDataValueType) {
				return DataTypeUtilities.ValueAsType<DateTime>(value);
			}
			if (column.DataValueType is LookupDataValueType){
				return String.IsNullOrEmpty((string)value) ? null : value;
			}
			return value;
		}
		
		/// <summary>
		/// ######### ######### ######## # #######.
		/// </summary>
		/// <param name="roleEntity">########, # ####### ##### ########### ######## #######.</param>
		/// <param name="nameValuePair">### # ######## #######.</param>
		private void SetRoleColumnValue(Entity roleEntity, KeyValuePair<string, object> nameValuePair) {
			EntitySchemaColumn column = roleEntity.Schema.Columns.GetByName(nameValuePair.Key);
			object columnValue = GetColumnValue(column, nameValuePair.Value);
			roleEntity.SetColumnValue(column.ColumnValueName, columnValue);
		}

		/// <summary>
		/// ######### ######### ##### #### # ## ##########.
		/// </summary>
		/// <param name="roleEntity">########, # ####### ##### ########## ######.</param>
		/// <param name="columnValues">######### ######## ####### #######.</param>
		/// <returns>############# ####.</returns>
		private object ChangeEntityAndSave(Entity roleEntity, Dictionary<string, object> columnValues) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			columnValues.ForEach(kvp => SetRoleColumnValue(roleEntity, kvp));
			roleEntity.Save();
			return roleEntity.GetColumnValue("Id");
		}

		/// <summary>
		/// ######### ### #### ###### #############.
		/// </summary>
		/// <param name="name">### #### ### ####### ######### ###### #############.</param>
		/// <returns>### #### ### ###### #############.</returns>
		private string GetChiefRoleName(object name) {
			return String.Concat(name,
				new LocalizableString(UserConnection.Workspace.ResourceStorage, "AdministrationServiceSysAdminUnitRoles",
					"LocalizableStrings.ChiefDefaultNamePostfix.Value"));
		}

		/// <summary>
		/// ######## ############# #### ## ### ######.
		/// </summary>
		/// <param name="type">##### ####.</param>
		/// <returns>############# ####.</returns>
		private string GetTypeIdByValue(int type) {
			string result;
			if (!Cache.TryGetValue(type, out result)) {
				var select = (Select)new Select(UserConnection).Top(1)
					.Column("Id")
					.From("SysAdminUnitType")
					.Where("Value").IsEqual(Column.Parameter(type));
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
						if (dataReader.Read()) {
							result = dataReader.GetColumnValue<string>("Id");
							Cache.GetOrAdd(type, result);
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// ######### ##### ######### ## ######.
		/// </summary>
		/// <param name="e">########## <see cref="DbOperationException"/>, ############### ### ########## #######.</param>
		/// <returns>############## ##### ######### ## ######.</returns>
		private string GetExceptionMessage(DbOperationException e) {
			SqlException innerException = e.InnerException as SqlException;
			if ((innerException != null && innerException.Number == 2601)
				|| e.InnerException.Message.StartsWith("ORA-00001") || e.InnerException.Message.StartsWith("23505")) {
				return new LocalizableString(
					UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceSysAdminUnitRoles",
					"LocalizableStrings.CannotDuplicateSysAdminUnitRoleName.Value");
			}
			return new LocalizableString(
					UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceSysAdminUnitRoles",
					"LocalizableStrings.OperationExecutedWithError.Value");
			
		}
		

		/// <summary>
		/// #########, ########## ## ######## VwSysAdminUnit # ##### Id # ######## #####, ########### ##########.
		/// #### ### SysAdminUnitType ## ############## ####, ## ####### ############# ######## # ##### ############.
		/// </summary>
		/// <param name="columnValues">######### ######## ####### #######.</param>
		/// <returns>############# ####.</returns>
		private object SaveRoleEntity(Dictionary<string, object> columnValues) {
			object targetRole;
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity roleEntity = entitySchema.CreateEntity(UserConnection);
			if (!roleEntity.FetchFromDB(columnValues["Id"])) {
				roleEntity.SetDefColumnValues();
			}
			targetRole = ChangeEntityAndSave(roleEntity, columnValues);
			return targetRole;
		}
		
		/// <summary>
		/// ######### ########## #### #############.
		/// </summary>
		/// <param name="id">############# ######, ### ####### ## ######### ###### #############.</param>
		/// <param name="name">### ######, ### ####### ## ######### ###### #############.</param>
		/// <returns>############# #### #############.</returns>
		private object SaveChiefsRoleEntity(string id, string name) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity chiefRoleEntity = entitySchema.CreateEntity(UserConnection);
			chiefRoleEntity.SetDefColumnValues();
			chiefRoleEntity.SetColumnValue("Name", GetChiefRoleName(name));
			chiefRoleEntity.SetColumnValue("ParentRoleId", id);
			chiefRoleEntity.SetColumnValue("SysAdminUnitTypeId", GetTypeIdByValue((int)BPMSoft.Core.DB.SysAdminUnitType.Manager));
			chiefRoleEntity.Save();
			return chiefRoleEntity.GetColumnValue("Id");
		}

		#endregion Methods: Private

		#region Methods: Public

		/// <summary>
		/// ######### ########## ####. #### ########### ########## ##### #### # ### #### ## ######## ##############,
		/// ## ##### ####### # #### #############. #### #### ##########, ## ##### ######### ## ##########.
		/// </summary>
		/// <param name="jsonObject">############### ###### ########## ####### ##### "VwSysAdminUnit".</param>
		/// <returns>############### ######, ########## ######## success, ############# ####, ####
		/// success = true, ### ##### ######, #### success = false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SaveRole(string jsonObject) {
			object result, targetRole = null;
			string exceptionMessage = string.Empty;
			Dictionary<string, object> columnValues = Json.Deserialize<Dictionary<string, object>>(jsonObject);
			try {
				targetRole = SaveRoleEntity(columnValues);
			} catch (DbOperationException e) {
				exceptionMessage = GetExceptionMessage(e);
			} catch (SecurityException e) {
				exceptionMessage = e.Message;
			} finally {
				if (targetRole != null) {
					result = new {
						success = true,
						roleId = targetRole
					};
				} else {
					result = new {
						success = false,
						message = exceptionMessage
					};
				}
			}
			return Serialize(result, true);
		}

		/// <summary>
		/// ######### ########## #### ############.
		/// </summary>
		/// <param name="id">############# ######, ### ####### ## ######### ###### #############.</param>
		/// <param name="name">### ######, ### ####### ## ######### ###### #############.</param>
		/// <returns>############### ######, ########## ######## success, ############# ####, ####
		/// success = true, ### ##### ######, #### success = false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveChiefsRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SaveChiefsRole(string id, string name) {
			object result, targetRole = null;
			string exceptionMessage = string.Empty;
			try {
				targetRole = SaveChiefsRoleEntity(id, name);
			} catch (DbOperationException e) {
				exceptionMessage = GetExceptionMessage(e);
			} catch(SecurityException e) {
				exceptionMessage = e.Message;
			} finally {
				if (targetRole != null) {
					result = new {
						success = true,
						roleId = targetRole
					};
				} else {
					result = new {
						success = false,
						message = exceptionMessage
					};
				}
			}

			return Serialize(result, true);
		}
		
		/// <summary>
		/// ####### ########## ############# # ######### ####.
		/// </summary>
		/// <param name="roleId">############# ####.</param>
		/// <returns>########## ############# # ######### ####.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUsersCount", 
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
			ResponseFormat = WebMessageFormat.Json)]
		public int GetUsersCount(string roleId) {
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			EntitySchemaQueryColumn countColumn = entitySchemaQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"[SysUserInRole:SysUser:Id].[SysAdminUnit:Id:SysRole].Id", roleId));
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"SysAdminUnitTypeValue", BPMSoft.Core.DB.SysAdminUnitType.User));
			Entity summary = entitySchemaQuery.GetSummaryEntity(UserConnection);
			return (summary != null) ? summary.GetTypedColumnValue<int>(countColumn.Name) : 0;
		}

		#endregion Methods: Public

	}

	#endregion Class: AdministrationService

}


