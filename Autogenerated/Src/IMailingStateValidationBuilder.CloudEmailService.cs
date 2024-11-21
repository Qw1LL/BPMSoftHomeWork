namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	/// <summary>
	/// Provides method to get rules for state validator.
	/// </summary>
	public interface IMailingStateValidationBuilder
	{

		#region Methods: Public

		/// <summary>
		/// Gets the rules for mailing state validation.
		/// </summary>
		/// <returns><see cref="IEnumerable<IMailingStateValidationRule>"/> with rules.</returns>
		IEnumerable<IMailingStateValidationRule> GetRules();

		#endregion

	}
}

