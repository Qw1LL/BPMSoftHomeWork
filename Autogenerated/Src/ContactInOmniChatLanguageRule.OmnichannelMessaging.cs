namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Class, provides language, from OmniChat using Contact.
	/// </summary>
	public class ContactInOmniChatLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="ContactInOmniChatLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ContactInOmniChatLanguageRule(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Provides language from OmniChat, using Contact.
		/// </summary>
		/// <param name="omniChatId">OmniChat entity identifier.</param>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid omniChatId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OmniChat");
			var languageColumnName = esq.AddColumn("Contact.Language.Id").Name;
			Entity omniChatEntity = esq.GetEntity(UserConnection, omniChatId);
			Guid languageId = omniChatEntity.GetTypedColumnValue<Guid>(languageColumnName);
			return languageId;
		}

		#endregion

	}
}
