/**
 * Parent: BaseUserTaskPropertiesPage
 */
define("PreconfiguredPageUserTaskPropertiesPage", ["BPMSoft", "PreconfiguredPageUserTaskPropertiesPageResources",
	"ProcessModuleUtilities", "ProcessEntryPointPropertiesPageMixin", "DesignTimeEnums"
], function(BPMSoft, resources, ProcessModuleUtilities) {
	return {
		mixins: {
			processEntryPointPropertiesPageMixin: "BPMSoft.ProcessEntryPointPropertiesPageMixin"
		},
		properties: {
			/**
			 * @inheritdoc RootUserTaskPropertiesPage.properties#schemaManagerName
			 * @override
			 */
			schemaManagerName: "ClientUnitSchemaManager",

			/**
			 * @inheritdoc RootUserTaskPropertiesPage.properties#useNotification
			 * @override
			 */
			useNotification: true,

			/**
			 * @private
			 */
			_pageTemplates: [
				BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_SIMPLE_PROCESS_TEMPLATE,
				BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_PROCESS_TEMPLATE,
				BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_RIGHT_CONTAINER_PROCESS_TEMPLATE,
				BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_LEFT_CONTAINER_PROCESS_TEMPLATE
			]
		},
		messages: {},
		attributes: {
			/**
			 * Page schema to open.
			 */
			"ClientUnitSchemaUId": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				referenceSchemaName: "SysSchema",
				doAutoSave: true,
				isRequired: true
			},
			/**
			 * Previous selected page schema.
			 */
			"PreviousClientUnitSchemaUId": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				referenceSchemaName: "SysSchema"
			},
			/**
			 * Recommendations for filling out the page.
			 */
			"Recommendation": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.RecommendationCaption,
				initMethod: "initProperty",
				isRequired: false,
				doAutoSave: true
			},
			/**
			 * User hints.
			 */
			"InformationOnStep": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.InformationOnStepCaption,
				doAutoSave: true,
				initMethod: "initProperty"
			},
			/**
			 * To whom open a page.
			 */
			"OwnerId": {
				isRequired: false
			},
			/**
			 * Connection object.
			 */
			"EntitySchemaUId": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.EntitySchemaCaption,
				referenceSchemaName: "SysSchema",
				doAutoSave: true
			},
			/**
			 * Instance of connection object.
			 */
			"EntityId": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: resources.localizableStrings.EntityCaption,
				doAutoSave: true,
				initMethod: "initProperty"
			},
			/**
			 * Flag that indicates page parameters visibility.
			 */
			"IsPageParametersVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			/**
			 * Flag that indicates element PageHasNoParametersLabel visible.
			 */
			"PageHasNoParametersLabelVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			/**
			 * Page parameters.
			 */
			"PageParameters": {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true,
				value: this.Ext.create("BPMSoft.ObjectCollection")
			},
			/**
			 * Template(Parent) page.
			 */
			"Template": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initProperty",
				referenceSchemaName: "VwSysSchemaInfo"
			},
			/**
			 * Cached page parameter view config.
			 */
			"PageParameterViewConfig": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @inheritdoc BPMSoft.BaseUserTaskPropertiesPage#getSupportsTechnicalActivity
			 * @override
			 */
			getSupportsTechnicalActivity: function() {
				return false;
			},

			/**
			 * Reverts attribute ClientUnitSchemaUId if empty.
			 * @private
			 */
			revertClientUnitSchema: function() {
				var schema = this.$ClientUnitSchemaUId;
				var oldSchema = this.$PreviousClientUnitSchemaUId;
				if (!schema && oldSchema) {
					this.$ClientUnitSchemaUId = oldSchema;
				}
			},

			/**
			 * Saves page parameters values.
			 * @private
			 */
			savePageParameters: function() {
				var element = this.get("ProcessElement");
				var parameters = this.get("PageParameters");
				parameters.each(function(model) {
					this.saveExtendedValue(model, element);
					if (model.hasItemProperties()) {
						this._saveNestedCollection(model.$ItemProperties);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_getShouldSkipParameter: function(parameter, element) {
				return parameter.tag === "ActivityConnection" || element.getIsAssignmentOptionsParameter(parameter.uId);
			},

			/**
			 * Initializes selected preconfigured page parameters.
			 * @private
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 */
			initPageParameters: function(element) {
				this.clearPageParameters();
				const parameters = element.getDynamicParameters().filterByFn(function(parameter) {
					const skip = this._getShouldSkipParameter(parameter, element);
					return !ProcessModuleUtilities.isSystemParameter(parameter.name) && !skip;
				}, this);
				parameters.each(function(parameter) {
					const viewModel = this.createParameterViewModel(parameter);
					viewModel.validate();
					this.$PageParameters.add(parameter.uId, viewModel);
				}, this);
				const hasParameters = !parameters.isEmpty();
				this.$PageHasNoParametersLabelVisible = !hasParameters;
				this.$IsPageParametersVisible = hasParameters;
			},

			/**
			 * Sets attribute "ClientUnitSchemaUId".
			 * @private
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initClientUnitSchema: function(callback, scope) {
				var parameter = this.get("ProcessElement").getParameterByName("ClientUnitSchemaUId");
				var schemaUId = parameter.getValue();
				if (BPMSoft.isEmpty(schemaUId)) {
					callback.call(scope);
					return;
				}
				ProcessModuleUtilities.loadSchemaDisplayValue(schemaUId, function(displayValue, name) {
					if (name && displayValue) {
						const lookupdisplayValue = this._appendSchemaName(displayValue, name);
						this._initClientUnitSchemaUId({
							value: schemaUId,
							displayValue: lookupdisplayValue
						});
						this.initSchemaParameters(callback, scope);
					} else {
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * The event handler for preparing page schemas drop-down list.
			 * @private
			 * @param {Object} filter Filters for data preparation.
			 * @param {BPMSoft.Collection} list The data for the drop-down list.
			 */
			onPrepareClientUnitSchemaList: function(filter, list) {
				if (BPMSoft.isEmptyObject(list)) {
					return;
				}
				list.clear();
				var selectedSchema = this.$ClientUnitSchemaUId;
				var pageSchemas = this.get("PageSchemas");
				if (selectedSchema) {
					pageSchemas = pageSchemas.filterByFn(function(schema) {
						return schema.value !== selectedSchema.value;
					});
				}
				list.loadAll(pageSchemas);
			},

			/**
			 * Clears page parameter collection and sets empty parameters group caption.
			 * @private
			 */
			clearPageParameters: function() {
				this.$PageParameterViewConfig = null;
				this.$IsPageParametersVisible = false;
				this.$PageHasNoParametersLabelVisible = false;
				this.$PageParameters.clear();
			},

			/**
			 * Returns label configuration for page parameter.
			 * @private
			 */
			getPageParameterLabelConfig: function() {
				return {
					id: "Caption",
					className: "BPMSoft.Label",
					caption: {bindTo: "Caption"},
					classes: {labelClass: ["t-label-proc", "t-label-proc-param"]}
				};
			},

			/**
			 * @private
			 */
			_showParametersLoadMask: function() {
				var config = {
					selector: ".sub-process-parameters-container:not(:first-child)",
					timeout: 0
				};
				return BPMSoft.Mask.show(config);
			},

			/**
			 * @inheritdoc BPMSoft.RootUserTaskPropertiesPage#onAfterSchemaCnahged
			 * @override
			 */
			onAfterSchemaChanged: function() {
				this.$PreviousClientUnitSchemaUId = this.$ClientUnitSchemaUId;
				var element = this.get("ProcessElement");
				element.clearDynamicParameters();
				this.synchronizeSchemaParameters();
			},

			/**
			 * @inheritdoc BPMSoft.RootUserTaskPropertiesPage#synchronizeSchemaParameters
			 * @override
			 */
			synchronizeSchemaParameters: function(callback, scope) {
				var maskId = this._showParametersLoadMask();
				BPMSoft.chain(
					function(next) {
						BPMSoft.ClientUnitSchemaManager.initialize(next, this);
					},
					function(next) {
						this.initSchemaParameters(next, this);
					},
					function() {
						BPMSoft.Mask.hide(maskId);
						Ext.callback(callback, scope);
					},
					this
				);
			},

			/**
			 * @private
			 */
			_updateTitleParameter: function(caption) {
				var element = this.get("ProcessElement");
				var parameter = element.getParameterByName("Title");
				var mappingValue = parameter.getMappingValue();
				mappingValue.value = caption;
				mappingValue.displayValue = caption;
				mappingValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
				parameter.setMappingValue(mappingValue);
			},

			/**
			 * @private
			 */
			_appendSchemaName: function(displayValue, name) {
				if (displayValue !== name) {
					return displayValue + " | " + name;
				} else {
					return displayValue;
				}
			},

			/**
			 * @private
			 */
			_subscribeClientUnitSchemaChanges: function() {
				this.on("change:ClientUnitSchemaUId", this.onBeforeSchemaChanged, this);
			},

			/**
			 * @private
			 */
			_findEqualParameter: function(parameters, sourceParameter) {
				return parameters.findByFn(function(parameter) {
					if (parameter.name !== sourceParameter.name && parameter.uId !== sourceParameter.uId) {
						return false;
					}
					if (ProcessModuleUtilities.isSystemParameter(parameter.name)) {
						return parameter.sourceValue.value === sourceParameter.sourceValue.value;
					}
					return true;
				}, this);
			},

			/**
			 * @private
			 */
			_checkParameterChanged: function(oldParameters) {
				var element = this.get("ProcessElement");
				var parameters = element.parameters;
				var parentSchema = element.parentSchema;
				if (parameters.getCount() === oldParameters.getCount()) {
					var changedParameters = [];
					parameters.each(function(parameter) {
						var equalOldParameter = this._findEqualParameter(oldParameters, parameter);
						if (!equalOldParameter) {
							changedParameters.push(parameter);
						}
					}, this);
					if (changedParameters.length) {
						parentSchema.fireEvent("changed", {parameters: changedParameters}, this);
					}
				} else {
					parentSchema.fireEvent("changed", {item: "parameters"}, this);
				}
			},

			/**
			 * @private
			 */
			_initClientUnitSchemaUId: function(lookupValue) {
				this.$ClientUnitSchemaUId = lookupValue;
				this.$PreviousClientUnitSchemaUId = lookupValue;
			},

			/**
			 * @private
			 */
			_getClientUnitSchemaInstance: function(callback, scope) {
				var config = {
					schemaUId: this.$ClientUnitSchemaUId.value,
					packageUId: this.get("packageUId"),
					useCache: false
				};
				BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(config, function(schema) {
					if (!schema) {
						this._initClientUnitSchemaUId(null);
					}
					callback.call(scope, schema);
				}, this);
			},

			/**
			 * @private
			 */
			_subscribeOnParametersChanged: function() {
				var element = this.$ProcessElement;
				element.parameters.each(function(parameter) {
					parameter.on("changed", this._onParameterChanged, this);
				}, this);
			},

			/**
			 * @private
			 */
			_onParameterChanged: function(changes, parameter) {
				var parentSchema = parameter.getParentSchema();
				parentSchema.fireEvent("changed", changes, parameter);
			},

			/**
			 * @private
			 */
			_updateElementParametersBySchemaParameters: function(schema) {
				const schemaParameters = schema.parameters;
				const element = this.$ProcessElement;
				schemaParameters.each(function(schemaParameter) {
					var processParameter = schemaParameter.convertToProcessParameter();
					const uId = processParameter.uId;
					const elementParameters = element.parameters;
					const oldParameter = element.findParameterByName(processParameter.name) ||
						element.findParameterBySourceUId(uId) || element.findParameterByUId(uId);
					if (oldParameter) {
						elementParameters.removeByKey(oldParameter.uId);
						processParameter.uId = oldParameter.uId;
					} else {
						processParameter.uId = BPMSoft.generateGUID();
					}
					processParameter.sourceParameterUId = uId;
					elementParameters.add(processParameter.uId, processParameter);
					this.initPageParameter(processParameter, element);
				}, this);
			},

			/**
			 * @private
			 */
			_clearDynamicParameters: function(schema) {
				const basePageTemplateUId = BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_PROCESS_TEMPLATE;
				if (BPMSoft.ClientUnitSchemaManager.isInheritedFrom(schema.uId, basePageTemplateUId)) {
					const element = this.$ProcessElement;
					const dynamicParameters = element.getDynamicParameters();
					const schemaParameters = schema.parameters;
					dynamicParameters.each(function(parameter) {
						if (this._getShouldSkipParameter(parameter, element)) {
							return true;
						}
						const sourceParameterUId = parameter.sourceParameterUId;
						const schemaParameter = sourceParameterUId && schemaParameters.find(sourceParameterUId);
						if (!schemaParameter) {
							element.clearDynamicParameter(parameter.uId);
						}
					}, this);
				}
			},

			//endregion

			/**
			 * Re-initializes page parameters.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initSchemaParameters: function(callback, scope) {
				this._getClientUnitSchemaInstance(function(clientUnitSchema) {
					if (!clientUnitSchema) {
						callback.call(scope);
						return;
					}
					var element = this.$ProcessElement;
					var links = element.parentSchema.findLinksToElements([element.name]);
					var oldParameters = element.parameters.clone();
					var oldRootsParameters = this.getRootsParameters(oldParameters);
					this.clearPageParameters();
					this._updateElementParametersBySchemaParameters(clientUnitSchema);
					this._clearDynamicParameters(clientUnitSchema);
					oldRootsParameters.each(function(oldRootParameter) {
						if (ProcessModuleUtilities.isSystemParameter(oldRootParameter.name)) {
							return;
						}
						var newParameter = element.findParameterByName(oldRootParameter.name) ||
							element.findParameterByUId(oldRootParameter.uId);
						this.synchronizeSchemaParameter(element, newParameter, oldRootParameter);
					}, this);
					this._subscribeOnParametersChanged();
					this.initPageParameters(element);
					this._checkParameterChanged(oldParameters);
					this._updateTitleParameter(clientUnitSchema.caption);
					this.invalidateDependentElements(links);
					this.validateDependedConditonalFlows(callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
			 * @override
			 */
			getParameterReferenceSchemaUId: function(elementParameter) {
				return this.mixins.processEntryPointPropertiesPageMixin
					.getParameterReferenceSchemaUId.call(this, elementParameter);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#onElementDataLoad.
			 * @overridden
			 */
			onElementDataLoad: function(element, callback, scope) {
				this.callParent([element, function() {
					BPMSoft.chain(
						this.initClientUnitSchema,
						this.initPageSchemas,
						this.initEntitySchemas,
						function(next) {
							this.initEntitySchema(element, next, this);
						},
						function() {
							this._subscribeClientUnitSchemaChanges();
							Ext.callback(callback, scope);
						}, this);
				}, this]);
			},

			/**
			 * Initializes PageSchemas attribute.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initPageSchemas: function(callback, scope) {
				var packageUId = this.get("packageUId");
				BPMSoft.SchemaDesignerUtilities.buildPackageHierarchy(packageUId, function(hierarchy) {
					var pageSchemas = new BPMSoft.Collection();
					var packageItems = BPMSoft.ClientUnitSchemaManager.filterByFn(function(item) {
						return _.contains(hierarchy, item.packageUId);
					}, this);
					var items = _.uniq(packageItems.mapArrayByPath("name"));
					items.forEach(function(name) {
						var item = BPMSoft.ClientUnitSchemaManager.findRootSchemaItemByName(name);
						var displayValue = this._appendSchemaName(item.getDisplayValue(), item.name);
						var orderValue = displayValue.toLowerCase().replace(/["\-|]/g, "");
						pageSchemas.add(item.uId, {
							value: item.uId,
							packageUId: item.packageUId,
							name: item.name,
							displayValue: displayValue,
							orderValue: orderValue
						});
					}, this);
					pageSchemas.sort("orderValue");
					this.set("PageSchemas", pageSchemas);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues.
			 * @overridden
			 */
			saveValues: function() {
				this.revertClientUnitSchema();
				this.callParent(arguments);
				this.savePageParameters();
			},

			/**
			 * Initializes page parameter.
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Parameter.
			 * @param {BPMSoft.ProcessUserTaskSchema} element Process user task schema.
			 */
			initPageParameter: function(parameter, element) {
				parameter.processFlowElementSchema = element;
				const processSchema = element.parentSchema;
				if (parameter.itemProperties.getCount() > 0) {
					this.initNestedPageParameter(parameter, element);
				}
				parameter.createdInSchemaUId = processSchema.uId;
			},

			/**
			 * Initializes nested page parameter.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Parameter.
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 */
			initNestedPageParameter: function(parameter, element) {
				parameter.itemProperties.each(function(nestedParameter) {
					nestedParameter.processFlowElementSchema = element;
					if (nestedParameter.itemProperties.getCount() > 0) {
						this.initNestedPageParameter(nestedParameter, element);
					}
				}, this);
			},

			/**
			 * @protected
			 * @param {BPMSoft.ClientUnitSchema} pageSchema Page schema
			 */
			getPageDesignerButtonHint: function(pageSchema) {
				var stringName = pageSchema ? "OpenSchemaButtonHintCaption" : "AddSchemaButtonHintCaption";
				return this.get("Resources.Strings." + stringName);
			},

			/**
			 * @protected
			 * @param {BPMSoft.ClientUnitSchema} pageSchema Page schema
			 */
			getPageDesignerButtonImage: function(pageSchema) {
				var imageName = pageSchema ? "OpenButtonImage" : "AddButtonImage32";
				return this.get("Resources.Images." + imageName);
			},

			/**
			 * Opens page designer, if schema is not inherited from template it opens 5.x client unit designer.
			 * @protected
			 */
			openPageDesigner: function() {
				var maskId = BPMSoft.Mask.show({
					selector: ".properties-container",
					timeout: 0
				});
				var manager = BPMSoft.ClientUnitSchemaManager;
				manager.reInitialize(function() {
					BPMSoft.Mask.hide(maskId);
					var templatePageUId = BPMSoft.FormulaParserUtils.getLookupValue(this.$Template);
					var pageUId = this.$ClientUnitSchemaUId && this.$ClientUnitSchemaUId.value;
					this.$IsAddSchemaButtonClicked = Ext.isEmpty(pageUId);
					if (pageUId && !manager.isInheritedFrom(pageUId, templatePageUId)) {
						manager.findInstanceByUId(pageUId, function(schema) {
							ProcessModuleUtilities.showClientUnitSchemaDesigner(schema);
						}, this);
					} else if (pageUId) {
						ProcessModuleUtilities.showPageSchemaDesigner(pageUId, templatePageUId);
					} else {
						ProcessModuleUtilities.showPageTemplateLookup();
					}
				}, this);
			},

			/**
			 * Handles before page schema change, shows confirmation message.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} model Page view model.
			 * @param {Object} newSchema New schemas value.
			 */
			onBeforeSchemaChanged: function(model, newSchema) {
				var oldSchema = this.$PreviousClientUnitSchemaUId;
				var newSchemaUId = newSchema ? newSchema.value : "";
				var oldSchemaUId = oldSchema && oldSchema.value;
				if (!newSchemaUId || newSchemaUId === oldSchemaUId) {
					return;
				}
				if (Ext.isEmpty(oldSchema)) {
					BPMSoft.defer(this.onAfterSchemaChanged, this);
				} else {
					this.canChangeSchema(function(canChange) {
						if (canChange) {
							this.confirmSchemaChange(oldSchema);
						} else {
							this.$ClientUnitSchemaUId = oldSchema;
						}
					}, this);
				}
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#getSchema.
			 * @overridden
			 */
			getSchema: function() {
				return this.$ClientUnitSchemaUId;
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#getSchema
			 * @overridden
			 */
			setSchema: function(schema, options) {
				this.set("ClientUnitSchemaUId", schema, options);
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#onSchemaOutdated
			 * @overridden
			 */
			onSchemaOutdated: function(event) {
				const manager = BPMSoft.ClientUnitSchemaManager;
				const parentMethod = this.getParentMethod();
				manager.reInitialize(() => {
					if (this._pageTemplates.some(templateUId => manager.isInheritedFrom(event.uId, templateUId))) {
						parentMethod.apply(this, arguments);
					}
				})
			},

			/**
			 * @inheritdoc RootUserTaskPropertiesPage#getSchema
			 * @overridden
			 */
			getOutdatedSchema: function(event) {
				var result = this.callParent(arguments);
				result.displayValue += " | " + event.name;
				return result;
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#getResultParameterAllValues
			 * @overridden
			 */
			getResultParameterAllValues: function(callback, scope) {
				var resultParameterValues = {};
				var element = this.get("ProcessElement");
				var parameter = element.findParameterByName("Buttons");
				if (parameter) {
					var parameterValue = parameter.getValue();
					if (parameterValue) {
						var buttonsArray = BPMSoft.decode(parameterValue).$values;
						BPMSoft.each(buttonsArray, function(item) {
							if (item.PerformClosePage.value === "True") {
								var id = item.Id.value;
								var caption = item.Caption.value;
								resultParameterValues[id] = caption;
							}
						}, this);
					}
				}
				callback.call(scope, resultParameterValues);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "RecommendationLabel"
			},
			{
				"operation": "insert",
				"name": "WhatPageToOpenLabel",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.WhatPageToOpenLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] }
				}
			},
			{
				"operation": "insert",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"name": "ClientUnitSchemaUId",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 22 },
					"labelConfig": { "visible": false },
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": { "bindTo": "onPrepareClientUnitSchemaList" },
						"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "OpenSchemaDesignerButton",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"hint": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": {
							"converter": "getPageDesignerButtonHint"
						}
					},
					"imageConfig": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": {
							"converter": "getPageDesignerButtonImage"
						}
					},
					"classes": {
						"wrapperClass": ["open-schema-designer-tool-button"]
					},
					"click": { "bindTo": "openPageDesigner" },
					"layout": { "column": 22, "row": 1, "colSpan": 2 }
				}
			},
			{
				"operation": "insert",
				"name": "TaskPropertiesContainer",
				"propertyName": "items",
				"parentName": "UserTaskContainer",
				"className": "BPMSoft.Container",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "ClientUnitSchemaUId",
						"bindConfig": { "converter": "toBoolean" }
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "Recommendation",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "InformationOnStep",
				"values": {
					"contentType": BPMSoft.ContentType.LONG_TEXT,
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "WhichRecordToConnectThePageToLabel",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.WhichRecordToConnectThePageToLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] }
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "EntitySchemaUId",
				"values": {
					"contentType": BPMSoft.ContentType.ENUM,
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"controlConfig": {
						"prepareList": { "bindTo": "onPrepareEntitySchemaList" },
						"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "EntityId",
				"values": {
					"layout": { "column": 0, "row": 4, "colSpan": 24 },
					"wrapClass": ["top-caption-control"],
					"enabled": { "bindTo": "EntitySchemaUId" }
				}
			},
			{
				"operation": "insert",
				"name": "PageParametersLabel",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 5, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.PageParametersLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] },
					"visible": { "bindTo": "IsPageParametersVisible" }
				}
			},
			{
				"operation": "insert",
				"name": "PageHasNoParametersLabel",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 6, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.PageHasNoParametersLabelCaption" },
					"classes": { "labelClass": ["t-title-label-proc"] },
					"visible": { "bindTo": "PageHasNoParametersLabelVisible" }
				}
			},
			{
				"operation": "insert",
				"name": "PageParameters",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 7, "colSpan": 24 },
					"generator": "ConfigurationItemGenerator.generateHierarchicalContainerList",
					"idProperty": "ParameterEditKey",
					"nestedItemsAttributeName": "ItemProperties",
					"nestedItemsContainerId": "nested-parameters",
					"onItemClick": { "bindTo": "onItemClick" },
					"collection": "PageParameters",
					"defaultItemConfig": BPMSoft.ProcessSchemaParameterViewConfig.generate(),
					"rowCssSelector": ".paramContainer",
					"classes": { "wrapClassName": ["sub-process-parameters-container"] }
				}
			},
			{
				"operation": "insert",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items",
				"name": "useBackgroundMode",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"visible": { "bindTo": "canUseBackgroundProcessMode" },
					"layout": { "column": 0, "row": 8, "colSpan": 24 }
				}
			},
			{
				"operation": "move",
				"name": "ActivityControlsContainer",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "ActivityControlsContainer",
				"parentName": "TaskPropertiesContainer",
				"values": {
					"layout": { "column": 0, "row": 9, "colSpan": 24 },
				}
			}

		]
	};
});
