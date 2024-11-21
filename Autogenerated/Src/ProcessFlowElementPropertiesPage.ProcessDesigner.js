/**
 * ProcessFlowElementPropertiesPage edit page schema.
 * Parent: BaseProcessSchemaElementPropertiesPage
 */
define("ProcessFlowElementPropertiesPage", ["BPMSoft", "ProcessFlowElementPropertiesPageResources",
		"ConfigurationItemGenerator", "LookupUtilitiesV2", "ProcessSchemaParameterEditModule", "MappingEditMixin",
		"ProcessSchemaParameterViewModel", "ProcessSchemaParameterViewConfig", "HierarchicalContainerList",
		"css!ProcessFlowElementPropertiesPageCSS", "ProcessSchemaParametersEditMixin"],
	function(BPMSoft, resources) {
		return {
			mixins: {
				mappingEditMixin: "BPMSoft.MappingEditMixin",
				parametersEditMixin: "BPMSoft.ProcessSchemaParametersEditMixin"
			},
			properties: {
				/**
				 * Schema manager name, used for outdated schema notifications.
				 * @protected
				 * @virtual
				 * @type {String}
				 */
				schemaManagerName: null,

				/**
				 * Use websocket notifications.
				 * @protected
				 * @type {Boolean}
				 */
				useNotification: false
			},
			messages: {
				/**
				 * @message GetParametersInfo
				 * Pass parameter values.
				 */
				"GetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetParametersInfo
				 * Specifies parameter values.
				 */
				"SetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SaveParameterInfo
				 * Save parameter info message.
				 */
				"SaveParameterInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message DiscardParameterInfoChanges
				 * Close and unloads parameter edit page message.
				 */
				"DiscardParameterInfoChanges": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetParameterEditInfo
				 * Sends parameter info to parameter edit page message.
				 */
				"GetParameterEditInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetItemEditInfo
				 * Sends item info to item edit page message.
				 */
				"GetItemEditInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message DiscardItemInfoChanges
				 * Close and unloads item edit page message.
				 */
				"DiscardItemInfoChanges": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SaveItemInfo
				 * Save item info message.
				 */
				"SaveItemInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SaveParameter
				 * Message for save editing parameter.
				 */
				"SaveParameter": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Flag that indicates is element logging or not.
				 */
				"isLogging": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.IsLoggingCaption
				},

				/**
				 * Flag that indicates serialization in database.
				 */
				"serializeToDB": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.SerializeToDBCaption
				},

				/**
				 * Value that indicates whether the current element is used background mode.
				 */
				"useBackgroundMode": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: { bindTo: "getUseBackgroundModeCaption" }
				},

				/**
				 * Process element parameters.
				 */
				"Parameters": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Flag that indicates the lack of parameters.
				 */
				"IsEmptyParameters": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Flag that indicates availability of editing SerializeToDB field.
				 */
				"IsSerializeToDBEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Flag that indicates visibility of SerializeToDB field.
				 */
				"IsSerializeToDBVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Flag that indicates visibility of IsLogging field.
				 */
				"IsLoggingVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Active parameter edit identifier.
				 */
				"ActiveParameterEditUId": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: null
				},

				/**
				 * Determines whether current element is in Multi Instance mode or not.
				 */
				"IsMultiInstanceMode": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Multi-instance execution mode config.
				 */
				"MultiInstanceExecutionModeConfig": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.MultiInstanceExecutionModeCaption,
					isRequired: true,
					value: {
						value: BPMSoft.process.MultiInstanceExecutionMode.SEQUENTIAL
					}
				},

				/**
				 * Determines whether ignore execution errors for multi-instance elements or not.
				 */
				"IgnoreMultiInstanceErrors": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.IgnoreMultiInstanceErrorsCaption,
					value: false
				},

				/**
				 * Multi-instance execution mode list.
				 */
				"MultiInstanceExecutionModeList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: Ext.create("BPMSoft.Collection")
				}
			},
			methods: {

				/**
				 * @inheritdoc BaseSchemaViewModel#constructor
				 * @overridden
				 */
				constructor: function() {
					this.callParent(arguments);
					this.$Parameters = Ext.create("BPMSoft.ObjectCollection");
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					var parentMethod = this.getParentMethod();
					BPMSoft.chain(
						function(next) {
							parentMethod.call(this, element, next, this);
						},
						function(next) {
							this.clearParameters();
							this.initElementProperty(element, next, this);
						},
						function(next) {
							if (this.getHasParameters()) {
								element.updateParametersDisplayValue(next, this);
							} else {
								next();
							}
						},
						function() {
							this.initDefaultTab(element);
							var isEditPageDefault = this.getIsEditPageDefault(element.editPageSchemaName);
							if (isEditPageDefault) {
								this.initBaseParameters(element);
							} else {
								this.initParameters(element);
							}
							callback.call(scope);
						}, this);
				},

				/**
				 * Initializes element property.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				initElementProperty: function(element, callback, scope) {
					const isLoggingVisible = this.getIsLoggingVisible();
					this.set("IsLoggingVisible", isLoggingVisible);
					if (isLoggingVisible) {
						this.set("isLogging", element.isLogging);
					}
					this.set("useBackgroundMode", element.useBackgroundMode);
					const isSerializeToDBVisible = this.getIsSerializeToDBVisible();
					this.set("IsSerializeToDBVisible", isSerializeToDBVisible);
					const isMultiInstanceMode = this._getIsMultiInstanceMode();
					this.set("IsMultiInstanceMode", isMultiInstanceMode);
					if (isMultiInstanceMode) {
						this._initMultiInstanceExecutionModeDisplayValue(element.multiInstanceOptions);
						this.set("IgnoreMultiInstanceErrors", element.multiInstanceOptions.ignoreErrors);
					}
					if (isSerializeToDBVisible) {
						this.initIsSerializeToDB(element);
						this.initIsSerializeToDBEnabled(element, callback, scope);
					} else {
						callback.call(scope);
					}
				},

				/**
				 * Initializes SerializeToDB property.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initIsSerializeToDB: function(element) {
					this.set("serializeToDB", element.serializeToDB);
				},

				/**
				 * Returns flag that indicates visibility of SerializeToDB field.
				 * @return {Boolean} Visibility of SerializeToDB field.
				 */
				getIsSerializeToDBVisible: function() {
					const element = this.get("ProcessElement");
					return !element.parentSchema || !element.parentSchema.isEmbedded;
				},

				/**
				 * Returns flag that indicates visibility of IsLogging field.
				 * @return {Boolean} Visibility of IsLogging field.
				 */
				getIsLoggingVisible: function() {
					const element = this.get("ProcessElement");
					return !element.parentSchema || !element.parentSchema.isEmbedded;
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getDefaultTabName
				 * @overridden
				 */
				getDefaultTabName: function() {
					var defaultTabName = this.callParent(arguments);
					var element = this.get("ProcessElement");
					var parameters = element.parameters;
					if (parameters && !parameters.isEmpty()) {
						var tabsCollection = this.get("TabsCollection");
						var firstTab = tabsCollection.getByIndex(0);
						defaultTabName = firstTab.get("Name");
					}
					return defaultTabName;
				},

				/**
				 * The event handler clicking on the Advanced mode menu.
				 * @private
				 */
				onPageModeClick: function() {
					this.callParent(arguments);
					const isExtendedMode = this.get("IsExtendedMode");
					const element = this.get("ProcessElement");
					if(isExtendedMode) {
						this.initBaseParameters(element);
					} else {
						this.saveExtendedValues();
						this.initBaseParameters(element);
						this.initParameters(element);
					}
				},

				/**
				 * @private
				 */
				_getIsMultiInstanceMode: function() {
					const processElement = this.get("ProcessElement");
					return  processElement instanceof BPMSoft.manager.ProcessFlowElementSchema &&
						processElement.getIsMultiInstanceModeEnabled();
				},

				/**
				 * Initializes "IsSerializeToDBEnabled" by user task schema.
				 * @private
				 * @param {String} managerName The manager name.
				 * @param {String} itemUId Manager item identifier.
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The callback scope.
				 */
				_setIsSerializeToDbEnabled: function(managerName, itemUId, callback, scope) {
					var manager = BPMSoft[managerName];
					manager.initialize(function() {
						var item = manager.getItem(itemUId);
						var serializeToDB = item.instance.serializeToDB;
						this.set("IsSerializeToDBEnabled", !serializeToDB);
						callback.call(scope);
					}, this);
				},

				/**
				 * Determines whether the schema element can be used in background processes.
				 * @return {Boolean} True, if functionality is enabled; otherwise - False.
				 */
				canUseBackgroundProcessMode: function() {
					const element = this.get("ProcessElement");
					const processSchema = element instanceof BPMSoft.ProcessSchema
						? element
						: (element && element.parentSchema);
					return Boolean(processSchema) && this.BPMSoft.Features.getIsEnabled("UseBackgroundProcessMode") &&
						!processSchema.isEmbedded;
				},

				/**
				 * Initializes the value of an attribute IsSerializeToDBEnabled.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				initIsSerializeToDBEnabled: function(element, callback, scope) {
					if (element instanceof BPMSoft.ProcessUserTaskSchema) {
						this._setIsSerializeToDbEnabled(element.taskSchemaManagerName,
							element.managerItemUId, callback, scope);
					} else {
						this.set("IsSerializeToDBEnabled", true);
						callback.call(scope);
					}
				},

				/**
				 * Initializes the attributes of the element parameters.
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initParameters: function(element) {
					this.initDesignerType();
					this.mixins.parametersEditMixin.initParameters.call(this, element);
				},

				/**
				 * Saves nested parameter view models.
				 * @private
				 */
				_saveNestedCollection: function(models) {
					models.each(function(model) {
						var element = this.get("ProcessElement");
						this.saveExtendedValue(model, element);
						if (model.hasItemProperties()) {
							this._saveNestedCollection(model.$ItemProperties);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_sortParameterCollection: function(collection) {
					var required = collection.filterByFn(function(parameter) {
						return parameter.$IsRequired;
					});
					var optional = collection.filterByFn(function(parameter) {
						return !parameter.$IsRequired;
					});
					required.sortByFn(function(item1, item2) {
						return item1.$Caption.localeCompare(item2.$Caption);
					});
					optional.sortByFn(function(item1, item2) {
						return item1.$Caption.localeCompare(item2.$Caption);
					});
					collection.clear();
					collection.loadAll(required);
					collection.loadAll(optional);
					return collection;
				},

				/**
				 * Returns current suer contact macros string.
				 * @private
				 * @return {String} Current contact macros string.
				 */
				getCurrentUserContactMappingValue: function() {
					var macros = BPMSoft.FormulaMacros.prepareSysVariableValue(
						BPMSoft.SystemValueType.CURRENT_USER_CONTACT);
					return macros.toString();
				},

				/**
				 * Clears view model parameters.
				 * @private
				 */
				clearParameters: function() {
					const parameters = this.get("Parameters");
					if (parameters) {
						parameters.clear();
					}
				},

				/**
				 * Returns flag that indicates empty Parameters or not.
				 * @private
				 * @return {Boolean} Returns flag that indicates empty Parameters or not.
				 */
				getHasParameters: function() {
					const element = this.get("ProcessElement");
					const elementParameters = element.parameters;
					return elementParameters ? !elementParameters.isEmpty() : false;
				},

				/**
				 * Initializes element parameters ViewModel.
				 * @protected
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Boolean} skipValidation Flag that indicates when to skip parameter validation.
				 */
				initBaseParameters: function(element, skipValidation) {
					this.clearParameters();
					const parameters = this.get("Parameters");
					const isExtendedMode = this.get("IsExtendedMode");
					const elementParameters = element.getEditableParameters({
						isExtendedMode: isExtendedMode
					});
					const isEmptyParameters = !this.getHasParameters();
					this.set("IsEmptyParameters", isEmptyParameters);
					if (isEmptyParameters) {
						return true;
					}
					const collection = Ext.create("BPMSoft.BaseViewModelCollection");
					elementParameters.forEach(function(parameter) {
						const viewModel = this.createParameterViewModel(parameter);
						if (skipValidation === true) {
							collection.add(parameter.uId, viewModel);
						} else {
							viewModel.validate();
							collection.add(parameter.uId, viewModel);
						}
					}, this);
					this.sortParameterViewModelCollectionByCaption(collection);
					collection.each(function(parameter) {
						parameters.add(parameter.get("UId"), parameter);
					}, this);
				},

				/**
				 * Sorts view model collection by caption.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} parameters Parameters collection.
				 */
				sortParameterViewModelCollectionByCaption: function(parameters) {
					this.sortCollectionByColumn(parameters, "UId", "CaptionWithDirection");
				},

				/**
				 * Returns tools button edit menu item viewModel.
				 * @protected
				 * @param {String} parameterName Parameter name.
				 * @return {BPMSoft.BaseViewModel} Menu item ViewModel.
				 */
				getParameterEditToolsButtonEditMenuItem: function(parameterName) {
					return this.getButtonMenuItem({
						caption: this.get("Resources.Strings.EditMenuItemCaption"),
						tag: parameterName,
						click: { "bindTo": "onParameterLabelClick" }
					});
				},

				/**
				 * Returns parameter view model values config.
				 * @param {BPMSoft.ProcessSchemaParameter} parameter Process schema parameter.
				 * @protected
				 * @virtual
				 * @return {Object} Parameter view model values config.
				 */
				getParameterViewModelConfig: function(parameter) {
					let initialReferenceSchemaUId;
					const name = parameter.name;
					const dataValueType = parameter.dataValueType;
					const direction = parameter.direction;
					const parameterInvokerUId = this.getIsInvokedByProcessSchema()
						? parameter.uId
						: this.getInvokerUId();
					const typeImageUrl =
						BPMSoft.ProcessSchemaDesignerUtilities.getDataValueTypeImageUrl(dataValueType);
					const directionImageUrl = BPMSoft.ProcessSchemaDesignerUtilities.getDirectionImageUrl(direction);
					const value = parameter.value || parameter.getMappingValue();
					const editMenuItem = this.getParameterEditToolsButtonEditMenuItem(name);
					const toolsButtonMenu = Ext.create("BPMSoft.BaseViewModelCollection", {
						items: {
							"editButton": editMenuItem
						}
					});
					const element = this.get("ProcessElement");
					const parentSchema = element && element.parentSchema;
					const entitySchema = parentSchema && parentSchema.entitySchema;
					const initialConfig = parameter.initialConfig;
					if (initialConfig) {
						const sourceValue = initialConfig.sourceValue;
						const sourceReferenceSchemaUId = sourceValue ? sourceValue.referenceSchemaUId : null;
						initialReferenceSchemaUId = initialConfig.referenceSchemaUId || sourceReferenceSchemaUId;
					}
					const parent = parameter.getParent();
					const parentUId = parent && parent.uId;
					let itemProperties = parameter.itemProperties && parameter.itemProperties.map(function(nested) {
						return this.createParameterViewModel(nested);
					}, this);
					if (itemProperties) {
						itemProperties = this._sortParameterCollection(itemProperties);
					}
					const canAssignSourceValue = this.$ProcessElement.getCanAssignParameterSourceValue(parameter);
					const allowedCollectionItemNestingLevel =
						this.getAllowedCollectionItemNestingLevel(element, parameter);
					const hasCollectionMapping = this._checkHasCollectionMapping(element, value.value);
					return {
						Id: name,
						UId: parameter.uId,
						Name: name,
						Caption: parameter.getDisplayValue(),
						DataValueTypeImage: typeImageUrl,
						DataValueType: dataValueType,
						IsRequired: parameter.isRequired,
						ReferenceSchemaUId: parameter.referenceSchemaUId,
						InitialReferenceSchemaUId: initialReferenceSchemaUId,
						Value: value,
						ParameterEditToolsButtonMenu: toolsButtonMenu,
						Enabled: false,
						packageUId: this.get("packageUId"),
						InvokerUId: parameterInvokerUId,
						Parameters: this.get("Parameters"),
						ProcessElement: element,
						EntitySchema: entitySchema,
						Direction: parameter.direction,
						DirectionImage: directionImageUrl,
						ParentUId: parentUId,
						ItemProperties: itemProperties,
						AllowedCollectionItemNestingLevel: allowedCollectionItemNestingLevel,
						CanAssignSourceValue: canAssignSourceValue,
						HasCollectionMapping: hasCollectionMapping
					};
				},

				/**
				 * @private
				 */
				_checkHasCollectionMapping: function(element, value) {
					let result = false;
					const parentSchema = element && element.parentSchema;
					if (!parentSchema) {
						return result;
					}
					BPMSoft.FormulaParserUtils.getFormulaParameters(value, parentSchema,
						function(formulaParameters) {
							if (formulaParameters === null || !BPMSoft.isEmpty(formulaParameters)) {
								BPMSoft.each(formulaParameters, function(formulaParameter) {
									const parameterInfo =
										BPMSoft.FormulaParserUtils.getParameterMappingInfo(formulaParameter);
									const parameter = this.getMappingParameter(parameterInfo);
									const parentParameter = parameter && parameter.getParent();
									if (parentParameter) {
										result = true;
										return false;
									}
								}, this);
							}
						}, this);
					return result;
				},

				/**
				 * Returns true if properties page invoked for process schema and false if for user task.
				 * @private
				 * @return {Boolean} True if invoked for process schema, false if for user task.
				 */
				getIsInvokedByProcessSchema: function() {
					return this.get("ProcessElement") instanceof BPMSoft.ProcessSchema;
				},

				/**
				 * Creates parameter viewModel.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.ProcessSchemaParameter} parameter Process schema parameter.
				 * @return {BPMSoft.ProcessSchemaParameterViewModel} Parameter view model.
				 */
				createParameterViewModel: function(parameter) {
					var parameterViewModelConfig = this.getParameterViewModelConfig(parameter);
					var viewModel = Ext.create("BPMSoft.ProcessSchemaParameterViewModel", {
						values: parameterViewModelConfig,
						sandbox: this.sandbox,
						methods: {
							onItemFocused: this.onItemFocused
						}
					});
					viewModel.on("change", this.onChildViewModelChange, this);
					viewModel.on("change:Visible", this.closeParameterEditPage, this);
					viewModel.on("collectionMappingSet", this._convertElementToMultiInstanceMode, this);
					viewModel.on("collectionMappingReset", this._convertElementToSingleInstanceMode, this);
					return viewModel;
				},

				/**
				 * Handler for collectionMappingReset event on parameter view model. Saves current parameter
				 * mappings, converts element into single instance mode and refreshes parameters view models.
				 * @private
				 */
				_convertElementToSingleInstanceMode: function() {
					const elementSchema = this.$ProcessElement;
					if (elementSchema instanceof BPMSoft.ProcessActivitySchema &&
							elementSchema.getIsMultiInstanceModeEnabled()) {
						this.saveExtendedValues();
						elementSchema.convertToSingleInstance();
						this.initBaseParameters(elementSchema, false);
						this.set("IsMultiInstanceMode", false);
						this.set("useBackgroundMode", false);
					}
				},

				/**
				 * Handler for collectionMappingSet event on parameter view model. Saves current parameter
				 * mappings, converts element into multi instance mode and refreshes parameters view models.
				 * @private
				 * @return {BPMSoft.ProcessSchemaParameterViewModel} Source collection parameter view model.
				 */
				_convertElementToMultiInstanceMode: function(config) {
					const elementSchema = this.$ProcessElement;
					if (elementSchema.getIsMultiInstanceModeEnabled()) {
						return null;
					}
					this.saveExtendedValues();
					elementSchema.convertToMultiInstance();
					this.initBaseParameters(elementSchema, false);
					config.parent = this.$Parameters.findByPath("$UId",
						elementSchema.multiInstanceOptions.inputCollectionParameterUId);
					this.set("IsMultiInstanceMode", elementSchema.getIsMultiInstanceModeEnabled());
					this.set("MultiInstanceExecutionModeList", Ext.create("BPMSoft.Collection"));
					this._initMultiInstanceExecutionModeDisplayValue(elementSchema.multiInstanceOptions);
					this.set("useBackgroundMode", true);
				},

				/**
				 * Closes parameter edit page if opened.
				 * @protected
				 */
				closeParameterEditPage: function(sender, value) {
					const currentParameterUId = sender.get("UId");
					const currentParameter = this.findParameterViewModel(currentParameterUId);
					if (!currentParameter) {
						return;
					}
					if (value) {
						this.set("ActiveParameterEditUId", null);
					} else {
						const previousParameterUId = this.get("ActiveParameterEditUId");
						if (previousParameterUId) {
							const parameter = this.findParameterViewModel(previousParameterUId);
							if (!parameter) {
								this.saveActiveParameterEdit();
							} else {
								parameter.set("Visible", true);
							}
						}
						this.set("ActiveParameterEditUId", currentParameterUId);
						this.set("AddParameterButtonEnabled", true);
					}
				},

				/**
				 * Recursively finds parameter view model by it's unique identifier.
				 * @protected
				 * @param {String} parameterUId Parameter unique identifier to find.
				 * @returns {BPMSoft.ProcessSchemaParameterViewModel} Found parameter or undefined.
				 */
				findParameterViewModel: function(parameterUId) {
					const parameters = this.get("Parameters");
					return this._findParameterViewModel(parameters, parameterUId);
				},

				/**
				 * @private
				 */
				_findParameterViewModel: function(parameters, parameterUId) {
					let parameter = parameters.findByPath("$UId", parameterUId);
					if (!parameter) {
						parameters.each(function(item) {
							const nestedParameter = this._findParameterViewModel(item.$ItemProperties, parameterUId);
							if (nestedParameter) {
								parameter = nestedParameter;
								return false;
							}
						}, this);
					}
					return parameter;
				},

				/**
				 * Child view model changes event handler.
				 * @protected
				 * @param {Object} config
				 */
				onChildViewModelChange: function(config) {
					if (config) {
						this.set(config.propertyName, config.propertyValue);
					}
				},

				/**
				 * Returns page ID.
				 * @return {String} Page ID.
				 */
				getParameterEditPageId: function() {
					return this.sandbox.id + "parameteredit";
				},

				/**
				 * Saves settings.
				 * @protected
				 * @virtual
				 */
				saveValues: function() {
					this.callParent(arguments);
					this.saveActiveParameterEdit();
					this.saveExtendedValues();
					const element = this.get("ProcessElement");
					if (this.get("IsLoggingVisible")) {
						element.setPropertyValue("isLogging", this.get("isLogging"));
					}
					if (this.get("IsSerializeToDBVisible")) {
						element.setPropertyValue("serializeToDB", this.get("serializeToDB"));
					}
					if (!this.get("IsExtendedMode")) {
						this.saveParameters(element);
					}
					const useBackgroundMode = this.get("useBackgroundMode");
					element.setPropertyValue("useBackgroundMode", useBackgroundMode);
					if (element.multiInstanceOptions) {
						const ignoreMultiInstanceErrors = this.get("IgnoreMultiInstanceErrors");
						element.multiInstanceOptions.setPropertyValue("ignoreErrors", ignoreMultiInstanceErrors, false);
					}
				},

				/**
				/**
				 * Saves extended parameters values.
				 * @protected
				 * @virtual
				 */
				saveExtendedValues: function() {
					var element = this.get("ProcessElement");
					var parameters = this.get("Parameters");
					parameters.each(function(model) {
						this.saveExtendedValue(model, element);
						if (model.hasItemProperties()) {
							this._saveNestedCollection(model.$ItemProperties);
						}
					}, this);
				},

				/**
				 * Saves extended parameter value.
				 * @protected
				 * @param {BPMSoft.ProcessSchemaParameterViewModel} model Parameter data model.
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @throws {BPMSoft.ItemNotFoundException} Throws an exception
				 * if the property is not found in the element.
				 */
				saveExtendedValue: function(model, element) {
					const name = model.get("Name");
					if (!model.changedValues) {
						return;
					}
					const uId = model.get("UId");
					const value = model.get("Value");
					const caption = model.get("Caption");
					const dataValueType = model.get("DataValueType");
					const direction = model.get("Direction");
					const parameter = element.parameters.find(uId);
					if (parameter) {
						parameter.setPropertyValue("name", name);
						parameter.setPropertyValue("dataValueType", dataValueType);
						parameter.setPropertyValue("direction", direction);
						parameter.setLocalizableStringPropertyValue("caption", caption);
						parameter.setMappingValue(value);
					} else {
						const template = BPMSoft.Resources.ProcessSchemaDesigner.Messages.ParameterNotFoundMessage;
						const message = Ext.String.format(template, uId);
						this.error(message);
					}
				},

				/**
				 * Saves active editing parameter.
				 * @protected
				 */
				saveActiveParameterEdit: function() {
					if (this.get("ActiveParameterEditUId")) {
						var pageId = this.getParameterEditPageId();
						this.sandbox.publish("SaveParameter", this, [pageId]);
					}
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getTabs
				 * @overridden
				 */
				getTabs: function() {
					var tabs = this.callParent(arguments);
					tabs.push({
						Name: "ParametersTab",
						Caption: resources.localizableStrings.ParametersTabCaption,
						MarkerValue: "ParametersTab"
					});
					return tabs;
				},

				/**
				 * Returns tools button delete menu item ViewModel.
				 * @private
				 * @param {String} parameterName Parameter name.
				 * @return {BPMSoft.BaseViewModel} Delete menu item ViewModel
				 */
				getParameterEditToolsButtonDeleteMenuItem: function(parameterName) {
					return this.getButtonMenuItem({
						caption: this.get("Resources.Strings.DeleteMenuItemCaption"),
						tag: parameterName,
						click: {"bindTo": "onParameterDeleteClick"}
					});
				},

				/**
				 * Processes tab change event.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} activeTab Selected tab.
				 */
				onActiveTabChange: function(activeTab) {
					this.callParent(arguments);
					var activeTabName = activeTab.get("Name");
					if (activeTabName !== "ParametersTab") {
						this.saveActiveParameterEdit();
					}
				},

				/**
				 * Handler of multi-instance execution mode config changes.
				 * @param {BPMSoft.process.constants.MultiInstanceExecutionModeConfig} executionMode multi-instance
				 * execution mode.
				 */
				onMultiInstanceExecutionModeChange: function (executionMode) {
					const oldExecutionMode = this.get("MultiInstanceExecutionModeConfig");
					const oldExecutionModeValue = oldExecutionMode ? oldExecutionMode.value : null;
					const executionModeValue = executionMode ? executionMode.value : null;
					if (oldExecutionModeValue === executionModeValue) {
						return;
					}
					this.set("MultiInstanceExecutionModeConfig", executionMode);
					const elementSchema = this.$ProcessElement;
					elementSchema.changeMultiInstanceExecutionMode(executionModeValue);
				},

				/**
				 * Returns all values for result parameter.
				 * @param {Function} callback Callback function.
				 * @param {Object} callback.resultParameterValues Key-value pair of result parameter values.
				 * @param {Object} scope Execution context of callback function.
				 */
				getResultParameterAllValues: function(callback, scope) {
					callback.call(scope, {});
				},

				/**
				 * @private
				 */
				_getDependedConditionalFlows: function() {
					var element = this.$ProcessElement;
					if (!element.parentSchema) {
						return null;
					}
					var conditionalFlows = element.parentSchema.flowElements.filterByFn(function(item) {
						return item instanceof BPMSoft.ProcessConditionalSequenceFlowSchema;
					}, this);
					var dependedFlows = conditionalFlows.filterByFn(function(item) {
						var sourceElement = item.findSourceElement();
						return sourceElement && sourceElement.uId === element.uId;
					}, this);
					return dependedFlows;
				},

				/**
				 * @private
				 */
				_validateConditonalFlow: function(elementResults, flow) {
					var flowResults = flow.processActivitiesSelectedResults;
					var hasMissingResults = _.some(flowResults, function(results) {
						return _.difference(results, elementResults).length > 0;
					}, this);
					if (hasMissingResults) {
						flow.setPropertyValue("isValid", false);
					}
				},

				/**
				 * Prepares multi-instance execution modes list.
				 * @protected
				 * @param {String} filter Filter string.
				 * @param {BPMSoft.core.collections.Collection} list Execution modes list.
				 */
				prepareMultiInstanceExecutionModeList: function (filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					list.loadAll(BPMSoft.process.constants.MultiInstanceExecutionModeConfig);
				},

				/**
				 * @private
				 * @param {BPMSoft.ProcessSchemaMultiInstanceOptions} options
				 */
				_initMultiInstanceExecutionModeDisplayValue: function (options) {
					const executionModeConfig = BPMSoft.process.constants.MultiInstanceExecutionModeConfig;
					BPMSoft.each(executionModeConfig, function (config) {
						if (config.value === options.executionMode) {
							this.set("MultiInstanceExecutionModeConfig", BPMSoft.deepClone(config));
						}
					}, this);
				},

				/**
				 * Invalidates conditional flows connected to element.
				 * @protected
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The scope of callback function.
				 */
				validateDependedConditonalFlows: function(callback, scope) {
					var flows = this._getDependedConditionalFlows();
					if (!flows || flows.isEmpty()) {
						Ext.callback(callback, scope);
						return;
					}
					this.getResultParameterAllValues(function(elementResults) {
						elementResults = _.sortBy(_.keys(elementResults));
						flows.each(this._validateConditonalFlow.bind(this, elementResults), this);
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Returns allowed collection item nesting level.
				 * @protected
				 */
				getAllowedCollectionItemNestingLevel: function(element, parameter) {
					const isMappingToFistLevelCollectionItemAllowed = element instanceof
						BPMSoft.manager.ProcessFlowElementSchema &&
						element.getIsMultiInstanceSupported() && !element.getIsMultiInstanceModeEnabled();
					const maxAllowedLevelForElement = isMappingToFistLevelCollectionItemAllowed ? 1 : 0;
					return Math.max(maxAllowedLevelForElement, parameter.getNestingLevel());
				},

				/**
				 * Returns true if process schema must be compiled.
				 * @public
				 */
				isProcessSchemaCompiled: function() {
					var element = this.get("ProcessElement");
					var parentSchema = element && element.parentSchema;
					return this.isNoCompilationFeatureEnableConverter(
						BPMSoft.isInstanceOfClass(parentSchema, "BPMSoft.ProcessSchema")
							? parentSchema.shouldBeCompiled()
							: false, false);
				},

				/**
				 * Creates process schema parameter.
				 * @protected
				 * @param {Object} parameterInfo Parameter info.
				 * @return {Object} Process schema parameter.
				 */
				createParameter: function(parameterInfo) {
					const process = this.get("ProcessElement");
					const parameter = Ext.create("BPMSoft.ProcessSchemaParameter", {
						uId: BPMSoft.generateGUID(),
						name: parameterInfo.Name,
						caption: new BPMSoft.LocalizableString(parameterInfo.Caption),
						dataValueType: parameterInfo.DataValueType.value,
						direction: parameterInfo.Direction
							? parameterInfo.Direction.value
							: BPMSoft.process.enums.ProcessSchemaParameterDirection.VARIABLE,
						isRequired: parameterInfo.IsRequired,
						processFlowElementSchema: process,
						sourceValue: {
							modifiedInSchemaUId: process.uId,
							displayValue: Ext.create("BPMSoft.LocalizableString")
						},
						createdInSchemaUId: process.uId,
						itemProperties: parameterInfo.ItemProperties
					});
					const value = parameterInfo.Value;
					const referenceSchema = parameterInfo.ReferenceSchema ? parameterInfo.ReferenceSchema.value : null;
					value.referenceSchemaUId = referenceSchema;
					parameter.setMappingValue(value);
					return parameter;
				},

				/**
				 * Returns a caption for a useBackgroundMode control.
				 * @protected
				 * @returns {String} Caption value.
				 */
				getUseBackgroundModeCaption: function() {
					return resources.localizableStrings.UseBackgroundModeCaption;
				},

				/**
				 * Determines whether user can create, edit and delete collection parameters and theirs nested
				 * parameters.
				 * @protected
				 * @returns {Boolean}
				 */
				getCanManageCollectionParameters: function() {
					return false;
				},

				/**
				 * Determines whether an AddParameterContainer should be shown or not.
				 * @protected
				 * @returns {Boolean}
				 */
				getShouldShowAddParameterContainer: function() {
					return !this.$AddParameterButtonEnabled;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"name": "ParametersTab",
					"values": {
						"wrapClass": ["tabs"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ParametersTab",
					"propertyName": "items",
					"name": "ParameterEdit",
					"values": {
						"id": "ParameterEdit",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["parameter-edit-container-wrapClass"],
						"visible": false
					}
				},
				{
					"operation": "insert",
					"parentName": "ParametersTab",
					"propertyName": "items",
					"name": "EmptyParametersMessage",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EmptyParametersMessage"
						},
						"visible": {
							"bindTo": "IsEmptyParameters"
						},
						"classes": {
							"labelClass": ["empty-parameters"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEdit",
					"propertyName": "items",
					"name": "AddParameterButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {
							"bindTo": "Resources.Strings.AddParameterButtonCaption"
						},
						"enabled": {
							"bindTo": "AddParameterButtonEnabled"
						},
						"menu": {
							"items": {
								"bindTo": "AddButtonMenu"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEdit",
					"propertyName": "items",
					"name": "AddParameterContainer",
					"values": {
						"id": "AddParameterContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "getShouldShowAddParameterContainer"
						},
						"wrapClass": ["parameter-edit-ct"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ParametersTab",
					"propertyName": "items",
					"name": "ParametersContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateHierarchicalContainerList",
						"idProperty": "ParameterEditKey",
						"onItemClick": {
							"bindTo": "onItemClick"
						},
						"nestedItemsAttributeName": "ItemProperties",
						"nestedItemsContainerId": "nested-parameters",
						"nestedContainerIdAttributeName": "UId",
						"collection": "Parameters",
						"defaultItemConfig": BPMSoft.ProcessSchemaParameterViewConfig.generate(),
						"rowCssSelector": ".paramContainer"
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "isLogging",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "IsLoggingVisible"
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "serializeToDB",
					"values": {
						"enabled": {
							"bindTo": "IsSerializeToDBEnabled"
						},
						"visible": {
							"bindTo": "IsSerializeToDBVisible"
						},
						"wrapClass": ["t-checkbox-control"],
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SettingsTab",
					"propertyName": "items",
					"name": "MultiInstanceExecutionModeConfig",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"visible": {
							"bindTo": "IsMultiInstanceMode"
						},
						"classes": {
							"wrapClassName": ["multi-instance-property-container"],
							"labelClass": ["t-title-label-proc"]
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "prepareMultiInstanceExecutionModeList"
							},
							"list": {"bindTo": "MultiInstanceExecutionModeList"},
							"change": {"bindTo": "onMultiInstanceExecutionModeChange"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SettingsTab",
					"propertyName": "items",
					"name": "IgnoreMultiInstanceErrors",
					"values": {
						"visible": {
							"bindTo": "IsMultiInstanceMode"
						},
						"wrapClass": ["t-checkbox-control"]
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
