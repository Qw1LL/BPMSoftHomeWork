define("ProcessEmailContentBuilderHelper", ["EmailContentBuilder", "ProcessEmailContentTextElementViewModel"],
		function() {
	Ext.define("BPMSoft.ContentBuilder.ProcessEmailContentBuilderHelper", {
		extend: "BPMSoft.ContentBuilderHelper",
		alternateClassName: "BPMSoft.ProcessEmailContentBuilderHelper",

		/**
		 * User task invoker uid of the mapping page.
		 * @private
		 * @type {String}
		 */
		invokerUId: null,

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#textToViewModel
		 * @protected
		 * @overridden
		 */
		textToViewModel: function(config) {
			config = this.sliceObject(config, {expectedParameters: this.textElementProperties});
			config.Id = BPMSoft.generateGUID();
			return Ext.create("BPMSoft.ProcessEmailContentTextElementViewModel", {
				values: config,
				sandbox: this.sandbox,
				invokerUId: this.invokerUId
			}, true);
		}

	});
});
