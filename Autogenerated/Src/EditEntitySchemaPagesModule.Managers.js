define("EditEntitySchemaPagesModule", ["EditEntitySchemaPagesModuleResources", "ContainerList",
		"ContainerListGenerator", "SysModuleEntityManager", "BaseNestedModule", "SysModuleEditManager"],
	function(resources) {

		//######### ## ###### ######### ####### #####.




		/**
		 * @class BPMSoft.configuration.EntitySchemaPageModel
		 *
		 */
		Ext.define("BPMSoft.configuration.EntitySchemaPageModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.EntitySchemaPageModel",

			sandbox: null,

			Ext: null,

			/**
			 *
			 * @type {Object}
			 */
			managerItem: null,

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
			 * ############## ############ ######## ### ########.
			 * @protected
			 * @virtual
			 */
			getCaption: function() {
				var pageCaption = this.managerItem.pageCaption;
				return pageCaption || this.get("Resources.Strings.DefaultItemLabel");
			},

			init: function(callback, scope) {
				this.loadSchemaName(callback, scope);
			},

			getSchemaFilters: function() {
				var filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value
				));
				filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"ManagerName",
					"ClientUnitSchemaManager"
				));
				var cardSchemaUId = this.managerItem.cardSchemaUId;
				filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"UId",
					cardSchemaUId
				));
				return filters;
			},

			validate: function() {
				return true;
			},

			save: function() {

			},

			loadSchemaName: function(callback, scope) {
				if (!this.managerItem || !this.managerItem.cardSchemaUId) {
					callback.call(scope);
					return;
				}
				var query = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					"rootSchemaName": "VwSysSchemaInfo"
				});
				query.addColumn("UId");
				query.addColumn("Name");
				query.addColumn("Caption");
				query.filters.addItem(this.getSchemaFilters());
				query.getEntityCollection(function(response) {
					if (response.success && !response.collection.isEmpty()) {
						var item = response.collection.getByIndex(0);
						var values = item.values;
						Ext.apply(values, {
							value: values.UId,
							displayValue: values.Caption
						});
						this.set("ClientUnitSchema", values);
					}
					callback.call(scope);
				}, this);
			},

			/**
			 * ####### ######, ############## ### ########.
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				var managerItem = this.managerItem;
				this.initResourcesValues(resources);
				if (managerItem) {
					this.set("id", managerItem.getId());
				}

			}
		});

		/**
		 * @class BPMSoft.configuration.EditEntitySchemaPagesModuleViewModel
		 * ##### ###### ############# ###### #######.
		 */
		Ext.define("BPMSoft.configuration.EditEntitySchemaPagesModuleViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.EditEntitySchemaPagesModuleViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			columns: {
				"ClientUnitSchema": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isLookup: true,
					referenceSchema: {
						name: "VwSysSchemaInfo",
						primaryColumnName: "Name",
						primaryDisplayColumnName: "Caption"
					},
					referenceSchemaName: "VwSysSchemaInfo"
				}
			},

			/**
			 * ##### ####### ### ###### ############# ######.
			 * @type {BPMSoft.BaseEntitySchema}
			 */
			entitySchema: Ext.create("BPMSoft.BaseEntitySchema", {
				columns: {},
				primaryColumnName: "Id"
			}),

			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
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

			loadEntityPages: function(sysEntitySchemaUId, callback, scope) {
				BPMSoft.chain(
					function(next) {
						BPMSoft.SysModuleEntityManager.findItemsByEntitySchemaUId(sysEntitySchemaUId, next, scope);
					},
					function(next, sysModuleEntityManagerItems) {
						var sysModuleEntityManagerItem = sysModuleEntityManagerItems.getByIndex(0);
						if (sysModuleEntityManagerItem) {
							sysModuleEntityManagerItem.getSysModuleEditManagerItems(next, this);
						} else {
							next();
						}
					},
					function(next, sysModuleEditManagerItems) {
						if (callback) {
							callback.call(scope || this, sysModuleEditManagerItems);
						}
					},
					this
				);
			},

			initPagesCollection: function(sysModuleEditManagerItems, callback, scope) {
				var pageCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.set("PagesCollection", pageCollection);

				if (sysModuleEditManagerItems && !sysModuleEditManagerItems.isEmpty()) {
					sysModuleEditManagerItems.each(function(managerItem) {
						var newItem = this.Ext.create("BPMSoft.EntitySchemaPageModel", {
							managerItem: managerItem,
							sandbox: this.sandbox,
							Ext: this.Ext
						});
						newItem.init(BPMSoft.emptyFn, this);
						pageCollection.add(managerItem.id, newItem);
					}, this);
					callback.call(callback, scope);
				} else {
					BPMSoft.SysModuleEditManager.createItem({
						id: BPMSoft.generateGUID()
					}, function(managerItem) {
						var newItem = this.Ext.create("BPMSoft.EntitySchemaPageModel", {
							managerItem: managerItem,
							sandbox: this.sandbox,
							Ext: this.Ext
						});
						newItem.init(BPMSoft.emptyFn, this);
						pageCollection.add(managerItem.id, newItem);
						callback.call(callback, scope);
					}, this);
				}
			},

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			init: function(callback, scope) {
				//var sysEntitySchemaUId = "C82AB6F0-0E36-4376-9AB3-C583D714B7B6";
				var sysEntitySchemaUId = "c449d832-a4cc-4b01-b9d5-8a12c42a9f89";

				BPMSoft.chain(function(next) {
						BPMSoft.SysModuleEntityManager.initialize(null, next, this);
					},
					function(next) {
						this.loadEntityPages(sysEntitySchemaUId, next, this);
					},
					function(next, sysModuleEditManagerItems) {
						this.initPagesCollection(sysModuleEditManagerItems, next, this);
					},
					function() {
						if (callback) {
							callback.call(scope || this, this);
						}
					},
					this
				);
			},
			onRender: function() {

			}

		});

		/**
		 * @class BPMSoft.configuration.EditEntitySchemaPagesModuleViewConfig
		 * ##### ############ ############ ############# ###### #######.
		 */
		Ext.define("BPMSoft.configuration.EditEntitySchemaPagesModuleViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.EditEntitySchemaPagesModuleViewConfig",

			diff: [
				{
					"operation": "insert",
					"name": "PagesCollection",
					"values": {
						"idProperty": "id",
						"collection": { "bindTo": "PagesCollection" },
						"generator": "ContainerListGenerator.generatePartial",
						"itemType": BPMSoft.ViewItemType.GRID,
						"itemConfig": [{
							"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
							"name": "ClientUnitSchema",
							"labelConfig": {
								"caption": { "bindTo": "getCaption" }
							}
						}]
					}
				}
			],

			/**
			 * ########## ############ ############# #######.
			 * @returns {Object[]} ########## ############ ############# #######.
			 */
			generate: function() {
				var viewConfig = [];
				return BPMSoft.JsonApplier.applyDiff(viewConfig, this.diff);
			}

		});

		/**
		 * @class BPMSoft.configuration.ChartModule
		 * ##### ###### #######.
		 */
		Ext.define("BPMSoft.configuration.EditEntitySchemaPagesModule", {
			alternateClassName: "BPMSoft.EditEntitySchemaPagesModule",
			extend: "BPMSoft.BaseNestedModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: true,

			/**
			 * ###### ############ ######.
			 * @type {Object}
			 */
			moduleConfig: null,

			/**
			 * ### ###### ###### ############# ### ########## ######.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.EditEntitySchemaPagesModuleViewModel",

			/**
			 * ### ##### ########## ############ ############# ########## ######.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.EditEntitySchemaPagesModuleViewConfig",

			/**
			 * ### ##### ########## #############.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * ####### ######### ###### BPMSoft.ViewGenerator.
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
					viewConfig: viewClass.generate()
				};
				var viewConfig = Ext.apply({
					schema: schema
				}, config);
				viewConfig.schemaName = "";
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = {};
				generatorConfig.viewModelClass = this.viewModelClass;
				this.buildView(generatorConfig, function(view) {
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				this.viewModelClass = this.Ext.ClassManager.get(this.viewModelClassName);
				callback.call(scope);
			}

		});

		return BPMSoft.EditEntitySchemaPagesModule;
	});
