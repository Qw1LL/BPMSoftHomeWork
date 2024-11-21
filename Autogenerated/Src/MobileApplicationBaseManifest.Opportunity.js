{
	"SyncOptions": {
		"SysSettingsImportConfig": [],
		"SysLookupsImportConfig": [
			"OpportunityType",
			"OppContactInfluence",
			"OppContactLoyality",
			"OppContactRole",
			"OpportunityStage"
		]
	},
	"Modules": {
		"Opportunity": {
			"Title": "OpportunitySectionTitle"
		}
	},
	"Models": {
		"Account": {
			"RequiredModels": [
				"Opportunity",
				"Account",
				"AccountCommunication",
				"CommunicationType",
				"AccountAddress",
				"AddressType",
				"Country",
				"Region",
				"City",
				"AccountAnniversary",
				"AnniversaryType"
			]
		},
		"Activity": {
			"RequiredModels": [
				"Opportunity",
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
		"Contact": {
			"RequiredModels": [
				"OpportunityContact"
			]
		},
		"Opportunity": {
			"RequiredModels": [
				"Account",
				"Opportunity",
				"OpportunityType",
				"OpportunityStage",
				"Activity",
				"OpportunityContact",
				"Contact",
				"OppContactRole",
				"OppContactInfluence",
				"OppContactLoyality",
				"OpportunityProductInterest",
				"Product",
				"PropositionResult",
				"OpportunityOfferResult",
				"ActivityType",
				"ActivityStatus",
				"ActivityResult",
				"ActivityCategory",
				"ActivityPriority",
				"Lead",
				"ActivityParticipant",
				"ActivityCategoryResultEntry",
				"OpportunityFile",
				"OpportunityMood",
				"SysImage",
				"FileType",
				"KnowledgeBase",
				"KnowledgeBaseFile"
			]
		}
	}
}