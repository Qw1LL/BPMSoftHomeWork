namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region Class: QueuesFolderUtilities

	/// <summary>
	/// Utility class for work with queues folder.
	/// </summary>
	public class QueuesFolderUtilities {

		#region Constants: Private

		/// <summary>
		/// Group type identifier "Dynamic".
		/// </summary>
		private readonly Guid SearchFolderTypeId = new Guid("{65CA0946-0084-4874-B117-C13199AF3B95}");

		/// <summary>
		/// Group type identifier "Static".
		/// </summary>
		private readonly Guid GeneralFolderTypeId = new Guid("{9DC5F6E6-2A61-4DE8-A059-DE30F4E74F24}");

		/// <summary>
		/// Group type identifier "Static".
		/// </summary>
		private readonly Guid NewQueueItemStatusId = new Guid("{2B341A1D-6FA1-4960-9C85-FEF60D1BBCC4}");

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// ctor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public QueuesFolderUtilities(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Adds queue items from the object group.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="folderEntity">Object group.</param>
		/// <param name="entitySchemaName">The schema name of the queue object.</param>
		/// <param name="queueId">Queue identifier.</param>
		/// <returns>Number of entries added.</returns>
		private int AddFolderEntityQueueItems(Entity folderEntity, string entitySchemaName, Guid queueId) {
			try {
				EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
				var esq = new EntitySchemaQuery(entitySchemaManager, entitySchemaName);
				esq.PrimaryQueryColumn.IsVisible = true;
				Guid folderTypeId = folderEntity.GetTypedColumnValue<Guid>("FolderTypeId");
				Guid folderId = folderEntity.PrimaryColumnValue;
				if (folderTypeId == SearchFolderTypeId) {
					byte[] searchData = folderEntity.GetBytesValue("SearchData");
					string serializedFilter = Encoding.UTF8.GetString(searchData, 0, searchData.Length);
					if (serializedFilter.IsNullOrEmpty()) {
						return 0;
					}
					Filters filters = Json.Deserialize<Filters>(serializedFilter);
					IEntitySchemaQueryFilterItem esqFilters = filters.BuildEsqFilter(entitySchemaName, UserConnection);
					var queryFilterCollection = esqFilters as EntitySchemaQueryFilterCollection;
					if (queryFilterCollection.Count == 0) {
						return 0;
					}
					if (queryFilterCollection.IsNullOrEmpty()) {
						esq.Filters.Add(esqFilters);
					} else {
						esq.Filters.LogicalOperation = queryFilterCollection.LogicalOperation;
						esq.Filters.IsNot = queryFilterCollection.IsNot;
						foreach (IEntitySchemaQueryFilterItem filter in queryFilterCollection) {
							esq.Filters.Add(filter);
						}
					}
				} else if (folderTypeId == GeneralFolderTypeId) {
					esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
						string.Format("[{0}InFolder:{0}:Id].Folder", entitySchemaName), folderId));
				}
				Select select = esq.GetSelectQuery(UserConnection);
				select = select
					.Column(new QueryParameter("QueueId", queueId))
					.Column(new QueryParameter("StatusId", NewQueueItemStatusId))
					.And().Not().Exists(new Select(UserConnection)
						.Column("Id")
					.From("QueueItem")
						.Where(entitySchemaName, "Id").IsEqual("QueueItem", "EntityRecordId")
						.And("QueueItem", "QueueId").IsEqual(Column.Parameter(queueId))) as Select;
				var insertSelect = new InsertSelect(UserConnection)
					.Into("QueueItem")
					.Set("EntityRecordId", "QueueId", "StatusId")
					.FromSelect(select);
				return insertSelect.Execute();
			} catch (Exception e) {
				QueuesUtilities.LogError(string.Format(
					new LocalizableString(UserConnection.ResourceStorage, "QueuesFolderUtilities",
						"LocalizableStrings.InvokeMethodErrorMessage.Value").ToString(),
					"AddFolderEntityQueueItems", e.Message), e);
				throw;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds queue items from selected groups.
		/// </summary>
		/// <param name="folderIds">List of identifiers of the selected groups.</param>
		/// <param name="entitySchemaName">The schema name of the queue object.</param>
		/// <param name="queueId">Queue identifier.</param>
		/// <returns>A serialized object with information about the number of entries added and error messages.</returns>
		public virtual string AddQueueItems(List<object> folderIds, string entitySchemaName, Guid queueId) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, entitySchemaName + "Folder");
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.AddColumn("SearchData");
			esq.AddColumn("FolderType");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", folderIds));
			BPMSoft.Core.Entities.EntityCollection entities = esq.GetEntityCollection(UserConnection);
			var addedQuantity = 0;
			StringBuilder errorMessages = new StringBuilder();
			foreach (Entity entity in entities) {
				try {
					addedQuantity = addedQuantity + AddFolderEntityQueueItems(entity,
						entitySchemaName, queueId);
				} catch (Exception e) {
					errorMessages.AppendLine(e.Message);
				}
			}
			var result = new {
				addedEntitiesCount = addedQuantity,
				errorMessages = errorMessages.ToString()
			};
			return ServiceStackTextHelper.Serialize(result);
		}

		/// <summary>
		/// Validation of parameters required to fill a queue from a folder.
		/// </summary>
		/// <param name="folderIds">List of identifiers of the selected groups.</param>
		/// <param name="entitySchemaName">The schema name of the queue object.</param>
		/// <param name="queueId">Queue identifier.</param>
		/// <returns>Validation error message.</returns>
		public string ValidateAddFolderQueueItemsParams(List<object> folderIds, string entitySchemaName, Guid queueId) {
			var result = "";
			var emptyParameters = new List<string>();
			if (folderIds.IsNullOrEmpty()) {
				emptyParameters.Add("folderIds");
			}
			if (entitySchemaName.IsNullOrEmpty()) {
				emptyParameters.Add("entitySchemaName");
			}
			if (queueId.IsEmpty()) {
				emptyParameters.Add("queueId");
			}
			if (!emptyParameters.IsNullOrEmpty()) {
				string message = string.Format(new LocalizableString("BPMSoft.Common",
				"Exception.ArgumentNullOrEmpty"),
					StringUtilities.Concat(emptyParameters));
				var emptyParametersResult = new {
					addedEntitiesCount = 0,
					errorMessages = message
				};
				result = ServiceStackTextHelper.Serialize(emptyParametersResult);
			}
			return result;
		}

		#endregion

	}

	#endregion

}

