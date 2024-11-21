namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;
	using global::Common.Logging;

	#region Class: CampaignBaseFragmentSyncManager

	/// <summary>
	/// Describes base synchronizer for operational table - <see cref="CampaignParticipantOp" />.
	/// </summary>
	public abstract class CampaignBaseFragmentSyncManager : ICampaignFragmentSyncManager
	{

		#region Constants: Protected

		protected const string CampaignParticipantOpTableName = nameof(CampaignParticipantOp);
		protected const string CampaignParticipantTableName = nameof(CampaignParticipant);
		protected const string CampaignParticipantInfoTableName = nameof(CampaignParticipantInfo);
		protected const string CampaignParticipantOpInfoTableName = nameof(CampaignParticipantOpInfo);
		protected const string CampaignParticipantEmailTargetOpTableName = nameof(CmpgnPrtcpntEmailTargetOp);
		protected const string CampaignParticipantEmailTargetTableName = nameof(CmpgnPrtcpntEmailTarget);
		protected const string CampaignItemTableName = nameof(CampaignItem);
		protected const string BulkEmailTableName = nameof(BulkEmail);
		protected const string MandrillRecipientTableName = "BulkEmailTarget";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="CampaignBaseFragmentSyncManager"/> class.
		/// </summary>
		/// <param name="campaignId">Unique identifier of campaign.</param>
		/// <param name="campaignItemId">Unique identifier of campaign item for which to sync participants.</param>
		public CampaignBaseFragmentSyncManager(Guid campaignId, Guid campaignItemId) {
			CampaignId = campaignId;
			CampaignItemId = campaignItemId;
		}

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Select query for campaign participants manager has to synchronize.
		/// </summary>
		protected Select ParticipantsToSyncSelect { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of campaign entity.
		/// </summary>
		public Guid CampaignId { get; private set; }

		/// <summary>
		/// Unique identifier of initial campaign item for which to sync campaign participants.
		/// </summary>
		public Guid CampaignItemId { get; private set; }

		#endregion

		#region Methods: Private

		private void SetErrorStatusForIncompletedParticipants(UserConnection userConnection) {
			var update = new Update(userConnection, CampaignParticipantOpTableName)
				.Set("StatusId", Column.Parameter(CoreCampaignConsts.CampaignParticipantErrorStatusId))
				.Set("IsReadyToSync", Column.Parameter(true))
				.Where("InitialCampaignItemId").IsEqual(Column.Parameter(CampaignItemId))
					.And("IsReadyToSync").IsEqual(Column.Parameter(false)) as Update;
			update.WithHints(Hints.RowLock);
			update.Execute();
		}

		private void BatchedExecute(UserConnection userConnection, ref int synchronizedCount) {
			var participants = ParticipantsToSyncSelect
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id")).ToList();
			int participantsCount = participants.Count;
			int batchSize = GetCampaignElementAudienceQueryBatchSize(userConnection);
			int processedCount = 0;
			while (processedCount < participantsCount) {
				var audienceBatch = participants.Skip(processedCount).Take(batchSize);
				ParticipantsToSyncSelect.Condition.Clear();
				ParticipantsToSyncSelect.OrderByItems.Clear();
				ParticipantsToSyncSelect.Where(CampaignParticipantOpTableName, "Id")
					.In(Column.Parameters(audienceBatch));
				synchronizedCount += InternalSynchronize(userConnection);
				processedCount += batchSize;
				Task.Delay(10).Wait();
			}
		}

		private void MoveRelations(Select relationsSelect, bool wasUsed) {
			var relations = relationsSelect.ExecuteEnumerable(x => {
				var recipient = x.GetColumnValue<Guid>("MandrillRecipientUId");
				var participant = x.GetColumnValue<Guid>("CampaignParticipantId");
				var bulkEmail = x.GetColumnValue<Guid>("BulkEmailId");
				return (recipient, participant, bulkEmail);
			}).ToArray();
			if (relations.IsEmpty()) {
				return;
			}
			var userConnection = relationsSelect.UserConnection;
			int batchSize = GetCampaignElementAudienceQueryBatchSize(userConnection);
			int relationsCount = relations.Count();
			int processedCount = 0;
			while (processedCount < relationsCount) {
				var relationsBatch = relations.Skip(processedCount).Take(batchSize);
				var insertQuery = GetParticipantToRecipientRelationsInsert(userConnection, relationsBatch, wasUsed);
				insertQuery.Execute();
				processedCount += batchSize;
				Task.Delay(10).Wait();
			}
		}

		private Select GetParticipantsToSyncSelect(Select participantsToSyncSelect) {
			var userConnection = participantsToSyncSelect.UserConnection;
			var campaignParticipantOpToSyncSelect = new Select(participantsToSyncSelect);
			campaignParticipantOpToSyncSelect.Columns.Clear();
			campaignParticipantOpToSyncSelect
				.Column("Id")
				.Column(new WindowQueryFunction(
					new RowNumberQueryFunction(),
					new QueryColumnExpression(CampaignParticipantOpTableName, "ContactId"),
					new QueryColumnExpression(CampaignParticipantOpTableName, "CreatedOn"))).As("RowNum");
			campaignParticipantOpToSyncSelect.SpecifyNoLockHints();
			return new Select(userConnection)
				.Column("sub", "Id")
				.From(campaignParticipantOpToSyncSelect).As("sub")
				.Where("sub", "RowNum").IsEqual(Column.Parameter(1)) as Select;
		}

		private IEnumerable<Guid> GetParticipantOpIdsToSync(Select participantsToSyncSelect) {
			var participantOpIdsToSyncSelect = GetParticipantsToSyncSelect(participantsToSyncSelect);
			return participantOpIdsToSyncSelect.ExecuteEnumerable(x => {
				return x.GetColumnValue<Guid>("Id");
			});
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns select of operational relations that have to be moved into the
		/// <see cref="CmpgnPrtcpntEmailTarget"/> table.
		/// </summary>
		/// <returns>Select query.</returns>
		protected abstract Select GetOperationalRecipientRelationsToMoveSelect();

		/// <summary>
		/// Returns select of operational relations that have to be moved into the
		/// <see cref="CmpgnPrtcpntEmailTarget"/> table with WasUsed flag.
		/// </summary>
		/// <returns>Select query.</returns>
		protected abstract Select GetUsedOperationalRecipientRelationsToMoveSelect();

		/// <summary>
		/// Incapsulates main logic for campaign participants synchronization.
		/// Implementation have to base on specific sync strategy by concrete sync manager.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Count of synchronized campaign participants.</returns>
		protected abstract int InternalSynchronize(UserConnection userConnection);

		/// <summary>
		/// Returns select query for capmaign participants that wait for synchronization.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Select query for capmaign participants that wait for synchronization.</returns>
		protected virtual Select GetParticipantsToSyncQuery(UserConnection userConnection) {
			var select = new Select(userConnection)
					.Column("Id")
				.From(CampaignParticipantOpTableName)
				.Where(CampaignParticipantOpTableName, "IsReadyToSync").IsEqual(Column.Parameter(true))
					.And(CampaignParticipantOpTableName, "InitialCampaignItemId")
						.IsEqual(Column.Parameter(CampaignItemId))
				.OrderByDesc("CreatedOn") as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		/// <summary>
		/// Returns select query for capmaign participants that can be moved from operational table.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Select query for capmaign participants that can be moved from operational table.</returns>
		protected virtual Select GetParticipantsToMoveSelect(UserConnection userConnection) {
			var participantOpIds = GetParticipantOpIdsToSync(ParticipantsToSyncSelect);
			return GetBaseParticipantsToMoveSelect(userConnection)
				.LeftOuterJoin(CampaignParticipantTableName).As("cp")
					.On("cp", "ContactId").IsEqual("cpo", "ContactId")
						.And("cp", "CampaignId").IsEqual(Column.Parameter(CampaignId, "Guid"))
				.Where("cp", "Id").IsNull()
					.And("cpo", "Id").In(Column.Parameters(participantOpIds)) as Select;
		}

		/// <summary>
		/// Returns insert query for capmaign participants synchronization.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Insert query for capmaign participants synchronization.</returns>
		protected virtual InsertSelect GetMoveParticipantsQuery(UserConnection userConnection) {
			var contactsToMoveSelect = GetParticipantsToMoveSelect(userConnection);
			var query = new InsertSelect(userConnection)
				.Into(CampaignParticipantTableName)
					.Set("CreatedOn", "CreatedById", "CampaignId", "ContactId", "StatusId", "CampaignItemId",
						"StepModifiedOn", "StepCompletedOn", "StepCompleted")
				.FromSelect(contactsToMoveSelect);
			return query;
		}

		/// <summary>
		/// Returns update query for suspending capmaign participants' synchronization.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Update query for suspending capmaign participants synchronization.</returns>
		protected virtual UpdateSelect GetUpdateSuspendingParticipantsQuery(UserConnection userConnection) {
			var update = new UpdateSelect(userConnection, CampaignParticipantTableName, "cp")
					.Set("CampaignItemId", Column.SourceColumn(CampaignParticipantOpTableName, "CampaignItemId"))
					.Set("StatusId", Column.Parameter(CoreCampaignConsts.CampaignParticipantSuspendedStatusId))
					.Set("StepCompleted", Column.SourceColumn(CampaignParticipantOpTableName, "StepCompleted"))
					.Set("StepModifiedOn", Column.SourceColumn(CampaignParticipantOpTableName, "StepModifiedOn"))
					.Set("StepCompletedOn", Column.SourceColumn(CampaignParticipantOpTableName, "StepCompletedOn"))
				.From(CampaignParticipantOpTableName, null)
				.Where(ParticipantsToSyncSelect.Condition)
					.And("cp", "Id").IsEqual(CampaignParticipantOpTableName, "CampaignParticipantId")
					.And("cp", "CampaignItemId").IsEqual(CampaignParticipantOpTableName, "InitialCampaignItemId")
					.And("cp", "StatusId").IsEqual(
						Column.Parameter(CoreCampaignConsts.CampaignParticipantSuspendingStatusId)) as UpdateSelect;
			update.WithHints(new RowLockHint());
			update.SpecifyNoLockHints();
			return update;
		}

		/// <summary>
		/// Returns update query for capmaign participants synchronization.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Update query for capmaign participants synchronization.</returns>
		protected virtual UpdateSelect GetUpdateInProgressParticipantsQuery(UserConnection userConnection) {
			var update = new UpdateSelect(userConnection, CampaignParticipantTableName, "cp")
					.Set("CampaignItemId", Column.SourceColumn(CampaignParticipantOpTableName, "CampaignItemId"))
					.Set("StatusId", Column.SourceColumn(CampaignParticipantOpTableName, "StatusId"))
					.Set("StepCompleted", Column.SourceColumn(CampaignParticipantOpTableName, "StepCompleted"))
					.Set("StepModifiedOn", Column.SourceColumn(CampaignParticipantOpTableName, "StepModifiedOn"))
					.Set("StepCompletedOn", Column.SourceColumn(CampaignParticipantOpTableName, "StepCompletedOn"))
				.From(CampaignParticipantOpTableName, null)
				.Where(ParticipantsToSyncSelect.Condition)
					.And("cp", "Id").IsEqual(CampaignParticipantOpTableName, "CampaignParticipantId")
					.And("cp", "CampaignItemId").IsEqual(CampaignParticipantOpTableName, "InitialCampaignItemId")
					.And("cp", "StatusId").IsEqual(
						Column.Parameter(CoreCampaignConsts.CampaignParticipantInProgressStatusId)) as UpdateSelect;
			update.WithHints(new RowLockHint());
			update.SpecifyNoLockHints();
			return update;
		}

		/// <summary>
		/// Returns delete query for recipients that are synchronized.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Delete query for synchronized campaign participant.</returns>
		protected virtual Delete GetDeleteSynchronizedRelationsQuery(UserConnection userConnection) =>
			new Delete(userConnection)
				.From(CampaignParticipantEmailTargetOpTableName)
				.Where("CampaignParticipantId").In(ParticipantsToSyncSelect) as Delete;

		/// <summary>
		/// Returns delete query for synchronized capmaign participants.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Delete query for synchronized campaign participant.</returns>
		protected virtual Delete GetDeleteSynchronizedQuery(UserConnection userConnection) {
			var delete = new Delete(userConnection)
				.From(CampaignParticipantOpTableName);
			delete.AddCondition(ParticipantsToSyncSelect.Condition, LogicalOperation.And);
			return delete;
		}

		/// <summary>
		/// Actualizes campaign participants' state for which fragment is incompleted before force synchronization.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <param name="campaignItemIds">List of initial item ids for which to sync participants.</param>
		protected virtual void Actualize(UserConnection userConnection) {
			try {
				SetErrorStatusForIncompletedParticipants(userConnection);
			} catch (Exception ex) {
				Logger.Error($"Campaign item with Id {CampaignItemId} failed to actualize participants.", ex);
			}
		}

		/// <summary>
		/// Returns query to actualize relations for campaign participants.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Query to execute or <see cref="null"/>.</returns>
		protected virtual Insert GetParticipantToRecipientRelationsInsert(UserConnection userConnection,
				IEnumerable<(Guid, Guid, Guid)> relations, bool wasUsed) {
			var query = new Insert(userConnection).Into(CampaignParticipantEmailTargetTableName);
			foreach (var relation in relations) {
				query.Values()
					.Set("MandrillRecipientUId", Column.Parameter(relation.Item1))
					.Set("CampaignParticipantId", Column.Parameter(relation.Item2))
					.Set("WasUsed", Column.Parameter(wasUsed))
					.Set("BulkEmailId", Column.Parameter(relation.Item3));
			}
			return query;
		}

		/// <summary>
		/// Moves campaign participant to email recipient relations from operation table
		/// which is used for sessioned campaign execution.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		protected virtual void SyncParticipantRelations(UserConnection userConnection) {
			var actualRelationsSelect = GetOperationalRecipientRelationsToMoveSelect();
			MoveRelations(actualRelationsSelect, wasUsed: false);
			var usedRelationsSelect = GetUsedOperationalRecipientRelationsToMoveSelect();
			MoveRelations(usedRelationsSelect, wasUsed: true);
		}

		protected int GetCampaignElementAudienceQueryBatchSize(UserConnection userConnection) {
			var value = Core.Configuration.SysSettings.GetValue(userConnection,
				"CampaignElementAudienceQueryBatchSize", 500);
			return Math.Max(value, 0);
		}

		/// <summary>
		/// Returns base query to select campaign participants which will be synchronized.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="Select"/> query.</returns>
		protected virtual Select GetBaseParticipantsToMoveSelect(UserConnection userConnection) {
			var select = new Select(userConnection)
					.Column("cpo", "CreatedOn")
					.Column("cpo", "CreatedById")
					.Column("cpo", "CampaignId")
					.Column("cpo", "ContactId")
					.Column("cpo", "StatusId")
					.Column("cpo", "CampaignItemId")
					.Column("cpo", "StepModifiedOn")
					.Column("cpo", "StepCompletedOn")
					.Column("cpo", "StepCompleted")
				.From(CampaignParticipantOpTableName, "cpo");
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Moves participants with ReadyToSync flag and expected initial campaign item id
		/// into the CampaignParticipant table.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <param name="synchronizedCount">Count of synchronized participants.</param>
		/// <returns>A number of added participants.</returns>
		public void Synchronize(UserConnection userConnection, ref int synchronizedCount) {
			userConnection.CheckArgumentNull("userConnection");
			ParticipantsToSyncSelect = GetParticipantsToSyncQuery(userConnection);
			try {
				BatchedExecute(userConnection, ref synchronizedCount);
			} catch (Exception ex) {
				Logger.Error($"Campaign item with Id {CampaignItemId} failed to synchronize participants.", ex);
				throw;
			}
		}

		/// <summary>
		/// Moves participants with expected initial campaign item id into the CampaignParticipant table.
		/// For participants without ReadyToSync = true changes status to "Error".
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		/// <param name="synchronizedCount">Count of synchronized participants.</param>
		/// <returns>A number of added participants.</returns>
		public void ForceSynchronize(UserConnection userConnection, ref int synchronizedCount) {
			userConnection.CheckArgumentNull("userConnection");
			Actualize(userConnection);
			Synchronize(userConnection, ref synchronizedCount);
		}

		#endregion

	}

	#endregion

}

