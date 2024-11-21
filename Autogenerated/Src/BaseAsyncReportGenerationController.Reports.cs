namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Web.Common;
	using System.IO;
	using System.Web;
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Core.Factories;
	using System.Collections.Generic;
	using System.Linq;

	#region Class: BaseAsyncReportGenerationController

	/// <summary>
	/// Represents a base abstraction of asynchronous report generation controller.
	/// </summary>
	public abstract class BaseAsyncReportGenerationController : BaseService, IAsyncReportGenerationController
	{

		#region Constants: Private

		private const string CallbackRelatingUrl = "/ServiceModel/ReportCallbackService.svc/Notify";

		#endregion

		#region Fields: Private

		private readonly WebResponseProcessor _responseProcessor;

		#endregion

		#region Properties: Private

		private AsyncReportGenerationService _reportGenerationService;
		protected AsyncReportGenerationService ReportGenerationService {
			get {
				return _reportGenerationService ?? (_reportGenerationService = GetReportGenerationService());
			}
		}

		#endregion

		#region Constructors: Protected

		protected BaseAsyncReportGenerationController() {
			_responseProcessor = ClassFactory.Get<WebResponseProcessor>();
		}

		#endregion

		#region Properties: Protected

		protected abstract string ContentType { get; }

		protected abstract IAsyncReportGenerator ReportGenerator { get; }

		protected virtual string CallbackServiceUrl {
			get {
				var request = HttpContextAccessor.GetInstance().Request;
				var applicationUrl = WebUtilities.GetBaseApplicationUrl(request);
				return $"{applicationUrl}{CallbackRelatingUrl}";
			}
		}

		#endregion

		#region Methods: Private

		private AsyncReportGenerationService GetReportGenerationService() {
			var taskStore = UserConnection?.ApplicationCache;
			return ClassFactory.Get<AsyncReportGenerationService>(
				new ConstructorArgument(nameof(taskStore), taskStore),
				new ConstructorArgument("reportGenerator", ReportGenerator));
		}

		private Guid StartCreateReport(Guid recordId, Guid templateId) {
			var reportGenerationConfig = new AsyncReportGeneratorConfiguration {
				RecordId = recordId,
				ReportTemplateId = templateId,
				CallbackUrl = CallbackServiceUrl,
			};
			return ReportGenerationService.StartReportGenerationTask(UserConnection, reportGenerationConfig);
		}

		private Stream GetReportContent(ReportGenerationResult reportGenerationResult) {
			var reportName = HttpUtility.UrlPathEncode(reportGenerationResult.ReportName);
			var reportContent = reportGenerationResult.ReportStream;
			var contentLength = reportContent.Length;
			var contentDisposition = $"attachment; filename*=UTF-8''{reportName}";
			_responseProcessor.AssignFileResponseContent(
				HttpContextAccessor.GetInstance(), ContentType, contentLength, contentDisposition);
			return reportContent;
		}

		#endregion

		#region Methods: Public		

		/// <inheritdoc cref="IAsyncReportGenerationController.CreateReports"/>
		public AsyncReportGenerationResponse CreateReports(Guid templateId, Guid[] recordIds) {
			var response = new AsyncReportGenerationResponse();
			var taskIds = new List<Guid>();
			try {
				response.ReportGenerationTaskIds = recordIds
					.Select(recordId => StartCreateReport(recordId, templateId))
					.ToArray();
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <inheritdoc cref="IAsyncReportGenerationController.GetReportFile"/>
		public Stream GetReportFile(string taskId) {
			var reportGenerationResult = ReportGenerationService.GetReportGenerationResult(new Guid(taskId), UserConnection);
			var reportContent = GetReportContent(reportGenerationResult);
			return reportContent;
		}

		#endregion

	}

	#endregion

}
