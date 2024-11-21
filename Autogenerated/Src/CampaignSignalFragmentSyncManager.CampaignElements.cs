namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;

	#region Class: CampaignSignalFragmentSyncManager

	/// <summary>
	/// Describes synchronizer that is worked with campaign participants
	/// for which InitialCampaignItemId is campaign signal element Id.
	/// </summary>
	public sealed class CampaignSignalFragmentSyncManager : CampaignBaseFragmentSyncManager
	{

		#region Constructors: Public

		public CampaignSignalFragmentSyncManager(Guid campaignId, Guid campaignItemId)
			: base(campaignId, campaignItemId) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag to indicate state of recurring participation rule by signal.
		/// </summary>
		public bool IsRecurring { get; set; }

		#endregion

		#region Methods: Private

		private int MoveParticipants(UserConnection userConnection) {
			var query = GetMoveParticipantsQuery(userConnection);
			return query.Execute();
		}

		private void DeleteSynchronizedContacts(UserConnection userConnection) {
			var delete = GetDeleteSynchronizedQuery(userConnection);
			delete.Execute();
		}

		private void DeleteSynchronizedRelations(UserConnection userConnection) {
			var delete = GetDeleteSynchronizedRelationsQuery(userConnection);
			delete.Execute();
		}

		private Select GetNewParticipantToRecipientRelationsToMoveSelect() {
			var select = new Select(ParticipantsToSyncSelect);
			select.Columns.Clear();
			select
				.Column("cpetop", "MandrillRecipientUId")
				.Column("cp", "Id").As("CampaignParticipantId")
				.Column("cpetop", "BulkEmailId")
				.And(CampaignParticipantOpTableName, "StepCompleted").IsEqual(Column.Const(true))
				.InnerJoin(CampaignParticipantEmailTargetOpTableName).As("cpetop")
					.On(CampaignParticipantOpTableName, "Id").IsEqual("cpetop", "CampaignParticipantId")
				.InnerJoin(CampaignParticipantTableName).As("cp")
					.On("cp", "ContactId").IsEqual(CampaignParticipantOpTableName, "ContactId")
					.And("cp", "StatusId")
						.IsEqual(Column.Parameter(CoreCampaignConsts.CampaignParticipantParticipatingStatusId))
					.And("cp", "CampaignId").IsEqual(Column.Parameter(CampaignId, "Guid"))
				.InnerJoin(MandrillRecipientTableName).As("bet")
					.On("bet", "MandrillId").IsEqual("cpetop", "MandrillRecipientUId")
				.InnerJoin(BulkEmailTableName).As("be")
					.On("be", "Id").IsEqual("bet", "BulkEmailId")
				.InnerJoin(CampaignItemTableName).As("ci")
					.On("ci", "Id").IsEqual("cp", "CampaignItemId")
					.And("ci", "RecordId").IsEqual("be", "Id");
			select.SpecifyNoLockHints();
			return select;
		}

		private Select GetUsedNewParticipantToRecipientRelationsToMoveSelect() {
			var select = new Select(ParticipantsToSyncSelect);
			select.Columns.Clear();
			select
				.Column("cpetop", "MandrillRecipientUId")
				.Column("cp", "Id").As("CampaignParticipantId")
				.Column("cpetop", "BulkEmailId")
				.And().Not().Exists(new Select(ParticipantsToSyncSelect.UserConnection)
					.Column(Column.Const(1))
					.From(CampaignParticipantEmailTargetTableName, "cpet")
					.Where("cpet", "MandrillRecipientUId").IsEqual("cpetop", "MandrillRecipientUId"))
				.InnerJoin(CampaignParticipantEmailTargetOpTableName).As("cpetop")
					.On(CampaignParticipantOpTableName, "Id").IsEqual("cpetop", "CampaignParticipantId")
				.InnerJoin(CampaignParticipantTableName).As("cp")
					.On("cp", "ContactId").IsEqual(CampaignParticipantOpTableName, "ContactId")
				.And("cp", "StatusId")
					.In(Column.Parameters(new[] {
						CoreCampaignConsts.CampaignParticipantParticipatingStatusId,
						CoreCampaignConsts.CampaignParticipantInProgressStatusId
					}))
				.And("cp", "CampaignId").IsEqual(Column.Parameter(CampaignId, "Guid"));
			select.SpecifyNoLockHints();
			return select;
		}

		private Insert GetParticipantInfoInsert(UserConnection userConnection,
				IEnumerable<(Guid, Guid, Guid)> infoList) {
			var query = new Insert(userConnection).Into(CampaignParticipantInfoTableName);
			foreach (var info in infoList) {
				query.Values()
					.Set("LinkedEntityId", Column.Parameter(info.Item1))
					.Set("CampaignParticipantId", Column.Parameter(info.Item2))
					.Set("EntityObjectId", Column.Parameter(info.Item3));
			}
			return query;
		}

		private void SyncParticipantInfo() {
			var userConnection = ParticipantsToSyncSelect.UserConnection;
			var allowedStatuses = new[] {
				CoreCampaignConsts.CampaignParticipantParticipatingStatusId,
				CoreCampaignConsts.CampaignParticipantErrorStatusId
			};
			var infoSelect = new Select(userConnection)
				.Column(Column.Parameter(1))
				.From(CampaignParticipantInfoTableName).As("cpi")
				.Where("cpi", "CampaignParticipantId").IsEqual("cp", "Id")
					.And("cpi", "EntityObjectId").IsEqual("cpoi", "EntityObjectId");
			var participantSelect = new Select(ParticipantsToSyncSelect)
				.Column("ContactId")
				.Column("CampaignItemId")
				.Column("CreatedOn");
			var select = new Select(userConnection)
				.Column("cpoi", "LinkedEntityId")
				.Column("cp", "Id").As("CampaignParticipantId")
				.Column("cpoi", "EntityObjectId")
				.From(participantSelect).As("cpo")
				.InnerJoin(CampaignParticipantOpInfoTableName).As("cpoi")
					.On("cpo", "Id").IsEqual("cpoi", "CampaignParticipantId")
				.InnerJoin(CampaignParticipantTableName).As("cp")
					.On("cp", "ContactId").IsEqual("cpo", "ContactId")
						.And("cp", "CreatedOn").IsEqual("cpo", "CreatedOn")
						.And("cp", "StatusId").In(Column.Parameters(allowedStatuses))
						.And("cp", "CampaignItemId").IsEqual("cpo", "CampaignItemId")
						.And("cp", "CampaignId").IsEqual(Column.Parameter(CampaignId, "Guid"))
				.Where().Not().Exists(infoSelect) as Select;
			select.SpecifyNoLockHints();
			var infoArray = select.ExecuteEnumerable(x => {
				var linkedEntityId = x.GetColumnValue<Guid>("LinkedEntityId");
				var participantId = x.GetColumnValue<Guid>("CampaignParticipantId");
				var entityObjectId = x.GetColumnValue<Guid>("EntityObjectId");
				return (linkedEntityId, participantId, entityObjectId);
			}).ToArray();
			if (infoArray.IsNotEmpty()) {
				GetParticipantInfoInsert(userConnection, infoArray).Execute();
			}
		}

		private void DeleteSynchronizedParticipantInfo(UserConnection userConnection) =>
			new Delete(userConnection)
				.From(CampaignParticipantOpInfoTableName)
				.Where("CampaignParticipantId").In(ParticipantsToSyncSelect)
				.Execute();

		private Select GetParticipantsToSuspendSelect(UserConnection userConnection, Guid statusId) {
			var statusIds = new List<Guid>() { statusId };
			statusIds.AddIfNotExists(CoreCampaignConsts.CampaignParticipantParticipatingStatusId);
			var sortedActiveParticipantsSelect = new Select(userConnection)
				.Column("cp_source", "Id")
				.Column(new WindowQueryFunction(
					new RowNumberQueryFunction(),
					new QueryColumnExpression("cp_source", "ContactId"),
					new QueryColumnExpression("cp_source", "CreatedOn"),
						OrderDirection.Descending)).As("RowNum")
				.From(CampaignParticipantTableName, "cp_source")
				.Where("cp_source", "CampaignId").IsEqual(Column.Parameter(CampaignId))
					.And("cp_source", "StatusId").In(Column.Parameters(statusIds));
			return new Select(userConnection)
				.Column("Sub", "Id")
				.From(sortedActiveParticipantsSelect).As("Sub")
				.Where("Sub", "RowNum").IsGreater(Column.Parameter(1)) as Select;
		}

		private void SuspendParticipants(UserConnection userConnection, Guid statusId, Guid suspendStatusId) {
			var activeParticipantsToSuspendSelect = GetParticipantsToSuspendSelect(userConnection, statusId);
			new Delete(userConnection)
				.From(CampaignParticipantInfoTableName)
				.Where("CampaignParticipantId").In(activeParticipantsToSuspendSelect)
				.Execute();
			new Update(userConnection, CampaignParticipantTableName)
				.Set("StatusId", Column.Parameter(suspendStatusId))
				.Where("Id").In(activeParticipantsToSuspendSelect)
				.Execute();
		}

		private void SuspendParticipantDuplicatesByContact(UserConnection userConnection) {
			SuspendParticipants(userConnection, CoreCampaignConsts.CampaignParticipantParticipatingStatusId,
				CoreCampaignConsts.CampaignParticipantSuspendedStatusId);
			SuspendParticipants(userConnection, CoreCampaignConsts.CampaignParticipantInProgressStatusId,
				CoreCampaignConsts.CampaignParticipantSuspendingStatusId);
		}

		private Select GetAllParticipantsToMoveSelect(UserConnection userConnection) {
			var select = GetBaseParticipantsToMoveSelect(userConnection);
			select.Condition.Clear();
			var participantOpIds = ParticipantsToSyncSelect.ExecuteEnumerable(x => {
				return x.GetColumnValue<Guid>("Id");
			});
			return select.Where("cpo", "Id").In(Column.Parameters(participantOpIds)) as Select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns select of operational relations that have to be moved into the
		/// <see cref="CmpgnPrtcpntEmailTarget"/> table.
		/// </summary>
		/// <returns>Select query.</returns>
		protected override Select GetOperationalRecipientRelationsToMoveSelect() =>
			GetNewParticipantToRecipientRelationsToMoveSelect();

		/// <summary>
		/// Returns select of operational relations that have to be moved into the
		/// <see cref="CmpgnPrtcpntEmailTarget"/> table with WasUsed flag.
		/// </summary>
		/// <returns>Select query.</returns>
		protected override Select GetUsedOperationalRecipientRelationsToMoveSelect() =>
			GetUsedNewParticipantToRecipientRelationsToMoveSelect();

		/// <summary>
		/// Adds new campaign participants to campaign participant table and actualizes relations.
		/// Then removes operation campaign participants in transaction.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Count of synchronized participants.</returns>
		protected override int InternalSynchronize(UserConnection userConnection) {
			var addedParticipantsCount = 0;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					addedParticipantsCount = MoveParticipants(userConnection);
					if (userConnection.GetIsFeatureEnabled("CampaignSignalRecurringEntrance") && IsRecurring) {
						SuspendParticipantDuplicatesByContact(userConnection);
					}
					if (userConnection.GetIsFeatureEnabled("CampaignAudienceImport")) {
						SyncParticipantInfo();
						DeleteSynchronizedParticipantInfo(userConnection);
					}
					SyncParticipantRelations(userConnection);
					DeleteSynchronizedRelations(userConnection);
					DeleteSynchronizedContacts(userConnection);
					dbExecutor.CommitTransaction();
				} catch (Exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
			return addedParticipantsCount;
		}

		/// <inheritdoc/>
		protected override Select GetParticipantsToMoveSelect(UserConnection userConnection) {
			if (userConnection.GetIsFeatureEnabled("CampaignSignalRecurringEntrance") && IsRecurring) {
				return GetAllParticipantsToMoveSelect(userConnection);
			}
			return base.GetParticipantsToMoveSelect(userConnection);
		}

		#endregion

	}

	#endregion

}

