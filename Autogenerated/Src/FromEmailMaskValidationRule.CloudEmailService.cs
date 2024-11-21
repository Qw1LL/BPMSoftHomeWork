namespace BPMSoft.Configuration 
{
	using System.Collections.Generic;
	using System.Linq;

	#region Class:  FromEmailMaskValidationRule

	/// <summary>
	/// Represents the class with with rules of validation for emails from macros by mask.
	/// </summary>
	public class FromEmailMaskValidationRule : BaseValidationRule 
	{

		#region Methods: Protected

		/// <summary>
		/// Validates the sender email from the FromEmailMacro.
		/// </summary>
		/// <param name="recipient">Recipient of bulk email.</param>
		protected override void InternalValidate(IMessageRecipientInfo recipient) {
			var valueFromEmail = GetMacroValueFromRecipient(recipient, MailingConsts.FromEmailMacroKey);
			if (valueFromEmail != null && !MailingUtilities.ValidateEmail(valueFromEmail.Value.MacroValue)) {
				recipient.InitialResponseCode = (int)MailingResponseCode.CanceledSendersDomainNotVerified;
			}
		}

		#endregion

	}

	#endregion
}
