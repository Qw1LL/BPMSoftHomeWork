namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web;
	using Newtonsoft.Json;
	using Quartz;
	using Quartz.Impl.Matchers;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;

	#region Class: ForecastDataService

	[ServiceContract(Name = "forecast.api")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ForecastDataService : BaseService
	{

		#region Enum: ColumnType

		/// <summary>
		/// Specify the formula setting type.
		/// </summary>
		public enum FormulaSettingType
		{
			Default = 0,
			Summary = 1,
			Footer = 2
		}

		#endregion

		#region Class: ForecastDataResponse

		/// <summary>
		/// Provides properties of forecast data.
		/// </summary>
		[DataContract]
		public class ForecastDataResponse : ConfigurationServiceResponse
		{

			[DataMember(Name = "dataSource")]
			public ICollection<TreeTableDataItem> DataSource { get; set; }

			[DataMember(Name = "columns")]
			public ICollection<TableColumn> Columns { get; set; }

		}

		#endregion

		#region Class: ForecastSummaryResponse

		/// <summary>
		/// Provides properties of forecast summary.
		/// </summary>
		[DataContract]
		public class ForecastSummaryResponse : ConfigurationServiceResponse
		{

			[DataMember(Name = "summary")]
			public IDictionary<string, double> Summary { get; set; }

		}

		/// <summary>
		/// Provides properties of forecast formula cells summary.
		/// </summary>
		[DataContract]
		public class ForecastFormulaCellsSummaryResponse : ConfigurationServiceResponse
		{

			[DataMember(Name = "summary")]
			public IEnumerable<TableCell> Summary { get; set; }

			[DataMember(Name = "summaryRows")]
			public IEnumerable<TreeTableDataItem> SummaryRows { get; set; }

		}

		#endregion

		#region Class: ForecastCalculationStatusResponse

		/// <summary>
		/// Provides properties of forecast calculation status.
		/// </summary>
		[DataContract]
		public class ForecastCalculationStatusResponse : ConfigurationServiceResponse
		{

			#region Methods: Private

			private string SerializeDateTime(DateTime? dateTime) {
				return dateTime?.ToString(ActivityUtils.DateTimeToStringFormat);
			}

			#endregion

			#region Properties: Public

			public DateTime? LastCalcDate { get; set; }

			public DateTime? NextCalcDate { get; set; }

			[DataMember(Name = "isInProgress")]
			public bool IsInProgress { get; set; }

			private string _lastCalcDateTimeFormatted;
			[DataMember(Name = "lastCalcDateTime")]
			public string LastCalcDateTimeFormatted {
				get { return SerializeDateTime(LastCalcDate); }
				set { _lastCalcDateTimeFormatted = value; }
			}

			private string _nextCalcDateTimeFormatted;
			[DataMember(Name = "nextCalcDateTime")]
			public string NextCalcDateTimeFormatted {
				get { return SerializeDateTime(NextCalcDate); }
				set { _nextCalcDateTimeFormatted = value; }
			}

			#endregion

		}

		#endregion

		#region Class: ForecastColumnsResponse

		/// <summary>
		/// Provides properties of forecast columns.
		/// </summary>
		[DataContract]
		public class ForecastColumnsResponse : ConfigurationServiceResponse
		{

			[DataContract]
			public class Column
			{

				[DataMember(Name = "name")]
				public string Name { get; set; }

				[DataMember(Name = "code")]
				public string Code { get; set; }

				[DataMember(Name = "typeId")]
				public Guid TypeId { get; set; }

				[DataMember(Name = "isHide")]
				public bool IsHide { get; set; }

				[DataMember(Name = "useInSummary")]
				public bool UseInSummary { get; set; }

				[DataMember(Name = "isFractionalPartHidden")]
				public bool IsFractionalPartHidden { get; set; }
			}

			[DataMember(Name = "columns")]
			public ICollection<Column> Columns { get; set; }

		}

		#endregion

		#region Class: ForecastColumnSchemaDataResponse

		[DataContract]
		public class ForecastColumnSchemaDataResponse : ConfigurationServiceResponse
		{

			[DataMember(Name="primaryColumnName")]
			public string PrimaryColumnName { get; set; }
			
			[DataMember(Name="primaryColumnCaption")]
			public string PrimaryColumnCaption { get; set; }

			[DataMember(Name="displayValueColumnName")]
			public string DisplayValueColumnName { get; set; }

			[DataMember(Name="displayValueColumnCaption")]
			public string DisplayValueColumnCaption { get; set; }

			[DataMember(Name="valueColumnName")]
			public string ValueColumnName { get; set; }

			[DataMember(Name="valueColumnCaption")]
			public string ValueColumnCaption { get; set; }

			[DataMember(Name = "entitySchemaName")]
			public string EntitySchemaName { get; set; }
			
			[DataMember(Name = "entitySchemaUId")]
			public Guid EntitySchemaUId { get; set; }

		}

		#endregion

		#region Class: ForecastRequestData

		/// <summary>
		/// Provides properties of forecast data request.
		/// </summary>
		[DataContract]
		public class ForecastRequestData
		{
			[DataMember(Name = "forecastId")]
			public Guid ForecastId { get; set; }

			[DataMember(Name = "periods")]
			public IEnumerable<Guid> Periods { get; set; }

			[DataMember(Name = "offset")]
			public string Offset { get; set; }

			[DataMember(Name = "count")]
			public int Count { get; set; }

			[DataMember(Name = "lastRow")]
			public string LastRow { get; set; }

			[DataMember(Name = "hierarchyRows")]
			public IEnumerable<Guid> HierarchyRows { get; set; }

			[DataMember(Name = "filterValue")]
			public string FilterValue { get; set; }
		}

		#endregion

		#region ForecastSummaryRequestData

		/// <summary>
		/// Provides properties of forecast summary request.
		/// </summary>
		[DataContract]
		public class ForecastSummaryRequestData
		{
			[DataMember(Name = "forecastId")]
			public Guid ForecastId { get; set; }

			[DataMember(Name = "periods")]
			public IEnumerable<Guid> Periods { get; set; }
		}

		#endregion

		#region ForecastLczRequestData

		/// <summary>
		/// Provides properties of forecast localization request.
		/// </summary>
		[DataContract]
		public class ForecastLczRequestData
		{
			[DataMember(Name = "keys")]
			public IEnumerable<string> Keys { get; set; }
		}

		#endregion

		#region Constants: Private

		private const string LczResourcesSchemaName = "ForecastLczResources";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<ForecastDataService>();

		#endregion

		#region Properties: Protected

		private IForecastProviderV2 _forecastProvider;

		/// <summary>Gets the forecast provider.</summary>
		/// <value>The forecast provider.</value>
		protected IForecastProviderV2 ForecastProvider =>
			_forecastProvider ?? (_forecastProvider = ClassFactory.Get<IForecastProviderV2>());

		private ForecastDataMapper _forecastDataMapper;

		/// <summary>Gets the forecast data mapper.</summary>
		/// <value>The forecast data mapper.</value>
		protected ForecastDataMapper ForecastDataMapper =>
			_forecastDataMapper ?? (_forecastDataMapper = ClassFactory.Get<ForecastDataMapper>());

		private IForecastSheetRepository _sheetRepository;

		/// <summary>Gets the forecast sheet repository.</summary>
		/// <value>The forecast sheet repository.</value>
		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>());

		private IForecastCellRepository _cellRepository;

		/// <summary>Gets the forecast cell repository.</summary>
		/// <value>The forecast cell repository.</value>
		protected IForecastCellRepository CellRepository =>
			_cellRepository ?? (_cellRepository = ClassFactory.Get<IForecastCellRepository>());

		private IForecastSummaryProvider _forecastSummaryProvider;

		/// <summary> Gets the forecast summary. </summary>
		/// <value> The forecast summary. </value>
		protected IForecastSummaryProvider ForecastSummaryProvider =>
			_forecastSummaryProvider ?? (_forecastSummaryProvider = ClassFactory.Get<IForecastSummaryProvider>());

		private IForecastColumnRepository _columnRepository;

		/// <summary> Gets the forecast columns repository. </summary>
		/// <value> The columns repository. </value>
		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>());

		private IForecastColumnSettingsMapper _mapper;

		protected IForecastColumnSettingsMapper ColumnSettingsMapper =>
			_mapper ?? (_mapper =
				ClassFactory.Get<IForecastColumnSettingsMapper>());

		private IForecastCalculationScheduler _forecastCalculationScheduler;

		/// <summary> Gets the forecast columns repository. </summary>
		/// <value> The columns repository. </value>
		protected IForecastCalculationScheduler ForecastCalculationScheduler =>
			_forecastCalculationScheduler ?? (_forecastCalculationScheduler = ClassFactory.Get<IForecastCalculationScheduler>());


		private IForecastRowRepository _rowRepository;

		/// <summary> Gets the forecast delete cell repository. </summary>
		/// <value> The columns repository. </value>
		protected IForecastRowRepository RowRepository =>
			_rowRepository ?? (_rowRepository = ClassFactory.Get<IForecastRowRepository>());

		/// <summary> Gets the remove entity forecast repository. </summary>
		/// <value> The remove entity forecast repository. </value>
		protected IRemoveEntityForecastRepository RemoveRowRepository =>
			RowRepository  as IRemoveEntityForecastRepository;

		private IFormulaSummaryCalculator _formulaSummaryCalculator;

		/// <summary> Gets the forecast formula summary calculator. </summary>
		/// <value> The formula summary calculator. </value>
		protected IFormulaSummaryCalculator FormulaSummaryCalculator =>
			_formulaSummaryCalculator ?? (_formulaSummaryCalculator = ClassFactory.Get<IFormulaSummaryCalculator>());

		private IForecastSummaryColumnCalculator _summaryColumnCalculator;

		/// <summary> Gets the forecast summary columns calculator. </summary>
		/// <value> The formula summary calculator. </value>
		protected IForecastSummaryColumnCalculator SummaryColumnCalculator =>
			_summaryColumnCalculator ??
			(_summaryColumnCalculator = ClassFactory.Get<IForecastSummaryColumnCalculator>());

		/// <summary> Gets the formula utilities. </summary>
		/// <value> The formula utilities. </value>
		protected FormulaUtilities FormulaUtilities => ClassFactory.Get<FormulaUtilities>();

		private IPeriodRepository _periodRepository;

		protected IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>());

		private IForecastGroupCellsProvider _groupCellsProvider;

		protected IForecastGroupCellsProvider GroupCellsProvider =>
			_groupCellsProvider ?? (_groupCellsProvider = ClassFactory.Get<IForecastGroupCellsProvider>());

		#region Methods: Private

		private static ForecastColumnsResponse.Column ToResponseFormulaColumn(ForecastColumn column) {
			var settings = column.GetColumnSettings<FormulaSetting>();
			return new ForecastColumnsResponse.Column {
				Name = column.Name,
				Code = column.Code,
				TypeId = column.TypeId,
				UseInSummary = settings.UseInSummary,
				IsFractionalPartHidden = settings.IsFractionalPartHidden
			};
		}

		private void NotifyAllUsers(string messageCode, Guid forecastId) {
			var message = new {
				forecastId
			};
			MsgChannelUtilities.PostMessageToAll(messageCode, JsonConvert.SerializeObject(message));
		}

		private IDictionary<string, double> ConvertCellsToSummary(IEnumerable<TableCell> summaryCells) {
			IDictionary<string, double> summary = new Dictionary<string, double>();
			summaryCells.ForEach(cell => {
				summary[cell.ColumnCode] = cell.Value;
			});
			return summary;
		}

		private bool IsFormulaInColumnValid(FormulaSetting settings, FormulaSettingType type) {
			if (UserConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
				if (type == FormulaSettingType.Summary) {
					return FormulaUtilities.Validate(settings.SummaryValue ?? new FormulaItem[0]);
				}
			}
			return FormulaUtilities.Validate(settings.Value ?? new FormulaItem[0]);
		}

		#endregion

		#endregion

		#region Methods: Private

		private IEnumerable<Guid> ConvertStringIdentifiersToGuidList(string str) {
			var ids = string.IsNullOrEmpty(str) ? new Guid[] { } : str.Split(',').Select(e => new Guid(e));
			return ids;
		}

		private void FilterHiddenColumns(ICollection<TableColumn> columns) {
			columns.ForEach(periodColumn => {
				periodColumn.Children = periodColumn.Children.Where(c => !c.IsHide).ToArray();
			});
		}

		private ForecastDataResponse ProcessGetForecastData(ForecastRequestData requestData) {
			var response = new ForecastDataResponse();
			try {
				var periodIds = requestData.Periods;
				var hierarchyRowsId = requestData.HierarchyRows;
				int rowOffset = int.TryParse(requestData.Offset, out rowOffset) ? rowOffset : 0;
				int hierarchyLevel = hierarchyRowsId.Count();
				var pageableConfig = new PageableConfig() {
					RowCount = requestData.Count,
					RowsOffset = rowOffset,
					LastValue = requestData.LastRow,
					HierarchyRowsId = hierarchyRowsId,
					HierarchyLevel = hierarchyLevel,
					PrimaryFilterValue = HttpUtility.UrlDecode(requestData.FilterValue)
				};
				var data = ForecastProvider.GetData(requestData.ForecastId, periodIds, pageableConfig);
				var columns = ForecastDataMapper.GetMapTableColumns(data);
				response.DataSource = ForecastDataMapper.GetMapTreeTableDataItems(data, columns);
				var sheet = SheetRepository.GetSheet(requestData.ForecastId);
				var periodsId = PeriodRepository.GetForecastPeriods(periodIds, sheet.PeriodTypeId);
				if (UserConnection.GetIsFeatureEnabled("ForecastSummaryFormula") && periodsId.Count() > 1) {
					SummaryColumnCalculator.ApplySummaryColumns(UserConnection, columns);
					SummaryColumnCalculator.ApplySummaryData(UserConnection, requestData.ForecastId,
						response.DataSource);
				}
				FilterHiddenColumns(columns);
				response.Columns = columns;
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		private ForecastSummaryResponse ProcessGetForecastSummary(ForecastSummaryRequestData requestData) {
			var response = new ForecastSummaryResponse();
			try {
				var sheet = SheetRepository.GetSheet(requestData.ForecastId);
				var summaryCells = ForecastSummaryProvider.GetSummary(sheet, new FilterConfig {
					PeriodIds = requestData.Periods
				});
				var record = new TreeTableDataItem {
					ColumnValues = summaryCells.ToList()
				};
				if (UserConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
					SummaryColumnCalculator.ApplySummaryData(UserConnection, requestData.ForecastId,
						new []{ record });
				}
				response.Summary = ConvertCellsToSummary(record.ColumnValues);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		private Dictionary<string, string> GelLczDataDictionary(IEnumerable<string> keys) {
			var resources = new Dictionary<string, string>();
			foreach (string key in keys) {
				resources[key] = UserConnection.GetLocalizableString(LczResourcesSchemaName, key);
			}
			return resources;
		}

		private void CheckIsAbleToCalculateForecast() {
			var isAble = false;
			if (UserConnection.GetIsFeatureEnabled("ForecastCalculationByOperationRights")) {
				isAble = UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanCalculateForecast");
			} else {
				var userAdminUnitCollection = UserConnection.DBSecurityEngine.GetUserAdminUnitCollection();
				isAble = userAdminUnitCollection.Any(id =>
					id.Equals(ForecastConsts.FinanceRoleId) ||
					id.Equals(BaseConsts.SystemAdministratorsSysAdminUnitId));
			}
			if (!isAble) {
				throw new SecurityException(new LocalizableString("BPMSoft.Core",
					"ProcessSchemaManager.Exception.NoRightForModify"));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns forecast data.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="periods">Collection of periods identifier. Values separated by comma.</param>
		/// <returns><see cref="ForecastDataResponse"/>Properties of forecast data.</returns>
		[OperationContract]
		[WebInvoke(Method = "GET",
			UriTemplate = "/forecast/{forecastId}" +
				"?periods={periods}&offset={offset}&count={count}&lastRow={lastRow}&hierarchyRows={hierarchyRows}&filterValue={filterValue}",
			BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastDataResponse GetForecastData(string forecastId, string periods, string offset, string count,
			string lastRow, string hierarchyRows, string filterValue) {
			var requestData = new ForecastRequestData() {
				ForecastId = new Guid(forecastId),
				Periods = ConvertStringIdentifiersToGuidList(periods),
				Offset = offset,
				Count = int.TryParse(count, out var rowCount) ? rowCount : -1,
				LastRow = lastRow,
				HierarchyRows = ConvertStringIdentifiersToGuidList(hierarchyRows),
				FilterValue = filterValue
			};
			var response = ProcessGetForecastData(requestData);
			return response;
		}

		/// <summary>
		/// Returns forecast data.
		/// </summary>
		/// <param name="requestData">Model with of data such as forecastId, periods, count, offset etc.</param>
		/// <returns><see cref="ForecastDataResponse"/>Properties of forecast data.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastDataResponse GetForecastDataByPostMethod(ForecastRequestData requestData) {
			var response = ProcessGetForecastData(requestData);
			return response;
		}

		/// <summary>
		/// Returns forecast data.
		/// </summary>
		/// <param name="requestData">Model with of data such as ForecastId, periods.</param>
		/// <returns><see cref="ForecastDataResponse"/>Properties of forecast data.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/summary", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastSummaryResponse GetSummaryByPostMethod(ForecastSummaryRequestData requestData) {
			var response = ProcessGetForecastSummary(requestData);
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/forecast/{forecastId}/summary?periods={periods}",
			BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastSummaryResponse GetSummary(string forecastId, string periods) {
			var requestData = new ForecastSummaryRequestData() {
				Periods = ConvertStringIdentifiersToGuidList(periods),
				ForecastId = new Guid(forecastId)
			};
			var response = ProcessGetForecastSummary(requestData);
			return response;
		}

		/// <summary>
		/// Gets status of calculation.
		/// </summary>
		/// <param name="forecastId">Forecast sheet identifier.</param>
		/// <returns>Status of calculation.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/calc/status",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastCalculationStatusResponse GetCalcStatus(Guid forecastId) {
			forecastId.CheckArgumentEmpty(nameof(forecastId));
			var result = ForecastCalculationScheduler.GetCalculationStatus(new QuartzSchedulerConfig() {
				ForecastId = forecastId
			});
			var response = new ForecastCalculationStatusResponse() {
				IsInProgress = result.IsInProgress,
				LastCalcDate = result.LastCalcDateTime,
				NextCalcDate = result.NextCalcDateTime
			};
			return response;
		}

		/// <summary>
		/// Calculates formulas summary according to formulas dependent cells values.
		/// </summary>
		/// <param name="forecastId">Forecast sheet identifier.</param>
		/// <param name="summaryData">Cell values used in formulas.</param>
		/// <returns>Calculated formula summary cells.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/formula/summary", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastFormulaCellsSummaryResponse GetFormulaSummary(Guid forecastId, TableCell[] summaryData) {
			var response = new ForecastFormulaCellsSummaryResponse();
			try {
				var records = ForecastDataMapper.GetMapTreeTableDataItems(summaryData);
				var summaryRows = FormulaSummaryCalculator.CalcFormulaSummary(new FormulaSummaryParams {
					ForecastId = forecastId,
					Rows = records
				});
				var allCells = new List<TableCell>();
				summaryRows.ForEach(row => allCells.AddRange(row.ColumnValues));
				response.Summary = allCells;
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Calculates formulas summary according to formulas dependent cells values.
		/// </summary>
		/// <param name="forecastId">Forecast sheet identifier.</param>
		/// <param name="rows">Table rows which have column values to calculate formula.</param>
		/// <returns>Calculated formula summary cells.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/formula/summary/v2",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastFormulaCellsSummaryResponse GetFormulaSummaryV2(Guid forecastId, TreeTableDataItem[] rows) {
			var response = new ForecastFormulaCellsSummaryResponse();
			try {
				response.SummaryRows = FormulaSummaryCalculator.CalcFormulaSummary(new FormulaSummaryParams {
					ForecastId = forecastId,
					Rows = rows
				});
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/calc", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse RecalculateFact(Guid forecastId, string[] periods) {
			var response = new ConfigurationServiceResponse();
			try {
				CheckIsAbleToCalculateForecast();
				IEnumerable<Guid> periodIds = periods.Select(p => new Guid(p)).Take(ForecastConsts.MaxPeriodsCount);
				ForecastCalculationScheduler.TriggerJob(new QuartzSchedulerConfig() {
					ForecastId = forecastId,
					PeriodIds = periodIds.ToList()
				});
				if (UserConnection.GetIsFeatureEnabled("ForecastAutoCalculation")) {
					NotifyAllUsers(ForecastConsts.ForecastCalcStartedMessage, forecastId);
				}
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/cell", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SaveCell(Guid forecastId, Guid recordId, Guid periodId, Guid columnId,
			string value) {
			var response = new ConfigurationServiceResponse();
			var sheet = SheetRepository.GetSheet(forecastId);
			try {
				CellRepository.SaveCell(sheet, new Cell {
					EntityId = recordId,
					PeriodId = periodId,
					ColumnId = columnId,
					Value = Convert.ToDecimal(value, CultureInfo.InvariantCulture)
				});
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/groupcell",
			BodyStyle = WebMessageBodyStyle.WrappedResponse, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "SaveCellResult")]
		public ConfigurationServiceResponse SaveGroupCell(SaveGroupCellParams parameters) {
			var response = new ConfigurationServiceResponse();
			var sheet = SheetRepository.GetSheet(parameters.ForecastId);
			try {
				GroupCellsProvider.SaveGroupCell(sheet, parameters);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Deletes forecast cells.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="columnId">Forecast column identifier.</param>
		/// <param name="periods">Collection of periods identifiers</param>
		/// <returns><see cref="ConfigurationServiceResponse"/></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/cells/delete", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteCells(Guid forecastId, Guid columnId, Guid[] periods) {
			periods = periods ?? new Guid[0];
			var periodCollection = periods.Select(id => new Period {
				Id = id
			});
			var response = new ConfigurationServiceResponse();
			try {
				var sheet = SheetRepository.GetSheet(forecastId);
				CellRepository.DeleteCells(sheet, periodCollection, new[] {
					new ForecastColumn() {
						Id = columnId
					}
				});
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Returns localizable data.
		/// </summary>
		/// <param name="keys">Resources keys. Values separated by comma.</param>
		/// <returns>Dictionary of localizable strings.</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/forecast/lcz/{keysStr}", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, string> GetLczData(string keysStr) {
			string[] keys = keysStr.Split(',');
			return GelLczDataDictionary(keys);
		}

		/// <summary>
		/// Returns localizable data.
		/// </summary>
		/// <param name="requestData">Object that contain list of resources keys.</param>
		/// <returns>Dictionary of localizable strings.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/lcz", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, string> GetLczDataByPost(ForecastLczRequestData requestData) {
			return GelLczDataDictionary(requestData.Keys);
		}

		/// <summary>
		/// Returns <c>true</c>, if valid, <c>false</c> otherwise.
		/// </summary>
		/// <param name="columnTypeId">The column type identifier.</param>
		/// <param name="settings">The settings.</param>
		/// <param name="type"> The column settings type.</param>
		/// <returns>Returns <c>true</c>, if valid, <c>false</c> otherwise.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/column/validate", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse GetIsValidColumn(Guid columnTypeId, string settings,
			FormulaSettingType type = FormulaSettingType.Default) {
			var response = new ConfigurationServiceResponse();
			if (columnTypeId.Equals(ForecastConsts.FormulaColumnTypeId)) {
				var forecastColumn = new ForecastColumn {
					Settings = settings
				};
				var formulaSetting = forecastColumn.GetColumnSettings<FormulaSetting>();
				var isValid = IsFormulaInColumnValid(formulaSetting, type);
				response.Success = isValid;
				if (!isValid) {
					var message = UserConnection.GetLocalizableString(LczResourcesSchemaName, "FormulaNotValidMessage");
					response.ErrorInfo = new ErrorInfo {
						Message = message
					};
				}
			}
			return response;
		}

		/// <summary>
		/// Deletes column.
		/// </summary>
		/// <param name="columnId">The column identifier.</param>
		/// <param name="sheetId">The forecast sheet identifier.</param>
		/// <returns>Returns <c>true</c>, if valid, <c>false</c> otherwise.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/column/delete", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteColumn(Guid columnId, Guid sheetId) {
			var response = new ConfigurationServiceResponse();
			var isSuccess = false;
			IEnumerable<ForecastColumn> columns = ColumnRepository.GetColumns(sheetId);
			ForecastColumn column = columns.FirstOrDefault(c => c.Id == columnId);
			if (column != null) {
				try {
					var formulaColumns = FormulaUtilities.GetDependColumns(columns, column);
					if (!formulaColumns.Any()) {
						var sheet = SheetRepository.GetSheet(sheetId);
						isSuccess = ColumnRepository.Delete(sheet, columnId);
					} else {
						var messageTemplate =
							UserConnection.GetLocalizableString(LczResourcesSchemaName, "ColumnUsedInFormula");
						var message = string.Format(messageTemplate, formulaColumns.First().Name);
						response.ErrorInfo = new ErrorInfo {
							Message = message
						};
					}
				} catch (Exception ex) {
					response.Exception = ex;
				}
			} else {
				response.Exception = new KeyNotFoundException(columnId.ToString());
			}
			response.Success = isSuccess;
			return response;
		}

		/// <summary>
		/// Deletes forecast record.
		/// </summary>
		/// <param name="recordId">The record identifier.</param>
		/// <param name="forecastId">The forecast sheet identifier.</param>
		/// <param name="periodIds">Sheet period's identifiers.</param>
		/// <returns>Returns <c>true</c>, if valid, <c>false</c> otherwise.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/row/delete", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteForecastEntityRow(Guid recordId, Guid forecastId) {
			RowRepository.UserConnection = UserConnection;
			var response = new ConfigurationServiceResponse();
			var sheet = SheetRepository.GetSheet(forecastId);
			var config = new FilterConfig() {
				RecordIds = new List<Guid>() {
					recordId
				}
			};
			try {
				var rowIds = RowRepository.Get(sheet, config);
				if (rowIds.Any()) {
					var records = new[] { recordId };
					GroupCellsProvider.RecalculateGroupCells(sheet, new RecalculateGroupCellsParameters {
						RecordIds = records,
						ExcludedRecords = records
					});
					var item = rowIds.First();
					var args = new RemoveEntityForecastParams() {
						ForecastRowId = item,
						ForecastId = forecastId
					};
					response.Success = RemoveRowRepository.Remove(args);
				}
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Gets forecast columns of sheet.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <returns><see cref="ForecastColumnsResponse"/></returns>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/forecast/{forecastId}/columns", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ForecastColumnsResponse GetColumns(string forecastId) {
			var response = new ForecastColumnsResponse();
			try {
				var sheetId = new Guid(forecastId);
				ICollection<ForecastColumnsResponse.Column> columns =
					ColumnRepository.GetColumns(sheetId).Select(ToResponseFormulaColumn).ToList();
				response.Columns = columns;
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Get forecast cell values for specified records.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="forecastColumns">Forecast columns</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/columns/update", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateColumns(Guid forecastId,
			ICollection<ForecastColumnsResponse.Column> forecastColumns) {
			var response = new ConfigurationServiceResponse();
			try {
				IEnumerable<ForecastColumn> columns = forecastColumns.Select((fc, index) => new ForecastColumn {
					Name = fc.Name,
					Code = fc.Code,
					TypeId = fc.TypeId,
					Position = index
				});
				ColumnRepository.UpdateColumns(columns);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Get forecast cell values for specified records.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="periods">Periods identifiers.</param>
		/// <param name="records">Records identifiers.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/cell/records",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastDataResponse GetCellValuesByRecords(Guid forecastId, Guid[] periods, Guid[] records) {
			var response = new ForecastDataResponse();
			if (!records.Any()) {
				response.DataSource = new TreeTableDataItem[0];
				return response;
			}
			var data = ForecastProvider.GetData(forecastId, new FilterConfig {
				PeriodIds = periods,
				RecordIds = records
			});
			var columns = ForecastDataMapper.GetMapTableColumns(data);
			response.DataSource = ForecastDataMapper.GetMapTreeTableDataItems(data, columns);
			if (UserConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
				SummaryColumnCalculator.ApplySummaryData(UserConnection, forecastId, response.DataSource);
			}
			return response;
		}

		/// <summary>
		/// Gets the cell values by group records.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="periods">Periods identifiers.</param>
		/// <param name="groupsCollection">The record groups collection.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/cell/groups",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastDataResponse GetCellValuesByGroupRecords(Guid forecastId, Guid[] periods,
			GroupRecordsItem[] groupsCollection) {
			var response = new ForecastDataResponse();
			if (!UserConnection.GetIsFeatureEnabled("ForecastGroupSummary") || !groupsCollection.Any()) {
				response.DataSource = new TreeTableDataItem[0];
				return response;
			}
			var sheet = SheetRepository.GetSheet(forecastId);
			var sheetHierarchyList = sheet.GetHierarchyItems();
			var allRows = new List<TreeTableDataItem>();
			try {
				groupsCollection.ForEach(groupItem => {
					int level = groupItem.ParentIds?.Length ?? 0;
					HierarchySettingItem hierarchyItem = sheetHierarchyList.FirstOrDefault(item => item.Level == level);
					if (hierarchyItem == null) {
						string message = $"Could not get hierarchy item by level {level}. ForecastId: {forecastId}";
						_log.Error(message);
						throw new Exception(message);
					}
					IEnumerable<HierarchyFilterItem> hierarchyFilterItems =
						sheet.FormHierarchyFilter(groupItem.ParentIds);
					var cells = ForecastSummaryProvider.GetGroupsSummary(sheet, new FilterConfig() {
						PeriodIds = periods,
						RecordIds = groupItem.RecordIds,
						Hierarchy = hierarchyFilterItems,
						GroupColumnPath = hierarchyItem?.ColumnPath
					});
					var rows = ForecastDataMapper.GetMapTreeTableDataItems(cells, groupItem.ParentIds);
					rows.ForEach(row => row.IsGroup = true);
					allRows.AddRange(rows);
				});
				response.DataSource = allRows;
				if (UserConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
					SummaryColumnCalculator.ApplySummaryData(UserConnection, forecastId, response.DataSource);
				}
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Recalculates cells of records, that are in groups with specified records.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="periodIds">Periods identifiers.</param>
		/// <param name="recordIds">Forecast records identifiers.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/recalcgroupcells",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse RecalculateGroupCells(Guid forecastId, Guid[] recordIds) {
			var response = new ConfigurationServiceResponse();
			var sheet = SheetRepository.GetSheet(forecastId);
			try {
				GroupCellsProvider.RecalculateGroupCells(sheet, new RecalculateGroupCellsParameters {
					RecordIds = recordIds
				});
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Returns primary display value and value columns names.
		/// </summary>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="columnId">Column identifiers.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/forecast/column/schemadata",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ForecastColumnSchemaDataResponse GetForecastColumnSchemaData(Guid forecastId, Guid columnId) {
			var response = new ForecastColumnSchemaDataResponse();
			try {
				ForecastColumn column = ColumnRepository.GetColumns(forecastId)
					.FirstOrDefault(c => c.Id == columnId);
				if (column == null) {
					return response;
				}
				ColumnSettingsData settingsData = ColumnSettingsMapper.GetForecastColumnSettingsData(UserConnection, column);
				EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(settingsData.SourceEntityName);
				EntitySchemaColumn funcColumn = schema.GetSchemaColumnByPath(settingsData.FuncColumnName);
				response.PrimaryColumnName = schema.PrimaryColumn?.Name;
				response.PrimaryColumnCaption = schema.PrimaryColumn?.Caption;
				response.DisplayValueColumnName = schema.PrimaryDisplayColumn?.Name;
				response.DisplayValueColumnCaption = schema.PrimaryDisplayColumn?.Caption;
				response.ValueColumnName = funcColumn?.Name;
				response.ValueColumnCaption = funcColumn?.Caption;
				response.EntitySchemaName = schema.Name;
				response.EntitySchemaUId = schema.UId;
			} catch (Exception ex) {
				response.Success = false;
				response.Exception = ex;
			}
			return response;
		}

		#endregion

	}

	#endregion

	#region Classes: POCO

	[DataContract]
	public class BaseTreeTableDataItem<T> where T: TableCell
	{

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "recordId")]
		public Guid RecordId { get; set; }

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "isGroup")]
		public bool IsGroup { get; set; }

		[DataMember(Name = "columnValues")]
		public ICollection<T> ColumnValues { get; set; }

	}

	public class TreeTableDataItem : BaseTreeTableDataItem<TableCell>
	{ }

	[DataContract]
	public class TableCell
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "columnCode")]
		public string ColumnCode { get; set; }

		public Guid ColumnId { get; set; }

		[DataMember(Name = "recordId")]
		public Guid RecordId { get; set; }

		[DataMember(Name = "groupCode")]
		public string GroupCode { get; set; }

		[DataMember(Name = "groupId")]
		public Guid GroupId { get; set; }

		[DataMember(Name = "value")]
		public double Value { get; set; }

		[DataMember(Name = "hasRecords")]
		public Boolean HasRecords { get; set; }

		public IDictionary<string, double> FunctionsValueMap;

		/// <summary>
		/// Forms column code from column code and group code.
		/// </summary>
		/// <returns></returns>
		public string FormColumnCode() {
			return string.Join("_", ColumnCode, GroupCode?.Replace(" ", "_"));
		}

	}

	[DataContract]
	public class TableColumn
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "code")]
		public string Code { get; set; }

		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		[DataMember(Name = "children")]
		public ICollection<TableColumn> Children { get; set; }

		[DataMember(Name = "isEditable")]
		public bool IsEditable { get; set; }

		[DataMember(Name = "editMode")]
		public ColumnEditMode EditMode { get; set; }

		[DataMember(Name = "isHide")]
		public bool IsHide { get; set; }

		[DataMember(Name = "isFractionalPartHidden")]
		public bool IsFractionalPartHidden { get; set; }

		public Guid TypeId { get; set; }
	}

	[DataContract]
	public class GroupRecordsItem
	{
		[DataMember(Name = "parentIds")]
		public Guid[] ParentIds { get; set; }

		[DataMember(Name = "children")]
		public Guid[] RecordIds { get; set; }
	}

	[DataContract]
	public class SaveCellParams
	{
		[DataMember(Name = "forecastId")]
		public Guid ForecastId { get; set; }

		[DataMember(Name = "recordId")]
		public Guid RecordId { get; set; }

		[DataMember(Name = "periodId")]
		public Guid PeriodId { get; set; }

		[DataMember(Name = "columnId")]
		public Guid ColumnId { get; set; }

		[DataMember(Name = "value")]
		public decimal Value { get; set; }
	}

	[DataContract]
	public class SaveGroupCellParams : SaveCellParams
	{
		[DataMember(Name = "groupIds")]
		public Guid[] GroupIds { get; set; }

		/// <summary>
		/// Excluded records from group value calculation.
		/// </summary>
		public IEnumerable<Guid> ExcludedRecords { get; set; }
	}

	#endregion

}

