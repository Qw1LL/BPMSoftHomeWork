define("CampaignMessageBoxUtilities", ["CampaignMessageBoxUtilitiesResources"], function() {
	Ext.define("BPMSoft.configuration.CampaignMessageBoxUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.CampaignMessageBoxUtilities",
		singleton: true,
	
		/**
		 * Returning codes for campaign message box buttons.
		 * @public
		 */
		buttonReturnCodes: {
			/**
			 * Uses for continue current execution flow.
			 */
			CONTINUE: "continue",
			/**
			 * Uses for call campaign hard stop process.
			 */
			HARD_STOP: "hardStop",
			/**
			 * Uses for call campaign soft stop process.
			 */
			SOFT_STOP: "softStop"
		},
	
		/**
		 * Returns config object of controls to display message box.
		 * @param {String} message Message.
		 * @private
		 * @return {Object} config.
		 */
		_getCampaignMessageBoxControlConfig: function(message) {
			var controlConfig = {
				memo: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: message,
					customConfig: {
						className: "BPMSoft.MemoEdit",
						height: "235px",
						readonly: true,
						markerValue: "validationMessage"
					}
				}
			};
			return controlConfig;
		},
	
		/**
		 * Shows dialog window for campaigns.
		 * @public
		 * @param {Object} config Configuration object
		 */
		showMessageBox: function(config) {
			if (config.message) {
				config.customWrapClass = config.customWrapClass || "ts-campaign-message-box";
				config.controlConfig = config.controlConfig || this._getCampaignMessageBoxControlConfig(config.message);
			}
			BPMSoft.utils.showMessage(config);
		},
	
		/**
		 * Returns Button with applied config.
		 * @public
		 * @param {Object} config Parameters to apply on button.
		 * @returns {Object} New Button oblect.
		 */
		getButton: function(config) {
			return {
				className: "BPMSoft.Button",
				returnCode: config.returnCode,
				style: config.style,
				caption: config.caption,
				markerValue: config.caption
			};
		}
	});
	return BPMSoft.CampaignMessageBoxUtilities;
});