define("DelayExecutionUtilities", ["LoadProcessModules"], function(LoadProcessModules) {
	/**
	 * @class BPMSoft.configuration.mixins.DelayExecutionUtilities
	 * ######, ########### ###### # ####### DelayExecution
	 */
	Ext.define("BPMSoft.configuration.mixins.DelayExecutionUtilities", {
		alternateClassName: "BPMSoft.DelayExecutionUtilities",

		/**
		 *
		 */
		onDelayExecutionButtonClick: function() {
			var moduleId = this.sandbox.id + "_DelayExecutionModuleV2";
			if (this.get("DelayExecutionModuleContainerVisible")) {
				this.closeDelayExecutionModule(moduleId);
			} else {
				this.set("DelayExecutionModuleContainerVisible", true);
				this.sandbox.subscribe("CloseDelayExecutionModule", this.closeDelayExecutionModule, this, [moduleId]);
				this.sandbox.loadModule("DelayExecutionModuleV2", {renderTo: "DelayExecutionModuleContainer"});
			}
		},

		/**
		 * ######## ######## ######## "#########" ### ###### "######## ##########"
		 * return {Boolean} ########## ######## ######## "#########" ### ###### "######## ##########"
		 */
		getDelayExecutionButtonVisible: function() {
			return LoadProcessModules.isDelayExecutionButtonVisible(this.sandbox, this.get("IsProcessMode"))
				&& BPMSoft.Features.getIsDisabled("UseProcessPerformerAssignment");
		},

		/**
		 *
		 * @param moduleId
		 */
		closeDelayExecutionModule: function(moduleId) {
			this.set("DelayExecutionModuleContainerVisible", false);
			this.sandbox.unloadModule(moduleId);
		}
	});
	return BPMSoft.DelayExecutionUtilities;
});
