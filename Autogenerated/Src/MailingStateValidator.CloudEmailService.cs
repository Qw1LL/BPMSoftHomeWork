namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents the validator for mailing states according to the rules.
	/// </summary>
	public class MailingStateValidator
	{
		private readonly IEnumerable<IMailingStateValidationRule> _rules;

		/// <summary>
		/// Create instanse with specified builder.
		/// </summary>
		/// <param name="ruleBuilder">The mailing state rule bulder.</param>
		public MailingStateValidator(IMailingStateValidationBuilder ruleBuilder) {
			_rules = ruleBuilder.GetRules();
		}

		/// <summary>
		/// Validates the states according to the specified rules.
		/// </summary>
		/// <param name="state">State for validation.</param>
		/// <returns></returns>
		public virtual IEnumerable<ValidationResponse> Validate(MailingState state) {
			return _rules.Select(rule => rule.Validate(state));
		}
	}
}
