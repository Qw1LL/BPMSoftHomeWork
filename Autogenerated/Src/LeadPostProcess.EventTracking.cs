namespace BPMSoft.Configuration.GeneratedWebFormService
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Configuration;

	#region Class: EventTrackingPostProcess

	/// <summary>
	/// EventTrackingPostProcess replacing class.
	/// </summary>
	public class EventTrackingPostProcess : IGeneratedWebFormPostProcessHandler
	{

		#region Methods: Private

		private void InternalPostBpmSessionId(UserConnection userConnection, Entity leadEntity) {
			var sessionId = leadEntity.GetTypedColumnValue<Guid>("BpmSessionId");
			var knownSessionRequest = new KnownSessionRequest();
			var eventTrackingLogin = SysSettings.GetValue(userConnection,
				"EventTrackingLogin").ToString();
			var eventTrackingPassword = SysSettings.GetValue(userConnection,
				"EventTrackingPassword").ToString();
			var eventTrackingApiKey = SysSettings.GetValue(userConnection,
				"EventTrackingApiKey").ToString();
			var eventTrackingWebAppUrl = SysSettings.GetValue(userConnection,
				"EventTrackingWebAppUrl").ToString();
			if (string.IsNullOrEmpty(eventTrackingWebAppUrl) || 
			    string.IsNullOrEmpty(eventTrackingLogin) || string.IsNullOrEmpty(eventTrackingPassword) ||
				string.IsNullOrEmpty(eventTrackingApiKey) || string.IsNullOrEmpty(eventTrackingWebAppUrl)) {
				return;
			}
			eventTrackingWebAppUrl += "/SetKnownSession?format=json";
			knownSessionRequest.SetBasicAuth(eventTrackingLogin, eventTrackingPassword);
			knownSessionRequest.SetRequestMethod("POST");
			knownSessionRequest.ApiKey = eventTrackingApiKey;
			knownSessionRequest.SessionId = sessionId;
			knownSessionRequest.Execute(eventTrackingWebAppUrl);
		}
		
		#endregion
		
		#region Methods: Public

		/// <summary>
		/// Post cookie to tracking service.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		/// <param name="leadEntity">Lead entity.</param>
		[Obsolete("7.8.3 | Use BPMSoft.Configuration.GeneratedWebFormService.EventTrackingPostProcess.Execute")]
		public void PostBpmSessionId(UserConnection userConnection, Entity leadEntity) {
			InternalPostBpmSessionId(userConnection, leadEntity);
		}

		/// <summary>
		/// Executes the post processing for specified landing page.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="landingId">The landing identifier.</param>
		/// <param name="formData">The form data from POST-request.</param>
		/// <param name="entityId">The entity identifier.</param>
		public void Execute(UserConnection userConnection, Guid landingId, FormFieldsData[] formData, Guid entityId) {
			var leadEntity = new Lead(userConnection);
			if (!leadEntity.FetchFromDB(entityId)) {
				return;
			}
			InternalPostBpmSessionId(userConnection, leadEntity);
		}

		#endregion

	}

	#endregion

}

