namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Xml;
	using BPMSoft.Common;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Configuration.SearchDuplicatesService;
	using EntityCollection = BPMSoft.Nui.ServiceModel.DataContract.EntityCollection;

	#region Class: EntityClientDuplicatesGroup

	/// <summary>
	/// Group of duplicates.
	/// </summary>
	[DataContract]
	public class EntityClientDuplicatesGroup
	{

		/// <summary>
		/// Identifier of group.
		/// </summary>
		[DataMember(Name = "groupId")]
		public int GroupId {
			get;
			set;
		}

		/// <summary>
		/// Collection duplicates.
		/// </summary>
		[DataMember(Name = "rows")]
		public EntityCollection Rows {
			get;
			set;
		}
	}

	#endregion

	#region Class: DuplicatesGroupResponse

	/// <summary>
	/// Contains groups of duplicates.
	/// </summary>
	[DataContract]
	public class DuplicatesGroupResponse
	{

		/// <summary>
		/// Collection of groups.
		/// </summary>
		[DataMember(Name = "groups")]
		public Collection<EntityClientDuplicatesGroup> Groups {
			get;
			set;
		}

		/// <summary>
		/// Configuration of columns.
		/// </summary>
		[DataMember(Name = "rowConfig")]
		public Dictionary<string, object> RowConfig {
			get;
			set;
		}

		/// <summary>
		/// Next start position of groups.
		/// </summary>
		[DataMember(Name = "nextOffset")]
		public int NextOffset {
			get;
			set;
		}

		/// <summary>
		/// Total count records in all groups.
		/// </summary>
		[DataMember(Name = "totalCountRecords")]
		public int TotalCountRecords {
			get;
			set;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public DuplicatesGroupResponse() {
			NextOffset = -1;
		}

	}

	#endregion

	#region Class: DuplicatesMergeResponse

	/// <summary>
	/// Merge response.
	/// </summary>
	[DataContract]
	public class DuplicatesMergeResponse
	{

		/// <summary>
		/// Result.
		/// </summary>
		[DataMember(Name = "success")]
		public bool Success {
			get;
			set;
		}

		/// <summary>
		/// Message.
		/// </summary>
		[DataMember(Name = "message")]
		public string Message {
			get;
			set;
		}

		/// <summary>
		/// Conflicts.
		/// </summary>
		[DataMember(Name = "conflicts")]
		public EntityCollection Conflicts {
			get;
			set;
		}
	}

	#endregion

	#region Class: DeduplicationProcessing

	/// <summary>
	/// Implement business logic handling duplicates.
	/// </summary>
	public class DeduplicationProcessing
	{

		#region Struct: Internal

		#region Struct: InitialResultItem

		/// <summary>
		/// Presents row from duplicate results.
		/// </summary>
		internal struct InitialResultItem
		{

			/// <summary>
			/// Identifier of the group.
			/// </summary>
			public int GroupId {
				get;
				set;
			}

			/// <summary>
			/// Unique identifier of the record.
			/// </summary>
			public Guid RecordId {
				get;
				set;
			}

		}

		#endregion

		#endregion

		#region Class: Internal

		#region Class: EntityDuplicatesGroup

		/// <summary>
		/// Group of duplicates.
		/// </summary>
		internal class EntityDuplicatesGroup
		{

			/// <summary>
			/// Identifier of the group.
			/// </summary>
			public int GroupId {
				get;
				set;
			}

			/// <summary>
			/// Collection duplicates.
			/// </summary>
			public Core.Entities.EntityCollection Duplicates {
				get;
				set;
			}

		}

		#endregion

		#endregion

		#region Constants: Private

		private const int GroupsPerRequest = 7;
		private const int RowsPerRequest = 1000;
		private const string InitialResultsTableSuffix = "DuplicateSearchResult";
		private const string RecordIdColumnNamePattern = "{0}Id";
		private const string MergeDuplicatesJobNamePattern = "{0}MergeDuplicates_{1}";
		private const string MergeDuplicatesProcessName = "DeduplicationActionProcess";
		private const string FindDuplicatesProcedureName = "tsp_FindDuplicate";
		private const string CreateOnColumnName = "CreatedOn";

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		private IActionLocker _locker;

		private IDeduplicationMergeHandler _mergeHandler;

		private IConversationProvider _conversationProvider;

		private Dictionary<string, string> _clientColumns;

		#endregion

		#region Properties: Protected

		protected IActionLocker Locker {
			get {
				return _locker ?? (_locker = new DeduplicationActionLocker(_userConnection));
			}
			set {
				_locker = value;
			}
		}

		protected IDeduplicationMergeHandler MergeHandler {
			get {
				return _mergeHandler ?? (_mergeHandler = ClassFactory.Get<DeduplicationMergeHandler>(
					new ConstructorArgument("userConnection", _userConnection)));
			}
			set {
				_mergeHandler = value;
			}
		}

		protected IConversationProvider ConversationProvider {
			get {
				return _conversationProvider ?? (_conversationProvider = new ConversationProvider(_userConnection));
			}
			set {
				_conversationProvider = value;
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public DeduplicationProcessing(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		protected RightsHelper GetRightsServiceHelper() {
			var args = new ConstructorArgument[] { 
				new ConstructorArgument("userConnection", _userConnection)
			};
			return ClassFactory.Get<RightsHelper>(args);
		}

		private Select CreateInitialResultsSelect(string schemaName, int offset) {
			string initialResultsTableName = $"{schemaName}{InitialResultsTableSuffix}";
			string recordIdColumnName = GetRecordIdColumnName(schemaName);
			Guid sysAdminUnitId = _userConnection.CurrentUser.Id;
			Select selectQuery = new Select(_userConnection)
					.Top(RowsPerRequest)
					.Column(recordIdColumnName)
					.Column("GroupId")
				.From(initialResultsTableName).As(initialResultsTableName)
				.Where(initialResultsTableName, "GroupId")
					.In(CreateSubSelect(initialResultsTableName, offset)) as Select;
			AddSysAdminUnitCondition(sysAdminUnitId, selectQuery);
			return selectQuery;
		}

		private List<InitialResultItem> GetInitialResults(string schemaName, int offset) {
			string recordIdColumnName = GetRecordIdColumnName(schemaName);
			List<InitialResultItem> result = new List<InitialResultItem>();
			Select initialResultsQuery = CreateInitialResultsSelect(schemaName, offset);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = initialResultsQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						InitialResultItem resultItem = new InitialResultItem();
						resultItem.RecordId = reader.GetColumnValue<Guid>(recordIdColumnName);
						resultItem.GroupId = reader.GetColumnValue<int>("GroupId");
						result.Add(resultItem);
					}
				}
			}
			return result;
		}

		private Query CreateSubSelect(string initialResultsTableName, int offset) {
			Guid sysAdminUnitId = _userConnection.CurrentUser.Id;
			Select select = new Select(_userConnection)
				.Distinct()
				.Top(GroupsPerRequest)
				.Column("GroupId")
				.From(initialResultsTableName)
				.Where(initialResultsTableName, "GroupId")
					.IsGreaterOrEqual(Column.Parameter(offset)) as Select;
			return select.OrderByAsc(initialResultsTableName, "GroupId");
		}

		private void AddSysAdminUnitCondition(Guid? sysAdminUnitId, Select selectQuery) {
			bool isFeatureEnable = _userConnection.GetIsFeatureEnabled("FindDuplicatesOnSave");
			if (isFeatureEnable) {
				if (sysAdminUnitId == null) {
					selectQuery.And("SysAdminUnitId").IsNull();
				} else {
					selectQuery.And("SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId));
				}
			}
		}

		private EntitySchemaQuery GetEsqForInitialRecords(string schemaName, int offset, string[] columns) {
			string recordIdColumnName = GetRecordIdColumnName(schemaName);
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			_clientColumns = new Dictionary<string, string>();
			foreach (var column in columns) {
				_clientColumns[esq.AddColumn(column).Name] = column;
			}
			if (!_clientColumns.ContainsKey(CreateOnColumnName)) {
				_clientColumns[esq.AddColumn(CreateOnColumnName).Name] = CreateOnColumnName;
			}
			Select esqSelect = esq.GetSelectQuery(_userConnection);
			Select initialSelect = CreateInitialResultsSelect(schemaName, offset);
			initialSelect.And(initialSelect.SourceExpression.Alias, recordIdColumnName)
				.IsEqual(esqSelect.SourceExpression.Alias, "Id");
			if (esqSelect.HasCondition) {
				esqSelect.And().Exists(initialSelect);
			} else {
				esqSelect.Where().Exists(initialSelect);
			}
			return esq;
		}

		private void RemoveInappropriateRecordsByRight(string schemaName, List<InitialResultItem> initResults) {
			List<Guid> recordIds = initResults.Select(initResult => initResult.RecordId).Distinct().ToList();
			RightsHelper rightsHelper = GetRightsServiceHelper();
			foreach (Guid recordId in recordIds) {
				bool canEdit = rightsHelper.GetCanEditSchemaRecordRight(schemaName, recordId);
				if (!canEdit) {
					initResults.RemoveAll(initResult => initResult.RecordId == recordId);
				}
			}
		}

		private List<EntityDuplicatesGroup> GroupEntityResults(List<InitialResultItem> initResults,
				Core.Entities.EntityCollection entities) {
			List<EntityDuplicatesGroup> result = new List<EntityDuplicatesGroup>();
			foreach (var initResult in initResults) {
				Entity entity = entities.Find(initResult.RecordId);
				if (entity != null) {
					EntityDuplicatesGroup groupItem =
						result.FirstOrDefault(group => group.GroupId == initResult.GroupId);
					if (groupItem == null) {
						groupItem = new EntityDuplicatesGroup() {
							GroupId = initResult.GroupId,
							Duplicates = new Core.Entities.EntityCollection(_userConnection, entity.SchemaName)
						};
						result.Add(groupItem);
					}
					groupItem.Duplicates.Add(entity);
				}
			}
			return result;
		}

		private void PrepareResults(List<EntityDuplicatesGroup> groupsCollection) {
			int minRecordsInGroup = 2;
			groupsCollection.RemoveAll(group => group.Duplicates.Count < minRecordsInGroup);
			groupsCollection.ForEach(group => {
				group.Duplicates.Order(group.Duplicates.Schema.PrimaryColumn.Name, OrderDirection.Ascending);
				group.Duplicates.Order(CreateOnColumnName, OrderDirection.Ascending);
			});
		}

		private Dictionary<string, string> GetQueryColumns(EntitySchemaQuery esq) {
			var columns = new Dictionary<string, string>();
			foreach (var column in esq.Columns) {
				string key = column.Name;
				columns[key] = _clientColumns.GetValueOrDefault(key, key);
			}
			return columns;
		}

		private DuplicatesGroupResponse ConvertServerEntityToClientEntity(EntitySchemaQuery esq,
				List<EntityDuplicatesGroup> entityGroups) {
			DuplicatesGroupResponse result = new DuplicatesGroupResponse() {
				Groups = new Collection<EntityClientDuplicatesGroup>()
			};
			Dictionary<string, string> serverToClientColumnNameMap = GetQueryColumns(esq);
			foreach (EntityDuplicatesGroup groupItem in entityGroups) {
				EntityCollection convertedEntities =
					QueryExtension.GetEntityCollection(groupItem.Duplicates,
						serverToClientColumnNameMap);
				EntityClientDuplicatesGroup clientGroup = new EntityClientDuplicatesGroup() {
					GroupId = groupItem.GroupId,
					Rows = convertedEntities
				};
				result.Groups.Add(clientGroup);
			}
			if (result.Groups.Any()) {
				Dictionary<string, object> columnConfig =
					QueryExtension.GetColumnConfig(esq, serverToClientColumnNameMap);
				result.RowConfig = columnConfig;
			}
			result.Groups.OrderBy(group => group.GroupId);
			return result;
		}

		private string GetRecordIdColumnName(string schemaName) {
			return string.Format(RecordIdColumnNamePattern, schemaName);
		}

		private XmlDocument GetPreparedXml(SingleRequest request) {
			XmlDocument xml = new XmlDocument();
			XmlElement elementRows = xml.CreateElement("rows");
			List<RequestCommunication> communicationsList = request.Communication ?? new List<RequestCommunication>();
			foreach (RequestCommunication communication in communicationsList) {
				XmlElement elementRow = xml.CreateElement("row");
				XmlElement elementCommunicationTypeId = xml.CreateElement("CommunicationTypeId");
				elementCommunicationTypeId.InnerText = communication.CommunicationTypeId.ToString();
				XmlElement elementNumber = xml.CreateElement("Number");
				elementNumber.InnerText = communication.Number;
				elementRow.AppendChild(elementCommunicationTypeId);
				elementRow.AppendChild(elementNumber);
				AddElementsToRow(xml, elementRow, request);
				elementRows.AppendChild(elementRow);
			}
			if (communicationsList.Count < 1) {
				XmlElement elementRow = xml.CreateElement("row");
				AddElementsToRow(xml, elementRow, request);
				elementRows.AppendChild(elementRow);
			}
			xml.AppendChild(elementRows);
			return xml;
		}

		private void AddElementsToRow(XmlDocument xml, XmlElement elementRow, SingleRequest request) {
			XmlElement elementName = xml.CreateElement("Name");
			elementName.InnerText = request.Name;
			elementRow.AppendChild(elementName);
			if (request.Id != Guid.Empty) {
				XmlElement elementId = xml.CreateElement("Id");
				elementId.InnerText = request.Id.ToString();
				elementRow.AppendChild(elementId);
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual void ExecuteStoreProcedureWithParameters(string procedureName, Dictionary<string, object> parameters) {
			var storedProcedure = new StoredProcedure(_userConnection, procedureName);
			parameters.ForEach(p => storedProcedure.WithParameter(p.Key, p.Value));
			storedProcedure.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns groups of duplicates.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="columns">Requested columns.</param>
		/// <param name="offset">Start position for groups.</param>
		/// <returns>Instance <see cref="DuplicatesGroupResponse"/> contains groups of duplicates.</returns>
		public virtual DuplicatesGroupResponse GetDeduplicationResults(string schemaName, string[] columns,
				int offset) {
			offset = offset == 0 ? 1 : offset;
			List<InitialResultItem> initialResults = GetInitialResults(schemaName, offset);
			DuplicatesGroupResponse result = new DuplicatesGroupResponse();
			if (initialResults.Any()) {
				int groupIdMax = initialResults.Max(initialItem => initialItem.GroupId);
				RemoveInappropriateRecordsByRight(schemaName, initialResults);
				EntitySchemaQuery esqEntityResults = GetEsqForInitialRecords(schemaName, offset, columns);
				EntitySchemaQueryOptions options = new EntitySchemaQueryOptions {
					PageableDirection = PageableSelectDirection.First,
					PageableRowCount = RowsPerRequest,
					PageableConditionValues = new Dictionary<string, object>()
				};
				Core.Entities.EntityCollection entityResults = esqEntityResults.GetEntityCollection(_userConnection, options);
				List<EntityDuplicatesGroup> entityGroups = GroupEntityResults(initialResults, entityResults);
				PrepareResults(entityGroups);
				result = ConvertServerEntityToClientEntity(esqEntityResults, entityGroups);
				if (initialResults.Select(group => group.GroupId).Distinct().Count() == GroupsPerRequest) {
					result.NextOffset = groupIdMax;
					result.NextOffset++;
				}
			}
			return result;
		}

		/// <summary>
		/// Moves records group to ignore list.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="deduplicateRecordIds">Unique identifiers.</param>
		public void AddToIgnoreList(string schemaName, List<string> deduplicateRecordIds) {
			string duplicateRecordIdsToString = string.Join(",", deduplicateRecordIds.ToArray());
			var storedProcedure = new StoredProcedure(_userConnection, "tsp_AddDuplicatesToIgnoreList");
			storedProcedure.WithParameter("SchemaName", schemaName);
			storedProcedure.WithParameter("Duplicates", duplicateRecordIdsToString);
			storedProcedure.Execute();
		}

		/// <summary>
		/// Invokes merge process
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="groupId">Identifier of the group of search results</param>
		/// <param name="deduplicateRecordIds">Unique identifiers.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		/// <returns>Instance <see cref="DuplicatesMergeResponse"/> results for merge process execution.</returns>
		public virtual DuplicatesMergeResponse MergeEntityDuplicatesAsync(string schemaName, int groupId,
					List<Guid> duplicateRecordIds, Dictionary<string, string> resolvedConflicts = null) {
			DuplicatesMergeResponse result = new DuplicatesMergeResponse();
			if (!Locker.CanExecute(DeduplicationConsts.SearchOperationId, schemaName)) {
				return result;
			}
			ValidateDuplicatesResponse response = MergeHandler.ValidateDuplicates(schemaName, duplicateRecordIds, resolvedConflicts);
			if (response.ConflictsExists) {
				result.Conflicts = response.Conflicts;
				return result;
			}
			MergeHandler.ExcludeSearchResultGroup(schemaName, groupId);
			string jobName = string.Format(MergeDuplicatesJobNamePattern, schemaName, Guid.NewGuid());
			var parameters = new Dictionary<string, object>() {
				{ "SchemaName" , schemaName },
				{ "OperationId", DeduplicationConsts.MergeOperationId },
				{ "DuplicateGroupId", groupId },
				{ "DuplicateRecordIds", duplicateRecordIds },
				{ "ResolvedConflicts", resolvedConflicts }
			};
			AppScheduler.ScheduleImmediateProcessJob(jobName, "Dedublication", MergeDuplicatesProcessName,
				_userConnection.Workspace.Name, _userConnection.CurrentUser.Name, parameters);
			result.Success = true;
			return result;
		}

		/// <summary>
		/// Performs search duplicates records using stored procedure.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="searchValues">Values to find duplicates records.</param>
		/// <returns>Results for find duplicates.</returns>
		public virtual List<Guid> FindDuplicates(string schemaName, XmlDocument searchValues) {
			List<Guid> records = new List<Guid>();
			Guid conversationId = ConversationProvider.BeginConversation(FindDuplicatesProcedureName);
			Guid sysAdminUnitId = _userConnection.CurrentUser.Id;
			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{"schemaName", schemaName},
				{"xmlRows", searchValues.OuterXml},
				{"sysAdminUnit", sysAdminUnitId}
			};
			try {
				ExecuteStoreProcedureWithParameters(FindDuplicatesProcedureName, parameters);
				ConversationProvider.EndConversation(conversationId);
				List<InitialResultItem> result = GetInitialResults(schemaName, 0);
				records = result.Select(r => r.RecordId).Distinct().ToList();
			} catch (Exception e) {
				ConversationProvider.EndConversationWithError(conversationId, -1, e.Message);
			}
			return records;
		}

		public virtual List<Guid> FindDuplicates(string schemaName, SingleRequest data) {
			XmlDocument xml = GetPreparedXml(data);
			return FindDuplicates(schemaName, xml);
		}

		#endregion

	}

	#endregion
}
