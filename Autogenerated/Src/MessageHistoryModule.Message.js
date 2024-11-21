define("MessageHistoryModule", ["css!MessageHistoryStyle"],
	function() {
		/**
		 * @class BPMSoft.configuration.MessageHistoryModule
		 * Message history module.
		 */
		Ext.define("BPMSoft.configuration.MessageHistoryModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.MessageHistoryModule",

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
			 * @overridden
			 */
			generateViewContainerId: false,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "MessageHistoryPage";
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
			 * @overridden
			 */
			initHistoryState: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.initMessages();
			},

			/**
			 * Initialize subscription on module messages.
			 * @private
			 */
			initMessages: function() {
				this.sandbox.subscribe("RerenderModule", function(config) {
					if (this.viewModel) {
						this.render(this.Ext.get(config.renderTo));
						return true;
					}
				}, this, [this.sandbox.id]);
			}
		});
		return this.BPMSoft.MessageHistoryModule;
	}
);
