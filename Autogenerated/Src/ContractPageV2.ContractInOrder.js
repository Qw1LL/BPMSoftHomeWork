define("ContractPageV2", ["BusinessRuleModule", "ConfigurationConstants", "ConfigurationEnums"],
	function(BusinessRuleModule, ConfigurationConstants, enums) {
		return {
				entitySchemaName: "Contract",
				attributes: {
					"Order": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							columns: ["Currency", "Account"],
							filter: function() {
								var account = this.get("Account");
								if (!this.Ext.isEmpty(account)) {
									var filters = this.BPMSoft.createFilterGroup();
									filters.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
									filters.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
										"Account", account.value));
									filters.addItem(this.BPMSoft.createIsNullFilter(
										this.Ext.create("BPMSoft.ColumnExpression", {columnPath: "Account"})
									));
									return filters;
								}
							}
						}
					},
					"Currency": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							columns: ["Division", "Symbol"],
							filter: function() {
								var orderCurrency = this.get("Order");
								orderCurrency = orderCurrency && orderCurrency.Currency;
								var primaryCurrency = this.get("PrimaryCurrency");
								if (primaryCurrency && orderCurrency && orderCurrency.value !== primaryCurrency.value) {
									var filters = this.BPMSoft.createFilterGroup();
									filters.addItem(this.BPMSoft.createColumnInFilterWithParameters("Id",
											[orderCurrency.value, primaryCurrency.value]));
									return filters;
								}
							}
						},
						dependencies: [
							{
								columns: ["Order"],
								methodName: "orderChanged"
							}
						]
					}
				},
				messages: {
					/**
					 * @message GetPageInfo
					 * ########## ########## # ########.
					 * @param {Object} ########## # ########.
					 */
					"GetPageInfo": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				details: /**SCHEMA_DETAILS*/{
					"Product": {
						"schemaName": "ContractProductDetailV2",
						"entitySchemaName": "OrderProduct",
						"filterMethod": "orderFilter"
					}
				}/**SCHEMA_DETAILS*/,
				methods: {
					/**
					 * @inheritdoc BPMSoft.BasePageV2#init
					 * @protected
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.initPrimaryCurrency();
						this.sandbox.subscribe("GetPageInfo", function() {
							return this;
						}, this, [this.getDetailId("Product")]);
					},

					/**
					 * ############# ####### ######.
					 * @private
					 */
					initPrimaryCurrency: function() {
						this.BPMSoft.SysSettings.querySysSettingsItem("PrimaryCurrency", function(primaryCurrency) {
							this.set("PrimaryCurrency", primaryCurrency);
						}, this);
					},

					/**
					 * ######### ######### #### "#####".
					 */
					orderChanged: function() {
						var order = this.get("Order");
						this.set("OrderChanged", true);
						if (order && order.Currency) {
							this.set("Currency", order.Currency);
						}
					},

					/**
					 * ############# ##########.
					 */
					onSaved: function(response, config) {
						var isOrderChanged = this.get("OrderChanged");
						var isAdd = (this.get("Operation") === enums.CardStateV2.ADD);
						var isSilentSave = config && config.isSilent;
						var messageCaption = Ext.String.format(
								this.get("Resources.Strings.LinkProductCaption"),
								this.get("Number"));
						if ((config !== null) && (config !== undefined) && (config.recalc === true)) {
							this.callParent(arguments);
							this.set("OrderChanged", false);
							return;
						}
						if ((config !== null) && (config !== undefined) && (config.linked === true)) {
							this.calcAmount(function() {
								this.onSaved(response, Ext.apply(config || {}, {recalc: true}));
							}, this);
						} else {
							if (this.get("Order") && (isAdd || isOrderChanged) && !isSilentSave) {
								this.isOrderHasUnlinkedProducts(function(show) {
									if (!show) {
										this.onSaved(response, Ext.apply(config || {}, {linked: true}));
										return;
									}
									BPMSoft.utils.showMessage({
										caption: messageCaption,
										id:"order-contract-modal",
										buttons: [{
											className: "BPMSoft.Button",
											returnCode: "ButtonAll",
											style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
											caption: this.get("Resources.Strings.QuestionAllCaption"),
											classes: {
												textClass: ["button-choice-all"]
											},
											markerValue: this.get("Resources.Strings.QuestionAllCaption")
										}, {
											className: "BPMSoft.Button",
											returnCode: "ButtonChoice",
											style: BPMSoft.controls.ButtonEnums.style.ORANGE,
											classes: {
												textClass: ["button-choice-some"]
											},
											caption: this.get("Resources.Strings.QuestionChoiceCaption"),
											markerValue: this.get("Resources.Strings.QuestionChoiceCaption")
										}, {
											className: "BPMSoft.Button",
											returnCode: "cancel",
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
											caption: this.get("Resources.Strings.QuestionCancelCaption"),
											classes: {
												textClass: ["button-choice-cancel"]
											},
											markerValue: this.get("Resources.Strings.QuestionCancelCaption")
											},],
										defaultButton: 1,
										style: BPMSoft.MessageBoxStyles.ORANGE,
										handler: function(buttonCode) {
											if (buttonCode === "ButtonAll") {
												this.connectProducts(response, config);
											}
											if (buttonCode === "ButtonChoice") {
												this.openProductLookupToLink(response, config);
											}
											if (buttonCode === "cancel") {
												this.onSaved(response, Ext.apply(config || {}, {linked: true}));
											}
										},
										scope: this
									});
								}, this);
							} else {
								this.callParent(arguments);
							}
						}
					},

					/**
					 * ########## ######### ## ########## ######.
					 * @returns {BPMSoft.configuration.QuickSearchModule.getViewModel.methods.createFilterGroup}
					 */
					orderFilter: function() {
						var order =  this.get("Order");
						var id = this.get("Id");
						var orderId = this.BPMSoft.GUID_EMPTY;
						if (order && order.value) {
							orderId = order.value;
						}
						var filterGroup = new this.BPMSoft.createFilterGroup();
						filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
						filterGroup.add("OrderFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Order", orderId));
						filterGroup.add("ContractFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Contract", id));
						return filterGroup;
					},

					/**
					 * ######### ########## ######### ###### ### ###### #######,
					 * ####### ########## ####### # ####### #########.
					 * @private
					 */
					openProductLookupToLink: function(responseOnSaved, configOnSaved) {
						var config = {
							entitySchemaName: "OrderProduct",
							multiSelect: true,
							columns: ["Name"]
						};
						var orderId = this.get("Order").value;
						var filters = this.BPMSoft.createFilterGroup();
						var idFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"Order", orderId);
						var contractIsNull = this.BPMSoft.createColumnIsNullFilter("Contract");
						filters.addItem(idFilter);
						filters.addItem(contractIsNull);
						config.filters = filters;
						this.openLookup(config, function(response) {
							this.linkSelectedRecords(responseOnSaved, Ext.apply(response, configOnSaved));
						}, this);
					},

					/**
					 * ######### ##### ### ######### ######### # ####### #########.
					 * @param {Object} response ####### ## ###### onSaved
					 * @param {Object} args ###### #### {columnName: string, selectedRows: []}.
					 * ######## ###### ######### ####### ## ###########.
					 * @private
					 */
					linkSelectedRecords: function(response, args) {
						var selectedRows = args.selectedRows.getItems();
						var contractId = this.get(this.primaryColumnName) || this.get("MasterRecordId");
						var totalCount = selectedRows.length;
						var callsCount = 0;
						this.BPMSoft.each(selectedRows, function(item) {
							var update = this.Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: "OrderProduct"
							});
							callsCount++;
							update.setParameterValue("Contract", contractId, this.BPMSoft.DataValueType.GUID);
							update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id",  item.value));
							update.execute(function() {
								if (callsCount === totalCount) {
									this.onSaved(response, Ext.apply(args, {linked: true}));
								}
							}, this);
						}, this);
					},

					/**
					 * ########## ######## # ####### #########.
					 */
					connectProducts: function(response, config) {
						var contractId = this.get(this.primaryColumnName) || this.get("MasterRecordId");
						var orderId = this.get("Order");
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "OrderProduct"
						});
						update.setParameterValue("Contract", contractId, this.BPMSoft.DataValueType.GUID);
						update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Order",  orderId.value));
						update.filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contract"));
						update.execute(function() {
							this.onSaved(response, Ext.apply(config || {}, {linked: true}));
						}, this);
					},

					/**
					 * ######### ####### ############# ######### # #########.
					 */
					isOrderHasUnlinkedProducts: function(callback) {
						var orderId = this.get("Order");
						var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "OrderProduct"
						});
						select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Order",  orderId.value));
						select.filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contract"));
						select.execute(function(response) {
							if (response && response.success) {
								if (response.collection.getCount() > 0) {
									callback.call(this, true);
								} else {
									callback.call(this, false);
								}
							}
						}, this);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "Order",
						"values": {
							"bindTo": "Order",
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.OrderTip"}
							},
							enabled: true
						},
						"parentName": "ContractConnectionsBlock",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ContractPassportTab",
						"values": {
							"items": [],
							"caption": {
								"bindTo": "Resources.Strings.ContractPassportTab"
							}
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "Product",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ContractPassportTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "merge",
						"name": "HistoryTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.HistoryTab"
							}
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 2
					},
					{
						"operation": "merge",
						"name": "ContractVisaTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {"bindTo": "Resources.Strings.ContractVisaTabCaption"}
						},
						"index": 3
					},
					{
						"operation": "merge",
						"name": "NotesAndFilesTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.NotesAndFilesTab"
							}
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 4
					}
				]/**SCHEMA_DIFF*/,
				rules: {
					"CurrencyRate": {
						"EnabledCurrencyRateByCurrency": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.ENABLED,
							"conditions": [
								{
									"leftExpression": {
										"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										"attribute": "Currency"
									},
									"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
									"rightExpression": {
										"type": BusinessRuleModule.enums.ValueType.SYSSETTING,
										"value": "PrimaryCurrency"
									}
								}
							]
						}
					},
					"Account": {
						"FiltrationAccountByOrder": {
							"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
							"autocomplete": false,
							"autoClean": false,
							"baseAttributePatch": "Id",
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "Order",
							"attributePath": "Account"
						}
					}
				}
			};
	});
