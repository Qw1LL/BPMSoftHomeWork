define("SocialMessageTimelineItemView", ["BaseTimelineItemView", "LinkPreview"], function() {
	/**
	 * @class BPMSoft.configuration.SocialMessageTimelineItemView
	 * Social message timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.SocialMessageTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.SocialMessageTimelineItemView",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#bodyVisibilityHeight
		 * @override
		 */
		bodyVisibilityHeight: 76,

		// endregion

		// region Methods: Protected

		/**
		 * Returns link preview view config.
		 * @protected
		 * @return {Object}
		 */
		getLinkPreviewConfig: function() {
			return {
				"name": "LinkPreview",
				"itemType": BPMSoft.ViewItemType.COMPONENT,
				"className": "BPMSoft.LinkPreview",
				"linkPreviewInfo": {
					"bindTo": "LinkPreviewData"
				},
				"url": {
					"bindTo": "MessageUrl"
				},
				"visible": {
					"bindTo": "getLinkPreviewVisible"
				}
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			var messageItemConfig = this.findChildItemConfig(bodyConfig, "Message");
			if (messageItemConfig) {
				messageItemConfig.showLinks = true;
			}
			bodyConfig.items.push(this.getLinkPreviewConfig());
			return bodyConfig;
		}

		// endregion

	});
});
