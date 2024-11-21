namespace BPMSoft.Configuration.ExportToExcel
{

	using DocumentFormat.OpenXml.Spreadsheet;

	#region Enum: ExcelCellFormat

	/// <summary>
	/// Excel cell format enum.
	/// </summary>
	public enum ExcelCellFormat
	{
		[ExcelNumberFormat(false)]
		Bool = 1,
		[ExcelNumberFormat(true, 201U, 23)]
		Date = 2,
		[ExcelNumberFormat(true, 2U, 20, (int)HorizontalAlignmentValues.Right)]
		Decimal = 3,
		[ExcelNumberFormat(false, quotePrefix: true)]
		Header = 4,
		[ExcelNumberFormat(true, 1U, 20, (int)HorizontalAlignmentValues.Right)]
		Int = 5,
		[ExcelNumberFormat(false, width: 40, quotePrefix: true)]
		String = 6,
		[ExcelNumberFormat(true, 200U, 23)]
		DateTime = 7,
		[ExcelNumberFormat(false, width: 23, quotePrefix: true)]
		Lookup = 8
	}

	#endregion

}
