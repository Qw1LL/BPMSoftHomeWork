namespace BPMSoft.Configuration.ForecastV2
{
	using Newtonsoft.Json.Linq;
	using Newtonsoft.Json;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.UI.WebControls.ResourceHandlers;
	
	#region Class: ChunksConfig
	
	/// <summary>
	/// Provides properties for collection chunking.
	/// </summary>
	public class ChunksConfig
	{
		/// <summary>
		/// Gets or sets the max parameters counter per chunk query.
		/// </summary>
		/// <value>
		/// The max parameters counter per chunk query.
		/// </value>
		public int MaxParametersCounterPerQueryChunk { get; set; }

		/// <summary>
		/// Gets or sets the insert columns count.
		/// </summary>
		/// <value>
		/// The insert columns count.
		/// </value>
		public int InsertColumnsCount { get; set; }
	}
	
	#endregion

	#region Class: ForecastExtensions

	/// <summary>
	/// Utilities extensions for forecasts.
	/// </summary>
	public static class ForecastExtensions
	{
		#region Class: DTO

		private class FilterPeriod
		{
			[JsonProperty("Id")]
			public string Id { get; set; }
		}

		private class Filters
		{
			[JsonProperty("filterPeriods")]
			public IEnumerable<FilterPeriod> FilterPeriods { get; set; }
		}

		private class Profile
		{
			[JsonProperty("filters")]
			public Filters Filters { get; set; }
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the chunks from collection.
		/// </summary>
		/// <param name="collection">The source collection.</param>
		/// <param name="config">The chunks config.</param>
		/// <returns>The splitted collection.</returns>
		public static IEnumerable<IEnumerable<T>> GetChunks<T>(IEnumerable<T> collection, ChunksConfig config) {
			collection.CheckArgumentNull(nameof(collection));
			config.CheckArgumentNull(nameof(config));
			double maxParamsPerChunk = (double)config.MaxParametersCounterPerQueryChunk / config.InsertColumnsCount;
			int chunksCount = (int)Math.Ceiling(collection.Count() / maxParamsPerChunk);
			var chunks = collection.SplitOnParts(chunksCount);
			return chunks;
		}
		
		/// <summary>
		/// Gets periods by ids.
		/// If period ids are empty - returns periods for current year by period type.
		/// </summary>
		/// <param name="periodRepository">Periods repository.</param>
		/// <param name="periodIds">Periods identifiers.</param>
		/// <param name="periodTypeId">Period type identifier.</param>
		/// <returns></returns>
		public static IEnumerable<Period> GetForecastPeriods(this IPeriodRepository periodRepository,
				IEnumerable<Guid> periodIds, Guid periodTypeId) {
			if (periodIds.IsNullOrEmpty()) {
				return periodRepository.GetPeriods(periodTypeId, DateTime.UtcNow.Year);
			}
			return periodRepository.GetPeriods(periodIds);
		}

		/// <summary>
		/// Returns precision of forecast value column.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns></returns>
		public static int GetForecastValueColumnPrecision(this Sheet sheet, UserConnection userConnection) {
			var column = sheet.GetEntityInForecastValueColumn(userConnection);
			var valueType = column.DataValueType as FloatDataValueType;
			return valueType.Precision;
		}

		/// <summary>
		/// Checks cell value according to forecast sheet's entity's value column size.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="userConnection">User connection.</param>
		/// <param name="value">Cell value.</param>
		/// <returns>Cell value does not exceed column size and can be safely used for operations.</returns>
		public static bool CheckForecastValueExceedMaxSize(this Sheet sheet, UserConnection userConnection,
				decimal value) {
			var column = sheet.GetEntityInForecastValueColumn(userConnection);
			var valueType = column.DataValueType as FloatDataValueType;
			int decimalSizeLimit = valueType.DBSize - valueType.DBPrecision;
			int decimalPartLength = Math.Truncate(value).ToString().Length;
			return decimalPartLength > decimalSizeLimit;
		}

		/// <summary>
		/// Forms hierarchy filter items collection from sheet's hierarchy settings.
		/// </summary>
		/// <param name="sheet"></param>
		/// <param name="hierarchyRowIds"></param>
		/// <returns></returns>
		public static IEnumerable<HierarchyFilterItem> FormHierarchyFilter(this Sheet sheet,
			IEnumerable<Guid> hierarchyRowIds) {
			var hierarchyFilter = new List<HierarchyFilterItem>();
			int index = 0;
			IEnumerable<HierarchySettingItem> sheetHierarchyList = sheet.GetHierarchyItems();
			hierarchyRowIds?.ForEach(hierarchyId => {
				hierarchyFilter.Add(new HierarchyFilterItem {
					Value = hierarchyId,
					ColumnPath = sheetHierarchyList.ElementAt(index).ColumnPath
				});
				index++;
			});
			return hierarchyFilter;
		}

		/// <summary>
		/// Gets periods identifiers from specified forcast from sysprofile.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <returns>Periods identifiers collection.</returns>
		public static IEnumerable<Guid> GetPeriodsId(UserConnection userConnection, Guid forecastId) {
			string profileKey = "ForecastProfile";
			UserProfileResourceHandler handler = ClassFactory.Get<UserProfileResourceHandler>(
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("resourceName", profileKey));
			byte[] profileByte = handler.Fetch();
			string profileDataStr = Encoding.UTF8.GetString(profileByte);
			if (string.IsNullOrEmpty(profileDataStr)) {
				return Enumerable.Empty<Guid>();
			}
			Profile profile;
			try {
				var profileData = (JObject)Json.Deserialize(profileDataStr);
				var filtersObj = profileData.Value<JObject>(forecastId.ToString());
				profile = Json.Deserialize<Profile>(filtersObj.ToString());
			} catch (Exception ex) {
				return Enumerable.Empty<Guid>();
			}
			var periodsId = profile?.Filters?.FilterPeriods?.Select(period => {
				return new Guid(period.Id);
			}).ToArray();
			return periodsId;
		}

		/// <summary>
		/// Sets snapshot data to snapshot holder if possible.
		/// </summary>
		/// <param name="snapshotHolder"></param>
		/// <param name="snapshot"></param>
		public static void SetSnapshotData(this ISnapshot snapshotHolder, ForecastSnapshotData snapshot) {
			if (snapshotHolder != null) {
				snapshotHolder.SnapshotData = snapshot;
			}
		}

		#endregion

	}

	#endregion

}

