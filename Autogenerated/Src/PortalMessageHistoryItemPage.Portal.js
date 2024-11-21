define("PortalMessageHistoryItemPage", ["ServiceDeskConstants", "PortalMessageConstants",
		"css!PortalMessageHistoryItemStyle"],
	function(ServiceDeskConstants, PortalMessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {

				/**
				 * Case origin.
				 */
				"CaseOrigin": {
					dataValueType: BPMSoft.DataValueType.GUID,
					value: ServiceDeskConstants.CaseOrigin.Portal
				}
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryItemPage#getMessageFromHistory
				 * @overridden
				 */
				getMessageFromHistory: function() {
					var message = this.get("HighlightedHistoryMessage");
					if (this.isHistoryMessageEmpty(message)) {
						message = this.get("Message");
					}
					return message;
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryItemPage#getDependentEntities
				 * @overridden
				 */
				getDependentEntities: function(data) {
					var caseMessageHistoryEntity = this._getCaseMessageHistoryEntity(data);
					return [caseMessageHistoryEntity];
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryItemPage#getHistoryData
				 * @overridden
				 */
				getHistoryData: function() {
					var historyData = this.callParent(arguments);
					historyData.recordId = this.get("RecordId");
					return historyData;
				},

				/**
				 * Creates depended CaseMessageHistory entity, which used when new case created.
				 * @private
				 * @param data Data for portal message.
				 * @returns {Array} Array of portal message column values.
				 */
				_getCaseMessageHistoryEntity: function(data) {
					return {
						entitySchemaName: "CaseMessageHistory",
						columnValues: [
							{
								name: "Message",
								value: this.get("Message"),
								dataValueType: this.BPMSoft.DataValueType.TEXT
							},
							{
								name: "RecordId",
								value: data.recordId,
								dataValueType: this.BPMSoft.DataValueType.GUID
							},
							{
								name: "MessageNotifier",
								value: PortalMessageConstants.MessageNotifier.Portal,
								dataValueType: this.BPMSoft.DataValueType.GUID
							},
							{
								name: "Case",
								value: data.newCaseId,
								dataValueType: this.BPMSoft.DataValueType.GUID
							},
							{
								name: "CreatedOn",
								value: this.get("CreatedOn"),
								dataValueType: this.BPMSoft.DataValueType.DATE_TIME
							}
						]
					};
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "move",
					"name": "EmailAction",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "merge",
					"name": "MessageText",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.SelectionHandlerMultilineLabel",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Message"
								},
								"showLinks": true,
								"selectedTextChanged": {"bindTo": "onSelectedTextChanged"},
								"selectedTextHandlerButtonClick": {"bindTo": "onSelectedTextButtonClick"},
								"showFloatButton": {"bindTo": "CreateCaseFromHistoryFeatureState"}
							};
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
