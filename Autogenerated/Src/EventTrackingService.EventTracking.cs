namespace BPMSoft.Configuration.EventTrackingService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Configuration.StartTrackingPostProcess;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Configuration.EventTrackingResult;
	using BPMSoft.Web.Http.Abstractions;
	using global::Common.Logging;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EventTrackingService {

		#region Class: Tracking

		/// <summary>
		/// Web event tracking.
		/// </summary>
		public class Tracking
		{

			#region Properties: Public

			public string ApiKey {
				get;
				set;
			}
			
			public List<TrackingParameters> ListTracking {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Class: TrackingParameters

		/// <summary>
		/// Tracking parameters.
		/// </summary>
		public class TrackingParameters
		{

			#region Properties: Public

			public Guid Id {
				get;
				set;
			}

			private string _eventTime;
			public string EventTime {
				get {
					return _eventTime;
				}
				set {
					DateTime result;
					if (!DateTime.TryParse(value, out result)) {
						throw new SerializationException();
					}
					_eventTime = value;
				}
			}

			public Guid SessionId {
				get;
				set;
			}

			public Guid EventTypeId {
				get;
				set;
			}

			public string Url {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Properties: Private

		private UserConnection _userConnection;
		private UserConnection UserConnection {
			get {
				if (_userConnection != null) {
					return _userConnection;
				}
				_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection;
				if (_userConnection != null) {
					return _userConnection;
				}
				var appConnection = (AppConnection)HttpContext.Current.Application["AppConnection"];
				_userConnection = appConnection.SystemUserConnection;
				return _userConnection;
			}

			set {
				_userConnection = value;
			}
		}
		
		private static readonly ILog _log = LogManager.GetLogger("Tracking");

		#endregion

		#region Methods: Private

		private List<Guid> GetExistsSiteEventsIds(List<Guid> ids) {
			var eventsIds = new List<Guid>();
			var selectQuery = new Select(UserConnection)
				.Column("Id")
				.From("SiteEvent")
				.Where("Id").In(Column.Parameters(ids)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = selectQuery.ExecuteReader(dbExecutor)) {
					int idColumnIndex = reader.GetOrdinal("Id");
					while (reader.Read()) {
						var eventsId = reader.GetGuid(idColumnIndex);
						eventsIds.Add(eventsId);
					}
				}
			}
			return eventsIds;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Save event tracking.
		/// </summary>
		/// <param name="tracking">Request body.</param>
		/// <returns>Result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveEventTrackingData",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
			ResponseFormat = WebMessageFormat.Json)]
		public bool SaveEventTrackingData(Tracking tracking) {
			if (UserConnection == null) {
				_log.ErrorFormat("[EventTrackingService_SaveEventData. UserConnection = null]");
				return false;
			}
			if (tracking.ListTracking == null) {
				_log.ErrorFormat("[EventTrackingService_SaveEventData. ListTracking = null]");
				return false;
			}
			if (tracking.ListTracking.Count == 0) {
				_log.ErrorFormat("[EventTrackingService_SaveEventData. ListTracking.Count = 0]");
				return false;
			}
			var eventTrackingApiKey = SysSettings.GetValue(UserConnection,
				"EventTrackingApiKey").ToString();
			if (tracking.ApiKey != eventTrackingApiKey) {
				_log.ErrorFormat("[EventTrackingService_SaveEventData. tracking.ApiKey != eventTrackingApiKey]");
				return false;
			}
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					List<Guid> eventsId = tracking.ListTracking.Select(trackingItem => trackingItem.Id).ToList();
					List<Guid> existsEventsId = GetExistsSiteEventsIds(eventsId);
					List<TrackingParameters> newEvents = tracking.ListTracking
						.Where(item => !existsEventsId.Contains(item.Id)).ToList();
					newEvents.ForEach(item => {
						var query = new Insert(UserConnection).Into("SiteEvent")
							.Set("Id", Column.Parameter(item.Id))
							.Set("EventDate", Column.Parameter(Convert.ToDateTime(item.EventTime)))
							.Set("Source", Column.Parameter(item.Url))
							.Set("SiteEventTypeId", Column.Parameter(item.EventTypeId))
							.Set("BpmSessionId", Column.Parameter(item.SessionId));
						query.Execute(dbExecutor);
					});
					dbExecutor.CommitTransaction();
				} catch(Exception e) {
					dbExecutor.RollbackTransaction();
					_log.ErrorFormat("[EventTrackingService_SaveEventData. Insert data failed.]", e);
					return false;
				}
			}
			return true;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "StartTracking",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public int StartTracking(string apiKey) {
			if (UserConnection == null) {
				return (int)EventTrackingResult.OtherError;
			}
			return StartTrackingPostProcess.StartTracking(UserConnection, apiKey);
		}

		#endregion

	}
}

