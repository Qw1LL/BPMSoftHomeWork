namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastDataIterator

	/// <summary>
	/// Forecast data iterator.
	/// </summary>
	public interface IForecastDataIterator
	{
		/// <summary>
		/// Iterates through all rows of specified forecast.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="parameters">Parameters.</param>
		void IterateRows(Sheet sheet, ForecastDataIteratorParams parameters);
	}

	#endregion

	#region Class: ForecastDataIteratorParams

	/// <summary>
	/// ForecastDataIterator parameters.
	/// </summary>
	public class ForecastDataIteratorParams
	{

		#region Properties: Public

		/// <summary>
		/// Function that processes forecast rows.
		/// </summary>
		public Action<IEnumerable<Guid>> RowsIteratorFn { get; set; }

		/// <summary>
		/// Function that processes forecast group rows.
		/// </summary>
		public Action<IEnumerable<Guid>> GroupRowsIteratorFn { get; set; }

		/// <summary>
		/// Amount of rows to be processes at a time.
		/// </summary>
		public int RowCount { get; set; } = 100;

		#endregion

	}

	#endregion

	#region Class: ForecastDataIterator

	/// <summary>
	/// Forecast data iterator.
	/// Selects forecast data rows and iterates through it divided by data chunks.
	/// </summary>
	[DefaultBinding(typeof(IForecastDataIterator))]
	public class ForecastDataIterator : IForecastDataIterator
	{

		#region Fields: Private

		private IForecastHierarchyRowDataRepository _rowsRepository;

		#endregion

		#region Constructors: Public

		public ForecastDataIterator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected IEnumerable<HierarchySettingItem> Hierarchy { get; set; }

		protected Sheet Sheet { get; set; }

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Properties: Public

		public IForecastHierarchyRowDataRepository ForecastHierarchyRowDataRepository {
			get {
				return _rowsRepository ?? (_rowsRepository = ClassFactory.Get<IForecastHierarchyRowDataRepository>(
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _rowsRepository = value; }
		}

		#endregion

		#region Methods: Private

		private void InnerIterateRows(ForecastDataIteratorParams parameters, IEnumerable<Guid> parentRowIds = null) {
			bool hasMoreData = false;
			parentRowIds = parentRowIds ?? new List<Guid>();
			int offset = 0;
			int count = parameters.RowCount;
			int hierarchyLevel = parentRowIds.Count();
			string lastValue = string.Empty;
			do {
				var rows = ForecastHierarchyRowDataRepository.GetHierarchyRows(Sheet, Hierarchy, new PageableConfig {
					RowCount = count,
					RowsOffset = offset,
					HierarchyLevel = hierarchyLevel,
					HierarchyRowsId = parentRowIds,
					IgnoreRights = true,
					LastValue = lastValue
				});
				var lastRowsCount = rows.Count();
				offset += lastRowsCount;
				hasMoreData = lastRowsCount == count;
				lastValue = rows.LastOrDefault()?.Value;
				if (lastRowsCount == 0) {
					return;
				}
				var rowIds = rows.Select(row => row.RecordId);
				if (IsLastLevel(hierarchyLevel)) {
					parameters.RowsIteratorFn?.Invoke(rowIds);
				} else {
					parameters.GroupRowsIteratorFn?.Invoke(rowIds);
					foreach (Guid row in rowIds) {
						InnerIterateRows(parameters, parentRowIds.Concat(new[] { row }));
					}
				}
			} while (hasMoreData);
		}

		private bool IsLastLevel(int hierarchyLevel) {
			return hierarchyLevel == Hierarchy.Count();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Iterates through all rows of specified forecast.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="parameters">Parameters.</param>
		public void IterateRows(Sheet sheet, ForecastDataIteratorParams parameters) {
			sheet.CheckArgumentNull(nameof(sheet));
			parameters.CheckArgumentNull(nameof(parameters));
			Sheet = sheet;
			Hierarchy = sheet.GetHierarchyItems();
			InnerIterateRows(parameters);
		}

		#endregion

	}

	#endregion

}

