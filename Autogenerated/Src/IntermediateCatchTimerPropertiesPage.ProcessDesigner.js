/**
 * Parent: ProcessFlowElementPropertiesPage
 */
define("IntermediateCatchTimerPropertiesPage", ["BPMSoft", "IntermediateCatchTimerPropertiesPageResources"],
	function(BPMSoft) {
		return {
			messages: {},
			mixins: {},
			attributes: {
				/**
				 * Start offset parameter.
				 */
				"StartOffset": {
					"dataValueType": this.BPMSoft.DataValueType.MAPPING,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"doAutoSave": true,
					"initMethod": "initProperty"
				}
			},
			methods: {},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "UserTaskContainer",
				"propertyName": "items",
				"parentName": "EditorsContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
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
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "RecommendationLabel",
				"parentName": "TitleTaskContainer",
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
					},
					"styles": {
						"labelStyle": {
							"color": "#F79552"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "StartOffset",
				"parentName": "TitleTaskContainer",
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
					"wrapClass": ["no-caption-control"]
				}
			}, {
				"operation": "merge",
				"name": "useBackgroundMode",
				"values": {
					"enabled": false
				}
			}] /**SCHEMA_DIFF*/
		};
	}
);
