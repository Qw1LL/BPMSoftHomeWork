namespace BPMSoft.Configuration.ExportToExcel
{

	using DocumentFormat.OpenXml.Spreadsheet;

	#region Class: ExcelStylesheetTemplate

	/// <summary>
	/// Class that contains excel stylesheet template.
	/// </summary>
	public class ExcelStylesheetTemplate
	{
		public Stylesheet Stylesheet { get; set; }
		public CellFormat ValueCellFormat { get; set; }
		public CellFormat HeaderCellFormat { get; set; }
	}

	#endregion

}


