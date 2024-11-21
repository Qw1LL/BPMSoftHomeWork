define("ProcessLookupMappingModule", ["ext-base", "LookupPage"], function() {
	/**
	 * @class BPMSoft.configuration.ProcessLookupMappingModule
	 */
	Ext.define("BPMSoft.configuration.ProcessLookupMappingModule", {
		extend: "BPMSoft.LookupPage",
		alternateClassName: "BPMSoft.ProcessLookupMappingModule",

		/**
		 * @inheritdoc BPMSoft.LookupPage#getSchemaAndProfile
		 * @overridden
		 */
		getSchemaAndProfile: function(lookupPostfix, callback) {
			this.callParent([lookupPostfix, function(entitySchema, fixedProfile) {
				if (!entitySchema.primaryDisplayColumn) {
					entitySchema.primaryDisplayColumn = entitySchema.primaryColumn;
					entitySchema.primaryDisplayColumnName = entitySchema.primaryColumnName;
				}
				callback.call(this, entitySchema, fixedProfile);
			}.bind(this)]);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages({
				"ResultActiveRow": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			});
		},

		/**
		 * @inheritdoc BPMSoft.LookupPage#generateViewModel
		 * @overridden
		 */
		generateViewModel: function() {
			var viewModel = this.callParent(arguments);
			viewModel.on("change:activeRow", function(model, activeRowId) {
				if (!activeRowId) {
					return;
				}
				var item = viewModel.get("gridData").get(activeRowId);
				var values = item.values;
				values.value = values[item.primaryColumnName];
				values.displayValue = values[item.primaryDisplayColumnName];
				var result = new BPMSoft.Collection();
				result.collection.add(activeRowId, values);
				this.sandbox.publish("ResultActiveRow", {selectedRows: result}, [this.sandbox.id]);
			}, this);
			viewModel.setSearchEditFocused = BPMSoft.emptyFn;
			return viewModel;
		}
	});
	return BPMSoft.ProcessLookupMappingModule;
});
