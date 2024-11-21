define("OrderPageV2", ["ConfigurationEnums"],
	function(ConfigurationEnums) {
		return {
			entitySchemaName: "Order",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#getActions
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.add("CreateContract", this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.CreateContract"},
						"Tag": "createContract",
						"Enabled": {"bindTo": "canEntityBeOperated"}
					}));
					return actionMenuItems;
				},

				/**
				 * ########## ###### ######## ####### ### ######## ########.
				 * @return {Array}
				 */
				getContractColumnValues: function() {
					var columnValues = [{name: "Order", value: this.get("Id")}];
					var account = this.get("Account");
					if (account) {
						columnValues.push({
							name: "Account",
							value: account.value
						});
					}
					var owner = this.get("Owner");
					if (owner) {
						columnValues.push({
							name: "Owner",
							value: owner.value
						});
					}
					var currency = this.get("Currency");
					if (currency) {
						columnValues.push({
							name: "Currency",
							value: currency.value
						});
					}
					var currencyRate = this.get("CurrencyRate");
					if (currencyRate) {
						columnValues.push({
							name: "CurrencyRate",
							value: currencyRate,
							dataValueType: this.BPMSoft.DataValueType.FLOAT
						});
					}
					var currentUserAccount = this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT.value;
					if (currentUserAccount && !this.BPMSoft.isEmptyGUID(currentUserAccount)) {
						columnValues.push({
							name: "OurCompany",
							value: currentUserAccount
						});
					}
					return columnValues;
				},

				/**
				 * ######## ######### ## ######### ######.
				 * @private
				 */
				createContract: function() {
					var columnValues = this.getContractColumnValues();
					var columnValuesContainsColumn = function(columnName) {
						return Boolean(this.BPMSoft.findItem(columnValues, {name: columnName}));
					}.bind(this);
					if (!columnValuesContainsColumn("Account") || !columnValuesContainsColumn("OurCompany")) {
						this.openContractPage({
							id: this.BPMSoft.GUID_EMPTY,
							operation: ConfigurationEnums.CardStateV2.ADD,
							defaultValues: columnValues
						});
						return;
					}
					this.showBodyMask();
					this.insertContract(columnValues, function(response) {
						this.hideBodyMask();
						if (response.id) {
							this.onContractInserted(response.id);
						}
					}, this.hideBodyMask, this);
				},

				/**
				 * ####### ####### # ##.
				 * @protected
				 * @param {Array} columnValues ######## ####### ########.
				 * @param {Function} successCallback ##### ######### ######. ########### # ###### ######.
				 * @param {Function} errorCallback ##### ######### ######. ########### # ###### ######.
				 * @param {Object} scope ######## ##########.
				 */
				insertContract: function(columnValues, successCallback, errorCallback, scope) {
					var data = {
						sysSettingName: "Contract" + this.get("Resources.Strings.IncrementNumberSuffix"),
						sysSettingMaskName: "Contract" + this.get("Resources.Strings.IncrementMaskSuffix")
					};
					this.callServiceMethod("SysSettingsService", "GetIncrementValueVsMask", function(response) {
						var number = response ? response.GetIncrementValueVsMaskResult : null;
						var insertQuery = Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "Contract"
						});
						var guidType = this.BPMSoft.DataValueType.GUID;
						insertQuery.setParameterValue("Id", this.BPMSoft.generateGUID(), guidType);
						insertQuery.setParameterValue("Number", number, this.BPMSoft.DataValueType.TEXT);
						this.BPMSoft.each(columnValues, function(columnValue) {
							insertQuery.setParameterValue(columnValue.name, columnValue.value,
									columnValue.dataValueType || guidType);
						}, this);
						insertQuery.execute(function(response) {
							if (response.success) {
								successCallback.call(scope, response);
							} else {
								errorCallback.call(scope, response);
							}
						}, this);
					}, data, this);
				},

				/**
				 * ######### ####### ######### # ######, ### ## ########## ######### ######## ######## ### ####
				 * # ########## ########### #########.
				 * @private
				 * @param {GUID} contractId Id ######### ########.
				 */
				onContractInserted: function(contractId) {
					this.getIsOrderHasUnlinkedProducts(function(show) {
						if (!show) {
							this.openContractPage({
								id: contractId,
								operation: ConfigurationEnums.CardStateV2.EDIT
							});
							return;
						}
						this.showProductsConfirmation(function(buttonCode) {
							if (buttonCode === "ButtonAll") {
								this.connectProducts(contractId);
							} else if (buttonCode === "ButtonChoice") {
								this.openProductLookupToLink(contractId);
							} else {
								this.openContractPage({
									id: contractId,
									operation: ConfigurationEnums.CardStateV2.EDIT
								});
							}
						});
					});
				},

				/**
				 * ########## ########## #### # ########## ########### ######### # #######.
				 * @private
				 * @param {Function} handler ##### ######### ######.
				 */
				showProductsConfirmation: function(handler) {
					this.BPMSoft.showConfirmation(
						this.get("Resources.Strings.LinkProductCaption"),
						handler,
						[{
							className: "BPMSoft.Button",
							returnCode: "ButtonAll",
							style: this.BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: this.get("Resources.Strings.QuestionAllCaption"),
							markerValue: this.get("Resources.Strings.QuestionAllCaption")
						},
						{
							className: "BPMSoft.Button",
							returnCode: "ButtonChoice",
							style: this.BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: this.get("Resources.Strings.QuestionChoiceCaption"),
							markerValue: this.get("Resources.Strings.QuestionChoiceCaption")
						},
						"cancel"],
						this,
						{defaultButton: 0}
					);
				},

				/**
				 * ######### ######## ############## ########.
				 * @private
				 * @param {Object} config ######### ######## ########.
				 * @param {String} config.operation ### ######## ######## ##############.
				 * @param {GUID} config.id ############# ########.
				 * @param {Array} [config.defaultValues] ######## ## ######### ### ########### ######.
				 */
				openContractPage: function(config) {
					this.showBodyMask();
					this.openCardInChain({
						schemaName: "ContractPageV2",
						operation: config.operation,
						id: config.id,
						defaultValues: config.defaultValues,
						moduleId: this.sandbox.id + "_ContractEditByOrderPage"
					});
				},

				/**
				 * ######### ########## ######### ###### ### ###### #######,
				 * ####### ########## ####### # ####### #########.
				 * @private
				 * @param {String} id ############# ########.
				 */
				openProductLookupToLink: function(id) {
					var config = {
						entitySchemaName: "OrderProduct",
						multiSelect: true,
						columns: ["Name"]
					};
					var orderId = this.get("Id");
					var filters = this.BPMSoft.createFilterGroup();
					var idFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Order", orderId);
					var contractIsNull = this.BPMSoft.createColumnIsNullFilter("Contract");
					filters.addItem(idFilter);
					filters.addItem(contractIsNull);
					config.filters = filters;
					this.openLookup(config, function(response) {
						this.linkSelectedRecords(response, id);
					}, this);
				},

				/**
				 * ######### ##### ### ######### ######### # ####### #########.
				 * @private
				 * @param {Object} items ###### #### {columnName: string, selectedRows: []}.
				 * ######## ###### ######### ####### ## ###########.
				 * @param {String} id ############# ########.
				 */
				linkSelectedRecords: function(items, id) {
					this.showBodyMask();
					var selectedRows = items.selectedRows.getKeys();
					if (items.selectedRows.getCount() > 0) {
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "OrderProduct"
						});
						update.setParameterValue("Contract", id, this.BPMSoft.DataValueType.GUID);
						update.filters.addItem(this.BPMSoft.createColumnInFilterWithParameters("Id", selectedRows));
						update.execute(function() {
							this.updateContractAmount(id);
						}, this);
					} else {
						this.openContractPage({
							id: id,
							operation: ConfigurationEnums.CardStateV2.EDIT
						});
					}
				},

				/**
				 * ########## ######## # ####### #########.
				 * @private
				 * @param {String} id ############# ########.
				 */
				connectProducts: function(id) {
					this.showBodyMask();
					var orderId = this.get("Id");
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "OrderProduct"
					});
					update.setParameterValue("Contract", id, this.BPMSoft.DataValueType.GUID);
					update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Order",  orderId));
					update.filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contract"));
					update.execute(function() {
						this.updateContractAmount(id);
					}, this);
				},

				/**
				 * ######### ####### ############# ######### # #########.
				 * @private
				 * @param {Function} callback ####### ######### ######.
				 */
				getIsOrderHasUnlinkedProducts: function(callback) {
					var orderId = this.get("Id");
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OrderProduct"
					});
					select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Order",  orderId));
					select.filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contract"));
					select.execute(function(response) {
						callback.call(this, Boolean(response && response.success && response.collection.getCount()));
					}, this);
				},

				/**
				 * ############ ##### ######### # ######## # ######### ##.
				 * @private
				 * @param {String} id ############# ########.
				 */
				updateContractAmount: function(id) {
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OrderProduct"
					});
					select.addAggregationSchemaColumn("TotalAmount", this.BPMSoft.AggregationType.SUM, "TotalAmountSum");
					select.addAggregationSchemaColumn("PrimaryTotalAmount", this.BPMSoft.AggregationType.SUM,
						"PrimaryTotalAmountSum");
					var orderId =  this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					filterGroup.add("OrderFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Order", orderId));
					filterGroup.add("ContractFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Contract", id));
					select.filters = filterGroup;
					select.getEntityCollection(function(response) {
						if (response.success && response.collection) {
							var items = response.collection.getItems();
							if (items.length > 0) {
								var update = this.Ext.create("BPMSoft.UpdateQuery", {
									rootSchemaName: "Contract"
								});
								update.setParameterValue("Amount", items[0].get("TotalAmountSum"),
									this.BPMSoft.DataValueType.MONEY);
								update.setParameterValue("PrimaryAmount", items[0].get("PrimaryTotalAmountSum"),
									this.BPMSoft.DataValueType.MONEY);
								update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.EQUAL, "Id", id));
								update.execute(function() {
									this.openContractPage({
										id: id,
										operation: ConfigurationEnums.CardStateV2.EDIT
									});
								}, this);
							}
						}
					}, this);
				}
			},
			details: /**SCHEMA_DETAILS*/{
				Contract: {
					schemaName: "ContractDetailV2",
					entitySchemaName: "Contract",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"},
						Currency: {masterColumn: "Currency"},
						CurrencyRate: {masterColumn: "CurrencyRate"}
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "Contract",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					},
					"index": 1
				}
			]/**SCHEMA_DIFF*/
		};
	});
