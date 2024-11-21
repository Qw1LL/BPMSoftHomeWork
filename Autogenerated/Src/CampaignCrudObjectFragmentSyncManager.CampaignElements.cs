namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: CampaignCrudObjectFragmentSyncManager

	/// <summary>
	/// Describes synchronizer that is worked with campaign participants
	/// for which InitialCampaignItemId is campaign signal element Id.
	/// </summary>
	public sealed class CampaignCrudObjectFragmentSyncManager : CampaignBaseFragmentSyncManager
	{

		#region Constructors: Public

		public CampaignCrudObjectFragmentSyncManager(Guid campaignId, Guid campaignItemId)
			: base(campaignId, campaignItemId)
		{
		}

		#endregion

		#region Methods: Private
		
		private int UpdateSuspendingParticipants(UserConnection userConnection) {
			var update = GetUpdateSuspendingParticipantsQuery(userConnection);
			return update.Execute();
		}

		private int UpdateInProgressParticipants(UserConnection userConnection) {
			var update = GetUpdateInProgressParticipantsQuery(userConnection);
			return update.Execute();
		}

		private void DeleteSynchronizedRelations(UserConnection userConnection) {
			var delete = GetDeleteSynchronizedRelationsQuery(userConnection);
			delete.Execute();
		}

		private void DeleteSynchronizedContacts(UserConnection userConnection) {
			var delete = GetDeleteSynchronizedQuery(userConnection);
			delete.Execute();
		}

		private int UpdateParticipants(UserConnection userConnection) {
			int processedCount = UpdateSuspendingParticipants(userConnection);
			processedCount += UpdateInProgressParticipants(userConnection);
			return processedCount;
		}

		private Select GetExistingParticipantToRecipientRelationsToMoveSelect() {
			var select = new Select(ParticipantsToSyncSelect);
			select.Columns.Clear();
			select
				.Column("cpetop", "MandrillRecipientUId")
				.Column(CampaignParticipantOpTableName, "CampaignParticipantId")
				.Column("cpetop", "BulkEmailId")
				.And(CampaignParticipantOpTableName, "StepCompleted").IsEqual(Column.Parameter(true))
				.InnerJoin(CampaignParticipantEmailTargetOpTableName).As("cpetop")
					.On(CampaignParticipantOpTableName, "Id").IsEqual("cpetop", "CampaignParticipantId")
				.InnerJoin(MandrillRecipientTableName).As("bet")
					.On("bet", "MandrillId").IsEqual("cpetop", "MandrillRecipientUId")
				.InnerJoin(BulkEmailTableName).As("be")
					.On("be", "Id").IsEqual("bet", "BulkEmailId")
				.InnerJoin(CampaignItemTableName).As("ci")
					.On("ci", "Id").IsEqual(CampaignParticipantOpTableName, "CampaignItemId")
					.And("ci", "RecordId").IsEqual("be", "Id");
			select.SpecifyNoLockHints();
			return select;
		}

		private Select GetUsedExistingParticipantToRecipientRelationsToMoveSelect() {
			var select = new Select(ParticipantsToSyncSelect);
			select.Columns.Clear();
			select
				.Column("cpetop", "MandrillRecipientUId")
				.Column(CampaignParticipantOpTableName, "CampaignParticipantId")
				.Column("cpetop", "BulkEmailId")
				.And().Not().Exists(new Select(ParticipantsToSyncSelect.UserConnection)
					.Column(Column.Parameter(1))
					.From(CampaignParticipantEmailTargetTableName, "cpet")
					.Where("cpet", "MandrillRecipientUId").IsEqual("cpetop", "MandrillRecipientUId"))
				.InnerJoin(CampaignParticipantEmailTargetOpTableName).As("cpetop")
					.On(CampaignParticipantOpTableName, "Id").IsEqual("cpetop", "CampaignParticipantId");
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns select of operational relations that have to be moved into the
		/// <see cref="CmpgnPrtcpntEmailTarget"/> table.
		/// </summary>
		/// <returns>Select query.</returns>
		protected override Select GetOperationalRecipientRelationsToMoveSelect() =>
			GetExistingParticipantToRecipientRelationsToMoveSelect();

		/// <summary>
		/// Returns select of operational relations that have to be moved into the
		/// <see cref="CmpgnPrtcpntEmailTarget"/> table with WasUsed flag.
		/// </summary>
		/// <returns>Select query.</returns>
		protected override Select GetUsedOperationalRecipientRelationsToMoveSelect() =>
			GetUsedExistingParticipantToRecipientRelationsToMoveSelect();

		/// <summary>
		/// Updates processing campaign participants' state, actualizes relations
		/// and removes operation campaign participants in transaction.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Count of synchronized participants.</returns>
		protected override int InternalSynchronize(UserConnection userConnection) {
			int syncParticipantsCount;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					syncParticipantsCount = UpdateParticipants(userConnection);
					SyncParticipantRelations(userConnection);
					DeleteSynchronizedRelations(userConnection);
					DeleteSynchronizedContacts(userConnection);
					dbExecutor.CommitTransaction();
				} catch (Exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
			return syncParticipantsCount;
		}

		#endregion

	}

	#endregion

}

