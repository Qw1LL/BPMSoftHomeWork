/**
 * Event generation message edit page schema.
 * Parent: BaseMessageEventPropertiesPage
 */
define("IntermediateThrowMessagePropertiesPage", ["IntermediateThrowMessagePropertiesPageResources"],
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
			}, {
				"operation": "remove",
				"name": "useBackgroundMode"
			}] /**SCHEMA_DIFF*/
		};
	}
);
