﻿define("ModuleConfigEdit", ["BPMSoft", "LookupUtilities", "ModuleConfigEditResources"],
	function(BPMSoft, LookupUtilities, resources) {
		var localizableStrings = resources.localizableStrings;

		return {

			messages: {

				/**
				 * ######### ######### #########.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######### ######### ######## ######.
				 */
				"LookupInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######### ######## ###### ## ######.
				 */
				"ResultSelectedRows": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######### ######## ######### ######
				 */
				"PostModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######### ######### ######## ######.
				 */
				"GetModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######### ######## # ########### #########.
				 */
				"BackHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			mixins: {},
			attributes: {
				/**
				 * ####### ###### ### ###########.
				 */
				ModuleName: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isLookup: true,
					isRequired: true,
					referenceSchemaName: "VwSysSchemaInfo",
					lookupListConfig: {
						columns: [
						"Name",
						"UId",
						"Caption"
						],
						filters: [
							/**
							 * ######## ############## ####### ### ###### ## ############## ######## ############ # ####
							 * #####.
							 * @returns {BPMSoft.FilterGroup} ####### #######.
							 */
							function() {
								var filterGroup = Ext.create("BPMSoft.FilterGroup");
								filterGroup.add("ManagerNameFilter", BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "ManagerName", "ClientUnitSchemaManager"));
								filterGroup.add("SysWorkspaceIdFilter", BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "SysWorkspace",
									BPMSoft.SysValue.CURRENT_WORKSPACE.value));
								filterGroup.addItem(BPMSoft.createColumnIsNotNullFilter("Caption"));
							
								var self = this;
								this.getAngularModules(function(angularModules) {
									if (angularModules && angularModules.length > 0) {
										var angularModulesFilter = BPMSoft.createColumnInFilterWithParameters("UId", angularModules);
										angularModulesFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
										angularModulesFilter.Name = "angularModulesFilter";
										filterGroup.addItem(angularModulesFilter);
									}
								});
								return filterGroup;
							}
						]
					}
				},
				/**
				 * ####### ########## ######.
				 */
				ModuleParameters: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				/**
				 * @private
				 * @return {Object} config Module config.
				 */
				_getModuleConfig: function() {
					const config = this.sandbox.publish("GetModuleConfig", null, [this.getModuleId()]);
					config.parameters = config.parameters || "";
					config.configurationMessage = config.configurationMessage || "";
					return config;
				},

				/**
				 * @private
				 * @param {Object} config Module config.
				 * @param {String} config.parameters Parameters of the module.
				 * @param {String} config.configurationMessage Configuration message of the module.
				 */
				_setModuleParameters: function(config) {
					const moduleParameters = this._getModuleParameters(config);
					this.set("ModuleParameters", moduleParameters);
				},

				/**
				 * @private
				 * @param {Object} config Module config.
				 * @param {String} config.parameters Parameters of the module.
				 * @param {String} config.configurationMessage Configuration message of the module.
				 * @return {String} moduleParameters String representation of module parameters.
				 */
				_getModuleParameters: function(config) {
					const encodeConfig = {
						parameters: config.parameters,
						configurationMessage: config.configurationMessage
					};
					const moduleParameters = JSON.stringify(encodeConfig, null, "\t");
					return moduleParameters;
				},

				/**
				 * @private
				 * @param {Object} config Module config.
				 * @param {String} config.moduleName Name of the selected module.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope to execute callback function in.
				 */
				_initModuleName: function(config, callback, scope) {
					this._getModuleName(config, function(moduleName) {
						if (moduleName) {
							this.set("ModuleName", moduleName);
						}
						callback.call(scope);
					}, this);
				},

				/**
				 * @private
				 * @param {Object} config Module config.
				 * @param {String} config.moduleName Name of the selected module.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope to execute callback function in.
				 */
				_getModuleName: function(config, callback, scope) {
					let moduleName = null;
					if (config.moduleName) {
						const esq = this.getModuleNameESQ();
						esq.filters.add("NameFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Name", config.moduleName
						));
						esq.getEntityCollection(function(result) {
							if (result && result.success && !result.collection.isEmpty()) {
								const item = result.collection.getByIndex(0);
								if (item) {
									moduleName = item.values;
								}
							}
							callback.call(scope, moduleName);
						}, this);
					} else {
						callback.call(scope, moduleName);
					}
				},

				/**
				 * @private
				 */
				_changeHeaderCaption: function() {
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: localizableStrings.Header,
						dataViews: new BPMSoft.Collection(),
						moduleName: this.name
					});
				},

				/**
				 * ########## ############## ######.
				 * @protected
				 * @virtual
				 * @returns {string} ############# ######.
				 */
				getModuleId: function() {
					return this.sandbox.id;
				},

				getAngularModules: function(callback) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysSchema"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("UId");
					esq.filters.add("filter", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "[SysSchemaProperty:SysSchema:Id].Value", "AngularModule"));
					esq.getEntityCollection(function(result) {
						var angularModules = [];
						if (result.success) {
							result.collection.each(function(item) {
								angularModules.push(item.get("UId"));
							});
						}
						if (typeof callback === "function") {
							callback(angularModules);
						}
					});
				},

				/**
				 * ############## #### # ############ # ############# ######.
				 * @protected
				 * @virtual
				 */
				initializeValues: function(callback, scope) {
					const config = this._getModuleConfig();
					this._setModuleParameters(config);
					this._initModuleName(config, callback, scope);
				},

				/**
				 * ############## ######### ######## ######.
				 * @protected
				 * @virtual
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.initializeValues(callback, scope);
						this._changeHeaderCaption();
					}, this]);
				},

				/**
				 * ############# ############## ########## #####.
				 * @protected
				 * @virtual
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("ModuleParameters", this.validateModuleParameters);
				},

				/**
				 * ############### ######### ######### ###### # ###### ########## ######.
				 * @protected
				 * @virtual
				 * @param {String} strVal ######### ############# ########## ######.
				 * @returns {Object} ###### ##########.
				 */
				decodeParameters: function(strVal) {
					return BPMSoft.deserialize(strVal);
				},

				/**
				 * ######### ######### ########## ######.
				 * @protected
				 * @virtual
				 * @param {String} value ######### ############# ########## ######.
				 * @returns {Object} ######### #########.
				 */
				validateModuleParameters: function(value) {
					var result = {};
					try {
						this.decodeParameters(value);
					} catch (e) {
						result.invalidMessage = localizableStrings.ModuleParametersValidationMessage;
					}
					return result;
				},

				/**
				 * ######### ###### ### ######### ###### ######### #### ######.
				 * @protected
				 * @virtual
				 * @returns {BPMSoft.EntitySchemaQuery} ######.
				 */
				getModuleNameESQ: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "VwSysSchemaInfo"
					});
					esq.addColumn("Name", "Name");
					esq.addColumn("Caption", "Caption");
					esq.addColumn("Id", "value");
					esq.addColumn("Caption", "displayValue");
					esq.filters.add(this.getLookupQueryFilters("ModuleName"));
					return esq;
				},

				/**
				 * ######## ############## #######, ######### ############ #######.
				 * @protected
				 * @virtual
				 * @param {String} columnName ######## #######.
				 * @returns {BPMSoft.FilterGroup} ###### ############## ########.
				 */
				getLookupQueryFilters: function(columnName) {
					var filterGroup = Ext.create("BPMSoft.FilterGroup");
					var column = this.columns[columnName];
					var lookupListConfig = column.lookupListConfig;
					if (lookupListConfig) {
						var filterArray = lookupListConfig.filters;
						BPMSoft.each(filterArray, function(item) {
							var filter;
							if (Ext.isObject(item) && Ext.isFunction(item.method)) {
								filter = item.method.call(this, item.argument);
							}
							if (Ext.isFunction(item)) {
								filter = item.call(this);
							}
							if (Ext.isEmpty(filter)) {
								throw new BPMSoft.InvalidFormatException({
									message: Ext.String.format(
										this.get("Resources.Strings.ColumnFilterInvalidFormatException"),
										columnName)
								});
							}
							filterGroup.addItem(filter);
						}, this);
						if (lookupListConfig.filter) {
							var filterItem = lookupListConfig.filter.call(this);
							if (filterItem) {
								filterGroup.addItem(filterItem);
							}
						}
					}
					return filterGroup;
				},

				/**
				 * ######### ###### ######### # ###### #######.
				 * @protected
				 * @virtual
				 * @param {String} filterValue ######### ######.
				 * @param {BPMSoft.Collection} list ######### ######### ########.
				 */
				prepareModuleList: function(filterValue, list) {
					list.clear();
					var items = {};
				
					// Функция для получения и фильтрации списка модулей
					var getFilteredModules = function(angularModules) {
						var esq = this.getModuleNameESQ();
						var comparisonType = this.getLookupComparisonType();
			
						esq.filters.add("ManagerNameFilter", BPMSoft.createColumnFilterWithParameter(
							comparisonType, "Caption", filterValue));
				
						// Если есть идентификаторы модулей Angular, исключаем их
						if (angularModules && angularModules.length > 0) {
							var angularModulesFilter = BPMSoft.createColumnInFilterWithParameters("UId", angularModules);
							angularModulesFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
							esq.filters.add("angularModulesFilter", angularModulesFilter);
						}
				
						esq.getEntityCollection(function(response) {
							if (response && response.success) {
								var collection = response.collection.getItems();
								BPMSoft.each(collection, function(item) {
									var itemId = item.get("value");
									items[itemId] = item.values;
								}, this);
								list.loadAll(items);
							}
						}, this);
					};
				
					// Получаем идентификаторы модулей Angular и фильтруем список
					this.getAngularModules(function(angularModules) {
						getFilteredModules.call(this, angularModules);
					}.bind(this));
				},
				

				/**
				 * ######### ######### #### ###### ## ###########.
				 * @protected
				 * @virtual
				 * @param {Object} args #########.
				 * @param {String} tag ### ######## ##########.
				 */
				loadVocabulary: function(args, tag) {
					var config = {
						entitySchemaName: args.schemaName ||
							this.columns[tag].referenceSchemaName,
						multiSelect: false,
						columnName: tag,
						columnValue: this.get(tag),
						searchValue: args.searchValue,
						filters: this.getLookupQueryFilters.call(this, tag)
					};
					var lookupListConfig = this.columns[tag].lookupListConfig;
					var excludedProperty = ["filters", "filter"];
					if (lookupListConfig) {
						for (var property in lookupListConfig) {
							if (excludedProperty.indexOf(property) === -1) {
								config[property] = lookupListConfig[property];
							}
						}
					}
					LookupUtilities.Open(this.sandbox, config, this.onLookupResult, this, null, false, false);
				},

				/**
				 * ############# ######### # ########### ######## # ############### #### ######.
				 * @protected
				 * @virtual
				 * @param {Object} args #########.
				 */
				onLookupResult: function(args) {
					var columnName = args.columnName;
					var selectedRows = args.selectedRows;
					if (!selectedRows.isEmpty()) {
						this.set(columnName, selectedRows.getByIndex(0));
					}
				},

				/**
				 * ########## ############## ###### ############ ######
				 * @protected
				 * @virtual
				 * @returns {Object} ###### ############ ######
				 */
				getResult: function() {
					var moduleName = this.get("ModuleName");
					var strModuleParameters = this.get("ModuleParameters");
					var moduleParameters = this.decodeParameters(strModuleParameters);
					return this.Ext.apply({
						moduleName: moduleName.Name,
						caption: moduleName.Caption
					}, moduleParameters);
				},

				/**
				 * ######### ####### # ########## ########.
				 * @protected
				 * @virtual
				 */
				goBack: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * ######### ############ ######
				 * @protected
				 * @virtual
				 */
				save: function() {
					if (this.validate()) {
						var result = this.getResult();
						this.sandbox.publish("PostModuleConfig", result, [this.getModuleId()]);
						this.goBack();
					}
				}
			},
			rules: {},
			diff: [
				{
					"operation": "insert",
					"name": "ModuleSelectingContainer",
					"values": {
						"id": "ModuleSelectingContainer",
						"selectors": {wrapEl: "#ModuleSelectingContainer"},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [
						]
					}
				},
				{
					"operation": "insert",
					"name": "HeaderContainer",
					"parentName": "ModuleSelectingContainer",
					"propertyName": "items",
					"values": {
						"id": "HeaderContainer",
						"selectors": {wrapEl: "#HeaderContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {column: 0, row: 0, colSpan: 24},
						"items": [
						]
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "SaveButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": localizableStrings.SaveButtonCaption,
						"click": {bindTo: "save"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"layout": {column: 0, row: 0, colSpan: 2},
						"classes": {textClass: "actions-button-margin-right"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "CancelButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": localizableStrings.CancelButtonCaption,
						"click": {bindTo: "goBack"},
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"layout": {column: 4, row: 0, colSpan: 2}
					}
				},
				{
					"operation": "insert",
					"name": "ModuleSettingsContainer",
					"parentName": "ModuleSelectingContainer",
					"propertyName": "items",
					"values": {
						"id": "ModuleSettingsContainer",
						"selectors": {wrapEl: "#ModuleSettingsContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {column: 0, row: 1, colSpan: 11},
						"items": [
						]
					}
				},
				{
					"operation": "insert",
					"name": "moduleName",
					"parentName": "ModuleSettingsContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "ModuleName",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true,
							"caption": localizableStrings.ModuleNameEditCaption
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareModuleList"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "moduleParameters",
					"parentName": "ModuleSettingsContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "ModuleParameters",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": true,
							"caption": localizableStrings.ModuleParametersEditCaption
						}
					}
				}
			]
		};
	});

