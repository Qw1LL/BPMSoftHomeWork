namespace BPMSoft.Configuration.Deduplication
{
	using DeduplicationElastic.WebApi.Contracts.Requests;

	#region Interface: IBulkDeduplicationRuleFactory

	/// <summary>
	/// Provides method for building start bulk deduplication request.
	/// </summary>
	public interface IStartDeduplicationRequestFactory
	{
		/// <summary>
		/// Creates start bulk deduplication request.
		/// </summary>
		/// <param name="sectionName">Section name.</param>
		/// <param name="indexName">Index name.</param>
		/// <returns>Start bulk deduplication request.</returns>
		StartDeduplicationRequest CreateStartDeduplicationRequest(string sectionName, string indexName);
	}

	#endregion

}

