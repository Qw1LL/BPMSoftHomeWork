define("ContentBlockSection", ["ConfigurationEnums", "GridUtilitiesV2", "ContentBlockSectionGridRowViewModel",
		"css!ContentBlockCSS"],
function(ConfigurationEnums) {
	return {
		entitySchemaName: "ContentBlock",
		diff: /**SCHEMA_DIFF*/[
			
			{
				"operation": "merge",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "CombinedModeActionsButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
				}
			},
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"caption": {"bindTo": "Resources.Strings.AddBlockButtonCaption"}
				}
			},
			{
				"operation": "merge",
				"name": "CombinedModeAddRecordButton",
				"values": {
					"caption": {"bindTo": "Resources.Strings.AddBlockButtonCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "SeparateModeBackButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"index": 2,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.BackButtonCaption"},
					"click": {"bindTo": "closeSection"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"visible": {"bindTo": "SeparateModeActionsButtonVisible"}
				}
			},
			{
				"operation": "merge",
				"name": "DataViewsContainer",
				"values": {
					"wrapClass": [
						"data-views-container-wrapClass",
						"lookup-views-container-wrapClass",
						"lookup-content-block-section"
					]
				}
			}
		]/**SCHEMA_DIFF*/,
		attributes: {
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseSeparatedPageHeader
			 * @overridden
			 */
			"UseSeparatedPageHeader": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseSectionHeaderCaption
			 * @overridden
			 */
			"UseSectionHeaderCaption": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		messages: {

			/**
			 * @message GetExtendedFilterConfig
			 * Quick filters settings generate.
			 */
			"GetExtendedFilterConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addSectionDesignerViewOptions
			 * @overridden
			 */
			addSectionDesignerViewOptions: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addSectionHistoryState
			 * @overridden
			 */
			addSectionHistoryState: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#removeSectionHistoryState
			 * @overridden
			 */
			removeSectionHistoryState: this.BPMSoft.emptyFn,

			/**
			 * Hides "Run process" button menu.
			 * @inheritdoc ProcessEntryPointUtilities#initRunProcessButtonMenu
			 * @overridden
			 */
			initRunProcessButtonMenu: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addCardHistoryState
			 * @overridden
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
					
				if (schemaName && schemaName === 'ContentBlockPage') {
					this.set("UseSectionHeaderCaption", false);
				}
				this.sandbox.publish(eventName, stateConfig);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#removeCardHistoryState
			 * @overridden
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
			 * @inheritdoc BPMSoft.BaseSectionV2#isMultiSelectVisible
			 * @overridden
			 */
			isMultiSelectVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#isSingleSelectVisible
			 * @overridden
			 */
			isSingleSelectVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#isUnSelectVisible
			 * @overridden
			 */
			isUnSelectVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getGridRowViewModelClassName
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.ContentBlockSectionGridRowViewModel";
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getProfileKey
			 * @overridden
			 */
			getProfileKey: function() {
				var currentTabName = this.getActiveViewName();
				var schemaName = this.name;
				return schemaName + this.entitySchemaName + "GridSettings" + currentTabName;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
			 * @overridden
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			/**
			 * Reverses chain to the previous state.
			 * @protected
			 * @virtual
			 */
			closeSection: function() {
				var module = "LookupSection";
				this.sandbox.publish("PushHistoryState", {
					hash: this.BPMSoft.combinePath("SectionModuleV2", module)
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
			 * @overridden
			 */
			getModuleCaption: function() {
				var historyState = this.sandbox.publish("GetHistoryState");
				var state = historyState.state;
				if (state && state.caption) {
					return state.caption;
				}
				if (this.entitySchema) {
					var headerTemplate = this.get("Resources.Strings.HeaderCaptionTemplate");
					return this.Ext.String.format(headerTemplate, this.entitySchema.caption);
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#actualizeTiledGridConfig
			 * @overridden
			 */
			actualizeTiledGridConfig: function(viewGenerator, gridConfig) {
				this.callParent([viewGenerator, gridConfig]);
				this.modifyConfig(gridConfig);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#onGridLoaded
			 * @overridden
			 */
			onGridLoaded: function() {
				this.reloadGridColumnsConfig(false);
			},

			/**
			 * Adds image to tiled grid config.
			 * @protected
			 * @param {Object} gridConfig Tiled grid config.
			 */
			modifyConfig: function(gridConfig) {
				var item = gridConfig.isVertical
					? this.getImageConfigForTiledVerticalGrid()
					: this.getImageConfigForTiledGrid();
				var columnsConfig = gridConfig.tiledConfig.columnsConfig;
				this.Ext.Array.insert(columnsConfig, 0, [item]);
			},

			/**
			 * Returns image config for vertical grid.
			 * @protected
			 * @return {*[]} config.
			 */
			getImageConfigForTiledVerticalGrid: function() {
				return [
					[
						{
							"cols": 24,
							"key": [
								{
									"name": {
										"bindTo": "Image"
									},
									"type": "grid-icon-128x64"
								}
							]
						}
					]
				];
			},

			/**
			 * Returns image config for tiled grid.
			 * @protected
			 * @return {Object} config.
			 */
			getImageConfigForTiledGrid: function() {
				return {
					"cols": 24,
					"key": [
						{
							"name": {
								"bindTo": "Image"
							},
							"type": "grid-icon-128x128"
						}
					]
				};
			},

			/**
			 * @inheritdoc BaseSectionV2#initFilters
			 * @overridden
			 */
			initFilters: function() {
				var quickFilterModuleId = this.getQuickFilterModuleId();
				this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfig,
					this, [quickFilterModuleId]);
				this.callParent(arguments);
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
			}
		}
	};
});
