{
	"Features": {
		"UseMobileInvoiceCacheManager": {
			"Models": {
				"Invoice": {
					"CacheConfig": {
						"AssociatedModels": [
							"SocialMessage"
						]
					},
					"PagesExtensions": [
						"MobileInvoiceDataCacheManager",
						"MobileInvoiceDataCacheImporter",
						"MobileCacheSyncStateControllerMixin"
					]
				}
			}
		}
	},
	"CustomSchemas": [
		"MobileInvoiceConstants"
	],
	"SyncOptions": {
		"SysSettingsImportConfig": [
			"PrimaryCurrency",
			"InvoicePaymentStatusDef"
		]
	},
	"Modules": {
		"Invoice": {
			"Title": "InvoiceSectionTitle"
		}
	},
	"Models": {
		"Invoice": {
			"RequiredModels": [
				"InvoiceFile"
			],
			"ApprovalSettings": {
				"ListColumns": {
					"Title": "Amount",
					"SubTitle": "Currency.ShortName"
				},
				"CardColumns": ["Amount", "Currency"]
			},
			"Grid": "MobileInvoiceGridPage",
			"PagesExtensions": [
				"MobileInvoiceModuleConfig"
			]
		}
	}
}