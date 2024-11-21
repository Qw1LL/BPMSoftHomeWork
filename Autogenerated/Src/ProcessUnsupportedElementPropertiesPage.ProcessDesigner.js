/**
 * Edit page schema of process unsupported element.
 * Parent: BaseProcessSchemaElementPropertiesPage
 */
define("ProcessUnsupportedElementPropertiesPage", ["BaseProcessSchemaElementPropertiesPage"],
	function() {
		return {
			methods: {},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "UnsupportedMessage",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.UnsupportedMessage"
						},
						"classes": {
							"labelClass": ["unsupported-element-message"]
						}
					}
				},
				{
					"operation": "remove",
					"parentName": "ToolsContainer",
					"propertyName": "items",
					"name": "InfoButton",
				},
			] /**SCHEMA_DIFF*/
		};
	}
);
