define("ActivityTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.ActivityTimelineItemView
	 * Activity timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.ActivityTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.ActivityTimelineItemView",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#bodyVisibilityHeight
		 * @override
		 */
		bodyVisibilityHeight: 64,

		// endregion

		// region Methods: Protected

		/**
		 * Returns result message config.
		 * @protected
		 * @return {Object} Result message config.
		 */
		getResultMessageViewConfig: function() {
			return {
				"name": "ResultMessage",
				"itemType": BPMSoft.ViewItemType.LABEL,
				"caption": {
					"bindTo": "ResultMessage"
				},
				"visible": {
					"bindTo": "ResultMessage",
					"bindConfig": {
						"converter": "isNotEmptyValue"
					}
				},
				"classes": {
					"labelClass": ["timeline-text-normal"]
				}
			};
		},

		/**
		 * Returns detailed result label config.
		 * @protected
		 * @return {Object} Detailed result label config.
		 */
		getDetailedResultLabelViewConfig: function() {
			return {
				"name": "DetailedResultLabel",
				"itemType": BPMSoft.ViewItemType.LABEL,
				"caption": {
					"bindTo": "Resources.Strings.DetailedResultLabel"
				},
				"visible": {
					"bindTo": "isDetailedResultLabelVisible"
				},
				"classes": {
					"labelClass": ["timeline-detailed-result-label"]
				}
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getMessageViewConfig
		 * @override
		 */
		getMessageViewConfig: function() {
			return {
				"name": "Message",
				"itemType": BPMSoft.ViewItemType.LABEL,
				"isMultiline": true,
				"caption": {
					"bindTo": "Message"
				},
				"classes": {
					"labelClass": ["timeline-text-normal"]
				}
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			bodyConfig.items.unshift(this.getDetailedResultLabelViewConfig());
			bodyConfig.items.unshift(this.getResultMessageViewConfig());
			return bodyConfig;
		}

		// endregion

	});
});
