namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: OrderCalculator

	public class OrderCalculator
	{

		#region Fields: Private

		private UserConnection _userConnection;
		private ICurrenciesRateStorage _currenciesRateStorage;

		#endregion

		#region Constructors: Public

		public OrderCalculator(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected ICurrenciesRateStorage CurrenciesRateStorage {
			get {
				ConstructorArgument arg = new ConstructorArgument("userConnection", _userConnection);
				return _currenciesRateStorage ?? (_currenciesRateStorage = ClassFactory.Get<ICurrenciesRateStorage>(arg));
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual CurrencyRateInfo GetCurrencyInfo(Guid currencyId) {
			return CurrenciesRateStorage.GetActualCurrencyRates(currencyId).FirstOrDefault();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates the amount in primary currency.
		/// </summary>
		/// <param name="entity">The entity to calculate</param>
		/// <returns></returns>
		public virtual void CalculatePrimaryAmount(Entity entity) {
			var amount = entity.GetTypedColumnValue<decimal>("Amount");
			var primaryAmount = entity.GetTypedColumnValue<decimal>("PrimaryAmount");
			var currencyId = entity.GetTypedColumnValue<Guid>("CurrencyId");
			var currencyRate = entity.GetTypedColumnValue<decimal>("CurrencyRate");
			if (currencyId == Guid.Empty) {
				return;
			}
			CurrencyRateInfo currencyInfo = null;
			if (currencyRate == 0) {
				currencyInfo = GetCurrencyInfo(currencyId);
				if (currencyInfo == null) {
					return;
				}
				currencyRate = currencyInfo.Rate;
				entity.SetColumnValue("CurrencyRate", currencyRate);
			}
			if (primaryAmount == 0 && amount != 0) {
				if (currencyInfo == null) {
					currencyInfo = GetCurrencyInfo(currencyId);
				}
				if (currencyInfo == null) {
					return;
				}
				var currencyDivision = currencyInfo.Division;
				if (currencyDivision != 0) {
					primaryAmount = amount / currencyRate * currencyDivision;
					entity.SetColumnValue("PrimaryAmount", primaryAmount);
				}
			}
		}

		#endregion
	}

	#endregion
}
