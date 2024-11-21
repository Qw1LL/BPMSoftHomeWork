define("DocumentTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.DocumentTimelineItemView
	 * Document timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.DocumentTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.DocumentTimelineItemView",

		// region Methods: Protected

		/**
		 * Returns Document info view config.
		 * @protected
		 * @return {Object} Document info view config.
		 */
		getDocumentInfoContainerViewConfig: function() {
			return {
				"name": "DocumentInfoContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-tile-info-container"]
				},
				"items": [
					this.getTextWithLabelContainerViewConfig("Resources.Strings.TypeLabel", "Type"),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.StatusLabel", "State")
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			bodyConfig.items = [
				this.getDocumentInfoContainerViewConfig()
			];
			return bodyConfig;
		}

		// endregion

	});
});
