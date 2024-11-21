define("IconizedProgressBarGenerator", ["ConfigurationBaseProgressBarGenerator", "IconizedProgressBar"],
		function() {
	/**
	 * @class BPMSoft.configuration.IconizedProgressBarGenerator
	 * Generator class for customizable with icons progress bar.
	 */
	Ext.define("BPMSoft.configuration.IconizedProgressBarGenerator", {
		alternateClassName: "BPMSoft.IconizedProgressBarGenerator",
		extend: "BPMSoft.ConfigurationBaseProgressBarGenerator",

		/**
		 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#progressBarName
		 * @override
		 */
		progressBarName: "IconizedProgressBar",

		/**
		 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#progressBarClassName
		 * @override
		 */
		progressBarClassName: "BPMSoft.IconizedProgressBar",

		/**
		 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#serviceProperties
		 * @override
		 */
		serviceProperties: [
			"horizontal",
			"menu",
			"value",
			"sectorsBounds",
			"progressColor",
			"sectorsColors",
			"pointIconUrl",
			"generator"
		]
	});

	return Ext.create("BPMSoft.IconizedProgressBarGenerator");
});
