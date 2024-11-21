namespace BPMSoft.Configuration.GlobalSearch
{

	using BPMSoft.ElasticSearch;

	#region Interface: IESQueryBuilder

	/// <summary>
	/// Elastic search query builder
	/// </summary>
	public interface IESQueryBuilder
	{

		#region Methods: Public

		/// <summary>
		/// Builds elastic query from select query.
		/// </summary>
		/// <param name="searchQuery">Search query.</param>
		/// <returns>Pageable elastic query.</returns>
		PageableElasticQuery BuildQuery(SearchQuery searchQuery);

		#endregion

	}

	#endregion

}
