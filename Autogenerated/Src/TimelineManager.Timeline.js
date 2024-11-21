define("TimelineManager", ["ext-base", "BPMSoft", "TimelinePageSetting"], function(Ext, BPMSoft, TimelinePageSettings) {
	/**
	 * Timeline manager.
	 */
	Ext.define("BPMSoft.manager.TimelineManager", {
		alternateClassName: "BPMSoft.TimelineManager",

		singleton: true,

		// region Properties: Private

		/**
		 * Initialization property.
		 * @private
		 * @property {Boolean} _initialized.
		 */
		_initialized: false,

		/**
		 * Indicates whether manager is in initialization process.
		 * @private
		 * @property {Boolean} _initializing.
		 */
		_initializing: false,

		/**
		 * Page setting entity schema name.
		 * @private
		 * @property {String} _pageSettingsEntitySchemaName.
		 */
		_pageSettingsEntitySchemaName: "TimelinePageSetting",

		/**
		 * Tile setting entity schema name.
		 * @private
		 * @property {String} _tileSettingsEntitySchemaName.
		 */
		_tileSettingsEntitySchemaName: "TimelineTileSetting",

		/**
		 * Tile setting entity schema name.
		 * @private
		 * @property {String} _tileSettingsKey.
		 */
		_tileSettingsKey: "TimelineTileSettings",

		/**
		 * Tile settings config.
		 * @private
		 * @property {Array} _tileConfig.
		 */
		_tileConfig: null,

		/**
		 * Timeline pages settings config.
		 * @private
		 * @property {Object} _timelinePageConfig.
		 */
		_timelinePageConfig: null,

		// endregion

		// region Methods: Private

		/**
		 * Returns tile image Url.
		 * @private
		 * @param {String} recordId Record id.
		 * @return {String} Tile mage Url.
		 */
		_getTileImageUrl: function(recordId) {
			return BPMSoft.ImageUrlBuilder.getUrl({
				source: BPMSoft.ImageSources.ENTITY_COLUMN,
				params: {
					schemaName: this._tileSettingsEntitySchemaName,
					columnName: "Image",
					primaryColumnValue: recordId
				}
			});
		},

		/**
		 * Removes link tile from page config.
		 * @private
		 * @param {Object} pageConfig Pages config.
		 */
		_removeLinkTile: function(pageConfig) {
			BPMSoft.each(pageConfig, function(pageTiles) {
				var findedTileConfig = BPMSoft.findItem(pageTiles, {
					"entityConfigKey": "09a6dad5-036b-4075-a813-e8278a5360ea"
				});
				if (findedTileConfig && findedTileConfig.item) {
					pageTiles.splice(findedTileConfig.index, 1);
				}
			}, this);
		},

		// endregion

		// region Methods: Protected

		/**
		 * Processes timeline tile esq result, and sets into tile settings property.
		 * @protected
		 * @param {Object} result Result.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback context.
		 */
		initTilesConfigCallback: function(result, callback, scope) {
			var timelineTileConfig = [];
			if (result && result.success) {
				var collection = result.collection;
				BPMSoft.each(collection, function(item) {
					var tileConfig = item.get("Data");
					var id = item.get("Id");
					if (BPMSoft.isJsonObject(tileConfig)) {
						tileConfig = Ext.decode(tileConfig);
						tileConfig.caption = item.get("Name");
						tileConfig.iconUrl = this._getTileImageUrl(id);
						tileConfig.entityConfigKey = id;
						timelineTileConfig.push(tileConfig);
					}
				}, this);
			}
			this._tileConfig = timelineTileConfig;
			Ext.callback(callback, scope);
		},

		/**
		 * Processes timeline page esq result, and sets into page settings property.
		 * @protected
		 * @param {Object} result Result.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback context.
		 */
		initPagesConfigCallback: function(result, callback, scope) {
			var timelineConfig = {};
			if (result && result.success) {
				var collection = result.collection;
				BPMSoft.each(collection, function(item) {
					var key = item.get("Key");
					var pageConfig = item.get("Data");
					if (BPMSoft.isJsonObject(pageConfig) && key) {
						pageConfig = Ext.decode(pageConfig);
						timelineConfig[key] = pageConfig;
					}
				}, this);
			}
			if (!BPMSoft.Features.getIsEnabled("LinkPreview")) {
				this._removeLinkTile(timelineConfig);
			}
			this._timelinePageConfig = timelineConfig;
			Ext.callback(callback, scope);
		},

		// endregion

		// region Methods: Public

		/**
		 * Initializes timeline configuration.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback context.
		 */
		initPagesConfig: function(callback, scope) {
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: this._pageSettingsEntitySchemaName
			});
			esq.addColumn("Key");
			esq.addColumn("Data");
			esq.getEntityCollection(function(response) {
				this.initPagesConfigCallback(response, callback, scope);
			}, this);
		},

		/**
		 * Initializes timeline tile configuration.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback context.
		 */
		initTilesConfig: function(callback, scope) {
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: this._tileSettingsEntitySchemaName,
				serverESQCacheParameters: {
					cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
					cacheGroup: "Timeline",
					cacheItemName: this._tileSettingsKey
				}
			});
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
			esq.addColumn("Data");
			esq.getEntityCollection(function(result) {
				this.initTilesConfigCallback(result, callback, scope);
			}, this);
		},

		/**
		 * Returns tile config.
		 * @return {Array}
		 */
		getTileConfig: function() {
			return this._tileConfig;
		},

		/**
		 * Returns page config.
		 * @param {String} key Key of config.
		 * @return {Array} Timeline page config.
		 */
		getTimelinePageConfig: function(key) {
			return this._timelinePageConfig && this._timelinePageConfig[key];
		},

		/**
		 * Copies source page config to target page if config not exist.
		 * @param {String} packageUId
		 * @param {String} sourceKey
		 * @param {String} targetKey
		 * @param {Function} callback
		 * @param {Object} scope
		 */
		copyTimelinePageConfig: function({packageUId, sourceKey, targetKey}, callback, scope) {
			BPMSoft.chain((next) => {
				BPMSoft.DataManager.select({
					entitySchemaName: this._pageSettingsEntitySchemaName
				}, next);
			}, (next, dataCollection) => {
				const targetDataItem = dataCollection.findByFn((dataItem) => dataItem.viewModel.get("Key") === targetKey);
				if (targetDataItem) {
					console.warn("Target page config already exists!");
					Ext.callback(callback, scope);
					return;
				}
				next(dataCollection);
			}, (next, dataCollection) => {
				const sourceDataItem = dataCollection.findByFn((dataItem) => dataItem.viewModel.get("Key") === sourceKey);
				if (!sourceDataItem) {
					console.warn("Source page config not found!");
					Ext.callback(callback, scope);
					return;
				}
				next(sourceDataItem);
			}, (next, sourceDataItem) => {
				BPMSoft.DataManager.createItem({
					entitySchemaName: this._pageSettingsEntitySchemaName,
					columnValues: {
						"Key": targetKey,
						"Data": sourceDataItem.viewModel.get("Data"),
					}
				}, next);
			}, (next, dataManagerItem) => {
				BPMSoft.DataManager.addItem(dataManagerItem);
				BPMSoft.DataManager.saveAndUpdatePackageSchemaData({
					entitySchemaNames: [this._pageSettingsEntitySchemaName],
					packageSchemaDataNameTemplate: `{0}_${targetKey}_Data`,
					packageUId,
				}, next);
			}, () => {
				Ext.callback(callback, scope);
			});
		},

		/**
		 * Initializes manager.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initialize: function(callback, scope) {
			if (this._initialized) {
				Ext.callback(callback, scope);
				return;
			}
			if (this._initializing) {
				return;
			}
			this._initializing = true;
			BPMSoft.chain(
				this.initTilesConfig,
				this.initPagesConfig,
				function() {
					this._initialized = true;
					this._initializing = false;
					Ext.callback(callback, scope);
				},
				this);
		}

		// endregion

	});

	return BPMSoft.manager.TimelineManager;
});
