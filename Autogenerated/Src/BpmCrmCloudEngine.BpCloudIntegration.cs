namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Web.Http.Abstractions;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.CESResponses;

	#region Class: BpmCrmCloudEngine

	/// <summary>
	/// Implements tools for integration with bpmcrm cloud.
	/// </summary>
	public class BpmCrmCloudEngine
	{
		#region Fields: Private

		private ICESApi _serviceApi;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public BpmCrmCloudEngine(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Instance of <see cref="UserConnection"/>.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Url of the remote service.
		/// </summary>
		public string ServiceUrl =>
			(string)Core.Configuration.SysSettings.GetValue(UserConnection, "CloudServicesBaseUrl");

		/// <summary>
		/// Api to interact with a remote service.
		/// </summary>
		public virtual ICESApi ServiceApi {
			get {
				if (_serviceApi == null) {
					string authKey = GetAPIKey(UserConnection);
					_serviceApi = new CESApi(authKey, ServiceUrl);
				}
				return _serviceApi;
			}
		}

		#endregion

		#region Methods: Private

		private static string GetLczStringValue(UserConnection userConnection, string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(userConnection.Workspace.ResourceStorage,
				"BpmCrmCloudEngine", localizableStringName);
			string value = localizableString.Value;
			if (value.IsNullOrEmpty()) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Authenticate cloud key in request.
		/// </summary>
		/// <param name="request">Instance of <see cref="HttpRequest"/> current request.</param>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/> current request.</param>
		/// <returns>Authentication result <see cref="BPMSoft.Configuration.AuthenticationResult"/>.</returns>
		public static AuthenticationResult Authenticate(HttpRequest request, UserConnection userConnection) {
			var bpmCrmSignatureKey = (string)BPMSoft.Core.Configuration.SysSettings.GetValue(userConnection, "BpmCrmSignatureKey", "bpmcrm-signature");
			var authenticationResult = new AuthenticationResult();
			if (!request.Headers.AllKeys.Contains(bpmCrmSignatureKey, StringComparer.InvariantCultureIgnoreCase)) {
				var signatureNotFoundMessage = GetLczStringValue(userConnection, "SignatureNotFoundMessage");
				authenticationResult.Message = string.Format(signatureNotFoundMessage, bpmCrmSignatureKey);
				return authenticationResult;
			}
			string incomingAuthKey = request.Headers[bpmCrmSignatureKey];
			string cloudServicesAuthKey = GetAuthKey(userConnection);
			if (string.IsNullOrEmpty(cloudServicesAuthKey)) {
				authenticationResult.Message = GetLczStringValue(userConnection, "BpmCrmHasNoAuthKeyMessage");
			} else if (string.IsNullOrEmpty(incomingAuthKey)) {
				authenticationResult.Message = GetLczStringValue(userConnection, "RequestHasNoAuthKeyMessage");
			} else if (!string.Equals(incomingAuthKey, cloudServicesAuthKey)) {
				authenticationResult.Message = GetLczStringValue(userConnection, "WrongAuthKeyMessage");
			} else {
				authenticationResult.Message = GetLczStringValue(userConnection, "SuccessAuthenticationMessage");
				authenticationResult.Success = true;
			}
			return authenticationResult;
		}

		/// <summary>
		/// Gets the API key.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <returns>Api key withoud leading and trailing whitespaces.</returns>
		public static string GetAPIKey(UserConnection userConnection) {
			var key = (string)Core.Configuration.SysSettings.GetValue(userConnection, "CloudServicesAPIKey");
			if (key.IsNotNullOrEmpty()) {
				key = key.Trim();
			}
			return key;
		}

		public static string GetAuthKey(UserConnection userConnection) {
			return (string)Core.Configuration.SysSettings.GetValue(userConnection, "CloudServicesAuthKey");
		}

		/// <summary>
		/// Returns account info.
		/// </summary>
		/// <returns>Account info.</returns>
		public virtual AccountInfo AccountInfo() {
			string authKey = GetAuthKey(UserConnection);
			return ServiceApi.AccountInfo(authKey);
		}

		/// <summary>
		/// Adds sender domains.
		/// </summary>
		/// <param name="domain">Domain.</param>
		/// <returns>Sender domains info.</returns>
		public virtual CloudSenderDomainsInfo AddSenderDomain(string domain) {
			return ServiceApi.AddSenderDomainsInfo(domain);
		}

		/// <summary>
		/// Adds the sender domain.
		/// </summary>
		/// <param name="addSenderDomainsInfoRequest">The add sender domains information request.</param>
		public CloudSenderDomainsInfo AddSenderDomain(AddSenderDomainsInfoRequest addSenderDomainsInfoRequest) {
			return ServiceApi.AddSenderDomainsInfo(addSenderDomainsInfoRequest);
		}

		/// <summary>
		/// Authenticate cloud key in request.
		/// </summary>
		/// <param name="request">Instance of <see cref="HttpRequest"/> current request.</param>
		/// <returns>Authentication result <see cref="BPMSoft.Configuration.AuthenticationResult"/>.</returns>
		public virtual AuthenticationResult Authenticate(HttpRequest request) {
			return Authenticate(request, UserConnection);
		}

		/// <summary>
		/// Gets checked emails from provider.
		/// </summary>
		/// <param name="emails">Enumerable of emails.</param>
		public virtual CheckedEmailResponse GetCheckedEmails(IEnumerable<string> emails) {
			return ServiceApi.GetCheckedEmails(emails);
		}

		/// <summary>
		/// Returns sender domains info by the provider name.
		/// </summary>
		/// <param name="senderDomainsInfoRequest">The sender domains information request.</param>
		/// <returns>Sender domains info.</returns>
		public virtual CloudSenderDomainsInfo GetSenderDomainsInfo(SenderDomainsInfoRequest senderDomainsInfoRequest) {
			senderDomainsInfoRequest.ApiKey = ServiceApi.ApiKey;
			return ServiceApi.SenderDomainsInfo(senderDomainsInfoRequest);
		}

		/// <summary>
		/// Registers the sender's domain.
		/// </summary>
		/// <param name="domain">The sender's domain.</param>
		public virtual void RegisterSenderDomain(string domain) {
			CloudSenderDomainsInfo domainInfo = SenderDomainsInfo();
			if (!domainInfo.Domains.Exists(x => x.Domain == domain)) {
				AddSenderDomain(domain);
			}
		}

		/// <summary>
		/// Returns sender domains info.
		/// </summary>
		/// <returns>Sender domains info.</returns>
		public virtual CloudSenderDomainsInfo SenderDomainsInfo() {
			return ServiceApi.SenderDomainsInfo();
		}

		/// <summary>
		/// Updates user settings.
		/// </summary>
		/// <param name="webHookAppDomain">WebHooks app domain.</param>
		/// <returns>Account info.</returns>
		public virtual AccountInfo UpdateUserSettings(string webHookAppDomain, string authKey) {
			return ServiceApi.UpdateUserSettings(webHookAppDomain, authKey);
		}

		/// <summary>
		/// Gets <see cref="SenderValidationInfo"/> with separate emails enums.
		/// </summary>
		/// <param name="emails">Enumerable of emails.</param>
		public virtual SenderValidationInfo ValidateSender(IEnumerable<string> emails) {
			var request = new ValidateSenderRequest {
				ApiKey = ServiceApi.ApiKey,
				EmailList = emails
			};
			return ServiceApi.ValidateSenderForProvider(request);
		}

		#endregion

	}

	#endregion

}

