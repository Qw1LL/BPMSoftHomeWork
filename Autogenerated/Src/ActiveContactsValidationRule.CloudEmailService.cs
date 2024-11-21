namespace BPMSoft.Configuration
{

	/// <summary>
	/// Represents the active contact validation rule.
	/// </summary>
	public class ActiveContactsValidationRule : IMailingStateValidationRule
	{

		#region Methods: Public

		/// <summary>
		///	Execute validation for active contact rule.
		/// </summary>
		/// <param name="state">The state for validation.</param>
		/// <returns>Instance of <see cref="ValidationResponse"/> represents validation results.</returns>
		public ValidationResponse Validate(MailingState state) {
			MailingContext context = state.Context;
			ActiveContactsValidationResult validationResult =
				ActiveContactsHelper.ValidatePermissionEditBulkEmail(context.UserConnection);
			if (validationResult.Code == ActiveContactsValidationResult.Error) {
				MailingUtilities.Log.ErrorFormat("[CESMaillingProvider.ExecuteSendMessage]: License check failed.");
				return new ValidationResponse {
					Success = false,
					LczStringCode = validationResult.Message
				};
			}
			return new ValidationResponse {
				Success = true
			};
		}

		#endregion

	}

}

