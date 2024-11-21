namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;

	#region Interface: IOperationAgent

	/// <summary>
	/// Typed interface of the operation agent.
	/// </summary>
	public interface IOperationAgent<TValue, TResult> {

		#region Properties: Public 

		/// <summary>
		/// Returns true if more available.
		/// </summary>
		bool MoreAvaliable { get; }
		
		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns next collection of the records.
		/// </summary>
		/// <returns>Collection of the records.</returns>
		IEnumerable<TResult> GetNextItems();

		/// <summary>
		/// Sets collection of the records to the queue.
		/// </summary>
		/// <param name="records">Collection of the records.</param>
		void Enqueue(IEnumerable<TValue> recordIds);
		
		#endregion

	}

	#endregion

}


