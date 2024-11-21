define("GlobalSearchModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.GlobalSearchModule
	 */
	Ext.define("BPMSoft.configuration.GlobalSearchModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.GlobalSearchModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.callParent([this.search.bind(this, callback, scope), this]);
		},

		/**
		 * Run global search by query.
		 * @protected
		 */
		search: function(callback, scope) {
			this.Ext.callback(callback, scope);
			this.viewModel.search();
		}
	});
	return BPMSoft.GlobalSearchModule;
});
