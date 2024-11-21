namespace BPMSoft.Configuration.CES
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.CESResponses;

	#region Class: CESApi

	/// <summary>
	/// Introduces API for Cloud Email Service.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.CES.ICESApi"/>
	public class CESApi : ICESApi
	{

		#region Constants: Private

		private const string AccountInfoApiPath = "/account/info.json";
		private const string AddSenderDomainsInfoApiPath = "/account/mailing/sender-domains/add.json";
		private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
		private const string GetCheckedEmailsApiPath = "/account/mailing/checked-email.json";
		private const string PingApiPath = "/users/ping.json";
		private const string SenderDomainsInfoApiPath = "/account/mailing/sender-domains.json";
		private const string SendMessageApiPath = "/messages/send.json";
		private const string SendTemplateApiPath = "/messages/send-template.json";
		private const string UpdateUserSettingsApiPath = "/account/update-user-settings.json";
		private const string ValidateSenderApiPath = "/users/validate";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CESApi"/> class.
		/// </summary>
		/// <param name="apiKey">
		/// The API Key received from CESApp
		/// </param>
		/// <param name="baseUrl">
		/// The base url.
		/// </param>
		public CESApi(string apiKey, string baseUrl) {
			ApiKey = apiKey;
			BaseUrl = baseUrl;
			ServiceClient = new WebServiceClient(baseUrl) {
				ContentType = RequestContentType.Json
			};
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// The main rest client for use throughout the whole app.
		/// </summary>
		public IWebServiceClient ServiceClient { get; set; }

		/// <summary>
		/// The Api Key for the project received from the CESApp website.
		/// </summary>
		public string ApiKey { get; }

		/// <summary>
		/// Service base url.
		/// </summary>
		public string BaseUrl { get; set; }

		/// <summary>
		/// Service base secure url.
		/// </summary>
		public string BaseSecureUrl { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns the mailing account info.
		/// </summary>
		/// <param name="authKey"></param>
		/// <returns>The <see cref="AccountInfo"/>.</returns>
		public AccountInfo AccountInfo(string authKey) {
			var request = new AccountInfoRequest {
				AuthKey = authKey,
				ApiKey = ApiKey
			};
			return ServiceClient.Post<AccountInfo>(request, AccountInfoApiPath);
		}

		/// <summary>
		/// Adds the sender domain.
		/// </summary>
		/// <param name="domain">The domain.</param>
		/// <returns>Information about added domain from provider. <see cref="CloudSenderDomainsInfo"/></returns>
		public CloudSenderDomainsInfo AddSenderDomainsInfo(string domain) {
			var request = new AddSenderDomainsInfoRequest {
				ApiKey = ApiKey,
				Domain = domain
			};
			return ServiceClient.Post<CloudSenderDomainsInfo>(request, AddSenderDomainsInfoApiPath);
		}

		/// <summary>
		/// Add a new template.
		/// </summary>
		/// <param name="name">The name for the new template - must be unique.</param>
		/// <param name="fromEmail">A default sending address for emails sent using this template.</param>
		/// <param name="fromName">A default from name to be used.</param>
		/// <param name="subject">A default subject line to be used.</param>
		/// <param name="code">
		/// The HTML code for the template with <c>mc:edit</c> attributes for
		/// the editable elements.
		/// </param>
		/// <param name="text">A default text part to be used when sending with this template.</param>
		/// <param name="emailId">Unique id of email.</param>
		/// <param name="images">List of inline attachments.</param>
		/// <param name="checksum">Current template checksum.</param>
		/// <param name="replicaId">The replica identifier.</param>
		/// <returns>
		/// A <see cref="BaseCloudResponse"/> object.
		/// </returns>
		public BaseCloudResponse AddTemplate(string name, string fromEmail, string fromName, string subject, string code,
			string text, Guid emailId, IEnumerable<image> images = null, string checksum = null,
			string replicaId = null) {
			var request = new AddTemplateRequest {
				Name = name,
				FromEmail = fromEmail,
				FromName = fromName,
				Subject = subject,
				Code = code,
				Text = text,
				EmailId = emailId,
				Images = images,
				ReplicaChecksum = checksum,
				ReplicaId = replicaId
			};
			return this.AddTemplate(request, ServiceClient);
		}

		/// <summary>
		/// Gets the checked emails by api key.
		/// </summary>
		/// <param name="emails">Enumerable of emails.</param>
		/// <returns></returns>
		public CheckedEmailResponse GetCheckedEmails(IEnumerable<string> emails) {
			var request = new CheckedEmailRequest {
				ApiKey = ApiKey,
				Emails = emails
			};
			return ServiceClient.Post<CheckedEmailResponse>(request, GetCheckedEmailsApiPath);
		}

		/// <summary>
		/// Validate an API key and respond to a ping
		/// </summary>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public string Ping() {
			ServiceClient.ContentType = RequestContentType.Json;
			var request = new BaseServiceRequest {
				ApiKey = ApiKey
			};
			return ServiceClient.Post<string>(request, PingApiPath);
		}

		/// <summary>
		/// Gets the list of sender's domains from provider.
		/// </summary>
		/// <returns>
		/// The <see cref="CloudSenderDomainsInfo"/>.
		/// </returns>
		public CloudSenderDomainsInfo SenderDomainsInfo() {
			var request = new BaseServiceRequest {
				ApiKey = ApiKey
			};
			return ServiceClient.Post<CloudSenderDomainsInfo>(request, SenderDomainsInfoApiPath);
		}

		/// <summary>
		/// Sends a new transactional message through CES.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="emailId"></param>
		/// <param name="sendAt">The send_at.</param>
		/// <returns>
		/// <see cref="BaseCloudResponse"/>
		/// </returns>
		public BaseCloudResponse SendMessage(EmailMessage message, Guid emailId, DateTime sendAt = new DateTime()) {
			sendAt = sendAt.ToUniversalTime();
			var request = new SendMessageRequest {
				ApiKey = ApiKey,
				Message = message
			};
			if (emailId != Guid.Empty) {
				request.EmailId = emailId;
			}
			request.SendAt = sendAt == DateTime.MinValue ? string.Empty : sendAt.ToString(DateTimeFormat);
			return ServiceClient.Post<BaseCloudResponse>(request, SendMessageApiPath);
		}

		/// <summary>
		/// Send a new transactional message through CES using a template
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="templateName"></param>
		/// <param name="templateContents"></param>
		/// <param name="emailId">Identifier of email.</param>
		/// <param name="sendAt">The send_at.</param>
		/// <returns>
		/// <see cref="BaseCloudResponse"/>
		/// </returns>
		public BaseCloudResponse SendTemplate(EmailMessage message, string templateName,
			IEnumerable<TemplateContent> templateContents, Guid emailId, DateTime sendAt = new DateTime()) {
			sendAt = sendAt.ToUniversalTime();
			var request = new SendTemplateRequest {
				ApiKey = ApiKey,
				Message = message,
				TemplateName = templateName,
				EmailId = emailId,
				SendAt = sendAt == DateTime.MinValue ? string.Empty : sendAt.ToString(DateTimeFormat)
			};
			return ServiceClient.Post<BaseCloudResponse>(request, SendTemplateApiPath);
		}

		/// <summary>
		/// Updates the user settings.
		/// </summary>
		/// <param name="webHookAppDomain"></param>
		/// <param name="authKey"></param>
		/// <returns>
		/// The <see cref="AccountInfo"/>.
		/// </returns>
		public AccountInfo UpdateUserSettings(string webHookAppDomain, string authKey) {
			var request = new UpdateUserSettingsRequest {
				ApiKey = ApiKey,
				AuthKey = authKey,
				WebHookAppDomain = webHookAppDomain
			};
			return ServiceClient.Post<AccountInfo>(request, UpdateUserSettingsApiPath);
		}

		/// <summary>
		/// Validates sender's emails and send validation emails if needed.
		/// </summary>
		/// <param name="emails">List of sender's emails for validation</param>
		/// <returns>
		/// Lists of incorrect and validated emails
		/// </returns>
		public SenderValidationInfo ValidateSender(IEnumerable<string> emails) {
			var request = new ValidateSenderRequest {
				EmailList = emails,
				ApiKey = ApiKey
			};
			return ServiceClient.Post<SenderValidationInfo>(request, ValidateSenderApiPath);
		}

		#endregion

	}

	#endregion

	#region Class CESApiExtension
	
	/// <summary>
	/// Provides extensions for Cloud email service API methods for <see cref="ICESApi"/>.
	/// </summary>
	public static class CESApiExtension
	{
		private const string AddSenderDomainsInfoApiPath = "/account/mailing/sender-domains/add.json";
		private const string AddTemplateApiPath = "/templates/add.json";
		private const string GetThrottlingSchedulesApiPath = "/throttling/get-schedules";
		private const string StopEmailApiPath = "/messages/stop.json";
		private const string ThrottlingScheduleApiPath = "/throttling/schedule.json";
		private const string LicenceInformationApiPath = "/license/get-info";
		private const string MessagesUpdateScheduleApiPath = "/messages/update-schedule";
		private const string GetAvailableProvidersApiPath = "/account/mailing/providers";
		private const string ValidateSenderApiPath = "/users/validate";
		private const string SenderDomainsInfoApiPath = "/account/mailing/sender-domains.json";
		private const string UpdateAccountMailingProviderApiPath = "/account/update-mailing-provider-settings";

		private static IWebServiceClient GetServiceClient(ICESApi cesApi, IWebServiceClient serviceClient = null) {
			if (serviceClient != null) {
				return serviceClient;
			}
			if (cesApi is CESApi cesApiInstance) {
				return cesApiInstance.ServiceClient;
			}
			return new WebServiceClient(cesApi.BaseUrl) {
				ContentType = RequestContentType.Json
			};
		}

		/// <summary>
		/// Adds the sender domains information.
		/// </summary>
		/// <param name="cesApi">The ces API.</param>
		/// <param name="request">The request.</param>
		/// <param name="serviceClient">The service client.</param>
		public static CloudSenderDomainsInfo AddSenderDomainsInfo(this ICESApi cesApi, AddSenderDomainsInfoRequest request,
			IWebServiceClient serviceClient = null) {
			request.ApiKey = cesApi.ApiKey;
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			return internalServiceClient.Post<CloudSenderDomainsInfo>(request, AddSenderDomainsInfoApiPath);
		}

		/// <summary>
		/// Sends request to add email template.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request">Template add request.</param>
		/// <param name="serviceClient">Web service client. If Null - uses default instance.</param>
		/// <returns></returns>
		public static BaseCloudResponse AddTemplate(this ICESApi cesApi, AddTemplateRequest request, 
				IWebServiceClient serviceClient = null) {
			request.ApiKey = cesApi.ApiKey;
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			return 	internalServiceClient.Post<BaseCloudResponse>(request, AddTemplateApiPath);
		}

		/// <summary>
		/// Connects mailing provider for account.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request">Info about cloud account services.</param>
		/// <param name="serviceClient">Web service client. If Null - uses default instance.</param>
		/// <returns>The <see cref="BaseCloudResponse"/> with code, status and message.</returns>
		public static BaseCloudResponse ConnectMailingProvider(this ICESApi cesApi, 
			UpdateCloudAccountServiceRequest request, IWebServiceClient serviceClient = null) {
			request.ApiKey = cesApi.ApiKey;
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			var response = internalServiceClient.Post<BaseCloudResponse>(request, UpdateAccountMailingProviderApiPath);
			return response;
		}

		/// <summary>
		/// Gets account's license information by given API key.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request">Base cloud request with API key.</param>
		/// <param name="serviceClient">Web service client. If Null - uses default instance.</param>
		/// <returns></returns>
		public static EmailLicenseInformationResponse GetAccountLicenseInformation(this ICESApi cesApi,
				BaseServiceRequest request, IWebServiceClient serviceClient = null) {
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			return internalServiceClient.Post<EmailLicenseInformationResponse>(request, LicenceInformationApiPath);
		}

		/// <summary>
		/// Gets throttling schedules for the current user by the specified strategy id.
		/// </summary>
		/// <param name="cesApi">Extending instance <see cref="ICESApi"/>.</param>
		/// <param name="throttlingScheduleRequest">Request instance with the required service id.</param>
		/// <returns>The <see cref="GetThrottlingSchedulesResponse"/> with throttling schedules.</returns>
		public static GetThrottlingSchedulesResponse GetThrottlingSchedules(this ICESApi cesApi,
			GetThrottlingScheduleRequest throttlingScheduleRequest) {
			var internalServiceClient = GetServiceClient(cesApi, null);
			return internalServiceClient.Post<GetThrottlingSchedulesResponse>(throttlingScheduleRequest, GetThrottlingSchedulesApiPath);
		}
		
		/// <summary>
		/// Sends request to set new email schedule.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request">Request instance with new email schedule <see cref="UpdateEmailScheduleRequest"/></param>
		/// <returns>The <see cref="BaseCloudResponse"/>.</returns>
		public static BaseCloudResponse UpdateEmailSchedule(this ICESApi cesApi, UpdateEmailScheduleCloudRequest request) {
			request.ApiKey = cesApi.ApiKey;
			var internalServiceClient = GetServiceClient(cesApi);
			return internalServiceClient.Post<BaseCloudResponse>(request, MessagesUpdateScheduleApiPath);
		}

		/// <summary>
		/// Sends request to stop bulk email.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="bulkEmailId">BulkEmail Id</param>
		/// <param name="serviceClient">Web service client. If Null - uses default instance.</param>
		/// <returns>The <see cref="BaseCloudResponse"/>.</returns>
		public static BaseCloudResponse StopBulkEmail(this ICESApi cesApi, Guid bulkEmailId,
			IWebServiceClient serviceClient = null) {
			var request = new StopEmailRequest {
				ApiKey = cesApi.ApiKey,
				EmailId = bulkEmailId
			};
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			return internalServiceClient.Post<BaseCloudResponse>(request, StopEmailApiPath);
		}
		
		/// <summary>
		/// Sends request to set new throttling schedule.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request">Request instance with new schedule <see cref="ThrottlingSchedule"/></param>
		/// <param name="serviceClient">Web service client. If Null - uses default instance.</param>
		/// <returns>The <see cref="BaseCloudResponse"/>.</returns>
		public static BaseCloudResponse SetThrottlingSchedule(this ICESApi cesApi, ThrottlingScheduleRequest request,
			IWebServiceClient serviceClient = null) {
			request.ApiKey = cesApi.ApiKey;
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			return internalServiceClient.Post<BaseCloudResponse>(request, ThrottlingScheduleApiPath);
		}
		
		/// <summary>
		/// Sends request to set new throttling schedule.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request">Request instance with new schedule <see cref="ThrottlingSchedule"/></param>
		/// <param name="serviceClient">Web service client. If Null - uses default instance.</param>
		/// <returns>The <see cref="GetAvailableProvidersResponse"/>.</returns>
		public static GetAvailableProvidersResponse GetAvailableProviders(this ICESApi cesApi, 
				IWebServiceClient serviceClient = null) {
			GetAvailableProvidersRequest request = new GetAvailableProvidersRequest {
				ApiKey = cesApi.ApiKey
			};
			var internalServiceClient = GetServiceClient(cesApi, serviceClient);
			return internalServiceClient.Post<GetAvailableProvidersResponse>(request, GetAvailableProvidersApiPath);
		}

		/// <summary>
		/// Validates sender's emails for stored ESP.
		/// </summary>
		/// <param name="cesApi">Extending instance.</param>
		/// <param name="request"><see cref="ValidateSenderRequest"/>Request with parameters provided.</param>
		/// <returns>
		/// Lists of incorrect and validated emails
		/// </returns>
		public static SenderValidationInfo ValidateSenderForProvider(this ICESApi cesApi, ValidateSenderRequest 
				request) {
			var serviceClient = GetServiceClient(cesApi);
			return serviceClient.Post<SenderValidationInfo>(request, ValidateSenderApiPath);
		}
		
		/// <summary>
		/// Gets the list of sender's domains from provider.
		/// </summary>
		/// <returns>
		/// The <see cref="CloudSenderDomainsInfo"/>.
		/// </returns>
		public static CloudSenderDomainsInfo SenderDomainsInfo(this ICESApi cesApi, SenderDomainsInfoRequest request) {
			var serviceClient = GetServiceClient(cesApi);
			return serviceClient.Post<CloudSenderDomainsInfo>(request, SenderDomainsInfoApiPath);
		}
	}
	
	#endregion

}

