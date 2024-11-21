namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: PriceListPickerRebinder

	/// <summary>
	/// IPriceListPicker class rebinder.
	/// </summary>
	public class PriceListPickerRebinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.ReBind<IPriceListPicker, PartnershipPriceListPicker>();
		}

		#endregion

	}

	#endregion

}
