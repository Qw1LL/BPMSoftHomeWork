define("EmailTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.EmailTimelineItemView
	 * Email timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.EmailTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.EmailTimelineItemView",

		// region Properties: Protected

		/**
		 * The maximum size of the window in which the message is displayed.
		 * @type {Number}
		 */
		messageFrameMaxHeight: 99999,

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#bodyVisibilityHeight
		 * @override
		 */
		bodyVisibilityHeight: 47,

		// endregion

		// region Methods: Protected

		/**
		 * Returns recipient caption view config.
		 * @protected
		 * @return {Object}
		 */
		getRecipientCaptionViewConfig: function() {
			return {
				"name": "RecipientCaption",
				"itemType": BPMSoft.ViewItemType.HYPERLINK,
				"caption": {
					"bindTo": "RecipientName"
				},
				"markerValue": {
					"bindTo": "RecipientName"
				},
				"click": {
					"bindTo": "onRecipientCaptionClick"
				},
				"href": {
					"bindTo": "getRecipientUrl"
				},
				"linkMouseOver": {
					"bindTo": "recipientLinkMouseOver"
				},
				"classes": {
					"hyperlinkClass": ["timeline-item-recipient-caption"]
				}
			};
		},

		/**
		 * Returns subject view config.
		 * @protected
		 * @return {Object}
		 */
		getSubjectViewConfig: function() {
			return {
				"name": "SubjectContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-item-subject-container"]
				},
				"items": [{
					"name": "Subject",
					"itemType": BPMSoft.ViewItemType.HYPERLINK,
					"caption": {
						"bindTo": "Subject"
					},
					"click": {
						"bindTo": "onCaptionClick"
					},
					"href": {
						"bindTo": "getRecordUrl"
					},
					"classes": {
						"hyperlinkClass": ["timeline-item-subject-label"]
					}
				}]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getMessageViewConfig
		 * @override
		 */
		getMessageViewConfig: function() {
			var config = this.callParent(arguments);
			config.isHtmlBody = true;
			config.frameMaxHeight = this.messageFrameMaxHeight;
			config.showLinks = true;
			config.frameBodyStyle = {"bindTo": "getMessageIframeBodyStyle"};
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getLeftHeaderViewConfig
		 * @override
		 */
		getLeftHeaderViewConfig: function() {
			var baseConfig = this.callParent(arguments);
			baseConfig.items.push(
				this.getToLabelViewConfig(),
				this.getRecipientCaptionViewConfig(),
				this.getGoToPageButtonViewConfig()
			);
			return baseConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var baseConfig = this.callParent(arguments);
			if (Ext.isArray(baseConfig.items)) {
				baseConfig.items.splice(0, 0, this.getSubjectViewConfig());
			}
			return baseConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getItemTileContainerConfig
		 * @override
		 */
		getItemTileContainerConfig: function() {
			var baseConfig = this.callParent(arguments);
			var classes = this.getItemClasses(baseConfig);
			this.insertClass(classes, "timeline-email-item");
			return baseConfig;
		}

		// endregion

	});
});
