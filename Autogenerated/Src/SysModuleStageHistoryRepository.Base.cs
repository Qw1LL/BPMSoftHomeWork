namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: ISysModuleStageHistoryRepository

	/// <summary>
	/// Provides methods for setting and retrieving stage history settings.
	/// </summary>
	public interface ISysModuleStageHistoryRepository
	{
		#region Methods: Public

		/// <summary>
		/// Finds stage setting.
		/// </summary>
		/// <param name="entitySchemaUId">Entity schema identifier.</param>
		/// <returns><see cref="StageHistorySetting"/></returns>
		StageHistorySetting Find(Guid entitySchemaUId);

		/// <summary>
		/// Gets stage setting.
		/// </summary>
		/// <param name="schemaName">Entity schema name.</param>
		/// <returns><see cref="StageHistorySetting"/></returns>
		StageHistorySetting Get(string schemaName);

		/// <summary>
		/// Saves stage setting.
		/// </summary>
		/// <param name="item"><see cref="StageHistorySetting"/></param>
		void Save(StageHistorySetting item);

		/// <summary>
		/// Gets all stage settings.
		/// </summary>
		IEnumerable<StageHistorySetting> GetAll();

		#endregion
	}

	#endregion
	
	#region Interface : ISysModuleStageHistoryCache

	/// <summary>
	/// Provides methods for setting and retrieving stage history settings to or from cache.
	/// </summary>
	public interface ISysModuleStageHistoryCache
	{
		/// <summary>
		/// Gets is cache initialized.
		/// </summary>
		bool IsCacheInitialized { get; }
		
		/// <summary>
		/// Finds specific stage history setting in cache.
		/// </summary>
		/// <param name="entitySchemaUId">Entity schema unique identifier.</param>
		/// <returns><see cref="StageHistorySetting"/></returns>
		StageHistorySetting FindStageHistorySetting(Guid entitySchemaUId);

		/// <summary>
		/// Add stage history setting to cache.
		/// </summary>
		/// <param name="setting">The stage history settings.</param>
		/// <returns><see cref="StageHistorySetting"/></returns>
		void SetStageHistoryToCache(StageHistorySetting setting);

		/// <summary>
		/// Gets all items from cache.
		/// </summary>
		/// <returns><see cref="StageHistorySetting"/></returns>
		IEnumerable<StageHistorySetting> GetAll();
	}

	#endregion
	
	#region Class: SysModuleStageHistoryApplicationCache
	
	/// <inheritdoc />
	[DefaultBinding(typeof(ISysModuleStageHistoryCache), Name = "Application")]
	public class SysModuleStageHistoryApplicationCache : ISysModuleStageHistoryCache
	{
		#region Constants: Private

		private const string CacheKey = "StageHistorySetting";

		#endregion
		
		#region Properties: Protected
		
		/// <summary>
		/// The user connection.
		/// </summary>
		protected UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets is cache initialized.
		/// </summary
		public bool IsCacheInitialized {
			get {
				var settings = GetStageHistoryFromCache();
				return settings != null;
			}
		}

		#endregion
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SysModuleStageHistoryApplicationCache"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public SysModuleStageHistoryApplicationCache(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}
		
		#endregion

		#region Methods: Private

		private IDictionary<Guid, StageHistorySetting> GetStageHistorySettings() {
			var settings = GetStageHistoryFromCache() ?? GetSafelyStageHistoryFromCache();
			settings.Values.ForEach(value => {
				value.UserConnection = UserConnection;
			});
			return settings;
		}
		
		private IDictionary<Guid, StageHistorySetting> GetSafelyStageHistoryFromCache() {
			return GetStageHistoryFromCache() ?? new Dictionary<Guid, StageHistorySetting>();
		}

		private IDictionary<Guid, StageHistorySetting> GetStageHistoryFromCache() {
			return (IDictionary<Guid, StageHistorySetting>)UserConnection.ApplicationCache[CacheKey]; 
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public StageHistorySetting FindStageHistorySetting(Guid entitySchemaUId) {
			var settings = GetStageHistorySettings();
			settings.TryGetValue(entitySchemaUId, out var result);
			return result;
		}

		/// <inheritdoc />
		public void SetStageHistoryToCache(StageHistorySetting setting) {
			setting.CheckArgumentNull(nameof(setting));
			var cache = GetSafelyStageHistoryFromCache();
			cache[setting.EntitySchemaUId] = setting;
			UserConnection.ApplicationCache[CacheKey] = cache;
		}

		/// <inheritdoc />
		public IEnumerable<StageHistorySetting> GetAll() {
			var settings = GetStageHistorySettings();
			return settings.Values;
		}
		
		#endregion
	}
	
	#endregion
	
	#region Class: SysModuleStageHistoryInMemoryCache

	/// <inheritdoc />
	[DefaultBinding(typeof(ISysModuleStageHistoryCache), Name = "Memory")]
	public class SysModuleStageHistoryInMemoryCache : ISysModuleStageHistoryCache
	{
		#region Properties: Protected

		/// <summary>
		/// The stage setting cache.
		/// </summary>
		protected static Lazy<ConcurrentDictionary<Guid, StageHistorySetting>> SettingsCache { get; private set; } =
			new Lazy<ConcurrentDictionary<Guid, StageHistorySetting>>();

		protected static bool IsSettingsCacheInitialized { get; set; } 
		
		/// <summary>
		/// The user connection.
		/// </summary>
		protected UserConnection UserConnection { get; }
		
		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets is cache initialized.
		/// </summary
		public bool IsCacheInitialized {
			get => IsSettingsCacheInitialized;
		}

		#endregion

		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SysModuleStageHistoryInMemoryCache"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public SysModuleStageHistoryInMemoryCache(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}
		
		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public StageHistorySetting FindStageHistorySetting(Guid entitySchemaUId) {
			SettingsCache.Value.TryGetValue(entitySchemaUId, out StageHistorySetting result);
			return result;
		}

		/// <inheritdoc />
		public void SetStageHistoryToCache(StageHistorySetting setting) {
			setting.CheckArgumentNull(nameof(setting));
			if (!IsSettingsCacheInitialized) {
				IsSettingsCacheInitialized = true;
			}
			if (SettingsCache.Value.ContainsKey(setting.EntitySchemaUId)) {
				SettingsCache.Value.TryUpdate(setting.EntitySchemaUId, setting, SettingsCache.Value[setting.EntitySchemaUId]);
			} else {
				SettingsCache.Value.TryAdd(setting.EntitySchemaUId, setting);
			}
		}
		
		/// <inheritdoc />
		public IEnumerable<StageHistorySetting> GetAll() {
			return SettingsCache.Value.Values;
		}

		#endregion
	}
	
	#endregion

	#region Class: SysModuleStageHistoryRepository

	[DefaultBinding(typeof(ISysModuleStageHistoryRepository))]
	public class SysModuleStageHistoryRepository : ISysModuleStageHistoryRepository
	{

		#region Constants: Private

		private const string SysModuleStageHistorySchemaName = "SysModuleStageHistory";

		#endregion
		
		#region Properties: Protected
		
		/// <summary>
		/// The user connection.
		/// </summary>
		protected UserConnection UserConnection { get; }
		
		private ISysModuleStageHistoryCache _sysModuleStageHistoryCache;

		/// <summary>
		/// The instance of SysModuleStageHistoryCache.
		/// </summary>
		protected ISysModuleStageHistoryCache SysModuleStageHistoryCache {
			get {
				_sysModuleStageHistoryCache = _sysModuleStageHistoryCache ?? (_sysModuleStageHistoryCache = GetSysModuleStageHistoryCache());
				if (!_sysModuleStageHistoryCache.IsCacheInitialized) {
					InitSettingsCache(_sysModuleStageHistoryCache);
				}
				return _sysModuleStageHistoryCache;
			}
			set => _sysModuleStageHistoryCache = value;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="SysModuleStageHistoryRepository"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public SysModuleStageHistoryRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private
		
		private void InitSettingsCache(ISysModuleStageHistoryCache cache) {
			EntityCollection collection = FetchSysModuleStageHistoryCollection();
			foreach (var entity in collection) {
				var setting = new StageHistorySetting(UserConnection);
				setting.FillFromEntity(entity);
				cache.SetStageHistoryToCache(setting);
			}
		}
		
		private EntityCollection FetchSysModuleStageHistoryCollection() {
			var collection = new EntityCollection(UserConnection, SysModuleStageHistorySchemaName);
			collection.Load();
			return collection;
		}

		private ISysModuleStageHistoryCache GetSysModuleStageHistoryCache() {
			var constructorArgs = new[] { new ConstructorArgument("userConnection", UserConnection) };
			bool inMemoryCacheEnabled = UserConnection.GetIsFeatureEnabled("EntityStageHistoryJournalingInMemory");
			if (inMemoryCacheEnabled) {
				return ClassFactory.Get<ISysModuleStageHistoryCache>("Memory", constructorArgs);
			}
			return ClassFactory.Get<ISysModuleStageHistoryCache>("Application", constructorArgs);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public IEnumerable<StageHistorySetting> GetAll() {
			var settings = SysModuleStageHistoryCache.GetAll();
			return settings;
		}

		/// <inheritdoc />
		public void Save(StageHistorySetting setting) {
			setting.CheckArgumentNull(nameof(setting));
			EntitySchema schema = UserConnection.EntitySchemaManager
				.GetInstanceByName(SysModuleStageHistorySchemaName);
			var entity = schema.CreateEntity(UserConnection);
			entity.FetchFromDB(setting.Id);
			setting.FillEntity(entity);
			entity.Save(false);
			SysModuleStageHistoryCache.SetStageHistoryToCache(setting);
		}

		/// <inheritdoc />
		public StageHistorySetting Find(Guid entitySchemaUId) {
			var setting = SysModuleStageHistoryCache.FindStageHistorySetting(entitySchemaUId);
			return setting;
		}

		/// <inheritdoc />
		/// <exception cref="ItemNotFoundException">If can't find setting by <paramref name="schemaName"/>.</exception>
		public StageHistorySetting Get(string schemaName) {
			var schemaUId = UserConnection.EntitySchemaManager.GetItemByName(schemaName).UId;
			var setting = SysModuleStageHistoryCache.FindStageHistorySetting(schemaUId);
			if (setting == null) {
				throw new Common.ItemNotFoundException($"Schema name = {schemaName}");
			}
			return setting;
		}

		#endregion

	}

	#endregion
}

