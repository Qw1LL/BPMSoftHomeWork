namespace BPMSoft.Configuration
{
	using Common;
	using Core;
	using Core.Scheduler;
	using Web.Common;

	#region Class : SecurityTokenJobManager

	/// <summary>
	/// A class for Security token job management.
	/// </summary>
	public class SecurityTokenJobManager : AppEventListenerBase
	{

		#region Constants : Private

		/// <summary>
		/// Daily execution period.
		/// </summary>
		private const int SecurityTokenCleanerExecutionPeriod = 1440;
		/// <summary>
		/// Job group name.
		/// </summary>
		private const string JobGroupName = "SecurityTokenGroup";

		#endregion

		#region Properties : Protected

		protected UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Methods : Protected

		/// <summary>
		/// Gets user connection from application event context.
		/// </summary>
		/// <param name="context">Application event context.</param>
		/// <returns>User connection.</returns>
		protected UserConnection GetUserConnection(AppEventContext context) {
			var appConnection = context.Application["AppConnection"] as AppConnection;
			if (appConnection == null) {
				throw new ArgumentNullOrEmptyException("AppConnection");
			}
			return appConnection.SystemUserConnection;
		}

		/// <summary>
		/// Sets up SecurityToken jobs.
		/// </summary>
		protected virtual void SetupSecurityTokenJobs() {
			if (UserConnection.GetIsFeatureEnabled("SecureEstimation")) {
				string className = typeof(SecurityTokenCleaner).AssemblyQualifiedName;
				if (!AppScheduler.DoesJobExist(className, JobGroupName)) {
					AppScheduler.ScheduleMinutelyJob<SecurityTokenCleaner>(JobGroupName, UserConnection.Workspace.Name,
						UserConnection.CurrentUser.Name, SecurityTokenCleanerExecutionPeriod, null, true);
				}
			} else {
				string className = typeof(SecurityTokenCleaner).AssemblyQualifiedName;
				AppScheduler.RemoveJob(className, JobGroupName);
			}
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Handles application start.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			UserConnection = GetUserConnection(context);
			SetupSecurityTokenJobs();
		}

		#endregion

	}

	#endregion

}
