namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	/// <summary>
	/// Provides method to get rules for state validator.
	/// </summary>
	public class ValidationStateRuleBuilder : IMailingStateValidationBuilder
	{

		#region Methods: Public

		/// <summary>
		/// Gets the rules for mailing state validation.
		/// </summary>
		/// <returns><see cref="IEnumerable<IMailingStateValidationRule>"/> with rules.</returns>
		public virtual IEnumerable<IMailingStateValidationRule> GetRules() {
			yield return new ActiveContactsValidationRule();
			yield return new SplitTestStatusValidationRule();
			yield return new StatusValidationRule();
			yield return new PingValidationRule();
			yield return new SendingLimitValidationRule();
		}

		#endregion

	}
}

