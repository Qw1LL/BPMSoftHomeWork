namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;

	#region Interface: IRecordsOperationWorker

	/// <summary>
	/// Interface of the operation to records.
	/// </summary>
	public interface IRecordsOperationWorker {

		#region Events: Public

		/// <summary>
		/// Triggers when a record is processed.
		/// </summary>
		event EventHandler<RecordProcessedEventArgs> RecordProcessed;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Applies operation to the records.
		/// </summary>
		/// <param name="collection">Collection of the unique identifiers.</param>
		void ApplyOperations(IEnumerable<Guid> collection);

		#endregion

	}

	#endregion

}

