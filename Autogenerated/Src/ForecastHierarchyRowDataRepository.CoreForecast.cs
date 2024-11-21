namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.DB;

	#region Interface: IForecastHierarchyRowDataRepository

	/// <summary>
	/// Provides methods to retrieve the data hierarchy of the records in the forecast.
	/// </summary>
	public interface IForecastHierarchyRowDataRepository
	{
		/// <summary>
		/// Gets the hierarchy rows.
		/// </summary>
		/// <param name="sheet">The forecast sheet entity.</param>
		/// <param name="hierarchy">The hierarchy.</param>
		/// <param name="pageableConfig">The records ids.</param>
		/// <returns>Collection of <see cref="HierarchyRow"/></returns>
		IEnumerable<HierarchyRow> GetHierarchyRows(Sheet sheet,
			IEnumerable<HierarchySettingItem> hierarchy, PageableConfig pageableConfig);
	}

	/// <summary>
	/// The hierarchy row.
	/// </summary>
	public class HierarchyRow
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the record identifier.
		/// </summary>
		/// <value>
		/// The record identifier.
		/// </value>
		public Guid RecordId { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public string Value { get; set; }

		#endregion

	}

	#endregion

	#region Interface: IForecastRowSortStrategy

	/// <summary>
	/// Parameters object forecast sorting strategy.
	/// </summary>
	public class ForecastRowSortStrategyParams
	{
		/// <summary>
		/// Forecast sheet.
		/// </summary>
		public Sheet Sheet { get; set; }

		/// <summary>
		/// Curreny hierarchy level.
		/// </summary>
		public int CurrentHierarchyLevel { get; set; }
	}

	/// <summary>
	/// Sort strategy for forecast hierarchical rows.
	/// </summary>
	public interface IForecastRowSortStrategy
	{
		/// <summary>
		/// Sets order by statement for select.
		/// </summary>
		/// <param name="select">Select query to apply sort options to.</param>
		/// <param name="params">Forecast sort parameters.</param>
		/// <returns></returns>
		Select ApplySortOptions(Select select, ForecastRowSortStrategyParams @params);
	}

	#endregion

	#region Class: ForecastRowNameSortStrategy
	
	/// <summary>
	/// Sort strategy by display value column for forecast hierarchical rows.
	/// </summary>
	[DefaultBinding(typeof(IForecastRowSortStrategy))]
	public class ForecastRowNameSortStrategy : IForecastRowSortStrategy
	{

		/// <summary>
		/// Sets order by statement for select.
		/// </summary>
		/// <param name="params">Sort strategy parameters (Sheet and CurrentHierarchyLevel).</param>
		/// <param name="select">Forecast rows select.</param>
		/// <returns></returns>
		public Select ApplySortOptions(Select select, ForecastRowSortStrategyParams @params) {
			select.CheckArgumentNull(nameof(select));
			var displayValueColumn = select.Columns.First();
			return select.OrderByAsc(displayValueColumn) as Select;
		}
	}

	#endregion

	#region Class: ForecastHierarchyRowDataRepository

	/// <summary>
	/// Provides methods to retrieve the data hierarchy of the records in the forecast.
	/// </summary>
	/// <seealso cref="IForecastHierarchyRowDataRepository" />
	[DefaultBinding(typeof(IForecastHierarchyRowDataRepository))]
	public class ForecastHierarchyRowDataRepository : BaseForecastHierarchyRowRepository, IForecastHierarchyRowDataRepository
	{
		#region Constructors: Public

		public ForecastHierarchyRowDataRepository(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		
		#region Methods: Public

		/// <summary>
		/// Gets the hierarchy rows.
		/// </summary>
		/// <param name="sheet">The forecast sheet <see cref="Sheet" />.</param>
		/// <param name="hierarchy">The hierarchy <see cref="HierarchySettingItem" />.</param>
		/// <param name="pageableConfig">The pageable configuration <see cref="PageableConfig" />.</param>
		/// <returns> Collection of <see cref="HierarchyRow" /></returns>
		public IEnumerable<HierarchyRow> GetHierarchyRows(Sheet sheet,
					IEnumerable<HierarchySettingItem> hierarchy, PageableConfig pageableConfig) {
				sheet.CheckArgumentNull(nameof(sheet));
				pageableConfig.CheckArgumentNull(nameof(pageableConfig));
				EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityUId);
				var select =  GetForecastEntitySelect(entitySchema.Name, sheet);
				var config = new SelectQueryConfig() {
					Select = select,
					Hierarchy = hierarchy,
					Sheet = sheet,
					PageableConfig = pageableConfig
				};
				return GetSelectQueryWithOptions(config);
			}

		#endregion
	}

	#endregion

}

