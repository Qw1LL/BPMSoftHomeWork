namespace BPMSoft.Configuration
{
	using System;
	using global::Common.Logging;
	using BPMSoft.Core.Store;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: AsyncReportGenerationService

	/// <summary>
	/// Represents a service of a asynchronously report generation by user.
	/// </summary>
	public class AsyncReportGenerationService
	{

		#region Fields: Private

		private readonly IBaseStore _taskStore;
		private readonly IAsyncReportGenerator _reportGenerator;

		#endregion

		#region Constructors: Public

		public AsyncReportGenerationService(
				IBaseStore taskStore,
				IAsyncReportGenerator reportGenerator) {
			Log = LogManager.GetLogger("ReportGeneration");
			_taskStore = taskStore;
			_reportGenerator = reportGenerator;
		}

		#endregion

		#region Properties: Protected

		protected virtual ILog Log { get; }

		#endregion

		#region Methods: Private

		private void CacheReportGenerationTask(ReportGenerationTask task, UserConnection userConnection) {
			var key = task.TaskId.ToString();
			var value = new UserReportGenerationTask(task, userConnection.CurrentUser.Id);
			_taskStore[key] = value;
		}

		private UserReportGenerationTask GetCachedReportGenerationTask(Guid taskId) {
			var cacheKey = taskId.ToString();
			var cachedTask = _taskStore[cacheKey] as UserReportGenerationTask;
			_taskStore.Remove(cacheKey);
			cachedTask.CheckArgumentNull(nameof(cachedTask));
			return cachedTask;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Starts a process of creating a report by specified template and record.
		/// </summary>
		/// <param name="userConnection">The user connection to bind a task to a user.</param>
		/// <param name="reportGenerationConfig">The identifier of a data record.</param>
		/// <returns>The identifier of created report generation task.</returns>
		public virtual Guid StartReportGenerationTask(UserConnection userConnection, AsyncReportGeneratorConfiguration reportGenerationConfig) {
			var reportGenerationTask = _reportGenerator.StartReportGenerationTask(userConnection, reportGenerationConfig);
			var reportGenerationTaskId = reportGenerationTask.TaskId;
			CacheReportGenerationTask(reportGenerationTask, userConnection);
			Log.Info($"The report generation task with ID = {reportGenerationTaskId} has been started.");
			return reportGenerationTaskId;
		}

		/// <summary>
		/// Gets a report content by a specified generation task.
		/// </summary>
		/// <param name="taskId">The identifier of report generation task.</param>
		/// <param name="userConnection">The user connection to identify a report generation task.</param>
		/// <returns>The content of a generated report.</returns>
		public virtual ReportGenerationResult GetReportGenerationResult(Guid taskId, UserConnection userConnection) {
			var reportGenerationTask = GetCachedReportGenerationTask(taskId);
			if (reportGenerationTask.UserId != userConnection.CurrentUser.Id) {
				throw new UnauthorizedAccessException("You can not download this report.");
			}
			var reportGenerationResult = _reportGenerator.GetReportGenerationResult(reportGenerationTask);
			return reportGenerationResult;
		}
		
		#endregion
		
	}
	
	#endregion

}
