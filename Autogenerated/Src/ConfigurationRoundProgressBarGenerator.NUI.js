define("ConfigurationRoundProgressBarGenerator", ["ConfigurationBaseProgressBarGenerator", "RoundProgressBar"],
		function() {

			/**
			 * @class BPMSoft.configuration.ConfigurationRoundProgressBarGenerator
			 * Generator class for round progress bar.
			 */
			Ext.define("BPMSoft.configuration.ConfigurationRoundProgressBarGenerator", {
				alternateClassName: "BPMSoft.ConfigurationRoundProgressBarGenerator",
				extend: "BPMSoft.ConfigurationBaseProgressBarGenerator",

				/**
				 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#progressBarName
				 * @overridden
				 */
				progressBarName: "RoundProgressBar",

				/**
				 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#progressBarClassName
				 * @overridden
				 */
				progressBarClassName: "BPMSoft.RoundProgressBar",

				/**
				 * @inheritdoc BPMSoft.ConfigurationBaseProgressBarGenerator#serviceProperties
				 * @overridden
				 */
				serviceProperties: [
					"menu",
					"value",
					"sectorsBounds",
					"progressColor",
					"sectorsColors",
					"size",
					"clockwise",
					"borderWidth",
					"generator"
				]
			});

			return Ext.create("BPMSoft.ConfigurationRoundProgressBarGenerator");
		});
