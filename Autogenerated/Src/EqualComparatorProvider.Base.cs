namespace BPMSoft.Configuration.EntitySynchronization
{

	using System;

	#region Class: EqualComparatorProvider

	/// <summary>
	/// Provides comparators for different types.
	/// </summary>
	public class EqualComparatorProvider : IEqualComparatorProvider
	{

		#region Methods: Public

		/// <summary>
		/// Returns equal comparator for string.
		/// </summary>
		/// <returns>Comparator.</returns>
		public SynchronizationColumnComparator GetStringEqualComparator() {
			return delegate(object sourceValue, object destinationValue) {
				return (sourceValue != null && destinationValue != null && sourceValue.Equals(destinationValue))
					|| (string.IsNullOrEmpty((string)sourceValue) && string.IsNullOrEmpty((string)destinationValue));
			};
		}

		/// <summary>
		/// Returns equal comparator for dateTime.
		/// </summary>
		/// <returns>Comparator.</returns>
		public SynchronizationColumnComparator GetDateEqualComparator() {
			return delegate(object sourceValue, object destinationValue) {
				DateTime? sourceDateTime = (DateTime?)sourceValue;
				DateTime? destinationDateTime = (DateTime?)destinationValue;
				return (sourceDateTime != null && destinationDateTime != null
					&& sourceDateTime.Value.Date.Equals(destinationDateTime.Value.Date))
					|| (sourceDateTime == null && destinationDateTime == null);
			};
		}

		#endregion

	}

	#endregion

}

