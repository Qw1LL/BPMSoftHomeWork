define("IntroPageUtilities", ["BPMSoft"], function(BPMSoft) {

	/**
	 * Intro page utilities.
	 */
	Ext.define("BPMSoft.configuration.IntroPageUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.IntroPageUtilities",

		singleton: true,

		// region Methods: Public

		/**
		 * Returns the name of the main page by default.
		 * @param {String} defaultIntroPageId The Id value for the master page by default.
		 * @param {Function} callback The callback function
		 * @param {Object} scope The scope of callback function.
		 */
		getDefaultIntroPageName: function(defaultIntroPageId, callback, scope) {
			callback.call(scope, BPMSoft.configuration.defaultIntroPageName);
		}

		// endregion

	});

	return BPMSoft.IntroPageUtilities;
});
