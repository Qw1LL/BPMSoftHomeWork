namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;

	#region Class: ActiveContactsHandler

	/// <summary>
	/// Handler for the actualization of active contacts.
	/// </summary>
	public class ActiveContactsHandler : BaseMailingHandler
	{
		#region Constants: Private

		private const string CronExpression = "0 0 * ? * *";

		#endregion

		#region Properties: Protected

		private string _processName = "ActualizeActiveContactsProcess";
		protected override string ProcessName {
			get {return _processName;}
		}

		private string _jobName = "ActualizeActiveContacts";
		protected override string JobName {
			get {return _jobName;}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public override void CreateInstance(UserConnection userConnection) {
			try {
				MailingSchedulerUtilities.CreateCronJob(userConnection, CronExpression, JobName, JobGroupName, 
					ProcessName, null, true, true);
				MailingUtilities.Log.InfoFormat("[ActiveContactsHandler.CreateInstance]: Job {0} " + 
					"for process {1} scheduled", JobName, ProcessName);
			} catch (Exception exception) {
				MailingUtilities.Log.ErrorFormat("[ActiveContactsHandler.CreateInstance]: Error while scheduling " +
					"job {0}", exception, JobName);
				throw;
			}
		}

		#endregion

	}

	#endregion

}

