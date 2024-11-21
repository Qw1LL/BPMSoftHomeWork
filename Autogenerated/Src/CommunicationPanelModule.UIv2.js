define("CommunicationPanelModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.CommunicationPanelModule
	 * ##### ######## ################ ######.
	 */
	Ext.define("BPMSoft.configuration.CommunicationPanelModule", {
		alternateClassName: "BPMSoft.CommunicationPanelModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * ############## ######## #####.
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "CommunicationPanel";
		},

		/**
		 * ######## ######### ####### # ####### #########, #### ### ############# ###### ########## ## ########.
		 * @protected
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn

	});
	return BPMSoft.CommunicationPanelModule;
});
