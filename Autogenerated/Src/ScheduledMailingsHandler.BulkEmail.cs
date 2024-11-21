namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using System;

	#region Class: ScheduledMailingsHandler

	/// <summary>
	/// Handler for the scheduled mailings.
	/// </summary>
	public class ScheduledMailingsHandler : BaseMailingHandler
	{

		#region Properties: Protected

		private readonly string _processName = "ScheduleMassMailing";
		protected override string ProcessName {
			get {
				return _processName;
			}
		}

		private readonly string _jobName = "MandrillScheduledMailing";
		protected override string JobName {
			get {
				return _jobName;
			}
		}

		#endregion

		#region Methods: Private

		private int GetInterval(UserConnection userConnection) {
			return (int)BPMSoft.Core.Configuration.SysSettings.GetValue(userConnection, "MandrillShedulerTimeStep");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public override void CreateInstance(UserConnection userConnection) {
			try {
				int interval = GetInterval(userConnection);
				MailingSchedulerUtilities.CreateJob(userConnection, JobName, JobGroupName, ProcessName, interval,
					null, true, true);
				MailingUtilities.Log.InfoFormat("[ScheduledMailingsHandler.CreateInstance]: Job {0} for " +
					"process {1} with interval {2} scheduled", JobName, ProcessName, interval);
			} catch (Exception exception) {
				MailingUtilities.Log.ErrorFormat("[ScheduledMailingsHandler.CreateInstance]: Error while scheduling " +
					"job {0}", exception, JobName);
				throw;
			}
		}

		#endregion

	}

	#endregion

}

