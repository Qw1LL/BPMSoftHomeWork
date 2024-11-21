define("SiteEventAttributePageV2", ["SiteEventConstants", "SiteEventAttributeDetailV2"],
	function(SiteEventConstants) {
		return {
			entitySchemaName: "SiteEventAttribute",
			methods: {
				/**
				 * ########## ######### ###### "###### ########" ## #### ######## ########
				 * @returns {boolean} ########## true,
				 * #### ###### #### ###### ###### "###### ########".
				 */
				isValuesListVisible: function() {
					var attributeType = this.get("Type");
					return (!!attributeType &&
						attributeType.value === SiteEventConstants.AttributeTypes.ListType);
				},

				/**
				 *  ########## ###### ######### ######## ########, #### ##### ## ################ ## #######.
				 *  ####### ##### ######## # ####### ######!
				 * @returns {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########.
				 */
				getActions: function() {
					var parentActions = this.callParent(arguments);
					if (parentActions && !this.getSchemaAdministratedByRecords()) {
						parentActions.clear();
					}
					return parentActions;
				},

				/**
				 * ############## ######## ##############.
				 * @protected
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.set("CanUserEditType", this.isNewMode());
				}
			},
			details: /**SCHEMA_DETAILS*/{
				AttributeListItemDetail: {
					schemaName: "AttributeListItemDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SiteEventAttribute"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
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
						"layout": { "column": 0, "row": 0, "colSpan": 18 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Type",
					"values": {
						"bindTo": "Type",
						"enabled": {"bindTo" : "CanUserEditType"},
						"layout": { "column": 0, "row": 1, "colSpan": 18 },
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
						"layout": { "column": 0, "row": 2, "colSpan": 18 }
					}
				},
				{
					"operation": "insert",
					"name": "DetailControlGroup",
					"parentName": "Headers",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {
							"collapsed": false,
							"visible": {"bindTo" : "isValuesListVisible"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DetailControlGroup",
					"propertyName": "items",
					"name": "AttributeListItemDetail",
					"values": {
						"layout": { "column": 0, "row": 4, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
