// D9 Team
define("SpecificationInObjectPageV2", ["SpecificationUtils",
	"SpecificationConstants", "BusinessRuleModule"],
	function(SpecificationUtils, SpecificationConstants, BusinessRuleModule) {
		return {
			entitySchemaName: "SpecificationInObject",
			attributes: {
				/**
				 * ##############
				 * @type: {BPMSoft.DataValueType.LOOKUP}
				 */
				"Specification":
				{
					lookupListConfig: {
						columns: ["Type"]
					}
				}
			},
			methods: {
				/**
				 *  ########## ###### ######### ######## ########, #### ##### ## ################ ## #######
				 *  ####### ##### ######## # ####### ######
				 * @returns {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########
				 */
				getActions: function() {
					var parentActions = this.callParent(arguments);
					if (parentActions && !this.getSchemaAdministratedByRecords()) {
						parentActions.clear();
					}
					return parentActions;
				}
			},
			diff: /**SCHEMA_DIFF*/[
// Tabs
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
					"name": "Specification",
					"values": {
						"bindTo": "Specification",
						"layout": { "column": 0, "row": 1, "colSpan": 24 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"name": "ColumnsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": { "column": 0, "row": 2, "colSpan": 24, "rowSpan": 3},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "FloatValue",
					"values": {
						"wrapClass": ["product-value"],
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"bindTo": "FloatValue"
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "ListItemValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"contentType": BPMSoft.ContentType.ENUM,
						"bindTo": "ListItemValue"
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "StringValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"bindTo": "StringValue"
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "IntValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"bindTo": "IntValue"
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnsContainer",
					"propertyName": "items",
					"name": "BooleanValue",
					"values": {
						"caption": { "bindTo": "Resources.Strings.ValueCaption" },
						"bindTo": "BooleanValue"
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"StringValue": SpecificationUtils.GenerateVisibleRuleForSpecificationType("StringValue",
					SpecificationConstants.SpecificationTypes.StringType),
				"IntValue": SpecificationUtils.GenerateVisibleRuleForSpecificationType("IntValue",
					SpecificationConstants.SpecificationTypes.IntType),
				"FloatValue": SpecificationUtils.GenerateVisibleRuleForSpecificationType("FloatValue",
					SpecificationConstants.SpecificationTypes.FloatType),
				"BooleanValue": SpecificationUtils.GenerateVisibleRuleForSpecificationType("BooleanValue",
					SpecificationConstants.SpecificationTypes.BooleanType),
				"ListItemValue": SpecificationUtils.GenerateVisibleRuleForSpecificationType("ListItemValue",
					SpecificationConstants.SpecificationTypes.ListType,
						"FiltrationListItemValueBySpecififcation",
						{
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autoClean: true,
							baseAttributePatch: "Specification",
							comparisonType: this.BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Specification"
					})
			}
		};
	});
