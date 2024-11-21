define("BusinessRuleFilterActionDesignerViewModel", ["BusinessRuleFilterActionDesignerViewModelResources",
		"BusinessRuleActionDesignerViewModel", "ExpressionEdit", "ExpressionEnums",
		"BusinessRuleFilterActionConditionDesignerViewModel"], function(resources) {

		/**
		 * @class BPMSoft.Designers.BusinessRuleBindParameterActionDesignerViewModel
		 */
		Ext.define("BPMSoft.Designers.BusinessRuleFilterActionDesignerViewModel", {
			extend: "BPMSoft.BusinessRuleActionDesignerViewModel",
			alternateClassName: "BPMSoft.BusinessRuleFilterActionDesignerViewModel",

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseModel#getModelColumns
			 * @overridden
			 */
			getModelColumns: function() {
				var baseColumns = this.callParent(arguments);
				return this.Ext.apply(baseColumns, {
					"Condition": {
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT
					}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.prepareCondition();
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getConfigForEmptyMetaItem
			 * @overridden
			 */
			getConfigForEmptyMetaItem: function() {
				var config = this.callParent(arguments);
				const Type = BPMSoft.ExpressionEnums.ExpressionType;
				var expressionType = this.entitySchemaUId ? Type.COLUMN : Type.PARAMETER;
				Ext.apply(config, {
					"condition": {
						"type": "ComparisonBusinessRuleCondition",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"leftExpression": {
							"type": expressionType,
							"columnMetaPath": null
						},
						"rightExpression": {
							"type": expressionType
						}
					}
				});
				if (this.entitySchemaUId) {
					config.condition.leftExpression.dataModelName = this.getFirstEntitySchemaName();
				}
				return config;
			},

			/**
			 * Prepare filter condition.
			 * @protected
			 */
			prepareCondition: function() {
				var metaItem = this.getMetaItem();
				var conditionClassName = "BPMSoft.BusinessRuleFilterActionConditionDesignerViewModel";
				var conditionViewModel = this.createItemViewModel(conditionClassName, {
					"MetaItemType": "ComparisonBusinessRuleCondition",
					"MetaItem": metaItem.condition,
					"DefaultExpressionCaption": this.get("DefaultExpressionCaption")
				});
				conditionViewModel.on("pullChanges", this.onPullChanges, this);
				this.set("Condition", conditionViewModel);
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleActionDesignerViewModel#getActionTitle
			 * @overridden
			 */
			getActionTitle: function() {
				return resources.localizableStrings.ActionTitle;
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getActionTitle
			 * @overridden
			 */
			getAsyncValidators: function() {
				var validators = this.callParent(arguments);
				validators.push(this.validateCondition);
				return validators;
			},

			/**
			 * Validate action condition.
			 * @protected
			 * @param  {Function} next Callback method.
			 * @param  {Object} validationInfo Validation info.
			 */
			validateCondition: function(next, validationInfo) {
				var condition = this.get("Condition");
				condition.asyncValidate(function(responseValidationInfo) {
					this.applyValidationInfo(validationInfo, responseValidationInfo);
					next(validationInfo);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getMetaItemUpdaters
			 * @overridden
			 */
			getMetaItemUpdaters: function() {
				var updaters = this.callParent(arguments);
				updaters.push(this.updateConditionMetaItem);
				return updaters;
			},

			/**
			 * Async update condition.
			 * @protected
			 * @param {Function} next Callback method.
			 */
			updateConditionMetaItem: function(next) {
				var condition = this.get("Condition");
				condition.updateMetaItem(function() {
					next();
				}, this);
			},

			/**
			 * Returns condition view property items config.
			 * @protected
			 * @return {Object} Condition view property items config.
			 */
			getConditionItemsViewConfig: function() {
				var conditionViewModel = this.get("Condition");
				var config = conditionViewModel.getViewConfig();
				Ext.apply(config, {
					"bindingContext": "Condition"
				});
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#unsubscribePullChangesEvent
			 * @overridden
			 */
			unsubscribePullChangesEvent: function() {
				this.$Condition.un("pullChanges", this.onPullChanges, this);
				this.callParent(arguments);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BusinessRuleActionDesignerViewModel#enrichViewConfig
			 * @overridden
			 */
			enrichViewConfig: function(config) {
				this.callParent(arguments);
				this.Ext.apply(config, {
					"conditionItems": [this.getConditionItemsViewConfig()],
					"conditionTitleItems": [{
						"className": "BPMSoft.Container",
						"classes": {
							"wrapClassName": ["business-rule-case-action-header-item"]
						},
						"items": [{
							"className": "BPMSoft.Label",
							"caption": resources.localizableStrings.LeftExpressionGroupCaption
						}]
					}, {
						"className": "BPMSoft.Container",
						"classes": {
							"wrapClassName": ["business-rule-case-action-header-item"]
						},
						"items": [{
							"className": "BPMSoft.Label",
							"caption": resources.localizableStrings.RightExpressionGroupCaption
						}]
					}]
				});
			}

			//endregion

		});
		return BPMSoft.BusinessRuleFilterActionDesignerViewModel;
	});
