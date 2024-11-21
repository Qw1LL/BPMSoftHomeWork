/**
 * Parent: BaseSectionV2
 */
define("BaseLookupSection", ["ConfigurationEnums",
	"GridUtilitiesV2",
	"css!BaseLookupSectionCSS"
], function(ConfigurationEnums) {
	return {
		contextHelpId: "",
		messages: {
			/**
			 * Publish the message reshaping the summary module.
			 */
			"GetModuleSchema": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Quick filters settings generate.
			 */
			"GetExtendedFilterConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseSeparatedPageHeader
			 * @override
			 */
			"UseSeparatedPageHeader": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseSectionHeaderCaption
			 * @override
			 */
			"UseSectionHeaderCaption": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#IsIncludeInFolderButtonVisible
			 * @override
			 */
			"IsIncludeInFolderButtonVisible": {
				value: false
			},
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseFolderFilter
			 * @override
			 */
			"UseFolderFilter": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @override
			 */
			init: function() {
				this.set("IsIncludeInFolderButtonVisible", false);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addSectionDesignerViewOptions
			 * @override
			 */
			addSectionDesignerViewOptions: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addSectionHistoryState
			 * @override
			 */
			addSectionHistoryState: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#removeSectionHistoryState
			 * @override
			 */
			removeSectionHistoryState: BPMSoft.emptyFn,

			/**
			 * Hides menu button "Start process".
			 * @inheritdoc ProcessEntryPointUtilities#initRunProcessButtonMenu
			 * @override
			 */
			initRunProcessButtonMenu: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addCardHistoryState
			 * @override
			 */
			addCardHistoryState: function(schemaName, operation, primaryColumnValue) {
				if (!schemaName) {
					return;
				}
				var cardOperationConfig = {
					schemaName: schemaName,
					operation: operation,
					primaryColumnValue: primaryColumnValue
				};
				var historyState = this.getHistoryStateInfo();
				var stateConfig = this.getCardHistoryStateConfig(cardOperationConfig);
				var eventName = (historyState.workAreaMode === ConfigurationEnums.WorkAreaMode.COMBINED)
					? "ReplaceHistoryState"
					: "PushHistoryState";
				this.sandbox.publish(eventName, stateConfig);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#removeCardHistoryState
			 * @override
			 */
			removeCardHistoryState: function() {
				var module = "LookupSectionModule";
				var schema = this.name;
				var historyState = this.sandbox.publish("GetHistoryState");
				var currentState = historyState.state;
				var newState = {
					moduleId: currentState.moduleId
				};
				var hash = [module, schema].join("/");
				this.sandbox.publish("PushHistoryState", {
					hash: hash,
					stateObj: newState,
					silent: true
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getProfileKey
			 * @override
			 */
			getProfileKey: function() {
				var currentTabName = this.getActiveViewName();
				var schemaName = this.name;
				return schemaName + this.entitySchemaName + "GridSettings" + currentTabName;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
			 * @override
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				var quickFilterModuleId = this.sandbox.id + "_QuickFilterModuleV2";
				this.sandbox.subscribe("GetModuleSchema", this.getModuleSchema, this, [quickFilterModuleId]);
			},

			/**
			 * @inheritdoc BaseSectionV2#initFilters
			 * @override
			 */
			initFilters: function() {
				var quickFilterModuleId = this.getQuickFilterModuleId();
				this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfig,
					this, [quickFilterModuleId]);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getSectionCode
			 * @override
			 */
			getSectionCode: function() {
				return this.entitySchemaName || "Lookup";
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
			 * @override
			 */
			getModuleCaption: function() {
				var historyState = this.sandbox.publish("GetHistoryState");
				var state = historyState.state;
				if (state && state.caption) {
					return state.caption;
				}
				if (this.entitySchema) {
					var headerTemplate = this.get("Resources.Strings.HeaderCaptionTemplate");
					return Ext.String.format(headerTemplate, this.entitySchema.caption);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				if (!this.get("Restored")) {
					this.reloadGridColumnsConfig(true);
				}
				this.changeSelectedSideBarMenu();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#requireProfile
			 * @override
			 */
			requireProfile: function(callback, scope) {
				this.callParent([function(profile) {
					if (BPMSoft.isEmptyObject(profile)) {
						profile = this.generateEntityProfile();
					}
					Ext.callback(callback, scope, [profile]);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getFilterFromStorage
			 * @override
			 */
			getFilterFromStorage: function(callback, scope) {
				var storage = BPMSoft.configuration.Storage;
				var filters = storage.Filters = storage.Filters || {};
				filters[this.name] = {};
				Ext.callback(callback, scope || this);
			},

			/**
			 * Returns the schema of the current section.
			 * @protected
			 * @return {BPMSoft.BaseEntitySchema} Current section entity schema.
			 */
			getModuleSchema: function() {
				return this.entitySchema;
			},

			/**
			 * Discards chain to previous state.
			 * @protected
			 */
			closeSection: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: BPMSoft.combinePath("SectionModuleV2", "LookupSection")
				});
			},

			/**
			 * Returns quick filters current section settings.
			 * @protected
			 * @return {Object} Filter settings.
			 */
			onGetExtendedFilterConfig: function() {
				return {
					isFoldersHidden: true,
					hasExtendedMode: false
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#loadSummaryModule
			 * @override
			 */
			loadSummaryModule: function() {
				this.sandbox.loadModule("SummaryModuleV2", {
					renderTo: "SectionSummaryContainer",
					instanceConfig: {
						messagePublishTags: [this.getSummaryModuleSandboxId()]
					}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#loadSummary
			 * @override
			 */
			loadSummary: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("GetSectionModuleId", function() {
					return this.sandbox.id;
				}, this, [this.getSummaryModuleSandboxId()]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#initGetFiltersMessage
			 * @override
			 */
			initGetFiltersMessage: function() {
				this.callParent(arguments);
				const sandboxId = this.getSummaryModuleSandboxId();
				this.sandbox.subscribe("GetFiltersCollection", this.onGetFiltersCollection, this, [sandboxId]);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "SeparateModeBackButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"index": 2,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.BackButtonCaption"},
					"click": {"bindTo": "closeSection"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"visible": {"bindTo": "SeparateModeActionsButtonVisible"},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
				}
			},
			{
				"operation": "merge",
				"name": "DataViewsContainer",
				"values": {
					"wrapClass": ["data-views-container-wrapClass", "data-view-border-right",
						"right-inner-el", "lookup-views-container-wrapClass"]
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
