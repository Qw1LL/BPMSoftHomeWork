namespace BPMSoft.Configuration.ExportToExcel
{

	#region Class: LookupExcelCellWriter

	/// <summary>
	/// Lookup excel cell writer.
	/// </summary>
	public class LookupExcelCellWriter : StringExcelCellWriter
	{

		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Lookup;

		#endregion

	}

	#endregion

}
