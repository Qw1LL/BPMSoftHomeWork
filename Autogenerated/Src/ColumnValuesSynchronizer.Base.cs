namespace BPMSoft.Configuration.EntitySynchronization
{

	using System.Collections.Generic;
	using BPMSoft.Core.Entities;

	#region Class: ColumnValuesSynchronizer

	/// <summary>
	/// Synchronizes entity column values.
	/// </summary>
	public class ColumnValuesSynchronizer : IColumnValuesSynchronizer
	{

		#region Methods: Private

		/// <summary>
		/// General equal comparator.
		/// </summary>
		/// <param name="sourceValue">Source value.</param>
		/// <param name="destinationValue">Destination value.</param>
		/// <returns>If <paramref name="sourceValue"/> is equal to <paramref name="destinationValue">.</returns>
		private bool EqualComparator(object sourceValue, object destinationValue) {
			return (sourceValue != null && sourceValue.Equals(destinationValue))
					|| (sourceValue == null && destinationValue == null);
		}

		/// <summary>
		/// Fills <paramref name="columnMapping"> destination with <paramref name="columnMapping"> source column value.
		/// </summary>
		/// <param name="source">Source entity.</param>
		/// <param name="destination">Destination entity.</param>
		/// <param name="columnMapping">Column mapping.</param>
		private void FillColumn(Entity source, Entity destination,
				SynchronizationColumnMapping columnMapping) {
			destination.SetColumnValue(columnMapping.DestinationColumnName,
				source.GetColumnValue(columnMapping.SourceColumnName));
		}

		/// <summary>
		/// Matches <paramref name="columnMapping"> source column value and <paramref name="columnMapping">
		/// destination value. If they are equal skips them. Fills <paramref name="columnMapping"> destination otherwise.
		/// </summary>
		/// <param name="source">Source entity.</param>
		/// <param name="destination">Destination entity.</param>
		/// <param name="columnMapping">Column mapping.</param>
		private void SynchronizeColumns(Entity source, Entity destination,
				SynchronizationColumnMapping columnMapping) {
			object sourceValue = source.GetColumnValue(columnMapping.SourceColumnName);
			object destinationValue = destination.GetColumnValue(columnMapping.DestinationColumnName);
			SynchronizationColumnComparator equalComparator = columnMapping.Comparator ?? EqualComparator;
			if (!equalComparator(sourceValue, destinationValue)) {
				destination.SetColumnValue(columnMapping.DestinationColumnName, sourceValue);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Synchronizes <parameref name="source"> and <paramref name="destination">.
		/// </summary>
		/// <param name="source">Source entity.</param>
		/// <param name="destination">Destination entity.</param>
		/// <param name="columnMappings">Column mappings.</param>
		public void SynchronizeEntities(Entity source, Entity destination,
				ICollection<SynchronizationColumnMapping> columnMappings) {
			foreach (SynchronizationColumnMapping columnMapping in columnMappings) {
				SynchronizeColumns(source, destination, columnMapping);
			}
		}

		/// <summary>
		/// Fills <parameref name="destination"> with <paramref name="source"> column values.
		/// </summary>
		/// <param name="source">Source entity.</param>
		/// <param name="destination">Destination entity.</param>
		/// <param name="columnMappings">Column mappings.</param>
		public void FillDestinationEntity(Entity source, Entity destination,
				ICollection<SynchronizationColumnMapping> columnMappings) {
			foreach (SynchronizationColumnMapping columnMapping in columnMappings) {
				FillColumn(source, destination, columnMapping);
			}
		}

		#endregion

	}

	#endregion

}

