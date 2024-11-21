namespace BPMSoft.Configuration.TestService
{
	using global::Common.Logging;
    using IntegrationApi.Interfaces;
    using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
    using BPMSoft.Core.Factories;
    using BPMSoft.Mail;
    using BPMSoft.Mail.Sender;
    using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MailboxSynchronizationSettingsService : BaseService
	{
		ILog _log = LogManager.GetLogger("Exchange");

		private IResourceStorage GetResourceStorage() {
			return UserConnection.ResourceStorage;
		}

		private IImapSyncJobScheduler GetSyncJobScheduler() {
			return ClassFactory.Get<IImapSyncJobScheduler>();
		}

		public LocalizableString CanNotSendTestMessageCaption {
			get {
				return new LocalizableString(GetResourceStorage(), "MailboxSynchronizationSettingsService",
					"LocalizableStrings.CanNotSendTestMessageCaption.Value").ToString();
			}
		}

		public LocalizableString ConnectToImapServerCaption {
			get {
				return new LocalizableString(GetResourceStorage(), "MailboxSynchronizationSettingsService",
					"LocalizableStrings.ConnectToImapServerCaption.Value").ToString();
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanExecuteOperation", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetCanExecuteOperation(string operation) {
			return UserConnection.DBSecurityEngine.GetCanExecuteOperation(operation);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetMailProviderSettingsById", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public MailProviderSettings GetMailProviderSettingsById(Guid id) {
			var mailProvider = EmailCollectMailboxUtilities.GetMailProviderByUId(UserConnection, id);
			var mailProviderSettings = new MailProviderSettings() {
				AllowEmailDownloading = mailProvider.GetTypedColumnValue<bool>("AllowEmailDownloading"),
				AllowEmailSending = mailProvider.GetTypedColumnValue<bool>("AllowEmailSending")
			};
			return mailProviderSettings;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateBPMCRMFolder", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool CreateBPMCRMFolder(Guid id, string userName, string userPassword) {
			if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
				return false;
			}
			var currentMailServer = new MailServer(UserConnection);
			if (!currentMailServer.FetchFromDB(id)) {
				return false;
			}
			var imapServerCredentials = new MailCredentials{
				Host = currentMailServer.GetTypedColumnValue<string>("Address"),
				Port = currentMailServer.GetTypedColumnValue<int>("Port"),
				UseSsl = currentMailServer.GetTypedColumnValue<bool>("UseSSL"),
				StartTls = currentMailServer.GetTypedColumnValue<bool>("IsStartTls"),
				UserName = userName,
				UserPassword = userPassword
			};
			var imapClient = ClassFactory.Get<IImapClient>("OldEmailIntegration",
					new ConstructorArgument("credentials", imapServerCredentials),
					new ConstructorArgument("errorMessages", new BPMSoft.Mail.ImapErrorMessages()),
					new ConstructorArgument("userConnection", UserConnection));
			imapClient.EnsureFolderExists("BPMCRM");
			var mailboxFolderTypeId = new Guid("99c2351c-f0f8-e111-9dba-00155d051801");
			var emailFolderTypeId = new Guid("b97a5836-1cd0-e111-90c6-00155d054c03");
			var mailboxFolder = new ActivityFolder(UserConnection);
			if(mailboxFolder.FetchFromDB(
					new Dictionary<string, object>{
						{"FolderType", mailboxFolderTypeId},
						{"Name", imapServerCredentials.UserName}})){
							var activityFolderSchema = UserConnection.EntitySchemaManager.GetInstanceByName("ActivityFolder");
							var bpmcrmFolder = activityFolderSchema.CreateEntity(UserConnection);
							var parentColumn = activityFolderSchema.Columns.GetByName("Parent");
							var folderTypeColumn = activityFolderSchema.Columns.GetByName("FolderType");
							bpmcrmFolder.SetDefColumnValues();
							bpmcrmFolder.SetColumnValue("Name", "BPMCRM");
							bpmcrmFolder.SetColumnValue(parentColumn.ColumnValueName, mailboxFolder.PrimaryColumnValue);
							bpmcrmFolder.SetColumnValue(folderTypeColumn.ColumnValueName, emailFolderTypeId);
							bpmcrmFolder.Save();
							return true;
			}
			return false;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateDeleteSyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CreateDeleteSyncJob(bool create, int interval) {
			try {
				var syncJobScheduler = GetSyncJobScheduler();
				if (create) {
					syncJobScheduler.CreateSyncJob(UserConnection, interval);
				} else {
					syncJobScheduler.RemoveSyncJob(UserConnection);
				}
			} catch(ImapException e) {
				return e.Message;
			}
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DoesSyncJobExist", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool DoesSyncJobExist() {
			var syncJobScheduler = GetSyncJobScheduler();
			return syncJobScheduler.DoesSyncJobExist(UserConnection);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "IsServerValid", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IsValidAnswer IsServerValid(Guid id, string userName, string userPassword, bool enableSync, 
				bool sendEmail, string senderEmailAddress, bool isAnonymousAuthentication) {
			var currentMailServer = new MailServer(UserConnection);
			var isValidAnswer = new IsValidAnswer() {
				IsValid = true,
				Message = string.Empty
			};
			if (!currentMailServer.FetchFromDB(id)) {
				isValidAnswer.IsValid = false;
				return isValidAnswer;
			}
			if (currentMailServer.AllowEmailDownloading && enableSync) {
				try {
					var imapServerCredentials = new MailCredentials{
						Host = currentMailServer.Address,
						Port = currentMailServer.Port,
						UseSsl = currentMailServer.UseSSL,
						StartTls = currentMailServer.IsStartTls,
						UserName = userName,
						UserPassword = userPassword
					};
					var imapClient = ClassFactory.Get<IImapClient>("OldEmailIntegration",
						new ConstructorArgument("credentials", imapServerCredentials),
						new ConstructorArgument("errorMessages", new BPMSoft.Mail.ImapErrorMessages()),
						new ConstructorArgument("userConnection", UserConnection),
						new ConstructorArgument("login", true));
				} catch(ImapException exception) {
					isValidAnswer.IsValid = false;
					isValidAnswer.Message = ConnectToImapServerCaption.ToString() + exception.Message;
				}
			}
			if (currentMailServer.AllowEmailSending && sendEmail) {
				var smtpServerCredentials = new MailCredentials();
				if (isAnonymousAuthentication) {
					smtpServerCredentials.IsAnonymousAuthentication = true;
				} else {
					smtpServerCredentials.UserName = userName;
					smtpServerCredentials.UserPassword = userPassword;
				}
				smtpServerCredentials.Host = currentMailServer.SMTPServerAddress;
				smtpServerCredentials.Port = currentMailServer.SMTPPort;
				smtpServerCredentials.UseSsl = currentMailServer.UseSSLforSending;
				smtpServerCredentials.StartTls = currentMailServer.IsStartTls;
				smtpServerCredentials.Timeout = currentMailServer.SMTPServerTimeout * 1000;
				smtpServerCredentials.SenderEmailAddress = senderEmailAddress;
				try {
					var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
					IEmailSender emailSender = ClassFactory.Get<IEmailSender>(
						new ConstructorArgument("emailClientFactory", emailClientFactory),
						new ConstructorArgument("userConnection", UserConnection));
					emailSender.SendTestMessage(smtpServerCredentials.SenderEmailAddress, smtpServerCredentials);
				} catch(SmtpException ex) {
					_log.Error(ex);
					if (!string.IsNullOrEmpty(isValidAnswer.Message)) {
						isValidAnswer.Message += Environment.NewLine;
					}
					isValidAnswer.IsValid = false;
					isValidAnswer.Message += CanNotSendTestMessageCaption.ToString() + ex.Message;
				}
			}
			return isValidAnswer;
		}

		[DataContract]
		public class MailProviderSettings {
			
			[DataMember]
			public bool AllowEmailDownloading {
				get;
				set;
			}
			
			[DataMember]
			public bool AllowEmailSending {
				get;
				set;
			}
		}

		[DataContract]
		public class IsValidAnswer {
			
			[DataMember]
			public bool IsValid {
				get;
				set;
			}
			
			[DataMember]
			public string Message {
				get;
				set;
			}
		}
	}
}
