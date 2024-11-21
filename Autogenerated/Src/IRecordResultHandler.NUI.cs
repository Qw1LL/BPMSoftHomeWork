namespace BPMSoft.Configuration
{

	#region Interface: IRecordResultHandler

	/// <summary>
	/// Interface of the record result handler.
	/// </summary>
	public interface IRecordResultHandler {

		#region Methods: Public

		/// <summary>
		/// The method is executed after record is processed.
		/// </summary>
		void RecordProcessed();

		#endregion
		
	}

	#endregion

}


