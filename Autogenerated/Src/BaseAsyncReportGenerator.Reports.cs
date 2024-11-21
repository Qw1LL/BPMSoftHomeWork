namespace BPMSoft.Configuration
{
	using System;
	using FileConverter.Client;
	using FileConverterFileExtension = FileConverter.Client.File;
	using BPMSoft.Core;
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Core.Factories;
	using FileConverter.Client.Task;

	#region Class: BaseAsyncReportGenerator

	/// <summary>
	/// Represents a base abstraction of a report generation functionality using convert service.
	/// </summary>
	public abstract class BaseAsyncReportGenerator : IAsyncReportGenerator 
	{

		#region Properties: Protected

		/// <summary>
		/// Gets the source report file extension.
		/// </summary>
		protected abstract FileConverterFileExtension.FileExtension SourceFileExtension { get; }

		/// <summary>
		/// Gets the target report file extension.
		/// </summary>
		protected abstract FileConverterFileExtension.FileExtension TargetFileExtension { get; }

		/// <summary>
		/// Gets the instance of a File Converter client.
		/// </summary>
		protected virtual IFileConverterClient FileConverterClient => ClassFactory.Get<IFileConverterClient>();

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Generates report before sending to convert service.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/>.</param>
		/// <param name="configuration">Report generator configuration.</param>
		/// <returns>Returns generated report data. <see cref="ReportData"/>.</returns>
		protected abstract ReportData PrepareReport(UserConnection userConnection, ReportGeneratorConfiguration configuration);

		#endregion

		#region Methods: Private

		private string GetReportName(ReportData report) {
			var reportFileName = report.Caption;
			var reportFileExtension = TargetFileExtension.ToString().ToLower();
			return $"{reportFileName}.{reportFileExtension}";
		}

		private Guid StartReportConversionTask(ReportData report, string callbackUrl) {
			var startConversionTaskRequest = new StartFileConversionTaskRequest(
				callbackUrl,
				report.Data,
				SourceFileExtension,
				TargetFileExtension);
			var conversionTask = FileConverterClient.Task.StartFileConversionTaskAsync(startConversionTaskRequest);
			var conversionTaskId = conversionTask.GetAwaiter().GetResult();
			return conversionTaskId;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IAsyncReportGenerator.GetReportGenerationResult"/>
		public virtual ReportGenerationResult GetReportGenerationResult(ReportGenerationTask task) {
			var getFileContentTask = FileConverterClient.File.GetTargetFileContentByTaskAsync(task.TaskId);
			var reportContent = getFileContentTask.GetAwaiter().GetResult();
			return new ReportGenerationResult(task.ReportName, reportContent);
		}

		/// <inheritdoc cref="IAsyncReportGenerator.StartReportGenerationTask"/>
		public virtual ReportGenerationTask StartReportGenerationTask(UserConnection userConnection, AsyncReportGeneratorConfiguration configuration) {
			var report = PrepareReport(userConnection, configuration);
			var reportName = GetReportName(report);
			var conversionTaskId = StartReportConversionTask(report, configuration.CallbackUrl);
			return new ReportGenerationTask(conversionTaskId, reportName);
		}

		#endregion

	}

	#endregion

}

