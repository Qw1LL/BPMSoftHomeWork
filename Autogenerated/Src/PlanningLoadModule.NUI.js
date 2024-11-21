define("PlanningLoadModule", ["BaseSchemaModuleV2", "css!DetailModuleV2"], function() {
	Ext.define("BPMSoft.configuration.PlanningLoadModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.PlanningLoadModule",

		/**
		 * Entity schema name.
		 */
		entitySchemaName: null,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#getViewContainerId
		 * @overridden
		 */
		getViewContainerId: function() {
			var id = this.callParent(arguments);
			return this.entitySchemaName + id;
		}

	});

	return BPMSoft.PlanningLoadModule;
});
