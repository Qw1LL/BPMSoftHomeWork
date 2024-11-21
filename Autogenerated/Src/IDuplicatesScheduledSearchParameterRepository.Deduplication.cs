namespace BPMSoft.Configuration.Deduplication
{
	#region Interface: IDuplicatesScheduledSearchParameterRepository

	/// <summary>
	/// Represents a repository to access to parameters of the schedule duplicates search.
	/// </summary>
	public interface IDuplicatesScheduledSearchParameterRepository
	{
		#region Methods: Public

		/// <summary>
		/// Checks the availability of a parameter of the schedule duplicates search by a specified search schema name.
		/// </summary>
		/// <param name="schemaName">The search schema name to check.</param>
		/// <returns>True if a parameter of the schedule duplicates search with <paramref name="schemaName"/> exists, otherwise false.</returns>
		bool GetIsSearchParametersExist(string schemaName);

		/// <summary>
		/// Creates a parameter of the schedule duplicates search with default values by a specified search schema name.
		/// </summary>
		/// <param name="schemaName">The search schema name.</param>
		void CreateDefaultSearchParameterBySchemaName(string schemaName);

		/// <summary>
		/// Deletes a parameter of the schedule duplicates search by a specified search schema name.
		/// </summary>
		/// <param name="schemaName">The search schema name.</param>
		void DeleteSearchParameterBySchemaName(string schemaName);

		#endregion
	}

	#endregion
}

