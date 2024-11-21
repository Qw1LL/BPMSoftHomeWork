define("PortalOrderPage", ["ConfigurationEnums"],
	function(ConfigurationEnums) {
		return {
			entitySchemaName: "Order",
			methods: {

				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function () {
					this.callParent(arguments);
					this.setOrderCustomer();
				},

				/**
				 * Sets customer of the order.
				 * @protected
				 * @virtual
				 */
				setOrderCustomer: function () {
					if (this.isAddMode() && !this.$IsProcessMode) {
						const esq = this.getContactAccountQuery();
						esq.getEntityCollection(function(response) {
							if (response.success && response.collection.getCount() > 0) {
								const account = response.collection.first();
								this.$Client = {
									value: account.$Id,
									displayValue: account.$Name,
									column: "Account"
								};
							}
						}, this);
					}
				},

				/**
				 * Returns query to account.
				 * @protected
				 * @virtual
				 * @returns {BPMSoft.EntitySchemaQuery} Query to account.
				 */
				getContactAccountQuery: function () {
					const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Account",
						rowCount: 1
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("PriceList");
					const contactFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "[Contact:Account:Id].Id",
						BPMSoft.SysValue.CURRENT_USER_CONTACT.value);
					esq.filters.addItem(contactFilter);
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @override
				 */
				onSaved: function() {
					const operation = this.get("Operation");
					if (operation === ConfigurationEnums.CardStateV2.EDIT) {
						this.updateDetail({detail: "PortalSupplyPaymentDetail"});
						this.updateDetail({detail: "PortalSupplyPaymentResultsDetail"});
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getLookupPageConfig
				 * @override
				 */
				getLookupPageConfig: function () {
					const parentConfig = this.callParent(arguments);
					parentConfig.hideActions = true;
					return parentConfig;
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"PortalSupplyPaymentDetail": {
					"schemaName": "PortalSupplyPaymentDetailV2",
					"entitySchemaName": "SupplyPaymentElement",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Order"
					},
					"defaultValues": {
						"Currency": {
							"masterColumn": "Currency"
						},
						"CurrencyRate": {
							"masterColumn": "CurrencyRate"
						}
					},
					"subscriber": {"methodName": "refreshAmount"}
				},
				"PortalSupplyPaymentResultsDetail": {
					"schemaName": "PortalSupplyPaymentDetailV2",
					"entitySchemaName": "SupplyPaymentElement",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Order"
					},
					"defaultValues": {
						"Currency": {
							"masterColumn": "Currency"
						},
						"CurrencyRate": {
							"masterColumn": "CurrencyRate"
						}
					},
					"subscriber": {"methodName": "refreshAmount"}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "OrderPassportTab",
					"propertyName": "items",
					"name": "PortalSupplyPaymentDetail",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "OrderResultsTab",
					"propertyName": "items",
					"name": "PortalSupplyPaymentResultsDetail",
					"index": 1,
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "remove",
					"name": "SupplyPayment"
				},
				{
					"operation": "merge",
					"parentName": "OrderReceiverInformationResultsBlock",
					"propertyName": "items",
					"name": "ReceiverNameResultsBlock",
					"values": {
						"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "merge",
					"parentName": "OrderReceiverInformationResultsBlock",
					"propertyName": "items",
					"name": "CommentResultsBlock",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24, "rowSpan": 1}
					}
				},
				{
					"operation": "merge",
					"name": "ReceiverName",
					"values": {
						"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "merge",
					"name": "Comment",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24, "rowSpan": 1}
					}
				},
				{
					"operation": "remove",
					"name": "SupplyPaymentResults"
				}
			]/**SCHEMA_DIFF*/
		};
	});
