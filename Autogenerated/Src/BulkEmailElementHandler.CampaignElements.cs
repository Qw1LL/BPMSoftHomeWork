namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;
	using System.Threading.Tasks;

	#region Class: BulkEmailElementHandler

	/// <summary>
	/// Contains methods for maintaining bulk email elements in campaign.
	/// </summary>
	public sealed class BulkEmailElementHandler : CampaignEventHandlerBase, IOnCampaignAfterSave, IOnCampaignDelete,
		IOnCampaignValidate, IOnCampaignStart, IOnCampaignStop, IOnCampaignCopy, IOnCampaignExecutionTerminate
	{

		#region Constants: Private

		private const string ElementHandlerName = nameof(BulkEmailElementHandler);
		private const string CampaignParticipantTableName = nameof(CampaignParticipant);
		private const string MandrillRecipientTableName = "MandrillRecipient";
		private const string BulkEmailTableName = nameof(BulkEmail);
		private const string CampaignItemTableName = nameof(CampaignItem);
		private const string CampaignParticipantEmailTargetTableName = nameof(CmpgnPrtcpntEmailTarget);

		#endregion

		#region Fields: Private

		private Guid _bulkEmailSchemaUId = new Guid("95FBCF9C-E36D-4ACD-8B5A-D657DE6E30A8");

		#endregion

		#region Properties: Private

		/// <summary>
		/// Flag based on CampaignBatchQueries feature state.
		/// </summary>
		private bool UseCampaignBatchedQueries => UserConnection.GetIsFeatureEnabled("CampaignBatchedQueries");

		/// <summary>
		/// Size of a single batch to split queries while using CampaignBatchedQueries feature.
		/// </summary>
		private int _campaignElementAudienceQueryBatchSize = int.MinValue;
		private int CampaignElementAudienceQueryBatchSize {
			get {
				if (_campaignElementAudienceQueryBatchSize < 0) {
					var value = Core.Configuration.SysSettings.GetValue(UserConnection,
						"CampaignElementAudienceQueryBatchSize", 500);
					_campaignElementAudienceQueryBatchSize = Math.Max(value, 0);
				}
				return _campaignElementAudienceQueryBatchSize;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="MailingService"/> class.
		/// </summary>
		private MailingService _mailingService;
		public MailingService MailingService {
			get => _mailingService ?? (_mailingService = GetMailingService());
			set => _mailingService = value;
		}

		#endregion

		#region Methods: Private

		private MailingService GetMailingService() {
			return ClassFactory.Get<MailingService>(new ConstructorArgument("userConnection", UserConnection));
		}

		private IEnumerable<MarketingEmailElement> GetBulkEmailElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<MarketingEmailElement>();
		}

		private IEnumerable<Guid> GetBulkEmailIds(CoreCampaignSchema schema) {
			return GetBulkEmailElements(schema).Select(x => x.MarketingEmailId);
		}
		
		private void BindBulkEmails(IEnumerable<Guid> bulkEmailIds, Guid campaignId, Guid statusId) {
			if (bulkEmailIds.Any()) {
				var update = new Update(UserConnection, "BulkEmail")
					.Set("CampaignId", Column.Parameter(campaignId))
					.Set("IsAudienceInited", Column.Parameter(true));
				if (statusId == CampaignConsts.RunCampaignStatusId) {
					UpdateBulkEmailsStatus(bulkEmailIds, MailingConsts.BulkEmailStatusActiveId);
				}
				update.Where(Column.SourceColumn("Id")).In(Column.Parameters(bulkEmailIds));
				update.WithHints(new RowLockHint());
				update.Execute();
			}
		}

		private void UnbindBulkEmails(Guid campaignId) {
			var update = new Update(UserConnection, "BulkEmail")
				.Set("CampaignId", Column.Const(null))
				.Set("IsAudienceInited", Column.Parameter(false))
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}
		
		private void UnbindRemovedBulkEmails(IEnumerable<Guid> bulkEmailIds, Guid statusId) {
			IEnumerable<Guid> boundBulkEmailIds = CampaignSchema.InitialSchema != null ?
				GetBulkEmailIds(CampaignSchema.InitialSchema) : Enumerable.Empty<Guid>();
			List<Guid> removedBulkEmailIds = boundBulkEmailIds.Where(x => !bulkEmailIds.Contains(x)).ToList();
			if (removedBulkEmailIds.Any()) {
				var update = new Update(UserConnection, "BulkEmail")
					.Set("CampaignId", Column.Const(null))
					.Set("IsAudienceInited", Column.Parameter(false));
				if (statusId != CampaignConsts.PlannedCampaignStatusId) {
					UpdateBulkEmailsStatus(removedBulkEmailIds, MailingConsts.BulkEmailStatusStoppedId);
				}
				update.Where(Column.SourceColumn("Id")).In(Column.Parameters(removedBulkEmailIds));
				update.WithHints(new RowLockHint());
				update.Execute();
			}
		}

		private void UpdateBulkEmailsStatus(IEnumerable<Guid> bulkEmailIds, Guid statusId) {
			if (bulkEmailIds.Any()) {
				var update = new Update(UserConnection, "BulkEmail")
					.Set("StatusId", Column.Parameter(statusId))
					.Where(Column.SourceColumn("Id")).In(Column.Parameters(bulkEmailIds))
					.And(Column.SourceColumn("StatusId")).Not().In(Column.Parameters(MailingConsts.FinalStatuses)) as Update;
				update.WithHints(new RowLockHint());
				update.Execute();
			}
		}

		private void PingMailingProvider() {
			if (!MailingService.PingProvider()) {
				string message = GetLczStringValue(ElementHandlerName, "CESIntegrationException");
				CampaignSchema.AddValidationInfo(message, CampaignValidationInfoLevel.Warning);
			}
		}

		private void ValidateMessages(IEnumerable<Guid> bulkEmailIds) {
			ConfigurationServiceResponse response = MailingService.ValidateMessages(bulkEmailIds.ToArray());
			if (!response.Success) {
				CampaignSchema.AddValidationInfo(response.ErrorInfo.Message, CampaignValidationInfoLevel.Warning);
			}
		}

		private void ValidateDraftStatus(IEnumerable<Guid> bulkEmailIds) {
			ConfigurationServiceResponse response = MailingService.ValidateDraftStatus(bulkEmailIds.ToArray());
			if (!response.Success) {
				CampaignSchema.AddValidationInfo(response.ErrorInfo.Message, CampaignValidationInfoLevel.Error);
			}
		}

		private Entity CopyEntity(Entity source) {
			var sourceEntityId = source.GetTypedColumnValue<Guid>("Id");
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(source.Schema.Name);
			var newEntity = entitySchema.CreateEntity(UserConnection);
			SetOldPrimaryColumnValue(newEntity, sourceEntityId);
			newEntity.SetDefColumnValues();
			CopyCloneableColumnValues(source, newEntity);
			return newEntity;
		}

		private void SetOldPrimaryColumnValue(Entity entity, Guid oldPrimaryColumnValue) {
			var primaryColumnName = entity.Schema.PrimaryColumn.Name;
			var primaryColumnValue = entity.FindEntityColumnValue(primaryColumnName);
			entity.SetColumnValue(primaryColumnName, oldPrimaryColumnValue);
			primaryColumnValue.ResetOldValue();
		}

		private void CopyCloneableColumnValues(Entity source, Entity target) {
			var columnNames = source.GetColumnValueNames();
			var columns = source.Schema.Columns
				.Where(x => x.IsValueCloneable && columnNames.Contains(x.ColumnValueName));
			foreach (var column in columns) {
				target.SetColumnValue(column.ColumnValueName, source.GetColumnValue(column.ColumnValueName));
			}
		}

		private Guid CopyBulkEmailEntity(Entity sourceBulkEmail, Guid campaignId) {
			var newEntityId = Guid.NewGuid();
			var sourceName = sourceBulkEmail.GetTypedColumnValue<string>("Name");
			var newBulkEmailName = GetUniqueName(sourceName, sourceBulkEmail.Schema.Name);
			var newBulkEmailEntity = CopyEntity(sourceBulkEmail);
			newBulkEmailEntity.SetColumnValue("Id", newEntityId);
			newBulkEmailEntity.SetColumnValue("Name", newBulkEmailName);
			newBulkEmailEntity.SetColumnValue("CampaignId", campaignId);
			newBulkEmailEntity.SetColumnValue("StatusId", MarketingConsts.BulkEmailStatusPlannedId);
			newBulkEmailEntity.SetColumnValue("StartDate", sourceBulkEmail.GetColumnValue("StartDate"));
			newBulkEmailEntity.SetColumnValue("SendStartDate", null);
			newBulkEmailEntity.Save();
			return newEntityId;
		}

		private void BindNewBulkEmails(CoreCampaignSchema schema) {
			IEnumerable<MarketingEmailElement> bulkEmailElements = schema.FlowElements.OfType<MarketingEmailElement>();
			foreach (var bulkEmailElement in bulkEmailElements) {
				var bulkEmailESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "BulkEmail");
				bulkEmailESQ.AddAllSchemaColumns();
				IEntitySchemaQueryFilterItem filter = bulkEmailESQ.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Id", bulkEmailElement.MarketingEmailId);
				bulkEmailESQ.Filters.Add(filter);
				Entity bulkEmailEntity = bulkEmailESQ.GetEntity(UserConnection, bulkEmailElement.MarketingEmailId);
				if (bulkEmailEntity != null) {
					var bulkEmailCopyId = CopyBulkEmailEntity(bulkEmailEntity, schema.EntityId);
					bulkEmailElement.MarketingEmailId = bulkEmailCopyId;
				}
			}
		}

		private IEnumerable<MarketingEmailElement> GetModifiedBulkEmailElements() {
			var currentElements = GetBulkEmailElements(CampaignSchema);
			if (CampaignSchema.InitialSchema == null) {
				return currentElements;
			}
			var initialElements = GetBulkEmailElements(CampaignSchema.InitialSchema);
			var sameElements = initialElements.Join(currentElements,
					initial => initial.UId,
					current => current.UId,
					(initial, current) => (initial.MarketingEmailId == current.MarketingEmailId, current))
				.Where(x => x.Item1)
				.Select(x => x.Item2);
			return currentElements.Except(sameElements);
		}

		private void UpdateConnectedBulkEmailInfo(IEnumerable<MarketingEmailElement> elements) {
			foreach (var element in elements) {
				var bulkEmailId = element.MarketingEmailId.IsEmpty() ? null as Guid? : element.MarketingEmailId;
				UpdateCampaignItemConnectedRecordInfo(element.UId, _bulkEmailSchemaUId, bulkEmailId);
			}
		}

		private Select GetParticipantEmailTargetRecordsToUpdateSelect() {
			var emailTargetSelect = new Select(UserConnection)
					.Column("cpet", "MandrillRecipientUId").As("UId")
				.From(CampaignParticipantEmailTargetTableName).As("cpet")
				.InnerJoin(CampaignParticipantTableName).As("cp")
					.On("cp", "Id").IsEqual("cpet", "CampaignParticipantId")
				.InnerJoin(CampaignItemTableName).As("ci")
					.On("ci", "Id").IsEqual("cp", "CampaignItemId")
				.Where("cpet", "WasUsed").IsEqual(Column.Parameter(false))
					.And("cp", "CampaignId").IsEqual(Column.Parameter(CampaignSchema.EntityId))
					.And()
						.OpenBlock("ci", "RecordId").IsNull()
							.Or("ci", "RecordId").IsNotEqual("cpet", "BulkEmailId")
							.Or("cp", "StepCompleted").IsEqual(Column.Parameter(false))
						.CloseBlock() as Select;
			emailTargetSelect.SpecifyNoLockHints();
			return emailTargetSelect;
		}

		private Update GetUpdateUsedParticipantEmailTargetRecordsQuery() {
			var update = new Update(UserConnection, CampaignParticipantEmailTargetTableName)
					.Set("WasUsed", Column.Parameter(true));
			update.WithHints(new RowLockHint());
			return update;
		}

		private void UpdateUsedParticipantEmailTargetRecords(Select emailTargetSelect) {
			var update = GetUpdateUsedParticipantEmailTargetRecordsQuery();
			update.Where(Column.SourceColumn("MandrillRecipientUId")).In(emailTargetSelect);
			update.Execute();
		}

		private Update GetUpdateUsedParticipantEmailTargetRecordsQuery(IEnumerable<Guid> emailTargetIds) {
			var update = GetUpdateUsedParticipantEmailTargetRecordsQuery();
			update.Where(Column.SourceColumn("MandrillRecipientUId")).In(Column.Parameters(emailTargetIds));
			return update;
		}

		private void BatchedUpdateUsedParticipantEmailTargetRecords(Select recordsSelect) {
			var mandrillRecipientsCollection = recordsSelect
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("UId")).ToList();
			int recipientsCount = mandrillRecipientsCollection.Count;
			int batchSize = CampaignElementAudienceQueryBatchSize;
			int processedCount = 0;
			while (processedCount < recipientsCount) {
				var recipientsBatch = mandrillRecipientsCollection.Skip(processedCount).Take(batchSize);
				var updateQuery = GetUpdateUsedParticipantEmailTargetRecordsQuery(recipientsBatch);
				updateQuery.Execute();
				processedCount += batchSize;
				Task.Delay(10).Wait();
			}
		}

		private void UpdateUsedParticipantEmailTargetRecords() {
			var recordsSelect = GetParticipantEmailTargetRecordsToUpdateSelect();
			if (UseCampaignBatchedQueries) {
				BatchedUpdateUsedParticipantEmailTargetRecords(recordsSelect);
			} else {
				UpdateUsedParticipantEmailTargetRecords(recordsSelect);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// 1. Applies methods for bulk email elements after campaign schema saved.
		/// 2. Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		public void OnAfterSave() {
			Guid campaignId = CampaignSchema.EntityId;
			try {
				var bulkEmailIds = GetBulkEmailIds(CampaignSchema);
				var statusId = CampaignSchema.StatusId;
				UnbindRemovedBulkEmails(bulkEmailIds, statusId);
				BindBulkEmails(bulkEmailIds, campaignId, statusId);
				var modifiedElements = GetModifiedBulkEmailElements();
				UpdateConnectedBulkEmailInfo(modifiedElements);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnAfterSaveException");
				CampaignLogger.ErrorFormat(message, ex, campaignId);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for bulk email elements before campaign schema deleted.
		/// </summary>
		public void OnDelete() {
			try {
				UnbindBulkEmails(CampaignSchema.EntityId);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnDeleteException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Applies validation rules for bulk email elements on campaign validation.
		/// </summary>
		public void OnValidate() {
			Guid campaignId = CampaignSchema.EntityId;
			try {
				IEnumerable<Guid> bulkEmailIds = GetBulkEmailIds(CampaignSchema);
				if (bulkEmailIds.Any()) {
					PingMailingProvider();
					ValidateMessages(bulkEmailIds);
					ValidateDraftStatus(bulkEmailIds);
				}
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnValidateException");
				CampaignLogger.ErrorFormat(message, ex, campaignId);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for bulk email elements on campaign start.
		/// </summary>
		public void OnStart() {
			Guid campaignId = CampaignSchema.EntityId;
			try {
				IEnumerable<Guid> bulkEmailIds = GetBulkEmailIds(CampaignSchema);
				UpdateBulkEmailsStatus(bulkEmailIds, MailingConsts.BulkEmailStatusActiveId);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStartException");
				CampaignLogger.ErrorFormat(message, ex, campaignId);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for bulk email elements on campaign stop.
		/// </summary>
		public void OnStop() {
			try {
				IEnumerable<Guid> bulkEmailIds = GetBulkEmailIds(CampaignSchema);
				UpdateBulkEmailsStatus(bulkEmailIds, MailingConsts.BulkEmailStatusStoppedId);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStopException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// 1. Applies methods for bulk email elements on campaign copy.
		/// 2. Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(2)]
		public void OnCopy() {
			try {
				BindNewBulkEmails(CampaignSchema);
				var allElements = GetBulkEmailElements(CampaignSchema);
				UpdateConnectedBulkEmailInfo(allElements);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnCopyException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Updates related bulk email recipients records for used trigger emails.
		/// </summary>
		[Order(1)]
		public void OnExecutionTerminate() {
			try {
				var currentElements = GetBulkEmailElements(CampaignSchema)
					.Where(e => !e.MarketingEmailId.IsEmpty());
				if (!currentElements.Any()) {
					return;
				}
				UpdateUsedParticipantEmailTargetRecords();
			}
			catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnExecutionTerminateException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

}

