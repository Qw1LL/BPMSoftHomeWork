// Parent: BaseTemplate
define("BaseSectionTemplate", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "ActionContainer",
				"values": {
					"styles": {
						"border-top": "none",
						"border-bottom": "none",
						"border-radius": 0
					},
					"padding": {
						"top": "none",
						"right": "large",
						"bottom": "none",
						"left": "large"
					}
				}
			},
			{
				"operation": "insert",
				"name": "AddButton",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.CreateRecordRequest",
						"params": {
							"itemsAttributeName": "Items"
						}
					},
					"color": "accent",
					"caption": "$Resources.Strings.AddButton"
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/
	};
});
