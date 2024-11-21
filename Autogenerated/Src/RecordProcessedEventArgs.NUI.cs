namespace BPMSoft.Configuration {
	using System;

	#region Class: RecordProcessedEventArgs

	/// <summary>
	/// Provides additional information for the RecordProcessed event.
	/// </summary>
	public class RecordProcessedEventArgs : EventArgs {
		#region Properties: Public

		/// <summary>
		/// Exception of record processing.
		/// </summary>
		public Exception Exception { get; set; }

		/// <summary>
		/// Unique identifiers of record.
		/// </summary>
		public Guid RecordId { get; set; }

		#endregion
	}

	#endregion

}

