define("OpportunityPageV2", ["OpportunityOrderUtilities"],
	function() {
		return {
			entitySchemaName: "Opportunity",
			details: /**SCHEMA_DETAILS*/{
				/**
				 * Order Detail
				 */
				Order: {
					schemaName: "OrderDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"}
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {
				/**
				 * Order utilities mixin.
				 */
				OpportunityOrderUtilities: "BPMSoft.OpportunityOrderUtilities"
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.OpportunityOrderUtilities#getCurrentOpportunityId
				 * @protected
				 * @overridden
				 */
				getCurrentOpportunityId: function() {
					return this.get("Id");
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onCardAction
				 * @protected
				 * @overridden
				 */
				onCardAction: function(config) {
					if (this.Ext.isObject(config)) {
						var method = this[config.methodName];
						return method.apply(config.scope || this, config.args);
					} else {
						return this.callParent(arguments);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "Order",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "CreateOrderFromOpportunityButton",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"index": 4,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "getButtonCaption"},
						"click": {"bindTo": "CreateOrderFromOpportunity"},
						"enabled": {"bindTo": "canEntityBeOperated"},
						"classes": {
							"textClass": ["actions-button-margin-right"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					}
				},
				{
					"operation": "merge",
					"name": "actions",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						},
				},
			]/**SCHEMA_DIFF*/
		};
	});
