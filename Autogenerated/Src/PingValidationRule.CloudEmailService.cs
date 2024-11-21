namespace BPMSoft.Configuration
{
	using BPMSoft.Configuration.CES;

	/// <summary>
	/// Represents the ping service api validation rule.
	/// </summary>
	public class PingValidationRule : IMailingStateValidationRule
	{

		#region Methods: Private

		private bool PingProvider(ICESApi serviceApi) {
			try {
				if (string.IsNullOrWhiteSpace(serviceApi.BaseUrl)) {
					return false;
				}
				serviceApi.Ping();
				return true;
			} catch {
				return false;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		///	Execute validation for ping service api rule.
		/// </summary>
		/// <param name="state">The state for validation.</param>
		/// <returns>Instance of <see cref="ValidationResponse"/> represents validation results.</returns>
		public ValidationResponse Validate(MailingState state) {
			MailingContext context = state.Context;
			if (!PingProvider(context.ServiceApi)) {
				MailingUtilities.Log.ErrorFormat("[CESMaillingProvider.ExecuteSendMessage]: CESApi.Ping Fails.");
				return new ValidationResponse {
					Success = false,
					LczStringCode = "CloudUnreachableMsg"
				};
			}
			return new ValidationResponse {
				Success = true
			};
		}

		#endregion

	}
}

