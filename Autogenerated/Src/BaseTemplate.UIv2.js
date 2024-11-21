 define("BaseTemplate", /**SCHEMA_DEPS*/["css!CardSchemaViewModule"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "MainHeader",
				"values": {
					"type": "crt.HeaderContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ActionContainer",
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 0,
				"values": {
					"type": "crt.GridContainer",
					"direction": "column",
					"rows": "minmax(max-content, 32px)",
					"columns": ["minmax(64px, 1fr)"],
					"color": "primary",
					"padding": {
						"top": "none",
						"right": "large",
						"bottom": "large",
						"left": "large"
					},
					"gap": {
						"columnGap": "small",
						"rowGap": "small"
					},
					"borderRadius": "medium",
					"styles": {
						"border-top": "none",
						"border-top-left-radius": 0,
						"border-top-right-radius": 0
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ActionButtonsContainer",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"type": "crt.FlexContainer",
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"direction": "row",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MainContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": []
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/
	};
});
