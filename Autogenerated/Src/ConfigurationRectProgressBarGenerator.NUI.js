define("ConfigurationRectProgressBarGenerator", ["ConfigurationBaseProgressBarGenerator", "RectProgressBar"],
		function() {

			/**
			 * @class BPMSoft.configuration.ConfigurationRectProgressBarGenerator
			 * Generator class for rectangle progress bar.
			 */
			Ext.define("BPMSoft.configuration.ConfigurationRectProgressBarGenerator", {
				alternateClassName: "BPMSoft.ConfigurationRectProgressBarGenerator",
				extend: "BPMSoft.ConfigurationBaseProgressBarGenerator",

				/**
				 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#progressBarName
				 * @overridden
				 */
				progressBarName: "RectProgressBar",

				/**
				 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#progressBarClassName
				 * @overridden
				 */
				progressBarClassName: "BPMSoft.RectProgressBar",

				/**
				 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#serviceProperties
				 * @overridden
				 */
				serviceProperties: [
					"horizontal",
					"menu",
					"value",
					"sectorsBounds",
					"progressColor",
					"sectorsColors",
					"generator"
				]
			});

			return Ext.create("BPMSoft.ConfigurationRectProgressBarGenerator");
		});
