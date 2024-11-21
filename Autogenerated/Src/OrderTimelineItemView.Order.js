define("OrderTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.OrderTimelineItemView
	 * Order timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.OrderTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.OrderTimelineItemView",

		// region Methods: Protected

		/**
		 * Returns order info view config.
		 * @protected
		 * @return {Object} Order info view config.
		 */
		getInfoContainerViewConfig: function() {
			return {
				"name": "OrderInfoContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-tile-info-container"]
				},
				"items": [
					this.getTextWithLabelContainerViewConfig("getAmountWithCurrencyCaption", "PrimaryAmount", {
						"textValueConverter": "getFormattedFloatNumberValue"
					}),
					this.getTextWithLabelContainerViewConfig("getPaymentAmountWithCurrencyCaption", "PrimaryPaymentAmount", {
						"textValueConverter": "getFormattedFloatNumberValue"
					}),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.StatusLabel", "Status", {
						"cssWrapClass": "timeline-text-with-label-container-130px"
					})
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
				this.getInfoContainerViewConfig()
			];
			return bodyConfig;
		}

		// endregion

	});
});
