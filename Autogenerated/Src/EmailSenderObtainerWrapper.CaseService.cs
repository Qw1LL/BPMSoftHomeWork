namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: EmailSenderObtainerWrapper

	/// <summary>
	/// Wrapper for <see cref="EmailSenderObtainer"/>.
	/// </summary>
	public class EmailSenderObtainerWrapper
	{

		#region Properties: Private

		private EmailSenderObtainer _obtainer;
		private EmailSenderObtainer Obtainer {
			get {
				return _obtainer ?? (_obtainer = CreateObtainer());
			}
		}

		/// <summary>
		/// Indicates whether mailbox collection should be filtered by case category.
		/// </summary>
		private bool UseCategory {
			get {
				return SystemSettings.GetValue(UserConnection, "DefineCaseCategoryFromMailBox", false)
					&& UserConnection.GetIsFeatureEnabled("CategoryFromMailBox");
			}
		}

		/// <summary>
		/// Indicates whether multilanguage is enabled.
		/// </summary>
		private bool IsMultilanguageEnabled {
			get {
				return UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguage") ||
					UserConnection.GetIsFeatureEnabled("EmailMessageMultiLanguageV2");
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Constructors: Public

		public EmailSenderObtainerWrapper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		public EmailSenderObtainerWrapper(UserConnection userConnection, EmailSenderObtainer obtainer)
			: this(userConnection) {
			_obtainer = obtainer;
		}

		#endregion

		#region Methods: Private

		private EmailSenderObtainer CreateObtainer() {
			var mailBoxRepository = new SupportMailBoxRepository(UserConnection);
			var contactCommLang = new ContactCommLanguage(UserConnection);
			return new EmailSenderObtainer(mailBoxRepository, contactCommLang) {
				UseCategory = UseCategory,
				IsMultilanguageEnabled = IsMultilanguageEnabled
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets support mailbox.
		/// </summary>
		/// <param name="recipients">Recipients, separated by semicolon.</param>
		/// <param name="contactId">Contact entity identifier.</param>
		/// <param name="categoryId">Category entity identifier.</param>
		/// <returns>Support mailbox.</returns>
		public string GetSupportMailBox(string recipients, Guid contactId, Guid categoryId = default(Guid)) {
			string[] parsedEmails = recipients.ParseEmailAddress().ToArray();
			return Obtainer.GetMailSender(parsedEmails, contactId, categoryId);
		}

		#endregion

	}

	#endregion

}
