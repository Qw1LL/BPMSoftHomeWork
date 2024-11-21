namespace BPMSoft.Configuration.ExportToExcel
{
	using System;
	using DocumentFormat.OpenXml;

	#region Class: ExcelCellWriterConfig

	/// <summary>
	/// Excel cell writer config.
	/// </summary>
	public class ExcelCellWriterConfig
	{
		public OpenXmlWriter Writer { get; set; }
		public UInt64 RowNumber { get; set; }
		public UInt64 ColumnNumber { get; set; }
		public object Value { get; set; }
	}

	#endregion

}
