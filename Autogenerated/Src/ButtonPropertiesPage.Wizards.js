/**
 * Parent: BaseElementPropertiesPage
 */
define("ButtonPropertiesPage", ["ButtonPropertiesPageResources", "BusinessRuleModule"
], function(resources, BusinessRuleModule) {
	return {
		messages: {
			"SaveButtonConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			"Id": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Name": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Caption": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				caption: resources.localizableStrings.CaptionCaption,
				autoBind: true,
				isRequired: true
			},
			"Style": {
				dataValueType: BPMSoft.DataValueType.ENUM,
				caption: resources.localizableStrings.StyleCaption,
				isRequired: true
			},
			"StyleCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			"Tag": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				caption: resources.localizableStrings.TagCaption,
				autoBind: true,
				isRequired: true
			},
			"PerformClosePage": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				caption: resources.localizableStrings.PerformClosePage,
				autoBind: true
			},
			"PerformSaveData": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				caption: resources.localizableStrings.PerformSaveData,
				autoBind: true
			},
			"GenerateSignal": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				caption: resources.localizableStrings.GenerateSignalCaption,
				autoBind: true
			},
			"Enabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				caption: resources.localizableStrings.IsEnabledCaption,
				autoBind: true
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_initStyleCollection: function() {
				this.$StyleCollection = new BPMSoft.Collection();
				var buttonStyles = BPMSoft.controls.ButtonEnums.style;
				var exceptStyles = [buttonStyles.TRANSPARENT];
				BPMSoft.each(buttonStyles, function(code) {
					if (BPMSoft.contains(exceptStyles, code)) {
						return;
					}
					this.$StyleCollection.add(code, {
						value: code,
						displayValue: BPMSoft.Button.getStyleCaption(code)
					});
				}, this);
			},

			/**
			 * @private
			 */
			_revertDisabledControlValues: function() {
				var showUserAutoChanges = false;
				if (this.$PerformClosePage === false) {
					showUserAutoChanges = this.$PerformSaveData !== false || this.$GenerateSignal !== "";
					this.$PerformSaveData = false;
					this.$GenerateSignal = "";
				}
				return showUserAutoChanges;
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function() {
				this._initStyleCollection();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseElementPropertiesPage#loadData
			 * @override
			 */
			loadData: function() {
				this.callParent(arguments);
				var item = this.getDesignSchemaItem();
				var style = item.$Style || BPMSoft.controls.ButtonEnums.style.DEFAULT;
				this.$Style = this.$StyleCollection.get(style);
			},

			/**
			 * @inheritdoc BPMSoft.BaseElementPropertiesPage#saveData
			 * @override
			 */
			saveData: function(callback, scope) {
				var showUserAutoChanges = this._revertDisabledControlValues();
				this.callParent([function() {
					var item = this.getDesignSchemaItem();
					item.$Style = this.$Style.value;
					this.sandbox.publish("SaveButtonConfig", null, [this.sandbox.id]);
					var closeTimeout = showUserAutoChanges ? 500 : 0;
					setTimeout(function() {
						Ext.callback(callback, scope);
					}, closeTimeout);
				}, this]);
			}

			// endregion

		},
		rules: {
			"PerformSaveData": {
				"BindPerformSaveDataEnabledToPerformClosePage": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [{
						"leftExpression": {
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "PerformClosePage"
						},
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"rightExpression": {
							"type": BusinessRuleModule.enums.ValueType.CONSTANT,
							"value": true
						}
					}]
				}
			},
			"GenerateSignal": {
				"BindPerformSaveDataEnabledToPerformClosePage": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"logical": BPMSoft.LogicalOperatorType.AND,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "PerformClosePage"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							}
						}
					]
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "Caption",
				"values": {
					"bindTo": "Caption",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"layout": {"column": 0, "row": 0, "colSpan": 24}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "Tag",
				"values": {
					"bindTo": "Tag",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"layout": {"column": 0, "row": 1, "colSpan": 24}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "Style",
				"values": {
					"bindTo": "Style",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"controlConfig": {
						"prepareList": {"bindTo": "onPrepareList"},
						"list": {"bindTo": "StyleCollection"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "PerformClosePage",
				"values": {
					"bindTo": "PerformClosePage",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"classes": {"wrapClassName": ["checkbox-left-position"]},
					"layout": {"column": 0, "row": 3, "colSpan": 24}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "PerformSaveData",
				"values": {
					"bindTo": "PerformSaveData",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"classes": {"wrapClassName": ["checkbox-left-position"]},
					"labelConfig": {
						"enabled": {"bindTo": "PerformClosePage"}
					},
					"layout": {"column": 0, "row": 4, "colSpan": 24}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "GenerateSignal",
				"values": {
					"bindTo": "GenerateSignal",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"labelConfig": {
						"enabled": {"bindTo": "PerformClosePage"}
					},
					"layout": {"column": 0, "row": 5, "colSpan": 24}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainGridContainer",
				"propertyName": "items",
				"name": "Enabled",
				"values": {
					"bindTo": "Enabled",
					"classes": {"wrapClassName": ["checkbox-left-position"]},
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"layout": {"column": 0, "row": 6, "colSpan": 24}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
