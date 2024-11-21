namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: CampaignEventHandler

	/// <summary>
	/// Contains methods for maintaining campaign and assigned schema during campaign events.
	/// </summary>
	public sealed class CampaignEventHandler : CampaignEventHandlerBase, IOnCampaignBeforeSave, IOnCampaignAfterSave,
		IOnCampaignValidate, IOnCampaignStart, IOnCampaignFinalize, IOnCampaignStop, IOnCampaignCopy {

		#region Class: LocalizableDataModel

		private class LocalizableDataModel
		{

			#region Properties: Public

			public Guid SysCultureId {
				get; set;
			}

			public string Key {
				get; set;
			}

			public string Value {
				get; set;
			}

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string ElementHandlerName = "CampaignEventHandler";
		private const string SchemaName = "Campaign";
		private const string CampaignParticipantTableName = "CampaignParticipant";

		#endregion

		#region Constructors: Public

		public CampaignEventHandler() : base() {
			InitSaveVersionDelegate(null);
		}

		public CampaignEventHandler(Action<string, string> saveCampaignVersionDelegate) {
			InitSaveVersionDelegate(saveCampaignVersionDelegate);
		}

		#endregion

		#region Properties

		private bool IsCampaignStatusRun => CampaignSchema.StatusId == CampaignConsts.RunCampaignStatusId;

		/// <summary>
		/// Contains camapign schema version saving mechanism. String argument contains serialized data.
		/// </summary>
		private Action<string, string> SaveCampaignVersion { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets campaign logger. Instance of <see cref="ICampaignExecutionLogger"/>.
		/// </summary>
		private ICampaignExecutionLogger _campaignExecutionLogger;
		public ICampaignExecutionLogger CampaignExecutionLogger {
			get => _campaignExecutionLogger
				?? (_campaignExecutionLogger = ClassFactory.Get<ICampaignExecutionLogger>(
					new ConstructorArgument("userConnection", UserConnection)));
			set => _campaignExecutionLogger = value;
		}

		/// <summary>
		/// Gets or sets the campaign scheduler. Instance of <see cref="ICampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignTimeScheduler _campaignTimeScheduler;
		public ICampaignTimeScheduler CampaignTimeScheduler {
			get => _campaignTimeScheduler ?? (_campaignTimeScheduler = new CampaignTimeScheduler(UserConnection));
			set => _campaignTimeScheduler = value;
		}

		/// <summary>
		/// Gets or sets the campaign scheduler. Instance of <see cref="ICampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignJobDispatcher _campaignJobDispatcher;
		public ICampaignJobDispatcher CampaignJobDispatcher {
			get => _campaignJobDispatcher ?? (_campaignJobDispatcher = new CampaignJobDispatcher(UserConnection));
			set => _campaignJobDispatcher = value;
		}

		/// <summary>
		/// Represents campaign participants synchronizer to sync participants after campaign fragments' execution.
		/// </summary>
		private ICampaignFragmentSynchronizer _campaignFragmentSynchronizer;
		public ICampaignFragmentSynchronizer CampaignFragmentSynchronizer {
			get => _campaignFragmentSynchronizer
				?? (_campaignFragmentSynchronizer = new CampaignFragmentSynchronizer());
			set => _campaignFragmentSynchronizer = value;
		}

		/// <summary>
		/// Defines current time. Returns value if it was set before, and UtcNow if not.
		/// </summary>
		private DateTime _currentTime;
		public DateTime CurrentTime {
			get => _currentTime == default(DateTime)
					? DateTime.UtcNow
					: _currentTime;
			set => _currentTime = value;
		}

		private ICampaignQueueManager _campaignQueueManager;

		/// <summary>
		/// Instance of <see cref="CampaignQueueManager" />.
		/// </summary>
		public ICampaignQueueManager CampaignQueueManager {
			get => _campaignQueueManager ?? (_campaignQueueManager = new CampaignQueueManager(UserConnection));
			set => _campaignQueueManager = value;
		}

		#endregion

		#region Methods: Private

		private void FillCampaignStatusInSchema() {
			var selectQuery = new Select(UserConnection)
					.Column("CampaignStatusId")
					.Column("InProgress")
				.From("Campaign")
				.Where("Campaign", "Id").IsEqual(Column.Parameter(CampaignSchema.EntityId)) as Select;
			selectQuery.SpecifyNoLockHints();
			selectQuery.ExecuteReader(dr => {
				CampaignSchema.StatusId = dr.GetColumnValue<Guid>("CampaignStatusId");
				CampaignSchema.IsInProgress = dr.GetColumnValue<bool>("InProgress");
			});
		}

		private DateTime? GetScheduledStopDate(Guid campaignId) {
			DateTime? result = null;
			var stopDateSelect = new Select(UserConnection)
					.Column("ScheduledStopDate")
					.Column("ScheduledStopModeId")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			stopDateSelect.SpecifyNoLockHints();
			stopDateSelect.ExecuteReader(dr => {
				var scheduledStopModeId = dr.GetColumnValue<Guid>("ScheduledStopModeId");
				if (scheduledStopModeId == CampaignConsts.CampaingSpecifiedTimeModeId) {
					result = dr.GetColumnValue<DateTime>("ScheduledStopDate");
				}
			});
			return result;
		}

		private void SyncCampaignSchemaWithEntity() {
			EntitySchema entitySchema =
				UserConnection.EntitySchemaManager.GetInstanceByUId(CampaignSchema.EntitySchemaUId);
			var update = new Update(UserConnection, entitySchema.Name)
					.Set(entitySchema.GetPrimaryDisplayColumnName(), Column.Parameter(CampaignSchema.Caption.Value))
					.Set("CampaignSchemaUId", Column.Parameter(CampaignSchema.UId))
				.Where("Id").IsEqual(Column.Parameter(CampaignSchema.EntityId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private Update CreateCampaignUpdate() {
			var update = new Update(UserConnection, "Campaign")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Where("Id").IsEqual(Column.Parameter(CampaignSchema.EntityId)) as Update;
			update.WithHints(new RowLockHint());
			return update;
		}

		private void ChangeNextRunDate(DateTime nextRunDate) {
			var update = CreateCampaignUpdate();
			update.Set("NextFireTime", Column.Parameter(nextRunDate));
			update.Execute();
		}

		private void ChangeStatusToScheduledStart(DateTime scheduledDate) {
			var update = CreateChangeStatusUpdate(CampaignConsts.ScheduledCampaignStatusId);
			update
				.Set("NextFireTime", Column.Parameter(scheduledDate))
				.Set("EndDate", Column.Parameter(null, "DateTime"));
			update.Execute();
		}

		private void ChangeStatusOnStart() {
			var update = CreateChangeStatusUpdate(CampaignConsts.RunCampaignStatusId);
			update
				.Set("InProgress", Column.Parameter(true))
				.Set("StartDate", Column.Parameter(DateTime.UtcNow))
				.Set("EndDate", Column.Parameter(null, "DateTime"));
			update.Execute();
		}

		private void ChangeStatusToStop() {
			var update = CreateChangeStatusUpdate(CampaignConsts.CompletedCampaignStatusId);
			update
				.Set("InProgress", Column.Parameter(false))
				.Set("EndDate", Column.Parameter(DateTime.UtcNow))
				.Set("NextFireTime", Column.Parameter(null, "DateTime"));
			update.Execute();
		}

		private Update CreateChangeStatusUpdate(Guid campaignStatusId) {
			var update = CreateCampaignUpdate();
			update.Set("CampaignStatusId", Column.Parameter(campaignStatusId));
			return update;
		}

		private void ChangeStatusToStopping() {
			var update = CreateChangeStatusUpdate(CampaignConsts.StoppingCampaignStatusId);
			update.Execute();
		}

		private void InsertCampaignItems(IEnumerable<CampaignSchemaElement> campaignItems, Guid campaignId) {
			foreach (var item in campaignItems) {
				new Insert(UserConnection).Into("CampaignItem")
					.Set("Id", Column.Parameter(item.UId))
					.Set("Name", Column.Parameter(item.Caption.Value, "Text"))
					.Set("CampaignId", Column.Parameter(campaignId))
					.Set("CampaignElementType", Column.Parameter(item.ElementType.ToString()))
					.Execute();
			}
		}

		private void UpdateCampaignItems(IEnumerable<CampaignSchemaElement> existingItems) {
			foreach (var item in existingItems) {
				new Update(UserConnection, "CampaignItem").WithHints(new RowLockHint())
					.Set("Name", Column.Parameter(item.Caption.Value, "Text"))
					.Where("Id").IsEqual(Column.Parameter(item.UId))
					.Execute();
			}
		}

		private void MarkAsDeletedCampaignItems(IEnumerable<Guid> existingItems) {
			if (existingItems.Any()) {
				var update = new Update(UserConnection, "CampaignItem")
					.Set("IsDeleted", Column.Parameter(true))
					.Where("Id").In(Column.Parameters(existingItems)) as Update;
				update.WithHints(new RowLockHint());
				update.Execute();
			}
		}

		private void AddOrUpdateCampaignItems() {
			List<Guid> schemaElementsIds = CampaignSchema.FlowElements.Select(x => x.UId).ToList();
			var listCommon = new List<Guid>();
			if (CampaignSchema.InitialSchema != null) {
				List<Guid> existingCampaignItemIds = CampaignSchema.InitialSchema.FlowElements
					.Select(x => x.UId).ToList();
				listCommon = existingCampaignItemIds.Join(schemaElementsIds, x => x, y => y, (x, y) => x).ToList();
				IEnumerable<Guid> listDelete = existingCampaignItemIds.Except(listCommon);
				var listUpdate = new List<Guid>();
				foreach (var se in CampaignSchema.FlowElements.Where(x => listCommon.Contains(x.UId))) {
					listUpdate.AddRange(CampaignSchema.InitialSchema.FlowElements
						.Where(x => x.UId == se.UId && x.Caption.Value != se.Caption.Value)
						.Select(x => x.UId));
				}
				IEnumerable<CampaignSchemaElement> itemsToUpdate = CampaignSchema.FlowElements
					.Where(x => listUpdate.Contains(x.UId));
				MarkAsDeletedCampaignItems(listDelete);
				UpdateCampaignItems(itemsToUpdate);
			}
			IEnumerable<Guid> listInsert = schemaElementsIds.Except(listCommon);
			IEnumerable<CampaignSchemaElement> itemsToInsert =
				CampaignSchema.FlowElements.Where(x => listInsert.Contains(x.UId));
			InsertCampaignItems(itemsToInsert, CampaignSchema.EntityId);
		}

		private void UpdateNewSchemaUIdForItems() {
			foreach (var item in CampaignSchema.FlowElements) {
				item.CreatedInSchemaUId = CampaignSchema.UId;
				item.ModifiedInSchemaUId = CampaignSchema.UId;
			}
		}

		private void SaveCopiedCampaignItems() {
			UpdateNewSchemaUIdForItems();
			InsertCampaignItems(CampaignSchema.FlowElements, CampaignSchema.EntityId);
		}

		private void UpdateCampaignSchemaUId() {
			new Update(UserConnection, "Campaign")
				.Set("CampaignSchemaUId", Column.Parameter(CampaignSchema.UId))
				.Where("Id").IsEqual(Column.Parameter(CampaignSchema.EntityId))
				.Execute();
		}

		private void SynchronizeCampaignParticipantsOp() {
			CampaignSynchronizationInfo result =
					CampaignFragmentSynchronizer.ForceSynchronize(UserConnection, CampaignSchema);
			if (result.Success && result.SynchronizedParticipantsCount > 0) {
				LogAction(CampaignConstants.CampaignLogTypeCampaignSynchronization, null, result.SynchronizedParticipantsCount);
				return;
			}
			if (!result.Success) {
				var stringBuilder = new StringBuilder();
				foreach (var error in result.Errors) {
					stringBuilder.Append(error);
					stringBuilder.Append(Environment.NewLine);
				}
				LogError(CampaignConstants.CampaignLogTypeCampaignSynchronization, stringBuilder.ToString());
			}
		}

		private void UpdateParticipantsInProgressStatus() {
			var update = new Update(UserConnection, CampaignParticipantTableName)
				.Set("StatusId", Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
				.Where("CampaignId").IsEqual(Column.Parameter(CampaignSchema.EntityId))
					.And("StatusId")
						.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private List<Guid> GetCampaignItemsWithParticipantsInProgressStatus() {
			var resultCampaignItems = new List<Guid>();
			var select = new Select(UserConnection)
					.Column("CampaignItemId")
				.From(CampaignParticipantTableName)
				.Where("CampaignId").IsEqual(Column.Parameter(CampaignSchema.EntityId))
					.And("StatusId")
						.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantInProgressStatusId))
				.GroupBy("CampaignItemId") as Select;
			select.SpecifyNoLockHints();
			select.ExecuteReader(reader => {
				resultCampaignItems.Add(reader.GetColumnValue<Guid>("CampaignItemId"));
			});
			return resultCampaignItems;
		}

		private void RemoveParticipantsFromQueue() {
			var campaignItems = GetCampaignItemsWithParticipantsInProgressStatus();
			CampaignQueueManager.ClearByCampaignItems(campaignItems);
		}

		private void SyncronizeParticipants() {
			SynchronizeCampaignParticipantsOp();
			RemoveParticipantsFromQueue();
			UpdateParticipantsInProgressStatus();
		}

		private void LogAction(Guid actionId, DateTime? scheduledDate = null, int? amount = 0) {
			try {
				var logInfo = new CampaignLogInfo {
					CampaignId = CampaignSchema.EntityId,
					Action = actionId,
					Amount = amount,
					IsSuccess = true
				};
				if (scheduledDate != null) {
					logInfo.ScheduledDate = scheduledDate;
				} else {
					logInfo.StartDate = DateTime.UtcNow;
				}
				CampaignExecutionLogger.LogAction(logInfo);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat("Exception has occured when logging actions for campaign {0}",
						ex, CampaignSchema.EntityId);
			}
		}

		private void LogError(Guid actionId, string errorText) {
			try {
				var logInfo = new CampaignLogInfo {
					CampaignId = CampaignSchema.EntityId,
					Action = actionId,
					IsSuccess = false,
					ErrorText = errorText
				};
				CampaignExecutionLogger.LogAction(logInfo);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat("Exception has occured when logging actions for campaign {0}",
					ex, CampaignSchema.EntityId);
			}
		}

		private void ValidateCampaignTimeZone() {
			if (CampaignSchema.TimeZoneOffset == null) {
				string message = GetLczStringValue(ElementHandlerName, "IncorrectCampaignTimeZoneOffset");
				CampaignSchema.AddValidationInfo(message);
			}
		}

		private void ValidateDefaultCampaignFirePeriod() {
			if (CampaignSchema.DefaultCampaignFirePeriod == 0) {
				string message = GetLczStringValue(ElementHandlerName, "IncorrectDefaultCampaignFirePeriod");
				CampaignSchema.AddValidationInfo(message);
			}
		}

		private void SendUpdateSchemaMessage() {
			string msg = string.Format("{{\"campaignId\":\"{0}\", \"operation\":\"UpdateSchema\"}}",
				CampaignSchema.EntityId);
			MsgChannelUtilities.PostMessage(UserConnection, SchemaName, msg);
		}

		private void SendUpdateVersionMessage(Guid campaignVersionId) {
			string msg = $"{{\"campaignId\":\"{CampaignSchema.EntityId}\", \"operation\":\"UpdateVersion\", " +
				$"\"versionId\":\"{campaignVersionId}\"}}";
			MsgChannelUtilities.PostMessage(UserConnection, SchemaName, msg);
		}

		private string SerializeCampaignSchema() {
			var sb = new StringBuilder();
			var stringWriter = new StringWriter(sb);
			var settings = new JsonDataWriterSettings() {
				WriteDefValues = true
			};
			using (var writer = new Core.Process.ProcessJsonDataWriter(settings, stringWriter)) {
				CampaignSchema.WriteMetaData(writer);
			}
			return sb.ToString();
		}

		private string SerializeLocalizableValues() {
			var select = new Select(UserConnection)
				.Column("SysCultureId")
				.Column("Key")
				.Column("Value")
				.From("SysLocalizableValue")
				.Where("SysSchemaId").IsEqual(Column.Parameter(CampaignSchema.Id)) as Select;
			select.SpecifyNoLockHints();
			var localizableData = select.ExecuteEnumerable (r => {
				return new LocalizableDataModel {
					SysCultureId = r.GetColumnValue<Guid>("SysCultureId"),
					Key = r.GetColumnValue<string>("Key"),
					Value = r.GetColumnValue<string>("Value")
				};
			}).ToArray();
			return Json.Serialize(localizableData, true);
		}

		private void SaveCampaignSchemaVersion() {
			var schema = SerializeCampaignSchema();
			var resources = SerializeLocalizableValues();
			SaveCampaignVersion?.Invoke(schema, resources);
		}

		private void InitSaveVersionDelegate(Action<string, string> action) {
			if (action == null) {
				SaveCampaignVersion = (data, resources) => {
					var timestamp = DateTime.UtcNow.ToString("yyyy.MM.dd HH.mm.ss");
					var version = new CampaignVersion(UserConnection) {
						Data = data,
						DataFormat = 1,
						LocalizableData = resources,
						CampaignId = CampaignSchema.EntityId,
						DisplayName = $"{timestamp} - {CampaignSchema.Caption}"
					};
					version.SetDefColumnValues();
					version.Save();
					var versionId = version.PrimaryColumnValue;
					SendUpdateVersionMessage(versionId);
				};
			} else {
				SaveCampaignVersion = action;
			}
		}

	#endregion

	#region Methods: Public

	/// <summary>
	/// Applies methods for campaign before campaign schema saved.
	/// </summary>
	[Order(-100)]
		public void OnBeforeSave() {
			try {
				FillCampaignStatusInSchema();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnBeforeSaveException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign after campaign schema saved.
		/// </summary>
		[Order(-100)]
		public void OnAfterSave() {
			try {
				SyncCampaignSchemaWithEntity();
				AddOrUpdateCampaignItems();
				if (IsCampaignStatusRun && !CampaignSchema.IsInProgress) {
					var jobConfig = CampaignTimeScheduler.GetNextFireTime(CampaignSchema, CurrentTime);
					ChangeNextRunDate(jobConfig.Time);
					CampaignJobDispatcher.RescheduleJob(CampaignSchema, jobConfig);
				}
				SaveCampaignSchemaVersion();
				SendUpdateSchemaMessage();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnAfterSaveException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Applies rules for campaign validation.
		/// </summary>
		public void OnValidate() {
			try {
				CampaignSchema.ValidateElements();
				ValidateDefaultCampaignFirePeriod();
				ValidateCampaignTimeZone();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnValidateException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign on start.
		/// </summary>
		[Order(1)]
		public void OnStart() {
			try {
				var jobConfig = CampaignTimeScheduler.GetNextFireTime(CampaignSchema, null);
				if (jobConfig.ScheduledAction == CampaignScheduledAction.ScheduledStart) {
					ChangeStatusToScheduledStart(jobConfig.Time);
				} else {
					ChangeStatusOnStart();
					LogAction(CampaignConsts.CampaignLogTypeCampaignStart);
				}
				CampaignJobDispatcher.ScheduleJob(CampaignSchema, jobConfig);
				DateTime? stopDate = GetScheduledStopDate(CampaignSchema.EntityId);
				if (stopDate != null) {
					LogAction(CampaignConsts.CampaignLogTypeScheduledStop, (DateTime)stopDate);
				}
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStartException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				LogError(CampaignConsts.CampaignLogTypeCampaignStart, message);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign on finalize.
		/// </summary>
		[Order(int.MinValue)]
		public void OnFinalize() {
			try {
				ChangeStatusToStopping();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStopException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				LogError(CampaignConsts.CampaignLogTypeCampaignStop, message);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign on stop.
		/// </summary>
		[Order(int.MinValue)]
		public void OnStop() {
			try {
				SyncronizeParticipants();
				CampaignJobDispatcher.RemoveJobs(CampaignSchema.EntityId);
				ChangeStatusToStop();
				LogAction(CampaignConsts.CampaignLogTypeCampaignStop);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStopException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				LogError(CampaignConsts.CampaignLogTypeCampaignStop, message);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign on copy.
		/// </summary>
		[Order(1)]
		public void OnCopy() {
			try {
				SaveCopiedCampaignItems();
				UpdateCampaignSchemaUId();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnCopyException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

}

