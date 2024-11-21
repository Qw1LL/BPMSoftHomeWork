namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: ExchangeEventsAppListener

	/// <summary>
	/// Class creates exchange events listener service fail handling job.
	/// </summary>
	public class ExchangeEventsAppListener : AppEventListenerBase
	{
		#region Fields: Private

		/// <summary>
		/// <see cref="AppEventContext"/> instance.
		/// </summary>
		private AppEventContext _appEventContext;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default class constructor, executes automatically by bpmcrm app on start.
		/// </summary>
		public ExchangeEventsAppListener() {
		}

		/// <summary>
		/// Setups instance of <see cref="ExchangeEventsAppListener"/> with custom user connection.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public ExchangeEventsAppListener(UserConnection userConnection) {
			UserConnection = userConnection;
			AppConnection = userConnection.AppConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;
		private UserConnection UserConnection {
			get => _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
			set => _userConnection = value;
		}

		/// <summary>
		/// <see cref="AppConnection"/> instance.
		/// </summary>
		private AppConnection _appConnection;
		private AppConnection AppConnection {
			get {
				if (_appConnection == null) {
					_appEventContext.CheckArgumentNull("AppEventContext");
					_appConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
			set => _appConnection = value;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Run ListenerServiceFailJob using <see cref="IListenerServiceFailJobFactory"/> instance.
		/// </summary>
		protected void RunScheduleListenerServiceFailJob() {
			var failJobFactory = ClassFactory.Get<IListenerServiceFailJobFactory>();
			failJobFactory.ScheduleListenerServiceFailJob(UserConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Application start handler.
		/// </summary>
		/// <param name="context">Application context.</param>
		public override void OnAppStart(AppEventContext context) {
			_appEventContext = context;
			RunScheduleListenerServiceFailJob();
		}

		#endregion

	}

	#endregion

}
