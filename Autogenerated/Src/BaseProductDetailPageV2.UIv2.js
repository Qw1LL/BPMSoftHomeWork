define("BaseProductDetailPageV2", ["BusinessRuleModule", "MoneyModule", "DiscountUtils", "MoneyUtilsMixin"],
	function(BusinessRuleModule, MoneyModule, DiscountUtils) {
		return {
			entitySchemaName: "BaseProductEntry",
			attributes: {
				/**
				 * Product
				 * @type {BPMSoft.DataValueType.LOOKUP}
				 */
				"Product": {
					lookupListConfig: {
						columns: ["Currency", "Currency.Division", "Price", "Unit", "Tax", "Tax.Percent"]
					},
					dependencies: [
						{
							columns: ["Product"],
							methodName: "setProductPriceEnabled"
						}
					]
				},

				/**
				 * Tax
				 * @type {BPMSoft.DataValueType.LOOKUP}
				 */
				"Tax": {
					lookupListConfig: {
						columns: ["Percent"]
					}
				},

				/**
				 * Discount tax
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"DiscountTax": {
					name: "DiscountTax",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["Tax"],
							methodName: "onTaxChange"
						}
					]
				},

				/**
				 * Tax amount
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"TaxAmount": {
					name: "TaxAmount",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["Amount", "DiscountTax"],
							methodName: "setTaxAmount"
						}
					]
				},

				/**
				 * Price
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"Price": {
					name: "Price",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["Product"],
							methodName: "onProductSelect"
						}
					]
				},

				/**
				 * Amount
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"Amount": {
					name: "Amount",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["Price", "Quantity"],
							methodName: "calcAmount"
						}
					]
				},

				/**
				 * Discount percent
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"DiscountPercent": {
					name: "DiscountPercent",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["DiscountAmount"],
							methodName: "calcDiscountPercent"
						}
					]
				},

				/**
				 * Discount amount
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"DiscountAmount": {
					name: "DiscountAmount",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["Amount", "DiscountPercent"],
							methodName: "calcDiscountAmount"
						}
					]
				},

				/**
				 * Total amount
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"TotalAmount": {
					name: "TotalAmount",
					dataValueType: BPMSoft.DataValueType.FLOAT,
					dependencies: [
						{
							columns: ["Amount", "TaxAmount", "DiscountAmount"],
							methodName: "setTotalAmount"
						}
					]
				},

				/**
				 * Name
				 * @type {String}
				 */
				"Name": {
					name: "Name",
					dataValueType: BPMSoft.DataValueType.TEXT,
					dependencies: [
						{
							columns: ["CustomProduct", "Product"],
							methodName: "changeProductName"
						}
					]
				},

				/**
				 * Sign that product price is enabled.
				 * @type {Boolean}
				 */
				"IsProductPriceEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Master entity column name.
				 * @type {BPMSoft.DataValueType.TEXT}
				 */
				"MasterEntityColumnName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT
				}
			},
			mixins: {
				MoneyUtilities: "BPMSoft.MoneyUtilsMixin"
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#constructor.
				 * @overridden
				 */
				init: function() {
					BPMSoft.SysSettings.querySysSettingsItem("PriceWithTaxes", function(value) {
						if (value) {
							this.set("PriceWithTaxes", value);
						}
					}, this);
					this.callParent(arguments);
				},

				/**
				 * MoneyModule getter.
				 * @private
				 * @return {BPMSoft.MoneyModule}
				 */
				getMoneyModule: function() {
					return MoneyModule;
				},

				/**
				 * Changes product name.
				 * @protected
				 */
				changeProductName: function() {
					var product = this.get("Product");
					var customProduct = this.get("CustomProduct");
					var caption = product && product.displayValue ? product.displayValue : customProduct;
					this.set("ShowSaveButton", true);
					this.set("Name", caption);
				},

				/**
				 * @inheritdoc BPMSoft.BaseEntityPage#constructor.
				 * @overridden
				 */
				getDefaultValues: function() {
					var defValues = this.callParent(arguments);
					if (this.Ext.isEmpty(this.get("Quantity"))) {
						defValues.push({
							name: "Quantity",
							value: 1
						});
					}
					if (this.Ext.isEmpty(this.get("DiscountPercent"))) {
						defValues.push({
							name: "DiscountPercent",
							value: 0
						});
					}
					this.set("DefaultValues", this.BPMSoft.deepClone(defValues));
					return defValues;
				},

				/**
				 * Handles tax change.
				 * @protected
				 */
				onTaxChange: function() {
					var tax = this.get("Tax");
					var taxPercent = (!this.Ext.isEmpty(tax)) ? tax.Percent : null;
					this.set("DiscountTax", taxPercent);
				},

				/**
				 * Handles product selection.
				 * @protected
				 * @virtual
				 */
				onProductSelect: function() {
					if (!this.changedValues.IsChanged) {
						return;
					}
					var product = this.get("Product");
					this.set("Tax", null);
					this.set("Unit", null);
					if (this.Ext.isEmpty(product)) {
						this.set("Price", 0);
						return;
					}
					if (!this.Ext.isEmpty(product.Tax)) {
						product.Tax.Percent = product["Tax.Percent"];
						this.set("Tax", product.Tax);
					}
					if (!this.Ext.isEmpty(product.Unit)) {
						this.set("Unit", product.Unit);
					}
					if (product.Currency) {
						var moneyModule = this.getMoneyModule();
						moneyModule.onLoadCurrencyRate.call(this, product.Currency.value, null, function(item) {
							var master = this.get("ProductEntryMasterRecord");
							var price = 0.0;
							if (!master) {
								return;
							}
							if (product.Currency.value !== master.Currency.value) {
								var calculator = this.getMoneyCalculator();
								price = calculator.evaluate({
									divide: [
										{multiply: [product.Price, master.CurrencyRate, item.Division]},
										{multiply: [item.Rate, master["Currency.Division"]]}
									]
								});
							} else {
								price = product.Price;
							}
							this.set("Price", price);
						});
					}
				},

				/**
				 * Calculates amount.
				 * @protected
				 */
				calcAmount: function() {
					var price = this.get("Price");
					var quantity = this.get("Quantity");
					if (!this.Ext.isEmpty(price) && !this.Ext.isEmpty(quantity)) {
						var calculator = this.getMoneyCalculator();
						this.set("Amount", calculator.multiply(price, quantity));
					}
				},

				/**
				 * Calculates discount percent.
				 * @protected
				 */
				calcDiscountPercent: function() {
					var amount = this.get("Amount");
					var discountAmount = this.get("DiscountAmount");
					var discountPercent = DiscountUtils.calcDiscountPercent(amount, discountAmount);
					this.set("DiscountPercent", discountPercent);
				},

				/**
				 * Calculates discount amount.
				 * @protected
				 */
				calcDiscountAmount: function() {
					var amount = this.get("Amount");
					var discountPercent = this.get("DiscountPercent");
					var newDiscountAmount = DiscountUtils.calcDiscountAmount(amount, discountPercent);
					if (this.get("DiscountAmount") !== newDiscountAmount) {
						this.set("DiscountAmount", newDiscountAmount);
					}
					var taxAmount = this.calcTaxAmount();
					if (this.get("TaxAmount") !== taxAmount) {
						this.set("TaxAmount", taxAmount);
					}
				},

				/**
				 * Calculates total amount.
				 * @protected
				 * @returns {number} total amount.
				 */
				calcTotalAmount: function() {
					var amount = this.get("Amount");
					if (this.Ext.isEmpty(amount)) {
						amount = 0;
					}
					var discountAmount = this.get("DiscountAmount");
					if (this.Ext.isEmpty(discountAmount)) {
						discountAmount = 0;
					}
					if (discountAmount > amount) {
						discountAmount = amount;
					}
					var calculator = this.getMoneyCalculator();
					return calculator.subtract(amount, discountAmount);
				},

				/**
				 * Calculates tax amount.
				 * @protected
				 * @returns {number} tax amount.
				 */
				calcTaxAmount: function() {
					var totalAmount = this.calcTotalAmount();
					var discountTax = this.get("DiscountTax");
					if (this.Ext.isEmpty(discountTax)) {
						discountTax = 0;
					}
					if (discountTax > 100) {
						discountTax = 100;
					}
					var taxAmount = 0;
					if (this.get("PriceWithTaxes")) {
						taxAmount = this.getIncludedPercentagePart(totalAmount, discountTax);
					} else {
						taxAmount = this.getPercentagePart(totalAmount, discountTax);
					}
					return taxAmount;
				},

				/**
				 * Calculates tax amount.
				 * @protected
				 */
				setTaxAmount: function() {
					var taxAmount = this.calcTaxAmount();
					if (this.get("TaxAmount") !== taxAmount) {
						this.set("TaxAmount", taxAmount);
					}
				},

				/**
				 * Calculates total amount.
				 * @protected
				 */
				setTotalAmount: function() {
					var totalAmount = this.calcTotalAmount();
					if (!this.get("PriceWithTaxes")) {
						var taxAmount = this.calcTaxAmount();
						var calculator = this.getMoneyCalculator();
						totalAmount = calculator.add(totalAmount, taxAmount);
					}
					if (this.get("TotalAmount") !== totalAmount) {
						this.set("TotalAmount", totalAmount);
					}
				},

				/**
				 * @inheritDoc BPMSoft.configuration.BaseViewModel#validate
				 * @overridden
				 */
				validate: function() {
					var product = this.get("Product");
					var customProduct = this.get("CustomProduct");
					if (this.Ext.isEmpty(product) && this.Ext.isEmpty(customProduct)) {
						this.showInformationDialog(this.get("Resources.Strings.WarningProductCustomProductRequire"));
						return false;
					}
					//TODO: this solution is temporary, may be reviewed in future, if hints are available
					var quantity = this.get("Quantity");
					if (quantity < 0) {
						this.showInformationDialog(this.get("Resources.Strings.FieldMustBeGreaterOrEqualZeroMessage"));
						return false;
					}
					var date = this.get("DeliveryDate");
					if (this.Ext.isEmpty(date)) {
						this.set("DeliveryDate", null);
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.setProductPriceEnabled();
					this.callParent();
				},

				/**
				 * Sets that product price is enabled.
				 */
				setProductPriceEnabled: function() {
					var customProduct = this.get("CustomProduct");
					var isChangeProductPrice = this.BPMSoft.Features.getIsEnabled("ChangeProductPrice");
					if (this.isNotEmpty(customProduct) || isChangeProductPrice) {
						this.set("IsProductPriceEnabled", true);
					}
				},


				/**
				 * @obsolete
				 */
				getColumnData: function(table, column, scope) {
					return this._getColumnData(table, column, scope);
				},

				/**
				 * Returns value from specified object attribute name.
				 * @private
				 * @param {String} attributeName Attribute name.
				 * @param {String} column Object's field name.
				 * @param {Object} [scope] Context.
				 * @return {Object} Object's value.
				 */
				_getColumnData: function(attributeName, column, scope) {
					scope = scope || this;
					const attrPropName = this.Ext.String.format("{0}.{1}", attributeName, column);
					if (scope.get(attributeName) && scope.get(attributeName)[column]) {
						scope.set(attrPropName, scope.get(attributeName)[column]);
					}
					return scope.get(attrPropName);
				},

				/**
				 * Sets product price.
				 * @param {String} priceListPrice Price
				 * @param {Number} division Division.
				 * @param {Number} rate Rate.
				 */
				setPrice: function(priceListPrice, division, rate) {
					const productCurrencyRate = this.get("CurrencyRate");
					const productDivision = this.getColumnData("Currency", "Division") || 1;
					const divisionNew = (division === 0) ? 1 : division;
					const rateNew = (rate === 0) ? 1 : rate;
					const calculator = this.getMoneyCalculator();
					let price = calculator.evaluate({
						divide: [
							{multiply: [priceListPrice, productCurrencyRate, divisionNew]},
							{multiply: [rateNew, productDivision]}
						]
					});
					price = this.roundValue(price, {
						"decimalPlaces": 2
					});
					this.set("Price", price);
				},

				/**
				 * Calculates primary InvoiceProduct values.
				 * @virtual
				 * @protected
				 */
				calculatePrimaryValues: function() {
					const columnName = arguments[arguments.length - 1];
					const moneyModule = this.getMoneyModule();
					moneyModule.RecalcBaseValue.call(this, "CurrencyRate", columnName, "Primary" + columnName,
						this.getCurrencyDivision());
				},

				/**
				 * Sets product price.
				 * @protected
				 */
				setPriceAsync: function() {
					const masterEntityName = this.get("MasterEntityColumnName");
					const masterEntity = this.get(masterEntityName);
					const priceList = this.get("PriceList") || {};
					const productCurrency = this.get("Currency") || masterEntity.Currency || {};
					const productCurrencyId = productCurrency.value;
					const priceListCurrencyId = priceList["Currency.Id"] || productCurrencyId;
					if (priceListCurrencyId === productCurrencyId) {
						this.set("Price", priceList.Price || 0);
						return;
					}
					const product = this.get("Product");
					if (product) {
						const priceListPrice = priceList.Price || product.Price || 0;
						const moneyModule = this.getMoneyModule();
						moneyModule.onLoadCurrencyRate.call(
							this, priceList["Currency.Id"], null,
							function(item) {
								this.setPrice(priceListPrice, item.Division, item.Rate);
							},
							function() {
								this.setPrice(priceListPrice, 1, 1);
							}
						);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "actions"
				},
				{
					"operation": "insert",
					"name": "BaseProductPageGeneralTabContainer",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BaseGeneralInfoGroup",
					"parentName": "BaseProductPageGeneralTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "BaseGeneralInfoBlock",
					"parentName": "BaseGeneralInfoGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Product",
					"parentName": "BaseGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Product",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "CustomProduct",
					"parentName": "BaseGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "CustomProduct",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "Quantity",
					"parentName": "BaseGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Quantity",
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "Unit",
					"parentName": "BaseGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Unit",
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "DeliveryDate",
					"parentName": "BaseGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "DeliveryDate",
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "AmountControlGroup",
					"parentName": "BaseProductPageGeneralTabContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.AmountGroupCaption"
						},
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "AmountBlock",
					"parentName": "AmountControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Price",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Price",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "Amount",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Amount",
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "DiscountPercent",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "DiscountPercent",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "DiscountAmount",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "DiscountAmount",
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "Tax",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Tax",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"name": "TaxAmount",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "TaxAmount",
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "DiscountTax",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "DiscountTax",
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "TotalAmount",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "TotalAmount",
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Product": {
					"BindParameterEnabledProductToCustomProduct": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "CustomProduct"
								},
								"comparisonType": BPMSoft.ComparisonType.IS_NULL
							}
						]
					}
				},
				"CustomProduct": {
					"BindParameterEnabledCustomProductToProduct": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Product"
								},
								"comparisonType": BPMSoft.ComparisonType.IS_NULL
							}
						]
					}
				},
				"Price": {
					"BindParameterEnabledCustomProductToProduct": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "IsProductPriceEnabled"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": true
								}
							}
						]
					}
				}
			}
		};
	});
