namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: FindSimilarRecordsRequestBuilder

	/// <summary>
	/// Default implementation of the <see cref="IFindSimilarRecordsRequestBuilder"/> interface.
	/// </summary>
	/// <seealso cref="IFindSimilarRecordsRequestBuilder"/>
	[DefaultBinding(typeof(IFindSimilarRecordsRequestBuilder))]
	public class FindSimilarRecordsRequestBuilder : IFindSimilarRecordsRequestBuilder
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IDuplicatesRuleManager _duplicatesRuleManager;

		#endregion

		#region Constructors: Public

		public FindSimilarRecordsRequestBuilder(
			UserConnection userConnection,
			IDuplicatesRuleManager duplicatesRuleManager) {
			_userConnection = userConnection;
			_duplicatesRuleManager = duplicatesRuleManager;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<Guid> GetColumnUIds(List<DuplicatesRuleFilter> duplicatesRuleFilters) {
			foreach (var rule in duplicatesRuleFilters) {
				if (Guid.TryParse(rule.SourceColumnUId, out Guid sourceColumnUId)) {
					yield return sourceColumnUId;
				}
			}
		}

		private Entity GetSourceEntity(Guid id, string schemaName, IEnumerable<Guid> columnUIds) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName) {
				UseAdminRights = false
			};
			foreach (var columnUid in columnUIds) {
				esq.AddColumn(entitySchema.Columns.FindByUId(columnUid).Name);
			}
			var systemUserConnection = _userConnection.AppConnection?.SystemUserConnection ?? _userConnection;
			return esq.GetEntity(systemUserConnection, id);
		}

		private List<DuplicatesRuleFilter> GetDuplicatesRuleFilters(string schemaName, string sourceSchemaName) {
			var similarEntitiesRules = _duplicatesRuleManager.GetDuplicatesRules(sourceSchemaName, schemaName);
			var result = new HashSet<DuplicatesRuleFilter>();
			foreach (var rule in similarEntitiesRules) {
				var ruleBody = rule.RuleBody;
				foreach (var filter in ruleBody.Filters) {
					result.Add(filter);
				}
			}
			return result.ToList();
		}

		private string GetColumnDataKey(DuplicatesRuleFilter ruleFilter) {
			var resultPrefix = ruleFilter.SchemaName;
			var resultSufix = ruleFilter.ColumnName ?? ruleFilter.Type;
			return $"{resultPrefix}#{resultSufix}";
		}

		private List<DuplicatesColumnData> GetRequestModel(Entity sourceEntity,
				List<DuplicatesRuleFilter> duplicatesRuleFilters) {
			var duplicatesColumnDictionary = new Dictionary<string, DuplicatesColumnData>();
			foreach(var filter in duplicatesRuleFilters) {
				if (Guid.TryParse(filter.SourceColumnUId, out Guid sourceColumnUId)) {
					var column = sourceEntity.Schema.Columns.FindByUId(sourceColumnUId);
					var columnDataKey = GetColumnDataKey(filter);
					var columnValue = sourceEntity.GetColumnDisplayValue(column);
					if (duplicatesColumnDictionary.ContainsKey(columnDataKey)) {
						var duplicateColumn = duplicatesColumnDictionary[columnDataKey];
						duplicateColumn.Value.Add(columnValue);
					} else {
						var columnData = new DuplicatesColumnData {
							SchemaName = filter.SchemaName,
							ColumnName = filter.ColumnName,
							Type = filter.Type,
							Value = new List<string> {columnValue}
						};
						duplicatesColumnDictionary.Add(columnDataKey, columnData);
					}
				}
			}
			return duplicatesColumnDictionary.Values.ToList();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IFindSimilarRecordsRequestBuilder.BuildRequest(FindSimilarRecordsFromStoredRequest)"/>
		public FindDuplicatesRequest BuildRequest(FindSimilarRecordsFromStoredRequest findSimilarRecordsFromStoredRequest) {
			var filters = GetDuplicatesRuleFilters(findSimilarRecordsFromStoredRequest.SchemaName,
				findSimilarRecordsFromStoredRequest.SourceSchemaName);
			var sourceColumnUids = GetColumnUIds(filters);
			var sourceEntity = GetSourceEntity(findSimilarRecordsFromStoredRequest.SourceId,
				findSimilarRecordsFromStoredRequest.SourceSchemaName, sourceColumnUids);
			var requestModel = GetRequestModel(sourceEntity, filters);
			var result = new FindDuplicatesRequest {
				SchemaName = findSimilarRecordsFromStoredRequest.SchemaName,
				Columns = new List<string> { "Id" },
				Model = requestModel
			};
			return result;
		}

		/// <inheritdoc cref="IFindSimilarRecordsRequestBuilder.BuildRequest(UserConnection, FindSimilarRecordsFromStoredRequest)"/>
		[Obsolete("7.12.4 | Method is deprecated. Use IFindSimilarRecordsRequestBuilder.BuildRequest(FindSimilarRecordsFromStoredRequest)")]
		public FindDuplicatesRequest BuildRequest(UserConnection userConnection,
			FindSimilarRecordsFromStoredRequest findSimilarRecordsFromStoredRequest) {
			return BuildRequest(findSimilarRecordsFromStoredRequest);
		}

		#endregion

	}

	#endregion

}
