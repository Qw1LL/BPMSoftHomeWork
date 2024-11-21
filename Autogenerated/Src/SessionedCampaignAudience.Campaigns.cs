namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: SessionedCampaignAudience

	/// <summary>
	/// Sessioned campaign audience store.
	/// </summary>
	public sealed class SessionedCampaignAudience : BaseCampaignAudience
	{

		#region Constructors: Public

		/// <summary>
		/// Sessioned campaign audience constructor.
		/// </summary>
		/// <param name="config">Configuration object which injected for correct store execution.</param>
		public SessionedCampaignAudience(CampaignAudienceConfig config)
				: base(config.UserConnection, config.CampaignId) {
			config.CheckArgumentNull("config");
			CampaignParticipantTableName = "CampaignParticipantOp";
			SessionId = config.SessionId;
		}

		#endregion

		#region Properties: Private

		private Guid SessionId { get; }

		#endregion

		#region Methods: Private

		private Query AddSessionIdCondition(Query query) {
			if (query.HasCondition) {
				query.And(CampaignParticipantTableName, "SessionId").IsEqual(Column.Parameter(SessionId));
			} else {
				query.Where(CampaignParticipantTableName, "SessionId").IsEqual(Column.Parameter(SessionId));
			}
			return query;
		}

		#endregion

		#region Methods: Proptected

		/// <summary>
		/// See <see cref="BaseCampaignAudience.GetUpdateStatusQueryForItem(Guid, Guid)"/>
		/// </summary>
		protected override Update GetUpdateStatusQueryForItem(Guid itemId, Guid participantStatusId) {
			var update = base.GetUpdateStatusQueryForItem(itemId, participantStatusId);
			update = (Update)AddSessionIdCondition(update);
			return update;
		}

		/// <summary>
		/// See <see cref="BaseCampaignAudience.GetItemCompletedUpdate(Guid)"/>
		/// </summary>
		protected override Update GetItemCompletedUpdate(Guid campaignItemId) {
			var update = base.GetItemCompletedUpdate(campaignItemId);
			update = (Update)AddSessionIdCondition(update);
			return update;
		}

		/// <summary>
		/// See <see cref="BaseCampaignAudience.GetAudienceSelect(Guid)"/>
		/// </summary>
		protected override Select GetAudienceSelect(Guid itemId) {
			var select = base.GetAudienceSelect(itemId);
			select = (Select)AddSessionIdCondition(select);
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// See <see cref="ICampaignAudience.GetSequenceFlowBaseUpdate(Guid, Guid)"/>.
		/// Add SessionId to base query condition.
		/// </summary>
		public override Update GetSequenceFlowBaseUpdate(Guid sourceRefUId, Guid targetRefUId) {
			var baseQuery = base.GetSequenceFlowBaseUpdate(sourceRefUId, targetRefUId);
			baseQuery = (Update)AddSessionIdCondition(baseQuery);
			return baseQuery;
		}

		/// <summary>
		/// Adding audience to campaign from list.
		/// </summary>
		/// <param name="contacts">List of contacts which need to add to the participant table.</param>
		/// <param name="campaignItemId">Unique identifier of the campaign step item.</param>
		public override void Add(IEnumerable<Guid> contacts, Guid campaignItemId) {
			foreach (var contact in contacts) {
				var insert = new Insert(UserConnection)
					.Into(CampaignParticipantTableName)
					.Set("ContactId", Column.Parameter(contact))
					.Set("CampaignId", Column.Parameter(CampaignId))
					.Set("CampaignItemId", Column.Parameter(campaignItemId))
					.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Set("StatusId", Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
					.Set("StepCompleted", Column.Parameter(false))
					.Set("SessionId", Column.Parameter(SessionId))
					.Set("IsReadyToSync", Column.Parameter(false))
					.Set("InitialCampaignItemId", Column.Parameter(campaignItemId));
				insert.Execute();
			}
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.Add(Select, Guid, string)"/>
		/// </summary>
		/// <exception cref="NotSupportedException">Throws everytime.</exception>
		public override int Add(Select select, Guid campaignItemId, string contactIdColumn) {
			throw new NotSupportedException();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.Exclude(Select, Guid)"/>
		/// </summary>
		/// <exception cref="NotSupportedException">Throws everytime.</exception>
		public override int Exclude(Select select, Guid campaignItemId) {
			throw new NotSupportedException();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.Exclude(Select, Guid, Guid)"/>
		/// </summary>
		/// <exception cref="NotSupportedException">Throws everytime.</exception>
		public override int Exclude(Select select, Guid campaignItemId, Guid participantStatusId) {
			throw new NotSupportedException();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.GetAudienceByItemSelect(Guid)"/>
		/// </summary>
		/// <exception cref="NotSupportedException">Throws everytime.</exception>
		public override Select GetAudienceByItemSelect(Guid itemId) {
			throw new NotSupportedException();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.SetItemCompleted(Guid, Select)"/>
		/// </summary>
		/// <exception cref="NotSupportedException">Throws everytime.</exception>
		public override int SetItemCompleted(Guid campaignStepId, Select contactSelect) {
			throw new NotSupportedException();
		}

		/// <summary>
		/// See <see cref="ICampaignAudience.IncreaseCampaignParticipantsCount(int)"/>
		/// </summary>
		/// <exception cref="NotSupportedException">Throws everytime.</exception>
		public override void IncreaseCampaignParticipantsCount(int addedParticipantsCount) {
			throw new NotSupportedException();
		}

		#endregion

	}

	#endregion

}

