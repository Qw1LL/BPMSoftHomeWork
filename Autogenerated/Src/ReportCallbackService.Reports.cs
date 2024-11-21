namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using global::Common.Logging;
	using FileConverter.Client.Task;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: ReportCallbackService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ReportCallbackService : BaseService {

		#region Properties: Protected

		/// <summary>
		/// Gets the logger of report generation.
		/// </summary>
		protected virtual ILog Log {
			get;
		}

		/// <summary>
		/// Gets the sender of report generation completion.
		/// </summary>
		protected virtual ReportGenerationCompletionSender ReportCompletionSender {
			get;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportCallbackService"/> class.
		/// </summary>
		public ReportCallbackService() {
			Log = LogManager.GetLogger("ReportGeneration");
			ReportCompletionSender = ClassFactory.Get<ReportGenerationCompletionSender>();
		}

		#endregion

		#region Methods: Private

		private UserReportGenerationTask GetCachedReportGenerationTask(Guid taskId) {
			var cachedItem = AppConnection.SystemUserConnection.ApplicationCache[taskId.ToString()];
			var cachedTask = cachedItem as UserReportGenerationTask;
			cachedTask.CheckArgumentNull(nameof(cachedTask));
			return cachedTask;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends the user notification about report generation task completion.
		/// </summary>
		/// <param name="conversionTask">The completed file conversion task.</param>
		[OperationContract]
		[WebInvoke(
			Method = "POST",
			BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public virtual void Notify(FileConversionTask conversionTask) {
			conversionTask.CheckArgumentNull(nameof(conversionTask));
			var fileconversionTaskId = conversionTask.Id;
			var userReportGenerationTask = GetCachedReportGenerationTask(fileconversionTaskId);
			if (!ReportCompletionSender.SendMessage(conversionTask, userReportGenerationTask)) {
				Log.Error($"The notification about report generation completion by task ID = {fileconversionTaskId} has not been sent.");
			}
		}

		#endregion

	}

	#endregion

}
