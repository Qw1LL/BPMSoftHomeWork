define("ContactPageV2", [],
function() {
	return {
		entitySchemaName: "Contact",
		messages: {
			/**
			 * @message HistoryTabDeactivated
			 * ######## # ########### ####### "#######".
			 * @param {String} tabName ######## #######.
			 */
			"HistoryTabDeactivated": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#activeTabChange
			 * @overridden
			 */
			activeTabChange: function() {
				var tabName = this.get("ActiveTabName");
				if (tabName === "HistoryTab") {
					var detailId = this.getDetailId("Calls");
					this.sandbox.publish("HistoryTabDeactivated", null, [detailId]);
				}
				this.callParent(arguments);
			}
		},
		details: /**SCHEMA_DETAILS*/{
			Calls: {
				schemaName: "CallDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "HistoryTab",
				"index": 1,
				"propertyName": "items",
				"name": "Calls",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
