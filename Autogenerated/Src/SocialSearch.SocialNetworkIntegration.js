define("SocialSearch", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.SocialSearch", {

		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.SocialSearch",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @private
		 * @type {String}
		 */
		searchQuery: "",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#createViewModel
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			viewModel.set("Query", this.searchQuery);
			return viewModel;
		}
	});
	return BPMSoft.SocialSearch;
});
