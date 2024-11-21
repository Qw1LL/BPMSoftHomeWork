namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: CurrencyRateInfo

	public class CurrencyRateInfo
	{
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>
		/// The code.
		/// </value>
		public int Code { get; set; }

		/// <summary>
		/// Gets or sets the short name.
		/// </summary>
		/// <value>
		/// The short name.
		/// </value>
		public string ShortName { get; set; }

		/// <summary>
		/// Gets or sets the currency identifier.
		/// </summary>
		/// <value>
		/// The currency identifier.
		/// </value>
		public Guid CurrencyId { get; set; }

		/// <summary>
		/// Gets or sets the rate.
		/// </summary>
		/// <value>
		/// The rate.
		/// </value>
		public decimal Rate { get; set; }

		/// <summary>
		/// Gets or sets the rate mantissa.
		/// </summary>
		/// <value>
		/// The rate mantissa.
		/// </value>
		public string RateMantissa { get; set; }

		/// <summary>
		/// Gets or sets the currency division.
		/// </summary>
		/// <value>
		/// The currency division.
		/// </value>
		public int Division { get; set; }

	}

	#endregion

	#region Interface: ICurrencyRateStorage

	/// <summary>
	/// Describes interface for currency rate storage.
	/// </summary>
	public interface ICurrencyRateStorage
	{
		void SaveRates(params CurrencyRateInfo[] rates);

		List<CurrencyRateInfo> GetActualCurrencyRates(Guid? currencyId = null, DateTime? startDate = null);

		UserConnection UserConnection { get; set; }
	}

	#endregion

	#region Interface: ICurrenciesRateStorage

	/// <summary>
	/// Describes interface for currencies rate storage.
	/// </summary>
	public interface ICurrenciesRateStorage : ICurrencyRateStorage
	{
		/// <summary>
		/// Gets actual currencies rate.
		/// </summary>
		/// <param name="currenciesId">Currency unique identifiers.</param>
		/// <param name="startDate">CurrencyRate start date.</param>
		/// <returns>List of currency rates.</returns>
		IEnumerable<CurrencyRateInfo> GetCurrenciesRate(IEnumerable<Guid> currenciesId, DateTime startDate);

		/// <summary>
		/// Gets actual currencies rate for current user time.
		/// </summary>
		/// <param name="currenciesId">Currency unique identifiers.</param>
		/// <returns>List of currency rates.</returns>
		IEnumerable<CurrencyRateInfo> GetCurrenciesRate(IEnumerable<Guid> currenciesId);
	}

	#endregion

	#region Class: CurrencyRateStorage

	[DefaultBinding(typeof(ICurrenciesRateStorage))]
	public class CurrencyRateStorage : ICurrenciesRateStorage
	{

		#region Fields: Private

		private readonly IDictionary<string, CurrencyRateInfo> _localCurrencyRateInfos =
			new Dictionary<string, CurrencyRateInfo>();

		#endregion

		#region Constructors

		public CurrencyRateStorage(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
			CurrencyRateSchema = UserConnection.EntitySchemaManager.GetInstanceByName("CurrencyRate");
		}

		public CurrencyRateStorage(UserConnection userConnection, EntitySchema schema) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			schema.CheckArgumentNull(nameof(schema));
			UserConnection = userConnection;
			CurrencyRateSchema = schema;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the user connection.
		/// </summary>
		/// <value>
		/// The user connection.
		/// </value>
		public UserConnection UserConnection { get; set; }

		/// <summary>
		/// Gets or sets the currency rate schema.
		/// </summary>
		/// <value>
		/// The currency rate schema.
		/// </value>
		public EntitySchema CurrencyRateSchema { get; set; }

		#endregion

		#region Methods: Private

		private static IEnumerable<Guid> GetValidateCurrenciesCollection(Guid? currencyId) {
			return currencyId == null ? null : new[] { (Guid)currencyId };
		}

		private IEnumerable<CurrencyRateInfo> GetCurrencyRateInfosInternal(IEnumerable<Guid> currenciesId,
			DateTime? startDate) {
			DateTime date = GetCorrectStardDate(startDate);
			IEnumerable<CurrencyRateInfo> rates;
			IEnumerable<CurrencyRateInfo> localRates = new List<CurrencyRateInfo>();
			if (currenciesId != null) {
				localRates = GetCurrencyRateInfosToLocalCollection(currenciesId, date);
				currenciesId = currenciesId.Except(localRates.Select(a => a.CurrencyId));
				if (!currenciesId.Any()) {
					return localRates;
				}
			}
			rates = GetCurrencyRateInfosFromDb(currenciesId, date);
			SetCurrencyRateInfosToLocalCollection(rates, date);
			return localRates.Concat(rates);
		}

		private DateTime GetCorrectStardDate(DateTime? startDate) {
			return startDate ?? UserConnection.CurrentUser.GetCurrentDateTime().ToUniversalTime();
		}

		private List<CurrencyRateInfo> GetCurrencyRateInfosFromDb(IEnumerable<Guid> currenciesId, DateTime date) {
			Select query = GetCurrencyRatesSelect(currenciesId, date);
			var rates = new List<CurrencyRateInfo>();
			query.ExecuteReader((reader) => {
				CurrencyRateInfo rate = GetCurrencyRateInfo(reader);
				rates.Add(rate);
			});
			return rates;
		}

		private void SetCurrencyRateInfosToLocalCollection(IEnumerable<CurrencyRateInfo> rates, DateTime date) {
			foreach (CurrencyRateInfo currencyRateInfo in rates) {
				currencyRateInfo.Rate = CurrencyRateHelper.SetMantissaToRate(currencyRateInfo.Rate,
					currencyRateInfo.RateMantissa);
				var key = GetLocalKey(currencyRateInfo.CurrencyId, date);
				if (!_localCurrencyRateInfos.ContainsKey(key)) {
					_localCurrencyRateInfos.Add(key, currencyRateInfo);
				}
			}
		}

		private IEnumerable<CurrencyRateInfo> GetCurrencyRateInfosToLocalCollection(IEnumerable<Guid> currenciesId,
			DateTime date) {
			IEnumerable<string> keys = currenciesId.Select(a => GetLocalKey(a, date));
			return _localCurrencyRateInfos.Where(a => keys.Contains(a.Key)).Select(a => a.Value).ToList();
		}

		private static string GetLocalKey(Guid currencyId, DateTime date) {
			return string.Join("_", currencyId.ToString(), date);
		}

		#endregion

		#region Methods: Protected

		protected virtual Select GetCurrencyRatesSelect(Guid? currencyId, DateTime? startDate) {
			IEnumerable<Guid> currenciesId = GetValidateCurrenciesCollection(currencyId);
			DateTime date = GetCorrectStardDate(startDate);
			return GetCurrencyRatesSelect(currenciesId, date);
		}

		protected virtual Select GetCurrencyRatesSelect(IEnumerable<Guid> currenciesId, DateTime startDate) {
			Select subSelect = GetActualCurrencyRateSubSelect(startDate);
			var result = new Select(UserConnection).Column("CurrencyRate", "CurrencyId").As("CurrencyId")
				.Column("CurrencyRate", "Rate").As("Rate").Column("CurrencyRate", "RateMantissa").As("RateMantissa")
				.Column("Currency", "Division").As("Division").From(subSelect).As("ActualCurrency")
				.InnerJoin("CurrencyRate").On("ActualCurrency", "CurrencyId").IsEqual("CurrencyRate", "CurrencyId")
				.And("ActualCurrency", "CreatedOn").IsEqual("CurrencyRate", "CreatedOn").InnerJoin("Currency")
				.On("CurrencyRate", "CurrencyId").IsEqual("Currency", "Id") as Select;
			if (!currenciesId.IsNullOrEmpty()) {
				result.Where("Currency", "Id").In(Column.Parameters(currenciesId.Cast<object>()));
			}
			return result;
		}

		protected virtual Select GetActualCurrencyRateSubSelect(DateTime date) {
			var result = new Select(UserConnection).Column("CurrencyRate", "CurrencyId").As("CurrencyId")
				.Column(Func.Max("CurrencyRate", "CreatedOn")).As("CreatedOn").From("CurrencyRate")
				.Where("CurrencyRate", "StartDate").IsLessOrEqual(Column.Parameter(date.Date)).And()
				.OpenBlock("EndDate").IsNull().Or("CurrencyRate", "EndDate")
				.IsGreaterOrEqual(Column.Parameter(date.Date)).CloseBlock()
				.GroupBy("CurrencyRate", "CurrencyId") as Select;
			return result;
		}

		protected virtual void UpdateOldRates(Guid currencyId) {
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			var oldRatesSelect = (Select)new Select(UserConnection).Column("Id").From("CurrencyRate")
				.Where("CurrencyId").IsEqual(Column.Parameter(currencyId)).And("EndDate").IsNull();
			oldRatesSelect.ExecuteReader((reader) => {
				var rateId = reader.GetColumnValue<Guid>("Id");
				UpdateRateEndDate(rateId, currentDate);
			});
		}

		protected virtual void UpdateRateEndDate(Guid rateId, DateTime date) {
			Entity rateEntity = CurrencyRateSchema.CreateEntity(UserConnection);
			rateEntity.FetchFromDB(rateId, false);
			rateEntity.SetColumnValue("EndDate", date);
			rateEntity.Save(false);
		}

		protected virtual void InsertRate(CurrencyRateInfo currencyRateInfo) {
			Entity rateEntity = CurrencyRateSchema.CreateEntity(UserConnection);
			rateEntity.SetDefColumnValues();
			SetColumnsValueToInvertRate(currencyRateInfo, rateEntity);
			rateEntity.Save(false);
		}

		protected virtual void SetColumnsValueToInvertRate(CurrencyRateInfo currencyRateInfo, Entity rateEntity) {
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			rateEntity.SetColumnValue("Id", Guid.NewGuid());
			rateEntity.SetColumnValue("StartDate", currentDate);
			rateEntity.SetColumnValue("CurrencyId", currencyRateInfo.CurrencyId);
			rateEntity.SetColumnValue("Rate", currencyRateInfo.Rate);
			rateEntity.SetColumnValue("RateMantissa", currencyRateInfo.RateMantissa);
		}

		protected virtual CurrencyRateInfo GetCurrencyRateInfo(IDataReader reader) {
			var currencyId = reader.GetColumnValue<Guid>("CurrencyId");
			var rate = reader.GetColumnValue<decimal>("Rate");
			var division = reader.GetColumnValue<int>("Division");
			var rateMantissa = reader.GetColumnValue<string>("RateMantissa");
			return new CurrencyRateInfo {
				CurrencyId = currencyId,
				Rate = rate,
				Division = division,
				RateMantissa = rateMantissa
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves currency rates.
		/// </summary>
		/// <param name="rates">Array of currency rates to save.</param>
		public void SaveRates(params CurrencyRateInfo[] rates) {
			if (rates != null && rates.Length == 0) {
				return;
			}
			foreach (CurrencyRateInfo currencyRateInfo in rates) {
				UpdateOldRates(currencyRateInfo.CurrencyId);
				InsertRate(currencyRateInfo);
			}
		}

		/// <summary>
		/// Gets actual currency rates.
		/// </summary>
		/// <param name="currencyId">Currency unique identifier.</param>
		/// <param name="startDate">Currency rate start date.</param>
		/// <returns>List of currency rates.</returns>
		public List<CurrencyRateInfo> GetActualCurrencyRates(Guid? currencyId = null, DateTime? startDate = null) {
			IEnumerable<Guid> currenciesId = GetValidateCurrenciesCollection(currencyId);
			return GetCurrencyRateInfosInternal(currenciesId, startDate).ToList();
		}

		/// <summary>
		/// Gets actual currencies rate.
		/// </summary>
		/// <param name="currenciesId">Currency unique identifiers.</param>
		/// <param name="startDate">CurrencyRate start date.</param>
		/// <returns>List of currency rates.</returns>
		public IEnumerable<CurrencyRateInfo> GetCurrenciesRate(IEnumerable<Guid> currenciesId, DateTime startDate) {
			IEnumerable<CurrencyRateInfo> rates = GetCurrencyRateInfosInternal(currenciesId, startDate);
			return rates;
		}

		/// <summary>
		/// Gets actual currencies rate for current user time.
		/// </summary>
		/// <param name="currenciesId">Currency unique identifiers.</param>
		/// <returns>List of currency rates.</returns>
		public IEnumerable<CurrencyRateInfo> GetCurrenciesRate(IEnumerable<Guid> currenciesId) {
			IEnumerable<CurrencyRateInfo> rates = GetCurrencyRateInfosInternal(currenciesId, null);
			return rates;
		}

		#endregion

	}

	#endregion

}

