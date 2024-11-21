namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: CESWebHooksHandler

	/// <summary>
	/// Handler for the raw webhooks.
	/// </summary>
	public class CESWebHooksHandler : BaseMailingHandler
	{

		#region Constants: Private

		private const int DefaultInterval = 1;

		#endregion

		#region Properties: Protected

		private string _processName = "HandleWebHookProcess";
		protected override string ProcessName {
			get {return _processName;}
		}

		private string _jobName = "CESWebHooksSync";
		protected override string JobName {
			get {return _jobName;}
		}

		#endregion

		#region Methods: Private

		private int GetInterval(UserConnection userConnection) {
			int interval = (int)BPMSoft.Core.Configuration.SysSettings.GetValue(userConnection,
				"MandrillWebHooksSyncProcessInterval");
			if (interval < DefaultInterval) {
				interval = DefaultInterval;
			}
			return interval;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public override void CreateInstance(UserConnection userConnection) {
			int interval = GetInterval(userConnection);
			MailingSchedulerUtilities.CreateJob(userConnection, JobName, JobGroupName, ProcessName, interval,
				null, true, true);
		}

		#endregion

	}

	#endregion

}

