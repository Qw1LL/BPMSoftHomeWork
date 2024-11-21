namespace BPMSoft.Configuration.Deduplication
{

	#region Interface: IMergeReferencesFactory

	/// <summary>
	/// Provides methods for entity references during merge process.
	/// </summary>
	public interface IMergeReferencesFactory
	{
		/// <summary>
		/// Returns collection of references for merge process.
		/// </summary>
		/// <returns>Collection of references.</returns>
		MergeReferenceCollection GetReferences(string schemaName);

	} 
	
	#endregion

}
