namespace BPMSoft.Configuration.Deduplication
{
	using System.Collections.Generic;
	using System.Linq;

	#region Class: DeduplicationSearchQueryBuilder

	/// <summary>
	/// Search query builder for deduplication request.
	/// </summary>
	public class DeduplicationSearchQueryBuilder : IDeduplicationSearchQueryBuilder
	{

		#region Methods: Private

		private SearchQueryFilter BuildSearchQueryFilter(DuplicatesRuleFilter duplicatesRuleFilter,
				List<DuplicatesColumnData> model) {
			var schemaColumns = model.Where(column => column.SchemaName == duplicatesRuleFilter.SchemaName);
			DuplicatesColumnData modelColumn;
			if (string.IsNullOrEmpty(duplicatesRuleFilter.Type)) {
				modelColumn = schemaColumns.FirstOrDefault(column => column.ColumnName == duplicatesRuleFilter.ColumnName
					&& string.IsNullOrEmpty(column.Type));
			} else {
				modelColumn = schemaColumns.FirstOrDefault(column => column.Type == duplicatesRuleFilter.Type);
			}
			if (modelColumn?.Value == null || modelColumn.Value.FirstOrDefault(value =>!string.IsNullOrEmpty(value)) == null) {
				return null;
			} else {
				return new SearchQueryFilter {
					SchemaName = duplicatesRuleFilter.SchemaName,
					ColumnName = duplicatesRuleFilter.ColumnName,
					Type = duplicatesRuleFilter.Type,
					Value = modelColumn.Value.Where(value => !string.IsNullOrEmpty(value)).ToList()
				};
			}
		}

		private SearchQueryRule BuildSearchQueryRule(DuplicatesRuleDTO rule, List<DuplicatesColumnData> model, string schemaName) {
			if (rule.RuleBody == null) {
				return null;
			}
			var ruleBody = rule.RuleBody;
			if (string.IsNullOrEmpty(ruleBody.RootSchemaName) || ruleBody.RootSchemaName == schemaName) {
				var searchQueryRule = new SearchQueryRule {
					Filters = new List<SearchQueryFilter>()
				};
				foreach(var ruleFiler in ruleBody.Filters) {
					var searchQueryFilter = BuildSearchQueryFilter(ruleFiler, model);
					if (searchQueryFilter != null) {
						searchQueryRule.Filters.Add(searchQueryFilter);
					} else {
						return null;
					}
				}
				return searchQueryRule;
			}
			return null;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDeduplicationSearchQueryBuilder.BuildSearchQuery"/>
		public SearchQuery BuildSearchQuery(
			IEnumerable<DuplicatesRuleDTO> rules,
			FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			var model = findDuplicatesOnSaveRequest.Model;
			var schemaName = findDuplicatesOnSaveRequest.SchemaName;
			var searchQueryRules = rules.Select(rule => BuildSearchQueryRule(rule, model, schemaName))
				.Where(searchQueryRule => searchQueryRule != null)
				.ToList();
			if (searchQueryRules.Count == 0) {
				return null;
			}
			return new SearchQuery {
				From = findDuplicatesOnSaveRequest.From,
				Size = findDuplicatesOnSaveRequest.Size,
				Rules = searchQueryRules,
				Columns = findDuplicatesOnSaveRequest.Columns,
				SchemaName = findDuplicatesOnSaveRequest.SchemaName,
				PrimaryColumnValue = findDuplicatesOnSaveRequest.PrimaryColumnValue
			};
		}

		#endregion

	}

	#endregion

}
