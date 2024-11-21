namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: MarketingAppEventListener

	/// <summary>
	/// Represents methods to initialize package.
	/// </summary>
	public class MarketingAppEventListener : AppEventListenerBase
	{

		#region Methods: Public

		/// <summary>
		/// Binds packages <see cref="ClassFactory"/> items.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<IContactsToSyncRequest, ContactsWithClicksToSyncRequest>();
		}

		#endregion

	}

	#endregion

}

