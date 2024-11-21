namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.Marketing.Utilities;

	#region Class: SenderValidator

	/// <summary>
	/// Manages validation of bulk email messages senders.
	/// </summary>
	public class SenderValidator : BaseMessageValidator
	{

		#region Constants: Private

		private const string MacroRegexPattern = "^(\\[\\#.+\\#\\])$";

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the possibility to interrupt chain of validators.
		/// </summary>
		protected override bool IsAbortOnValidation => false;

		#endregion

		#region Methods: Private

		private string GetDomainValidationExceptionMessage(IEnumerable<string> domains, string lczPattern) {
			var emails = string.Join(", ", domains);
			var message = domains.Count() == 1 ? GetLczStringValue(string.Format(lczPattern, "Singular"))
				: GetLczStringValue(string.Format(lczPattern, "Plural"));
			return string.Format(message, emails);
		}

		private IEnumerable<string> GetUniqueDomainsFromEmails(IEnumerable<string> emailsList) {
			return emailsList.Select(email => new Regex("^.*@").Replace(email, "")).Distinct();
		}

		private string ValidateDefaultSenderByMacro(IEnumerable<string> emailProviders) {
			var defaultEspEmail =
				BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "DefaultESPEmail") as string;
			if (string.IsNullOrEmpty(defaultEspEmail)) {
				var message = GetLczStringValue("SenderEmailValidationDefaultESPEmailEmpty");
				return message;
			}
			var resultList = new List<SenderValidationInfo>();
			var request = new ValidateSenderRequest {
				ApiKey = ServiceApi.ApiKey
			};
			foreach (string provider in emailProviders) {
				request.EmailList = new[] { defaultEspEmail };
				request.ProviderName = provider;
				var validationResult = ServiceApi.ValidateSenderForProvider(request);
				resultList.Add(validationResult);
			}
			if (resultList.Any(x => x.ValidatedEmailsList.Any())) {
				var messageTemplate = GetLczStringValue("SenderEmailValidationDefaultESPEmailNotApproved");
				var message = string.Format(messageTemplate, defaultEspEmail);
				return message;
			}
			if (resultList.Any(x => x.WrongEmailsList.Any())) {
				var messageTemplate = GetLczStringValue("SenderEmailValidationDefaultESPEmailWrong");
				var message = string.Format(messageTemplate, defaultEspEmail);
				return message;
			}
			return string.Empty;
		}

		private List<SenderValidationInfo> ValidateSendForEachProvider(
			IEnumerable<ProviderSenderEmail> senderEmailsWithProviders) {
			var validationResults = new List<SenderValidationInfo>();
			foreach (var providerSenderEmails in senderEmailsWithProviders) {
				var request = new ValidateSenderRequest {
					EmailList = providerSenderEmails.SenderEmails,
					ApiKey = ServiceApi.ApiKey,
					ProviderName = providerSenderEmails.ProviderName
				};
				var validationResult =
					Utilities.RetryOnFailure(() => ServiceApi.ValidateSenderForProvider(request), 20, 10);
				validationResults.Add(validationResult);
			}
			return validationResults;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Validates sender in bulk email messages.
		/// </summary>
		/// <param name="emailContext">Dto with necessary bulk email info</param>
		/// <returns>Validation message if not succeed.</returns>
		protected override string Validate(BulkEmailContext emailContext) {
			var exceptionMessage = string.Empty;
			var bulkEmailQueryHelper = new BulkEmailQueryHelper();
			var senderEmailsWithProviders = bulkEmailQueryHelper.GetSenderEmailsWithProviderNames(emailContext.MessageIds,
				UserConnection);
			if (senderEmailsWithProviders.Any(x => x.SenderEmails.Any(y => Regex.IsMatch(y, MacroRegexPattern)))) {
				var message =
					ValidateDefaultSenderByMacro(senderEmailsWithProviders.Select(x => x.ProviderName).Distinct());
				if (!string.IsNullOrEmpty(message)) {
					exceptionMessage += message;
					exceptionMessage += '\n';
				}
			}
			var valuableSenderEmails = senderEmailsWithProviders.Select(x => new ProviderSenderEmail {
				ProviderName = x.ProviderName,
				SenderEmails = x.SenderEmails.Where(y => !Regex.IsMatch(y, MacroRegexPattern)).ToList()
			}).Where(z => z.SenderEmails.Any());
			if (!valuableSenderEmails.Any()) {
				return exceptionMessage;
			}
			var resultList = ValidateSendForEachProvider(valuableSenderEmails);
			if (!resultList.Any(x => x.ValidatedEmailsList.Any())) {
				return exceptionMessage;
			}
			var domains = GetUniqueDomainsFromEmails(resultList.SelectMany(x => x.ValidatedEmailsList));
			exceptionMessage += GetDomainValidationExceptionMessage(domains, "SenderEmailValidation{0}Warning");
			exceptionMessage += '\n';
			return exceptionMessage;
		}

		#endregion

	}

	#endregion

}
