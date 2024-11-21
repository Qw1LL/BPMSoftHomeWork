namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration;
	using Consts = BPMSoft.Configuration.ForecastObjectValueRecordConstants;

	/// <summary>
	/// Provides methods to create and get the forecast object value records.
	/// </summary>
	[DefaultBinding(typeof(IForecastObjectValueAddFromSelectOperation))]
	[DefaultBinding(typeof(IForecastObjectValueGetOperation), Name = "Actual")]
	public class ForecastObjectValueRepository : ISnapshot, IForecastObjectValueAddFromSelectOperation, IForecastObjectValueGetOperation
	{


		#region Constructors: Public

		public ForecastObjectValueRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		private Sheet Sheet { get; set; }

		private FilterConfig FilterConfig { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// The forecast snapshot data.
		/// </summary>
		public ForecastSnapshotData SnapshotData { get; set; }

		#endregion

		#region Methods: Private

		private List<ObjectValueRecord> GetObjectValueRecordsByRecords() {
			var select = GetObjectValueRecordsQuery();
			return GetObjectValueRecords(select);
		}

		private void AddFuncColumnToSelect(Select select) {
			var calcFunction = ForecastUtilities.GetCalcFunction(FilterConfig.ColumnSettings.FuncCode);
			if (calcFunction == AggregationTypeStrict.Count) {
				select.Column(Column.Const(1)).As(Consts.FuncColumnNameAlias);
			} else {
				AddAggregateColumnToSelect(select);
			}
		}

		private void AddAggregateColumnToSelect(Select select) {
			var selectWithAggregateColumn = GetSelectWithAggregateColumn();
			selectWithAggregateColumn.Where(FilterConfig.ColumnSettings.SourceEntityName, "Id")
				.IsEqual(Consts.ForecastCellEntitySchemaAlias, "Id");
			select.Column(selectWithAggregateColumn).As(Consts.FuncColumnNameAlias);
		}

		private Select GetSelectWithAggregateColumn() {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(FilterConfig.ColumnSettings.SourceEntityName);
			AggregationTypeStrict aggregationTypeStrict = ForecastUtilities.GetCalcFunction(FilterConfig.ColumnSettings.FuncCode);
			EntitySchemaQuery esq = new EntitySchemaQuery(entitySchema);
			EntitySchemaQuery subQuery;
			esq.AddColumn(FilterConfig.ColumnSettings.FuncColumnName, aggregationTypeStrict, out subQuery);
			return esq.GetSelectQuery(UserConnection);
		}

		private List<ObjectValueRecord> GetObjectValueRecords(Select select) {
			var records = new List<ObjectValueRecord>();
			var displayColumnName = GetSchemaPrimaryDisplayColumn();
			select.ExecuteReader(reader => {
				records.Add(CreateObjectValueRecord(reader, displayColumnName));
			});
			return records;
		}

		private ObjectValueRecord CreateObjectValueRecord(IDataReader reader, string displayColumnName) {
			var record = new ObjectValueRecord {
				EntityId = reader.GetColumnValue<Guid>(Consts.EntityIdColumnName),
				RefEntityId = reader.GetColumnValue<Guid>(Consts.RefEntityColumnName),
				PeriodId = reader.GetColumnValue<Guid>(Consts.PeriodColumnName),
				ColumnId = reader.GetColumnValue<Guid>(Consts.ColumnColumnName),
				Value = reader.GetColumnValue<decimal>(Consts.FuncColumnNameAlias),
				DisplayValue = displayColumnName != null
					? reader.GetColumnValue<string>(displayColumnName)
					: string.Empty
			};
			return record;
		}

		private Select AddColumns(Select select) {
			var displayColumnName = GetSchemaPrimaryDisplayColumn();
			select
				.Column(Consts.ForecastObjValueRecordSchemaAlias, Consts.EntityIdColumnName)
				.Column(Consts.ForecastObjValueRecordSchemaAlias, Consts.PeriodColumnName)
				.Column(Consts.ForecastObjValueRecordSchemaAlias, Consts.RefEntityColumnName)
				.Column(Consts.ForecastObjValueRecordSchemaAlias, Consts.ColumnColumnName);
			if (displayColumnName != null) {
				select.Column(Consts.ForecastCellEntitySchemaAlias, displayColumnName);
			}
			return select;
		}

		private Select GetObjectValueRecordsQuery() {
			var select = new Select(UserConnection);
			AddColumns(select)
				.From(Consts.ForecastObjValueRecordSchemaName).As(Consts.ForecastObjValueRecordSchemaAlias)
				.InnerJoin(FilterConfig.ColumnSettings.SourceEntityName).As(Consts.ForecastCellEntitySchemaAlias)
					.On(Consts.ForecastObjValueRecordSchemaAlias, Consts.EntityIdColumnName)
						.IsEqual(Consts.ForecastCellEntitySchemaAlias, "Id")
					.Where(Consts.ForecastObjValueRecordSchemaAlias, Consts.RefEntityColumnName)
						.In(Column.Parameters(FilterConfig.RecordIds))
					.And(Consts.ForecastObjValueRecordSchemaAlias, Consts.ColumnColumnName).IsEqual(Column.Parameter(FilterConfig.ColumnId));
			if (!FilterConfig.PeriodIds.IsNullOrEmpty()) {
				select.And(Consts.ForecastObjValueRecordSchemaAlias, Consts.PeriodColumnName)
					.In(Column.Parameters(FilterConfig.PeriodIds));
			}
			AddFuncColumnToSelect(select);
			return select;
		}

		private string GetSchemaPrimaryDisplayColumn() {
			var schemaInstance = UserConnection.EntitySchemaManager.FindInstanceByName(FilterConfig.ColumnSettings.SourceEntityName);
			return schemaInstance.PrimaryDisplayColumn?.Name;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		///  Execute add records to ForecastObjValueRecord.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="select">Select, with all required columns.
		///  Columns should be presented with the next names and order: EntityId, SheetId, RefEntityId, PeriodId, ColumnId.
		/// </param>
		public void BulkAddRecords(Sheet sheet, Select select) {
			var insert = new InsertSelect(UserConnection).Into("ForecastObjValueRecord")
				.Set("EntityId", "RefEntityId", "PeriodId", "ColumnId").FromSelect(select);
			insert.Execute();
		}

		/// <summary>
		/// Get forecast object value records 
		/// </summary>
		/// <param name="sheet">Sheet</param>
		/// <param name="filterConfig">Filter config</param>
		/// <returns>List enumerable of records</returns>
		public IEnumerable<ObjectValueRecord> GetRecords(Sheet sheet, FilterConfig filterConfig) {
			sheet.CheckArgumentNull(nameof(sheet));
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			Sheet = sheet;
			FilterConfig = filterConfig;
			return GetObjectValueRecordsByRecords();
		}

		#endregion

	}
}
