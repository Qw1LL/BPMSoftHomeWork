namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: BaseCampaignAudience

	/// <summary>
	/// Base abstract class for campaign audience store.
	/// </summary>
	public abstract class BaseCampaignAudience : ICampaignAudience
	{

		#region Constructors: Protected

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of the UserConnection.</param>
		/// <param name="campaignId">Campaign identifier.</param>
		protected BaseCampaignAudience(UserConnection userConnection, Guid campaignId) {
			userConnection.CheckArgumentNull("userConnection");
			campaignId.CheckArgumentEmpty("campaignId");
			UserConnection = userConnection;
			CampaignId = campaignId;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Instance of the UserConnection.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		/// <summary>
		/// Campaign identifier.
		/// </summary>
		protected Guid CampaignId { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name for campaign participant table.
		/// </summary>
		public string CampaignParticipantTableName { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Create <see cref="Update"/> query for modify participants status from 
		/// <paramref name="participantStatusId"/> on item with identifier contains in <paramref name="itemId"/>.
		/// </summary>
		/// <param name="itemId">Identifier of campaign item for wich needs update participants status.</param>
		/// <param name="participantStatusId">Participant status identifier.</param>
		/// <returns><see cref="Update"/> query.</returns>
		protected virtual Update GetUpdateStatusQueryForItem(Guid itemId, Guid participantStatusId) {
			var exceptStatuses = Column.Parameters(GetParticipantSuspensionStatuses());
			exceptStatuses.Add(Column.Parameter(participantStatusId));
			var update =
				new Update(UserConnection, CampaignParticipantTableName)
					.Set("StatusId", Column.Parameter(participantStatusId))
					.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where(CampaignParticipantTableName, "CampaignItemId").IsEqual(Column.Parameter(itemId))
						.And(CampaignParticipantTableName, "StatusId")
							.Not().In(exceptStatuses) as Update;
			update.WithHints(new RowLockHint());
			return update;
		}

		/// <summary>
		/// Create <see cref="Update"/> query for update participants parameters when completed step for this item.
		/// </summary>
		/// <param name="campaignItemId">Campaign item identifier.</param>
		/// <returns><see cref="Update"/> query for <see cref="SequenceFlowElement"/></returns>
		protected virtual Update GetItemCompletedUpdate(Guid campaignItemId) {
			var exceptStatuses = GetParticipantSuspensionStatuses();
			var update =
				new Update(UserConnection, CampaignParticipantTableName)
					.Set("StepCompleted", Column.Parameter(true))
					.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("StepCompletedOn", Column.Parameter(DateTime.UtcNow))
					.Where("CampaignId").IsEqual(Column.Parameter(CampaignId))
						.And(CampaignParticipantTableName, "CampaignItemId")
							.IsEqual(Column.Parameter(campaignItemId))
						.And(CampaignParticipantTableName, "StatusId")
							.Not().In(Column.Parameters(exceptStatuses))
						.And(CampaignParticipantTableName, "StepCompleted")
							.IsEqual(Column.Parameter(false)) as Update;
			update.WithHints(new RowLockHint());
			return update;
		}

		protected virtual Select GetAudienceSelect(Guid itemId) {
			var select =
				new Select(UserConnection).Column("Contact", "RId").As("ContactRId")
					.Column("Contact", "Email").As("EmailAddress")
					.From(CampaignParticipantTableName)
					.InnerJoin("Contact")
					.On("Contact", "Id").IsEqual(CampaignParticipantTableName, "ContactId")
					.Where(CampaignParticipantTableName, "CampaignId").IsEqual(Column.Parameter(CampaignId))
						.And(CampaignParticipantTableName, "CampaignItemId").IsEqual(Column.Parameter(itemId))
						.And(CampaignParticipantTableName, "StatusId")
							.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
						.And(CampaignParticipantTableName, "StepCompleted").IsEqual(Column.Parameter(false)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		protected Guid[] GetParticipantSuspensionStatuses() {
			return new[] {
				CampaignConstants.CampaignParticipantErrorStatusId,
				CampaignConstants.CampaignParticipantInProgressStatusId,
				CampaignConstants.CampaignParticipantSuspendedStatusId,
				CampaignConstants.CampaignParticipantSuspendingStatusId
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// See <see cref="ICampaignAudience.SetItemCompleted(Guid)"/>
		/// </summary>
		public virtual int SetItemCompleted(Guid itemId) {
			var audienceUpdate = GetItemCompletedUpdate(itemId);
			return audienceUpdate.Execute();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.UpdateStatusForItem(Guid, Guid)"/>
		/// </summary>
		public virtual int UpdateStatusForItem(Guid itemId, Guid participantStatusId) {
			var update = GetUpdateStatusQueryForItem(itemId, participantStatusId);
			return update.Execute();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.GetSequenceFlowBaseQuery(Guid, Guid)"/>
		/// </summary>
		public virtual Update GetSequenceFlowBaseUpdate(Guid sourceRefUId, Guid targetRefUId) {
			var result = new Update(UserConnection, CampaignParticipantTableName)
				.Set("CampaignItemId", Column.Parameter(targetRefUId))
				.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("StepCompletedOn", Column.Parameter(null, "DateTime"))
				.Set("StepCompleted", Column.Parameter(false))
				.Where("StatusId").IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
					.And("CampaignItemId")
						.IsEqual(Column.Parameter(sourceRefUId)) as Update;
			result.WithHints(new RowLockHint());
			return result;
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.Add(Select, Guid, string)"/>
		/// </summary>
		public abstract int Add(Select select, Guid campaignItemId, string contactIdColumn);

		/// <summary>
		/// See <see cref="ICampaignAudience.Add(IEnumerable{Guid}, Guid)"/>
		/// </summary>
		public abstract void Add(IEnumerable<Guid> contacts, Guid campaignItemId);

		/// <summary>
		/// See <see cref="ICampaignAudience.Exclude(Select, Guid)"/>
		/// </summary>
		public abstract int Exclude(Select select, Guid campaignItemId);

		/// <summary>
		/// See <see cref="ICampaignAudience.Exclude(Select, Guid, Guid)"/>
		/// </summary>
		public abstract int Exclude(Select select, Guid campaignItemId, Guid participantStatusId);

		/// <summary>
		/// See <see cref="ICampaignAudience.GetAudienceByItemSelect(Guid)"/>
		/// </summary>
		public abstract Select GetAudienceByItemSelect(Guid itemId);

		/// <summary>
		/// See <see cref="ICampaignAudience.GetItemAudienceSelect(Guid)"/>
		/// </summary>
		public virtual Select GetItemAudienceSelect(Guid itemId) {
			return GetAudienceSelect(itemId);
		}

		/// <summary>
		/// Sets StepCompleted flag true and specified participants' status for audience on campaign step.
		/// </summary>
		/// <param name="itemId">Unique identifier of the campaign step.</param>
		/// <param name="participantStatusId">Unique identifier of the campaign participant status to set.</param>
		/// <returns>Count of updated participants.</returns>
		public virtual int SetItemCompleted(Guid itemId, Guid participantStatusId) {
			var update = GetItemCompletedUpdate(itemId);
			update.Set("StatusId", Column.Parameter(participantStatusId));
			return update.Execute();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.SetItemCompleted(Guid, Select)"/>
		/// </summary>
		public abstract int SetItemCompleted(Guid itemId, Select contactSelect);

		/// <summary>
		/// See <see cref="ICampaignAudience.IncreaseCampaignParticipantsCount(int)"/>
		/// </summary>
		public abstract void IncreaseCampaignParticipantsCount(int addedParticipantsCount);

		#endregion

	}

	#endregion

}
