namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;

	#region Interface: IOperationAgent

	/// <summary>
	/// Interface of the operation agent.
	/// </summary>
	public interface IOperationAgent {

		#region Properties: Public 

		/// <summary>
		/// Returns true if more available.
		/// </summary>
		bool MoreAvaliable { get; }
		
		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns next collection of the unique identifiers.
		/// </summary>
		/// <returns>Collection of the unique identifiers.</returns>
		IEnumerable<Guid> GetNextItems();

		/// <summary>
		/// Updates information of the record.
		/// </summary>
		/// <param name="recordId">Unique identifier.</param>
		/// <param name="exception">Exception.</param>
		void UpdateRecordInfo(Guid recordId, Exception exception);

		/// <summary>
		/// Sets collection of the unique identificators to the queue.
		/// </summary>
		/// <param name="recordIds">Collection of the unique identifiers.</param>
		void Enqueue(IEnumerable<Guid> recordIds);
		
		#endregion

	}

	#endregion

}


