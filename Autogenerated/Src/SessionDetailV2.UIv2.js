define("SessionDetailV2", ["BPMSoft", "SessionDetailV2Resources"],
	function(BPMSoft, resources) {
		return {
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "AddRecordButton"
				},
				{
					"operation": "remove",
					"name": "ActionsButton"
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"parentName": "Detail",
					"propertyName": "items",
					"values": {
						"selectRow": {"bindTo": "rowSelected"},
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"activeRowActions": []
					}
				},
				{
					"operation": "insert",
					"name": "EndTheSessionActionButton",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": resources.localizableStrings.EndTheSessionButtonCaption,
						"tag": "endSession",
						"markerValue": "EndSessionButtonMarker",
					}
				},
				{
					"operation": "insert",
					"name": "EndTheSessionButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.EndTheSessionButtonCaption"},
						"click": {"bindTo": "endTheSession"},
						"enabled": {"bindTo": "EndTheSessionButtonEnabled"}
					}
				}
			]/**SCHEMA_DIFF*/,
			entitySchemaName: "SysUserSession",
			methods: {

				/**
				 * ########## ####### ## ###### ########## ######.
				 * @protected
				 * @param {String} buttonTag ### ######.
				 * @param {Guid} primaryColumnValue ############# ########## ######.
				 */
				onActiveRowAction: function(buttonTag, primaryColumnValue) {
					switch (buttonTag) {
						case "endSession":
							this.endTheSession(primaryColumnValue);
							break;
					}
				},

				/**
				 * ############ ####### ###### ###### #######.
				 * @protected
				 */
				rowSelected: function(primaryColumnValue) {
					this.setEndTheSessionButtonEnable(primaryColumnValue);
				},

				/**
				 * @inheritdoc GridUtilitiesV2#onGridDataLoaded
				 * @overridden
				 */
				onGridDataLoaded: function() {
					this.callParent(arguments);
					this.setEndTheSessionButtonEnable(this.get("ActiveRow"));
				},

				/**
				 * ######## ######## ########### ###### "######### #####".
				 * @protected
				 * @return {boolean} ######### ######.
				 */
				setEndTheSessionButtonEnable: function(primaryColumnValue) {
					var visible = false;
					var activeRow;
					if (primaryColumnValue) {
						var gridData = this.getGridData();
						activeRow = gridData.find(primaryColumnValue) ? gridData.get(primaryColumnValue) : null;
					}
					if (!this.Ext.isEmpty(activeRow)) {
						visible = this.Ext.isEmpty(activeRow.get("SessionEndDate"));
					}
					this.set("EndTheSessionButtonEnabled", visible);
				},

				/**
				 * @inheritdoc BaseDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BaseDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				addRecordOperationsMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * ############ ##### ####### ##### ######## ######### #####.
				 * @param {Object} response ######, ########## ##### #######.
				 * @protected
				 */
				endTheSessionCallBack: function(response) {
					if (response) {
						if (!this.Ext.isEmpty(response.TerminateSessionResult) &&
							response.TerminateSessionResult >= 0) {
							this.reloadGridData();
						} else {
							this.showInformationDialog(
								this.get("Resources.Strings.TerminateSessionErrorMessage"));
						}
					}
				},

				/**
				 * ######### ######## "######### #####".
				 * @protected
				 */
				endTheSession: function() {
					this.showConfirmationDialog(this.get("Resources.Strings.TerminateSessionMessage"),
						function(returnCode) {
							if (returnCode === this.BPMSoft.MessageBoxButtons.NO.returnCode || returnCode === null) {
								return;
							}
							var dataSend = {
								recordId: this.get("ActiveRow")
							};
							var config = {
								serviceName: "AdministrationService",
								methodName: "TerminateSession",
								data: dataSend
							};
							this.callService(config, this.endTheSessionCallBack);
						},
						[this.BPMSoft.MessageBoxButtons.YES.returnCode, this.BPMSoft.MessageBoxButtons.NO.returnCode],
						null);
				},

                /**
                 * @overridden
                 * @return {String} ### #######.
                 */
                getFilterDefaultColumnName: function() {
                    return "SessionStartDate";
                }
			}
		};
	});
