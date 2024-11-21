define("ContractSectionV2", ["GridUtilitiesV2", "VisaHelper"],
function(GridUtilitiesV2, VisaHelper) {
	return {
		entitySchemaName: "Contract",
		attributes: {
			/**
			 * ######### ###### #### "######### ## ###########"
			 */
			SendToVisaMenuItemCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: VisaHelper.resources.localizableStrings.SendToVisaCaption
			}
		},
		contextHelpId: "1071",
		diff: /**SCHEMA_DIFF*/[
		]/**SCHEMA_DIFF*/,
		messages: {},
		methods: {
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
			 * @inheritdoc BPMSoft.BaseSectionV2#initContextHelp
			 * @overridden
			*/
			initContextHelp: function() {
				this.set("ContextHelpId", 1071);
				this.callParent(arguments);
			}
		}
	};
});
