namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Class: AsyncReportGenerationResponse

	public class AsyncReportGenerationResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the collection of identifiers of report generation tasks.
		/// </summary>
		public IList<Guid> ReportGenerationTaskIds { get; set; }

		#endregion

	}

	#endregion

}
