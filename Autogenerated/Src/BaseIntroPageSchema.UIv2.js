define("BaseIntroPageSchema", ["BaseIntroPageSchemaResources", "MainMenuTileGenerator", "AcademyUtilities"],
	function(resources, MainMenuTileGenerator) {
		return {
			attributes: {
				"LmsUrl": {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				"IsAcademyBannerVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				"IsMobilePannerVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				"IsSdkPanelVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				"IsGettingStartedPanelVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				"IsComunityPanelVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				"IsSocialAccountsPanelVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				"IntroPageWidgetUrl": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				},

				"IsWidgetOnIntroPageVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				"MarketPlaceIframeSource": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				},

				"IsMarketPlaceIframeVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				"ContentBody": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				}
			},
			messages: {
				/**
				 * @message SelectedSideBarItemChanged
				 * Modifies the selection of the current section in the menu of sections in the left panel.
				 * @param {String} Structure of section (E.g. "SectionModuleV2/AccountPageV2/" or "DashboardsModule/").
				 */
				"SelectedSideBarItemChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetHistoryState
				 * Publishing message for HistoryState request.
				 */
				"GetHistoryState": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				/**
				 * Gets feature UseNewWidgetMarketPlace state.
				 * @public
				 * @returns {Object|Boolean|*|boolean}
				 */
				getIsMarketPlacePanelVisible: function() {
					return false;
				},

				/**
				 * Navigate by specified hash.
				 * @protected
				 * @param {Ext.EventObjectImpl} event Event.
				 * @param {String} tag Navigate tag.
				 */
				onNavigateTo: function(event, tag) {
					this.showBodyMask();
					this.sandbox.publish("SelectedSideBarItemChanged", tag, ["sectionMenuModule"]);
					this.sandbox.publish("PushHistoryState", {hash: tag});
					return false;
				},

				/**
				 * Navigates to academy site.
				 * @protected
				 */
				navigateToAcademy: function() {
					var path = this.get("LmsUrl");
					if (path) {
						window.open(path);
					}
				},

				/**
				 * Navigates to marketplace site.
				 * @protected
				 */
				navigateToMarketplace: function() {
					var link = this.get("Resources.Strings.MarketplaceUrl");
					window.open(link);
				},

				/**
				 * Navigates to getting started site.
				 * @protected
				 */
				navigateToGettingStarted: function() {
					var link = this.get("Resources.Strings.GettingStartedUrl");
					window.open(link);
				},

				/**
				 * Navigates to community site.
				 * @protected
				 */
				CommunityClick: function() {
					var communityLink = this.get("Resources.Strings.CommunityUrl");
					window.open(communityLink);
				},

				/**
				 * Navigates to SDK site.
				 * @protected
				 */
				SdkClick: function() {
					BPMSoft.SysSettings.querySysSettingsItem("ConfigurationVersion", function(configurationVersion) {
						var parameters = [];
						parameters.push("product=" + encodeURIComponent("SDK"));
						if (configurationVersion) {
							parameters.push("ver=" + encodeURIComponent(configurationVersion));
						}
						var path = this.get("LmsUrl") + "/documents/?" + parameters.join("&");
						window.open(path);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onRender
				 * @override
				 */
				onRender: function() {
					var isMarketPlacePanelVisible = this.getIsMarketPlacePanelVisible();
					if (!this.getIsMarketPlacePanelVisible()) {
						this._marketPlaceIframeConfigure();
					}
					var sdkContainer = this.Ext.get("sdk-container-el");
					var gettingStartedContainer = this.Ext.get("gettingStarted-container-el");
					var communityContainer = this.Ext.get("community-container-el");
					var marketplaceContainer = isMarketPlacePanelVisible ?
							this.Ext.get("marketplace-container-el") :
							null;
					var academyContainer = this.Ext.get("academy-container-el");
					if (this.isNotEmpty(sdkContainer)) {
						sdkContainer.on("click", this.SdkClick, this);
					}
					if (this.isNotEmpty(gettingStartedContainer)) {
						gettingStartedContainer.on("click", this.navigateToGettingStarted, this);
					}
					if (this.isNotEmpty(communityContainer)) {
						communityContainer.on("click", this.CommunityClick, this);
					}
					if (isMarketPlacePanelVisible && this.isNotEmpty(marketplaceContainer)) {
						marketplaceContainer.on("click", this.navigateToMarketplace, this);
					}
					if (this.isNotEmpty(academyContainer)) {
						academyContainer.on("click", this.navigateToAcademy, this);
					}
					BPMSoft.defer(function() {
						this._initLmsDocumentations();
						this._initWidget();
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @override
				 */
				init: function() {
					this.setEmptyIframeContent();
					this.callParent(arguments);
				},

				/**
				 * @protected
				 * Show empty container for reserved area for iframe
				 */
				setEmptyIframeContent: function() {

					if (!this.getIsMarketPlacePanelVisible()) {

						var emptyContent = "<html style=\"hight: 100%;  overflow: hidden;\" ></html>";
						this.set("ContentBody", emptyContent);

						this.set("IsMarketPlaceIframeVisible", true);

					}
				},

				/**
				 * @private
				 */
				_initWidget: function() {
					BPMSoft.SysSettings.querySysSettings(["ShowWidgetOnIntroPage", "IntroPageWidgetUrl"],
						function(items) {
						var widgetUrl = items.IntroPageWidgetUrl;
						var isWidgetVisible = items.ShowWidgetOnIntroPage || false;
						if (!isWidgetVisible || this.Ext.isEmpty(widgetUrl)) {
							this.set("IsWidgetOnIntroPageVisible", false);
							return;
						}
						this.set("IsWidgetOnIntroPageVisible", true);
						this.set("IntroPageWidgetUrl", widgetUrl);
					}, this);
				},

				/**
				 * @private
				 */
				_onGetAcademyUrlCallback: function(lmsUrl) {
					const {hash} = this.sandbox.publish("GetHistoryState");
					this.sandbox.publish("SelectedSideBarItemChanged", hash?.historyState, ["sectionMenuModule"]);
					this.set("LmsUrl", lmsUrl);
				},

				/**
				 * @private
				 */
				_initLmsDocumentations: function() {
					var sysSettingsNameArray = ["UseLMSDocumentation"];
					BPMSoft.SysSettings.querySysSettings(sysSettingsNameArray, function(values) {
						this.set("UseLMSDocumentation", values.UseLMSDocumentation);
						if (values.UseLMSDocumentation === false) {
							this.set("IsAcademyBannerVisible", false);
						}
						BPMSoft.AcademyUtilities.getUrl({
							scope: this,
							contextHelpCode: this.name,
							callback: this._onGetAcademyUrlCallback
						});
					}, this);
				},

				/**
				 * @private
				 */
				_marketPlaceIframeConfigure: function() {
					var config = {
						serviceName: "MarketPlaceUrlService",
						methodName: "GetUrlMarketPlace",
						data: {
							productCode: this.name
						}
					};
					this.callService(config, function(response) {
						var source = (response && response.GetUrlMarketPlaceResult) || "";
						this.set("MarketPlaceIframeSource", source);
						if (Ext.isEmpty(source)) {
							this.set("IsMarketPlaceIframeVisible", false);
						} else {
							this.set("IsMarketPlaceIframeVisible", true);
						}
					}, this);
				},

				/**
				 * @private
				 * @deprecated
				 */
				_initPageLinks: function() {
					const rightContainer = Ext.get("right-container");
					if (!rightContainer) {
						return;
					}
					const schemaName = this.schemaName || this.name || "";
					const cacheKey = schemaName + "IntroPageLookup";
					var select = new BPMSoft.EntitySchemaQuery({
						rootSchemaName: "IntroPageLookup",
						clientESQCacheParameters: {
							cacheItemName: cacheKey
						},
						serverESQCacheParameters: {
							cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
							cacheGroup: "ApplicationMainMenu",
							cacheItemName: cacheKey
						}
					});
					select.addColumn("VideoUrl");
					select.addColumn("VideoCaption");
					select.filters.addItem(BPMSoft.createColumnFilterWithParameter("CodePage", schemaName));
					select.execute(function(response) {
						this.preparePageLinks(response);
					}, this);
				},

				/**
				 * Gets links from lookup.
				 * @deprecated
				 * @param {Object} response Response from server.
				 */
				preparePageLinks: function(response) {
					const row = response.collection.first();
					const videoUrl = row && row.get("VideoUrl");
					const videoCaption = row && row.get("VideoCaption");
					const videoPanel = Ext.get("VideoPanel");
					var playlist = [];
					if (videoUrl && videoUrl.length > 0) {
						playlist.push({
							videoUrl: videoUrl,
							caption: videoCaption
						});
					} else if (videoPanel) {
						var links = videoPanel.select(".video-link").elements;
						playlist = links.map(function(link) {
							return {
								videoUrl: link.href,
								caption: link.text
							};
						}, this);
					}
					if (playlist.length === 0) {
						return;
					}
					const videoPanelConfig = MainMenuTileGenerator.generateVideoPanel({
						playBtnIcon: resources.localizableImages.playBtn,
						activePlayBtnIcon: resources.localizableImages.playBtnActive,
						playlist: playlist
					});
					const videoPanelEl = Ext.create("BPMSoft.Container", videoPanelConfig);
					if (videoPanel) {
						videoPanel.remove();
					}
					const rightContainer = Ext.get("right-container");
					// videoPanelEl.render(rightContainer, 0);
				}
			},

			diff: [
				{
					"operation": "insert",
					"name": "MainContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"id": "main-container",
						"classes": {
							"wrapClassName": ["main-container", "x-unselectable"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "LeftContainer",
					"propertyName": "items",
					"parentName": "MainContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						id: "left-container",
						"classes": {
							"wrapClassName": ["left-container", "main-container-panel"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "RightContainer",
					"propertyName": "items",
					"parentName": "MainContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"id": "right-container",
						"classes": {
							"wrapClassName": ["right-container", "main-container-panel"]
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "LinksContainer",
					"propertyName": "items",
					"parentName": "RightContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						id: "links-container",
						"classes": {
							"wrapClassName": ["links-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SearchPanel",
					"propertyName": "items",
					"parentName": "RightContainer",
					"values": {
						"generator": "MainMenuTileGenerator.generateSearchBar",
						"searchIcon": resources.localizableImages.SearchIcon,
						"inputPlaceholder": resources.localizableStrings.SearchInputPlaceholder
					}
				},
				{
					"operation": "remove",
					"name": "BPMSoftAccountsLinksPanel",
					"propertyName": "items",
					"parentName": "LinksContainer",
					"values": {
						"generator": "MainMenuTileGenerator.generateBPMSoftAccountsLinks",
						"IsSdkPanelVisible": {"bindTo": "IsSdkPanelVisible"},
						"IsSocialAccountsPanelVisible": {"bindTo": "IsSocialAccountsPanelVisible"},
						"sdkIcon": resources.localizableImages.SdkIcon,
						"sdkCaption": resources.localizableStrings.SdkCaption,
						"isGettingStartedVisible": {"bindTo": "IsGettingStartedPanelVisible"},
						"gettingStartedCaption": {"bindTo": "Resources.Strings.GettingStartedCaption"},
						"gettingStartedLabel": resources.localizableStrings.GettingStartedLabel,
						"gettingStartedIcon": resources.localizableImages.GettingStartedIcon,
						"IsComunityPanelVisible": {"bindTo": "IsComunityPanelVisible"},
						"communityCaption": {"bindTo": "Resources.Strings.CommunityCaption"},
						"communityLabel": resources.localizableStrings.CommunityLabel,
						"communityIcon": resources.localizableImages.CommunityIcon,
						"isMarketplacePanelVisible": {"bindTo": "getIsMarketPlacePanelVisible"},
						"marketplaceCaption": {"bindTo": "Resources.Strings.MarketplaceCaption"},
						"marketplaceLabel": resources.localizableStrings.MarketplaceLabel,
						"marketplaceIcon": resources.localizableImages.MarketplaceIcon,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"socialAccountsCaption": {"bindTo": "Resources.Strings.SocialAccountsCaption"},
						"isAcademyVisible": {bindTo: "IsAcademyBannerVisible"},
						"academyIcon": resources.localizableImages.AcademyBanner,
						"academyCaption": {"bindTo": "Resources.Strings.AcademyCaption"},
						"academyLabel": resources.localizableStrings.BannerCaption,
						"socialAccounts": []
					}
				},
			]
		};
	});
