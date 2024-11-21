define("LinkTimelineItemView", ["LinkTimelineItemViewResources", "BaseTimelineItemView", "LinkPreview"],
	function() {
		/**
		 * @class BPMSoft.configuration.LinkTimelineItemView
		 * Link timeline item view class.
		 */
		Ext.define("BPMSoft.configuration.LinkTimelineItemView", {
			alternateClassName: "BPMSoft.LinkTimelineItemView",
			extend: "BPMSoft.BaseTimelineItemView",

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
						"bindTo": "Caption"
					},
					"visible": {
						"bindTo": "getLinkPreviewVisible"
					}
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemView#getCaptionViewConfig
			 * @protected
			 */
			getCaptionViewConfig: function() {
				var config = this.callParent(arguments);
				config.href = {
					"bindTo": "Caption",
					"bindConfig": {
						"converter": BPMSoft.addProtocolPrefix
					}
				};
				delete config.click;
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
			 * @override
			 */
			getBodyViewConfig: function() {
				var bodyConfig = this.callParent(arguments);
				delete bodyConfig.className;
				delete bodyConfig.controlConfig;
				bodyConfig.items = [
					this.getLinkPreviewConfig()
				];
				return bodyConfig;
			}

			// endregion

		});
	});
