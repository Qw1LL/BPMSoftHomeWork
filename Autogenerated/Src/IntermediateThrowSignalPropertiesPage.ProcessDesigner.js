/**
 * Edit page schema of process element "intermediate throw signal".
 * Parent: ProcessBaseEventPropertiesPage
 */
define("IntermediateThrowSignalPropertiesPage", ["IntermediateThrowSignalPropertiesPageResources"],
	function() {
		return {
			attributes: {
				/**
				 * Property of process element.
				 * @private
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
				},

				/**
				 * @inheritDoc ProcessFlowElementPropertiesPage#canUseBackgroundProcessMode
				 * @overridden
				 */
				canUseBackgroundProcessMode: function() {
					return false;
				}
			},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "ControlGroup",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
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
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.RecommendationCaption"
					},
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
				"name": "useBackgroundMode",
				"parentName": "ControlGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"visible": {
						"bindTo": "canUseBackgroundProcessMode"
					},
					"wrapClass": ["t-checkbox-control"]
				}
			}] /**SCHEMA_DIFF*/
		};
	}
);
