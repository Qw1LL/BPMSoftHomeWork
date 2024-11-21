namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Core;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastProvider

	/// <summary>
	/// Provides method of select forecast data.
	/// </summary>
	public interface IForecastProvider
	{

		/// <summary>
		/// Gets the forecast data with pagination options.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <param name="periodIds">The period ids.</param>
		/// <param name="pageableConfig">The pageable configuration.</param>
		/// <returns>
		///   <see cref="ForecastData" />
		/// </returns>
		ForecastData GetData(Guid forecastId, IEnumerable<Guid> periodIds, PageableConfig pageableConfig);

		/// <summary>
		/// Gets the forecast data.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <param name="periodIds">The period ids.</param>
		/// <returns>
		///   <see cref="ForecastData" />
		/// </returns>
		ForecastData GetData(Guid forecastId, IEnumerable<Guid> periodIds);
	}

	#endregion

	#region Interface: ForecastProviderV2

	///<inheritdoc />
	public interface IForecastProviderV2 : IForecastProvider
	{
		/// <summary>
		/// Gets the forecast data with filter options.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <param name="filterConfig">Filter configuration.</param>
		/// <returns>
		///   <see cref="ForecastData" />
		/// </returns>
		ForecastData GetData(Guid forecastId, FilterConfig filterConfig);
	}

	#endregion

	#region Classes: Data Transfer Objects

	/// <summary>
	/// The pageable configuration.
	/// </summary>
	public class PageableConfig
	{
		/// <summary>
		/// Gets or sets the row count.
		/// </summary>
		/// <value>
		/// The row count.
		/// </value>
		public int RowCount { get; set; }

		/// <summary>
		/// Gets or sets the rows offset.
		/// </summary>
		/// <value>
		/// The rows offset.
		/// </value>
		public int RowsOffset { get; set; }

		/// <summary>
		/// Gets or sets the hierarchy level.
		/// </summary>
		/// <value>
		/// The hierarchy level.
		/// </value>
		public int HierarchyLevel { get; set; }

		/// <summary>
		/// Gets or sets the last value.
		/// </summary>
		/// <value>
		/// The last value.
		/// </value>
		public string LastValue { get; set; }

		/// <summary>
		/// Gets or sets the primary filter value.
		/// </summary>
		/// <value>
		/// The primary filter value.
		/// </value>
		public string PrimaryFilterValue { get; set; }

		/// <summary>
		/// Gets or sets the hierarchy rows identifier.
		/// </summary>
		/// <value>
		/// The hierarchy rows identifier.
		/// </value>
		public IEnumerable<Guid> HierarchyRowsId { get; set; }

		/// <summary>
		/// Gets or sets the records filter.
		/// </summary>
		/// <value>
		/// Records identifiers.
		/// </value>
		public IEnumerable<Guid> RecordIds { get; set; }

		/// <summary>
		/// Ignore user rights while select.
		/// </summary>
		public bool IgnoreRights { get; set; }
	}

	/// <summary>
	/// The forecast data.
	/// </summary>
	[DataContract]
	public class ForecastData
	{
		/// <summary>
		/// Gets or sets the columns.
		/// </summary>
		/// <value>
		/// The columns.
		/// </value>
		[DataMember(Name = "columns")]
		public IEnumerable<ColumnInfo> Columns { get; set; }

		/// <summary>
		/// Gets or sets the rows.
		/// </summary>
		/// <value>
		/// The rows.
		/// </value>
		[DataMember(Name = "rows")]
		public IEnumerable<Row> Rows { get; set; }
	}

	/// <summary>
	/// The column information.
	/// </summary>
	[DataContract]
	public class ColumnInfo
	{
		/// <summary>
		/// Gets or sets the period.
		/// </summary>
		/// <value>
		/// The period.
		/// </value>
		[DataMember(Name = "period")]
		public Item Period { get; set; }

		/// <summary>
		/// Gets or sets the indicator.
		/// </summary>
		/// <value>
		/// The indicator.
		/// </value>
		[DataMember(Name = "indicator")]
		public Item Indicator { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the type identifier.
		/// </summary>
		/// <value>
		/// The type identifier.
		/// </value>
		public Guid TypeId { get; set; }

		/// <summary>
		/// Gets or sets sign of hiding column.
		/// </summary>
		/// <value>
		/// Sign of hiding.
		/// </value>
		public bool IsHide { get; set; }

		/// <summary>
		/// Gets or sets column edit mode.
		/// </summary>
		/// <value>
		/// Forecast column edit mode.
		/// </value>
		public ColumnEditMode EditMode { get; set; }

		/// <summary>
		/// Defines visibility of fractional part of column value.
		/// </summary>
		public bool IsFractionalPartHidden { get; set; }
	}

	/// <summary>
	/// The item of column information.
	/// </summary>
	[DataContract]
	public class Item
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// /// <value>
		/// Item unique text code.
		/// </value>
		[DataMember(Name = "code")]
		public string Code { get; set; }
	}

	/// <summary>
	/// The forecast row.
	/// </summary>
	[DataContract]
	public class Row
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "value")]
		public string Value { get; set; }

		/// <summary>
		/// Gets or sets the hierarchy.
		/// </summary>
		/// <value>
		/// The hierarchy.
		/// </value>
		[DataMember(Name = "hierarchy")]
		public IEnumerable<HierarchyItem> Hierarchy { get; set; }

		/// <summary>
		/// Gets or sets the cells.
		/// </summary>
		/// <value>
		/// The cells.
		/// </value>
		[DataMember(Name = "cells")]
		public IEnumerable<Cell> Cells { get; set; }

		/// <summary>
		/// Gets or sets the group sign.
		/// </summary>
		/// <value>
		/// The cells.
		/// </value>
		[DataMember(Name = "isGroup")]
		public bool IsGroup { get; set; }
	}

	/// <summary>
	/// The item of forecast hierarchy.
	/// </summary>
	[DataContract]
	public class HierarchyItem
	{
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[DataMember(Name = "value")]
		public string Value { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		/// <value>
		/// The level.
		/// </value>
		[DataMember(Name = "level")]
		public int Level { get; set; }

	}

	/// <summary>
	/// The forecast cell.
	/// </summary>
	[DataContract]
	public class Cell
	{
		/// <summary>
		/// Gets or sets cell identifier.
		/// </summary>
		/// <value>
		/// Cell identifier.
		/// </value>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the period identifier.
		/// </summary>
		/// <value>
		/// The period identifier.
		/// </value>
		[DataMember(Name = "periodId")]
		public Guid PeriodId { get; set; }

		/// <summary>
		/// Gets or sets the entity identifier.
		/// </summary>
		/// <value>
		/// The entity identifier.
		/// </value>
		[DataMember(Name = "entityId")]
		public Guid EntityId { get; set; }

		/// <summary>
		/// Gets or sets the indicator identifier.
		/// </summary>
		/// <value>
		/// The indicator identifier.
		/// </value>
		[DataMember(Name = "indicatorId")]
		public Guid IndicatorId { get; set; }

		/// <summary>
		/// Gets or sets the indicator code.
		/// </summary>
		/// <value>
		/// Indicator unique text code.
		/// </value>
		[DataMember(Name = "indicatorCode")]
		public string IndicatorCode { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[DataMember(Name = "value")]
		public decimal Value { get; set; }

		/// <summary>
		/// Gets or sets the row identifier.
		/// </summary>
		/// <value>
		/// Connected forecast row identifier.
		/// </value>
		[DataMember(Name = "rowId")]
		public Guid RowId { get; set; }

		/// <summary>
		/// Gets or sets the column identifier.
		/// </summary>
		/// <value>
		/// Connected forecast row identifier.
		/// </value>
		[DataMember(Name = "columnId")]
		public Guid ColumnId { get; set; }
	}

	/// <summary>
	/// Filter data configuration.
	/// </summary>
	public partial class FilterConfig
	{
		/// <summary>
		/// Identifiers of periods.
		/// </summary>
		public IEnumerable<Guid> PeriodIds { get; set; }

		/// <summary>
		/// Identifiers of records.
		/// </summary>
		public IEnumerable<Guid> RecordIds { get; set; }

		/// <summary>
		/// Path of group column.
		/// </summary>
		public string GroupColumnPath { get; set; }

		/// <summary>
		/// Hierarchy filter conditions.
		/// </summary>
		public IEnumerable<HierarchyFilterItem> Hierarchy { get; set; }

	}

	/// <summary>
	/// Hierarchy item filter.
	/// </summary>
	public class HierarchyFilterItem
	{
		/// <summary>
		/// Hierarchy column path.
		/// </summary>
		public string ColumnPath { get; set; }

		/// <summary>
		/// Hierarchy item identifier.
		/// </summary>
		public Guid Value { get; set; }
	}

	#endregion

	#region Enums

	/// <summary>
	/// Determines mode of table cells editing.
	/// Row - Allows to edit only Forecast entity row cells.
	/// Group - Allows to edit only group cells.
	/// </summary>
	public enum ColumnEditMode
	{
		Row,
		Group
	}

	#endregion

	#region Class: ForecastProvider

	/// <summary>
	/// Provides method of select forecast data.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ForecastV2.IForecastProviderV2" />
	[DefaultBinding(typeof(IForecastProvider))]
	[DefaultBinding(typeof(IForecastProviderV2))]
	public class ForecastProvider : IForecastProviderV2
	{

		#region Fields: Private

		private IForecastSummaryProvider _forecastSummaryProvider;
		private IGetForecastCellRepository _getForecastCellRepository;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public ForecastProvider(UserConnection userConnection, IForecastSheetRepository sheetRepository,
			IForecastColumnRepository columnRepository, IPeriodRepository periodRepository,
			IEntityInForecastCellRepository entityInForecastCellRepository,
			IForecastHierarchyRowDataRepository hierarchyRowDataRepository) {
			sheetRepository.CheckArgumentNull(nameof(sheetRepository));
			columnRepository.CheckArgumentNull(nameof(columnRepository));
			periodRepository.CheckArgumentNull(nameof(periodRepository));
			hierarchyRowDataRepository.CheckArgumentNull(nameof(hierarchyRowDataRepository));
			_userConnection = userConnection;
			SheetRepository = sheetRepository;
			ColumnRepository = columnRepository;
			PeriodRepository = periodRepository;
			EntityInForecastCellRepository = entityInForecastCellRepository;
			ForecastHierarchyRowDataRepository = hierarchyRowDataRepository;
		}

		#endregion

		#region Properties: Public

		public IForecastSheetRepository SheetRepository { get; set; }

		public IForecastColumnRepository ColumnRepository { get; set; }

		public IPeriodRepository PeriodRepository { get; set; }

		public IEntityInForecastCellRepository EntityInForecastCellRepository { get; set; }

		public IGetForecastCellRepository GetForecastCellRepository {
			get {
				var args = new[] { new ConstructorArgument("userConnection", _userConnection) };
				return _getForecastCellRepository ??
					(_getForecastCellRepository = ClassFactory.Get<IGetForecastCellRepository>("Actual", args));
			}
			set => _getForecastCellRepository = value;
		}

		public IForecastHierarchyRowDataRepository ForecastHierarchyRowDataRepository { get; set; }

		public IForecastSummaryProvider ForecastSummaryProvider {
			get {
				var args = new[] { new ConstructorArgument("userConnection", _userConnection) };
				return _forecastSummaryProvider ??
					(_forecastSummaryProvider = ClassFactory.Get<IForecastSummaryProvider>(args));
			}
			set => _forecastSummaryProvider = value;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<ColumnInfo> FillColumns(IEnumerable<ForecastColumn> forecastColumns,
				IEnumerable<Period> periods) {
			var columns = new List<ColumnInfo>();
			foreach (var period in periods) {
				foreach (var column in forecastColumns) {
					var setting = column.GetColumnSettings<BaseColumnSetting>();
					columns.Add(new ColumnInfo {
						Period = new Item {
							Id = period.Id,
							Name = period.Name
						},
						Indicator = new Item {
							Id = column.Id,
							Name = column.Name,
							Code = column.Code
						},
						Id = column.Id,
						Title = column.Name,
						TypeId = column.TypeId,
						IsHide = column.IsHide,
						EditMode = column.GetColumnSettings<EditableSetting>().IsGroupEdit ?
							ColumnEditMode.Group : ColumnEditMode.Row,
						IsFractionalPartHidden = setting.IsFractionalPartHidden
					});
				}
			}
			return columns;
		}

		private ForecastData GetPageableData(Guid forecastId, IEnumerable<Guid> periodIds, PageableConfig pageableConfig) {
			Sheet sheet = SheetRepository.GetSheet(forecastId);
			var periods = PeriodRepository.GetForecastPeriods(periodIds, sheet.PeriodTypeId);
			var columns = GetColumnInfos(forecastId, periods);
			var sheetHierarchyList = sheet.GetHierarchyItems();
			var hierarchyRows = ForecastHierarchyRowDataRepository
				.GetHierarchyRows(sheet, sheetHierarchyList, pageableConfig);
			var maxLevel = sheetHierarchyList.Count();
			var hierarchyRowsIds = hierarchyRows.Select(r => r.RecordId);
			IEnumerable<Cell> allCells = new List<Cell>();
			var hierarchy = new List<HierarchyItem>();
			if (IsLastLevel(pageableConfig, maxLevel)) {
				if (hierarchyRows.Any()) {
					allCells = GetForecastCellRepository.GetCells(sheet,  new FilterConfig {
							PeriodIds = periods.Select(e => e.Id),
							RecordIds = hierarchyRowsIds
						});
					hierarchy.Add(new HierarchyItem {
						Id = Guid.NewGuid(),
						Level = maxLevel
					});
				}
			} else {
				var hierarchyItem = sheetHierarchyList.ElementAt(pageableConfig.HierarchyLevel);
				var hierarchyFilter = sheet.FormHierarchyFilter(pageableConfig.HierarchyRowsId);
				allCells = GetGroupSummaryCells(sheet, new FilterConfig {
					PeriodIds = periodIds,
					GroupColumnPath = hierarchyItem.ColumnPath,
					RecordIds = hierarchyRowsIds,
					Hierarchy = hierarchyFilter
				});
			}
			List<Row> rows = new List<Row>();
			hierarchyRows.ForEach(hr => {
				IEnumerable<Cell> cells = allCells.Where(c => c.EntityId == hr.RecordId);
				rows.Add(new Row {
					Id = hr.RecordId,
					Value = hr.Value,
					Hierarchy = hierarchy,
					Cells = cells,
					IsGroup = !IsLastLevel(pageableConfig, maxLevel)
				});
			});
			return new ForecastData {
				Columns = columns,
				Rows = rows
			};
		}

		private IEnumerable<Cell> GetGroupSummaryCells(Sheet sheet, FilterConfig filterConfig) {
			var summaryCells = ForecastSummaryProvider.GetGroupsSummary(sheet, filterConfig);
			var cells = summaryCells.Select(cell => new Cell() {
				Id = cell.Id,
				Value = (decimal)cell.Value,
				ColumnId = cell.ColumnId,
				PeriodId = cell.GroupId,
				EntityId = cell.RecordId
			});
			return cells;
		}

		private bool IsLastLevel(PageableConfig pageableConfig, int maxLevel) {
			return pageableConfig.HierarchyLevel == maxLevel;
		}

		private IEnumerable<ColumnInfo> GetColumnInfos(Guid forecastId, IEnumerable<Period> periods) {
			IEnumerable<ForecastColumn> forecastColumns = ColumnRepository.GetColumns(forecastId);
			return FillColumns(forecastColumns, periods);
		}

		private IEnumerable<Row> GetRows(IEnumerable<Cell> cells) {
			List<Row> rows = new List<Row>();
			var rowIds = cells.GroupBy(cell => cell.EntityId).Select(row => row.Key);
			rowIds.ForEach(rowId => {
				rows.Add(new Row {
					Id = rowId,
					Hierarchy = new[] { new HierarchyItem() },
					Cells = cells.Where(c => c.EntityId == rowId)
				});
			});
			return rows;
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public ForecastData GetData(Guid forecastId, IEnumerable<Guid> periodIds) {
			forecastId.CheckArgumentEmpty(nameof(forecastId));
			return GetPageableData(forecastId, periodIds, new PageableConfig() {
				HierarchyLevel = 0,
				RowCount = -1
			});
		}

		///<inheritdoc />
		public ForecastData GetData(Guid forecastId, IEnumerable<Guid> periodIds, PageableConfig pageableConfig) {
			forecastId.CheckArgumentEmpty(nameof(forecastId));
			pageableConfig.CheckArgumentNull(nameof(pageableConfig));
			return GetPageableData(forecastId, periodIds, pageableConfig);
		}

		///<inheritdoc />
		public ForecastData GetData(Guid forecastId, FilterConfig filterConfig) {
			forecastId.CheckArgumentEmpty(nameof(forecastId));
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			filterConfig.RecordIds.CheckArgumentNull(nameof(filterConfig.RecordIds));
			var sheet = SheetRepository.GetSheet(forecastId);
			var recordIds = filterConfig.RecordIds;
			IEnumerable<Period> periods =
				PeriodRepository.GetForecastPeriods(filterConfig.PeriodIds, sheet.PeriodTypeId);
			var periodIds = periods.Select(p => p.Id);
			var allCells = GetForecastCellRepository.GetCells(sheet,  filterConfig);
			var columns = GetColumnInfos(forecastId, periods);
			var rows = GetRows(allCells);
			return new ForecastData() {
				Rows = rows,
				Columns = columns
			};
		}

		#endregion

	}

	#endregion

}

