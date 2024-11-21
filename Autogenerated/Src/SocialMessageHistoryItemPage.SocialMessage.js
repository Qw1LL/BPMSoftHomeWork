define("SocialMessageHistoryItemPage", ["SocialMessageConstants", "css!SocialMessageHistoryItemStyle"],
	function(socialMessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryPage#historyMessageEsqApply
				 * @overridden
				 */
				historyMessageEsqApply: function(esq) {
					var filterGroup = esq.createFilterGroup();
					filterGroup.name = "SocialNotifierFilter";
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.add("SocialMessageExists", esq.createExistsFilter("[SocialMessage:Id:RecordId].Id"));
					filterGroup.add("NotSocialNotifier", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, "MessageNotifier",
						socialMessageConstants.MessageNotifier.Social));
					esq.filters.addItem(filterGroup);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "HistoryMessageWrapContainer",
					"values": {
						"wrapClass": ["historyMessageWrap", "historySocialMessageWrap"],
						"markerValue": "SocialHistoryMessageWrapContainer"
					}
				},
				{
					"operation": "merge",
					"name": "MessageContentContainer",
					"values": {
						"wrapClass": ["messageContent", "speech-bubble"]
					}
				},
				{
					"operation": "insert",
					"name": "CreatedByLink",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"classes": {
							"hyperlinkClass": ["link", "createdByLink", "label-url", "label-link"]
						},
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"href": {
							"bindTo": "getCreatedByUrl"
						},
						"markerValue": "CreatedByLink",
						"target": this.BPMSoft.controls.HyperlinkEnums.target.SELF
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "CreationInfo",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"id": "CreationInfo",
						"labelClass": ["creationInfoLabel"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreationInfo"
						}
					},
					"index": 2
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
