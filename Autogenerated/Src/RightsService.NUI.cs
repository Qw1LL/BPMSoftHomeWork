namespace BPMSoft.Configuration.RightsService
{
	using System;
	using System.Collections.Generic;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: RightsService

	/// <summary>
	/// A web service used to manage rights.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class RightsService : BaseService, IReadOnlySessionState
	{

		#region Methods: Private

		private BaseResponse ExecuteSecurityOperation(Action<RightsHelper> securityOperationAction) {
			RightsHelper rightsHelper = GetRightsServiceHelper();
			var response = new BaseResponse();
			try {
				securityOperationAction(rightsHelper);
			} catch (Exception e) {
				response.SetRunTimeException(e);
			}
			return response;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns an instance of the <see cref="RightsHelper"/> type.
		/// </summary>
		protected RightsHelper GetRightsServiceHelper() {
			return ClassFactory.Get<RightsHelper>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// #########, ### ######## ############, 
		/// ########### ######### #### ####### # ########.
		/// ########## ###### # ####### JSON, # ########### ##########.
		/// </summary>
		/// <returns>C##### # ####### JSON. 
		/// ######## ############### ###### # ######:
		/// Success - ########## ########## ######,
		/// ExMessage - ##### ######, #### Success = false </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CheckCanChangeAdminOperationGrantee",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string CheckCanChangeAdminOperationGrantee() {
			RightsHelper helper = GetRightsServiceHelper();
			return helper.CheckCanChangeAdminOperationGrantee();
		}

		/// <summary>
		/// Check whether the user can change process execution grantee.
		/// </summary>
		/// <returns>Base response with result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CheckCanChangeProcessExecutionGrantee", 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse CheckCanChangeProcessExecutionGrantee() {
			return ExecuteSecurityOperation(rightsHelper => rightsHelper.CheckCanChangeProcessExecutionGrantee());
		}

		/// <summary>
		/// ###### ##### ####### ############ # ########.
		/// ########## ###### # ####### JSON, # ########### ##########.
		/// </summary>
		/// <param name="adminOperationId">Id ########</param>
		/// <param name="adminUnitIds">###### Id #############/#####</param>
		/// <param name="canExecute">###### # ########</param>
		/// <returns>C##### # ####### JSON. 
		/// ######## ############### ###### # ######:
		/// Success - ########## ########## ######,
		/// ExMessage - ##### ######, #### Success = false </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetAdminOperationGrantee", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SetAdminOperationGrantee(Guid adminOperationId, Guid[] adminUnitIds, bool canExecute) {
			RightsHelper helper = GetRightsServiceHelper();
			return helper.SetAdminOperationGrantee(adminOperationId, adminUnitIds, canExecute);
		}

		/// <summary>
		/// Sets process execution grantee.
		/// </summary>
		/// <param name="processSchemaUId">Process schema unique identifier.</param>
		/// <param name="adminUnitIds">Enumerable of the admin unit identifiers</param>
		/// <param name="canExecute">Can execute or not.</param>
		/// <returns>Base response with result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetProcessExecutionGrantees", 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse SetProcessExecutionGrantees(Guid processSchemaUId, IEnumerable<Guid> adminUnitIds,
				bool canExecute) {
			return ExecuteSecurityOperation(rightsHelper =>
				rightsHelper.SetProcessExecutionGrantees(processSchemaUId, adminUnitIds, canExecute));
		}

		/// <summary>
		/// ###### ####### ##### ####### ############ # ########.
		/// ########## ###### # ####### JSON, # ########### ##########.
		/// </summary>
		/// <param name="granteeId">############# ##### #######.</param>
		/// <param name="position">##### ######## #### #######.</param>
		/// <returns>C##### # ####### JSON. 
		/// ######## ############### ###### # ######:
		/// Success - ########## ########## ######,
		/// ExMessage - ##### ######, #### Success = false </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetAdminOperationGranteePosition", 
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string SetAdminOperationGranteePosition(Guid granteeId, int position) {
			RightsHelper helper = GetRightsServiceHelper();
			return helper.SetAdminOperationGranteePosition(granteeId, position);
		}

		/// <summary>
		/// Sets process execution grantee position.
		/// </summary>
		/// <param name="processSchemaUId">Process schema unique identifier.</param>
		/// <param name="adminUnitId">Admin unit identifier</param>
		/// <param name="position">New position value.</param>
		/// <returns>Base response with result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetProcessExecutionGranteePosition", 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse SetProcessExecutionGranteePosition(Guid processSchemaUId, Guid adminUnitId, int position) {
			return ExecuteSecurityOperation(rightsHelper =>
				rightsHelper.SetProcessExecutionGranteePosition(processSchemaUId, adminUnitId, position));
		}

		/// <summary>
		/// ####### ##### ####### # ########.
		/// ########## ###### # ####### JSON, # ########### ##########.
		/// </summary>
		/// <param name="recordIds">###### Id #### #######</param>
		/// <returns>C##### # ####### JSON. 
		/// ######## ############### ###### # ######:
		/// Success - ########## ########## ######,
		/// ExMessage - ##### ######, #### Success = false </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteAdminOperationGrantee",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string DeleteAdminOperationGrantee(Guid[] recordIds) {
			RightsHelper helper = GetRightsServiceHelper();
			return helper.DeleteAdminOperationGrantee(recordIds);
		}

		/// <summary>
		/// Removes rights for process execution.
		/// </summary>
		/// <param name="processSchemaUId">Process schema unique identifier.</param>
		/// <param name="adminUnitIds">Enumerable of the admin unit identifiers.</param>
		/// <returns>Base response with result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteProcessExecutionGrantees",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse DeleteProcessExecutionGrantees(Guid processSchemaUId, IEnumerable<Guid> adminUnitIds) {
			return ExecuteSecurityOperation(rightsHelper =>
				rightsHelper.DeleteProcessExecutionGrantees(processSchemaUId, adminUnitIds));
		}

		/// <summary>
		/// ####### ### ######## ########.
		/// </summary>
		/// <param name="recordId">Id ########</param>
		/// <param name="name">######## ########</param>
		/// <param name="code">### ########</param>
		/// <param name="description">######## ########</param>
		/// <returns>C##### # ####### JSON. 
		/// ######## ############### ###### # ######:
		/// Success - ########## ########## ######,
		/// ExMessage - ##### ######, #### Success = false </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpsertAdminOperation", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpsertAdminOperation(Guid recordId, String name, String code, String description) {
			RightsHelper helper = GetRightsServiceHelper();
			return helper.UpsertAdminOperation(recordId, name, code, description);
		}

		/// <summary>
		/// Deletes operations.
		/// Returns JSON-string, containing execution result.
		/// </summary>
		/// <param name="recordIds">Array of operation Ids.</param>
		/// <returns>JSON-string that contains serialized object with fields:
		/// Success - indicates success of method execution,
		/// ExMessage - error messase, if Success = false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteAdminOperation", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeleteAdminOperation(Guid[] recordIds) {
			RightsHelper helper = GetRightsServiceHelper();
			return helper.DeleteAdminOperation(recordIds);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSchemaOperationRightLevel", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SchemaOperationRightLevels GetSchemaOperationRightLevel(string schemaName) {
			var rightsHelper = GetRightsServiceHelper();
			return rightsHelper.GetSchemaOperationRightLevel(schemaName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSchemaDeleteRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetSchemaDeleteRights(string schemaName) {
			var rightsHelper = GetRightsServiceHelper();
			if (rightsHelper.GetCanDeleteSchemaOperationRight(schemaName)) {
				return string.Empty;
			}
			SchemaOperationRightLevels rightLevels = UserConnection.LicHelper.GetSchemaLicRights(schemaName, true);
			bool hasLicRight = (rightLevels & SchemaOperationRightLevels.CanDelete) == SchemaOperationRightLevels.CanDelete;
			if (hasLicRight) {
				return "RightLevelWarningMessage";
			}
			return "LicenceNotFound";
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSchemaEditRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetSchemaEditRights(string schemaName) {
			var rightsHelper = GetRightsServiceHelper();
			return !rightsHelper.GetCanEditSchemaOperationRight(schemaName) ? "RightLevelWarningMessage" : string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSchemaReadRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetSchemaReadRights(string schemaName) {
			var rightsHelper = GetRightsServiceHelper();
			return !rightsHelper.GetCanEditSchemaOperationRight(schemaName) ? "RightLevelWarningMessage" : string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSchemaRecordRightLevel", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SchemaRecordRightLevels GetSchemaRecordRightLevel(string schemaName, string primaryColumnValue) {
			var rightsHelper = GetRightsServiceHelper();
			return rightsHelper.GetSchemaRecordRightLevel(schemaName, new Guid(primaryColumnValue));
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanDelete", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetCanDelete(string schemaName, string primaryColumnValue) {
			var rightsHelper = GetRightsServiceHelper();
			if (!rightsHelper.GetCanDeleteSchemaRecordRight(schemaName, new Guid(primaryColumnValue))) {
				SchemaOperationRightLevels rightLevels = UserConnection.LicHelper.GetSchemaLicRights(schemaName, true);
				bool hasLicRight = (rightLevels & SchemaOperationRightLevels.CanDelete) == SchemaOperationRightLevels.CanDelete;
				if (hasLicRight) {
					return "RightLevelWarningMessage";
				}
				return string.Format(new LocalizableString("BPMSoft.Core", "LicHelper.Exception.LicenceNotFound"));
			}
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanDeleteRecords", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetCanDeleteRecords(string schemaName, Guid[] primaryColumnValues) {
			var rightsHelper = GetRightsServiceHelper();
			foreach (var id in primaryColumnValues) {
				if (!rightsHelper.GetCanDeleteSchemaRecordRight(schemaName, id)) {
					SchemaOperationRightLevels rightLevels = UserConnection.LicHelper.GetSchemaLicRights(schemaName, true);
					bool hasLicRight = (rightLevels & SchemaOperationRightLevels.CanDelete) == SchemaOperationRightLevels.CanDelete;
					if (hasLicRight) {
						return "RightLevelWarningMessage";
					}
					return string.Format(new LocalizableString("BPMSoft.Core", "LicHelper.Exception.LicenceNotFound"));
				}
			}
			return string.Empty;
		}

		/// <summary>
		/// Returns empty string if schema can be added or edited. Otherwise returns error text string.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="primaryColumnValue">Schema id.</param>
		/// <param name="isNew">New or existing schema state</param>
		/// <returns>Empty string if schema can be added or edited. Otherwise returns error text string.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanEdit", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetCanEdit(string schemaName, Guid primaryColumnValue, bool isNew) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			var rightsHelper = GetRightsServiceHelper();
			SchemaOperationRightLevels rightLevels = UserConnection.LicHelper.GetSchemaLicRights(schemaName, true);
			if (isNew) {
				bool canAppend = (rightLevels & SchemaOperationRightLevels.CanAppend) == SchemaOperationRightLevels.CanAppend;
				return rightsHelper.GetCanAppendSchemaOperationRight(schemaName)
					? string.Empty
					: (canAppend
						? string.Format(new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Insert"), schema.Caption.Value)
						: string.Format(new LocalizableString("BPMSoft.Core", "LicHelper.Exception.LicenceNotFound")));
			}
			bool canEditByLicRight = (rightLevels & SchemaOperationRightLevels.CanEdit) == SchemaOperationRightLevels.CanEdit;
			bool canEditSchemaRecord = rightsHelper.GetCanEditSchemaRecordRight(schemaName, primaryColumnValue);
			if (rightsHelper.GetCanEditSchemaOperationRight(schemaName) && canEditSchemaRecord) {
				return string.Empty;
			}
			if (!canEditSchemaRecord) {
				return string.Format(new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Update"), schema.Caption.Value);
			}
			return (canEditByLicRight ? string.Format(new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Update"), schema.Caption.Value)
				: string.Format(new LocalizableString("BPMSoft.Core", "LicHelper.Exception.LicenceNotFound")));
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanEditRecords", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<Guid, bool> GetCanEditRecords(string schemaName, Guid[] primaryColumnValues) {
			var recordsEditRights = new Dictionary<Guid, bool>();
			var rightsHelper = GetRightsServiceHelper();
			foreach (var primaryColumnValue in primaryColumnValues) {
				recordsEditRights.Add(primaryColumnValue, rightsHelper.GetCanEditSchemaRecordRight(schemaName, primaryColumnValue));
			}
			return recordsEditRights;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanReadRecords", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<Guid, bool> GetCanReadRecords(string schemaName, Guid[] primaryColumnValues) {
			var recordsReadRights = new Dictionary<Guid, bool>();
			var rightsHelper = GetRightsServiceHelper();
			foreach (var primaryColumnValue in primaryColumnValues) {
				recordsReadRights.Add(primaryColumnValue, rightsHelper.GetCanReadSchemaRecordRight(schemaName, primaryColumnValue));
			}
			return recordsReadRights;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetRecordRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<RecordRight> GetRecordRights(string tableName, string recordId) {
			var rightsHelper = GetRightsServiceHelper();
			return rightsHelper.GetRecordRights(tableName, recordId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetRecordRight", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Guid SetRecordRight(Guid adminUnitId, string schemaName, string administratedRecordId,
			int operation, int rightLevel) {
			var rightsHelper = GetRightsServiceHelper();
			Guid rightId = rightsHelper.SetRecordRight(adminUnitId, schemaName, administratedRecordId, operation, rightLevel);
			return rightId;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ApplyChanges", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ApplyChanges(RecordRight[] recordRights, Record record) {
			var rightsHelper = GetRightsServiceHelper();
			rightsHelper.ApplyChanges(recordRights, record);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUserRecordRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool[] GetUserRecordRights(string userId, string schemaName, string recordId) {
			var rightLevel = UserConnection.DBSecurityEngine.GetEntitySchemaRecordRightLevel(Guid.Parse(userId), schemaName, Guid.Parse(recordId));
			return new bool[] { (((int)rightLevel & (int)SchemaRecordRightLevels.CanChangeReadRight) == (int)SchemaRecordRightLevels.CanChangeReadRight),
				(((int)rightLevel & (int)SchemaRecordRightLevels.CanChangeEditRight) == (int)SchemaRecordRightLevels.CanChangeEditRight),
				(((int)rightLevel & (int)SchemaRecordRightLevels.CanChangeDeleteRight) == (int)SchemaRecordRightLevels.CanChangeDeleteRight) };
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUseDenyRecordRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetUseDenyRecordRights(string schemaName) {
			return UserConnection.EntitySchemaManager.GetInstanceByName(schemaName).UseDenyRecordRights;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetRecordPosition", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetRecordPosition(string schemaName, Guid primaryColumnValue, int position) {
			SetCustomRecordPosition(schemaName, primaryColumnValue, "Operation,RecordId", position);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetCustomRecordPosition", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetCustomRecordPosition(string tableName, Guid primaryColumnValue, string grouppingColumnNames, int position) {
			var rightsHelper = GetRightsServiceHelper();
			rightsHelper.SetCustomRecordPosition(tableName, primaryColumnValue, grouppingColumnNames, position);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanExecuteEntityOperation",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public bool GetCanExecuteEntityOperation(string entityOperationCode, string entitySchemaName) {
			return UserConnection.DBSecurityEngine.GetCanExecuteEntityOperation(entitySchemaName, entityOperationCode);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanExecuteOperation", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetCanExecuteOperation(string operation) {
			return UserConnection.DBSecurityEngine.GetCanExecuteOperation(operation);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanExecuteOperations", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IDictionary<string, bool> GetCanExecuteOperations(string[] operations) {
			var dbSecurityEngine = UserConnection.DBSecurityEngine;
			var dictionary = new Dictionary<string, bool>();
			foreach (var operation in operations) {
				var canExecuteOperation = false;
				try {
					canExecuteOperation = dbSecurityEngine.GetCanExecuteOperation(operation);
				} catch (SecurityException) {
					canExecuteOperation = false;
				}
				dictionary.Add(operation, canExecuteOperation);
			}
			return dictionary;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetHasLicense", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetHasLicense(string licenseName) {
			return UserConnection.LicHelper.GetHasOperationLicense(licenseName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanEditColumns", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, bool> GetCanEditColumns(string schemaName, string[] columnNames) {
			var columnsEditRights = new Dictionary<string, bool>();
			RightsHelper rightsHelper = GetRightsServiceHelper();
			foreach (string columnName in columnNames) {
				columnsEditRights.Add(columnName, rightsHelper.CheckCanEditColumn(schemaName, columnName));
			}
			return columnsEditRights;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CopyRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CopyRights(string schemaName, Guid sourceId, Guid targetId) {
			var rightsHelper = GetRightsServiceHelper();
			rightsHelper.CopyRecordRights(schemaName, sourceId, targetId);
		}

		#endregion

	}

	#endregion

}
