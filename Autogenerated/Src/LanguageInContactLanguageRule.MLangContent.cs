namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	/// <summary>
	/// Class, provides language, from contact.
	/// </summary>
	public class LanguageInContactLanguageRule : BaseLanguageRule
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="LanguageInContactLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public LanguageInContactLanguageRule(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Provides language identifier from contact.
		/// </summary>
		/// <param name="caseEntityRecordId">Contact entity identifier.</param>
		/// <inheritdoc />
		public override Guid GetLanguageId(Guid contactId) {
			var contactLanguageSelect = new Select(UserConnection).Column("c", "LanguageId").From("Contact", "c")
				.Where("c", "Id").IsEqual(Column.Parameter(contactId)) as Select;
			contactLanguageSelect.ExecuteSingleRecord(reader => reader.GetColumnValue<Guid>("LanguageId"), out Guid languageId);
			return languageId;
		}

		#endregion

	}
}
