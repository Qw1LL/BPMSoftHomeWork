namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;

	#region Class: SocialMentionSearchRuleEntity

	[Serializable]
	public class SocialMentionSearchRuleEntity
	{

		#region Fields: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected readonly UserConnection UserConnection;

		#endregion

		#region SocialMentionSearchRuleEntity: Public

		public SocialMentionSearchRuleEntity(UserConnection userConnection, string entitySchema, string filterByColumn,
				string userColumn) {
			UserConnection = userConnection;
			EntitySchema = entitySchema;
			FilterByColumn = filterByColumn;
			UserColumn = userColumn;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// <see cref="Core.Entities.EntitySchema"/> name.
		/// </summary>
		public string EntitySchema {
			get;
		}

		/// <summary>
		/// Filtration by column name (can be primary column or lookup column
		/// with reference <see cref="Core.Entities.EntitySchema"/> on <see cref="Contact"/> or <see cref="Account"/>
		/// instances).
		/// </summary>
		public string FilterByColumn {
			get;
		}

		/// <summary>
		/// User column (can be primary column or lookup column
		/// with reference <see cref="Core.Entities.EntitySchema"/> on <see cref="Contact"/> instances).
		/// </summary>
		public string UserColumn {
			get;
		}

		#endregion

		/// <summary>
		/// Creates <see cref="Select"/> data select.
		/// </summary>
		/// <param name="searchName">Part of <see cref="Contact"/> name that will be used to filter result list.</param>
		/// <param name="filterColumn"><see cref="Core.Entities.EntitySchemaColumn"/> name for filtration.</param>
		/// <param name="filterValue"><see cref="Contact"/> <see cref="Core.Entities.EntitySchemaColumn"/> name.</param>
		/// <returns><see cref="Select"/> instance.</returns>
		protected Select GetSocialMentionSearchRuleContactsSelect(string searchName, EntitySchema filterColumn,
				Guid filterValue) {
			var contactColumnLookupName = string.Concat(UserColumn, "Id");
			var filterByColumnLookupName = filterColumn != null ? string.Concat(FilterByColumn, "Id") : FilterByColumn;
			Select activeSysAdminUnitSubSelect = GetActiveSysAdminUnitSubSelect();
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var primaryDisplayColumnName = contactSchema.GetPrimaryDisplayColumnName();
			var select = new Select(UserConnection).Top(ESNFeedModuleService.MentionContactsPageSize).Distinct()
				.Column("MentionContact", "Id").As("Id")
				.Column("MentionContact", primaryDisplayColumnName).As("Name")
				.Column("MentionContact", "PhotoId").As("PhotoId")
				.Column("MentionContact", "Email").As("Email")
				.Column("ConnectionType").As("SysAdminUnit.ConnectionType")
			.From(EntitySchema, EntitySchema)
			.InnerJoin("Contact").As("MentionContact")
				.On(EntitySchema, contactColumnLookupName).IsEqual("MentionContact", "Id")
			.InnerJoin("SysAdminUnit").On("SysAdminUnit", "ContactId").IsEqual("MentionContact", "Id")
			.Where(EntitySchema, filterByColumnLookupName).IsEqual(Column.Parameter(filterValue))
				.And("MentionContact", "Name").ConsistsWith(Column.Parameter(searchName))
				.And().Exists(activeSysAdminUnitSubSelect) as Select;
			return select;
		}

		/// <summary>
		/// Creates <see cref="SysAdminUnit"/> data select.
		/// </summary>
		/// <returns><see cref="Select"/> instance.</returns>
		protected Select GetActiveSysAdminUnitSubSelect() {
			var select = new Select(UserConnection)
				.Column("Id")
			.From("SysAdminUnit")
			.Where("SysAdminUnit", "ContactId").IsEqual("MentionContact", "Id")
				.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true)) as Select;
			return select;
		}

		/// <summary>
		/// Returns value for contact filtration from rule.
		/// </summary>
		/// <param name="filterSchema"><see cref="Core.Entities.EntitySchema"/> instance.</param>
		/// <returns>Value for contact filtration from rule.</returns>
		protected Guid GetSocialMentionSearchRuleFilterValue(EntitySchema filterSchema) {
			Guid filterValue = Guid.Empty;
			if (filterSchema == null) {
				switch (EntitySchema) {
					case "Account":
						filterValue = UserConnection.CurrentUser.AccountId;
						break;
					case "Contact":
						filterValue = UserConnection.CurrentUser.ContactId;
						break;
				}
			} else {
				filterValue = filterSchema.Name == "Account"
					? UserConnection.CurrentUser.AccountId
					: UserConnection.CurrentUser.ContactId;
			}
			return filterValue;
		}

		#region Methods: Public 

		/// <summary>
		/// Returns additional contacts used for mention in feed (by using macros @...) from
		/// "User mention search rules" lookup.
		/// </summary>
		/// <param name="searchName">Part of <see cref="Contact"/> name that will be used to filter result list.</param>
		/// <returns>The list of contacts that could be used for mention in feed that exist in
		/// "User mention search rules" lookup.</returns>
		public List<ContactForMention> GetSocialMentionSearchRuleContacts(string searchName) {
			var contacts = new List<ContactForMention>();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(EntitySchema);
			EntitySchemaColumn filterByColumn = entitySchema.Columns
				.FirstOrDefault(column => column.Name == FilterByColumn);
			if (filterByColumn == null) {
				return contacts;
			}
			EntitySchema filterSchema  = filterByColumn.ReferenceSchema;
			Guid filterValue = GetSocialMentionSearchRuleFilterValue(filterSchema);
			if (filterValue.IsEmpty()) {
				return contacts;
			}
			Select select = GetSocialMentionSearchRuleContactsSelect(searchName, filterSchema, filterValue);
			contacts.AddRange(select.ExecuteEnumerable(reader => new ContactForMention(reader)));
			return contacts;
		}

		#endregion

	}

	#endregion

}

