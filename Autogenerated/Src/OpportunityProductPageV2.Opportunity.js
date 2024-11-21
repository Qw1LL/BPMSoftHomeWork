define("OpportunityProductPageV2", ["MoneyModule"],
		function(MoneyModule) {
			return {
				entitySchemaName: "OpportunityProductInterest",
				attributes: {
					/**
					 * Product
					 */
					"Product": {
						lookupListConfig: {
							columns: ["Price", "Currency", "Currency.Division"]
						},
						dependencies: [
							{
								columns: ["Product"],
								methodName: "calculatePrice"
							}
						]
					},
					/**
					 * Amount
					 */
					"Amount": {
						dependencies: [
							{
								columns: ["Price", "Quantity"],
								methodName: "recalculateAmount"
							}
						]
					}
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				methods: {
					/**
					 * Validates fields of the card.
					 * @override
					 * @return {Boolean}
					 */
					validate: function() {
						var isValid = this.callParent(arguments);
						if (!isValid) {
							return false;
						}
						var quantity = this.get("Quantity");
						if (quantity < 0) {
							this.showInformationDialog(this.get("Resources.Strings.FieldMustBeGreaterOrEqualZeroMessage"));
							return false;
						}
						return true;
					},

					/**
					 * Recalculates products amount in opportunity.
					 * @private
					 */
					recalculateAmount: function() {
						var price = this.get("Price");
						var quantity = this.get("Quantity");
						if (price && quantity) {
							this.set("Amount", price * quantity);
						}
					},

					/**
					 * Recalculates product price.
					 * @private
					 */
					calculatePrice: function() {
						var product = this.get("Product");
						if (this.Ext.isEmpty(product) || this.Ext.isEmpty(product.Currency)) {
							return;
						}
						MoneyModule.onLoadCurrencyRate.call(this, product.Currency.value, null, function(item) {
							var price = (product.Price * item.Division) / (item.Rate);
							this.set("Price", price);
						});
					},

					/**
					 * Returns action list in page.
					 * @override
					 * @return {BPMSoft.BaseViewModelCollection}
					 */
					getActions: function() {
						var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
						return actionMenuItems;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Opportunity",
						"values": {
							"bindTo": "Opportunity",
							"layout": {"column": 0, "row": 0, "colSpan": 11},
							"enabled": false,
							"controlConfig": {
								"enableRightIcon": false
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Product",
						"values": {
							"bindTo": "Product",
							"layout": {"column": 0, "row": 1, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Price",
						"values": {
							"bindTo": "Price",
							"layout": {"column": 0, "row": 2, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Quantity",
						"values": {
							"bindTo": "Quantity",
							"layout": {"column": 0, "row": 3, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Amount",
						"values": {
							"bindTo": "Amount",
							"layout": {"column": 0, "row": 4, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "OfferDate",
						"values": {
							"bindTo": "OfferDate",
							"layout": {"column": 0, "row": 5, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "OfferResult",
						"values": {
							"bindTo": "OfferResult",
							"layout": {"column": 0, "row": 6, "colSpan": 11},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Comment",
						"values": {
							"bindTo": "Comment",
							"layout": {"column": 0, "row": 7, "colSpan": 11}
						}
					},
					{
						"operation": "merge",
						"name": "Tabs",
						"parentName": "CardContentContainer",
						"propertyName": "items",
						"values": {
							"visible": false
						}
					},
					{
						"operation": "insert",
						"name": "OpportunityProductPageGeneralTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"alias": {"name": "GeneralInfoTab"},
						"values": {
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "OpportunityProductPageGeneralTabContainer",
						"propertyName": "items",
						"name": "OpportunityProductPageGeneralBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
