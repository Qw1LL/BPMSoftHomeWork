namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Runtime.Serialization;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core;
	using BPMSoft.Monitoring;
	using global::Common.Logging;

	#region Class: FullPipelineService

	/// <summary>
	/// Provides web-service for work with full pipeline.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public sealed class FullPipelineService : BaseService
	{

		#region Constants: Private

		private const string FullPipelineErrorMetricName = "full_pipeline_service_error_count";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("FullPipeline");
		private readonly IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();

		#endregion

		#region Constructors: Public

		public FullPipelineService() {
		}

		public FullPipelineService(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private IFullPipelineProvider GetFullPipelineProvider() {
			var provider = ClassFactory.Get<IFullPipelineProvider>(
				new ConstructorArgument("userConnection", UserConnection));
			return provider;
		}

		private void SendErrorMetric() {
			_metricReporter.Gauge(FullPipelineErrorMetricName, 1);
		}

		private void AddToLog(string message) {
			_log.Error(message);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets all slices of full pipeline data.
		/// </summary>
		/// <param name="pipelineConfig">Full pipeline request <see cref="FullPipelineRequest"/></param>
		/// <returns>All slices data of full pipeline <see cref="FullPipelineResponse"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAllSlicesFullPipelineData", RequestFormat = WebMessageFormat.Json, 
			ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public FullPipelineResponse GetAllSlicesFullPipelineData(FullPipelineRequest pipelineConfig) {
			var provider = GetFullPipelineProvider();
			var response = new FullPipelineResponse();
			try {
				var fullpipelineInfo = provider.GetAllSlicesData(pipelineConfig.Entities);
				response.FullPipelineInfo = fullpipelineInfo;
			} catch (Exception ex) {
				response.Exception = ex;
				AddToLog(ex.Message);
				SendErrorMetric();
			}
			return response;
		}

		#endregion

	}

	#endregion

	#region Class: FullPipelineRequest

	[DataContract]
	public class FullPipelineRequest
	{
		[DataMember(Name = "entities")]
		public List<FullPipelineEntityConfig> Entities;
	}

	#endregion

	#region Class: FullPipelineResponse

	[DataContract]
	public class FullPipelineResponse : ConfigurationServiceResponse
	{
		[DataMember(Name = "info")]
		public FullPipelineInfo FullPipelineInfo {
			get;
			set;
		}
	}

	#endregion

}

