namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region Class: ForecastCalcParams

	/// <summary>
	/// Parameters for forcast column calculations.
	/// </summary>
	public partial class ForecastCalcParams
	{

		#region Constructors: Public

		public ForecastCalcParams(Guid forecastId, IEnumerable<Guid> periods) {
			ForecastId = forecastId;
			Periods = periods;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the forecast identifier.
		/// </summary>
		/// <value>
		/// The forecast identifier.
		/// </value>
		public Guid ForecastId { get; private set; }

		/// <summary>
		/// Gets or sets the periods.
		/// </summary>
		/// <value>
		/// The periods.
		/// </value>
		public IEnumerable<Guid> Periods { get; private set; }

		/// <summary>
		/// Gets or sets the forecast cells.
		/// </summary>
		/// <value>
		/// The cells.
		/// </value>
		public List<Cell> Cells { get; set; }

		#endregion
	}

	#endregion

	#region Class: ForecastObjectValueColumnCalculator

	/// <summary>
	/// Calculates forecast object value columns.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ForecastV2.IForecastCalculator" />
	[DefaultBinding(typeof(IForecastCalculator), Name = ForecastConsts.ObjectValueColumnTypeName)]
	public class ForecastObjectValueColumnCalculator : IForecastCalculator {

		#region Classes: Private

		/// <summary>
		/// Column path parts.
		/// </summary>
		private class ColumnPathParts
		{
			/// <summary>
			/// Gets or sets the entity path.
			/// </summary>
			/// <value>
			/// The entity path.
			/// </value>
			public string EntityPath { get; internal set; }
			/// <summary>
			/// Gets or sets the column path.
			/// </summary>
			/// <value>
			/// The column path.
			/// </value>
			public string ColumnPath { get; internal set; }
		}

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<ForecastObjectValueColumnCalculator>();

		#endregion

		#region Constructors: Public

		public ForecastObjectValueColumnCalculator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; private set; }
		protected Sheet ForecastSheet { get; private set; }
		protected IEnumerable<Period> Periods { get; private set; }
		protected string ReferenceSchemaName { get; set; }
		protected string SchemaNamePrefix { get; set; }
		protected EntitySchema EntityForecastSchema { get; set; }

		private IForecastCellRepository _cellRepository;
		protected IForecastCellRepository CellRepository =>
			_cellRepository ?? (_cellRepository = ClassFactory.Get<IForecastCellRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastSheetRepository _sheetRepository;
		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IPeriodRepository _periodRepository;
		protected IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastColumnRepository _columnRepository;
		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastObjectValueAddFromSelectOperation _forecastObjValueAddFromSelectOperation;
		protected IForecastObjectValueAddFromSelectOperation ForecastObjectValueAddFromSelectOperation =>
			_forecastObjValueAddFromSelectOperation ?? (_forecastObjValueAddFromSelectOperation =
				ClassFactory.Get<IForecastObjectValueAddFromSelectOperation>(
					new ConstructorArgument("userConnection", UserConnection)));

		private IForecastColumnSettingsMapper _mapper;
		protected IForecastColumnSettingsMapper ColumnSettingsMapper =>
			_mapper ?? (_mapper =
				ClassFactory.Get<IForecastColumnSettingsMapper>());

		protected bool ForecastDrilldownEnabled => UserConnection.GetIsFeatureEnabled("ForecastDrilldown");

		#endregion

		#region Methods: Private

		private IEnumerable<ForecastColumn> GetObjectValueColumns() {
			var columns = ColumnRepository.GetColumns(ForecastSheet.Id);
			return columns.Where(c => c.TypeId == ForecastConsts.ObjectValueColumnTypeId);
		}

		private void InitPeriods(IEnumerable<Guid> periodIds) {
			Periods = PeriodRepository.GetForecastPeriods(periodIds, ForecastSheet.PeriodTypeId);
		}

		private void InitData(ForecastCalcParams parameters) {
			ForecastSheet = SheetRepository.GetSheet(parameters.ForecastId);
			InitPeriods(parameters.Periods);
			parameters.Cells = parameters.Cells ?? new List<Cell>();
			EntityForecastSchema = UserConnection.EntitySchemaManager
				.GetInstanceByUId(ForecastSheet.ForecastEntityInCellUId);
			ReferenceSchemaName = UserConnection.EntitySchemaManager
				.GetItemByUId(ForecastSheet.ForecastEntityUId).Name;
			SchemaNamePrefix = Core.Configuration.SysSettings.GetDefValue(UserConnection,
					"SchemaNamePrefix") as string;
		}

		private void AddEntitiesFilter(string entityInCellColumnPath, EntitySchemaQuery esq) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				$"{entityInCellColumnPath}.Sheet", ForecastSheet.Id));
			esq.Filters.Add(esq.CreateIsNullFilter($"{entityInCellColumnPath}.Period"));
			esq.Filters.Add(esq.CreateIsNullFilter($"{entityInCellColumnPath}.ForecastColumn"));
		}

		private void AddPeriodFilter(Period period, string columnName, EntitySchemaQuery esq) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Between,
				columnName,
				period.StartDate,
				period.DueDate.AddDays(1).AddSeconds(-1)));
		}

		private void AddSettingsFilter(ColumnSettingsData settings, EntitySchemaQuery esq) {
			IEntitySchemaQueryFilterItem filterItem = settings.FilterData?.BuildEsqFilter(
				settings.FilterData.RootSchemaName, UserConnection);
			if (filterItem != null) {
				esq.Filters.Add(filterItem);
			}
		}

		private void SaveCells(List<Cell> cells) {
			CellRepository.InsertCells(ForecastSheet, cells);
		}

		private decimal CalcValue(ColumnSettingsData settings, decimal value) {
			string operand = settings.PercentOperand;
			if (operand.IsNotNullOrEmpty() && value != 0) {
				if (decimal.TryParse(operand, out var decimalValue)) {
					value = value / 100 * decimalValue;
				}
			}
			return value;
		}

		private string GetEntityInCellColumnPath(ColumnSettingsData settings) {
			var refColumn = ForecastSheet.GetEntityReferenceColumn(UserConnection);
			if (refColumn == null) {
				string message = $"Reference column by schema name {ReferenceSchemaName} not found.";
				_log.Error(message);
				throw new ItemNotFoundException(message);
			}
			var referenceParts = GetReferenceParts(settings.ReferenceColumnName);
			string columnPath = $"{referenceParts.EntityPath}" +
					$"=[{EntityForecastSchema.Name}:{refColumn.Name}:{referenceParts.ColumnPath}]";
			return columnPath;
		}

		private ColumnPathParts GetReferenceParts(string referenceColumnName) {
			if (!referenceColumnName.Contains('.')) {
				return new ColumnPathParts {
					ColumnPath = referenceColumnName,
					EntityPath = string.Empty
				};
			}
			var refColumnParts = referenceColumnName.Split('.');
			var entitiesParts = refColumnParts.Take(refColumnParts.Length - 1);
			return new ColumnPathParts {
				EntityPath = string.Join(".", entitiesParts) + '.',
				ColumnPath = refColumnParts.Last()
			};
		}

		private void InsertObjectValueRecords(ColumnSettingsData settings, string columnPath, Period period,
			ForecastColumn column) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, settings.SourceEntityName);
			esq.IgnoreDisplayValues = true;
			esq.AddColumn("Id");
			var refCol = esq.AddColumn($"{settings.ReferenceColumnName}");
			AddEsqFilters(settings, esq, period, columnPath);
			Select select = esq.GetSelectQuery(UserConnection);
			select.Column(Column.Parameter(period.Id)).As("PeriodId").Column(Column.Parameter(column.Id)).As("ColumnId");
			ForecastObjectValueAddFromSelectOperation.BulkAddRecords(ForecastSheet, select);
		}

		private void AddEsqFilters(ColumnSettingsData settings, EntitySchemaQuery esq, Period period, string columnPath) {
			AddSettingsFilter(settings, esq);
			AddPeriodFilter(period, settings.PeriodColumnName, esq);
			AddEntitiesFilter(columnPath, esq);
		}

		private void DeleteForecastObjValueRecords(IEnumerable<ForecastColumn> columns) {
			var delete = new Delete(UserConnection).From("ForecastObjValueRecord").Where("ColumnId")
				.In(Column.Parameters(columns.Select(c => c.Id)));
			delete.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates forecast object value column's values.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		/// <returns>
		/// Parameters with calculated cells.
		/// </returns>
		public ForecastCalcParams Calculate(ForecastCalcParams parameters) {
			InitData(parameters);
			var objectValueColumns = GetObjectValueColumns();
			List<Cell> cells = new List<Cell>();
			if (objectValueColumns.IsNotEmpty()) {
				CellRepository.DeleteCells(ForecastSheet, Periods, objectValueColumns);
				DeleteForecastObjValueRecords(objectValueColumns);
			}
			_log.Info($"Forecast object value calculation. " +
				$"Columns to count: {objectValueColumns.Count()}");
			foreach (ForecastColumn column in objectValueColumns) {
				var settings = ColumnSettingsMapper.GetForecastColumnSettingsData(UserConnection, column);
				if (settings == null) {
					_log.Info($"Settings for forecast {ForecastSheet.Name} - {ForecastSheet.Id} " +
						$"column {column.Name} - {column.Id} does not exists");
					continue;
				}
				_log.Info($"Forecast object value calculation. " +
					$"Periods to count: {Periods.Count()}");
				foreach (Period period in Periods) {
					var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, settings.SourceEntityName);
					esq.IgnoreDisplayValues = true;
					string columnPath = GetEntityInCellColumnPath(settings);
					var refColumnName = esq.AddColumn(settings.ReferenceColumnName);
					var rowIdColumnName = esq.AddColumn($"{columnPath}.Row");
					var valueColumn = esq.AddColumn(esq.CreateAggregationFunction(
						ForecastUtilities.GetCalcFunction(settings.FuncCode), settings.FuncColumnName));
					AddEsqFilters(settings, esq, period, columnPath);
					List<Cell> periodCells = new List<Cell>();
					Select select = esq.GetSelectQuery(UserConnection);
					select.ExecuteReader((reader) => {
						decimal value = reader.GetColumnValue<decimal>(valueColumn.ValueQueryAlias);
						value = CalcValue(settings, value);
						periodCells.Add(new Cell {
							Value = value,
							ColumnId = column.Id,
							EntityId = reader.GetColumnValue<Guid>(refColumnName.ValueQueryAlias),
							RowId = reader.GetColumnValue<Guid>(rowIdColumnName.ValueQueryAlias),
							PeriodId = period.Id
						});
					});
					if (periodCells.Any()) {
						cells.AddRange(periodCells);
						_log.Info($"Forecast object value calculation. " +
							$"Has {periodCells.Count()} cells data for period {period.Name}");
					}
					if (ForecastDrilldownEnabled) {
						InsertObjectValueRecords(settings, columnPath, period, column);
					}
				}
			}
			SaveCells(cells);
			parameters.Cells.AddRange(cells);
			return parameters;
		}

		#endregion

	}

	#endregion

}

