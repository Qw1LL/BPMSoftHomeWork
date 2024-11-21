namespace BPMSoft.Configuration.Deduplication
{
	#region Interface: _IBulkDeduplicationSearchScheduler

	/// <summary>
	/// Represents a scheduler for managing duplicates search jobs.
	/// </summary>
	public interface IBulkDeduplicationScheduler
	{

		#region Methods: Public

		/// <summary>
		/// Schedules a duplicates search job with a specified parameter.
		/// </summary>
		/// <param name="duplicatesScheduledSearchParameter">The parameter of the schedule duplicates search for job starting.</param>
		void ScheduleSearchJob(DuplicatesScheduledSearchParameter duplicatesScheduledSearchParameter);

		/// <summary>
		/// Deletes a schedule duplicates search job by a specified search schema name.
		/// </summary>
		/// <param name="schemaName">The search schema name for job deletion.</param>
		void DeleteSearchJob(string schemaName);

		#endregion

	}

	#endregion
}

