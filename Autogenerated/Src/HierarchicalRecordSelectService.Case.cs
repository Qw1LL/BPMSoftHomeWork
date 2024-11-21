namespace BPMSoft.Configuration.HierarchicalRecordSelectService
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;

	#region Class: HierarchicalRecordSelectService
	/// <summary>
	/// ##### ####### ## ###### # ############# #######
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class HierarchicalRecordSelectService : BaseService
	{
		#region Constants: Private
		const string GetChildrenRecordsProcedure = "tsp_GetChildrenRecords";
		const string GetParentRecordsProcedure = "tsp_GetParentRecords";
		const string ParentRequestType = "parent";
		const string MssqlDbName = "MSSqlExecutor";
		#endregion

		#region Methods: Private
		/// <summary>
		/// ######### ### ########### # #######
		/// </summary>
		/// <param name="userConnection"> ################ ###########/param>
		/// <returns>MSSql - true</returns>
		private bool IsMsSqlServer(UserConnection userConnection) {
			return (userConnection.DBExecutorType.Name == MssqlDbName);
		}

		/// <summary>
		/// ########## ########### # ######## ######### ### MSSql
		/// </summary>
		/// <param name="userConnection">################ ###########</param>
		/// <param name="procedureName">### ########## #########</param>
		/// <returns></returns>
		private BaseStoredProcedure getMsSqlProcedure(UserConnection userConnection, string procedureName) {
			return new StoredProcedure(userConnection, procedureName);
		}

		/// <summary>
		/// ########## ########### # ####### ### Oracle
		/// </summary>
		/// <param name="userConnection">################ ###########</param>
		/// <param name="procedureName">### ########## #######</param>
		/// <returns></returns>
		private BaseStoredProcedure getOracleProcedure(UserConnection userConnection, string procedureName) {
			BaseStoredProcedure result;
			result = new UserDefinedFunction(userConnection, procedureName);
			((UserDefinedFunction)result).ReturnType = UserDefinedFunctionReturnType.Table;

			return result;
		}

		/// <summary>
		/// ########## ######### ########## ###### BaseStoredProcedure 
		/// # ########### ## #### ########### # ####
		/// </summary>
		/// <param name="userConnection"> ################ ###########</param>
		/// <param name="procedureName"> ### ########## #########</param>
		/// <returns>######### ########## ###### BaseStoredProcedure</returns>
		private BaseStoredProcedure GetStoredProcedure(UserConnection userConnection, string procedureName) {
			return IsMsSqlServer(userConnection) ? getMsSqlProcedure(userConnection, procedureName) :
				getOracleProcedure(userConnection, procedureName);
		}
		#endregion

		#region Methods: Public
		/// <summary>
		/// ######## ############# ############ ### ######## ####### ############## ######
		/// </summary>
		/// <param name="request">######.</param>
		/// <returns>###### ############### ####### ############## ######</returns>
		[Obsolete("Method GetRecords deprecated, please use UpdateRecords instead.")]
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public Guid[] GetRecords(ServiceRecordRequest request) {
			var ids = new List<Guid>();
			var procedureName = GetChildrenRecordsProcedure;
			if (request.Type == ParentRequestType) {
				procedureName = GetParentRecordsProcedure;
			}
			var procedure = GetStoredProcedure(UserConnection, procedureName);
			procedure.WithParameter(request.Id);
			procedure.WithParameter(request.SchemaTableName);
			procedure.WithParameter(request.ParentIdColumnName);
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = procedure.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var id = reader.GetColumnValue<Guid>("Id");
						ids.Add(id);
					}
				}
			}

			return ids.ToArray();
		}
		/// <summary>
		/// Get a parent and child records id
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Whether the result is successful</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateRecords(ServiceUpdateRecordRequest request) {
			HierarchicalRecords records;
			var response = new ConfigurationServiceResponse();
			records = new HierarchicalRecords(UserConnection, request.SchemaName, request.ParentColumnName);
			foreach (Guid item in request.ChildrenIds) {
				try {
					bool hasParentResult = records.HasParentInBranch(item, request.ParentId);
					if (hasParentResult) {
						records.RemoveParent(request.ParentId);
						records.ChangeParent(item, request.ParentId);
					} else {
						records.ChangeParent(item, request.ParentId);
					}
				} catch (LoopInHierarchyException ex) {
					response = new ConfigurationServiceResponse(ex);
				}
			}
			return response;
		}

		#endregion
	}

	#endregion

	#region Class: ServiceRecordRequest
	/// <summary>
	/// ##### #######
	/// </summary>
	[DataContract]
	public class ServiceRecordRequest
	{
		#region Properties: Public
		[DataMember]
		public Guid Id {
			get;
			set;
		}

		[DataMember]
		public string SchemaTableName {
			get;
			set;
		}

		[DataMember]
		public string ParentIdColumnName {
			get;
			set;
		}

		[DataMember]
		public string Type {
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region Class: ServiceUpdateRecordRequest
	/// <summary>
	/// Request class
	/// </summary>
	[DataContract]
	public class ServiceUpdateRecordRequest
	{
		#region Properties: Public

		[DataMember]
		public Guid ParentId {
			get;
			set;
		}

		[DataMember]
		public Guid[] ChildrenIds {
			get;
			set;
		}

		[DataMember]
		public string SchemaName {
			get;
			set;
		}

		[DataMember]
		public string ParentColumnName {
			get;
			set;
		}

		#endregion
	}

	#endregion Class: ServiceUpdateRecordRequest	
}

