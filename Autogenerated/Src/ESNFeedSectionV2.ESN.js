define("ESNFeedSectionV2", [], function() {
	return {
		entitySchemaName: "SocialChannel",
		attributes: {
			/**
			 * ######## ############# "#####"
			 */
			"ESNFeedDataViewName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "ESNFeedDataView"
			}
		},
		messages: {
			"CanSubscribe": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message RemoveChannel
			 * ######### ######### ## ######## ######.
			 */
			"RemoveChannel": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		methods: {

			/**
			 * ############# ######## ## ######### CanSubscribe ## ########.
			 */
			initCanSubscribeChangedHandler: function() {
				this.sandbox.subscribe("CanSubscribe", function(config) {
					this.set(config.key, config.value);
				}, this);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			onDeleted: function(result) {
				this.callParent(result);
				this.sandbox.publish("RemoveChannel", {
					deletedItems: result.DeletedItems
				});
			},

			/**
			 * ######### ###### ##### # ######### #########.
			 * @protected
			 * @param {Boolean} loadData
			 */
			loadESNFeedDataView: function(loadData) {
				if (!loadData) {
					return;
				}
				var isSocialFeedDataView = this.getIsSocialFeedDataView();
				if (!isSocialFeedDataView) {
					return;
				}
				this.loadSocialFeedModule("ESNFeedSectionContainer");
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				this.loadESNFeedDataView(true);
			},

			/**
			 * ########## ####### ####, ### ######## ############# ### #####.
			 * @private
			 * @return {Boolean}
			 */
			getIsSocialFeedDataView: function() {
				return (this.getActiveViewName() === this.get("ESNFeedDataViewName"));
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			loadFiltersModule: function() {
				var isSocialFeedDataView = this.getIsSocialFeedDataView();
				if (isSocialFeedDataView) {
					return;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			loadSummary: function() {
				var isSocialFeedDataView = this.getIsSocialFeedDataView();
				if (isSocialFeedDataView) {
					return;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initSeparateModeActionsButtonHeaderMenuItemCaption: function() {
				var caption = this.getSocialChannelGridDataViewCaption();
				this.set("SeparateModeActionsButtonHeaderMenuItemCaption", caption);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDefaultDataViews: function() {
				var socialChannelDataView = {
					name: this.get("GridDataViewName"),
					active: false,
					caption: this.getSocialChannelGridDataViewCaption(),
					hint: this.get("Resources.Strings.ChannelsViewButtonHint"),
					icon: this.getDefaultGridDataViewIcon()
				};
				var esnFeedDataView = {
					name: this.get("ESNFeedDataViewName"),
					active: true,
					caption: this.getDefaultGridDataViewCaption(),
					hint: this.get("Resources.Strings.FeedViewButtonHint"),
					icon: this.getESNFeedGridDataViewIcon()
				};
				return {
					"ESNFeedDataView": esnFeedDataView,
					"GridDataView": socialChannelDataView
				};
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			changeDataView: function(viewConfig) {
				this.callParent(arguments);
				var viewName = (typeof viewConfig === "string") ? viewConfig : viewConfig.tag;
				var isSocialChannelDataView = (viewName === this.get("GridDataViewName"));
				this.sandbox.publish("ChangeHeaderCaption", {
					caption: isSocialChannelDataView ? this.getSocialChannelGridDataViewCaption() :
						this.getDefaultGridDataViewCaption(),
					dataViews: this.get("DataViews"),
					moduleName: this.name
				});
				this.setHeaderRadius();
				this.changeViewToFeed(isSocialChannelDataView);
			},
			
			/**
			 * Toggle class for #ESNFeedSectionV2SectionWrapContainerContainer on feed page.
			 * @protected
			 */
			changeViewToFeed: function (GridDataViewName) {
				const feedContainer = document.querySelector('.main-content-wrapper')
				if(!GridDataViewName) {
					feedContainer?.classList.add('feed-page')
				} else {
					feedContainer?.classList.remove('feed-page')
				}
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			loadView: function(dataViewName, loadData) {
				var isViewChanged = this.get("IsViewChanged");
				if (!isViewChanged) {
					return;
				}
				var isGridDataView = (dataViewName === this.get("GridDataViewName"));
				if (isGridDataView && loadData) {
					this.callParent([dataViewName, true]);
					var filtersContainerId = "QuickFilterModuleContainer";
					if (this.checkElementExists(filtersContainerId)) {
						this.loadQuickFilterModule(filtersContainerId);
					}
					var summaryContainerId = "SectionSummaryContainer";
					if (this.checkElementExists(summaryContainerId)) {
						this.loadSummaryModule(summaryContainerId);
					}
				} else {
					this.unloadQuickFilterModule();
					this.unloadSummaryModule();
					this.callParent(arguments);
				}
				this.changeViewToFeed(isGridDataView);
			},

			/**
			 * ######### ###### ####### ##########.
			 * @private
			 * @param {String} renderTo
			 */
			loadQuickFilterModule: function(renderTo) {
				var quickFilterModuleId = this.getQuickFilterModuleSandboxId();
				this.sandbox.loadModule("QuickFilterModuleV2", {
					renderTo: renderTo,
					reload: false,
					id: quickFilterModuleId
				});
			},

			/**
			 * ######### ###### ####### ##########.
			 * @private
			 */
			unloadQuickFilterModule: function() {
				var quickFilterModuleSandboxId = this.getQuickFilterModuleSandboxId();
				this.sandbox.unloadModule(quickFilterModuleSandboxId);
			},

			/**
			 * ######### ###### ######.
			 * @private
			 * @param {String} renderTo
			 */
			loadSummaryModule: function(renderTo) {
				var summaryModuleId = this.getSummaryModuleSandboxId();
				this.sandbox.loadModule("SummaryModuleV2", {
					renderTo: renderTo || "SectionSummaryContainer",
					reload: false,
					id: summaryModuleId
				});
			},

			/**
			 * ######### ###### ######.
			 * @private
			 */
			unloadSummaryModule: function() {
				var summaryModuleSandboxId = this.getSummaryModuleSandboxId();
				this.sandbox.unloadModule(summaryModuleSandboxId);
			},

			/**
			 * ######### ###### #####.
			 * @private
			 * @param {String} renderTo
			 */
			loadSocialFeedModule: function(renderTo) {
				var socialFeedModuleId = this.getSocialFeedModuleSandboxId();
				this.sandbox.loadModule("ESNFeedModule", {
					renderTo: renderTo,
					id: socialFeedModuleId,
					reload: false
				});
			},

			/**
			 * ######### ###### #####.
			 * @private
			 */
			unloadSocialFeedModule: function() {
				var socialFeedModuleId = this.getSocialFeedModuleSandboxId();
				this.sandbox.unloadModule(socialFeedModuleId);
			},

			/**
			 * ######### ####### ######## # ########.
			 * @param {String} elementId ############# ########.
			 * @return {Boolean} ####### ######## # ########.
			 */
			checkElementExists: function(elementId) {
				var container = this.Ext.getCmp(elementId);
				return Boolean(container);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			setActiveView: function(activeViewName) {
				this.showBodyMask({timeout: 0});
				var isSocialFeedDataView = this.getIsSocialFeedDataView();
				if (isSocialFeedDataView && this.get("IsViewChanged")) {
					var isAnySelected = this.isAnySelected();
					if (isAnySelected) {
						this.deselectRows();
					}
				}
				var dataViewVisiblePropertyName = this.getDataViewVisiblePropertyName(activeViewName);
				var isViewChanged = !this.get(dataViewVisiblePropertyName);
				this.set("IsViewChanged", isViewChanged);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.initCanSubscribeChangedHandler();
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1036);
				this.callParent(arguments);
			},

			/**
			 * ########## ######### ############# "#####".
			 * @private
			 * @return {String}
			 */
			getSocialChannelGridDataViewCaption: function() {
				return this.get("Resources.Strings.SocialChannelSectionCaption");
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDefaultGridDataViewCaption: function() {
				return this.get("Resources.Strings.GridDataViewCaption");
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDefaultGridDataViewIcon: function() {
				return this.get("Resources.Images.GridDataViewIcon");
			},

			/**
			 * ########## ########### ############# #####.
			 * @protected
			 */
			getESNFeedGridDataViewIcon: function() {
				return this.get("Resources.Images.ESNFeedDataViewIcon");
			},

			/**
			 * ########## ######### ###### ##### #############.
			 * @private
			 * @return {boolean}
			 */
			getActionButtonsVisible: function() {
				return (this.get("ActiveViewName") !== this.get("ESNFeedDataViewName"));
			},

			/**
			 * ########## ############# ###### #####.
			 * @private
			 * @return {string} ############# ###### #####.
			 */
			getSocialFeedModuleSandboxId: function() {
				return this.sandbox.id + "_ESNFeed";
			},

			/**
			 * ########## ############# ###### ####### ##########.
			 * @private
			 * @return {string} ############# ###### ####### ##########.
			 */
			getQuickFilterModuleSandboxId: function() {
				return this.sandbox.id + "_QuickFilterModuleV2";
			},

			/**
			 * ########## ############# ###### ######.
			 * @private
			 * @return {string} ############# ###### ######.
			 */
			getSummaryModuleSandboxId: function() {
				return this.sandbox.id + "_SummaryModuleV2";
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			updateSection: function() {
				var isSocialFeedDataView = this.getIsSocialFeedDataView();
				if (isSocialFeedDataView) {
					return;
				}
				this.callParent(arguments);
			},
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"index": 3,
				"parentName": "CombinedModeActionButtonsCardLeftContainer",
				"propertyName": "items",
				"name": "SubscribeChannelButton",
				"values": {
					"caption": {"bindTo": "getChangeUserSubscriptionCaption"},
					"enabled": {"bindTo": "getChangeUserSubscriptionIsEnabled"},
					"tag": "changeUserSubscription",
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "onCardAction"},
					"classes": {"textClass": ["actions-button-margin-right"]},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE
				}
			},
			{
				"operation": "merge",
				"name": "SaveRecordButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				}
			},
			{
				"operation": "merge",
				"name": "DiscardChangesButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
				}
			},
			{
				"operation": "merge",
				"name": "CloseButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				}
			},
			{
				"operation": "merge",
				"name": "CombinedModeActionsButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
				}
			},
			{
				"operation": "remove",
				"parentName": "RightContainer",
				"propertyName": "items",
				"name": "ViewOptionsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ViewOptionsButtonCaption"}
				}
			},
			{
				"operation": "merge",
				"name": "GridUtilsContainer",
				"parentName": "DataViewsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["utils-container-wrapClass"],
					"visible": {"bindTo": "getActionButtonsVisible"}
				}
			},
			{
				"operation": "merge",
				"name": "ActionButtonsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"id": "ActionButtonsContainer",
					"selectors": {"wrapEl": "#ActionButtonsContainer"},
					"wrapClass": ["action-buttons-container-wrapClass"],
					"visible": {
						"bindTo": "getActionButtonsVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ESNFeedDataView",
				"parentName": "DataViewsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.SECTION_VIEW,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ESNFeedSectionContainer",
				"parentName": "ESNFeedDataView",
				"propertyName": "items",
				"values": {
					"id": "ESNFeedSectionContainer",
					"selectors": {"wrapEl": "#ESNFeedSectionContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["esnFeedSection-container-margin"],
					"items": []
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
