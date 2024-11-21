define("EmailMessageHistoryItemPage", ["ServiceDeskConstants", "ConfigurationConstants", "EmailMessageConstants",
		"NetworkUtilities",	"MaskHelper", "css!EmailMessageHistoryItemStyle"],
	function(ServiceDeskConstants, ConfigurationConstants, EmailMessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {

				/**
				 * Case origin.
				 */
				"CaseOrigin": {
					dataValueType: BPMSoft.DataValueType.GUID,
					value: ServiceDeskConstants.CaseOrigin.Email
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
						message = this.get("[Activity:Id:RecordId].Body");
					}
					return message;
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryItemPage#getHistoryData
				 * @overridden
				 */
				getHistoryData: function() {
					var historyData = this.callParent(arguments);
					historyData.activityId = this.get("RecordId");
					return historyData;
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
				 * Creates dependent CaseMessageHistory entity, which used when new case created.
				 * @private
				 * @param {Object} data Data for email message.
				 * @returns {Array} Array of case message history column values.
				 */
				_getCaseMessageHistoryEntity: function(data) {
					return {
						entitySchemaName: "CaseMessageHistory",
						columnValues: [
							{
								name: "Message",
								value: this.get("[Activity:Id:RecordId].Body"),
								dataValueType: this.BPMSoft.DataValueType.TEXT
							},
							{
								name: "RecordId",
								value: data.activityId,
								dataValueType: this.BPMSoft.DataValueType.GUID
							},
							{
								name: "MessageNotifier",
								value: EmailMessageConstants.MessageNotifier.Email,
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
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryItemPage#isHistoryActionVisible
				 * @overridden
				 */
				isHistoryActionVisible: function() {
					return true;
				}
			},
			diff: /**SCHEMA_DIFF*/[

			]/**SCHEMA_DIFF*/
		};
	}
);
