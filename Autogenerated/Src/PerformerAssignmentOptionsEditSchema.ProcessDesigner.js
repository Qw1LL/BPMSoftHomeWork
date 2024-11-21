define("PerformerAssignmentOptionsEditSchema", ["PerformerAssignmentOptionsEditSchemaResources",
		"ProcessSchemaUserTaskUtilities", "BaseFiltersGenerateModule",
		"EntitySchemaDesignerUtilities", "MappingEditMixin", "MappingMenuBuilder"],
	function(resources, userTaskUtilities, baseFiltersGenerateModule) {
		return {
			messages: {
				/**
				 * @message GetProcessElementInfo
				 * Returns process element and package unique identifier.
				 */
				"GetProcessElementInfo": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},
				/**
				 * @message ValidateProcessElement
				 * Validates process element.
				 */
				"ValidateProcessElement": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SaveProcessElement
				 * Saves process element.
				 */
				"SaveProcessElement": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GetProcessSchema
				 * Returns process schema instance.
				 */
				"GetProcessSchema": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SetParametersInfo
				 * Sets parameters info.
				 */
				"SetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message AssignmentTypeChanged
				 * Sends when assignment type changes.
				 */
				"AssignmentTypeChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			properties: {
				/**
				 * Actions to invoke when the assignment type changes from one value to another.
				 */
				changeActions: [
					{
						from: [BPMSoft.process.enums.AssignmentType.USER,
								BPMSoft.process.enums.AssignmentType.MANAGER],
						to: [BPMSoft.process.enums.AssignmentType.ROLE],
						methodName: "_initAssigneeValueForRole"
					}, {
						from: [BPMSoft.process.enums.AssignmentType.ROLE],
						to: [BPMSoft.process.enums.AssignmentType.MANAGER,
								BPMSoft.process.enums.AssignmentType.USER],
						methodName: "_initAssigneeValueForUserOrManager"
					}
				]
			},
			attributes: {
				/**
				 * Package unique identifier.
				 */
				"PackageUId": {
					dataValueType: BPMSoft.DataValueType.TEXT,
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
				 * Performer assignment types list.
				 */
				"AssignmentTypeList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Assignment type select.
				 */
				"AssignmentTypeSelect": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * Assignment type.
				 */
				"AssignmentType": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Assignee value.
				 */
				"AssigneeValue": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * Assignee value's reference schema unique identifier.
				 */
				"AssigneeValueReferenceSchemaUId" : {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			mixins: {
				mappingEditMixin: "BPMSoft.MappingEditMixin"
			},
			methods: {

				// region Methods: Public

				/**
				 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
				 * @override
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						const sandbox = this.sandbox;
						const tags = [sandbox.id];
						const config = sandbox.publish("GetProcessElementInfo", null, tags);
						this._setAttributes(config);
						sandbox.subscribe("SaveProcessElement", this._savePerformer, this, tags);
						sandbox.subscribe("ValidateProcessElement", this._validateProcessElement, this, tags);
						this.set("AssignmentTypeList", Ext.create("BPMSoft.Collection"));
						this._initPerformer(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
				 * @override
				 */
				getParameterReferenceSchemaUId: function() {
					return this.get("AssigneeValueReferenceSchemaUId");
				},

				/**
				 * @inheritdoc BPMSoft.configuration.MenuItemsMappingMixin#getMenuItemsCollection
				 * @override
				 */
				getMenuItemsCollection: function(config) {
					this.tag = config.attributeName || this.get("Name");
					const dataValueType = BPMSoft.DataValueType.LOOKUP;
					const referenceSchemaUId = this.get("AssigneeValueReferenceSchemaUId");
					const mappingMenuBuilder = Ext.create("BPMSoft.MappingMenuBuilder", {
						_isProcessDesigner: this.getIsProcessDesigner(),
						_dataValueType: dataValueType,
						_referenceSchemaUId: referenceSchemaUId,
						_dateTimeValueType: this.getDataValueTypeForDateTimeMenuItem(dataValueType),
						_sourceColumns: this.getSourceColumns(),
						_mainRecordMappingConfig: this.getMainRecordMappingConfig()
					});
					return mappingMenuBuilder.buildMenu(config.typeMappingMenu);
				},

				/**
				 * @inheritdoc BPMSoft.configuration.EntitySchemaSelectMixin#getPackageUId
				 * @override
				 */
				getPackageUId: function() {
					return this.get("PackageUId");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("AssignmentTypeSelect", userTaskUtilities.validateSelectValue);
					this.addColumnValidator("AssigneeValue", userTaskUtilities.validateMappingValue);
				},

				// endregion

				// region Methods: Private

				/**
				 * @private
				 */
				_setAttributes: function(config) {
					this.set("PackageUId", config.packageUId);
					this.set("ProcessElement", config.processElement);
					this.set("EntitySchema", config.entitySchema);
				},

				/**
				 * @private
				 */
				_initPerformer: function(callback, scope) {
					const processElement = this.get("ProcessElement");
					const options = processElement.performerAssignmentOptions;
					if (options) {
						const assignmentType = options.assignmentType;
						this._setAssignmentTypeControlValue(assignmentType);
						this.set("AssignmentType", assignmentType, {silent: true});
						const assigneeParameterValue = this._getAssigneeParameterValue(processElement, options);
						const schemaName = assignmentType === BPMSoft.process.enums.AssignmentType.ROLE
							? "VwSysRole"
							: "Contact";
						const schemaUId = this._getReferenceSchemaUId(schemaName);
						this.set("AssigneeValueReferenceSchemaUId", schemaUId);
						this._setAssigneeControlValue(assigneeParameterValue);
						Ext.callback(callback, scope);
					} else {
						const assignmentType = BPMSoft.process.enums.AssignmentType.USER;
						this.set("AssignmentType", assignmentType, {silent: true});
						this._setAssignmentTypeControlValue(assignmentType);
						this._getDefAssigneeControlValue(processElement, function(defaultValue) {
							this._setAssigneeControlValue(defaultValue);
							Ext.callback(callback, scope);
						}, this);
					}
				},

				/**
				 * @private
				 */
				_getReferenceSchemaUId: function(schemaName) {
					return BPMSoft.EntitySchemaDesignerUtilities.getEntitySchemaUIdByName(schemaName);
				},

				/**
				 * @private
				 */
				_getPerformerParameterValue: function(processElement) {
					const performerParameter = processElement.findPerformerParameter();
					if (performerParameter && performerParameter.hasValue()) {
						return performerParameter.getMappingValue();
					}
				},

				/**
				 * @private
				 */
				_getCurrentUserContactMappingValue: function(processElement, callback, scope) {
					const macros = BPMSoft.FormulaMacros.prepareSysVariableValue(
						BPMSoft.SystemValueType.CURRENT_USER_CONTACT);
					const mappingValue = {
						value: macros.toString(),
						source: BPMSoft.ProcessSchemaParameterValueSource.Script,
						dataValueType: BPMSoft.DataValueType.LOOKUP
					};
					const value = mappingValue.value;
					const schema = processElement.parentSchema;
					const referenceSchemaUId = this._getReferenceSchemaUId("Contact");
					this.set("AssigneeValueReferenceSchemaUId", referenceSchemaUId);
					mappingValue.referenceSchemaUId = referenceSchemaUId;
					BPMSoft.FormulaParserUtils.getFormulaDisplayValue(value, schema, function(displayValue) {
						mappingValue.displayValue = displayValue;
						Ext.callback(callback, scope, [mappingValue]);
					}, this);
				},

				/**
				 * @private
				 */
				_getDefAssigneeControlValue: function(processElement, callback, scope) {
					const performerParameterValue = this._getPerformerParameterValue(processElement);
					if (performerParameterValue) {
						Ext.callback(callback, scope, [performerParameterValue]);
						return;
					}
					this._getCurrentUserContactMappingValue(processElement, callback, scope);
				},

				/**
				 * @private
				 */
				_setAssignmentTypeControlValue: function(assignmentType) {
					const config = this._getPerformerAssignmentTypeConfig(assignmentType);
					this.set("AssignmentTypeSelect", config);
				},

				/**
				 * @private
				 */
				_setAssigneeControlValue: function(value) {
					this.set("AssigneeValue", value);
				},

				/**
				 * @private
				 */
				_applyChangeAction: function(oldAssignmentType, newAssignmentType) {
					const changeAction = BPMSoft.find(this.changeActions, function(initAction) {
						return BPMSoft.contains(initAction.from, oldAssignmentType) &&
							BPMSoft.contains(initAction.to, newAssignmentType);
						}, this);
					if (changeAction) {
						this[changeAction.methodName].apply(this);
					}
				},

				/**
				 * @private
				 */
				_getAssigneeParameterValue: function(processElement, options) {
					const parameterUId = options.assignmentType === BPMSoft.process.enums.AssignmentType.ROLE
						? options.roleParameterUId
						: options.performerParameterUId;
					const parameter = processElement.findParameterByUId(parameterUId);
					return parameter.getMappingValue();
				},

				/**
				 * @private
				 */
				_savePerformer: function() {
					const processElement = this.get("ProcessElement");
					const assignmentType = this.get("AssignmentType");
					if (!Ext.isEmpty(assignmentType)) {
						const assigneeValue = this.get("AssigneeValue");
						processElement.setPerformerAssigmentOptions({
							assignmentType: assignmentType,
							assigneeValue: assigneeValue
						});
					}
				},

				/**
				 * @private
				 */
				_validateProcessElement: function() {
					this.validate();
					const validationInfo = this.validationInfo.get("AssigneeValue");
					return [validationInfo];
				},

				/**
				 * @private
				 */
				_preparePerformerAssignmentTypesList: function(filter, list) {
					if (!list) {
						return;
					}
					const assignmentTypes = this._getPerformerAssignmentTypesConfig();
					list.clear();
					list.loadAll(assignmentTypes);
				},

				/**
				 * @private
				 */
				_getPerformerAssignmentTypeConfig: function(type) {
					const assignmentTypeCaption = Ext.String.format("AssignmentType{0}Caption", type);
					return {
						value: type,
						displayValue: resources.localizableStrings[assignmentTypeCaption]
					};
				},

				/**
				 * @private
				 */
				_getAllowedAssignmentTypes: function() {
					return [
						BPMSoft.process.enums.AssignmentType.USER,
						BPMSoft.process.enums.AssignmentType.MANAGER,
						BPMSoft.process.enums.AssignmentType.ROLE
					];
				},

				/**
				 * @private
				 */
				_getPerformerAssignmentTypesConfig: function() {
					const assignmentTypes = BPMSoft.process.enums.AssignmentType;
					const assignmentTypesConfig = Ext.create("BPMSoft.Collection");
					const allowedAssignmentTypes = this._getAllowedAssignmentTypes();
					BPMSoft.each(assignmentTypes, function(type) {
						if (BPMSoft.contains(allowedAssignmentTypes, type)) {
							const config = this._getPerformerAssignmentTypeConfig(type);
							assignmentTypesConfig.add(type, config);
						}
					}, this);
					return assignmentTypesConfig;
				},

				/**
				 * @private
				 */
				_getAllUsersFilter: function() {
					return baseFiltersGenerateModule.AllUsersFilter();
				},

				/**
				 * @private
				 */
				_applyMappingWindowConfig: function(assignmentType) {
					const column = this.columns["AssigneeValue"];
					let mappingWindowConfig = null;
					if (assignmentType !== BPMSoft.process.enums.AssignmentType.ROLE) {
						mappingWindowConfig = {
							filterMethod: "_getAllUsersFilter"
						};
					}
					column.mappingWindowConfig = mappingWindowConfig;
				},

				/**
				 * @private
				 */
				_setAssignmentType: function(assignmentType) {
					this.set("AssignmentType", assignmentType);
					this.sandbox.publish("AssignmentTypeChanged", assignmentType, [this.sandbox.id]);
					this._applyMappingWindowConfig(assignmentType);
				},

				/**
				 * @private
				 */
				_onPerformerAssignmentTypeChanged: function(value) {
					const oldAssignmentType = this.get("AssignmentType");
					const newAssignmentType = value ? value.value : null;
					if (Ext.isEmpty(oldAssignmentType) && !Ext.isEmpty(newAssignmentType)) {
						this._setAssignmentType(newAssignmentType);
						return;
					}
					if (oldAssignmentType === newAssignmentType || Ext.isEmpty(newAssignmentType)) {
						return;
					}
					this._applyChangeAction(oldAssignmentType, newAssignmentType);
					this._setAssignmentType(newAssignmentType);
				},

				/**
				 * @private
				 */
				_getMappingControlCaption: function() {
					const assignmentType = this.get("AssignmentType");
					const localizableStrings = resources.localizableStrings;
					const resourceName = Ext.String.format("AssignmentType{0}LabelCaption", assignmentType);
					return localizableStrings[resourceName];
				},
				/**
				 * @private
				 */
				_initAssigneeValueForRole: function() {
					const uId = this._getReferenceSchemaUId("VwSysRole");
					this.set("AssigneeValueReferenceSchemaUId", uId);
					this._setAssigneeControlValue({
						value: null,
						displayValue: null,
						source: BPMSoft.ProcessSchemaParameterValueSource.None,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						referenceSchemaUId: uId
					});
				},

				/**
				 * @private
				 */
				_initAssigneeValueForUserOrManager: function() {
					const processElement = this.get("ProcessElement");
					this._getCurrentUserContactMappingValue(processElement, function(defaultValue) {
						this._setAssigneeControlValue(defaultValue);
					}, this);
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "PerformerAssignmentContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"name": "AssignmentTypeSelect",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "_preparePerformerAssignmentTypesList" },
							"change": { "bindTo": "_onPerformerAssignmentTypeChanged" },
							"list": { "bindTo": "AssignmentTypeList" }
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": true
					}
				},
				{
					"operation": "insert",
					"name": "AssignmentTypeLabel",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "_getMappingControlCaption" },
						"classes": {
							"labelClass": ["t-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AssignmentTypeValue",
					"parentName": "PerformerAssignmentContainer",
					"propertyName": "items",
					"values": {
						"id": "AssigneeValue",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.MappingEdit",
						"tag": {
							"attributeName": "AssigneeValue"
						},
						"value": {
							"bindTo": "AssigneeValue"
						},
						"openEditWindow": {
							"bindTo": "openExtendedMappingEditWindow"
						},
						"prepareMenu": {
							"bindTo": "onPrepareMenu"
						},
						"menu": {
							"items": {
								"bindTo": "MenuItems"
							}
						},
						"cleariconclick": "$onClearIconClick"
					}
				}
			]/**SCHEMA_DIFF*/
		};
});
