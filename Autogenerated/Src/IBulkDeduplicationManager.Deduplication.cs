namespace BPMSoft.Configuration.Deduplication
{
	using System;

	#region Interface: IBulkDeduplicationManager

	/// <summary>
	/// Bulk deduplication manager.
	/// </summary>
	public interface IBulkDeduplicationManager : IBulkDeduplicationTaskStarter
	{

		#region Methods: Public

		/// <summary>
		/// Gets <see cref="BulkDeduplicationInfo"/>.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <returns><see cref="BulkDeduplicationInfo"/></returns>
		BulkDeduplicationInfo GetDeduplicationInfo(string entityName);

		/// <summary>
		/// Gets <see cref="BulkDuplicatesGroupResponse"/>.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="columns">Entity columns names.</param>
		/// <param name="offset">Duplicates select offset.</param>
		/// <param name="count">Duplicates select row count.</param>
		/// <returns><see cref="BulkDuplicatesGroupResponse"/>.</returns>
		BulkDuplicatesGroupResponse GetDuplicateEntitiesGroups(string entityName, string[] columns, int offset, int count);

		/// <summary>
		/// Gets groups of duplicates with duplicate entities. <see cref="BulkDuplicatesGroupResponse"/>.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="columns">Entity columns names.</param>
		/// <param name="offset">Duplicates groups select offset.</param>
		/// <param name="count">Duplicates groups select row count.</param>
		/// <param name="topDuplicatesPerGroup">Duplicates count in group.</param>
		/// <returns>Groups of duplicates with duplicate entities. <see cref="BulkDuplicatesGroupResponse"/>.</returns>
		BulkDuplicatesGroupResponse GetGroupsOfDuplicates(string entityName, string[] columns, int offset, int count, int topDuplicatesPerGroup);

		/// <summary>
		/// Gets duplicates by group.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="columns">Entity columns names.</param>
		/// <param name="groupId">Duplicate group identifier.</param>
		/// <param name="offset">Duplicates select offset.</param>
		/// <param name="count">Duplicates select row count.</param>
		/// <returns>Duplicate by group identidier. <see cref="BulkEntityClientDuplicatesGroup"/></returns>
		BulkEntityClientDuplicatesGroup GetDuplicateEntitiesByGroup(string entityName, string[] columns, Guid groupId, int offset, int count);

		/// <summary>
		/// Adds records to unique entity list.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="uniqueRecordIds">Unique record array.</param>
		/// <returns>Result of add.</returns>
		bool AddToUniqueList(string entityName, Guid[] uniqueRecordIds);

		/// <summary>
		/// Gets a groups count and duplicates count by a specified <paramref name="entityName"/>.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <returns>The groups count and duplicates count by a specified <paramref name="entityName"/>.</returns>
		BulkDuplicatesCountResponse GetDuplicateCountData(string entityName);

		#endregion

	}

	#endregion

}
