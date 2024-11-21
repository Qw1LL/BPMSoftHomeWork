namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Web.Common;

	#region Interface: IEntityInForecastCellRepository

	/// <summary>
	/// Provides methods to get information from forecast cells.
	/// </summary>
	public interface IEntityInForecastCellRepository
	{
		/// <summary>
		/// Gets cells with pagination options.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet <see cref="Sheet" />.</param>
		/// <param name="periodIds">Collection of periods.</param>
		/// <param name="pageableConfig">Pageable configuration <see cref="PageableConfig" />.</param>
		/// <returns>
		/// Collection of cells <see cref="Cell" />
		/// </returns>
		[Obsolete("7.15 | Method is deprecated. Use GetCells(Sheet forecastSheet, " +
			"IEnumerable<Guid> periodIds, IEnumerable<Guid> recordIds)")]
		IEnumerable<Cell> GetCells(Sheet forecastSheet, IEnumerable<Guid> periodIds,
			PageableConfig pageableConfig);

		/// <summary>
		/// Gets cells by records.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet <see cref="Sheet" />.</param>
		/// <param name="periodIds">Collection of periods.</param>
		/// <param name="recordIds">Records of sheet.</param>
		/// <returns>
		/// Collection of cells <see cref="Cell" />
		/// </returns>
		IEnumerable<Cell> GetCellsByRecords(Sheet forecastSheet, IEnumerable<Guid> periodIds, IEnumerable<Guid> recordIds);

		/// <summary>
		/// Gets cells.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet <see cref="Sheet" />.</param>
		/// <param name="periodIds">Collection of periods.</param>
		/// <returns>
		/// Collection of cells <see cref="Cell" />
		/// </returns>
		IEnumerable<Cell> GetCells(Sheet forecastSheet, IEnumerable<Guid> periodIds);

		/// <summary>
		/// Saves the cell.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet.</param>
		/// <param name="recordId">The record identifier.</param>
		/// <param name="indicatorId">The indicator identifier.</param>
		/// <param name="periodId">The period identifier.</param>
		/// <param name="value">The period identifier.</param>
		void SaveCell(Sheet forecastSheet, Guid recordId, Guid indicatorId, Guid periodId, ValueInfo value);
	}

	/// <summary>
	/// Information of value.
	/// </summary>
	public class ValueInfo
	{
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public decimal Value { get; set; }
	}

	#endregion

	#region Interface: IForecastCellRepository

	/// <summary>
	/// Extends forecast cell repository methods.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ForecastV2.IEntityInForecastCellRepository" />
	public interface IForecastCellRepository : IEntityInForecastCellRepository, IInsertForecastCellRepository
	{
		/// <summary>
		/// Saves the cell.
		/// </summary>
		/// <param name="forecastSheet">Forecast sheet info</param>
		/// <param name="cell">Cell info</param>
		void SaveCell(Sheet forecastSheet, Cell cell);

		/// <summary>
		/// Gets the entity cells.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet.</param>
		/// <returns></returns>
		IEnumerable<Cell> GetEntityCells(Sheet forecastSheet);

		/// <summary>
		/// Gets the entity cells.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet.</param>
		/// <param name="periodIds">The periods.</param>
		/// <param name="columns">The columns.</param>
		/// <returns></returns>
		IEnumerable<Cell> GetCells(Sheet forecastSheet, IEnumerable<Period> periodIds, IEnumerable<ForecastColumn> columns);

		/// <summary>
		/// Deletes entity cells.
		/// </summary>
		/// <param name="forecastSheet">The forecast sheet.</param>
		/// <param name="periods">Periods.</param>
		/// <param name="columns">Forecast columns.</param>
		/// <returns></returns>
		void DeleteCells(Sheet forecastSheet, IEnumerable<Period> periods, IEnumerable<ForecastColumn> columns);
	}
	
	#endregion
	
	#region Interface: IGetForecastCellRepository
	
	/// <summary>
	/// Provides get forecast cells methods.
	/// </summary>
	public interface IGetForecastCellRepository
	{
		/// <summary>
		/// Gets entity forecast cells by filter configuration.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="filterConfig">Filter configuration.</param>
		/// <returns></returns>
		IEnumerable<Cell> GetCells(Sheet sheet, FilterConfig filterConfig);
	}
	
	#endregion

	#region Interface: IInsertForecastCellRepository
	
	/// <summary>
	/// Provides get forecast cells methods.
	/// </summary>
	public interface IInsertForecastCellRepository
	{
		/// <summary>
		/// Insert the cells.
		/// </summary>
		/// <param name="forecastSheet">Forecast sheet info</param>
		/// <param name="cells">Cells info</param>
		void InsertCells(Sheet forecastSheet, IEnumerable<Cell> cells);
	}

	#endregion

	#region Class: ForecastAppEventListener

	/// <summary>
	/// Registers class bindings.
	/// </summary>
	/// <seealso cref="BPMSoft.Web.Common.AppEventListenerBase" />
	public class ForecastAppEventListener : AppEventListenerBase
	{
		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			ClassFactory.Bind<IForecastCellRepository, EntityInForecastCellRepository>();
		}

		#endregion
	}

	#endregion

	#region Class: EntityInForecastCellRepository

	/// <summary>
	/// Implements methods to get information from forecast cells.
	/// </summary>
	/// <seealso cref="IEntityInForecastCellRepository" />
	[DefaultBinding(typeof(IEntityInForecastCellRepository))]
	[DefaultBinding(typeof(IGetForecastCellRepository), Name = "Actual")]
	public class EntityInForecastCellRepository : IForecastCellRepository, IGetForecastCellRepository
	{

		#region Constants: Private

		private const string SheetColumnName = "Sheet";
		private const string IndicatorColumnName = "Indicator";
		private const string PeriodColumnName = "Period";
		private const string ValueColumnName = "Value";
		private const string RowColumnName = "Row";
		private const string ForecastRow = "ForecastRow";
		private const string ForecastColumnName = "ForecastColumn";
		private const int MaxParametersCountPerQueryChunk = 1000;
		private const int DefaultMaxRowsCount = 1000;

		#endregion

		#region Constructors: Public

		public EntityInForecastCellRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<EntityInForecastCellRepository>();

		#endregion

		#region Properties: Protected

		private string _entityColumnName;
		protected string EntityColumnName {
			get {
				return _entityColumnName.IsNullOrEmpty()
					? (_entityColumnName = GetEntityColumnName())
					: _entityColumnName;
			}
			set { _entityColumnName = value; }
		}

		protected UserConnection UserConnection { get; }

		private Sheet _forecastSheet;
		protected Sheet ForecastSheet {
			get { return _forecastSheet; }
			set {
				value.CheckArgumentNull(nameof(ForecastSheet));
				_forecastSheet = value;
			}
		}

		protected RightsHelper RightsHelper {
			get {
				return ClassFactory.Get<RightsHelper>(new ConstructorArgument("userConnection", UserConnection));
			}
		}

		protected bool ForecastUIV2Enabled => UserConnection.GetIsFeatureEnabled("ForecastUIV2");

		#endregion

		#region Methods: Private

		private string GetSchemaName(Guid uId) {
			return UserConnection.EntitySchemaManager.FindInstanceByUId(uId).Name;
		}

		private string GetEntityColumnName() {
			return ForecastSheet.GetEntityReferenceColumn(UserConnection)?.Name;
		}

		private Cell CreateCell(Entity entity) {
			return new Cell {
				EntityId = entity.GetTypedColumnValue<Guid>($"{EntityColumnName}Id"),
				IndicatorId = entity.GetTypedColumnValue<Guid>($"{IndicatorColumnName}Id"),
				ColumnId = entity.GetTypedColumnValue<Guid>($"{ForecastColumnName}Id"),
				PeriodId = entity.GetTypedColumnValue<Guid>($"{PeriodColumnName}Id"),
				Value = entity.GetTypedColumnValue<decimal>(ValueColumnName),
				RowId = entity.GetTypedColumnValue<Guid>($"{RowColumnName}Id")
			};
		}

		private IEnumerable<Cell> FillCells(EntityCollection entities) {
			List<Cell> cells = new List<Cell>();
			foreach (Entity entity in entities) {
				cells.Add(CreateCell(entity));
			}
			return cells;
		}

		private EntitySchemaQuery GetEsq() {
			string schemaName = GetSchemaName(ForecastSheet.ForecastEntityInCellUId);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.PrimaryQueryColumn.OrderDirection = OrderDirection.Ascending;
			return esq;
		}

		private Entity GetEntity() {
			EntitySchema schema = UserConnection.EntitySchemaManager
				.FindInstanceByUId(ForecastSheet.ForecastEntityInCellUId);
			Entity entity = schema.CreateEntity(UserConnection);
			return entity;
		}

		private void ObsoleteValidateArguments(Guid recordId, Guid indicatorId,
				Guid periodId, ValueInfo value) {
			recordId.CheckArgumentEmpty(nameof(recordId));
			indicatorId.CheckArgumentEmpty(nameof(indicatorId));
			periodId.CheckArgumentEmpty(nameof(periodId));
			value.CheckArgumentNull(nameof(value));
		}

		private void ValidateArguments(Cell cell) {
			cell.CheckArgumentNull(nameof(cell));
			cell.EntityId.CheckArgumentEmpty(nameof(cell.EntityId));
			cell.ColumnId.CheckArgumentEmpty(nameof(cell.ColumnId));
			cell.PeriodId.CheckArgumentEmpty(nameof(cell.PeriodId));
		}

		private void ObsoleteInnerSaveCell(Guid recordId, Guid indicatorId, Guid periodId, ValueInfo value) {
			Entity entity = GetEntity();
			Dictionary<string, object> conditions = new Dictionary<string, object> {
					{PeriodColumnName, periodId},
					{IndicatorColumnName, indicatorId},
					{SheetColumnName, ForecastSheet.Id},
					{EntityColumnName, recordId}
				};
			if (!entity.FetchFromDB(conditions, false)) {
				Guid rowId = GetRowId(entity.SchemaName, recordId, ForecastSheet.Id);
				if (!RightsHelper.GetCanEditSchemaRecordRight(ForecastRow, rowId)) {
					throw new SecurityException(string.Format(
						new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Insert"),
						entity.SchemaName));
				}
				entity.SetDefColumnValues();
				entity.SetColumnValue($"{PeriodColumnName}Id", periodId);
				entity.SetColumnValue($"{IndicatorColumnName}Id", indicatorId);
				entity.SetColumnValue($"{SheetColumnName}Id", ForecastSheet.Id);
				entity.SetColumnValue($"{EntityColumnName}Id", recordId);
				entity.SetColumnValue($"{RowColumnName}Id", rowId);
			}
			entity.SetColumnValue(ValueColumnName, value.Value);
			entity.Save();
		}

		private void InnerSaveCell(Cell cell) {
			Entity entity = GetEntity();
			Dictionary<string, object> conditions = new Dictionary<string, object> {
					{PeriodColumnName, cell.PeriodId},
					{ForecastColumnName, cell.ColumnId},
					{SheetColumnName, ForecastSheet.Id},
					{EntityColumnName, cell.EntityId}
				};
			if (!entity.FetchFromDB(conditions, false)) {
				Guid rowId = GetRowId(entity.SchemaName, cell.EntityId, ForecastSheet.Id);
				if (!RightsHelper.GetCanEditSchemaRecordRight(ForecastRow, rowId)) {
					throw new SecurityException(string.Format(
						new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Insert"),
						entity.SchemaName));
				}
				entity.SetDefColumnValues();
				entity.SetColumnValue($"{PeriodColumnName}Id", cell.PeriodId);
				entity.SetColumnValue($"{ForecastColumnName}Id", cell.ColumnId);
				entity.SetColumnValue($"{SheetColumnName}Id", ForecastSheet.Id);
				entity.SetColumnValue($"{EntityColumnName}Id", cell.EntityId);
				entity.SetColumnValue($"{RowColumnName}Id", rowId);
			}
			entity.SetColumnValue(ValueColumnName, cell.Value);
			entity.Save();
		}
		private Guid GetRowId(string schemaName, Guid recordId, Guid sheetId) {
			var select = new Select(UserConnection).Top(1)
					.Column($"{RowColumnName}Id")
				.From(schemaName)
					.Where($"{EntityColumnName}Id").IsEqual(Column.Parameter(recordId))
					.And($"{SheetColumnName}Id").IsEqual(Column.Parameter(sheetId)) as Select;
			var rowId = select.ExecuteScalar<Guid>();
			rowId.CheckArgumentEmpty(nameof(rowId));
			return rowId;
		}

		private IEnumerable<Cell> GetCells(EntitySchemaQuery esq) {
			int  maxRowCount = UserConnection.AppConnection.MaxEntityRowCount > 0 
				? UserConnection.AppConnection.MaxEntityRowCount
				: DefaultMaxRowsCount;
			bool useOffsetFetchPaging = GlobalAppSettings.UseOffsetFetchPaging;
			esq.UseOffsetFetchPaging = useOffsetFetchPaging;
			EntitySchemaQueryOptions pageOptions = new EntitySchemaQueryOptions {
				RowsOffset = 0,
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = maxRowCount,
				PageableConditionValues = new Dictionary<string, object>()
			};
			EntityCollection entities = new EntityCollection(UserConnection, esq.RootSchema.Name);
			EntityCollection entityCollection = new EntityCollection(UserConnection, esq.RootSchema.Name);
			int pageOffset = 0;
			int rowCount = maxRowCount;
			while (rowCount == maxRowCount) {
				if (useOffsetFetchPaging) {
					pageOptions.RowsOffset = pageOffset;
					esq.ResetSelectQuery();
				}
				entityCollection = esq.GetEntityCollection(UserConnection, pageOptions);
				pageOptions.PageableDirection = PageableSelectDirection.Next;
				entities.AddRange(entityCollection);
				rowCount = entityCollection.Count;
				pageOffset += rowCount;
			};
			return FillCells(entities);
		}

		private EntitySchemaQuery GetCellsESQ(Sheet forecastSheet, IEnumerable<Guid> periodIds) {
			ForecastSheet = forecastSheet;
			EntitySchemaQuery esq = GetEsq();
			AddColumns(esq);
			AddFilters(esq, periodIds);
			return esq;
		}

		private void ChunkSave(IEnumerable<Cell> cells) {
			if (cells.IsNullOrEmpty()) {
				return;
			}
			string schemaName = UserConnection.EntitySchemaManager
				.FindInstanceByUId(ForecastSheet.ForecastEntityInCellUId).Name;
			cells = GetAllowedCellToInsert(cells);
			IEnumerable<IEnumerable<Cell>> chunks = GetChunks(cells);
			foreach (var chunkCells in chunks) {
				MultiInsertCell(schemaName, chunkCells);
			}
		}

		private IEnumerable<Cell> GetAllowedCellToInsert(IEnumerable<Cell> cells) {
			return cells
				.Where(cell => RightsHelper.GetCanEditSchemaRecordRight(ForecastRow, cell.RowId));
		}

		protected void MultiInsertCell(string schemaName, IEnumerable<Cell> cells) {
			var insert = new Insert(UserConnection).Into(schemaName);
			foreach (var cell in cells) {
				if (!SafeValidateArguments(cell)) {
					continue;
				}

				if (ForecastSheet.CheckForecastValueExceedMaxSize(UserConnection, cell.Value)) {
					LogForecastValueExceedMaxSizeWarning(cell);
					cell.Value = 0;
				}
				insert.Values()
					.Set($"{PeriodColumnName}Id", Column.Parameter(cell.PeriodId))
					.Set($"{ForecastColumnName}Id", Column.Parameter(cell.ColumnId))
					.Set($"{SheetColumnName}Id", Column.Parameter(ForecastSheet.Id))
					.Set($"{EntityColumnName}Id", Column.Parameter(cell.EntityId))
					.Set($"{RowColumnName}Id", Column.Parameter(cell.RowId))
					.Set(ValueColumnName, Column.Parameter(cell.Value));
			}
			if (insert.ColumnValues.IsNotEmpty()) {
				insert.Execute();
			}
		}

		private bool SafeValidateArguments(Cell cell) {
			try {
				ValidateArguments(cell);
				cell.RowId.CheckArgumentEmpty(nameof(cell.RowId));
			} catch (Exception ex) {
				LogValidateArgumentException(cell, ex);
				return false;
			}
			return true;
		}

		private void LogForecastValueExceedMaxSizeWarning(Cell cell) {
			_log.Warn($"Forecast cell (cell value: {cell.Value}, cell entity id: {cell.EntityId}, " +
				$"period id: {cell.PeriodId}, column id: {cell.ColumnId}, " +
				$"forecast sheet id: {ForecastSheet.Id}, forecast sheet name: {ForecastSheet.Name}) " +
				"exceeds size limit for current SQL data type");
		}

		private void LogValidateArgumentException(Cell cell, Exception ex) {
			_log.Error($"Error while cell validation with id \"{cell?.Id.ToString()}\", " +
				$"entity id \"{cell?.EntityId.ToString()}\", column id \"{cell?.ColumnId.ToString()}\" ," +
				$" period id \"{cell?.PeriodId.ToString()}\", row id \"{cell?.RowId.ToString()}\"", ex);
		}

		private IEnumerable<IEnumerable<Cell>> GetChunks(IEnumerable<Cell> cells) {
			var insertColumnsCount = 6;
			double maxParamsPerChunk = (double)MaxParametersCountPerQueryChunk / insertColumnsCount;
			int chunksCount = (int)Math.Ceiling(cells.Count() / maxParamsPerChunk);
			var chunks = cells.SplitOnParts(chunksCount);
			return chunks;
		}

		#endregion

		#region Methods: Protected

		protected virtual void AddColumns(EntitySchemaQuery esq) {
			esq.IgnoreDisplayValues = true;
			esq.AddColumn(SheetColumnName);
			esq.AddColumn(IndicatorColumnName);
			esq.AddColumn(ForecastColumnName);
			esq.AddColumn(PeriodColumnName);
			esq.AddColumn(EntityColumnName);
			esq.AddColumn(ValueColumnName);
			esq.AddColumn(RowColumnName);
		}

		protected virtual void AddFilters(EntitySchemaQuery esq, IEnumerable<Guid> periodIds) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				SheetColumnName, ForecastSheet.Id));
			if (periodIds.IsNullOrEmpty()) {
				esq.Filters.Add(esq.CreateIsNotNullFilter(PeriodColumnName));
			} else {
				var filterGroup = new EntitySchemaQueryFilterCollection(esq);
				filterGroup.LogicalOperation = LogicalOperationStrict.Or;
				filterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					PeriodColumnName, periodIds.Cast<object>()));
				filterGroup.Add(esq.CreateIsNullFilter(PeriodColumnName));
				esq.Filters.Add(filterGroup);
			}
		}

		protected virtual void AddEntityCellsFilters(EntitySchemaQuery esq) {
			esq.Filters.LogicalOperation = LogicalOperationStrict.And;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				SheetColumnName, ForecastSheet.Id));
			esq.Filters.Add(esq.CreateIsNullFilter(PeriodColumnName));
			esq.Filters.Add(esq.CreateIsNullFilter(ForecastColumnName));
		}

		protected virtual void AddColumnFilters(EntitySchemaQuery esq, IEnumerable<Guid> columnIds) {
			if (columnIds.IsNullOrEmpty()) {
				return;
			}
			var filterGroup = new EntitySchemaQueryFilterCollection(esq);
			filterGroup.LogicalOperation = LogicalOperationStrict.Or;
			filterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				ForecastColumnName, columnIds.Cast<object>()));
			filterGroup.Add(esq.CreateIsNullFilter(ForecastColumnName));
			esq.Filters.Add(filterGroup);
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public IEnumerable<Cell> GetCells(Sheet forecastSheet, IEnumerable<Guid> periodIds) {
			var esq = GetCellsESQ(forecastSheet, periodIds);
			return GetCells(esq);
		}

		///<inheritdoc />
		public IEnumerable<Cell> GetCells(Sheet forecastSheet, IEnumerable<Guid> periodIds,
				PageableConfig pageableConfig) {
			return new List<Cell>();
		}

		///<inheritdoc />
		public IEnumerable<Cell> GetCellsByRecords(Sheet forecastSheet, IEnumerable<Guid> periodIds,
				IEnumerable<Guid> recordIds) {
			forecastSheet.CheckArgumentNull(nameof(forecastSheet));
			recordIds.CheckArgumentNullOrEmpty(nameof(recordIds));
			var esq = GetCellsESQ(forecastSheet, periodIds);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				EntityColumnName, recordIds.Cast<object>()));
			return GetCells(esq);
		}

		///<inheritdoc />
		public IEnumerable<Cell> GetCells(Sheet forecastSheet, IEnumerable<Period> periodIds, IEnumerable<ForecastColumn> columns) {
			periodIds.CheckArgumentNullOrEmpty(nameof(periodIds));
			ForecastSheet = forecastSheet;
			EntitySchemaQuery esq = GetEsq();
			AddColumns(esq);
			AddFilters(esq, periodIds.Select(a => a.Id));
			AddColumnFilters(esq, columns.Select(a => a.Id));
			return GetCells(esq);
		}

		///<inheritdoc />
		public void SaveCell(Sheet forecastSheet, Guid recordId, Guid indicatorId, Guid periodId, ValueInfo value) {
			ForecastSheet = forecastSheet;
			ObsoleteValidateArguments(recordId, indicatorId, periodId, value);
			ObsoleteInnerSaveCell(recordId, indicatorId, periodId, value);
		}

		///<inheritdoc />
		public void SaveCell(Sheet forecastSheet, Cell cell) {
			ForecastSheet = forecastSheet;
			ValidateArguments(cell);
			InnerSaveCell(cell);
		}

		///<inheritdoc />
		public void InsertCells(Sheet forecastSheet, IEnumerable<Cell> cells) {
			ForecastSheet = forecastSheet;
			ChunkSave(cells);
		}

		///<inheritdoc />
		public IEnumerable<Cell> GetEntityCells(Sheet forecastSheet) {
			ForecastSheet = forecastSheet;
			EntitySchemaQuery esq = GetEsq();
			esq.AddColumn(EntityColumnName);
			AddEntityCellsFilters(esq);
			List<Cell> cells = new List<Cell>();
			esq.GetEntityCollection(UserConnection).ForEach(item =>
				cells.Add(new Cell {
					EntityId = item.GetTypedColumnValue<Guid>($"{EntityColumnName}Id")
				})
			);
			return cells;
		}

		///<inheritdoc />
		public void DeleteCells(Sheet forecastSheet, IEnumerable<Period> periods,
				IEnumerable<ForecastColumn> columns) {
			forecastSheet.CheckArgumentNull(nameof(forecastSheet));
			forecastSheet.Id.CheckArgumentEmpty(nameof(forecastSheet.Id));
			periods.CheckArgumentNull(nameof(periods));
			columns.CheckArgumentNull(nameof(columns));
			var schemaName = UserConnection.EntitySchemaManager
				.GetItemByUId(forecastSheet.ForecastEntityInCellUId).Name;
			var deleteQuery = new Delete(UserConnection)
				.From(schemaName)
				.Where("SheetId").IsEqual(Column.Parameter(forecastSheet.Id));
			if (columns.IsNotEmpty()) {
				deleteQuery
					.And("ForecastColumnId").In(Column.Parameters(columns.Select(c => c.Id)));
			}
			if (periods.IsNotEmpty()) {
				deleteQuery
					.And("PeriodId").In(Column.Parameters(periods.Select(p => p.Id)));
			}
			deleteQuery.Execute();
		}
		
		///<inheritdoc />
		public IEnumerable<Cell> GetCells(Sheet sheet, FilterConfig filterConfig) {
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			return GetCellsByRecords(sheet, filterConfig.PeriodIds, filterConfig.RecordIds);
		}

		#endregion
		
	}


	#endregion

}

