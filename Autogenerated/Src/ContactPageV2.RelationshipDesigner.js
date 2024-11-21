define("ContactPageV2", ["BusinessRuleModule", "RelationshipDesignerMixin"], function(BusinessRuleModule) {
	return {
		attributes: {
			"UseRelationshipDesigner": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": BPMSoft.Features.getIsEnabled("UseRelationshipDesigner")
			}
		},
		messages: {
			"UpdateRelationshipDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			RelationshipDesignerMixin: "BPMSoft.RelationshipDesignerMixin"
		},
		businessRules: {
			RelationshipTabContainer: {
				RelationshipTabVisible: {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.VISIBLE,
					logical: BPMSoft.LogicalOperatorType.AND,
					conditions: [
						{
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							leftExpression: {
								type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								attribute: "UseRelationshipDesigner"
							},
							rightExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: true
							}
						}
					]
				},
			},
			Relationships: {
				Relationships: {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.VISIBLE,
					logical: BPMSoft.LogicalOperatorType.AND,
					conditions: [
						{
							comparisonType: BPMSoft.ComparisonType.NOT_EQUAL,
							leftExpression: {
								type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								attribute: "UseRelationshipDesigner"
							},
							rightExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: true
							}
						}
					]
				}
			}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @override BPMSoft.BasePageV2#subscribeSandboxEvents
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.mixins.RelationshipDesignerMixin.subscribeSandboxEvents.apply(this, arguments);
			},

			/**
			 * @override BPMSoft.BaseSchemaViewModel#getModuleId
			 */
			getModuleId: function(moduleName) {
				if (moduleName === "RelationshipDesigner") {
					return this.mixins.RelationshipDesignerMixin.getRelationshipDesignerModuleSandboxId.apply(this);
				}
				return this.callParent(arguments);
			},

			/**
			 * @override BPMSoft.BaseEntityPage#updateDetails
			 */
			updateDetails: function() {
				this.callParent(arguments);
				this.loadRelationshipDesignerModule();
			},

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "TabsContainer",
				"values": {
					"wrapClass": ["tabs-container"]
				}
			},
			{
				"operation": "insert",
				"name": "RelationshipTabContainer",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.RelationshipTabCaption"
					},
					"items": [],
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "RelationshipContainer",
				"parentName": "RelationshipTabContainer",
				"propertyName": "items",
				"values": {
					"id": "RelationshipContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"afterrerender": { "bindTo": "loadRelationshipDesignerModule" },
					"afterrender": { "bindTo": "loadRelationshipDesignerModule" },
					"visible": {
						"bindTo": "UseRelationshipDesigner"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
