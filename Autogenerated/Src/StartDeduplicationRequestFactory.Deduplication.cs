namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using DeduplicationElastic.Domain.Deduplication.Rule;
	using DeduplicationElastic.WebApi.Contracts.Requests;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: StartDeduplicationRequestFactory

	/// <summary>
	/// Default implementation of <see cref="IStartDeduplicationRequestFactory"/>
	/// </summary>
	[DefaultBinding(typeof(IStartDeduplicationRequestFactory))]
	public class StartDeduplicationRequestFactory : IStartDeduplicationRequestFactory
	{

		#region Fields: Private

		private readonly ISearchColumnNameProvider _searchColumnNameProvider;
		private readonly IDuplicatesRuleManager _duplicatesRuleManager;

		#endregion

		#region Constructors: Public

		public StartDeduplicationRequestFactory(UserConnection userConnection) {
			var userConnectionConstructorArgument = new ConstructorArgument("userConnection", userConnection);
			_searchColumnNameProvider = ClassFactory.Get<ISearchColumnNameProvider>(
				userConnectionConstructorArgument);
			_duplicatesRuleManager = ClassFactory.Get<IDuplicatesRuleManager>(
				userConnectionConstructorArgument);
		}

		#endregion

		#region Methods: Private

		private IEnumerable<DeduplicationRule> GetDeduplicationRules(string sectionName,
				IEnumerable<DuplicatesRuleDTO> duplicateRules) {
			foreach (var duplicateRule in duplicateRules) {
				var ruleBody = duplicateRule.RuleBody;
				if (ruleBody != null) {
					yield return GetDeduplicationRule(sectionName, ruleBody);
				}
			}
		}

		private SearchColumn GetSearchColumnFromFilter(string rootSchemaName,
				DuplicatesRuleFilter duplicatesRuleFilter) {
			return new SearchColumn
			{
				ColumnName = duplicatesRuleFilter.ColumnName,
				SchemaName = duplicatesRuleFilter.SchemaName,
				ReferenceSchemaName = rootSchemaName,
				Type = duplicatesRuleFilter.Type
			};
		}

		private DeduplicationRule GetDeduplicationRule(string sectionName,
				DuplicatesRuleBody duplicatesRuleBody) {
			var filters = duplicatesRuleBody.Filters;
			if (filters == null || filters.Count == 0) {
				return null;
			}
			var columns = new List<string>();
			foreach (var filter in filters) {
				var searchColumn = GetSearchColumnFromFilter(sectionName, filter);
				var searchColumnName = _searchColumnNameProvider.GetSearchColumnName(searchColumn);
				columns.Add(searchColumnName);
			}
			return new DeduplicationRule(columns);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IStartDeduplicationRequestFactory.Build"/>
		public StartDeduplicationRequest CreateStartDeduplicationRequest(string sectionName,
				string indexName) {
			var bulkDuplicatesRules = _duplicatesRuleManager.GetBulkDuplicatesRules(sectionName);
			var rules = GetDeduplicationRules(sectionName, bulkDuplicatesRules)
				.Where(rule=>rule!=null).ToList();
			if (rules.Count == 0) {
				throw new Exception("There is no eligible rules");
			}
			return new StartDeduplicationRequest
			{
				IndexName = indexName,
				SourceEntityName = sectionName,
				Rules = rules
			};
		}

		#endregion

	}

	#endregion
}
