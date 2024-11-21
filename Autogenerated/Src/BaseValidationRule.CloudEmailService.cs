namespace BPMSoft.Configuration 
{
	#region Class: BaseValidationRule

	/// <summary>
	/// Base abstract class for validation rule.
	/// </summary>
	public abstract class BaseValidationRule 
	{

		#region Methods: Protected

		/// <summary>
		/// Gets value macro from recipient.
		/// </summary>
		/// <param name="recipient">Recipient of bulk email.</param>
		/// <param name="alias">Alias macro.</param>
		/// <returns>Value from macro.</returns>
		protected virtual (string Alias, string MacroValue)? GetMacroValueFromRecipient(IMessageRecipientInfo recipient, string alias) {
			var recipientItem = recipient as IDCRecipientInfo;
			if (recipientItem != null && recipientItem.Macros.ContainsKey(alias)) {
				return (Alias: alias, MacroValue: recipientItem.Macros[alias]);
			}
			return null;
		}

		/// <summary>
		/// Abstract method for validation by custom rule.
		/// </summary>
		/// <param name="recipient">Recipient of bulk email.</param>
		protected abstract void InternalValidate(IMessageRecipientInfo recipient);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates by custom rule.
		/// </summary>
		/// <param name="recipient">Recipient of bulk email.</param>
		public void Validate(IMessageRecipientInfo recipient) {
			if (!(recipient is IDCRecipientInfo)) {
				return;
			}
			if (recipient.InitialResponseCode == (int)MailingResponseCode.PostedProvider) {
				InternalValidate(recipient);
			}
		}

		#endregion
	}

	#endregion
}
