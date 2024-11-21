namespace BPMSoft.Configuration {
	
	#region Interface: IRecordProcessedHandler

	/// <summary>
	/// Interface of the record processed handler.
	/// </summary>
	public interface IRecordProcessedHandler {

		#region Methods: Public

		/// <summary>
		/// Handler for the record processed event.
		/// </summary>
		/// <param name="sender">Execution context.</param>
		/// <param name="args">Additional information of the RecordProcessed event.</param>
		void HandleRecordProcessed(object sender, RecordProcessedEventArgs args);

		#endregion

	}

	#endregion

}

