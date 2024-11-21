namespace BPMSoft.Configuration.SocialLeadGen
{
	using System.Collections.Generic;
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Web.Common;
	using BPMSoft.Common;
	using BPMSoft.Core.Process;
	using BPMSoft.Core;

	#region Class: SocialLeadGenWebhookService

	/// <summary>
	/// Service for receiving webhooks.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SocialLeadGenWebhookService : BaseService, IReadOnlySessionState
	{

		#region Constants: Private

		private const string WebhookProcessingProcessName = "SocialLeadGeneration_WebhookProcessing";
		private const string NotificationProcessName = "SocialLeadGeneration_ProcessingIncomingMessages";

		#endregion

		#region Properties: Private

		private UserConnection SysUserConnection {
			get {
				return AppConnection.SystemUserConnection;
			}
		}

		#endregion

		#region Methods: Private

		private void RunWebhookProcessingProcess(string matadata) {
			var processExecutor = SysUserConnection.ProcessEngine.ProcessExecutor;
			var nameValues = new Dictionary<string, string> {
				["WebhookMetadata"] = matadata
			};
			processExecutor.Execute(WebhookProcessingProcessName, nameValues);
		}

		private void RunMessageNotifyProcess(string notifyData) {
			var processExecutor = SysUserConnection.ProcessEngine.ProcessExecutor;
			var nameValues = new Dictionary<string, string> {
				["InputMessage"] = notifyData
			};
			processExecutor.Execute(NotificationProcessName, nameValues);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles incoming webhooks.
		/// </summary>
		/// <param name="stream">Request body.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "LeadNotify", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void LeadNotify(Stream stream) {
			RunWebhookProcessingProcess(stream.GetContent());
		}

		/// <summary>
		/// Handles incoming messages notify.
		/// </summary>
		/// <param name="stream">Request body.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "MessageNotify", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void MessageNotify(Stream stream) {
			RunMessageNotifyProcess(stream.GetContent());
		}

		/// <summary>
		/// Ping BPMStudio instance.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Ping", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string Ping() {
			return "PONG";
		}

		#endregion

	}

	#endregion

}

