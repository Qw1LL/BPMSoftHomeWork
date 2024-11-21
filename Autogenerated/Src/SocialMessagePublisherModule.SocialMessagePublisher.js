define("SocialMessagePublisherModule", ["BaseMessagePublisherModule"],
	function() {
		Ext.define("BPMSoft.configuration.SocialMessagePublisherModule", {
			extend: "BPMSoft.BaseMessagePublisherModule",
			alternateClassName: "BPMSoft.SocialMessagePublisherModule",

			/**
			 * @inheritdoc BPMSoft.SocialMessagePublisherModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "SocialMessagePublisherPage";
			}
		});
		return BPMSoft.SocialMessagePublisherModule;
	});
