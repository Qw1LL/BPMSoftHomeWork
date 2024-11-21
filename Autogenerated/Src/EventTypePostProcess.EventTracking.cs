namespace BPMSoft.Configuration.EventTypePostProcess
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;

	#region Class: EventTypePostProcess

	/// <summary>
	/// Post event type class
	/// </summary>
	public static class EventTypePostProcess
	{

		#region Methods: Public

		/// <summary>
		/// Set event type to tracking service.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		public static void SetEventType(UserConnection userConnection) {
			var listEventType = new List<EventType>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				Select tableSelect = new Select(userConnection)
					.Column("SiteEventType", "Id").As("SiteEventTypeId")
					.Column("Identifier")
					.Column("IsActive")
					.Column("SelectorType", "Code").As("SelectorTypeCode")
					.Column("WebsiteEventType", "Code").As("WebsiteEventTypeCode")
					.From("SiteEventType")
					.LeftOuterJoin("SelectorType")
						.On("SelectorType", "Id").IsEqual("SiteEventType", "SelectorTypeId")
					.LeftOuterJoin("WebsiteEventType")
						.On("WebsiteEventType", "Id").IsEqual("SiteEventType", "WebsiteEventTypeId") as Select;
				using (var dr = tableSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						EventType eventType = new EventType();
						eventType.Id = dr.GetColumnValue<Guid>("SiteEventTypeId");
						eventType.IdValue = dr.GetColumnValue<string>("Identifier");
						eventType.TrackModeId = dr.GetColumnValue<sbyte>("SelectorTypeCode");
						eventType.KindId = dr.GetColumnValue<sbyte>("WebsiteEventTypeCode");
						eventType.Action = dr.GetColumnValue<bool>("IsActive") ? (sbyte) 1 : (sbyte) -1;
						listEventType.Add(eventType);
					}
				}
			}
			SetEventType(userConnection, listEventType);
		}

		/// <summary>
		/// Post event type to tracking service.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		/// <param name="listEventType">List event type</param>
		public static void SetEventType(UserConnection userConnection, List<EventType> listEventType) {
			var setEventTypeRequest = new SetEventType();
			var eventTrackingLogin = SysSettings.GetValue(userConnection,
				"EventTrackingLogin").ToString();
			var eventTrackingPassword = SysSettings.GetValue(userConnection,
				"EventTrackingPassword").ToString();
			var eventTrackingApiKey = SysSettings.GetValue(userConnection,
				"EventTrackingApiKey").ToString();
			var eventTrackingWebAppUrl = SysSettings.GetValue(userConnection,
				"EventTrackingWebAppUrl").ToString();
			if(string.IsNullOrEmpty(eventTrackingWebAppUrl))
				return;
			eventTrackingWebAppUrl += "/SetEventType?format=json";
			
			setEventTypeRequest.SetBasicAuth(eventTrackingLogin, eventTrackingPassword);
			setEventTypeRequest.SetRequestMethod("POST");
			setEventTypeRequest.ApiKey = eventTrackingApiKey;
			setEventTypeRequest.EventTypeList = listEventType;
			setEventTypeRequest.Execute(eventTrackingWebAppUrl);
		}

		#endregion

	}

	#endregion

	#region Class: SetEventType

	/// <summary>
	/// Request parameters web service SetEventType.
	/// </summary>
	public class SetEventType : BaseRestClient<int>
	{

		#region Properties: Public

		public string ApiKey {
			get;
			set;
		}

		public List<EventType> EventTypeList {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: EventType

	public class EventType
	{

		#region Properties: Public

		public Guid Id {
			get;
			set;
		}

		public sbyte TrackModeId {
			get;
			set;
		}

		public string IdValue {
			get;
			set;
		}

		public sbyte KindId {
			get;
			set;
		}

		public sbyte Action {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
