namespace BPMSoft.Configuration.Deduplication
{
	using System.Collections.Generic;

	#region Interface: IDeduplicationSearchQueryBuilder

	/// <summary>
	/// Search query builder for deduplication request.
	/// </summary>
	public interface IDeduplicationSearchQueryBuilder
	{

		#region Methods: Public

		/// <summary>
		/// Builds search query from duplicates rules.
		/// </summary>
		/// <param name="rules">Duplicate rules.</param>
		/// <param name="findDuplicatesRequest">Request.</param>
		/// <returns>Search query.</returns>
		SearchQuery BuildSearchQuery(IEnumerable<DuplicatesRuleDTO> rules,
				FindDuplicatesRequest findDuplicatesRequest);

		#endregion
	}

	#endregion

}
