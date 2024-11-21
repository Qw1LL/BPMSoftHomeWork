/**
 * CampaignSequenceFlowPropertiesPage edit page schema.
 * Parent: BaseCampaignSchemaElementPage.
 */
define("CampaignSequenceFlowPropertiesPage", ["MultilineLabel", "css!MultilineLabel"], function() {
	return {
		messages: {},
		attributes: {
			/**
			 * Condition when synchronous is checked
			 */
			"IsSynchronous": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {
			/**
			 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
			 * @overridden
			 */
			getContextHelpCode: function() {
				return "CampaignSequenceFlow";
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#initParameters.
			 * @overridden
			 */
			initParameters: function(element) {
				this.callParent(arguments);
				this.set("IsSynchronous", element.isSynchronous);
			},

			/**
			 * @inheritdoc BaseCampaignSchemaElementPage#saveValues.
			 * @overridden
			 */
			saveValues: function() {
				this.callParent(arguments);
				var element = this.get("ProcessElement");
				element.isSynchronous = this.get("IsSynchronous");
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ContentContainer",
				"propertyName": "items",
				"parentName": "EditorsContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SequenceContainer",
				"propertyName": "items",
				"parentName": "ContentContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "InformationLabel",
				"parentName": "SequenceContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"className": "BPMSoft.MultilineLabel",
					"caption": {"bindTo": "Resources.Strings.ProcessInformationText"},
					"contentVisible": true,
					"classes": {
						"labelClass": ["label-small"]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
