{
	"SyncOptions": {
		"SysLookupsImportConfig": [
			"LeadType"
		]
	},
	"Modules": {
		"Lead": {
			"Title": "LeadSectionTitle"
		}
	},
	"Models": {
		"Account": {
			"RequiredModels": [
				"Lead"
			]
		},
		"Activity": {
			"RequiredModels": [
				"Lead",
				"Activity",
				"ActivityPriority",
				"ActivityType",
				"ActivityCategory",
				"ActivityStatus",
				"ActivityParticipant",
				"Contact",
				"ActivityParticipantRole"
			]
		},
		"Lead": {
			"RequiredModels": [
				"Lead",
				"InformationSource",
				"AccountIndustry",
				"AddressType",
				"Country",
				"Region",
				"City",
				"Contact",
				"Account",
				"LeadTypeStatus",
				"QualifyStatus",
				"LeadRegisterMethod",
				"Activity",
				"Department",
				"LeadStatus",
				"ActivityType",
				"ActivityStatus",
				"ActivityResult",
				"ActivityCategory",
				"ActivityPriority",
				"ActivityParticipant",
				"ActivityCategoryResultEntry",
				"SysImage",
				"LeadType",
				"CallDirection",
				"SocialMessage"
			]
		}
	},		
	"FileModelAssociations": {
		"Lead": "FileLead"
	}
}
