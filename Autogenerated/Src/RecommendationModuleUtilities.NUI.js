﻿define("RecommendationModuleUtilities", ["LoadProcessModules", "ProcessModuleUtilities"],
		function(LoadProcessModules, ProcessModuleUtilities) {
	/**
	 * @class BPMSoft.configuration.mixins.RecommendationModuleUtilities
	 * ######, ########### ###### # ####### RecommendationModule
	 */
	Ext.define("BPMSoft.configuration.mixins.RecommendationModuleUtilities", {
		alternateClassName: "BPMSoft.RecommendationModuleUtilities",

		/**
		 *
		 */
		activitySchemaName: "Activity",

		/**
		 *
		 */
		loadRecommendationModule: function() {
			if (!this.get("IsProcessMode")) {
				return;
			}
			var data = this.sandbox.publish("GetProcessExecData");
			if (!data) {
				return;
			}
			var entitySchemaName = data.entitySchemaName;
			if (entitySchemaName !== this.activitySchemaName || data.autoGeneratedPage || data.preconfiguredPage) {
				this.sandbox.loadModule("RecommendationModule", {
					renderTo: "RecommendationModuleContainer"
				});
			}
		}
	});
	return BPMSoft.RecommendationModuleUtilities;
});
