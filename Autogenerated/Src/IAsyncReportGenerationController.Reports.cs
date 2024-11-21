namespace BPMSoft.Configuration
{
	using System;
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Web;

	#region Interface: IAsyncReportGenerationController

	[ServiceContract]
	/// <summary>
	/// Represents a controller of asynchronous report generation service.
	/// </summary>
	public interface IAsyncReportGenerationController
	{
		[OperationContract]
		[WebInvoke(
			Method = "POST",
			BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		/// <summary>
		/// Starts the reports creation processes for specified records.
		/// </summary>
		/// <param name="templateId">The identifier of a report template.</param>
		/// <param name="recordIds">The collection of records identifier for reports generation.</param>
		/// <returns>The configuration service response that indicating result of the reports creation processes.</returns>
		AsyncReportGenerationResponse CreateReports(Guid templateId, Guid[] recordIds);

		[OperationContract]
		[WebGet(UriTemplate = "GetReportFile/{taskId}")]
		/// <summary>
		/// Gets a content of the generated report by a specified task.
		/// </summary>
		/// <param name="taskId">The identifier of a report generation task.</param>
		/// <returns>The content of a generated report.</returns>
		Stream GetReportFile(string taskId);
	}

	#endregion

}
