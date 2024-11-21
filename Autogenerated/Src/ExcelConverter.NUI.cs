namespace BPMSoft.Configuration.ExportToExcel
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using Common;
	using global::Common.Logging;
	using Core;
	using Core.DB;
	using Core.Entities;
	using Core.Factories;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Spreadsheet;
	using Column = DocumentFormat.OpenXml.Spreadsheet.Column;
	using System.Globalization;

	#region Class: ExcelConverter

	/// <summary>
	/// Entity that converts ESQ to excel contained stream.
	/// </summary>
	public class ExcelConverter
	{
		#region Constants: Private

		private const string OpenXmlRowAttribute = "r";

		private const int MaxExcelSheetNameLength = 31;

		#endregion

		#region Fields: Private

		private OpenXmlWriter _writer;

		private WorksheetPart _worksheetPart;

		private readonly Dictionary<ExcelCellFormat, BaseExcelCellWriter> _cellWriters;

		private bool _isPrimaryColumnSelected = false;

		private CultureInfo _excelCulture;

		#endregion

		#region Constructors: Public

		public ExcelConverter() {
			_cellWriters = new Dictionary<ExcelCellFormat, BaseExcelCellWriter>();
			SetCellWriters();
		}

		public ExcelConverter(CultureInfo excelCulture) : this() {
			excelCulture.CheckArgumentNull("ExcelConverter.Constructor excelCulture");
			_excelCulture = excelCulture;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Stream repository.
		/// </summary>
		private ExcelStylesheetConstructor _excelStylesheetConstructor;
		protected ExcelStylesheetConstructor ExcelStylesheetConstructor {
			get {
				if (_excelStylesheetConstructor == null) {
					_excelStylesheetConstructor = ClassFactory.Get<ExcelStylesheetConstructor>(
						new ConstructorArgument("excelCulture", _excelCulture));
				}
				_excelStylesheetConstructor.CheckArgumentNull("ExcelConverter.ExcelStylesheetConstructor");
				return _excelStylesheetConstructor;
			}
		}

		/// <summary>
		/// Error logger.
		/// </summary>
		private ILog _log;
		protected ILog Log => _log ?? (_log = LogManager.GetLogger("Excel"));

		#endregion

		#region Properties: Public

		/// <summary>
		/// Database query batch size.
		/// </summary>
		private int _batchSize;
		public int BatchSize {
			get => _batchSize;
			set => _batchSize = value;
		}

		/// <summary>
		/// Report sheet name.
		/// </summary>
		private string _reportSheetName = "Report";
		public string ReportSheetName {
			get => _reportSheetName;
			set => _reportSheetName = value;
		}

		/// <summary>
		/// Exported row count.
		/// </summary>
		private UInt64 _exportedRowCount;
		public UInt64 ExportedRowCount => _exportedRowCount - 2;

		#endregion

		#region Methods: Private

		private string GetExcelSheetName(string name) {
			var nameLength = name.Length;
			return  nameLength < MaxExcelSheetNameLength ? name : name.Substring(0, MaxExcelSheetNameLength);
		}

		private void CloseExcelFile(SpreadsheetDocument spreadsheetDocument) {
			spreadsheetDocument.CheckArgumentNull("ExcelConverter.CloseExcelFile spreadsheetDocument");
			_writer.WriteEndElement();
			_writer.WriteEndElement();
			_writer.Close();
			var sheetIds = spreadsheetDocument.WorkbookPart.GetIdOfPart(_worksheetPart);
			var _sheetWriter = OpenXmlWriter.Create(spreadsheetDocument.WorkbookPart, Encoding.UTF8);
			_sheetWriter.WriteStartElement(new Workbook());
			_sheetWriter.WriteStartElement(new Sheets());
			_sheetWriter.WriteElement(new Sheet {
				Name = _reportSheetName,
				SheetId = 1,
				Id = sheetIds
			});
			_sheetWriter.WriteEndElement();
			_sheetWriter.WriteEndElement();
			_sheetWriter.Close();
			spreadsheetDocument.Close();
		}

		private void CloseRow() {
			_writer.WriteEndElement();
		}

		private SpreadsheetDocument CreateExcelFile(Stream stream) {
			var excelDocument = CreateExcelHeaders(stream);
			_writer.WriteStartElement(new SheetData());
			return excelDocument;
		}

		private SpreadsheetDocument CreateExcelFile(Stream stream, EntitySchemaQuery esq) {
			ReportSheetName = GetExcelSheetName(esq.RootSchema.Caption);
			var excelDocument = CreateExcelHeaders(stream);
			WriteColumns(esq);
			_writer.WriteStartElement(new SheetData());
			return excelDocument;
		}

		private SpreadsheetDocument CreateExcelHeaders(Stream stream) {
			var excelDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook, true);
			var workbookPart = excelDocument.AddWorkbookPart();
			var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
			workbookStylesPart.Stylesheet = ExcelStylesheetConstructor.ConstructStylesheet();
			_worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
			_writer = OpenXmlWriter.Create(_worksheetPart, Encoding.UTF8);
			var worksheet = new Worksheet {MCAttributes = new MarkupCompatibilityAttributes {Ignorable = "x14ac"}};
			var ns = new Dictionary<string, string> {
				["r"] = "http://schemas.openxmlformats.org/officeDocument/2006/relationships",
				["mc"] = "http://schemas.openxmlformats.org/markup-compatibility/2006",
				["x14ac"] = "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac"
			};
			var attr = new List<OpenXmlAttribute> {new OpenXmlAttribute("mc:Ignorable", null, "x14ac")};
			_writer.WriteStartElement(worksheet, attr, ns);
			return excelDocument;
		}

		private DoubleValue GetColumnWidth(EntitySchemaQueryColumn column, EntitySchemaQuery entitySchemaQuery) {
			var schemaColumn = entitySchemaQuery.GetSchema().Columns.GetByName(column.Name);
			var cellFormat = GetExcelCellFormat(schemaColumn);
			return BaseExcelCellWriter.GetExcelFormatMemberAttribute(cellFormat).Width;
		}

		private EntitySchemaQueryOptions GetEntitySchemaQueryOptions() {
			var pageableConditionValues = new Dictionary<string, object>();
			var options = new EntitySchemaQueryOptions {
				RowsOffset = 0,
				PageableRowCount = _batchSize,
				PageableDirection = PageableSelectDirection.First,
				PageableConditionValues = pageableConditionValues
			};
			return options;
		}

		private ExcelCellFormat GetExcelCellFormat(EntitySchemaColumn entitySchemaColumn = null, bool isHeader = false) {
			if (entitySchemaColumn == null) {
				return ExcelCellFormat.String;
			}
			if (isHeader) {
				return ExcelCellFormat.Header;
			}
			if (entitySchemaColumn.IsLookupType) {
				return ExcelCellFormat.Lookup;
			}
			switch (entitySchemaColumn.DataValueType) {
				case DataValueType floatType when floatType.UId == DataValueType.FloatDataValueTypeUId
				|| floatType.UId == DataValueType.Float1DataValueTypeUId
				|| floatType.UId == DataValueType.Float2DataValueTypeUId
				|| floatType.UId == DataValueType.Float3DataValueTypeUId
				|| floatType.UId == DataValueType.Float4DataValueTypeUId
				|| floatType.UId == DataValueType.MoneyDataValueTypeUId:
					return ExcelCellFormat.Decimal;
				case DataValueType dateType when dateType.UId == DataValueType.DateDataValueTypeUId:
					return ExcelCellFormat.Date;
				case DataValueType intType when intType.UId == DataValueType.IntegerDataValueTypeUId:
					return ExcelCellFormat.Int;
				case DataValueType dateTimeType when dateTimeType.UId == DataValueType.DateTimeDataValueTypeUId:
					return ExcelCellFormat.DateTime;
				case DataValueType boolType when boolType.UId == DataValueType.BooleanDataValueTypeUId:
					return ExcelCellFormat.Bool;
				default:
					return ExcelCellFormat.String;
			}
		}

		private bool GetIsColumnInReport(EntitySchemaQueryColumn column, EntitySchemaQuery entitySchemaQuery) {
			var isColumnOnReport = column.IsVisible;
			if (!_isPrimaryColumnSelected && column == entitySchemaQuery.PrimaryQueryColumn) {
				return false;
			}
			return isColumnOnReport;
		}

		private void OpenRow(UInt64 rowNum) {
			var openXmlAttributes = new List<OpenXmlAttribute> {
				new OpenXmlAttribute(OpenXmlRowAttribute, null, rowNum.ToString())
			};
			_writer.WriteStartElement(new Row(), openXmlAttributes);
		}

		private void SaveCell(EntitySchemaColumn entitySchemaColumn, object value, UInt64 rowNumber, UInt64 columnNumber) {
			try {
				var cellWriterType = GetExcelCellFormat(entitySchemaColumn);
				var cellWriter = _cellWriters[cellWriterType];
				var writerConfig = new ExcelCellWriterConfig {
					Writer = _writer,
					Value = value,
					RowNumber = rowNumber,
					ColumnNumber = columnNumber
				};
				cellWriter.WriteCell(writerConfig);
			} catch (Exception ex) {
				Log.Error($"SaveCell failed. Value: {value}, entitySchemaColumn: {entitySchemaColumn.Name}. Exception: {ex}");
			}
		}

		private bool IsPrimaryColumnSelected(EntitySchemaQuery entitySchemaQuery) {
			return entitySchemaQuery.PrimaryQueryColumn.IsVisible;
		}

		private bool IsRepeat(Entity previousPageLastFetchedEntity, Entity currentPageLastFetchedEntity) {
			if (previousPageLastFetchedEntity == null || currentPageLastFetchedEntity == null) {
				return false;
			}
			return Equals(previousPageLastFetchedEntity.PrimaryColumnValue,
				currentPageLastFetchedEntity.PrimaryColumnValue);
		}

		private void SaveData(EntitySchemaQuery entitySchemaQuery, UserConnection userConnection) {
			 _exportedRowCount = 2;
			Entity previousPageLastFetchedEntity = null;
			var options = GetEntitySchemaQueryOptions();
			entitySchemaQuery.UseOffsetFetchPaging = GlobalAppSettings.UseOffsetFetchPaging;
			var entityCollection = entitySchemaQuery.GetEntityCollection(userConnection, options);
			options.PageableDirection = PageableSelectDirection.Next;
			UInt64 columnNumber = 1;
			while (entityCollection.Count > 0) {
				var currentPageLastFetchedEntity = entityCollection.Last();
				if (IsRepeat(previousPageLastFetchedEntity, currentPageLastFetchedEntity)) {
					Log.Error($"Cycle in excel export. Query is {entitySchemaQuery.GetSelectQuery(userConnection, options).GetSqlText()}");
					break;
				}
				previousPageLastFetchedEntity = currentPageLastFetchedEntity;
				foreach (var entity in entityCollection) {
					OpenRow(_exportedRowCount);
					foreach (var column in entitySchemaQuery.Columns) {
						if (GetIsColumnInReport(column, entitySchemaQuery)) {
							var schemaColumn = entity.Schema.Columns.GetByName(column.Name);
							SaveCell(schemaColumn, schemaColumn.IsLookupType
								? entity.GetColumnDisplayValue(schemaColumn)
								: entity.GetColumnValue(schemaColumn), _exportedRowCount, columnNumber);
							columnNumber++;
						}
					}
					CloseRow();
					_exportedRowCount++;
					columnNumber = 1;
				}
				if (entityCollection.Count != _batchSize) {
					break;
				}
				if (!GlobalAppSettings.UseOffsetFetchPaging) {
					ApplyPageableOptions(options, entitySchemaQuery, currentPageLastFetchedEntity);
				}
				options.RowsOffset += entityCollection.Count;
				entitySchemaQuery.ResetSelectQuery();
				entityCollection = entitySchemaQuery.GetEntityCollection(userConnection, options);
			}
		}

		private void ApplyPageableOptions(EntitySchemaQueryOptions options, EntitySchemaQuery entitySchemaQuery, Entity lastPageEntity) {
			options.PageableConditionValues.Clear();
			var primaryColumnName = entitySchemaQuery.RootSchema.GetPrimaryColumnName();
			options.PageableConditionValues.Add(primaryColumnName, lastPageEntity.PrimaryColumnValue);
			var orderColumn = entitySchemaQuery.Columns
				.FirstOrDefault(col => col.OrderDirection != OrderDirection.None && col.Name != primaryColumnName);
			if (orderColumn != null) {
				var column = lastPageEntity.Schema.Columns.GetByName(orderColumn.Name);
				var value = column.IsLookupType
						? lastPageEntity.GetColumnDisplayValue(column)
						: lastPageEntity.GetColumnValue(column);
				options.PageableConditionValues.Add(orderColumn.Name, value);
			}
		}

		private void SaveHeader(EntitySchemaQuery entitySchemaQuery) {
			OpenRow(1);
			UInt64 columnNumber = 1;
			foreach (var column in entitySchemaQuery.Columns) {
				if (GetIsColumnInReport(column, entitySchemaQuery)) {
					SaveHeaderCell(column.Caption.Value, columnNumber);
					columnNumber++;
				}
			}
			CloseRow();
		}

		private void SaveHeaderCell(object value, UInt64 columnNumber) {
			var cellWriter = _cellWriters[ExcelCellFormat.Header];
			var writerConfig = new ExcelCellWriterConfig {
				Writer = _writer,
				Value = value,
				RowNumber = 1,
				ColumnNumber = columnNumber
			};
			cellWriter.WriteCell(writerConfig);
		}

		private void SetCellWriters() {
			var writers = BaseExcelCellWriter.GetAllCellWriters();
			foreach (var writer in writers) {
				_cellWriters.Add(writer.ExcelCellFormat, writer);
			}
		}

		private void WriteColumns(EntitySchemaQuery entitySchemaQuery) {
			_writer.WriteStartElement(new Columns());
			var columnsInReport = entitySchemaQuery.Columns.Where(column => GetIsColumnInReport(column, entitySchemaQuery))
													.ToList();
			foreach (var indexedColumn in columnsInReport.Select((column, index) => new {index, column})) {
				var openXmlIndex = UInt32Value.FromUInt32((uint) indexedColumn.index);
				_writer.WriteElement(new Column {
					Min = openXmlIndex + 1,
					Max = openXmlIndex + 1,
					Width = GetColumnWidth(indexedColumn.column, entitySchemaQuery),
					CustomWidth = true
				});
			}
			_writer.WriteEndElement();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Converts data to excel memory stream.
		/// </summary>
		/// <param name="entitySchemaQuery"></param>
		/// <param name="userConnection"></param>
		/// <returns>Excel memory stream.</returns>
		[Obsolete("Will be removed after 7.15.0. Use GetExcelData methdod.")]
		public virtual Stream GetExcelStream(EntitySchemaQuery entitySchemaQuery, UserConnection userConnection) {
			return new MemoryStream(GetExcelData(entitySchemaQuery, userConnection));
		}

		/// <summary>
		/// Returns excel data by entity schema query.
		/// </summary>
		/// <param name="entitySchemaQuery">Export data entity schema query.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Excel data bytes.</returns>
		public virtual byte[] GetExcelData(EntitySchemaQuery entitySchemaQuery, UserConnection userConnection) {
			entitySchemaQuery.CheckArgumentNull("ExcelConverter.GetExcelData entitySchemaQuery");
			userConnection.CheckArgumentNull("ExcelConverter.GetExcelData userConnection");
			_isPrimaryColumnSelected = IsPrimaryColumnSelected(entitySchemaQuery);
			if (!_isPrimaryColumnSelected) {
				entitySchemaQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			}
			using (var excelStream = new MemoryStream()) {
				try {
					var spreadsheetDocument = CreateExcelFile(excelStream, entitySchemaQuery);
					SaveHeader(entitySchemaQuery);
					SaveData(entitySchemaQuery, userConnection);
					CloseExcelFile(spreadsheetDocument);
				} catch (Exception exception) {
					Log.Error($"Error during export to excel {exception}");
					throw new ExportToExcelException(exception);
				}
				return excelStream.ToArray();
			}
		}

		/// <summary>
		/// Creates document with cell by <paramref name="cellWriter" /> with <paramref name="value" />.
		/// </summary>
		/// <param name="cellWriter">Cell writer.</param>
		/// <param name="value">Cell value.</param>
		/// <returns>Excel stream.</returns>
		public Stream WriteCell(BaseExcelCellWriter cellWriter, object value) {
			var excelStream = new MemoryStream();
			var spreadsheetDocument = CreateExcelFile(excelStream);
			OpenRow(1);
			var writerConfig = new ExcelCellWriterConfig {Writer = _writer, Value = value};
			cellWriter.WriteCell(writerConfig);
			CloseRow();
			CloseExcelFile(spreadsheetDocument);
			return excelStream;
		}

		#endregion
	}

	#endregion
}

