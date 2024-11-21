define("ContractDetailV2", ["BPMSoft", "ConfigurationEnums", "BusinessRuleModule"],
function(BPMSoft, enums) {
	return {
		entitySchemaName: "Contract",
		attributes: {},
		messages: {
			/**
			 * @message CardModuleResponse
			 * ########## ########## # ########## ########.
			 * @param {Object} ############ ########### ########.
			 */
			"CardModuleResponse": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				var cardModuleId = this.sandbox.id.replace("_detail_ContractContract", "") + "_ContractEdit";
				this.sandbox.subscribe("CardModuleResponse", function(config) {
					if (this.destroyed) {
						return;
					}
					this.loadGridDataRecord(config.primaryColumnValue);
				}, this, [cardModuleId]);
			},

			/**
			 * ########## ######### ## ########## ############ ######## ############## # ########## #####
			 * ######## ########### ########## ### ##### # #########
			 * @private
			 */
			linkWithExisting: function() {
				var editPages = this.get("EditPages");
				if (editPages.getCount() === 0) {
					return;
				}
				var editPage = editPages.getByIndex(0);
				var editPageUId = editPage.get("Tag");
				var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
				var isNew = (cardState.state === enums.CardStateV2.ADD ||
				cardState.state === enums.CardStateV2.COPY);
				if (isNew) {
					this.set("CardState", enums.CardStateV2.ADD);
					this.set("EditPageUId", editPageUId);
					var scope = this;
					var args = {
						isSilent: true,
						callback: function() {
							scope.openContractLookupToLink();
						},
						messageTags: [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
				} else {
					this.openContractLookupToLink();
				}
			},
			/**
			 * ######### ########## ########## ### ###### #######,
			 * ####### ########## ####### # ####### #########.
			 * @private
			 */
			getLookupFilters: function() {
				var config = {
					entitySchemaName: "Contract",
					multiSelect: true,
					columns: ["Number", "Account", "Type", "State"]
				};
				var filterGroup = this.BPMSoft.createFilterGroup();
				var defaultValues = this.get("DefaultValues");
				var existsFilterGroup = this.BPMSoft.createFilterGroup();
				existsFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Parent", this.get("MasterRecordId")));
				var existsFilter = this.BPMSoft.createNotExistsFilter("Id", existsFilterGroup);
				filterGroup.addItem(existsFilter);
				var filterGroupNull = this.BPMSoft.createFilterGroup();
				filterGroupNull.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				filterGroupNull.addItem(this.BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Parent", this.get("MasterRecordId")));
				filterGroupNull.addItem(this.BPMSoft.createColumnIsNullFilter("Parent"));
				filterGroup.addItem(filterGroupNull);
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_EQUAL, "Id", this.get("MasterRecordId")));
				if (defaultValues) {
					this.BPMSoft.each(defaultValues, function(defValue) {
						if (defValue.name === "Account" || defValue.name === "OurCompany") {
							filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, defValue.name, defValue.value));
						}
					}, this);
				}
				config.filters = filterGroup;
				return config;
			},
			/**
			 * ######### ########## ########## ### ###### #######,
			 * ####### ########## ####### # ####### #########.
			 * @private
			 */
			openContractLookupToLink: function() {
				var config = this.getLookupFilters();
				this.openLookup(config, this.linkSelectedRecords, this);
			},
			/**
			 * ######### ##### ### ######### ####### # ############ #########.
			 * ########## ####### ########### ####### # # ##### ########## #########,
			 * ####### ######### #### ######### ## ######### # ##########.
			 * @param {Object} args ###### #### {columnName: string, selectedRows: []}.
			 * ######## ###### ######### ####### ## ###########.
			 * @private
			 */
			linkSelectedRecords: function(args) {
				var selectedRows = args.selectedRows.getItems();
				var totalCount = selectedRows.length;
				var addedCount = 0;
				var callsCount = 0;
				this.BPMSoft.each(selectedRows, function(item) {
					callsCount++;
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Contract"
					});
					update.enablePrimaryColumnFilter(item.value);
					update.setParameterValue("Parent", this.get("MasterRecordId"), this.BPMSoft.DataValueType.GUID);
					update.execute(function(response) {
						if (response && response.success) {
							addedCount++;
						}
						if (callsCount === totalCount) {
							var resultMessage =
								this.Ext.String.format(this.get("Resources.Strings.AddedLinksCountMessage"),
									addedCount, totalCount);
							this.BPMSoft.showInformation(resultMessage);
							this.reloadGridData();
						}
					}, this);
				}, this);
			},
			/**
			 * ####### ##### ############ ######## # ####### #########.
			 * @private
			 */
			deleteLinkWithContracts: function() {
				this.showBodyMask();
				var selectedRows = this.getSelectedItems();
				var update = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "Contract"
				});
				update.filters.add("ContractsFilter",
					BPMSoft.createColumnInFilterWithParameters("Id", selectedRows));
				update.setParameterValue("Parent", null, this.BPMSoft.DataValueType.GUID);
				this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
					function(returnCode) {
						if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
							update.execute(function() {
								this.hideBodyMask();
								this.set("ActiveRow", null);
								this.set("SelectedRow", null);
								this.reloadGridData();
							}, this);
						} else {
							this.hideBodyMask();
						}
					},
					[this.BPMSoft.MessageBoxButtons.YES.returnCode,
						this.BPMSoft.MessageBoxButtons.NO.returnCode]);
			},
			/**
			 * ##########/######## ###### ##### # ############ #########
			 * @private
			 * @returns {boolean} ########## ####### ######### ######.
			 */
			getLinkButtonVisible: function() {
				return (this.get("CardPageName") === "ContractPageV2");
			},
			/**
			 ** ######### ######## ############### ######## # ######### ########### ###### ############## ######.
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @overridden
			 */
			addRecordOperationsMenuItems: function(toolsButtonMenu) {
				this.callParent(arguments);
				toolsButtonMenu.addItem(this.getButtonMenuSeparator());
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.LinkWithExistingCaption"},
					Click: {"bindTo": "linkWithExisting"},
					Visible: {"bindTo": "getLinkButtonVisible"}
				}));
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.DeleteLinkWithContractsCaption"},
					Click: {"bindTo": "deleteLinkWithContracts"},
					Visible: {"bindTo": "getLinkButtonVisible"},
					Enabled: {"bindTo": "getSelectedItems"}
				}));
			},
			/**
			 * ############# ######### ###### "########" # ########### ## ######## ########
			 * @protected
			 *
			 * @return {String}
			 */
			getContractDetailCaption: function() {
				var cardPageName = this.get("CardPageName");
				if (cardPageName === "ContractPageV2") {
					return this.get("Resources.Strings.ContractCaption");
				}
				return this.get("Resources.Strings.Caption");
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "NumberListedGridColumn",
								"bindTo": "Number",
								"position": {
									"column": 1,
									"colSpan": 11
								},
								"type": BPMSoft.GridCellType.TITLE
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {
							"columns": 24,
							"rows": 3
						},
						"items": [
							{
								"name": "NumberTiledGridColumn",
								"bindTo": "Number",
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 11
								},
								"type": BPMSoft.GridCellType.TITLE
							}
						]
					}
				}
			},
			{
				"operation": "merge",
				"name": "Detail",
				"values": {
					caption: {bindTo: "getContractDetailCaption"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
