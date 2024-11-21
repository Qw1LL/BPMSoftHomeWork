namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: OpportunityLanguageIterator

	/// <summary>
	/// Iterator for listing by lead languages.
	/// </summary>
	public class LeadLanguageIterator : BaseLanguageIterator
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="LeadLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public LeadLanguageIterator(UserConnection userConnection)
				: base(userConnection) {
			LanguageRules = new ILanguageRule[] {
				new ContactInLeadLanguageRule(UserConnection), 
				new ContactInAccountLeadLanguageRule(UserConnection),
				new DefaultLanguageRule(UserConnection),
			};
		}

		#endregion

	}

	#endregion

}
