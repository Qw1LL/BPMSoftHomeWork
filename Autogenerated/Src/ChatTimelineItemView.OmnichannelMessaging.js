define("ChatTimelineItemView", ["BaseTimelineItemView", "ImageCustomGeneratorV2", "css!ChatTimelineItemView", "OmniChatComponent"],
	function() {
	/**
	 * @class BPMSoft.configuration.ChatTimelineItemView
	 * Chat timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.ChatTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.ChatTimelineItemView",

		/**
		 * @private
		 */
		_getReadMoreButton: function() {
			return {
				"name": "ShowButtonContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["chat-show-more-less-button-container"],
				"items": [
					{
						"name": "ShowMoreLessIcon",
						"itemType": BPMSoft.ViewItemType.IMAGE,
						"getSrcMethod": "ShowMoreLessImage",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["chat-show-more-less-image"],
						}
					},	
					{
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.ShowChatButtonCaption"},
						"click": { "bindTo": "toggleChat"},
						"visible": {
							"bindTo": "IsChatShown",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						"id": "ShowChatButton",
						"classes": {
							"labelClass": ["chats-button"]
						},
					},
					{
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.HideChatButtonCaption"},
						"click": { "bindTo": "toggleChat"},
						"id": "HideChatButton",
						"visible": {
							"bindTo": "IsChatShown",
						},
						"classes": {
							"labelClass": ["chats-button"]
						},
					}
				]
			};
		},

		/**
		 * @private
		 */
		_getChatContainer: function () {
			return {
				"name": "Chat",
				"itemType": BPMSoft.ViewItemType.COMPONENT,
				"className": "BPMSoft.OmniChatComponent",
				"chatId": {
					"bindTo": "getChatId"
				},
				"visible": { "bindTo": "IsChatShown" }
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			return {
				itemType: BPMSoft.ViewItemType.CONTAINER,
				id: "ChatContainer",
				items: [this._getReadMoreButton(), this._getChatContainer()],
			};
		}

	});
});
