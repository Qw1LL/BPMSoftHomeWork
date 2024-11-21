namespace BPMSoft.Configuration.GlobalSearch
{
	/// <summary>
	/// Types of indexing.
	/// </summary>
	public enum IndexingType
	{
		/// <summary>
		/// Indexes a document.
		/// </summary>
		Index,
 
		/// <summary>
		/// Indexes a document, fails if a document by that id already exists in the index.
		/// </summary>
		Create, 

		/// <summary>
		/// Updates a document.
		/// </summary>
		Update, 

		/// <summary>
		/// Inserts a document if not already present otherwise update.
		/// </summary>
		Upsert, 

		/// <summary>
		/// deletes a document.
		/// </summary>
		Delete
	}
}
