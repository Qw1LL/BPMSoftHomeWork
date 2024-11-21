 {
	"Features": {
		"UseMobileCallerId": {
			"CustomSchemas": [
				"MobileCallerIdDataLoader"
			],
			"SyncOptions": {
				"ModelDataImportConfig": [
					{
						"Name": "DialingCode",
						"SyncColumns": [
							"Country",
							"Code",
							"TrunkPrefix"
						]
					},
					{
						"Name": "Employee",
						"SyncColumns": [
							"Contact"
						]
					}
				]
			},
			"ApplicationRequiredModels": ["DialingCode", "Employee"]
		},
		"UseMobileFolders": {
			"CustomSchemas": [
				"MobileFoldersData",
				"MobileFoldersStore"
			],
			"ApplicationRequiredModels": ["BaseFolder", "FolderType"]
		},
		"UseMobileDynamicLink": {
			"CustomSchemas": [
				"MobileDynamicLinkReceiver"
			],
			"ApplicationRequiredModels": ["VwModuleEditInfo"]
		},
		"UseMobileSummaries": {
			"CustomSchemas": [
				"MobileSummariesData"
			]
		}
	},
	"UseOptimisticEditing": true,
	"UseUTC": true,
	"UseIconEdit": true,
	"ModuleGroups": {
		"main": {
			"Position": 0
		},
		"sales": {
			"Position": 1
		}
	},
	"DefaultModuleImageId": "MobileImageListDefaultModuleImage",
	"DefaultModuleImageIdV2": "MobileImageListDefaultModuleImageV2",
	"CustomSchemas": [
		"MobileImageList",
		"MobileCss",
		"MobileUtilities",
		"MobileConstants",
		"MobileDashboardEnums",
		"MobileDashboardUtils",
		"MobileDashboardContainer",
		"MobileServiceHelper",
		"MobileAnalyticsService",
		"MobileAnalyticsServiceResponseParser",
		"MobileAnalyticsServiceGridDataProxy",
		"MobileDashboardViewGenerator",
		"MobileDashboardDataManager",
		"MobileBaseDashboardItemConfigGenerator",
		"MobileBaseDashboardItem",
		"MobileIndicatorDashboardConfigGenerator",
		"MobileIndicatorDashboardComponent",
		"MobileIndicatorDashboardItem",
		"MobileGridDashboardItem",
		"MobileChartDashboardItemConfigGenerator",
		"MobileChartDashboardItem",
		"MobilePushNotificationReceiver",
		"MobileLookupGridPageConfig",
		"MobilePhoneCallLogPage",
		"MobilePhoneCallLogUtils",
		"BaseLocalNotificationManager",
		"MobileLocalNotificationManager",
		"MobileEditPageController",
		"MobileFileAndLinksPreviewControllerV2",
		"MobileFileAndLinksEditControllerV2",
		"MobileFileAndLinksBusinessRule",
		"MobileFileAndLinksEmbeddedDetailGenerator",
		"MobilePortalMessagePublisherPage",
		"MobileActionAddFileAndLinks",
		"MobileOpenStandardDetailAction",
		"MobileOpenPortalMessagePublisherPageAction",
		"MobileFileService",
		"MobileFileServiceProvider",
		"MobileActionShareLink",
		"MobileVisaEmbeddedDetailGenerator",
		"MobileVisaEmbeddedDetailItem",
		"MobileVisaActions"
	],
	"SyncOptions": {
		"ImportPageSize": 1000,
		"PagesInImportTransaction": 5,
		"UseBatchExport": true,
		"UseSkipToken": true,
		"SysSettingsImportConfig": [
			"SchedulerDisplayTimingStart",
			"PrimaryCulture",
			"PrimaryCurrency",
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
			"MobileTrackLocationFrequency",
			"UseMobileLastKnownLocation",
			"UseMobileCertificateAuthentication",
			"MobileEmailForPermissionRequests",
			"MobileAmplitudeApiKey",
			"DataServiceQueryTimeout",
			"MaxFileSize",
			"FileExtensionsAllowList"
		],
		"SysLookupsImportConfig": [
			"ActivityCategory",
			"ActivityPriority",
			"ActivityResult",
			"ActivityResultCategory",
			"ActivityStatus",
			"ActivityType",
			"ActivityCategoryResultEntry",
			"ActivityParticipantRole",
			"AddressType",
			"CommunicationType",
			"AnniversaryType",
			"InformationSource",
			"MobileApplicationMode",
			"AccountType",
			"AccountCategory",
			"FileType",
			"CallDirection",
			"VisaStatus"
		],
		"ModelDataImportConfig": [
			{
				"Name": "VwSysEntitySchemaInWorkspace",
				"Position": 0
			},
			{
				"Name": "SysAdminUnit",
				"ExpandLookups": true,
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "SysAdminUnit",
					"logicalOperation": 0,
					"items": {
						"CurrentContact": {
							"filterType": 1,
							"comparisonType": 3,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Contact"
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
					"Contact",
					"Account",
					"SysAdminUnitTypeValue",
					"Active",
					"ConnectionType"
				]
			},
			{
				"Name": "VwRemindings",
				"SyncFilter": {
					"property": "Contact",
					"valueIsMacros": true,
					"value": "BPMSoft.ValueMacros.CurrentUserContact"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "VwRemindings",
					"items": {
						"ContactCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Contact"
							},
							"comparisonType": 3
						}
					}
				}
			}, 
			{
				"Name": "CallDirection"
			},
			{
				"Name": "VisaStatus",
				"SyncColumns": [
					"IsFinal"
				]
			},
			{
				"Name": "VwModuleEditInfo",
				"SyncColumns": [
					"Name",
					"ModuleCode"
				],
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "VwModuleEditInfo",
					"logicalOperation": 0,
					"items": {
						"Module": {
							"comparisonType": 4,
							"filterType": 1,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "ModuleCode"
							},
							"rightExpression": {
								"expressionType": 2,
								"parameter": {
									"dataValueType": 1,
									"value": ""
								}
							}
						}
					}
				}
			}
		]
	},
	"Modules": {
		"Contact": {
			"Group": "main",
			"Model": "Contact",
			"Position": 0,
			"Title": "ContactSectionTitle",
			"Icon": {
				"ImageId": "MobileImageListContactModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListContactModuleImageV2"
			},
			"Hidden": false
		},
		"Account": {
			"Group": "main",
			"Model": "Account",
			"Position": 1,
			"Title": "AccountSectionTitle",
			"Icon": {
				"ImageId": "MobileImageListAccountModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListAccountModuleImageV2"
			},
			"Hidden": false
		},
		"Activity": {
			"Group": "main",
			"Model": "Activity",
			"Position": 2,
			"Title": "ActivitySectionTitle",
			"Icon": {
				"ImageId": "MobileImageListActivityModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListActivityModuleImageV2"
			},
			"Hidden": false
		},
		"Contract": {
			"Group": "main",
			"Model": "Contract",
			"Icon": {
				"ImageId": "MobileImageListContractModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListContractModuleImageV2"
			},
			"Hidden": true
		},
		"Document": {
			"Group": "main",
			"Model": "Document",
			"Icon": {
				"ImageId": "MobileImageListDocumentModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListDocumentModuleImageV2"
			},
			"Hidden": true
		},
		"Order": {
			"Group": "main",
			"Model": "Order",
			"Icon": {
				"ImageId": "MobileImageListOrderModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListOrderModuleImageV2"
			},
			"Hidden": true
		},
		"Forecast": {
			"Group": "main",
			"Model": "Forecast",
			"Icon": {
				"ImageId": "MobileImageListPlanningModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListPlanningModuleImageV2"
			},
			"Hidden": true
		},
		"Product": {
			"Group": "main",
			"Model": "Product",
			"Icon": {
				"ImageId": "MobileImageListProductModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListProductModuleImageV2"
			},
			"Hidden": true
		},
		"Project": {
			"Group": "main",
			"Model": "Project",
			"Icon": {
				"ImageId": "MobileImageListProjectModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListProjectModuleImageV2"
			},
			"Hidden": true
		},
		"Invoice": {
			"Group": "main",
			"Model": "Invoice",
			"Icon": {
				"ImageId": "MobileImageListInvoiceModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListInvoiceModuleImageV2"
			},
			"Hidden": true
		},
		"Request": {
			"Group": "main",
			"Model": "Request",
			"Icon": {
				"ImageId": "MobileImageListRequestModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListRequestModuleImageV2"
			},
			"Hidden": true
		},
		"Listing": {
			"Group": "main",
			"Model": "Listing",
			"Icon": {
				"ImageId": "MobileImageListListingModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListListingModuleImageV2"
			},
			"Hidden": true
		},
		"SocialMessage": {
			"Group": "main",
			"Model": "SocialMessage",
			"Icon": {
				"ImageId": "MobileImageListFeedModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListFeedModuleImageV2"
			},
			"Hidden": true
		},
		"ConfItem": {
			"Group": "main",
			"Model": "ConfItem",
			"Icon": {
				"ImageId": "MobileImageListConfigurationModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListConfigurationModuleImageV2"
			},
			"Hidden": true
		},
		"Case": {
			"Group": "main",
			"Model": "Case",
			"Icon": {
				"ImageId": "MobileImageListTreatmentModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListTreatmentModuleImageV2"
			},
			"Hidden": true
		},
		"Problem": {
			"Group": "main",
			"Model": "Problem",
			"Icon": {
				"ImageId": "MobileImageListProblemModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListProblemModuleImageV2"
			},
			"Hidden": true
		},
		"ServicePact": {
			"Group": "main",
			"Model": "ServicePact",
			"Icon": {
				"ImageId": "MobileImageListServiceContractModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListServiceContractModuleImageV2"
			},
			"Hidden": true
		},
		"ServiceItem": {
			"Group": "main",
			"Model": "ServiceItem",
			"Icon": {
				"ImageId": "MobileImageListServiceModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListServiceModuleImageV2"
			},
			"Hidden": true
		},
		"Campaign": {
			"Group": "main",
			"Model": "Campaign",
			"Icon": {
				"ImageId": "MobileImageListCampaignModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListCampaignModuleImageV2"
			},
			"Hidden": true
		},
		"KnowledgeBase": {
			"Group": "main",
			"Model": "KnowledgeBase",
			"Icon": {
				"ImageId": "MobileImageListKnowledgeBaseModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListKnowledgeBaseModuleImageV2"
			},
			"Title": "KnowledgeBaseSectionTitle",
			"Hidden": true
		},
		"BulkEmail": {
			"Group": "main",
			"Model": "BulkEmail",
			"Icon": {
				"ImageId": "MobileImageListEmailModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListEmailModuleImageV2"
			},
			"Hidden": true
		},
		"Event": {
			"Group": "main",
			"Model": "Event",
			"Icon": {
				"ImageId": "MobileImageListActionModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListActionModuleImageV2"
			},
			"Hidden": true
		},
		"SocialSubscription": {
			"Group": "main",
			"Model": "SocialSubscription",
			"Icon": {
				"ImageId": "MobileImageListSubscriptionModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListSubscriptionModuleImageV2"
			},
			"Hidden": true
		},
		"Lead": {
			"Group": "main",
			"Model": "Lead",
			"Icon": {
				"ImageId": "MobileImageListLeadModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListLeadModuleImageV2"
			},
			"Hidden": true
		},
		"Opportunity": {
			"Group": "main",
			"Model": "Opportunity",
			"Icon": {
				"ImageId": "MobileImageListOpportunityModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListOpportunityModuleImageV2"
			},
			"Hidden": true
		},
		"SysDashboard": {
			"Group": "main",
			"Model": "SysDashboard",
			"Position": 6,
			"Title": "DashboardSectionTitle",
			"Icon": {
				"ImageId": "MobileImageListDashboardModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListDashboardModuleImageV2"
			},
			"Hidden": false
		},
		"Approval": {
			"Group": "main",
			"Model": "Approval",
			"Position": 7,
			"Title": "ApprovalSectionTitle",
			"IconV2": {
				"ImageId": "MobileImageListApprovalModuleImage"
			},
			"Hidden": true,
			"screens": {
				"start": {
					"screenName": "ApprovalsScreen"
				}
			}
		},
		"GeneratedWebForm": {
			"Icon": {
				"ImageId": "MobileImageListGeneratedWebFormModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListGeneratedWebFormModuleImageV2"
			},
			"Hidden": true
		},
		"Partnership": {
			"Icon": {
				"ImageId": "MobileImageListPartnershipModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListPartnershipModuleImageV2"
			},
			"Hidden": true
		},
		"SysSettings": {
			"Icon": {
				"ImageId": "MobileImageListSysSettingsModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListSysSettingsModuleImageV2"
			},
			"Hidden": true
		},
		"Employee": {
			"Icon": {
				"ImageId": "MobileImageListEmployeeModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListEmployeeModuleImageV2"
			},
			"Hidden": true
		},
		"SysLookup": {
			"Icon": {
				"ImageId": "MobileImageListSysLookupModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListSysLookupModuleImageV2"
			},
			"Hidden": true
		},
		"OmniChat": {
			"Icon": {
				"ImageId": "MobileImageListOmniChatModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListOmniChatModuleImageV2"
			},
			"Hidden": true
		},
		"BulkEmailSplit": {
			"Icon": {
				"ImageId": "MobileImageListBulkEmailSplitModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListBulkEmailSplitModuleImageV2"
			},
			"Hidden": true
		},
		"CampaignPlanner": {
			"Icon": {
				"ImageId": "MobileImageListCampaignPlannerModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListCampaignPlannerModuleImageV2"
			},
			"Hidden": true
		},
		"MktgActivity": {
			"Icon": {
				"ImageId": "MobileImageListMarketingActivityModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListMarketingActivityModuleImageV2"
			},
			"Hidden": true
		},
		"Change": {
			"Icon": {
				"ImageId": "MobileImageListChangeModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListChangeModuleImageV2"
			},
			"Hidden": true
		},
		"Queue": {
			"Icon": {
				"ImageId": "MobileImageListQueueModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListQueueModuleImageV2"
			},
			"Hidden": true
		},
		"SysSchema": {
			"Icon": {
				"ImageId": "MobileImageListSysSchemaModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListSysSchemaModuleImageV2"
			},
			"Hidden": true
		},
		"VwQueueItem": {
			"Icon": {
				"ImageId": "MobileImageListVwQueueItemModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListVwQueueItemModuleImageV2"
			},
			"Hidden": true
		},
		"FinApplication": {
			"Icon": {
				"ImageId": "MobileImageListFinApplicationModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListFinApplicationModuleImageV2"
			},
			"Hidden": true
		},
		"WSColourOfField": {
			"Icon": {
				"ImageId": "MobileImageListWSColourOfFieldModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListWSColourOfFieldModuleImageV2"
			},
			"Hidden": true
		},
		"WSPattern": {
			"Icon": {
				"ImageId": "MobileImageListWSPatternModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListWSPatternModuleImageV2"
			},
			"Hidden": true
		},
		"AppForm": {
			"Icon": {
				"ImageId": "MobileImageListAppFormModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListAppFormModuleImageV2"
			},
			"Hidden": true
		},
		"BankAccount": {
			"Icon": {
				"ImageId": "MobileImageListBankAccountModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListBankAccountModuleImageV2"
			},
			"Hidden": true
		},
		"BankCard": {
			"Icon": {
				"ImageId": "MobileImageListBankCardModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListBankCardModuleImageV2"
			},
			"Hidden": true
		},
		"ExternalAccess": {
			"Icon": {
				"ImageId": "MobileImageListExternalAccessModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListExternalAccessModuleImageV2"
			},
			"Hidden": true
		},
		"FinIndicator": {
			"Icon": {
				"ImageId": "MobileImageListFinIndicatorModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListFinIndicatorModuleImageV2"
			},
			"Hidden": true
		}
	},
	"Models": {
		"SysDashboard": {
			"CacheConfig": {
				"Disable": true
			},
			"RequiredModels": [
				"SysDashboard",
				"SysModule"
			],
			"Grid": "MobileDashboardPage",
			"PagesExtensions": [
				"MobileDashboardPageView",
				"MobileDashboardPageController",
				"MobileDashboardItemPageView",
				"MobileDashboardItemPageController",
				"MobileChartDashboardItemPageView",
				"MobileChartDashboardItemPageController",
				"MobileIndicatorDashboardItemPageView",
				"MobileIndicatorDashboardItemPageController"
			]
		},
		"LocationHistory": {
			"RequiredModels": [
				"LocationHistory"
			],
			"Autoclear": true
		},
		"VisaStatus": {
			"RequiredModels": [
				"VisaStatus"
			]
		}
	},
	"ApplicationRequiredModels": ["Contact", "Account", "SysImage", "SysAdminUnit", "SysSchema",
		"VwSysEntitySchemaInWorkspace", "VwRemindings", "DuplicatesHistory", "SysAdminUnitInRole"]
}