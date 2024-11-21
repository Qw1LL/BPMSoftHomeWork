namespace BPMSoft.Configuration.Deduplication
{
	
	#region Interface: IBulkDeduplicationTaskStarter

	/// <summary>
	/// Provides method for starting bulk deduplication process.
	/// </summary>
	public interface IBulkDeduplicationTaskStarter
	{
		/// <summary>
		/// Starts deduplication task.
		/// </summary>
		/// <param name="sectionName">Section name.</param>
		bool StartDeduplicationTask(string sectionName);
	}

	#endregion

}
