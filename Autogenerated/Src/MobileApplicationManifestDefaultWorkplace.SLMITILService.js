{
	"SyncOptions": {
		"ModelDataImportConfig": [
			{
				"Name": "Case",
				"SyncColumns": [
					"SupportLevel"
				]
			},
			{
				"Name": "RoleInServiceTeam",
				"SyncColumns": []
			}
		]
	},
	"Models": {
		"Case": {
			"RequiredModels": [
				"RoleInServiceTeam"
			]
		}
	}
}