/**
 * Base page template with left container with process as source of data for page designer.
 * Parent: BasePageProcessTemplate
 */
define("BasePageLeftContainerProcessTemplate", [], function() {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "LeftModulesContainer",
				"values": {
					"visible": true
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"index": 0,
				"name": "LeftTopContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["profile-container", "autofill-layout"]
					},
					"collapseEmptyRow": true,
					"items": []
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
