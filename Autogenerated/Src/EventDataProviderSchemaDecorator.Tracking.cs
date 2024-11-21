namespace BPMSoft.Configuration.Tracking
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;
	using CoreConfig = Core.Configuration;

	#region Class: EventDataProviderSchemaDecorator

	/// <summary>
	/// Provide information from report service.
	/// </summary>
	public class EventDataProviderSchemaDecorator
	{
		private readonly EventDataProvider _eventDataProvider;
		private readonly UserConnection _userConnection;
		private bool IsDemoMode { 
			get { 
				Func<string, string> getSettingsStringValue = (code)
					=> CoreConfig.SysSettings.GetValue(_userConnection, code).ToString();
				var trackingTenantUrl = getSettingsStringValue("TrackingTenantUrl");
				var trackingReceiverUrl = getSettingsStringValue("TrackingReceiverUrl");
				var trackingReportUrl = getSettingsStringValue("TrackingReportUrl");
				var trackingDemoData = _userConnection.GetIsFeatureEnabled("TrackingDemoData");
				var isAllSettingsEmpty = string.IsNullOrEmpty(trackingTenantUrl) &&
					string.IsNullOrEmpty(trackingReceiverUrl) &&
					string.IsNullOrEmpty(trackingReportUrl);
				return trackingDemoData && isAllSettingsEmpty;
			}  
		}

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		/// <param name="eventDataProvider">Instance of EventDataProvider.</param>
		public EventDataProviderSchemaDecorator(UserConnection userConnection, EventDataProvider eventDataProvider) {
			_userConnection = userConnection;
			_eventDataProvider = eventDataProvider;
		}

		#endregion

		#region Methods: Private

		private Select GetLeadSessionIdsByContactQuery(Guid contactId) {
			var select = new Select(_userConnection)
				.Distinct()
				.Column("BpmSessionId")
				.From("Lead")
				.Where("QualifiedContactId")
					.IsEqual(Column.Parameter(contactId))
				.And("BpmSessionId")
					.Not().IsNull() as Select;
			return select;
		}

		private Select GetLeadSessionIdsQuery(Guid leadId) {
			var select = new Select(_userConnection)
				.Distinct()
				.Column("BpmSessionId")
				.From("Lead")
				.Where("Id")
					.IsEqual(Column.Parameter(leadId))
				.And("BpmSessionId")
					.Not().IsNull() as Select;
			return select;
		}

		private IEnumerable<Guid> GetLeadSessionIdsByContact(Guid contactId) {
			var select = GetLeadSessionIdsByContactQuery(contactId);
			var bpmSessionIds = new List<Guid>();
			select.ExecuteReader(dataReader => {
				bpmSessionIds.Add(dataReader.GetColumnValue<Guid>("BpmSessionId"));
			});
			return bpmSessionIds;
		}

		private IEnumerable<Guid> GetLeadSessionIds(Guid leadId) {
			var select = GetLeadSessionIdsQuery(leadId);
			var bpmSessionIds = new List<Guid>();
			select.ExecuteReader(dataReader => {
				bpmSessionIds.Add(dataReader.GetColumnValue<Guid>("BpmSessionId"));
			});
			return bpmSessionIds;
		}

		private EventFeedDataProviderResponse GetEventFeedDataProviderResponseMock (){
			return new EventFeedDataProviderResponse
			{
				Events = EventFeedMock.GetEvents()
			};		
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns contact tracking feed.
		/// </summary>
		/// <param name="contactId">Contact identifier for get feed.</param>
		/// <param name="offset">Records offset.</param>
		/// <param name="count">Records count.</param>
		/// <returns>Object <see cref="EventFeedDataProviderResponse"/> which contains all needed records.</returns>
		public EventFeedDataProviderResponse GetContactFeed(Guid contactId, string offset, int count) {
			if (IsDemoMode) {
				return GetEventFeedDataProviderResponseMock();
			}
			var bpmstudioTrackingIds = GetLeadSessionIdsByContact(contactId);
			if (bpmstudioTrackingIds.IsEmpty()) {
				return new EventFeedDataProviderResponse();
			}
			var feed = _eventDataProvider.GetFeed(bpmstudioTrackingIds, offset, count);
			return feed;
		}

		/// <summary>
		/// Returns contact tracking feed.
		/// </summary>
		/// <param name="leadId">Lead identifier for get feed.</param>
		/// <param name="offset">Records offset.</param>
		/// <param name="count">Records count.</param>
		/// <returns>Object <see cref="EventFeedDataProviderResponse"/> which contains all needed records.</returns>
		public EventFeedDataProviderResponse GetLeadFeed(Guid leadId, string offset, int count) {
			if (IsDemoMode) {
				return GetEventFeedDataProviderResponseMock();
			}
			var bpmstudioTrackingIds = GetLeadSessionIds(leadId);
			if (bpmstudioTrackingIds.IsEmpty()) {
				return new EventFeedDataProviderResponse();
			}
			var feed = _eventDataProvider.GetFeed(bpmstudioTrackingIds, offset, count);
			return feed;
		}

		#endregion

	}

	#endregion
}

