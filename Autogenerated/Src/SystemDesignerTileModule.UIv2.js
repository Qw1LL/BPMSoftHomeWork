define("SystemDesignerTileModule", ["SystemDesignerTileModuleResources", "BaseNestedModule"],
	function(resources) {

	/**
	 * @class BPMSoft.configuration.SystemDesignerTileViewConfig
	 * ##### ############ ############ ############# ######.
	 */
	Ext.define("BPMSoft.configuration.SystemDesignerTileViewConfig", {
		extend: "BPMSoft.BaseModel",
		alternateClassName: "BPMSoft.SystemDesignerTileViewConfig",

		/**
		 * ########## ############ ############# ###### ######.
		 * @protected
		 * @virtual
		 * @param {Object} config ###### ############.
		 * @param {String} config.style ##### ###########.
		 * @return {Object[]} ########## ############ ############# ###### ##########.
		 */
		generate: function(config) {
			var style = config.style || "";
			var fontStyle = config.fontStyle || "";
			var wrapClassName = Ext.String.format("{0}", style);
			var id = BPMSoft.Component.generateId();
			var result = {
				"name": id,
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": { wrapClassName: [wrapClassName, "system-designer-tile-module-wraper"] },
				"styles": {
					"width": "100%"
				},
				"items": [
					{
						"name": id + "-wrap",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"styles": {
							"width": "100%"
						},
						"classes": { wrapClassName: ["system-designer-tile-wrap"] },
						"items": [
							{
								"name": "system-designer-tile-caption-" + id,
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": { "bindTo": "caption" },
								"classes": { "labelClass": ["system-designer-tile-caption"] },
								"click": { "bindTo": "onClick"},
								"markerValue": { "bindTo": "caption" }
							},
							{
								"name": "system-designer-tile-hint-" + id,
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": { "bindTo": "hint" },
								"classes": { "labelClass": ["system-designer-tile-hint " + fontStyle] }
							}
						]
					}
				]
			};
			return result;
		}

	});

	/**
	 * @class BPMSoft.configuration.SystemDesignerTileViewModel
	 * ##### ###### ############# ######.
	 */
	Ext.define("BPMSoft.configuration.SystemDesignerTileViewModel", {
		extend: "BPMSoft.BaseModel",
		alternateClassName: "BPMSoft.SystemDesignerTileViewModel",
		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * ######## ####### ######.
		 * {Object}
		 */
		columns: {
			caption: {
				type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
				dataValueType: BPMSoft.DataValueType.Text,
				value: null
			},
			hint: {
				type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
				dataValueType: BPMSoft.DataValueType.Text,
				value: null
			}
		},

		/**
		 * @overridden
		 */
		onRender: Ext.emptyFn,

		/**
		 * ########## ####### ## #########.
		 * @virtual
		 */
		onClick: Ext.emptyFn,

		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * ######### ########## ########## ##########.
		 * @protected
		 * @virtual
		 * @param {Function} callback #######, ####### ##### ####### ## ##########
		 * @param {Object} scope ########, # ####### ##### ####### ####### callback
		 */
		prepareTile: function(callback, scope) {
			if (callback) {
				callback.call(scope || this);
			}
		},

		/**
		 * ############## ###### ########## ######## ## ####### ########.
		 * @protected
		 * @virtual
		 * @param {Object} resourcesObj ###### ########.
		 */
		initResourcesValues: function(resourcesObj) {
			var resourcesSuffix = "Resources";
			BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
					var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		},

		/**
		 * ############## ######### ######## ######.
		 * @protected
		 * @virtual
		 * @param {Function} callback #######, ####### ##### ####### ## ##########
		 * @param {Object} scope ########, # ####### ##### ####### ####### callback
		 */
		init: function(callback, scope) {
			var caption = this.get("Resources.Strings.Caption");
			var hint = this.get("Resources.Strings.Hint");
			if (caption) {
				this.set("caption", caption);
			}
			if (hint) {
				this.set("hint", hint);
			}
			if (callback) {
				callback.call(scope || this);
			}
		}

	});

	Ext.define("BPMSoft.configuration.SystemDesignerTileModule", {
		extend: "BPMSoft.BaseNestedModule",
		alternateClassName: "BPMSoft.SystemDesignerTileModule",

		Ext: null,
		sandbox: null,
		BPMSoft: null,
		showMask: true,

		/**
		 * ### ###### ###### ############# ### ######.
		 * @type {String}
		 */
		viewModelClassName: "BPMSoft.SystemDesignerTileViewModel",

		/**
		 * ### ##### ########## ############ ############# ######.
		 * @type {String}
		 */
		viewConfigClassName: "BPMSoft.SystemDesignerTileViewConfig",

		/**
		 * ### ##### ########## #############.
		 * @type {String}
		 */
		viewGeneratorClass: "BPMSoft.ViewGenerator",

		/**
		 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
		 * @overridden
		 */
		initViewConfig: function(callback, scope) {
			var generatorConfig = BPMSoft.deepClone(this.moduleConfig);
			generatorConfig.viewModelClass = this.viewModelClass;
			this.buildView(generatorConfig, function(view) {
				this.viewConfig = view[0];
				callback.call(scope);
			}, this);
		},

		/**
		 * @inheritDoc BPMSoft.configuration.BaseNestedModule#init
		 * @overridden
		 */
		init: function() {
			if (!this.viewModel) {
				this.initConfig();
				this.subscribeMessages();
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
		 * @overridden
		 */
		initViewModelClass: function(callback, scope) {
			if (this.moduleConfig.hasOwnProperty("requiredModule")) {
				var requiredModule = this.moduleConfig.requiredModule;
				this.sandbox.requireModuleDescriptors([ requiredModule], function() {
					BPMSoft.require([requiredModule, "css!" + requiredModule],
						function() {
							this.viewModelClass = Ext.ClassManager.get(this.viewModelClassName);
							callback.call(scope);
						}, this);
				}, this);
			} else {
				this.viewModelClass = Ext.ClassManager.get(this.viewModelClassName);
				callback.call(scope);
			}
		},

		/**
		 * @inheritDoc BPMSoft.configuration.BaseNestedModule#getViewModelConfig
		 * @overridden
		 */
		getViewModelConfig: function() {
			var config = this.callParent(arguments);
			config.values = this.moduleConfig;
			return config;
		},

		/**
		 * ####### ######### ###### BPMSoft.ViewGenerator.
		 * @protected
		 * @virtual
		 * @return {BPMSoft.ViewGenerator} ########## ###### BPMSoft.ViewGenerator.
		 */
		createViewGenerator: function() {
			return this.Ext.create(this.viewGeneratorClass);
		},

		/**
		 * ####### ############ ############# ########## ######.
		 * @protected
		 * @virtual
		 * param {Object} config ###### ############.
		 * param {Function} callback ####### ######### ######.
		 * param {BPMSoft.BaseModel} scope ######## ########## ####### ######### ######.
		 * @return {Object[]} ########## ############ ############# ########## ######.
		 */
		buildView: function(config, callback, scope) {
			var viewGenerator = this.createViewGenerator();
			var viewClass = this.Ext.create(this.viewConfigClassName);
			var schema = {
				viewConfig: [viewClass.generate(config)]
			};
			var viewConfig = Ext.apply({
				schema: schema
			}, config);
			viewGenerator.generate(viewConfig, callback, scope);
		},

		/**
		 * ############## ###### ############ ######.
		 * @protected
		 * @virtual
		 */
		initConfig: function() {
			var sandbox = this.sandbox;
			this.moduleConfig = sandbox.publish("GetSystemDesignerTileConfig", null, [sandbox.id]);
			this.viewModelClassName = this.moduleConfig.viewModelClassName || this.viewModelClassName;
			this.viewConfigClassName = this.moduleConfig.viewConfigClassName || this.viewConfigClassName;
		},

		/**
		 * ############# ## ######### ############# ######.
		 * @protected
		 * @virtual
		 */
		subscribeMessages: function() {
			var sandbox = this.sandbox;
			sandbox.subscribe("GenerateSystemDesignerTile", this.onGenerateTile, this, [sandbox.id]);
		},

		/**
		 * ##### ######### ######### ######### ##########.
		 * @protected
		 * @virtual
		 */
		onGenerateTile: function() {
			var viewModel = this.viewModel;
			this.initConfig();
			viewModel.loadFromColumnValues(this.moduleConfig);
			viewModel.prepareTile(function() {
				var view = this.view;
				if (view && !view.destroyed) {
					view.destroy();
				}
				this.initViewConfig(function() {
					var renderTo = Ext.get(viewModel.renderTo);
					if (renderTo) {
						this.render(renderTo);
					}
				}, this);
			}, this);
		}
	});

	return BPMSoft.SystemDesignerTileModule;

});
