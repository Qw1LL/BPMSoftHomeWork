/**
 * Parent: BaseDataModificationUserTaskPropertiesPage
 */
define("SearchDuplicatesUserTaskPropertiesPage", [
		"BPMSoft", 
		"ProcessSchemaUserTaskUtilities", 
		"ProcessUserTaskConstants",
		"EntityColumnMappingMixin", 
		"DuplicatesRule",
		"css!SearchDuplicatesUserTaskPropertiesPageCSS"],
	function(BPMSoft, UserTaskUtilities, processUserTaskConstants) {
		return {
			mixins: {
				entityColumnMappingMixin: "BPMSoft.EntityColumnMappingMixin"
			},
			attributes: {
				/**
				 * Collection viewModel's controls for duplicate rule value element.
				 */
				"DuplicateRulesCollection": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Selected entity record.
				 * @protected
				 * @type {{value: String, displayValue: String}}
				 */
				"EntityId": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Rule select modes.
				 * @protected
				 * @type {Object}
				 */
				"RuleSelectModeEnum": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						ReadAllRules: 0,
						ReadOnlySelectedRules: 1
					}
				},

				/**
				 * Rule select mode.
				 * @protected
				 * @type {Object}
				 */
				"RuleSelectMode": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Indicates if the rule select mode is visible.
				 * @protected
				 * @type {Boolean}
				 */
				"IsRuleSelectModeVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},

				/**
				 * Indicates if the ESDeduplication feature is enabled.
				 * @protected
				 * @type {Boolean}
				 */
				"ESDeduplicationFeatureEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: BPMSoft.Features.getIsEnabled("ESDeduplication")
				}

			},
			rules: {},
			methods: {

				/**
				 * @overriden
				 */
				init: function() {
					const parentMethod = this.getParentMethod(this, arguments);
					this.initDuplicateRulesCollection();
					this.BPMSoft.chain(
						this.loadAllowedDuplicatesSchemas,
						function() {
							parentMethod.call();
						},
						this
					);
				},

				/**
				 * Inits DuplicateRulesCollection.
				 * @protected
				 */
				initDuplicateRulesCollection: function() {
					const controlList = Ext.create("BPMSoft.ObjectCollection");
					this.set("DuplicateRulesCollection", controlList);
				},

				/**
				 * Loads allowed duplicates schemas.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				loadAllowedDuplicatesSchemas: function(callback, scope) {
					const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "DuplicatesRule"
					});
					esq.addColumn("Object");
					esq.isDistinct = true;
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"IsActive", true));
					esq.getEntityCollection(function(response) {
						if (response.success) {
							this.set("AllowedDuplicatesSearchSchemas", response.collection);
						}
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.EntitySchemaSelectMixin#onEntitySchemaSelectChanged
				 * @overridden
				 */
				onEntitySchemaSelectChanged: function(model, newReferenceSchema) {
					this.callParent(arguments);
					this.initDuplicatesRulePrimaryColumnUId();					
					var element = this.get("ProcessElement");
					if (element) {
						this.initEntityId(element);
					}
				},

				/**
				 * Initialization EntityId parameter value.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initEntityId: function(element) {
					var parameterName = this.getEntityIdParameterName();
					var parameter = element.findParameterByName(parameterName);
					this.initProperty(parameter);
					var recordId = this.get(parameterName);
					recordId.referenceSchemaUId = this.get("ReferenceSchemaUId");
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#setValidationConfig.
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("EntityId", UserTaskUtilities.validateMappingValue);
				},

				/**
				 * @inheritDoc BPMSoft.BaseDataModificationUserTaskPropertiesPage#customValidator
				 * @overridden
				 */
				customValidator: function() {
					const validationInfo = {
						isValid: true,
						invalidMessage: ""
					};
					const entityId = this.getEntityIdParameterName();
					if (this.Ext.isEmpty(this.get(entityId))) {
						validationInfo.isValid = false;
						validationInfo.invalidMessage = this.get("Resources.Strings.EntityIdSchemaEmpty");
					}
					return validationInfo;
				},

				/**
				 * @inheritDoc BPMSoft.EntityColumnMappingMixin#clearSelection.
				 * @overridden
				 */
				clearSelection: function(id) {
					var entityColumns = this.get("EntityColumns");
					if (!entityColumns.contains(id)) {
						return;
					}
					var entityColumn = entityColumns.get(id);
					entityColumn.selected = false;
				},

				/**
				 * Returns DuplicatesRule schema UId.
				 * @protected
				 * @return {Guid} Schema UId
				 */
				getDuplicateRuleSchemaUId: function() {
					const duplicatesRuleSchema = this.getDuplicatesRuleSchema();
					return duplicatesRuleSchema && duplicatesRuleSchema.uId || null;
				},

				/**
				 * Gets DuplicatesRule schema.
				 * @protected
				 * @return {BPMSoft.manager.BaseProcessSchemaElement} Process schema.
				 */
				getDuplicatesRuleSchema: function() {
					return BPMSoft.EntitySchemaManager.findItemByName("DuplicatesRule");
				},

				/**
				 * Loads DuplicatesRule instance and inits DuplicatesRulePrimaryColumnUId value.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 * @protected
				 */
				initDuplicatesRulePrimaryColumnUId: function(callback, scope) {
					var getRuleSchemaWithCallback = function(callback, scope) {
						const duplicatesRuleSchema = scope.getDuplicatesRuleSchema();
						if (duplicatesRuleSchema && duplicatesRuleSchema.uId) {
							duplicatesRuleSchema.getInstance(function (item) {
								scope.set("DuplicatesRulePrimaryColumnUId", item.primaryColumnUId);
								scope.Ext.callback(callback, scope);
							}, scope)
						}
					}
					if (BPMSoft.EntitySchemaManager.initialized) {
						getRuleSchemaWithCallback(callback, scope || this);
					} else {
						BPMSoft.EntitySchemaManager.initialize(function() {
							getRuleSchemaWithCallback(callback, scope);
						}, this);
					}					
				},

				/**
				 * Returns DuplicatesRule element parameter name.
				 * @protected
				 * @return {String} Parameter name
				 */
				getRulesSchemaParameterName: function() {
					return "Rules";
				},

				/**
				 * Returns EntityId parameter name.
				 * @protected
				 * @return {String} Parameter name
				 */
				getEntityIdParameterName: function() {
					return "EntityId";
				},

				/**
				 * Returns filter for email template mapping window.
				 * @protected
				 * @return {BPMSoft.FilterGroup|null}
				 */
				getDuplicateFilter: function() {
					var duplicatesSchemaUId = this.get("EntitySchemaSelect");
					var items = this.parentCollection.getItems();
					var excludedRules = [];
					for (var item in items) {
						var excludedItem = this.getRuleId(items[item].$Value, items[item].$Value.referenceSchemaUId);
						excludedRules.push(excludedItem);
					}
					var filters = null;
					if (duplicatesSchemaUId && duplicatesSchemaUId.value) {
						filters = Ext.create("BPMSoft.FilterGroup");
						filters.addItem(BPMSoft.createColumnFilterWithParameter("Object.Id", duplicatesSchemaUId.value));
						filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"IsActive", true));
						if (excludedRules.length > 0) {
							var existsFilter = BPMSoft.createColumnInFilterWithParameters("Id",
								excludedRules);
							existsFilter.Name = "existsFilter";
							existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
							filters.add(existsFilter);
						}
					}
					return filters;
				},

				/**
				 * Returns Id of selected duplicates rule.
				 * @protected
				 * @param {object} lookupValue Selected lookup value.
				 * @return {string}
				 */
				getRuleId: function(lookupValue, schemaUId) {
					if (!lookupValue || !lookupValue.value) {
						return BPMSoft.GUID_EMPTY;
					}
					const value = lookupValue.value;
					const startPattern = "[#Lookup." + schemaUId + ".";
					const endPattern = "#]";
					const startPatternLength = startPattern.length;
					const startIndex = value.indexOf(startPattern) + startPatternLength;
					if (value.indexOf(startPattern) < 0) {
						return BPMSoft.GUID_EMPTY;
					}
					return value.substr(startIndex, value.indexOf(endPattern) - startPatternLength);
				},

				/**
				 * Returns filter for email template mapping window.
				 * @protected
				 * @param {BPMSoft.EntitySchemaColumn} column rule column value.
				 * @param {Object} config Mapping configuration.
				 * @param {Guid} itemId collection record id.
				 * @param {int} markerIndex element marker value.
				 * @return {BPMSoft.BaseViewModel}
				 */
				createRuleItemViewModel: function(column, config, itemId, markerIndex) {
					column.caption = this.get("Resources.Strings.RuleCaption");
					column.schemaColumn.dataValueType = this.BPMSoft.DataValueType.LOOKUP;
					column.schemaColumn.referenceSchemaUId = this.getDuplicateRuleSchemaUId();
					column.id = itemId;
					var viewModel = this.getEntityColumnMappingViewModel(config);
					viewModel.$MarkerValue = "Rule-" + markerIndex;
					viewModel.isDuplicateRule = true;
					viewModel.columns.Value.mappingWindowConfig = {
						filterMethod: "getDuplicateRulesFilter"
					};
					viewModel.values.Value.isLookupEnabled = false;
					viewModel.getDuplicateRulesFilter = this.getDuplicateFilter;
					viewModel.getRuleId = this.getRuleId;
					viewModel.set("EntitySchemaSelect", this.get("EntitySchemaSelect"));
					return viewModel;
				},

				/**
				 * Adds duplicate rule value to parameter
				 * @protected
				 */
				onAddDuplicateRule: function() {
					var primaryColumnUId = this.get("DuplicatesRulePrimaryColumnUId");
					var entityColumnsOld = Ext.create("BPMSoft.Collection");
					entityColumnsOld.loadAll(this.get("EntityColumns"));
					var controlList = this.get("DuplicateRulesCollection");
					if (!controlList) {
						controlList = Ext.create("BPMSoft.ObjectCollection");
						this.set("DuplicateRulesCollection", controlList);
					}
					this.queryMappingEntitySchemaColumns(this.getDuplicateRuleSchemaUId(), function(entityColumns) {
						entityColumns.each(function(column) {
							var id = column.id;
							var itemId = this.BPMSoft.generateGUID();
							var selected = this.Ext.Array.contains([primaryColumnUId], id);
							if (selected && !controlList.contains(itemId)) {
								var config = {column: column};
								var viewModel = this.createRuleItemViewModel(column, config, itemId, controlList.getCount());
								controlList.add(itemId, viewModel);
							}
							column.selected = selected;
						}, this);
						this.set("EntityColumns", entityColumnsOld);
					}, this);
				},

				/**
				 * @inheritDoc EntityColumnMappingMixin#getEntityColumnMappingsControlViewConfig
				 * @overridden
				 */
				getEntityColumnMappingsControlViewConfig: function(itemConfig, item) {
					this.set("EntityColumnMappingsViewConfig", null);
					this.mixins.entityColumnMappingMixin.getEntityColumnMappingsControlViewConfig.apply(this, [itemConfig]);
					if (item.isDuplicateRule) {
						return;
					}
					if (itemConfig && itemConfig.config) {
						var entityColumnContainer = itemConfig.config.items.find(function (item) {
							if (item.id == "EntityColumnContainer") {
								return item;
							}
						}, this);
						if (entityColumnContainer && entityColumnContainer.items) {
							var value = entityColumnContainer.items.find(function (item) {
								if (item.id == "Value") {
									return item;
								}
							}, this);
							if (value) {
								value.tag = {
									attributeName: "SourceColumnItem",
									typeMappingMenu: "SourceColumnItem"
								};
							}
						}
					}
				},

				//region Methods: Private

				/**
				 * Saves schema parameter by its name.
				 * @private
				 * @param {String} parameterName parameter name.
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveSchemaParameterByName: function(parameterName, element) {
					this.saveReferenceSchemaUId(element, parameterName, parameterName);
				},

				/**
				 * Saves element parameter.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {string} parameterName UserTask parameter name.
				 */
				saveParameterValue: function (element, parameterName) {
					var value = this.get(parameterName);
					if (!this.BPMSoft.isEmpty(value)) {
						var parameter = element.findParameterByName(parameterName);
						parameter.setMappingValue(value);
					}
				},

				/**
				 * Saves the entity schema identifier.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveEntitySchema: function(element) {
					var entitySchemaParameterName = this.getReferenceSchemaUIdParameterName();
					var entitySchemaAttributeName = this.getEntitySchemaAttributeName();
					this.saveReferenceSchemaUId(element, entitySchemaParameterName, entitySchemaAttributeName);
				},

				/**
				 * Initializes element parameter by its name.
				 * @private
				 * @param {String} parameterName parameter name.
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Function} callback Callback function.
				 */
				initParameterByName: function(parameterName, element, callback) {
					var parameter = element.getParameterByName(parameterName);
					var metaDataCollectionValue = BPMSoft.decode(parameter.sourceValue.value);
					if (!this.Ext.isEmpty(metaDataCollectionValue)) {
						this.set(parameterName, metaDataCollectionValue);
					}
					this.Ext.callback(callback, this);
				},

				/**
				 * Initializes collection of duplicete rules.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Function} callback Callback function.
				 * @param {scope} scope
				 */
				_loadDuplicateRulesCollection: function(element, callback, scope) {
					var controlList = Ext.create("BPMSoft.ObjectCollection");
					var parameter = element.getParameterByName(this.getRulesSchemaParameterName());
					var metaDataCollectionValue = parameter.getValue();
					if (metaDataCollectionValue) {
						this.queryMappingEntitySchemaColumns(this.getDuplicateRuleSchemaUId(), function(entityColumns) {
							var recordColumnValueList = BPMSoft.decode(metaDataCollectionValue).$values;
							recordColumnValueList.forEach(function (item) {
								var id = item.ItemId.value;
								var primaryColumnUId = this.get("DuplicatesRulePrimaryColumnUId");
								var column = entityColumns.find(primaryColumnUId);
								if (!column) {
									return;
								}
								var config = {
									column: column,
									columnMapping: item
								};
								var viewModel = this.createRuleItemViewModel(column, config, id, controlList.getCount());
								controlList.add(id, viewModel);
								column.selected = true;
							}, this);
							this.set("DuplicateRulesCollection", controlList);
							controlList.eachAsync(function(viewModel, next) {
								viewModel.init(next, this);
							}, callback, scope);
						}, this)
					} else {
						this.Ext.callback(callback, scope);
					}
				},
				/**
				 * Validate EntitySchemaSelect value by allowed entity list
				 */
				validateEntitySchemaSelect: function() {
					var schemaCollection = this.get("AllowedDuplicatesSearchSchemas");
					var entitySchemaSelect = this.get("EntitySchemaSelect");
					if (schemaCollection && entitySchemaSelect && entitySchemaSelect.value) {						
						var foundItem = schemaCollection.getItems().find(function (value) {
							return value.$Object.value === entitySchemaSelect.value;
						});
						if (!foundItem) {
							this.set("ReferenceSchemaUId", foundItem);
							this.set("EntitySchemaSelect", foundItem);
						}
					}
				},

				/**
				 * Updates duplicates rules collection reference schema uid.
				 * @private
				 * @param {String} schemaUId New reference schema uid.
				 */
				updateRulesCollectionReferenceSchema: function(schemaUId) {
					var controlList = this.get("DuplicateRulesCollection");
					if (!controlList) {
						return;
					}
					controlList.each(function(control) {
						control.set("EntitySchemaSelect", schemaUId);
					}, this);
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritDoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {					
					this.callParent([element, function() {
						this.BPMSoft.chain(
							function(next) {
								this.initDuplicatesRulePrimaryColumnUId(next, this);
							},
							function(next) {								
								this._loadDuplicateRulesCollection(element, next, this);
								this.validateEntitySchemaSelect();
							},
							function () {
								this.initEntityId(element);
								this.initRuleSelectMode(element);
								this.onRuleSelectModeChanged();
								this.set("TypeCaption", this.get("Resources.Strings.TypeCaption"));
								this.initEntityColumnMappingMixin(element, callback, scope);
							}, this);
					}, this]);
				},

				/**
				 * @inheritDoc BaseProcessSchemaElementPropertiesPage#saveParameters
				 * @overridden
				 */
				saveParameters: function(element) {
					this.callParent(arguments);
					this.saveDuplicateRuleValues(element);
				},

				/**
				 * Saves element Duplicate Rules property.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * */
				saveDuplicateRuleValues: function(element) {
					var parameter = element.getParameterByName(this.getRulesSchemaParameterName());
					var entitySchemaUId = this.getDuplicateRuleSchemaUId();
					if (!entitySchemaUId) {
						return [];
					}
					var controlList = this.get("DuplicateRulesCollection");
					if (!controlList  || !this.$IsRuleSelectModeVisible) {
						controlList = Ext.create("BPMSoft.ObjectCollection");
					}
					var serverObject = {
						$type: processUserTaskConstants.SERVER_GENERIC_LIST_TYPE,
						$values: []
					};
					controlList.each(function(control) {
						var mappingValue = control.get("Value");
						if (!mappingValue) {
							return;
						}
						var dataValueTypeUId = mappingValue.dataValueTypeUId;
						var source = mappingValue.source;
						var value = this.getLocalizableParameterValues(mappingValue.value, source, dataValueTypeUId);
						var displayValue = this.getLocalizableParameterValues(mappingValue.displayValue, source,
							dataValueTypeUId);
						if (!this.Ext.isEmpty(value.value)) {
							var itemValue = {
								"ItemUId": control.get("LocalizableParameterValueId"),
								"columnMetaPath": {
									"value": this.get("DuplicatesRulePrimaryColumnUId")
								},
								"ItemId": {
									"value": control.get("Id")
								},
								"schemaUId": {
									"value": entitySchemaUId
								},
								"value": value,
								"displayValue": displayValue,
								"parameterValue": {
									"value": this.getEntityColumnMappingsParameterValue(mappingValue, dataValueTypeUId)
								},
								"RuleId": this.getRuleId(value, this.getDuplicateRuleSchemaUId())
							};
							serverObject.$values.push(itemValue);
						}
					}, this);

					var stringValue = BPMSoft.encode(serverObject);
					var parameterValue = parameter.getMappingValue();
					parameterValue.value = stringValue;
					parameterValue.displayValue = stringValue;
					parameterValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
					parameter.setMappingValue(parameterValue);
				},

				/**
				 * @inheritDoc BaseProcessSchemaElementPropertiesPage#saveParameters
				 * @overridden
				 */
				saveReferenceSchemas: function(element) {
					this.callParent(arguments);
					this.saveParameterValue(element, this.getEntityIdParameterName());
				},

				/**
				 * @inheritDoc BaseDataModificationUserTaskPropertiesPage#getReferenceSchemaUIdParameterName
				 * @overridden
				 */
				getReferenceSchemaUIdParameterName: function() {
					return "EntitySchemaId";
				},

				/**
				 * @inheritDoc BaseDataModificationUserTaskPropertiesPage#getFilterReferenceSchemaParameterName
				 * @overridden
				 */
				getSearchReferenceSchemaParameterName: function() {
					return "EntitySchemaId";
				},

				/**
				 * @inheritDoc BaseDataModificationUserTaskPropertiesPage#onUpdatedEntitySchema
				 * @overridden
				 */
				onUpdatedEntitySchema: function() {
					this.callParent(arguments);
					var controlList = this.get("DuplicateRulesCollection");
					controlList.clear();
					const ruleSelectModeEnum = this.get("RuleSelectModeEnum");
					const ruleSelectModes = this.getRuleSelectModes();
					this.set("RuleSelectMode", ruleSelectModes[ruleSelectModeEnum.ReadAllRules]);
					var element = this.get("ProcessElement");
					this.reInitEntityColumnMapping(element, this.Ext.emptyFn);
				},

				/**
				 * @inheritDoc BaseDataModificationUserTaskPropertiesPage#initFilterModuleMixin
				 * @overridden
				 */
				initFilterModuleMixin: function(filterconfig, callback, scope) {
					this.initEntitySchemaSelect(function() {
						this.setValidationInfo("EntitySchemaSelect", true, null)
						this.setValidationInfo("EntitySchemaId", true, null);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @inheritDoc BaseDataModificationUserTaskPropertiesPage#updateFiltersOnEntitySchemaSelectChanged
				 * @overridden
				 */
				updateFiltersOnEntitySchemaSelectChanged: Ext.emptyFn,

				/**
				 * @inheritDoc BaseDataModificationUserTaskPropertiesPage#getIsFilterUnitVisible
				 * @overridden
				 */
				getIsFilterUnitVisible: function() {
					return false;
				},

				/**
				 * @inheritDoc EntityColumnMappingMixin#getEntityColumnMappingSchemaUId
				 * @overridden
				 */
				getEntityColumnMappingSchemaUId: function() {
					return this.getEntitySchemaUId();
				},

				/**
				 * @inheritDoc EntityColumnMappingMixin#initEntityColumnMappings
				 * @overridden
				 */
				initEntityColumnMappings: function(element, entityColumns, callback) {
					callback.call(this, entityColumns);
				},

				/**
				 * @inheritDoc BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.destroyEntityColumnMappings();
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc EntitySchemaSelectMixin#prepareEntityList
				 * @overridden
				 */
				prepareEntityList: function(filter, list, columnName) {
					if (list === null) {
						return;
					}
					list.clear();
					this.getReferenceSchemaList(function(entitySchemaList) {
						if (columnName === "EntitySchemaSelect") {
							var allowedSchemaCollection = this.get("AllowedDuplicatesSearchSchemas");
							for (var item in entitySchemaList) {
								var found = allowedSchemaCollection.getItems().find(function (value) {
									return value.$Object.value === item;
								});
								if (!found) {
									delete entitySchemaList[item];
								}
							}
						}
						list.loadAll(entitySchemaList);
					}, this);
				},

				/**
				 * Returns true if binded schema is selected
				 * @protected
				 * @return Boolean
				 */
				isReferenceSchemaSelected: function(value) {
					var isSelected = !this.Ext.isEmpty(value);
					if (!isSelected) {
						this.set("IsRuleSelectModeVisible", isSelected);
					}					
					return isSelected;
				},

				/**
				 * Return EntitySchema parameter name
				 * @protected
				 * @return String
				 */
				getEntitySchemaParameterName: function() {
					return "EntitySchemaUId";
				},

				/**
				 * Return EntitySchema attribute name
				 * @protected
				 * @return String
				 */
				getEntitySchemaAttributeName: function() {
					return "EntitySchemaSelect";
				},

				/**
				 * Fills out the drop down list of rule select modes.
				 * @private
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list The drop down list.
				 */
				prepareRuleSelectModes: function(filter, list) {
					if (list === null) {
						return;
					}
					const ruleSelectModes = this.getRuleSelectModes();
					list.clear();
					list.loadAll(ruleSelectModes);
				},

				/**
				 * Returns rule select modes.
				 * @private
				 * @return {Object}
				 */
				getRuleSelectModes: function() {
					const ruleSelectModes = {};
					const ruleSelectModeEnum = this.get("RuleSelectModeEnum");
					ruleSelectModes[ruleSelectModeEnum.ReadAllRules] = {
						value: ruleSelectModeEnum.ReadAllRules,
						displayValue: this.get("Resources.Strings.ReadAllRulesCaption")
					};
					ruleSelectModes[ruleSelectModeEnum.ReadOnlySelectedRules] = {
						value: ruleSelectModeEnum.ReadOnlySelectedRules,
						displayValue: this.get("Resources.Strings.ReadOnlySelectedRulesCaption")
					};
					return ruleSelectModes;
				},

				/**
				 * Initializes rule selection mode.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initRuleSelectMode: function(element) {
					const ruleSelectModeEnum = this.get("RuleSelectModeEnum");
					const duplicateRulesCollection = this.$DuplicateRulesCollection;
					const ruleSelectMode = !duplicateRulesCollection || duplicateRulesCollection.getCount() === 0
						? ruleSelectModeEnum.ReadAllRules
						: ruleSelectModeEnum.ReadOnlySelectedRules;
					const ruleSelectModes = this.getRuleSelectModes();
					this.set("RuleSelectMode", ruleSelectModes[ruleSelectMode]);
					this.on("change:RuleSelectMode", this.onRuleSelectModeChanged, this);
				},

				/**
				 * Handles modification event of the rule selection mode.
				 * @protected
				 */
				onRuleSelectModeChanged: function () {
					const ruleSelectModeEnum = this.get("RuleSelectModeEnum");
					this.set("IsRuleSelectModeVisible", this.$RuleSelectMode.value === ruleSelectModeEnum.ReadOnlySelectedRules);
				},

				//endregion
				
			},
			diff: [
				{
					"operation": "merge",
					"name": "BaseDataModificationLayout",
					"values": {
						"visible": {"bindTo": "ESDeduplicationFeatureEnabled"}
					}
				},
				{
					"operation": "merge",
					"name": "RecommendationLabel",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 23},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SourceObjectCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
					}
				},
				{
					"operation": "merge",
					"name": "EntitySchemaSelect",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"name": "EntitySchemaInfoContainer",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 23, "row": 0, "colSpan": 1},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "EntitySchemaInfoButtonContainer",
						"wrapClass": ["filter-info-button-container"]
					}
				},
				{
					"operation": "insert",
					"parentName": "EntitySchemaInfoContainer",
					"propertyName": "items",
					"name": "EntitySchemaInfoButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.EntitySchemaInfoCaption"
						}
					}
				},
				
				//region Entity record selection

				{
					"operation": "insert",
					"name": "EntityIdLabel",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 23},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.EntityIdCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"visible": {
							"bindTo": "ReferenceSchemaUId",
							"bindConfig": {
								"converter": "isReferenceSchemaSelected"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "EntityIdInfoContainer",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 23, "row": 2, "colSpan": 1},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "EntityIdInfoButtonContainer",
						"wrapClass": ["filter-info-button-container"],
						"visible": {
							"bindTo": "ReferenceSchemaUId",
							"bindConfig": {
								"converter": "isReferenceSchemaSelected"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EntityIdInfoContainer",
					"propertyName": "items",
					"name": "EntityIdInfoButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.EntityIdInfoCaption"
						}
					}
				},
				{
					"operation": "insert",
					"name": "EntityId",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 24},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": {
							"bindTo": "ReferenceSchemaUId",
							"bindConfig": {
								"converter": "isReferenceSchemaSelected"
							}
						}
					}
				},
				
				//endregion
				
				{
					"operation": "remove",
					"name": "FilterUnitLabel"
				},
				{
					"operation": "remove",
					"name": "FilterInfoButtonContainer"
				},
				{
					"operation": "remove",
					"name": "ExtendedFiltersContainer"
				},

				//endregion
				
				//region duplicate rules

				{
					"operation": "insert",
					"name": "RuleSelectModeLabel",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.RuleSelectModeCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"visible": {
							"bindTo": "ReferenceSchemaUId",
							"bindConfig": {
								"converter": "isReferenceSchemaSelected"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"name": "RuleSelectMode",
					"values": {
						"layout": {"column": 0, "row": 5, "colSpan": 24},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRuleSelectModes"
							}
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": {
							"bindTo": "ReferenceSchemaUId",
							"bindConfig": {
								"converter": "isReferenceSchemaSelected"
							}
						}
					}
				},

				{
					"operation": "insert",
					"name": "DuplicateRulesContainer",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 6, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": {
							"bindTo": "IsRuleSelectModeVisible"
						}
					}
				},
				{
					"operation": "insert",
					"name": "DuplicateRuleContainer",
					"parentName": "DuplicateRulesContainer",
					"propertyName": "items",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "DuplicateRulesCollection",
						"onGetItemConfig": "getEntityColumnMappingsControlViewConfig",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AddRecordDuplicateRuleButton",
					"parentName": "DuplicateRulesContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.DuplicateRule_AddRecordColumnValuesButtonCaption"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": {"bindTo": "onAddDuplicateRule"}
					}
				},
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "BlankSlateContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["duplicates-usertask-blankslate"]},
						"visible": {
							"bindTo": "ESDeduplicationFeatureEnabled",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"name": "BlankSlateDescription",
					"values": {
						"generator": "HtmlControlGeneratorV2.generateHtmlControl",
						"htmlContent": {"bindTo": "Resources.Strings.BlankSlateDescription"},
						"classes": {"wrapClass": ["duplicates-usertask-blankslate-description-label"]}
					}
				}

				//endregion

			]
		};
	}
);
