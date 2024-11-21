define("ProductSectionV2", ["ProductManagementDistributionConstants"],
	function(DistributionConsts) {
		return {
			entitySchemaName: "Product",
			messages: {
				/**
				 * @message GetBackHistoryState
				 * Returns the path where to move after you press the button
				 * to close the folder level settings window.
				 */
				"GetBackHistoryState": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			properties: {
				folderManagerViewModelClassName: "BPMSoft.ProductCatalogueFolderManagerViewModel"
			},
			methods: {
				/**
				 * Sets the variable current state history.
				 */
				setInitialHistoryState: function() {
					var initialHistoryState = this.sandbox.publish("GetHistoryState").hash.historyState;
					this.set("InitialHistoryState", initialHistoryState);
				},

				/**
				 * @inheritdoc BPMSoft.Configuration.BaseSectionV2#closeCard
				 * @overriden
				 */
				closeCard: function() {
					this.callParent(arguments);
					this.setInitialHistoryState();
				},

				/**
				 * @inheritdoc BPMSoft.Configuration.BaseSectionV2#subscribeSandboxEvents
				 * @overriden
				 */
				subscribeSandboxEvents: function() {
					this.callParent();
					this.setInitialHistoryState();
					this.sandbox.subscribe("GetBackHistoryState", function() {
						return this.get("InitialHistoryState");
					}, this, ["ProductTypeSectionV2", "ProductCatalogueLevelSectionV2"]);
				},

				/**
				 * Returns a collection of actions section.
				 * @protected
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} Collection of actions section.
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Type": "BPMSoft.MenuSeparator",
						"Caption": ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.ConfigureProductCatalogue"},
						"Enabled": true,
						"Click": {"bindTo": "navigateToProductCatalogueLevelSection"}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.ConfigureProductTypes"},
						"Enabled": true,
						"Click": {"bindTo": "navigateToProductTypeSection"}
					}));
					return actionMenuItems;
				},

				/**
				 * Implements the action "Setting up the product catalog"
				 * Go to the section Level product catalog.
				 * @protected
				 */
				navigateToProductCatalogueLevelSection: function() {
					this.sandbox.publish("PushHistoryState", {
						hash: "SectionModuleV2/ProductCatalogueLevelSectionV2"
					});
				},

				/**
				 * Implements the action "Setup type and filter products".
				 * Go to the section Product type.
				 * @protected
				 */
				navigateToProductTypeSection: function() {
					this.sandbox.publish("PushHistoryState", {
						hash: "SectionModuleV2/ProductTypeSectionV2"
					});
				},

				/**
				 * Returns setting group manager.
				 * @protected
				 * @overriden
				 */
				getFolderManagerConfig: function() {
					var config = this.callParent(arguments);
					config.catalogueRootRecordItem = {
						value: DistributionConsts.ProductFolder.RootCatalogueFolder.RootId,
						displayValue: this.get("Resources.Strings.ProductCatalogueRootCaption")
					};
					var filterValue = this.get("SectionFiltersValue");
					if (filterValue && filterValue.getCount() > 0 && filterValue.contains("FolderFilters")) {
						var folderFilter = filterValue.get("FolderFilters");
						config.activeFolderId = (folderFilter && folderFilter.length > 0) ?
							(folderFilter[0].folderId || folderFilter[0].value) : null;
					}
					return config;
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
