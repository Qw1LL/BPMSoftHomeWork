namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CompletenessService : BaseService, IReadOnlySessionState
	{
		#region Methods: Private

		private BaseCompletenessService CreateCompletenessService() {
			return ClassFactory.Get<BaseCompletenessService>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetRecordCompleteness", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CompletenessServiceResponse GetRecordCompleteness(Guid recordId, string schemaName, Guid typeValue = new Guid()) {
			BaseCompletenessService service = CreateCompletenessService();
			CompletenessServiceResponse response;
			try {
				response = service.GetRecordCompleteness(recordId, schemaName, typeValue);
			} catch (Exception e) {
				response = new CompletenessServiceResponse {
					Exception = e
				};
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RecalculateAllByCompleteness", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RecalculateAllByCompleteness(Guid completenessId) {
			BaseCompletenessService service = CreateCompletenessService();
			service.RecalculateAllByCompleteness(completenessId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RecalculateAll", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RecalculateAll() {
			BaseCompletenessService service = CreateCompletenessService();
			service.RecalculateAll();
		}

		#endregion

	}
}

