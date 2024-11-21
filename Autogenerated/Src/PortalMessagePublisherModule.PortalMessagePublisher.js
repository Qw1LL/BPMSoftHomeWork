define("PortalMessagePublisherModule", ["BaseMessagePublisherModule"],
	function() {
		Ext.define("BPMSoft.configuration.PortalMessagePublisherModule", {
			extend: "BPMSoft.BaseMessagePublisherModule",
			alternateClassName: "BPMSoft.PortalMessagePublisherModule",

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "PortalMessagePublisherPage";
			}
		});
		return BPMSoft.PortalMessagePublisherModule;
	});
