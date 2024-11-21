namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.ProcessDesigner;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Mail;
	using BPMSoft.Mail.Sender;
	using SysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: AutoEmailUserTaskSender

	public class AutoEmailUserTaskSender : IEmailUserTaskSender
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Process");

		#endregion

		#region Properties: Private

		private LocalizableString NoRecepientError =>
			new LocalizableString(GetResourceStorage(), "AutoEmailUserTaskSender",
				"LocalizableStrings.NoRecepientError.Value").ToString();

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get;
			set;
		}

		/// <inheritdoc />
		public bool NeedUserInteraction => false;

		#endregion

		#region Methods: Private

		private IResourceStorage GetResourceStorage() {
			return UserConnection.Workspace.ResourceStorage;
		}

		#endregion

		#region Methods: Internal

		/// <summary>
		/// Creates <see cref="ActivityEmailSender"/> instance.
		/// </summary>
		/// <param name="emailClientFactory">Email client factory.</param>
		protected virtual ActivityEmailSender CreateActivityEmailSender(EmailClientFactory emailClientFactory) {
			return new ActivityEmailSender(emailClientFactory, UserConnection);
		}

		#endregion

		#region Methods: Public

		public virtual void SendEmailWithDefaultSender(EmailMessage emailMessage, bool ignoreErrors) {
			var userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			var emailClientFactory = ClassFactory.Get<EmailClientFactory>(userConnectionArg);
			if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration") && 
					!UserConnection.GetIsFeatureEnabled("OldEmailSend")) {
				var sender = new ActivityEmailSender(emailClientFactory, UserConnection);
				sender.Send(emailMessage, true);
			} else {
				var credentials = new MailCredentials {
					Host = (string)SysSettings.GetValue(UserConnection, "SmtpHost"),
					Port = int.Parse(SysSettings.GetValue(UserConnection, "SmtpPort").ToString()),
					UseSsl = (bool)SysSettings.GetValue(UserConnection, "SmtpEnableSsl"),
					UserName = (string)SysSettings.GetValue(UserConnection, "SmtpUserName"),
					UserPassword = (string)SysSettings.GetValue(UserConnection, "SmtpUserPassword")
				};
				try {
					var emailClientFactoryArg = new ConstructorArgument("emailClientFactory", emailClientFactory);
					var emailSener = ClassFactory.Get<IEmailSender>(emailClientFactoryArg, userConnectionArg);
					emailSener.Send(emailMessage, credentials);
				} catch (Exception e) {
					_log.Error(e);
					if (!ignoreErrors) {
						throw;
					}
				}
			}
		}

		public bool Execute(IEmailUserTaskMessageProvider messageProvider, ProcessExecutingContext context) {
			EmailTemplateUserTask userTask = messageProvider.EmailUserTask;
			EmailMessage message = messageProvider.GetEmailMessage();
			if (message.To.IsNullOrEmpty()) {
				if (userTask.IgnoreErrors) {
					return true;
				}
				throw new Exception(NoRecepientError);
			}
			if (message.From.IsEmpty()) {
				SendEmailWithDefaultSender(message, userTask.IgnoreErrors);
				return true;
			}
			var constructorArguments = new ConstructorArgument("userConnection", UserConnection);
			var emailClientFactory = ClassFactory.Get<EmailClientFactory>(constructorArguments);
			bool ignoreRights = (SendEmailType)userTask.SendEmailType == SendEmailType.Auto;
			if (userTask.CreateActivity) {
				SendEmailUsingActivity(emailClientFactory, userTask, message, ignoreRights);
			} else {
				SendEmail(emailClientFactory, userTask, message, ignoreRights);
			}
			return true;
		}

		private bool FetchExistingActivity(EmailTemplateUserTask userTask, out Entity activity) {
			activity = null;
			if (userTask.ActivityId.IsEmpty()) {
				return false;
			}
			Entity existingActivity = UserConnection.EntitySchemaManager.GetInstanceByName("Activity")
				.CreateEntity(UserConnection);
			existingActivity.UseAdminRights = false;
			if (!existingActivity.FetchFromDB(userTask.ActivityId, false)) {
				return false;
			}
			activity = existingActivity;
			return true;
		}

		private void TrySendEmail(EmailTemplateUserTask userTask, Action sendAction, Action onError = null) {
			try {
				sendAction();
			} catch (Exception e) {
				_log.Error(e);
				if (!userTask.IgnoreErrors) {
					onError?.Invoke();
					throw;
				}
			}
		}

		private void SendEmailUsingActivity(EmailClientFactory emailClientFactory, EmailTemplateUserTask userTask,
				EmailMessage message, bool ignoreRights) {
			ActivityEmailSender emailSender = CreateActivityEmailSender(emailClientFactory);
			if (FetchExistingActivity(userTask, out var existingActivity)) {
				TrySendEmail(userTask, () => emailSender.Send(existingActivity, null, ignoreRights));
				userTask.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
					Activity = existingActivity,
					RemoveListener = true,
					SynchronizeParameterValues = true
				});
			} else {
				Entity createdActivity = userTask.CreateActivityEntity(message, false);
				TrySendEmail(userTask, () => emailSender.Send(createdActivity, message, ignoreRights),
					() => userTask.AddActivityCompletionListener(createdActivity));
			}
			userTask.IsActivityCompleted = true;
		}

		private void SendEmail(EmailClientFactory emailClientFactory, EmailTemplateUserTask userTask,
				EmailMessage message, bool ignoreRights) {
			var emailSender = new HtmlEmailMessageSender(emailClientFactory, UserConnection);
			TrySendEmail(userTask, () => emailSender.Send(message, ignoreRights));
		}

		public bool CompleteExecuting(EmailTemplateUserTask userTask,
				Func<object[], bool> callBase, params object[] parameters) {
			return callBase(parameters);
		}

		public void CancelExecuting(EmailTemplateUserTask userTask,
				Action<object[]> callBase, params object[] parameters) {
			callBase(parameters);
		}

		public string GetExecutionData(EmailTemplateUserTask userTask) {
			return string.Empty;
		}

		/// <inheritdoc />
		[Obsolete("7.18.2 | Method is not in use and will be removed in upcoming builds")]
		public IProcessNotifier GetProcessNotifier(Func<IProcessNotifier> baseProcessNotifier) {
			return new EmptyProcessNotifier();
		}

		#endregion

	}

	#endregion

}

