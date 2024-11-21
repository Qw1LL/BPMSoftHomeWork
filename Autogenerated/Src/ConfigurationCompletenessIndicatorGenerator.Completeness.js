define("ConfigurationCompletenessIndicatorGenerator", ["CompletenessIndicator",
		"ConfigurationRoundProgressBarGenerator"
	],
	function() {

		/**
		 * @class BPMSoft.configuration.ConfigurationCompletenessIndicatorGenerator
		 * Generator class for round completeness indicator.
		 * @deprecated Use {@link #BPMSoft.ConfigurationRoundProgressBarGenerator}.
		 */
		Ext.define("BPMSoft.configuration.ConfigurationCompletenessIndicatorGenerator", {
			alternateClassName: "BPMSoft.ConfigurationCompletenessIndicatorGenerator",
			extend: "BPMSoft.ConfigurationRoundProgressBarGenerator",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ########## ############ ########## CompletenessIndicator.
			 * @protected
			 * @param {Object} config ############, ####### ######## ######## ### ######### CompletenessIndicator.
			 * @return {Object} ############ ########## CompletenessIndicator.
			 */
			generateCompletenessIndicator: function(config) {
				config = Ext.apply(config, {
					className: "BPMSoft.CompletenessIndicator"
				});
				var serviceProperties = this.getConfigWithoutServiceProperties(config, ["menu", "generator"]);
				var baseConfig = this.generateProgressBar(config);
				Ext.apply(baseConfig, serviceProperties);
				return baseConfig;
			}
		});

		return Ext.create("BPMSoft.ConfigurationCompletenessIndicatorGenerator");
	}
);
