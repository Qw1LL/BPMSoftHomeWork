define("CaseStatusPage", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "CaseStatus",
			diff: [
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "ESNFeedContainer"
				},
				{
					"operation": "remove",
					"name": "ESNFeed"
				},
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Name",
						"caption": {
							"bindTo": "Resources.Strings.NameCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Description",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 4
						},
						"bindTo": "Description",
						"caption": {
							"bindTo": "Resources.Strings.DescriptionCaption"
						},
						"contentType": this.BPMSoft.ContentType.LONG_TEXT
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "IsFinal",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "IsFinal",
						"caption": {
							"bindTo": "Resources.Strings.IsFinalCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "IsResolved",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "IsResolved",
						"caption": {
							"bindTo": "Resources.Strings.IsResolvedCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "IsPaused",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "IsPaused",
						"caption": {
							"bindTo": "Resources.Strings.IsPausedCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "ButtonCaption",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ButtonCaption",
						"caption": {
							"bindTo": "Resources.Strings.ButtonCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 6
				},
				{
					"operation": "insert",
					"name": "ClosureCode",
					"values": {
						"layout": {
							"column": 13,
							"row": 4,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ClosureCode",
						"caption": {
							"bindTo": "Resources.Strings.ClosureCodeCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 7
				},
				{
					"operation": "insert",
					"name": "IsCloseOnSave",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "IsCloseOnSave",
						"caption": {
							"bindTo": "Resources.Strings.IsCloseOnSaveCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 8
				}
			],
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#getColumnCaption
				 * @overridden
				 */
				getColumnCaption: function(column) {
					return column.caption || "";
				},
				
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initPageMessages();
				},
				
				/**
				 * Initializes the required messages for the page.
				 * @protected
				 */
				initPageMessages: function() {
				}
			},
			rules: {
				"ClosureCode": {
					"EnableClosureCode": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						logical: BPMSoft.LogicalOperatorType.OR,
						conditions: [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "IsFinal"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							}
						},
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "IsResolved"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							}
						}]
					}
				}
			},
			userCode: {}
		};
	});
