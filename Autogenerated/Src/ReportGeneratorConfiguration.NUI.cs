namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Class: ReportGeneratorConfiguration

	public class ReportGeneratorConfiguration
	{

		#region Properties: Public

		public Guid ReportTemplateId { get; set; }

		public Guid EntitySchemaUId { get; set; }

		public Guid RecordId { get; set; }

		public Dictionary<string, object> ReportParameters { get; set; }

		#endregion

	}

	#endregion

}

