/**
 * Base edit page schema of process element "message".
 * Parent: ProcessBaseEventPropertiesPage
 */
define("BaseMessageEventPropertiesPage", ["BaseMessageEventPropertiesPageResources"],
	function() {
		return {
			messages: {},
			attributes: {
				/**
				 * Property of process element.
				 * @type {String}
				 */
				"Message": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				}
			},
			methods: {
				/**
				 * @inheritDoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						var message = element.getPropertyValue("message");
						if (!this.Ext.isEmpty(message) && message !== "null") {
							this.set("Message", message);
						}
						callback.call(scope);
					}, this]);
				},

				/**
				 * @inheritDoc BaseProcessSchemaElementPropertiesPage#saveValues
				 * @overridden
				 */
				saveValues: function() {
					var element = this.get("ProcessElement");
					element.setPropertyValue("message", this.get("Message"));
					this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "ControlGroup",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "RecommendationLabel",
				"parentName": "ControlGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.RecommendationCaption" },
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			}, {
				"operation": "insert",
				"name": "Message",
				"parentName": "ControlGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"markerValue": "MessageValue",
					"wrapClass": ["no-caption-control"]
				}
			}, {
				"operation": "insert",
				"name": "BackgroundProcessModeControlGroup",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "BackgroundProcessModeControlGroup",
				"propertyName": "items",
				"name": "useBackgroundMode",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"visible": {
						"bindTo": "canUseBackgroundProcessMode"
					},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					}
				}
			}] /**SCHEMA_DIFF*/
		};
	}
);
