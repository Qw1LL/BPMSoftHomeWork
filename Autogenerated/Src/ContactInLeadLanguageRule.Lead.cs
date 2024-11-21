namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: ContactInLeadLanguageRule

	/// <summary>
	/// Class, that provides contact in lead language rule.
	/// </summary>
	public class ContactInLeadLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="ContactInLeadLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ContactInLeadLanguageRule(UserConnection userConnection)
			: base(userConnection) {
			
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Obtains language identifier from contact in lead.
		/// </summary>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid entityRecordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Lead");
			var languageColumnName = esq.AddColumn("QualifiedContact.Language.Id").Name;
			Entity entity = esq.GetEntity(UserConnection, entityRecordId);
			return entity?.GetTypedColumnValue<Guid>(languageColumnName) ?? Guid.Empty;
		}

		#endregion

	}

	#endregion

}
