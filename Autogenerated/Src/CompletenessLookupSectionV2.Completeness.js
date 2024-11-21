define("CompletenessLookupSectionV2", ["ConfigurationEnums", "CompletenessLookupSectionV2Resources"],
	function(ConfigurationEnums) {
		return {
			entitySchemaName: "Completeness",
			attributes: {
				"UseTagModule": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

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
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			}, {
				"operation": "remove",
				"name": "DataGridActiveRowDeleteAction"
			}, {
				"operation": "remove",
				"name": "ProcessEntryPointGridRowButton"
			}, {
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			}, {
				"operation": "remove",
				"name": "activeRowActionCopy"
			}, {
				"operation": "remove",
				"name": "activeRowActionRemove"
			}, {
				"operation": "remove",
				"name": "activeRowActionSave"
			}, {
				"operation": "insert",
				"name": "SeparateModeBackButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"caption": {
						"bindTo": "Resources.Strings.BackButtonCaption"
					},
					"click": {
						"bindTo": "closeSection"
					},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"visible": {
						"bindTo": "SeparateModeActionsButtonVisible"
					}
				}
			}, {
				"operation": "merge",
				"name": "DataViewsContainer",
				"values":
				{
					"wrapClass": ["data-views-container-wrapClass", "data-view-border-right",
						"right-inner-el", "lookup-views-container-wrapClass"]
				}
			}] /**SCHEMA_DIFF*/,
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#addSectionDesignerViewOptions
				 * @overridden
				 */
				addSectionDesignerViewOptions: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				addSectionHistoryState: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				addCardHistoryState: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				removeCardHistoryState: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				removeSectionHistoryState: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#editRecord
				 * @overridden
				 */
				editRecord: function(primaryColumnValue) {
					var activeRow = this.getActiveRow();
					var typeColumnValue = this.getTypeColumnValue(activeRow);
					var schemaName = this.getEditPageSchemaName(typeColumnValue);
					this.openCardInChain({
						id: primaryColumnValue,
						schemaName: schemaName,
						operation: ConfigurationEnums.CardStateV2.EDIT,
						moduleId: this.getChainCardModuleSandboxId(typeColumnValue)
					});
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
				 * @inheritdoc BPMSoft.BaseSectionV2#getViewOptions
				 * @overridden
				 */
				getViewOptions: function() {
					var viewOptions = this.Ext.create("BPMSoft.BaseViewModelCollection");
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.SortMenuCaption"
						},
						"Items": this.get("SortColumns")
					}));
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.OpenGridSettingsCaption"
						},
						"Click": {
							"bindTo": "openGridSettings"
						}
					}));
					return viewOptions;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
				 * @overridden
				 */
				getModuleCaption: function() {
					return (this.entitySchema && this.entitySchema.caption);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getCardModuleResponseTags
				 * @overridden
				 */
				getCardModuleResponseTags: function() {
					var editCardsSandboxIds = this.callParent(arguments);
					editCardsSandboxIds.push(this.getChainCardModuleSandboxId(BPMSoft.GUID_EMPTY));
					return editCardsSandboxIds;
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
				 * Closes section.
				 * @protected
				 * @virtual
				 */
				closeSection: function() {
					this.sandbox.publish("BackHistoryState");
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
				}
			}
		};
	}
);
