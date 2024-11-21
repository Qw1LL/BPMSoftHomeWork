namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: EmailTemplateUserTaskLanguageIterator

	/// <summary>
	/// Iterator for listing by email template user task languages.
	/// </summary>
	public class EmailTemplateUserTaskLanguageIterator : ILanguageIterator
	{

		#region Properties: Public

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get;
			set;
		}

		private ILanguageRule[] _languageRules;
		/// <summary>
		/// Array of language rules.
		/// </summary>
		protected ILanguageRule[] LanguageRules {
			get => _languageRules ?? (_languageRules = new ILanguageRule[]
				{
					new EmailTemplateUserTaskContactLanguageRule(UserConnection),
					new EmailTemplateUserTaskSysAdminUnitLanguageRule(UserConnection),
					new DefaultLanguageRule(UserConnection)
				});
			set => _languageRules = value;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="EmailTemplateUserTaskLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public EmailTemplateUserTaskLanguageIterator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		/// <summary>
		/// Initializes new instance of <see cref="EmailTemplateUserTaskLanguageIterator"/>. 
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="rules">Rules for selecting languages.</param>
		public EmailTemplateUserTaskLanguageIterator(UserConnection userConnection, ILanguageRule[] rules)
				: this(userConnection) {
			LanguageRules = rules;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets languages by contact identifier.
		/// </summary>
		/// <param name="recordId">Contact identifier.</param>
		/// <returns>Enumerator of languages.</returns>
		public IEnumerable<Guid> GetLanguages(Guid recordId) {
			foreach (var rule in LanguageRules) {
				yield return rule.GetLanguageId(recordId);
			}
		}

		#endregion

	}

	#endregion

}
