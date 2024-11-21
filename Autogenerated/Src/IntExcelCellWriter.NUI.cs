namespace BPMSoft.Configuration.ExportToExcel
{

	#region Class: DecimalExcelCellFormatter

	/// <summary>
	/// Integer excel cell writer.
	/// </summary>
	public class IntExcelCellWriter : BaseExcelCellWriter
	{

		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Int;

		#endregion

		#region Methods: Protected

		///<inheritdoc />
		protected override string FormatValue(object value) {
			var intValue = (int)value;
			return intValue.ToString();
		}

		#endregion

	}

	#endregion

}
