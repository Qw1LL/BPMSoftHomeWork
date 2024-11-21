namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.Mailing;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: BulkEmailValidator

	/// <summary>
	/// Provides methods to validate bulkemail before sending.
	/// </summary>
	public class BulkEmailValidator
	{

		#region Fields: Private

		private readonly ICESApi _serviceApi;

		private BulkEmailEventLogger _bulkEmailEventLogger;

		private BulkEmailMacroParser _bulkEmailMacroParser;

		#endregion

		#region Constructors: Public

		public BulkEmailValidator(UserConnection userConnection, ICESApi cesApi) {
			_serviceApi = cesApi;
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected string LinkedEntitySchemaName { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets the bulk email event logger.
		/// </summary>
		/// <value>
		/// The bulk email event logger.
		/// </value>
		public BulkEmailEventLogger BulkEmailEventLogger =>
			_bulkEmailEventLogger ?? (_bulkEmailEventLogger = new BulkEmailEventLogger(UserConnection));

		/// <summary>
		/// Gets or sets the bulk email macro parser.
		/// </summary>
		/// <value>
		/// The bulk email macro parser.
		/// </value>
		public BulkEmailMacroParser BulkEmailMacroParser {
			get => _bulkEmailMacroParser ?? (_bulkEmailMacroParser = GetMacroParser());
			set => _bulkEmailMacroParser = value;
		}

		/// <summary>
		/// Gets or sets the user connection.
		/// </summary>
		/// <value>
		/// The user connection.
		/// </value>
		public UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private void AddBulkEmailEventLogMessage(Guid bulkEmailId, string lczEvent, string lczDescription,
			params object[] parameters) {
			var messageTemplate = GetLczStringValue(lczDescription);
			var message = parameters == null || parameters.Length < 1 ? messageTemplate
				: string.Format(messageTemplate, parameters);
			BulkEmailEventLogger.LogError(bulkEmailId, DateTime.UtcNow, GetLczStringValue(lczEvent), message,
				UserConnection.CurrentUser.ContactId);
		}

		private EmailSendingLimitValidator CreateChainOfBulkEmailValidators() {
			var emailSendingValidator = new EmailSendingLimitValidator();
			emailSendingValidator
				.SetNext(new TemplateSizeValidator())
				.SetNext(new SenderValidator())
				.SetNext(new ProviderValidator());
			return emailSendingValidator;
		}

		private string GetLczStringValue(string lczName) {
			var localizableStringName = $"LocalizableStrings.{lczName}.Value";
			var localizableString = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"CESMaillingProvider", localizableStringName);
			var value = localizableString.Value ??
				localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			return value;
		}

		private BulkEmailMacroParser GetMacroParser() {
			var macrosHelper = ClassFactory.Get<MacrosHelperV2>();
			macrosHelper.UserConnection = UserConnection;
			var bulkEmailMacroParser = ClassFactory.Get<BulkEmailMacroParser>(
				new ConstructorArgument("macrosHelper", macrosHelper),
				new ConstructorArgument("linkedEntitySchemaName", LinkedEntitySchemaName));
			return bulkEmailMacroParser;
		}

		private string GetStatusValidationExceptionMessage(string lczPattern, IEnumerable<string> bulkEmails) {
			var emails = string.Join(", ", bulkEmails.Select(x => $"\"{x}\""));
			var lczName = bulkEmails.Count() == 1 ? string.Format(lczPattern, "Singular")
				: string.Format(lczPattern, "Plural");
			var message = GetLczStringValue(lczName);
			return string.Format(message, emails);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates the bulk email to not be in draft status.
		/// </summary>
		/// <param name="bulkEmailIds">The bulk email ids.</param>
		/// /// <returns>Instance of <see cref="ConfigurationServiceResponse"/></returns>
		public ConfigurationServiceResponse ValidateDraftStatus(Guid[] bulkEmailIds) {
			var response = new ConfigurationServiceResponse();
			if (!bulkEmailIds.Any()) {
				return response;
			}
			var draftEmails = new List<string>();
			foreach (var messageId in bulkEmailIds) {
				var status = BulkEmailQueryHelper.GetBulkEmailStatus(messageId, UserConnection);
				if (status == MarketingConsts.BulkEmailStatusDraftId) {
					var bulkEmailName = BulkEmailQueryHelper.GetBulkEmailName(messageId, UserConnection);
					draftEmails.Add(bulkEmailName);
				}
			}
			if (!draftEmails.Any()) {
				return response;
			}
			var message = GetStatusValidationExceptionMessage("TemplateStatusValidation{0}Error", draftEmails);
			response.Exception = new Exception(message);
			return response;
		}

		/// <summary>
		/// Validates the bulk emails by identifiers before sending.
		/// </summary>
		/// <param name="messageIds">The message ids.</param>
		/// <param name="recipientsCount">Recipients count to send.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse"/>.</returns>
		public ConfigurationServiceResponse ValidateMessages(Guid[] messageIds, int recipientsCount = 0) {
			var response = new ConfigurationServiceResponse();
			if (!messageIds.Any()) {
				return response;
			}
			var exceptionMessages = new List<string>();
			try {
				var bulkEmailContext = new BulkEmailContext {
					MessageIds = messageIds,
					RecipientCount = recipientsCount,
					UserConnection = UserConnection,
					ServiceApi = _serviceApi
				};
				var emailSendingValidator = CreateChainOfBulkEmailValidators();
				exceptionMessages = emailSendingValidator.HandleValidation(bulkEmailContext).ToList();
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("[ValidateMessages]: Error while validating message", e);
				foreach (var messageId in messageIds) {
					BulkEmailEventLogger.LogError(messageId, DateTime.UtcNow, GetLczStringValue("ValidateMessageEvent"),
						e, GetLczStringValue("ValidateEmailErrorMsg"), UserConnection.CurrentUser.ContactId);
				}
				exceptionMessages.Add(GetLczStringValue("DefaultEmailValidationException"));
			}
			if (exceptionMessages.IsNotEmpty()) {
				response.Exception = new Exception(string.Join("\n", exceptionMessages));
			}
			return response;
		}

		/// <summary>
		/// Validates the test message.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="contactId">The contact identifier.</param>
		/// <param name="template">The template.</param>
		/// <param name="emailMessage">The email message.</param>
		/// <returns></returns>
		public bool ValidateTestMessage(Guid bulkEmailId, Guid contactId, IMailingTemplate template,
			EmailMessage emailMessage) {
			var validationResult = true;
			if (contactId.IsNotEmpty() && !emailMessage.to.Any()) {
				MailingUtilities.Log.InfoFormat("[SendTestMessage]: Can't find contact by id {0}", contactId);
				AddBulkEmailEventLogMessage(bulkEmailId, "TestEmailSending", "TestEmailSendingCommonError");
				validationResult = false;
			}
			var fromEmailMacrosText = MailingConsts.FromEmailMacroKey;
			var fromNameMacrosText = MailingConsts.FromNameMacroKey;
			if (template is CESMailingTemplate cesTemplate) {
				if (cesTemplate.TrackedAliases.TryGetValue(MailingConsts.FromEmailMacroKey, out var fromEmailMacroName)) {
					fromEmailMacrosText = cesTemplate.MacrosCollection.First(x => x.Alias == fromEmailMacroName)
						.MacrosText;
				}
				if (cesTemplate.TrackedAliases.TryGetValue(MailingConsts.FromNameMacroKey, out var fromNameMacrosName)) {
					fromNameMacrosText = cesTemplate.MacrosCollection.First(x => x.Alias == fromNameMacrosName)
						.MacrosText;
				}
			}
			if (string.IsNullOrEmpty(emailMessage.from_email)) {
				MailingUtilities.Log.InfoFormat("[SendTestMessage]: FromEmail value can't be empty");
				validationResult = false;
				AddBulkEmailEventLogMessage(bulkEmailId, "TestEmailSending", "TestEmailSendingSenderEmailEmpty",
					fromEmailMacrosText);
			} else if (!MailingUtilities.ValidateEmail(emailMessage.from_email)) {
				MailingUtilities.Log.InfoFormat("[SendTestMessage]: FromEmail value is not an email: ",
					emailMessage.from_email);
				validationResult = false;
				AddBulkEmailEventLogMessage(bulkEmailId, "TestEmailSending", "TestEmailSendingSenderEmailWrong",
					fromEmailMacrosText, emailMessage.from_email);
			}
			if (!string.IsNullOrEmpty(emailMessage.from_name)) {
				return validationResult;
			}
			MailingUtilities.Log.InfoFormat("[SendTestMessage]: FromEmail value can't be empty");
			AddBulkEmailEventLogMessage(bulkEmailId, "TestEmailSending", "TestEmailSendingSenderNameEmpty",
				fromNameMacrosText);
			return false;
		}

		#endregion

	}

	#endregion

}

