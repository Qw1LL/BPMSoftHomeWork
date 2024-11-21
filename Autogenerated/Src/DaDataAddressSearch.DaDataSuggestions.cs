namespace BPMSoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.DaDataSuggestions;
	using BPMSoft.Configuration.DaDataSuggestions;

	#region Class: DaDataAddressSearch

	/// <exclude/>
	public partial class DaDataAddressSearch
	{
		#region Private

		/// <summary>
		/// Вспомогательный класс для работы с подсказками.
		/// </summary>
		private DaDataSuggestionsHelper _daDataSuggestionsHelper;

		/// <summary>
		/// Устанавливает значения параметров адреса контрагента, полученных из подсказки DaData.
		/// </summary>
		/// <param name="accountAddress">Подсказка DaData по адресу организации</param>
		private void SetAccountAddressParameters(AddressData accountAddress)
		{
			PostalCode = accountAddress.PostalCode;
			Country = accountAddress.Country;
			CountryIsoCode = accountAddress.CountryIsoCode;
			FederalDistrict = accountAddress.FederalDistrict;
			Region = accountAddress.Region;
			RegionFiasId = accountAddress.RegionFiasId;
			Area = accountAddress.Area;
			AreaFiasId = accountAddress.AreaFiasId;
			City = accountAddress.City;
			CityFiasId = accountAddress.CityFiasId;
			CityDistrict = accountAddress.CityDistrict;
			CityDistrictFiasId = accountAddress.CityDistrictFiasId;
			Settlement = accountAddress.Settlement;
			SettlementFiasId = accountAddress.SettlementFiasId;
			Street = accountAddress.Street;
			StreetFiasId = accountAddress.StreetFiasId;
			House = accountAddress.House;
			HouseFiasId = accountAddress.HouseFiasId;
			Block = accountAddress.Block;
			Flat = accountAddress.Flat;
			Okato = accountAddress.Okato;
			Oktmo = accountAddress.Oktmo;
			GeoLat = accountAddress.GeoLat;
			GeoLon = accountAddress.GeoLon;

			CountryId = _daDataSuggestionsHelper.GetLookupId("Country", "Alpha2Code", CountryIsoCode);
			RegionId = _daDataSuggestionsHelper.GetLookupId("Region", "Name", Region, FilterComparisonType.StartWith);
			CityId = _daDataSuggestionsHelper.GetLookupId("City", "Name", City, FilterComparisonType.StartWith);

		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Выполняет поиск адреса в DaData.
		/// </summary>
		/// <param name="context">Контекст выполнения процесса</param>
		/// <returns></returns>
		protected override bool InternalExecute(ProcessExecutingContext context)
		{
			try
			{
				var userConnection = context.UserConnection;
				var apiKey = (string)Core.Configuration.SysSettings.GetValue(userConnection, "DaDataAPIKey");
				var daDataSuggestionsClient = new DaDataSuggestionsClient(apiKey);
				
				_daDataSuggestionsHelper = new DaDataSuggestionsHelper(userConnection);

				var response = daDataSuggestionsClient.GetAddressData(Address)
					.GetAwaiter().GetResult();

				AddressFound = response.Suggestions.Length != 0 && response.Suggestions[0].Data != null;

				if (!AddressFound)
				{
					ErrorText = "Адрес не найден.";
					return true;
				}

				UnrestrictedValue = response.Suggestions[0].UnrestrictedValue;
				
				SetAccountAddressParameters(response.Suggestions[0].Data);

				return true;
			}
			catch (Exception e)
			{
				Log.Error($"Ошибка при поиске адреса: {e}");
				ErrorText = e.ToString();
				return true;
			}
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters)
		{
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters)
		{
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData()
		{
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData()
		{
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}

