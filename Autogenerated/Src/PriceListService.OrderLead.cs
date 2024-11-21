namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: PriceListService

	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class PriceListService : BaseService
	{
		#region Methods: Public

		/// <summary>
		/// Get Price List using account. Took from account, if there is no Price List,
		/// then took it from partnership
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>PriceList identifier</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public Guid GetPriceList(Guid accountId) {
			var priceListPicker = ClassFactory.Get<IPriceListPicker>(new ConstructorArgument("userConnection",
				UserConnection));
			var	preSetPriceList = priceListPicker.GetPriceList(accountId);
			return preSetPriceList != default(Guid)
				? preSetPriceList
				: priceListPicker.GetPriceList(UserConnection.CurrentUser.AccountId);
		}

		#endregion

	}

	#endregion

}
