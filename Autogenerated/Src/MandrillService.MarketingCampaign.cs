namespace BPMSoft.Configuration.MandrillService
{
	using System;
	using System.Collections.Specialized;
	using System.IO;
	using System.Linq;
	using System.Security.Cryptography;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Http.Abstractions;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: MandrillService

	///<summary>Class for work with Mandrill.</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MandrillService : IMailingProvider
	{

		#region Class: Internal

		#endregion

		#region Constants: Private

		private const int StreamReaderBufferSize = 65536;

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		private static bool _isAnonymousAuthentication = false;

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get {
				if (_userConnection != null) {
					return _userConnection;
				}
				_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection;
				if (_userConnection != null) {
					return _userConnection;
				}
				if (_isAnonymousAuthentication) {
					var appConnection = (AppConnection)HttpContext.Current.Application["AppConnection"];
					_userConnection = appConnection.SystemUserConnection;
				}
				return _userConnection;
			}
			set => _userConnection = value;
		}

		#endregion

		#region Methods: Private

		private void Authenticate() {
			if (UserConnection == null) {
				throw new System.Security.Authentication.AuthenticationException();
			}
		}


		private int SetBulkEmailBreakingStatus(Guid bulkEmailId) {
			int result = 0;
			try {
				var bulkEmailUpdate = new Update(UserConnection, "BulkEmail")
					.Set("StatusId", Column.Parameter(MarketingConsts.BulkEmailStatusStoppedId))
					.Set("StartDate", Column.Const(null))
					.Where("Id").IsEqual(Column.Parameter(bulkEmailId))
					.And("StatusId").In(
						new QueryParameter(MarketingConsts.BulkEmailStatusStartsId),
						new QueryParameter(MarketingConsts.BulkEmailStatusLaunchedId)
					) as Update;
				result = bulkEmailUpdate.Execute();
			} catch (System.Data.SqlClient.SqlException e) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.SetBulkEmailBreakingStatus]: "
					+ "Update Breaking Status: BulkEmail: {0} fails.", e, bulkEmailId);
			}
			return result;
		}

		private string GetMandrillPayload(HttpRequest request, NameValueCollection rawPostData) {
			var appUrl = request.Url.ToString();
			var sb = new StringBuilder(appUrl);
			rawPostData.AllKeys.OrderBy(x => x).BulkEmail(x => sb.Append(x).Append(rawPostData[x]));
			return sb.ToString();
		}

		private bool IsRequestAuthenticate(string key, HttpRequest request, NameValueCollection rawPostData) {
			if (request.Headers.AllKeys.Contains("X-Mandrill-Signature") &&
				request.Headers["X-Mandrill-Signature"] == "6639391572") {
				return true;
			}
			if (string.IsNullOrEmpty(key)) {
				MandrillUtilities.Log.ErrorFormat("[MandrillService.IsRequestAuthenticate]: The AuthKey is empty.");
				return false;
			}
			if (!request.Headers.AllKeys.Contains("X-Mandrill-Signature")) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.IsRequestAuthenticate]: The header X-Mandrill-Signature not found.");
				return false;
			}
			string data = GetMandrillPayload(request, rawPostData);
			using (var hashAlg = new HMACSHA1(Encoding.UTF8.GetBytes(key))) {
				var hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(data));
				string signature = request.Headers["X-Mandrill-Signature"];
				return (signature == Convert.ToBase64String(hash));
			}
		}

		private string GetMandrillAuthKey() {
			var result = string.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MandrillWebhook");
			esq.AddColumn("AuthKey");
			EntityCollection mandrillWebhooks = esq.GetEntityCollection(UserConnection);
			foreach (Entity mandrillWebhook in mandrillWebhooks) {
				return mandrillWebhook.GetTypedColumnValue<string>("AuthKey");
			}
			return result;
		}

		private string GetRequestMethod() {
#if !NETSTANDARD2_0
			return WebOperationContext.Current.IncomingRequest.Method;
#else
			return HttpContext.Current.Request.HttpMethod;
#endif
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates message.
		/// </summary>
		/// <param name="messageId">Unique identifier of the message.</param>
		/// <returns>Validation result.</returns>
		public ConfigurationServiceResponse ValidateMessage(Guid messageId) {
			return new ConfigurationServiceResponse();
		}

		/// <summary>
		/// Validates messages.
		/// </summary>
		/// <param name="messageIds">Unique identifiers of the message.</param>
		/// <returns>Validation result.</returns>
		public ConfigurationServiceResponse ValidateMessages(Guid[] messageIds) {
			return new ConfigurationServiceResponse();
		}

		public ConfigurationServiceResponse ValidateDraftStatus(Guid[] messageIds) {
			return new ConfigurationServiceResponse();
		}

		/// <summary>
		/// Sets up current Campaign step by stepId.
		/// </summary>
		/// <typeparam name="campaignId">Uniqueidentifier of Campaign.</typeparam>
		/// <typeparam name="stepId">Uniqueidentifier of objectlinked with Campaign step.</typeparam>
		public static void SetCampaignTargetsCurrentStep(Guid campaignId, Guid stepId, UserConnection userConnection) {
			try {
				var updateCampaignTarget = new Update(userConnection, "CampaignTarget")
					.Set("CurrentStepId", Column.Parameter(stepId))
					.Set("NextStepId", Column.Const(null))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
					.And("NextStepId").IsEqual(Column.Parameter(stepId)) as Update;
				updateCampaignTarget.Execute();
			} catch (System.Data.SqlClient.SqlException e) {
				MandrillUtilities.Log.ErrorFormat(
					"[MandrillService.SetCampaignTargetsCurrentStep]: "
					+ "Set CurrentStepId: {0} to Campaign: {1} fails.", e, stepId, campaignId);
				throw e;
			}
		}

		/// <summary>
		/// Returns Uniqueidentifier of Campaign step.
		/// </summary>
		/// <param name="campaignId">Uniqueidentifier of Campaign.</param>
		/// <param name="recordId">Uniqueidentifier of objectlinked with Campaign step.</param>
		/// <returns>Uniqueidentifier of Campaign step.</returns>
		public static Guid GetCampaignStepIdByRecordId(Guid campaignId, Guid recordId, UserConnection userConnection) {
			var selectCampaignStep = new Select(userConnection)
				.Column("Id")
				.From("CampaignStep")
				.Where("CampaignId").IsEqual(Column.Parameter(campaignId))
				.And("RecordId").IsEqual(Column.Parameter(recordId)) as Select;
			return selectCampaignStep.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Bulk insert operation.
		/// </summary>
		/// <param name="select">Query to fetch data.</param>
		/// <returns>Amount of added records.</returns>
		public static int ExecuteInsertSelect(Select select, Func<Select, InsertSelect> getInsertSelect,
				UserConnection userConnection) {
			const int packageSize = 10000;

			var execSelect = new Select(userConnection)
				.Top(packageSize)
				.Column(Column.Asterisk("ResultSelect"))
				.From(select).As("ResultSelect");

			var iterateInsertedCount = 0;
			var insertedCount = 0;
			do {
				var insertSelect = getInsertSelect(execSelect);
				using (var dbExecutor = userConnection.EnsureDBConnection()) {
					dbExecutor.StartTransaction(System.Data.IsolationLevel.ReadUncommitted);
					try {
						iterateInsertedCount = insertSelect.Execute(dbExecutor);
					} catch {
						dbExecutor.RollbackTransaction();
						throw;
					}
					insertedCount += iterateInsertedCount;
					dbExecutor.CommitTransaction();
				}
			} while (iterateInsertedCount == packageSize);
			return insertedCount;
		}

		/// <summary>
		/// Creates Task for update split test emil target in Scheduler.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="recordId">Uniqueidentifier of Schema record.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateSplitTestAudience", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdateSplitTestAudience(Guid recordId) {
			Authenticate();
			var data = new UpdateTargetAudienceData(null, "BulkEmailSplit", recordId, false);
			Core.Tasks.Task.StartNewWithUserConnection<UpdateAudienceBackgroundTask, UpdateTargetAudienceData>(data);
		}

		/// <summary>
		/// Creates Task for update campaign target in Scheduler.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="recordId">Uniqueidentifier of Schema record.</param>
		/// <param name="isSetCampaignFirstStep">Is it need to set up first step.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateTargetAudience", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdateTargetAudience(string schemaName, Guid recordId, bool isSetCampaignFirstStep = false) {
			Authenticate();
			var data = new UpdateTargetAudienceData(null, schemaName, recordId, isSetCampaignFirstStep);
			Core.Tasks.Task.StartNewWithUserConnection<UpdateAudienceBackgroundTask, UpdateTargetAudienceData>(data);
		}

		/// <summary>
		/// Executes Email update statistcs process.
		/// </summary>
		/// <param name="id">Email uniqueidentifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateStatistic", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdateStatistic(Guid id) {
			Authenticate();
			var bulkEmailAudienceHelper = ClassFactory.Get<BulkEmailAudienceHelper>();
			bulkEmailAudienceHelper.UpdateStatistic(UserConnection, id);
		}

		/// <summary>
		/// Stop Email sending.
		/// </summary>
		/// <param name="id">Email uniqueidentifier.</param>
		/// <returns>Returns Email state.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "BreakMailing", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public MailingResponse BreakMailing(Guid bulkEmailId) {
			var bulkEmail = new BulkEmail(UserConnection);
			var response = new MailingResponse() {
				Success = false,
				StatusId = Guid.Empty
			};
			if (!bulkEmail.FetchFromDB(bulkEmailId)) {
				MandrillUtilities.Log.InfoFormat("Can'not access record with Id: {0}.", bulkEmailId);
				return response;
			}
			if (SetBulkEmailBreakingStatus(bulkEmail.Id) > 0) {
				response.Success = true;
				response.StatusId = MarketingConsts.BulkEmailStatusBreakingId;
				return response;
			}
			response.Success = true;
			response.StatusId = bulkEmail.StatusId;
			return response;
		}

		/// <summary>
		/// Sending Email to Mandrill.
		/// </summary>
		/// <param name="id">Email uniqueidentifier.</param>
		/// <param name="isDelayedStart">Parameter that indicates is the delayed Email was executed by Scheduler.</param>
		/// <returns>Returns Email state.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SendMessage", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public MailingResponse SendMessage(Guid id, bool isDelayedStart = false,
				string applicationUrl = "") {
			throw new NotImplementedException("Mandrill deprecated");
		}

		public MailingResponse SendMessage(IMessageInfo messageInfo) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sending of test Email to Mandrill.
		/// </summary>
		/// <param name="bulkEmailId">Email uniqueidentifier.</param>
		/// <param name="contactId">Contatc uniqueidentifier.</param>
		/// <param name="emailRecipient">email address of recipient for test email.</param>
		/// <returns>Returns boolean: is test email was sent successfully.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SendTestMessage", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool SendTestMessage(Guid bulkEmailId, Guid contactId, string emailRecipient) {
			throw new NotImplementedException("Mandrill deprecated");
		}

		/// <summary>
		/// Processing Mandrill events.
		/// </summary>
		/// <param name="mandrill_events">Mandrill events.</param>
		[OperationContract]
		[WebInvoke(Method = "*", UriTemplate = "HandleWebHookEvents")]
		public void HandleWebHookEvents(Stream mandrill_events) {
			_isAnonymousAuthentication = true;
			MandrillUtilities.WebHookLog.Info("[MandrillService.HandleWebHookEvents]: Started.");
			string method = GetRequestMethod();
			if (method == "HEAD") {
				return;
			}
			if (method != "POST") {
				throw new ArgumentException(method + " method is not supported.");
			}
			var rawPostData = new StringBuilder();
			var buffer = new char[StreamReaderBufferSize];
			using (var streamReader = new StreamReader(mandrill_events)) {
				var readLength = 0;
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
			string webHookEventJson = queryParameters["mandrill_events"];
			if (string.IsNullOrEmpty(webHookEventJson)) {
				var exception = new ArgumentNullException("mandrill_events");
				MandrillUtilities.WebHookLog.Error("[MandrillService.HandleWebHookEvents]: Empty args.", exception);
				return;
			}
			bool enableWebHooksLogging = (bool)BPMSoft.Core.Configuration.SysSettings
				.GetValue(UserConnection, "EnableWebHooksLogging");
			if (enableWebHooksLogging) {
				MandrillUtilities.WebHookLog
					.InfoFormat("[MandrillService.HandleWebHookEvents]: Data: {0}", webHookEventJson);
			}
			string authKey = GetMandrillAuthKey();
			if (!IsRequestAuthenticate(authKey, HttpContext.Current.Request, queryParameters)) {
				MandrillUtilities.WebHookLog.ErrorFormat(
					"[MandrillService.HandleWebHookEvents]: The AuthKey {0} is wrong.", authKey);
				return;
			}
			queryParameters.Clear();
			try {
				byte[] compressedJson = MandrillUtilities.Compress(webHookEventJson);
				var insert = new Insert(UserConnection)
					.Into("RawMandrillEvent")
					.Set("Id", Column.Parameter(Guid.NewGuid()))
					.Set("JsonData", Column.Parameter(compressedJson))
					.Execute();
			} catch (Exception e) {
				MandrillUtilities.WebHookLog.ErrorFormat("[MandrillService.HandleWebHookEvents].", e);
				throw e;
			}
			MandrillUtilities.WebHookLog
				.Info("[MandrillService.HandleWebHookEvents]: Completed successfully. End process.");
		}

		/// <summary>
		/// Checks provider connection.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "PingProvider", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool PingProvider() {
			throw new NotImplementedException("Mandrill deprecated");
		}


		#endregion
	}

	#endregion

}

