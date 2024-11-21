define("SiteEventPageV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "SiteEvent",
			attributes: {},
			details: /**SCHEMA_DETAILS*/{
				Attributes: {
					schemaName: "AttributeInSiteEventDetailV2",
					entitySchemaName: "AttributeInSiteEvent",
					filter: {
						masterColumn: "Id",
						detailColumn: "SiteEvent"
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "merge",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"name": "actions",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "EventDate",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Contact",
					"values": {
						"layout": {"column": 13, "row": 0, "colSpan": 11},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Source",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Tag",
					"values": {
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "SiteEventType",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM,
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "LeadType",
					"values": {
						"layout": {"column": 13, "row": 2, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM,
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"name": "SiteAttributesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": { "bindTo": "Resources.Strings.AttributesTabCaption" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Attributes",
					"propertyName": "items",
					"parentName": "SiteAttributesTab",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
