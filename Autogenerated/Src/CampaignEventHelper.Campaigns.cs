namespace BPMSoft.Configuration.CampaignEventHelper
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Configuration.MandrillService;
	using global::Common.Logging;

	#region Class: CampaignEventHelper

	/// <summary>
	/// Class for work with events that used in campaigns.
	/// </summary>
	public class CampaignEventHelper
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly ILog _log = LogManager.GetLogger("EventHelper");

		#endregion

		#region Constructors: Public

		public CampaignEventHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_log = LogManager.GetLogger("EventHelper");
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns collection of ready to send events identifiers.
		/// </summary>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <returns>Collection of unique identifiers of events</returns>
		private List<Guid> GetReadyToStartEventsList(Guid campaignId) {
			List<Guid> eventsList = new List<Guid>();
			Select eventsSelect = (Select)new Select(_userConnection)
				.Column("Id")
				.From("Event")
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId));
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = eventsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						int eventIdColumnIndex = reader.GetOrdinal("Id");
						Guid eventId = reader.GetGuid(eventIdColumnIndex);
						eventsList.Add(eventId);
					}
				}
			}
			return eventsList;
		}

		/// <summary>
		/// Adds contacts from the campaign audience into audience of the event.
		/// </summary>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="eventId">Unique identifier of the Event.</param>
		private void ActualizeEventAudienceFromCampaign(Guid campaignId, Guid eventId) {
			try {
				Guid stepId = MandrillService.GetCampaignStepIdByRecordId(campaignId, eventId, _userConnection);
				AddContactsToEventFromCampaign(campaignId, eventId, stepId);
				MandrillService.SetCampaignTargetsCurrentStep(campaignId, stepId, _userConnection);
			} catch (System.Data.SqlClient.SqlException e) {
				_log.ErrorFormat(
					"[EventHelper.ActualizeEventAudienceFromCampaign]: "
					+ "Actualize Event: {0} audience from campaign: {1} fails.", e, eventId, campaignId);
				throw e;
			}
		}

		/// <summary>
		/// Actualize the event audience from the campaign audience and sets event as current step.
		/// </summary>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="eventId">Unique identifier of the Event.</param>
		/// <param name="stepId">Unique identifier of the Campaign step.</param>
		private void AddContactsToEventFromCampaign(Guid campaignId, Guid eventId, Guid stepId) {
			Select select = GetSelectContactsCampaignForEvent(campaignId, eventId, stepId);
			MandrillService.ExecuteInsertSelect(select, GetInsertSelectContactsEventFromCampaign, _userConnection);
		}

		/// <summary>
		/// Creates query for select contacts from the campaign audience.
		/// </summary>
		/// <param name="campaignId">Unique identifier of the Campaign.</param>
		/// <param name="eventId">Unique identifier of the Event.</param>
		/// <param name="stepId">Unique identifier of the Campaign step.</param>
		/// <returns>Query.</returns>
		private Select GetSelectContactsCampaignForEvent(Guid campaignId, Guid eventId, Guid stepId) {
			var select = new Select(_userConnection)
				.Column(Column.Parameter(eventId)).As("EventId")
				.Column(Column.Parameter(MarketingConsts.EventResponsePlannedId)).As("EventResponseId")
				.Column(Column.Parameter(false)).As("IsFromGroup")
				.Column(Column.Parameter(DateTime.UtcNow)).As("CreatedOn")
				.Column(Column.Parameter(DateTime.UtcNow)).As("ModifiedOn")
				.Column(Column.Parameter(MarketingConsts.MandrillUserId)).As("ModifiedById")
				.Column("CT", "ContactId").As("ContactId")
				.From("CampaignTarget").As("CT")
				.Where("CT", "CampaignId").IsEqual(Column.Parameter(campaignId))
				.And("CT", "NextStepId").IsEqual(Column.Parameter(stepId))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("Id")
						.From("EventTarget").As("ET")
						.Where("ET", "EventId").IsEqual(Column.Parameter(eventId))
						.And("ET", "ContactId").IsEqual("CT", "ContactId")) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		/// <summary>
		/// Creates query for instert contacts into the event audience.
		/// </summary>
		/// <param name="select">Query for select contacts.</param>
		/// <returns>The insert query.</returns>
		private InsertSelect GetInsertSelectContactsEventFromCampaign(Select select) {
			var insertSelect = new InsertSelect(_userConnection)
				.Into("EventTarget")
				.Set("EventId", "EventResponseId", "IsFromGroup", "CreatedOn", "ModifiedOn", "ModifiedById",
						"ContactId")
				.FromSelect(select);
			return insertSelect;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualize the events audience from the campaign.
		/// </summary>
		public void ActualizeEvents(Guid campaignId) {
			List<Guid> events = GetReadyToStartEventsList(campaignId);
			foreach (Guid eventId in events) {
				try {
					ActualizeEventAudienceFromCampaign(campaignId, eventId);
				} catch (Exception e) {
					_log.ErrorFormat(
						"[EventHelper.ActualizeAllEvents]: "
						+ "Actualize Event: {0} audience from campaign: {1} fails.", e,
						eventId,
						campaignId);
				}
			}
		}

		#endregion
	}

	#endregion
}
