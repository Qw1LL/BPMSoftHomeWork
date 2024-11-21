/**
 * Simple base page template with process as source of data for page designer.
 * Parent: BasePageProcessTemplate
 */
define("BasePageSimpleProcessTemplate", [], function() {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "Tabs"
			}
		]/**SCHEMA_DIFF*/
	};
});
