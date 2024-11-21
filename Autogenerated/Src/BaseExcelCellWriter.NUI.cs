namespace BPMSoft.Configuration.ExportToExcel
{
	using System;
	using System.Reflection;
	using System.Collections.Generic;
	using System.Linq;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Spreadsheet;
	using global::Common.Logging;

	#region Class: BaseExcelCellFormatter

	/// <summary>
	/// Base excel cell writer.
	/// </summary>
	public abstract class BaseExcelCellWriter
	{
		#region Properties: Protected

		protected string OpenXmlStyleIndexAttribute => "s";

		protected string OpenXmlCellReferenceAttribute => "r";

		/// <summary>
		/// Error logger.
		/// </summary>
		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("Excel"));

		#endregion

		#region Properties: Public

		/// <summary>
		/// Formatting type.
		/// </summary>
		public abstract ExcelCellFormat ExcelCellFormat { get; }

		#endregion

		#region Methods: Private

		private static string GetExcelColumnName(UInt64 columnNumber) {
			var dividend = columnNumber;
			string columnName = String.Empty;
			while (dividend > 0) {
				var modulo = (dividend - 1) % 26;
				columnName = Convert.ToChar(65 + modulo) + columnName;
				dividend = (dividend - modulo) / 26;
			}
			return columnName;
		}

		private void WriteCellElement(OpenXmlWriter xmlWriter, Cell cell, object value) {
			var openXmlAttributes = GetOpenXmlAttributes().ToList();
			openXmlAttributes.Add(new OpenXmlAttribute(OpenXmlCellReferenceAttribute, null, cell.CellReference));
			xmlWriter.WriteStartElement(cell, openXmlAttributes);
			var cellValue = string.Empty;
			if (value != null) {
				cellValue = FormatValue(value);
			}
			xmlWriter.WriteElement(new CellValue(cellValue));
			xmlWriter.WriteEndElement();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns converted value to string according to excel type.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Converted value.</returns>
		protected abstract string FormatValue(object value);

		/// <summary>
		/// Returns OpenXmlAttibutes that should annotate excel cell.
		/// </summary>
		/// <returns></returns>
		protected virtual IEnumerable<OpenXmlAttribute> GetOpenXmlAttributes() {
			var openXmlAttributes = new List<OpenXmlAttribute> {
				new OpenXmlAttribute(OpenXmlStyleIndexAttribute, null, ((int) ExcelCellFormat).ToString())
			};
			return openXmlAttributes;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns list of all excel cell writers.
		/// If there is two writers on one type throws exception.
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<BaseExcelCellWriter> GetAllCellWriters() {
			var baseExcelCellWriters = Assembly.GetAssembly(typeof(BaseExcelCellWriter)).GetTypes()
					.Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseExcelCellWriter)));
			foreach (var type in baseExcelCellWriters) {
				yield return (BaseExcelCellWriter) Activator.CreateInstance(type);
			}
		}

		/// <summary>
		/// Writes value into the cell using writer.
		/// </summary>
		/// <param name="writerConfig">Excel cell writer config.</param>
		public void WriteCell(ExcelCellWriterConfig writerConfig) {
			var writer = writerConfig.Writer;
			var value = writerConfig.Value;
			var cell = new Cell();
			cell.CellReference = GetExcelCellReference(writerConfig.ColumnNumber, writerConfig.RowNumber);
			WriteCellElement(writer, cell, value);
		}

		/// <summary>
		/// Writes value into the cell using writer.
		/// </summary>
		/// <param name="writer">Open XML writer.</param>
		/// <param name="value">Value.</param>
		[Obsolete("Use 7.12.0 | Method is deprecated. Use WriteCell with ExcelCellWriterConfig")]
		public void WriteCell(OpenXmlWriter writer, object value) {
			var cell = new Cell();
			WriteCellElement(writer, cell, value);
		}

		/// <summary>
		/// Returns excel number format attribute for given excelcellformat value.
		/// </summary>
		/// <param name="excelCellFormat">Excel cell format value.</param>
		/// <returns>Excel number format attribute.</returns>
		public static ExcelNumberFormatAttribute GetExcelFormatMemberAttribute(ExcelCellFormat excelCellFormat) {
			var excelCellFormatType = typeof(ExcelCellFormat);
			var formatMember = excelCellFormatType.GetMember(excelCellFormat.ToString());
			return (ExcelNumberFormatAttribute) formatMember[0].GetCustomAttribute(typeof(ExcelNumberFormatAttribute), false);
		}

		/// <summary>
		/// Return Excel cell reference based on column and row number.
		/// </summary>
		/// <param name="columnNumber">Column number.</param>
		/// <param name="rowNumber">Row number.</param>
		/// <returns>Cell reference</returns>
		public static string GetExcelCellReference(UInt64 columnNumber, UInt64 rowNumber) {
			return GetExcelColumnName(columnNumber) + rowNumber.ToString();
		}

		#endregion

	}

	#endregion
}
