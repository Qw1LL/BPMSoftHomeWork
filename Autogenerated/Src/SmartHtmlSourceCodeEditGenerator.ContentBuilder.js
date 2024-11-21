define("SmartHtmlSourceCodeEditGenerator", ["ViewGeneratorV2", "SourceCodeEditGenerator",
		"SmartHtmlSourceCodeEdit"], function() {
	/**
	 * @class BPMSoft.configuration.SourceCodeEditGenerator
	 * Custom view generator for SourceCodeEditor control. Extends BPMSoft.ViewGenerator.
	 */
	Ext.define("BPMSoft.configuration.SmartHtmlSourceCodeEditGenerator", {
		extend: "BPMSoft.SourceCodeEditGenerator",
		alternateClassName: "BPMSoft.SmartHtmlSourceCodeEditGenerator",

		/**
		 * Class name of SourceCodeEdit control.
		 * @type {String}
		 */
		sourceCodeEditClassName: "BPMSoft.SmartHtmlSourceCodeEdit"
	});

	return Ext.create("BPMSoft.SmartHtmlSourceCodeEditGenerator");
});
