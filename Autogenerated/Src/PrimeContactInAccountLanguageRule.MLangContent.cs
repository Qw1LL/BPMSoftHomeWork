namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Class, provides language, from account.
	/// </summary>
	public class PrimeContactInAccountLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="LanguageInContactLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public PrimeContactInAccountLanguageRule(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Provides language identifier from account.
		/// </summary>
		/// <param name="accountId">Account entity identifier.</param>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid accountId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Account");
			var languageColumnName = esq.AddColumn("PrimaryContact.Language.Id").Name;
			Entity accounttEntity = esq.GetEntity(UserConnection, accountId);
			Guid languageId = accounttEntity.GetTypedColumnValue<Guid>(languageColumnName);
			return languageId;
		}

		#endregion

	}
}
