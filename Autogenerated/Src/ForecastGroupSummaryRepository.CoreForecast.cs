namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastGroupSummaryRepository

	[DefaultBinding(typeof(IForecastSummaryRepositoryV2), Name = "Group")]
	public class ForecastGroupSummaryRepository : ForecastSummaryRepository
	{

		#region Fields: Private

		private EntitySchemaQueryColumn _groupColumn;

		#endregion

		#region Constructors: Public

		public ForecastGroupSummaryRepository(UserConnection userConnection, IPeriodRepository periodRepository,
			IForecastColumnRepository columnRepository)
			: base(userConnection, periodRepository, columnRepository) { }

		#endregion

		#region Methods: Private

		private EntitySchemaQueryFilterCollection GetEsqSummaryGroupFilter(FilterConfig filterConfig,
				EntitySchemaColumn referenceColumn, EntitySchemaQuery esq) {
			string referenceSchemaGroupColumnName = $"{referenceColumn.Name}.{filterConfig.GroupColumnPath}";
			_groupColumn = esq.AddColumn(referenceSchemaGroupColumnName);
			var records = filterConfig.RecordIds?.ToList() ?? new List<Guid>();
			var recordsGroup = new EntitySchemaQueryFilterCollection(esq);
			var filterGroup = new EntitySchemaQueryFilterCollection(esq);
			recordsGroup.LogicalOperation = LogicalOperationStrict.Or;
			filterGroup.LogicalOperation = LogicalOperationStrict.And;
			if (records.Contains(Guid.Empty)) {
				records.Remove(Guid.Empty);
				recordsGroup.Add(esq.CreateIsNullFilter(referenceSchemaGroupColumnName));
			}
			if (records.IsNotEmpty()) {
				recordsGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					referenceSchemaGroupColumnName, records.Cast<object>().ToArray()));
			}
			filterGroup.Add(recordsGroup);
			AddHierarchyFilter(filterConfig, referenceColumn, esq);
			return recordsGroup;
		}

		private void AddHierarchyFilter(FilterConfig filterConfig, EntitySchemaColumn referenceColumn,
				EntitySchemaQuery esq) {
			filterConfig.Hierarchy?.ForEach(hierarchyItem => {
				string hierarchyItemColumnPath = $"{referenceColumn.Name}.{hierarchyItem.ColumnPath}";
				if (Guid.Empty.Equals(hierarchyItem.Value)) {
					esq.Filters.Add(esq.CreateIsNullFilter(hierarchyItemColumnPath));
				} else {
					esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
						hierarchyItemColumnPath,
						hierarchyItem.Value));
				}
			});
		}

		#endregion

		#region Methods: Protected

		protected override TableCell FormTableCellFromEntity(Entity item) {
			var cell = base.FormTableCellFromEntity(item);
			cell.RecordId = item.GetTypedColumnValue<Guid>(_groupColumn.Name + "Id");
			return cell;
		}

		protected override EntitySchemaQuery GetSummaryEsq(Sheet sheet, IEnumerable<Period> periodsInfo,
			IEnumerable<ForecastColumn> filterColumns, FilterConfig filterConfig) {
			var esq = base.GetSummaryEsq(sheet, periodsInfo, filterColumns, filterConfig);
			EntitySchemaColumn referenceColumn = sheet.GetEntityReferenceColumn(UserConnection);
			EntitySchemaQueryFilterCollection
				filterGroup = GetEsqSummaryGroupFilter(filterConfig, referenceColumn, esq);
			esq.Filters.Add(filterGroup);
			return esq;
		}

		#endregion

	}

	#endregion

}

