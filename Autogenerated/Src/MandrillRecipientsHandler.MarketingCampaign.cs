namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using Quartz;

	#region Class: MandrillRecipientsHandler

	/// <summary>
	/// Handler for the mandrill recipients.
	/// </summary>
	public class MandrillRecipientsHandler : BaseMailingHandler
	{

		#region Constants: Private

		private const int DefaultInterval = 24;

		private const string CronExpression = "0 0 1 1/1 * ? *";
		
		private const int MinutesInHour = 60;

		#endregion

		#region Properties: Protected

		private string _processName = "ActualizeBulkEmailRecipients";
		protected override string ProcessName {
			get {return _processName;}
		}

		private string _jobName = "ActualizeBulkEmailRecipients";
		protected override string JobName {
			get {return _jobName;}
		}

		#endregion

		#region Methods: Private

		private int GetInterval(UserConnection userConnection) {
			var interval = (int)BPMSoft.Core.Configuration.SysSettings.GetValue(userConnection,
				"PeriodActualizeBulkEmailRecipients");
			if (interval <= 0 || interval > DefaultInterval) {
				interval = DefaultInterval;
			}
			return interval;
		}

		private ICronTrigger FindCronTrigger() {
			var triggerKey = new TriggerKey(JobName + "Trigger", JobGroupName);
			return AppScheduler.Instance.GetTrigger(triggerKey) as ICronTrigger;
		}

		private int ConvertHoursToMinutes(int hours) {
			return hours * MinutesInHour;
		}

		private void CreateCronJob(UserConnection userConnection) {
			if (IsScheduledJobExists()) {
				RemoveInstance();
			}
			MailingSchedulerUtilities.CreateCronJob(userConnection, CronExpression, JobName, JobGroupName,
					ProcessName, null, false, true);
		}

		private void CreateScheduledJob(UserConnection userConnection) {
			if (IsCronJobExists()) {
				RemoveInstance();
			}
			int hoursInterval = GetInterval(userConnection);
			int minutelyInterval = ConvertHoursToMinutes(hoursInterval);
			MailingSchedulerUtilities.CreateJob(userConnection, JobName, JobGroupName, ProcessName,
				minutelyInterval, null, false, true);
		}

		private bool IsCronJob(UserConnection userConnection) {
			int hoursInterval = GetInterval(userConnection);
			return (hoursInterval == DefaultInterval);
		}

		private bool IsScheduledJobExists() {
			return FindCronTrigger() == null;
		}

		private bool IsCronJobExists() {
			return FindCronTrigger() != null;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public override void CreateInstance(UserConnection userConnection) {
			bool isCronJob = IsCronJob(userConnection);
			if (isCronJob) {
				CreateCronJob(userConnection);
			} else {
				CreateScheduledJob(userConnection);
			}
		}

		#endregion

	}

	#endregion

}

