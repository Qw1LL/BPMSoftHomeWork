namespace BPMSoft.Configuration.ExportToExcel
{
	using System;

	#region Class: DateExcelCellWriter

	/// <summary>
	/// Date excel cell writer.
	/// </summary>
	public class DateExcelCellWriter : DecimalExcelCellWriter
	{
		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Date;

		#endregion

		#region Methods: Protected

		///<inheritdoc />
		protected override string FormatValue(object value) {
			var result = string.Empty;
			if (DateTime.TryParse(value.ToString(), out var dateValue)) {
				try {
					result = dateValue.ToOADate().ToString(OpenXmlNumberFormatInfo);
				} catch (OverflowException ex) {
					Log.Error($"DateExcelCellWriter. Could not format value: {dateValue}. Exception: {ex}");
				}
			}
			return result;
		}

		#endregion
	}

	#endregion
}
