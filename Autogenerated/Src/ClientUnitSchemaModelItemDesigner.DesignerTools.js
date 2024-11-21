/**
 * Parent: SchemaModelItemDesigner.
 */
define("ClientUnitSchemaModelItemDesigner", [], function() {
	return {
		diff: [
			{
				"operation": "remove",
				"name": "IsValueCloneable"
			},
			{
				"operation": "remove",
				"name": "LabelCaption"
			},
			{
				"operation": "remove",
				"name": "IsCascade"
			}
		]
	};
});
