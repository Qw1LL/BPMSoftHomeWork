define("MobileGridDesignerModule", ["ext-base", "MobileGridDesignerModuleResources", "MobileBaseDesignerModule",
		"MobileGridDesignerSettings"],
	function(Ext, resources) {

		/**
		 * @class BPMSoft.configuration.MobileGridDesignerViewConfig
		 * #####, ############ ############ ############# ### ###### ######### #######.
		 */
		Ext.define("BPMSoft.configuration.MobileGridDesignerViewConfig", {
			extend: "BPMSoft.MobileBaseDesignerViewConfig",
			alternateClassName: "BPMSoft.MobileGridDesignerViewConfig",

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewConfig#getDesignerItemsView
			 * @overridden
			 */
			getDesignerItemsView: function() {
				var primaryColumnConfig = this.getGridPrimaryColumnViewConfig();
				var subtitleColumnsConfig = this.getGridSubtitleColumnsViewConfig();
				var groupColumnsConfig = this.getGridGroupColumnsViewConfig();
				return [primaryColumnConfig, subtitleColumnsConfig, groupColumnsConfig];
			},

			/**
			 * Returns view config for grid primary column.
			 * @protected
			 * @virtual
			 * @returns {Object} Configuration.
			 */
			getGridPrimaryColumnViewConfig: function() {
				var designerSettings = this.designerSettings;
				var itemsViewConfig = this.getGridLayoutEditItemsViewConfig({
					name: designerSettings.name,
					maxRows: 1
				});
				var config = {
					caption: { "bindTo": "Resources.Strings.GridColumnsLabelCaption" },
					disableTools: true,
					name: designerSettings.name,
					itemType: BPMSoft.ViewItemType.CONTROL_GROUP,
					items: itemsViewConfig
				};
				return config;
			},

			/**
			 * Returns view config for grid subtitle columns.
			 * @protected
			 * @virtual
			 * @returns {Object} Configuration.
			 */
			getGridSubtitleColumnsViewConfig: function() {
				var name = "SubtitleColumns";
				var itemsViewConfig = this.getGridLayoutEditItemsViewConfig({
					name: name
				});
				var config = {
					caption: { "bindTo": "Resources.Strings.GridSubtitleColumnsLabelCaption" },
					disableTools: true,
					name: name,
					itemType: BPMSoft.ViewItemType.CONTROL_GROUP,
					items: itemsViewConfig
				};
				return config;
			},

			/**
			 * Returns view config for grid group columns.
			 * @protected
			 * @virtual
			 * @returns {Object} Configuration.
			 */
			getGridGroupColumnsViewConfig: function() {
				var name = "GroupColumns";
				var itemsViewConfig = this.getGridLayoutEditItemsViewConfig({
					name: name
				});
				var config = {
					caption: { "bindTo": "Resources.Strings.GridGroupColumnsLabelCaption" },
					disableTools: true,
					name: name,
					itemType: BPMSoft.ViewItemType.CONTROL_GROUP,
					items: itemsViewConfig
				};
				return config;
			}

		});

		/**
		 * @class BPMSoft.configuration.MobileGridDesignerViewModel
		 * ##### ###### ############# ###### ######### #######.
		 */
		Ext.define("BPMSoft.configuration.MobileGridDesignerViewModel", {
			extend: "BPMSoft.MobileBaseDesignerViewModel",
			alternateClassName: "BPMSoft.MobileGridDesignerViewModel",

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewModel#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewModel#init
			 * @overridden
			 */
			init: function() {
				var designerSettings = this.designerSettings;
				var name = designerSettings.name;
				this.generateGridLayoutEditViewBindingData(name, designerSettings.items);
				this.generateControlGroupBindingData(name);
				this.generateGridLayoutEditViewBindingData("SubtitleColumns", designerSettings.subtitleItems);
				this.generateControlGroupBindingData("SubtitleColumns");
				this.generateGridLayoutEditViewBindingData("GroupColumns", designerSettings.groupItems);
				this.generateControlGroupBindingData("GroupColumns");
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewModel#onAddGridLayoutItemButtonClick
			 * @overridden
			 */
			onAddGridLayoutItemButtonClick: function() {
				var tag = arguments[3];
				this.openStructureExplorer({
					entitySchemaName: this.designerSettings.entitySchemaName,
					callback: Ext.bind(this.gridLayoutItemAddedCallback, this, [tag], true)
				});
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewModel#onRemoveGridLayoutItemButtonClick
			 * @overridden
			 */
			onRemoveGridLayoutItemButtonClick: function() {
				var collectionName = arguments[3];
				this.removeSelectedItemsFromCollection(collectionName);
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewModel#onCollectionChange
			 * @overridden
			 */
			onCollectionChange: function(collection, name) {
				this.callParent(arguments);
				if (name === this.designerSettings.name) {
					var enableAddPropertyName = this.getEnableAddPropertyName(name);
					var enableAdd = collection.getCount() === 0;
					this.set(enableAddPropertyName, enableAdd);
				}
			},

			/**
			 * ############ ######### ###### ## #### ######### #######.
			 * @protected
			 * @virtual
			 * @param {Object} explorerColumnConfig ############ #######.
			 */
			gridLayoutItemAddedCallback: function(explorerColumnConfig, collectionName) {
				var columnConfig = this.getColumnConfigFromStructureExplorer(explorerColumnConfig);
				var designerSettings = this.designerSettings;
				var columnItem = designerSettings.createColumnItem(columnConfig);
				this.addColumnItemToGridLayoutCollection(collectionName, columnItem);
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerViewModel#generateDesignerSettingsConfig
			 * @overridden
			 */
			generateDesignerSettingsConfig: function() {
				var designerSettingsConfig = this.callParent(arguments);
				var name = this.designerSettings.name;
				var itemsCollection = this.getItemsCollectionByName(name);
				designerSettingsConfig.items = this.generateSettingsConfigCollectionItems(itemsCollection);
				itemsCollection = this.getItemsCollectionByName("SubtitleColumns");
				designerSettingsConfig.subtitleItems = this.generateSettingsConfigCollectionItems(itemsCollection);
				itemsCollection = this.getItemsCollectionByName("GroupColumns");
				designerSettingsConfig.groupItems = this.generateSettingsConfigCollectionItems(itemsCollection);
				return designerSettingsConfig;
			}

		});

		/**
		 * @class BPMSoft.configuration.MobileGridDesignerModule
		 * ##### ###### ######### ####### ########## ##########.
		 */
		var designerModule = Ext.define("BPMSoft.configuration.MobileGridDesignerModule", {
			extend: "BPMSoft.MobileBaseDesignerModule",
			alternateClassName: "BPMSoft.MobileGridDesignerModule",

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerModule#viewModelClassName
			 * @overridden
			 */
			viewModelClassName: "BPMSoft.MobileGridDesignerViewModel",

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerModule#viewModelConfigClassName
			 * @overridden
			 */
			viewModelConfigClassName: "BPMSoft.MobileGridDesignerViewConfig",

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerModule#designerSettingsClassName
			 * @overridden
			 */
			designerSettingsClassName: "BPMSoft.MobileGridDesignerSettings"

		});
		return designerModule;

	});
