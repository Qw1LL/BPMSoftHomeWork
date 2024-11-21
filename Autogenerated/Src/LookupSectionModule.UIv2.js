define("LookupSectionModule", ["SectionModuleV2","css!SectionModuleV2"], function() {
	/**
	 * SectionModule class is intended to create an instance lookup section.
	 */
	Ext.define("BPMSoft.configuration.LookupSectionModule", {
		alternateClassName: "BPMSoft.LookupSectionModule",
		extend: "BPMSoft.SectionModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getProfileKey
		 * @override
		 */
		getProfileKey: function() {
			return this.schemaName + this.entitySchemaName + "GridSettingsGridDataView";
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: function() {
			var sandbox = this.sandbox;
			var state = sandbox.publish("GetHistoryState");
			var currentState = state.state || {};
			this.entitySchemaName = currentState.entitySchemaName || state.hash.operationType;
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.SectionModule#prepareHistoryState
		 * @override
		 */
		prepareHistoryState: function() {
			var newState = this.callParent(arguments);
			newState.entitySchemaName = this.entitySchemaName;
			return newState;
		},

		/**
		 * @inheritDoc BPMSoft.configuration.SectionModule#getViewModelConfig
		 * @override
		 */
		getViewModelConfig: function() {
			var viewModelConfig = this.callParent(arguments);
			Ext.apply(viewModelConfig, {
				values: {
					IsLookupSection: true
				}
			});
			return viewModelConfig;
		}

	});
	return BPMSoft.LookupSectionModule;
});
