namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CES;

	#region Class: ProviderValidator

	/// <summary>
	/// Manages validation of bulk email messages providers on availability.
	/// </summary>
	public class ProviderValidator : BaseMessageValidator
	{

		#region Properties: Protected

		/// <summary>
		/// Gets the possibility to interrupt chain of validators.
		/// </summary>
		protected override bool IsAbortOnValidation => true;

		#endregion

		#region Methods: Private

		private string GetBulkSplitTestProviderErrorMessage(IEnumerable<string> notConnectedProviders) {
			var notConnectedProviderNames = string.Join(", ", notConnectedProviders);
			var errorOriginMessage = GetLczStringValue("NotConnectedProviderSplitBulkEmailMessage");
			return string.Format(errorOriginMessage, notConnectedProviderNames);
		}

		private string GetTriggerErrorMessage(IEnumerable<BulkEmail> emailWithNotConnectedProviders) {
			var providerNamesToBeConnected = emailWithNotConnectedProviders.Select(email => email.ProviderName);
			var providersToBeConnected = string.Join(", ", providerNamesToBeConnected);
			var notConnectedProviderMessage = GetLczStringValue("NotConnectedProviderTriggerEmailMessage");
			var message = string.Format(notConnectedProviderMessage, providersToBeConnected);
			return message;
		}

		private bool IsBulkEmailFromSplitTest(BulkEmail emailWithNotConnectedProvider, IEnumerable<Guid> bulkEmailIds) {
			var isSplitTest = !emailWithNotConnectedProvider.SplitTestId.Equals(Guid.Empty) && bulkEmailIds.Count() > 1;
			return isSplitTest;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Validates providers in bulk email messages on availability.
		/// </summary>
		/// <param name="emailContext">Dto with necessary bulk email info</param>
		/// <returns>Validation message if not succeed.</returns>
		protected override string Validate(BulkEmailContext emailContext) {
			var availableProviders = ServiceApi.GetAvailableProviders().AvailableProviders
				.Where(providerInfo => providerInfo.IsConnected)
				.Select(providerInfo => providerInfo.ProviderName);
			var emails = emailContext.MessageIds.Select(GetBulkEmailFromDB).Where(email => email.ProviderName.IsNotNullOrEmpty());
			var emailsWithNotConnectedProviders = emails
				.Where(email => !availableProviders.Contains(email.ProviderName))
				.ToList();
			if (emailsWithNotConnectedProviders.IsEmpty()) {
				return string.Empty;
			}
			var emailWithNotConnectedProvider = emailsWithNotConnectedProviders[0];
			if (emailWithNotConnectedProvider.CategoryId == MailingConsts.TriggeredEmailBulkEmailCategoryId) {
				return GetTriggerErrorMessage(emailsWithNotConnectedProviders);
			}
			var notConnectedProviders = emailsWithNotConnectedProviders.Select(e => e.ProviderName).Distinct();
			return IsBulkEmailFromSplitTest(emailWithNotConnectedProvider, emailContext.MessageIds)
				? GetBulkSplitTestProviderErrorMessage(notConnectedProviders)
				: GetLczStringValue("NotConnectedProviderBulkEmailMessage");
		}

		#endregion

	}

	#endregion

}
