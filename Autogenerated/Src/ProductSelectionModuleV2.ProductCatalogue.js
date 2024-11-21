define("ProductSelectionModuleV2", ["BaseSchemaModuleV2", "css!ProductSelectionModuleV2"],
	function() {
		/**
		 * @class BPMSoft.configuration.ProductSelectionModule
		 */
		Ext.define("BPMSoft.configuration.ProductSelectionModuleV2", {
			alternateClassName: "BPMSoft.ProductSelectionModuleV2",
			extend: "BPMSoft.BaseSchemaModule",
			schemaName: "ProductSelectionSchema",
			Ext: null,
			sandbox: null,
			BPMSoft: null,
			useHistoryState: true,
			messages: null,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#init
			 * @overridden
			 */
			init: function() {
				this.registerMessages();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.config = this.sandbox.publish("ProductSelectionInfo", null, [this.sandbox.id]) || {};
				this.entitySchemaName = this.config.masterProductEntitySchemaName;
				this.parameters = {
					viewModelConfig: {}
				};
				var viewModelConfig = this.parameters.viewModelConfig;
				viewModelConfig.MasterEntitySchemaName = this.config.masterEntitySchemaName;
				viewModelConfig.MasterRecordId = this.config.masterRecordId;
				viewModelConfig.MasterCurrency = this.config.masterCurrency;
				viewModelConfig.PredefinedPriceList = this.config.predefinedPriceList;
			},

			/**
			 * Registers module messages.
			 * @protected
			 */
			registerMessages: function() {
				var messages = {
					"ProductSelectionInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"BackHistoryState": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"GetHistoryState": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"PushHistoryState": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"ReplaceHistoryState": {
						"direction": BPMSoft.MessageDirectionType.PUBLISH,
						"mode": BPMSoft.MessageMode.BROADCAST
					}
				};
				this.sandbox.registerMessages(messages);
			}
		});
		return BPMSoft.ProductSelectionModuleV2;
	});
