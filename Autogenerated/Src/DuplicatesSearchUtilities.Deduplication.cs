namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.GlobalSearch;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Entities;
	using BPMSoft.ElasticSearch;
	using BPMSoft.GlobalSearch.Monitoring;
	using BPMSoft.Monitoring;
	using DuplicatesCollection =
		System.Collections.Generic.IEnumerable<System.Collections.Generic.Dictionary<string, string>>;

	#region class: DuplicatesSearchUtilities

	/// <summary>
	/// Provides duplicates search utilities.
	/// </summary>
	public class DuplicatesSearchUtilities
	{
		#region Constants: Private

		private const int FakeGroupId = 2147483647;

		#endregion

		#region Fields: Private

		private IDeduplicationManager _deduplicationManager;
		private GlobalSearchConnectorHelper _globalSearchConnectorHelper;
		private IDuplicatesRuleRepository _duplicatesRuleRepository;
		private IDuplicatesRuleManager _duplicatesRuleManager;

		#endregion

		#region Constructors: Public

		public DuplicatesSearchUtilities(UserConnection userConnection, string entitySchemaName) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			entitySchemaName.CheckArgumentNull(nameof(entitySchemaName));
			UserConnection = userConnection;
			SearchSchemaName = entitySchemaName;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; set; }

		private string SearchSchemaName { get; set; }

		private IDeduplicationManager DeduplicationManager {
			get {
				if (_deduplicationManager == null) {
					_deduplicationManager = CreateDeduplicationManager();
				}
				return _deduplicationManager;
			}
		}

		private IDuplicatesRuleManager DuplicatesRuleManager =>
			_duplicatesRuleManager ?? (_duplicatesRuleManager = ClassFactory.Get<IDuplicatesRuleManager>(new[] {
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("duplicatesRuleRepository", DuplicatesRuleRepository)
			}));

		private IDuplicatesRuleRepository DuplicatesRuleRepository =>
			_duplicatesRuleRepository ?? (_duplicatesRuleRepository = new DuplicatesRuleRepository());

		private GlobalSearchConnectorHelper GlobalSearchConnectorHelper =>
			_globalSearchConnectorHelper ?? (_globalSearchConnectorHelper =
				ClassFactory.Get<GlobalSearchConnectorHelper>(new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		/// <summary>
		/// Search for deduplication rules by specified EntitySchema name .
		/// </summary>
		/// <param name="entitySchemaName">EntitySchema name</param>
		/// <returns>Collection of found rules</returns>
		private IEnumerable<DuplicatesRuleDTO> GetAllSchemaRules(string entitySchemaName) {
			return DuplicatesRuleManager.GetBulkDuplicatesRules(entitySchemaName);
		}

		/// <summary>
		/// Creates deduplication columns model.
		/// </summary>
		/// <param name="searchColumns">Column-values object</param>
		/// <param name="deduplicationFilters">Collection of column filters</param>
		/// <returns>List of column data (Model)</returns>
		private List<DuplicatesColumnData> GetDeduplicationModel(IEnumerable<KeyValuePair<string, object>> searchColumns, 
				IEnumerable<DuplicatesRuleFilter> deduplicationFilters) {
			var result = new List<DuplicatesColumnData>();
			foreach (var filter in deduplicationFilters) {
				bool isRootSchema = (filter.SchemaName == SearchSchemaName);
				if (isRootSchema) {
					var schemaColumnValue = searchColumns.Where(x => x.Key == filter.ColumnName).Select(x=> x.Value);
					result.Add(FormDuplicatesColumnData(filter, filter.ColumnName, schemaColumnValue));
				} else {
					foreach (string columnName in filter.RootSchemaColumns) {
						var schemaColumnValue = searchColumns.Where(x => x.Key == columnName).Select(x=> x.Value);
						result.Add(FormDuplicatesColumnData(filter, columnName, schemaColumnValue));
					}
				}
			}
			return result;
		}

		private DuplicatesColumnData FormDuplicatesColumnData(DuplicatesRuleFilter filter, string columnName, 
				IEnumerable<object> schemaColumnValue) {
			return new DuplicatesColumnData() {
				SchemaName = filter.SchemaName,
				ColumnName = columnName,
				Value = schemaColumnValue != null
					? schemaColumnValue.Select(x=> x.ToString()).ToList()
					: new List<string>(),
				Type = filter.Type
			};
		}

		private ISearchProvider GetSearchProvider() {
			return new ESSearchProvider(
				new ElasticSearchRepository(GetElasticSearchClientFactory()),
				new ESQueryBuilder(new ESSearchColumnNameProvider(UserConnection)),
				UserConnection);
		}

		private IElasticSearchClientFactory GetElasticSearchClientFactory() {
			string elasticSearchUrl;
			string elasticSearchLogin;
			string elasticSearchPassword;
			try {
				elasticSearchUrl = Core.Configuration.SysSettings.GetValue(UserConnection, "GlobalSearchUrl", string.Empty);
				elasticSearchLogin = GlobalSearchConnectorHelper.GetElasticSearchSetting("user");
				elasticSearchPassword = GlobalSearchConnectorHelper.GetElasticSearchSetting("password");
			} catch {
				var metricReporter = ClassFactory.Get<IMetricReporter>();
				metricReporter.Report(new ErrorMetric { SearchErrorCode = GlobalSearchErrorCode.NotConfigured });
				throw;
			}
			return new ElasticSearchClientFactory(elasticSearchUrl, elasticSearchLogin, elasticSearchPassword);
		}

		private IEnumerable<string> GetColumnNames(IEnumerable<KeyValuePair<string, object>> searchColumns, List<DuplicatesRuleFilter> filters) {
			return filters
				.Where(filter => filter.SchemaName == SearchSchemaName && searchColumns.Select(x=>x.Key).Contains(filter.ColumnName))
				.Select(x => x.ColumnName).ToList();
		}

		private IEnumerable<KeyValuePair<string, object>> GetAccountAddressEntityColumns(EntitySchema entitySchema,
			Guid entityId, List<string> columnsNames) {
			var result = new List<KeyValuePair<string, object>>();
			var esq = new EntitySchemaQuery(entitySchema);
			var cityColumn = esq.AddColumn("[City:Id:City].Name");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Account", entityId));
			var entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (var entity in entityCollection) {
				result.Add(new KeyValuePair<string, object>(columnsNames.FirstOrDefault(), entity.GetColumnValue(cityColumn.Name)));
			}
			return result;
		}

		private IEnumerable<KeyValuePair<string, object>> GetCommunicationEntityColumns(EntitySchema entitySchema,
			string keyColumnName, Guid entityId, List<string> entityTypeNames) {
			var result = new List<KeyValuePair<string, object>>();
			var esq = new EntitySchemaQuery(entitySchema);
			var searchNumberColumn = esq.AddColumn("Number");
			var typeColumn = esq.AddColumn("CommunicationType");
			var typesList = new Dictionary<string, Guid>();
			foreach (var typeName in entityTypeNames) {
				var commTypeId = GetCommunicationTypeByCode(typeName);
				typesList.Add(typeName, commTypeId);
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"CommunicationType", typesList.Select(x=> x.Value.ToString())));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				keyColumnName, entityId));
			var entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (var entity in entityCollection) {
				result.Add(new KeyValuePair<string, object>(
					typesList.Where(x => x.Value == entity.GetTypedColumnValue<Guid>(typeColumn.ValueQueryAlias))
					.Select(x => x.Key).FirstOrDefault(),
					entity.GetColumnValue(searchNumberColumn.Name)));
			}
			return result;
		}

		private IEnumerable<KeyValuePair<string, object>> GetEntitySchemaColumns(EntitySchema entitySchema,
			Guid entityId, List<string> columnNames) {
			var result = new List<KeyValuePair<string, object>>();
			var esq = new EntitySchemaQuery(entitySchema);
			foreach (var columnName in columnNames) {
				esq.AddColumn(columnName);
			}
			Entity entity = esq.GetEntity(UserConnection, entityId);
			foreach (string columnName in columnNames) {
				result.Add(new KeyValuePair<string, object>(columnName, entity.GetColumnValue(columnName)));
			}
			return result;
		}

		private Guid GetCommunicationTypeByCode(string typeName) {
			switch (typeName) {
				case "Email": return new Guid(CommunicationTypeConsts.EmailId);
				case "Phone": return new Guid(CommunicationTypeConsts.HomePhoneId);
				case "MobilePhone": return new Guid(CommunicationTypeConsts.MobilePhoneId);
				case "Web": return new Guid(CommunicationTypeConsts.WebId);
				case "AdditionalPhone": return new Guid(CommunicationTypeConsts.AdditionalPhoneId);
				default: return Guid.Empty;
			}
		}

		#endregion

		#region  Methods: Protected
		
		protected virtual IDeduplicationManager CreateDeduplicationManager() {
			var searchProvider = GetSearchProvider();
			var metricReporter = ClassFactory.Get<IMetricReporter>();
			var deduplicationSearchQueryBuilder = ClassFactory.Get<DeduplicationSearchQueryBuilder>();
			var findSimilarRecordsRequestBuilder = new FindSimilarRecordsRequestBuilder(UserConnection, DuplicatesRuleManager);
			return new DeduplicationManager(searchProvider, metricReporter, DuplicatesRuleManager,
				deduplicationSearchQueryBuilder, findSimilarRecordsRequestBuilder);
		}

		/// <summary>
		/// Starts async merge duplicates operation.
		/// </summary>
		/// <param name="recordIds">List of duplicate record Ids</param>
		/// <returns>Instance of DuplicatesMergeResponse class</returns>
		protected virtual DuplicatesMergeResponse MergeRecordsAsync(IEnumerable<Guid> recordIds) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(SearchSchemaName);
			var config = CreateMergeValuesConfig(recordIds, entitySchema);
			var args = new[] {
				new ConstructorArgument("userConnection", UserConnection)
			};
			DeduplicationProcessing deduplicationProcessing = ClassFactory.Get<DeduplicationProcessing>(args);
			DuplicatesMergeResponse response = 
				deduplicationProcessing.MergeEntityDuplicatesAsync(SearchSchemaName, FakeGroupId, recordIds.ToList(), config);
			return response;
		}

		/// <summary>
		/// Creates and forms config for merge operation with entity values resolve.
		/// </summary>
		/// <param name="duplicateRecordIds">Duplicates records identifiers.</param>
		/// <param name="entitySchema">Duplicated entity schema.</param>
		/// <returns>Merge config with entity values resolve.</returns>
		protected virtual Dictionary<string, string> CreateMergeValuesConfig(IEnumerable<Guid> duplicateRecordIds, EntitySchema entitySchema) {
			EntityCollection collection = GetDuplicateRecordsEntities(duplicateRecordIds, entitySchema);
			var config = new Dictionary<string, string>();
			foreach (var column in entitySchema.Columns) {
				Entity entity = FindEntityWhereExistsColumnValue(collection, column);
				if (entity != null) {
					config.Add(column.Name, entity.PrimaryColumnValue.ToString());
				}
			}
			return config;
		}

		/// <summary>
		/// Loads and returns duplicate records entities.
		/// </summary>
		/// <param name="duplicateRecordIds">Duplicates records identifiers.</param>
		/// <param name="entitySchema">Duplicated entity schema.</param>
		/// <returns>Duplicates entities.</returns>
		protected virtual EntityCollection GetDuplicateRecordsEntities(IEnumerable<Guid> duplicateRecordIds, EntitySchema entitySchema) {
			var esq = new EntitySchemaQuery(entitySchema);
			esq.AddAllSchemaColumns();
			esq.Columns.GetByName("CreatedOn").OrderByAsc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, entitySchema.PrimaryColumn.Name,
				duplicateRecordIds.Cast<object>()));
			var collection = esq.GetEntityCollection(UserConnection);
			return collection;
		}

		/// <summary>
		/// Finds first entity, where exists entity value for specified column.
		/// </summary>
		/// <param name="collection">Entities collection.</param>
		/// <param name="column">Entity schema column.</param>
		/// <returns>Found entity with entity value for specified column.</returns>
		protected Entity FindEntityWhereExistsColumnValue(EntityCollection collection, EntitySchemaColumn column) {
			var entity = collection.FirstOrDefault(e =>
				e.GetColumnValue(column.ColumnValueName)?.ToString().IsNotNullOrEmpty() == true);
			return entity;
		}

		/// <summary>
		/// Extract column filers from deduplication rules.
		/// </summary>
		/// <param name="selectedRules">Collection of deduplication rules</param>
		/// <returns>List of extracted filters</returns>
		protected virtual List<DuplicatesRuleFilter> GetDefaultDeduplicationColumnFilters( 
			IEnumerable<DuplicatesRuleDTO> selectedRules) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(SearchSchemaName);
			var result = new List<DuplicatesRuleFilter> {
				new DuplicatesRuleFilter {
					SchemaName = SearchSchemaName,
					ColumnName = entitySchema.PrimaryColumn.Name
				}
			};
			var duplicateSchemaRules = selectedRules.Any()
				? selectedRules
				: GetAllSchemaRules(SearchSchemaName);
			foreach (DuplicatesRuleDTO rule in duplicateSchemaRules) {
				DuplicatesRuleBody ruleBody = rule.RuleBody;
				if (ruleBody == null || ruleBody.Filters == null) {
					continue;
				}
				foreach (DuplicatesRuleFilter filter in ruleBody.Filters) {
					if (!result.Contains(filter)) {
						result.Add(filter);
					}
				}
			}
			return result;
		}

		protected virtual IEnumerable<DuplicatesRuleDTO> FindRulesById(IEnumerable<Guid> ruleIds) {
			var resultList = new List<DuplicatesRuleDTO>();
			foreach (var ruleId in ruleIds) {
				var rule = DuplicatesRuleRepository.Get(UserConnection, ruleId);
				if (rule?.RuleName != null) {
					resultList.Add(rule);
				}
			}
			if (!resultList.Any()) {
				return GetAllSchemaRules(SearchSchemaName);
			}
			return resultList;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Searching duplicates according to specified column values.
		/// </summary>
		/// <param name="mappedColumns">Column-valued object.</param>
		/// <param name="duplicationRules">List of specified deduplication rules identifiers</param>
		/// <returns>Collection of found duplicates</returns>
		public virtual IEnumerable<Dictionary<string, string>> FindRecordDuplicates(IEnumerable<KeyValuePair<string, object>> mappedColumns,
			IEnumerable<Guid> duplicationRules) {
			if (!UserConnection.GetIsFeatureEnabled("ESDeduplication")) {
				return new List<Dictionary<string, string>>();
			}
			var rules = FindRulesById(duplicationRules);
			var filters = GetDefaultDeduplicationColumnFilters(rules);
			var columns = GetColumnNames(mappedColumns, filters).ToList();
			var model = GetDeduplicationModel(mappedColumns, filters);
			var findDuplicatesOnSaveRequest = new FindDuplicatesRequest() {
				SchemaName = SearchSchemaName,
				Columns = columns,
				PrimaryColumnValue = null,
				Model = model,
				Rules = rules,
				Type = DuplicatesRuleType.OnlyActive
			};
			return DeduplicationManager.FindDuplicates(findDuplicatesOnSaveRequest);
		}

		/// <summary>
		/// Merge duplicates to 'Gold Record'.
		/// </summary>
		/// <param name="duplicatesCollection">Collection of duplicate record Ids</param>
		/// <param name="searchColumns">List of columns to exclude merge operation</param>
		/// <param name="primaryColumnName">Searching entity primary column name</param>
		/// <returns><c>true</c>, if merge operation successful. Otherwise - <c>false</c>.</returns>
		public virtual bool MergeRecordDuplicates(DuplicatesCollection duplicatesCollection, IEnumerable<string> searchColumns, 
			string primaryColumnName = "Id") {
			List<Guid> deduplicateRecordIds = duplicatesCollection
				.Where(item => item[primaryColumnName].IsEmpty() != true)
				.Select(x => Guid.Parse(x[primaryColumnName])).ToList();
			var response = MergeRecordsAsync(deduplicateRecordIds);
			return response.Success;
		}

		/// <summary>
		/// Map columns between source record and duplicates search entity.
		/// </summary>
		/// <param name="entity">Source record entity</param>
		/// <param name="columnMapping">Dictionary of column mapping (SourceColumn, TargetColumn)</param>
		/// <returns>Instance of CompositeObject</returns>
		public virtual IDictionary<string, object> MapSchemaColumns(Entity entity, Dictionary<string, string> columnMapping = null) {
			CompositeObject result = new CompositeObject();
			if (columnMapping != null) {
				foreach (var mapping in columnMapping) {
					result[mapping.Value] = entity.GetColumnValue(mapping.Key);
				}
				if (!result.ContainsKey("Id")) {
					result["Id"] = Guid.NewGuid();
				}
			}
			return result;
		}

		/// <summary>
		/// Returns dictionary of entity column value.
		/// </summary>
		/// <param name="entityId">Entity identifier</param>
		/// <param name="entitySchemaColumns">List of entity schema columns(Schema name, Column name)</param>
		/// <returns>Dictionary of entity column value (Column name, Value)</returns>
		public virtual IEnumerable<KeyValuePair<string, object>> GetEntityColumns(Guid entityId,
			IEnumerable<KeyValuePair<string, string>> entitySchemaColumns) {
			var mappedColumns = new List<KeyValuePair<string, object>>();
			foreach (var schemaColumns in entitySchemaColumns.GroupBy(x=> x.Key)) {
				var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaColumns.Key);
				var columnsNamesList = schemaColumns.Select(x => x.Value).ToList();
				switch (entitySchema.Name) {
					case "ContactCommunication": {
						var entityColumns = GetCommunicationEntityColumns(entitySchema, "Contact", entityId, columnsNamesList);
						mappedColumns.AddRange(entityColumns);
						break;
					}
					case "AccountCommunication": {
						var entityColumns = GetCommunicationEntityColumns(entitySchema, "Account", entityId, columnsNamesList);
						mappedColumns.AddRange(entityColumns);
						break;
					}
					case "AccountAddress": {
						var entityColumns = GetAccountAddressEntityColumns(entitySchema, entityId, columnsNamesList);
						mappedColumns.AddRange(entityColumns);
						break;
					}
					default: {
						var entityColumns = GetEntitySchemaColumns(entitySchema, entityId, columnsNamesList);
						mappedColumns.AddRange(entityColumns);
						break;
					}
				}
			}
			mappedColumns.Add(new KeyValuePair<string, object>("Id", entityId.ToString()));
			return mappedColumns.Distinct().Where(x=> x.Value as string != string.Empty);
		}

		/// <summary>
		/// Gets columns from duplicate rules.
		/// </summary>
		/// <param name="rulesIdsList">List of rules Ids</param>
		/// <returns>List of entity columns (Schema name, Column name)</returns>
		public virtual IEnumerable<KeyValuePair<string, string>> GetColumnsFromRules(IEnumerable<Guid> rulesIdsList) {
			var result = new List<KeyValuePair<string, string>>();
			foreach (var ruleId in rulesIdsList) {
				var filterDTOs = DuplicatesRuleManager.GetDuplicatesRuleFilters(ruleId);
				foreach (var filter in filterDTOs) {
					if (filter.IsDetail) {
						foreach (var schemaColumn in filter.RootSchemaColumns) {
							result.Add(new KeyValuePair<string, string>(filter.SchemaName, schemaColumn));
						}
					} else {
						result.Add(new KeyValuePair<string, string>(filter.SchemaName, filter.ColumnName));
					}
				}
			}
			return result.Distinct();
		}

		/// <summary>
		/// Returns list of id of active rules for specific entity.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <param name="rulesId">List of Ids of rules which should be returned if a rule is active</param>
		/// <returns></returns>
		public virtual IEnumerable<Guid> GetActiveRules(string entitySchemaName, IEnumerable<Guid> rulesId = null) {
			var activeRules = DuplicatesRuleManager.GetBulkDuplicatesRules(entitySchemaName).Select(x => x.Id);
			if (rulesId?.Any() == true) {
				return activeRules.Where(rulesId.Contains);
			}
			return activeRules;
		}

		#endregion

	}

	#endregion

}
