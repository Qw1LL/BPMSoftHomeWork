namespace BPMSoft.Configuration.Deduplication
{

	using System.Runtime.Serialization;

	#region Class: BulkDeduplicationInfo

	/// <summary>
	/// Bulk deduplication info
	/// </summary>
	[DataContract]
	public class BulkDeduplicationInfo {

		/// <summary>
		/// True if deduplication not started before.
		/// </summary>
		[DataMember(Name = "isFirstRun")]
		public bool IsFirstRun { get; set; }

		/// <summary>
		/// True if deduplication is running.
		/// </summary>
		[DataMember(Name = "isRunning")]
		public bool IsRunning { get; set; }

		/// <summary>
		/// Processed percent of deduplication task.
		/// </summary>
		[DataMember(Name = "processedPercent")]
		public int ProcessedPercent { get; set; }

		/// <summary>
		/// Duplicates count by source record.
		/// </summary>
		[DataMember(Name = "maxDuplicatesPerRecord")]
		public int MaxDuplicatesPerRecord { get; set; }

		/// <summary>
		/// True if deduplication task success.
		/// </summary>
		[DataMember(Name = "isSuccess")]
		public bool IsSuccess { get; set; }

	}

	#endregion
	
}
