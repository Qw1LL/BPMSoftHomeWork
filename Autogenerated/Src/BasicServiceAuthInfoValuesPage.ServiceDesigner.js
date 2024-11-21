define("BasicServiceAuthInfoValuesPage", [], function() {
	return {
		attributes: {

			/**
			 * UId of service schema.
			 */
			ServiceSchemaUId: {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Is allow edit schema.
			 */
			CanEditSchema: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},
		modules: {
			AuthInfoUsernameParameter: {
				moduleId: "AuthInfoUsernameParameterValuePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "AuthInfoUsernameValuePage",
					parameters: {
						viewModelConfig: {
							ServiceSchemaUid: {
								attributeValue: "ServiceSchemaUId"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					},
					useHistoryState: false
				}
			},
			AuthInfoPasswordParameter: {
				moduleId: "AuthInfoPasswordParameterValuePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "AuthInfoPasswordValuePage",
					parameters: {
						viewModelConfig: {
							ServiceSchemaUid: {
								attributeValue: "ServiceSchemaUId"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					},
					useHistoryState: false
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "BasicAuthInfo",
				"parentName": "ParameterEdit",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BasicAuthInfoContainer",
				"parentName": "BasicAuthInfo",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "AuthInfoUsernameParameter",
				"parentName": "BasicAuthInfoContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"layout": {"column": 0, "row": 0, "colSpan": 11},
				}

			},
			{
				"operation": "insert",
				"name": "AuthInfoPasswordParameter",
				"parentName": "BasicAuthInfoContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"layout": {"column": 13, "row": 0, "colSpan": 11},
				}
			}
		]
	};
});
