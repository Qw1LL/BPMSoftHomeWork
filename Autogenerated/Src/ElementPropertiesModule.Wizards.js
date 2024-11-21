define("ElementPropertiesModule", ["ConfigurationModuleV2"], function() {

	Ext.define("BPMSoft.ElementPropertiesModule", {
		extend: "BPMSoft.ConfigurationModule",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @override
		 */
		useHistoryState: false,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#isSchemaConfigInitialized
		 * @override
		 */
		isSchemaConfigInitialized: true,

		/**
		 * @inheritdoc BPMSoft.BaseModule#showMask
		 * @override
		 */
		showMask: true,

		/**
		 * Design schema.
		 * @protected
		 * @type {BPMSoft.PageDesignerSchema}
		 */
		designSchema: null,

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @override
		 */
		init: function() {
			this.showLoadingMask();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseModule#showLoadingMask
		 * @override
		 */
		showLoadingMask: function() {
			if (this.showMask && !this.maskId && this.renderToId) {
				this.maskId = BPMSoft.Mask.show({
					selector: Ext.String.format("#{0}", this.renderToId),
					clearMasks: true
				});
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseModule#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			this.hideLoadingMask();
		}

		// endregion

	});

	return BPMSoft.ElementPropertiesModule;

});
