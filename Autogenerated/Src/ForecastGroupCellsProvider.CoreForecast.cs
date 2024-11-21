namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastGroupCellsProvider

	/// <summary>
	/// Group cells operations interface.
	/// </summary>
	public interface IForecastGroupCellsProvider
	{
		/// <summary>
		/// Saves group cell value.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="parameters">Parameters.</param>
		void SaveGroupCell(Sheet sheet, SaveGroupCellParams parameters);

		/// <summary>
		/// Recalculates group cell values of changed records.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="parameters">Parameters.</param>
		void RecalculateGroupCells(Sheet sheet, RecalculateGroupCellsParameters parameters);
	}

	#endregion

	#region Class: RecalculateGroupCellsParameters

	/// <summary>
	/// RecalculateGroupCells parameters.
	/// </summary>
	public class RecalculateGroupCellsParameters
	{
		/// <summary>
		/// Changed records identifiers.
		/// Recalculates group values of changed records.
		/// Determines forecast groups by RecordIds or GroupEntities parameters.
		/// </summary>
		public IEnumerable<Guid> RecordIds { get; set; }

		/// <summary>
		/// Excluded records from group value calculation.
		/// </summary>
		public IEnumerable<Guid> ExcludedRecords { get; set; }

		/// <summary>
		/// Collection of referenced group entities.
		/// Determines forecast groups by GroupEntities or RecordIds parameters.
		/// </summary>
		public IEnumerable<Entity> GroupEntities { get; set; }
	}

	#endregion

	#region Class: ForecastGroupCellsProvider

	/// <summary>
	/// Forecast group cells operations provider.
	/// </summary>
	[DefaultBinding(typeof(IForecastGroupCellsProvider))]
	public class ForecastGroupCellsProvider : IForecastGroupCellsProvider
	{

		#region Fields: Private

		private IPeriodRepository _periodRepository;
		private IForecastCellRepository _cellRepository;
		private IForecastColumnRepository _columnRepository;
		private IForecastHierarchyRowDataRepository _forecastRowRepository;

		#endregion

		#region Class: ForecastMetaData

		protected class ForecastMetaData
		{

			#region Properties: Public

			public Sheet Sheet { get; set; }

			public IEnumerable<ForecastColumn> Columns { get; set; }

			public IEnumerable<Guid> PeriodIds { get; set; }

			public IEnumerable<HierarchySettingItem> HierarchySettingItems { get; set; }

			public EntitySchemaColumn ReferenceEntityColumn { get; set; }

			#endregion

		}

		#endregion

		#region Constructors: Public

		public ForecastGroupCellsProvider(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IForecastCellRepository CellRepository =>
			_cellRepository ?? (_cellRepository = ClassFactory.Get<IForecastCellRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		/// <summary> Gets the forecast columns repository. </summary>
		/// <value> The columns repository. </value>
		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IForecastHierarchyRowDataRepository ForecastRowRepository =>
			_forecastRowRepository ?? (_forecastRowRepository = ClassFactory.Get<IForecastHierarchyRowDataRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected ForecastMetaData MetaData { get; set; }

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private decimal CalcRecordCellValue(Sheet sheet, decimal groupCellValue, int recordsCount) {
			var value = recordsCount == 0 || groupCellValue == 0 ? 0 : groupCellValue / recordsCount;
			int precision = sheet.GetForecastValueColumnPrecision(UserConnection);
			decimal cellValue = Math.Round(value, precision, MidpointRounding.AwayFromZero);
			return cellValue;
		}

		private decimal CalculateValueFromCells(IEnumerable<Cell> recordsCells, ForecastColumn groupEditColumn,
				Guid periodId) {
			var cellsToSum = recordsCells.Where(c =>
				c.ColumnId == groupEditColumn.Id && c.PeriodId == periodId);
			decimal value = cellsToSum.Sum(c => c.Value);
			return value;
		}

		private decimal CalcValueWithDivisionRemainder(decimal cellValue, int recordsCount, decimal groupCellValue) {
			cellValue += groupCellValue - (cellValue * recordsCount);
			return cellValue;
		}

		private IEnumerable<Cell> GetGroupEditCells(IEnumerable<Guid> rowsIds) {
			var recordsCells = CellRepository.GetCellsByRecords(MetaData.Sheet, MetaData.PeriodIds, rowsIds);
			return FilterCellsByGroupEditColumns(recordsCells);
		}

		private IEnumerable<Cell> FilterCellsByGroupEditColumns(IEnumerable<Cell> recordsCells) {
			return recordsCells.Where(c => MetaData.Columns.Any(gc => gc.Id == c.ColumnId));
		}

		private EntityCollection GetItemsReferenceEntities(IEnumerable<Guid> recordIds) {
			var forecastRefEntity = UserConnection.EntitySchemaManager.GetInstanceByUId(MetaData.Sheet.ForecastEntityUId);
			var esq = new EntitySchemaQuery(forecastRefEntity);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			MetaData.HierarchySettingItems.ForEach(item => {
				esq.AddColumn(item.ColumnPath);
			});
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Id", recordIds.Cast<object>()));
			var entities = esq.GetEntityCollection(UserConnection);
			return entities;
		}

		private IEnumerable<List<Entity>> GroupByColumn(IEnumerable<Entity> referenceEntities, string columnName) {
			var groups = referenceEntities.GroupBy(e => e.GetTypedColumnValue<Guid>(columnName));
			return groups.Select(g => g.ToList());
		}

		private List<IEnumerable<Entity>> GroupEntitiesByHierarchy(IEnumerable<Entity> referenceEntities) {
			var groupedEntities = new List<IEnumerable<Entity>>();
			foreach (HierarchySettingItem hierarchyItem in MetaData.HierarchySettingItems) {
				string columnName = FormColumnName(hierarchyItem);
				if (groupedEntities.IsEmpty()) {
					var entitiesCollection = GroupByColumn(referenceEntities, columnName);
					groupedEntities.AddRange(entitiesCollection);
				} else {
					var newGrouping = new List<IEnumerable<Entity>>();
					foreach (var group in groupedEntities) {
						var entitiesCollection = GroupByColumn(group, columnName);
						newGrouping.AddRange(entitiesCollection);
					}
					groupedEntities = newGrouping;
				}
			}
			if (groupedEntities.IsEmpty()) {
				groupedEntities.Add(new List<Entity>(referenceEntities));
			}
			return groupedEntities;
		}

		private string FormColumnName(HierarchySettingItem hierarchyItem) {
			return hierarchyItem.ColumnPath.Replace(".", "_") + "Id";
		}

		private IEnumerable<Guid> GetRecordsInGroupIds(IEnumerable<HierarchyRow> rows) {
			return rows.Select(r => r.RecordId);
		}

		private IEnumerable<HierarchyRow> GetRecordsToUpdate(Sheet sheet, IEnumerable<Guid> groupIds) {
			var hierarchyItems = sheet.GetHierarchyItems();
			var records = ForecastRowRepository.GetHierarchyRows(sheet, hierarchyItems,
					new PageableConfig {
						HierarchyLevel = hierarchyItems.Count(),
						RowCount = -1,
						HierarchyRowsId = groupIds
			});
			return records;
		}

		private IEnumerable<ForecastColumn> GroupEditColumns(Sheet sheet) {
			IEnumerable<ForecastColumn> columns = ColumnRepository.GetColumns(sheet.Id);
			var groupEditColumns = columns.Where(c =>
				c.TypeId == ForecastConsts.EditableColumnTypeId && c.GetColumnSettings<EditableSetting>().IsGroupEdit);
			return groupEditColumns;
		}

		private void RecalculateByGroups(List<IEnumerable<Entity>> groups, IEnumerable<Guid> excludedRecords) {
			foreach (IEnumerable<Entity> groupedRows in groups) {
				var refEntity = groupedRows.First();
				var groupIds = FormGroupIds(refEntity);
				var recordsInGroup = GetRecordsToUpdate(MetaData.Sheet, groupIds);
				var rowsIds = GetRecordsInGroupIds(recordsInGroup);
				var recordsCells = GetGroupEditCells(rowsIds);
				foreach (Guid periodId in MetaData.PeriodIds) {
					foreach (ForecastColumn groupEditColumn in MetaData.Columns) {
						decimal value = CalculateValueFromCells(recordsCells, groupEditColumn, periodId);
						SaveGroupCell(MetaData.Sheet, new SaveGroupCellParams {
							Value = value,
							ColumnId = groupEditColumn.Id,
							PeriodId = periodId,
							GroupIds = groupIds.ToArray(),
							ExcludedRecords = excludedRecords
						});
					}
				}
			}
		}

		private List<Guid> FormGroupIds(Entity refEntity) {
			List<Guid> groupIds = new List<Guid>();
			MetaData.HierarchySettingItems.ForEach(item => {
				string columnName = FormColumnName(item);
				Guid groupValueId = refEntity.GetTypedColumnValue<Guid>(columnName);
				groupIds.Add(groupValueId);
			});
			return groupIds;
		}

		private EntityCollection GetPeriods(Sheet sheet, IEnumerable<ForecastColumn> groupEditColumns) {
			var columnIds = groupEditColumns.Select(c => c.Id);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityInCellUId));
			esq.IsDistinct = true;
			esq.PrimaryQueryColumn.IsAlwaysSelect = false;
			esq.AddColumn("Period");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", sheet.Id));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ForecastColumn",
				columnIds.Cast<object>()));
			var periods = esq.GetEntityCollection(UserConnection);
			return periods;
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public void RecalculateGroupCells(Sheet sheet, RecalculateGroupCellsParameters parameters) {
			var groupEditColumns = GroupEditColumns(sheet);
			if (groupEditColumns.IsEmpty()) {
				return;
			}
			var hierarchyItems = sheet.GetHierarchyItems();
			if (hierarchyItems.IsEmpty()) {
				return;
			}
			EntityCollection periods = GetPeriods(sheet, groupEditColumns);
			if (periods.IsEmpty()) {
				return;
			}
			var periodIds = periods.Select(p => p.GetTypedColumnValue<Guid>("PeriodId"));
			MetaData = new ForecastMetaData {
				Sheet = sheet,
				Columns = groupEditColumns,
				HierarchySettingItems = hierarchyItems,
				PeriodIds = periodIds,
				ReferenceEntityColumn = sheet.GetEntityReferenceColumn(UserConnection)
			};
			parameters.GroupEntities = parameters.GroupEntities ?? new Entity[0];
			IEnumerable<Entity> referenceEntities = parameters.GroupEntities.IsEmpty()
				? GetItemsReferenceEntities(parameters.RecordIds)
				: parameters.GroupEntities;
			var groups = GroupEntitiesByHierarchy(referenceEntities);
			RecalculateByGroups(groups, parameters.ExcludedRecords);
		}

		///<inheritdoc />
		public void SaveGroupCell(Sheet sheet, SaveGroupCellParams parameters) {
			var records = GetRecordsToUpdate(sheet, parameters.GroupIds);
			if (parameters.ExcludedRecords != null) {
				records = records.Where(r => !parameters.ExcludedRecords.Contains(r.RecordId));
			}
			int recordsCount = records.Count();
			decimal groupCellValue = parameters.Value;
			decimal cellValue = CalcRecordCellValue(sheet, groupCellValue, recordsCount);
			foreach (var record in records) {
				if (record == records.Last()) {
					cellValue = CalcValueWithDivisionRemainder(cellValue, recordsCount, groupCellValue);
				}
				CellRepository.SaveCell(sheet, new Cell {
					EntityId = record.RecordId,
					PeriodId = parameters.PeriodId,
					ColumnId = parameters.ColumnId,
					Value = cellValue
				});
			}
		}

		#endregion

	}

	#endregion

}

