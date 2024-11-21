define("InvoiceTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.InvoiceTimelineItemView
	 * Invoice timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.InvoiceTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.InvoiceTimelineItemView",

		// region Methods: Protected

		/**
		 * Returns invoice info container view config.
		 * @protected
		 * @return {Object} Invoice info view config.
		 */
		getInfoContainerViewConfig: function() {
			return {
				"name": "InfoContainer",
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
					this.getTextWithLabelContainerViewConfig("Resources.Strings.PaymentStatusCaption", "PaymentStatusName", {
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
			bodyConfig.items = [this.getInfoContainerViewConfig()];
			return bodyConfig;
		}

		// endregion

	});
});
