/**
 * Process intermediate catch message properties edit page schema.
 * Parent: BaseProcessElementMessagePropertiesPage
 */
define("IntermediateCatchMessagePropertiesPage", ["IntermediateCatchMessagePropertiesPageResources"],
	function() {
		return {
			methods: {},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "merge",
				"name": "RecommendationLabel",
				"values": {
					"styles": {
						"labelStyle": {
							"color": "#F79552"
						}
					}
				}
			}] /**SCHEMA_DIFF*/
		};
	});
