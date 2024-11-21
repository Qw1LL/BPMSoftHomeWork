namespace BPMSoft.Configuration.ExportToExcel
{
	using BPMSoft.Common;

	#region Class: StringExcelCellWriter

	/// <summary>
	/// String excel cell writer.
	/// </summary>
	public class BoolExcelCellWriter : StringExcelCellWriter
	{

		#region Constants: Private

		private const string NuiManagerName = "BPMSoft.Nui";

		private const string TrueStringValueName = "CommonUtils.TrueStringValue";

		private const string FalseStringValueName = "CommonUtils.FalseStringValue";

		#endregion

		#region Properties: Public

		///<inheritdoc />
		public override ExcelCellFormat ExcelCellFormat => ExcelCellFormat.Bool;

		#endregion

		#region Methods: Protected

		///<inheritdoc />
		protected override string FormatValue(object value) {
			var boolValue = (bool) value;
			return boolValue == true
				? new LocalizableString(NuiManagerName, TrueStringValueName).Value
				: new LocalizableString(NuiManagerName, FalseStringValueName).Value;
		}

		#endregion

	}

	#endregion

}
