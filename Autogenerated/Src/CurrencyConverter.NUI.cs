namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CurrencyException;

	#region Class: CurrencyConverter 

	/// <summary>
	/// Provides methods of the convert currencies.
	/// </summary>
	public class CurrencyConverter
	{
		#region Constructors: Public

		public CurrencyConverter(ICurrenciesRateStorage currenciesRateStorage) {
			currenciesRateStorage.CheckArgumentNull(nameof(currenciesRateStorage));
			CurrenciesRateStorage = currenciesRateStorage;
		}

		#endregion

		#region Properties: Protected

		protected ICurrenciesRateStorage CurrenciesRateStorage { get; }

		protected UserConnection UserConnection => CurrenciesRateStorage.UserConnection;

		protected IResourceStorage ResourceStorage => UserConnection.ResourceStorage;

		#endregion

		#region Methods: Private
		
		private CurrencyRateInfo GetCurrencyRateInfo(Guid currencyId, IEnumerable<CurrencyRateInfo> currenciesRate) {
			CurrencyRateInfo currencyRateInfo = currenciesRate.FirstOrDefault(a => a.CurrencyId == currencyId);
			if (currencyRateInfo == null) {
				throw new CurrencyNotFoundException(ResourceStorage, currencyId);
			}
			return currencyRateInfo;
		}

		private void ValidateRateAndDivicion(CurrencyRateInfo currencyRateInfo) {
			ValidateValueLessOrEqualsZero(currencyRateInfo.Rate, "Rate", currencyRateInfo.CurrencyId);
			ValidateValueLessOrEqualsZero(currencyRateInfo.Division, "Division", currencyRateInfo.CurrencyId);
		}

		private void ValidateValueLessOrEqualsZero(decimal value, string parameterName, Guid currencyId) {
			if (value <= 0) {
				throw new CurrencyParameterLessOrEqualsZeroException(ResourceStorage,
					currencyId, parameterName, value);
			}
		}

		#endregion

		#region Methods: Protected

		protected decimal GetConvertedAmount(decimal amount, CurrencyRateInfo currentCurrencyRateInfo,
				CurrencyRateInfo targetCurrencyRateInfo) {
			currentCurrencyRateInfo.CheckArgumentNull(nameof(currentCurrencyRateInfo));
			targetCurrencyRateInfo.CheckArgumentNull(nameof(targetCurrencyRateInfo));
			ValidateRateAndDivicion(currentCurrencyRateInfo);
			ValidateRateAndDivicion(targetCurrencyRateInfo);
			return (amount * currentCurrencyRateInfo.Division * targetCurrencyRateInfo.Rate) /
				(targetCurrencyRateInfo.Division * currentCurrencyRateInfo.Rate);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns converted amount to currency.
		/// </summary>
		/// <param name="currentCurrencyId">Current currency identifier.</param>
		/// <param name="targetCurrencyId">Target currency identifier.</param>
		/// <param name="amount">Amount.</param>
		/// <param name="dateTime">Date of rate.</param>
		/// <returns>Converted amount.</returns>
		public decimal GetConvertedAmountToCurrency(Guid currentCurrencyId, Guid targetCurrencyId, decimal amount,
				DateTime dateTime) {
			if (amount == 0) {
				return amount;
			}
			currentCurrencyId.CheckArgumentEmpty(nameof(currentCurrencyId));
			targetCurrencyId.CheckArgumentEmpty(nameof(targetCurrencyId));
			IEnumerable<CurrencyRateInfo> currenciesRate = CurrenciesRateStorage
				.GetCurrenciesRate(new[] { currentCurrencyId, targetCurrencyId }, dateTime);
			CurrencyRateInfo currentCurrencyRateInfo = GetCurrencyRateInfo(currentCurrencyId, currenciesRate);
			CurrencyRateInfo targetCurrencyRateInfo = GetCurrencyRateInfo(targetCurrencyId, currenciesRate);
			decimal convertedValue = GetConvertedAmountToCurrency(currentCurrencyRateInfo, targetCurrencyRateInfo,
				amount);
			return convertedValue;
		}

		/// <summary>
		/// Returns converted amount to currency.
		/// </summary>
		/// <param name="currentCurrencyRateInfo">Current currency rate information.</param>
		/// <param name="targetCurrencyRateInfo">Target currency rate information.</param>
		/// <param name="amount">Amount.</param>
		/// <returns>Converted amount.</returns>
		public decimal GetConvertedAmountToCurrency(CurrencyRateInfo currentCurrencyRateInfo,
				CurrencyRateInfo targetCurrencyRateInfo, decimal amount) {
			if (amount == 0) {
				return amount;
			}
			currentCurrencyRateInfo.CheckArgumentNull(nameof(currentCurrencyRateInfo));
			targetCurrencyRateInfo.CheckArgumentNull(nameof(targetCurrencyRateInfo));
			decimal convertedValue = GetConvertedAmount(amount, currentCurrencyRateInfo, targetCurrencyRateInfo);
			return convertedValue;
		}

		/// <summary>
		/// Returns converted amount to currency.
		/// </summary>
		/// <param name="currentCurrencyRateInfo">Current currency rate information.</param>
		/// <param name="targetCurrencyId">Target currency identifier.</param>
		/// <param name="amount">Amount.</param>
		/// <param name="dateTime">Date of rate.</param>
		/// <returns>Converted amount.</returns>
		public decimal GetConvertedAmountToCurrency(CurrencyRateInfo currentCurrencyRateInfo,
				Guid targetCurrencyId, decimal amount, DateTime dateTime) {
			if (amount == 0) {
				return amount;
			}
			targetCurrencyId.CheckArgumentEmpty(nameof(targetCurrencyId));
			IEnumerable<CurrencyRateInfo> currenciesRate = CurrenciesRateStorage
				.GetCurrenciesRate(new[] {targetCurrencyId}, dateTime);
			CurrencyRateInfo targetCurrencyRateInfo = GetCurrencyRateInfo(targetCurrencyId, currenciesRate);
			decimal convertedValue = GetConvertedAmountToCurrency(currentCurrencyRateInfo, targetCurrencyRateInfo,
				amount);
			return convertedValue;
		}

		#endregion
	}

	#endregion
}
