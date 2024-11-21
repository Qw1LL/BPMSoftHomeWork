namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: ContactInAccountLeadLanguageRule

	/// <summary>
	/// Class, that provides contact from account in lead language rule.
	/// </summary>
	public class ContactInAccountLeadLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="ContactInAccountLeadLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ContactInAccountLeadLanguageRule(UserConnection userConnection)
			: base(userConnection) {
			
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Obtains language identifier from contact in account from lead.
		/// </summary>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid entityRecordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Lead");
			var languageColumnName = esq.AddColumn("QualifiedAccount.PrimaryContact.Language.Id").Name;
			Entity entity = esq.GetEntity(UserConnection, entityRecordId);
			return entity?.GetTypedColumnValue<Guid>(languageColumnName) ?? Guid.Empty;
		}

		#endregion

	}

	#endregion

}
