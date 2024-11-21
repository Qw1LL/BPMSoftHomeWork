namespace BPMSoft.Configuration
{

	/// <summary>
	/// Represents the MailingStateValidationRule contract.
	/// </summary>
	public interface IMailingStateValidationRule
	{

		#region Methods: Public

		/// <summary>
		///	Execute validation for specified rule.
		/// </summary>
		/// <param name="state">The state for validation.</param>
		/// <returns>Instance of <see cref="ValidationResponse"/> represents validation results.</returns>
		ValidationResponse Validate(MailingState state);

		#endregion

	}
}

