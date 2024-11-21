namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using Quartz;
	using Quartz.Impl.Triggers;
	using BPMSoft.Core.Scheduler;

	#region Class: MarketingSchedulerUtilities

	public static class MarketingSchedulerUtilities {

		#region Methods: Public

		/// <summary>
		/// Creates scheduled job.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="periodInMinutes">The frequency of task startups in minutes.</param>
		/// <param name="parameters">Process parameters.</param>
		/// <param name="isSystemUser">Execute job by the systems user.</param>
		/// <param name="useMisfireInstructionFireOnceNow">Execute job immediately when it misfired.</param>
		[Obsolete("7.8.0 | Use MailingSchedulerUtilities.CreateJob")]
		public static void CreateJob(UserConnection userConnection, string jobName, string jobGroupName,
				string processName, int periodInMinutes, IDictionary<string, object> parameters = null,
				bool isSystemUser = false,
				bool useMisfireInstructionFireOnceNow = false) {
			MailingSchedulerUtilities.CreateJob(userConnection, jobName, jobGroupName, processName, periodInMinutes,
				parameters, isSystemUser, useMisfireInstructionFireOnceNow);
		}

		/// <summary>
		/// Searches for the task by the given parameters.
		/// </summary>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <returns>The job info.</returns>
		[Obsolete("7.8.0 | Use MailingSchedulerUtilities.FindJob")]
		public static IJobDetail FindJob(string jobName, string jobGroupName) {
			return MailingSchedulerUtilities.FindJob(jobName, jobGroupName);
		}

		/// <summary>
		/// Creates the immediately job.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="parameters">Process parameters.</param>
		[Obsolete("7.8.0 | Use MailingSchedulerUtilities.CreateImmediatelyJob")]
		public static void CreateImmediatelyJob(UserConnection userConnection, string jobName, string jobGroupName, 
				string processName, IDictionary<string, object> parameters) {
			MailingSchedulerUtilities.CreateImmediatelyJob(userConnection, jobName, jobGroupName, processName,
				parameters);
		}

		/// <summary>
		/// Creates scheduled job by cron expression.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="cronExpression">Cron scheduling parameters.</param>>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="parameters">Process parameters.</param>
		/// <param name="isSystemUser">Execute job by the systems user.</param>
		/// <param name="useMisfireInstructionFireOnceNow">Execute job immediately when it misfired.</param>
		[Obsolete("7.8.0 | Use MailingSchedulerUtilities.CreateCronJob")]
		public static void CreateCronJob(UserConnection userConnection, string cronExpression, string jobName, 
				string jobGroupName, string processName, IDictionary<string, object> parameters,
				bool isSystemUser = false, bool useMisfireInstructionFireOnceNow = false) {
			MailingSchedulerUtilities.CreateCronJob(userConnection, cronExpression, jobName,  jobGroupName,
				processName, parameters, isSystemUser, useMisfireInstructionFireOnceNow);
		}

		#endregion

	}

	#endregion
}
