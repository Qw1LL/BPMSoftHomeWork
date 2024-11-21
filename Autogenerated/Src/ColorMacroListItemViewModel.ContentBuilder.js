define("ColorMacroListItemViewModel", ["BaseMacroListItemViewModel"], function() {
	/**
	 * @class BPMSoft.configuration.ColorMacroListItemViewModel
	 */
	Ext.define("BPMSoft.configuration.ColorMacroListItemViewModel", {
		extend: "BPMSoft.BaseMacroListItemViewModel",
		alternateClassName: "BPMSoft.ColorMacroListItemViewModel",

		/**
		 * @override
		 */
		isEmailMacroButtonVisible: false,

		/**
		 * @inheritdoc BaseMacroListItemViewModel#getMacroInputConfig
		 * @override
		 */
		getMacroInputConfig: function() {
			return [this.getMacroLabelConfig(),
				{
					className: "BPMSoft.ColorButton",
					value: "$Value",
					markerValue: this.getControlMarkerValue(),
					classes: {
						"wrapClasses": ["macro-color-button"]
					},
					menuItemClassName: BPMSoft.MenuItemType.COLOR_PICKER
				}
			];
		}
	});
	return BPMSoft.ColorMacroListItemViewModel;
});
