namespace BPMSoft.Configuration
{
	using System;

	#region Class: ReportGenerationTask

	[Serializable]
	public class ReportGenerationTask
	{

		#region Constructors: Public

		public ReportGenerationTask() {
		}

		public ReportGenerationTask(Guid taskId, string reportName) {
			TaskId = taskId;
			ReportName = reportName;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets a generate report process task identifier.
		/// </summary>
		public Guid TaskId { get; set; }

		/// <summary>
		/// Gets or sets a generated report name.
		/// </summary>
		public string ReportName { get; set; }

		#endregion

	}

	#endregion

}

