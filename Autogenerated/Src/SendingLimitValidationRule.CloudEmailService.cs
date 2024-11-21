 namespace BPMSoft.Configuration
{
	using System.Linq;
	using BPMSoft.Common;

	/// <summary>
	/// Represents the sending limits validation rule.
	/// </summary>
	public class SendingLimitValidationRule : IMailingStateValidationRule
	{

		#region Methods: Public

		/// <summary>
		///	Execute validation for sending limits in the cloud service.
		/// </summary>
		/// <param name="state">The state for validation.</param>
		/// <returns>Instance of <see cref="ValidationResponse"/> represents validation results.</returns>
		public ValidationResponse Validate(MailingState state) {
			MailingContext context = state.Context;
			var validator = new EmailSendingLimitValidator();
			var bulkEmail = (BulkEmail)context.BulkEmailEntity;
			var bulkEmailContext = new BulkEmailContext {
				UserConnection = context.UserConnection,
				ServiceApi = context.ServiceApi,
				MessageIds = new[] { bulkEmail.PrimaryColumnValue },
				RecipientCount = 0
			};
			var validationMessage = validator.HandleValidation(bulkEmailContext).FirstOrDefault();
			if (!validationMessage.IsNullOrEmpty()) {
				MailingUtilities.Log.ErrorFormat("[SendingLimitValidationRule.Validate]: Sending limit exceeded.");
				return new ValidationResponse {
					Success = false
				};
			}
			return new ValidationResponse {
				Success = true
			};
		}

		#endregion

	}
}

