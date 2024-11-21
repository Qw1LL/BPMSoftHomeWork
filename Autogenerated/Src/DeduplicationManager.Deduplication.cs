namespace BPMSoft.Configuration.Deduplication
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using BPMSoft.Monitoring;
	using DuplicatesCollection =
		System.Collections.Generic.IEnumerable<System.Collections.Generic.Dictionary<string, string>>;

	#region class: DeduplicationManager

	/// <summary>
	/// Provides methods for searching duplicates and similar records.
	/// </summary>
	public class DeduplicationManager : IDeduplicationManager
	{

		#region Constants: Private

		private const string DuplicationSearchDurationMetricName = "duplication_search_duration";

		#endregion

		#region Fields: Private

		private readonly ISearchProvider _searchProvider;
		private readonly IMetricReporter _metricReporter;
		private readonly IDuplicatesRuleManager _duplicatesRuleManager;
		private readonly IDeduplicationSearchQueryBuilder _deduplicationSearchQueryBuilder;
		private readonly IFindSimilarRecordsRequestBuilder _findSimilarRecordsRequestBuilder;

		#endregion

		#region Constructors: Public

		public DeduplicationManager(
			ISearchProvider searchProvider,
			IMetricReporter metricReporter,
			IDuplicatesRuleManager duplicatesRuleManager,
			IDeduplicationSearchQueryBuilder deduplicationSearchQueryBuilder,
			IFindSimilarRecordsRequestBuilder findSimilarRecordsRequestBuilder) {
			_searchProvider = searchProvider;
			_metricReporter = metricReporter;
			_duplicatesRuleManager = duplicatesRuleManager;
			_deduplicationSearchQueryBuilder = deduplicationSearchQueryBuilder;
			_findSimilarRecordsRequestBuilder = findSimilarRecordsRequestBuilder;
		}

		#endregion

		#region Methods: Private

		private DuplicatesCollection FindSimilarRecords(
			ICollection<DuplicatesRuleDTO> duplicatesRules,
			FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			if (duplicatesRules.Count == 0) {
				return null;
			}
			var searchQuery = _deduplicationSearchQueryBuilder
				.BuildSearchQuery(duplicatesRules, findDuplicatesOnSaveRequest);
			return searchQuery == null ? null : _searchProvider.Search(searchQuery);
		}

		private IEnumerable<DuplicatesRuleDTO> GetEntityRules(FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			if (findDuplicatesOnSaveRequest.Rules?.Any() == true) {
				return findDuplicatesOnSaveRequest.Rules;
			} else if (findDuplicatesOnSaveRequest.Type == DuplicatesRuleType.OnlyActive) {
				return _duplicatesRuleManager.GetBulkDuplicatesRules(findDuplicatesOnSaveRequest.SchemaName);
			} else {
				return _duplicatesRuleManager.GetDuplicatesRules(findDuplicatesOnSaveRequest.SchemaName);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDeduplicationManager.FindDuplicates"/>
		public DuplicatesCollection FindDuplicates(FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			var timer = new Stopwatch();
			try {
				timer.Start();
				var entityRules = GetEntityRules(findDuplicatesOnSaveRequest);
				return FindSimilarRecords(entityRules.ToList(), findDuplicatesOnSaveRequest);
			}
			finally {
				timer.Stop();
				_metricReporter.Gauge(DuplicationSearchDurationMetricName, timer.ElapsedMilliseconds);
			}
		}

		/// <inheritdoc cref="IDeduplicationManager.FindSimilarRecordsFromStored"/>
		public DuplicatesCollection FindSimilarRecordsFromStored(FindSimilarRecordsFromStoredRequest request) {
			var entityRules = request.SchemaName == request.SourceSchemaName
				? _duplicatesRuleManager.GetDuplicatesRules(request.SchemaName)
				: _duplicatesRuleManager.GetDuplicatesRules(request.SourceSchemaName, request.SchemaName);
			var searchSimilarRecordsRequest = _findSimilarRecordsRequestBuilder.BuildRequest(request);
			return FindSimilarRecords(entityRules.ToList(), searchSimilarRecordsRequest);
		}

		#endregion

	}

	#endregion

}
