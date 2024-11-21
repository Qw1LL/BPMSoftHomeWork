namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	#region Class:  FromEmailDomainValidationRule

	/// <summary>
	/// Represents the class with rules of validation for emails domain. 
	/// </summary>
	public class FromEmailDomainValidationRule : BaseValidationRule
	{

		#region Fields: Private

		private readonly Lazy<HashSet<string>> _validDomains;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="FromEmailDomainValidationRule"/> class.
		/// </summary>
		/// <param name="validDomains">Valid domains list.</param>
		public FromEmailDomainValidationRule(Lazy<HashSet<string>> validDomains) {
			_validDomains = validDomains;
		}

		#endregion

		#region Methods: Private

		private string DefineDomainFromEmailAddress(string email) {
			return email?.Split('@').LastOrDefault();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Validates the sender email from the FromEmailMacro.
		/// </summary>
		/// <param name="recipient">Recipient of bulk email.</param>
		protected override void InternalValidate(IMessageRecipientInfo recipient) {
			var valueFromEmail = GetMacroValueFromRecipient(recipient, MailingConsts.FromEmailMacroKey);
			if (valueFromEmail == null) {
				return;
			}
			var domain = DefineDomainFromEmailAddress(valueFromEmail.Value.MacroValue);
			if (domain == null || !_validDomains.Value.Contains(domain)) {
				recipient.InitialResponseCode = (int)MailingResponseCode.CanceledSendersDomainNotVerified;
			}
		}

		#endregion

	}

	#endregion
}
