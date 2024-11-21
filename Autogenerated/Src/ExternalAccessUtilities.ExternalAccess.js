define("ExternalAccessUtilities", [
	"ExternalAccessServiceWrapper",
	"ExternalAccessUtilitiesResources"
], function(ExternalAccessServiceWrapper, resources) {

	/**
	 * Utility functions for external access.
	 */
	Ext.define("BPMSoft.configuration.mixins.ExternalAccessUtilities", {
		alternateClassName: "BPMSoft.ExternalAccessUtilities",

		/**
		 * @param {Object} responseObject Response of service that deactivates external accesses.
		 * @private
		 */
		_processServiceResponse: function(responseObject) {
			if (BPMSoft.isEmptyObject(responseObject)) {
				const errorMessage = resources.localizableStrings.ExternalAccessDeactivationErrorMessage;
				BPMSoft.showErrorMessage(errorMessage);
			} else {
				const successMessage = resources.localizableStrings.ExternalAccessDeactivationSuccessMessage;
				BPMSoft.showInformation(successMessage);
			}
		},

		/**
		 * Returns caption for deactivation action.
		 * @returns {String} Caption for deactivation action.
		 */
		getDeactivationActionCaption: function() {
			return resources.localizableStrings.DeactivateExternalAccessMenuCaption;
		},

		/**
		 * Deactivates specified external accesses.
		 * @param {String[]} accessIds Accesses to deactivate.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		deactivateAccesses: function(accessIds, callback, scope) {
			ExternalAccessServiceWrapper.deactivateAccesses(accessIds, function(responseObject) {
				this._processServiceResponse(responseObject);
				callback.call(scope, responseObject);
			}, this);
		}

	});

	return Ext.create("BPMSoft.ExternalAccessUtilities");
});
