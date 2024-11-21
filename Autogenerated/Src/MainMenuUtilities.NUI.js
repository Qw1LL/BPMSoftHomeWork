define("MainMenuUtilities", ["ConfigurationServiceProvider"], function() {

	/**
	 * Main menu utilities.
	 */
	Ext.define("BPMSoft.configuration.MainMenuUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.MainMenuUtilities",

		singleton: true,

		// region Methods: Private

		/**
		 * @private
		 */
		_replaceWindowLocation: function(location) {
			window.location.replace(location);
		},

		/**
		 * @private
		 */
		_logoutServiceCallback: function(response) {
			let loginUrl = BPMSoft.loaderBaseUrl + "?simpleLogin";
			if ((response && response.RedirectLocation)) {
				loginUrl =  response.RedirectLocation
			} else {
				window.logout = true;
			}
			this._replaceWindowLocation(loginUrl);
		},

		// endregion

		// region Methods: Public

		/**
		 * Perform logout with redirection to login page.
		 */
		logout: async function() {
			const config = {
				serviceName: "MainMenuService",
				methodName: "Logout"
			};
			await BPMSoft.CtiModel.onLogoutActionAsync();
			BPMSoft.ConfigurationServiceProvider.callService(config, this._logoutServiceCallback, this);
		}

		// endregion

	});

	return BPMSoft.MainMenuUtilities;
});
