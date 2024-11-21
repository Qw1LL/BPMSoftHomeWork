namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: DefaultLanguageIterator

	/// <summary>
	/// Default language iterator, that provide language from contact that set in schema.
	/// </summary>
	public class DefaultLanguageIterator : BaseLanguageIterator
	{
		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="DefaultLanguageIterator"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="schemaName">Schema, contains Contact.</param>
		public DefaultLanguageIterator(UserConnection userConnection, string schemaName)
			: base(userConnection) {
			LanguageRules = new ILanguageRule[] {
				new DefaultContactLanguageRule(UserConnection, schemaName),
				new DefaultLanguageRule(UserConnection)
			};
		}

		#endregion

	}

	#endregion

}
