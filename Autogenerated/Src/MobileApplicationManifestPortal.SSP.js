{
	"Features": {
		"UseMobileDynamicLink": {
			"CustomSchemas": [
				"MobileDynamicLinkReceiver"
			]
		}
	},
	"UseOptimisticEditing": true,
	"UseUTC": true,
	"ModuleGroups": {
		"main": {
			"Position": 0
		}
	},
	"DefaultModuleImageId": "MobileImageListDefaultModuleImage",
	"DefaultModuleImageIdV2": "MobileImageListDefaultModuleImageV2",
	"CustomSchemas": [
		"MobileImageList",
		"MobileCss",
		"MobileUtilities",
		"MobileConstants",
		"MobileServiceHelper",
		"MobilePushNotificationReceiver",
		"BaseLocalNotificationManager",
		"MobileLocalNotificationManager"
	],
	"SyncOptions": {
		"ImportPageSize": 1000,
		"PagesInImportTransaction": 5,
		"UseBatchExport": true,
		"UseSkipToken": true,
		"SysSettingsImportConfig": [
			"MobileApplicationMode",
			"CollectMobileAppUsageStatistics",
			"CanCollectMobileUsageStatistics",
			"MobileAppUsageStatisticsEmail",
			"MobileAppUsageStatisticsStorePeriod",
			"MobileSectionsWithSearchOnly",
			"MobileShowMenuOnApplicationStart",
			"MobileAppCheckUpdatePeriod",
			"ShowMobileLocalNotifications",
			"MobileLogoImage",
			"RunMobileSyncInService",
			"NotifyMobileUserAboutAppUpdate",
			"EnableMobileErrorLog",
			"MobileDataSyncFrequency",
			"UseMobileLastKnownLocation",
			"UseMobileCertificateAuthentication",
			"MobileEmailForPermissionRequests",
			"MobileAmplitudeApiKey",
			"DataServiceQueryTimeout",
			"MaxFileSize",
			"FileExtensionsAllowList"
		],
		"SysLookupsImportConfig": [
			"MobileApplicationMode"
		],
		"ModelDataImportConfig": [
			{
				"Name": "Contact",
				"ExpandLookups": true,
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "Contact",
					"logicalOperation": 0,
					"items": {
						"CurrentContact": {
							"filterType": 1,
							"comparisonType": 3,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Id"
							},
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							}
						}
					}
				},
				"SyncColumns": [
					"Name",
					"Account",
					"Department",
					"JobTitle",
					"Photo",
					"Job"
				]
			},
			{
				"Name": "SysImage",
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
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "SysImage",
					"logicalOperation": 0,
					"items": {
						"CurrentContact": {
							"filterType": 1,
							"comparisonType": 3,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "[Contact:Photo].Id"
							},
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
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
			}
		]
	},
	"Modules": {
		"Contact": {
			"Group": "main",
			"Model": "Contact",
			"IconV2": {
				"ImageId": "MobileImageListContactModuleImageV2"
			},
			"Hidden": true
		},
		"Account": {
			"Group": "main",
			"Model": "Account",
			"IconV2": {
				"ImageId": "MobileImageListAccountModuleImageV2"
			},
			"Hidden": true
		},
		"Activity": {
			"Group": "main",
			"Model": "Activity",
			"IconV2": {
				"ImageId": "MobileImageListActivityModuleImageV2"
			},
			"Hidden": true
		},
		"Contract": {
			"Group": "main",
			"Model": "Contract",
			"IconV2": {
				"ImageId": "MobileImageListContractModuleImageV2"
			},
			"Hidden": true
		},
		"Document": {
			"Group": "main",
			"Model": "Document",
			"IconV2": {
				"ImageId": "MobileImageListDocumentModuleImageV2"
			},
			"Hidden": true
		},
		"Order": {
			"Group": "main",
			"Model": "Order",
			"IconV2": {
				"ImageId": "MobileImageListOrderModuleImageV2"
			},
			"Hidden": true
		},
		"Forecast": {
			"Group": "main",
			"Model": "Forecast",
			"IconV2": {
				"ImageId": "MobileImageListPlanningModuleImageV2"
			},
			"Hidden": true
		},
		"Product": {
			"Group": "main",
			"Model": "Product",
			"IconV2": {
				"ImageId": "MobileImageListProductModuleImageV2"
			},
			"Hidden": true
		},
		"Project": {
			"Group": "main",
			"Model": "Project",
			"IconV2": {
				"ImageId": "MobileImageListProjectModuleImageV2"
			},
			"Hidden": true
		},
		"Invoice": {
			"Group": "main",
			"Model": "Invoice",
			"IconV2": {
				"ImageId": "MobileImageListInvoiceModuleImageV2"
			},
			"Hidden": true
		},
		"Request": {
			"Group": "main",
			"Model": "Request",
			"IconV2": {
				"ImageId": "MobileImageListRequestModuleImageV2"
			},
			"Hidden": true
		},
		"Listing": {
			"Group": "main",
			"Model": "Listing",
			"IconV2": {
				"ImageId": "MobileImageListListingModuleImageV2"
			},
			"Hidden": true
		},
		"SocialMessage": {
			"Group": "main",
			"Model": "SocialMessage",
			"IconV2": {
				"ImageId": "MobileImageListFeedModuleImageV2"
			},
			"Hidden": true
		},
		"ConfItem": {
			"Group": "main",
			"Model": "ConfItem",
			"IconV2": {
				"ImageId": "MobileImageListConfigurationModuleImageV2"
			},
			"Hidden": true
		},
		"Case": {
			"Group": "main",
			"Model": "Case",
			"IconV2": {
				"ImageId": "MobileImageListTreatmentModuleImageV2"
			},
			"Hidden": true
		},
		"Problem": {
			"Group": "main",
			"Model": "Problem",
			"IconV2": {
				"ImageId": "MobileImageListProblemModuleImageV2"
			},
			"Hidden": true
		},
		"ServicePact": {
			"Group": "main",
			"Model": "ServicePact",
			"IconV2": {
				"ImageId": "MobileImageListServiceContractModuleImageV2"
			},
			"Hidden": true
		},
		"ServiceItem": {
			"Group": "main",
			"Model": "ServiceItem",
			"IconV2": {
				"ImageId": "MobileImageListServiceModuleImageV2"
			},
			"Hidden": true
		},
		"Campaign": {
			"Group": "main",
			"Model": "Campaign",
			"IconV2": {
				"ImageId": "MobileImageListCampaignModuleImageV2"
			},
			"Hidden": true
		},
		"KnowledgeBase": {
			"Group": "main",
			"Model": "KnowledgeBase",
			"IconV2": {
				"ImageId": "MobileImageListKnowledgeBaseModuleImageV2"
			},
			"Title": "KnowledgeBaseSectionTitle",
			"Hidden": true
		},
		"BulkEmail": {
			"Group": "main",
			"Model": "BulkEmail",
			"IconV2": {
				"ImageId": "MobileImageListEmailModuleImageV2"
			},
			"Hidden": true
		},
		"Event": {
			"Group": "main",
			"Model": "Event",
			"IconV2": {
				"ImageId": "MobileImageListActionModuleImageV2"
			},
			"Hidden": true
		},
		"SocialSubscription": {
			"Group": "main",
			"Model": "SocialSubscription",
			"IconV2": {
				"ImageId": "MobileImageListSubscriptionModuleImageV2"
			},
			"Hidden": true
		},
		"Lead": {
			"Group": "main",
			"Model": "Lead",
			"IconV2": {
				"ImageId": "MobileImageListLeadModuleImageV2"
			},
			"Hidden": true
		},
		"Opportunity": {
			"Group": "main",
			"Model": "Opportunity",
			"IconV2": {
				"ImageId": "MobileImageListOpportunityModuleImageV2"
			},
			"Hidden": true
		},
		"SysDashboard": {
			"Group": "main",
			"Model": "SysDashboard",
			"IconV2": {
				"ImageId": "MobileImageListDashboardModuleImageV2"
			},
			"Hidden": true
		},
		"Approval": {
			"Group": "main",
			"Model": "Approval",
			"IsFlutterPage": true,
			"ScreenName": "ApprovalsScreen",
			"IconV2": {
				"ImageId": "MobileImageListApprovalModuleImage"
			},
			"Hidden": true
		}
	},
	"Models": {
	},
	"ApplicationRequiredModels": ["Contact", "Account", "SysImage", "DuplicatesHistory"]
}