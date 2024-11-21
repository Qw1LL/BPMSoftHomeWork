namespace BPMSoft.Configuration.Deduplication
{
	using System;

	#region Interface: IDuplicatesRuleChecker

	/// <summary>
	/// Provides a set of methods to check the availability of deduplication rules.
	/// </summary>
	public interface IDuplicatesRuleChecker
	{

		#region Methods: Public

		/// <summary>
		/// Checks the availability of a deduplication rule by a specified id.
		/// </summary>
		/// <param name="id">The ID to check.</param>
		/// <returns>True if a deduplication rule with <paramref name="id"/> exists, otherwise false.</returns>
		bool GetIsDuplicationRuleExist(Guid id);

		/// <summary>
		/// Checks the availability of a deduplication rule by a specified search schema name.
		/// </summary>
		/// <param name="schemaName">The search schema name to check.</param>
		/// <returns>True if a deduplication rule with <paramref name="schemaName"/> exists, otherwise false.</returns>
		bool GetIsActiveDuplicationRuleExist(string schemaName);

		#endregion

	}

	#endregion
}

