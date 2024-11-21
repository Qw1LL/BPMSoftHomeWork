/**
 * Parent: ProcessFlowElementPropertiesPage
 */
define("LinkEntityToProcessUserTaskPropertiesPage", ["BPMSoft", "LinkEntityToProcessUserTaskPropertiesPageResources",
	"ProcessSchemaUserTaskUtilities", "ProcessModuleUtilities", "ProcessEntryPointPropertiesPageMixin"],
		function(BPMSoft, resources, UserTaskUtilities) {
			return {
				messages: {},
				mixins: {
					processEntryPointPropertiesPageMixin: "BPMSoft.ProcessEntryPointPropertiesPageMixin"
				},
				attributes: {
					/**
					 * Connection object.
					 */
					"EntitySchemaId": {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						caption: resources.localizableStrings.EntitySchemaCaption,
						referenceSchemaName: "SysSchema",
						doAutoSave: true,
						isRequired: true
					},
					/**
					 * Record of connected object.
					 */
					"EntityId": {
						dataValueType: this.BPMSoft.DataValueType.MAPPING,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						caption: resources.localizableStrings.EntityCaption,
						initMethod: "initPropertySilent",
						doAutoSave: true,
						isRequired: true
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.ProcessEntryPointPropertiesPageMixin#getEntitySchemaParameterName.
					 * @overridden
					 */
					getEntitySchemaParameterName: function() {
						return "EntitySchemaId";
					},
					/**
					 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#onElementDataLoad.
					 * @overridden
					 */
					onElementDataLoad: function(element, callback, scope) {
						this.callParent([element, function() {
							this.initEntitySchemas(function() {
								this.initEntitySchema(element, callback, scope);
							}, this);
						}, this]);
					},
					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig.
					 * @overridden
					 */
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("EntityId", UserTaskUtilities.validateMappingValue);
					},
					/**
					 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
					 * @override
					 */
					getParameterReferenceSchemaUId: function() {
						var entitySchema = this.get("EntitySchemaId");
						return entitySchema ? entitySchema.value : null;
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
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"classes": {
								"wrapClassName": ["link-entity-to-process-user-task-properties-page"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "WhatPageToOpenLabel",
						"parentName": "TitleTaskContainer",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.WhichRecordToConnectThisProcessCaption"},
							"classes": {"labelClass": ["t-title-label-proc"]}
						}
					},
					{
						"operation": "insert",
						"parentName": "TitleTaskContainer",
						"propertyName": "items",
						"name": "EntitySchemaId",
						"values": {
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24
							},
							"controlConfig": {
								"prepareList": {"bindTo": "onPrepareEntitySchemaList"},
								"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
							},
							"wrapClass": ["top-caption-control"]
						}
					},
					{
						"operation": "insert",
						"parentName": "TitleTaskContainer",
						"propertyName": "items",
						"name": "EntityId",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24
							},
							"wrapClass": ["top-caption-control"],
							"enabled": {"bindTo": "EntitySchemaId"}
						}
					}
				]
			};
		}
);
