// Parent: BaseSectionTemplate
define("BaseGridSectionTemplate", /**SCHEMA_DEPS*/["@bpmstudio/sdk"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "SectionContentWrapper",
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"layoutConfig": {
						"basis": "100%"
					},
					"color": "primary",
					"stretch": true,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DataTable",
				"values": {
					"type": "crt.DataGrid",
					"columns": "$Columns",
					"items": "$Items",
					"layoutConfig": {
						"basis": "100%"
					},
				},
				"parentName": "SectionContentWrapper",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{
			"attributes": {
				"ActiveRecordId": {},
				"Items": {
					"isCollection": true,
					"viewModelConfig": {
						"attributes": {}
					}
				},
				"Columns": {
					"value": []
				}
			}
		}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/
	};
});
