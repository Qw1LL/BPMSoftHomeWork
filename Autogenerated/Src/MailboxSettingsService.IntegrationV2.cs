namespace BPMSoft.Configuration.TestService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using EmailContract.DTO;
	using global::Common.Logging;
	using IntegrationApi.Interfaces;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.EmailDomain;
	using BPMSoft.Mail;
	using BPMSoft.Web.Common;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using DTO = EmailContract.DTO;

	#region Class: MailboxSettingsService

	/// <summary>
	/// Provides mailbox synchronization settings management methods.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MailboxSettingsService : BaseService
	{

		#region Constants: Private

		private const string SyncJobErrorFormat = "[{0}]: {1}; ";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="ILog"/> instance.
		/// </summary>
		private readonly ILog _log = LogManager.GetLogger("ExchangeListener");

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates exchange synchronization job.
		/// </summary>
		/// <param name="interval">Synchronization interval.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <param name="processName">Synchronization process name.</param>
		private string CreateExchangeSyncJob(int interval, string senderEmailAddress, string processName) {
			var parameters = new Dictionary<string, object> { { "SenderEmailAddress", senderEmailAddress } };
			try {
				var syncJobScheduler = ClassFactory.Get<ISyncJobScheduler>();
				syncJobScheduler.CreateSyncJob(UserConnection, interval, processName, parameters);
			} catch (Exception ex) {
				return string.Format(SyncJobErrorFormat, processName, ex.Message);
			}
			return string.Empty;
		}

		/// <summary>
		/// Creates imap imediate synchronization job.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		private string CreateImapImediateSyncJob(string senderEmailAddress) {
			var parameters = new Dictionary<string, object> {
				{ "SenderEmailAddress", senderEmailAddress },
				{ "MailboxType", IntegrationConsts.ImapMailServerTypeId }
			};
			try {
				var syncJobScheduler = ClassFactory.Get<ISyncJobScheduler>();
				syncJobScheduler.CreateSyncJob(UserConnection, parameters);
			} catch (Exception ex) {
				return string.Format(SyncJobErrorFormat, "imap imediate", ex.Message);
			}
			return string.Empty;
		}

		/// <summary>
		/// Removes exchange synchronization job.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <param name="processName">Synchronization process name.</param>
		private string DeleteExchangeSyncJob(string senderEmailAddress, string processName) {
			try {
				var syncJobScheduler = ClassFactory.Get<ISyncJobScheduler>();
				syncJobScheduler.RemoveSyncJob(UserConnection, senderEmailAddress, processName);
			} catch (Exception ex) {
				return string.Format(SyncJobErrorFormat, processName, ex.Message);
			}
			return string.Empty;
		}

		/// <summary>
		/// Creates (or deletes, if necessary) Imap synchronization job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="interval">Synchronization interval.</param>
		/// <param name="create">Determines if synchronization job creation is necessary.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		private string CreateDeleteImapJob(UserConnection userConnection, int interval, bool create,
				string senderEmailAddress) {
			var parameters = new Dictionary<string, object> {
				{ "SenderEmailAddress", senderEmailAddress },
				{ "CurrentUserId", userConnection.CurrentUser.Id }
			};
			var scheduler = ClassFactory.Get<IImapSyncJobScheduler>();
			if (create) {
				if (interval == 0) {
					CreateImapImediateSyncJob(senderEmailAddress);
				} else {
					scheduler.CreateSyncJob(userConnection, interval, parameters);
				}
			} else {
				scheduler.RemoveSyncJob(userConnection, parameters);
			}
			return string.Empty;
		}

		/// <summary>
		/// Creates (or deletes, if necessary) all exchange synchronization jobs.
		/// </summary>
		/// <param name="mailbox"><see cref="Mailbox"/> instance.</param>
		/// <returns>Job creation error messages.</returns>
		private string CreateDeleteExchageJobs(Mailbox mailbox) {
			int syncInterval = mailbox.SynchronizationInterval;
			return CreateDeleteExchageJobs(mailbox.SenderEmailAddress, 
				mailbox.AllowEmailScheduledSynchronization, syncInterval,
				mailbox.AllowActivityScheduledSynchronization, syncInterval,
				mailbox.AllowContactScheduledSynchronization, syncInterval);
		}

		/// <summary>
		/// Creates (or deletes, if necessary) all exchange synchronization jobs.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <param name="createEmailJob">Is email sync job needed flag.</param>
		/// <param name="intervalEmailJob">Email sync job interval.</param>
		/// <param name="activityInterval">Calendar sync job interval.</param>
		/// <param name="createActivityJob">Is calendar sync job needed flag.</param>
		/// <param name="createContactJob">Is contact sync job needed flag.</param> 
		/// <param name="contactInterval">Contact sync job interval.</param>
		/// <returns>Job creation error messages.</returns>
		private string CreateDeleteExchageJobs(string senderEmailAddress, bool createEmailJob, int intervalEmailJob,
				bool createActivityJob, int activityInterval, bool createContactJob, int contactInterval) {
			var errorMessage = string.Empty;
			if (createEmailJob) {
				if (UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
					errorMessage += CreateExchangeSyncJob(intervalEmailJob, senderEmailAddress,
						ExchangeUtility.MailSyncProcessName);
				}
			} else {
				errorMessage += DeleteExchangeSyncJob(senderEmailAddress, ExchangeUtility.MailSyncProcessName);
			}
			if (createContactJob) {
				errorMessage += CreateExchangeSyncJob(contactInterval, senderEmailAddress,
					ExchangeUtility.ContactSyncProcessName);
			} else {
				errorMessage += DeleteExchangeSyncJob(senderEmailAddress, ExchangeUtility.ContactSyncProcessName);
			}
			if (createActivityJob) {
				errorMessage += CreateExchangeSyncJob(activityInterval, senderEmailAddress,
					ExchangeUtility.ActivitySyncProcessName);
			} else {
				errorMessage += DeleteExchangeSyncJob(senderEmailAddress, ExchangeUtility.ActivitySyncProcessName);
			}
			return errorMessage;
		}

		/// <summary>
		/// Creates (or deletes, if necessary) Imap synchronization job.
		/// </summary>
		/// <param name="mailbox"><see cref="Mailbox"/> instance.</param>
		/// <returns>Job creation error messages.</returns>
		private string CreateDeleteImapJob(Mailbox mailbox) {
			return CreateDeleteImapJob(UserConnection, mailbox.SynchronizationInterval, mailbox.AllowEmailScheduledSynchronization,
				mailbox.SenderEmailAddress);
		}

		/// <summary>
		/// Returns mailbox model instance.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns><see cref="Mailbox"/> instance.</returns>
		private Mailbox GetMailbox(string senderEmailAddress) {
			var mailboxService = ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", UserConnection));
			return mailboxService.GetMailboxBySenderEmailAddress(senderEmailAddress, false);
		}

		/// <summary>
		/// Returns localizable value from ExchangeUtility schema resources.
		/// </summary>
		/// <param name="lczName">Localizable value name.</param>
		/// <returns>Localizable value.</returns>
		private string GetLocalizableStringValue(string lczName) {
			return new LocalizableString(UserConnection.Workspace.ResourceStorage, "ExchangeUtility",
					"LocalizableStrings." + lczName + ".Value").ToString();
		}

		/// <summary>
		/// Returns localized "Mail provider does not exists" error message.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>Locaized error message.</returns>
		public string GetMailServerDoesNotExistLczValue() {
			return GetLocalizableStringValue("MailServerDoesNotExist");
		}

		/// <summary>
		/// Returns localized "The current user is not the owner of this mailbox" error message.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>Locaized error message.</returns>
		private string GetUserIsNotMailboxOwnerLczValue() {
			return GetLocalizableStringValue("UserIsNotMailboxOwner");
		}

		/// <summary>
		/// Get <see cref="IExchangeListenerManager"/> instance.
		/// </summary>
		/// <returns><see cref="IExchangeListenerManager"/> instance.</returns>
		private IExchangeListenerManager GetExchangeListenerManager() {
			var managerFactory = ClassFactory.Get<IListenerManagerFactory>();
			return managerFactory.GetExchangeListenerManager(UserConnection);
		}

		/// <summary>
		/// Get hierarhical <see cref="MailboxFolder"/> list.
		/// </summary>
		/// <param name="folders"><see cref="MailboxFolder"/> list.</param>
		/// <param name="mailboxName">Mailbox name.</param>
		/// <returns>Hierarhical <see cref="MailboxFolder"/> list.</returns>
		private List<MailboxFolder> GetHierarhicalFolderList(IEnumerable<DTO.MailboxFolder> folders, string mailboxName) {
			var result = new List<MailboxFolder>();
			var rootId = Guid.NewGuid().ToString();
			result.Add(new MailboxFolder {
				Id = rootId,
				Name = mailboxName,
				ParentId = string.Empty,
				Path = string.Empty
			});
			var pathToUIIdsMap = folders.Select(f => f.Id).Distinct().ToDictionary(
				path => path,
				path => Guid.NewGuid().ToString()
			);
			return result.Concat(folders.Select(f => new MailboxFolder {
				Id = pathToUIIdsMap[f.Id],
				Name = f.Name,
				ParentId = f.ParentId.IsNotNullOrEmpty() && pathToUIIdsMap.ContainsKey(f.ParentId)
					? pathToUIIdsMap[f.ParentId]
					: rootId,
				Path = f.Id
			})).ToList();
		}

		/// <summary>
		/// Returns <see cref="CredentialsValidationInfo"/> instance.
		/// </summary>
		/// <param name="exception"><see cref="Exception"/> instance.</param>
		/// <param name="senderEmailAddress"><see cref="MailboxSyncSettings"/> instance address.</param>
		/// <returns><see cref="CredentialsValidationInfo"/> instance.</returns>
		private CredentialsValidationInfo GetCredentialsValidationErrorInfo(Exception exception, string senderEmailAddress) {
			var validationInfo = new CredentialsValidationInfo() {
				IsValid = false
			};
			string exceptionClassName = exception.GetType().ToString();
			string exceptionMessage = exception.Message;
			SynchronizationErrorHelper helper = SynchronizationErrorHelper.GetInstance(UserConnection);
			Entity message = helper.GetExceptionMessage(exceptionClassName, exceptionMessage);
			if (message != null) {
				validationInfo.Message = string.Format(message.GetTypedColumnValue<string>("UserMessage"),
					senderEmailAddress);
				validationInfo.Data = message.GetTypedColumnValue<string>("Action");
			}
			return validationInfo;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates (or deletes, if necessary) synchronization jobs.
		/// </summary>
		/// <param name="create">Is email sync job needed flag.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <param name="interval">Email sync job interval.</param>
		/// <param name="createContactJob">Is contact sync job needed flag.</param>
		/// <param name="createActivityJob">Is calendar sync job needed flag.</param>
		/// <param name="contactActivityInterval">Calendar and contacts sync job interval.</param>
		/// <returns>Job creation error messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateDeleteSyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CreateDeleteSyncJob(bool create, string senderEmailAddress, int interval = 1,
				bool createContactJob = false, bool createActivityJob = false, int contactActivityInterval = 0,
				int activityInterval = 0) {
			var mailbox = GetMailbox(senderEmailAddress);
			if (!mailbox.OwnerId.Equals(UserConnection.CurrentUser.Id)) {
				return !UserConnection.GetIsFeatureEnabled("OldEmailIntegration")
					? string.Empty
					: GetUserIsNotMailboxOwnerLczValue();
			}
			try {
				return mailbox.TypeId == IntegrationConsts.ExchangeMailServerTypeId
					? CreateDeleteExchageJobs(senderEmailAddress, create, interval, createActivityJob,
						activityInterval, createContactJob, contactActivityInterval)
					: CreateDeleteImapJob(UserConnection, interval, create, senderEmailAddress);
			} catch (Exception ex) {
				return ex.Message;
			}
		}

		/// <summary>
		/// Creates (or deletes, if necessary) all synchronization jobs for mailbox.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns>Job creation error messages.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateSyncJobs", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateSyncJobs(string senderEmailAddress) {
			var mailbox = GetMailbox(senderEmailAddress);
			if (!mailbox.OwnerId.Equals(UserConnection.CurrentUser.Id)) {
				return !UserConnection.GetIsFeatureEnabled("OldEmailIntegration")
					? string.Empty
					: GetUserIsNotMailboxOwnerLczValue();
			}
			try {
				return mailbox.TypeId == IntegrationConsts.ExchangeMailServerTypeId
					? CreateDeleteExchageJobs(mailbox)
					: CreateDeleteImapJob(mailbox);
			} catch (Exception ex) {
				return ex.Message;
			}
		}

		/// <summary>
		/// Schedules contact synchronization job.
		/// </summary>
		/// <param name="interval">Job intervali in minutes.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns>Error message string if any error occur. Empty string if job scheduled successfully.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateContactSyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CreateContactSyncJob(int interval, string senderEmailAddress) {
			return CreateExchangeSyncJob(interval, senderEmailAddress, ExchangeUtility.ContactSyncProcessName);
		}

		/// <summary>
		/// Schedules activity synchronization job.
		/// </summary>
		/// <param name="interval">Job intervali in minutes.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns>Error message string if any error occur. Empty string if job scheduled successfully.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateActivitySyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CreateActivitySyncJob(int interval, string senderEmailAddress) {
			return CreateExchangeSyncJob(interval, senderEmailAddress, ExchangeUtility.ActivitySyncProcessName);
		}

		/// <summary>
		/// Schedules email synchronization job.
		/// </summary>
		/// <param name="create">Create or delete job flag.</param>
		/// <param name="interval">Job intervali in minutes.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns>Error message string if any error occur. Empty string if job scheduled successfully.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateEmailSyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string CreateEmailSyncJob(bool create, int interval, string senderEmailAddress) {
			var mailbox = GetMailbox(senderEmailAddress);
			if (!mailbox.OwnerId.Equals(UserConnection.CurrentUser.Id)) {
				return !UserConnection.GetIsFeatureEnabled("OldEmailIntegration")
					? string.Empty
					: GetUserIsNotMailboxOwnerLczValue();
			}
			try {
				return mailbox.TypeId == IntegrationConsts.ExchangeMailServerTypeId
					? CreateExchangeSyncJob(interval, senderEmailAddress, ExchangeUtility.MailSyncProcessName)
					: CreateDeleteImapJob(UserConnection, interval, create, senderEmailAddress);
			} catch (Exception ex) {
				return ex.Message;
			}
		}

		/// <summary>
		/// Returns mailbox owners list.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns>Mailbox owners list.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetMailboxOwners", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetMailboxOwners(string senderEmailAddress) {
			var mailbox = GetMailbox(senderEmailAddress);
			var result = new List<string>();
			if (mailbox != null) {
				result.Add(mailbox.OwnerName);
			}
			return result;
		}

		/// <summary>
		/// Validates mailbox settings.
		/// </summary>
		/// <param name="id">Mail server identifier.</param>
		/// <param name="userName">Mailbox user login.</param>
		/// <param name="userPassword">Mailbox user password.</param>
		/// <param name="enableSync">Emails synchronization allowed for mailbox flag.</param>
		/// <param name="sendEmail">Send emails allowed for mailbox flag.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <returns><see cref="CredentialsValidationInfo"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "IsServerValid", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CredentialsValidationInfo IsServerValid(Guid id, string userName, string userPassword, bool enableSync,
				bool sendEmail, string senderEmailAddress) {
			var mailServerService = ClassFactory.Get<IMailServerService>(new ConstructorArgument("uc", UserConnection));
			var mailServer = mailServerService.GetServer(id);
			if (mailServer == null) {
				return new CredentialsValidationInfo() {
					IsValid = false,
					Message = GetMailServerDoesNotExistLczValue()
				};
			}
			var mailbox = new Mailbox(senderEmailAddress, mailServer);
			mailbox.SetCredentials(userName, userPassword);
			mailbox.SetAllowSynchronization(enableSync);
			mailbox.SetAllowEmailSend(sendEmail);
			try {
				CredentialsValidationInfo validationInfo = mailbox.Validate(UserConnection);
				if (!validationInfo.IsValid) {
					_log.Warn($"Mailbox {senderEmailAddress} didn't pass validation with these credentials, info: {validationInfo.Message}");
				}
				validationInfo.Message = string.Empty;
				return validationInfo;
			} catch (Exception exception) {
				_log.Error("Error in credentials validation", exception);
				return GetCredentialsValidationErrorInfo(exception, senderEmailAddress);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetMailboxFolders", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<MailboxFolder> GetMailboxFolders(string senderEmailAddress, string folderClassName = "") {
			var manager = GetExchangeListenerManager();
			var folders = manager.GetMailboxFolders(senderEmailAddress, folderClassName);
			return GetHierarhicalFolderList(folders, senderEmailAddress);
		}

		#endregion

	}

	#endregion

	#region Class: MailboxFolder

	public class MailboxFolder
	{

		#region Properties: Public

		public string Id { get; set; }

		public string Path { get; set; }

		public string Name { get; set; }

		public string ParentId { get; set; }

		#endregion

	}

	#endregion

}
