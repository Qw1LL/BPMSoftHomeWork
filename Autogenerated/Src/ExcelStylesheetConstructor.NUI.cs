namespace BPMSoft.Configuration.ExportToExcel
{
	using System;
	using System.Globalization;
	using System.Linq;
	using global::Common.Logging;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Spreadsheet;
	using BPMSoft.Core.Factories;

	#region Class: ExcelStylesheetConstructor

	/// <summary>
	/// Entity that creates stylesheet by template.
	/// </summary>
	public class ExcelStylesheetConstructor
	{
		#region Fields: Private

		private CellFormat _tplHeaderCellFormat;
		private CellFormat _tplValueCellFormat;
		private Stylesheet _tplStyleSheet;
		private CultureInfo _excelCulture;

		#endregion

		#region Properties: Protected

		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("commonAppender"));

		/// <summary>
		/// Excel converter.
		/// </summary>
		private ExcelStylesheetTemplateLoader _excelStylesheetTemplateLoader;

		protected ExcelStylesheetTemplateLoader ExcelStylesheetTemplateLoader => _excelStylesheetTemplateLoader ??
																				(_excelStylesheetTemplateLoader = ClassFactory.Get<ExcelStylesheetTemplateLoader>());

		/// <summary>
		/// Excel date time format.
		/// </summary>
		protected DateTimeFormatInfo DateTimeFormat => _excelCulture?.DateTimeFormat ?? CultureInfo.CurrentCulture.DateTimeFormat;

		#endregion

		#region Methods: Private

		private void AddCellFormats(Stylesheet stylesheet) {
			var cellWriters = BaseExcelCellWriter.GetAllCellWriters().ToList();
			var cellWritersCount = cellWriters.Count;
			var cellFormatsCount = cellWritersCount + 1;
			var cellFormats = new CellFormats() {Count = (UInt32) cellFormatsCount};
			cellFormats.Append(new CellFormat());
			for (int index = 1; index <= cellWritersCount; index++) {
				var excelCellFormat = (ExcelCellFormat) index;
				var excelCellFormatAttribute = BaseExcelCellWriter.GetExcelFormatMemberAttribute(excelCellFormat);
				var numberFormat = excelCellFormatAttribute.NumberFormat;
				var applyNumberFormat = excelCellFormatAttribute.ApplyNumberFormat;
				var templateCellFormat = excelCellFormat == ExcelCellFormat.Header
					? _tplHeaderCellFormat
					: _tplValueCellFormat;
				var cellFormat = GetCellFormat(templateCellFormat, excelCellFormatAttribute);
				cellFormats.Append(cellFormat);
			}
			stylesheet.Append(cellFormats);
		}


		private CellFormat GetCellFormat(CellFormat tplCellFormat, ExcelNumberFormatAttribute excelCellFormatAttribute) {
			var cellFormat = new CellFormat {
				NumberFormatId = excelCellFormatAttribute.NumberFormat,
				ApplyNumberFormat = excelCellFormatAttribute.ApplyNumberFormat,
				QuotePrefix = excelCellFormatAttribute.QuotePrefix,
				FontId = (UInt32Value) 0U,
				FillId = (UInt32Value) 0U,
				BorderId = (UInt32Value) 0U,
				FormatId = (UInt32Value) 0U
			};
			if (tplCellFormat != null) {
				cellFormat.FontId = tplCellFormat.FontId;
				cellFormat.FillId = tplCellFormat.FillId;
				cellFormat.BorderId = tplCellFormat.BorderId;
				cellFormat.FormatId = tplCellFormat.FormatId;
				cellFormat.Alignment = GetDefaultAlignment(tplCellFormat.Alignment, excelCellFormatAttribute.HorizontalAlignment);
				cellFormat.Alignment.WrapText = excelCellFormatAttribute.NumberFormat == 0U;
				cellFormat.ApplyAlignment = tplCellFormat.ApplyAlignment;
			}
			return cellFormat;
		}

		private Alignment GetDefaultAlignment(Alignment tplAlignment, HorizontalAlignmentValues defHorizontalAlignment) {
			var alignment = tplAlignment != null ? tplAlignment.CloneNode(true) as Alignment : new Alignment();
			if (defHorizontalAlignment != HorizontalAlignmentValues.General) {
				alignment.Horizontal = defHorizontalAlignment;
			}
			return alignment;
		}

		private void AppendDefaultFonts(Stylesheet stylesheet) {
			var fonts = new Fonts() {Count = (UInt32Value) 1U, KnownFonts = true};
			var font = new Font();
			var fontSize = new FontSize() {Val = 11D};
			var color = new Color() {Theme = (UInt32Value) 1U};
			var fontName = new FontName() {Val = "Calibri"};
			var fontFamilyNumbering = new FontFamilyNumbering() {Val = 2};
			var fontCharSet = new FontCharSet() {Val = 204};
			var fontScheme = new FontScheme() {Val = FontSchemeValues.Minor};
			font.Append(fontSize);
			font.Append(color);
			font.Append(fontName);
			font.Append(fontFamilyNumbering);
			font.Append(fontCharSet);
			font.Append(fontScheme);
			fonts.Append(font);
			stylesheet.Append(fonts);
		}

		private void AppendDefaultFills(Stylesheet stylesheet) {
			Fills fills = new Fills() {Count = (UInt32Value) 1U};
			Fill fillNone = new Fill();
			PatternFill patternFillNone = new PatternFill() {PatternType = PatternValues.None};
			fillNone.Append(patternFillNone);
			fills.Append(fillNone);
			stylesheet.Append(fills);
		}

		private void AppendBorders(Stylesheet stylesheet) {
			var borders = new Borders() {Count = (UInt32Value) 1U};
			var border = new Border();
			var leftBorder = new LeftBorder();
			var rightBorder = new RightBorder();
			var topBorder = new TopBorder();
			var bottomBorder = new BottomBorder();
			var diagonalBorder = new DiagonalBorder();
			border.Append(leftBorder);
			border.Append(rightBorder);
			border.Append(topBorder);
			border.Append(bottomBorder);
			border.Append(diagonalBorder);
			borders.Append(border);
			stylesheet.Append(borders);
		}

		private void AppendDefaultStyles(Stylesheet stylesheet) {
			AppendDefaultFonts(stylesheet);
			AppendDefaultFills(stylesheet);
			AppendBorders(stylesheet);
		}

		private void AppendCustomStyles(Stylesheet stylesheet) {
			if (_tplStyleSheet.Fonts != null) {
				stylesheet.Append(_tplStyleSheet.Fonts.CloneNode(true) as Fonts);
			}
			if (_tplStyleSheet.Fills != null) {
				stylesheet.Append(_tplStyleSheet.Fills.CloneNode(true) as Fills);
			}
			if (_tplStyleSheet.Borders != null) {
				stylesheet.Append(_tplStyleSheet.Borders.CloneNode(true) as Borders);
			}
		}

		private StringValue GetDateTimeFormatCode() {
			var am_pmPattern = DateTimeFormat.ShortTimePattern.IndexOf("tt", StringComparison.OrdinalIgnoreCase) >= 0 ? " AM/PM" : string.Empty;
			return StringValue.FromString(string.Format("{0} hh{1}mm{2}",
				DateTimeFormat.ShortDatePattern,
				DateTimeFormat.TimeSeparator,
				am_pmPattern));
		}

		#endregion

		#region Constructors: Public

		public ExcelStylesheetConstructor() {
		}

		public ExcelStylesheetConstructor(CultureInfo excelCulture) : this() {
			_excelCulture = excelCulture;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Loads template values.
		/// </summary>
		/// <returns>Load result.</returns>
		protected bool LoadTpl() {
			_tplStyleSheet = null;
			_tplHeaderCellFormat = null;
			_tplValueCellFormat = null;
			try {
				var excelStylesheetTemplate = ExcelStylesheetTemplateLoader.LoadTemplate();
				_tplStyleSheet = excelStylesheetTemplate.Stylesheet;
				_tplHeaderCellFormat = excelStylesheetTemplate.HeaderCellFormat;
				_tplValueCellFormat = excelStylesheetTemplate.ValueCellFormat;
			} catch (Exception exception) {
				Log.Error(exception.Message);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Append custom format.
		/// </summary>
		/// <param name="stylesheet">Constructing stylesheet.</param>
		/// <param name="numberFormatId">Excel NumberFormatId.</param>
		/// <param name="formatCode">Excel FormatCode.</param>
		protected void AppendFormat(Stylesheet stylesheet, uint numberFormatId, StringValue formatCode) {
			NumberingFormat format = new NumberingFormat() {
				NumberFormatId = UInt32Value.FromUInt32(numberFormatId),
				FormatCode = formatCode
			};
			stylesheet.NumberingFormats.Append(format);
			stylesheet.NumberingFormats.Count++;
		}

		/// <summary>
		/// Adds custom formats to <paramref name="stylesheet"/>.
		/// </summary>
		/// <param name="stylesheet">Constructing stylesheet.</param>
		protected virtual void AddCustomFormats(Stylesheet stylesheet) {
			stylesheet.NumberingFormats = new NumberingFormats { 
				Count = 0
			};
			var dateTimeNumberFormat = BaseExcelCellWriter.GetExcelFormatMemberAttribute(ExcelCellFormat.DateTime).NumberFormat;
			AppendFormat(stylesheet, dateTimeNumberFormat, GetDateTimeFormatCode());
			var dateNumberFormat = BaseExcelCellWriter.GetExcelFormatMemberAttribute(ExcelCellFormat.Date).NumberFormat;
			AppendFormat(stylesheet, dateNumberFormat, StringValue.FromString(DateTimeFormat.ShortDatePattern));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Constructs excel style sheet.
		/// </summary>
		/// <returns>Constructed stylesheet.</returns>
		public virtual Stylesheet ConstructStylesheet() {
			var stylesheet = new Stylesheet() {
				MCAttributes = new MarkupCompatibilityAttributes() {Ignorable = "x14ac"}
			};
			stylesheet.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			stylesheet.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
			if (LoadTpl()) {
				AppendCustomStyles(stylesheet);
			} else {
				AppendDefaultStyles(stylesheet);
			}
			AddCustomFormats(stylesheet);
			AddCellFormats(stylesheet);
			return stylesheet;
		}

		#endregion
	}

	#endregion
}
