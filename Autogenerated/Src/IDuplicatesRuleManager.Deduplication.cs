namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;

	#region Interface: IDuplicatesRuleManager

	/// <summary>
	/// Provides methods for managing deduplication rules and filters.
	/// </summary>
	public interface IDuplicatesRuleManager : IDuplicatesRuleChecker
	{

		#region Methods: Public

		/// <summary>
		/// Gets a collection of all deduplication rules.
		/// </summary>
		/// <returns>The collection of all deduplication rules.</returns>
		IEnumerable<DuplicatesRuleDTO> GetAllDuplicatesRules();

		/// <summary>
		/// Gets a collection of deduplication rules by a specified schema name.
		/// </summary>
		/// <param name="schemaName">The name of a deduplication schema.</param>
		/// <returns>The collection of deduplication rules by the <paramref name="schemaName"/>.</returns>
		IEnumerable<DuplicatesRuleDTO> GetDuplicatesRules(string schemaName);

		/// <summary>
		/// Gets a collection of bulk deduplication rules by a specified schema name.
		/// </summary>
		/// <param name="schemaName">The name of a deduplication schema.</param>
		/// <returns>The collection of bulk deduplication rules by the <paramref name="schemaName"/>.</returns>
		IEnumerable<DuplicatesRuleDTO> GetBulkDuplicatesRules(string schemaName);

		/// <summary>
		/// Gets a collection of deduplication rules by specified source and search schema names.
		/// </summary>
		/// <param name="sourceSchemaName">The name of a source deduplication schema.</param>
		/// <param name="searchSchemaName">The name of a search deduplication schema.</param>
		/// <returns>The collection of deduplication rules by the <paramref name="sourceSchemaName"/> and the <paramref name="searchSchemaName"/>.</returns>
		IEnumerable<DuplicatesRuleDTO> GetDuplicatesRules(string sourceSchemaName, string searchSchemaName);

		/// <summary>
		/// Gets a collection of deduplication filters according to a specific deduplication rule.
		/// </summary>
		/// <param name="ruleId">The ID of deduplication rule.</param>
		/// <returns>The collection of deduplication filters according to the deduplication rule with <paramref name="ruleId"/>.</returns>
		IEnumerable<DuplicatesRuleFilterDTO> GetDuplicatesRuleFilters(Guid ruleId);

		#endregion

	}

	#endregion

}
