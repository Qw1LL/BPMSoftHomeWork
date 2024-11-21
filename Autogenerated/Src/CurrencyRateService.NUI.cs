namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Factories;

	#region Interface: ICurrencyRateService

	/// <summary>
	/// Describes inferface for currency rate service.
	/// </summary>
	public interface ICurrencyRateService
	{
		List<CurrencyRateInfo> GetActualCurrencyRates(Guid? currencyId = null);
	}

	#endregion

	#region class: CurrencyRateService

	/// <summary>
	/// Provides web-service for work with currency rates.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CurrencyRateService : BaseService, ICurrencyRateService
	{

		#region Constructors

		public CurrencyRateService() {
			CurrencyRateStorage = ClassFactory.Get<CurrencyRateStorage>(
				new ConstructorArgument("userConnection", UserConnection));
		}

		public CurrencyRateService(ICurrencyRateStorage storage) {
			CurrencyRateStorage = storage;
		}

		#endregion

		#region Properties: Public

		public ICurrencyRateStorage CurrencyRateStorage {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets actual currency rates.
		/// </summary>
		/// <param name="currencyId">Currency Id</param>
		/// <returns>List of currency rates.</returns>
		[OperationContract]
		[WebInvoke(UriTemplate = "GetActualCurrencyRates", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public List<CurrencyRateInfo> GetActualCurrencyRates(Guid? currencyId = null) {
			List<CurrencyRateInfo> rates = CurrencyRateStorage.GetActualCurrencyRates(currencyId);
			return rates;
		}

		#endregion

	}

 #endregion
}

