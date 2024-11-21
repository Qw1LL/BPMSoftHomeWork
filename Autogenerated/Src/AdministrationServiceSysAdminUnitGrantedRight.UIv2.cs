namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using System;
	using BPMSoft.Common.Json;

	#region Class: AdministrationService
	public partial class AdministrationService
	{
		
		#region Methods: Private
		/// <summary>
		/// ######### ##### ###### # # ####### SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="granteeSysAdminUnitId">######## ####### "######## #####".</param>
		/// <param name="grantorSysAdminUnitId">######## ####### "####### #####".</param>
		private void InsertSysAdminUnitGrantedRight(object granteeSysAdminUnitId, object grantorSysAdminUnitId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanChangeAdminUnitGrantedRight");
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysAdminUnitGrantedRight");
			Entity entity = tableSchema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("GranteeSysAdminUnitId", granteeSysAdminUnitId);
			entity.SetColumnValue("GrantorSysAdminUnitId", grantorSysAdminUnitId);
			entity.Save();
		}
		/// <summary>
		/// ####### ######### ###### # SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="selectedRecordId">######### ######.</param>
		private void DeleteSysAdminUnitGrantedRight(object selectedRecordId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanChangeAdminUnitGrantedRight");
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysAdminUnitGrantedRight");
			Entity entity = tableSchema.CreateEntity(UserConnection);
			if (entity.FetchFromDB(selectedRecordId)) {
				entity.Delete();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ############ ######## ########## ####### # SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="masterRecordId">######## ####### ######.</param>
		/// <param name="selectedRecords">######## ######### #######.</param>
		/// <returns>###### ### ##########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddSysAdminUnitGrantedRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddSysAdminUnitGrantedRights(string masterRecordId, string selectedRecords) {
			string[] selectedValues = Json.Deserialize<string[]>(selectedRecords);
			string errorMessage = string.Empty;
			foreach (var item in selectedValues) {
				try {
					InsertSysAdminUnitGrantedRight(item, masterRecordId);
				} catch (Exception e) {
					errorMessage = e.Message;
				}
			}
			return errorMessage;
		}

		/// <summary>
		/// ############ ########## #### # SysAdminUnitGrantedRight ## ######### #######.
		/// </summary>
		/// <param name="masterRecordId">############# ######, ####### ##### ############ #####.</param>
		/// <param name="selectedRecords">############## #######, ## ####### ##### ############ #####.</param>
		/// <returns>###### ### ##########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddSysAdminUnitGrantedRightsFromSelectedRecords", 
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
			ResponseFormat = WebMessageFormat.Json)]
		public string AddSysAdminUnitGrantedRightsFromSelectedRecords(string masterRecordId, string selectedRecords) {
			Guid[] selectedValues = Json.Deserialize<Guid[]>(selectedRecords);
			string errorMessage = string.Empty;
			foreach (Guid item in selectedValues) {
				try {
					InsertSysAdminUnitGrantedRight(masterRecordId, item);
				} catch (Exception e) {
					errorMessage = e.Message;
				}
			}
			return errorMessage;
		}
		
		/// <summary>
		/// ####### ######### ###### # SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="selectedRecords">######### ######.</param>
		/// <returns>###### ### ##########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemoveSysAdminUnitGrantedRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RemoveSysAdminUnitGrantedRights(string selectedRecords) {
			string[] selectedValues = Json.Deserialize<string[]>(selectedRecords);
			string errorMessage = string.Empty;
			foreach (var item in selectedValues) {
				try {
					DeleteSysAdminUnitGrantedRight(item);
				} catch (Exception e) {
					errorMessage = e.Message;
				}
			}
			return errorMessage;
		}

		#endregion Methods: Public
	}
	#endregion Class: AdministrationService
}

