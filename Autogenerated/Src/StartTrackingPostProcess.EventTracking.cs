namespace BPMSoft.Configuration.StartTrackingPostProcess
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Configuration.EventTrackingResult;
	using BPMSoft.Configuration.EventTypePostProcess;

	#region Class: StartTrackingPostProcess

	public static class StartTrackingPostProcess
	{

		#region Methods: Public

		/// <summary>
		/// Start event tracking.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		/// <param name="apiKey">Api key.</param>
		/// <returns>Result code.</returns>
		public static int StartTracking(UserConnection userConnection, string apiKey) {
			var apiKeyRequest = new ApiKeyRequest();
			string eventTrackingLogin = SysSettings.GetValue(userConnection,
				"EventTrackingLogin").ToString();
			string eventTrackingPassword = SysSettings.GetValue(userConnection,
				"EventTrackingPassword").ToString();
			SysSettings.SetDefValue(userConnection, "EventTrackingApiKey", apiKey);
			string eventTrackingWebAppUrl = SysSettings.GetValue(userConnection,
				"EventTrackingWebAppUrl").ToString();
			if(string.IsNullOrEmpty(eventTrackingWebAppUrl))
				return (int)EventTrackingResult.SysSettingIsEmpty;
			
			eventTrackingWebAppUrl += "/SetupTracking?format=json";
			string bpmUrl = SysSettings.GetValue(userConnection,
				"BpmEventTrackingServiceUrl").ToString();
			string bpmAuthKey = SysSettings.GetValue(userConnection,
				"BpmAuthKey").ToString();
			if (string.IsNullOrEmpty(bpmUrl) || string.IsNullOrEmpty(bpmAuthKey)) {
				return (int)EventTrackingResult.SysSettingIsEmpty;
			}
			var trackingDomainESQ = new EntitySchemaQuery(userConnection.EntitySchemaManager, "TrackingDomain");
			var nameColumn = trackingDomainESQ.AddColumn("Name");
			var trackingDomainCollection = trackingDomainESQ.GetEntityCollection(userConnection);
			apiKeyRequest.TrackingDomainList = trackingDomainCollection.Select(item => 
				item.GetColumnValue(nameColumn.Name).ToString()).ToList();
			if (!apiKeyRequest.TrackingDomainList.Any()) {
				return (int)EventTrackingResult.DomainIsEmpty;
			}
			apiKeyRequest.SetBasicAuth(eventTrackingLogin, eventTrackingPassword);
			apiKeyRequest.SetRequestMethod("POST");
			apiKeyRequest.ApiKey = apiKey;
			apiKeyRequest.BpmAuthKey = bpmAuthKey;
			apiKeyRequest.BpmUrl = bpmUrl;
			int result = apiKeyRequest.Execute(eventTrackingWebAppUrl);
			if (!apiKeyRequest.Success) {
				return (int)EventTrackingResult.OtherError;
			}
			EventTypePostProcess.SetEventType(userConnection);
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: ApiKeyRequest

	public class ApiKeyRequest : BaseRestClient<int>
	{

		#region Properties: Public

		/// <summary>
		/// bpmcrm api key.
		/// </summary>
		public string ApiKey {
			get;
			set;
		}

		/// <summary>
		/// bpmcrm site url.
		/// </summary>
		public string BpmUrl {
			get;
			set;
		}

		/// <summary>
		/// bpmcrm auth key.
		/// </summary>
		public string BpmAuthKey {
			get;
			set;
		}

		/// <summary>
		/// Tracking domains.
		/// </summary>
		public List<string> TrackingDomainList {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
