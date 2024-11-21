namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: OpportunityLanguageIterator

	/// <summary>
	/// Iterator for listing by opportunity languages.
	/// </summary>
	public class OpportunityLanguageIterator : BaseLanguageIterator
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="OpportunityLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public OpportunityLanguageIterator(UserConnection userConnection)
			: base(userConnection) {
			LanguageRules = new ILanguageRule[] {
				new DefaultContactLanguageRule(UserConnection, "Opportunity"),
				new ContactInAccountOpportunityLanguageRule(UserConnection),
				new DefaultLanguageRule(UserConnection),
			};
		}

		#endregion

	}

	#endregion

}
