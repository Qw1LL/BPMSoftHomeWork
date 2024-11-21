// Parent: BaseTemplate
define("BasePageTemplate", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "SaveButton",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.SaveRecordRequest"
					},
					"color": "accent",
					"caption": "$Resources.Strings.SaveButton",
					"visible": "$IsChanged"
				}
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.CancelRecordChangesRequest"
					},
					"caption":"$Resources.Strings.CancelButton",
					"visible": "$IsChanged"
				}
			},
			{
				"operation": "insert",
				"name": "CloseButton",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 2,
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"color": "primary",
					"caption":"$Resources.Strings.CloseButton",
					"visible": "$IsChanged | crt.invertBooleanValue"
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{
			"attributes": {
				"IsChanged": {
					"value": false
				},
				"IsChangesTrackingEnabled": {
					"value": false
				},
				"CardState": {}
			}
		}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/
	};
});
