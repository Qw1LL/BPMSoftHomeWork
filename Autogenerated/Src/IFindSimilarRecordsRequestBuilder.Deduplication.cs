namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using BPMSoft.Core;

	#region Interface: IFindSimilarRecordsRequestBuilder

	/// <summary>
	/// Builder of the <see cref="FindDuplicatesRequest"/> for searching of similar
	/// entities.
	/// </summary>
	public interface IFindSimilarRecordsRequestBuilder
	{

		#region Methods: Public

		/// <summary>
		/// Builds the <see cref="FindDuplicatesRequest"/> from a specified <see cref="FindSimilarRecordsFromStoredRequest"/> to search duplicates.
		/// </summary>
		/// <param name="findSimilarRecordsFromStoredRequest">The request to build the new search request.</param>
		/// <returns>The instance of the <see cref="FindDuplicatesRequest"/> to search duplicates.</returns>
		FindDuplicatesRequest BuildRequest(FindSimilarRecordsFromStoredRequest findSimilarRecordsFromStoredRequest);

		/// <summary>
		/// Builds request for search duplicates.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="findSimilarRecordsFromStoredRequest">Request data.</param>
		/// <returns>Search duplicates data.</returns>
		[Obsolete("7.12.4 | Method is deprecated. Use IFindSimilarRecordsRequestBuilder.BuildRequest(FindSimilarRecordsFromStoredRequest)")]
		FindDuplicatesRequest BuildRequest(UserConnection userConnection, 
			FindSimilarRecordsFromStoredRequest findSimilarRecordsFromStoredRequest);

		#endregion

	}

	#endregion

}
