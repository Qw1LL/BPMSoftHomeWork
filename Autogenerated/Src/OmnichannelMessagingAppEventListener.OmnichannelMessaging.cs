namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using Common;
	using Core;
	using Core.Configuration;
	using Core.Scheduler;
	using OmnichannelMessaging;
	using OmnichannelMessaging.Telegram;
	using OmnichannelMessaging.WhatsApp;
	using OmnichannelProviders;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.Interfaces;
	using OmnichannelProviders.MessageWorkers;
	using OmnichannelProviders.ProfileDataProviders;
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using Web.Common;

	#region Class : OmnichannelMessagingAppEventListener

	/// <summary>
	/// Class, that run all what OmnichannelMessaging need on app start.
	/// </summary>
	public class OmnichannelMessagingAppEventListener : AppEventListenerBase
	{

		#region Constants : Private

		/// <summary>
		/// Execute every minute.
		/// </summary>
		private const int DefaultExecutionPeriod = 1;
		private const string JobGroupName = "OmnichannelMessagingGroup";
		private const int FacebookActualizePeriod = 60 * 24 * 10;
		private const int RunAndCheckTelegramPeriod = 5;

		#endregion

		#region Fields : Protected

		protected UserConnection UserConnection {
			get;
			private set;
		}

		protected static IIncomingMessageNotifier Notifier;

		#endregion

		#region Methods : Protected

		/// <summary>
		/// Gets user connection from application event context.
		/// </summary>
		/// <param name="context">Application event context.</param>
		/// <returns>User connection.</returns>
		protected UserConnection GetUserConnection(AppEventContext context) {
			var appConnection = context.Application["AppConnection"] as AppConnection;
			if (appConnection == null) {
				throw new ArgumentNullOrEmptyException("AppConnection");
			}
			return appConnection.SystemUserConnection;
		}

		protected void CreateNotifiers() {
			Notifier = ClassFactory.Get<IIncomingMessageNotifier>();
			Notifier.AddListener(new SendToUserIncomingMessageListener());
		}

		/// <summary>
		/// Schedules a minutely job.
		/// </summary>
		/// <typeparam name="TJob">Job type.</typeparam>
		/// <param name="periodInMinutes">Period in minutes.</param>
		protected virtual void ScheduleJob<TJob>(int periodInMinutes)
			where TJob : IJobExecutor {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			string className = typeof(TJob).AssemblyQualifiedName;
			if (!AppScheduler.DoesJobExist(className, JobGroupName)) {
				AppScheduler.ScheduleMinutelyJob<TJob>(JobGroupName, UserConnection.Workspace.Name,
					currentUser.Name, periodInMinutes, null, true);
			}
		}

		/// <summary>
		/// Sets up omnichannel jobs.
		/// </summary>
		protected virtual void SetupOmnichannelMessagingJobs() {
			ScheduleJob<OmnichannelChatCloser>(DefaultExecutionPeriod);
			ScheduleJob<FacebookActualizeJob>(FacebookActualizePeriod);
			ScheduleJob<RunTelegramChannelsJob>(RunAndCheckTelegramPeriod);
		}

		protected virtual void BindRegistrationWorker() {
			ClassFactory.Bind<IMessengerRegistrationWorker, FacebookRegistrationWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IMessengerRegistrationWorker, WhatsAppRegistrationWorker>(ChannelType.WhatsApp.ToString());
		}

		protected virtual void BindProfileDataProvider() {
			ClassFactory.Bind<IProfileDataProvider, FacebookProfileDataProvider>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IProfileDataProvider, TelegramProfileDataProvider>(ChannelType.Telegram.ToString());
		}

		protected virtual void BindAttachmentLoadWorker() {
			ClassFactory.Bind<IAttachmentsLoadWorker, FacebookAttachmentLoadWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IAttachmentsLoadWorker, TelegramAttachmentLoadWorker>(ChannelType.Telegram.ToString());
			ClassFactory.Bind<IAttachmentsLoadWorker, WhatsAppAttachmentLoadWorker>(ChannelType.WhatsApp.ToString());
		}

		protected virtual void BindOutcomeMessageWorker() {
			ClassFactory.Bind<IOutcomeMessageWorker, FacebookMessageWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IOutcomeMessageWorker, TelegramOutcomeMessageWorker>(ChannelType.Telegram.ToString());
			ClassFactory.Bind<IOutcomeMessageWorker, WhatsAppOutcomeWorker>(ChannelType.WhatsApp.ToString());
		}

		protected virtual void BindIncomeMessageWorker() {
			ClassFactory.Bind<IIncomeMessageWorker, FacebookIncomeMessageWorker>(ChannelType.Facebook.ToString());
			ClassFactory.Bind<IIncomeMessageWorker, TelegramIncomeMessageWorker>(ChannelType.Telegram.ToString());
		}

		protected void BindInterfaces() {
			BindRegistrationWorker();
			BindProfileDataProvider();
			BindAttachmentLoadWorker();
			BindOutcomeMessageWorker();
			BindIncomeMessageWorker();
			ClassFactory.Bind<ILanguageIterator, ChatLanguageIterator>("OmniChat");
			ClassFactory.Bind<IOperatorRoutingRule, ForEveryoneOperatorRoutingRule>(
				OmnichannelMessagingConsts.QueueOperatorRoutingRuleForEveryone);
			ClassFactory.Bind<IOperatorRoutingRule, ForFreeOperatorRoutingRule>(
				OmnichannelMessagingConsts.QueueOperatorRoutingRuleForFree);
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Handles application start.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			UserConnection = GetUserConnection(context);
			TelegramClientFactory.Instance.Initialize(UserConnection);
			new RunTelegramChannelsJob().Execute(UserConnection, null);
			SetupOmnichannelMessagingJobs();
			CreateNotifiers();
			BindInterfaces();
		}

		/// <summary>
		/// Handles application end.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppEnd(AppEventContext context) {
			var userConnection = GetUserConnection(context);
			var cacheList = userConnection.ApplicationCache[RunTelegramChannelsJob.CacheChannelsName] as List<string>;
			if (cacheList != null) {
				userConnection.ApplicationCache.Remove(RunTelegramChannelsJob.CacheChannelsName);
			}
			base.OnAppEnd(context);
		}

		#endregion

	}

	#endregion

}
