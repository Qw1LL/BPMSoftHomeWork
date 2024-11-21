namespace BPMSoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using BPMSoft.DaDataSuggestions;
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
	using static BPMSoft.DaDataSuggestions.DaDataSuggestionsEnums;
	using BPMSoft.Configuration.DaDataSuggestions;

	#region Class: DaDataAccountSearch

	/// <exclude/>
	public partial class DaDataAccountSearch
	{
		#region Private

		/// <summary>
		/// Дата начала отсчета временной метки.
		/// </summary>
		private DateTime _timeStampStartDate = new DateTime(1970, 1, 1);

		/// <summary>
		/// Вспомогательный класс для работы с подсказками.
		/// </summary>
		private DaDataSuggestionsHelper _daDataSuggestionsHelper;

		/// <summary>
		/// Преобразует временную метку с миллисекундами в дату.
		/// </summary>
		/// <param name="timeStamp">Временная метка с миллисекундами</param>
		/// <returns>Дата, соответствующая временной метке</returns>
		private DateTime? GetDateFromTimeStamp(string timeStamp)
		{
			return string.IsNullOrEmpty(timeStamp)
				? null
				: (DateTime?)_timeStampStartDate.AddMilliseconds(long.Parse(timeStamp));
		}

		/// <summary>
		/// Преобразует значение параметра "Тип организации (DaData)" в соответствующий enum.
		/// </summary>
		/// <param name="daDataAccountTypeId">Id записи справочника "Тип организации (DaData)"</param>
		/// <returns>Тип организации (enum)</returns>
		private OrganizationType? GetOrganizationType(Guid daDataAccountTypeId)
		{
			var organizationTypeCode = (daDataAccountTypeId == Guid.Empty)
					? null
					: _daDataSuggestionsHelper
						.GetLookupValueById("DaDataAccountType", daDataAccountTypeId, "Code")?
						.ToString();

			var organizationType = string.IsNullOrEmpty(organizationTypeCode)
				? null
				: (OrganizationType?)Enum.Parse(typeof(OrganizationType), organizationTypeCode);

			return organizationType;
		}

		/// <summary>
		/// Устанавливает значения параметров контрагента, полученных из подсказки DaData.
		/// </summary>
		/// <param name="account">Подсказка DaData по организации</param>
		private void SetAccountParameters(AccountData account)
		{
			Inn = account.Inn;
			Kpp = account.Kpp;
			Ogrn = account.Ogrn;
			NameFullWithOpf = account.Name?.FullWithOpf;
			NameShortWithOpf = account.Name?.ShortWithOpf;
			NameFull = account.Name?.Full;
			NameShort = account.Name?.Short;
			Okato = account.Okato;
			Oktmo = account.Oktmo;
			Okpo = account.Okpo;
			Okogu = account.Okogu;
			Okfs = account.Okfs;
			Okved = account.Okved;
			OpfFull = account.Opf?.Full;
			OpfShort = account.Opf?.Short;
			OpfCode = account.Opf?.Code;
			ManagementName = account.Management?.Name;
			ManagementPost = account.Management?.Post;
			Address = account.Address?.Value;

			BranchCount = (int.TryParse(account.BranchCount, out int branchCount))
				? branchCount
				: 0;

			var ogrnDate = GetDateFromTimeStamp(account.OgrnDate);
			if (ogrnDate != null)
			{
				OgrnDate = ogrnDate.Value;
			}

			var registrationDate = GetDateFromTimeStamp(account.State?.RegistrationDate);
			if (registrationDate != null)
			{
				RegistrationDate = registrationDate.Value;
			}
			var liquidationDate = GetDateFromTimeStamp(account.State?.LiquidationDate);
			if (liquidationDate != null)
			{
				LiquidationDate = liquidationDate.Value;
			}

			var actualityDate = GetDateFromTimeStamp(account.State?.ActualityDate);
			if (actualityDate != null)
			{
				ActualityDate = actualityDate.Value;
			}

			if (DaDataAccountTypeId == Guid.Empty)
			{
				DaDataAccountTypeId = _daDataSuggestionsHelper.GetLookupId("DaDataAccountType", "Code", account.Type);
			}

			DaDataAccountStatusId = _daDataSuggestionsHelper.GetLookupId("DaDataAccountStatus", "Code", account.State.Status);
			DaDataBranchTypeId = _daDataSuggestionsHelper.GetLookupId("DaDataBranchType", "Code", account.BranchType);
			AccountOwnershipId = _daDataSuggestionsHelper.GetLookupId("AccountOwnership", "Name", OpfShort);
		}

		/// <summary>
		/// Устанавливает значения параметров адреса контрагента, полученных из подсказки DaData.
		/// </summary>
		/// <param name="accountAddress">Подсказка DaData по адресу организации</param>
		private void SetAccountAddressParameters(AddressData accountAddress)
		{
			if (accountAddress == null)
			{
				return;
			}

			AddressPostalCode = accountAddress.PostalCode;
			AddressCountry = accountAddress.Country;
			AddressCountryIsoCode = accountAddress.CountryIsoCode;
			AddressFederalDistrict = accountAddress.FederalDistrict;
			AddressRegion = accountAddress.Region;
			AddressRegionFiasId = accountAddress.RegionFiasId;
			AddressArea = accountAddress.Area;
			AddressAreaFiasId = accountAddress.AreaFiasId;
			AddressCity = accountAddress.City;
			AddressCityFiasId = accountAddress.CityFiasId;
			AddressCityDistrict = accountAddress.CityDistrict;
			AddressCityDistrictFiasId = accountAddress.CityDistrictFiasId;
			AddressSettlement = accountAddress.Settlement;
			AddressSettlementFiasId = accountAddress.SettlementFiasId;
			AddressStreet = accountAddress.Street;
			AddressStreetFiasId = accountAddress.StreetFiasId;
			AddressHouse = accountAddress.House;
			AddressHouseFiasId = accountAddress.HouseFiasId;
			AddressBlock = accountAddress.Block;
			AddressFlat = accountAddress.Flat;
			AddressOkato = accountAddress.Okato;
			AddressOktmo = accountAddress.Oktmo;
			AddressGeoLat = accountAddress.GeoLat;
			AddressGeoLon = accountAddress.GeoLon;

			AddressCountryId = _daDataSuggestionsHelper.GetLookupId("Country", "Alpha2Code", AddressCountryIsoCode);
			AddressRegionId = _daDataSuggestionsHelper.GetLookupId("Region", "Name", AddressRegion, FilterComparisonType.StartWith);
			AddressCityId = _daDataSuggestionsHelper.GetLookupId("City", "Name", AddressCity, FilterComparisonType.StartWith);

		}

		#endregion

		#region Methods: Protected
		/// <summary>
		/// Выполняет поиск контрагента в DaData.
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

				var organizationType = GetOrganizationType(DaDataAccountTypeId);
				var branchType = IsMain
					? (BranchType?)BranchType.MAIN
					: null;

				var response = daDataSuggestionsClient
					.GetAccountDataByFilter(Inn, branchType, Kpp, organizationType)
					.GetAwaiter()
					.GetResult();

				AccountFound = response.Suggestions.Length != 0 && response.Suggestions[0].Data != null;

				if (!AccountFound)
				{
					ErrorText = "Контрагент не найден.";
					return true;
				}

				UnrestrictedValue = response.Suggestions[0].UnrestrictedValue;

				SetAccountParameters(response.Suggestions[0].Data);
				SetAccountAddressParameters(response.Suggestions[0].Data.Address?.Data);

				return true;
			}
			catch (Exception e)
			{
				Log.Error($"Ошибка при поиске контрагента: {e}");
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

