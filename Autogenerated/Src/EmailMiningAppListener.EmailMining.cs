namespace BPMSoft.Configuration.EmailMining
{
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: EmailMiningAppListener

	/// <summary>
	/// Setups email mining periodical job.
	/// </summary>
	public class EmailMiningAppListener: AppEventListenerBase
	{

		#region Constants: Public

		public const string TargetJobGroupName = "EmailMiningJob";

		#endregion

		#region Fields: Private

		private readonly IAppSchedulerWraper _schedulerWraper = ClassFactory.Get<IAppSchedulerWraper>();
		private AppEventContext _appEventContext;
		private AppConnection _appConnection;
		private UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get {
				return _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
			}
			set {
				_userConnection = value;
			}
		}

		private AppConnection AppConnection {
			get {
				if (_appConnection == null) {
					_appEventContext.CheckArgumentNull("AppEventContext");
					_appConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
			set {
				_appConnection = value;
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default class constructor, executes automatically by bpmcrm app on start.
		/// </summary>
		public EmailMiningAppListener() {
		}

		/// <summary>
		/// Setups instance of <see cref="EmailMiningAppListener"/> with custom user connection.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public EmailMiningAppListener(UserConnection userConnection) {
			UserConnection = userConnection;
			AppConnection = userConnection.AppConnection;
		}

		#endregion

		#region Methods: Private

		private void ScheduleEmailMiningJob() {
			SchedulerUtils.DeleteOldJobs(TargetJobGroupName);
			SysUserInfo currentUser = UserConnection.CurrentUser;
			_schedulerWraper.ScheduleImmediateJob<EmailMiningJob>(TargetJobGroupName, UserConnection.Workspace.Name,
				currentUser.Name, null, true);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Application start handler.
		/// </summary>
		/// <param name="context">Application context.</param>
		public override void OnAppStart(AppEventContext context) {
			_appEventContext = context;
			ScheduleEmailMiningJob();
		}

		#endregion

	}

	#endregion

}
