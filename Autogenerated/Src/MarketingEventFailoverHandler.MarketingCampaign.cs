namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Scheduler;
	using SysSettingsCore = BPMSoft.Core.Configuration.SysSettings;

	#region Class: MarketingEventFailoverHandler

	/// <summary>
	/// Provides methods to get broken marketing event jobs.
	/// </summary>
	public class MarketingEventFailoverHandler : IFailoverHandler
	{

		#region Constants: Private

		private const int _periodInMinutes = 5;

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the marketing event queue job dispatcher.
		/// Instance of <see cref="MarketingEventQueueJobDispatcher"/>.
		/// </summary>
		private MarketingEventQueueJobDispatcher _marketingEventQueueJobDispatcher;
		public MarketingEventQueueJobDispatcher MarketingEventQueueJobDispatcher {
			get => _marketingEventQueueJobDispatcher
				?? (_marketingEventQueueJobDispatcher = new MarketingEventQueueJobDispatcher {
					UserConnection = _userConnection.AppConnection.SystemUserConnection
				});
			set => _marketingEventQueueJobDispatcher = value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Processes the event jobs to find out and reset broken ones.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			MarketingEventQueueJobDispatcher.TryRescheduleJob();
		}

		/// <summary>
		/// Creates job to monitor fails.
		/// <param name="userConnection">The user connection.</param>
		/// </summary>
		public void CreateJob(UserConnection userConnection) {
			_userConnection = userConnection;
			SysUserInfo currentUser = userConnection.CurrentUser;
			string jobGroupName = MarketingEventQueueJobDispatcher.JobGroupName;
			bool isSystemUser = true;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<MarketingEventFailoverHandler>(jobGroupName, userConnection.Workspace.Name,
				currentUser.Name, _periodInMinutes, null, isSystemUser, misfirePolicy);
		}

		#endregion

	}

	#endregion

}

