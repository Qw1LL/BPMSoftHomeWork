﻿define("CheckWSConnectionMixin", ["CheckWSConnectionMixinResources", "DesktopPopupNotification", "RightUtilities",
		"AcademyUtilities"],
	function(resources, DesktopPopupNotification, RightUtilities, AcademyUtilities) {
	/**
	 * @class BPMSoft.configuration.mixins.CheckWSConnectionMixin
	 * Mixin shows notification pop-up if WebSocket is not initialized and user is administrator.
	 */
	Ext.define("BPMSoft.configuration.mixins.CheckWSConnectionMixin", {
		alternateClassName: "BPMSoft.CheckWSConnectionMixin",

		/**
		 * Operations which should be available to the administrator.
		 * @private
		 * @type {String[]}
		 */
		adminOperations: [
			"CanManageSolution",
			"CanSelectEverything",
			"CanDeleteEverything"
		],

		/**
		 * Checks websocket initialization state. Shows notification pop-up if websocket is not working.
		 */
		checkWSInitialized: function() {
			var wsConnectionState = BPMSoft.ServerChannel.getConnectionState();
			if (wsConnectionState === BPMSoft.SocketConnectionState.OPEN) {
				return;
			}
			if (wsConnectionState === BPMSoft.SocketConnectionState.CONNECTING) {
				BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_ERROR, this.checkPermissions, this);
				return;
			}
			this.checkPermissions();
		},

		/**
		 * Checks administrator permissions.
		 * @private
		 */
		checkPermissions: function() {
			BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_ERROR, this.checkPermissions, this);
			if (!BPMSoft.isFirstLogin) {
				return;
			}
			RightUtilities.checkCanExecuteOperations(this.adminOperations, this.onCheckPermssions, this);
		},

		/**
		 * Handler for check administrator permissions.
		 * @protected
		 */
		onCheckPermssions: function(permissions) {
			var values = Ext.Object.getValues(permissions);
			var allow = values.every(function(element) {
				return element;
			});
			if (allow) {
				this.showInformationPopup();
			}
		},

		/**
		 * Shows information popup notification.
		 * @protected
		 */
		showInformationPopup: function() {
			var popupConfig = this.getDefaultInformationConfig();
			this.showPopup(popupConfig);
		},

		/**
		 * Returns default information popup config.
		 * @private
		 * @return {Object} Default popup configuration.
		 */
		getDefaultInformationConfig: function() {
			var icon = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.IconPopup);
			var title = resources.localizableStrings.TitlePopup;
			var body = resources.localizableStrings.BodyPopup;
			var config = {
				id: BPMSoft.generateGUID(),
				title: title,
				icon: icon,
				body: body,
				onClick: this.onClickPopup,
				ignorePageVisibility: true,
				scope: this
			};
			return config;
		},

		/**
		 * Handles popup notification after click.
		 * @protected
		 * @param {Event} event Event show.
		 * @return {Boolean} Always false.
		 */
		onClickPopup: function(event) {
			DesktopPopupNotification.closeNotification(event.target);
			var academyHelpId = resources.localizableStrings.AcademyHelpId;
			var config = {
				scope: this,
				contextHelpId: academyHelpId,
				callback: function(url) {
					window.open(url, "_blank");
				}
			};
			AcademyUtilities.getUrl(config);
			return false;
		},

		/**
		 * Shows popup notification.
		 * @private
		 * @param {Object} config Popup configuration.
		 * @param {String} config.title Title of the popup.
		 * @param {String} config.body Body of the popup.
		 * @param {Object} config.icon Icon of the popup.
		 * @param {Function} config.onClick Handler of the popup click.
		 */
		showPopup: function(config) {
			DesktopPopupNotification.showNotification(config);
		}
	});
});
