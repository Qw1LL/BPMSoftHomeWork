/**
 * Page schema for edit process parameter properties.
 */
define("ProcessSchemaParameterEditPage", ["BPMSoft", "ProcessSchemaParameterEditPageResources",
		"css!ProcessSchemaParameterEditModule", "MappingEditMixin"],
	function(BPMSoft, resources) {
		return {
			mixins: {
				mappingEdit: "BPMSoft.MappingEditMixin"
			},
			attributes: {
				/**
				 * Parameter identifier.
				 */
				"UId": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Parameter name.
				 */
				"Name": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.CodeCaption,
					isRequired: true
				},
				/**
				 * Parameter caption.
				 */
				"Caption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.TitleCaption,
					isRequired: true
				},
				/**
				 * Reference schema.
				 */
				"ReferenceSchema": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isLookup: true,
					referenceSchemaName: "VwSysEntitySchemaInWorkspace",
					dependencies: [{
						columns: ["ParameterDataValueTypeConfig"],
						methodName: "onParameterDataValueTypeConfigChange"
					}],
					caption: resources.localizableStrings.LookupCaption
				},
				/**
				 * Flag that indicates visibility of ReferenceSchema.
				 */
				"ReferenceSchemaVisible": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Flag that indicates enabled for page editors.
				 */
				"IsEnabled": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Flag that indicates is ViewModel changed.
				 */
				"IsChanged": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Parameter dataValueType.
				 */
				"ParameterDataValueTypeConfig": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.DataValueTypeCaption,
					isRequired: true
				},
				/**
				 * Parameter value.
				 */
				"Value": {
					dataValueType: this.BPMSoft.DataValueType.MAPPING,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.ValueCaption
				},
				/**
				 * DataValueType list.
				 */
				"DataValueTypeList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Parameter direction.
				 */
				"DirectionConfig": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.DirectionCaption,
					isRequired: true
				},
				/**
				 * Direction list.
				 */
				"DirectionList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Process element.
				 */
				"ProcessElement": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * The unique identifier of the package.
				 */
				"packageUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Flag that indicates whether SaveButton is enabled or not.
				 */
				"ShowSaveButton": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Parent parameter uId.
				 */
				"ParentUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Invoker uId.
				 */
				"InvokerUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}

			},
			messages: {
				/**
				 * @message GetParametersInfo
				 * Send process parameter value to mapping window.
				 */
				"GetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SetParametersInfo
				 * Save process parameter mapping value.
				 */
				"SetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SaveParameterInfo
				 * Save process parameter properties.
				 */
				"SaveParameterInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message DiscardParameterInfoChanges
				 * Discard parameter properties.
				 */
				"DiscardParameterInfoChanges": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message LookupInfo
				 * Send lookup info into Lookup page.
				 */
				"LookupInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SaveParameter
				 * Message for save parameter from parent module.
				 */
				"SaveParameter": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
				 * @override
				 */
				getParameterReferenceSchemaUId: function() {
					var referenceSchema = this.get("ReferenceSchema");
					return referenceSchema ? referenceSchema.value : null;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function(callback, scope) {
					this.setValidationConfig();
					this.initParameters();
					this.initReferenceSchema(function() {
						this.isParameterEditInitialized = true;
						this.subscribeMessages();
						this.onPageInitialized(callback, scope);
					}, this);
					this.on("change:Value", this.onMappingValueChanged, this);
				},

				/**
				 * @inheritdoc MappingEditMixin#getInvokerUId
				 * @override
				 */
				getInvokerUId: function() {
					return this.get("InvokerUId") || this.get("UId");
				},

				/**
				 * @inheritdoc MappingEditMixin#clearNestedValues
				 * @override
				 */
				clearNestedValues: BPMSoft.emptyFn,

				/**
				 * @inheritdoc MappingEditMixin#tryClearParentValue
				 * @override
				 */
				tryClearParentValue: BPMSoft.emptyFn,

				/**
				 * @inheritdoc MappingEditMixin#setParentMappingEditValue
				 * @override
				 */
				setParentMappingEditValue: function(sourceValue, callback, scope) {
					Ext.callback(callback, scope);
				},

				/**
				 * On mapping value change event handler. Activates save button.
				 * @private
				 */
				onMappingValueChanged: function() {
					this.set("ShowSaveButton", true);
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @override
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Name", this.nameValidator);
					this.addColumnValidator("Name", this.duplicateValueValidator);
					this.addColumnValidator("Caption", this.duplicateValueValidator);
					this.addColumnValidator("ReferenceSchema", this.referenceSchemaRequiredValidator);
				},

				/**
				 * Initializes parameter lookup schema name.
				 */
				initReferenceSchema: function(callback, scope) {
					var dataValueType = this.get("ParameterDataValueTypeConfig") || {};
					dataValueType = dataValueType.value;
					var isReferenceSchemaVisible = dataValueType === BPMSoft.DataValueType.LOOKUP;
					this.set("ReferenceSchemaVisible", isReferenceSchemaVisible);
					this.columns.ReferenceSchema.isRequired = isReferenceSchemaVisible;
					var referenceSchema = this.get("ReferenceSchema");
					if (isReferenceSchemaVisible && referenceSchema && referenceSchema.value) {
						this.initializeLookupSchema(referenceSchema.value, function(referenceSchema) {
							this.set("ReferenceSchema", referenceSchema);
							callback.call(scope);
						}, this);
						return;
					}
					callback.call(scope);
				},

				/**
				 * Handles change the data model.
				 * @override
				 */
				onDataChange: function() {
					this.callParent(arguments);
					if (this.isParameterEditInitialized) {
						this.set("IsChanged", true);
					}
				},

				/**
				 * Called after the initialization scheme.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 */
				onPageInitialized: function(callback, scope) {
					this._loadAllLazyPropertiesIfRequired(callback, scope || this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseModel#validate
				 * @override
				 */
				validate: function() {
					return this.callParent(arguments) && this._validateDataValueTypeChange();
				},

				//endregion

				//region Methods: Private

				/**
				 * Executes system name validation info.
				 * @private
				 * @param {String} value Parameter name.
				 * @return {Object} Validation info.
				 */
				nameValidator: function(value) {
					var message = "";
					var reqExp = /^[a-zA-Z]{1}[a-zA-Z0-9_]*$/;
					if (!reqExp.test(value)) {
						message = this.get("Resources.Strings.WrongParameterNameMessage");
					}
					return {invalidMessage: message};
				},

				/**
				 * Executes duplicate value validation info.
				 * @private
				 * @param {String} value Changed value.
				 * @param {Object} attribute Attribute.
				 * @param {String} attribute.name Attribute name.
				 * @return {Object} Validation info.
				 */
				duplicateValueValidator: function(value, attribute) {
					var message = "";
					var attributeName = attribute.name;
					var isEditEnabled = this.get("IsEnabled");
					if (isEditEnabled) {
						var parameters = this.get("Parameters");
						var filteredParameters = parameters.filterByFn(function(parameter) {
							return parameter.get(attributeName) === value;
						}, this);
						var parameter = filteredParameters.first();
						if (parameter) {
							if (parameter.get("UId") !== this.get("UId")) {
								message = this.get("Resources.Strings.DuplicateParameter" + attributeName + "Message");
							}
						} else if (attributeName === "Name") {
							var processElement = this.getProcessElement();
							var processSchema = processElement.parentSchema || processElement;
							var flowElement = processSchema.flowElements.findByFn(function(element) {
								return element.getName() === value;
							}, this);
							if (flowElement) {
								message = this.get("Resources.Strings.DuplicateElementNameMessage");
							}
						}
					}
					return {invalidMessage: message};
				},

				/**
				 * Executes reference schema validation info.
				 * @private
				 * @param {Object} referenceSchema Changed value.
				 * @param {Object} attribute Attribute.
				 * @param {String} attribute.name Attribute name.
				 * @return {Object} Validation info.
				 */
				referenceSchemaRequiredValidator: function(referenceSchema, attribute) {
					var value = referenceSchema && referenceSchema.value;
					return this.requiredValidator(value, attribute);
				},

				/**
				 * Initializes parameters.
				 * @private
				 */
				initParameters: function() {
					this.initDesignerType();
					this.set("DataValueTypeList", Ext.create("BPMSoft.Collection"));
					this.set("DirectionList", Ext.create("BPMSoft.Collection"));
					this.initDataValueTypeDisplayValue();
					this._initDirectionDisplayValue();
				},

				/**
				 * Initializes Data type display value.
				 * @private
				 */
				initDataValueTypeDisplayValue: function() {
					var dataValueType = this.get("ParameterDataValueTypeConfig");
					if (dataValueType && Ext.isNumber(dataValueType.value)) {
						var value = dataValueType.value;
						var dataValueTypeConfig = BPMSoft.data.constants.DataValueTypeConfig;
						BPMSoft.each(dataValueTypeConfig, function(typeConfig) {
							if (typeConfig.value === value) {
								this.set("ParameterDataValueTypeConfig", BPMSoft.deepClone(typeConfig));
								this.set("DataValueType", typeConfig.value);
							}
						}, this);
					}
				},

				/**
				 * Initializes Direction display value.
				 * @private
				 */
				_initDirectionDisplayValue: function () {
					const direction = this.get("DirectionConfig");
					if (direction && Ext.isNumber(direction.value)) {
						const value = direction.value;
						const directionConfig = BPMSoft.process.constants.ParameterDirectionConfig;
						BPMSoft.each(directionConfig, function (config) {
							if (config.value === value) {
								this.set("DirectionConfig", BPMSoft.deepClone(config));
							}
						}, this);
					}
				},

				/**
				 * Subscribes messages.
				 * @private
				 */
				subscribeMessages: function() {
					this.sandbox.subscribe("SaveParameter", this.saveParameter, this, [this.sandbox.id]);
				},

				/**
				 * Handles a click on the "Save" button.
				 * @private
				 */
				onSaveClick: function() {
					this.saveParameter();
				},

				/**
				 * Saves parameter.
				 * @private
				 * @return {Boolean} Parameter is saved.
				 */
				saveParameter: function() {
					var isValid = this.validate();
					if (!isValid) {
						return false;
					}
					var sandbox = this.sandbox;
					var data = {
						UId: this.get("UId"),
						Name: this.get("Name"),
						Caption: this.get("Caption"),
						DataValueType: this.get("ParameterDataValueTypeConfig"),
						Direction: this.get("DirectionConfig"),
						ReferenceSchema: this.get("ReferenceSchema") || {},
						Value: this.get("Value"),
						CanAssignSourceValue: this.get("CanAssignSourceValue"),
						ParentUId: this.get("ParentUId")
					};
					this.sandbox.publish("SaveParameterInfo", data, [sandbox.id]);
					return true;
				},

				/**
				 * Fires message "DiscardParameterInfoChanges" into base page.
				 * @private
				 */
				discardChanges: function() {
					var sandbox = this.sandbox;
					sandbox.publish("DiscardParameterInfoChanges", this.get("Name"), [sandbox.id]);
				},

				/**
				 * Handles DiscardChanges button click.
				 * @private
				 */
				onDiscardChangesClick: function() {
					this.discardChanges();
				},

				/**
				 * Initializes Data type list.
				 * @private
				 * @param {String} filter Filter string.
				 * @param {BPMSoft.core.collections.Collection} list Data type list.
				 */
				prepareDataValueTypeList: function(filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					var sortedList = Ext.create("BPMSoft.Collection");
					sortedList.loadAll(BPMSoft.data.constants.DataValueTypeConfig);
					sortedList.removeByKey("LOCALIZABLE_STRING");
					sortedList.sort("displayValue", BPMSoft.OrderDirection.ASC);
					list.loadAll(sortedList);
				},

				/**
				 * Initializes Parameter Direction list.
				 * @private
				 * @param {String} filter Filter string.
				 * @param {BPMSoft.core.collections.Collection} list Direction list.
				 */
				_prepareParameterDirectionList: function (filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					list.loadAll(BPMSoft.process.constants.ParameterDirectionConfig);
				},

				/**
				 * Handler of parameter data value type config changes.
				 * @param {BPMSoft.DataValueType} dataValueType Data type.
				 */
				onParameterDataValueTypeConfigChange: function(dataValueType) {
					var oldDataValueType = this.get("ParameterDataValueTypeConfig");
					var oldDataValueTypeValue = oldDataValueType ? oldDataValueType.value : null;
					var dataValueTypeValue = dataValueType ? dataValueType.value : null;
					if (oldDataValueTypeValue === dataValueTypeValue) {
						return;
					}
					this.set("DataValueType", dataValueType);
					var isLookup = dataValueTypeValue === BPMSoft.DataValueType.LOOKUP;
					this.set("ReferenceSchemaVisible", isLookup);
					this.set("ReferenceSchema", null);
					this.columns.ReferenceSchema.isRequired = isLookup;
					var oldValue = this.get("Value") || {};
					this.set("Value", {
						value: null,
						displayValue: null,
						source: BPMSoft.ProcessSchemaParameterValueSource.None,
						referenceSchemaUId: oldValue.referenceSchemaUId,
						dataValueType: dataValueTypeValue
					});
				},

				/**
				 * Handler of parameter direction type config changes.
				 * @param {BPMSoft.process.constants.ParameterDirectionConfig} direction config.
				 */
				onParameterDirectionConfigChange: function (direction) {
					const oldDirection = this.get("DirectionConfig");
					const oldDirectionValue = oldDirection ? oldDirection.value : null;
					const directionValue = direction ? direction.value : null;
					if (oldDirectionValue === directionValue) {
						return;
					}
					this.set("DirectionConfig", direction);
				},

				/**
				 * Reference schema change handler.
				 * @private
				 * @param {Object} referenceSchema Reference schema object.
				 */
				onReferenceSchemaChange: function(referenceSchema) {
					var currentValue = this.get("Value");
					var currentReferenceSchemaUId = currentValue ? currentValue.referenceSchemaUId : null;
					currentValue = {
						source: BPMSoft.ProcessSchemaParameterValueSource.None,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						value: null,
						displayValue: null,
						referenceSchemaUId: null
					};
					if (referenceSchema) {
						var newReferenceSchemaUId = referenceSchema.value;
						if (currentReferenceSchemaUId === newReferenceSchemaUId) {
							return;
						}
						currentValue.referenceSchemaUId = newReferenceSchemaUId;
					}
					this.set("Value", currentValue);
				},

				/**
				 * @inheritdoc MappingEditMixin#setMappingEditValue
				 * @override
				 */
				setMappingEditValue: function(parameterName, sourceValue, options) {
					this.mixins.mappingEdit.setMappingEditValue.call(this, parameterName, sourceValue, options);
				},

				/**
				 * @private
				 */
				getIsDirectionVisible: function() {
					return !Boolean(this.$ParentUId);
				},

				/**
				 * @private
				 */
				_loadAllLazyPropertiesIfRequired: function(callback, scope) {
					if (!this._getIsDataValueTypeValidationRequired()) {
						callback.call(scope);
						return;
					}
					const process = this.getProcessElement();
					BPMSoft.ProcessSchemaDesignerUtilities.validateAllLazyPropertiesAreLoaded(process, callback, scope);
				},

				/**
				 * @private
				 */
				_getIsDataValueTypeValidationRequired: function() {
					const process = this.getProcessElement();
					return process instanceof BPMSoft.ProcessSchema;
				},

				/**
				 * @private
				 */
				_validateDataValueTypeChange: function() {
					if (!this._getIsDataValueTypeValidationRequired()) {
						return true;
					}
					const dataValueTypeConfig = this.get("ParameterDataValueTypeConfig");
					const config = {
						schema: this.getProcessElement(),
						parameterUId: this.get("UId"),
						newDataValueType: dataValueTypeConfig && dataValueTypeConfig.value
					};
					return BPMSoft.ProcessSchemaDesignerUtilities.validateCanChangeParameterDataValueType(config);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ParameterEdit",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ParameterEditContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["parameter-edit-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"name": "Caption",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"value": {"bindTo": "Caption"},
						"isRequired": true,
						"enabled": {"bindTo": "IsEnabled"},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"wrapClass": ["parameter-edit-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"value": {"bindTo": "Name"},
						"isRequired": true,
						"enabled": {"bindTo": "IsEnabled"},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"wrapClass": ["parameter-edit-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"name": "ParameterDataValueTypeConfig",
					"values": {
						"itemType": BPMSoft.ContentType.ENUM,
						"isRequired": true,
						"enabled": {"bindTo": "IsEnabled"},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "prepareDataValueTypeList"
							},
							"list": {"bindTo": "DataValueTypeList"},
							"change": {"bindTo": "onParameterDataValueTypeConfigChange"}
						},
						"wrapClass": ["parameter-edit-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"name": "ReferenceSchema",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"value": {"bindTo": "ReferenceSchema"},
						"enabled": {"bindTo": "IsEnabled"},
						"visible": {"bindTo": "ReferenceSchemaVisible"},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"isRequired": true,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareEntityList"
							},
							"change": {"bindTo": "onReferenceSchemaChange"},
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
						},
						"wrapClass": ["parameter-edit-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"name": "DirectionConfig",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"isRequired": true,
						"enabled": {"bindTo": "IsEnabled"},
						"visible": {"bindTo": "getIsDirectionVisible"},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "_prepareParameterDirectionList"
							},
							"list": {"bindTo": "DirectionList"},
							"change": {"bindTo": "onParameterDirectionConfigChange"}
						},
						"wrapClass": ["parameter-edit-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"name": "Value",
					"values": {
						"itemType": BPMSoft.ViewItemType.MAPPING,
						"value": { "bindTo": "Value" },
						"enabled": { "bindTo": "CanAssignSourceValue" },
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"controlConfig": {
							"placeholder": {"bindTo": "Resources.Strings.ValuePlaceHolderCaption"},
							"cleariconclick": {"bindTo": "onClearIconClick"}
						},
						"wrapClass": ["parameter-edit-control", "placeholderOpacity"]
					}
				},
				{
					"operation": "insert",
					"name": "Actions",
					"parentName": "ParameterEditContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["actions-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "Actions",
					"propertyName": "items",
					"name": "DiscardChangesButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
						"click": {"bindTo": "onDiscardChangesClick"},
						"styles": {
							"textStyle": {
								"margin-left": "10px"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Actions",
					"propertyName": "items",
					"name": "SaveButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
						"click": {"bindTo": "onSaveClick"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"enabled": {"bindTo": "ShowSaveButton"},
						"tag": "save",
						"markerValue": "SaveButton"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
