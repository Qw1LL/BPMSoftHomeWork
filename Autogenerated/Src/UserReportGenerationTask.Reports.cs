namespace BPMSoft.Configuration
{
	using System;

	#region Class: UserReportGenerationTask

	[Serializable]
	public class UserReportGenerationTask : ReportGenerationTask
	{

		#region Constructors: Public

		public UserReportGenerationTask() {
		}

		public UserReportGenerationTask(ReportGenerationTask task, Guid userId)
			: base(task.TaskId, task.ReportName) {
			UserId = userId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets an identifier of user that initialize report generation task.
		/// </summary>
		public Guid UserId { get; set; }

		#endregion

	}

	#endregion

}

