{
	"CustomSchemas": [
		"MobileSocialMessageUtilities",
		"MobileFeedList",
		"MobileFeedCommentsList",
		"MobileSocialMessageHtmlField"
	],
	"SyncOptions": {
		"SysSettingsImportConfig": [],
		"SysLookupsImportConfig": [
			"SocialChannel",
			"VwMobileSysSchema"
		],
		"ModelDataImportConfig": [
			"SocialChannel",
			"SocialLike",
			{
				"Name": "VwSocialSubscription",
				"SyncFilter": {
					"property": "SysAdminUnit",
					"valueIsMacros": true,
					"value": "BPMSoft.ValueMacros.CurrentUser"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "VwSocialSubscription",
					"items": {
						"SysAdminUnitCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 1
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "SysAdminUnit"
							},
							"comparisonType": 3
						}
					}
				}
			},
			{
				"Name": "VwSocialUnsubscription",
				"SyncFilter": {
					"property": "SysAdminUnit",
					"valueIsMacros": true,
					"value": "BPMSoft.ValueMacros.CurrentUser"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "VwSocialUnsubscription",
					"items": {
						"SysAdminUnitCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 1
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "SysAdminUnit"
							},
							"comparisonType": 3
						}
					}
				}
			},
			"VwMobileSysSchema",
			{
				"Name": "SocialMessage",
				"SyncColumns": [
					"CreatedBy",
					"Message",
					"Parent",
					"EntityId",
					"EntitySchemaUId",
					"LikeCount",
					"CommentCount"
				]
			},
			{
				"Name": "SysImage",
				"SyncFilter": {
					"property": "HasRef",
					"value": true
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "SysImage",
					"items": {
						"ExistContactPhoto": {
							"filterType": 5,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "[Contact:Photo].Id"
							},
							"subFilters": {
								"items": {},
								"logicalOperation": 0,
								"filterType": 6,
								"rootSchemaName": "Contact"
							}
						}
					}
				},
				"SyncColumns": [
					"Name",
					"HasRef",
					{
						"Name": "PreviewData",
						"UseRecordIdAsFileName": true,
						"ImportBinaryData": true
					}
				]
			},
			{
				"Name": "Contact",
				"SyncColumns": [
					"Photo"
				]
			}
		],
		"ModelDataExportConfig": [
			{
				"Name": "SocialLike",
				"IgnoreSplitLogActions": true
			},
			{
				"Name": "SocialMessage",
				"IgnoreSplitLogActions": true
			},
			{
				"Name": "SocialMention",
				"IgnoreSplitLogActions": true
			}
		]
	},
	"Modules": {
		"SocialMessage": {
			"Title": "SocialMessageSectionTitle"
		}
	},
	"Models": {
		"SocialMessage": {
			"CacheConfig": {
				"Disable": true
			},
			"Grid": "MobileSocialMessageGridPage",
			"Preview": "MobileSocialMessagePreviewPage",
			"Edit": "MobileSocialMessageEditPage",
			"RequiredModels": [
				"SocialMessage",
				"Contact",
				"SysImage",
				"SocialSubscription",
				"SocialUnsubscription",
				"VwSocialSubscription",
				"VwSocialUnsubscription",
				"SocialChannel",
				"VwMobileSysSchema",
				"SocialLike",
				"SocialMention",
				"SysAdminUnit"
			],
			"ModelExtensions": [
				"MobileSocialMessageModelConfig"
			],
			"PagesExtensions": [
				"MobileSocialMessageGridPageSettingsDefaultWorkplace",
				"MobileSocialMessageRecordPageSettingsDefaultWorkplace",
				"MobileSocialMessageActionsSettingsDefaultWorkplace",
				"MobileSocialMessageEntityLoader",
				"MobileSocialMessageLikeManager",
				"MobileSocialMessageModuleConfig",
				"MobileSocialMessageGridPageStore",
				"MobileSocialMessageGridPageView",
				"MobileSocialMessageGridPageController",
				"MobileSocialMessageAssociateModelCacheManager"
			]
		},
		"SocialMention": {
			"ModelExtensions": [
				"MobileSocialMentionModelConfig"
			]
		}
	}
}
