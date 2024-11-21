define("InvoiceSectionV2", ["ProductSalesUtils", "BaseFiltersGenerateModule", "VisaHelper", "RightUtilities",
	"ReportUtilities", "css!VisaHelper"], function(ProductSalesUtils, BaseFiltersGenerateModule, VisaHelper) {
		return {
			entitySchemaName: "Invoice",
			attributes: {
				/**
				 * ######### ###### #### "######### ## ###########"
				 */
				SendToVisaMenuItemCaption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: VisaHelper.resources.localizableStrings.SendToVisaCaption
				}
			},
			methods: {
				/**
				 * ############# ######## ############## ########### ####### ### ####### "#####"
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1004);
					this.callParent(arguments);
				},

				/**
				 * @overridden
				 * @inheritDoc
				 */
				initFixedFiltersConfig: function() {
					var fixedFilterConfig = {
						entitySchema: this.entitySchema,
						filters: [
							{
								name: "PeriodFilter",
								caption: this.get("Resources.Strings.PeriodFilterCaption"),
								dataValueType: BPMSoft.DataValueType.DATE,
								columnName: "StartDate",
								startDate: {},
								dueDate: {}
							},
							{
								name: "Owner",
								caption: this.get("Resources.Strings.OwnerFilterCaption"),
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								filter: BaseFiltersGenerateModule.OwnerFilter,
								columnName: "Owner"
							}
						]
					};
					this.set("FixedFilterConfig", fixedFilterConfig);
				},

				/**
				 * ######## "######### ## ###########"
				 */
				sendToVisa: VisaHelper.SendToVisaMethod,

				/**
				 * ########## ######### ######## ####### # ###### ########### #######
				 * @protected
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ####### # ######
				 * ########### #######
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {bindTo: "SendToVisaMenuItemCaption"},
						"Click": {bindTo: "sendToVisa"},
						"Enabled": {bindTo: "isSingleSelected"}
					}));
					return actionMenuItems;
				},

				/**
				 * overridden
				 */
				getReportFilters: function() {
					var filters = this.getFilters();
					var recordId = this.get("ActiveRow");
					if (recordId) {
						filters.clear();
						filters.name = "primaryColumnFilter";
						filters.logicalComparisonTypes = BPMSoft.LogicalOperatorType.AND;
						var filter = this.BPMSoft.createColumnInFilterWithParameters(
							this.entitySchema.primaryColumnName, [recordId]);
						filters.addItem(filter);
					}
					return filters;
				},

				/**
				 * ######### ###### ### ######## # #######
				 * @param {Object} config
				 * @overridden
				 * @returns {Boolean}
				 */
				openCardInChain: function(config) {
					if (config && !config.hasOwnProperty("OpenProductSelectionModule")) {
						return this.callParent(arguments);
					}
					return ProductSalesUtils.openProductSelectionModuleInChain(config, this.sandbox);
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
