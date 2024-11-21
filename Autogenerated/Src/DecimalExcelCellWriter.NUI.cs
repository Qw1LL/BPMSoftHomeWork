namespace BPMSoft.Configuration.ExportToExcel
{
	using System;
	using System.Globalization;

	#region Class: DecimalExcelCellFormatter

	/// <summary>
	/// Decimal excel cell writer.
	/// </summary>
	public class DecimalExcelCellWriter : BaseExcelCellWriter
	{
		#region Properties: Protected

		/// <summary>
		///	Open xml specific number format info.
		/// </summary>
		protected NumberFormatInfo OpenXmlNumberFormatInfo { get; }

		#endregion

		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Decimal;

		#endregion

		#region Constructors: Public

		public DecimalExcelCellWriter() {
			OpenXmlNumberFormatInfo = new NumberFormatInfo {
				NumberDecimalSeparator = "."
			};
		}

		#endregion

		#region Methods: Protected 

		///<inheritdoc />
		protected override string FormatValue(object value) {
			var decimalValue = Convert.ToDecimal(value);
			return decimalValue.ToString(OpenXmlNumberFormatInfo);
		}

		#endregion
	}

	#endregion
}
