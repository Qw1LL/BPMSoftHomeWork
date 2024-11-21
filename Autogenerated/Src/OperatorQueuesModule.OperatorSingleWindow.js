define("OperatorQueuesModule", [], function() {

		/**
		 * @class BPMSoft.configuration.OperatorQueuesModule
		 * ##### ###### ######## #########.
		 */
		Ext.define("BPMSoft.configuration.OperatorQueuesModule", {
			alternateClassName: "BPMSoft.OperatorQueuesModule",
			extend: "BPMSoft.BaseSchemaModule",

			/**
			 * ############## ######## #####.
			 * @protected
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "OperatorQueues";
			},

			/**
			 * ######## ######### ####### # ####### #########, #### ### ############# ###### ########## ## ########.
			 * @protected
			 * @overridden
			 */
			initHistoryState: Ext.emptyFn
		});

		return BPMSoft.OperatorQueuesModule;
	}
);
