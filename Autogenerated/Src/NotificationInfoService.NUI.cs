namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: NotificationInfoService

	/// <summary>
	/// Class of the data service for notification information.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class NotificationInfoService : BaseService, IReadOnlySessionState
	{
		#region Class: NotificationCountersServiceResponse

		public class NotificationCountersServiceResponse : ConfigurationServiceResponse
		{
			#region Properties: Public

			[DataMember(Name = "NotificationCounters")]
			public IDictionary<string, int> NotificationCounters { get; set; }

			#endregion
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Publish notification information.
		/// </summary>
		/// <param name="groupName">Group name</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[Obsolete("Use 7.12.0 | Method is deprecated. Use GetCounters instead")]
		public ConfigurationServiceResponse PublishNotificationInfo(string groupName = null) {
			IDictionary<string, object> parameters = null;
			var systemUserConnection = UserConnection.AppConnection.SystemUserConnection;
			var response = new ConfigurationServiceResponse();
			if (!string.IsNullOrEmpty(groupName)) {
				parameters = new Dictionary<string, object>();
				parameters.Add("type", "byGroup");
				parameters.Add("typeParameter", groupName);
			}
			try {
				NotificationInfoRunner runner = ClassFactory.ForceGet<NotificationInfoRunner>(
					typeof(NotificationInfoRunner).AssemblyQualifiedName,
					new ConstructorArgument("userConnection", systemUserConnection),
					new ConstructorArgument("parameters", parameters));
				runner.Run();
			}
			catch (Exception ex) {
				response.SetErrorInfo(ex);
			}

			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public NotificationCountersServiceResponse GetCounters() {
			var response = new NotificationCountersServiceResponse();
			var currentContact = UserConnection.CurrentUser.ContactId;
			INotificationCounterFactory factory = ClassFactory
				.Get<INotificationCounterFactory>(new ConstructorArgument("userConnection", UserConnection));
			INotificationCountHandler handler = ClassFactory
				.Get<INotificationCountHandler>(new ConstructorArgument("factory", factory));
			try {
				IDictionary<string, int> counters = 
					handler.GetNotificationCounters(currentContact, NotificationGroupConst.All);
				response.NotificationCounters = counters;
			}
			catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}
		
		#endregion
	}

	#endregion
}
