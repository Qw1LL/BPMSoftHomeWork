namespace BPMSoft.Configuration
{
	using System;
	using System.IO;

	#region Class: ReportGenerationResult

	[Serializable]
	public class ReportGenerationResult
	{

		#region Constructors: Public

		public ReportGenerationResult(string reportName, byte[] reportContent)
			: this(reportName, new MemoryStream(reportContent)) {
		}

		public ReportGenerationResult(string reportName, Stream reportContent) {
			ReportName = reportName;
			ReportStream = reportContent;
		}

		#endregion

		#region Properties: Public

		public string ReportName { get; }

		public Stream ReportStream { get; }

		#endregion

	}

	#endregion

}
