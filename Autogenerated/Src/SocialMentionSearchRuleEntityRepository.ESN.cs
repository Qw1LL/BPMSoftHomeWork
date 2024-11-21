namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class SocialMentionSearchRuleEntityRepository

	public class SocialMentionSearchRuleEntityRepository
	{

		#region Fields: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		public SocialMentionSearchRuleEntityRepository(UserConnection uc) {
			UserConnection = uc;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Selects <see cref="SocialMentionSearchRule"/> data
		/// and creates <see cref="SocialMentionSearchRuleEntity"/> collection.
		/// </summary>
		/// <returns><see cref="SocialMentionSearchRuleEntity"/> collection.</returns>
		protected List<SocialMentionSearchRuleEntity> GetSocialMentionSearchRules() {
			var rules = new List<SocialMentionSearchRuleEntity>();
			var pagesSelect = GetSocialMentionSearchRulesSelect();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = pagesSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						rules.AddIfNotExists(CreateSocialMentionSearchRuleEntityInstance(dataReader));
					}
				}
			}
			return rules;
		}

		/// <summary>
		/// Returns new <see cref="SocialMentionSearchRuleEntity"/> instance, using information
		/// from <paramref name="dataReader"/>.
		/// </summary>
		/// <param name="dataReader"><see cref="IDataReader"/> implementation instance.</param>
		/// <returns><see cref="SocialMentionSearchRuleEntity"/> instance.</returns>
		private SocialMentionSearchRuleEntity CreateSocialMentionSearchRuleEntityInstance(IDataReader dataReader) {
			string entitySchema = dataReader.GetColumnValue<string>("EntitySchema");
			string filterByColumn = dataReader.GetColumnValue<string>("FilterByColumn");
			string userColumn = dataReader.GetColumnValue<string>("UserColumn");
			var rule = new SocialMentionSearchRuleEntity(UserConnection, entitySchema, filterByColumn, userColumn);
			return rule;
		}

		/// <summary>
		/// Returns <see cref="SocialMentionSearchRule"/> data select.
		/// </summary>
		/// <returns><see cref="Select"/> instance.</returns>
		protected Select GetSocialMentionSearchRulesSelect() {
			var mentionSelect =
				new Select(UserConnection).Distinct()
					.Column("EntitySchema")
					.Column("FilterByColumn")
					.Column("UserColumn")
				.From("SocialMentionSearchRule");
			return mentionSelect;
		}

		#endregion

		#region Methods: Public


		/// <summary>
		/// Returns <see cref="ContactForMention"/> instance collection using rules
		/// from "User mention search rules" lookup.
		/// </summary>
		/// <param name="searchName">Part of <see cref="Contact"/> name that will be used to filter result list.</param>
		/// <returns><see cref="ContactForMention"/> instance collection.</returns>
		public List<ContactForMention> GetContactsForMentionByRules(string searchName) {
			var contacts = new List<ContactForMention>();
			var rules = GetSocialMentionSearchRules();
			foreach (SocialMentionSearchRuleEntity rule in rules) {
				contacts.AddRangeIfNotExists(rule.GetSocialMentionSearchRuleContacts(searchName));
				if (contacts.Count >= ESNFeedModuleService.MentionContactsPageSize) {
					break;
				}
			}
			return contacts;
		}

		#endregion
	}

	#endregion

}
