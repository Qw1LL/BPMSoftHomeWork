define("ReleaseInConfItemDetail", ["BaseGridDetailV2Resources", "ConfigurationEnums",
		"NetworkUtilities"],
	function(resources, enums,NetworkUtilities) {
		return {
			entitySchemaName: "ReleaseConfItem",
			mixins: {
				NetworkUtilities: "BPMSoft.NetworkUtilities"
			},
			attributes: {
				"ActiveRow": {
					dataValueType: BPMSoft.DataValueType.GUID
				},

				"LastActiveRow": {
					dataValueType: BPMSoft.DataValueType.GUID
				},



				"CardState": {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				"EditPageUId": {
					dataValueType: BPMSoft.DataValueType.GUID
				},

			},
			methods: {
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * ############## ######### ######.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "Release";
					config.sectionEntitySchema = "ConfItem";
					config.lookupConfig.hideActions = true;
				},
				/**
				 * ######### #############.
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},
				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Release";
				},
				editRecord: function(record) {
					const activeRow = record || this.getActiveRow();
					if (!activeRow) {
						return;
					}
					if (!this.getIsCardValid()) {
						return;
					}
					const isCardChanged = this.getIsCardChanged();
					const primaryColumnValue = activeRow.get(activeRow.primaryColumnName);
					const typeColumnValue = this.getTypeColumnValue(activeRow);
					this.setLastActiveRow(primaryColumnValue);
					//

					const moduleStructure = BPMSoft.configuration.ModuleStructure[this.getFilterDefaultColumnName()];
					const moduleId = this._getChainCardModuleSandboxId(moduleStructure.cardModule);
					var historyState = this.sandbox.publish("GetHistoryState")
					if (isCardChanged) {
						this.set("CardState", enums.CardStateV2.EDIT);
						this.set("EditPageUId", typeColumnValue);
						this.set("PrimaryValueUId", primaryColumnValue);
						const args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					} else {
						NetworkUtilities.openCardInChain({
							sandbox: this.sandbox,
							entitySchemaName: moduleStructure.entitySchemaName,
							operation: enums.CardStateV2.EDIT,
							primaryColumnValue: activeRow.get(this.getFilterDefaultColumnName()).value,
							entitySchemaUId:moduleStructure.entitySchemaUId,
							historyState:historyState
						});
					}
				},
				getActiveRow: function() {
					const isEditable = this.get("IsEditable");
					let primaryColumnValue;
					if (isEditable) {
						primaryColumnValue = this.get("ActiveRow");
					} else {
						const selectedItems = this.getSelectedItems();
						if (this.Ext.isEmpty(selectedItems)) {
							return null;
						}
						primaryColumnValue = selectedItems[0];
					}
					if (primaryColumnValue) {
						const gridData = this.getGridData();
						return gridData.get(primaryColumnValue);
					}
				},
				getGridData: function() {
					return this.get("Collection");
				},
				getIsCardValid: function() {
					return this.sandbox.publish("ValidateCard", null, [this.sandbox.id]);
				},
				getIsCardChanged: function() {
					return this.sandbox.publish("IsCardChanged", null, [this.sandbox.id]);
				},
				setLastActiveRow: function(primaryColumnValue) {
					this.set("LastActiveRow", primaryColumnValue);
				},


				_getChainCardModuleSandboxId: function(moduleName) {
					return this.sandbox.id + moduleName + "_chain00000000-0000-0000-0000-000000000000";
				},
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
