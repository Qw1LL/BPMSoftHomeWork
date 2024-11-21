namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastGroupHistorySummaryRepository

	/// <summary>
	/// Provides methods for forecast group history summary.
	/// </summary>
	[DefaultBinding(typeof(IForecastSummaryRepositoryV2), Name = "HistoryGroup")]
	public class ForecastGroupHistorySummaryRepository : ForecastHistorySummaryRepository
	{

		#region Class: ReferenceColumnData

		protected class ReferenceColumnData
		{
			public string ReferenceSchemaNameAlias { get; set; }
			public string ReferenceColumnName { get; set; }
			public string SchemaName { get; set; }
			public string SchemaNameAlias { get; set; }
			public string ColumnPath { get; set; }
		}

		#endregion

		#region Fields: Private

		private readonly string _groupColumnName = "CellRecordId";

		#endregion

		#region Constructors: Public

		public ForecastGroupHistorySummaryRepository(UserConnection userConnection, IPeriodRepository periodRepository,
			IForecastColumnRepository columnRepository)
			: base(userConnection, periodRepository, columnRepository) { }

		#endregion

		#region Properties: Private

		private EntitySchemaColumn ReferenceColumn { get; set; }

		private List<ReferenceColumnData> ReferenceColumnsDataList { get; } = new List<ReferenceColumnData>();

		private List<ReferenceColumnData> HierarchyReferenceColumnsDataList { get;} =
			new List<ReferenceColumnData>();

		private string LastReferenceColumnSchemaAlias { get; set; }
		private int AliasPrefixIndex { get; set; }

		#endregion

		#region Methods: Private

		private void AddHierarchyFilter(FilterConfig filterConfig, Select select) {
			filterConfig.Hierarchy?.ForEach(hierarchyItem => {
				var hierarchySchemaNameAlias = GetHierarchySchemaAliasDataByColumnPath(hierarchyItem.ColumnPath);
				if (Guid.Empty.Equals(hierarchyItem.Value)) {
					select.And(hierarchySchemaNameAlias, "Id").IsNull();
				} else {
					select.And(hierarchySchemaNameAlias, "Id")
						.IsEqual(Column.Parameter(hierarchyItem.Value));
				}
			});
		}

		private string GetHierarchySchemaAliasDataByColumnPath(string hierarchyColumnPath) {
			var columnData = HierarchyReferenceColumnsDataList.Where(x=> x.ColumnPath == hierarchyColumnPath).First();
			return columnData.SchemaNameAlias;
		}

		private void AddLeftJoinByColumnData(List<ReferenceColumnData> columnDataList, Select select) {
			foreach (var referenceColumn in columnDataList) {
				select.LeftOuterJoin(referenceColumn.SchemaName).As(referenceColumn.SchemaNameAlias)
					.On(referenceColumn.ReferenceSchemaNameAlias, referenceColumn.ReferenceColumnName)
					.IsEqual(referenceColumn.SchemaNameAlias, "Id");
			}
		}

		private List<ReferenceColumnData> GetColumnsDataListByColumnPath(string groupColumnPath) {
			var result = new List<ReferenceColumnData>();
			string schemaName = ReferenceColumn.ReferenceSchema.Name;
			string referenceSchemaNameAlias = schemaName;
			string fullColumnPath = "";
			groupColumnPath.Split('.').ForEach(columnName => {
				fullColumnPath = (String.IsNullOrEmpty(fullColumnPath)) ? columnName : $"{fullColumnPath}.{columnName}";
				result.Add(
					GetReferenceColumnDataByColumnName(ref schemaName, ref referenceSchemaNameAlias, columnName, fullColumnPath));
			});
			return result;
		}

		private ReferenceColumnData GetReferenceColumnDataByColumnName(ref string schemaName,
			ref string referenceSchemaNameAlias, string columnName, string fullColumnPath) {
			EntitySchema schemaInstance = ReferenceColumn.EntitySchemaManager.GetInstanceByName(schemaName);
			EntitySchemaColumn schemaColumn = schemaInstance.Columns.GetByName(columnName);
			string schemaAlias = $"{schemaColumn.ReferenceSchema.Name}_{AliasPrefixIndex++}";
			schemaName = schemaColumn.ReferenceSchema.Name;
			var result = new ReferenceColumnData() {
				ReferenceColumnName = columnName + "Id",
				ReferenceSchemaNameAlias = referenceSchemaNameAlias,
				SchemaNameAlias = schemaAlias,
				ColumnPath = fullColumnPath,
				SchemaName = schemaName
			};
			referenceSchemaNameAlias = schemaAlias;
			return result;
		}

		#endregion

		#region Methods: Protected

		protected override TableCell FormTableCellFromEntity(IDataReader reader, IEnumerable<Period> periodsInfo) {
			var cellRecordId = reader.GetColumnValue<Guid>(_groupColumnName);
			var cell = base.FormTableCellFromEntity(reader, periodsInfo);
			cell.RecordId = cellRecordId;
			return cell;
		}

		protected override void GenerateColumnsSelect(Select select, Sheet sheet, Guid snapshotId,
			FilterConfig filterConfig) {
			base.GenerateColumnsSelect(select, sheet, snapshotId, filterConfig);
			select.Column(LastReferenceColumnSchemaAlias, "Id").As(_groupColumnName);
		}

		protected override void GenerateFromForSelect(Select select, Sheet sheet, Guid snapshotId,
			FilterConfig filterConfig) {
			base.GenerateFromForSelect(select, sheet, snapshotId, new FilterConfig {
				PeriodIds = filterConfig.PeriodIds
			});
			select.LeftOuterJoin(ReferenceColumn.ReferenceSchema.Name).As(ReferenceColumn.ReferenceSchema.Name)
				.On(_historyCellAlias, ForecastHistoryCellConstants.EntityColumnName)
				.IsEqual(ReferenceColumn.ReferenceSchema.Name, "Id");
			AddLeftJoinByColumnData(ReferenceColumnsDataList, select);
			AddLeftJoinByColumnData(HierarchyReferenceColumnsDataList, select);
		}

		protected override void GenerateWhereForSelect(Select select, Sheet sheet, Guid snapshotId,
			FilterConfig filterConfig) {
			var records = filterConfig.RecordIds?.ToList() ?? new List<Guid>();
			base.GenerateWhereForSelect(select, sheet, snapshotId, filterConfig);
			if (records.IsNotEmpty()) {
				if (records.Count > 1) {
					select.And().OpenBlock(LastReferenceColumnSchemaAlias, "Id")
						.In(Column.Parameters(records.Where(x => x != Guid.Empty)));
					if (records.Contains(Guid.Empty)) {
						select.Or(LastReferenceColumnSchemaAlias, "Id").IsNull();
					}
					select.CloseBlock();
				} else {
					if (records.Contains(Guid.Empty)) {
						select.And(LastReferenceColumnSchemaAlias, "Id").IsNull();
					} else {
						select.And(LastReferenceColumnSchemaAlias, "Id").In(Column.Parameters(records));
					}
				}
			}
			AddHierarchyFilter(filterConfig, select);
		}

		protected override void GenerateGroupByForSelect(Select select, Sheet sheet, Guid snapshotId,
			FilterConfig filterConfig) {
			base.GenerateGroupByForSelect(select, sheet, snapshotId, filterConfig);
			select.GroupBy(LastReferenceColumnSchemaAlias, "Id");
		}

		protected override Select CreateCellsSelect(Sheet sheet, Guid snapshotId, FilterConfig filterConfig) {
			ReferenceColumn = sheet.GetEntityReferenceColumn(UserConnection);
			ReferenceColumnsDataList.AddRange(GetColumnsDataListByColumnPath(filterConfig.GroupColumnPath));
			LastReferenceColumnSchemaAlias = ReferenceColumnsDataList.Last().SchemaNameAlias;
			filterConfig.Hierarchy?.ForEach(hierarchyItem =>
				HierarchyReferenceColumnsDataList.AddRange(
					GetColumnsDataListByColumnPath(hierarchyItem.ColumnPath)));
			return base.CreateCellsSelect(sheet, snapshotId, filterConfig);
		}

		#endregion

	}

	#endregion

}


