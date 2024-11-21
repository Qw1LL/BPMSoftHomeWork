namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region Class: ReportSettings

	/// <summary>
	/// Report settings.
	/// </summary>
	public class ReportSettings
	{

		#region Properties: Public

		/// <summary>
		/// Id of the report.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Report filters.
		/// </summary>
		public Filters Filters { get; set; }

		/// <summary>
		/// Determines whether to generate separate report files or not.
		/// </summary>
		public bool IsSeparateReports { get; set; }

		#endregion

	}

	#endregion

	#region Class: ReportResult

	/// <summary>
	/// The result of the report generation.
	/// </summary>
	public interface IReportResult
	{

		#region Properties: Public

		/// <summary>
		/// Report data.
		/// </summary>
		byte[] Data { get; }

		/// <summary>
		/// Identifier of the record the report was generated for.
		/// </summary>
		/// <remarks>Returns <see cref="Guid.Empty"/> when generating a single report for multiple records.</remarks>
		Guid RecordId { get; }

		/// <summary>
		/// Information about the generated report.
		/// </summary>
		IReportTemplateInfo ReportTemplateInfo { get; }

		/// <summary>
		/// Extension for report file.
		/// </summary>
		string ReportExtension { get; }

		#endregion

	}

	#endregion

	#region Enum: ReportType

	/// <summary>
	/// Determines the report type.
	/// </summary>
	public enum ReportType : byte
	{

		/// <summary>
		/// Microsoft Word report.
		/// </summary>
		[Description("MS Word")]
		MsWord = 1,

		/// <summary>
		/// FastReport report.
		/// </summary>
		[Description("FastReport")]
		FastReport = 2
	}

	#endregion

	#region Interface: IReportInfo

	/// <summary>
	/// An information about the report.
	/// </summary>
	public interface IReportTemplateInfo
	{

		#region Properties: Public

		/// <summary>
		/// Report identifier.
		/// </summary>
		Guid Id { get; }

		/// <summary>
		/// Report caption.
		/// </summary>
		string Caption { get; }

		/// <summary>
		/// Report type.
		/// </summary>
		ReportType Type { get; }

		/// <summary>
		/// Name of the report entity schema.
		/// </summary>
		string EntitySchemaName { get; }

		#endregion

	}

	#endregion

	#region Interface: IReportEngine

	/// <summary>
	/// Interface that is used for generating reports.
	/// </summary>
	public interface IReportEngine
	{

		#region Methods: Public

		/// <summary>
		/// Generates the report with the provided by the <paramref name="settings"/> settings.
		/// </summary>
		/// <param name="settings">Instance of the <see cref="ReportSettings"/> that describes the report to
		/// generate.</param>
		/// <returns>Enumerable of the generated reports bytes.</returns>
		IEnumerable<IReportResult> Generate(ReportSettings settings);

		/// <summary>
		/// Gets the list of available reports.
		/// </summary>
		/// <inheritdoc cref="IReportEngine.GetReportTemplates"/>
		/// <returns>Enumerable of the <see cref="IReportTemplateInfo"/> types that describes the available reports.</returns>
		IReadOnlyList<IReportTemplateInfo> GetReportTemplates();

		#endregion

	}

	#endregion

}

