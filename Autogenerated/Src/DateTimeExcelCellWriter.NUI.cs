namespace BPMSoft.Configuration.ExportToExcel
{
	#region Class: DateTimeExcelCellWriter

	/// <summary>
	/// DateTime excel cell writer.
	/// </summary>
	public class DateTimeExcelCellWriter : DateExcelCellWriter
	{
		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.DateTime;

		#endregion
	}

	#endregion
}
