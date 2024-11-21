 namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	#region Class: PostgresTypesCastOptionsAppListener

	/// <summary>
	/// Application event listener that applies PostgreSQL types cast options.
	/// </summary>
	/// <seealso cref="BPMSoft.Web.Common.AppEventListenerBase" />
	public class PostgresTypesCastOptionsAppListener : AppEventListenerBase
	{

		#region Fields: Private

		private AppEventContext _appEventContext;
		private AppConnection _appConnection;
		private UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get => _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
		}

		private AppConnection AppConnection {
			get {
				if (_appConnection == null) {
					_appConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Called when [application start].
		/// </summary>
		/// <param name="context">The context.</param>
		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			context.CheckArgumentNull("AppEventContext");
			_appEventContext = context;
			if (UserConnection.DBEngine.DBEngineType == DBEngineType.PostgreSql
					&& GlobalAppSettings.FeatureEnableIntToBoolImplicitCastPostgreSql) {
				UserConnection.DBMetaScript.ApplyTypesCastOptions();
			}
		}

		#endregion

	}

	#endregion

}
