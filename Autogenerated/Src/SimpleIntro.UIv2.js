define("SimpleIntro", ["SimpleIntroResources", "ConfigurationConstants"], function(resources, ConfigurationConstants) {
		return {
			attributes: {
				"SystemDesignerVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseIntroPageSchema#init
				 * @overridden
				 * @protected
				 */
				init: function() {
					this.callParent(arguments);
					this.isSystemDesignerVisible();
				},

				//endregion

				//region Methods: Public

				/**
				 * Sets visibility for "System designer" menu item.
				 */
				isSystemDesignerVisible: function() {
					BPMSoft.SysSettings.querySysSettings(["BuildType"], function(sysSettings) {
						var buildType = sysSettings.BuildType;
						if (buildType && (buildType.value === ConfigurationConstants.BuildType.Public)) {
							this.set("SystemDesignerVisible", false);
						} else {
							this.set("SystemDesignerVisible", true);
						}
					}, this);
				}

				//endregion

			},
			diff: [
				{
					"operation": "merge",
					"name": "MainContainer",
					"values": {
						"markerValue": "main-menu"
					}
				},
				{
					"operation": "insert",
					"name": "BasicTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.BasisCaption"},
						"cls": "basis",
						"icon": resources.localizableImages.BasisIcon,
						"items": []
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "ESNFeedSectionV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"moduleName": "ESNFeed",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "AccountSectionV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"moduleName": "Account",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "ContactSectionV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"moduleName": "Contact",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "EmployeeSection",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"moduleName": "Employee",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "ActivitySectionV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"moduleName": "Activity",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "KnowledgeBaseSectionV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.KnowlegebaseSectionCaption"},
						"tag": "SectionModuleV2/KnowledgeBaseSectionV2/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"name": "AnalyticsTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.AnalyticsCaption"},
						"cls": "analytics",
						"icon": resources.localizableImages.AnalyticsIcon,
						"items": []
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "AnalyticsTile",
					"name": "DashboardsModule",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"moduleName": "Dashboard",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"name": "SettingsTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.SettingsCaption"},
						"cls": "settings",
						"icon": resources.localizableImages.SettingsIcon,
						"items": []
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "SettingsTile",
					"name": "SystemDesigner",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.SectionDesignerCaption"},
						"tag": "IntroPage/SystemDesigner",
						"click": {"bindTo": "onNavigateTo"},
						"visible": {"bindTo": "SystemDesignerVisible"},
						"maskVisible": true
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "SettingsTile",
					"name": "UserProfile",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ProfileCaption"},
						"tag": "UserProfile",
						"click": {"bindTo": "onNavigateTo"}
					}
				}
			]
		};
	});
