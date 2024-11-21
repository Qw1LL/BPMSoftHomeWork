define("OppManagementMigrationUtils", ["ext-base", "BPMSoft", "FeatureServiceRequest"], function(Ext, BPMSoft) {

	Ext.define("BPMSoft.configuration.mixins.OppManagementMigrationUtils", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.OppManagementMigrationUtils",

		/**
		 * Sets value of old opportunity management process usage state to opposite of current value.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} [scope] Callback scope.
		 */
		toggleOldProcessUsageState: function(callback, scope) {
			var request = this.createFeatureRequest();
			var state = this.isOldProcessEnabled() ?
				BPMSoft.FeatureState.DISABLED :
				BPMSoft.FeatureState.ENABLED;
			request.updateFeatureState({state: state, forAllUsers: true}, callback, scope || this);
		},

		/**
		 * Returns feature service request.
		 * @private
		 * @return {BPMSoft.FeatureServiceRequest}
		 */
		createFeatureRequest: function() {
			return Ext.create("BPMSoft.FeatureServiceRequest", {
				code: "UseOldOpportunityManagementProcess"
			});
		},

		/**
		 * Returns old opportunity management process usage state.
		 * @protected
		 * @return {Boolean} True if opportunity management process is enabled.
		 */
		isOldProcessEnabled: function() {
			return this.get("OldOpportunityManagementEnabled");
		},

		/**
		 * Initializes old opportunity management process usage state.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} [scope] Callback scope.
		 */
		initOldProcessUsageState: function(callback, scope) {
			var request = this.createFeatureRequest();
			request.getFeatureState(function(state) {
				var oldProcessEnabled = BPMSoft.FeatureState.ENABLED === state;
				this.set("OldOpportunityManagementEnabled", oldProcessEnabled);
				callback.call(scope || this);
			}, this);
		}

	});
});
