define("CaseDetailSelectModule", ["ConfigurationEnums", "BaseDetailV2"],
	function(enums) {
		return {
			entitySchemaName: "Case",
			extend: "CaseDetail",
			attributes: {},
			messages: {
				/**
				 * @message DetailActiveRowChanged
				 * ########## # ######### ######## ###### ## ######.
				 * @param {Object} ############ ########### ########.
				 */
				"DetailActiveRowChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				/**
				 * ############## ######
				 * @protected
				 * @overridden
				 */
				initDetailOptions: function() {
					this.callParent();
					this.set("IsDetailCollapsed", false);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#editRecord
				 * @overridden
				 */
				editRecord: function(record) {
					var activeRow = record || this.getActiveRow();
					if (!activeRow) {
						return;
					}
					var primaryColumnValue = activeRow.get(activeRow.primaryColumnName);
					var typeColumnValue = this.getTypeColumnValue(activeRow);
					this.openCard(enums.CardStateV2.EDIT, typeColumnValue, primaryColumnValue);
				},

				/**
				 * ########## ######### ######### ###### # #######
				 * @protected
				 * @param {String} rowId ############# ######### ######
				 */
				onActiveRowChanged: function(rowId) {
					if (rowId === this.get("activeRow")) {
						return;
					}
					if (!rowId) {
						rowId = this.get("activeRow");
					}
					if (!rowId) {
						return;
					}
					var gridData = this.getGridData();
					var config = {
						activeRow: gridData.get(rowId),
						entitySchemaName: this.entitySchemaName
					};
					this.sandbox.publish("DetailActiveRowChanged", config, [this.sandbox.id]);
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "Detail",
					"values": {
						"caption": "",
						"collapsed": false,
						"isHeaderVisible": false,
						"markerValue": "CaseListControl"
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"selectRow": {"bindTo": "onActiveRowChanged"}
					}
				},
				{
					"operation": "remove",
					"name": "AddRecordButton"
				},
				{
					"operation": "remove",
					"name": "ActionsButton"
				}
			]
		};
	});
