namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.CESResponses;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: BpmCrmCloudService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class BpmCrmCloudService : BaseService, IReadOnlySessionState
	{

		#region Fields: Private

		private BpmCrmCloudEngine _cloudEngine;

		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public BpmCrmCloudService() { }

		public BpmCrmCloudService(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private BpmCrmCloudEngine CloudEngine {
			get {
				if (_cloudEngine == null) {
					_cloudEngine = ClassFactory.Get<BpmCrmCloudEngine>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _cloudEngine;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns account info.
		/// </summary>
		/// <returns>Account info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AccountInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "AccountInfo")]
		public AccountInfo AccountInfo() {
			return CloudEngine.AccountInfo();
		}

		/// <summary>
		/// Adds sender domains info.
		/// </summary>
		/// <param name="domain">Domain.</param>
		/// <returns>Sender domains info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "DomainsInfo")]
		public CloudSenderDomainsInfo AddSenderDomain(string domain) {
			return CloudEngine.AddSenderDomain(domain);
		}

		/// <summary>
		/// Adds sender domains info for the provider.
		/// </summary>
		/// <param name="addSenderDomainsInfoRequest">The add sender domains information request.</param>
		/// <returns>Sender domains info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddSenderDomainForProvider", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "DomainsInfo")]
		public CloudSenderDomainsInfo AddSenderDomainForProvider(AddSenderDomainsInfoRequest addSenderDomainsInfoRequest) {
			return CloudEngine.AddSenderDomain(addSenderDomainsInfoRequest);
		}

		/// <summary>
		/// Gets checked emails from provider.
		/// </summary>
		/// <param name="emails">Enumerable of emails.</param>
		/// <returns>Sender domains info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "GetCheckedEmails")]
		public CheckedEmailResponse GetCheckedEmails(IEnumerable<string> emails) {
			return CloudEngine.GetCheckedEmails(emails);
		}

		/// <summary>
		/// Returns sender domains info.
		/// </summary>
		/// <returns>Sender domains info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SenderDomainsInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "DomainsInfo")]
		public CloudSenderDomainsInfo SenderDomainsInfo() {
			return CloudEngine.SenderDomainsInfo();
		}

		/// <summary>
		/// Returns sender domains info by the provider name.
		/// </summary>
		/// <param name="senderDomainsInfoRequest">The sender domains information request.</param>
		/// <returns>Sender domains info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSenderDomainsInfoByProvider", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "DomainsInfo")]
		public CloudSenderDomainsInfo GetSenderDomainsInfoByProvider(SenderDomainsInfoRequest senderDomainsInfoRequest) {
			return CloudEngine.GetSenderDomainsInfo(senderDomainsInfoRequest);
		}

		/// <summary>
		/// Updates user settings.
		/// </summary>
		/// <param name="webHookAppDomain">WebHooks app domain.</param>
		/// <returns>Account info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateUserSettings", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "AccountInfo")]
		public AccountInfo UpdateUserSettings(string webHookAppDomain, string authKey) {
			return CloudEngine.UpdateUserSettings(webHookAppDomain, authKey);
		}

		/// <summary>
		/// Gets <see cref="SenderValidationInfo"/> with separate emails enums.
		/// </summary>
		/// <param name="emails">Enumerable of emails.</param>
		/// <returns>Sender domains info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "ValidateSender")]
		public SenderValidationInfo ValidateSender(IEnumerable<string> emails) {
			return CloudEngine.ValidateSender(emails);
		}

		#endregion

	}

	#endregion

}

