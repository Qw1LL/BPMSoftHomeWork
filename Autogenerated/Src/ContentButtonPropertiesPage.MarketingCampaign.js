define("ContentButtonPropertiesPage", ["ContentMacroButtonModule"], function() {
	return {
		diff: [
			{
				"operation": "insert",
				"name": "LinkMacroButtonModule",
				"parentName": "ImageLinkGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleId": "ContentMacroButtonModuleId",
					"moduleName": "ConfigurationModuleV2",
					"visible": "$isMacroButtonVisible",
					"instanceConfig": {
						"schemaName": "ContentMacroButtonModule",
						"isSchemaConfigInitialized": false,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"PropertyName": "Link"
							}
						}
					}
				}
			}
		]
	};
});
