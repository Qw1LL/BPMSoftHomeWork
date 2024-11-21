namespace BPMSoft.Configuration.ForecastV2
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastHistoryMatcher

	/// <summary>
	/// Provides methods to make forecast snapshots.
	/// </summary>
	public interface IForecastHistoryMatcher
	{
		/// <summary>
		/// Match tree table data.
		/// </summary>
		/// <param name="leftCollection">The master collection to compare. </param>
		/// <param name="rightCollection">The slave collection to compare. </param>
		/// <returns><see cref="Sheet"/></returns>
		IEnumerable<HistoryTreeTableDataItem> Match(IEnumerable<TreeTableDataItem> leftCollection,
			IEnumerable<TreeTableDataItem> rightCollection);

		/// <summary>
		/// Match table columns data.
		/// </summary>
		/// <param name="leftCollection">The master collection to compare. </param>
		/// <param name="rightCollection">The slave collection to compare. </param>
		/// <returns><see cref="Sheet"/></returns>
		IEnumerable<TableColumn> Match(IEnumerable<TableColumn> leftCollection,
			IEnumerable<TableColumn> rightCollection);
	}

	#endregion

	#region Class: ForecastSnapshotManager

	/// <summary>
	/// Provides methods to match forecast data and return a diff.
	/// </summary>
	/// <seealso cref="IForecastHistoryMatcher" />
	[DefaultBinding(typeof(IForecastHistoryMatcher))]
	public class ForecastHistoryMatcher: IForecastHistoryMatcher
	{

		#region Methods: Private

		private void FillColumnValues(HistoryTreeTableDataItem newRow, TreeTableDataItem leftItem,
			TreeTableDataItem rightItem) {
			newRow.ColumnValues = new List<HistoryTableCell>();
			foreach (TableCell leftItemColumnValue in leftItem.ColumnValues) {
				var newCell = new HistoryTableCell(leftItemColumnValue);
				var rightItemColumnValue = rightItem?.ColumnValues.FirstOrDefault(cv =>
					cv.ColumnId == leftItemColumnValue.ColumnId && cv.GroupId == leftItemColumnValue.GroupId);
				if (rightItemColumnValue != null) {
					newCell.ActualValue = rightItemColumnValue.Value;
				}
				newRow.ColumnValues.Add(newCell);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Match tree table data.
		/// </summary>
		/// <param name="leftCollection">The master collection to compare (Historical). </param>
		/// <param name="rightCollection">The slave collection to compare (Actual). </param>
		/// <returns><see cref="Sheet"/></returns>
		public IEnumerable<HistoryTreeTableDataItem> Match(IEnumerable<TreeTableDataItem> leftCollection,
				IEnumerable<TreeTableDataItem> rightCollection) {
			var rows = new List<HistoryTreeTableDataItem>();
			foreach (TreeTableDataItem leftItem in leftCollection) {
				var newRow = new HistoryTreeTableDataItem(leftItem);
				rows.Add(newRow);
				var rightItem = rightCollection.FirstOrDefault(item => item.RecordId == leftItem.RecordId);
				if (rightItem == null) {
					newRow.HistoryState = HistoryState.Deleted;
				}
				FillColumnValues(newRow, leftItem, rightItem);
			}
			return rows;
		}

		/// <summary>
		/// Match table columns data.
		/// </summary>
		/// <param name="leftCollection">The master collection to compare. </param>
		/// <param name="rightCollection">The slave collection to compare. </param>
		/// <returns><see cref="Sheet"/></returns>
		public IEnumerable<TableColumn> Match(IEnumerable<TableColumn> leftCollection, IEnumerable<TableColumn> rightCollection) {
			return new List<TableColumn>();
		}

		#endregion

	}

	#endregion

}

