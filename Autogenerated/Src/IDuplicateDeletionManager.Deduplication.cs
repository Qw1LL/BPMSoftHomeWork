namespace BPMSoft.Configuration.Deduplication
{
	using System;

	#region Interface: IDuplicateDeletionManager

	/// <summary>
	/// Duplicate deletion.
	/// </summary>
	public interface IDuplicateDeletionManager
	{

		#region Methods: Public

		/// <summary>
		/// Removes records from deduplication data.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <param name="uniqueRecordIds">Unique record array.</param>
		void Delete(string entityName, Guid[] uniqueRecordIds);

		#endregion

	}

	#endregion

}
