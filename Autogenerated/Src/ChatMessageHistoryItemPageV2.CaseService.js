define("ChatMessageHistoryItemPageV2", ["OmniChatUtilities", "OmnichannelConsts", "NetworkUtilities", "OmniChatComponent", "ImageCustomGeneratorV2"],
	function(OmniChatUtilities, OmnichannelConsts, NetworkUtilities) {
		return {
			entitySchemaName: "CaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this._setShowMoreLessIconUrl();
				},

				/**
				 * Toggles chat visibility.
				 */
				toggleChat: function() {
					const isShown = !this.$IsChatShown;
					this.set("IsChatShown", isShown);
					var omniEl =  Ext.select("ts-omnichannel-messaging-chat-history").elements[0];
					if (omniEl && isShown) {
						omniEl.addEventListener("contactClick", OmniChatUtilities.openContactCard.bind(this));
					}
					this._setShowMoreLessIconUrl();
				},

				/**
				 * @private
				 */
				_setShowMoreLessIconUrl: function() {
					const image = !this.$IsChatShown ?
						this.get("Resources.Images.ShowMoreImage")
						: this.get("Resources.Images.ShowLessImage");
					this.set("ShowMoreLessImage", this.BPMSoft.ImageUrlBuilder.getUrl(image));
				},

				/**
				 * Returns an image of the author.
				 * @protected
				 * @return {String} Image of the author.
				 */
				getCreatedByImage: function() {
					return this.getImageUrlByEntity(this.get("Contact"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getChannelIcon
				 * @overridden
				 */
				getChannelIcon: function () {
					return this.getImageUrlById(this.get("ChannelIcon").value);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryItemPage#historyMessageEsqApply
				 * @override
				 */
				historyMessageEsqApply: function(esq) {
					this.callParent(arguments);
					esq.addColumn("[OmniChat:Id:RecordId].Contact", "Contact");
					esq.addColumn("[OmniChat:Id:RecordId].Channel.Provider.Icon", "ChannelIcon");
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryItemPage#addAdditionalFilters
				 * @override
				 */
				addAdditionalFilters: function(esq) {
					var filterGroup = esq.createFilterGroup();
					filterGroup.name = "ChatNotifierFilter";
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					var closedGroup = esq.createFilterGroup();
					closedGroup.add("ChatMessageExists", esq.createExistsFilter("[OmniChat:Id:RecordId].Id"));
					closedGroup.add("OnlyClosedChat", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "[OmniChat:Id:RecordId].Status",
						OmnichannelConsts.Status.Completed));
					filterGroup.addItem(closedGroup);
					filterGroup.add(esq.createColumnIsNullFilter("[OmniChat:Id:RecordId].Id"));
					esq.filters.addItem(filterGroup);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryItemPage#openCreatedByPage
				 * @override
				 */
				openCreatedByPage: function() {
					var contact = this.get("Contact");
					if (this.isNotEmpty(contact) && contact.value !== this.BPMSoft.GUID_EMPTY) {
						this.showBodyMask();
						OmniChatUtilities.openContactCard.call(this, {
							detail: {
								contactId: contact.value
							}
						});
					}
				},

				/**
				 * Returns contact name.
				 * @protected
				 * @return {String} Contact name.
				 */
				getContactName: function () {
					var createdBy = this.get("Contact");
					return createdBy.displayValue;
				},

				/**
				 * Returns contact url.
				 * @return {String} Contact url.
				 */
				getContactUrl: function() {
					var createdBy = this.get("Contact");
					var hash = NetworkUtilities.getEntityUrl("Contact", createdBy.value);
					return this.get("Resources.Strings.ViewModuleUrl") + hash;
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "HistoryV1Container"
				},
				{
					"operation": "merge",
					"name": "HistoryV2Container",
					"values": {
						"wrapClass": ["historyV2-container-wrap", "historyV2-chat-message-main-container"]
					}
				},
				{
					"operation": "insert",
					"name": "HistoryV2CreatedByLink",
					"parentName": "HistoryV2MessageHeaderCenterContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"classes": {
							"hyperlinkClass": ["createdByLink"]
						},
						"caption": {
							"bindTo": "getContactName"
						},
						"href": {
							"bindTo": "getContactUrl"
						},
						"markerValue": "CreatedByLink",
						"target": this.BPMSoft.controls.HyperlinkEnums.target.SELF
					},
					"index": 0
				},
				{
					"operation": "merge",
					"name": "HistoryV2MessageContentContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"generator": function () {
							return {
								"className": "BPMSoft.OmniChatComponent",
								"chatId": {
									"bindTo": "RecordId"
								},
								"visible": { "bindTo": "IsChatShown" }
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "ShowButtonContainer",
					"parentName": "HistoryV2MessageFooterContainer",
					"propertyName": "items",
					"values": {
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
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
