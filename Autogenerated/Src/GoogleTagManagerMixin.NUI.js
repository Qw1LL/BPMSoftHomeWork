﻿define("GoogleTagManagerMixin", ["GoogleTagManagerUtilities"],
		function(GoogleTagManagerUtilities) {
			/**
			 * @class BPMSoft.configuration.mixins.GoogleTagManagerMixin
			 * Used to work with google analytics.
			 */
			Ext.define("BPMSoft.configuration.mixins.GoogleTagManagerMixin", {
				alternateClassName: "BPMSoft.GoogleTagManagerMixin",

				//region Properties: Private

				/**
				 * Google tag manager sys setting enabled.
				 * @private
				 * @type {Boolean}
				 */
				_isGoogleTagManagerEnabled: false,

				//endregion

				//region Methods: protected

				/**
				 * Initializes Google tag manager.
				 * @protected
				 */
				initGoogleTagManager: function(callback, scope) {
					if (BPMSoft.isCurrentUserSsp()) {
						this._isGoogleTagManagerEnabled = false;
						Ext.callback(callback, scope);
					} else {
						BPMSoft.SysSettings.querySysSettings(["UseGoogleTagManager"], function (settings) {
							const useGoogleTagManager = settings.UseGoogleTagManager;
							this._isGoogleTagManagerEnabled = useGoogleTagManager;
							Ext.callback(callback, scope);
						}, this);
					}
				},

				/**
				 * Gets GTM data.
				 * @protected
				 * @return {Object}
				 */
				getGoogleTagManagerData: function (data) {
					return Ext.apply({
						schemaName: this.entitySchemaName
					}, data);
				},

				/**
				 * Sends GTM data to google analytics.
				 * @protected
				 */
				sendGoogleTagManagerData: function (data) {
					if (!this.getGoogleTagManagerEnabled()) {
						return;
					}
					GoogleTagManagerUtilities.actionModule(data);
				},

				/**
				 * Checks google tag manager enabled.
				 * @returns {*|Boolean} True if sys setting and tag manager enabled, false otherwise.
				 */
				getGoogleTagManagerEnabled: function () {
					return GoogleTagManagerUtilities.isTagManagerEnabled() && this._isGoogleTagManagerEnabled;
				}

				//endregion

			});
		});
