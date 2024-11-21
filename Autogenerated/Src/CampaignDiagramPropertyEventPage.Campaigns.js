define("CampaignDiagramPropertyEventPage", ["CampaignDiagramPropertyEventPageResources", "BPMSoft"],
		function() {
			return {
				entitySchemaName: "Event",
				methods: {
					/**
					 * ########## ######### ##### ############ ### ######### ########.
					 * @protected
					 * @overridden
					 * @return {Array} ######### #####.
					 */
					getUsedColumns: function() {
						return [
							"Id",
							"Name",
							"StartDate",
							"EndDate",
							"Type",
							"Owner"
						];
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "CampaignDiagramPropertyDescriptionContainer"
					},
					{
						"operation": "merge",
						"name": "CampaignDiagramPropertyEntityMainContainer",
						"values": {
							"wrapClass": ["main", "fields-container"]
						}
					},
					{
						"operation": "insert",
						"name": "StartDate",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false
							}
						}
					},
					{
						"operation": "insert",
						"name": "EndDate",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false
							},
							"isRequired": false
						}
					},
					{
						"operation": "insert",
						"name": "Type",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false,
								"setValidationInfo": BPMSoft.emptyFn
							},
							"isRequired": false
						}
					},
					{
						"operation": "insert",
						"name": "Owner",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false,
								"setValidationInfo": BPMSoft.emptyFn
							},
							"isRequired": false
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
