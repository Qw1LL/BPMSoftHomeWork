namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Class: MandrillAnaliticsHandler

	/// <summary>
	/// Handler for the mandrill analitics.
	/// </summary>
	public class MandrillAnaliticsHandler : BaseMailingHandler
	{

		#region Constants: Private

		private const int DefaultInterval = 30;

		#endregion

		#region Properties: Protected

		private string _processName = "UpdateEmailAnaliticsProcess";
		protected override string ProcessName {
			get {return _processName;}
		}

		private string _jobName = "UpdateBulkEmailAnalitics";
		protected override string JobName {
			get {return _jobName;}
		}

		#endregion

		#region Methods: Private

		private int GetInterval(UserConnection userConnection) {
			int interval = (int)BPMSoft.Core.Configuration.SysSettings.GetValue(
				userConnection, "MaxMandrillStatisticUpdatePeriodMinutes");
			if (interval < 1) {
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
				null, false, true);
		}

		#endregion

	}

	#endregion

}

