namespace BPMSoft.Mail
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;

	#region Class: ImapSyncJobScheduler

	/// <summary>
	/// Implementation of <see cref="IImapSyncJobScheduler"/>.
	/// </summary>
	[DefaultBinding(typeof(IImapSyncJobScheduler))]
	public class ImapSyncJobScheduler: IImapSyncJobScheduler
	{

		#region Const: Private

		private const string JobName = "SyncImap";
		private const string SyncJobGroupName = "IMAP";
		private const string SyncProcessName = "SyncImapMail";

		#endregion

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("Imap");

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets synchronization job name.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Synchronization parameters.</param>
		/// <returns>Synchronization job name.</returns>
		private string GetSyncJobName(UserConnection userConnection,
				IDictionary<string, object> parameters = null) {
			List<string> syncJobNameParts = new List<string>();
			syncJobNameParts.Add(JobName);
			if (parameters != null) {
				object senderEmailAddress;
				if (parameters.TryGetValue("SenderEmailAddress", out senderEmailAddress)) {
					syncJobNameParts.Add(senderEmailAddress.ToString());
				}
			}
			syncJobNameParts.Add(userConnection.CurrentUser.Id.ToString());
			return string.Join("_", syncJobNameParts);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Check if sync job exists.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <param name="parameters">Job parameters collection.</param>
		/// <returns><c>True</c> if job exists. Otherwise returns <c>false</c>.</returns>
		public bool DoesSyncJobExist(UserConnection userConnection, IDictionary<string, object> parameters = null) {
			string syncJobName = GetSyncJobName(userConnection, parameters);
			return AppScheduler.DoesJobExist(syncJobName, SyncJobGroupName);
		}

		/// <summary>
		/// Removes synchronization job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Synchronization parameters.</param>
		public void RemoveSyncJob(UserConnection userConnection, IDictionary<string, object> parameters = null) {
			string[] syncJobNames = new string[] {
				GetSyncJobName(userConnection),
				GetSyncJobName(userConnection, parameters)
			};
			string trace = string.Empty;
			try {
				var stackTrace = new System.Diagnostics.StackTrace(false);
				trace = stackTrace.ToString();
			} catch { }
			foreach (string syncJobName in syncJobNames) {
				_log.ErrorFormat("RemoveJob called: CurrentUser {0}, SyncJobName {1}. Trace: {2}",
					userConnection.CurrentUser.Name, syncJobName, trace);
				AppScheduler.RemoveJob(syncJobName, SyncJobGroupName);
			}
		}

		/// <summary>
		/// Creates synchronization job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="periodInMinutes">Synchronization interval.</param>
		/// <param name="parameters">Synchronization parameters.</param>
		public void CreateSyncJob(UserConnection userConnection, int periodInMinutes,
				IDictionary<string, object> parameters = null) {
			if (periodInMinutes <= 0) {
				throw new ArgumentOutOfRangeException("periodInMinutes");
			}
			RemoveSyncJob(userConnection, parameters);
			string syncJobName = GetSyncJobName(userConnection, parameters);
			_log.ErrorFormat("ScheduleMinutelyJob called: CurrentUser {0}, SyncJobName {1}",
				userConnection.CurrentUser.Name, syncJobName);
			AppScheduler.ScheduleMinutelyJob(syncJobName, SyncJobGroupName, SyncProcessName,
				userConnection.Workspace.Name, userConnection.CurrentUser.Name, periodInMinutes, parameters);
		}

		#endregion

	}

	#endregion

}
