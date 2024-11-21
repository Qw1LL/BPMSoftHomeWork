namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: ContactLanguageIterator

	/// <summary>
	/// Iterator for listing by contact languages.
	/// </summary>
	public class ContactLanguageIterator : BaseLanguageIterator
	{
		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ContactLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ContactLanguageIterator(UserConnection userConnection)
			: base(userConnection) {
			LanguageRules = new ILanguageRule[] {
				new LanguageInContactLanguageRule(UserConnection),
				new DefaultLanguageRule(UserConnection),
			};
		}

		#endregion

	}

	#endregion

}
