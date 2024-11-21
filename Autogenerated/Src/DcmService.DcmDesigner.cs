namespace BPMSoft.Configuration {
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Factories;
	using System.Collections.Generic;
	using BPMSoft.Web.Common;

	#region Class: DcmService

	/// <summary>
	/// Provides web-service for work with section wizard case settings.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DcmService : BaseService {

		#region Methods: Public

		/// <summary>
		/// Runs dcm process.
		/// </summary>
		/// <param name="dcmSchemaUId">Schema identifier.</param>
		/// <param name="entityRecordId">Entity record identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RunDcmProcess", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RunDcmProcess(Guid dcmSchemaUId, Guid entityRecordId) {
			DcmSchemaManager dcmSchemaManager = UserConnection.DcmSchemaManager;
			DcmSchema dcmSchema = dcmSchemaManager.GetInstanceByUId(dcmSchemaUId);
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.RunDcmProcess(entityRecordId, dcmSchema);
		}

		/// <summary>
		/// Get allowed stages for current user.
		/// </summary>
		/// <param name="userId">Dcm schema unique identifier.</param>
		/// <returns>List allowed stages identifiers.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAllowedStagesForCurrentUser", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> GetAllowedStagesForCurrentUser(Guid dcmSchemaUId) {
			var dcmEntityUtilities = ClassFactory.Get<DcmPermissions>();
			var allowedStages = dcmEntityUtilities.GetAllowedStagesForCurrentUser(dcmSchemaUId);
			return allowedStages;
		}

		#endregion

	}

	#endregion

}
