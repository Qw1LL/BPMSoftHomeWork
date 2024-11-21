define("CallMessagePublisherModule", ["BaseMessagePublisherModule"],
	function() {
		Ext.define("BPMSoft.configuration.CallMessagePublisherModule", {
			extend: "BPMSoft.BaseMessagePublisherModule",
			alternateClassName: "BPMSoft.CallMessagePublisherModule",

			/**
			 * @inheritdoc BPMSoft.CallMessagePublisherModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "CallMessagePublisherPage";
			}
		});
		return BPMSoft.CallMessagePublisherModule;
	});
