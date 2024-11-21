define("ChangePage", [],
	function() {
		return {
			entitySchemaName: "Change",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Release",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Release",
						"caption": {
							"bindTo": "Resources.Strings.ReleaseCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Classification_GridLayout",
					"propertyName": "items",
					"index": 5
				}
			]/**SCHEMA_DIFF*/,
			mixins: {},
			attributes: {},
			methods: {},
			rules: {},
			userCode: {}
		};
	});
