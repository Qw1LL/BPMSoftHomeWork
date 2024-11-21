define("LocalMessageHistoryItemPageV2", ["css!LocalMessageHistoryItemStyleV2"],
	function() {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getChannelIcon
				 * @override
				 */
				getChannelIcon: function () {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.LocalChannelIcon"));
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "HistoryV1Container"
				},
				{
					"operation": "remove",
					"name": "HistoryV2MessageHeaderContainer"
				},
				{
					"operation": "move",
					"name": "ChannelIcon",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "ChannelIcon",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClass": ["localMessage-channelIcon"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "HistoryV2MessageContentContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"wrapClass": ["localMessage-message-content-container"]
					}
				},
				{
					"operation": "move",
					"name": "MessageText",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.MultilineLabel",
								"classes": {
									"multilineLabelClass": ["localMessage-text"]
								},
								"caption": {
									"bindTo": "getLocalMessageText"
								},
								"showLinks": true
							};
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
