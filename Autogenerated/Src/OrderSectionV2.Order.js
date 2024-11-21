define("OrderSectionV2", ["ProductSalesUtils", "BaseFiltersGenerateModule", "VisaHelper", "ReportUtilities",
	"css!VisaHelper"], function(ProductSalesUtils, BaseFiltersGenerateModule, VisaHelper) {
	return {
		entitySchemaName: "Order",
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
			 * ############# ############# ########### #######.
			 * @protected
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1055);
				this.callParent(arguments);
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
			},

			/**
			 * @inheritdoc BaseSectionV2#initFixedFiltersConfig
			 * @overridden
			 */
			initFixedFiltersConfig: function() {
				var fixedFilterConfig = {
					entitySchema: this.entitySchema,
					filters: [
						{
							name: "PeriodFilter",
							caption: this.get("Resources.Strings.PeriodFilterCaption"),
							dataValueType: this.BPMSoft.DataValueType.DATE,
							columnName: "Date",
							startDate: {
								defValue: this.BPMSoft.startOfWeek(new Date())
							},
							dueDate: {
								defValue: this.BPMSoft.endOfWeek(new Date())
							}
						},
						{
							name: "Owner",
							caption: this.get("Resources.Strings.OwnerFilterCaption"),
							dataValueType: this.BPMSoft.DataValueType.LOOKUP,
							defValue: this.BPMSoft.SysValue.CURRENT_USER_CONTACT,
							filter: BaseFiltersGenerateModule.OwnerFilter,
							columnName: "Owner"
						}
					]
				};
				this.set("FixedFilterConfig", fixedFilterConfig);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
