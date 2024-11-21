/**
 * Parent: RootUserTaskPropertiesPage
 */
define("BaseUserTaskPropertiesPage", ["BPMSoft", "BaseUserTaskPropertiesPageResources",
	"PerformerAssignmentOptionsEditSchema", "ProcessUserTaskActivityEditSchema"
], function(BPMSoft) {
	return {
			messages: {
				/**
				 * @message AssignmentTypeChanged
				 * Sends when assignment type changes.
				 */
				"AssignmentTypeChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {},
			attributes: {
				/**
				 * Recommendation.
				 * @type {Object}
				 */
				"Recommendation": {
					dataValueType: this.BPMSoft.DataValueType.MAPPING,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "_initRecommendation",
					isRequired: true,
					doAutoSave: true
				},
				/**
				 * Show execution page.
				 * @type {Boolean}
				 */
				"ShowExecutionPage": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true,
					initMethod: "_initShowExecutionPage"
				},
				/**
				 * Owner identifier.
				 * @type {Guid}
				 */
				"OwnerId": {
					dataValueType: this.BPMSoft.DataValueType.MAPPING,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					referenceSchemaName: "Contact",
					parameterBindConfig: {
						onInit: "_initOwner",
						onSave: "_saveOwner"
					}
				},
				/**
				 * Information on step.
				 * @type {String}
				 */
				"InformationOnStep": {
					dataValueType: this.BPMSoft.DataValueType.MAPPING,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true,
					initMethod: "initProperty"
				},
				/**
				 * Assignment type.
				 * @type {BPMSoft.process.enums.AssignmentType}
				 */
				"AssignmentType": {
					dataValueType: this.BPMSoft.DataValueType.ENUM,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Determines whether to create activity or not.
				 * @type {Boolean}
				 */
				"CreateActivity": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc RootUserTaskPropertiesPage#init
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						BPMSoft.chain(
							this._initEntitySchemaManager,
							this._initAssignmentType,
							function() {
								const moduleIds = this.getModuleIds();
								this.sandbox.subscribe("AssignmentTypeChanged", this._onChangeAssignmentType, this, moduleIds);
								Ext.callback(callback, scope);
							}, this);
					}, this]);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						this._initCreateActivityValue();
						Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * Determines whether the optional process activities is supported by the user task or not.
				 * @returns {Boolean}
				 */
				getIsOptionalActivitySupported: function() {
					return BPMSoft.Features.getIsEnabled("UseOptionalProcessUserTaskActivities");
				},

				/**
				 * Determines whether the process activity module is enabled or not.
				 * @returns {boolean}
				 */
				getIsActivityModuleEnabled: function() {
					return this.getIsOptionalActivitySupported() && this.get("CreateActivity");
				},

				/**
				 * Determines whether the process activity module is disabled or not.
				 * @returns {boolean}
				 */
				getIsActivityModuleDisabled: function() {
					return !this.getIsActivityModuleEnabled();
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
				 * @protected
				 * @overridden
				 */
				initParameters: function(processElement) {
					this.callParent(arguments);
				},

				/**
				 * Determines whether an element supports technical activity or not.
				 * @returns {Boolean}
				 */
				getSupportsTechnicalActivity: function() {
					return true;
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
				 * @protected
				 * @overridden
				 */
				saveValues: function() {
					this.callParent(arguments);
					this._saveCreateActivityValue();
					this._saveProcessElement();
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("*", this._validateProcessElement);
				},

				//endregion

				//region Methods: Private

				/**
				 * @private
				 */
				_initShowExecutionPage: function(parameter) {
					const parameterName = parameter.name;
					const sourceValue = parameter.sourceValue;
					let value = sourceValue.value;
					value = value.toLowerCase() === "true"
					this.set(parameterName, value);
				},

				/**
				 * @private
				 */
				_initEntitySchemaManager: function(callback, scope) {
					if (this.getIsPerformerAssignmentEnabled()) {
						BPMSoft.EntitySchemaManager.initialize(callback, scope);
					} else {
						Ext.callback(callback, scope);
					}
				},

				/**
				 * @private
				 */
				_initAssignmentType: function(callback, scope) {
					const processElement = this.get("ProcessElement");
					const options = processElement.performerAssignmentOptions;
					const assignmentType = options
						? options.assignmentType
						: BPMSoft.process.enums.AssignmentType.USER;
					this.set("AssignmentType", assignmentType);
					Ext.callback(callback, scope);
				},

				/**
				 * @private
				 */
				_onChangeAssignmentType: function(newAssignmentType) {
					const oldAssignmentType = this.get("AssignmentType");
					this.set("AssignmentType", newAssignmentType);
					const isNeedToChangeShowExecutionPageValue =
						newAssignmentType === BPMSoft.process.enums.AssignmentType.USER ||
							oldAssignmentType === BPMSoft.process.enums.AssignmentType.USER;
					const newShowExecutionPage = this.getIsPerformerAssignmentDisabled() ||
						newAssignmentType === BPMSoft.process.enums.AssignmentType.USER;
					if (isNeedToChangeShowExecutionPageValue) {
						this.set("ShowExecutionPage", newShowExecutionPage);
					}
				},

				/**
				 * @private
				 */
				_getIsShowExecutionPageEnabled: function() {
					return this.getIsPerformerAssignmentDisabled() ||
						this.get("AssignmentType") === BPMSoft.process.enums.AssignmentType.USER;
				},

				/**
				 * @private
				 */
				_setOwnerIdColumnRequired: function(isRequired) {
					if (BPMSoft.isEmpty(this.columns.OwnerId.isRequired)) {
						this.columns.OwnerId.isRequired = isRequired;
					}
				},

				/**
				 * @private
				 */
				_initOwner: function(parameter) {
					if (!parameter) {
						return;
					}
					const mappingValue = parameter.getMappingValue();
					const element = this.get("ProcessElement");
					const isNotPerformerAssignment = this.getIsPerformerAssignmentDisabled();
					this._setOwnerIdColumnRequired(isNotPerformerAssignment);
					if (!mappingValue.value && isNotPerformerAssignment) {
						mappingValue.value = this.getCurrentUserContactMappingValue();
						mappingValue.source = BPMSoft.ProcessSchemaParameterValueSource.Script;
						const value = mappingValue.value;
						const schema = element.parentSchema;
						BPMSoft.FormulaParserUtils.getFormulaDisplayValue(value, schema, function(displayValue) {
							mappingValue.displayValue = displayValue;
							this.set("OwnerId", mappingValue);
						}, this);
					} else {
						this.set("OwnerId", mappingValue);
					}
				},

				/**
				 * @private
				 */
				_saveOwner: function(ownerParameter) {
					if (this.getIsPerformerAssignmentDisabled() && ownerParameter) {
						this.saveParameter(ownerParameter);
					}
				},

				/**
				 * @private
				 */
				_moduleIdFilter: function(moduleIds) {
					const activityEditModuleId = this.getModuleId("ActivityEditModule");
					return this.getIsActivityModuleEnabled()
						? moduleIds
						: BPMSoft.filter(moduleIds, (moduleId) => moduleId !== activityEditModuleId, this);
				},

				/**
				 * @private
				 */
				_saveProcessElement: function() {
					if (!this.get("IsExtendedMode")) {
						this.postMessageToModules("SaveProcessElement", this._moduleIdFilter);
					}
				},

				/**
				 * @private
				 */
				_validateProcessElement: function() {
					const validationResults = this.postMessageToModules("ValidateProcessElement", this._moduleIdFilter);
					validationResults.forEach(validationResult => this.addCustomValidationResult(validationResult));
					return {
						invalidMessage: ""
					};
				},

				/**
				 * @private
				 */
				_initRecommendation: function(parameter) {
					const processElement = this.get("ProcessElement");
					const mappingValue = parameter.getMappingValue();
					if (!mappingValue.value) {
						const caption = processElement.caption.getValue();
						mappingValue.value = caption;
						mappingValue.displayValue = caption;
						mappingValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
						const sourceValue = {
							value: caption,
							displayValue: caption,
							source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
						};
						parameter.setMappingValue(sourceValue);
					}
					this.set("Recommendation", mappingValue);
				},

				/**
				 * @private
				 */
				_getCreateActivityParameter: function() {
					const element = this.get("ProcessElement");
					return element.findParameterByName("CreateActivity");
				},

				/**
				 * @private
				 */
				_initCreateActivityValue: function() {
					if (!this.getIsOptionalActivitySupported()) {
						return;
					}
					const parameter = this._getCreateActivityParameter();
					if (parameter) {
						this.initProperty(parameter);
					}
				},

				/**
				 * @private
				 */
				_saveCreateActivityValue: function() {
					if (!this.getIsOptionalActivitySupported()) {
						return;
					}
					const parameter = this._getCreateActivityParameter();
					if (parameter) {
						this.saveParameter(parameter);
					}
				}

				//endregion

			},
			modules: {
				"PerformerAssignmentModule": {
					"config": {
						"schemaName": "PerformerAssignmentOptionsEditSchema",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"showMask": true
					}
				},
				"ActivityEditModule": {
					"config": {
						"schemaName": "ProcessUserTaskActivityEditSchema",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"showMask": true
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "UserTaskContainer",
					"propertyName": "items",
					"parentName": "EditorsContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TitleTaskContainer",
					"propertyName": "items",
					"parentName": "UserTaskContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "RecommendationLabel",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.RecommendationCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "PerformerAssignmentContainer",
					"parentName": "UserTaskContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 1, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OwnerRegionLabel",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.OwnerRegionCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "OwnerId",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": { "bindTo": "getIsPerformerAssignmentDisabled" }
					}
				},
				{
					"operation": "insert",
					"name": "PerformerAssignmentModule",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"items": [],
						"visible": { "bindTo": "getIsPerformerAssignmentEnabled" }
					}
				},
				{
					"operation": "insert",
					"name": "ShowExecutionPage",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ShowExecutionPageCaption" },
						"wrapClass": ["t-checkbox-control"],
						"visible": true,
						"enabled": { "bindTo": "_getIsShowExecutionPageEnabled" }
					}
				},
				{
					"operation": "insert",
					"name": "ActivityControlsContainer",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 2, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CreateActivity",
					"parentName": "ActivityControlsContainer",
					"propertyName": "items",
					"values": {
						"caption": { "bindTo": "Resources.Strings.CreateActivityCaption" },
						"wrapClass": ["t-checkbox-control"],
						"visible": { "bindTo": "getIsOptionalActivitySupported"}
					}
				},
				{
					"operation": "insert",
					"name": "ActivityEditModule",
					"parentName": "ActivityControlsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"items": [],
						"visible": { "bindTo": "getIsActivityModuleEnabled" }
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
