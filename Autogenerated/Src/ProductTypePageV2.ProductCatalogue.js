define("ProductTypePageV2", [],
	function() {
		return {
			entitySchemaName: "ProductType",
			methods: {
				/**
				 *  ########## ###### ######### ######## ########, #### ##### ## ################ ## #######.
				 *  ####### ##### ######## # ####### ######
				 * @returns {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########.
				 */
				getActions: function() {
					var parentActions = this.callParent(arguments);
					if (parentActions && !this.getSchemaAdministratedByRecords()) {
						parentActions.clear();
					}
					return parentActions;
				}
			},
			details: /**SCHEMA_DETAILS*/{
				ProductFilterDetail: {
					schemaName: "ProductFilterDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "ProductType"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Tabs",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 18}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Category",
					"values": {
						"bindTo": "Category",
						"layout": {"column": 0, "row": 1, "colSpan": 18},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Description",
					"values": {
						"bindTo": "Description",
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"layout": {"column": 0, "row": 2, "colSpan": 18}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ProductFilterDetail",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
