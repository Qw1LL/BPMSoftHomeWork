namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	#region Class: MailingAppEventListener

	/// <summary>
	/// Represents methods to initialize package.
	/// </summary>
	public class MailingAppEventListener : AppEventListenerBase
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Methods: Private

		private UserConnection GetUserConnection(AppEventContext context) {
			if (_userConnection == null) {
				var appConection = context.Application["AppConnection"] as AppConnection;
				_userConnection = appConection.SystemUserConnection;
			}
			return _userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Binds packages <see cref="ClassFactory"/> items.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public override void OnAppStart(AppEventContext context) {
			var userConnection = GetUserConnection(context);
			MailingHandlersUtilities.EnableActiveProviderHandlers(userConnection);
		}

		#endregion

	}

	#endregion

}

