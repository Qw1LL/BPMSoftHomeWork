namespace BPMSoft.Configuration
{
	using EmailContract.DTO;
	using IntegrationApi.MailboxDomain;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Mail;
	using BPMSoft.Mail.Sender;

	#region Class: ImapSmtpMailboxValidator

	/// <summary>
	/// <see cref="IMailboxValidator"/> implementation for Imap\Smtp mail server mailboxes.
	/// </summary>
	[DefaultBinding(typeof(IMailboxValidator), Name = "ImapSmtpMailboxValidator")]
	public class ImapSmtpMailboxValidator : BaseMailboxValidator, IMailboxValidator
	{

		#region Constructors: Public

		public ImapSmtpMailboxValidator(UserConnection uc): base(uc) {
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="BaseMailboxValidator.GetEmailClientFactory"/>
		protected override IEmailClientFactory GetEmailClientFactory() {
			return ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection",
				UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IMailboxValidator.ValidateSynchronization"/>
		public CredentialsValidationInfo ValidateSynchronization(Mailbox mailbox) {
			var answer = new CredentialsValidationInfo {
				IsValid = true
			};
			try {
				var credentials = new MailCredentials {
					UserName = mailbox.Login,
					UserPassword = mailbox.Password,
					SenderEmailAddress = mailbox.SenderEmailAddress,
					Host = mailbox.GetServerAddress(),
					Port = mailbox.GetServerPort(),
					UseSsl = mailbox.UseSsl,
					StartTls = mailbox.StartTls
				};
				var imapClient = ClassFactory.Get<IImapClient>("OldEmailIntegration",
					  new ConstructorArgument("credentials", credentials),
					  new ConstructorArgument("errorMessages", new BPMSoft.Mail.ImapErrorMessages()),
					  new ConstructorArgument("userConnection", UserConnection),
					  new ConstructorArgument("login", true));
			}
			catch (ImapException exception) {
				answer.IsValid = false;
				answer.Message = ConnectToServerCaption + exception.Message;
			}
			return answer; 
		}

		/// <inheritdoc cref="IMailboxValidator.ValidateEmailSend"/>
		public CredentialsValidationInfo ValidateEmailSend(Mailbox mailbox) {
			return SendTestMessage(mailbox);
		}

		#endregion

	}

	#endregion

}
