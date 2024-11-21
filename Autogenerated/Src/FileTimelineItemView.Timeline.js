define("FileTimelineItemView", ["BaseTimelineItemView"], function() {
	/**
	 * @class BPMSoft.configuration.FileTimelineItemView
	 * File timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.FileTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.FileTimelineItemView",

		// region Methods: Protected

		/**
		 * Returns file type icon view config.
		 * @protected
		 * @return {Object}
		 */
		getFileTypeIconConfig: function() {
			return {
				"name": "FileTypeIcon",
				"itemType": BPMSoft.ViewItemType.IMAGE,
				"getSrcMethod": "FileTypeSrc",
				"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
				"onPhotoChange": BPMSoft.emptyFn,
				"classes": {
					"wrapClass": ["timeline-item-file-type-icon"]
				}
			};
		},

		/**
		 * Returns file preview image view config.
		 * @protected
		 * @return {Object}
		 */
		getFilePreviewImageConfig: function() {
			return {
				"name": "FilePreviewImage",
				"itemType": BPMSoft.ViewItemType.IMAGE,
				"getSrcMethod": "getPreviewImageSrc",
				"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
				"onPhotoChange": BPMSoft.emptyFn,
				"classes": {
					"wrapClass": ["timeline-item-file-preview-image"]
				}
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getCaptionViewConfig
		 * @protected
		 */
		getCaptionViewConfig: function() {
			var config = this.callParent(arguments);
			config.target = "_self";
			delete config.click;
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getLeftHeaderViewConfig
		 * @protected
		 */
		getLeftHeaderViewConfig: function() {
			var leftHeaderConfig = this.callParent(arguments);
			leftHeaderConfig.items.splice(1, 0, this.getFileTypeIconConfig());
			return leftHeaderConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			bodyConfig.controlConfig.visibilityHeight = 0;
			bodyConfig.visible = {
				"bindTo": "isFilePreviewImageVisible"
			};
			bodyConfig.items = [
				this.getFilePreviewImageConfig()
			];
			return bodyConfig;
		}

		// endregion

	});
});
