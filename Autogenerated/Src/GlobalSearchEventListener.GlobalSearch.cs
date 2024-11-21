namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using global::Common.Logging;
	using Quartz;
	using Quartz.Impl.Matchers;
	using BPMSoft.Configuration.GlobalSearch;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	#region Class: GlobalSearchEventListener

	/// <summary>
	/// Global search IAppEventListnere implementation.
	/// </summary>
	public class GlobalSearchEventListener : IAppEventListener
	{
		#region Constants: Private

		/// <summary>
		/// Logstash group name.
		/// </summary>
		private const string JobGroupName = "GlobalSearchGroup";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="AppEventContext"/> instance.
		/// </summary>
		private AppEventContext _appEventContext;
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Properties: Public

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;
		public UserConnection UserConnection => _userConnection ?? (_userConnection = 
			AppConnection.SystemUserConnection);

		/// <summary>
		/// <see cref="AppConnection"/> instance.
		/// </summary>
		private AppConnection _appConnection;
		public AppConnection AppConnection => _appConnection ?? (_appConnection = 
			_appEventContext.Application["AppConnection"] as AppConnection);

		#endregion

		#region Methods: Private

		/// <summary>
		/// Runs logstash configs generator.
		/// </summary>
		private void RunGlobalSearchConfigJob() {
			if (UserConnection.GetIsFeatureEnabled("GlobalSearch")) {
				_log.Info("Prepare GlobalSearchConfigsJob");
				SysUserInfo currentUser = UserConnection.CurrentUser;
				string workspaceName = UserConnection.Workspace.Name;
				RemoveJobs();
				AppScheduler.TriggerJob<LogstashConfigsJob>(JobGroupName, workspaceName, currentUser.Name, null, true);
				_log.Info("GlobalSearchConfigsJob started successfully");
			}
		}

		/// <summary>
		/// Removes logstash jobs.
		/// </summary>
		private void RemoveJobs() {
			try {
				var groupMatcher = GroupMatcher<JobKey>.GroupContains(JobGroupName);
				var jobKeys = AppScheduler.Instance.GetJobKeys(groupMatcher).ToList();
				AppScheduler.Instance.DeleteJobs(jobKeys);
				_log.InfoFormat("RemoveJobs {0} {1} successfully", JobGroupName, jobKeys.Count);
			} catch (Exception ex) {
				_log.ErrorFormat("Remove jobs failed. {0}\r\n{1}", ex.Message, ex.StackTrace);
			}
		}
		
		#endregion

		#region Methods: Protected
		
		protected virtual void InitializeDIModel() {
			ClassFactory.Bind<IESQueryBuilder, ESQueryBuilder>();
			ClassFactory.Bind<ISearchProvider, ESSearchProvider>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes logstash settings on application start.
		/// </summary>
		/// <param name="context"><see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			_appEventContext = context;
			InitializeDIModel();
			RunGlobalSearchConfigJob();
		}

		public void OnAppEnd(AppEventContext context) {}

		public void OnSessionStart(AppEventContext context) {}

		public void OnSessionEnd(AppEventContext context) {}

		#endregion

	}

	#endregion

}

