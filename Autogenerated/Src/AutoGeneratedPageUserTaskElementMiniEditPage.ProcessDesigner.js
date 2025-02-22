﻿/**
 * Parent: BaseProcessMiniEditPage
 */
define("AutoGeneratedPageUserTaskElementMiniEditPage", ["BPMSoft",
		"AutoGeneratedPageUserTaskElementMiniEditPageResources", "ProcessUserTaskConstants", "BusinessRuleModule",
		"MappingEditMixin", "EntitySchemaSelectMixin"],
	function(BPMSoft, resources, processUserTaskConstants, businessRuleModule) {
		return {
			mixins: {
				mappingEdit: "BPMSoft.MappingEditMixin",
				entitySchemaSelectMixin: "BPMSoft.EntitySchemaSelectMixin"
			},
			messages: {
				/**
				 * @message GetParametersInfo
				 * Pass parameter values.
				 */
				"GetParametersInfo": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SetParametersInfo
				 * Specifies parameter values.
				 */
				"SetParametersInfo": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Control edit type of page element.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"ControlEditType": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Title of page element.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Caption": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.CaptionCaption,
					"isRequired": true
				},
				/**
				 * Code of page element.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Name": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.NameCaption,
					"isRequired": true
				},
				/**
				 * Text of page element.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Text": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.TextCaption
				},
				/**
				 * Multiline flag of page element.
				 * @type {BPMSoft.dataValueType.BOOLEAN}
				 */
				"IsMultiline": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.IsMultilineCaption
				},
				/**
				 * Required flag of page element.
				 * @type {BPMSoft.dataValueType.BOOLEAN}
				 */
				"IsRequiredField": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.IsRequiredCaption
				},
				/**
				 * Minimized flag of page element.
				 * @type {BPMSoft.dataValueType.BOOLEAN}
				 */
				"Minimized": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.MinimizedCaption
				},
				/**
				 * Data source flag of page element.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				"DataSource": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.DataSourceCaption
				},
				/**
				 * Control view type of lookup page element.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				"ControlDataValueType": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.ControlDataValueTypeCaption
				},
				/**
				 * Date time format.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				"DateTimeFormat": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.DateTimeFormatCaption
				},
				/**
				 * Value property of page element.
				 * @type {BPMSoft.dataValueType.MAPPING}
				 */
				"Value": {
					"dataValueType": this.BPMSoft.DataValueType.MAPPING,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.ValueCaption,
					"onChange": "onMappingValueChanged"
				},
				/**
				 * Parent view model's collection.
				 * @type {BPMSoft.dataValueType.COLLECTION}
				 */
				"ParentCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				//region Methods: Public

				/**
				 * @inheritdoc MappingEditMixin#getInvokerUId
				 * @overridden
				 */
				getInvokerUId: function() {
					var processElement  = this.getProcessElement();
					return processElement.uId;
				},

				/**
				 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
				 * @override
				 */
				getParameterReferenceSchemaUId: function() {
					var dataSource = this.get("DataSource");
					return dataSource ? dataSource.value : null;
				},

				//endregion

				//region Methods: Private

				/**
				 * Handles after connection object schema changed, resets connection instance object.
				 * @private
				 * @param {BPMSoft.BaseViewModel} model Page view model.
				 * @param {Object} entitySchema New entity schema value.
				 */
				onDataSourceChange: function(model, entitySchema) {
					entitySchema = entitySchema || {};
					var entitySchemaUId = entitySchema.value;
					if (Ext.isEmpty(entitySchemaUId)) {
						this.set("Value", null);
					} else {
						var value = this.get("Value") || {};
						value.value = null;
						value.displayValue = null;
						value.referenceSchemaUId = entitySchemaUId;
						this.set("Value", value);
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrsoft.BaseSchemaViewModel#init
				 * @protected
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.setFieldsVisibility();
						this.on("change:DataSource", this.onDataSourceChange, this);
						this.BPMSoft.EntitySchemaManager.initialize(callback, scope);
					}, this]);
				},

				/**
				 * The event handler for preparing of the data drop-down StyleList.
				 * @protected
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareDateTimeFormatList: function(filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					list.loadAll(this.get("DateTimeFormatCollection"));
				},

				/**
				 * The event handler for preparing of the data drop-down StyleList.
				 * @protected
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareControlDataValueTypeList: function(filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					list.loadAll(this.get("ControlDataValueTypeCollection"));
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Name", this.nameValidator);
					this.addColumnValidator("Name", this.duplicateValueValidator);
					this.addColumnValidator("Caption", this.duplicateValueValidator);
				},

				/**
				 * Sets fields visibility by page element type.
				 * @protected
				 */
				setFieldsVisibility: function() {
					var contolType = this.get("ControlEditType");
					var fieldType = processUserTaskConstants.AutoGeneratedPageElementFieldType;
					switch (contolType) {
						case fieldType.NOTES.id:
							this.set("IsTextVisible", true);
							break;
						case fieldType.ITEMFOLDER.id:
							this.set("IsMinimizedVisible", true);
							break;
						case fieldType.TEXT.id:
							this.set("IsMultilineVisible", true);
							this.set("IsRequiredFieldVisible", true);
							this.set("IsValueVisible", true);
							break;
						case fieldType.SELECTION.id:
							this.set("IsRequiredFieldVisible", true);
							this.set("IsDataSourceVisible", true);
							this.set("IsControlDataValueTypeVisible", true);
							this.set("IsValueVisible", true);
							break;
						case fieldType.DATETIME.id:
							this.set("IsRequiredFieldVisible", true);
							this.set("IsDateTimeFormatVisible", true);
							this.set("IsValueVisible", true);
							break;
						case fieldType.INTEGER.id:
							this.set("IsRequiredFieldVisible", true);
							this.set("IsValueVisible", true);
							break;
						case fieldType.DECIMAL.id:
							this.set("IsRequiredFieldVisible", true);
							this.set("IsValueVisible", true);
							break;
						case fieldType.BOOLEAN.id:
							this.set("IsValueVisible", true);
							break;
						default:
							break;
					}
				}

				//endregion
			},
			rules: {
				"Text": {
					"RequiredTextFieldByControlEditType": {
						"ruleType": businessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": businessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": businessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ControlEditType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": businessRuleModule.enums.ValueType.CONSTANT,
									"value": processUserTaskConstants.AutoGeneratedPageElementFieldType.NOTES.id
								}
							}
						]
					}
				},
				"DataSource": {
					"RequiredDataSourceFieldByControlEditType": {
						"ruleType": businessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": businessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": businessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ControlEditType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": businessRuleModule.enums.ValueType.CONSTANT,
									"value": processUserTaskConstants.AutoGeneratedPageElementFieldType.SELECTION.id
								}
							}
						]
					}
				},
				"ControlDataValueType": {
					"RequiredControlDataValueTypeFieldByControlEditType": {
						"ruleType": businessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": businessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": businessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ControlEditType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": businessRuleModule.enums.ValueType.CONSTANT,
									"value": processUserTaskConstants.AutoGeneratedPageElementFieldType.SELECTION.id
								}
							}
						]
					}
				},
				"DateTimeFormat": {
					"RequiredDateTimeFormatFieldByControlEditType": {
						"ruleType": businessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": businessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": businessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ControlEditType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": businessRuleModule.enums.ValueType.CONSTANT,
									"value": processUserTaskConstants.AutoGeneratedPageElementFieldType.DATETIME.id
								}
							}
						]
					}
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "Caption",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"value": {
							"bindTo": "Caption"
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"value": {
							"bindTo": "Name"
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "Text",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"value": {
							"bindTo": "Text"
						},
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"visible": {
							"bindTo": "IsTextVisible"
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "IsMultiline",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "IsMultilineVisible"
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "IsRequiredField",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "IsRequiredFieldVisible"
						},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "Minimized",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "IsMinimizedVisible"
						},
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"markerValue": "MinimizedValue"
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "DataSource",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"value": {
							"bindTo": "DataSource"
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareEntityList"
							},
							"filterComparisonType": this.BPMSoft.StringFilterType.CONTAIN
						},
						"visible": {
							"bindTo": "IsDataSourceVisible"
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"],
						"labelConfig": {}
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "ControlDataValueType",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareControlDataValueTypeList"
							}
						},
						"value": {
							"bindTo": "ControlDataValueType"
						},
						"visible": {
							"bindTo": "IsControlDataValueTypeVisible"
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"],
						"labelConfig": {}
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "DateTimeFormat",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareDateTimeFormatList"
							}
						},
						"value": {
							"bindTo": "DateTimeFormat"
						},
						"visible": {
							"bindTo": "IsDateTimeFormatVisible"
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"],
						"labelConfig": {}
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "Value",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MAPPING,
						"value": {
							"bindTo": "Value"
						},
						"visible": {
							"bindTo": "IsValueVisible"
						},
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"]
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
