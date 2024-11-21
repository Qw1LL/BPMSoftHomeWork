namespace BPMSoft.Configuration
{
	using DynamicContent;
	using DynamicContent.Models;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Text.RegularExpressions;
	using System.Threading;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.CESResponses;
	using BPMSoft.Configuration.Mailing;
	using BPMSoft.Configuration.Marketing.Utilities;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Tasks;
	using Utils;

	#region DcSendActionData

	/// <summary>
	/// Represents data to be used for async sending.
	/// </summary>
	public class DcSendActionData
	{

		/// <summary>
		/// Bulk email id to sent.
		/// </summary>
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Current user culture info.
		/// </summary>
		public string CultureInfo { get; set; }

		/// <summary>
		/// The date and time to start sending.
		/// </summary>
		public DateTime StartSendingTime { get; set; }

	}

	#endregion

	#region Class: CESMaillingProvider

	/// <summary>
	/// Class for work with cloud email service.
	/// </summary>
	public class CESMaillingProvider : ISessionedMailingProvider, IConfigurableMailingProvider, ITestMessageProvider,
		IBackgroundTask<DcSendActionData>, IUserConnectionRequired, IThrottlingSchedulesProvider, IEmailLimitValidator,
		IMailingCesApiProvider
	{

		#region Constants: Private

		private const int PreparationRecipientsBatchSize = 20000;

		private const int MailingServicePingAttemptsCount = 3;

		private const int MailingServicePingTimeout = 10000;

		private const string MassMailingTag = "mass_mailing";

		private const string TriggeredEmailTag = "triggered_email";

		private const int MailingMaxTemplateSize = 5242880;

		#endregion

		#region Fields: Private

		private Guid _mailingSessionId = Guid.Empty;

		private bool? _isDcBulkEmail = null;


		protected string _linkedEntitySchemaName;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CESMaillingProvider"/> class.
		/// </summary>
		public CESMaillingProvider() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CESMaillingProvider"/> class.
		/// Instance of the provider will be configured by calling Configure method.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public CESMaillingProvider(UserConnection userConnection): this() {
			UserConnection = userConnection;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CESMaillingProvider"/> class.
		/// Use this constructor to initialize instnce by provider config parameter.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="configFactory">The configuration factory, instance of the <see cref="IMailingProviderConfigFactory"/></param>
		public CESMaillingProvider(UserConnection userConnection, IMailingProviderConfigFactory configFactory)
			: this(userConnection) {
			if (configFactory == null) {
				return;
			}
			IMailingProviderConfig providerConfig = configFactory.CreateInstance(userConnection);
			if (providerConfig is CESMailingProviderConfig) {
				var cesConfig = (CESMailingProviderConfig)providerConfig;
				_serviceApi = cesConfig.ServiceApi;
			}
		}

		#endregion

		#region Properties: Private

		private BpmCrmCloudEngine _cloudEngine;
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

		#region Properties: Protected
		
		protected ICESApi _serviceApi;

		private ISendingEmailProgressRepository _sendingRepo;
		protected ISendingEmailProgressRepository SendingEmailProgressRepository {
			get =>
				_sendingRepo ?? ClassFactory.Get<SendingEmailProgressRepository>(
					new ConstructorArgument("userConnection", UserConnection));
			set => _sendingRepo = value;
		}

		protected TemplateSizeValidator TemplateSizeValidator { get; set; }

		protected CESMailingTemplateFactory TemplateFactory { get; set; }

		[Obsolete("Will be removed after 7.17.3")]
		protected IMailingAudienceDataSourceFactory AudienceDataSourceFactory { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets instance of <see cref="ICESApi"/> to access cloud email service.
		/// </summary>
		public ICESApi ServiceApi => _serviceApi ?? (_serviceApi = CloudEngine.ServiceApi);

		/// <summary>
		/// Instance of current user connection.
		/// </summary>
		public UserConnection UserConnection { get; set; }

		private BulkEmailEventLogger _bulkEmailEventLogger;

		/// <summary>
		/// Instance of BulkEmailEventLogger. 
		/// </summary>
		public BulkEmailEventLogger BulkEmailEventLogger =>
			_bulkEmailEventLogger ?? (_bulkEmailEventLogger = new BulkEmailEventLogger(UserConnection));

		private BulkEmailMacroParser _bulkEmailMacroParser;

		public BulkEmailMacroParser BulkEmailMacroParser {
			get => _bulkEmailMacroParser ?? (_bulkEmailMacroParser = GetMacroParser());
			set => _bulkEmailMacroParser = value;
		}
		
		public BulkEmailValidator Validator { get; set; }

		#endregion

		#region Methods: Private

		private MailingContext CreateMailingContext(BulkEmail bulkEmail) {
			return new MailingContext(UserConnection, bulkEmail) {
				ServiceApi = ServiceApi,
				SessionId = _mailingSessionId
			};
		}

		private void InitMacroParser(Guid bulkEmailId) {
			var targetSchema = UserConnection.EntitySchemaManager.GetInstanceByName(nameof(BulkEmail));
			var esq = new EntitySchemaQuery(targetSchema);
			esq.AddColumn("AudienceSchema.EntityObject.Id");
			var bulkEmail = esq.GetEntity(UserConnection, bulkEmailId);
			var linkedEntitySchemaUId = bulkEmail.GetTypedColumnValue<Guid>("AudienceSchema_EntityObject_Id");
			if (linkedEntitySchemaUId.IsNotEmpty()) {
				_linkedEntitySchemaName = UserConnection.EntitySchemaManager
					.FindInstanceByUId(linkedEntitySchemaUId)?.Name;
			}
			BulkEmailMacroParser = GetMacroParser();
		}

		private BulkEmailMacroParser GetMacroParser() {
			var macrosHelper = ClassFactory.Get<MacrosHelperV2>();
			macrosHelper.UserConnection = UserConnection;
			return ClassFactory.Get<BulkEmailMacroParser>(
				new ConstructorArgument("macrosHelper", macrosHelper),
				new ConstructorArgument("linkedEntitySchemaName", _linkedEntitySchemaName));
		}

		private CESMacrosHelper GetMacrosHelper(Guid contactId, Guid bulkEmailId) {
			return ClassFactory.Get<CESMacrosHelper>(
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("contactId", contactId),
				new ConstructorArgument("bulkEmailId", bulkEmailId));
		}

		private string GetLczStringValue(string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, "CESMaillingProvider", localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		[Obsolete("Will be removed after 7.17.3")]
		private IEnumerable<EmailAddress> GetEmailMesageTo(IEnumerable<IMessageRecipientInfo> recipients,
				CESMacrosHelper macrosHelper, IMailingTemplate template, Guid bulkEmailId) {
			var validRecipients = GetValidRecipient(recipients);
			var personalMergeVars = GetMergeVars(macrosHelper, template, validRecipients, bulkEmailId);
			IEnumerable<EmailAddress> recipientEmailAddress = GetRecipientEmailAddress(personalMergeVars);
			return recipientEmailAddress;
		}

		[Obsolete("Will be removed after 7.17.3")]
		private void PrepareRecipients(IMessageInfo messageInfo, CESMacrosHelper macrosHelper,
				EmailMessage emailMessage, IMailingTemplate template, Guid bulkEmailId) {
			IEnumerable<EmailAddress> recipientEmailAddress =
				GetEmailMesageTo(messageInfo.Recipients, macrosHelper, template, bulkEmailId);
			emailMessage.to = recipientEmailAddress;
		}

		private List<string> GetBulkEmailCategoryTags(BulkEmail bulkEmail) {
			var tags = new List<string>();
			Guid categoryId = bulkEmail.CategoryId;
			if (categoryId == MailingConsts.MassmailingBulkEmailCategoryId) {
				tags.Add(MassMailingTag);
			} else if (categoryId == MailingConsts.TriggeredEmailBulkEmailCategoryId) {
				tags.Add(TriggeredEmailTag);
			}
			return tags;
		}

		[Obsolete("Will be removed after 7.17.3")]
		private EmailMessage InitEmailMessage(IMessageInfo messageInfo) {
			var instantMessageInfo = messageInfo as InstantMessageInfo;
			BulkEmail bulkEmail = instantMessageInfo.BulkEmail;
			CESMacrosHelper macrosHelper = GetMacrosHelper(bulkEmail.OwnerId, bulkEmail.Id);
			IMailingTemplate template = CreateTemplate(bulkEmail, macrosHelper);
			try {
				var message = new EmailMessage {
					subject = template.TemplateSubject,
					from_email = bulkEmail.SenderEmail,
					from_name = bulkEmail.SenderName,
					html = bulkEmail.TemplateBody,
					track_clicks = true,
					track_opens = true,
					inline_css = true,
					important = true
				};
				var bulkEmailId = bulkEmail.GetTypedColumnValue<Guid>("Id");
				PrepareRecipients(messageInfo, macrosHelper, message, template, bulkEmailId);
				MailingUtilities.Log.InfoFormat("CESMaillingProvider.GetRecipients. Bulk email with Id={0} "
					+ "executed successfully", bulkEmailId);
				message.tags = GetBulkEmailCategoryTags(bulkEmail);
				message.html = template.Content;
				message.images = template.InlineImages.ToCESImage();
				List<merge_var> globalMergeVars = macrosHelper.GetGlobalMergeVars(template.MacrosCollection);
				if (globalMergeVars.Any()) {
					message.InitGlobalVariable();
					message.global_merge_vars.AddRange(globalMergeVars);
				}
				return message;
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.InitEmailMessage]: Error while init message for BulkEmail with Id: {0}",
					e, bulkEmail.Id);
				throw;
			}
		}


		private void SetInvalidBulkEmailCounters(Guid bulkEmailId, int invalidAddresseeCount) {
			QueryColumnExpression actualInvalidAdresseeExpression
				= MailingDbUtilities.GetAddCountColumnExpression("InvalidAddresseeCount", invalidAddresseeCount);
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmailId, UserConnection,
				new KeyValuePair<string, object>("SendDueDate", Column.Const(null)),
				new KeyValuePair<string, object>("InvalidAddresseeCount", actualInvalidAdresseeExpression));

		}

		private void PerformWaitBeforeSend(BulkEmail bulkEmail) {
			int sendDelayInSeconds
				= (int)Core.Configuration.SysSettings.GetValue(UserConnection, "MandrillMailingDelayInSeconds");
			bool isTriggeredCategory = (bulkEmail.CategoryId == MailingConsts.TriggeredEmailBulkEmailCategoryId);
			if (!isTriggeredCategory) {
				Thread.Sleep(sendDelayInSeconds * 1000);
			}
		}

		private void SetBulkEmailStatus(BulkEmail bulkEmail, Guid statusId) {
			Guid bulkEmailId = Guid.Empty;
			try {
				bulkEmailId = bulkEmail.Id;
				var bulkEmailStatusUpdate =
					new Update(UserConnection, "BulkEmail").Set("StatusId", Column.Parameter(statusId))
						.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Update;
				bulkEmailStatusUpdate.WithHints(new RowLockHint());
				bulkEmailStatusUpdate.Execute();
				bulkEmail.StatusId = statusId;
				if (bulkEmail.SplitTestId != Guid.Empty) {
					SetBulkEmailSplitStatus(bulkEmail.SplitTestId, statusId);
				}
				MailingUtilities.Log.InfoFormat(
					"BulkEmail with Id: {0} set to {1} status.", bulkEmailId, statusId);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SetBulkEmailStatus]: Error while saving BulkEmail with Id: {0}",
					e, bulkEmailId);
				BulkEmailEventLogger.LogError(bulkEmailId, DateTime.UtcNow,
					GetLczStringValue("BulkEmailStatusUpdateEvent"), e, GetLczStringValue("SaveErrorMsg"),
					UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		private void SetBulkEmailSplitStatus(Guid splitTestId, Guid bulkEmailStatusId) {
			try {
				var bulkEmailSplit = new BulkEmailSplit(UserConnection);
				if (!bulkEmailSplit.FetchFromDB(splitTestId)) {
					MailingUtilities.Log.ErrorFormat(
						"[CESMaillingProvider.SetBulkEmailSplitStatus]: Failed to fetch BulkEmailSplit from DB." +
						"Id: {0}", splitTestId);
					return;
				}
				if (bulkEmailStatusId == MailingConsts.BulkEmailStatusStartsId &&
						bulkEmailSplit.StatusId == MailingConsts.BulkEmailSplitStatusStartPlanedId) {
					bulkEmailSplit.SetColumnValue("StatusId", MailingConsts.BulkEmailSplitStatusLaunchedId);
				}
				if (bulkEmailStatusId == MailingConsts.BulkEmailStatusFinishedId) {
					var selectCount = new Select(UserConnection)
						.Column(Func.Count("Id"))
						.From("BulkEmail")
						.Where("SplitTestId").IsEqual(Column.Parameter(splitTestId))
							.And("StatusId").IsNotEqual(Column.Parameter(MailingConsts.BulkEmailStatusFinishedId)) as Select;
					var count = selectCount.ExecuteScalar<int>();
					if (count == 0) {
						bulkEmailSplit.SetColumnValue("StatusId", MailingConsts.BulkEmailSplitStatusFinishedId);
						string tableName = string.Format("ST_{0}", splitTestId.ToBase36());
						Utilities.DropTable(tableName, UserConnection, true);
					}
				}
				bulkEmailSplit.Save();
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SetBulkEmailSplitStatus]: Error while saving BulkEmailSplit with Id: {0}",
					e, splitTestId);
			}
		}

		private void SetBulkEmailErrorStatus(BulkEmail bulkEmail) {
			Guid status;
			try {
				if (MailingConsts.TriggeredEmailBulkEmailCategoryId.Equals(bulkEmail.CategoryId)) {
					status = MailingConsts.BulkEmailStatusActiveId;
				} else if (MailingConsts.MassmailingBulkEmailCategoryId.Equals(bulkEmail.CategoryId)) {
					status = MailingConsts.BulkEmailStatusErrorId;
				} else {
					throw new ArgumentException(string.Format("Unknown BulkEmail category: {0}.", bulkEmail.CategoryId));
				}
				SetBulkEmailStatus(bulkEmail, status);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SetBulkEmailErrorStatus]: "
					+ "Update Error Status: BulkEmail: {0} fails.", e, bulkEmail.Id);
				BulkEmailEventLogger.LogError(bulkEmail.Id, DateTime.UtcNow,
					GetLczStringValue("BulkEmailStatusUpdateEvent"), e,
					GetLczStringValue("SetBulkEmailErrorStatusErrorMsg"), UserConnection.CurrentUser.ContactId);
				throw;
			}
		}

		private Dictionary<Guid, Guid> GetBulkEmailStopStatusMapping() {
			var bulkEmailStatusMapping = new Dictionary<Guid, Guid> {
				{ MailingConsts.BulkEmailStatusWaitingBeforeSendId, MailingConsts.BulkEmailStatusStoppedId },
				{ MailingConsts.BulkEmailStatusStartPlanedId, MailingConsts.BulkEmailStatusStoppedId }
			};
			if (UserConnection.GetIsFeatureEnabled("BulkEmailStop")) {
				bulkEmailStatusMapping.Add(MailingConsts.BulkEmailStatusStartsId, MailingConsts.BulkEmailStatusBreakingId);
				bulkEmailStatusMapping.Add(MailingConsts.BulkEmailStatusLaunchedId, MailingConsts.BulkEmailStatusBreakingId);
				bulkEmailStatusMapping.Add(MailingConsts.BulkEmailStatusQueuedId, MailingConsts.BulkEmailStatusHardStoppedId);
				bulkEmailStatusMapping.Add(MailingConsts.BulkEmailStatusActiveId, MailingConsts.BulkEmailStatusHardStoppedId);
			}
			return bulkEmailStatusMapping;
		}

		private Guid SetBulkEmailBreakingStatus(BulkEmail bulkEmail) {
			var startOperationDate = DateTime.UtcNow;
			var defaultResult = bulkEmail.StatusId;
			var eventLcz = "MailingPausedManually";
			var eventDescriptionLcz = "MailingPausedManuallyDescription";
			try {
				var bulkEmailStatusMapping = GetBulkEmailStopStatusMapping();
				if (!bulkEmailStatusMapping.TryGetValue(bulkEmail.StatusId, out var stoppedStatusId)) {
					return defaultResult;
				}
				var bulkEmailUpdate = new Update(UserConnection, "BulkEmail")
					.Set("StatusId", Column.Parameter(stoppedStatusId))
					.Set("StartDate", Column.Const(null))
					.Where("Id").IsEqual(Column.Parameter(bulkEmail.Id));
				var updatedCount = bulkEmailUpdate.Execute();
				if (stoppedStatusId == MailingConsts.BulkEmailStatusBreakingId ||
					stoppedStatusId == MailingConsts.BulkEmailStatusHardStoppedId && updatedCount > 0) {
					eventLcz = "MailingPrepareStopManually";
					eventDescriptionLcz = "MailingPrepareStopManuallyDescription";
				}
				BulkEmailEventLogger.LogInfo(bulkEmail.Id, startOperationDate,
					GetLczStringValue(eventLcz), GetLczStringValue(eventDescriptionLcz),
					UserConnection.CurrentUser.ContactId);
				return stoppedStatusId;
				
			} catch (System.Data.SqlClient.SqlException e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SetBulkEmailBreakingStatus]: "
					+ "Update Breaking Status: BulkEmail: {0} fails.", e, bulkEmail.Id);
				BulkEmailEventLogger.LogError(bulkEmail.Id, DateTime.UtcNow,
					GetLczStringValue("BulkEmailStatusUpdateEvent"), e, GetLczStringValue("StateUpdateErrorMsg"),
					UserConnection.CurrentUser.ContactId);
			}
			return defaultResult;
		}

		private BulkEmail GetBulkEmailFromDB(Guid bulkEmailId) {
			var bulkEmail = new BulkEmail(UserConnection);
			var fetchBulkEmailResult = bulkEmail.FetchFromDB("Id", bulkEmailId, new[] {
				"Id", "Owner", "Name", "TemplateBody", "UseUtm", "StartDate", "Category","Domains", "UtmSource",
				"UtmMedium", "UtmCampaign", "UtmTerm", "UtmContent", "TemplateSubject", "SenderName", "SenderEmail",
				"SplitTest", "Status", "LaunchOption", "SegmentsStatus", "AudienceSchema", "SendStartDate", 
				"IsSystemEmail", "Type", "Priority", "BusinessTimeStart", "BusinessTimeEnd", 
				"ExpirationDate", "DeliveryScheduleDays", "ThrottlingMode", "ThrottlingQueue", "TimeZone",
				"StoppedManuallyCount", "StoppedSummaryCount", "StoppedInProviderCount","DelayBetweenEmail","DailyLimit",
				"ProviderName"
			});
			bulkEmail.Priority.FetchFromDB("Id", bulkEmail.PriorityId, new[] { "Priority" });
			bulkEmail.ThrottlingQueue.FetchFromDB("Id", bulkEmail.ThrottlingQueueId, new[] { "Code" });
			bulkEmail.ThrottlingMode.FetchFromDB("Id", bulkEmail.ThrottlingModeId, new[] { "Code" });
			bulkEmail.TimeZone.FetchFromDB("Id", bulkEmail.TimeZoneId, new[] { "Code" });
			if (!fetchBulkEmailResult) {
				MailingUtilities.Log.WarnFormat(
					"[CESMaillingProvider.GetBulkEmailFromDB]: FetchFromDB BulkEmail: {0} fails.", bulkEmailId);
				throw new Exception(
					$"[CESMaillingProvider.GetBulkEmailFromDB]: FetchFromDB BulkEmail: {bulkEmailId} fails.");
			}
			return bulkEmail;
		}

		private IEnumerable<IMessageRecipientInfo> GetValidRecipient(IEnumerable<IMessageRecipientInfo> recipientsBatch) {
			var validRecipients = recipientsBatch.Where(item =>
				item.InitialResponseCode == (int)MailingResponseCode.PostedProvider);
			return validRecipients;
		}

		private IEnumerable<EmailAddress> GetRecipientEmailAddress(
				Dictionary<IMessageRecipientInfo, rcpt_merge_var> recipientsBatch) {
			var emailAddresses = new List<EmailAddress>();
			foreach (var recipientPair in recipientsBatch) {
				var recipientInfo = recipientPair.Key;
				var emailAddress = new EmailAddress(recipientInfo.Id, recipientInfo.EmailAddress);
				emailAddress.rcpt_merge_var = recipientPair.Value;
				emailAddresses.Add(emailAddress);
			}
			return emailAddresses;
		}

		private int GetInitialResponseCodeByContactRId(int contactRId) {
			var responseCase = new QueryCase();
			var trueValue = 1;
			MailingDbUtilities.AddWhenCondition(
				responseCase, "Contact", "IsNonActualEmail", QueryConditionType.Equal, trueValue,
				(int)MailingResponseCode.CanceledInvalidEmail);
			MailingDbUtilities.AddWhenCondition(
				responseCase, "Contact", "DoNotUseEmail", QueryConditionType.Equal, trueValue,
				(int)MailingResponseCode.CanceledDoNotUseEmail);
			responseCase.ElseExpression =
				new QueryColumnExpression(Column.Parameter((int)MailingResponseCode.PostedProvider));
			var select = new Select(UserConnection)
				.Column(responseCase).As("InitialResponseCode")
				.From("Contact")
				.Where("RId").IsEqual(Column.Parameter(contactRId)) as Select;
			return select.ExecuteScalar<int>();
		}

		private void PrepareInitialResponses(IEnumerable<IMessageRecipientInfo> recipients) {
			foreach (IMessageRecipientInfo recipient in recipients) {
				if (string.IsNullOrEmpty(recipient.EmailAddress)) {
					recipient.InitialResponseCode = (int)MailingResponseCode.CanceledBlankEmail;
				} else if (!MailingUtilities.ValidateEmail(recipient.EmailAddress)) {
					recipient.InitialResponseCode = (int)MailingResponseCode.CanceledIncorrectEmail;
				} else {
					recipient.InitialResponseCode = GetInitialResponseCodeByContactRId(recipient.ContactRId);
				}
			}
		}

		private void RegisterSenderDomain(string senderEmail) {
			try {
				var domain = new Regex("^.*@").Replace(senderEmail, "");
				CloudEngine.RegisterSenderDomain(domain);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.RegisterSenderDomain]: Error while registering domain for email: {0}",
					e, senderEmail);
			}
		}

		[Obsolete("Will be removed after 7.17.3")]
		private IMailingAudienceDataSource InitializeAudienceDataSource(Guid bulkEmailId, int recipientsBatchSize) {
			IMailingAudienceDataSource audienceDataSource = null;
			if (_mailingSessionId.Equals(Guid.Empty)) {
				audienceDataSource = AudienceDataSourceFactory.CreateInstance(UserConnection, bulkEmailId,
					recipientsBatchSize);
			} else {
				var sessionedFactory = AudienceDataSourceFactory as IMailingAudienceSessionedDataSourceFactory;
				audienceDataSource = sessionedFactory.CreateSessionedInstance(UserConnection, bulkEmailId,
					recipientsBatchSize, _mailingSessionId);
			}
			var dcAudienceDataSource = (IDCAudienceDataSource)audienceDataSource;
			if (_isDcBulkEmail.HasValue && dcAudienceDataSource != null) {
				dcAudienceDataSource.IsDCBulkEmail = _isDcBulkEmail.Value;
			}
			return audienceDataSource;
		}

		private bool PingProvider(Guid emailId) {
			DateTime startPingTime = DateTime.UtcNow;
			try {
				object pingResult;
				var result = Utilities.TryExecute(ServiceApi.Ping, MailingServicePingAttemptsCount,
					MailingServicePingTimeout, out pingResult);
				BulkEmailEventLogger.LogInfo(emailId, startPingTime, GetLczStringValue("PingCes"),
					GetLczStringValue("PingCesDescription"), UserConnection.CurrentUser.ContactId);
				return result;
			} catch (Exception e) {
				BulkEmailEventLogger.LogError(emailId, startPingTime, GetLczStringValue("PingCes"), e,
					GetLczStringValue("PingCesDescription"), UserConnection.CurrentUser.ContactId);
				return false;
			}
		}

		private IEnumerable<DCReplicaModel> GetReplicasByMasks(DCTemplateModel template,
				IEnumerable<int> replicaMasks = null) {
			var replicas = template.Replicas;
			if (replicaMasks != null && replicaMasks.Any()) {
				replicas = replicas.Where(x => replicaMasks.Contains(x.Mask));
			}
			return replicas;
		}

		private bool HandleMailingStepResult(BulkEmail bulkEmail, MailingStateExecutionResult stepResult,
			bool isSendingProcessFailed = true) {
			if (stepResult.Success) {
				return stepResult.Success;
			}
			if (isSendingProcessFailed) {
				SetBulkEmailErrorStatus(bulkEmail);
			}
			CreateReminders(bulkEmail, stepResult);
			var messages = stepResult.NotificationLcsStringCodes;
			string lczEventName = stepResult.EventLczStringCode;
			CreateEventLogErrorMessage(bulkEmail, stepResult, lczEventName, messages);
			return stepResult.Success;
		}

		private void CreateEventLogErrorMessage(BulkEmail bulkEmail, MailingStateExecutionResult stepResult,
			string lczEventName, IEnumerable<string> lczEventValues) {
			var notEmptyLczEvents = lczEventValues.Where(x => !x.IsNullOrEmpty());
			foreach (string lczEventValue in notEmptyLczEvents) {
				BulkEmailEventLogger.LogError(bulkEmail.Id, DateTime.UtcNow, GetLczStringValue(lczEventName),
					stepResult.Exception, GetLczStringValue(lczEventValue), UserConnection.CurrentUser.ContactId);
			}
		}

		private void CreateReminders(BulkEmail bulkEmail, MailingStateExecutionResult stepResult) {
			foreach (var lczString in stepResult.NotificationLcsStringCodes) {
				if (!string.IsNullOrEmpty(lczString)) {
					CreateReminding(bulkEmail, lczString);
				}
			}
		}

		private MailingResponse CreateErrorMailingResponse() {
			return new MailingResponse {
				Success = false,
				StatusId = MailingConsts.BulkEmailStatusErrorId
			};
		}

		private void RunDCSendActionAsync(DcSendActionData sendActionData) {
			MethodInfo method = typeof(Core.Tasks.Task).GetMethod("StartNewWithUserConnection");
			var mailingProviderType = this.GetType();
			MethodInfo genericMethod = method.MakeGenericMethod(mailingProviderType, typeof(DcSendActionData));
			genericMethod.Invoke(null, new[] { sendActionData });
		}

		private void ProcessRecipientResponseGroup(IGrouping<int, IMessageRecipientInfo> recipientsByResponse, int batchSize) {
			int processedCount = 0;
			var groupCount = recipientsByResponse.Count();
			while (processedCount < groupCount) {
				var recipientsToUpdate = recipientsByResponse.Skip(processedCount).Take(batchSize);
				var responseId = BulkEmailResponseMapping.GetResponseIdByCode(UserConnection, recipientsByResponse.Key);
				var updateInitialResponse = new Update(UserConnection, "BulkEmailTarget")
					.Set("BulkEmailResponseId", Column.Parameter(responseId))
					.Where("MandrillId").In(Column.Parameters(recipientsToUpdate.Select(x => x.Id))) as Update;
				updateInitialResponse.WithHints(new RowLockHint());
				processedCount += updateInitialResponse.Execute();
			}
		}
		
		private void SendDCMessage(BulkEmail bulkEmail, CultureInfo culture) {
			MailingUtilities.Log.InfoFormat("[CESMaillingProvider.CreateSendAction]: Start action for send. " +
				"BulkEmail.Id: {0}", bulkEmail.Id);
			Thread.CurrentThread.CurrentCulture = culture;
			ExecuteMailingStates(bulkEmail);
		}

		private void ExecuteMailingStates(BulkEmail bulkEmail) {
			var states = new MailingState[] {
				new InitialSendingMailingState(), new AudienceSegmentationMailingState(), new PreparingTemplateState(),
				new SendingMailingState(), new StopMailingState(), new ExpiredMailingState()
			};
			var listResults = new List<MailingStateExecutionResult>();
			bool anyStepProcessed;
			var mailingContext = CreateMailingContext(bulkEmail);
			do {
				anyStepProcessed = false;
				mailingContext.StartedOn = DateTime.UtcNow;
				foreach (var state in states) {
					mailingContext.ChangeState(state);
					var stateExecutionResult = mailingContext.Execute();
					listResults.Add(stateExecutionResult);
					if (!HandleMailingStepResult(bulkEmail, stateExecutionResult)) {
						break;
					}
					anyStepProcessed = anyStepProcessed ||
						stateExecutionResult.Status == MailingStateExecutionStatus.Continue;
				}
			} while (anyStepProcessed);
			if (!listResults.Any() || listResults.All(r => r.Status == MailingStateExecutionStatus.Skipped)) {
				throw new MailingStateHandleException($"No one state has been finished with success status. ");
			}
		}

		private bool StopBulkEmailInProvider(Guid bulkEmailId) {
			if (!UserConnection.GetIsFeatureEnabled("BulkEmailStop")) {
				return true;
			}
			try {
				Utilities.RetryOnFailure(() => ServiceApi.StopBulkEmail(bulkEmailId), 15, 5);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[CESMailingProvider.StopBulkEmailInCes]: BulkEmail with " +
					"Id: {0} stop email execution error", e, bulkEmailId);
				BulkEmailEventLogger.LogError(bulkEmailId, DateTime.UtcNow,
					GetLczStringValue("MailingStoppedManually"), e, GetLczStringValue("MailingStoppedManuallyErrorMsg"),
					UserConnection.CurrentUser.ContactId);
				return false;
			}
			return true;
		}

		#endregion

		#region Methods: Protected

		protected virtual void InitTemplateFactory() {
			if (TemplateFactory == null) {
				TemplateFactory = new CESMailingTemplateFactory();
			}
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected virtual void InitAudienceDataSourceFactory() {
			if (AudienceDataSourceFactory == null) {
				AudienceDataSourceFactory = new BulkEmailAudienceDataSourceFactory();
			}
		}

		protected IMailingTemplate CreateTemplate(BulkEmail bulkEmail, CESMacrosHelper macrosHelper) {
			var template = TemplateFactory.CreateInstance(UserConnection, bulkEmail, BulkEmailMacroParser);
			template.Init();
			return template;
		}

		protected IEnumerable<IMailingTemplate> CreateTemplates(BulkEmail bulkEmail, BulkEmailMacroParser macroParser,
				IEnumerable<DCReplicaModel> replicasToProcess) {
			if (replicasToProcess == null) {
				var templateCollection = new List<IMailingTemplate>();
				var mailingTemplate = TemplateFactory.CreateInstance(UserConnection, bulkEmail, macroParser);
				mailingTemplate.Init();
				templateCollection.Add(mailingTemplate);
				return templateCollection;
			} else {
				return TemplateFactory.CreateInstances(UserConnection, bulkEmail, replicasToProcess, macroParser);
			}
		}

		protected IEnumerable<IMailingTemplate> CreateTemplates(BulkEmail bulkEmail, BulkEmailMacroParser macroParser,
				IEnumerable<int> replicaMasksToProcess = null) {
			var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
			var templateReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.None
			};
			DCTemplateModel template = templateRepository.ReadByRecordId(bulkEmail.Id, templateReadOptions);
			IEnumerable<DCReplicaModel> replicas = null;
			if (template != null) {
				replicas = GetReplicasByMasks(template, replicaMasksToProcess);
			}
			return CreateTemplates(bulkEmail, macroParser, replicas);
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected void ActualizeRecipientsBeforeSend(int bulkEmailRId) {
			try {
				var update = new Update(UserConnection, "MandrillRecipient")
					.Set("IsSent", Column.Const(true))
				.Where().Exists(new Select(UserConnection).Column("Id")
					.From("MandrillSentMessage")
					.Where("BulkEmailRId").IsEqual("MandrillRecipient", "BulkEmailRId")
					.And("ContactRId").IsEqual("MandrillRecipient", "ContactRId")
				).And("BulkEmailRId").IsEqual(Column.Parameter(bulkEmailRId))
				.And("IsSent").IsEqual(Column.Const(false)) as Update;
				update.Execute();
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[CESMaillingProvider.ActualizeRecipientsBeforeSend]: "
					+ "Update of BulkEmail: {0} fails.", e, bulkEmailRId);
				throw;
			}
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected void SaveTemplate(IMailingTemplate template, BulkEmail bulkEmail) {
			if (!TemplateSizeValidator.ValidateTemplateSize(template, out var templateSize)) {
				throw new Exception(string.Format("Template {0} have size {1} more than {2}.", template.Name,
					MailingMaxTemplateSize));
			}
			IEnumerable<image> images = template.InlineImages.ToCESImage();
			string checksum = string.Empty;
			string replicaId = null;
			string senderEmail;
			string senderName;
			if (template is IMailingTemplateWithHeaders templateReplica) {
				checksum = templateReplica.Checksum;
				replicaId = templateReplica.ReplicaId.ToString();
				senderEmail = templateReplica.SenderEmail;
				senderName = templateReplica.SenderName;
			} else {
				senderEmail = bulkEmail.SenderEmail;
				senderName = bulkEmail.SenderName;
			}
			Utilities.RetryOnFailure(() => ServiceApi.AddTemplate(
				template.Name,
				senderEmail,
				senderName,
				template.TemplateSubject,
				template.Content,
				string.Empty,
				bulkEmail.Id,
				images,
				checksum,
				replicaId));
		}

		[Obsolete("7.17.1 | Sending bulk email moved to BPMSoft.Configuration.SendingMailingState.")]
		protected Action CreateDCSendAction(BulkEmail bulkEmail, CultureInfo culture, DateTime startSendingTime) {
			return () => SendDCMessage(bulkEmail, culture);
		}

		protected void CreateReminding(Entity entity, string lczStringName, params object[] parameters) {
			CreateReminding(entity, lczStringName, GetLczStringValue("RemindingMsgCaption"), parameters);
		}

		protected void CreateReminding(Entity entity, string lczStringName, string caption,
				params object[] parameters) {
			string description = parameters.Any() 
				? string.Format(GetLczStringValue(lczStringName), parameters) 
				: GetLczStringValue(lczStringName);
			MailingUtilities.CreateReminding(UserConnection, entity, description, caption);
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected void ExecuteSendMessagePostProcessing(SendMessageData sendMessageData,
				List<TypedCounter<MailingResponseCode>> sendResults, SendMessageTaskData sendMessageTaskData) {
			BulkEmail bulkEmail = sendMessageData.BulkEmail;
			Guid sessionId = sendMessageData.SessionId;
			int blankEmailCount = sendResults.Sum("BlankEmail");
			int doNotUseEmailCount = sendResults.Sum("DoNotUseEmail");
			int unsubscribedByTypeCount = sendResults.Sum("UnsubscribedByType");
			int incorrectEmailCount = sendResults.Sum("IncorrectEmail");
			int unreachableEmailCount = sendResults.Sum("UnreachableEmail");
			int communicationLimitCount = sendResults.Sum("CommunicationLimit");
			int duplicateEmailCount = sendResults.Sum("DuplicateEmail");
			int templateNotFoundCount= sendResults.Sum("TemplateNotFound");
			int sendersDomainNotVerifiedCount = sendResults.Sum("SendersDomainNotVerified");
			int sendersNameNotValidCount = sendResults.Sum("SendersNameNotValid");
			int invalidAddresseeCount = sendResults.Sum("InvalidAddressee");
			if (sendMessageTaskData.IsBreaking) {
				SetBulkEmailStatus(bulkEmail, MailingConsts.BulkEmailStatusStoppedId);
				BulkEmailEventLogger.LogInfo(bulkEmail.Id, DateTime.UtcNow,
					GetLczStringValue("MailingStoppedManually"), GetLczStringValue("MailingStoppedManuallyDescription"),
					UserConnection.CurrentUser.ContactId);
				SetInvalidBulkEmailCounters(bulkEmail.Id, invalidAddresseeCount);
				CreateReminding(bulkEmail, "CESStoppedMailingMsg");
				MailingUtilities.Log.InfoFormat("BulkEmail with Id: {0} Was stopped manually.", bulkEmail.Id);
				return;
			}
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmail.Id, UserConnection,
				new KeyValuePair<string, object>("SendDueDate", DateTime.UtcNow),
				new KeyValuePair<string, object>("BlankEmailCount", blankEmailCount),
				new KeyValuePair<string, object>("DoNotUseEmailCount", doNotUseEmailCount),
				new KeyValuePair<string, object>("UnsubscribedByTypeCount", unsubscribedByTypeCount),
				new KeyValuePair<string, object>("IncorrectEmailCount", incorrectEmailCount),
				new KeyValuePair<string, object>("UnreachableEmailCount", unreachableEmailCount),
				new KeyValuePair<string, object>("CommunicationLimitCount", communicationLimitCount),
				new KeyValuePair<string, object>("DuplicateEmailCount", duplicateEmailCount),
				new KeyValuePair<string, object>("TemplateNotFoundCount", templateNotFoundCount),
				new KeyValuePair<string, object>("SendersDomainNotVerifiedCount", sendersDomainNotVerifiedCount),
				new KeyValuePair<string, object>("SendersNameNotValidCount", sendersNameNotValidCount),
				new KeyValuePair<string, object>("InvalidAddresseeCount", invalidAddresseeCount));
			MailingUtilities.Log.InfoFormat(
				"[CESMaillingProvider.ExecuteSendMessage]: Finished: BulkEmail.Id: {0}, SessionId: {1}",
				bulkEmail.Id, sessionId);
			if (sendMessageTaskData.ProcessedGroupsCounter == 0) {
				SetBulkEmailErrorStatus(bulkEmail);
				CreateReminding(bulkEmail, "CESNoRecipientsMsg");
				MailingUtilities.Log.InfoFormat("BulkEmail with Id: {0} Has no recipients.", bulkEmail.Id);
			}
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected bool ExecuteSendMessage(IMessageInfo messageInfo) {
			var instatntMessageInfo = messageInfo as InstantMessageInfo;
			var bulkEmail = instatntMessageInfo.BulkEmail;
			RegisterSenderDomain(bulkEmail.SenderEmail);
			var emailMessage = InitEmailMessage(messageInfo);
			try {
				ServiceApi.SendMessage(emailMessage, bulkEmail.Id);
				HandleEmailResult(messageInfo.MessageRId, messageInfo.Recipients);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[ExecuteSendMessage]: Error while sending message", e);
				BulkEmailEventLogger.LogError(bulkEmail.Id, DateTime.UtcNow, GetLczStringValue("BatchSendEvent"), e,
					GetLczStringValue("SendToCloudErrorMsg"), UserConnection.CurrentUser.ContactId);
				return false;
			} finally {
				emailMessage = null;
			}
			return true;
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected List<IMessageRecipientInfo> GetRecipients(IMailingAudienceDataSource audienceDataSource) {
			return audienceDataSource.GetAudience();
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected Dictionary<IMessageRecipientInfo, rcpt_merge_var> GetMergeVars(CESMacrosHelper macrosHelper,
				IMailingTemplate template, IEnumerable<IMessageRecipientInfo> recipientsBatch, Guid bulkEmailId) {
			var audienceDataSource = InitializeAudienceDataSource(bulkEmailId, PreparationRecipientsBatchSize);
			Select recipientSelect = audienceDataSource.GetRecipientsSelectQuery();
			Dictionary<Guid, IMessageRecipientInfo> contactCollection = recipientsBatch.GroupBy(p => p.ContactId)
				.Select(p => p.First()).ToDictionary(p => p.ContactId, p => p);
			var contactIdSelect = new Select(UserConnection).Column("ContactId").From(recipientSelect).As("IdSubSelect");
			return macrosHelper.GetRecipientMergeVars(contactIdSelect, contactCollection, template.MacrosCollection);
		}

		protected void HandleEmailResult(int bulkEmailRId, IEnumerable<IMessageRecipientInfo> recipients) {
			var batchSize = 500;
			var groupedRecipients = recipients.GroupBy(r => r.InitialResponseCode);
			foreach (var recipientsByResponse in groupedRecipients) {
				ProcessRecipientResponseGroup(recipientsByResponse, batchSize);
			}
		}
		
		[Obsolete("Will be removed after 7.17.3")]
		protected void UpdateResultCounter(IEnumerable<IMessageRecipientInfo> recipients,
				TypedCounter<MailingResponseCode> resultsCounter) {
			foreach (IMessageRecipientInfo recipient in recipients) {
				resultsCounter.Count((MailingResponseCode)recipient.InitialResponseCode);
			}
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected bool SendBatch(SendMessageData messageData, int recipientCount) {
			MailingUtilities.Log.InfoFormat("[CESMaillingProvider.SendBatch]: Start: BulkEmailId: {0}. GroupId {1}.",
					messageData.BulkEmail.Id, messageData.BatchId);
			bool sendResult = false;
			try {
				DateTime startSendingTime = DateTime.UtcNow;
				Utilities.RetryOnFailure(() => ServiceApi.SendTemplate(messageData.EmailMessage,
					messageData.TemplateName, null, messageData.BulkEmail.Id));
				sendResult = true;
				BulkEmailEventLogger.LogInfo(messageData.BulkEmail.Id, startSendingTime,
					GetLczStringValue("SentBatchStatus"), GetLczStringValue("SentBatchStatusDescription"),
					UserConnection.CurrentUser.ContactId, messageData.BatchId);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SendBatch]: Error while sending BulkEmail with Id: {0}. "
					+ "SessionId: {1}. GroupId {2}.", e, messageData.BulkEmail.Id, messageData.SessionId,
					messageData.BatchId);
				BulkEmailEventLogger.LogError(messageData.BulkEmail.Id, DateTime.UtcNow,
					GetLczStringValue("BatchSendEvent"), e, GetLczStringValue("BatchSendErrorMsg"),
					UserConnection.CurrentUser.ContactId, messageData.BulkEmail);
				sendResult = false;
			}
			return sendResult;
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected void UpdateSendEmailIterationResult(SendMessageData messageData, IEnumerable<IMessageRecipientInfo> recipients,
				TypedCounter<MailingResponseCode> resultsCounter) {
			try {
				HandleEmailResult(messageData.BulkEmailRId, recipients);
				UpdateResultCounter(recipients, resultsCounter);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SendBatch]: Error while handling result of BulkEmail with Id: {0}",
					e, messageData.BulkEmail.Id);
				BulkEmailEventLogger.LogError(messageData.BulkEmail.Id, DateTime.UtcNow,
					GetLczStringValue("BatchSendEvent"), e, GetLczStringValue("HandleResultErrorMsg"),
					UserConnection.CurrentUser.ContactId);
			} finally {
				messageData.EmailMessage = null;
			}
			MailingUtilities.Log.InfoFormat("[CESMaillingProvider.SendBatch]: Success: BulkEmailId: {0}. GroupId {1}.",
				messageData.BulkEmail.Id, messageData.BatchId);
		}

		protected bool ValidateBulkEmail(Guid bulkEmailId, BulkEmail bulkEmail, MailingResponse stateExecutionResult) {
			var context = CreateMailingContext(bulkEmail);
			context.ChangeState(new ValidationMailingState());
			var executionResult = context.Execute();
			return HandleMailingStepResult(bulkEmail, executionResult, false);
		}

		[Obsolete("Will be removed after 7.17.3")]
		protected void AddContactToBulkEmailAudience(IMessageInfo messageInfo) {
			foreach (IMessageRecipientInfo recipientInfo in messageInfo.Recipients) {
				var insert = new Insert(UserConnection)
				.Into("BulkEmailTarget")
				.Set("BulkEmailId", Column.Parameter(messageInfo.MessageId))
				.Set("ContactId", Column.Parameter(recipientInfo.ContactId))
				.Set("EmailAddress", Column.Parameter(recipientInfo.EmailAddress))
				.Set("MandrillId", Column.Parameter(recipientInfo.Id))
				.Set("BulkEmailResponseId", Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId));
				insert.Execute();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Configures properties of current instance.
		/// </summary>
		public virtual void Configure() {
			Validator = new BulkEmailValidator(UserConnection, ServiceApi);
			TemplateSizeValidator = new TemplateSizeValidator();
			InitTemplateFactory();
		}

		/// <summary>
		/// Breaks process of sending.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>Returns status of bulk email.</returns>
		public MailingResponse BreakMailing(Guid bulkEmailId) {
			var bulkEmail = new BulkEmail(UserConnection);
			var response = new MailingResponse {
				Success = false,
				StatusId = Guid.Empty
			};
			if (!bulkEmail.FetchFromDB("Id", bulkEmailId, new[] {"Id","Status" })) {
				MailingUtilities.Log.InfoFormat("Cannot access record with Id: {0}.", bulkEmailId);
				return response;
			}
			var providerStopResult = StopBulkEmailInProvider(bulkEmail.Id);
			if (!providerStopResult) {
				return response;
			}
			var newBulkEmailStatusId = SetBulkEmailBreakingStatus(bulkEmail);
			response.Success = true;
			response.StatusId = newBulkEmailStatusId;
			return response;
		}

		/// <summary>
		/// Starts sending of the bulk email with the sessionId.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="sessionId">Guid identifier of the current trigger mailing session</param>
		/// <param name="isDelayedStart">Delay sending.</param>
		/// <returns>Returns status of bulk email.</returns>
		public MailingResponse SendMessage(Guid bulkEmailId, Guid sessionId, bool isDelayedStart = false,
				string applicationUrl = "") {
			_mailingSessionId = sessionId;
			return SendMessage(bulkEmailId, isDelayedStart, applicationUrl);
		}

		/// <summary>
		/// Starts sending of the bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="isDelayedStart">Delay sending.</param>
		/// <returns>Returns status of bulk email.</returns>
		public MailingResponse SendMessage(Guid bulkEmailId, bool isDelayedStart = false,
				string applicationUrl = "") {
			DateTime startSendingTime = DateTime.UtcNow;
			var bulkEmail = GetBulkEmailFromDB(bulkEmailId);
			var response = CreateErrorMailingResponse();
			if (!ValidateBulkEmail(bulkEmailId, bulkEmail, response)) {
				return response;
			}
			RegisterSenderDomain(bulkEmail.SenderEmail);
			if (bulkEmail.StartDate != DateTime.MinValue && !isDelayedStart) {
				BulkEmailEventLogger.LogInfo(bulkEmail.Id, startSendingTime,
					GetLczStringValue("StartSendingEmail"), GetLczStringValue("StartSendingScheduledEmailDescription"),
					UserConnection.CurrentUser.ContactId, bulkEmail.StartDate.ToString("yyyy-MM-dd HH:mm:ss\" GMT\"zzz"));
				SetBulkEmailStatus(bulkEmail, MailingConsts.BulkEmailStatusStartPlanedId);
			} else {
				CultureInfo culture = Thread.CurrentThread.CurrentCulture;
				SetSendStartDate(bulkEmail);
				SendingEmailProgressRepository.IncrementReceivedInitialResponses(bulkEmail.Id);
				if(bulkEmail.CategoryId == MailingConsts.MassmailingBulkEmailCategoryId
						&& bulkEmail.LaunchOptionId == MailingConsts.BulkEmailManaulLaunchOptionId) {
					SetBulkEmailStatus(bulkEmail, MailingConsts.BulkEmailStatusWaitingBeforeSendId);
					new System.Threading.Tasks.Task(()=> StartSendBulkEmail(bulkEmail, culture, startSendingTime)).Start();
				} else {
					try {
						SendDCMessage(bulkEmail, culture);
					} catch (Exception e) {
						MailingUtilities.Log.ErrorFormat("[CESMailingProvider.SendMessage]: BulkEmail with " +
							"Id: {0} sendAction execution error", e, bulkEmail.Id);
						BulkEmailEventLogger.LogError(bulkEmail.Id, DateTime.UtcNow,
							GetLczStringValue("BatchSendEvent"), e, GetLczStringValue("SendEmailErroMsg"),
							UserConnection.CurrentUser.ContactId);
						return response;
					}
				}
			}
			response.Success = true;
			response.StatusId = bulkEmail.StatusId;
			return response;
		}

		private void SetSendStartDate(BulkEmail bulkEmail) {
			var sendStartDate = DateTime.UtcNow;
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmail.Id, UserConnection,
				new KeyValuePair<string, object>("SendStartDate", sendStartDate));
			bulkEmail.SendStartDate = sendStartDate;
		}

		private void StartSendBulkEmail(BulkEmail bulkEmail, CultureInfo culture, DateTime startSendingTime) {
			PerformWaitBeforeSend(bulkEmail);
			Guid currentBulkEmailStatus = BulkEmailQueryHelper.GetBulkEmailStatus(bulkEmail.Id, UserConnection);
			if (currentBulkEmailStatus == MailingConsts.BulkEmailStatusStoppedId) {
				MailingUtilities.Log.InfoFormat(
					"[CESMaillingProvider.ExecuteSendMessageTask]: Break iterations. " +
					"BulkEmail.Id {0} has status 'Stopped'.", bulkEmail.Id);
			} else {
				BulkEmailQueryHelper.UpdateBulkEmail(bulkEmail.Id, UserConnection,
					new KeyValuePair<string, object>("StartDate", DateTime.UtcNow));
				DcSendActionData sendActionData = new DcSendActionData {
					CultureInfo = culture.Name,
					BulkEmailId = bulkEmail.Id,
					StartSendingTime = startSendingTime
				};
				RunDCSendActionAsync(sendActionData);
			}
		}

		/// <summary>
		/// Gets throttling schedules for the current user by the required strategy.
		/// </summary>
		/// <param name="getThrottlingScheduleRequest">Request instance with the required service id.</param>
		/// <returns>Throttling for the current user by the required strategy.</returns>
		public GetThrottlingSchedulesResponse GetThrottlingSchedules(
			GetThrottlingScheduleRequest getThrottlingScheduleRequest) {
			getThrottlingScheduleRequest.ApiKey = _serviceApi.ApiKey;
			return _serviceApi.GetThrottlingSchedules(getThrottlingScheduleRequest);
		}

		/// <summary>
		/// Starts sending of the message.
		/// </summary>
		/// <param name="messageInfo">Object that holds information about message.</param>
		/// <returns>Status of message.</returns>
		[Obsolete("Will be removed after 7.17.3")]
		public MailingResponse SendMessage(IMessageInfo messageInfo) {
			messageInfo.PrepareMessage(UserConnection);
			if (!messageInfo.Validate()) {
				return new MailingResponse {
					StatusId = MailingConsts.BulkEmailStatusErrorId,
					Success = false
				};
			}
			bool sendMessageResult = false;
			try {
				PrepareInitialResponses(messageInfo.Recipients);
				sendMessageResult = ExecuteSendMessage(messageInfo);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[CESMailingProvider.SendMessage]: "
					+ "Error occurred while send message", e);
				return new MailingResponse {
					StatusId = MailingConsts.BulkEmailStatusErrorId,
					Success = false
				};
			}
			AddContactToBulkEmailAudience(messageInfo);
			messageInfo.UpdateMessageInfo(UserConnection, !sendMessageResult);
			return new MailingResponse {
				StatusId = MailingConsts.BulkEmailStatusFinishedId,
				Success = true
			};
		}

		/// <summary>
		/// Sends test email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="contactId">Unique identifier of the contact from audience.</param>
		/// <param name="emailRecipient">Email address of the recipient.</param>
		/// <returns>Returns result of successful sending.</returns>
		public bool SendTestMessage(Guid bulkEmailId, Guid contactId, string emailRecipient) {
			var result = SendDCTestMessage(new SendTestMessageData {
				ContactId = contactId,
				EmailRecipients = emailRecipient,
				BulkEmailId = bulkEmailId
			});
			return result.Success;
		}

		/// <summary>
		/// Sends test bulk email message with dynamic content. Sends all replicas if 
		/// <see cref="SendTestMessageData.ReplicaMasks"/> property of the parameter <paramref name="data"/>
		/// is null or empty, or chosen replicas in another case.
		/// </summary>
		/// <param name="data">Data required for test message sending.</param>
		/// <returns>Results of successful sending for each replica.</returns>
		public SendTestMessageResult SendDCTestMessage(SendTestMessageData data) {
			if (!PingProvider(data.BulkEmailId)) {
				BulkEmailEventLogger.LogInfo(data.BulkEmailId, DateTime.UtcNow, GetLczStringValue("PingCes"),
					GetLczStringValue("PingCesDescription"), UserConnection.CurrentUser.ContactId);
				return new SendTestMessageResult {
					Success = false
				};
			}
			InitMacroParser(data.BulkEmailId);
			var executor = new ImmediateEmailExecutor(UserConnection) {
				TemplateFactory = TemplateFactory,
				CloudEngine = CloudEngine,
				ServiceApi = ServiceApi,
				Validator = Validator,
				BulkEmailMacroParser = BulkEmailMacroParser,
				TemplateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection)
			};
			return executor.Send(data);
		}

		/// <summary>
		/// Validates message.
		/// </summary>
		/// <param name="messageId">Unique identifier of the message.</param>
		/// <returns>Validation result.</returns>
		public ConfigurationServiceResponse ValidateMessage(Guid messageId) {
			return ValidateMessages(new[] { messageId });
		}

		/// <summary>
		/// Validates messages.
		/// </summary>
		/// <param name="messageIds">Unique identifiers of the message.</param>
		/// <returns>Validation result.</returns>
		public ConfigurationServiceResponse ValidateMessages(Guid[] messageIds) {
			return Validator.ValidateMessages(messageIds, 0);
		}

		/// <summary>
		/// Validates single email.
		/// </summary>
		/// <param name="messageId">Unique identifiers of the message.</param>
		/// <param name="recipientsCount">Recipients count to validate for sending limit.
		/// If 0 - counts recipients from audience with "Ready to send" response.</param>
		/// <returns>Validation result.</returns>
		public ConfigurationServiceResponse ValidateMessage(Guid messageId, int recipientsCount) {
			return Validator.ValidateMessages(new[] { messageId }, recipientsCount);
		}

		/// <summary>
		/// Validates status of bulk emails.
		/// </summary>
		/// <param name="bulkEmailIds">Unique identifiers of the message.</param>
		/// <returns>Validation result.</returns>
		public ConfigurationServiceResponse ValidateDraftStatus(Guid[] bulkEmailIds) {
			return Validator.ValidateDraftStatus(bulkEmailIds);
		}

		/// <summary>
		/// Ping provider's service.
		/// </summary>
		public bool PingProvider() {
			try {
				if (string.IsNullOrWhiteSpace(ServiceApi.BaseUrl)) {
					return false;
				}
				ServiceApi.Ping();
				return true;
			} catch (Exception) {
				return false;
			}
		}

		/// <summary>
		/// Method to run async send action with user connection.
		/// </summary>
		/// <param name="data"><see cref="DcSendActionData">Data to be used for async sending.</param>
		public void Run(DcSendActionData data) {
			Configure();
			var bulkEmail = GetBulkEmailFromDB(data.BulkEmailId);
			var culture = CultureInfo.GetCultureInfo(data.CultureInfo);
			SendDCMessage(bulkEmail, culture);
		}

		/// <summary>
		/// Method to set user connection when run async task.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public virtual void SetUserConnection(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

	}

	#endregion

}
