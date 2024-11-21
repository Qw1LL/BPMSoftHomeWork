namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using Marketing.Utilities;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using System.Text;
	using EntitySchema = Core.Entities.EntitySchema;
	using EntityCollection = Core.Entities.EntityCollection;

	#region Class: BulkEmailAudienceRepository

	/// <summary>
	/// Implements CRUD operations for audience of the bulk email.
	/// </summary>
	public class BulkEmailAudienceRepository : IBulkEmailAudienceRepository
	{

		#region Constants: Private

		private const string contactIdAlias = "Contact_Id";
		private const string emailAddressAlias = "Email_Address";
		private const string linkedEntityIdAlias = "LinkedEntity_Id";
		private const string recipientTableName = "BulkEmailTarget";
		private const string bulkEmailTableName = "BulkEmail";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailAudienceRepository"/> class.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public BulkEmailAudienceRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailAudienceRepository"/> class with batch size setup.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="queryBatchSize">Defines size of a batch for each query.</param>
		public BulkEmailAudienceRepository(UserConnection userConnection, int queryBatchSize) :this(userConnection) {
			QueryBatchSize = queryBatchSize;
		}

		#endregion

		#region Properties: Private

		private int QueryBatchSize { get; set; } = 500;
		private Guid SessionUId { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="UserConnection"/> class.
		/// </summary>
		public UserConnection UserConnection { get; set; }

		/// <summary>
		/// Instance of recipient linked entity schema. 
		/// </summary>
		public EntitySchema SourceSchema { get; set; }

		/// <summary>
		/// Path to Contact column in linked entity schema. 
		/// </summary>
		public string ContactPath { get; set; }

		/// <summary>
		/// Path to Email column in linked entity schema. 
		/// </summary>
		public string EmailPath { get; set; }

		/// <summary>
		/// Instance of BulkEmailEventLogger. 
		/// </summary>
		private BulkEmailEventLogger _bulkEmailEventLogger;
		public BulkEmailEventLogger BulkEmailEventLogger =>
			_bulkEmailEventLogger ?? (_bulkEmailEventLogger = new BulkEmailEventLogger(UserConnection));

		/// <summary>
		/// Unique identifier of the bulk email.
		/// </summary>
		private Guid _bulkEmailId;
		public Guid BulkEmailId {
			get => _bulkEmailId;
			set {
				if (_bulkEmailId != value) {
					_bulkEmailId = value;
					InitBulkEmailProperties();
				}
			}
		}

		#endregion

		#region Methods: Private

		private string GetLczStringValue(string lczName) {
			var localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, "BulkEmailAudienceRepository", localizableStringName);
			var value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private EntitySchemaQueryColumn GetQueryColumn(string schemaName, string column, string path, string alias) {
			var schema = new EntitySchemaQuery(SourceSchema.EntitySchemaManager, schemaName).GetSchema();
			return GetQueryColumn(schema, column, path, alias);
		}

		private EntitySchemaQueryColumn GetQueryColumn(EntitySchema schema, string column, string path, string alias) {
			var col = schema.AddColumn("Integer", column);
			var queryColumn = new EntitySchemaQueryColumn(alias) {
				ValueExpression = new EntitySchemaQueryExpression(schema, col, path),
				IsAlwaysSelect = false
			};
			queryColumn.SetForcedQueryColumnValueAlias(alias);
			return queryColumn;
		}

		private Delete GetDeleteRecipientsQuery() {
			return new Delete(UserConnection)
				.From(recipientTableName)
				.Where("BulkEmailId").IsEqual(Column.Parameter(BulkEmailId)) as Delete;
		}

		private void SafeDelete(Select subSelect, ref int result) {
			subSelect.Top(QueryBatchSize);
			var delete = GetDeleteRecipientsQuery()
				.And("MandrillId").In(subSelect) as Delete;
			var queryResult = 0;
			do {
				queryResult = delete.Execute();
				result += queryResult;
				Thread.Sleep(100);
			} while (queryResult > 0);
		}

		private EntitySchemaQuery GetAudienceESQ(EntitySchemaQuery sourceEsq = null) {
			var contactIdPath = string.IsNullOrWhiteSpace(ContactPath) ? "Id" : ContactPath + ".Id";
			var esq = sourceEsq ?? new EntitySchemaQuery(SourceSchema);
			esq.Columns.Clear();
			esq.AddColumn("Id").SetForcedQueryColumnValueAlias(linkedEntityIdAlias);
			esq.AddColumn(contactIdPath).SetForcedQueryColumnValueAlias(contactIdAlias);
			var contactIdNotNullFilter = esq.CreateIsNotNullFilter(contactIdPath);
			esq.Filters.Add(contactIdNotNullFilter);
			return esq;
		}

		private Select GetFilteredAudienceQuery(IEnumerable<Guid> entityList) {
			var esq = GetAudienceESQ();
			var select = esq.GetSelectQuery(UserConnection);
			select.And(SourceSchema.Name, "Id").In(Column.Parameters(entityList));
			return AddRecipientFilters(select);
		}

		private Select GetFilteredAudienceQuery(Select filterSelect) {
			var esq = GetAudienceESQ();
			var select = esq.GetSelectQuery(UserConnection);
			select.And().Exists(filterSelect);
			return AddRecipientFilters(select);
		}

		private Select GetRecipientsSelect() {
			return new Select(UserConnection)
				.Column("MandrillId")
				.From(recipientTableName).As("Recipient")
				.Where("BulkEmailId").IsEqual(Column.Parameter(BulkEmailId)) as Select;
		}

		private Select GetExistingRecipientQuery() {
			var select = GetRecipientsSelect();
			if (SourceSchema.Name == "Contact") {
				select.And("ContactId").IsEqual(contactIdAlias);
			} else {
				select.And("LinkedEntityId").IsEqual(linkedEntityIdAlias);
			}
			select.And("BulkEmailResponseId")
				.IsEqual(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId))
				.And("BE", "CategoryId")
				.IsEqual(Column.Parameter(MailingConsts.MassmailingBulkEmailCategoryId));
			select.InnerJoin("BulkEmail").As("BE")
				.On("BE", "Id").IsEqual("Recipient", "BulkEmailId");
			return select;
		}

		private Select AddRecipientFilters(Select select) {
			var resultSelect = new Select(UserConnection)
				.Column(linkedEntityIdAlias)
				.Column(contactIdAlias)
				.From(select).As("Recipient")
				.Where(Column.Parameter(1)).IsEqual(Column.Parameter(1)) as Select;
			var existingRecipientQuery = GetExistingRecipientQuery();
			resultSelect.And().Not().Exists(existingRecipientQuery);
			resultSelect.SpecifyNoLockHints();
			return resultSelect;
		}

		private Select GetAudienceQuery(IEnumerable<Guid> keys) {
			var esq = GetAudienceESQ();
			esq.AddColumn(EmailPath).SetForcedQueryColumnValueAlias(emailAddressAlias);
			var select = esq.GetSelectQuery(UserConnection);
			select.And(SourceSchema.Name, "Id").In(Column.Parameters(keys));
			return select;
		}

		private Entity GetFolderEntity(Guid recordId) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(SourceSchema.Name + "Folder");
			var esq = new EntitySchemaQuery(schema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("FolderType");
			esq.AddColumn("Name");
			esq.AddColumn("SearchData");
			return esq.GetEntity(UserConnection, recordId);
		}

		private Select GetStaticFolderSelect(Entity folder) {
			var folderId = folder.GetTypedColumnValue<Guid>("Id");
			var folderTable = SourceSchema.Name + "InFolder";
			var folderSelect = new Select(UserConnection)
				.Column("Id")
				.From(folderTable)
				.Where(SourceSchema.Name + "Id").IsEqual(SourceSchema.Name, "Id")
				.And("FolderId").IsEqual(Column.Parameter(folderId)) as Select;
			return GetFilteredAudienceQuery(folderSelect);
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
				RootSchemaName = SourceSchema.Name,
				Filters = DeserializeFilters(searchData)
			};
			var folderEsq = BuildFolderEsq(selectQuery);
			return GetRecipientsSelectFromEsq(folderEsq);
		}

		private void IncreaseRecipientCount(int addedCount) {
			var update = new Update(UserConnection, bulkEmailTableName)
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Set("RecipientCount",
					QueryColumnExpression.Add(new QueryColumnExpression("RecipientCount"),
						Column.Parameter(addedCount)))
				.Where("Id").IsEqual(Column.Parameter(BulkEmailId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void DecreaseRecipientCount(int count) {
			var update = new Update(UserConnection, bulkEmailTableName)
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
			update.Where("Id").IsEqual(Column.Parameter(BulkEmailId));
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private SelectQuery DeserializeEsq(string esqSerialized) {
			var selectQuery = Json.Deserialize<SelectQuery>(esqSerialized);
			selectQuery.CheckArgumentNull($"{nameof(BulkEmailAudienceRepository)}.DeserializeEsq selectQuery");
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
			var audienceEsq = GetAudienceESQ(sourceEsq);
			var audienceSelect = audienceEsq.GetSelectQuery(UserConnection);
			return AddRecipientFilters(audienceSelect);
		}

		private void ApplyDuplicateFilter(BulkEmailAudienceDuplicateType type, EntitySchemaQuery esq,
				Guid bulkEmailId) {
			var select = esq.GetSelectQuery(UserConnection);
			Select subSelect;
			switch (type) {
				case BulkEmailAudienceDuplicateType.Email:
					subSelect = GetDuplicateEmailSelect(bulkEmailId, esq.RootSchema.Name);
					select.InnerJoin(subSelect).As("ct")
						.On("ct", "EmailAddress").IsEqual(esq.RootSchema.Name, "EmailAddress");
					break;
				case BulkEmailAudienceDuplicateType.Contact:
					subSelect = GetDuplicateContactSelect(bulkEmailId, esq.RootSchema.Name);
					select.InnerJoin(subSelect).As("ct")
						.On("ct", "ContactId").IsEqual(esq.RootSchema.Name, "ContactId");
					break;
			}
		}

		private Select GetDuplicateEmailSelect(Guid bulkEmailId, string rootSchemaName) {
			return new Select(UserConnection)
				.Column("EmailAddress")
				.From(rootSchemaName)
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId))
				.GroupBy("EmailAddress")
				.Having(Func.Count("Id")).IsGreater(Column.Parameter(1)) as Select;
		}

		private Select GetDuplicateContactSelect(Guid bulkEmailId, string rootSchemaName) {
			return new Select(UserConnection)
				.Column("ContactId")
				.From(rootSchemaName)
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId))
				.GroupBy("ContactId")
				.Having(Func.Count("Id")).IsGreater(Column.Parameter(1)) as Select;
		}

		private Select GetDuplicateValuesSelect(Guid bulkEmailId, EntitySchemaQuery esq, string columnName) {
			var select = esq.GetSelectQuery(UserConnection);
			var rootSchemaName = esq.RootSchema.Name;
			var result = new Select(select);
			result.Columns.Clear();
			result.Column(rootSchemaName, columnName)
				.And(rootSchemaName, "BulkEmailId").IsEqual(Column.Parameter(bulkEmailId))
				.GroupBy(rootSchemaName, columnName)
				.Having(Func.Count(rootSchemaName, "Id")).IsGreater(Column.Parameter(1));
			result.SpecifyNoLockHints();
			return result;
		}

		private void DeleteDuplicates(BulkEmailAudienceDuplicateType type, EntitySchemaQuery esq, Guid bulkEmailId,
				ref int result) {
			var select = esq.GetSelectQuery(UserConnection);
			var queryResult = true;
			while (queryResult) {
				var workSelect = new Select(select);
				Select valueSelect;
				var columnName = "ContactId";
				switch (type) {
					case BulkEmailAudienceDuplicateType.Email:
						columnName = "EmailAddress";
						valueSelect = GetDuplicateValuesSelect(bulkEmailId, esq, columnName).Top(QueryBatchSize);
						var emails = valueSelect.ExecuteEnumerable(r => r.GetColumnValue<string>(columnName)).ToList();
						queryResult = emails.Any();
						workSelect.And(esq.RootSchema.Name, columnName).In(Column.Parameters(emails));
						break;
					case BulkEmailAudienceDuplicateType.Contact:
						columnName = "ContactId";
						valueSelect = GetDuplicateValuesSelect(bulkEmailId, esq, columnName).Top(QueryBatchSize);
						var contacts = valueSelect.ExecuteEnumerable(r => r.GetColumnValue<Guid>(columnName)).ToList();
						queryResult = contacts.Any();
						workSelect.And(esq.RootSchema.Name, columnName).In(Column.Parameters(contacts));
						break;
				}
				if (queryResult) {
					SafeDelete(workSelect, ref result);
				}
			};
		}

		#endregion

		#region Methods: Protected

		protected void InitBulkEmailProperties() {
			var targetSchema = UserConnection.EntitySchemaManager.GetInstanceByName("BulkEmail");
			var esq = new EntitySchemaQuery(targetSchema);
			esq.AddColumn("AudienceSchema.EntityObject.Id");
			esq.AddColumn("AudienceSchema.ContactColumn");
			esq.AddColumn("AudienceSchema.EmailAddressColumn");
			var bulkEmail = esq.GetEntity(UserConnection, BulkEmailId);
			var sourceSchemaUId = bulkEmail.GetTypedColumnValue<Guid>("AudienceSchema_EntityObject_Id");
			if (sourceSchemaUId.IsNotEmpty()) {
				SourceSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(sourceSchemaUId);
				ContactPath = bulkEmail.GetTypedColumnValue<string>("AudienceSchema_ContactColumn");
				EmailPath = bulkEmail.GetTypedColumnValue<string>("AudienceSchema_EmailAddressColumn");
			}
			if (SourceSchema == null) {
				SourceSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
				EmailPath = "Email";
			}
		}

		protected List<Select> GetAudienceSelect(IEnumerable<Guid> entityList) {
			var selects = new List<Select>();
			var totalCount = entityList.Count();
			var count = 0;
			while (count < totalCount) {
				var batch = entityList.Skip(count).Take(QueryBatchSize);
				var batchSelect = GetFilteredAudienceQuery(batch);
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

		protected InsertSelect GetInsertSelect(IEnumerable<Guid> keys) {
			var query = GetAudienceQuery(keys);
			var createdOnColumn = DateTime.UtcNow;
			query
				.Column(Column.Parameter(BulkEmailId))
				.Column(Column.Parameter(createdOnColumn))
				.Column(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId));
			var insertSelect = new InsertSelect(UserConnection)
				.Into(recipientTableName)
				.Set("LinkedEntityId", "ContactId", "EmailAddress", "BulkEmailId", "CreatedOn", "BulkEmailResponseId")
				.FromSelect(query);
			return insertSelect;
		}

		protected int ExecuteAudienceInsert(Select select, out int totalCount) {
			var result = 0;
			var keys = select.ExecuteEnumerable(r => r.GetColumnValue<Guid>(linkedEntityIdAlias)).ToList();
			totalCount = keys.Count();
			var insertCount = 0;
			while (insertCount < totalCount) {
				var batch = keys.Skip(insertCount).Take(QueryBatchSize);
				var insertSelect = GetInsertSelect(batch);
				result += insertSelect.Execute();
				insertCount += QueryBatchSize;
				Thread.Sleep(50);
			}
			return result;
		}

		protected int InsertAudienceFromSelects(IEnumerable<Select> selects, out int totalCount) {
			var result = 0;
			totalCount = 0;
			foreach (var select in selects) {
				if (select == null) {
					continue;
				}
				var count = 0;
				result += ExecuteAudienceInsert(select, out count);
				totalCount += count;
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds list of entities as audience.
		/// </summary>
		/// <param name="audience">List of entity identifiers to add.</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="sessionUId">Unique identifier of trigger email session.</param>
		/// <returns>Number of contacts added.</returns>
		public virtual int ImportEntities(IEnumerable<Guid> audience, Guid bulkEmailId, Guid sessionUId) {
			var startDate = DateTime.UtcNow;
			try {
				BulkEmailId = bulkEmailId;
				SessionUId = sessionUId;
				var selects = GetAudienceSelect(audience);
				var result = InsertAudienceFromSelects(selects, out int totalCount);
				BulkEmailEventLogger.LogInfo(BulkEmailId, startDate, GetLczStringValue("SuccessInsert"),
					GetLczStringValue("SuccessInsertDescription"), UserConnection.CurrentUser.ContactId,
					SourceSchema.Caption, result, totalCount);
				if (result > 0) {
					IncreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorInsertEntities"), ex,
					GetLczStringValue("ErrorInsertDescription"), UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		/// <summary>
		/// Adds audience from entity folder.
		/// </summary>
		/// <param name="folderId">Unique identifier of the entity folder.</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="sessionUId">Unique identifier of trigger email session.</param>
		/// <returns>Number of contacts added.</returns>
		public virtual int ImportEntityFolder(Guid folderId, Guid bulkEmailId, Guid sessionUId) {
			var folder = default(Entity);
			var startDate = DateTime.UtcNow;
			try {
				BulkEmailId = bulkEmailId;
				SessionUId = sessionUId;
				folder = GetFolderEntity(folderId);
				var folderName = folder?.GetTypedColumnValue<string>("Name") ?? folderId.ToString();
				var select = GetFolderSelect(folder);
				var result = InsertAudienceFromSelects(new[] { select }, out int totalCount);
				if (totalCount > 0) {
					BulkEmailEventLogger.LogInfo(BulkEmailId, startDate, GetLczStringValue("SuccessInsert"),
						GetLczStringValue("SuccessInsertFolderDescription"), UserConnection.CurrentUser.ContactId,
						SourceSchema.Caption, result, totalCount, folderName);
				} else {
					BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorInsertFolder"),
						GetLczStringValue("EmptyFolderInsertDescription"), UserConnection.CurrentUser.ContactId,
						folderName);
				}
				if (result > 0) {
					IncreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				var folderName = folder?.GetTypedColumnValue<string>("Name") ?? folderId.ToString();
				BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorInsertFolder"), ex,
					GetLczStringValue("ErrorInsertFolderDescription"), UserConnection.CurrentUser.ContactId, folderName);
				throw;
			}
		}

		/// <summary>
		/// Adds audience by filter.
		/// </summary>
		/// <param name="esqSerialized">Serialized ESQ (SelectQuery)</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="sessionUId">Unique identifier of trigger email session.</param>
		/// <returns>Number of imported records.</returns>
		/// <exception cref="ArgumentNullOrEmptyException"/>
		public virtual int ImportByFilter(string esqSerialized, Guid bulkEmailId, Guid sessionUId) {
			var startDate = DateTime.UtcNow;
			try {
				BulkEmailId = bulkEmailId;
				SessionUId = sessionUId;
				var selectQuery = DeserializeEsq(esqSerialized);
				var sourceEsq = selectQuery.BuildEsq(UserConnection);
				sourceEsq.CheckArgumentNull($"{nameof(BulkEmailAudienceRepository)}.DeserializeEsq esq");
				var audienceSelect = GetRecipientsSelectFromEsq(sourceEsq);
				var result = InsertAudienceFromSelects(new[] { audienceSelect }, out int totalCount);
				if (totalCount > 0) {
					BulkEmailEventLogger.LogInfo(BulkEmailId, startDate, GetLczStringValue("SuccessInsert"),
						GetLczStringValue("SuccessInsertByFilterDescription"), UserConnection.CurrentUser.ContactId,
						SourceSchema.Caption, result, totalCount);
				} else {
					BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorInsertByFilter"),
						GetLczStringValue("EmptyFilterInsertDescription"), UserConnection.CurrentUser.ContactId);
				}
				if (result > 0) {
					IncreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorInsertByFilter"), ex,
					GetLczStringValue("ErrorInsertByFilterDescription"), UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		/// <summary>
		/// Deletes list of recipients from bulk email.
		/// </summary>
		/// <param name="audience">List of recipient identifiers to delete.</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>Number of recipients deleted.</returns>
		public virtual int Delete(IEnumerable<Guid> audience, Guid bulkEmailId) {
			var startDate = DateTime.UtcNow;
			try {
				var result = 0;
				BulkEmailId = bulkEmailId;
				var totalCount = audience.Count();
				var deleteCount = 0;
				while (deleteCount < totalCount) {
					var batch = audience.Skip(deleteCount).Take(QueryBatchSize);
					var delete = GetDeleteRecipientsQuery()
						.And("MandrillId").In(Column.Parameters(batch));
					result += delete.Execute();
					deleteCount += QueryBatchSize;
				}
				if (result > 0) {
					BulkEmailEventLogger.LogInfo(BulkEmailId, startDate, GetLczStringValue("SuccessDelete"),
						GetLczStringValue("SuccessDeleteDescription"), UserConnection.CurrentUser.ContactId, result);
					DecreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorDelete"), ex,
					GetLczStringValue("ErrorDeleteDescription"), UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		/// <summary>
		/// Deletes recipients from bulk email by filter.
		/// </summary>
		/// <param name="esqSerialized">Serialized ESQ (SelectQuery)</param>
		/// <param name="duplicateType">Audience duplicate type.</param>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>Number of recipients deleted.</returns>
		public virtual int DeleteByFilter(string esqSerialized, BulkEmailAudienceDuplicateType duplicateType,
				Guid bulkEmailId) {
			var result = 0;
			var startDate = DateTime.UtcNow;
			try {
				BulkEmailId = bulkEmailId;
				var selectQuery = DeserializeEsq(esqSerialized);
				var schema = UserConnection.EntitySchemaManager.GetInstanceByName(selectQuery.RootSchemaName)
					.Clone() as EntitySchema;
				var column = schema.Columns.FindByName("LinkedEntity");
				column.ReferenceSchema = SourceSchema;
				column.ReferenceSchemaUId = SourceSchema.UId;
				var sourceEsq = selectQuery.BuildEsq(schema, UserConnection, out var columnNameMap);
				sourceEsq.CheckArgumentNull($"{nameof(BulkEmailAudienceRepository)}.DeserializeEsq esq");
				CommonUtilities.DisableEmptyEntitySchemaQueryFilters(sourceEsq.Filters);
				if (IsEsqFiltersEmpty(sourceEsq.Filters)) {
					return 0;
				}
				if (duplicateType != BulkEmailAudienceDuplicateType.None) {
					DeleteDuplicates(duplicateType, sourceEsq, bulkEmailId, ref result);
				} else {
					var select = sourceEsq.GetSelectQuery(UserConnection);
					SafeDelete(select, ref result);
				}
				if (result > 0) {
					BulkEmailEventLogger.LogInfo(BulkEmailId, startDate, GetLczStringValue("SuccessDelete"),
						GetLczStringValue("SuccessDeleteDescription"), UserConnection.CurrentUser.ContactId, result);
					DecreaseRecipientCount(result);
				}
				return result;
			} catch (Exception ex) {
				BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorDelete"), ex,
					GetLczStringValue("ErrorDeleteDescription"), UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		/// <summary>
		/// Deletes all recipients from bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>Number of recipients deleted.</returns>
		public virtual int DeleteAll(Guid bulkEmailId) {
			var startDate = DateTime.UtcNow;
			var result = 0;
			try {
				BulkEmailId = bulkEmailId;
				var select = GetRecipientsSelect();
				SafeDelete(select, ref result);
				if (result > 0) {
					BulkEmailEventLogger.LogInfo(BulkEmailId, startDate, GetLczStringValue("SuccessDeleteAll"),
						GetLczStringValue("SuccessDeleteAllDescription"), UserConnection.CurrentUser.ContactId);
					DecreaseRecipientCount(int.MaxValue);
				}
				return result;
			} catch (Exception ex) {
				BulkEmailEventLogger.LogError(BulkEmailId, startDate, GetLczStringValue("ErrorDelete"), ex,
					GetLczStringValue("ErrorDeleteDescription"), UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		/// <summary>
		/// Gets audience of the bulk email with duplicate conditions.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="esq">Select query of the bulk email audience.</param>
		/// <param name="duplicateType">Audience duplicate type.</param>
		/// <param name="options">Select query options.</param>
		/// <returns>Collection of recipients with duplicate email address.</returns>
		public virtual EntityCollection SelectAudience(Guid bulkEmailId, EntitySchemaQuery esq,
				BulkEmailAudienceDuplicateType duplicateType, EntitySchemaQueryOptions options) {
			ApplyDuplicateFilter(duplicateType, esq, bulkEmailId);
			return options != null
				? esq.GetEntityCollection(UserConnection, options)
				: esq.GetEntityCollection(UserConnection);
		}

		#endregion
	}

	#endregion

}

