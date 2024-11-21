/**
 * Base page template with right container with process as source of data for page designer.
 * Parent: BasePageLeftContainerProcessTemplate
 */
define("BasePageRightContainerProcessTemplate", ["css!BasePageRightContainerProcessTemplateCSS"], function() {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["card-content-container", "right-container-template"]
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
