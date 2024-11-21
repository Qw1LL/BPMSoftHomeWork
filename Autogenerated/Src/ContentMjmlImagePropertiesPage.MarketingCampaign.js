define("ContentMjmlImagePropertiesPage", ["ContentMacroButtonModule"],
		function() {
	return {
		diff: [
			{
				"operation": "insert",
				"name": "ImageLinkMacroButton",
				"parentName": "ImageLinkGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleId": "ImageLinkMacroButton",
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
			},
			{
				"operation": "insert",
				"name": "ImageTitleMacroButton",
				"parentName": "ImageTitleContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleId": "ImageTitleMacroButton",
					"moduleName": "ConfigurationModuleV2",
					"visible": "$isMacroButtonVisible",
					"instanceConfig": {
						"schemaName": "ContentMacroButtonModule",
						"isSchemaConfigInitialized": false,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"PropertyName": "ImageTitle"
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "ImageAltMacroButton",
				"parentName": "ImageAltGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleId": "ImageAltMacroButton",
					"moduleName": "ConfigurationModuleV2",
					"visible": "$isMacroButtonVisible",
					"instanceConfig": {
						"schemaName": "ContentMacroButtonModule",
						"isSchemaConfigInitialized": false,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"PropertyName": "Alt"
							}
						}
					}
				}
			}
		]
	};
});
