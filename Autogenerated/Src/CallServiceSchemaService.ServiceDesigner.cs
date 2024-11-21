namespace BPMSoft.Configuration.ServiceSchema
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core.Factories;
	using BPMSoft.Services;
	using BPMSoft.Web.Common;

	#region Class: CallServiceSchemaService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CallServiceSchemaService : BaseService
	{

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public CallServiceSchemaResponse Execute(string serviceName, string methodName,
				List<ServiceSchemaParameter> parameters) {
			if (parameters == null) {
				parameters = new List<ServiceSchemaParameter>();
			}
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				var builder = ClassFactory.Get<IServiceSchemaParameterBuilder>();
				var serviceSchemaClient = ClassFactory.Get<IServiceSchemaClient>();
				var serviceResponse =
					serviceSchemaClient.Execute(UserConnection, serviceName, methodName, builder.Build(parameters));
				return new CallServiceSchemaResponse(serviceResponse);
			} catch(Exception e) {
				return new CallServiceSchemaResponse(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: CallServiceSchemaResponse

	[DataContract(Name = "CallServiceSchemaResponse")]
	public class CallServiceSchemaResponse : ConfigurationServiceResponse
	{

		#region  Construtor: public

		public CallServiceSchemaResponse(IServiceClientResponse serviceResponse) {
			StatusCode = serviceResponse.StatusCode;
			Success = serviceResponse.Success;
			ResponseBody = serviceResponse.Body;
			ResponseRawData = serviceResponse.RawDataResponse;
			RequestBody = serviceResponse.RequestBody;
			RequestRawData = serviceResponse.RawDataRequest;
			ParameterValues = Newtonsoft.Json.JsonConvert.SerializeObject(serviceResponse.ParameterValues);
		}

		public CallServiceSchemaResponse(Exception e)
			: base(e) {}

		#endregion

		#region Properties: Public

		[DataMember]
		public int StatusCode;

		[DataMember]
		public string ParameterValues;

		[DataMember]
		public string RequestRawData;

		[DataMember]
		public string RequestBody;

		[DataMember]
		public string ResponseRawData;

		[DataMember]
		public string ResponseBody;

		#endregion

	}

	#endregion

	#region Class: ServiceSchemaParameter

	[DataContract]
	public class ServiceSchemaParameter
	{

		#region Properties: Internal

		[DataMember(Name = "code")]
		public string Code;

		[DataMember(Name = "value")]
		public object Value;

		[DataMember(Name = "nested")]
		public List<List<ServiceSchemaParameter>> NestedParameters;

		#endregion

	}

	#endregion

}

