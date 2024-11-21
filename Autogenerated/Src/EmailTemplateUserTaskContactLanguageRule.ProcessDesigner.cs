namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.Entities;

	#region Class: ContactLanguageRule

	/// <summary>
	/// Class, that provides language from contact, that set in email template user task entity.
	/// </summary>
	public class EmailTemplateUserTaskContactLanguageRule : ILanguageRule
	{

		#region Properties: Public

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get; set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="EmailTemplateUserTaskContactLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public EmailTemplateUserTaskContactLanguageRule(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Obtains language identifier from contact, that set in email template user task.
		/// </summary>
		/// <inheritdoc />
		public Guid GetLanguageId(Guid entityRecordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			var languageColumnName = esq.AddColumn("Language.Id").Name;
			Entity contactEntity = esq.GetEntity(UserConnection, entityRecordId);
			if (contactEntity != null) {
				return contactEntity.GetTypedColumnValue<Guid>(languageColumnName);
			}
			return Guid.Empty;
		}

		#endregion

	}

	#endregion

}
