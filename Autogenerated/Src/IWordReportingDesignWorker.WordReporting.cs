namespace BPMSoft.Configuration.Reporting.Word.Worker
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization;

	#region Class: WordReportMainInfo

	[DataContract]
	public class WordReportMainInfoDto
	{

		#region Properties: Public

		[DataMember]
		public Guid ReportId { get; set; }

		[DataMember]
		public string ReportCaption { get; set; }

		[DataMember]
		public Guid SysModuleId { get; set; }

		[DataMember]
		public string SysModuleCaption { get; set; }

		#endregion

	}

	#endregion

	#region Class: DataObjectSettingsDto

	[DataContract]
	public class DataObjectSettingsDto
	{

		#region Properties: Public

		[DataMember]
		public Guid EntitySchemaUId { get; set; }

		[DataMember]
		public string Caption { get; set; }

		[DataMember]
		public string MacrosCollection { get; set; }

		#endregion

	}

	#endregion

	#region Class: WordReportSettingsDto

	[DataContract]
	public class WordReportSettingsDto
	{

		#region Properties: Public

		[DataMember]
		public Guid ReportId { get; set; }

		[DataMember]
		public DataObjectSettingsDto MainDataObjectSettings { get; set; }

		[DataMember]
		public DataObjectSettingsDto[] TableDataObjectSettingsCollection { get; set; }

		#endregion

	}

	#endregion

	#region Interface: IWordReportDesignWorker

	/// <summary>
	/// Provide reports design functional.
	/// </summary>
	public interface IWordReportDesignWorker
	{

		#region Methods: Public

		/// <summary>
		/// Get all reports.
		/// </summary>
		/// <returns>Returns reports collection.</returns>
		IEnumerable<WordReportMainInfoDto> GetReportsCollection();

		/// <summary>
		/// Get report.
		/// </summary>
		/// <param name="reportId">Report id.</param>
		/// <returns>Returns report.</returns>        
		WordReportSettingsDto GetReportSettings(Guid reportId);

		/// <summary>
		/// Upload report template.
		/// </summary>
		/// <param name="template">Template stream.</param>
		/// <param name="reportId">Report id.</param>
		void SaveTemplate(Stream template, Guid reportId);
		
		/// <summary>
		/// Validate docx file.
		/// </summary>
		/// <param name="fileId">File id.</param>
		Stream ValidateTemplate(Guid fileId);

		/// <summary>
		/// Remove report template.
		/// </summary>
		/// <param name="reportId">Report id.</param>
		void RemoveTemplate(Guid reportId);
		
		/// <summary>
		/// Download report template.
		/// </summary>
		/// <param name="reportId">Report id.</param>
		/// <returns>Returns template stream.</returns>
		(Stream, string) DownloadTemplate(Guid reportId);

		/// <summary>
		/// Copies report template file from source record to destination record.
		/// </summary>
		/// <param name="sourceReportId">Source report id.</param>
		/// <param name="destinationReportId">Destination report id.</param>
		void CopyTemplate(Guid sourceReportId, Guid destinationReportId);

		#endregion

	}

	#endregion

}

