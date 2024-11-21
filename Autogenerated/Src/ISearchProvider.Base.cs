namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	#region Interface: ISearchProvider

	/// <summary>
	/// Search provider.
	/// </summary>
	public interface ISearchProvider
	{

		#region Methods: Public

		/// <summary>
		/// Searchs by query.
		/// </summary>
		/// <param name="searchQuery">Search query.</param>
		/// <returns>Search results.</returns>
		IEnumerable<Dictionary<string, string>> Search(SearchQuery searchQuery);

		#endregion

	}

	#endregion

}
