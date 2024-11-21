namespace BPMSoft.Configuration.ReportService
{
	using System.Runtime.Serialization;
	using BPMSoft.Configuration;

	#region Class: ExportFiltersResponse

	[DataContract]
	public class ExportFiltersResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "key")]
		public string Key {get; set;}

		[DataMember(Name = "maxEntityRowCount")]
		public int MaxEntityRowCount {get; set;}

		#endregion

	}

	#endregion

}
