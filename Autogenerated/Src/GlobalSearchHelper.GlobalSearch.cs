namespace BPMSoft.Configuration.GlobalSearchHelper
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using global::Common.Logging;
	using BPMSoft.Configuration.GlobalSearchDto;
	using BPMSoft.Core;
	using BPMSoft.GlobalSearch;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using EntitySchemaColumn = BPMSoft.Core.Entities.EntitySchemaColumn;
	using BPMSoft.Configuration.GlobalSearchColumnUtils;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Store;
	using EntityCollection = BPMSoft.Core.Entities.EntityCollection;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using BPMSoft.Monitoring;
	using System.Diagnostics;
	using BPMSoft.GlobalSearch.Monitoring;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Configuration;

	#region Class: GlobalSearchHelper

	public class GlobalSearchHelper
	{

		#region Constants: Private

		private const int AdditionalRecordsCount = 20;
		private const string FileEntityNameSuffix = "File";
		private const string LeadFileEntityName = "FileLead";

		#endregion

		#region Fields: Private

		private string _entityName;
		private EntitySchema _entitySchema;
		private GlobalSearchColumnUtils _globalSearchColumnUtils;
		private readonly Regex _replaceHighlightRegex = new Regex(@"[{}]");
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");
		private readonly string[] _defaultScoreSectionNames = { "Contact", "Account" };
		private IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();

		#endregion

		#region Properties: Private
		private int ShouldMatchPercent {
			get {
				return Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchShouldMatchPercent", 0);
			}
		}
		private bool UseInexactSearch {
			get {
				return Core.Configuration.SysSettings.GetValue(UserConnection, "UseInexactGlobalSearch", false);
			}
		}

		private bool UseLocalizableGlobalSearchResult {
			get {
				return Core.Configuration.SysSettings.GetValue(UserConnection, "UseLocalizableGlobalSearchResult", false);
			}
		}

		private int PrimaryColumnDefaultWeight {
			get {
				return Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchDefaultPrimaryColumnWeight", 5);
			}
		}

		private int EntityDefaultWeight {
			get {
				return Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchDefaultEntityWeight", 2);
			}
		}

		private GlobalSearchColumnUtils GlobalSearchColumnUtils {
			get {
				if (_globalSearchColumnUtils == null) {
					_globalSearchColumnUtils = ClassFactory.Get<GlobalSearchColumnUtils>();
				}
				return _globalSearchColumnUtils;
			}
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the class <see cref="GlobalSearchHelper"/>,
		/// using the specified user connection.</summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public GlobalSearchHelper(UserConnection userConnection) {
			this.UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private KeyValuePair<string, List<string>> PrepareRightsCondition(ESSearchResponse esResponse, string entityName, List<string> listOfRecordsId) {
			var conditions = new Dictionary<string, List<string>> {
				{entityName, listOfRecordsId}
			};
			if (GetIsFileEntity(entityName) && !UserConnection.DBSecurityEngine.GetSchemaUseMasterRecordRights(entityName)) {
				conditions = PrepareFileRightsConditions(esResponse, conditions);
			}
			return conditions.First();
		}

		private Dictionary<string, List<string>> PrepareFileRightsConditions(ESSearchResponse esResponse, Dictionary<string, List<string>> conditions) {
			var entityName = conditions.First().Key;
			var listOfIds = conditions.First().Value;
			var parentEntityName = entityName.Replace(FileEntityNameSuffix, "");
			var parentEntity = UserConnection.EntitySchemaManager.FindInstanceByName(parentEntityName);
			if (parentEntity != null) {
				try {
					var currentFileHits = esResponse.SearchResult.Hits.Where(x => listOfIds.Contains(x.Id)).ToList();
					EntitySchema fileSchema = UserConnection.EntitySchemaManager.FindInstanceByName(entityName);
					var column = fileSchema.Columns.FindByName(parentEntityName);
					if (column != null) {
						var masterPrimaryColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, entityName);
						return new Dictionary<string, List<string>> {
							{parentEntityName, currentFileHits
								.Where(x=>x.Source.ContainsKey(masterPrimaryColumnAlias))
								.Select(x => x.Source[masterPrimaryColumnAlias]).ToList()}
						};
					}
				} catch (Exception ex) {
					_log.ErrorFormat(@"Entity name: {0}, Identifiers: {1} 
						Exception: {2}", entityName, string.Join(", ", listOfIds), ex.Message);
				}
			}
			return conditions;
		}

		private void AppendAvailableRecordIds(List<string> availableRecordIdentifiers, EntityCollection rightsCollection,
			string entityName, ESSearchResponse esResponse) {
			if (GetIsFileEntity(entityName)) {
				var availableIds = rightsCollection.Select(e => e.PrimaryColumnValue.ToString().ToLower());
				try {
					EntitySchema fileSchema = UserConnection.EntitySchemaManager.FindInstanceByName(entityName);
					var parentColumnName = entityName.Replace(FileEntityNameSuffix, "");
					var column = fileSchema.Columns.FindByName(parentColumnName);
					if (column != null) {
						var masterPrimaryColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, entityName);
						var availableFileHits =
							UserConnection.DBSecurityEngine.GetSchemaUseMasterRecordRights(entityName) ?
								esResponse.SearchResult.Hits.Where(
									x => x.Type == entityName && availableIds.Contains(x.Id.ToLower())).ToList() :
								esResponse.SearchResult.Hits.Where(
									x => x.Source.ContainsKey(masterPrimaryColumnAlias)
									     && x.Type == entityName
									     && availableIds.Contains(x.Source[masterPrimaryColumnAlias].ToLower())).ToList();
						availableRecordIdentifiers.AddRange(availableFileHits.Select(x => x.Id.ToLower()));
					}
				} catch (Exception ex) {
					_log.ErrorFormat(@"Entity name: {0}, Identifiers: {1} 
						Exception: {2}", entityName, string.Join(", ", availableIds), ex.Message);
				}
				return;
			}
			availableRecordIdentifiers.AddRange(rightsCollection
					.Select(e => e.PrimaryColumnValue.ToString().ToLower()));
		}

		private bool GetIsFileEntity(string entityName) {
			return entityName.EndsWith(FileEntityNameSuffix) || entityName == LeadFileEntityName;
		}

		private BpmSearchResponseEntity FillBpmResponseEntity(ESHit esHit) {
			_entityName = esHit.Type;
			_entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(_entityName);
			var responseEntity = new BpmSearchResponseEntity {
				Id = esHit.Id,
				EntityName = _entityName,
				ColumnValues = new Dictionary<string, object>(),
				FoundColumns = new Dictionary<string, string[]>()
			};
			var columnValues = responseEntity.ColumnValues;
			var foundColumns = responseEntity.FoundColumns;
			var availableColumns = GetAvailableColumnsCollection(_entityName);
			if (UseLocalizableGlobalSearchResult) {
				var entityValues = GetLocalizableEntityValues(_entitySchema, Guid.Parse(esHit.Id), availableColumns);
				foreach (var column in availableColumns) {
					columnValues.Add(column.Name, entityValues[column.Name]);
					AddHighlights(esHit, column, foundColumns, columnValues);
				}
			} else {
				foreach (var column in availableColumns) {
					if (column.IsLookupType) {
						AddLookupColumnValue(esHit, column, columnValues);
					} else {
						AddColumnValue(esHit, column, columnValues);
					}
					AddHighlights(esHit, column, foundColumns, columnValues);
				}
			}
			AddDetailsHighlight(responseEntity, esHit);
			return responseEntity;
		}

		private Dictionary<string, object> GetLocalizableEntityValues(EntitySchema entitySchema,
			Guid recordId,
			IEnumerable<EntitySchemaColumn> availableColumns) {
			var esq = new EntitySchemaQuery(entitySchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var serverClientColumnMap = new Dictionary<string, string>();
			foreach (var c in availableColumns) {
				esq.AddColumn(c.Name);
				serverClientColumnMap.Add(c.Name, c.Name);
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				esq.RootSchema.GetPrimaryColumnName(), recordId));
			return Nui.ServiceModel.Extensions.QueryExtension
				.GetEntityCollection(esq.GetEntityCollection(UserConnection), serverClientColumnMap)
				.First();
		}

		private void AddDetailsHighlight(BpmSearchResponseEntity responseEntity, ESHit esHit) {
			var highlights = esHit.Highlight;
			if (highlights != null) {
				var detailsHighlights = esHit.Highlight.Where(s => s.Key.StartsWith(ESConstants.DetailsPrefix)
					&& !s.Key.EndsWith("id"));
				IEnumerable<IGrouping<string, string[]>> groupedDetailsHighlights =
					detailsHighlights.GroupBy(x => GetDetailNameByKey(x.Key), x => x.Value);
				foreach (var detailsHighlight in groupedDetailsHighlights) {
					var detailEntityName = detailsHighlight.Key.Replace(string.Format("{0}.", ESConstants.DetailsPrefix), "");
					var highlightValues = detailsHighlight.Select(x => string.Join(" ... ", x)).ToArray();
					var detailCaption = GetDetailCaption(detailEntityName);
					responseEntity.FoundColumns.Add(detailEntityName, GetHighLightMathces(highlightValues));
					responseEntity.ColumnValues.Add(detailEntityName, new {
						caption = detailCaption,
						displayValue = _replaceHighlightRegex.Replace(string.Join(" ... ", highlightValues), "")
					});
				}
			}
		}

		/// <summary>
		/// Gets detail name by key with suffix.
		/// </summary>
		/// <param name="keyWithSuffix">Key name with suffix.</param>
		/// <returns>Detail name.</returns>
		private string GetDetailNameByKey(string keyWithSuffix) {
			Regex detailPattern = new Regex("^([^.]+\\.[^.]+)\\..*$");
			var key = detailPattern.Replace(keyWithSuffix, "$1");
			Regex detailSuffixPattern = new Regex("^([^_]+)_.*$");
			return detailSuffixPattern.Replace(key, "$1");
		}

		private string GetDetailCaption(string detailName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysDetail");
			esq.IsDistinct = true;
			esq.Cache = UserConnection.SessionCache.WithLocalCaching("GlobalSearchDetails");
			esq.CacheItemName = "GlobalSearchDetailList";
			var captionColumn = esq.AddColumn("Caption");
			var nameColumn = esq.AddColumn("[SysSchema:UId:EntitySchemaUId].Name");
			var collection = esq.GetEntityCollection(UserConnection);
			var detailEntity = collection.FirstOrDefault(x => x.GetTypedColumnValue<string>(nameColumn.Name) == detailName);
			return detailEntity != null ? detailEntity.GetTypedColumnValue<string>(captionColumn.Name) : "Unknown detail";
		}

		private void AddHighlights(ESHit esHit, EntitySchemaColumn column, Dictionary<string, string[]> foundColumns,
			Dictionary<string, object> columnValues) {
			var columnName = column.Name;
			var highlight = GetColumnHighlight(esHit, column);
			if (highlight != null && highlight.Length > 0) {
				foundColumns[columnName]  = highlight;
				if (!columnValues.ContainsKey(columnName)) {
					AppendAdditionalHighLightColumn(columnValues, esHit, column);
				}
			}
		}

		private void AddColumnValue(ESHit esHit, EntitySchemaColumn column, Dictionary<string, object> columnValues) {
			var value = GetColumnValue(esHit, column);
			if (!string.IsNullOrEmpty(value)) {
				columnValues[column.Name] = value;
			}
		}

		private void AddLookupColumnValue(ESHit esHit, EntitySchemaColumn column, Dictionary<string, object> columnValues) {
			var lookupValue = GetLookupColumnValue(esHit, column);
			if (lookupValue != null) {
				columnValues[column.Name] = lookupValue;
			}
		}

		private string[] GetColumnHighlight(ESHit esHit, EntitySchemaColumn column) {
			string[] result = new string[0];
			if (esHit.Highlight != null) {
				var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
				var columnHighlightValue = esHit.Highlight.FirstOrDefault(x => string.Equals(x.Key, columnAlias)).Value;
				if (columnHighlightValue == null) {
					return result;
				}
				result = GetHighLightMathces(columnHighlightValue);
			}
			return result;
		}

		private string[] GetHighLightMathces(string[] columnHighlightValue) {
			var highlightPattern = string.Format("{0}(.*?){1}", Regex.Escape("{{{"), Regex.Escape("}}}"));
			var regexp = new Regex(highlightPattern);
			var matches = regexp.Matches(string.Join("", columnHighlightValue));
			return matches.Cast<Match>().Select(m => _replaceHighlightRegex.Replace(m.Value, "")).ToArray();
		}

		private void AppendAdditionalHighLightColumn(Dictionary<string, object> columnValues, ESHit esHit, EntitySchemaColumn column) {
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
			var columnHighlightValue = esHit.Highlight.FirstOrDefault(x => string.Equals(x.Key, columnAlias)).Value;
			if (columnHighlightValue != null) {
				columnValues.Add(column.Name, _replaceHighlightRegex.Replace(string.Join("...", columnHighlightValue), ""));
			}
		}

		private LookupColumnValue GetLookupColumnValue(ESHit esHit, EntitySchemaColumn column) {
			LookupColumnValue resultValue = null;
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
			string displayValue = esHit.Source.FirstOrDefault(x => string.Equals(x.Key, columnAlias)).Value;
			if (!string.IsNullOrEmpty(displayValue)
				|| GlobalSearchColumnUtils.GetIsSysImageLookupColumn(column)) {
				var displayColumnAlias = GlobalSearchColumnUtils.GetPrimaryColumnAlias(column, _entityName);
				resultValue = new LookupColumnValue {
					Value = esHit.Source.FirstOrDefault(x => string.Equals(x.Key, displayColumnAlias)).Value,
					DisplayValue = displayValue
				};
				var imageColumn = column.ReferenceSchema.PrimaryImageColumn;
				if (imageColumn != null && imageColumn.DataValueType is ImageLookupDataValueType) {
					var priamaryImageColumnAlias = GlobalSearchColumnUtils.GetPrimaryImageColumnAlias(column, _entityName);
					resultValue.PrimaryImageValue = esHit.Source
						.FirstOrDefault(x => string.Equals(x.Key, priamaryImageColumnAlias)).Value;
				}
			}
			return resultValue;
		}

		private string GetColumnValue(ESHit esHit, EntitySchemaColumn column) {
			var columnAlias = GlobalSearchColumnUtils.GetAlias(column, _entitySchema);
			return esHit.Source.FirstOrDefault(x => string.Equals(x.Key, columnAlias,
				StringComparison.InvariantCultureIgnoreCase)).Value;

		}

		private SearchRequestQuery GetDefaultSearchRequestQuery(int countRecord, int pageNum, int from) {
			var size = countRecord + AdditionalRecordsCount;
			var searchRequestQuery = new SearchRequestQuery {
				From = from + pageNum * size,
				Size = size,
				Source = new ESSource(),
				Highlight = new EShighlight()
			};
			return searchRequestQuery;
		}

		private HashSet<string> GetQueryFields(bool exactQuery) {
			var allField = exactQuery ? string.Format("{0}^5", ESConstants.AllField) : ESConstants.AllField;
			var fields = new HashSet<string> { allField, String.Format("*{0}^10", ESConstants.NumberColumnSuffix) };
			fields.Add($"*{ESConstants.PrimaryColumnsSuffix}^5");
			fields.Add($"{ESConstants.TextDetailColumnsPattern}^5");
			return fields;
		}

		private void ApplySectionScoreSettings(string sectionEntityName, List<ESMultiMatchQuery> multiMatchQueries,
			EntitySchema currentSectionEntity, List<ESFunction> functions) {
			foreach (var esMultiMatchQuery in multiMatchQueries) {
				AppendDefaultPrimaryColumnField(currentSectionEntity, esMultiMatchQuery);
			}
			AppendDefaultFunction(functions, sectionEntityName);
		}

		private List<ESMultiMatchQuery> GetMultiMatchQueries(string query) {
			var multiMatchQueries = new List<ESMultiMatchQuery>();
			if (UseInexactSearch) {
				multiMatchQueries.Add(new ESMultiMatchQuery {
					Query = query,
					Fields = GetQueryFields(false),
					MinimumShouldMatch = ShouldMatchPercent == 0
						? ESConstants.MinShouldMatch
						: $"{ShouldMatchPercent}%"
				});
			} else {
				multiMatchQueries.Add(new ESMultiMatchQuery
				{
					Query = query,
					Type = "cross_fields",
					Operator = "and",
					Fields = GetQueryFields(true)
				});
			}
			return multiMatchQueries;
		}

		private void AppendDefaultPrimaryColumnField(EntitySchema entitySchema, ESMultiMatchQuery multiMatchQuery) {
			var primaryColumn = entitySchema.PrimaryDisplayColumn;
			if (primaryColumn != null) {
				var alias = GlobalSearchColumnUtils.GetAlias(primaryColumn, entitySchema);
				if (!multiMatchQuery.Fields.Any(x => x.Contains(alias))) {
					multiMatchQuery.Fields.Add(string.Format("{0}^{1}", alias, PrimaryColumnDefaultWeight));
				}
			}
		}

		private void AppendDefaultFunction(List<ESFunction> functions, string sectionEntityName) {
			functions.Add(new ESFunction { Type = sectionEntityName, Weight = EntityDefaultWeight });
		}

		private void AddFileItemToGroup(List<BpmSearchAggregation> group, ESAggregation esAggregation) {
			var fileItem = group.FirstOrDefault(x => x.TypeAlias == FileEntityNameSuffix);
			if (fileItem == null) {
				fileItem = new BpmSearchAggregation {
					Count = esAggregation.Count,
					TypeAlias = FileEntityNameSuffix,
					Type = esAggregation.Type
				};
				group.Add(fileItem);
				return;
			}
			fileItem.Count += esAggregation.Count;
			fileItem.Type += string.Format(",{0}", esAggregation.Type);
		}

		private ESScoreQuery GetSearchScoreQuery(string query, string sectionEntityName, bool useScoreSettings = true) {
			var functions = new List<ESFunction>();
			var multiMatchQueries = GetMultiMatchQueries(query);
			if (!useScoreSettings) {
				return new ESScoreQuery(functions, multiMatchQueries);
			}
			if (string.IsNullOrEmpty(sectionEntityName)) {
				ApplyDefaultScoreSettings(functions, multiMatchQueries);
				return new ESScoreQuery(functions, multiMatchQueries);
			}
			var currentSectionEntity = UserConnection.EntitySchemaManager.FindInstanceByName(sectionEntityName);
			if (currentSectionEntity != null) {
				ApplySectionScoreSettings(sectionEntityName, multiMatchQueries, currentSectionEntity, functions);
			}
			return new ESScoreQuery(functions, multiMatchQueries);
		}

		#endregion

		#region Methods: Protected


		/// <summary>
		/// Get available column colection.
		/// </summary>
		/// <param name="entityName"> entity schema name.</param>
		/// <returns><see cref="IEnumerable<EntitySchemaColumn>"/>.</returns>
		protected virtual IEnumerable<EntitySchemaColumn> GetAvailableColumnsCollection(string entityName) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
			return entitySchema.Columns
				.Where(column => CanReadColumn(entityName, column));
		}

		/// <summary>
		/// Check if can read column.
		/// </summary>
		/// <param name="schemaName"> entity schema name. </param>
		/// <param name="column"> column name. </param>
		/// <returns><see cref="bool"/>.</returns>
		protected virtual bool CanReadColumn(string schemaName, EntitySchemaColumn column) {
			var operation = UserConnection.DBSecurityEngine
						.GetEntitySchemaColumnRightLevel(schemaName, column.ColumnValueName, SchemaOperationRightLevels.CanRead);
			return operation != EntitySchemaColumnRightLevel.Deny;
		}

		/// <summary>
		/// Get aggregation groups.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance. </param>
		/// <returns><see cref="List<ESAggregation>"/> collection elastic search aggregation.</returns>
		protected virtual List<ESAggregation> GetEsAggregationGroups(ESAggregationResponse esAggsResponse) {
			return esAggsResponse.Aggregations.GroupedAggregations.Groups;
		}


		/// <summary>
		/// Get search response groups.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> search response. </param>
		/// <returns><see cref="IEnumerable<IGrouping<string, string>>>"/> grouped elastic search response.</returns>
		protected virtual IEnumerable<IGrouping<string, string>> GetEsSearchResponseGroups(ESSearchResponse esResponse) {
			return esResponse.SearchResult.Hits.GroupBy(x => x.Type, x => x.Id);
		}

		/// <summary>
		/// Get records with read rights.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> search response. </param>
		/// <returns><see cref="List<string>"/> grouped elastic search response.</returns>
		protected virtual List<string> GetAvailableRecordIdentifiers(ESSearchResponse esResponse) {
			IEnumerable<IGrouping<string, string>> groupedTypes = GetEsSearchResponseGroups(esResponse);
			List<string> availableRecordIdentifiers = new List<string>();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			foreach (var groupedType in groupedTypes) {
				var condition = PrepareRightsCondition(esResponse, groupedType.Key, groupedType.ToList());
				if (UserConnection.EntitySchemaManager.FindInstanceByName(condition.Key) == null || condition.Value.Count == 0) {
					_log.InfoFormat("Instance of entity with name {0} was not found while checking record permisiions.", condition.Key);
					continue;
				}
				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, condition.Key);
				esq.PrimaryQueryColumn.IsAlwaysSelect = true;
				foreach (string column in UserConnection.DBSecurityEngine.GetSchemaSignificantColumns(condition.Key)) {
					if (esq.RootSchema.Columns.FindByName(column) != null) {
						esq.AddColumn(column);
					}
				}
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					esq.PrimaryQueryColumn.Name, condition.Value));
				EntityCollection collection = esq.GetEntityCollection(UserConnection);
				AppendAvailableRecordIds(availableRecordIdentifiers, collection, groupedType.Key, esResponse);
			}
			sw.Stop();
			_metricReporter.Report(new SearchMetric { Duration = sw.ElapsedMilliseconds, Source = SearchSource.Bpm });
			return availableRecordIdentifiers;
		}

		/// <summary>
		/// Add default score settings.
		/// </summary>
		/// <param name="functions">.</param>
		/// <param name="multiMatchQueries">.</param>
		protected virtual void ApplyDefaultScoreSettings(List<ESFunction> functions, List<ESMultiMatchQuery> multiMatchQueries) {
			foreach (var defaultSectionName in _defaultScoreSectionNames) {
				AppendDefaultFunction(functions, defaultSectionName);
			}
			foreach (var esMultiMatchQuery in multiMatchQueries) {
				foreach (var defaultSectionName in _defaultScoreSectionNames) {
					var sectionEntity = UserConnection.EntitySchemaManager.FindInstanceByName(defaultSectionName);
					AppendDefaultPrimaryColumnField(sectionEntity, esMultiMatchQuery);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Process elastic search response.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> instance.</param>
		/// <returns><see cref="BpmSearchResponse"/> instance.</returns>
		[Obsolete("Use ProcessEsSearchResponse(esResponse)")]
		public virtual BpmSearchResponse ProccessEsSearchResponse(ESSearchResponse esResponse) {
			return ProcessEsSearchResponse(esResponse);
		}

		/// <summary>
		/// Process elastic search response.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> instance.</param>
		/// <returns><see cref="BpmSearchResponse"/> instance.</returns>
		public virtual BpmSearchResponse ProcessEsSearchResponse(ESSearchResponse esResponse) {
			var availableRecordIdentifiers = GetAvailableRecordIdentifiers(esResponse);
			BpmSearchResponse searchResponse = new BpmSearchResponse();
			searchResponse.Took = esResponse.Took;
			searchResponse.Total = esResponse.SearchResult.Total;
			searchResponse.Data = new List<BpmSearchResponseEntity>();
			searchResponse.Success = true;
			foreach (ESHit esHit in esResponse.SearchResult.Hits
						.Where(x => availableRecordIdentifiers.Contains(x.Id.ToLower())).ToList()) {
				if (UserConnection.EntitySchemaManager.FindInstanceByName(esHit.Type) != null) {
					var responseEntity = FillBpmResponseEntity(esHit);
					if (responseEntity.ColumnValues.Any() && responseEntity.FoundColumns.Any()) {
						searchResponse.Data.Add(responseEntity);
					}
				}
			}
			return searchResponse;
		}

		/// <summary>
		/// Process elastic search aggregations response.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance.</param>
		/// <returns>List of <see cref="BpmSearchAggregation"/> instances.</returns>
		[Obsolete("Use ProcessEsAggregationResponse(esAggsResponse)")]
		public virtual List<BpmSearchAggregation> ProccessEsAggregationResponse(ESAggregationResponse esAggsResponse) {
			return ProcessEsAggregationResponse(esAggsResponse);
		}

		/// <summary>
		/// Process elastic search aggregations response.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance.</param>
		/// <returns>List of <see cref="BpmSearchAggregation"/> instances.</returns>
		public virtual List<BpmSearchAggregation> ProcessEsAggregationResponse(ESAggregationResponse esAggsResponse) {
			var group = new List<BpmSearchAggregation>();
			try {
				List<ESAggregation> esAggregationGroups = GetEsAggregationGroups(esAggsResponse);
				foreach (var esAggregation in esAggregationGroups) {
					var type = esAggregation.Type;
					if (!UserConnection.DBSecurityEngine.GetIsEntitySchemaReadingAllowed(type)) {
						continue;
					}
					if (GetIsFileEntity(type)) {
						AddFileItemToGroup(group, esAggregation);
						continue;
					}
					group.Add(new BpmSearchAggregation {
						Type = type,
						TypeAlias = type,
						Count = esAggregation.Count
					});
				}
			} catch (Exception ex) {
				_log.ErrorFormat("ProcessESAggregationResponse. {0}\r\n{1}", ex.Message, ex.StackTrace);
			}
			return group;
		}

		/// <summary>
		/// Prepare <see cref="SearchRequestQuery"/> instance.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="recordCount">Count of selected records.</param>
		/// <param name="pageNum">Number of selected page.</param>
		/// <param name="from"></param>
		/// <returns><see cref="SearchRequestQuery"/> instance.</returns>
		public virtual SearchRequestQuery GetSearchRequestQuery(string queryString, int recordCount, int pageNum, int from) {
			var searchRequestQuery = GetDefaultSearchRequestQuery(recordCount, pageNum, from);
			searchRequestQuery.Query = new ESMatchQuery { Query = queryString };
			return searchRequestQuery;
		}

		/// <summary>
		/// Prepare <see cref="SearchRequestQuery"/> instance with custom score settings.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <param name="recordCount">Count of selected records.</param>
		/// <param name="pageNum">Number of search page.</param>
		/// <param name="from"></param>
		/// <returns><see cref="SearchRequestQuery"/> instance.</returns>
		public virtual SearchRequestQuery GetSearchScoreRequestQuery(string queryString, string sectionEntityName,
				int recordCount, int pageNum, int from) {
			var searchRequestQuery = GetDefaultSearchRequestQuery(recordCount, pageNum, from);
			searchRequestQuery.Query = GetSearchScoreQuery(queryString, sectionEntityName);
			return searchRequestQuery;
		}

		/// <summary>
		/// Prepare <see cref="AggsSearchRequestQuery"/> instance with custom score settings.
		/// </summary>
		/// <param name="queryString">Query string.</param>
		/// <param name="sectionEntityName">Current section entity name.</param>
		/// <returns><see cref="AggsSearchRequestQuery"/> instance.</returns>
		public virtual AggsSearchRequestQuery GetAggsSearchScoreRequestQuery(string queryString, string sectionEntityName) {
			var aggsSearchRequestQuery = new AggsSearchRequestQuery {
				Query = GetSearchScoreQuery(queryString, sectionEntityName, false)
			};
			return aggsSearchRequestQuery;
		}

		#endregion

	}

	#endregion

}

