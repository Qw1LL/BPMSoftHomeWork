namespace BPMSoft.Configuration.ExportToExcel
{
	
	#region Class: HeaderExcelCellWriter

	/// <summary>
	/// Header excel cell writer.
	/// </summary>
	public class HeaderExcelCellWriter : StringExcelCellWriter
	{

		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Header;

		#endregion

	}

	#endregion

}
