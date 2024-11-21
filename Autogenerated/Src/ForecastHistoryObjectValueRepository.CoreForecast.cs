namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using Consts = BPMSoft.Configuration.ForecastObjectValueRecordConstants;

	#region Class: ForecastHistoryObjectValueRepository

	/// <summary>
	/// Forecast history object value record repository.
	/// </summary>
	[DefaultBinding(typeof(IForecastObjectValueBulkAddOperation), Name = "History")]
	[DefaultBinding(typeof(IForecastObjectValueGetOperation), Name = "History")]
	public class ForecastHistoryObjectValueRepository : ISnapshot, IForecastObjectValueBulkAddOperation,
		IForecastObjectValueGetOperation
	{

		#region Constructors: Public

		public ForecastHistoryObjectValueRepository(UserConnection userConnection, ForecastSnapshotData snapshotData) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			snapshotData.CheckArgumentNull(nameof(snapshotData));
			UserConnection = userConnection;
			SnapshotData = snapshotData;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// The forecast snapshot data.
		/// </summary>
		public ForecastSnapshotData SnapshotData { get; set; }

		#endregion

		#region Methods: Private

		private List<ObjectValueRecord> GetHistoryObjectValueRecords(FilterConfig filterConfig) {
			var select = GetObjectValueRecordsQuery(filterConfig);
			return GetObjectValueRecords(select);
		}

		private List<ObjectValueRecord> GetObjectValueRecords(Select select) {
			var records = new List<ObjectValueRecord>();
			select.ExecuteReader(reader => {
				records.Add(CreateObjectValueRecord(reader));
			});
			return records;
		}

		private ObjectValueRecord CreateObjectValueRecord(IDataReader reader) {
			return new ObjectValueRecord {
				Id = reader.GetColumnValue<Guid>("Id"),
				EntityId = reader.GetColumnValue<Guid>(Consts.EntityIdColumnName),
				DisplayValue = reader.GetColumnValue<string>(Consts.DisplayValueColumnName),
				RefEntityId = reader.GetColumnValue<Guid>(Consts.RefEntityColumnName),
				PeriodId = reader.GetColumnValue<Guid>(Consts.PeriodColumnName),
				ColumnId = reader.GetColumnValue<Guid>(Consts.ColumnColumnName),
				Value = reader.GetColumnValue<decimal>(Consts.ValueColumnName)
			};
		}

		private Select GetObjectValueRecordsQuery(FilterConfig filterConfig) {
			string historyObjectValueRecordAlias = "ho_fhc";
			string snapshotAlias = "s_fs";
			string historyObjectValueRecordSubQueryAlias = "cs_sqc";
			var select = new Select(UserConnection)
					.Column(historyObjectValueRecordAlias, "Id").As("Id")
					.Column(historyObjectValueRecordAlias, Consts.DisplayValueColumnName).As(Consts.DisplayValueColumnName)
					.Column(historyObjectValueRecordAlias, Consts.ValueColumnName).As(Consts.ValueColumnName)
					.Column(historyObjectValueRecordAlias, Consts.EntityIdColumnName)
					.Column(historyObjectValueRecordAlias, Consts.PeriodColumnName)
					.Column(historyObjectValueRecordAlias, Consts.RefEntityColumnName)
					.Column(historyObjectValueRecordAlias, Consts.ColumnColumnName)
					.Column(historyObjectValueRecordAlias, Consts.SnapshotColumnName)
					.From(Consts.ForecastHistoryObjValueRecordSchemaName).As(historyObjectValueRecordAlias)
					.InnerJoin(ForecastHistoryCellConstants.SnapshotSchemaName).As(snapshotAlias).On(snapshotAlias, "Id")
						.IsEqual(historyObjectValueRecordAlias, Consts.SnapshotColumnName)
					.InnerJoin(CreateMaxDateSnapshotSelect(filterConfig)).As(historyObjectValueRecordSubQueryAlias)
						.On(historyObjectValueRecordSubQueryAlias, Consts.EntityIdColumnName).IsEqual(historyObjectValueRecordAlias, Consts.EntityIdColumnName)
						.And(historyObjectValueRecordSubQueryAlias, Consts.ColumnColumnName).IsEqual(historyObjectValueRecordAlias, Consts.ColumnColumnName)
						.And(historyObjectValueRecordSubQueryAlias, Consts.PeriodColumnName).IsEqual(historyObjectValueRecordAlias, Consts.PeriodColumnName)
						.And(snapshotAlias, "Date").IsEqual(historyObjectValueRecordSubQueryAlias, "Date")
					.Where()
						.OpenBlock(historyObjectValueRecordAlias, Consts.DeletedOnColumnName)
						.IsGreater(Column.Parameter(SnapshotData.Date))
							.Or(historyObjectValueRecordAlias, Consts.DeletedOnColumnName).IsNull()
						.CloseBlock()
				as Select;
			select = GetPageableSelect(select, filterConfig);
			if (GlobalAppSettings.UseOffsetFetchPaging || filterConfig.PagingConfig == null) {
				select = (filterConfig.SortConfig != null
					? select.OrderBy(filterConfig.SortConfig.Direction, filterConfig.SortConfig.ColumnPath)
					: select.OrderByAsc(Consts.DisplayValueColumnName)) as Select;
			}
			return select;
		}

		private Select GetPageableSelect(Select select, FilterConfig filterConfig) {
			if (filterConfig.PagingConfig == null) {
				return select;
			}
			PagingConfig pagingConfig = filterConfig.PagingConfig;
			if (GlobalAppSettings.UseOffsetFetchPaging) {
				return select.OffsetFetch(pagingConfig.Offset, pagingConfig.RowsCount);
			}
			QueryColumnExpression conditionColumn = filterConfig.SortConfig != null ? 
				select.Columns.GetByAlias(filterConfig.SortConfig.ColumnPath) : 
				select.Columns[0];
			var direction = PageableSelectDirection.First;
			var conditionValue = string.Empty;
			if (pagingConfig.LastValue.IsNotNullOrEmpty()) {
				direction = PageableSelectDirection.Next;
				conditionValue = pagingConfig.LastValue;
			}
			var options = new PageableSelectOptions(null, pagingConfig.RowsCount, direction);
			options.AddCondition(conditionColumn, 
				new QueryParameter("columnLastValue", conditionValue));
			Select pageableSelect = select.ToPageable(options);
			return pageableSelect.Top(pagingConfig.RowsCount);
		}

		private Select CreateMaxDateSnapshotSelect(FilterConfig filterConfig) {
			string snapshotAlias = "mds_fs";
			string historyObjectValueRecordAlias = "hmds_fhc";
			var select = new Select(UserConnection)
					.Column(historyObjectValueRecordAlias, Consts.EntityIdColumnName)
					.Column(historyObjectValueRecordAlias, Consts.ColumnColumnName)
					.Column(historyObjectValueRecordAlias, Consts.PeriodColumnName)
					.Column(historyObjectValueRecordAlias, Consts.RefEntityColumnName)
					.Column(Func.Max(snapshotAlias, "Date")).As("Date")
				.From(Consts.ForecastHistoryObjValueRecordSchemaName).As(historyObjectValueRecordAlias)
				.InnerJoin(Consts.ForecastSnapshotSchemaName).As(snapshotAlias).On(snapshotAlias, "Id")
					.IsEqual(historyObjectValueRecordAlias, Consts.SnapshotColumnName)
				.Where(snapshotAlias, "Date")
					.IsLessOrEqual(CreateSnapshotDateSelect(SnapshotData.SnapshotId))
				.And(historyObjectValueRecordAlias, Consts.ColumnColumnName).IsEqual(Column.Parameter(filterConfig.ColumnId))
				as Select;
			if (!filterConfig.RecordIds.IsNullOrEmpty()) {
				select.And(historyObjectValueRecordAlias, Consts.RefEntityColumnName)
					.In(Column.Parameters(filterConfig.RecordIds));
			}
			if (!filterConfig.PeriodIds.IsNullOrEmpty()) {
				select.And(historyObjectValueRecordAlias, Consts.PeriodColumnName)
					.In(Column.Parameters(filterConfig.PeriodIds));
			}
			select
				.GroupBy(historyObjectValueRecordAlias, Consts.EntityIdColumnName)
				.GroupBy(historyObjectValueRecordAlias, Consts.ColumnColumnName)
				.GroupBy(historyObjectValueRecordAlias, Consts.PeriodColumnName)
				.GroupBy(historyObjectValueRecordAlias, Consts.RefEntityColumnName);
			return select;
		}

		private Select CreateSnapshotDateSelect(Guid snapshotId) {
			string snapshotAlias = "sds_fs";
			return new Select(UserConnection)
				.Column(snapshotAlias, "Date")
				.From(Consts.ForecastSnapshotSchemaName).As(snapshotAlias)
				.Where(snapshotAlias, "Id").IsEqual(Column.Parameter(snapshotId)) as Select;
		}

		private void InternalUpdateHistoryRecords(IEnumerable<ObjectValueRecord> records) {
			foreach (var record in records) {
				var update = new Update(UserConnection, Consts.ForecastHistoryObjValueRecordSchemaName)
					.Set(Consts.DeletedOnColumnName, Column.Parameter(record.DeletedOn))
					.Where(Consts.EntityIdColumnName).IsEqual(Column.Parameter(record.EntityId)) as Update;
				update.Execute();
			}
		}

		private void InternalInsertHistoryRecords(ForecastSnapshotData snapshot, IEnumerable<ObjectValueRecord> records) {
			var insert = new Insert(UserConnection).Into(Consts.ForecastHistoryObjValueRecordSchemaName);
			foreach (var record in records) {
				insert.Values()
					.Set(Consts.SnapshotColumnName, Column.Parameter(snapshot.SnapshotId))
					.Set(Consts.DisplayValueColumnName, Column.Parameter(record.DisplayValue))
					.Set(Consts.RefEntityColumnName, Column.Parameter(record.RefEntityId))
					.Set(Consts.EntityIdColumnName, Column.Parameter(record.EntityId))
					.Set(Consts.PeriodColumnName, Column.Parameter(record.PeriodId))
					.Set(Consts.ColumnColumnName, Column.Parameter(record.ColumnId))
					.Set(Consts.ValueColumnName, Column.Parameter(record.Value));
			}
			if (insert.ColumnValues.IsNotEmpty()) {
				insert.Execute();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Add records to forecast history object value record.
		/// </summary>
		/// <param name="snapshot">Forecast snapshot</param>
		/// <param name="records">Records</param>
		public void AddRecords(ForecastSnapshotData snapshot, IEnumerable<ObjectValueRecord> records) {
			InternalInsertHistoryRecords(snapshot, records.Where(x => x.DeletedOn == default));
			InternalUpdateHistoryRecords(records.Where(x => x.DeletedOn != default));
		}

		/// <summary>
		/// Get forecast history object value records.
		/// </summary>
		/// <param name="sheet">Sheet</param>
		/// <param name="filterConfig">Filter config</param>
		/// <returns>Enumerable of records</returns>
		public IEnumerable<ObjectValueRecord> GetRecords(Sheet sheet, FilterConfig filterConfig) {
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			SnapshotData.CheckArgumentNull(nameof(SnapshotData));
			return GetHistoryObjectValueRecords(filterConfig);
		}

		#endregion

	}

	#endregion

}

