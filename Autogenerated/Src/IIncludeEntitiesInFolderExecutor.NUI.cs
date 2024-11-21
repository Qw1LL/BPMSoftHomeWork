namespace BPMSoft.Configuration {

	#region interface: IIncludeEntitiesInFolderExecutor

	/// <summary>
	/// Interface include entities to folders.
	/// </summary>
	public interface IIncludeEntitiesInFolderExecutor {

		/// <summary>
		/// Add selected entities to folder.
		/// </summary>
		/// <param name="filtersConfig"></param>
		int Execute(string[] recordsToAdd);
	}

	#endregion

}

