define("AttributeInSiteEventPageV2", ["SiteEventConstants", "BusinessRuleModule"],
	function(SiteEventConstants, BusinessRuleModule) {
		return {
			entitySchemaName: "AttributeInSiteEvent",
			attributes: {
				/**
				 * ####### #######.
				 * @type: {BPMSoft.DataValueType.LOOKUP}
				 */
				"SiteEventAttribute":
				{
					lookupListConfig: {
						columns: ["Type"]
					}
				}
			},
			methods: {
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
				 * ########## ######### ####### ## #### ######## ########.
				 * @returns {boolean} ########## true.
				 */
				isColumnVisibleByType: function(attributeType) {
					var siteEventAttribute = this.get("SiteEventAttribute");
					var siteEventAttributeType = (siteEventAttribute && siteEventAttribute.Type &&
						siteEventAttribute.Type.value);
					return (siteEventAttributeType === SiteEventConstants.AttributeTypes[attributeType]);
				},

				/**
				 * ########## ######### ####### ########## ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isStringValueVisible: function() {
					return this.isColumnVisibleByType("StringType");
				},

				/**
				 * ########## ######### ####### ######### ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isIntValueVisible: function() {
					return this.isColumnVisibleByType("IntType");
				},

				/**
				 * ########## ######### ####### ######## ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isFloatValueVisible: function() {
					return this.isColumnVisibleByType("FloatType");
				},

				/**
				 * ########## ######### ####### ########### ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isBooleanValueVisible: function() {
					return this.isColumnVisibleByType("BooleanType");
				},

				/**
				 * ########## ######### ####### ######## ######## ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isListItemValueVisible: function() {
					return this.isColumnVisibleByType("ListType");
				},

				/**
				 * ########## ######### ####### ######## ###### ## #### ########.
				 * @returns {boolean} ########## true.
				 */
				isProductValueVisible: function() {
					return this.isColumnVisibleByType("ProductType");
				}
			},
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
					"name": "SiteEvent",
					"values": {
						"bindTo": "SiteEvent",
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "SiteEventAttribute",
					"values": {
						"bindTo": "SiteEventAttribute",
						"layout": {"column": 0, "row": 1, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"name": "ColumnsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 0, "row": 2, "colSpan": 11, "rowSpan": 0},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "ProductValue",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ValueCaption"},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"visible": {
							"bindTo": "isProductValueVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "ListItemValue",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ValueCaption"},
						"contentType": BPMSoft.ContentType.ENUM,
						"bindTo": "ListItemValue",
						"visible": {
							"bindTo": "isListItemValueVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "StringValue",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ValueCaption"},
						"visible": {
							"bindTo": "isStringValueVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "IntValue",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ValueCaption"},
						"visible": {
							"bindTo": "isIntValueVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "FloatValue",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ValueCaption"},
						"visible": {
							"bindTo": "isFloatValueVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "BooleanValue",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ValueCaption"},
						"visible": {
							"bindTo": "isBooleanValueVisible"
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"ListItemValue": {
					"FiltrationListItemValueBySiteEventAttribute": {
						ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
						autoClean: true,
						baseAttributePatch: "SiteEventAttribute",
						comparisonType: this.BPMSoft.ComparisonType.EQUAL,
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: "SiteEventAttribute"
					}
				}
			}
		};
	});
