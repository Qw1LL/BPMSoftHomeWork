/**
 * Parent: ProcessFlowElementPropertiesPage
 */
define("SendEmailUserTaskPropertiesPage", ["BPMSoft", "ProcessSchemaUserTaskUtilities", "MailboxSyncSettings",
		"HtmlEditModule", "EmailPropertiesPageMixin", "HtmlEditMappingValueMixin"],
	function(BPMSoft, ProcessSchemaUserTaskUtilities, MailboxSyncSettings) {
		return {
			messages: {},
			mixins: {
				EmailPropertiesPageMixin: "BPMSoft.EmailPropertiesPageMixin",
				HtmlEditMappingValueMixin: "BPMSoft.HtmlEditMappingValueMixin"
			},
			attributes: {
				"Sender": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initProperty",
					isRequired: true,
					doAutoSave: true
				},
				"Recepient": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initPropertySilent",
					isRequired: true,
					doAutoSave: true
				},
				"CopyRecepient": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initProperty",
					doAutoSave: true
				},
				"BlindCopyRecepient": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initProperty",
					doAutoSave: true
				},
				"Body": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initProperty",
					doAutoSave: true
				},
				"Importance": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initImportance",
					doAutoSave: true
				},
				"Subject": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initPropertySilent",
					isRequired: true,
					doAutoSave: true
				},
				"IsIgnoreErrors": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					initMethod: "initProperty",
					doAutoSave: true
				},
				"HtmlBody": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsBodyEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
				 * @override
				 */
				getParameterReferenceSchemaUId: function() {
					return MailboxSyncSettings.uId;
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					var validateMappingValue = ProcessSchemaUserTaskUtilities.validateMappingValue;
					this.addColumnValidator("Recepient", validateMappingValue);
					this.addColumnValidator("Subject", validateMappingValue);
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.mixins.HtmlEditMappingValueMixin.init.call(this);
					this.callParent([function() {
						callback.call(scope || this);
					}], this);
				},

				/**
				 * @inheritdoc BPMSoft.configuration.mixins.HtmlEditMappingValueMixin#getAttributesConfig
				 * @overridden
				 */
				getAttributesConfig: function() {
					return {
						Body: {
							displayAttributeName: "HtmlBody",
							enabledAttributeName: "IsBodyEnabled"
						}
					};
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "SendEmailContainer",
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
					"name": "WhoMessageSendRegionLabel",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"caption": {"bindTo": "Resources.Strings.SenderCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"name": "Sender",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "RecepientRegionContainer",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"items": [],
						"wrapClass": ["label-info-button-container-wrapClass"]
					}
				},
				{
					"operation": "insert",
					"name": "RecipientLabel",
					"parentName": "RecepientRegionContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.RecipientCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "InfoRecepientButton",
					"parentName": "RecepientRegionContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {"bindTo": "Resources.Strings.RecepientTip"},
						"behaviour": {
							"displayEvent": BPMSoft.controls.TipEnums.displayEvent.CLICK
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"name": "Recepient",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"caption": {"bindTo": "Resources.Strings.RecepientCaption"},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "CopyRecepient",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"caption": {"bindTo": "Resources.Strings.CopyRecepientCaption"},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "BlindCopyRecepient",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"caption": {"bindTo": "Resources.Strings.BlindCopyRecepientCaption"},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "WhatMessageSendRegionLabel",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.WhatMessageSendRegionCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "Subject",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"caption": {"bindTo": "Resources.Strings.SubjectCaption"},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"name": "HtmlBody",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.RICH_TEXT,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"enabled": {
								"bindTo": "IsBodyEnabled"
							}
						},
						"wrapClass": ["email-body-control"]
					}
				},
				{
					"operation": "insert",
					"name": "Importance",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareImportanceList"
							}
						},
						"caption": {"bindTo": "Resources.Strings.ImportanceCaption"},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "IsIgnoreErrors",
					"parentName": "SendEmailContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 10,
							"colSpan": 24
						},
						"caption": {"bindTo": "Resources.Strings.IsIgnoreErrorsCaption"},
						"wrapClass": ["t-checkbox-control"]
					}
				},
				{
					"operation": "remove",
					"name": "useBackgroundMode"
				}
			]
		};
	}
);
