namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Store;

	#region Interface: IForecastSheetRepository

	/// <summary>
	/// Provides methods to retrieve information about the forecast.
	/// </summary>
	public interface IForecastSheetRepository
	{
		/// <summary>
		/// Gets the sheet.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <returns><see cref="Sheet"/></returns>
		Sheet GetSheet(Guid forecastId);
	}

	/// <summary>
	/// Provides methods to retrieve information about the forecast.
	/// </summary>
	public interface IForecastSheetRepositoryV2 : IForecastSheetRepository
	{
		/// <summary>
		/// Gets the sheet.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <returns><see cref="Sheet"/></returns>
		Sheet GetSheet(SheetFilterConfig config);
	}

	/// <summary>
	/// Provides methods to update the forecast.
	/// </summary>
	public interface IUpdateForecastSheetRepository: IForecastSheetRepositoryV2
	{
		/// <summary>
		/// Update the sheet.
		/// </summary>
		/// <param name="sheet">The forecast sheet.</param>
		/// <returns><see cref="bool"/>Is successfully updated.</returns>
		bool UpdateSheet(Sheet sheet);
	}

	/// <summary>
	/// Forecast sheet.
	/// </summary>
	public class Sheet
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the period type identifier.
		/// </summary>
		/// <value>
		/// The period type identifier.
		/// </value>
		public Guid PeriodTypeId { get; set; }

		/// <summary>
		/// Gets or sets the setting.
		/// </summary>
		/// <value>
		/// The setting.
		/// </value>
		public SheetSetting Setting { get; set; }

		/// <summary>
		/// Gets or sets the forecast entity identifier.
		/// </summary>
		/// <value>
		/// The forecast entity identifier.
		/// </value>
		public Guid ForecastEntityUId { get; set; }

		/// <summary>
		/// Gets or sets the forecast entity in cell identifier.
		/// </summary>
		/// <value>
		/// The forecast entity in cell identifier.
		/// </value>
		public Guid ForecastEntityInCellUId { get; set; }

		/// <summary>
		/// Gets or sets the last forecast calculation date and time.
		/// </summary>
		/// <value>
		/// The last forecast calculation date and time.
		/// </value>
		public DateTime LastCalculationDateTime { get; set; }

		/// <summary>
		/// Returns hierarchy collection from settings.
		/// </summary>
		/// <returns>Hierarchy items collection</returns>
		public IEnumerable<HierarchySettingItem> GetHierarchyItems() {
			return Setting?.Hierarchy ?? new HierarchySettingItem[0];
		}

		/// <summary>
		/// Returns entity in forecast's value column by current sheet.
		/// </summary>
		/// <param name="sheet">Forecast Sheet.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Value column.</returns>
		public EntitySchemaColumn GetEntityInForecastValueColumn(UserConnection userConnection) {
			EntitySchema schema = userConnection.EntitySchemaManager.GetInstanceByUId(ForecastEntityInCellUId);
			return schema.Columns.FindByName("Value");
		}

		/// <summary>
		/// Returns entity in forecast cell entity reference column.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Entity reference column</returns>
		public EntitySchemaColumn GetEntityReferenceColumn(UserConnection userConnection) {
			EntitySchema forecastEntityInCell = userConnection.EntitySchemaManager
				.FindInstanceByUId(ForecastEntityInCellUId);
			EntitySchemaColumn column = forecastEntityInCell?.Columns.FirstOrDefault(c =>
				c.ReferenceSchemaUId == ForecastEntityUId && !c.IsInherited);
			return column;
		}
	}

	/// <summary>
	/// Sheet select filter config.
	/// </summary>
	public class SheetFilterConfig
	{
		/// <summary>
		/// Forecast identifier.
		/// </summary>
		public Guid ForecastId { get; set; }

		/// <summary>
		/// Save and retrieve from cache.
		/// Enabled by default.
		/// </summary>
		public bool UseCaching { get; set; }
	}

	/// <summary>
	/// Forecast sheet setting.
	/// </summary>
	[Serializable]
	public class SheetSetting
	{
		/// <summary>
		/// Gets or sets the auto calculation settings.
		/// </summary>
		/// /// <value>
		/// The auto calculation settings.
		/// </value>
		public AutoCalculationSettings AutoCalculation { get; set; }

		/// <summary>
		/// Auto-snapshot settings
		/// </summary>
		public AutoSnapshotSettings AutoSnapshot { get; set; }
		
		/// <summary>
		/// The timezone identifier.
		/// </summary>
		public Guid? TimeZoneId { get; set; }

		/// <summary>
		/// Gets or sets the hierarchy.
		/// </summary>
		/// <value>
		/// The hierarchy.
		/// </value>
		public IEnumerable<HierarchySettingItem> Hierarchy { get; set; }
	}

	#region AutoCalculationSettings

	/// <summary>
	/// The auto calculation settings.
	/// </summary>
	[Serializable]
	public class AutoCalculationSettings
	{
		/// <summary>
		/// Gets or sets the auto calculation enabled.
		/// </summary>
		public bool IsEnabled { get; set; }

		/// <summary>
		/// Gets or sets the cron expression.
		/// </summary>
		public string CronExpression { get; set; }

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="obj">The object to compare with the current object. </param>
		/// <returns>
		/// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
		public override bool Equals(object obj) {
			var objToCompare = obj as AutoCalculationSettings;
			if (objToCompare == null) {
				return false;
			}
			return IsEnabled.Equals(objToCompare.IsEnabled) && CronExpression == objToCompare.CronExpression;
		}

		/// <summary>Serves as the default hash function. </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode() {
			return (IsEnabled + CronExpression).GetHashCode();
		}
	}

	#endregion

	#region AutoSnapshotSettings

	public class AutoSnapshotSettings
	{
		public bool IsEnabled { get; set; }

		public AutoSnapshotTime Time { get; set; }
		
		public override bool Equals(object obj) {
			var objToCompare = obj as AutoSnapshotSettings;
			if (objToCompare == null) {
				return false;
			}
			return IsEnabled.Equals(objToCompare.IsEnabled) 
				&& Time.Equals(objToCompare.Time);
		}

		public override int GetHashCode() {
			return IsEnabled.GetHashCode() ^ Time?.GetHashCode() ?? 1;
		}
	}

	#endregion
	
	#region AutoSnapshotTime
	
	public class AutoSnapshotTime
	{
		public int Hours { get; set; }
		
		public int Minutes { get; set; }
		
		public override bool Equals(object obj) {
			var objToCompare = obj as AutoSnapshotTime;
			if (objToCompare == null) {
				return false;
			}
			return Hours.Equals(objToCompare.Hours) 
				&& Minutes.Equals(objToCompare.Minutes);
		}
		
		public override int GetHashCode() {
			return Hours.GetHashCode() ^ Minutes.GetHashCode();
		}
	}
	
	#endregion

	#endregion

	#region HierarchySettingItem

	/// <summary>
	/// Forecast sheet hierarchy setting item.
	/// </summary>
	[Serializable]
	public class HierarchySettingItem
	{
		/// <summary>
		/// Gets or sets the column path.
		/// </summary>
		/// <value>
		/// The column path.
		/// </value>
		public string ColumnPath { get; set; }
		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		/// <value>
		/// The level.
		/// </value>
		public int Level { get; set; }
	}

	#endregion

	#region Class: ForecastSheetCacheListener

	[EntityEventListener(SchemaName = "ForecastSheet")]
	public class ForecastSheetCacheListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void ClearCache(UserConnection userConnection, Guid forecastId) {
			var group = userConnection.ApplicationCache.WithLocalCaching(ForecastSheetRepository.CacheGroupName);
			string key = forecastId.ToString();
			group.Remove(key);
		}

		#endregion

		#region Methods: Public

		/// <summary>Hadles entity Saving event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" />
		/// instance containing the event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var entity = (Entity)sender;
			ClearCache(entity.UserConnection, entity.PrimaryColumnValue);
		}

		/// <summary>Hadles entity Deleting event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" />
		/// instance containing the event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			ClearCache(entity.UserConnection, entity.PrimaryColumnValue);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastSheetRepository

	/// <summary>
	/// Provides methods to retrieve information about the forecast.
	/// </summary>
	/// <seealso cref="IForecastSheetRepository" />
	[DefaultBinding(typeof(IForecastSheetRepository))]
	[DefaultBinding(typeof(IForecastSheetRepositoryV2))]
	[DefaultBinding(typeof(IUpdateForecastSheetRepository))]
	public class ForecastSheetRepository : IUpdateForecastSheetRepository
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Forecast");

		#endregion

		#region Fields: Public

		public static readonly string CacheGroupName = "ForecastSheet";

		#endregion

		#region Constructors: Public

		public ForecastSheetRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Methods: Private

		private Sheet GetSheet(Entity entity) {
			var result = new Sheet();
			result.Id = entity.PrimaryColumnValue;
			result.Name = entity.GetTypedColumnValue<string>(ForecastConsts.Name);
			result.PeriodTypeId = entity.GetTypedColumnValue<Guid>(ForecastConsts.PeriodType);
			result.ForecastEntityUId = entity.GetTypedColumnValue<Guid>(ForecastConsts.ForecastEntity);
			result.ForecastEntityInCellUId = entity.GetTypedColumnValue<Guid>(ForecastConsts.ForecastEntityInCell);
			result.LastCalculationDateTime = entity.GetTypedColumnValue<DateTime>(ForecastConsts.LastCalculationDateTime);
			var settingJson = entity.GetTypedColumnValue<string>(ForecastConsts.Setting);
			result.Setting = GetSetting(settingJson);
			return result;
		}

		private SheetSetting GetSetting(string settingJson) {
			try {
				return Json.Deserialize<SheetSetting>(settingJson);
			}
			catch (Exception e) {
				_log.ErrorFormat("An error occurred while JSON not valid: {0}, Message: {1}, StackTrace: {2}",
					settingJson, e.Message, e.StackTrace);
			}
			return new SheetSetting();
		}

		private Entity GetEntity(Guid forecastId, bool useCaching = true) {
			EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, ForecastConsts.ForecastSheet);
			if (useCaching) {
				esq.Cache = UserConnection.ApplicationCache.WithLocalCaching(CacheGroupName);
				esq.CacheItemName = forecastId.ToString();
			}
			esq.AddAllSchemaColumns();
			Entity entity = esq.GetEntity(UserConnection,  forecastId);
			return entity;
		}

		private void RemoveFromCache(Guid forecastId) {
			ICacheStore cache = UserConnection.ApplicationCache.WithLocalCaching(CacheGroupName);
			cache.Remove(forecastId.ToString());
		}

		private void UpdateEntityColumns(IEntity entity, Sheet sheet) {
			JsonSerializerSettings serializeSettings = GetSerializerSettings();
			string settings = JsonConvert.SerializeObject(sheet.Setting, serializeSettings);
			entity.SetColumnValue(ForecastConsts.Name, sheet.Name);
			entity.SetColumnValue(ForecastConsts.Setting, settings);
			entity.SetColumnValue(ForecastConsts.PeriodType, sheet.PeriodTypeId);
			entity.SetColumnValue(ForecastConsts.ForecastEntity, sheet.ForecastEntityUId);
			entity.SetColumnValue(ForecastConsts.LastCalculationDateTime, sheet.LastCalculationDateTime);
			entity.SetColumnValue(ForecastConsts.ForecastEntityInCell, sheet.ForecastEntityInCellUId);
		}

		private JsonSerializerSettings GetSerializerSettings() {
			var contractResolver = new DefaultContractResolver {
				NamingStrategy = new CamelCaseNamingStrategy()
			};
			var serializeSettings = new JsonSerializerSettings {
				ContractResolver = contractResolver
			};
			return serializeSettings;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the sheet.
		/// </summary>
		/// <param name="forecastId">The forecast identifier.</param>
		/// <returns><see cref="Sheet"/></returns>
		public Sheet GetSheet(Guid forecastId) {
			forecastId.CheckArgumentEmpty(nameof(forecastId));
			Entity entity = GetEntity(forecastId);
			return GetSheet(entity);
		}

		/// <summary>
		/// Update the sheet.
		/// </summary>
		/// <param name="sheet">The forecast sheet.</param>
		/// <returns><see cref="bool"/>Is successfully updated.</returns>
		public bool UpdateSheet(Sheet sheet) {
			sheet.CheckArgumentNull(nameof(sheet));
			sheet.Id.CheckArgumentEmpty(nameof(sheet.Id));
			Entity entity = GetEntity(sheet.Id);
			if (entity == null) {
				return false;
			}
			UpdateEntityColumns(entity, sheet);
			bool result = entity.Save();
			if (result) {
				RemoveFromCache(sheet.Id);
			}
			return result;
		}

		/// <summary>
		/// Gets the sheet.
		/// </summary>
		/// <param name="forecastId">Filter config.</param>
		/// <returns><see cref="Sheet"/></returns>
		public Sheet GetSheet(SheetFilterConfig config) {
			config.CheckArgumentNull(nameof(config));
			Entity entity = GetEntity(config.ForecastId, config.UseCaching);
			return GetSheet(entity);
		}

		#endregion

	}

	#endregion

}

