namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Text;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using RestSharp;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Monitoring;

	#region Interface: IEmailMiningServiceProxy

	/// <summary>
	/// Interface for calling service of email mining.
	/// </summary>
	public interface IEmailMiningServiceProxy
	{

		#region Methods: Public

		/// <summary>
		/// Applies batch request for set of emails.
		/// </summary>
		/// <param name="emails">List of emails for processing.</param>
		/// <returns>Dictionary with email as key and found data as value.</returns>
		Dictionary<Entity, GetEmailEntitiesResponse> BatchCall(IEnumerable<Entity> emails);

		#endregion

	}

	#endregion

	#region Class: EmailMiningServiceProxy

	/// <summary>
	/// Base implementation of <see cref="IEmailMiningServiceProxy"/>.
	/// </summary>
	[DefaultBinding(typeof(IEmailMiningServiceProxy))]
	public class EmailMiningServiceProxy : IEmailMiningServiceProxy
	{

		#region Constants: Private

		private const string CloudServicesAPIKey = "CloudServicesAPIKey";
		private const string ServiceEmailParsingMethod = "getEmailEntitiesBatch";
		private const string EmailMiningUnreachableMetricName = "email_mining_connect_error_count";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("EmailMining");
		private readonly UserConnection _userConnection;
		private readonly IRestClient _httpClient;
		private readonly TimeSpan _requestTimeout = TimeSpan.FromMinutes(8);
		private readonly IMetricReporter _metricReporter = ClassFactory.Get<IMetricReporter>();

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes instance of proxy to email analysis web service.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public EmailMiningServiceProxy(UserConnection userConnection) {
			_userConnection = userConnection;
			if (!ClassFactory.TryGet("EmailMiningServiceProxyRestClient", out _httpClient)) {
				_httpClient = RestClientFactory.CreateRestClient();
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets the API key.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <returns>Api key withoud leading and trailing whitespaces.</returns>
		private static string GetAPIKey(UserConnection userConnection) {
			var key = (string)SysSettings.GetValue(userConnection, "CloudServicesAPIKey");
			if (key.IsNotNullOrEmpty()) {
				key = key.Trim();
			}
			return key;
		}

		private void CheckRequiredParameters(out string serviceUrl, out string apiKey) {
			serviceUrl = SysSettings.GetValue(_userConnection,
				EmailMiningConsts.TextParsingServiceSysSetting, string.Empty);
			if (serviceUrl.IsNullOrEmpty()) {
				_metricReporter.Gauge(EmailMiningUnreachableMetricName, 1);
				throw new IncorrectConfigurationException(EmailMiningConsts.TextParsingServiceSysSetting);
			}
			apiKey = GetAPIKey(_userConnection);
			if (apiKey.IsNullOrEmpty()) {
				_metricReporter.Gauge(EmailMiningUnreachableMetricName, 1);
				throw new IncorrectConfigurationException(CloudServicesAPIKey);
			}
		}

		private GetEmailEntitiesRequest PrepareRequest(Entity emailEntity, string apiKey) {
			string emailBody = emailEntity.GetTypedColumnValue<string>("Body");
			string msgType = emailEntity.GetTypedColumnValue<bool>("IsHtmlBody") ? "html" : "plain";
			string sender = emailEntity.GetTypedColumnValue<string>("Sender");
			string senderEmail = sender.ExtractEmailAddress();
			var request = new GetEmailEntitiesRequest {
				EmailBody = emailBody,
				MsgType = msgType,
				ApiKey = apiKey,
				SenderEmail = senderEmail
			};
			return request;
		}

		private void LogBatchResponseSummary(Dictionary<Entity, GetEmailEntitiesResponse> result) {
			StringBuilder logMessage = new StringBuilder(Environment.NewLine);
			int totalResponses = result.Count;
			int totalSucceeded = result.Count(response => response.Value.IsSuccess);
			int totalFailed = result.Count(response => response.Value.IsFailure);
			logMessage.AppendLine("Batch request summary >>>");
			logMessage.AppendFormat("Total responses: {0}{1}", totalResponses, Environment.NewLine);
			logMessage.AppendFormat("Succeeded:       {0}{1}", totalSucceeded, Environment.NewLine);
			logMessage.AppendFormat("Failed:          {0}{1}", totalFailed, Environment.NewLine);
			if (totalFailed > 0) {
				logMessage.AppendLine("Details of errors:");
				IEnumerable<string> errorMessages = result.Where(kv => kv.Value.IsFailure)
					.Select(kv => string.Format("Email '{0}'. Error message: {1}.",
						kv.Key.PrimaryColumnValue, kv.Value.ErrorMessage));
				logMessage.AppendLine(string.Join(Environment.NewLine, errorMessages));
				logMessage.Append("Batch request summary <<<");
				_log.Error(logMessage.ToString());
			} else {
				logMessage.Append("Batch request summary <<<");
				_log.Info(logMessage.ToString());
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Applies batch request for set of emails.
		/// </summary>
		/// <param name="emails">List of email entities for processing. Entities must be loaded with
		/// Id, Body, IsHtmlBody, Sender columns.</param>
		/// <returns>Dictionary with email as key and found data as value.</returns>
		/// <exception cref="BPMSoft.Common.ArgumentNullOrEmptyException">Throws when emails are null.</exception>
		/// <exception cref="IncorrectConfigurationException">Throws if configuration is wrong.</exception>
		public Dictionary<Entity, GetEmailEntitiesResponse> BatchCall(IEnumerable<Entity> emails) {
			var result = new Dictionary<Entity, GetEmailEntitiesResponse>();
			emails.CheckArgumentNull("emails");
			CheckRequiredParameters(out string serviceUrl, out string apiKey);
#if NETFRAMEWORK
			_httpClient.BaseUrl = serviceUrl;
#else
			_httpClient.BaseUrl = new Uri(serviceUrl);
#endif
			_httpClient.Timeout = (int)_requestTimeout.TotalMilliseconds;
			_httpClient.AddDefaultHeader("ApiKey", apiKey);
			GetEmailEntitiesRequest[] requests = emails.Select(email => PrepareRequest(email, apiKey)).ToArray();
			IRestRequest batchRequest = _httpClient.CreateJsonRequest(ServiceEmailParsingMethod, requests);
			IRestResponse batchResponse = _httpClient.Post(batchRequest);
			var batchResponseStatusCode = (int)batchResponse.StatusCode;
			if (batchResponseStatusCode >= 400 || batchResponseStatusCode == 0) {
				if (batchResponseStatusCode != 500) {
					_metricReporter.Gauge(EmailMiningUnreachableMetricName, 1);
				}
				switch (batchResponse.StatusCode) {
					case 0:
						if (batchResponse.ErrorException is UriFormatException) {
							throw new IncorrectConfigurationException(EmailMiningConsts.TextParsingServiceSysSetting,
								serviceUrl, batchResponse.ErrorMessage);
						} else {
							_log.ErrorFormat("Request cannot be completed by RestSharp. Error: {0}",
								batchResponse.ErrorMessage);
							return result;
						}
					case HttpStatusCode.Unauthorized:
						throw new IncorrectConfigurationException(CloudServicesAPIKey, apiKey);
					case HttpStatusCode.NotFound:
						throw new IncorrectConfigurationException(EmailMiningConsts.TextParsingServiceSysSetting,
							serviceUrl, "Text Mining service not found");
					default:
						string error = batchResponse.ErrorMessage.IsNullOrEmpty()
							? batchResponse.Content
							: batchResponse.ErrorMessage;
						_log.ErrorFormat("Cannot process email pack. Response code: {0}({1}). Error: {2}",
							batchResponse.StatusCode, (int)batchResponse.StatusCode, error);
						return result;
				}
			} else {
				_metricReporter.Gauge(EmailMiningUnreachableMetricName, 0);
			}
			List<GetEmailEntitiesResponse> responses;
			try {
				responses = JsonConvert.DeserializeObject<List<GetEmailEntitiesResponse>>(batchResponse.Content)
					.ToList();
			} catch (JsonSerializationException) {
				throw new IncorrectConfigurationException(EmailMiningConsts.TextParsingServiceSysSetting,
					serviceUrl, "OK, but malformed batch response received - Text Mining API version mismatch.");
			}
			if (responses.Count != requests.Length) {
				_log.ErrorFormat(
					"Batch request corrupted! Number of requests ({0}) is not equal to number of responses ({1}).",
					requests.Length, responses.Count);
				return result;
			}
			if (responses.All(response => response.Code == (int)HttpStatusCode.OK && response.TextEntities == null)) {
				throw new IncorrectConfigurationException(EmailMiningConsts.TextParsingServiceSysSetting,
					serviceUrl, "OK, but malformed responses received - Text Mining API version mismatch.");
			}
			result = emails
				.Zip(responses, (email, response) => new { email, response })
				.ToDictionary(pair => pair.email, pair => pair.response);
			LogBatchResponseSummary(result);
			return result;
		}

		#endregion

	}

	#endregion

}

