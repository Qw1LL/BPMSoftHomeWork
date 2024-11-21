define("ChangePasswordModule", ["ServiceHelper", "ChangePasswordModuleResources", "ChangePasswordModuleSchema"],
	function(ServiceHelper, resources) {
	Ext.define("BPMSoft.configuration.ChangePasswordModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.ChangePasswordModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ChangePasswordModuleSchema";
		},

		render: function(renderTo) {
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: function() {
			var sandbox = this.sandbox;
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			var newState = BPMSoft.deepClone(currentState);
			newState.moduleId = sandbox.id;
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				hash: currentHash.historyState,
				silent: true
			});
		}

	});
	return BPMSoft.ChangePasswordModule;
});
