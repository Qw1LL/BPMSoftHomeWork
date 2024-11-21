define("MacroUtils", function() {
	/**
	 * @class BPMSoft.configuration.MacroUtils
	 */
	Ext.define("BPMSoft.configuration.MacroUtils", {
		alternateClassName: "BPMSoft.MacroUtils",

		// region Methods: Public

		/**
		 * Validates given string is a macro.
		 * @param {String} value String value to validate.
		 * @returns {boolean} True if given string is a macro like [#AnyMacroName#].
		 * @public
		 */
		isValueMacro: function(value) {
			var macroRegex = /(^(\[\#.+\#\])$)/;
			return macroRegex.test(value);
		},

		/**
		 * Validates given string contains macro.
		 * @param {String} value String value to validate.
		 * @returns {boolean} True if given string contains a macro like [#AnyMacroName#].
		 * @public
		 */
		isStringContainsMacro: function(value) {
			var stringWithMacroRegex = /^.*?(\[\#.+\#\]).*?$/;
			return stringWithMacroRegex.test(value);
		}

		// endregion

	});

	return Ext.create("BPMSoft.MacroUtils");
});
