define("BaseMessagePublisherModule", ["BaseSchemaModuleV2"],
	function() {
		Ext.define("BPMSoft.configuration.BaseMessagePublisherModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.BaseMessagePublisherModule",

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
				this.schemaName = "BaseMessagePublisherPage";
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
			 * @overridden
			 */
			initHistoryState: BPMSoft.emptyFn,

			/**
			 * @inheritdoc
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.initMessages();
			},

			/**
			 * Subscribes to messages of the module.
			 * @private
			 */
			initMessages: function() {
				this.sandbox.subscribe("RerenderPublisherModule", function(config) {
					if (this.viewModel) {
						this.render(this.Ext.get(config.renderTo));
						return true;
					}
				}, this, [this.sandbox.id]);
			}
		});
		return this.BPMSoft.BaseMessagePublisherModule;
	});
