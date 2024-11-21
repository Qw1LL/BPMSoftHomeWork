define("ConfigurationBaseProgressBarGenerator", ["ViewGeneratorV2"], function() {

	/**
	 * @class BPMSoft.configuration.ConfigurationBaseProgressBarGenerator
	 * Generator class for progress bar.
	 */
	Ext.define("BPMSoft.configuration.ConfigurationBaseProgressBarGenerator", {
		alternateClassName: "BPMSoft.ConfigurationBaseProgressBarGenerator",
		extend: "BPMSoft.ViewGenerator",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * Progress bar name.
		 * @protected
		 * @type {String}
		 */
		progressBarName: null,

		/**
		 * Progress bar class name.
		 * @protected
		 * @type {String}
		 */
		progressBarClassName: null,

		/**
		 * Progress bar service properties.
		 * @protected
		 * @type {String[]}
		 */
		serviceProperties: [],

		/**
		 * Generate configuration ProgressBar's component.
		 * @protected
		 * @param {Object} config Configuration which contains properties for generate ProgressBar.
		 * @return {Object} ProgressBar's configuration.
		 */
		generateProgressBar: function(config) {
			var id = config.name || this.progressBarName;
			var progressBar = {
				className: this.progressBarClassName
			};
			this.applyControlId(progressBar, config, id);
			var serviceProperties = this.getConfigWithoutServiceProperties(config, this.serviceProperties);
			Ext.apply(progressBar, serviceProperties);
			this.applyControlConfig(progressBar, config);
			return progressBar;
		}
	});

	return Ext.create("BPMSoft.ConfigurationBaseProgressBarGenerator");
});
