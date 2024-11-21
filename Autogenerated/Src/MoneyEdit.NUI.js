define("MoneyEdit", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.controls.MoneyEdit
	 * Control for editing values with money data type.
	 */
	Ext.define("BPMSoft.controls.MoneyEdit", {
		extend: "BPMSoft.FloatEdit",
		alternateClassName: "BPMSoft.MoneyEdit",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.FloatEdit#decimalPrecision
		 * @overridden
		 */
		decimalPrecision: null,

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.NumberEdit#init
		 * @overridden
		 */
		init: function() {
			if (this.decimalPrecision === null) {
				this.decimalPrecision = BPMSoft.SysValue.CURRENT_MONEY_DISPLAY_PRECISION;
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.controls.NumberEdit#getFormattedNumberValue
		 * @overridden
		 */
		getFormattedNumberValue: function(value) {
			var config = Ext.apply({}, this.displayNumberConfig);
			config.type = BPMSoft.DataValueType.MONEY;
			return BPMSoft.getFormattedNumberValue(value, config);
		}

		//endregion

	});

});
