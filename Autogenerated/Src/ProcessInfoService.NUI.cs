 namespace BPMSoft.Configuration.NUI
 {
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: ProcessInfoService

	[ServiceContract]
	[SspServiceRoute]
	[DefaultServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ProcessInfoService : BaseService
	{

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ProcessWithParameterInfoResponse GetProcessWithParametersInfo(Guid processUId, Guid parameterUId) {
			try {
				var schema = UserConnection.ProcessSchemaManager.FindInstanceByUId(processUId);
				var parameter = schema?.Parameters.GetByUId(parameterUId);
				return new ProcessWithParameterInfoResponse(schema?.Name, parameter?.Name);
			} catch (Exception e) {
				return new ProcessWithParameterInfoResponse(e);
			}
		}

		#endregion
		
	}

	#endregion

	#region Class: ProcessWithParameterInfoResponse

	[DataContract]
	public class ProcessWithParameterInfoResponse : ConfigurationServiceResponse
	{
		
		#region  Construtor: public

		public ProcessWithParameterInfoResponse(string processName, string parameterName) : base() {
			ProcessName = processName;
			ParameterName = parameterName;
		}

		public ProcessWithParameterInfoResponse(Exception e)
			: base(e) {}

		#endregion
		
		#region Properties: Public

		[DataMember]
		public string ProcessName;

		[DataMember]
		public string ParameterName;

		#endregion
	}

	#endregion

 }
