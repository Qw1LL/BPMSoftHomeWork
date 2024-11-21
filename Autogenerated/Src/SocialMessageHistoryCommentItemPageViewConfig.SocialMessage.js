define("SocialMessageHistoryCommentItemPageViewConfig", ["ViewUtilities", "ImageCustomGeneratorV2", "MultilineLabel",
		"css!SocialMessageHistoryCommentItemPageViewConfig"],
	function(ViewUtilities) {
	/**
	 * @class BPMSoft.configuration.SocialMessageHistoryCommentItemPageViewConfig
	 * Comment to social message in history view class.
	 */
	Ext.define("BPMSoft.configuration.SocialMessageHistoryCommentItemPageViewConfig", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.SocialMessageHistoryCommentItemPageViewConfig",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var mainContainer = ViewUtilities.getContainerConfig("CommentMainContainer", ["mainContainer"]);
			var headerContainer = ViewUtilities.getContainerConfig("CommentHeaderContainer",
				["historyV2-comment-header-container"]);
			headerContainer.items.push(this.getCommentPhotoConfig());
			headerContainer.items.push(this.getCommentAvatarConfig());
			var titleContainer = ViewUtilities.getContainerConfig("CommentTitleContainer",
				["historyV2-comment-header-title-container"]);
			titleContainer.items.push(this.getCommentAuthorNameConfig());
			titleContainer.items.push(this.getCreatedOnConfig());
			headerContainer.items.push(titleContainer);
			mainContainer.items.push(headerContainer);
			var centerContainer = ViewUtilities.getContainerConfig("CommentCenterContainer",
				["comment-center-container"]);
			centerContainer.items.push(
				{
					"className": "BPMSoft.MultilineLabel",
					"caption": {"bindTo": "Message"}
				}
			);
			mainContainer.items.push(centerContainer);
			return mainContainer;
		},

		/**
		 * Return view config for photo.
		 * @return {Object} Built config.
		 */
		getCommentPhotoConfig: function() {
			var viewGenerator = Ext.create("BPMSoft.ImageCustomGenerator");
			var config = {
					"name": "CreatedByImage",
					"getSrcMethod": "getCreatedByImage",
					"onPhotoChange": BPMSoft.emptyFn,
					"readonly": true,
					"classes": {
						"wrapClass": ["created-by-image"]
					},
					"markerValue": "CreatedByImage",
					"onImageClick": {
						"bindTo": "openCreatedByPage"
					},
					"visible": {
						"bindTo": "HasImage"
					}
			};
			return viewGenerator.generateSimpleCustomImage(config);
		},

		/**
		 * Get view config for avatar.
		 * @return {Object} View config.
		 */
		getCommentAvatarConfig: function() {
			return {
				className: "BPMSoft.Label",
				classes: {
					labelClass: ["author-initials"]
				},
				visible: {
					bindTo: "HasImage",
					bindConfig: {converter: "invertBooleanValue"}
				},
				caption: {bindTo: "Initials"},
				click: {
					bindTo: "openCreatedByPage"
				}
			};
		},

		/**
		 * Return view config for author name.
		 * @return {Object} Built config.
		 */
		getCommentAuthorNameConfig: function() {
			return {
				"className": "BPMSoft.Hyperlink",
				"caption": {
					"bindTo": "CreatedBy",
					"bindConfig": {"converter": "displayValueConverter"}
				},
				"href": {
					"bindTo": "CreatedBy",
					"bindConfig": {"converter": "contactToUrlConverter"}
				},
				"target": BPMSoft.controls.HyperlinkEnums.target.SELF,
				"classes": {
					"hyperlinkClass": ["createdByLink"]
				}
			};
		},

		/**
		 * Return view config for creation date.
		 * @return {Object} Built config.
		 */
		getCreatedOnConfig: function() {
			return {
				"className": "BPMSoft.Label",
				"caption": {"bindTo": "getCreatedOn"},
				"classes": {"labelClass": ["creationInfoLabel"]}
			};
		}
	});
});
