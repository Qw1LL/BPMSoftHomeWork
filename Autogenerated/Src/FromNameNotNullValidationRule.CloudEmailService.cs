namespace BPMSoft.Configuration 
{
	using System.Collections.Generic;
	using System.Linq;

	#region Class:  FromNameNotNullValidationRule

	/// <summary>
	/// Represents the class with rules of validation for name from macros by empty.
	/// </summary>
	public class FromNameNotNullValidationRule : BaseValidationRule 
	{

		#region Methods: Protected

		/// <summary>
		/// Validates the sender name from the FromNameMacro.
		/// </summary>
		/// <param name="recipient">Recipient of bulk email.</param>
		protected override void InternalValidate(IMessageRecipientInfo recipient) {
			var valueFromName = GetMacroValueFromRecipient(recipient, MailingConsts.FromNameMacroKey);
			if (valueFromName != null && valueFromName.Value.MacroValue == string.Empty) {
				recipient.InitialResponseCode = (int)MailingResponseCode.CanceledSendersNameNotValid;
			}
		}

		#endregion

	}

	#endregion

}
