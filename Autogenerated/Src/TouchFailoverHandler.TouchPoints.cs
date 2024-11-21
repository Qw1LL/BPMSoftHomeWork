 namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Scheduler;

	#region Class: TouchFailoverHandler

	/// <summary>
	/// Provides methods to get and restore broken touchpoints queue job.
	/// </summary>
	public class TouchFailoverHandler : IFailoverHandler
	{

		#region Constants: Private

		private const int _periodInMinutes = 5;

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the touch queue job dispatcher.
		/// Instance of <see cref="TouchQueueJobDispatcher"/>.
		/// </summary>
		private TouchQueueJobDispatcher _touchQueueJobDispatcher;
		public TouchQueueJobDispatcher TouchQueueJobDispatcher {
			get => _touchQueueJobDispatcher
				?? (_touchQueueJobDispatcher = new TouchQueueJobDispatcher {
					UserConnection = _userConnection.AppConnection.SystemUserConnection
				});
			set => _touchQueueJobDispatcher = value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Processes broken jobs to find and restore touch queue job.
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">Job parameters.</param>
		/// </summary>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			TouchQueueJobDispatcher.TryRescheduleJob();
		}

		/// <summary>
		/// Creates job to monitor fails.
		/// <param name="userConnection">The user connection.</param>
		/// </summary>
		public void CreateJob(UserConnection userConnection) {
			_userConnection = userConnection;
			SysUserInfo currentUser = userConnection.CurrentUser;
			var jobGroupName = TouchQueueJobDispatcher.JobGroupName;
			var isSystemUser = true;
			var misfirePolicy = AppSchedulerMisfireInstruction.RescheduleNowWithRemainingRepeatCount;
			AppScheduler.ScheduleMinutelyJob<TouchFailoverHandler>(jobGroupName, userConnection.Workspace.Name,
				currentUser.Name, _periodInMinutes, null, isSystemUser, misfirePolicy);
		}

		#endregion

	}

	#endregion

}

