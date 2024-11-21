define("HtmlControlGeneratorV2", ["ext-base", "BPMSoft", "ViewGeneratorV2"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.HtmlControlGenerator", {
		extend: "BPMSoft.ViewGenerator",
		alternateClassName: "BPMSoft.HtmlControlGenerator",

		/**
		 * Generates options for creating controls.
		 * @param {Object} config Options for generator.
		 * @return {Object} Options for creating controls.
		 */
		generateCustomHtmlControl: function(config) {
			var id = this.getControlId(config, "BPMSoft.HtmlControl");
			var controlConfig = {
				className: "BPMSoft.HtmlControl",
				htmlContent: config.htmlContent
			};
			this.applyControlId(controlConfig, config, id);
			Ext.apply(controlConfig, this.getConfigWithoutServiceProperties(config, ["generator", "htmlContent"]));
			return controlConfig;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#getControlId
		 * @overridden
		 */
		getControlId: function(config) {
			return config.name + BPMSoft.generateGUID() + "HtmlControl";
		},

		/**
		 * Forms creation options to control the display of html control.
		 * @param {Object} config Options for generator.
		 * @return {Object} Options to control the display of html control.
		 */
		generateHtmlControl: function(config) {
			var initialConfig = this.generateCustomHtmlControl(config);
			initialConfig.tpl = [
				/*jshint quotmark:true */
				'<div id="{id}" class="{wrapClass}">',
				'{htmlContent}',
				'</div>'
				/*jshint quotmark:false */
			];
			return initialConfig;
		}
	});
	return Ext.create(BPMSoft.HtmlControlGenerator);
});
