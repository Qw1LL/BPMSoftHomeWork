namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;

	#region Interface: IDeduplicationManager

	/// <summary>
	/// Deduplication manager.
	/// </summary>
	public interface IDeduplicationManager
	{

		#region Methods: Public

		/// <summary>
		/// Finds duplicates on save.
		/// </summary>
		/// <param name="findDuplicatesRequest">Request.</param>
		/// <returns>Duplicates collection.</returns>
		IEnumerable<Dictionary<string, string>> FindDuplicates(FindDuplicatesRequest findDuplicatesRequest);

		/// <summary>
		/// Finds similar records from stored entity.
		/// </summary>
		/// <param name="request">Request.</param>
		/// <returns>Similar entities collection.</returns>
		IEnumerable<Dictionary<string, string>> FindSimilarRecordsFromStored(FindSimilarRecordsFromStoredRequest request);
		
		#endregion

	}

	#endregion

}
