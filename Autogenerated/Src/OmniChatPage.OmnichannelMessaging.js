define("OmniChatPage", ["OmnichannelConsts", "OmniChatUtilities", "OmniChatComponent"],
	function(OmnichannelConsts, OmniChatUtilities) {
	return {
		entitySchemaName: "OmniChat",
		attributes: {
			"Channel": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"lookupListConfig": {
					"columns": [
						"Provider",
						"ChatQueue"
					]
				}
			},
			"ChannelProvider": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.ChannelProviderCaption"}
			},
			"ChatQueue": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.ChatQueueCaption"}
			}
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"Files": {
				"schemaName": "FileDetailV2",
				"entitySchemaName": "OmniChatFile",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "OmniChat"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {

			/**
			 * @inheritDoc BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.set("ChannelProvider", this.get("Channel").Provider);
				this.set("ChatQueue", this.get("Channel").ChatQueue);
			},

			/**
			 * Returns true if chat was completed.
			 */
			isChatCompleted: function() {
				return (this.$Status && this.$Status.value) === OmnichannelConsts.Status.Completed;
			},

			/**
			 * Chat component rendered action.
			 * @protected
			 */
			chatComponentRendered: function() {
				const omniEl =  Ext.select("ts-omnichannel-messaging-chat-history").elements[0];
				if (omniEl) {
					omniEl.addEventListener("contactClick", OmniChatUtilities.openContactCard.bind(this));
				}
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Contact",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ProfileContainer"
					},
					"enabled": false,
					"bindTo": "Contact"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Channel",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ProfileContainer"
					},
					"enabled": false,
					"bindTo": "Channel"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ChannelProvider",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"controlConfig": {
						"iconsVisible": true
					},
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "ChannelProvider",
					"enabled": false
				},
				"parentName": "ProfileContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ChatQueue",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "ProfileContainer"
					},
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "ChatQueue",
					"enabled": false
				},
				"parentName": "ProfileContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ChatDurationContainter",
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"values": {
					"id": "ChatDurationContainter",
					"selectors": {"wrapEl": "#ChatDurationContainter"},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["chat-duration-container", "profile-container"]
					},
					"items": [],
					"markerValue": "ChatDurationContainter"
				}
			},
			{
				"operation": "insert",
				"name": "ChatStartDate",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					},
					"bindTo": "ChatStartDate",
					"enabled": false
				},
				"parentName": "ChatDurationContainter",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ChatEndDate",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					},
					"bindTo": "ChatEndDate",
					"enabled": false
				},
				"parentName": "ChatDurationContainter",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ChatDurationInMinutes",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					},
					"bindTo": "ChatDuration",
					"enabled": false
				},
				"parentName": "ChatDurationContainter",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "FirstReplyTime",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					},
					"bindTo": "FirstReplyTime",
					"enabled": false
				},
				"parentName": "ChatDurationContainter",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ConversationTab",
				"values": {
					"items": [],
					"caption": {
						"bindTo": "Resources.Strings.ConversationTabCaption"
					},
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ChatConversationContainer",
				"parentName": "ConversationTab",
				"propertyName": "items",
				"values": {
					"id": "ChatConversationContainer",
					"selectors": {"wrapEl": "#ChatConversationContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "ChatConversationContainer",
					"visible": {
						"bindTo": "isChatCompleted",
					}
				}
			},
			{
				"operation": "insert",
				"name": "ChatConversation",
				"parentName": "ChatConversationContainer",
				"propertyName": "items",
				"values": {
					"id": "ChatConversation",
					"itemType": this.BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.OmniChatComponent",
					"chatId": {
						"bindTo": "Id"
					},
					"afterrerender": {
						"bindTo": "chatComponentRendered"
					},
					"afterrender": {
						"bindTo": "chatComponentRendered"
					},
				}
			},
			{
				"operation": "insert",
				"name": "NotesAndFilesTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.NotesAndFilesTabCaption"
					},
					"items": [],
					"order": 2
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Files",
				"values": {
					"itemType": 2
				},
				"parentName": "NotesAndFilesTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "NotesControlGroup",
				"values": {
					"itemType": 15,
					"caption": {
						"bindTo": "Resources.Strings.NotesGroupCaption"
					},
					"items": []
				},
				"parentName": "NotesAndFilesTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Notes",
				"values": {
					"bindTo": "Notes",
					"dataValueType": 1,
					"contentType": 4,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"imageLoaded": {
							"bindTo": "insertImagesToNotes"
						},
						"images": {
							"bindTo": "NotesImagesCollection"
						}
					}
				},
				"parentName": "NotesControlGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 3
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
