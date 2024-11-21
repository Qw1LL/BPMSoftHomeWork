namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: ContactInAccountOpportunityLanguageRule

	/// <summary>
	/// Class, that provides contact language for Opportunity.
	/// </summary>
	public class ContactInAccountOpportunityLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="ContactInAccountOpportunityLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ContactInAccountOpportunityLanguageRule(UserConnection userConnection)
			: base(userConnection) {
			
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Obtains language identifier from contact in account.
		/// </summary>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid entityRecordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Opportunity");
			var languageColumnName = esq.AddColumn("Account.PrimaryContact.Language.Id").Name;
			Entity entity = esq.GetEntity(UserConnection, entityRecordId);
			return entity?.GetTypedColumnValue<Guid>(languageColumnName) ?? Guid.Empty;
		}

		#endregion

	}

	#endregion

}
