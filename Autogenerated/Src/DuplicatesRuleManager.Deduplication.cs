namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region class: DuplicatesRuleManager

	/// <summary>
	/// Provides methods for managing deduplication rules and filters.
	/// </summary>
	[DefaultBinding(typeof(IDuplicatesRuleManager))]
	public class DuplicatesRuleManager : IDuplicatesRuleManager
	{

		#region Constants: Private

		private const string LeadSchemaName = "Lead";

		#endregion

		#region Fields: Private

		private static readonly ILog Log = LogManager.GetLogger("Deduplication");
		private readonly UserConnection _userConnection;
		private readonly IDuplicatesRuleRepository _duplicatesRuleRepository;

		#endregion

		#region Constructors: Public

		public DuplicatesRuleManager(
			UserConnection userConnection,
			IDuplicatesRuleRepository duplicatesRuleRepository) {
			_userConnection = userConnection;
			_duplicatesRuleRepository = duplicatesRuleRepository;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDuplicatesRuleChecker.GetIsDuplicationRuleExist"/>
		public bool GetIsDuplicationRuleExist(Guid entitySchemaUid) {
			var schema = _userConnection.EntitySchemaManager.FindInstanceByUId(entitySchemaUid);
			return schema != null && GetAllDuplicatesRules().Any(x => x.SchemaName == schema.Name);
		}

		/// <inheritdoc cref="IDuplicatesRuleChecker.GetIsActiveDuplicationRuleExist"/>
		public bool GetIsActiveDuplicationRuleExist(string schemaName) {
			return GetAllDuplicatesRules().Any(rule => rule.IsActive && rule.SchemaName == schemaName);
		}

		/// <inheritdoc cref="IDuplicatesRuleManager.GetAllDuplicatesRules"/>
		public IEnumerable<DuplicatesRuleDTO> GetAllDuplicatesRules() {
			return _duplicatesRuleRepository.GetDuplicatesRules(_userConnection, _userConnection.SessionCache);
		}

		/// <inheritdoc cref="IDuplicatesRuleManager.GetDuplicatesRules(string)"/>
		public IEnumerable<DuplicatesRuleDTO> GetDuplicatesRules(string schemaName) {
			return GetAllDuplicatesRules()
				.Where(rule => rule.SchemaName == schemaName &&
					(schemaName == LeadSchemaName ? rule.IsActive : rule.UseAtSave) &&
					(string.IsNullOrEmpty(rule.SearchSchemaName) || rule.SearchSchemaName == schemaName));
		}

		/// <inheritdoc cref="IDuplicatesRuleManager.GetDuplicatesRules(string, string)"/>
		public IEnumerable<DuplicatesRuleDTO> GetDuplicatesRules(string sourceSchemaName, string searchSchemaName) {
			return GetAllDuplicatesRules()
				.Where(rule => rule.IsActive &&
							rule.SchemaName == sourceSchemaName &&
							rule.SearchSchemaName == searchSchemaName);
		}

		/// <inheritdoc cref="IDuplicatesRuleManager.GetDuplicatesRuleFilters"/>
		public IEnumerable<DuplicatesRuleFilterDTO> GetDuplicatesRuleFilters(Guid ruleId) {
			var duplicatesRule = _duplicatesRuleRepository.Get(_userConnection, ruleId);
			if (duplicatesRule != null) {
				return duplicatesRule.RuleBody?.Filters?.Select(ruleFilter => new DuplicatesRuleFilterDTO {
					ColumnName = ruleFilter.ColumnName,
					SchemaName = ruleFilter.SchemaName,
					RootSchemaColumns = ruleFilter.RootSchemaColumns,
					IsDetail = ruleFilter.SchemaName != duplicatesRule.SchemaName
				});
			}
			Log.ErrorFormat("Error during retrieving rule, rule id {0}", ruleId);
			return null;
		}

		/// <inheritdoc cref="IDuplicatesRuleManager.GetBulkDuplicatesRules"/>
		public IEnumerable<DuplicatesRuleDTO> GetBulkDuplicatesRules(string schemaName)
		{
			return GetAllDuplicatesRules()
					.Where(rule => rule.SchemaName == schemaName && rule.IsActive &&
						(string.IsNullOrEmpty(rule.SearchSchemaName) || rule.SearchSchemaName == schemaName));
		}

		#endregion

	}

	#endregion

}
