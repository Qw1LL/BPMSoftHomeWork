define("ContractProductDetailV2", ["BPMSoft", "ProductInContractUtilitiesV2", "ConfigurationEnums"],
		function(BPMSoft, PICUtilities, ConfigurationEnums) {
			return {
				entitySchemaName: "OrderProduct",
				messages: {
					/**
					 * @message CalcAmount
					 * ######## ######## # ############# ######### #####.
					 */
					"CalcAmount": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message GetPageInfo
					 * ########## ########## # ########.
					 * @param {Object} ########## # ########.
					 */
					"GetPageInfo": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {},
				methods: {
					deleteLink: function() {
						this.showBodyMask();
						var selectedRows = this.getSelectedItems();
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "OrderProduct"
						});
						update.filters.add("ProductsFilter",
						BPMSoft.createColumnInFilterWithParameters("Id", selectedRows));
						update.setParameterValue("Contract", null, this.BPMSoft.DataValueType.GUID);
						this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
							function(returnCode) {
								if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									update.execute(function() {
										this.hideBodyMask();
										this.set("ActiveRow", null);
										this.set("SelectedRow", null);
										this.reloadGridData();
										this.sandbox.publish("CalcAmount");
									}, this);
								} else {
									this.hideBodyMask();
								}
							},
							[this.BPMSoft.MessageBoxButtons.YES.returnCode,
								this.BPMSoft.MessageBoxButtons.NO.returnCode]);
					},

					/**
					 * ######### ######## # ######### ########### ###### ############## ######.
					 * @protected
					 * @virtual
					 * @param {BaseViewModelCollection} toolsButtonMenu ######### ###########
					 * ###### ############## ######.
					 */
					addToolsButtonMenuItems: function(toolsButtonMenu) {
						toolsButtonMenu.addItem(this.getButtonMenuSeparator());
						toolsButtonMenu.addItem(this.getButtonMenuItem({
							Caption: {"bindTo": "Resources.Strings.DeleteMenuCaption"},
							Click: {"bindTo": "deleteLink"},
							Enabled: {"bindTo": "getSelectedItems"}
						}));
						this.addGridOperationsMenuItems(toolsButtonMenu);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecord
					 * @overridden
					 */
					addRecord: function() {
						var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
						var isNew = (cardState.state === ConfigurationEnums.CardStateV2.ADD ||
							cardState.state === ConfigurationEnums.CardStateV2.COPY);
						if (isNew) {
							this.sandbox.publish("SaveRecord", {
								isSilent: true,
								messageTags: [this.sandbox.id]
							}, [this.sandbox.id]);
						} else {
							this.openProductLookup();
						}
					},

					/**
					 * ######### ########## ######### ### ###### #######.
					 * @virtual
					 */
					openProductLookup: function() {
						var pageInfo = this.sandbox.publish("GetPageInfo", null, [this.sandbox.id]);
						var order = pageInfo.get("Order");
						var orderValue = this.Ext.isEmpty(order) ? this.BPMSoft.GUID_EMPTY : order.value;
						PICUtilities.openProductLookupToLink(orderValue, pageInfo.get("Id"),
							function() {
								this.updateDetail({detail: "Product", reloadAll: true});
								this.sandbox.publish("CalcAmount");
							}, this);
					},

					/**
					 * ########## ####### ######### ########## # ####### ######.
					 * @inheritdoc BaseGridDetailV2#onCardSaved
					 * @overridden
					 */
					onCardSaved: function() {
						this.openProductLookup();
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
										"name": "NameListedGridColumn",
										"bindTo": "Name",
										"position": {
											"column": 1,
											"colSpan": 11
										},
										"type": BPMSoft.GridCellType.TITLE
									},
									{
										"name": "QuantityListedGridColumn",
										"bindTo": "Quantity",
										"position": {
											"column": 13,
											"colSpan": 6
										}
									},
									{
										"name": "TotalAmountListedGridColumn",
										"bindTo": "TotalAmount",
										"position": {
											"column": 19,
											"colSpan": 6
										}
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
										"name": "NameTiledGridColumn",
										"bindTo": "Name",
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 16
										},
										"type": BPMSoft.GridCellType.TITLE
									},
									{
										"name": "QuantityTiledGridColumn",
										"bindTo": "Quantity",
										"position": {
											"row": 1,
											"column": 17,
											"colSpan": 8
										}
									},
									{
										"name": "PriceTiledGridColumn",
										"bindTo": "Price",
										"position": {
											"row": 2,
											"column": 1,
											"colSpan": 8
										}
									},
									{
										"name": "DiscountPercentTiledGridColumn",
										"bindTo": "DiscountPercent",
										"position": {
											"row": 2,
											"column": 9,
											"colSpan": 8
										}
									},
									{
										"name": "TotalAmountTiledGridColumn",
										"bindTo": "TotalAmount",
										"position": {
											"row": 2,
											"column": 17,
											"colSpan": 8
										}
									}
								]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
