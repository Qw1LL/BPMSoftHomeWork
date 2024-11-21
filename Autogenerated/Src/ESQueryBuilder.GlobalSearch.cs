namespace BPMSoft.Configuration.GlobalSearch
{
	using System.Collections.Generic;
	using global::Common.Logging;
	using Nest;
	using BPMSoft.Core;
	using BPMSoft.ElasticSearch;

	#region Class: ESQueryBuilder

	/// <summary>
	/// Elastic search query builder.
	/// </summary>
	public class ESQueryBuilder : IESQueryBuilder
	{

		#region Fields: Private

		private string _schemaName;
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");
		private readonly ISearchColumnNameProvider _searchColumnNameProvider;

		#endregion

		#region Properties: Protected

		protected virtual int DefaultFrom => 0;

		protected virtual int DefaultSize => 100;

		protected virtual int MinimumShouldMatchPercentage => 100;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Last builded match query.
		/// </summary>
		private MatchQuery _lastBuildedMatchQuery;
		public MatchQuery LastBuildedMatchQuery => _lastBuildedMatchQuery;

		#endregion

		#region Constructors: Public

		public ESQueryBuilder(ISearchColumnNameProvider searchColumnNameProvider) {
			_searchColumnNameProvider = searchColumnNameProvider;
		}

		#endregion

		#region Methods: Private

		private SearchColumn GetSearchColumn(SearchQueryFilter filter) {
			return new SearchColumn {
				ColumnName = filter.ColumnName,
				ReferenceSchemaName = _schemaName,
				SchemaName = filter.SchemaName,
				Type = filter.Type
			};
		}

		private MatchQuery BuildMatchQuery(SearchQueryFilter filter, string value) {
			var searchColumn = GetSearchColumn(filter);
			var columnName = _searchColumnNameProvider.GetSearchColumnName(searchColumn);
			var matchQuery = new MatchQuery {
				Query = value,
				MinimumShouldMatch = MinimumShouldMatch.Percentage(MinimumShouldMatchPercentage),
				Field = new Field(columnName)
			};
			_lastBuildedMatchQuery = matchQuery;
			return matchQuery;
		}

		private QueryContainer BuildFilterQuery(SearchQueryFilter filter) {
			var valuesCollection = filter.Value;
			using (var valueEnumerator = valuesCollection.GetEnumerator()) {
				valueEnumerator.MoveNext();
				var currentValue = valueEnumerator.Current;
				var filterQuery = new QueryContainer();
				if (currentValue != null) {
					filterQuery = BuildMatchQuery(filter, currentValue);
				}
				while (valueEnumerator.MoveNext()) {
					currentValue = valueEnumerator.Current;
					if (currentValue != null) {
						filterQuery = filterQuery || BuildMatchQuery(filter, currentValue);
					}
				}
				return filterQuery;
			}
		}

		private QueryContainer BuildSingleRuleContainer(SearchQueryRule rule) {
			var filters = rule.Filters;
			using (var filterEnumerator = filters.GetEnumerator()) {
				filterEnumerator.MoveNext();
				var currentFilter = filterEnumerator.Current;
				var resultContainer = BuildFilterQuery(currentFilter);
				while (filterEnumerator.MoveNext()) {
					currentFilter = filterEnumerator.Current;
					resultContainer = resultContainer && BuildFilterQuery(currentFilter);
				}
				return resultContainer;
			}
		}

		private QueryContainer BuildQueryContainer(List<SearchQueryRule> rules) {
			using (var rulesEnumerator = rules.GetEnumerator()) {
				rulesEnumerator.MoveNext();
				var currentRule = rulesEnumerator.Current;
				if (currentRule == null) {
					_log.Error("There is no rules in this request");
					return null;
				}
				var resultContainer = BuildSingleRuleContainer(currentRule);
				while (rulesEnumerator.MoveNext()) {
					currentRule = rulesEnumerator.Current;
					resultContainer = resultContainer || BuildSingleRuleContainer(currentRule);
				}
				return resultContainer;
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IESQueryBuilder.BuildQuery"/>
		public PageableElasticQuery BuildQuery(SearchQuery searchQuery) {
			_schemaName = searchQuery.SchemaName;
			var queryContainer = BuildQueryContainer(searchQuery.Rules);
			if (queryContainer != null) {
				return new PageableElasticQuery {
					From = searchQuery.From ?? DefaultFrom,
					Size = searchQuery.Size ?? DefaultSize,
					DocumentName = searchQuery.SchemaName,
					QueryContainer = queryContainer
				};
			}
			return null;
		}

		#endregion

	}

	#endregion

}
