namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: LocationHelper

	/// <summary>
	/// Utilities for working with location entities.
	/// </summary>
	public class LocationHelper
	{

		#region Methods: Private

		private static readonly Regex _cyrillicRegex = new Regex(@"^[\p{IsCyrillic}-/\s\d]+$");
		private readonly UserConnection _userConnection;
		private readonly Dictionary<Guid, string> _sysCultures;
		private readonly Guid _userCultureId;
		private readonly EntitySchema _citySchema;
		private readonly EntitySchema _countrySchema;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="LocationHelper"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public LocationHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_sysCultures = Core.Configuration.SysCulture.GetSysCultures(_userConnection);
			_userCultureId = userConnection.CurrentUser.SysCultureId;
			_citySchema = _userConnection.EntitySchemaManager.GetInstanceByName("City");
			_countrySchema = _userConnection.EntitySchemaManager.GetInstanceByName("Country");
		}

		#endregion

		#region Methods: Private

		private static string IdentifyCulture(string cityName) {
			return _cyrillicRegex.IsMatch(cityName) ? "ru-RU" : "en-US";
		}
		private static IEnumerable<string> IdentifyCulture(IEnumerable<string> cityNames) {
			return cityNames.Select(IdentifyCulture).Distinct();
		}
		private void SetCityQueryCulture(IEnumerable<string> cityNames, EntitySchemaQuery esq) {
			IEnumerable<string> cultures = IdentifyCulture(cityNames);
			Guid cultureId = _userCultureId;
			if (cultures.Count() == 1) {
				var culture = cultures.First();
				cultureId = _sysCultures.FirstOrDefault(pair => pair.Value == culture).Key;
				if (cultureId.IsNotEmpty() && cultureId != _userCultureId) {
					esq.SetLocalizationCultureId(cultureId);
				}
			}
			esq.CacheItemName = string.Format("EmailMining_LocationHelper_SearchForCity_{0}_{1}",
				string.Join(",", cityNames), cultureId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Searches for the city entity.
		/// </summary>
		/// <param name="cityNames">The variants of the city name.</param>
		/// <returns>The found city entity or <c>null</c>.</returns>
		/// <remarks>Tries to identify the city name language and searches for this language's culture.</remarks>
		public Entity SearchForCity(IEnumerable<string> cityNames) {
			if (cityNames.IsNullOrEmpty()) {
				return null;
			}
			var esq = new EntitySchemaQuery(_citySchema) {
				RowCount = 1,
				Cache = _userConnection.ApplicationCache,
				IgnoreDisplayValues = true
			};
			string primaryDisplayColumnName = _citySchema.PrimaryDisplayColumn.Name;
			esq.AddColumn(_citySchema.PrimaryDisplayColumn.Name);
			esq.PrimaryQueryColumn.IsVisible = true;
			SetCityQueryCulture(cityNames, esq);
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryDisplayColumnName, cityNames));
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			return entities.FirstOrDefault();
		}

		/// <summary>
		/// Searches for the country entity.
		/// </summary>
		/// <param name="code">The code of the country.</param>
		/// <remarks>Uses alpha3 code of the country.</remarks>
		/// <returns>The found country entity or <c>null</c>.</returns>
		public Entity SearchForCountry(string code) {
			if (code.IsNullOrEmpty()) {
				return null;
			}
			string cacheItemName =
				string.Format("EmailMining_LocationHelper_SearchForCountry_{0}_{1}", code, _userCultureId);
			var esq = new EntitySchemaQuery(_countrySchema) {
				RowCount = 1,
				Cache = _userConnection.ApplicationCache,
				CacheItemName = cacheItemName,
				IgnoreDisplayValues = true
			};
			esq.AddColumn(_countrySchema.PrimaryDisplayColumn.Name);
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Code", code));
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			return entities.FirstOrDefault();
		}

		#endregion

	}

	#endregion

}

