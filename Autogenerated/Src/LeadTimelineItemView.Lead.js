define("LeadTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.LeadTimelineItemView
	 * Lead timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.LeadTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.LeadTimelineItemView",

		// region Methods: Protected

		/**
		 * Returns lead info view config.
		 * @protected
		 * @return {Object} Lead info view config.
		 */
		getLeadInfoContainerViewConfig: function() {
			return {
				"name": "LeadInfoContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-tile-info-container"]
				},
				"items": [
					this.getTextWithLabelContainerViewConfig("Resources.Strings.LeadTypeLabel", "LeadType"),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.RegisterMethodLabel", "RegisterMethod"),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.StageLabel", "Stage")
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getLeftHeaderViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			bodyConfig.items = [
				this.getLeadInfoContainerViewConfig()
			];
			return bodyConfig;
		}

		// endregion

	});
});
