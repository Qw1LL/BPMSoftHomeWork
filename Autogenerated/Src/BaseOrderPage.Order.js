define("BaseOrderPage", ["ProductSalesUtils", "OrderConfigurationConstants", "BusinessRuleModule", "MoneyModule", 
		"ProductEntryPageUtils", "MultiCurrencyEdit", "MultiCurrencyEditUtilities", "EntityProductCountMixin"],
	function(ProductSalesUtils, OrderConfigurationConstants, BusinessRuleModule, MoneyModule) {
		return {
			entitySchemaName: "Order",
			messages: {
				/**
				 * @message GetOrderProductSummary
				 * ########### ########## ### ###### ###### "########".
				 */
				"GetOrderProductSummary": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message UpdateOrderProductSummary
				 * ########## ###### ###### "########".
				 */
				"UpdateOrderProductSummary": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetIsDeliveryAddressDetailVisible
				 * ########### ######### ###### "##### ########".
				 */
				"GetIsDeliveryAddressDetailVisible": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetActiveAddress
				 * ############ ### ######### ######### ###### # #######.
				 */
				"SetActiveAddress": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateOrderAddress
				 * ############ ### ########## ######### ###### ### ###### ######## # ######.
				 */
				"UpdateOrderAddress": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message OnCurrencyChanged
				 * Message on currency changed.
				 */
				"OnCurrencyChanged": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				"Status": {
					"lookupListConfig": {
						"orders": [{columnPath: "Position"}]
					},
					"dependencies": [
						{
							"columns": ["Status"],
							"methodName": "onOrderStatusChanged"
						}
					]
				},

				"PaymentStatus": {
					"lookupListConfig": {
						orders: [{columnPath: "Position"}]
					}
				},

				"DeliveryStatus": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					"lookupListConfig": {
						orders: [{columnPath: "Position"}]
					}
				},

				"DeliveryType": {
					dependencies: [
						{
							columns: ["DeliveryType"],
							methodName: "updateDeliveryAddresses"
						}
					]
				},

				"SourceOrder": {
					"lookupListConfig": {
						orders: [{columnPath: "Name"}]
					}
				},

				/**
				 * ######
				 */
				"Currency": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					lookupListConfig: {
						columns: ["Division", "ShortName", "Symbol"]
					}
				},

				"CurrencyRate": {
					dataValueType: BPMSoft.DataValueType.FLOAT,
					onChange: "onCurrencyRateChange",
					dependencies: [
						{
							columns: ["Currency"],
							methodName: "onCurrencyChanged"
						}
					]
				},

				/**
				 * Currency rate list.
				 */
				"CurrencyRateList": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: this.Ext.create("BPMSoft.Collection")
				},

				/**
				 * Currency button menu list.
				 */
				"CurrencyButtonMenuList": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: this.Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Payment amount in primary currency.
				 */
				"PrimaryPaymentAmount": {
					dataValueType: BPMSoft.DataValueType.FLOAT
				},

				"ActualDate": {
					dataValueType: BPMSoft.DataValueType.DATE_TIME,
					dependencies: [
						{
							columns: ["PaymentStatus", "DeliveryStatus", "Date"],
							methodName: "setClosedOrder"
						}
					]
				},

				/**
				 * Execution date.
				 */
				"Date": {
					dataValueType: BPMSoft.DataValueType.DATE_TIME
				},

				"ClientUpdateDeliveryAddresses": {
					dependencies: [
						{
							columns: ["Account", "Contact"],
							methodName: "updateDeliveryAddresses"
						}
					]
				},

				"AmountAndCurrency": {
					dependencies: [
						{
							columns: ["Amount", "Currency"],
							methodName: "updateOrderProductSummary"
						}
					]
				},

				"Client": {
					"caption": {"bindTo": "Resources.Strings.Client"},
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"multiLookupColumns": ["Contact", "Account"],
					"isRequired": true
				},

				/**
				 * Flag of payment amount is larger than
				 * planned amount.
				 */
				"IsPaymentAmountLargerThanAmount": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false,
					dependencies: [
						{
							columns: ["PaymentAmount", "Amount"],
							methodName: "setIsPaymentAmountLargerThanAmount"
						}
					]
				},
				/**
				 * Account of the order.
				 */
				"Account": {
					"lookupListConfig": {
						"columns": ["PriceList"]
					},
					"dependencies": [
						{
							"columns": ["Account"],
							"methodName": "onOrderAccountChanged"
						}
					]
				},
				/**
				 * Stores predefined price list.
				 */
				"PredefinedPriceList": {
					"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			properties: {
				moneyModule: null
			},
			details: /**SCHEMA_DETAILS*/{
				Files: {
					schemaName: "FileDetailV2",
					entitySchemaName: "OrderFile",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					}
				},
				ProductInProductsTab: {
					schemaName: "OrderProductDetailV2",
					entitySchemaName: "OrderProduct",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					},
					subscriber: {methodName: "refreshAmount"},
					defaultValues: {
						Currency: {masterColumn: "Currency"},
						CurrencyRate: {masterColumn: "CurrencyRate"}
					}
				},
				ProductInResultsTab: {
					schemaName: "OrderProductDetailV2",
					entitySchemaName: "OrderProduct",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					},
					subscriber: {methodName: "refreshAmount"},
					defaultValues: {
						Currency: {masterColumn: "Currency"},
						CurrencyRate: {masterColumn: "CurrencyRate"}
					}
				},
				DeliveryAddressDetail: {
					schemaName: "AddressSelectionDetailV2",
					defaultValues: {
						"ContactId": {masterColumn: "Contact"},
						"AccountId": {masterColumn: "Account"},
						"DeliveryAddress": {masterColumn: "DeliveryAddress"}
					}
				},
				AddressSelectionDetailResultsTab: {
					schemaName: "AddressSelectionResultDetailV2",
					defaultValues: {
						"ContactId": {masterColumn: "Contact"},
						"AccountId": {masterColumn: "Account"},
						"DeliveryAddress": {masterColumn: "DeliveryAddress"}
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {
				ProductEntryPageUtils: "BPMSoft.ProductEntryPageUtils",

				/**
				 * ###### ########## ################# # ######## ##############.
				 */
				MultiCurrencyEditUtilities: "BPMSoft.MultiCurrencyEditUtilities",

				/**
				 * Mixin for products count by entity.
				 */
				EntityProductCountMixin: "BPMSoft.EntityProductCountMixin"
			},
			methods: {
				init: function() {
					this.callParent(arguments);
					this.moneyModule = MoneyModule;
				},

				/**
				 * ############ ######## #### ## ##.
				 */
				refreshAmount: function() {
					this.updateAmount(function() {
						BPMSoft.chain(
							this.updateOrderProductSummary,
							function(next) {
								this.updatePageHeaderCaption();
							},
							this
						)
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#activeTabChange
				 * @overridden
				 */
				activeTabChange: function(activeTab) {
					this.callParent(arguments);
					var tabName = activeTab.get("Name");
					if (tabName === "OrderProductTab") {
						this.updateDetail({detail: "ProductInProductsTab"});
					} else if (tabName === "OrderResultsTab") {
						this.updateDetail({detail: "ProductInResultsTab"});
					}
				},

				/**
				 * # ########### ## #### ######## ##########/######## ###### ###### ########.
				 * @private
				 */
				getDeliveryAddressVisible: function() {
					var deliveryType = this.get("DeliveryType");
					return deliveryType &&
						(deliveryType.value === OrderConfigurationConstants.Order.DeliveryType.Courier);
				},

				/**
				 * ############# ############# ########### #######.
				 * @protected
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1055);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.setIncrementCode();
					this.callParent(arguments);
					this.mixins.MultiCurrencyEditUtilities.init.call(this);
					this.initializePredefinedPriceList();
				},

				/**
				 * Account changed action.
				 * @protected
				 * @virtual
				 */
				onOrderAccountChanged: function() {
					this.initializePredefinedPriceList();
				},

				/**
				 * Sets predefined price list.
				 * @protected
				 * @virtual
				 */
				initializePredefinedPriceList: function() {
					if (this.isPredefinedPriceListsEnabled()) {
						this.$PredefinedPriceList = this.$Account && this.$Account.PriceList;
						if (this.isEmpty(this.$PredefinedPriceList)) {
							const config = this.getPriceListServiceConfig();
							this.callService(config, this.onPredefinedPriceListInitialized, this);
						}
					}
				},

				/**
				 * Handles loaded predefined price list.
				 * @protected
				 * @virtual
				 * @param {Object} response Service response.
				 */
				onPredefinedPriceListInitialized: function(response) {
					const loadedPriceListId = response && response.GetPriceListResult;
					if (this.isNotEmpty(loadedPriceListId) && loadedPriceListId !== this.BPMSoft.GUID_EMPTY) {
						const esq = this.getPriceListEsq();
						esq.getEntity(loadedPriceListId, function(result) {
							const entity = result.entity;
							if (!entity) {
								return;
							}
							this.$PredefinedPriceList = {
								value: entity.get("Id"),
								displayValue: entity.get("Name")
							};
						}, this);
					}
				},

				/**
				 * Returns identifier of  selected order account or account of current user.
				 * @protected
				 * @virtual
				 * @returns {Guid} Account identifier.
				 */
				getOrderAccountId: function() {
					return this.$Account && this.$Account.value
						|| this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT.value;
				},

				/**
				 * Returns config to price list service.
				 * @protected
				 * @virtual
				 * @returns {Object} Service config.
				 */
				getPriceListServiceConfig: function() {
					return {
						serviceName: "PriceListService",
						methodName: "GetPriceList",
						data: {
							accountId: this.getOrderAccountId()
						}
					};
				},

				/**
				 * Indicates that predefined product price lists enabled.
				 * @protected
				 * @virtual
				 * @returns {Boolean} Is predefined product price lists enabled.
				 */
				isPredefinedPriceListsEnabled: function() {
					return this.getIsFeatureEnabled("UsePredefinedProductPriceList");
				},

				/**
				 * Returns query to price lists.
				 * @protected
				 * @virtual
				 * @returns {BPMSoft.EntitySchemaQuery} Query to price lists.
				 */
				getPriceListEsq: function() {
					const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Pricelist"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getIncrementColumn
				 * @overridden
				 */
				getIncrementColumn: function() {
					return "Number";
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#asyncValidate
				 * @overridden
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						this.BPMSoft.chain(
							function(next) {
								this.validateAccountOrContactFilling(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							this.validatePaymentStatus,
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				},

				/**
				 * ######### ##########
				 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("ActualDate", this.validateDate);
					this.addColumnValidator("DueDate", this.validateDate);
					this.addColumnValidator("Date", this.validateDate);
				},

				/**
				 * ####### ######### ####### "####", "#### ##########", "######## #### ##########".
				 * #### ########## # ######## #### ## ##### #### ###### #### ######
				 * @return {{fullInvalidMessage: string, invalidMessage: string}}
				 */
				validateDate: function() {
					var actualDate = BPMSoft.deepClone(this.get("ActualDate"));
					var dueDate = BPMSoft.deepClone(this.get("DueDate"));
					var date = BPMSoft.deepClone(this.get("Date"));
					var invalidMessage = "";
					if (dueDate && date && dueDate.setHours(0, 0, 0, 0) < date.setHours(0, 0, 0, 0)) {
						invalidMessage = this.get("Resources.Strings.DateLessDueDate");
					}
					if (actualDate && date && actualDate.setHours(0, 0, 0, 0) < date.setHours(0, 0, 0, 0)) {
						invalidMessage = this.get("Resources.Strings.DateLessActualDate");
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * ####### ######### ####### "##### ######".
				 * ##### ###### ###### ## ##### #### ###### ##### ######.
				 * @return {{fullInvalidMessage: string, invalidMessage: string}}
				 */
				validatePaymentAmount: function() {
					var paymentAmount = this.get("PaymentAmount");
					var amount = this.get("Amount");
					var invalidMessage = "";
					if (paymentAmount < 0) {
						invalidMessage = this.get("Resources.Strings.ValidatePaymentAmountNegative");
					} else if ((!amount && (paymentAmount > 0)) || (paymentAmount > amount)) {
						invalidMessage = this.get("Resources.Strings.ValidatePaymentAmount");
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * ######### ############ ##### "#######" ### "##########" ##########
				 * @param {Function} callback ####### ######### ######
				 * @param {Object} scope ########
				 */
				validateAccountOrContactFilling: function(callback, scope) {
					var account = this.get("Account");
					var contact = this.get("Contact");
					var result = {
						success: true
					};
					if (this.Ext.isEmpty(account) && this.Ext.isEmpty(contact)) {
						result.message = this.get("Resources.Strings.RequiredFieldsMessage");
						result.success = false;
					}
					callback.call(scope || this, result);
				},

				/**
				 * Handler for currency change. Updates currency rate value.
				 * @protected
				 */
				onCurrencyChanged: function() {
					this.set("ShowSaveButton", true);
					this.set("ShowDiscardButton", true);
					this.set("IsChanged", true, {silent: true});
					this.moneyModule.LoadCurrencyRate.call(this, "Currency", "CurrencyRate", this.get("StartDate"),
						this.recalculateAmountValues);
					this.sandbox.publish("OnCurrencyChanged");
				},

				/**
				 * Handler for currency rate change.
				 * @protected
				 * @virtual
				 */
				onCurrencyRateChange: function() {
					if (this.get("IsEntityInitialized")) {
						this.recalculateAmountValues();
					}
				},

				/**
				 * Updates amount and payment amount values using new currency rate value.
				 * @protected
				 */
				recalculateAmountValues: function() {
					var division = this.getCurrencyDivision();
					this.moneyModule.RecalcCurrencyValue.call(this, "CurrencyRate", "Amount", "PrimaryAmount", division);
					this.moneyModule.RecalcCurrencyValue.call(this, "CurrencyRate", "PaymentAmount",
						"PrimaryPaymentAmount", division);
				},

				/**
				 * Returns the division ratio.
				 * @protected
				 */
				getCurrencyDivision: function() {
					var currency = this.get("Currency");
					return currency && currency.Division;
				},

				/**
				 * Sets the order is close and checks the dates of the logic.
				 * @protected
				 */
				setClosedOrder: function() {
					if (!this.get("IsEntityInitialized")) {
						return;
					}
					var paymentStatus = this.get("PaymentStatus");
					var deliveryStatus = this.get("DeliveryStatus");
					if (paymentStatus && deliveryStatus &&
						(paymentStatus.value === OrderConfigurationConstants.Order.PaymentStatus.Paid) &&
						(deliveryStatus.value === OrderConfigurationConstants.Order.DeliveryStatus.Delivery)) {
						this.loadLookupDisplayValue("Status", OrderConfigurationConstants.Order.OrderStatus.Closed);
					}
				},

				/**
				 * Handles order status change.
				 * @protected
				 */
				onOrderStatusChanged: function() {
					var status = this.get("Status");
					if (status && (status.value === OrderConfigurationConstants.Order.OrderStatus.Closed)) {
						this.setActualDate();
					}
				},

				/**
				 * Sets actual date.
				 * @protected
				 */
				setActualDate: function() {
					var actualDate = this.get("ActualDate");
					var currentDateTime = this.getSysDefaultValue(BPMSoft.SystemValueType.CURRENT_DATE_TIME);
					if (this.Ext.isEmpty(actualDate)) {
						this.set("ActualDate", currentDateTime);
					}
				},

				/**
				 * Validates payment status and change if valid.
				 * @protected
				 * @param {Function} callback The callback function.
				 * @param {Object} scope Environment object callback function.
				 */
				validatePaymentStatus: function(callback, scope) {
					if (this.validate()) {
						var parameters = {
							columnNames: ["PaymentStatus"],
							callback: this.handleColumnRightsAvailability.bind(this, callback, scope)
						};
						this.checkColumnsEditRight.call(this, parameters);
					} else {
						callback.call(scope || this);
					}
				},

				/**
				 * Handles column rights availability.
				 * @private
				 * @param {Function} callback The callback function.
				 * @param {Object} scope Environment object callback function.
				 * @param {Object} columnRights Rights of column.
				 */
				handleColumnRightsAvailability: function(callback, scope, columnRights) {
					if (columnRights.PaymentStatus) {
						this.changePaymentStatus(callback, scope || this);
					} else {
						callback.call(scope || this);
					}
				},

				/**
				 * Changes payment status.
				 * @protected
				 * @param {Function} callback The callback function.
				 * @param {Object} scope Environment object callback function.
				 */
				changePaymentStatus: function(callback, scope) {
					var amount = this.get("Amount");
					var paymentAmount = this.get("PaymentAmount");
					if (amount && (amount > 0) && (amount === paymentAmount)) {
						this.loadLookupDisplayValue("PaymentStatus",
							OrderConfigurationConstants.Order.PaymentStatus.Paid, callback, scope);
					} else if (paymentAmount > 0) {
						this.loadLookupDisplayValue("PaymentStatus",
							OrderConfigurationConstants.Order.PaymentStatus.PartiallyPaid, callback, scope);
					} else {
						callback.call(scope || this);
					}
				},

				/**
				 * Set flag of payment amount is larger than amount.
				 * @protected
				 */
				setIsPaymentAmountLargerThanAmount: function() {
					var paymentAmount = this.get("PaymentAmount");
					var amount = this.get("Amount");
					var isLarger =
						this.isNotEmpty(paymentAmount) &&
						this.isNotEmpty(amount) &&
						(paymentAmount > amount);
					this.set("IsPaymentAmountLargerThanAmount", isLarger);
				},

				/**
				 * Postprocessing record is saved.
				 * @protected
				 * @virtual
				 */
				onSaved: function() {
					const isNewMode = this.isNewMode();
					this.callParent(arguments);
					const config = arguments[arguments.length - 1];
					if (config && config.isSilent || isNewMode) {
						return;
					}
					this.updateAmountAfterSave("ProductInProductsTab",
						function() {
							this.updateDetail({detail: "ProductInResultsTab"});
							this.updateOrderProductSummary();
						},
						this
					);
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#loadEntity
				 * @overriden
				 */
				loadEntity: function(primaryColumnValue, callback, scope) {
					scope = scope || this;
					this.callParent([primaryColumnValue, function() {
						this.setIsPaymentAmountLargerThanAmount();
						this.setProductCount(primaryColumnValue, callback, scope);
					}, scope]);
				},

				/**
				 * @inheritdoc BPMSoft.EntityProductCountMixin#getProductCountInEntityColumnName
				 * @overriden
				 */
				getProductCountInEntityColumnName: function() {
					return "ProductCount";
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#setColumnValues
				 * @overridden
				 */
				setColumnValues: function(entity) {
					this.callParent(arguments);
					this.updateProductsCount(entity);
				},

				/**
				 * @inheritdoc BPMSoft.ProductEntryPageUtils#modifyAmountESQ
				 * @overridden
				 */
				modifyAmountESQ: function(esq) {
					this.mixins.ProductEntryPageUtils.modifyAmountESQ.apply(this, arguments);
					this.addProductsCountColumn(esq);
				},

				/**
				 * @inheritdoc BPMSoft.ProductEntryPageUtils#updateAmountColumnValues
				 * @overridden
				 */
				updateAmountColumnValues: function(entity) {
					this.mixins.ProductEntryPageUtils.updateAmountColumnValues.apply(this, arguments);
					this.updateProductsCount(entity);
				},

				/**
				 * ######### ####### # ########## ######### ###### # ######.
				 * @param {BPMSoft.EntitySchemaQuery} esq ###### # ####### ######.
				 */
				addProductsCountColumn: function(esq) {
					esq.addAggregationSchemaColumn("[OrderProduct:Order].Id",
						this.BPMSoft.AggregationType.COUNT, "ProductCount");
				},

				/**
				 * ######### ########## ######### # ######.
				 * @param {BPMSoft.BaseModel} entity ##### # ########## ###########.
				 */
				updateProductsCount: function(entity) {
					var countColumn = "ProductCount";
					this.setColumnValue(countColumn, entity.get(countColumn), {preventValidation: true});
				},

				/**
				 * ######### ############ ### ###### ## ###### "########".
				 * @return {Object} ############ ### ########## ###### ######.
				 */
				getProductSummaryConfig: function() {
					var currency = this.get("Currency") || {};
					return {
						count: this.get("ProductCount"),
						currency: currency.Symbol,
						amount: this.get("Amount")
					};
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("GetOrderProductSummary", this.getProductSummaryConfig, this,
						[this.getDetailId("ProductInProductsTab"), this.getDetailId("ProductInResultsTab")]);
					this.sandbox.subscribe("GetIsDeliveryAddressDetailVisible", this.getDeliveryAddressVisible, this,
						[this.getDetailId("DeliveryAddressDetail"),
							this.getDetailId("AddressSelectionDetailResultsTab")]);
					this.sandbox.subscribe("UpdateOrderAddress", this.onUpdateAddress, this,
						[this.getDetailId("DeliveryAddressDetail"),
							this.getDetailId("AddressSelectionDetailResultsTab")]);
				},

				/**
				 * Updates summaries on product detail.
				 */
				updateOrderProductSummary: function(callback, scope) {
					this.sandbox.publish("UpdateOrderProductSummary", null,
						[this.getDetailId("ProductInProductsTab"), this.getDetailId("ProductInResultsTab")]);
					if (callback) {
						callback.call(scope || this);
					}
				},

				/**
				 * Updates address details.
				 */
				updateDeliveryAddresses: function() {
					this.updateDetail({detail: "DeliveryAddressDetail"});
					this.updateDetail({detail: "AddressSelectionDetailResultsTab"});
				},

				/**
				 * ############# ##### ######## ######.
				 * @private
				 * @param {Object} config ########## ### ########## ###### ########. ######## ######### #########:
				 * @param {String} config.senderId ############# ###### ####### ######## #########.
				 * @param {String} config.deliveryAddress ##### ########.
				 */
				onUpdateAddress: function(config) {
					var detailIds = [
						this.getDetailId("DeliveryAddressDetail"),
						this.getDetailId("AddressSelectionDetailResultsTab")
					];
					var position = detailIds.indexOf(config.senderId);
					detailIds.splice(position, 1);
					this.set("DeliveryAddress", config.deliveryAddress);
					this.sandbox.publish("SetActiveAddress", config.deliveryAddress, detailIds);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#openCardInChain
				 * @overridden
				 */
				openCardInChain: function(config) {
					if (config && !config.hasOwnProperty("OpenProductSelectionModule")) {
						return this.callParent(arguments);
					}
					return ProductSalesUtils.openProductSelectionModuleInChain(config, this.sandbox);
				},

				/**
				 * ######## ###### ######## #######.
				 * @overridden
				 * @return {[String]} ###### ######## #######.
				 */
				getDefQuickAddColumnNames: function() {
					var columns = this.callParent(arguments);
					columns.push("Account");
					return columns;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "TabsContainer",
					"values": {
						"wrapClass": ["order-tabs-container"]
					}
				},
				{
					"operation": "insert",
					"name": "OrderProductTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": {"bindTo": "Resources.Strings.OrderProduct"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OrderDeliveryTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2,
					"values": {
						"caption": {"bindTo": "Resources.Strings.OrderDelivery"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OrderResultsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 3,
					"values": {
						"caption": {"bindTo": "Resources.Strings.OrderResults"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderResultsTab",
					"propertyName": "items",
					"name": "ProductInResultsTab",
					"index": 0,
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "OrderResultsTab",
					"name": "OrderResultsDeliveryAndPaymentControlBlock",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.DeliveryAndPaymentGroupCaption"},
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderResultsDeliveryAndPaymentControlBlock",
					"propertyName": "items",
					"name": "OrderPageDeliveryAndPaymentBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageDeliveryAndPaymentBlock",
					"propertyName": "items",
					"name": "DeliveryTypeResult",
					"values": {
						"bindTo": "DeliveryType",
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageDeliveryAndPaymentBlock",
					"propertyName": "items",
					"name": "PaymentTypeResult",
					"values": {
						"bindTo": "PaymentType",
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderResultsTab",
					"propertyName": "items",
					"name": "AddressSelectionDetailResultsTab",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "getDeliveryAddressVisible"}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderResultsTab",
					"name": "OrderReceiverInformationResultsControlBlock",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.OrderReceiverInformationGroupCaption"},
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationResultsControlBlock",
					"propertyName": "items",
					"name": "OrderReceiverInformationResultsBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationResultsBlock",
					"propertyName": "items",
					"name": "ContactNumberResultsBlock",
					"values": {
						"bindTo": "ContactNumber",
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationResultsBlock",
					"propertyName": "items",
					"name": "ReceiverNameResultsBlock",
					"values": {
						"bindTo": "ReceiverName",
						"layout": {"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationResultsBlock",
					"propertyName": "items",
					"name": "CommentResultsBlock",
					"values": {
						"bindTo": "Comment",
						"layout": {"column": 0, "row": 2, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderGeneralInformationTab",
					"propertyName": "items",
					"name": "OrderPageGeneralInformationBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"collapseEmptyRow": true
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "Number",
					"values": {
						"bindTo": "Number",
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "Date",
					"values": {
						"bindTo": "Date",
						"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1},
						"dataValueType": BPMSoft.DataValueType.DATE
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "SourceOrder",
					"values": {
						"bindTo": "SourceOrder",
						"layout": {"column": 13, "row": 1, "colSpan": 11, "rowSpan": 1},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Amount",
					"values": {
						"bindTo": "Amount",
						"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1},
						"primaryAmount": "PrimaryAmount",
						"currency": "Currency",
						"rate": "CurrencyRate",
						"primaryAmountEnabled": false,
						"enabled": false,
						"generator": "MultiCurrencyEditViewGenerator.generate",
						"tip": {
							"content": {"bindTo": "Resources.Strings.AmountTip"}
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "PaymentAmount",
					"values": {
						"bindTo": "PaymentAmount",
						"layout": {"column": 13, "row": 1, "colSpan": 11, "rowSpan": 1},
						"primaryAmount": "PrimaryPaymentAmount",
						"currency": "Currency",
						"rate": "CurrencyRate",
						"primaryAmountEnabled": false,
						"enabled": false,
						"tip": {
							"content": {"bindTo": "Resources.Strings.PaymentAmountTip"}
						},
						"generator": "MultiCurrencyEditViewGenerator.generate"
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "PaymentAmountInfoButton",
					"values": {
						"layout": { "column": 23, "row": 1, "colSpan": 0, "rowSpan": 1},
						"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.ValidatePaymentAmount"
						},
						"controlConfig": {
							"visible": {"bindTo": "IsPaymentAmountLargerThanAmount"}
						},
						"style": BPMSoft.controls.ButtonEnums.style.RED
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "DueDate",
					"values": {
						"bindTo": "DueDate",
						"layout": {"column": 0, "row": 2, "colSpan": 11, "rowSpan": 1},
						"dataValueType": BPMSoft.DataValueType.DATE
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "ActualDate",
					"values": {
						"bindTo": "ActualDate",
						"layout": {"column": 13, "row": 2, "colSpan": 11, "rowSpan": 1},
						"dataValueType": BPMSoft.DataValueType.DATE
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "PaymentStatus",
					"values": {
						"bindTo": "PaymentStatus",
						"layout": {"column": 0, "row": 3, "colSpan": 11, "rowSpan": 1},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "DeliveryStatus",
					"values": {
						"bindTo": "DeliveryStatus",
						"layout": {"column": 13, "row": 3, "colSpan": 11, "rowSpan": 1},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"bindTo": "Owner",
						"layout": {"column": 0, "row": 4, "colSpan": 24, "rowSpan": 1},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "OrderHistoryTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4,
					"values": {
						"caption": {"bindTo": "Resources.Strings.OrderHistoryTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OrderGeneralInformationTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 5,
					"values": {
						"caption": {"bindTo": "Resources.Strings.OrderGeneralInformationTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FileNotesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 7,
					"values": {
						"caption": {"bindTo": "Resources.Strings.FileNotes"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"name": "OrderPageHistoryTabContainer",
					"alias": {
						"name": "OrderHistoryTab"
					},
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "Document",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Client",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ClientTip"}
						},
						"wrapClass": ["control-with-user-icon"],
						"controlConfig": {
							"enableLeftIcon": true,
							"leftIconConfig": {"bindTo": "getMultiLookupIconConfig"}
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Status",
					"values": {
						"bindTo": "Status",
						"layout": {"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderProductTab",
					"propertyName": "items",
					"name": "ProductInProductsTab",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "FileNotesTab",
					"propertyName": "items",
					"name": "Files",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"parentName": "FileNotesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"contentType": BPMSoft.ContentType.RICH_TEXT,
						"layout": {"column": 0, "row": 0, "colSpan": 24, "rowSpan": 1},
						"labelConfig": {"visible": false},
						"controlConfig": {
							"imageLoaded": {"bindTo": "insertImagesToNotes"},
							"images": {"bindTo": "NotesImagesCollection"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderDeliveryTab",
					"name": "OrderDeliveryInformationControlBlock",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderDeliveryInformationControlBlock",
					"propertyName": "items",
					"name": "OrderDeliveryInformationBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderDeliveryInformationBlock",
					"propertyName": "items",
					"name": "DeliveryType",
					"values": {
						"bindTo": "DeliveryType",
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderDeliveryInformationBlock",
					"propertyName": "items",
					"name": "PaymentType",
					"values": {
						"bindTo": "PaymentType",
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderDeliveryTab",
					"propertyName": "items",
					"name": "DeliveryAddressDetail",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "getDeliveryAddressVisible"}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderDeliveryTab",
					"name": "OrderReceiverInformationControlBlock",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.OrderReceiverInformationGroupCaption"},
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationControlBlock",
					"propertyName": "items",
					"name": "OrderReceiverInformationBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationBlock",
					"propertyName": "items",
					"name": "ContactNumber",
					"values": {
						"bindTo": "ContactNumber",
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationBlock",
					"propertyName": "items",
					"name": "ReceiverName",
					"values": {
						"bindTo": "ReceiverName",
						"layout": {"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderReceiverInformationBlock",
					"propertyName": "items",
					"name": "Comment",
					"values": {
						"bindTo": "Comment",
						"layout": {"column": 0, "row": 2, "colSpan": 11, "rowSpan": 1}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
