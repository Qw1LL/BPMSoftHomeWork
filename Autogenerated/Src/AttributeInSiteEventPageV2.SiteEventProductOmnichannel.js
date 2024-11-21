define("AttributeInSiteEventPageV2", [],
	function() {
		return {
			entitySchemaName: "AttributeInSiteEvent",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * ########## ######### ####### ######## #### ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isProductTypeVisible: function() {
					return this.isColumnVisibleByType("ProductTypeType");
				},

				/**
				 * ########## ######### ####### ######## ######### ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isProductCategoryVisible: function() {
					return this.isColumnVisibleByType("ProductCategoryType");
				},

				/**
				 * ########## ######### ####### ######## ######## ##### ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isProductTrademarkVisible: function() {
					return this.isColumnVisibleByType("ProductTradeMarkType");
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "ProductCategoryValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"contentType": BPMSoft.ContentType.LOOKUP,
						visible: {
							"bindTo": "isProductCategoryVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "ProductTypeValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"contentType": BPMSoft.ContentType.LOOKUP,
						visible: {
							"bindTo": "isProductTypeVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "ProductTradeMarkValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"contentType": BPMSoft.ContentType.LOOKUP,
						visible: {
							"bindTo": "isProductTrademarkVisible"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		}

	});
