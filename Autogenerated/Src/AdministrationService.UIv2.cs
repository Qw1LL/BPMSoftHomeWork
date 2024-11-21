namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
  	using BPMSoft.Core.OrgStructure;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: AdministrationService

	[ServiceContract]
	[SspServiceRoute]
	[DefaultServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public partial class AdministrationService
	{


		#region Properties: Protected

		private IOrgStructureManager _orgStructureManager;
		/// <summary>
		/// Gets IOrgStructureManager instance.
		/// </summary>
		protected IOrgStructureManager OrgStructureManager {
			get => _orgStructureManager ?? (_orgStructureManager = new OrgStructureManager(UserConnection));
			set => _orgStructureManager = value;
		}

		#endregion

		#region Properties: Public

		private UserConnection _userConnection;

		/// <summary>
		/// ################ ###########.
		/// </summary>
		public UserConnection UserConnection {
			get {
				return _userConnection ?? (_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection);
			}
			set {
				_userConnection = value;
			}
		}

		#endregion

		#region Constructors: Public

		public AdministrationService() {
		}

		public AdministrationService(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private string GetSessionId(Guid sessionRecordId) {
			string sessionId = null;
			Select getSessionIdSelect =
				new Select(UserConnection)
					.Column("SessionId")
					.From("SysUserSession")
					.Where("Id").IsEqual(Column.Parameter(sessionRecordId)) as Select;
			getSessionIdSelect.ExecuteReader((IDataReader dataReader) => {
				sessionId = dataReader.GetColumnValue<string>("SessionId");
			});
			return sessionId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ##### ######### ##### ### ######### ######.
		/// </summary>
		/// <param name="recordId">### ############.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "TerminateSession", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int TerminateSession(string recordId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			if (!Guid.TryParse(recordId, out Guid parsedRecordId)) {
				return -1;
			}
			string sessionId = GetSessionId(parsedRecordId);
			if (string.IsNullOrWhiteSpace(sessionId)) {
				return -1;
			}
			var userSessionManager = ClassFactory.Get<IUserSessionManager>();
			userSessionManager.Expire(sessionId);
			return 1;
		}

		/// <summary>
		/// Завершить все сессии пользователя.
		/// </summary>
		/// <param name="userId">Id пользователя</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "TerminateUserSessions", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int TerminateUserSessions(string userId)
		{
			if (!Guid.TryParse(userId, out Guid parsedUserId))
			{
				return -1;
			}
			var userSessionManager = ClassFactory.Get<IUserSessionManager>();
			userSessionManager.Expire(parsedUserId);
			return 1;
			
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ValidatePassword", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		/// <summary>
		/// ##### ######### ###### ## ############ ######## ############, ########### # #######.
		/// </summary>
		/// <param name="userName">### ############.</param>
		/// <param name="password">######, ####### ##### ############.</param>
		/// <returns>##### ##########, #### # ######## ######### #### ############# ########## SecurityException, ##### ###### ######.</returns>
		public string ValidatePassword(string userName, string password) {
			string validationMessage = string.Empty;
			try {
				password.ValidatePassword(UserConnection, userName);
			} catch (SecurityException ex) {
				validationMessage = ex.Message;
			}
			return validationMessage;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ActualizeAdminUnitInRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		/// <summary>
		/// Actualizes SysAdminUnitInRole.
		/// </summary>
		/// <returns><b>true</b>, if actualizing was successful, <b>false</b> - otherwise.</returns>
		public bool ActualizeAdminUnitInRole() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			int result = OrgStructureManager.ActualizeSysAdminUnitInRole();
			return result >= 0;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetChildAdminUnitsAndUsersCount",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		/// <summary>
		/// ##### ## ########### ############## #### ####### ############## #### ########
		/// ############### ### ############## ##### # ########## ############# # #### #####.
		/// </summary>
		/// <param name="parentRoleId">############# ############### ### ##############
		/// ####.</param>
		/// <returns>#######, ######### ## #### ######### - ###### ###############
		/// ########### ##### # ####### ####, # ###### ####### - ########## #############
		/// # #### #####</returns>
		public Dictionary<string, object> GetChildAdminUnitsAndUsersCount(string parentRoleId) {
			object[] groups = GetChildAdminUnits(parentRoleId);
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysUserInRole:SysUser:Id].[SysAdminUnit:Id:SysRole].Id", groups));
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysAdminUnitTypeValue", BPMSoft.Core.DB.SysAdminUnitType.User));
			EntityCollection entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			var result = new Dictionary<string, object>();
			result.Add("deletedItems", groups);
			result.Add("userCount", entities.Count);
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetChildAdminUnits", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		/// <summary>
		/// ##### ## ########### ############## #### ###### ###### # ########## ############## #### ######## ###############
		/// (###########, #############, ############ ### #######) ### ############## ##### ####### ##########.
		/// </summary>
		/// <param name="parentRoleId">############# ############### ### ############## ####.</param>
		/// <returns>###### ############### #### ########### ############### #####, ####### ##########.</returns>
		public object[] GetChildAdminUnits(string parentRoleId) {
			Select adminUnitSelect =
				new BPMSoft.Core.DB.Select(UserConnection).Column("Id")
					.As("Id")
					.Column("Name")
					.As("Name")
					.Column("ParentRoleId")
					.As("ParentRoleId")
					.From("SysAdminUnit")
					.Where("SysAdminUnitTypeValue")
						.In(Column.Parameter(BPMSoft.Core.DB.SysAdminUnitType.Organisation, "AdminUnitType_Organisation", Common.ParameterDirection.Input),
							Column.Parameter(BPMSoft.Core.DB.SysAdminUnitType.Department, "AdminUnitType_Department", Common.ParameterDirection.Input),
							Column.Parameter(BPMSoft.Core.DB.SysAdminUnitType.Manager, "AdminUnitType_Manager", Common.ParameterDirection.Input),
							Column.Parameter(BPMSoft.Core.DB.SysAdminUnitType.Team, "AdminUnitType_Team", Common.ParameterDirection.Input),
							Column.Parameter(6, "AdminUnitType_FunctionalRole", Common.ParameterDirection.Input)) as Select;
			HierarchicalSelectOptions options = new HierarchicalSelectOptions()
			{
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentRoleId",
				SelectType = HierarchicalSelectType.Children
			};
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("ParentRoleId");
			startingCondition.IsEqual(Column.Parameter(new Guid(parentRoleId), "FolderId", Common.ParameterDirection.Input));
			adminUnitSelect.HierarchicalOptions = options;
			var list = new List<object>();
			list.Add(new Guid(parentRoleId));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection())
			{
				using (IDataReader reader = adminUnitSelect.ExecuteReader(dbExecutor))
				{
					while (reader.Read())
					{
						Guid id = reader.GetColumnValue<Guid>("Id");
						list.Add(id);
					}
				}
			}
			return list.ToArray();
		}
		#endregion Methods: Public
	}
	#endregion Class: AdministrationService
}

