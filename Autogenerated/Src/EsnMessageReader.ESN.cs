namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using Common;
	using Core;
	using Core.Entities;
	using Core.Factories;
	using BPMSoft.Core.DB;
	using CoreEntities = BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.Extensions;

  	#region  Class: EsnMessageReader

	/// <inheritdoc />
	[DefaultBinding(typeof(IEsnMessageReader))]
	public class EsnMessageReader : IEsnMessageReader
	{
		#region Constants: Protected

		protected const string EsnMessageEntitySchemaName = "SocialMessage";
		protected readonly UserConnection UserConnection;

		#endregion

		#region Properties: Private

		private EntitySchema ContactSchema => UserConnection?.EntitySchemaManager?.GetInstanceByName("Contact");

		private string _contactSchemaTypedColumnName;

		private string ContactSchemaTypedColumnName =>
			_contactSchemaTypedColumnName ?? (_contactSchemaTypedColumnName = GetContactSchemaTypedColumnName());

		#endregion

		#region Constructors: Public

		public EsnMessageReader(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private EntitySchema GetEsnMessageSchema() =>
				UserConnection.EntitySchemaManager.GetInstanceByName(EsnMessageEntitySchemaName);

		private string GetSortedColumnName(SortedMessageColumn sortedMessageColumn) => sortedMessageColumn.ToString();

		private void SetOrder(EntitySchemaQuery messageQuery, SortedMessageColumn sortedMessageColumn,
				OrderDirection direction) {
			var sortedColumn = messageQuery.Columns.GetByName(GetSortedColumnName(sortedMessageColumn));
			sortedColumn.OrderDirection = direction;
			sortedColumn.OrderPosition = 1;
		}

		private EntitySchemaQuery GetESQ() {
			var esnMessageSchema = GetEsnMessageSchema();
			var messageQuery = new EntitySchemaQuery(esnMessageSchema) {
				UseAdminRights = false
			};
			return messageQuery;
		}

		private void AddCreatedByColumn(EntitySchemaQuery messageQuery) {
			AddCreatedByIdColumn(messageQuery);
			AddCreatedByNameColumn(messageQuery);
			AddCreatedByTypedColumn(messageQuery);
			AddCreatedByImageColumn(messageQuery);
		}

		private void AddCreatedByImageColumn(EntitySchemaQuery messageQuery) {
			EntitySchemaColumn contactImageColumn = ContactSchema.PrimaryImageColumn;
			if (contactImageColumn == null) {
				return;
			}
			string columnPath = contactImageColumn.IsLookupType ? $"{contactImageColumn.Name}.Id" : contactImageColumn.Name;
			EntitySchemaQueryColumn createdByPrimaryImageColumn = messageQuery.AddColumn($"CreatedBy.{columnPath}");
			createdByPrimaryImageColumn.Name = "CreatedByPrimaryImage";
		}

		private void AddCreatedByTypedColumn(EntitySchemaQuery messageQuery) {
			EntitySchemaQueryColumn createdByTypedColumn;
			if (UserConnection.GetIsFeatureEnabled("IgnoreCreatedByTypedValueInEsnCenter") ||
				ContactSchemaTypedColumnName.IsNullOrEmpty()) {
				createdByTypedColumn = messageQuery.AddColumn(Guid.Empty,
					new GuidDataValueType(UserConnection.DataValueTypeManager));
				createdByTypedColumn.SetForcedQueryColumnValueAlias("CreatedByTypedValue");
			} else {
				createdByTypedColumn = messageQuery.AddColumn($"CreatedBy.{ContactSchemaTypedColumnName}.Id");
			}
			createdByTypedColumn.Name = "CreatedByTypedValue";
		}

		private void AddCreatedByNameColumn(EntitySchemaQuery messageQuery) {
			EntitySchemaColumn contactPrimaryDisplayColumn = ContactSchema.PrimaryDisplayColumn;
			if (contactPrimaryDisplayColumn == null) {
				return;
			}
			EntitySchemaQueryColumn createdByNameColumn =
				messageQuery.AddColumn($"CreatedBy.{contactPrimaryDisplayColumn.Name}");
			createdByNameColumn.Name = "CreatedByName";
		}

		private void AddCreatedByIdColumn(EntitySchemaQuery messageQuery) {
			EntitySchemaColumn contactPrimaryValueColumn = ContactSchema.PrimaryColumn;
			EntitySchemaQueryColumn createdByIdColumn = messageQuery.AddColumn($"CreatedBy.{contactPrimaryValueColumn.Name}");
			createdByIdColumn.Name = "CreatedById";
		}

		private string GetContactSchemaTypedColumnName() {
			const string key = "EsnMessageReader_ContactSchemaTypedColumnUId";
			string cachedValue = GetCreatedByTypedColumnUIdFromCache(key);
			if (cachedValue.IsNullOrEmpty() || !Guid.TryParse(cachedValue, out Guid typedColumnUId) ) {
				typedColumnUId = LoadTypedColumnUId(ContactSchema.UId);
				SaveCreatedByTypedColumnUIdInCache(key, typedColumnUId);
			}
			return typedColumnUId == Guid.Empty ? string.Empty : FindContactSchemaColumnByUId(typedColumnUId);
		}

		private void SaveCreatedByTypedColumnUIdInCache(string key, Guid typedColumnUId) {
			UserConnection.SessionCache[key] = typedColumnUId;
		}

		private string GetCreatedByTypedColumnUIdFromCache(string key) {
			return UserConnection.SessionCache[key]?.ToString();
		}

		private string FindContactSchemaColumnByUId(Guid typedColumnUId) => ContactSchema.Columns.FindByUId(typedColumnUId)?.Name ?? string.Empty;

		private Guid LoadTypedColumnUId(Guid contactSchemaUId) {
			var typedColumnUISelect = new Select(UserConnection)
				.Top(1)
				.Column("SysModuleEntity", "TypeColumnUId").As("SysEntitySchemaUId")
				.From("SysModuleEntity").As("SysModuleEntity")
				.Where("SysModuleEntity", "SysEntitySchemaUId").IsEqual(Column.Parameter(contactSchemaUId)) as Select;
			return typedColumnUISelect.ExecuteScalar<Guid>();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Add filter by message id.
		/// </summary>
		/// <param name="messageQuery">Instance <see cref="EntitySchemaQuery" /></param>
		/// <param name="messageId">Message id.</param>
		protected virtual void AddCommentsQueryFilter(EntitySchemaQuery messageQuery, Guid messageId) {
			messageQuery.Filters.Add(
				messageQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Parent", messageId));
		}

		/// <summary>
		/// Add filter by entity id and options.
		/// </summary>
		/// <param name="messageQuery">Instance <see cref="EntitySchemaQuery" /></param>
		/// <param name="entityId">Entity message id.</param>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		protected virtual void AddEntityMessageFilter(EntitySchemaQuery messageQuery, Guid entityId,
				EsnReadMessageOptions readOptions) {
			if (readOptions.IncludeComments) {
				var entityFilter = new EntitySchemaQueryFilterCollection(messageQuery) {
					LogicalOperation = LogicalOperationStrict.Or
				};
				entityFilter.Add(
					messageQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", entityId));
				entityFilter.Add(
					messageQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Parent.EntityId", entityId));
				messageQuery.Filters.Add(entityFilter);
			} else {
				messageQuery.Filters.Add(messageQuery.CreateIsNullFilter("Parent"));
				messageQuery.Filters.Add(
					messageQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", entityId));
			}
			if (readOptions.OffsetDate != default) {
				var filterComparisonType  = readOptions.OrderDirection == OrderDirection.Descending
					? FilterComparisonType.Less
					: FilterComparisonType.Greater;
				messageQuery.Filters.Add(
					messageQuery.CreateFilterWithParameters(
						filterComparisonType,
						GetSortedColumnName(readOptions.SortedBy),
						readOptions.OffsetDate
					));
			}
			if (readOptions.Filters != null) {
				var filters = readOptions.Filters;
				IEntitySchemaQueryFilterItem esqFilters
					= filters.BuildEsqFilter(messageQuery.RootSchema.UId, UserConnection);
				messageQuery.Filters.Add(esqFilters);
			}
		}

		/// <summary>
		/// Add filter by user subscription feed.
		/// </summary>
		/// <param name="messageQuery">Instance <see cref="EntitySchemaQuery" /></param>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		protected virtual void AddFeedFilter(EntitySchemaQuery messageQuery, EsnReadMessageOptions readOptions) {
			if (readOptions.OffsetDate != default) {
				messageQuery.Filters.Add(
					messageQuery.CreateFilterWithParameters(
						FilterComparisonType.Less,
						GetSortedColumnName(readOptions.SortedBy),
						readOptions.OffsetDate
					));
			}
			var feedFilter = new EntitySchemaQueryFilterCollection(messageQuery);
			var subscriptionFilter = new EntitySchemaQueryFilterCollection(messageQuery) {
				LogicalOperation = LogicalOperationStrict.Or
			};
			var userId = UserConnection.CurrentUser.Id;
			subscriptionFilter.Add(
					messageQuery.CreateFilterWithParameters(
							FilterComparisonType.Equal,
							"[SocialSubscription:EntityId:EntityId].[SysUserInRole:SysRole:SysAdminUnit].SysUser",
							userId
					));
			subscriptionFilter.Add(
					messageQuery.CreateFilterWithParameters(
							FilterComparisonType.Equal,
							"[SocialSubscription:EntityId:EntityId].SysAdminUnit",
							userId
					));
			if (readOptions.IncludeComments) {
				subscriptionFilter.Add(
						messageQuery.CreateFilterWithParameters(
								FilterComparisonType.Equal,
								"[SocialMessage:Id:ParentId].[SocialSubscription:EntityId:EntityId].[SysUserInRole:SysRole:SysAdminUnit].SysUser",
								userId
						));
				subscriptionFilter.Add(
						messageQuery.CreateFilterWithParameters(
								FilterComparisonType.Equal,
								"[SocialMessage:Id:ParentId].[SocialSubscription:EntityId:EntityId].SysAdminUnit",
								userId
						));
			} else {
				messageQuery.Filters.Add(messageQuery.CreateIsNullFilter("Parent"));
			}
			feedFilter.Add(subscriptionFilter);
			var unsubscriptionFilter = new EntitySchemaQueryFilterCollection(messageQuery) {
				IsNot = true
			};
			unsubscriptionFilter.Add(
					messageQuery.CreateFilterWithParameters(
							FilterComparisonType.Equal,
							"[SocialUnsubscription:EntityId:EntityId].SysAdminUnit",
							userId
					));
			feedFilter.Add(unsubscriptionFilter);
			messageQuery.Filters.Add(feedFilter);
		}

		/// <summary>
		/// Add column to messages query.
		/// </summary>
		/// <param name="messageQuery">Instance <see cref="EntitySchemaQuery" />.</param>
		protected virtual void AddMessageQueryColumns(EntitySchemaQuery messageQuery) {
			messageQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			messageQuery.AddColumn("CommentCount");
			AddCreatedByColumn(messageQuery);
			messageQuery.AddColumn("CreatedOn");
			messageQuery.AddColumn("LastActionOn");
			messageQuery.AddColumn("EntityId");
			messageQuery.AddColumn("EntitySchemaUId");
			var entitySchemaName = messageQuery.AddColumn("[SysSchema:UId:EntitySchemaUId].Name");
			entitySchemaName.Name = "EntitySchemaName";
			var entitySchemaCaption = messageQuery.AddColumn("[SysSchema:UId:EntitySchemaUId].Caption");
			entitySchemaCaption.Name = "EntitySchemaCaption";
			if (UserConnection.GetFeatureState("LinkPreview") == 0) {
				var linkPreviewDataColumn = messageQuery.AddColumn("[LinkPreviewData:EntityId:Id].Data");
				linkPreviewDataColumn.Name = "LinkPreviewData";
			}
			messageQuery.AddColumn("LikeCount");
			messageQuery.AddColumn("Message");
			messageQuery.AddColumn("Parent");
			var colorColumn = messageQuery.AddColumn("[SocialChannel:Id:EntityId].Color");
			colorColumn.Name = "Color";
		}

		/// <summary>
		/// Get query for retrieving messages.
		/// </summary>
		/// <returns>Instance <see cref="EntitySchemaQuery" />.</returns>
		protected virtual EntitySchemaQuery GetMessageQuery() {
			var messageQuery = GetESQ();
			AddMessageQueryColumns(messageQuery);
			return messageQuery;
		}

		/// <summary>
		/// Get query for retrieving messages with all columns entity.
		/// </summary>
		/// <returns>Instance <see cref="EntitySchemaQuery" />.</returns>
		protected virtual EntitySchemaQuery GetMessageAllColumnQuery() {
			var messageQuery = GetESQ();
			messageQuery.AddAllSchemaColumns();
			return messageQuery;
		}

		/// <summary>
		/// Get query for retrieving messages.
		/// </summary>
		/// <param name="sortedBy">Sorted messages by <see cref="SortedMessageColumn" />.</param>
		/// <param name="direction">Sorted direction.</param>
		/// <returns>Instance <see cref="EntitySchemaQuery" />.</returns>
		protected virtual EntitySchemaQuery GetMessageQuery(SortedMessageColumn sortedBy, OrderDirection direction =
				OrderDirection.Descending) {
			var messageQuery = GetMessageQuery();
			SetOrder(messageQuery, sortedBy, direction);
			return messageQuery;
		}

		/// <summary>
		/// Get query for retrieving messages.
		/// </summary>
		/// <param name="readOptions">Reading options <see cref="EsnReadMessageOptions" />.</param>
		/// <returns>Instance <see cref="EntitySchemaQuery" />.</returns>
		protected virtual EntitySchemaQuery GetMessageQuery(EsnReadMessageOptions readOptions) {
			var messageQuery = GetMessageQuery(readOptions.SortedBy, readOptions.OrderDirection);
			messageQuery.RowCount = readOptions.ReadMessageCount;
			return messageQuery;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public IEnumerable<Entity> ReadComments(Guid messageId) {
			var messageQuery = GetMessageQuery(SortedMessageColumn.CreatedOn, OrderDirection.Ascending);
			AddCommentsQueryFilter(messageQuery, messageId);
			return messageQuery.GetEntityCollection(UserConnection);
		}

		/// <inheritdoc />
		public Entity ReadMessage(Guid messageId) {
			var messageQuery = GetMessageQuery();
			return messageQuery.GetEntity(UserConnection, messageId);
		}

		/// <inheritdoc />
		public Entity ReadMessageAllColumnsEntity(Guid messageId) {
			var messageQuery = GetMessageAllColumnQuery();
			return messageQuery.GetEntity(UserConnection, messageId);
		}

		/// <inheritdoc />
		public IEnumerable<Entity> ReadEntityMessage(Guid entityId, EsnReadMessageOptions readOption) {
			var messageQuery = GetMessageQuery(readOption);
			AddEntityMessageFilter(messageQuery, entityId, readOption);
			return messageQuery.GetEntityCollection(UserConnection);
		}

		/// <inheritdoc />
		public IEnumerable<Entity> ReadFeedMessage(EsnReadMessageOptions readOption) {
			var messageQuery = GetMessageQuery(readOption);
			AddFeedFilter(messageQuery, readOption);
			return messageQuery.GetEntityCollection(UserConnection);
		}

		#endregion
	}

	#endregion
}

