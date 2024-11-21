namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;

	#region Interface: IReportGeneratorAsync

	/// <summary>
	/// Provides asynchronously report generating functionality.
	/// </summary>
	public interface IAsyncReportGenerator
	{

		#region Methods: Public

		/// <summary>
		/// Starts a report generation task.
		/// </summary>
		/// <param name="userConnection">The user connection to generate report.</param>
		/// <param name="configuration">The configuration to generate report.</param>
		/// <returns>The created task of report generation.</returns>
		ReportGenerationTask StartReportGenerationTask(UserConnection userConnection, AsyncReportGeneratorConfiguration configuration);

		/// <summary>
		/// Gets a result of report generation task by a specified identifier.
		/// </summary>
		/// <param name="task">The report generation task to get result.</param>
		/// <returns>The result of a generation task with the <paramref name="taskId"/> identifier.</returns>
		ReportGenerationResult GetReportGenerationResult(ReportGenerationTask taskId);

		#endregion

	}

	#endregion

}

