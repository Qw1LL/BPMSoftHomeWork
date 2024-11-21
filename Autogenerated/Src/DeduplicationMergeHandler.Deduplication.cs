namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Configuration.Deduplication;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Entities;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using Json = Newtonsoft.Json;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using IAfterDeduplicationAction = Deduplication.IAfterDeduplicationAction;

	#region Class: MergeProcedureConfig

	public class MergeProcedureConfig
	{
		public List<string> EligibleForSchema { get; set; }
	}

	#endregion
	
	#region Class: DeduplicationMergeHandler

	/// <summary>
	/// Implement merging collection of entities into golden entity.
	/// </summary>
	public class DeduplicationMergeHandler : IDeduplicationMergeHandler
	{

		#region Consts: Private

		private const string InitialResultsTableSuffix = "DuplicateSearchResult";

		private const string MergeRuleStoredProcedurePrefix = "tsp_";

		private static readonly string[] IgnoredColumns = new string[] { "Address", "City",
			"Region", "Zip", "Country", "Facebook", "LinkedIn", "Twitter",
			"FacebookId", "LinkedInId", "TwitterId", "ContactPhoto",
			"Code", "Surname", "GivenName", "MiddleName", "Completeness"
		};
		
		private static readonly ILog _log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Fields: Protected

		protected readonly UserConnection UserConnection;

		#endregion

		#region Methods: Private

		private Dictionary<string, string> GetQueryColumns(EntitySchemaColumnCollection columns) {
			var queryColumns = new Dictionary<string, string>();
			foreach (EntitySchemaColumn column in columns) {
				queryColumns[column.Name] = column.Name;
			}
			return queryColumns;
		}

		private bool IsEmptyOrDefaultColumnValue(EntitySchemaColumn column, EntityColumnValue columnValue) {
			return (
				columnValue.Value == null ||
				columnValue.Value.ToString().IsNullOrEmpty() ||
				(column.HasDefValue && columnValue.Value.Equals(column.DefValue.Value)));
		}

		private string FindModifiedOnColumn(string tableName) {
			string modifiedOnColumnName = "";
			try {
				EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(tableName);
				EntitySchemaColumn modifiedOnColumn = entitySchema.ModifiedOnColumn;
				if (modifiedOnColumn != null) {
					modifiedOnColumnName = modifiedOnColumn.Name;
				}
			} catch { }
			return modifiedOnColumnName;
		}

		private void UpdateReferencedRecords(string tableName, List<string> tableColumns, Guid masterRecordId,
			List<Guid> detailRecordIds, DBExecutor dbExecutor) {
			List<QueryParameter> duplicatesRecordIds =
				detailRecordIds.Select(recordId => new QueryParameter(recordId)).ToList();
			string modifiedOnColumnName = FindModifiedOnColumn(tableName);
			foreach (string tableColumn in tableColumns) {
				var update = new Update(UserConnection, tableName)
					.Set(tableColumn, Column.Parameter(masterRecordId));
				if (modifiedOnColumnName != "") {
					update.Set(modifiedOnColumnName, Column.Parameter(DateTime.UtcNow));
				}
				update.Where(tableColumn).In(duplicatesRecordIds);
				try {
					update.Execute(dbExecutor);
				} catch(Exception e) {
					_log.Error($"Failed UpdateReferencedRecords. tableName: {tableName}, modifiedOnColumnName: {modifiedOnColumnName}, tableColumn: {tableColumn}");
					throw e;
				}
			}
		}

		private void DeleteMasterRecords(string schemaName, List<Guid> recordIds, DBExecutor dbExecutor) {
			QueryParameterCollection queryParameterCollection = new QueryParameterCollection();
			foreach (Guid recordId in recordIds) {
				queryParameterCollection.Add(new QueryParameter(recordId));
			}
			if (queryParameterCollection.Count == 0) {
				throw new Exception("Invalid Query paramers exception. Collection cannot be empty/");
			}
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			string primaryColumnName = entitySchema.GetDBPrimaryColumnName();
			var delete = new Delete(UserConnection).From(schemaName)
				.Where(primaryColumnName)
				.In(queryParameterCollection);
			delete.Execute(dbExecutor);
		}

		private bool GetIsDetailMergeRuleEligibleForSchema(string schemaName, string sqlText, string additionalMergeConfig) {
			if (!sqlText.StartsWith(MergeRuleStoredProcedurePrefix)) {
				return true;
			}
			try {
				var procedureConfig = Json.JsonConvert.DeserializeObject<MergeProcedureConfig>(additionalMergeConfig);
				var schemas = procedureConfig.EligibleForSchema;
				return schemas.Select(schema=>schema.ToLower()).Contains(schemaName.ToLower());
			} catch {
				return true;
			}
		}
		
		private Dictionary<string, string> GetDetailMergeRules(string schemaName) {
			Dictionary<string, string> mergeRules = new Dictionary<string, string>();
			var select = new Select(UserConnection)
				.Column("Name")
				.Column("SQLText")
				.Column("AdditionalMergeConfig")
				.From("DeduplicateMergeRules");
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var sqlTextValue = reader.GetColumnValue<string>("SQLText");
						var additionalMergeConfig = reader.GetColumnValue<string>("AdditionalMergeConfig");
						if (GetIsDetailMergeRuleEligibleForSchema(schemaName, sqlTextValue, additionalMergeConfig)) {
							var nameValue = reader.GetColumnValue<string>("Name");
							mergeRules[nameValue] = sqlTextValue;
						}
					}
				}
			}
			return mergeRules;
		}

		private void DeleteMergedEntitiesFromSearchResult(string schemaName, List<Guid> duplicatesRecordIds) {
			QueryParameterCollection queryParameterCollection = new QueryParameterCollection();
			foreach (Guid recordId in duplicatesRecordIds) {
				queryParameterCollection.Add(new QueryParameter(recordId));
			}
			if (queryParameterCollection.Count > 0) {
				string initialResultsTableName = string.Format("{0}{1}", schemaName, InitialResultsTableSuffix);
				if (!ValidateEntitySchema(initialResultsTableName)) {
					return;
				}
				string columnName = string.Format("{0}Id", schemaName);
				var delete = new Delete(UserConnection).From(initialResultsTableName)
					.Where(columnName).In(queryParameterCollection);
				delete.Execute();
			}
		}

		private void RevertSearchResultGroupToPositive(string schemaName, int groupId) {
			string initialResultsTableName = string.Format("{0}{1}", schemaName, InitialResultsTableSuffix);
			if (!ValidateEntitySchema(initialResultsTableName)) {
				return;
			}
			int reverseValueToNegative = groupId * -1;
			var update = new Update(UserConnection, initialResultsTableName)
				.Set("GroupId", Column.Parameter(groupId))
					.Where("GroupId").IsEqual(Column.Parameter(reverseValueToNegative));
			update.Execute();
		}

		private void DeleteSearchResultGroup(string schemaName, int groupId) {
			int reverseValueToNegative = groupId * -1;
			string initialResultsTableName = string.Format("{0}{1}", schemaName, InitialResultsTableSuffix);
			if (!ValidateEntitySchema(initialResultsTableName)) {
				return;
			}
			var delete = new Delete(UserConnection).From(initialResultsTableName)
					.Where("GroupId").IsEqual(Column.Parameter(reverseValueToNegative));
			delete.Execute();
		}

		private bool ValidateEntitySchema(string entitySchemaName) {
			return UserConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName) != null;
		}

		private bool GetIsSystemColumn(EntitySchema schema, EntitySchemaColumn column) {
			if (column == null) {
				return false;
			}
			if (schema.PrimaryColumn != null && column.Name == schema.PrimaryColumn.Name) {
				return true;
			}
			if (schema.CreatedOnColumn != null && column.Name == schema.CreatedOnColumn.Name) {
				return true;
			}
			if (schema.CreatedByColumn != null && column.Name == schema.CreatedByColumn.Name) {
				return true;
			}
			if (schema.ModifiedOnColumn != null && column.Name == schema.ModifiedOnColumn.Name) {
				return true;
			}
			if (schema.ModifiedByColumn != null && column.Name == schema.ModifiedByColumn.Name) {
				return true;
			}
			if (column.Name == "ProcessListeners") {
				return true;
			}
			return false;
		}

		private Update CreateConversionDuplicatesToGoldUpdate(string detailName, string recordIdColumnName,
				string[] aggregationColumns, Guid goldRecoredId, List<Guid> duplicateRecoredIds) {
			var detailNameAlias = $"{detailName}RootSchema";
			Select excludeGoldRecordSelect = new Select(UserConnection)
					.Column(Column.Const(null))
					.From(detailName).As(detailName);
			excludeGoldRecordSelect = GetSelectWithAggregationColumnsConditions(excludeGoldRecordSelect, aggregationColumns, detailNameAlias);
			excludeGoldRecordSelect.AddCondition(excludeGoldRecordSelect.SourceExpression.Alias, recordIdColumnName,
					LogicalOperation.And).IsEqual(Column.Parameter(goldRecoredId));
			Select recordIdInAggregated = new Select(UserConnection)
				.Top(1)
				.Column("Id")
				.From(detailName).As(detailName);
			recordIdInAggregated = GetSelectWithAggregationColumnsConditions(recordIdInAggregated, aggregationColumns, detailNameAlias);
			List<QueryParameter> duplicateIds
				= duplicateRecoredIds.Select(recordId => new QueryParameter(recordId)).ToList();
			Select recordIdsForUpdate = new Select(UserConnection)
				.Column(recordIdInAggregated).As("Id")
				.From(detailName).As(detailNameAlias)
				.Where(recordIdColumnName).In(duplicateIds)
				.And().Not().Exists(excludeGoldRecordSelect) as Select;
			foreach (string columnName in aggregationColumns) {
				recordIdsForUpdate.GroupBy(detailNameAlias, columnName);
			}
			string modifiedOnColumnName = FindModifiedOnColumn(detailName);
			Update update = new Update(UserConnection, detailName)
				.Set(recordIdColumnName, Column.Parameter(goldRecoredId));
			if (modifiedOnColumnName != "") {
				update.Set(modifiedOnColumnName, Column.Parameter(DateTime.UtcNow));
			}
			update.Where("Id").In(recordIdsForUpdate);
			return update;
		}

		private Select GetSelectWithAggregationColumnsConditions(Select select, string[] aggregationColumns, string detailNameAlias) {
			foreach (string columnName in aggregationColumns) {
				QueryCondition condition = select.AddCondition(LogicalOperation.And);
				condition
					.OpenBlock(select.SourceExpression.Alias, columnName)
						.IsEqual(detailNameAlias, columnName)
						.Or()
						.OpenBlock(select.SourceExpression.Alias, columnName)
							.IsNull()
							.And(detailNameAlias, columnName).IsNull()
						.CloseBlock()
					.CloseBlock();
			}
			return select;
		}

		private Delete CreateDuplicatesDelete(string detailName, string recordIdColumnName, List<Guid> duplicateRecoredIds) {
			List<QueryParameter> duplicateIds
				= duplicateRecoredIds.Select(recordId => new QueryParameter(recordId)).ToList();
			Delete delete = new Delete(UserConnection)
				.From(detailName)
				.Where(recordIdColumnName).In(duplicateIds) as Delete;
			return delete;
		}

		private (string, string[]) ParseRuleBody(string ruleBody) {
			var ruleSplitted = ruleBody.Split(';');
			var ruleEntityColumn = ruleSplitted[0];
			var aggregationColumns = ruleSplitted[1].Split(',');
			return (ruleEntityColumn, aggregationColumns);
		}
		
		private string[] GetRuleColumns(string mergeRule, string entityColumnAlias) {
			(var ruleEntityColumn, var aggregationColumns) = ParseRuleBody(mergeRule);
			var result = aggregationColumns.Concat(new [] {ruleEntityColumn});
			return result.Where(item => item != entityColumnAlias).ToArray();
		}
		
		private void MergeDetailRecordsByRule(string mergeRule, string detailName, Guid goldRecordId, List<Guid> duplicateRecordIds,
				DBExecutor dbExecutor, EntitySchemaOppositeReferenceInfoCollection schemaReferences) {
			if (mergeRule.StartsWith(MergeRuleStoredProcedurePrefix)) {
				string duplicateRecordIdsToString = string.Join("", duplicateRecordIds.ToArray());
				var storedProcedure = new StoredProcedure(UserConnection, mergeRule);
				storedProcedure.WithParameter("GoldenRecordId", goldRecordId);
				storedProcedure.WithParameter("DuplicateList", duplicateRecordIdsToString);
				storedProcedure.Execute(dbExecutor);
				return;
			}
			var detailSchema = UserConnection.EntitySchemaManager.GetInstanceByName(detailName);
			if (UserConnection.GetIsFeatureEnabled("FetchSchemaFromMetadataForDeduplication")) {
				var columnUids = schemaReferences.Where(referenceInfo => referenceInfo.SchemaUId == detailSchema.UId
						&& referenceInfo.ColumnUId != null)
					.Select(x => x.ColumnUId);
				foreach (var columnUid in columnUids) {
					var entityColumn = detailSchema.Columns.FindByUId(columnUid);
					if (entityColumn == null) {
						continue;
					}
					var entityColumnAlias = entityColumn.ColumnValueName;
					var ruleColumns = GetRuleColumns(mergeRule, entityColumnAlias);
					MergeByRule(ruleColumns, detailName, entityColumn.ColumnValueName, dbExecutor, goldRecordId,
						duplicateRecordIds);
				}
			} else {
				(var ruleEntityColumn, var aggregationColumns) = ParseRuleBody(mergeRule);
				MergeByRule(aggregationColumns, detailName, ruleEntityColumn, dbExecutor, goldRecordId,
					duplicateRecordIds);
			}
		}

		private void MergeByRule(string[] aggregationColumns, string detailName, string entityColumnName,
				DBExecutor dbExecutor, Guid goldRecordId, List<Guid> duplicateRecordIds) {
			Update update = CreateConversionDuplicatesToGoldUpdate(detailName, entityColumnName,
				aggregationColumns, goldRecordId, duplicateRecordIds);
			var jsonAdditionalMergeConfigs = GetAdditionalMergeConfig(detailName);
			if (!string.IsNullOrEmpty(jsonAdditionalMergeConfigs)) {
				ApplyDetailAdditionalMergeConfig(update, jsonAdditionalMergeConfigs);
			}
			Delete delete = CreateDuplicatesDelete(detailName, entityColumnName, duplicateRecordIds);
			update.Execute(dbExecutor);
			delete.Execute(dbExecutor);
		}

		private MergeConfigItem[] GetAdditionalMergeConfigs(string jsonAdditionalMergeConfigs) {
			try {
				return Json.JsonConvert.DeserializeObject<MergeConfigItem[]>(jsonAdditionalMergeConfigs);
			} catch {
				return new MergeConfigItem[0];
			}
		}

		private string GetAdditionalMergeConfig(string detailName) {
			var ret = string.Empty;
			var select = new Select(UserConnection)
				.Top(1)
				.Column("AdditionalMergeConfig")
				.From("DeduplicateMergeRules")
				.Where("Name")
				.IsEqual(Column.Parameter(detailName)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						ret = reader.GetColumnValue<string>("AdditionalMergeConfig");
					}
				}
			}
			return string.IsNullOrEmpty(ret) ? string.Empty : ret.Trim();
		}

		private bool IsEquals(Object valueOne, Object valueTwo) {
			string strOne = valueOne as String;
			string strTwo = valueTwo as String;
			if (strOne != null) {
				valueOne = strOne.Trim();
			}
			if (strTwo != null) {
				valueTwo = strTwo.Trim();
			}
			return Object.Equals(valueOne, valueTwo);
		}

		private bool IsColumnInIgnoreList(string columnName) {
			return IgnoredColumns.Contains(columnName);
		}

		private void ApplyReferencedTable(Dictionary<string, List<string>> referencedTable, string fkTableName,
				string fkColumnName) {
			if (referencedTable.ContainsKey(fkTableName) && !referencedTable[fkTableName].Contains(fkColumnName)) {
				referencedTable[fkTableName].Add(fkColumnName);
			} else {
				referencedTable[fkTableName] = new List<string>() { fkColumnName };
			}
		}

		private void CreateMergeReminding(Entity goldenEntity) {
			var resourceStorage = UserConnection.Workspace.ResourceStorage;
			string description = new LocalizableString(resourceStorage, "DeduplicationMergeHandler",
				"LocalizableStrings.MergedMessageDescription.Value");
			string subjectCaption = new LocalizableString(resourceStorage, "DeduplicationMergeHandler",
				"LocalizableStrings.MergedMessageCaption.Value");
			SysUserInfo currentUser = UserConnection.CurrentUser;
			DateTime remindTime = currentUser.GetCurrentDateTime();
			var remindingSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Reminding");
			var reminding = remindingSchema.CreateEntity(UserConnection);
			reminding.SetDefColumnValues();
			reminding.SetColumnValue("AuthorId", currentUser.ContactId);
			reminding.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			reminding.SetColumnValue("ContactId", currentUser.ContactId);
			reminding.SetColumnValue("RemindTime", remindTime);
			reminding.SetColumnValue("Description", description);
			reminding.SetColumnValue("SubjectCaption", string.Format(subjectCaption, goldenEntity.Schema.Caption));
			reminding.SetColumnValue("SubjectId", goldenEntity.PrimaryColumnValue);
			reminding.SetColumnValue("SysEntitySchemaId", goldenEntity.Schema.UId);
			reminding.SetColumnValue("NotificationTypeId", RemindingConsts.NotificationTypeNotificationId);
			reminding.Save();
		}

		private void ApplyDuplicatesReferencedTablesInfo(string schemaName, Dictionary<string, List<string>> result) {
			var entitySchemaName = "DuplicatesReference";
			if (!ValidateEntitySchema(entitySchemaName)) {
				return;
			}
			EntitySchema schema = UserConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName);
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ObjectName", schemaName));
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			foreach (Entity entity in entityCollection) {
				string fkTableName = entity.GetTypedColumnValue<string>("TableName");
				string columnName = entity.GetTypedColumnValue<string>("ColumnName");
				string[] columns = columnName.Split(';');
				foreach (string fkTableColumnName in columns) {
					ApplyReferencedTable(result, fkTableName, fkTableColumnName);
				}
			}
		}

		private EntitySchemaOppositeReferenceInfoCollection GetEntitySchemaOpposites(Guid entitySchemaUid) {
			return UserConnection.EntitySchemaManager.GetSchemaOppositeReferences(entitySchemaUid,
				EntitySchemaColumnUsageType.General, UserConnection, true);
		}

		private Dictionary<string, List<string>> GetTableReferencesByForeignKeys(string schemaName) {
			var result = new Dictionary<string, List<string>>();
			EntitySchema entity = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			var references = GetEntitySchemaOpposites(entity.UId)
					.GroupBy(x => new { x.ColumnUId, x.SchemaName } )
					.Select(x => x.First());
			foreach (var reference in references) {
				string fkTableName = reference.SchemaName;
				var referenceEntity = UserConnection.EntitySchemaManager.GetInstanceByName(fkTableName);
				if (referenceEntity.IsDBView) {
					continue;
				}
				string fkTableColumnName = referenceEntity.Columns.GetByUId(reference.ColumnUId).ColumnValueName;
				ApplyReferencedTable(result, fkTableName, fkTableColumnName);
			}
			return result;
		}

		private void SendDataToExternalServices(EntitySchema entitySchema, List<Guid> duplicateRecordIds) {
			DeleteDuplicates(entitySchema, duplicateRecordIds);
			DeleteIndexedEntities(entitySchema, duplicateRecordIds);
		}

		private void DeleteIndexedEntities(EntitySchema entitySchema, List<Guid> duplicateRecordIds) {
			if (!UserConnection.GetIsFeatureEnabled("GlobalSearch_V2")) {
				return;
			}
			var indexingBuilder = ClassFactory.Get<IndexingRequestDataBuilder>();
			var requestData = indexingBuilder.BuildQueriedRequestData(UserConnection, IndexingOperationType.Delete,
				duplicateRecordIds, entitySchema.Name,
				GlobalSearchColumnUtils.GlobalSearchColumnUtils.Instance.RelationColumnsFieldPattern);
			var indexingSender = ClassFactory.Get<IndexingEntitySender>();
			indexingSender.SendIndexingEntity(requestData);
		}

		private void DeleteDuplicates(EntitySchema entitySchema, List<Guid> duplicateRecordIds) {
			if (!UserConnection.GetIsFeatureEnabled("BulkESDeduplication")) {
				return;
			}
			var duplicatesRuleChecker = ClassFactory.Get<IDuplicatesRuleChecker>(
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("duplicatesRuleRepository", ClassFactory.Get<IDuplicatesRuleRepository>())
				);
			if (duplicatesRuleChecker.GetIsDuplicationRuleExist(entitySchema.UId)) {
				var deduplicateDeletion = ClassFactory.Get<IDuplicateDeletionManager>(
					new ConstructorArgument("userConnection", UserConnection));
				deduplicateDeletion.Delete(entitySchema.Name, duplicateRecordIds.ToArray());
			}
		}

		private void MergeImageColumn(Entity goldRecord, EntityColumnValue winnerImageColumnValue,
				EntitySchemaColumn column) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysImage");
			var entityImage = entitySchema.CreateEntity(UserConnection);
			entityImage.FetchFromDB(winnerImageColumnValue.Value);
			var newImageId = Guid.NewGuid();
			var cloneEntity = entityImage.Clone() as Entity;
			cloneEntity.SetColumnValue("Id", newImageId);
			var saveResult = cloneEntity.Save();
			if (saveResult) {
				goldRecord.SetColumnValue(column.ColumnValueName, newImageId);
			}
		}

		private bool IsImageColumn(Entity goldRecord, string columnName) {
			return goldRecord.Schema.PrimaryImageColumn != null
				&& goldRecord.Schema.PrimaryImageColumn.Name == columnName;
		}
		
		private void PostMessage() {
			MsgChannelUtilities.PostMessageToAll( "DuplicatesOperationExecuted", "");
		}

		#endregion

		#region Methods: Protected

		protected void ApplyDetailAdditionalMergeConfig(Update update, string jsonAdditionalMergeConfigs) {
			var arrayData = GetAdditionalMergeConfigs(jsonAdditionalMergeConfigs);
			foreach (var columnValue in arrayData) {
				update.Set(columnValue.Column, Column.Parameter(columnValue.Value));
			}
		}

		protected void MergeDuplicatesWithGoldRecord(Entity goldRecord, EntityCollection dublicates,
				Dictionary<string, string> resolvedConflicts) {
			foreach (var column in goldRecord.Schema.Columns) {
				if (IsColumnInIgnoreList(column.Name)) {
					continue;
				}
				if (resolvedConflicts != null && resolvedConflicts.ContainsKey(column.Name)) {
					ResolveConflict(goldRecord, dublicates, resolvedConflicts, column);
					continue;
				}
				FillColumnValueIfEmpty(goldRecord, dublicates, column);
			}
		}

		private void FillColumnValueIfEmpty(Entity goldRecord, EntityCollection dublicates,
				EntitySchemaColumn column) {
			var goldenColumnValue = goldRecord.FindEntityColumnValue(column.ColumnValueName);
			if (!IsEmptyOrDefaultColumnValue(column, goldenColumnValue)) {
				return;
			}
			foreach (var dublicate in dublicates) {
				var columnValue = dublicate.FindEntityColumnValue(column.ColumnValueName);
				if (!IsEmptyOrDefaultColumnValue(column, columnValue)) {
					if (IsImageColumn(goldRecord, column.Name)) {
						MergeImageColumn(goldRecord, columnValue, column);
						break;
					}
					goldRecord.SetColumnValue(column.ColumnValueName, columnValue.Value);
					break;
				}
			}
		}

		protected virtual void ResolveConflict(Entity goldRecord, EntityCollection dublicates,
				Dictionary<string, string> resolvedConflicts, EntitySchemaColumn column) {
			var sourceId = new Guid(resolvedConflicts[column.Name]);
			var source = dublicates.FindOrFetch(dublicates.Schema.PrimaryColumn, sourceId);
			if (source != null) {
				var columnValue = source.FindEntityColumnValue(column.ColumnValueName);
				if (IsImageColumn(goldRecord, column.Name)) {
					MergeImageColumn(goldRecord, columnValue, column);
					return;
				}
				goldRecord.SetColumnValue(column.ColumnValueName, columnValue.Value);
			}
		}

		protected virtual void ApplyFactoryReferences(string schemaName, Dictionary<string, List<string>> result) {
			var factories = ClassFactory.GetAll<IMergeReferencesFactory>();
			var factoryReferences = factories.Select(factory => factory.GetReferences(schemaName));
			factoryReferences.ForEach(factoryReference => factoryReference.ForEach(
				reference => {
					reference.Value?.ForEach(value => ApplyReferencedTable(result, reference.Key, value));
				}
			));
		}

		protected virtual Dictionary<string, List<string>> GetReferencedTablesInfo(string schemaName) {
			var result = GetTableReferencesByForeignKeys(schemaName);
			ApplyDuplicatesReferencedTablesInfo(schemaName, result);
			ApplyFactoryReferences(schemaName, result);
			return result;
		}

		protected virtual void LogMergeDuplicatesRecords(string schemaName, List<Guid> duplicateRecordIds, Guid newRecordId) {
			foreach (var dublicateId in duplicateRecordIds) {
				var insert = new Insert(UserConnection)
					.Into("DuplicatesHistory")
					.Set("Id", Column.Parameter(Guid.NewGuid()))
					.Set("OldRecordId", Column.Parameter(dublicateId))
					.Set("NewRecordId", Column.Parameter(newRecordId))
					.Set("SchemaTableName", Column.Parameter(schemaName)) as Insert;
				insert.Execute();
			}
		}

		/// <summary>
		/// Perform after deduplication actions
		/// </summary>
		/// <param name="goldenEntity">Golden entity</param>
		protected virtual void PerformAfterDeduplicationActions(Entity goldenEntity) {
			CreateMergeReminding(goldenEntity);
			PostMessage();
			var type = typeof(IAfterDeduplicationAction);
			var actions = UserConnection.Workspace.WorkspaceAssembly.GetTypes()
				.Where(p => type.IsAssignableFrom(p) && p.IsClass)
				.Select(t => (IAfterDeduplicationAction)Activator.CreateInstance(t, UserConnection));
			foreach (IAfterDeduplicationAction action in actions) {
				action.Execute(goldenEntity);
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="Core.UserConnection"/></param>
		public DeduplicationMergeHandler(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get collection of entity for merge.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="ids">Collection of entity identifiers.</param>
		/// <param name="columns">Names of columns to read.</param>
		/// <returns>Collection of entity.</returns>
		public EntityCollection GetEntityDublicates(string schemaName, List<Guid> ids, List<string> columns = null) {
			EntitySchema schema = UserConnection.EntitySchemaManager
				.GetInstanceByName(schemaName);
			var esq = new EntitySchemaQuery(schema);
			if (columns == null) {
				esq.AddAllSchemaColumns();
			} else {
				esq.PrimaryQueryColumn.IsAlwaysSelect = true;
				if (!columns.Contains("CreatedOn")) {
					esq.AddColumn("CreatedOn");
				}
				foreach (string columnName in columns) {
					esq.AddColumn(columnName);
				}
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				esq.RootSchema.PrimaryColumn.Name, ids.Cast<object>()));
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			entityCollection.Order("CreatedOn", OrderDirection.Ascending);
			return entityCollection;
		}

		/// <summary>
		///  Validates duplicate entities.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="duplicateRecordIds">Collection of identifiers of duplicate entities.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		/// <returns>Validation result.</returns>
		public ValidateDuplicatesResponse ValidateDuplicates(string schemaName, List<Guid> duplicateRecordIds,
				Dictionary<string, string> resolvedConflicts) {
			ValidateDuplicatesResponse response = new ValidateDuplicatesResponse();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			EntityCollection entityCollection = GetEntityDublicates(schemaName, duplicateRecordIds);
			Entity goldenEntity = entityCollection.FirstOrDefault();
			if (goldenEntity == null) {
				return response;
			}
			entityCollection.RemoveFirst();
			List<string> resolvedColumns = new List<string>();
			if (resolvedConflicts != null) {
				resolvedColumns = resolvedConflicts.Keys.ToList();
			}
			List<string> conflictColumns = new List<string>();
			foreach (EntitySchemaColumn column in goldenEntity.Schema.Columns) {
				if (IsColumnInIgnoreList(column.Name)) {
					continue;
				}
				if (GetIsSystemColumn(entitySchema, column)) {
					continue;
				}
				if (resolvedColumns.Contains(column.Name)) {
					continue;
				}
				bool isConflictColumn = false;
				EntityColumnValue goldenColumnValue = goldenEntity.FindEntityColumnValue(column.ColumnValueName);
				foreach (Entity entity in entityCollection) {
					EntityColumnValue columnValue = entity.FindEntityColumnValue(column.ColumnValueName);
					if (DataTypeUtilities.ValueIsNullOrEmpty(goldenColumnValue.Value)) {
						goldenColumnValue = columnValue;
						continue;
					}
					if (DataTypeUtilities.ValueIsNullOrEmpty(columnValue.Value)) {
						continue;
					}
					if (IsEquals(goldenColumnValue.Value, columnValue.Value) == false) {
						isConflictColumn = true;
						break;
					}
				}
				if (isConflictColumn) {
					conflictColumns.Add(column.Name);
				}
			}
			if (conflictColumns.Any()) {
				conflictColumns.AddRange(resolvedColumns);
				EntityCollection conflicts = GetEntityDublicates(schemaName, duplicateRecordIds, conflictColumns);
				Dictionary<string, string> columnMap = GetQueryColumns(conflicts.Schema.Columns);
				DataContract.EntityCollection convertedEntities =
					QueryExtension.GetEntityCollection(conflicts, columnMap);
				response.Conflicts = convertedEntities;
			}
			return response;
		}

		/// <summary>
		/// Setting group value to negative to exclude from result list for merge.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="groupId">Identifier of the group of search results.</param>
		public void ExcludeSearchResultGroup(string schemaName, int groupId) {
			int negativeGroupId = groupId * -1;
			string initialResultsTableName = string.Format("{0}{1}", schemaName, InitialResultsTableSuffix);
			if (!ValidateEntitySchema(initialResultsTableName)) {
				return;
			}
			var update = new Update(UserConnection, initialResultsTableName)
				.Set("GroupId", Column.Parameter(negativeGroupId))
					.Where("GroupId").IsEqual(Column.Parameter(groupId));
			update.Execute();
		}

		/// <summary>
		/// Merge collection of entities into golden entity.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="groupId">Identifier of the group of search results.</param>
		/// <param name="goldenRecordId">Golden entity record identifier.</param>
		/// <param name="duplicateRecordIds">Collection of entity unique identifiers.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		public virtual void MergeEntityDublicates(string schemaName, int groupId, List<Guid> duplicateRecordIds, Dictionary<string, string> resolvedConflicts) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			EntityCollection duplicates = GetEntityDublicates(schemaName, duplicateRecordIds);
			Entity goldenEntity = duplicates.FirstOrDefault();
			if (goldenEntity == null) {
				return;
			}
			duplicates.RemoveFirst();
			duplicateRecordIds.Remove(goldenEntity.PrimaryColumnValue);
			if (duplicates.Count == 0) {
				return;
			}
			Dictionary<string, string> detailMergeRules = GetDetailMergeRules(schemaName);
			Dictionary<string, List<string>> referencedTables = GetReferencedTablesInfo(schemaName);
			var entitySchemaOpposites = GetEntitySchemaOpposites(entitySchema.UId);
			string logIdSuffix = $"{schemaName}_{groupId}";
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.CommandTimeout = 3600;
				_log.Info($"START_TRANSACTION: {logIdSuffix}");
				dbExecutor.StartTransaction();
				foreach (var table in referencedTables) {
					string tableName = table.Key;
					_log.Info($"SCHEMA_NAME: {schemaName}, REF.TABLE_NAME: {tableName}, REF.COLUMNS: {string.Join(", ", table.Value)}");
					Guid goldRecordId = goldenEntity.PrimaryColumnValue;
					try {
						if (detailMergeRules.ContainsKey(tableName)) {
							string mergeRule = detailMergeRules[tableName];
							_log.Info($"START_MERGE_DETAIL_RECORDS_BY_RULE RULE:{mergeRule} TABLE:{tableName} GOLD_ID:{goldRecordId}");
							MergeDetailRecordsByRule(mergeRule, tableName, goldRecordId, duplicateRecordIds,
								dbExecutor, entitySchemaOpposites);
							_log.Info($"END_MERGE_DETAIL_RECORDS_BY_RULE RULE:{mergeRule} TABLE:{tableName} GOLD_ID:{goldRecordId}");
						} else {
							_log.Info($"START_UPDATE_REFERENCED_RECORDS TABLE:{tableName} GOLD_ID:{goldRecordId}");
							UpdateReferencedRecords(tableName, table.Value, goldRecordId, duplicateRecordIds,
								dbExecutor);
							_log.Info($"END_UPDATE_REFERENCED_RECORDS TABLE:{tableName} GOLD_ID:{goldRecordId}");
						}
					} catch {
						_log.Info($"START_INNER_ROLLBACK_TRANSACTION: {logIdSuffix}");
						dbExecutor.RollbackTransaction();
						_log.Info($"END_INNER_ROLLBACK_TRANSACTION: {logIdSuffix}");
						throw;
					}
				}
				try {
					_log.Info($"START_MERGE_DUPLICATES_WITH_GOLD_RECORD: {logIdSuffix}");
					MergeDuplicatesWithGoldRecord(goldenEntity, duplicates, resolvedConflicts);
					_log.Info($"END_MERGE_DUPLICATES_WITH_GOLD_RECORD: {logIdSuffix}");
					_log.Info($"START_DELETE_MASTER_RECORDS: ${logIdSuffix}");
					DeleteMasterRecords(schemaName, duplicateRecordIds, dbExecutor);
					_log.Info($"END_DELETE_MASTER_RECORDS: {logIdSuffix}");
					_log.Info($"START_SEND_DATA_TO_EXTERNAL_SERVICES: {logIdSuffix}");
					SendDataToExternalServices(entitySchema, duplicateRecordIds);
					_log.Info($"END_SEND_DATA_TO_EXTERNAL_SERVICES: {logIdSuffix}");
					_log.Info($"START_SAVE_GOLD_ENTITY: {logIdSuffix}");
					goldenEntity.Save();
					_log.Info($"END_SAVE_GOLD_ENTITY: {logIdSuffix}");
				} catch {
					_log.Info($"START_ROLLBACK_TRANSACTION: {logIdSuffix}");
					dbExecutor.RollbackTransaction();
					_log.Info($"END_ROLLBACK_TRANSACTION: {logIdSuffix}");
					RevertSearchResultGroupToPositive(schemaName, groupId);
					throw;
				}
				_log.Info($"START_COMMIT_TRANSACTION: {logIdSuffix}");
				dbExecutor.CommitTransaction();
				_log.Info($"END_COMMIT_TRANSACTION: {logIdSuffix}");
			}
			_log.Info($"START_DELETE_SEARCH_RESULT_GROUP: {logIdSuffix}");
			DeleteSearchResultGroup(schemaName, groupId);
			_log.Info($"END_DELETE_SEARCH_RESULT_GROUP: {logIdSuffix}");
			_log.Info($"START_MERGE_ENTITIES_FROM_SEARCH_RESULT: {logIdSuffix}");
			DeleteMergedEntitiesFromSearchResult(schemaName, duplicateRecordIds);
			_log.Info($"END_MERGE_ENTITIES_FROM_SEARCH_RESULT: {logIdSuffix}");
			_log.Info($"START_PERFORM_AFTER_DEDUPLICATION_ACTIONS: {logIdSuffix}");
			PerformAfterDeduplicationActions(goldenEntity);
			_log.Info($"END_PERFORM_AFTER_DEDUPLICATION_ACTIONS: {logIdSuffix}");
			if (UserConnection.GetIsFeatureEnabled("UseDuplicatesHistory")) {
				_log.Info($"START_LOG_MERGE_DUPLICATES_RECORDS: {logIdSuffix}");
				LogMergeDuplicatesRecords(schemaName, duplicateRecordIds, goldenEntity.PrimaryColumnValue);
				_log.Info($"END_LOG_MERGE_DUPLICATES_RECORDS: {logIdSuffix}");
			}
		}

		#endregion
	}

	#endregion

	#region Class: MergeConfigItem

	[Serializable]
	public class MergeConfigItem
	{
		[Json.JsonProperty("column")]
		public string Column { get; set; }
		[Json.JsonProperty("value")]
		public object Value { get; set; }
	}

	#endregion
}
