define("InvoicePageV2", [],
	function() {
		return {
				entitySchemaName: "Invoice",
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Order",
						"values": {
							"bindTo": "Order",
							"layout": {"column": 13, "row": 1, "colSpan": 11},
							"tip": {
								"content": {"bindTo": "Resources.Strings.OrderTip"}
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
	});
