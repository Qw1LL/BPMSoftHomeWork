namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web;
	using BPMSoft.Common;
	using BPMSoft.Configuration.ExportToExcel;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Enum: HistoryState

	/// <summary>
	/// The state of forecast history item.
	/// </summary>
	public enum HistoryState
	{
		NotChanged = 0,
		Added = 1,
		Deleted = 2
	}

	#endregion

	#region Class: ForecastHistoryDataService

	[ServiceContract(Name = "forecast.history.api")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ForecastHistoryDataService : BaseService
	{

		#region Fields: Private

		private IGetForecastCellRepository _cellsRepository;
		private IForecastSummaryRepositoryV2 _forecastHistorySummaryRepository;
		private IForecastSummaryRepositoryV2 _forecastGroupHistorySummaryRepository;
		private ForecastDataMapper _forecastDataMapper;
		private IForecastProviderV2 _historicalForecastProvider;
		private IForecastSnapshotRepository _snapshotRepository;
		private IForecastProviderV2 _forecastProvider;
		private IForecastSummaryColumnCalculator _summaryColumnCalculator;
		private IForecastSummaryProvider _forecastHistorySummaryProvider;
		private IForecastSummaryProvider _forecastSummaryProvider;

		#endregion

		#region Class: ForecastHistoryDataResponse

		/// <summary>
		/// Provides properties of forecast data.
		/// </summary>
		[DataContract]
		public class ForecastHistoryDataResponse : ConfigurationServiceResponse
		{

			#region Properties: Public

			[DataMember(Name = "dataSource")]
			public ICollection<HistoryTreeTableDataItem> DataSource { get; set; }

			[DataMember(Name = "columns")]
			public ICollection<TableColumn> Columns { get; set; }

			#endregion

		}
		
		/// <summary>
		/// Provides properties of forecast history object value records.
		/// </summary>
		[DataContract]
		public class ForecastHistoryObjectValueDataResponse : ConfigurationServiceResponse
		{

			#region Properties: Public

			[DataMember(Name = "dataSource")]
			public IEnumerable<HistoryObjectValueRecord> DataSource { get; set; }

			#endregion

		}

		#endregion

		#region Class: ForecastHistoryRequestData

		/// <summary>
		/// Provides properties of forecast history data request.
		/// </summary>
		[DataContract]
		public class ForecastHistoryRequestData : ForecastDataService.ForecastRequestData
		{

			#region Properties: Public

			[DataMember(Name = "snapshotId")]
			public Guid SnapshotId { get; set; }

			#endregion

		}

		#endregion

		#region Class: ForecastHistorySaveRequestData

		/// <summary>
		/// Provides properties of forecast save data request.
		/// </summary>
		[DataContract]
		public class ForecastHistorySaveRequestData
		{

			#region Properties: Public

			[DataMember(Name = "forecastId")]
			public Guid ForecastId { get; set; }

			#endregion

		}

		/// <summary>
		/// Provides properties of forecast save data request.
		/// </summary>
		[DataContract]
		public class ForecastHistoryGetSnapshotsRequest
		{

			#region Properties: Public

			[DataMember(Name = "forecastId")]
			public Guid ForecastId { get; set; }

			#endregion

		}

		#endregion

		#region Class: ForecastHistorySummaryRequestData

		/// <summary>
		/// Provides properties of forecast summary request.
		/// </summary>
		[DataContract]
		public class ForecastHistorySummaryRequestData : ForecastDataService.ForecastSummaryRequestData
		{

			#region Properties: Public

			[DataMember(Name = "snapshotId")]
			public Guid SnapshotId { get; set; }

			#endregion

		}

		[DataContract]
		public class ForecastSnapshotsResponse : ConfigurationServiceResponse
		{
			[DataMember(Name = "snapshots")]
			public IEnumerable<ForecastSnapshotDataResponse> Snapshots { get; set; }
		}

		[DataContract]
		public class ForecastSnapshotDataResponse
		{
			[DataMember(Name = "snapshotId")]
			public Guid SnapshotId { get; set; }

			[DataMember(Name = "date")]
			public string Date { get; set; }
		}

		[DataContract]
		public class ColumnCaptionData
		{
			[DataMember(Name = "name")]
			public string Name { get; set; }
			
			[DataMember(Name = "caption")]
			public string Caption { get; set; }
		}

		[DataContract]
		public class ForecastHistoryObjectValueRequestData
		{

			#region Properties: Public

			[DataMember(Name = "entitySchemaName")]
			public string EntitySchemaName { get; set; }

			[DataMember(Name = "forecastId")]
			public Guid ForecastId { get; set; }

			[DataMember(Name = "recordId")]
			public Guid RecordId { get; set; }

			[DataMember(Name = "columnId")]
			public Guid ColumnId { get; set; }

			[DataMember(Name = "periodId")]
			public Guid PeriodId { get; set; }

			[DataMember(Name = "snapshotId")]
			public Guid SnapshotId { get; set; }

			[DataMember(Name = "sortConfig")]
			public SortConfig SortConfig { get; set; }

			[DataMember(Name = "pagingConfig")]
			public PagingConfig PagingConfig { get; set; }

			[DataMember(Name = "columns")]
			public ColumnCaptionData[] Columns { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Protected
		
		protected ForecastSnapshotData SnapshotData { get; set; }

		/// <summary>
		/// Forecast data mapper.
		/// </summary>
		protected ForecastDataMapper ForecastDataMapper =>
			_forecastDataMapper ?? (_forecastDataMapper = ClassFactory.Get<ForecastDataMapper>());

		/// <summary>
		/// Forecast cell repository with get cells operation.
		/// </summary>
		protected IGetForecastCellRepository GetForecastCellRepository {
			get {
				if (_cellsRepository == null) {
					var args = new[] { new ConstructorArgument("userConnection", UserConnection) };
					_cellsRepository = ClassFactory.Get<IGetForecastCellRepository>("History", args);
					(_cellsRepository as ISnapshot).SetSnapshotData(new ForecastSnapshotData {
						SnapshotId = SnapshotId
					});
				}
				return _cellsRepository;
			}
			set => _cellsRepository = value;
		}

		/// <summary>
		/// Forecast cell repository with get cells operation.
		/// </summary>
		protected IForecastSummaryRepositoryV2 ForecastHistorySummaryRepository {
			get {
				if (_forecastHistorySummaryRepository == null) {
					var args = new[] { new ConstructorArgument("userConnection", UserConnection) };
					_forecastHistorySummaryRepository = ClassFactory.Get<IForecastSummaryRepositoryV2>("HistoryTotal", args);
					(_forecastHistorySummaryRepository as ISnapshot).SetSnapshotData(new ForecastSnapshotData {
						SnapshotId = SnapshotId
					});
				}
				return _forecastHistorySummaryRepository;
			}
			set => _forecastHistorySummaryRepository = value;
		}

		/// <summary>
		/// Forecast group history summary repository.
		/// </summary>
		protected IForecastSummaryRepositoryV2 ForecastGroupHistorySummaryRepository {
			get {
				if (_forecastGroupHistorySummaryRepository == null) {
					var args = new[] { new ConstructorArgument("userConnection", UserConnection) };
					_forecastGroupHistorySummaryRepository = ClassFactory.Get<IForecastSummaryRepositoryV2>("HistoryGroup", args);
					(_forecastGroupHistorySummaryRepository as ISnapshot).SetSnapshotData(new ForecastSnapshotData {
						SnapshotId = SnapshotId
					});
				}
				return _forecastGroupHistorySummaryRepository;
			}
			set => _forecastGroupHistorySummaryRepository = value;
		}

		/// <summary>
		/// Forecast summary provider with get operation.
		/// </summary>
		protected IForecastSummaryProvider ForecastSummaryProvider =>
			_forecastSummaryProvider ?? (_forecastSummaryProvider = ClassFactory.Get<IForecastSummaryProvider>());

		/// <summary>
		/// Forecast snapshot repository with get operation.
		/// </summary>
		protected IForecastSnapshotRepository ForecastSnapshotRepository {
			get {
				return _snapshotRepository ?? (_snapshotRepository = ClassFactory.Get<IForecastSnapshotRepository>());
			}
		}

		/// <summary>
		/// The forecast history summary provider.
		/// </summary>
		protected IForecastSummaryProvider ForecastHistorySummaryProvider {
			get {
				if (_forecastHistorySummaryProvider == null) {
					_forecastHistorySummaryProvider = ClassFactory.Get<IForecastSummaryProvider>();
					var provider = _forecastHistorySummaryProvider as ForecastSummaryProvider;
					if (provider != null) {
						provider.ForecastSummaryRepository = ForecastHistorySummaryRepository;
						provider.ForecastGroupSummaryRepository = ForecastGroupHistorySummaryRepository;
					}
				}
				return _forecastHistorySummaryProvider;
			}
		}

		/// <summary>
		/// Forecast provider. Gets forecast historical data.
		/// </summary>
		protected IForecastProviderV2 HistoricalForecastProvider {
			get {
				if (_historicalForecastProvider == null) {
					_historicalForecastProvider = ClassFactory.Get<IForecastProviderV2>();
					var provider = _historicalForecastProvider as ForecastProvider;
					if (provider != null) {
						provider.GetForecastCellRepository = GetForecastCellRepository;
						provider.ForecastSummaryProvider = ForecastHistorySummaryProvider;
						if (UserConnection.GetIsFeatureEnabled("ForecastRowSnapshot")) {
							provider.ForecastHierarchyRowDataRepository = ForecastHistoryRowRepository;
						}
					}
				}
				return _historicalForecastProvider;
			}
		}

		/// <summary>
		/// Forecast provider.
		/// </summary>
		protected IForecastProviderV2 ActualForecastProvider =>
			_forecastProvider ?? (_forecastProvider = ClassFactory.Get<IForecastProviderV2>());

		/// <summary> Gets the forecast summary columns calculator. </summary>
		/// <value> The formula summary calculator. </value>
		protected IForecastSummaryColumnCalculator SummaryColumnCalculator =>
			_summaryColumnCalculator ??
			(_summaryColumnCalculator = ClassFactory.Get<IForecastSummaryColumnCalculator>());

		protected Guid SnapshotId { get; set; }

		private IForecastSheetRepository _sheetRepository;

		/// <summary>Gets the forecast sheet repository.</summary>
		/// <value>The forecast sheet repository.</value>
		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>());

		private IForecastHistoryMatcher _forecastHistoryMatcher;

		/// <summary>Gets the forecast history data matcher.</summary>
		/// <value>The forecast history data matcher.</value>
		protected IForecastHistoryMatcher HistoryMatcher =>
			_forecastHistoryMatcher ?? (_forecastHistoryMatcher = ClassFactory.Get<IForecastHistoryMatcher>());

		private IForecastHistoricalHierarchyRowDataRepository _forecastHistoryRowRepository;

		/// <summary>Gets the forecast history rows repository.</summary>
		/// <value>The forecast history rows repository.</value>
		protected IForecastHistoricalHierarchyRowDataRepository ForecastHistoryRowRepository {
			get
			{
				if (_forecastHistoryRowRepository == null) {
					var args = new[] { new ConstructorArgument("userConnection", UserConnection) };
					_forecastHistoryRowRepository = ClassFactory.Get<IForecastHistoricalHierarchyRowDataRepository>("Default", args);
					(_forecastHistoryRowRepository as ISnapshot).SetSnapshotData(new ForecastSnapshotData {
						SnapshotId = SnapshotId
					});
				}
				return _forecastHistoryRowRepository;
			}
		}

		private IPeriodRepository _periodRepository;

		/// <summary>
		/// Gets the period repository.
		/// </summary>
		/// <value>The period repository.</value>
		public IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>());


		private IForecastObjectValueGetOperation _forecastObjectValueHistoryRepository;
		protected IForecastObjectValueGetOperation ForecastObjectValueHistoryRepository {
			get {
				if (_forecastObjectValueHistoryRepository == null) {
					var args = new[] { 
						new ConstructorArgument("userConnection", UserConnection), 
						new ConstructorArgument("snapshotData", SnapshotData ?? new ForecastSnapshotData {
							SnapshotId = SnapshotId
						})
					};
					_forecastObjectValueHistoryRepository = ClassFactory.Get<IForecastObjectValueGetOperation>("History", args);
				}
				return _forecastObjectValueHistoryRepository;
			}
		}
		
		private IForecastObjectValueGetOperation _forecastObjectValueActualRepository;
		protected IForecastObjectValueGetOperation ForecastObjectValueActualRepository =>
			_forecastObjectValueActualRepository ?? (_forecastObjectValueActualRepository =
				ClassFactory.Get<IForecastObjectValueGetOperation>("Actual", 
					new ConstructorArgument("userConnection", UserConnection)));
		
		private IForecastObjectValueHistoryMatcher _forecastObjectValueHistoryMatcher;
		protected IForecastObjectValueHistoryMatcher ForecastObjectValueHistoryMatcher =>
			_forecastObjectValueHistoryMatcher ?? (_forecastObjectValueHistoryMatcher =
				ClassFactory.Get<IForecastObjectValueHistoryMatcher>("Default"));
		
		
		private IForecastColumnRepository _columnRepository;
		private IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastColumnSettingsMapper _mapper;
		private IForecastColumnSettingsMapper ColumnSettingsMapper =>
			_mapper ?? (_mapper = ClassFactory.Get<IForecastColumnSettingsMapper>());

		private IForecastExportToExcelService _forecastExportToExcelService;
		private IForecastExportToExcelService ForecastHistoryExportToExcelService =>
			_forecastExportToExcelService ?? (_forecastExportToExcelService =
				ClassFactory.Get<IForecastExportToExcelService>("History",
					new ConstructorArgument("userConnection", UserConnection))); 
		
		#endregion

		#region Methods: Private

		private void FilterHiddenColumns(ICollection<TableColumn> columns) {
			columns.ForEach(periodColumn => {
				periodColumn.Children = periodColumn.Children.Where(c => !c.IsHide).ToArray();
			});
		}

		private ForecastData GetHistoricalData(ForecastHistoryRequestData requestData) {
			PageableConfig pageableConfig = FormPageableConfig(requestData);
			pageableConfig.PrimaryFilterValue = HttpUtility.UrlDecode(requestData.FilterValue);
			var data = HistoricalForecastProvider.GetData(requestData.ForecastId, requestData.Periods, pageableConfig);
			return data;
		}

		private ForecastDataService.ForecastDataResponse GetActualRowsData(ForecastHistoryRequestData requestData, IEnumerable<Guid> records) {
			var actualData = new ForecastDataService.ForecastDataResponse();
			PageableConfig pageableConfig = FormPageableConfig(requestData);
			pageableConfig.RecordIds = records;
			pageableConfig.RowsOffset = 0;
			var data = ActualForecastProvider.GetData(requestData.ForecastId, requestData.Periods, pageableConfig);
			var columns = ForecastDataMapper.GetMapTableColumns(data);
			actualData.DataSource = ForecastDataMapper.GetMapTreeTableDataItems(data, columns);
			FilterHiddenColumns(columns);
			actualData.Columns = columns;
			return actualData;
		}

		private PageableConfig FormPageableConfig(ForecastHistoryRequestData requestData) {
			var hierarchyRowsId = requestData.HierarchyRows;
			int rowOffset = int.TryParse(requestData.Offset, out rowOffset) ? rowOffset : 0;
			int hierarchyLevel = hierarchyRowsId?.Count() ?? 0;
			var pageableConfig = new PageableConfig() {
				RowCount = requestData.Count,
				RowsOffset = rowOffset,
				LastValue = requestData.LastRow,
				HierarchyRowsId = hierarchyRowsId,
				HierarchyLevel = hierarchyLevel
			};
			return pageableConfig;
		}

		private IDictionary<string, double> ConvertCellsToSummary(IEnumerable<TableCell> summaryCells) {
			IDictionary<string, double> summary = new Dictionary<string, double>();
			summaryCells.ForEach(cell => {
				summary[cell.ColumnCode] = cell.Value;
			});
			return summary;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns historical forecast data.
		/// </summary>
		/// <param name="requestData">Model with of data such as forecastId, periods, count, offset etc.</param>
		/// <returns><see cref="ForecastHistoryDataResponse"/>Properties of forecast data.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastHistoryDataResponse GetData(ForecastHistoryRequestData requestData) {
			var response = new ForecastHistoryDataResponse();
			SnapshotId = requestData.SnapshotId;
			var sheet = SheetRepository.GetSheet(requestData.ForecastId);
			try {
				ForecastData historicalData = GetHistoricalData(requestData);
				var columns = ForecastDataMapper.GetMapTableColumns(historicalData);
				var records = ForecastDataMapper.GetMapTreeTableDataItems(historicalData, columns);
				var periodsId = PeriodRepository.GetForecastPeriods(requestData.Periods, sheet.PeriodTypeId);
				if (periodsId.Count() > 1) {
					SummaryColumnCalculator.ApplySummaryColumns(UserConnection, columns);
					SummaryColumnCalculator.ApplySummaryData(UserConnection, requestData.ForecastId, records);
				}
				FilterHiddenColumns(columns);
				response.Columns = columns;
				if (records.IsEmpty()) {
					response.DataSource = records.Select(r => new HistoryTreeTableDataItem(r)).ToList();
					return response;
				}
				var recordIds = records.Select(r => r.RecordId);
				var actualData = GetActualRowsData(requestData, recordIds);
				response.DataSource = HistoryMatcher.Match(records, actualData.DataSource).ToList();
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Returns forecast data.
		/// </summary>
		/// <param name="requestData">Model with of data such as ForecastId, periods.</param>
		/// <returns><see cref="ForecastDataService.ForecastDataResponse"/>Properties of forecast data.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/summary", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastDataService.ForecastSummaryResponse GetSummary(ForecastHistorySummaryRequestData requestData) {
			var response = new ForecastDataService.ForecastSummaryResponse();
			SnapshotId = requestData.SnapshotId;
			try {
				var sheet = SheetRepository.GetSheet(requestData.ForecastId);
				var summaryCells = ForecastHistorySummaryProvider.GetSummary(sheet, new FilterConfig() {
					PeriodIds = requestData.Periods,
				});
				var record = new TreeTableDataItem {
					ColumnValues = summaryCells.ToList()
				};
				SummaryColumnCalculator.ApplySummaryData(UserConnection, requestData.ForecastId, new[] { record });
				response.Summary = ConvertCellsToSummary(record.ColumnValues);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Make snapshot of specified forecast.
		/// </summary>
		/// <param name="requestData">Forecast sheet information.</param>
		/// <returns>Status of snapshot.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/snapshot/save", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse Save(ForecastHistorySaveRequestData requestData) {
			var response = new ConfigurationServiceResponse();
			ForecastSnapshotManager manager = new ForecastSnapshotManager(UserConnection);
			manager.SaveSnapshot(requestData.ForecastId, new FilterConfig());
			return response;
		}

		/// <summary>
		/// Make snapshot of specified forecast.
		/// </summary>
		/// <param name="requestData">Forecast sheet information.</param>
		/// <returns>Status of snapshot.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/snapshot", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastSnapshotsResponse GetSnapshots(ForecastHistoryGetSnapshotsRequest request) {
			var response = new ForecastSnapshotsResponse();
			var snapshots = ForecastSnapshotRepository.GetAll(request.ForecastId, null);
			response.Snapshots = snapshots.Select(snapshot => new ForecastSnapshotDataResponse {
				SnapshotId = snapshot.SnapshotId,
				Date = snapshot.Date.ToString(ActivityUtils.DateTimeToStringFormat)
			});
			return response;
		}

		/// <summary>
		/// Returns historical forecast data.
		/// </summary>
		/// <param name="requestData">Model with of data such as forecastId, periods, count, offset etc.</param>
		/// <returns><see cref="ForecastHistoryDataResponse"/>Properties of forecast data.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/objectvalue", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastHistoryObjectValueDataResponse GetObjectValueData(ForecastHistoryObjectValueRequestData requestData) {
			var response = new ForecastHistoryObjectValueDataResponse();
			SnapshotId = requestData.SnapshotId;
			SnapshotData = ForecastSnapshotRepository.Get(SnapshotId);
			var sheet = SheetRepository.GetSheet(requestData.ForecastId);
			try {
				var column = ColumnRepository.GetColumns(requestData.ForecastId)
					.FirstOrDefault(c => c.Id == requestData.ColumnId);
				var setting = ColumnSettingsMapper.GetForecastColumnSettingsData(UserConnection, column);
				var filter = new FilterConfig {
					ColumnId = requestData.ColumnId,
					PeriodIds = new[] { requestData.PeriodId },
					RecordIds = new[] { requestData.RecordId },
					ColumnSettings = setting,
					SortConfig = requestData.SortConfig,
					PagingConfig = requestData.PagingConfig
				};
				var actualData = ForecastObjectValueActualRepository.GetRecords(sheet, filter);
				var historicalData = ForecastObjectValueHistoryRepository.GetRecords(sheet, filter);
				response.DataSource = ForecastObjectValueHistoryMatcher.Match(historicalData, actualData);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Creates and writes excel stream to local storage and return export key.
		/// </summary>
		/// <param name="requestData">Model with of data such as forecastId, periods, count, offset etc.</param>
		/// <returns><see cref="ExportToExcelResponse"/>Export response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/exportobjectvalue", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ExportToExcelResponse GetExportToExcelFileKey(ForecastHistoryObjectValueRequestData requestData) {
			var response = new ExportToExcelResponse() { Success = false };
			SnapshotId = requestData.SnapshotId;
			SnapshotData = ForecastSnapshotRepository.Get(SnapshotId);
			var sheet = SheetRepository.GetSheet(requestData.ForecastId);
			try {
				var column = ColumnRepository.GetColumns(requestData.ForecastId)
					.FirstOrDefault(c => c.Id == requestData.ColumnId);
				var setting = ColumnSettingsMapper.GetForecastColumnSettingsData(UserConnection, column);
				var filter = new FilterConfig {
					ColumnId = requestData.ColumnId,
					PeriodIds = new[] { requestData.PeriodId },
					RecordIds = new[] { requestData.RecordId },
					ColumnSettings = setting,
					ColumnCaptionData = requestData.Columns,
					SortConfig = requestData.SortConfig
				};
				var historicalData = ForecastObjectValueHistoryRepository.GetRecords(sheet, filter);
				response = ForecastHistoryExportToExcelService.GetExportToExcelKey(filter, historicalData);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		#endregion

	}

	#endregion

	#region Classes: POCO

	[DataContract]
	public class HistoryTreeTableDataItem : BaseTreeTableDataItem<HistoryTableCell>
	{

		#region Constructors: Public

		public HistoryTreeTableDataItem() { }

		public HistoryTreeTableDataItem(TreeTableDataItem source) {
			this.Id = source.Id;
			this.RecordId = source.RecordId;
			this.Caption = source.Caption;
			this.IsGroup = source.IsGroup;
			this.ColumnValues = source.ColumnValues.Select(cv => new HistoryTableCell(cv)).ToList();
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "historyState")]
		public HistoryState HistoryState { get; set; }

		#endregion

	}

	[DataContract]
	public class HistoryTableCell : TableCell
	{

		#region Constructors: Public

		public HistoryTableCell() { }

		public HistoryTableCell(TableCell source) {
			this.Id = source.Id;
			this.GroupId = source.GroupId;
			this.GroupCode = source.GroupCode;
			this.ColumnId = source.ColumnId;
			this.ColumnCode = source.ColumnCode;
			this.RecordId = source.RecordId;
			this.Value = source.Value;
			this.FunctionsValueMap = source.FunctionsValueMap;
			this.HasRecords = source.HasRecords;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "actualValue")]
		public double ActualValue { get; set; }

		#endregion
	}
	
	[DataContract]
	public class HistoryTableColumn : TableColumn
	{

		#region Properties: Public

		[DataMember(Name = "historyState")]
		public HistoryState HistoryState { get; set; }

		#endregion

	}
	
	[DataContract]
	public class HistoryObjectValueRecord : ObjectValueRecord
	{

		#region Constructors: Public

		public HistoryObjectValueRecord() { }

		public HistoryObjectValueRecord(ObjectValueRecord source) {
			RefEntityId = source.RefEntityId;
			EntityId = source.EntityId;
			ColumnId = source.ColumnId;
			DisplayValue = source.DisplayValue;
			Value = source.Value;
			DeletedOn = source.DeletedOn;
			PeriodId = source.PeriodId;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "historyState")]
		public HistoryState HistoryState { get; set; }

		#endregion

	}
	
	[DataContract]
	public class SortConfig
	{
		[DataMember(Name = "columnPath")]
		public string ColumnPath { get; set; }

		[DataMember(Name = "direction")]
		public OrderDirectionStrict Direction { get; set; }
	}

	[DataContract]
	public class PagingConfig
	{
		/// <summary>
		/// Gets or sets the row count.
		/// </summary>
		/// <value>
		/// The row count.
		/// </value>
		[DataMember(Name = "rowsCount")]
		public int RowsCount { get; set; }

		/// <summary>
		/// Gets or sets the rows offset.
		/// </summary>
		/// <value>
		/// The rows offset.
		/// </value>
		[DataMember(Name = "offset")]
		public int Offset { get; set; }

		/// <summary>
		/// Gets or sets the last row value.
		/// </summary>
		/// <value>
		/// The rows offset.
		/// </value>
		[DataMember(Name = "lastValue")]
		public string LastValue { get; set; }
	}

	#endregion

}

