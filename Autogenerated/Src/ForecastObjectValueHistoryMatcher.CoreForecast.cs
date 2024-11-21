namespace BPMSoft.Configuration.ForecastV2 {

	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;

	#region Interface : IForecastObjectValueHistoryMatcher

	/// <summary>
	/// History object values matcher interface.
	/// </summary>
	public interface IForecastObjectValueHistoryMatcher {

		#region Methods: Public

		/// <summary>
		/// Match object value records.
		/// </summary>
		/// <param name="leftCollection">The left collection to compare. </param>
		/// <param name="rightCollection">The right collection to compare. </param>
		/// <returns><see cref="Sheet"/></returns>
		IEnumerable<HistoryObjectValueRecord> Match(IEnumerable<ObjectValueRecord> leftCollection,
			IEnumerable<ObjectValueRecord> rightCollection);
		
		#endregion

	}
	
	#endregion

	#region Class: ForecastObjectValueHistoryMatcher

	/// <summary>
	/// History object values matcher.
	/// </summary>
	[DefaultBinding(typeof(IForecastObjectValueHistoryMatcher), Name = "Default")]
	public class ForecastObjectValueHistoryMatcher : IForecastObjectValueHistoryMatcher {

		#region Methods: Public

		/// <summary>
		/// Match object value records.
		/// </summary>
		/// <param name="leftCollection">The left collection to compare. </param>
		/// <param name="rightCollection">The right collection to compare. </param>
		/// <returns><see cref="Sheet"/></returns>
		public IEnumerable<HistoryObjectValueRecord> Match(IEnumerable<ObjectValueRecord> leftCollection, 
				IEnumerable<ObjectValueRecord> rightCollection) {
			leftCollection.CheckArgumentNull(nameof(leftCollection));
			rightCollection.CheckArgumentNull(nameof(rightCollection));
			var rows = new List<HistoryObjectValueRecord>();
			foreach (ObjectValueRecord leftItem in leftCollection) {
				var newRow = new HistoryObjectValueRecord(leftItem);
				rows.Add(newRow);
				var rightItem = rightCollection.FirstOrDefault(item => 
					item.RefEntityId == leftItem.RefEntityId &&
					item.ColumnId == leftItem.ColumnId &&
					item.PeriodId == leftItem.PeriodId &&
					item.EntityId == leftItem.EntityId
					);
				if (rightItem == null) {
					newRow.HistoryState = HistoryState.Deleted;
				}
			}
			return rows;
		}

		#endregion

	}

	#endregion

}
