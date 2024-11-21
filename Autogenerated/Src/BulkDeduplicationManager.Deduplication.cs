namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Net;
	using DeduplicationElastic.Domain.Deduplication.Task;
	using DeduplicationElastic.WebApi.Contracts.Requests;
	using DeduplicationElastic.WebApi.Contracts.Response;
	using RestSharp;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Http.Abstractions;
	using EntityCollection = BPMSoft.Nui.ServiceModel.DataContract.EntityCollection;

	#region Class: BulkDeduplicationManager

	/// <summary>
	/// Bulk deduplication manager.
	/// </summary>
	[DefaultBinding(typeof(IBulkDeduplicationManager))]
	public class BulkDeduplicationManager : BaseDeduplicationManager, IBulkDeduplicationManager
	{

		#region Fields: Private

		private readonly IStartDeduplicationRequestFactory _startDeduplicationRequestFactory;
		private readonly IBulkDeduplicationTaskClient _bulkDeduplicationTaskClient;
		private readonly IAppSchedulerWraper _appSchedulerWraper;
		private const string IsUniqueAttributeName = "IsUnique";
		private const string IsSourceEntityAttributeName = "IsSourceEntity";
		private const int MaxFetchPages = 100;

		#endregion

		#region Properties: Protected

		protected virtual int CheckDeduplicationTaskStatusInterval => 1;

		#endregion

		#region Contructors: Public

		public BulkDeduplicationManager(UserConnection userConnection,
				IAppSchedulerWraper appSchedulerWraper) : base(userConnection) {
			if (string.IsNullOrEmpty(DeduplicationWebApiUrl)) {
				Log.Error("DeduplicationWebApiUrl is empty.");
			}
			var userConnectionConstructorArgument = new ConstructorArgument("userConnection", userConnection);
			_startDeduplicationRequestFactory = ClassFactory.Get<IStartDeduplicationRequestFactory>(
				userConnectionConstructorArgument);
			_bulkDeduplicationTaskClient = ClassFactory.Get<IBulkDeduplicationTaskClient>(
				userConnectionConstructorArgument);
			_appSchedulerWraper = appSchedulerWraper;
		}

		#endregion

		#region Methods: Private
		
		private EntitySchemaQuery GetDuplicateEntitiesEsq(string entityName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entityName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.UseAdminRights = true;
			return esq;
		}

		private Dictionary<string, string> GetServerToClientColumnNameMap(string[] columns, EntitySchemaQuery esq) {
			var serverToClientColumnNameMap = new Dictionary<string, string>();
			var primaryColumnName = esq.PrimaryQueryColumn.Name;
			foreach (var column in columns) {
				serverToClientColumnNameMap[esq.AddColumn(column).Name] = column;
			}
			if (!serverToClientColumnNameMap.Any(x => x.Key == primaryColumnName || x.Value == primaryColumnName)) {
				serverToClientColumnNameMap[esq.PrimaryQueryColumn.Name] = esq.PrimaryQueryColumn.Name;
			}
			serverToClientColumnNameMap.Add(IsUniqueAttributeName, IsUniqueAttributeName);
			return serverToClientColumnNameMap;
		}

		private Guid GetRowRecordId(Dictionary<string, object> row, EntitySchemaQuery esq) {
			var primaryColumnName = esq.PrimaryQueryColumn.Name;
			var primaryColumnStringValue = row[primaryColumnName].ToString();
			return Guid.Parse(primaryColumnStringValue);
		}

		private EntityCollection GetDuplicateEntities(EntitySchemaQuery esq, 
			Dictionary<string, string> serverToClientColumnNameMap, IList<DuplicateInfo> entities) {
			if (entities.Count == 0) {
				return new EntityCollection();
			}
			var duplicateRecordIds = entities.Select(entity => entity.RecordId);
			var duplicatesCollection = GetDuplicatesEntityCollection(esq, serverToClientColumnNameMap, duplicateRecordIds);
			foreach (var item in duplicatesCollection) {
				var firstDuplicateInfo = entities.First(x => x.RecordId == GetRowRecordId(item, esq));
				var isSourceEntity = firstDuplicateInfo.SourceRecordId == firstDuplicateInfo.RecordId;
				if (isSourceEntity) {
					item.Add(IsSourceEntityAttributeName, true);
				}
				item.Add(IsUniqueAttributeName, firstDuplicateInfo.IsUnique);
			}
			return duplicatesCollection;
		}

		private EntityCollection GetDuplicatesEntityCollection(EntitySchemaQuery esq,
			Dictionary<string, string> serverToClientColumnNameMap, IEnumerable<Guid> entityIds) {
			esq.ResetSelectQuery();
			esq.Filters.Clear();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, esq.PrimaryQueryColumn.Path,
				entityIds.Select(id => id.ToString()).Distinct()));
			return QueryExtension.GetEntityCollection(esq.GetEntityCollection(UserConnection), serverToClientColumnNameMap);
		}

		private BulkEntityClientDuplicatesGroup GetDuplicateGroup(EntitySchemaQuery esq, 
			Dictionary<string, string> serverToClientColumnNameMap, List<DuplicateInfo> entities, Guid groupId) {
			esq.ResetSelectQuery();
			esq.Filters.Clear();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, esq.PrimaryQueryColumn.Path,
				entities.Select(entity => entity.RecordId.ToString()).Distinct()));
			var duplicatesCollection = QueryExtension.GetEntityCollection(esq.GetEntityCollection(UserConnection), serverToClientColumnNameMap);
			foreach (var item in duplicatesCollection) {
				item.Add(IsUniqueAttributeName, entities.First(x => x.RecordId == GetRowRecordId(item, esq)).IsUnique);
			}
			return new BulkEntityClientDuplicatesGroup {
				GroupId = groupId,
				Rows = duplicatesCollection
			};
		}

		private void AddIsUniqueColumn(EntitySchemaQuery esq) {
			esq.Columns.Add(new EntitySchemaQueryColumn {
				ValueExpression = new EntitySchemaQueryExpression(EntitySchemaQueryExpressionType.Parameter) {
					ParameterValue = default(bool)
				},
				Name = IsUniqueAttributeName,
				UId = Guid.NewGuid()
			});
		}

		private void ScheduleDeduplicationTaskStatusCheckingJob(string sectionName) {
			var checkDeduplicationTaskParameters = new Dictionary<string, object> {
				{CheckDeduplicationTaskStatusJobExecutor.EntityNameParamName, sectionName},
				{CheckDeduplicationTaskStatusJobExecutor.IndexNameParamName, IndexName}
			};
			var checkDeduplicationStatusJobGroupName =
				CheckDeduplicationTaskStatusJobExecutor.GetCheckDeduplicationStatusJobGroupName(sectionName);
			_appSchedulerWraper.RemoveGroupJobs(checkDeduplicationStatusJobGroupName);
			_appSchedulerWraper.ScheduleMinutelyJob<CheckDeduplicationTaskStatusJobExecutor>(
				checkDeduplicationStatusJobGroupName,
				UserConnection.Workspace.Name, UserConnection.CurrentUser.Name,
				CheckDeduplicationTaskStatusInterval, checkDeduplicationTaskParameters, false);
		}

		private IList<IGrouping<Guid, DuplicateInfo>> FetchDuplicatesFromService(string entityName, int offset, int count) {
			var duplicatesResponse = ExecuteFetchRequest<DuplicateResponse>(DuplicationControllerPath, new Dictionary<string, object> {
				{ "sourceEntityName", entityName },
				{ "elasticIndexName", IndexName },
				{ "offset", offset },
				{ "count", count },
			});
			return duplicatesResponse.Duplicates?.GroupBy(x => x.GroupId).ToList();
		}

		private List<DuplicateGroupInfo> FetchGroupOfDuplicatesFromService(string entityName, int offset, int count, int topDuplicatesPerGroup) {
			return ExecuteFetchRequest<List<DuplicateGroupInfo>>(DuplicationGroupControllerPath, new Dictionary<string, object> {
				{ "sourceEntityName", entityName },
				{ "elasticIndexName", IndexName },
				{ "offset", offset },
				{ "count", count },
				{ "topDuplicatesCountPerGroup", topDuplicatesPerGroup },
			});
		}
		
		private DuplicateCountInfo FetchDuplicatesCountFromService(string entityName) {
			return ExecuteFetchRequest<DuplicateCountInfo>(DuplicatesCountControllerPath, new Dictionary<string, object> {
				{ "sourceEntityName", entityName },
				{ "elasticIndexName", IndexName },
			});
		}

		private List<DuplicateInfo> FetchDuplicatesByGroupFromService(string entityName, Guid groupId, int offset, int count) {
			return ExecuteFetchRequest<List<DuplicateInfo>>($"{DuplicationControllerPath}/{groupId}", new Dictionary<string, object> {
				{ "offset", offset },
				{ "count", count }
			});
		}

		private T ExecuteFetchRequest<T>(string resourcePath, IDictionary<string, object> requestQueryParams)
			 where T : new() {
			var request = new RestRequest(resourcePath, Method.GET);
			request.RequestFormat = DataFormat.Json;
			foreach (var queryParam in requestQueryParams) {
				request.AddParameter(queryParam.Key, queryParam.Value, ParameterType.QueryString);
			}
			var response = RestClient.Execute<T>(request);
			if (response.StatusCode != HttpStatusCode.OK) {
				Log.Error($"Fetch for {nameof(T)} failed. Path: {resourcePath}. StatusCode: {response.StatusCode}. " +
					$"QueryParams: {string.Join(", ", requestQueryParams.Keys)}({string.Join(", ", requestQueryParams.Values)})");
				return new T();
			}
			var duplicatesResponse = response.Data;
			if (duplicatesResponse == null) {
				Log.Error($"Content for {nameof(T)} is invalid. Path: {resourcePath}. {response.Content}." +
					$"QueryParams: {string.Join(", ", requestQueryParams.Keys)}({string.Join(", ", requestQueryParams.Values)})");
				return new T();
			}
			return response.Data;
		}

		private BulkEntityClientDuplicatesGroup GetDuplicatesGroupResponse(DuplicateGroupInfo duplicateGroup, EntitySchemaQuery esq,
			Dictionary<string, string> serverToClientColumnNameMap) {
			var minDuplicatesCountPerGroup = 2;
			var isEmptyDuplicatesInGroup = duplicateGroup.Duplicates.Count == 0;
			if (isEmptyDuplicatesInGroup) {
				Log.Info($"Empty duplicate group {duplicateGroup.Id} from service. Source entity: {duplicateGroup.SourceRecordId}.");
				return null;
			}
			var sourceEntity = GetDuplicatesEntityCollection(esq, serverToClientColumnNameMap, new List<Guid> {
						duplicateGroup.SourceRecordId
					}).FirstOrDefault();
			if (sourceEntity == null) {
				Log.Info($"Source entity by group {duplicateGroup.Id} not found. Source entity: {duplicateGroup.SourceRecordId}.");
				return null;
			}
			var duplicateEntities = GetDuplicateEntities(esq, serverToClientColumnNameMap, duplicateGroup.Duplicates);
			var isNotFilledDuplicatesGroup = duplicateEntities.Count < minDuplicatesCountPerGroup;
			if (isNotFilledDuplicatesGroup) {
				Log.Info($"Creation duplicates collection by group {duplicateGroup.Id} not filled. Source entity: {duplicateGroup.SourceRecordId}.");
				return null;
			}
			return new BulkEntityClientDuplicatesGroup {
				DuplicatesCount = duplicateGroup.DuplicatesCount,
				GroupId = duplicateGroup.Id,
				SourceEntityId = duplicateGroup.SourceRecordId,
				Rows = duplicateEntities,
				SourceEntity = sourceEntity
			};
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IBulkDeduplicationManager.GetDeduplicationInfo"/>
		public BulkDeduplicationInfo GetDeduplicationInfo(string entityName) {
			try {
				var actualDeduplicationTask =
					_bulkDeduplicationTaskClient.GetActualDeduplicationTask(entityName, IndexName);
				if (actualDeduplicationTask == null || actualDeduplicationTask.TaskStatus == null) {
					return new BulkDeduplicationInfo {
						IsFirstRun = true,
						IsRunning = false
					};
				}
				var deduplicationTaskStatus = actualDeduplicationTask.TaskStatus;
				var maxDuplicatesPerRecord = actualDeduplicationTask.MaxDuplicatesPerRecord != null
						&& actualDeduplicationTask.MaxDuplicatesPerRecord.HasValue
						? actualDeduplicationTask.MaxDuplicatesPerRecord.Value
						: -1;
				var processedPercentValue = actualDeduplicationTask.TotalRecordsCount > 0 
					? (double)actualDeduplicationTask.ProcessedRecordsCount / actualDeduplicationTask.TotalRecordsCount * 100
					: 0;
				var isNowRunning = deduplicationTaskStatus == DeduplicationTaskStatus.Pending ||
						deduplicationTaskStatus == DeduplicationTaskStatus.Running;
				var isSuccessRunning = deduplicationTaskStatus != DeduplicationTaskStatus.Canceled
						&& deduplicationTaskStatus != DeduplicationTaskStatus.Failed;
				return new BulkDeduplicationInfo {
					IsFirstRun = false,
					IsRunning = isNowRunning,
					IsSuccess = isSuccessRunning,
					MaxDuplicatesPerRecord = maxDuplicatesPerRecord,
					ProcessedPercent = Convert.ToInt32(processedPercentValue)
				};
			}
			catch (HttpException) {
				return null;
			}
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.GetGroupsOfDuplicates"/>
		public BulkDuplicatesGroupResponse GetGroupsOfDuplicates(string entityName, string[] columns, 
				int offset, int count, int topDuplicatesPerGroup) {
			var response = new BulkDuplicatesGroupResponse { Groups = new Collection<BulkEntityClientDuplicatesGroup>() };
			var esq = GetDuplicateEntitiesEsq(entityName);
			var serverToClientColumnNameMap = GetServerToClientColumnNameMap(columns, esq);
			var serviceGroupOffset = offset;
			var serviceGroupCount = count;
			for (int i = 0; i < MaxFetchPages; i++) {
				var duplicateGroupsInfo = FetchGroupOfDuplicatesFromService(entityName, serviceGroupOffset, serviceGroupCount, topDuplicatesPerGroup);
				foreach (var duplicateGroup in duplicateGroupsInfo) {
					var duplicateGroupResponse = GetDuplicatesGroupResponse(duplicateGroup, esq, serverToClientColumnNameMap);
					if (duplicateGroupResponse == null) {
						continue;
					}
					response.Groups.Add(duplicateGroupResponse);
				}
				var allRowsFetchedFromService = duplicateGroupsInfo.Count < serviceGroupCount;
				if (allRowsFetchedFromService) {
					serviceGroupOffset = -1;
					break;
				}
				serviceGroupOffset += serviceGroupCount;
				serviceGroupCount = count - response.Groups.Count;
				var requestedRowsCountFetched = response.Groups.Count >= count;
				if (requestedRowsCountFetched) {
					break;
				}
			}
			AddIsUniqueColumn(esq);
			response.RowConfig = QueryExtension.GetColumnConfig(esq, serverToClientColumnNameMap);
			response.NextOffset = serviceGroupOffset;
			return response;
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.GetDuplicateEntitiesByGroup"/>
		public BulkEntityClientDuplicatesGroup GetDuplicateEntitiesByGroup(string entityName, string[] columns, Guid groupId, int offset, int count) {
			var response = new BulkEntityClientDuplicatesGroup();
			var esq = GetDuplicateEntitiesEsq(entityName);
			var serverToClientColumnNameMap = GetServerToClientColumnNameMap(columns, esq);
			var duplicates = FetchDuplicatesByGroupFromService(entityName, groupId, offset, count);
			var duplicateEntities = GetDuplicateEntities(esq, serverToClientColumnNameMap, duplicates);
			response.GroupId = groupId;
			response.Rows = duplicateEntities;
			return response;
		}
		
		/// <inheritdoc cref="IBulkDeduplicationManager.GetDuplicateCountData"/>
		public BulkDuplicatesCountResponse GetDuplicateCountData(string entityName) {
			var duplicates = FetchDuplicatesCountFromService(entityName);
			var response = new BulkDuplicatesCountResponse() {
				DuplicatesCount = duplicates.DuplicatesCount,
				GroupsCount = duplicates.GroupsCount
			};
			return response;
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.GetDuplicateEntitiesGroups"/>
		public BulkDuplicatesGroupResponse GetDuplicateEntitiesGroups(string entityName, string[] columns,
				int clientOffset, int clientCount) {
			var response = new BulkDuplicatesGroupResponse {Groups = new Collection<BulkEntityClientDuplicatesGroup>()};
			int totalCountFromBpm = 0;
			var offset = clientOffset;
			var esq = GetDuplicateEntitiesEsq(entityName);
			var serverToClientColumnNameMap = GetServerToClientColumnNameMap(columns, esq);
			for (int i = 0; i < MaxFetchPages; i++) {
				var duplicateRecordGroups = FetchDuplicatesFromService(entityName, offset, clientCount);
				if (duplicateRecordGroups == null) {
					break;
				}
				foreach (var duplicateRecords in duplicateRecordGroups) {
					var duplicatesGroupId = duplicateRecords.Key;
					var duplicatesOfGroup = duplicateRecords.ToList();
					var existingDuplicates = GetDuplicateEntities(esq, serverToClientColumnNameMap, duplicatesOfGroup);
					var responseGroup = response.Groups.Find(x => x.GroupId == duplicatesGroupId);
					if (responseGroup == null) {
						responseGroup = new BulkEntityClientDuplicatesGroup {
							GroupId = duplicatesGroupId, 
							Rows = new EntityCollection()
						};
						response.Groups.Add(responseGroup);
					}
					responseGroup.Rows.AddRange(existingDuplicates);
				}
				var receivedDuplicatesCount = duplicateRecordGroups.Sum(x => x.Count());
				var existingDuplicatesCount = response.Groups.Sum(x => x.Rows.Count());
				response.NextOffset = offset += receivedDuplicatesCount;
				if (receivedDuplicatesCount < clientCount || existingDuplicatesCount >= clientCount) {
					break;
				}
			}
			if (response.Groups.IsEmpty()) {
				return null;
			}
			AddIsUniqueColumn(esq);
			response.RowConfig = QueryExtension.GetColumnConfig(esq, serverToClientColumnNameMap);
			response.TotalCountRecords = response.Groups.Sum(x => x.Rows.Count);
			return response;
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.StartDeduplicationTask"/>
		public bool StartDeduplicationTask(string sectionName) {
			try {
				var startDeduplicationRequest = _startDeduplicationRequestFactory
					.CreateStartDeduplicationRequest(sectionName, IndexName);
				var request = new RestRequest($"{DeduplicationTaskControllerPath}start", Method.POST);
				request.RequestFormat = DataFormat.Json;
#if NETFRAMEWORK
				request.AddBody(startDeduplicationRequest);
#else
				request.AddJsonBody(startDeduplicationRequest);
#endif
				var response = RestClient.Execute<DeduplicationTaskResponse>(request);
				if (response.Data?.TaskStatus != null) {
					var taskStatus = response.Data.TaskStatus;
					if (taskStatus != DeduplicationTaskStatus.Pending) {
						return false;
					}
					ScheduleDeduplicationTaskStatusCheckingJob(sectionName);
					return true;
				}
				Log.Error($"StartDeduplicationTask for '{sectionName}' is invalid. {response.Content}");
				return false;
			} catch (Exception exception) {
				Log.Error($"StartDeduplicationTask for '{sectionName}' is invalid", exception);
				return false;
			}
		}

		/// <inheritdoc cref="IBulkDeduplicationManager.AddToUniqueList"/>
		public bool AddToUniqueList(string entityName, Guid[] uniqueRecordIds) {
			var addToUniqueListRequest = new AddUniqueRecordsRequest {
				IndexName = IndexName,
				SourceEntityName = entityName,
				UniqueRecordIds = new Collection<Guid>(uniqueRecordIds.ToList())
			};
			var request = new RestRequest(UniqueControllerPath, Method.POST) {
				RequestFormat = DataFormat.Json
			};
#if NETFRAMEWORK
			request.AddBody(addToUniqueListRequest);
#else
			request.AddJsonBody(addToUniqueListRequest);
#endif
			var response = RestClient.Execute(request);
			if (response.StatusCode != HttpStatusCode.OK) {
				Log.ErrorFormat("Cannot add unique records for section {0} and index {1}. The message is {2}",
					entityName, IndexName, response.Content);
			}
			return response.StatusCode == HttpStatusCode.OK;
		}

		#endregion
	}

	#endregion

}
