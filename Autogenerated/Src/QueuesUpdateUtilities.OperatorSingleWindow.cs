namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using CoreConfiguration = BPMSoft.Core.Configuration;
	using ServiceDataContract = BPMSoft.Nui.ServiceModel.DataContract;

	#region Class: QueuesUpdateUtilities

	/// <summary>
	/// Utility class for work with queues.
	/// </summary>
	public class QueuesUpdateUtilities
	{

		#region Struct: Protected

		/// <summary>
		/// Structure for cacheable information for the queue.
		/// </summary>
		protected struct QueueInfo
		{
			/// <summary>
			/// Time of the last queue items update.
			/// </summary>
			public DateTime QueueItemsUpdatedOn;

			/// <summary>
			/// Count of not handled elements in queue.
			/// </summary>
			public int QueueItemsCount;
		}

		#endregion

		#region Constants: Private

		/// <summary>
		/// ########## ########### ########### ####### # ######## ####### ## #########.
		/// </summary>
		private const int DefaultInsertQueueItemTopValue = 1000;

		/// <summary>
		/// ############ ########## ############## ######### # ####### ## #########.
		/// </summary>
		private const int DefaultMaximumQueueItemsInQueue = 10000;

		/// <summary>
		/// Maximum number of the specified values in a list of the "IN" query expression by default.
		/// </summary>
		private const int DefaultMaximumQueueIdQueryParameters = 2000;

		#endregion

		#region Fields: Private

			/// <summary>
			/// ############# ######### ######## # ####### ####### #### "## #########".
			/// </summary>
		private readonly Guid _newQueueItemStatusId = new Guid("{2B341A1D-6FA1-4960-9C85-FEF60D1BBCC4}");

		/// <summary>
		/// ########## ########### ########### ####### # ######## ####### ## #########.
		/// </summary>
		private readonly int _insertQueueItemTopValue;

		/// <summary>
		/// ############ ########## ############## ######### # ####### ## #########.
		/// </summary>
		private readonly int _maximumQueueItemsInQueue;

		private readonly ICacheStore _cache;
		private static readonly string _expireGroupKey =
			"QueueItemsUpdatedOnGroup_527675BC-91F8-4E4D-94C1-FC1F2C416B3C";
		private readonly string _cacheItemName = "QueueItemsUpdatedOn_527675BC-91F8-4E4D-94C1-FC1F2C416B3C";

		#endregion

		#region Fields: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected readonly UserConnection _userConnection;

		/// <summary>
		/// Auto update queues process identifier.
		/// </summary>
		protected Guid _autoUpdateQueuesProcessId;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// ########### ###### ####### ### ###### # ######## # ###### ####.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns></returns>
		public QueuesUpdateUtilities(UserConnection userConnection) {
			_userConnection = userConnection;
			_insertQueueItemTopValue = GetInsertQueueItemTopValue();
			_maximumQueueItemsInQueue = GetMaximumQueueItemsInQueue();
			_cache = Store.Cache[CacheLevel.Application].WithLocalCachingOnly(_expireGroupKey);
		}

		#endregion

		#region Properties: Private

		private ConcurrentDictionary<Guid, QueueInfo> QueuesInfo {
			get {
				var result = _cache[_cacheItemName] as ConcurrentDictionary<Guid, QueueInfo>;
				if (result == null) {
					QueuesUtilities.LogWarn("QueuesInfo in cache is null, creating");
					result = new ConcurrentDictionary<Guid, QueueInfo>();
					_cache[_cacheItemName] = result;
				}
				return result;
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns number of records that simultaneity adding to queue items.
		/// </summary>
		/// <returns></returns>
		private int GetInsertQueueItemTopValue() {
			return CoreConfiguration.SysSettings.GetValue(_userConnection, "InsertQueueItemTopValue",
				DefaultInsertQueueItemTopValue);
		}

		/// <summary>
		/// Returns maximum number of rough queue items.
		/// </summary>
		/// <returns></returns>
		private int GetMaximumQueueItemsInQueue() {
			return CoreConfiguration.SysSettings.GetValue(_userConnection, "MaximumQueueItemsInQueue",
				DefaultMaximumQueueItemsInQueue);
		}

		/// <summary>
		/// Returns maximum number of the specified values in a list of the "IN" query expression.
		/// </summary>
		private int GetMaximumQueueIdQueryParameters() {
			return CoreConfiguration.SysSettings.GetValue(_userConnection, "MaximumQueueIdQueryParameters",
				DefaultMaximumQueueIdQueryParameters);
		}

		/// <summary>
		/// Deletes elements from queue with filtration.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name in queue.</param>
		/// <param name="entitySelect">Query to queue object with filtration.</param>
		/// <param name="queueId">Identifier of queue.</param>
		/// <param name="queueName">Queue name.</param>
		/// <param name="entityRecordId">Queue item entity identifier.</param>
		/// <returns>Deleted queue items count.</returns>
		private int DeleteEntityQueueItemsByFilter(string entitySchemaName, Select entitySelect, Guid queueId,
				string queueName, Guid entityRecordId) {
			try {
				var idColumnExpression = new QueryColumnExpression(entitySchemaName, "Id");
				var selectCondition = new QueryCondition(idColumnExpression);
				selectCondition.IsEqual("QueueItem", "EntityRecordId");
				if (!entitySelect.HasCondition) {
					entitySelect.Where(selectCondition);
				} else {
					entitySelect.And(selectCondition);
				}
				Select select =
					(Select)new Select(_userConnection)
						.Column("Id")
					.From("QueueItemStatus")
					.Where("IsFinal").IsEqual(Column.Parameter(false));
				var delete =
					(Delete)new Delete(_userConnection)
						.From("QueueItem")
					.Where("OperatorId").IsNull()
					.And("QueueItem", "QueueId").IsEqual(Column.Parameter(queueId))
					.And("StatusId").In(Column.SubSelect(select))
					.And().Not().Exists(entitySelect);
				if (entityRecordId.IsNotEmpty()) {
					delete.And("EntityRecordId").IsEqual(Column.Parameter(entityRecordId));
				}
				DateTime addedRecordsStartTime = DateTime.Now;
				int deletedRecords = delete.Execute();
				if (addedRecordsStartTime.AddSeconds(60) < DateTime.Now) {
					delete.BuildParametersAsValue = true;
					QueuesUtilities.LogDebug(string.Format(GetResourceValue("LongDeleteQueueItemsMessage"),
						queueName, _autoUpdateQueuesProcessId.ToString(), delete.GetSqlText()));
				}
				return deletedRecords;
			} catch (Exception e) {
				QueuesUtilities.LogError(string.Format(GetResourceValue("InvokeMethodErrorMessage"),
					string.Concat("DeleteEntityQueueItemsByFilter ", queueName), e.Message), e);
				throw;
			}
		}

		/// <summary>
		/// Adds elements from queue with filtration.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name of queue element.</param>
		/// <param name="entitySelect">Query to queue object with filtration.</param>
		/// <param name="queueId">Identifier of queue.</param>
		/// <param name="queueName">Queue name.</param>
		/// <param name="itemsCount">Count of not handled elements in queue.</param>
		/// <returns>Added queue items count.</returns>
		private int AddEntityQueueItemsByFilter(string entitySchemaName, Select entitySelect, Guid queueId,
				string queueName, int itemsCount) {
			try {
				if (itemsCount >= _maximumQueueItemsInQueue) {
					QueuesUtilities.LogWarn(string.Format(GetResourceValue("QueueMaximumItemsWarning"), queueName));
					return 0;
				}
				entitySelect.Top(_insertQueueItemTopValue)
					.Column(new QueryParameter("QueueId", queueId)).As("QueueId")
					.Column(new QueryParameter("StatusId", _newQueueItemStatusId)).As("StatusId");
				var selectCondition = new QueryCondition();
				selectCondition.IsNot = true;
				selectCondition.Exists(
					new Select(_userConnection)
						.Column("QueueItem", "Id")
					.From("QueueItem")
					.InnerJoin("QueueItemStatus")
					.On("QueueItemStatus", "Id").IsEqual("QueueItem", "StatusId")
					.Where(entitySchemaName, "Id").IsEqual("QueueItem", "EntityRecordId")
					.And("QueueItem", "QueueId").IsEqual(Column.Parameter(queueId))
					.And("QueueItemStatus", "IsFinal").IsNotEqual(Column.Parameter(true)));
				if (!entitySelect.HasCondition) {
					entitySelect.Where(selectCondition);
				} else {
					entitySelect.And(selectCondition);
				}
				var insertSelect = new InsertSelect(_userConnection)
					.Into("QueueItem")
					.Set("EntityRecordId", "QueueId", "StatusId")
					.FromSelect(entitySelect);
				DateTime addedRecordsStartTime = DateTime.Now;
				int addedRecords = insertSelect.Execute();
				if (addedRecordsStartTime.AddSeconds(60) < DateTime.Now) {
					insertSelect.BuildParametersAsValue = true;
					QueuesUtilities.LogDebug(string.Format(GetResourceValue("LongInsertQueueItemsMessage"),
						queueName, _autoUpdateQueuesProcessId.ToString(), insertSelect.GetSqlText()));
				}
				return addedRecords;
			} catch (Exception e) {
				QueuesUtilities.LogError(string.Format(GetResourceValue("InvokeMethodErrorMessage"),
					string.Concat("AddEntityQueueItemsByFilter ", queueName), e.Message), e);
				throw;
			}
		}

		/// <summary>
		/// Returns a query to select the number of queue items.
		/// </summary>
		/// <param name="queryParameters">Query parameters.</param>
		/// <returns>Instance of the <see cref="Select"/> type.</returns>
		private Select GetQueueCountItemSelect(IEnumerable<Guid> queryParameters) {
			return (Select)new Select(_userConnection).WithHints(Hints.NoLock)
					.Column("Q", "Id").As("QueueId")
					.Column(Func.Count("QueueId")).As("QueueItemsCount")
				.From("QueueItem").As("QI")
					.RightOuterJoin("Queue").As("Q")
						.On("Q", "Id").IsEqual("QueueId")
				.Where("Q", "Id").In(Column.Parameters(queryParameters))
				.GroupBy("Q", "Id");
		}

		private void ProcessQueueChunk(IEnumerable<Guid> chunkItems, Dictionary<Guid, Entity> queueIdEntityMap) {
			Select countQueueItemsSelect = GetQueueCountItemSelect(chunkItems);
			countQueueItemsSelect.BuildParametersAsValue = true;
			QueuesUtilities.LogInfo($"ProcessQueueChunk select text = {countQueueItemsSelect.GetSqlText()}");
			countQueueItemsSelect.ExecuteReader(dataReader => {
				Guid queueId = dataReader.GetColumnValue<Guid>("QueueId");
				QueuesUtilities.LogInfo($"[ProcessQueueChunk] getting queueId = {queueId}," +
					$" QueuesInfo.ContainsKey = {QueuesInfo.ContainsKey(queueId)}," +
					$" QueuesInfo keys [{String.Join(",", QueuesInfo.Keys.Select(i => i.ToString()).ToArray())}]");
				if (QueuesInfo.ContainsKey(queueId)) {
					QueuesUtilities.LogInfo($"[ProcessQueueChunk] try get queueId = {queueId}");
					QueueInfo queueInfo = QueuesInfo[queueId];
					QueuesUtilities.LogInfo($"[ProcessQueueChunk] gotten queueId = {queueId}");
					queueInfo.QueueItemsCount = dataReader.GetColumnValue<int>("QueueItemsCount");
					ProcessAutoUpdateQueue(queueId, queueInfo, queueIdEntityMap[queueId]);
				} else {
					 QueuesUtilities.LogInfo($"[ProcessQueueChunk] not contains queueId = {queueId}");
				}
			});
		}

		private Select GetEntityQueueItemSelectQuery(ServiceDataContract.Filters filters, string entitySchemaName, Guid entityId) {
			Select queueFilters = GetQueueEntitySelectWithFilter(entitySchemaName, filters);
			queueFilters.And("Id").IsEqual(Column.Parameter(entityId));
			return queueFilters;
		}

		private void ProcessEntityQueueItem(string queueName, Guid queueId, string entitySchemaName, Guid entityId, string action,
				ServiceDataContract.Filters filters, int queueItemsCount) {
			switch (action) {
				case "Inserted":
					Select addQueueFilters = GetEntityQueueItemSelectQuery(filters, entitySchemaName, entityId);
					AddEntityQueueItemsByFilter(entitySchemaName, addQueueFilters, queueId, queueName, queueItemsCount);
					break;
				case "Updated":
					Select queueFilters = GetEntityQueueItemSelectQuery(filters, entitySchemaName, entityId);
					AddEntityQueueItemsByFilter(entitySchemaName, queueFilters, queueId, queueName, queueItemsCount);
					queueFilters = GetQueueEntitySelectWithFilter(entitySchemaName, filters);
					DeleteEntityQueueItemsByFilter(entitySchemaName, queueFilters, queueId, queueName, entityId);
					break;
				case "Deleted":
					Select deleteQueueFilters = GetQueueEntitySelectWithFilter(entitySchemaName, filters);
					DeleteEntityQueueItemsByFilter(entitySchemaName, deleteQueueFilters, queueId, queueName, entityId);
					break;
				default:
					break;
			}
		}


		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns query for the queue object schema.
		/// </summary>
		/// <returns>Instance of the type <see cref="EntitySchemaQuery"/> type.</returns>
		protected virtual EntitySchemaQuery GetQueueEntitySchemaQuery() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Queue") {
				UseAdminRights = false,
				CanReadUncommitedData = true,
				IgnoreDisplayValues = true
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Name");
			EntitySchemaQueryColumn frequency =
				esq.AddColumn("[QueueUpdateFrequency:Id:QueueUpdateFrequency].Frequency");
			frequency.Name = "Frequency";
			esq.AddColumn("FilterEditData");
			esq.AddColumn("QueueEntitySchema");
			EntitySchemaQueryFilterCollection esqFilters = esq.Filters;
			IEntitySchemaQueryFilterItem isManuallyFillingFilterItem =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsManuallyFilling", false);
			esqFilters.Add(isManuallyFillingFilterItem);
			IEntitySchemaQueryFilterItem statusIsInitialFilterItem =
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status.IsInitial", true);
			esqFilters.Add(statusIsInitialFilterItem);
			IEntitySchemaQueryFilterItem statusIsFinalFilterItem =
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status.IsFinal", true);
			esqFilters.Add(statusIsFinalFilterItem);
			return esq;
		}

		/// <summary>
		/// Returns query for the queue object schema.
		/// </summary>
		/// <param name="queueId">Queue unique identifier.</param>
		/// <returns>Instance of the type <see cref="EntitySchemaQuery"/> type.</returns>
		protected virtual EntitySchemaQuery GetQueueEntitySchemaQuery(Guid queueId) {
			var esq = GetQueueEntitySchemaQuery();
			if (queueId.IsNotEmpty()) {
				IEntitySchemaQueryFilterItem singleQueryUpdateFilterItem =
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", queueId);
				esq.Filters.Add(singleQueryUpdateFilterItem);
			}
			return esq;
		}

		/// <summary>
		/// Updates content of auto updating queues.
		/// </summary>
		/// <param name="queueId">Identifier of queue.</param>
		/// <param name="queueInfo"><see cref="QueueInfo"/> structure.</param>
		/// <param name="queueEntity"><see cref="Entity"/> object for the queue.</param>
		protected virtual void ProcessAutoUpdateQueue(Guid queueId, QueueInfo queueInfo, Entity queueEntity) {
			var queueItemsInfo = new Dictionary<Guid, int> {
				{ queueId, queueInfo.QueueItemsCount }
			};
			var keyValuePair = new KeyValuePair<Guid, Entity>(queueId, queueEntity);
			ProcessAutoUpdateQueue(queueItemsInfo, keyValuePair);
		}

		/// <summary>
		/// Updates content of auto updating queues.
		/// </summary>
		/// <param name="queueItemsInfo">Dictionary with queue items data, where the key represents unique identifier
		/// of the queue entity and value - number of items.</param>
		/// <param name="keyValuePair">Key/value pair, where key gets the unique identifier of the queue
		/// and value - queue data.</param>
		protected virtual void ProcessAutoUpdateQueue(Dictionary<Guid, int> queueItemsInfo,
				KeyValuePair<Guid, Entity> keyValuePair) {
			int queueItemsCount;
			Guid queueId = keyValuePair.Key;
			queueItemsInfo.TryGetValue(queueId, out queueItemsCount);
			Entity currentEntity = keyValuePair.Value;
			string queueName = currentEntity.GetTypedColumnValue<string>("Name");
			string filterEditData = currentEntity.GetTypedColumnValue<string>("FilterEditData");
			ProcessAutoUpdateQueueItems(queueId, queueName, filterEditData, queueItemsCount);
		}

		/// <summary>
		/// Updates content of autoupdating queue.
		/// </summary>
		/// <param name="queueId">Identifier of queue.</param>
		/// <param name="queueName">Name of queue.</param>
		/// <param name="filterData">Serialized filter.</param>
		/// <param name="itemsCount">Count of not handled elements in queue.</param>
		protected void ProcessAutoUpdateQueueItems(Guid queueId, string queueName, string filterData, int itemsCount) {
			try {
				if (filterData.IsNullOrEmpty()) {
					QueuesUtilities.LogWarn(string.Format(GetResourceValue("EmptyQueueFiltersWarning"),
						queueName));
					return;
				}
				ServiceDataContract.Filters filters = Json.Deserialize<ServiceDataContract.Filters>(filterData);
				if ((filters == null) || ((filters.FilterType == ServiceDataContract.FilterType.FilterGroup)
						&& (filters.Items.Count == 0))) {
					QueuesUtilities.LogWarn(string.Format(GetResourceValue("EmptyQueueFiltersWarning"),
						queueName));
					return;
				}
				string entitySchemaName = filters.RootSchemaName;
				int addedRecords = 0;
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("StartInsertQueueItemsMessage"),
					queueName, _autoUpdateQueuesProcessId.ToString()));
				Select addEntitySelect = GetQueueEntitySelectWithFilter(entitySchemaName, filters);
				addedRecords = AddEntityQueueItemsByFilter(entitySchemaName, addEntitySelect, queueId, queueName, itemsCount);
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("EndInsertQueueItemsMessage"),
					queueName, _autoUpdateQueuesProcessId.ToString()));
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("StartDeleteQueueItemsMessage"),
					queueName, _autoUpdateQueuesProcessId.ToString()));
				Select deleteEntitySelect = GetQueueEntitySelectWithFilter(entitySchemaName, filters);
				var deletedRecords = DeleteEntityQueueItemsByFilter(entitySchemaName, deleteEntitySelect, queueId, queueName, Guid.Empty);
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("EndDeleteQueueItemsMessage"),
					queueName, _autoUpdateQueuesProcessId.ToString()));
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("ProcessAutoUpdateQueueResultMessage"),
					queueName, addedRecords, deletedRecords));
			} catch (Exception e) {
				QueuesUtilities.LogError(string.Format(GetResourceValue("InvokeMethodErrorMessage"),
					string.Concat("ProcessAutoUpdateQueueItems ", queueName), e.Message), e);
			}
		}

		/// <summary>
		/// Returns resource value.
		/// </summary>
		/// <param name="resourceName">Resource name.</param>
		/// <returns>Resource value</returns>
		protected string GetResourceValue(string resourceName) {
			IResourceStorage resourceStorage = _userConnection.Workspace.ResourceStorage;
			var resource = new LocalizableString(resourceStorage, "QueuesUpdateUtilities",
				string.Format("LocalizableStrings.{0}.Value", resourceName));
			return resource.Value;
		}

		/// <summary>
		/// Returns queue object query with filtration.
		/// </summary>
		/// <param name="entitySchemaName">Queue object schema name.</param>
		/// <param name="filters">Queue object filters.</param>
		/// <returns>Queue object query with filtration</returns>
		protected Select GetQueueEntitySelectWithFilter(string entitySchemaName, ServiceDataContract.Filters filters) {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, entitySchemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			IEntitySchemaQueryFilterItem esqFilters = filters.BuildEsqFilter(entitySchemaName, _userConnection);
			esq.Filters.Add(esqFilters);
			return esq.GetSelectQuery(_userConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates content of auto updating queues.
		/// </summary>
		public virtual void ProcessAutoUpdateQueues() {
			ProcessAutoUpdateQueues(Guid.Empty);
		}


		/// <summary>
		/// Updates content of auto updating queues.
		/// </summary>
		public virtual void ProcessAutoUpdateQueues(Guid singleQueueId) {
			_autoUpdateQueuesProcessId = Guid.NewGuid();
			QueuesUtilities.LogDebug(string.Format(GetResourceValue("StartProcessAutoUpdateQueuesMessage"),
				_autoUpdateQueuesProcessId.ToString()));
			try {
				int maximumQueueIdQueryParameters = GetMaximumQueueIdQueryParameters();
				Dictionary<Guid, Entity> queueIdEntityMap = GetQueueIdEntityMap(singleQueueId);
				var chunkItems = new HashSet<Guid>();
				ConcurrentDictionary<Guid, QueueInfo> queuesInfo = QueuesInfo;
				foreach (KeyValuePair<Guid, Entity> queue in queueIdEntityMap) {
					Guid queueId = queue.Key;
					QueueInfo queueInfo;
					QueuesUtilities.LogInfo($"[ProcessAutoUpdateQueues] QueuesInfo check contains value with key {queueId}");
					if (queuesInfo.ContainsKey(queueId)) {
						QueuesUtilities.LogInfo($"[ProcessAutoUpdateQueues] QueuesInfo getting value with key {queueId}");
						queueInfo = queuesInfo[queueId];
						QueuesUtilities.LogInfo($"[ProcessAutoUpdateQueues] QueuesInfo gotten value with key {queueId}");
						Entity queueEntity = queue.Value;
						int queueFrequency = queueEntity.GetTypedColumnValue<int>("Frequency");
						if (queueInfo.QueueItemsUpdatedOn.AddMinutes(queueFrequency) > DateTime.UtcNow && !queueId.Equals(singleQueueId)) {
							continue;
						}
					} else {
						QueuesUtilities.LogInfo($"[ProcessAutoUpdateQueues] QueuesInfo not contains value with key {queueId}");
						queueInfo = new QueueInfo();
					}
					queueInfo.QueueItemsUpdatedOn = DateTime.UtcNow;
					QueuesUtilities.LogInfo($"[ProcessAutoUpdateQueues] QueuesInfo add with key {queueId}");
					queuesInfo[queueId] = queueInfo;
					QueuesUtilities.LogInfo($"[ProcessAutoUpdateQueues] QueuesInfo added with key {queueId}");
					chunkItems.Add(queueId);
					if (chunkItems.Count >= maximumQueueIdQueryParameters) {
						ProcessQueueChunk(chunkItems, queueIdEntityMap);
						chunkItems.Clear();
					}
				}
				if (chunkItems.Count > 0) {
					ProcessQueueChunk(chunkItems, queueIdEntityMap);
				}
			} catch (Exception e) {
				QueuesUtilities.LogError(string.Format(GetResourceValue("InvokeMethodErrorMessage"), "ProcessAutoUpdateQueues", e.Message), e);
				throw;
			} finally {
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("EndProcessAutoUpdateQueuesMessage"),
					_autoUpdateQueuesProcessId.ToString()));
			}
		}

		/// <summary>
		/// Deletes elements from not active queues.
		/// </summary>
		public void ProcessDeleteInactiveQueueItems() {
			try {
				var statusColumns = new List<QueryColumnExpression> {
					new QueryColumnExpression("QueueStatus", "IsFinal"),
					new QueryColumnExpression("QueueStatus", "IsInitial")
				};
				Select queueSelect =
					(Select)new Select(_userConnection)
						.Column("Queue", "Id")
					.From("Queue")
					.InnerJoin("QueueStatus").On("Queue", "StatusId").IsEqual("QueueStatus", "Id")
					.Where("Queue", "Id").IsEqual("QueueItem", "QueueId")
					.And("Queue", "IsManuallyFilling").IsEqual(new QueryParameter(false))
					.And(new QueryParameter(true)).In(statusColumns);
				var delete = (Delete)new Delete(_userConnection)
					.From("QueueItem")
					.Where("OperatorId").IsNull()
					.And().Exists(queueSelect);
				var deletedRecords = delete.Execute();
				QueuesUtilities.LogDebug(string.Format(GetResourceValue("DeleteInactiveQueueItemsMessage"),
					deletedRecords));
			} catch (Exception e) {
				QueuesUtilities.LogError(string.Format(GetResourceValue("InvokeMethodErrorMessage"),
					"ProcessDeleteInactiveQueueItems", e.Message), e);
				throw;
			}
		}

		/// <summary>
		/// Clears the queues information cache.
		/// </summary>
		public void ClearQueuesInfoCache() {
			QueuesUtilities.LogWarn("QueuesInfo remove from cache");
			_cache.Remove(_cacheItemName);
		}

		/// <summary>
		/// Gets queue objects map.
		/// </summary>
		/// <param name="queueId"><see cref="Queue"/> instance identifier.</param>
		/// <returns><see cref="Dictionary<Guid, Entity>"/> instance.</returns>
		public virtual Dictionary<Guid, Entity> GetQueueIdEntityMap(Guid queueId) {
			EntitySchemaQuery esq = GetQueueEntitySchemaQuery(queueId);
			var queueCacheHelper = new QueueCacheHelper(_userConnection, esq);
			EntityCollection queueEntities = queueCacheHelper.Items;
			var queueIdEntityMap = new Dictionary<Guid, Entity>(queueEntities.Count);
			foreach (Entity entity in queueEntities) {
				Guid id = entity.GetTypedColumnValue<Guid>("Id");
				queueIdEntityMap[id] = entity;
			}
			return queueIdEntityMap;
		}

		/// <summary>
		/// Processes entity queue item event.
		/// </summary>
		/// <param name="queueName"><see cref="Queue"/> instance name.</param>
		/// <param name="queueId"><see cref="Queue"/> instance identifier.</param>
		/// <param name="entitySchemaName"><see cref="Entity"/> schema name of <see cref="Queue"/> instance element.</param>
		/// <param name="entityId"><see cref="Entity"/> instance identifier.</param>
		/// <param name="action"><see cref="Entity"/> instance action type.</param>
		/// <param name="filterData"><see cref="Queue"/> instance filters.</param>
		public virtual void ProcessEntityQueueItemEvent(string queueName, Guid queueId, string entitySchemaName, Guid entityId, string action, string filterData) {
			if (filterData.IsNullOrEmpty()) {
				QueuesUtilities.LogWarn($"Queue {queueName} with automatic population has no filters");
				return;
			}
			ServiceDataContract.Filters filters = Json.Deserialize<ServiceDataContract.Filters>(filterData);
			if ((filters == null) || ((filters.FilterType == ServiceDataContract.FilterType.FilterGroup) && (filters.Items.Count == 0))) {
				QueuesUtilities.LogWarn($"Queue {queueName} with automatic population has no filters");
				return;
			}
			Select countQueueItemsSelect = GetQueueCountItemSelect(new List<Guid>() { queueId });
			countQueueItemsSelect.ExecuteReader(dataReader => {
				int queueItemsCount = dataReader.GetColumnValue<int>("QueueItemsCount");
				ProcessEntityQueueItem(queueName, queueId, entitySchemaName, entityId, action, filters, queueItemsCount);
			});
		}

		#endregion

	}

	#endregion

}

