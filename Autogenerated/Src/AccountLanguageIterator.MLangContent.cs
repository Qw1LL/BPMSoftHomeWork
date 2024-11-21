namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: AccountLanguageIterator

	/// <summary>
	/// Iterator for listing by account languages.
	/// </summary>
	public class AccountLanguageIterator : BaseLanguageIterator
	{
		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="AccountLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public AccountLanguageIterator(UserConnection userConnection)
			: base(userConnection) {
			LanguageRules = new ILanguageRule[] {
				new PrimeContactInAccountLanguageRule(UserConnection),
				new DefaultLanguageRule(UserConnection),
			};
		}

		#endregion

	}

	#endregion

}
