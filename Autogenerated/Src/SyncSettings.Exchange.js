define("SyncSettings", ["SyncSettingsResources"], function() {
	return {
		entitySchemaName: "MailboxSyncSettings",
		diff: [
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "ActivitySettingsTab",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ActivitySettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ActivitySettingsTab",
				"name": "ActivitySettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_ActivitySyncSettingsSchemaModule",
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "ActivitySyncSettingsTab",
						"defaultValues": [{
							"name": "TabName",
							"value": "ActivitySyncSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			},
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "ContactSettingsTab",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ContactSettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ContactSettingsTab",
				"name": "ContactSettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_ContactSyncSettingsSchemaModule",
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "ContactSyncSettingsTab",
						"defaultValues": [{
							"name": "TabName",
							"value": "ContactSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			}
		]
	};
});
