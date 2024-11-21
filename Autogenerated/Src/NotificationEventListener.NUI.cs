namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using Quartz;
	using Quartz.Impl.Matchers;
	using Quartz.Impl.Triggers;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Common;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.Configuration;

	public class NotificationEventListener : AppEventListenerBase
	{

		#region Fields: Private

		private AppEventContext _appEventContext;
		private AppConnection _appConnection;
		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get {
				return _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
			}
			set {
				value.CheckArgumentNull("UserConnection");
				_userConnection = value;
			}
		}

		public AppConnection AppConnection {
			get {
				if (_appConnection == null) {
					AppConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
			set {
				value.CheckArgumentNull("AppConnection");
				_appConnection = value;
			}
		}

		#endregion

		#region Methods: Private

		private void ScheduleCleanerJob() {
			string jobName = typeof(NotificationCleanerJob).FullName;
			string jobGroupName = "NotificationCleanerGroup";
			string jobTriggerName = "NotificationCleanerTrigger";
			string cronExp = "0 0 2 * * ?";
			if (AppScheduler.DoesJobExist(jobName, jobGroupName)) {
				return;
			}
			IJobDetail job = AppScheduler.CreateClassJob<NotificationCleanerJob>(jobGroupName,
				UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, null, true);
			ITrigger trigger = new CronTriggerImpl(jobTriggerName, jobGroupName, cronExp);
			AppScheduler.Instance.ScheduleJob(job, trigger);
		}

		private void ScheduleRemindingJob() {
			string jobGroupName = "RemindingGroup";
			string jobName = typeof(RemindingJob).FullName;
			if (!AppScheduler.DoesJobExist(jobName, jobGroupName)) {
				SysUserInfo currentUser = UserConnection.CurrentUser;
				AppScheduler.ScheduleMinutelyJob<RemindingJob>(jobGroupName, UserConnection.Workspace.Name, currentUser.Name,
					GetNotificatonJobInterval(), isSystemUser: true);
			}
		}

		private int GetNotificatonJobInterval() {
			return Core.Configuration.SysSettings.GetValue(UserConnection, "NotificatonJobInterval", 1);
		}

		#endregion

		#region Methods: Protected

		protected virtual void NotificationDIModel() {
			ClassFactory.Bind<INotificationSender, NotificationSender>();
			ClassFactory.Bind<INotificationCounterFactory, NotificationCounterFactory>();
			ClassFactory.Bind<INotificationCountHandler, NotificationCountHandler>();
			ClassFactory.Bind<IRemindingRepository, RemindingRepository>();
			ClassFactory.Bind<INotificationHandler, PushNotificationSender>();
			ClassFactory.Bind<INotificationHandler, WebSocketNotificationSender>();
			ClassFactory.Bind<INotificationCounter, RemindingCounter>(NotificationGroupConst.All);
			ClassFactory.Bind<INotificationCounter, ESNNotificationCounter>(NotificationGroupConst.All);
			ClassFactory.Bind<INotificationCounter, VisaNotificationCounter>(NotificationGroupConst.All);
		}

		#endregion

		#region Members: IAppEventListener

		public override void OnAppStart(AppEventContext context) {
			context.CheckArgumentNull("context");
			_appEventContext = context;
			NotificationDIModel();
			ScheduleCleanerJob();
			ScheduleRemindingJob();
		}

		#endregion
	}
}

