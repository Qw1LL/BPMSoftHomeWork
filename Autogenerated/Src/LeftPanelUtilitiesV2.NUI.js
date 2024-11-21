define("LeftPanelUtilitiesV2", ["ext-base", "BPMSoft", "ConfigurationConstants", "profile!LeftPanelCollapsed"],
	function(Ext, BPMSoft, ConfigurationConstants, profile) {
	/**
	 * @class BPMSoft.configuration.LeftPanelUtilities
	 * ############### ##### ###### # ##### ####### ####### ##########
	 */
	Ext.define("BPMSoft.configuration.LeftPanelUtilitiesV2", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.LeftPanelUtilitiesV2",

		/**
		 * ####### ############# #######.
		 * @private
		 * @type {Boolean}
		 */
		useProfile: true,

		/**
		 * ########### ######.
		 * @returns {BPMSoft.configuration.LeftPanelUtilities} ########## ######### ######### ######.
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event
				 * ####### ######### ########### ##### ######.
				 */
				"collapsedChanged"
			);
			return this;
		},

		/**
		 * ############# ######### ########### # ######### #########.
		 * @public
		 */
		initCollapsedState: function() {
			var defaultCollapsed = this.getDefaultCollapsed();
			this.setCollapsed(defaultCollapsed);
		},

		/**
		 * ########## ######### ######## ########### ##### ######.
		 * @protected
		 * @return {Boolean} ######### ######## ########### ##### ######.
		 */
		getDefaultCollapsed: function() {
			if (this.useProfile) {
				if (profile !== null) {
					return profile;
				} else {
					return true;
				}
			} else {
				return true;
			}
		},

		/**
		 * ########## ####### ######## ########### ##### ######.
		 * @public
		 * @return {Boolean} ####### ######## ########### ##### ######.
		 */
		getCollapsed: function() {
			var body = Ext.getBody();
			return body.hasCls("left-panel-collapsed");
		},

		/**
		 * ######## ######## ########### ##### ###### ## ########.
		 * @public
		 */
		changeCollapsed: function() {
			var collapsed = this.getCollapsed();
			this.setCollapsed(!collapsed);
		},

		/**
		 * ######## ######## ########### ##### ######.
		 * @param {Boolean} collapsed ####### ###########.
		 * @public
		 */
		setCollapsed: function(collapsed) {
			var body = Ext.getBody();
			var internalCollapsed = this.getCollapsed();
			if (collapsed) {
				body.addCls("left-panel-collapsed");
			} else {
				body.removeCls("left-panel-collapsed");
			}
			if (BPMSoft.isCurrentUserSsp()) {
				this.applySspConfig(body, collapsed);
			}
			if (internalCollapsed !== collapsed) {
				this.fireEvent("collapsedChanged", collapsed);
			}
			if (this.useProfile) {
				BPMSoft.utils.saveUserProfile("LeftPanelCollapsed", collapsed, false);
			}
		},

		/**
		 * Applies ssp config to the left panel.
		 * @param {Object} body Left panel body. 
		 * @param {Boolean} collapsed Is panel collapsed. 
		 */
		applySspConfig: function(body, collapsed) {
			if (collapsed) {
				body.addCls("left-panel-collapsed-ssp");
			} else {
				body.removeCls("left-panel-collapsed-ssp");
			}
		}

	});
	return Ext.create(BPMSoft.configuration.LeftPanelUtilitiesV2);
});
