define("OAuthAuthenticationMixin", [], function() {
		/**
		 * @class BPMSoft.configuration.mixins.OAuthAuthenticationMixin
		 * The mixin to work with OAuth authentication.
		 */
		Ext.define("BPMSoft.configuration.mixins.OAuthAuthenticationMixin", {
			alternateClassName: "BPMSoft.OAuthAuthenticationMixin",

			//region Fields: Private

			/**
			 * Request URL template.
			 * @type {String}
			 */
			_requestUrlTemplate: "{0}/rest/{1}/AuthenticateUser?userLogin={2}&mailServerId={3}",

			//endregion

			//region Methods: Public

			/**
			 * Redirect to OAuth authentication server.
			 * @param {String} email User email address.
			 * @param {String} applicationName OAuth application name.
			 * @param {String} itemId MailBox server id.
			 */
			useOAuthAuthentication: function(email, applicationName, itemId) {
				this.BPMSoft.AjaxProvider.request({
					url: Ext.String.format(
						this._requestUrlTemplate, this.BPMSoft.workspaceBaseUrl, applicationName, email, itemId),
					headers: {
						"Accept": "application/json",
						"Content-Type": "application/json"
					},
					method: "GET",
					callback: function(request, success, response) {
						var responseObject = this.BPMSoft.decode(response.responseText);
						var document = Ext.getDoc();
						document.dom.location = responseObject.AuthenticateUserResult;
					},
					scope: this
				});
			}

			//endregion
		});

		return BPMSoft.OAuthAuthenticationMixin;
	}
);
