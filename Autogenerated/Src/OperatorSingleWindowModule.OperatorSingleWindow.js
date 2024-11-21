define("OperatorSingleWindowModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.OperatorSingleWindowModule
	 * ##### ####### #### #########.
	 */
	Ext.define("BPMSoft.configuration.OperatorSingleWindowModule", {
		alternateClassName: "BPMSoft.OperatorSingleWindowModule",
		extend: "BPMSoft.BaseSchemaModule",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModuleV2#initSchemaName.
		 * @overridden
		 */
		initSchemaName: function() {
			this.callParent(arguments);
			this.schemaName = "OperatorSingleWindowPage";
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModuleV2#prepareHistorySate.
		 * @overridden
		 */
		prepareHistorySate: function() {
			var newState = this.callParent(arguments);
			delete newState.isSeparateMode;
			delete newState.schemaName;
			delete newState.entitySchemaName;
			delete newState.operation;
			delete newState.primaryColumnValue;
			delete newState.isInChain;
			return newState;
		}

	});
	return BPMSoft.OperatorSingleWindowModule;
});
