define("EmailMLangContentEditSchema", ["EmailMLangContentEditSchemaResources",
	"EmailTemplateMLangContentBuilderEnumsModule", "css!EmailTemplatePageV2V2Styles",
	"css!EmailMLangContentEditSchemaStyles", "css!DetailModule"
], function(resources, EmailTemplateMLangContentBuilderEnumsModule) {
	return {
		attributes: {
			/**
			 * Template subject.
			 */
			"Subject": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * Template body.
			 */
			"Body": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "MainContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClassName": ["mlang-content-main-container"]
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ContentGridGroup",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.ModuleEditCaption"
					},
					"items": [],
					"tools": [],
					"controlConfig": {
						"collapsed": false,
						"classes": ["detail"]
					}
				},
				"parentName": "MainContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"parentName": "ContentGridGroup",
				"propertyName": "tools",
				"name": "EditButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.EditButtonCaption"},
					"click": {"bindTo": "onEditButtonClick"},
					"tag": "Body"
				}
			},
			{
				"operation": "insert",
				"name": "ContentGridLayout",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "ContentGridGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Subject",
				"parentName": "ContentGridLayout",
				"propertyName": "items",
				"values": {
					"tag": "Subject",
					"layout": {
						"column": 0,
						"row": 0,
						"rowSpan": 1
					},
					"value": {
						"bindTo": "Subject"
					},
					"classes": {
						"labelClass": ["mlang-subject-label-class"]
					},
					"wrapClass": ["mlang-subject-label-wrap"],
					"caption": {"bindTo": "Resources.Strings.SubjectCaption"},
					"change": {"bindTo": "onControlValueChanged"}
				},
				"index": 1
			},
			{
				"operation": "insert",
				"parentName": "ContentGridLayout",
				"propertyName": "items",
				"name": "Body",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"generator": function() {
						return {
							"className": "BPMSoft.IframeControl",
							"id": "preview-content-iframe",
							"iframeContent": {"bindTo": "Body"}
						};
					}
				}
			}
		],
		methods: {}
	};
});
