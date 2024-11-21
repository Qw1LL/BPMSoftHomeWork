namespace BPMSoft.Configuration
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using EntitySchema = Core.Entities.EntitySchema;

	#region Class: EventAudienceRepository

	/// <summary>
	/// Implements CRUD operations for the event audience.
	/// </summary>
	public class EventAudienceRepository
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EventAudienceRepository"/> class.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public EventAudienceRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventAudienceRepository"/> class with batch size setup.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="queryBatchSize">Defines size of a batch for each query.</param>
		public EventAudienceRepository(UserConnection userConnection, int queryBatchSize) : this(userConnection) {
			QueryBatchSize = queryBatchSize;
		}

		#endregion

		#region Properties: Private

		private int QueryBatchSize { get; } = 500;

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="UserConnection"/> class.
		/// </summary>
		public UserConnection UserConnection { get; set; }

		/// <summary>
		/// Instance of EventLogger. 
		/// </summary>
		public ILog Logger => LogManager.GetLogger("EventLogger");

		/// <summary>
		/// Unique identifier of the event.
		/// </summary>
		private Guid _eventId;
		public Guid EventId {
			get => _eventId;
			set {
				if (_eventId != value) {
					_eventId = value;
				}
			}
		}

		#endregion

		#region Methods: Private

		private Delete GetDeleteRecipientsQuery() {
			return new Delete(UserConnection)
				.From("EventTarget")
				.Where("EventId").IsEqual(Column.Parameter(EventId)) as Delete;
		}

		private void SafeDelete(Select subSelect, ref int result) {
			subSelect.Top(QueryBatchSize);
			var delete = GetDeleteRecipientsQuery();
			if (subSelect.SourceExpression.SchemaName == "EventTarget") {
				delete.And("Id").In(subSelect);
			} else {
				delete.And("ContactId").In(subSelect);
			}
			int queryResult;
			do {
				queryResult = delete.Execute();
				result += queryResult;
				Thread.Sleep(10);
			} while (queryResult > 0);
		}

		private EntitySchemaQuery GetContactESQ(EntitySchemaQuery sourceEsq = null) {
			var esq = sourceEsq ?? new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			esq.Columns.Clear();
			esq.AddColumn("Id");
			return esq;
		}

		private Select GetExistingParticipantsQuery() =>
			new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From("EventTarget")
				.Where("EventTarget", "ContactId").IsEqual("Contact", "Id")
				.And("EventTarget", "EventId").IsEqual(Column.Parameter(EventId)) as Select;

		private Select AddParticipantFilters(Select contactSelect) {
			var existingRecipientQuery = GetExistingParticipantsQuery();
			var resultSelect = new Select(contactSelect)
				.And().Not().Exists(existingRecipientQuery) as Select;
			resultSelect.SpecifyNoLockHints();
			return resultSelect;
		}

		private Select GetFilteredContactsQuery(IEnumerable<Guid> contactList) {
			var esq = GetContactESQ();
			var select = esq.GetSelectQuery(UserConnection);
			if (select.HasCondition) {
				select.And("Id").In(Column.Parameters(contactList));
			} else {
				select.Where("Id").In(Column.Parameters(contactList));
			}
			return AddParticipantFilters(select);
		}

		private Select GetFilteredFolderQuery(Select filterSelect) {
			var esq = GetContactESQ();
			var select = esq.GetSelectQuery(UserConnection);
			if (select.HasCondition) {
				select.And().Exists(filterSelect);
			} else {
				select.Where().Exists(filterSelect);
			}
			return AddParticipantFilters(select);
		}

		private Entity GetFolderEntity(Guid folderId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactFolder");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("FolderType");
			esq.AddColumn("SearchData");
			return esq.GetEntity(UserConnection, folderId);
		}

		private Select GetStaticFolderSelect(Entity folder) {
			var folderId = folder.GetTypedColumnValue<Guid>("Id");
			var folderSelect = new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From("ContactInFolder")
				.Where("FolderId").IsEqual(Column.Parameter(folderId))
				.And("Contact", "Id").IsEqual("ContactInFolder", "ContactId") as Select;
			return GetFilteredFolderQuery(folderSelect);
		}

		private Filters DeserializeFilters(byte[] filterData) {
			string serializedFilters = Encoding.UTF8.GetString(filterData, 0, filterData.Length);
			return Json.Deserialize<Filters>(serializedFilters);
		}

		private EntitySchemaQuery BuildFolderEsq(SelectQuery selectQuery) {
			var folderEsq = selectQuery.BuildEsq(UserConnection);
			var folderFilter = selectQuery.Filters.BuildEsqFilter(folderEsq, UserConnection);
			var filterCollection = new EntitySchemaQueryFilterCollection(folderEsq);
			filterCollection.Add(folderFilter);
			folderEsq.Filters.Clear();
			folderEsq.Filters.LogicalOperation = LogicalOperationStrict.And;
			folderEsq.Filters.Add(filterCollection);
			return folderEsq;
		}

		private Select GetDynamicFolderSelect(Entity folder) {
			var searchData = folder.GetBytesValue("SearchData");
			if (searchData?.IsEmpty() != false) {
				return null;
			}
			var selectQuery = new SelectQuery {
				RootSchemaName = "Contact",
				Filters = DeserializeFilters(searchData)
			};
			var folderEsq = BuildFolderEsq(selectQuery);
			return GetRecipientsSelectFromEsq(folderEsq);
		}

		private Select GetParticipatingContactsQuery() {
			var esq = GetContactESQ();
			var select = esq.GetSelectQuery(UserConnection);
			var existingRecipientQuery = GetExistingParticipantsQuery();
			var resultSelect = new Select(select);
			if (resultSelect.HasCondition) {
				resultSelect.And().Exists(existingRecipientQuery);
			} else {
				resultSelect.Where().Exists(existingRecipientQuery);
			}
			resultSelect.SpecifyNoLockHints();
			return resultSelect;
		}

		private void IncreaseRecipientCount(int addedCount) {
			var update = new Update(UserConnection, "Event")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Set("RecipientCount",
					QueryColumnExpression.Add(new QueryColumnExpression("RecipientCount"),
						Column.Parameter(addedCount)))
				.Where("Id").IsEqual(Column.Parameter(EventId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void DecreaseRecipientCount(int count) {
			var update = new Update(UserConnection, "Event")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId)) as Update;
			if (count == int.MaxValue) {
				update.Set("RecipientCount", Column.Parameter(0));
				update.Set("IsAudienceInited", Column.Parameter(false));
			} else {
				update.Set("RecipientCount",
						QueryColumnExpression.Subtract(new QueryColumnExpression("RecipientCount"),
							Column.Parameter(count)));
			}
			update.Where("Id").IsEqual(Column.Parameter(EventId));
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private SelectQuery DeserializeEsq(string esqSerialized) {
			var selectQuery = Json.Deserialize<SelectQuery>(esqSerialized);
			selectQuery.CheckArgumentNull($"{nameof(EventAudienceRepository)}.DeserializeEsq selectQuery");
			selectQuery.Columns?.Items?.Clear();
			return selectQuery;
		}

		private bool IsEsqFiltersEmpty(EntitySchemaQueryFilterCollection filters) {
			foreach (var filter in filters) {
				if (!filter.IsEnabled) {
					continue;
				}
				if ((filter.GetType() == typeof(EntitySchemaQueryFilterCollection)
						&& !IsEsqFiltersEmpty((EntitySchemaQueryFilterCollection)filter))
						|| filter.GetType() == typeof(EntitySchemaQueryFilter)) {
					return false;
				}
			}
			return true;
		}

		private Select GetRecipientsSelectFromEsq(EntitySchemaQuery sourceEsq) {
			CommonUtilities.DisableEmptyEntitySchemaQueryFilters(sourceEsq.Filters);
			if (IsEsqFiltersEmpty(sourceEsq.Filters)) {
				return null;
			}
			var audienceEsq = GetContactESQ(sourceEsq);
			var contactSelect = audienceEsq.GetSelectQuery(UserConnection);
			return AddParticipantFilters(contactSelect);
		}

		#endregion

		#region Methods: Protected

		protected List<Select> GetContactSelectList(IEnumerable<Guid> contactList) {
			var selects = new List<Select>();
			var totalCount = contactList.Count();
			var count = 0;
			while (count < totalCount) {
				var batch = contactList.Skip(count).Take(QueryBatchSize);
				var batchSelect = GetFilteredContactsQuery(batch);
				selects.Add(batchSelect);
				count += QueryBatchSize;
			}
			return selects;
		}

		protected Select GetFolderSelect(Entity folder) {
			var folderType = folder.GetTypedColumnValue<Guid>("FolderTypeId");
			if (folderType == MarketingConsts.FolderTypeDynamicId) {
				return GetDynamicFolderSelect(folder);
			}
			if (folderType == MarketingConsts.FolderTypeStaticId) {
				return GetStaticFolderSelect(folder);
			}
			return null;
		}

		private bool CreateEventTarget(Guid contactId) {
			var eventTargetSchema = UserConnection.EntitySchemaManager.GetInstanceByName(nameof(EventTarget));
			var eventTarget = eventTargetSchema.CreateEntity(UserConnection);
			eventTarget.SetDefColumnValues();
			eventTarget.SetColumnValue("EventId", EventId);
			eventTarget.SetColumnValue("ContactId", contactId);
			return eventTarget.Save();
		}

		protected int InsertAudienceFromSelect(Select filteredSelect, out int totalCount) {
			var contactIds = filteredSelect.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToList();
			totalCount = contactIds.Count();
			var insertCount = 0;
			foreach (var contactId in contactIds) {
				var isEntityCreated = CreateEventTarget(contactId);
				if (isEntityCreated) {
					insertCount++;
				}
				Thread.Sleep(10);
			}
			return insertCount;
		}

		protected int InsertAudienceFromSelects(IEnumerable<Select> selects, out int totalCount) {
			var result = 0;
			totalCount = 0;
			foreach (var select in selects) {
				if (select == null) {
					continue;
				}
				var count = 0;
				result += InsertAudienceFromSelect(select, out count);
				totalCount += count;
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds list of contacts to event audience.
		/// </summary>
		/// <param name="contactIds">List of contacts identifiers to add.</param>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Number of contacts added.</returns>
		public virtual int ImportById(IEnumerable<Guid> contactIds, Guid eventId) {
			try {
				EventId = eventId;
				var selects = GetContactSelectList(contactIds);
				var result = InsertAudienceFromSelects(selects, out int totalCount);
				Logger.DebugFormat("ImportById success. Imported: {0} of {1}, EventId:{2}, CurrentUser:{3}",
					result, totalCount, EventId, UserConnection.CurrentUser.ContactId);
				return result;
			} catch (Exception ex) {
				Logger.Error(ex);
				throw;
			}
		}

		/// <summary>
		/// Adds event audience from contact folder.
		/// </summary>
		/// <param name="folderId">Unique identifier of the contact folder.</param>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Number of contacts added.</returns>
		public virtual int ImportByFolder(Guid folderId, Guid eventId) {
			try {
				EventId = eventId;
				var folder = GetFolderEntity(folderId);
				if (folder == null) {
					Logger.ErrorFormat("Can't import participants by not existed folder. FolderId: {0}, EventId: {1}",
						folderId, eventId);
				}
				var folderSelect = GetFolderSelect(folder);
				var result = InsertAudienceFromSelect(folderSelect, out int totalCount);
				if (totalCount > 0) {
					Logger.DebugFormat("ImportByFolder. Imported: {0} of {1}, EventId:{2}, CurrentUser:{3}",
						result, totalCount, EventId, UserConnection.CurrentUser.ContactId);
				} else {
					Logger.DebugFormat("ImportByFolder error. Folder is empty: FolderId:{0}, CurrentUser:{1}",
						folderId, UserConnection.CurrentUser.ContactId);
				}
				return result;
			} catch (Exception ex) {
				Logger.ErrorFormat("Can't import event participants by ContactFolder. FolderId: {0}, EventId: {1}", ex,
					folderId, eventId);
				throw;
			}
		}

		/// <summary>
		/// Adds event audience by filter.
		/// </summary>
		/// <param name="esqSerialized">Serialized ESQ (SelectQuery).</param>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Number of imported records.</returns>
		/// <exception cref="ArgumentNullOrEmptyException"/>
		public virtual int ImportByFilter(string esqSerialized, Guid eventId) {
			try {
				EventId = eventId;
				var selectQuery = DeserializeEsq(esqSerialized);
				var sourceEsq = selectQuery.BuildEsq(UserConnection);
				sourceEsq.CheckArgumentNull($"{nameof(EventAudienceRepository)}.DeserializeEsq esq");
				var audienceSelect = GetRecipientsSelectFromEsq(sourceEsq);
				var result = InsertAudienceFromSelects(new[] { audienceSelect }, out int totalCount);
				if (totalCount > 0) {
					Logger.DebugFormat("ImportByFilter. Imported: {0} of {1}, EventId:{2}, CurrentUser:{3}",
						result, totalCount, EventId, UserConnection.CurrentUser.ContactId);
				} else {
					Logger.DebugFormat("ImportByFilter error. Filter result is empty: Filter:{0}, CurrentUser:{1}",
						esqSerialized, UserConnection.CurrentUser.ContactId);
				}
				return result;
			} catch (Exception ex) {
				Logger.ErrorFormat("Can't import event participants by filter. Filter: {0}, EventId: {1}", ex,
					esqSerialized, eventId);
				throw;
			}
		}

		/// <summary>
		/// Deletes list of event participants from event.
		/// </summary>
		/// <param name="eventTargets">List of event participant identifiers to delete.</param>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Number of recipients deleted.</returns>
		public virtual int DeleteById(IEnumerable<Guid> eventTargets, Guid eventId) {
			try {
				EventId = eventId;
				var result = 0;
				var totalCount = eventTargets.Count();
				var deleteCount = 0;
				while (deleteCount < totalCount) {
					var batch = eventTargets.Skip(deleteCount).Take(QueryBatchSize);
					var delete = GetDeleteRecipientsQuery()
						.And("Id").In(Column.Parameters(batch));
					result += delete.Execute();
					deleteCount += QueryBatchSize;
				}
				if (result > 0) {
					Logger.DebugFormat("DeleteById. Deleted: {0} of {1}, EventId:{2}, CurrentUser:{3}",
						result, totalCount, EventId, UserConnection.CurrentUser.ContactId);
					DecreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				Logger.Error(ex);
				throw;
			}
		}

		/// <summary>
		/// Deletes recipients from event by filter.
		/// </summary>
		/// <param name="esqSerialized">Serialized ESQ (SelectQuery)</param>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Number of recipients deleted.</returns>
		public virtual int DeleteByFilter(string esqSerialized, Guid eventId) {
			try {
				EventId = eventId;
				var result = 0;
				var selectQuery = DeserializeEsq(esqSerialized);
				var schema = UserConnection.EntitySchemaManager.GetInstanceByName(selectQuery.RootSchemaName)
					.Clone() as EntitySchema;
				var sourceEsq = selectQuery.BuildEsq(schema, UserConnection, out var columnNameMap);
				sourceEsq.CheckArgumentNull($"{nameof(EventAudienceRepository)}.DeserializeEsq esq");
				CommonUtilities.DisableEmptyEntitySchemaQueryFilters(sourceEsq.Filters);
				if (IsEsqFiltersEmpty(sourceEsq.Filters)) {
					return 0;
				}
				var select = sourceEsq.GetSelectQuery(UserConnection);
				SafeDelete(select, ref result);
				if (result > 0) {
					Logger.DebugFormat("DeleteByFilter. Deleted: {0}, EventId:{1}, CurrentUser:{2}",
						result, EventId, UserConnection.CurrentUser.ContactId);
					DecreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				Logger.ErrorFormat("Can't delete event participants by filter. Filter: {0}, EventId: {1}", ex,
					esqSerialized, eventId);
				throw;
			}
		}

		/// <summary>
		/// Deletes all recipients from event.
		/// </summary>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Number of recipients deleted.</returns>
		public virtual int DeleteAll(Guid eventId) {
			try {
				EventId = eventId;
				var result = 0;
				var participatingContactsSelect = GetParticipatingContactsQuery();
				SafeDelete(participatingContactsSelect, ref result);
				if (result > 0) {
					Logger.DebugFormat("DeleteAll. Deleted: {0}, EventId:{1}, CurrentUser:{2}",
						result, EventId, UserConnection.CurrentUser.ContactId);
					DecreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				Logger.Error(ex);
				throw;
			}
		}

		#endregion
	}

	#endregion

}

