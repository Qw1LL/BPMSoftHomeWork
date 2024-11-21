namespace BPMSoft.Configuration.Deduplication
{
	using DeduplicationElastic.Domain.Deduplication.Task;
	using DeduplicationElastic.WebApi.Contracts.Response;

	#region Interface: IBulkDeduplicationTaskClient

	/// <summary>
	/// Provides a set of deduplication tasks management methods. 
	/// </summary>
	public interface IBulkDeduplicationTaskClient
	{

		/// <summary>
		/// Retrieves task status by entity name and index name.
		/// If task does not exists returns null.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="indexName">Index name.</param>
		/// <returns>Deduplication task status.</returns>
		DeduplicationTaskStatus? GetDeduplicationTaskStatus(string entityName, string indexName);

		/// <summary>
		/// Retrieves actual task by entity name and index name.
		/// If task does not exists returns null.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="indexName">Index name.</param>
		/// <returns>Deduplication task response.</returns>
		DeduplicationTaskResponse GetActualDeduplicationTask(string entityName, string indexName);

	}

	#endregion

}
