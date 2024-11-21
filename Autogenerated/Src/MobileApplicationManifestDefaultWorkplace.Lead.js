{
	"SyncOptions": {
		"ModelDataImportConfig": [
			{
				"Name": "Lead",
				"SyncColumns": [
					"Account",
					"Contact",
					"LeadName",
					"FullJobTitle",
					"Industry",
					"BusinesPhone",
					"MobilePhone",
					"Email",
					"Fax",
					"Website",
					"Address",
					"City",
					"Region",
					"Country",
					"Zip",
					"AddressType",
					"InformationSource",
					"Commentary",
					"Status",
					"LeadType",
					"Owner",
					"LeadMedium",
					"QualifyStatus",
					"CreatedOn"
				]
			},
			{
				"Name": "Contact",
				"SyncColumns": []
			},
			{
				"Name": "Account",
				"SyncColumns": []
			},
			{
				"Name": "LeadStatus",
				"SyncColumns": [
					"Active"
				]
			},
			{
				"Name": "Activity",
				"SyncColumns": [
					"Lead"
				]
			},
			{
				"Name": "ActivityParticipant",
				"SyncColumns": [
					"Activity",
					"Participant"
				]
			},
			{
				"Name": "ActivityParticipantRole",
				"SyncColumns": []
			},
			{
				"Name": "InformationSource",
				"SyncColumns": []
			},
			{
				"Name": "AccountIndustry",
				"SyncColumns": []
			},
			{
				"Name": "AddressType",
				"SyncColumns": []
			},
			{
				"Name": "Country",
				"SyncColumns": []
			},
			{
				"Name": "Region",
				"SyncColumns": []
			},
			{
				"Name": "City",
				"SyncColumns": []
			},
			{
				"Name": "LeadTypeStatus",
				"SyncColumns": []
			},
			{
				"Name": "QualifyStatus",
				"SyncColumns": []
			},
			{
				"Name": "ActivityPriority",
				"SyncColumns": []
			},
			{
				"Name": "ActivityType",
				"SyncColumns": []
			},
			{
				"Name": "ActivityCategory",
				"SyncColumns": []
			},
			{
				"Name": "ActivityStatus",
				"SyncColumns": []
			},
			{
				"Name": "LeadRegisterMethod",
				"SyncColumns": []
			},
			{
				"Name": "LeadType",
				"SyncColumns": []
			},
			{
				"Name": "LeadMedium",
				"SyncColumns": []
			}
		],
		"SysSettingsImportConfig": []
	},
	"Modules": {
		"Lead": {
			"Position": 3,
			"Hidden": false
		}
	},
	"Models": {
		"Account": {
			"RequiredModels": [
				"Lead"
			]
		},
		"Activity": {
			"PagesExtensions": [
				"MobileActivityRecordPageSettingsDefaultWorkplace",
				"MobileActivityLeadModuleConfig"
			],
			"ModelExtensions": []
		},
		"Lead": {
			"Preview": "MobileLeadPreviewPage",
			"ModelExtensions": [
				"MobileLeadModelConfig"
			],
			"PagesExtensions": [
				"MobileLeadRecordPageSettingsDefaultWorkplace",
				"MobileLeadGridPageSettingsDefaultWorkplace",
				"MobileLeadActionsSettingsDefaultWorkplace",
				"MobileLeadModuleConfig"
			],
			"RequiredModels": [
				"Lead",
				"LeadMedium",
				"QualifyStatus",
				"LeadTypeStatus",
				"LeadRegisterMethod"
			]
		}
	}
}