namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Polly;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.Mailing;
	using BPMSoft.Configuration.Marketing.Utilities;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: SendingMailingState

	public class SendingMailingState : MailingState
	{

		#region Constants: Private

		private const string BulkEmailIdPropertyName = "bulkEmailId";
		private const string MassMailingTag = "mass_mailing";
		private const string TriggeredEmailTag = "triggered_email";
		private const int RecipientBatchSize = 3000;

		#endregion

		#region Fields: Private

		private static readonly int _retryCount = 3;
		private readonly Context _retryContext;
		private readonly Policy _retryPolicy;
		private MacroValuesDataSource _macroValuesDataSource;
		private SendingAudienceDataSource _sendingAudienceDataSource;

		private static readonly MailingResponseCode[] _orderedResponse = {
			MailingResponseCode.CanceledIncorrectEmail,
			MailingResponseCode.CanceledBlankEmail,
			MailingResponseCode.CanceledInvalidEmail,
			MailingResponseCode.Unsub,
			MailingResponseCode.CanceledUnsubscribedByType,
			MailingResponseCode.Duplicated,
			MailingResponseCode.CanceledTemplateNotFound,
			MailingResponseCode.CanceledSendersDomainNotVerified,
			MailingResponseCode.CanceledSendersNameNotValid,
			MailingResponseCode.CanceledCommunicationLimit,
			MailingResponseCode.RequestFailed
		};
		#endregion

		#region Constructors: Public

		public SendingMailingState() {
			_retryPolicy = Policy.Handle<Exception>().Retry(_retryCount,
				(exception, retryIteration, context) => OnRetry(context, retryIteration, exception));
			_retryContext = new Context("SendingRetryPolicy");
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		protected override string ErrorMessageStringCode => "ExecuteSendMessageErrorMsg";

		protected override string EventLczStringCode => "BatchSendEvent";

		#endregion

		#region Properties: Public

		public ICESApi ServiceApi { get; set; }

		public BulkEmailRecipientValidator RecipientsValidator { get; set; }

		public SendingAudienceDataSource SendingAudienceDataSource {
			get =>
				_sendingAudienceDataSource ?? (_sendingAudienceDataSource =
					ClassFactory.Get<SendingAudienceDataSource>(
						new ConstructorArgument("userConnection", UserConnection),
						new ConstructorArgument("email", null)));
			set => _sendingAudienceDataSource = value;
		}

		public MacroValuesDataSource MacroValuesDataSource {
			get => _macroValuesDataSource ?? (_macroValuesDataSource = InitMacroValuesDataSource());
			set => _macroValuesDataSource = value;
		}

		public override Guid[] AvailableForExecutionStatuses =>
			new[] { MailingConsts.BulkEmailStatusStartsId, MailingConsts.BulkEmailStatusLaunchedId };

		#endregion

		#region Methods: Private

		private static void OnRetry(Context context, int retryIteration, Exception exception) {
			MailingUtilities.Log.WarnFormat(
				$"[SendingMailingState]: Error while audience sending. Email: {context[BulkEmailIdPropertyName]} " +
				$"and iteration {retryIteration - 1}. ", exception);
		}

		private bool BuildAudienceAndSendToProvider() {
			SendMessageData messageData = CreateSendMessageData(Context.BulkEmailEntity as BulkEmail);
			BulkEmail bulkEmail = messageData.BulkEmail;
			var sendResults = new List<TypedCounter<MailingResponseCode>>();
			BulkEmailQueryHelper.ResetBulkEmailCounters(messageData.BulkEmailRId, UserConnection);
			_sendingAudienceDataSource = ClassFactory.Get<SendingAudienceDataSource>(
				new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("email", bulkEmail));
			while (CanHandle() && GetAudienceBatch() is var recipients && recipients.Any()) {
				Context.BatchNumber++;
				MailingUtilities.Log.InfoFormat($"[SendingMailingState.BuildAudienceAndSendToProvider]: " +
					$"Set BatchId - {Context.BatchNumber}. BulkEmail.Id {bulkEmail.Id}.");
				messageData.BulkEmail = bulkEmail;
				messageData.EmailMessage = InitEmailMessage(messageData);
				messageData.EmailMessage.InitRecipientVariable();
				messageData.BatchId = Context.BatchNumber;
				DateTime startGetRecipientTime = DateTime.UtcNow;
				RecipientsValidator.Validate(recipients);
				LogRecipientState(recipients, bulkEmail.Id, Context.BatchNumber, startGetRecipientTime);
				var validRecipients = GetValidRecipient(recipients);
				messageData.EmailMessage.to = CreateEmailAddresses(validRecipients);
				var sentResult = true;
				if (messageData.EmailMessage.to.Any()) {
					sentResult = SendBatch(messageData);
				}
				if (!sentResult) {
					recipients.Where(x => x.InitialResponseCode == (int)MailingResponseCode.PostedProvider).ForEach(y =>
						y.InitialResponseCode = (int)MailingResponseCode.RequestFailed);
				}
				SendingEmailProgressRepository.IncrementProcessedRecipients(bulkEmail.Id, recipients.Count());
				var resultsCounter = UpdateSendEmailIterationResult(recipients);
				SendingEmailProgressRepository.IncrementPreparedRecipients(bulkEmail.Id,
					resultsCounter.Get("TemplateNotFound"));
				sendResults.Add(resultsCounter);
				SendMessagePostProcessing(messageData, sendResults);
			}
			return sendResults.Any();
		}

		private IEnumerable<EmailAddress> CreateEmailAddresses(IEnumerable<IMessageRecipientInfo> recipients) {
			var emailAddresses = new List<EmailAddress>();
			foreach (IMessageRecipientInfo recipient in recipients) {
				var emailAddress = new EmailAddress(recipient.Id, recipient.EmailAddress);
				if (recipient is IDCRecipientInfo dcRecipient) {
					emailAddress.replica_id = dcRecipient.ReplicaId;
				}
				if (recipient is IDCRecipientInfo macrosInfo) {
					emailAddress.rcpt_merge_var = CreateRecipientMergeVar(recipient.EmailAddress, macrosInfo.Macros);
				}
				emailAddresses.Add(emailAddress);
			}
			return emailAddresses;
		}

		private rcpt_merge_var
			CreateRecipientMergeVar(string recipientEmailAddress, Dictionary<string, string> macros) {
			return new rcpt_merge_var {
				rcpt = recipientEmailAddress,
				vars = macros.Select(x => new merge_var {
					name = x.Key,
					content = x.Value
				}).ToList()
			};
		}

		private TypedCounter<MailingResponseCode> CreateResultsCounter() {
			var resultsCounter = new TypedCounter<MailingResponseCode>();
			resultsCounter.Register("InvalidAddressee", MailingResponseCode.Invalid);
			resultsCounter.Register("BlankEmail", MailingResponseCode.CanceledBlankEmail);
			resultsCounter.Register("DoNotUseEmail", MailingResponseCode.CanceledDoNotUseEmail);
			resultsCounter.Register("UnsubscribedByType", MailingResponseCode.CanceledUnsubscribedByType);
			resultsCounter.Register("IncorrectEmail", MailingResponseCode.CanceledIncorrectEmail);
			resultsCounter.Register("UnreachableEmail", MailingResponseCode.CanceledInvalidEmail);
			resultsCounter.Register("CommunicationLimit", MailingResponseCode.CanceledCommunicationLimit);
			resultsCounter.Register("TemplateNotFound", MailingResponseCode.CanceledTemplateNotFound);
			resultsCounter.Register("SendersDomainNotVerified", MailingResponseCode.CanceledSendersDomainNotVerified);
			resultsCounter.Register("SendersNameNotValid", MailingResponseCode.CanceledSendersNameNotValid);
			resultsCounter.Register("DuplicateEmail", MailingResponseCode.Duplicated);
			return resultsCounter;
		}

		private SendMessageData CreateSendMessageData(BulkEmail bulkEmail) {
			DateTime startDateUtc = TimeZoneInfo.ConvertTimeToUtc(bulkEmail.StartDate,
				UserConnection.CurrentUser.TimeZone);
			var messageData = new SendMessageData {
				UserConnection = UserConnection,
				BulkEmail = bulkEmail,
				BulkEmailStartDate = startDateUtc,
			};
			return messageData;
		}

		private bool ExecuteSendingWithRetry(BulkEmail bulkEmail) {
			_retryContext[BulkEmailIdPropertyName] = bulkEmail.Id;
			return _retryPolicy.Execute(BuildAudienceAndSendToProvider, _retryContext);
		}

		private BulkEmailRecipientInfo[] GetAudienceBatch() {
			var recipients = SendingAudienceDataSource.GetAudience(Context.StartedOn, RecipientBatchSize).ToArray();
			if (!recipients.Any()) {
				return recipients;
			}
			var recipientsWithMacro = PopulateRecipientsMacros(recipients);
			return recipientsWithMacro.ToArray();
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

		private TypedCounter<MailingResponseCode> GetResultCounter(IEnumerable<IMessageRecipientInfo> recipients) {
			var resultsCounter = CreateResultsCounter();
			foreach (IMessageRecipientInfo recipient in recipients) {
				resultsCounter.Count((MailingResponseCode)recipient.InitialResponseCode);
			}
			return resultsCounter;
		}

		private IEnumerable<IMessageRecipientInfo>
			GetValidRecipient(IEnumerable<IMessageRecipientInfo> recipientsBatch) {
			var validRecipients = recipientsBatch.Where(item =>
				item.InitialResponseCode == (int)MailingResponseCode.PostedProvider);
			return validRecipients;
		}

		private void HandleEmailResult(IEnumerable<IMessageRecipientInfo> recipients) {
			var batchSize = 500;
			var groupedRecipients = recipients.GroupBy(r => r.InitialResponseCode);
			foreach (var recipientsByResponse in groupedRecipients) {
				ProcessRecipientResponseGroup(recipientsByResponse, batchSize);
			}
		}

		private EmailMessage InitEmailMessage(SendMessageData messageData) {
			BulkEmail bulkEmail = messageData.BulkEmail;
			var message = new EmailMessage {
				track_clicks = true,
				track_opens = true,
				images = messageData.Images,
				inline_css = true
			};
			message.tags = GetBulkEmailCategoryTags(bulkEmail);
			return message;
		}

		private MacroValuesDataSource InitMacroValuesDataSource() {
			var macroValuesDataSource = ClassFactory.Get<MacroValuesDataSource>(
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("linkedEntitySchemaName", Context.LinkedEntitySchemaName));
			return macroValuesDataSource;
		}

		private void LogRecipientState(BulkEmailRecipientInfo[] recipients, Guid bulkEmailId, int batchId,
			DateTime startDate) {
			if (!recipients.Any()) {
				return;
			}
			int validCount = recipients.Count(x => x.InitialResponseCode == (int)MailingResponseCode.PostedProvider);
			var tinyMessages = new List<string> {
				string.Format(GetLczStringValue("PrepareBatchDescription"), batchId, recipients.Length, validCount)
			};
			var responseCounters = _orderedResponse.Select(response => new {
				Count = recipients.Count(r => r.InitialResponseCode == (int)response),
				Response = response
			}).Where(x => x.Count > 0);
			var responseDetailedMessages = responseCounters
				.Select(c => string.Format(GetLczStringValue($"{c.Response}Message"), c.Count)).ToArray();
			tinyMessages.AddRange(responseDetailedMessages);
			var logMessage = string.Join(", ", tinyMessages);
			logMessage += ".";
			var eventHeader = string.Format(GetLczStringValue("PrepareBatch"), RecipientBatchSize);
			BulkEmailEventLogger.LogInfo(bulkEmailId, startDate, eventHeader, logMessage,
				UserConnection.CurrentUser.ContactId);
		}

		private void LogSendingComplete(BulkEmail bulkEmail, Guid bulkEmailId, DateTime startSendingTime) {
			if (bulkEmail.CategoryId.Equals(MailingConsts.MassmailingBulkEmailCategoryId)) {
				CreateReminding(bulkEmail, "CESMassMailingFinishedMsg");
			}
			var providerNameMessage = !string.IsNullOrEmpty(bulkEmail.ProviderName) ? 
				$". {GetLczStringValue("EmailSentProvider")} { bulkEmail.ProviderName}"
				: string.Empty;
			var emailSentMessage = $"{GetLczStringValue("EmailSent")}{providerNameMessage}";
			BulkEmailEventLogger.LogInfo(bulkEmailId, startSendingTime, emailSentMessage,
				GetLczStringValue("EmailSentDescription"), UserConnection.CurrentUser.ContactId);
		}

		private void LogSendingStart(BulkEmail bulkEmail, DateTime startSendingTime) {
			var providerNameMessage = !string.IsNullOrEmpty(bulkEmail.ProviderName) ?
				$". {GetLczStringValue("EmailSentProvider")} { bulkEmail.ProviderName}"
				: string.Empty;
			var startSendingMessage = $"{GetLczStringValue("StartSendingEmail")}{providerNameMessage}";
			BulkEmailEventLogger.LogInfo(bulkEmail.Id, startSendingTime, startSendingMessage,
				GetLczStringValue("StartSendingEmailDescription"), UserConnection.CurrentUser.ContactId);
			MailingUtilities.Log.Info("[SendingMailingState.ExecuteSendMessage]: Start sending bulk email. " + 
				$"Id: {bulkEmail.Id}");
		}

		private IEnumerable<BulkEmailRecipientInfo> PopulateRecipientsMacroByReplica(CESMailingTemplate template,
			IEnumerable<BulkEmailRecipientInfo> recipientsWithoutMacro) {
			var bulkEmail = Context.BulkEmailEntity as BulkEmail;
			var macrosCollection = template.MacrosCollection;
			MacroValuesDataSource.TrackedAliases = template.TrackedAliases;
			var recipientsByReplica = recipientsWithoutMacro.Where(x => x.ReplicaId == template.ReplicaId).ToArray();
			var recipientContracts = recipientsByReplica.Select(x => new RecipientMacroContract {
				ContactId = x.ContactId,
				LinkedEntityId = x.LinkedEntityId,
				RecipientUId = x.Id
			});
			var globalMacros =
				MacroValuesDataSource.GetGlobalMacrosValues(bulkEmail.Id, bulkEmail.OwnerId, macrosCollection);
			var recipientsMacro =
				MacroValuesDataSource.GetMacroValues(recipientContracts, globalMacros, macrosCollection);
			foreach (BulkEmailRecipientInfo bulkEmailRecipientInfo in recipientsByReplica) {
				var macros = recipientsMacro[bulkEmailRecipientInfo.Id];
				bulkEmailRecipientInfo.Macros = macros.ToDictionary(x => x.Alias, x => x.Value);
			}
			return recipientsByReplica;
		}

		private IEnumerable<BulkEmailRecipientInfo> PopulateRecipientsMacros(
			IEnumerable<BulkEmailRecipientInfo> recipients) {
			var recipientsWithoutMacro = recipients.Where(x =>
				x.Macros.IsNullOrEmpty() && x.InitialResponseCode == (int)MailingResponseCode.PostedProvider).ToArray();
			var exceptedRecipients = recipients.Where(x =>
				!x.Macros.IsNullOrEmpty() || x.InitialResponseCode != (int)MailingResponseCode.PostedProvider).ToArray();
			var templates = Context.MailingTemplates.Select(x => x as CESMailingTemplate).Where(x =>
				recipientsWithoutMacro.Any(r => r.ReplicaId == x.ReplicaId));
			var populatedRecipients = new List<BulkEmailRecipientInfo>();
			foreach (CESMailingTemplate template in templates) {
				var recipientsByReplica = PopulateRecipientsMacroByReplica(template, recipientsWithoutMacro);
				populatedRecipients.AddRange(recipientsByReplica);
			}
			return exceptedRecipients.Concat(populatedRecipients);
		}

		private void ProcessRecipientResponseGroup(IGrouping<int, IMessageRecipientInfo> recipientsByResponse,
			int batchSize) {
			var processedCount = 0;
			int groupCount = recipientsByResponse.Count();
			while (processedCount < groupCount) {
				var recipientsToUpdate = recipientsByResponse.Skip(processedCount).Take(batchSize);
				Guid responseId =
					BulkEmailResponseMapping.GetResponseIdByCode(UserConnection, recipientsByResponse.Key);
				var updateInitialResponse = new Update(UserConnection, "BulkEmailTarget")
					.Set("BulkEmailResponseId", Column.Parameter(responseId))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where("MandrillId")
					.In(Column.Parameters(recipientsToUpdate.Select(x => x.Id))) as Update;
				updateInitialResponse.WithHints(new RowLockHint());
				processedCount += updateInitialResponse.Execute();
			}
		}

		private bool SendBatch(SendMessageData messageData) {
			MailingUtilities.Log.InfoFormat(
				$"[SendingMailingState.SendBatch]: Start: BulkEmailId: {messageData.BulkEmail.Id}. GroupId {messageData.BatchId}.");
			bool sendResult;
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
					$"[SendingMailingState.SendBatch]: Error while sending BulkEmail with Id: {messageData.BulkEmail.Id}. " +
					$"SessionId: {messageData.SessionId}. GroupId {messageData.BatchId}.", e);
				BulkEmailEventLogger.LogError(messageData.BulkEmail.Id, DateTime.UtcNow,
					GetLczStringValue("BatchSendEvent"), e, GetLczStringValue("BatchSendErrorMsg"),
					UserConnection.CurrentUser.ContactId, messageData.BulkEmail);
				sendResult = false;
			}
			return sendResult;
		}

		private void SendMessagePostProcessing(SendMessageData sendMessageData,
			List<TypedCounter<MailingResponseCode>> sendResults) {
			BulkEmail bulkEmail = sendMessageData.BulkEmail;
			Guid sessionId = sendMessageData.SessionId;
			int blankEmailCount = sendResults.Sum("BlankEmail");
			int doNotUseEmailCount = sendResults.Sum("DoNotUseEmail");
			int unsubscribedByTypeCount = sendResults.Sum("UnsubscribedByType");
			int incorrectEmailCount = sendResults.Sum("IncorrectEmail");
			int unreachableEmailCount = sendResults.Sum("UnreachableEmail");
			int communicationLimitCount = sendResults.Sum("CommunicationLimit");
			int duplicateEmailCount = sendResults.Sum("DuplicateEmail");
			int templateNotFoundCount = sendResults.Sum("TemplateNotFound");
			int sendersDomainNotVerifiedCount = sendResults.Sum("SendersDomainNotVerified");
			int sendersNameNotValidCount = sendResults.Sum("SendersNameNotValid");
			int invalidAddresseeCount = sendResults.Sum("InvalidAddressee");
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmail.Id, UserConnection,
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
				"[SendingMailingState.ExecuteSendMessage]: Finished: BulkEmail.Id: {0}, SessionId: {1}", bulkEmail.Id,
				sessionId);
			SendingEmailProgressRepository.IncrementReceivedInitialResponses(bulkEmail.Id);
		}

		private void SetBulkEmailQueuedStatus(BulkEmail bulkEmail) {
			Guid status;
			if (MailingConsts.TriggeredEmailBulkEmailCategoryId.Equals(bulkEmail.CategoryId)) {
				status = MailingConsts.BulkEmailStatusActiveId;
			} else if (MailingConsts.MassmailingBulkEmailCategoryId.Equals(bulkEmail.CategoryId)) {
				var throttlingFeatureEnabled = UserConnection.GetIsFeatureEnabled("BulkEmailThrottlingQueue");
				status = throttlingFeatureEnabled ? MailingConsts.BulkEmailStatusQueuedId : MailingConsts.BulkEmailStatusFinishedId;
			} else {
				throw new ArgumentException(string.Format("Unknown BulkEmail category: {0}.", bulkEmail.CategoryId));
			}
			SetBulkEmailStatus(bulkEmail.Id, status);
		}

		private void SendBulkEmailToQueue(BulkEmail bulkEmail) {
			if (!CanHandle()) {
				return;
			}
			SetBulkEmailQueuedStatus(bulkEmail);
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmail.Id, UserConnection,
				new KeyValuePair<string, object>("SendDueDate", DateTime.UtcNow));
		}

		private void UpdateBulkEmailBeforeSend(Guid bulkEmailId) {
			if(!CanHandle()) {
				return;
			}
			int recipientCount = BulkEmailQueryHelper.GetRecipientsInQueueCount(bulkEmailId, UserConnection);
			BulkEmailQueryHelper.UpdateBulkEmail(bulkEmailId, UserConnection,
				new KeyValuePair<string, object>("InQueueCount", recipientCount),
				new KeyValuePair<string, object>("RecipientCount", recipientCount),
				new KeyValuePair<string, object>("StatusId", MailingConsts.BulkEmailStatusLaunchedId));
		}

		private TypedCounter<MailingResponseCode> UpdateSendEmailIterationResult(
			IEnumerable<IMessageRecipientInfo> recipients) {
			HandleEmailResult(recipients);
			return GetResultCounter(recipients);
		}
		
		private void SetBulkEmailSplitStatus(UserConnection userConnection, Guid splitTestId) {
			var bulkEmailSplit = new BulkEmailSplit(userConnection);
			if (!bulkEmailSplit.FetchFromDB(splitTestId)) {
				MailingUtilities.Log.ErrorFormat(
					"[CESMaillingProvider.SetBulkEmailSplitStatus]: Failed to fetch BulkEmailSplit from DB." + "Id: {0}",
					splitTestId);
				return;
			}
			var selectCount = new Select(userConnection).Column(Func.Count("Id")).From("BulkEmail").Where("SplitTestId")
				.IsEqual(Column.Parameter(splitTestId)).And("StatusId")
				.IsNotEqual(Column.Parameter(MailingConsts.BulkEmailStatusFinishedId)) as Select;
			var count = selectCount.ExecuteScalar<int>();
			if (count == 0) {
				bulkEmailSplit.SetColumnValue("StatusId", MailingConsts.BulkEmailSplitStatusFinishedId);
				string tableName = string.Format("ST_{0}", splitTestId.ToBase36());
				Utilities.DropTable(tableName, userConnection, true);
			}
			bulkEmailSplit.Save();
		}

		#endregion

		#region Methods: Protected

		protected override MailingStateExecutionResult HandleStepInternal() {
			var bulkEmail = (BulkEmail)Context.BulkEmailEntity;
			DateTime startSendingTime = DateTime.UtcNow;
			Guid bulkEmailId = bulkEmail.Id;
			if (Context.BatchNumber == 0) {
				LogSendingStart(bulkEmail, startSendingTime);
			}
			UpdateBulkEmailBeforeSend(bulkEmailId);
			var anyRecordSent = ExecuteSendingWithRetry(bulkEmail);
			if (!anyRecordSent) {
				SendBulkEmailToQueue(bulkEmail);
				LogSendingComplete(bulkEmail, bulkEmailId, startSendingTime);
			}
			return new MailingStateExecutionResult(this.GetType()) {
				Success = true,
				Status = anyRecordSent ? MailingStateExecutionStatus.Continue : MailingStateExecutionStatus.Done
			};
		}
		
		/// <summary>
		/// Sets the bulk email status.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="bulkEmailStatusId">The bulk email status identifier.</param>
		protected override void SetBulkEmailStatus(Guid bulkEmailId, Guid bulkEmailStatusId) {
			base.SetBulkEmailStatus(bulkEmailId, bulkEmailStatusId);
			var bulkEmail = Context.BulkEmailEntity as BulkEmail;
			var throttlingFeatureEnabled = UserConnection.GetIsFeatureEnabled("BulkEmailThrottlingQueue");
			if (!throttlingFeatureEnabled && bulkEmail.SplitTestId != Guid.Empty) {
				SetBulkEmailSplitStatus(UserConnection, bulkEmail.SplitTestId);
			}
		}

		#endregion

		#region Methods: Public

		public override void Initialize() {
			base.Initialize();
			UserConnection = Context.UserConnection;
			ServiceApi = Context.ServiceApi;
			var validationBuilder = new BulkEmailRecipientValidatorBuilder(ServiceApi, Context.BulkEmailEntity);
			RecipientsValidator = new BulkEmailRecipientValidator(validationBuilder);
		}

		#endregion

	}

	#endregion

}

