namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Specialized;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Text;
	using System.Security.Authentication;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Http.Abstractions;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;
	using HttpUtility = System.Web.HttpUtility;
	using System.Collections.Generic;
	using BPMSoft.Common;

	#region Class: CESWebHooksService

	///<summary>Service for receiving webhooks from the bpmcrm cloud.</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CESWebHooksService : BaseService
	{
		#region Constants: Private

		private const int StreamReaderBufferSize = 65536;
		private const string WebHooksParameterName = "webhooks";
		private const string WebHooksTypeParameterName = "type";
		private readonly string HandleWebHooksLogPattern = "[CESWebHooksService.HandleWebHooks] {0}";

		#endregion

		#region Properties: Private

		private UserConnection UserConnectionSafe {
			get {
#if NETFRAMEWORK
				return UserConnection ?? AppConnection.SystemUserConnection;
#else
				return AppConnection.SystemUserConnection;
#endif
			}
		}

		private bool WebHooksLoggingEnabled =>
			(bool)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnectionSafe, "EnableWebHooksLogging");

		#endregion

		#region Methods: Private

		private void InsertWebHook(string webHookEventJson, string webhookType) {
			byte[] compressedJson = MailingUtilities.Compress(webHookEventJson);
			var insert = new Insert(UserConnectionSafe)
				.Into("RawWebHooks")
				.Set("Id", Column.Parameter(Guid.NewGuid()))
				.Set("JsonData", Column.Parameter(compressedJson));
			if (webhookType != null && int.TryParse(webhookType, out var type)) {
				insert.Set("Type", Column.Parameter(type));
			}
			insert.Execute();
		}

		private void LogInfo(string message) {
			message = string.Format(HandleWebHooksLogPattern, message);
			MailingUtilities.WebHookLog.Info(message);
		}

		private void LogError(string message, Exception exception = null) {
			message = string.Format(HandleWebHooksLogPattern, message);
			if (exception == null) {
				MailingUtilities.WebHookLog.Error(message);
			} else {
				MailingUtilities.WebHookLog.Error(message, exception);
			}
		}

		private void LogError(Exception exception) {
			LogError(string.Empty, exception);
		}

		private NameValueCollection ParseQueryParameters(Stream stream) {
			var rawPostData = new StringBuilder();
			char[] buffer = new char[StreamReaderBufferSize];
			using (StreamReader streamReader = new StreamReader(stream)) {
				int readLength = 0;
				while ((readLength = streamReader.ReadBlock(buffer, 0, StreamReaderBufferSize)) > 0) {
					if (readLength < StreamReaderBufferSize) {
						char[] bufferLast = buffer.Take(readLength).ToArray();
						rawPostData.Append(bufferLast);
						bufferLast = null;
					} else {
						rawPostData.Append(buffer);
					}
				}
			}
			buffer = null;
			NameValueCollection queryParameters = HttpUtility.ParseQueryString(rawPostData.ToString(), Encoding.UTF8);
			rawPostData.Clear();
			return queryParameters;
		}

		private void Authenticate(HttpRequest request) {
			AuthenticationResult authenticationResult = BpmCrmCloudEngine.Authenticate(request, UserConnectionSafe);
			if (!authenticationResult.Success) {
				LogError(authenticationResult.Message);
				throw new InvalidCredentialException(authenticationResult.Message);
			}
		}

		private NameValueCollection GetRequestParametersFromForm(FormCollection form) {
			var nameValueCollection = new NameValueCollection();
			nameValueCollection.Add(WebHooksParameterName, form[WebHooksParameterName]);
			nameValueCollection.Add(WebHooksTypeParameterName, form[WebHooksTypeParameterName]);
			return nameValueCollection;
		}

		private NameValueCollection GetRequestParameters(Stream stream, HttpRequest request) {
#if NETFRAMEWORK
			return ParseQueryParameters(stream);
#else
			return GetRequestParametersFromForm(request.Form);
#endif
		}

		#endregion

		#region Methods: Protected

		protected virtual void PrepareCorsHeaders() {
#if NETFRAMEWORK
			WebOperationContext operationContext = WebOperationContext.Current;
			WebHeaderCollection outgoingResponseHeaders = operationContext.OutgoingResponse.Headers;
			string incomingRequestOrigin = operationContext.IncomingRequest.Headers["Origin"];
			outgoingResponseHeaders.Add("Access-Control-Allow-Origin", incomingRequestOrigin);
#else
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			string incomingRequestOrigin = httpContext.Request.Headers["Origin"];
			httpContext.Response.AddHeader("Access-Control-Allow-Origin", incomingRequestOrigin);
#endif
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Head method for request to HandleWebHooks.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "HEAD", UriTemplate = "HandleWebHooks")]
		public void HandleWebHooksHead() {
			PrepareCorsHeaders();
		}

		/// <summary>
		/// Handles incoming webhooks.
		/// </summary>
		/// <param name="stream">Request body.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "HandleWebHooks")]
		public void HandleWebHooks(Stream stream) {
			LogInfo("Started");
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			Authenticate(httpContext.Request);
			var queryParameters = GetRequestParameters(stream, httpContext.Request);
			var webHooksJson = queryParameters[WebHooksParameterName];
			var webhookType = queryParameters[WebHooksTypeParameterName];
			if (string.IsNullOrEmpty(webHooksJson)) {
				LogError("Empty args", new ArgumentNullException(WebHooksParameterName));
				return;
			}
			if (WebHooksLoggingEnabled) {
				LogInfo(string.Format("Data: {0}", webHooksJson));
			}
			queryParameters.Clear();
			try {
				InsertWebHook(webHooksJson, webhookType);
			} catch (Exception e) {
				LogError(e);
				throw e;
			}
			LogInfo("Completed successfully");
		}

		#endregion
	}

	#endregion
}

