namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Campaign.StartSignal;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: CampaignAppEventListener

	/// <summary>
	/// Represents methods to initialize package.
	/// </summary>
	public class CampaignAppEventListener : IAppEventListener
	{

		#region Methods: Public

		/// <summary>
		/// Binds packages <see cref="ClassFactory"/> items.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			ClassFactory.Bind<ICampaignExecutionLogger, CampaignExecutionLogger>("userConnection");
			ClassFactory.Bind<ICampaignJobDispatcher, CampaignJobDispatcher>("userConnection");
			ClassFactory.Bind<ICampaignTimeScheduler, CampaignTimeScheduler>("userConnection");
			ClassFactory.Bind<ICampaignFragmentSynchronizer, CampaignFragmentSynchronizer>();
		}

		/// <summary>
		/// OnAppEnd empty handler.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppEnd(AppEventContext context) {
			//Do nothing for this package yet.
		}

		/// <summary>
		/// OnSessionStart empty handler.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnSessionStart(AppEventContext context) {
			//Do nothing for this package yet.
		}

		/// <summary>
		/// OnSessionEnd empty handler.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnSessionEnd(AppEventContext context) {
			//Do nothing for this package yet.
		}

		#endregion

	}

	#endregion

}

