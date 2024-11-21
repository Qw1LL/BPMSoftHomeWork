namespace BPMSoft.Configuration.ExportToExcel
{

	using System;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Spreadsheet;

	#region Class: ExcelNumberFormatAttribute

	/// <summary>
	/// Attribute for decorating excel cell format enum field.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class ExcelNumberFormatAttribute : Attribute
	{

		#region Properties: Public

		/// <summary>
		/// Excel number format id.
		/// </summary>
		public UInt32 NumberFormat { get; }

		/// <summary>
		/// Excel flag, should use numberformatid
		/// </summary>
		public bool ApplyNumberFormat { get; }

		/// <summary>
		/// Excel flag, should use excel cell value quote prefix
		/// </summary>
		public bool QuotePrefix { get; }

		/// <summary>
		/// Excel column width.
		/// </summary>
		public DoubleValue Width { get; }

		/// <summary>
		/// Excel value horizontal alignment.
		/// </summary>
		public HorizontalAlignmentValues HorizontalAlignment { get; }

		#endregion

		#region Constructors: Public

		public ExcelNumberFormatAttribute(bool applyNumberFormat, 
				UInt32 numberFormat = 0U, 
				double width = 10D,
				int horizontalAlignment = -1, 
				bool quotePrefix = false) {
			NumberFormat = numberFormat;
			ApplyNumberFormat = applyNumberFormat;
			Width = DoubleValue.FromDouble(width);
			QuotePrefix = quotePrefix;
			if (Enum.IsDefined(typeof(HorizontalAlignmentValues), horizontalAlignment)) {
				HorizontalAlignment = (HorizontalAlignmentValues)horizontalAlignment;
			}
		}

		#endregion

	}

	#endregion

}
