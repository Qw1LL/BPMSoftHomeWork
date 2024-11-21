define("OrderPageV2", ["VisaHelper", "ConfigurationConstants", "css!VisaHelper"],
	function(VisaHelper, ConfigurationConstants) {
		return {
			entitySchemaName: "Order",
			messages: {},
			attributes: {},
			details: /**SCHEMA_DETAILS*/{
				Activities: {
					schemaName: "ActivityDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"}
					}
				},
				Calls: {
					schemaName: "CallDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					}
				},
				Invoice: {
					schemaName: "InvoiceDetailV2",
					entitySchemaName: "Invoice",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"}
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					},
					filterMethod: "emailDetailFilter"
				},
				Visa: {
					schemaName: "VisaDetailV2",
					entitySchemaName: "OrderVisa",
					filter: {
						masterColumn: "Id",
						detailColumn: "Order"
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getActions
				 * @override
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.add("SendToVisaSeparator", this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.add("SendToVisa", this.getButtonMenuItem({
						"Caption": VisaHelper.resources.localizableStrings.SendToVisaCaption,
						"Tag": VisaHelper.SendToVisaMenuItem.methodName,
						"Enabled": {"bindTo": "canEntityBeOperated"}
					}));
					return actionMenuItems;
				},

				/**
				* Action "Send to visa".
				*/
				sendToVisa: VisaHelper.SendToVisaMethod,

				/**
				 * Creates filter for detail Email.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Group filters.
				 */
				emailDetailFilter: function() {
					var recordId = this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("OrderNotNull", this.BPMSoft.createColumnIsNotNullFilter("Order"));
					filterGroup.add("OrderConnection", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Order", recordId));
					filterGroup.add("ActivityType", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				},
			},

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "OrderPageVisaTabContainer",
					"propertyName": "items",
					"name": "OrderPageVisaBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OrderVisaTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 6,
					"values": {
						"caption": {"bindTo": "Resources.Strings.OrderVisaTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderVisaTab",
					"name": "OrderPageVisaTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderVisaTab",
					"propertyName": "items",
					"name": "Visa",
					"lableConfig": {"visible": false},
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "Activities",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "Calls",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL},
					"index": 3
				},
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "EmailDetailV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					},
					"index": 4
				},
				{
					"operation": "move",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "Document",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL},
					"index": 5
				},
				{
					"operation": "insert",
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"name": "Invoice",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL},
					"index": 6
				}
			]/**SCHEMA_DIFF*/
		};
	});
