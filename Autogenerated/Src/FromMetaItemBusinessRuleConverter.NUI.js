define("FromMetaItemBusinessRuleConverter", ["BusinessRuleModule"], function(BusinessRuleModule) {

	/**
	 * @class BPMSoft.configuration.FromMetaItemBusinessRuleConverter
	 * FromMetaItemBusinessRuleConverter class.
	 */
	Ext.define("BPMSoft.configuration.FromMetaItemBusinessRuleConverter", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.FromMetaItemBusinessRuleConverter",

		// region Properties: Private

		/**
		 * Action type map.
		 * @private
		 * @type {Object}
		 */
		actionTypeMap: null,

		/**
		 * Expression type map.
		 * @private
		 * @type {Object}
		 */
		expressionTypeMap: null,

		/**
		 * Attribute actions.
		 * @private
		 * @type {Array}
		 */
		attributeActions: null,

		/**
		 * Entity schema.
		 * @private
		 * @type {BPMSoft.BaseEntitySchema}
		 */
		entitySchema: null,

		/**
		 * Page schema UId.
		 * @private
		 * @type {String}
		 */
		pageSchemaUId: null,

		// endregion

		// region Methods: Private

		/**
		 * Returns entity schema column name.
		 * @private
		 * @param {String} columnUId Column uId.
		 * @return {String} Entity schema column name.
		 */
		getEntitySchemaColumnName: function(columnUId, modelName) {
			var result;
			const entitySchema = BPMSoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(modelName,
				this.pageSchemaUId);
			BPMSoft.each(entitySchema.columns, function(column, columnName) {
				if (column.uId === columnUId) {
					result = columnName;
					return false;
				}
			}, this);
			if (!Ext.isDefined(result)) {
				throw new BPMSoft.ItemNotFoundException();
			}
			return result;
		},

		/**
		 * @private
		 */
		_getAttributeName: function(columnUId, modelName) {
			const columnName = this.getEntitySchemaColumnName(columnUId, modelName);
			return BPMSoft.BusinessRuleSchemaManager.getAttributeName(columnName, modelName, this.pageSchemaUId);
		},

		/**
		 * Checks object is of className type.
		 * @private
		 * @param {Object} object Object.
		 * @param {String} className Class name.
		 * @return {Boolean} If object is of type, returns true.
		 */
		isObjectOfClass: function(object, className) {
			return BPMSoft.isInstanceOfClass(object, "BPMSoft.manager." + className);
		},

		/**
		 * Checks object is of type from classNameMap.
		 * @private
		 * @param {Object} object Object.
		 * @param {Object} classNameMap Class name map.
		 * @return {Boolean} If object is of type, returns true.
		 */
		isObjectOfClasses: function(object, classNameMap) {
			var result = false;
			BPMSoft.each(classNameMap, function(value, key) {
				if (this.isObjectOfClass(object, Ext.isArray(classNameMap) ? value : key)) {
					result = true;
					return false;
				}
			}, this);
			return result;
		},

		/**
		 * Returns old enum type by object type.
		 * @private
		 * @param {Object} classNameMap Class name map.
		 * @param {Object} object Object.
		 * @return {Object} Old enum type.
		 */
		getEnumTypeByObject: function(classNameMap, object) {
			var fullClassName = Ext.getClassName(object);
			var className = fullClassName.split(".").pop();
			var result = this[classNameMap][className];
			if (!Ext.isEmpty(result)) {
				return result;
			} else {
				throw new BPMSoft.InvalidOperationException();
			}
		},

		/**
		 * @private
		 */
		_getEntitySchemaColumnPathByMetaPath: function(entitySchemaUId, metaPath, callback, scope) {
			var request = {
				getSchemaColumnInformation: {
					entitySchemaUId: entitySchemaUId,
					schemaColumnMetaPath: metaPath
				}
			};
			BPMSoft.SchemaDesignerUtilities.execute(request, function(response) {
				var schemaColumnInformation = response && response.getSchemaColumnInformationResponse;
				if (Ext.isEmpty(schemaColumnInformation)) {
					throw new BPMSoft.InvalidOperationException();
				}
				callback.call(scope, schemaColumnInformation.columnPath);
			}, this);
		},

		/**
		 * Returns entity schema column path by metaPath.
		 * @private
		 * @param {String} metaPath Entity schema column metaPath.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getEntitySchemaColumnPathByMetaPath: function(metaPath, modelName, callback, scope) {
			const entitySchema = BPMSoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(modelName,
				this.pageSchemaUId);
			const entitySchemaUId = entitySchema.uId;
			this._getEntitySchemaColumnPathByMetaPath(entitySchemaUId, metaPath, callback, scope);
		},

		/**
		 * @private
		 */
		_getParameterColumnPathByMetaPath: function(expression, callback, scope) {
			const paths = expression.columnMetaPath.split(".");
			const parameterUId = paths[0];
			const columnMetaPath = paths.splice(1).join(".");
			let attribute;
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.findParameterByUId({
						schemaUId: this.pageSchemaUId,
						parameterUId: parameterUId
					}, next, this);
				},
				function(next, parameter) {
					attribute = parameter.name;
					var entitySchemaUId = parameter.referenceSchemaUId;
					this._getEntitySchemaColumnPathByMetaPath(entitySchemaUId, columnMetaPath, next, this);
				},
				function(next, columnPath) {
					callback.call(scope, {
						attribute: attribute,
						attributePath: columnPath
					});
				}, this
			);
		},

		/**
		 * Validates business rule expression metaItem.
		 * @private
		 * @param {BPMSoft.BaseBusinessRuleExpression} expression Business rule expression metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isExpressionMetaItem: function(expression) {
			return this.isObjectOfClasses(expression, this.expressionTypeMap);
		},

		/**
		 * Converts business rule column expression metaItem to old business rule expression config.
		 * @private
		 * @param {BPMSoft.ColumnBusinessRuleExpression} expression Business rule column expression metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromColumnExpressionMetaItem: function(expression, callback, scope) {
			var columnMetaPath = expression.columnMetaPath;
			const modelName = expression.dataModelName;
			if (!BPMSoft.contains(columnMetaPath, ".")) {
				callback.call(scope, {
					attribute: this._getAttributeName(columnMetaPath, modelName)
				});
				return;
			}
			const columnIdArray = columnMetaPath.split(".");
			const columnId = columnIdArray[0];
			const attribute = this._getAttributeName(columnId, modelName);
			this.getEntitySchemaColumnPathByMetaPath(columnMetaPath, modelName, function(columnPath) {
				const columnPathArray = columnPath.split(".");
				const attributePath = columnPathArray.splice(1).join(".");
				callback.call(scope, {
					attribute: attribute,
					attributePath: attributePath
				});
			}, this);
		},

		/**
		 * @private
		 */
		_convertFromParameterExpressionMetaItem: function(expression, callback, scope) {
			if (BPMSoft.contains(expression.columnMetaPath, ".")) {
				this._getParameterColumnPathByMetaPath(expression, callback, scope);
			} else {
				callback.call(scope, {attribute: expression.attributeName});
			}
		},

		/**
		 * Converts business rule expression metaItem to old business rule expression config.
		 * @private
		 * @param {BPMSoft.BaseBusinessRuleExpression} expression Business rule expression metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromExpressionMetaItem: function(expression, callback, scope) {
			if (!this.isExpressionMetaItem(expression)) {
				throw new BPMSoft.UnsupportedTypeException();
			}
			var enumType = this.getEnumTypeByObject("expressionTypeMap", expression);
			var convertedExpression = {type: enumType};
			BPMSoft.chain(
				function(next) {
					switch (enumType) {
						case BusinessRuleModule.enums.ValueType.CONSTANT:
							convertedExpression.value = expression.value;
							convertedExpression.dataValueType = expression.dataValueType;
							next();
							break;
						case BusinessRuleModule.enums.ValueType.SYSVALUE:
							convertedExpression.value = expression.sysValueType;
							convertedExpression.dataValueType = expression.dataValueType;
							next();
							break;
						case BusinessRuleModule.enums.ValueType.SYSSETTING:
							convertedExpression.value = expression.sysSettingCode;
							convertedExpression.dataValueType = expression.dataValueType;
							next();
							break;
						case BusinessRuleModule.enums.ValueType.PARAMETER:
							this._convertFromParameterExpressionMetaItem(expression, function(convertedExpressionPart) {
								Ext.apply(convertedExpression, convertedExpressionPart);
								next();
							}, this);
							break;
						case BusinessRuleModule.enums.ValueType.ATTRIBUTE:
							if (this.isObjectOfClass(expression, "AttributeBusinessRuleExpression")) {
								convertedExpression.attribute = expression.attributeName;
								next();
							} else {
								this.convertFromColumnExpressionMetaItem(expression, function(convertedExpressionPart) {
									Ext.apply(convertedExpression, convertedExpressionPart);
									next();
								}, this);
							}
							break;
						case BusinessRuleModule.enums.ValueType.FORMULA:
							convertedExpression.formula = expression.formula;
							next();
							break;
						default:
							throw new BPMSoft.UnsupportedTypeException();
					}
				},
				function() {
					callback.call(scope, convertedExpression);
				},
				this
			);
		},

		/**
		 * Validates business rule right expression metaItem.
		 * @private
		 * @param {Object} rightExpression Business rule right expression metaItem.
		 * @param {BPMSoft.ComparisonType} comparisonType Comparison type.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isRightExpressionMetaItem: function(rightExpression, comparisonType) {
			var nullableComparisonTypes = [
				BPMSoft.ComparisonType.IS_NULL,
				BPMSoft.ComparisonType.IS_NOT_NULL
			];
			return Ext.isObject(rightExpression) || BPMSoft.contains(nullableComparisonTypes, comparisonType);
		},

		/**
		 * Validates business rule comparison condition metaItem.
		 * @private
		 * @param {BPMSoft.ComparisonBusinessRuleCondition} condition Business rule comparison condition metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isComparisonConditionMetaItem: function(condition) {
			return this.isObjectOfClass(condition, "ComparisonBusinessRuleCondition") &&
				Ext.isNumber(condition.comparisonType) &&
				Ext.isObject(condition.leftExpression) &&
				this.isRightExpressionMetaItem(condition.rightExpression, condition.comparisonType);
		},

		/**
		 * Converts business rule comparison condition metaItem to old business rule condition config.
		 * @private
		 * @param {BPMSoft.BusinessRuleConditionGroup} condition Business rule comparison condition metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromComparisonCondiotionMetaItem: function(condition, callback, scope) {
			if (!this.isComparisonConditionMetaItem(condition)) {
				throw new BPMSoft.UnsupportedTypeException();
			}
			var convertedCondition = {comparisonType: condition.comparisonType};
			BPMSoft.chain(
				function(next) {
					this.convertFromExpressionMetaItem(condition.leftExpression, function(convertedExpression) {
						convertedCondition.leftExpression = convertedExpression;
						next();
					}, this);
				},
				function(next) {
					if (!Ext.isEmpty(condition.rightExpression)) {
						this.convertFromExpressionMetaItem(condition.rightExpression, function(convertedExpression) {
							convertedCondition.rightExpression = convertedExpression;
							next();
						}, this);
					} else {
						next();
					}
				},
				function() {
					callback.call(scope, convertedCondition);
				},
				this
			);
		},

		/**
		 * Validates business rule condition group metaItem.
		 * @private
		 * @param {BPMSoft.BusinessRuleConditionGroup} conditionGroup Business rule condition group metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isConditionGroupMetaItem: function(conditionGroup) {
			return this.isObjectOfClass(conditionGroup, "BusinessRuleConditionGroup") &&
				Ext.isNumber(conditionGroup.operationType) &&
				Ext.isArray(conditionGroup.items);
		},

		/**
		 * Converts business rule condition group metaItem to old business rule condition config.
		 * @private
		 * @param {BPMSoft.BusinessRuleConditionGroup} conditionGroup Business rule condition group metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromCondiotionGroupMetaItem: function(conditionGroup, callback, scope) {
			if (!this.isConditionGroupMetaItem(conditionGroup)) {
				throw new BPMSoft.UnsupportedTypeException();
			}
			var items = [];
			var functions = conditionGroup.items.map(function(condition) {
				return function(next) {
					this.convertFromComparisonCondiotionMetaItem(condition, function(result) {
						items.push(result);
						next();
					}, this);
				};
			}, this);
			functions.push(function() {
				callback.call(scope, {
					logical: conditionGroup.operationType,
					conditions: items
				});
			});
			BPMSoft.chain.apply(this, functions);
		},

		/**
		 * Converts business rule filtration action metaItem to old business rule action config.
		 * @private
		 * @param {BPMSoft.FiltrationBusinessRuleAction} action Business rule action metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromFiltrationActionMetaItem: function(action, callback, scope) {
			var actionRulePart = {ruleType: BusinessRuleModule.enums.RuleType.FILTRATION};
			this.convertFromComparisonCondiotionMetaItem(action.condition, function(convertedCondition) {
				var actionColumnName = convertedCondition.leftExpression.attribute;
				Ext.apply(actionRulePart, convertedCondition.rightExpression, {
					baseAttributePatch: convertedCondition.leftExpression.attributePath,
					comparisonType: convertedCondition.comparisonType,
					autoClean: action.condition.leftExpression.autoClean,
					autocomplete: action.condition.rightExpression.autocomplete
				});
				callback.call(scope, actionColumnName, actionRulePart);
			}, this);
		},

		/**
		 * @private
		 */
		_convertFromPopulateAttributeActionMetaItem: function(action, callback, scope) {
			let actionColumnName;
			let sourceExpression;
			BPMSoft.chain(
				function(next) {
					const isValidExpression =
						this.isObjectOfClass(action.leftExpression, "ColumnBusinessRuleExpression") ||
						this.isObjectOfClass(action.leftExpression, "AttributeBusinessRuleExpression") ||
						this.isObjectOfClass(action.leftExpression, "ParameterBusinessRuleExpression");
					if (!isValidExpression) {
						throw new BPMSoft.UnsupportedTypeException();
					}
					this.convertFromExpressionMetaItem(action.leftExpression, function(convertedExpression) {
						actionColumnName = convertedExpression.attribute;
						next();
					}, this);
				},
				function(next) {
					this.convertFromExpressionMetaItem(action.rightExpression, function(convertedExpression) {
						sourceExpression = convertedExpression;
						next();
					}, this);
				},
				function() {
					callback.call(scope, actionColumnName, {
						ruleType: BusinessRuleModule.enums.RuleType.POPULATE_ATTRIBUTE,
						populatingAttributeSource: {expression: sourceExpression}
					});
				},
				this
			);
		},

		/**
		 * @private
		 */
		_convertFromBindParameterAttributeActionMetaItem: function(action) {
			const sourceType = action.getPropertyValue("sourceType");
			const attributeName = action.getPropertyValue("attributeName");
			const dataModelName = action.getPropertyValue("dataModelName");
			return sourceType === BPMSoft.BusinessRuleActionSourceType.COLUMN_SOURCE
				? BPMSoft.BusinessRuleSchemaManager.getAttributeName(attributeName, dataModelName, this.pageSchemaUId)
				: attributeName;
		},

		/**
		 * Converts business rule bindable parameter action metaItem to old business rule action config.
		 * @private
		 * @param {BPMSoft.BaseBusinessRuleAction} action Business rule action metaItem.
		 * @return {Object} Old business rule action config.
		 */
		convertFromBindParameterActionMetaItem: function(action) {
			const actionRulePart = {
				ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
				property: this.getEnumTypeByObject("actionTypeMap", action)
			};
			let actionColumnName;
			if (this.isObjectOfClasses(action, this.attributeActions)) {
				actionColumnName = this._convertFromBindParameterAttributeActionMetaItem(action);
			} else {
				actionColumnName = this._getAttributeName(action.columnUId);
			}
			return {
				actionRulePart: actionRulePart,
				actionColumnName: actionColumnName
			};
		},

		/**
		 * Validates business rule action metaItem.
		 * @private
		 * @param {BPMSoft.BaseBusinessRuleAction} action Business rule action metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isActionMetaItem: function(action) {
			return this.isObjectOfClass(action, "FiltrationBusinessRuleAction") ||
				this.isObjectOfClass(action, "PopulateBusinessRuleAction") ||
				this.isObjectOfClasses(action, this.actionTypeMap);
		},

		/**
		 * Validates business rule action group metaItem.
		 * @private
		 * @param {BPMSoft.BusinessRuleActionGroup} actionGroup Business rule action group metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isActionGroupMetaItem: function(actionGroup) {
			return this.isObjectOfClass(actionGroup, "BusinessRuleActionGroup") &&
				Ext.isArray(actionGroup.items) &&
				actionGroup.items.length === 1 &&
				this.isActionMetaItem(actionGroup.items[0]);
		},

		/**
		 * Converts business rule action metaItem to old business rule action config.
		 * @private
		 * @param {BPMSoft.BusinessRuleActionGroup} actionGroup Action group metaItem.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromActionMetaItem: function(actionGroup, callback, scope) {
			if (!this.isActionGroupMetaItem(actionGroup)) {
				throw new BPMSoft.UnsupportedTypeException();
			}
			const action = actionGroup.items[0];
			if (this.isObjectOfClass(action, "FiltrationBusinessRuleAction")) {
				this.convertFromFiltrationActionMetaItem(action, function(actionColumnName, actionRulePart) {
					callback.call(scope, true, actionColumnName, actionRulePart);
				}, this);
				return;
			}
			if (this.isObjectOfClass(action, "PopulateBusinessRuleAction")) {
				this._convertFromPopulateAttributeActionMetaItem(action, function(actionColumnName, actionRulePart) {
					callback.call(scope, false, actionColumnName, actionRulePart);
				}, this);
				return;
			}
			const actionConfig = this.convertFromBindParameterActionMetaItem(action);
			callback.call(scope, false, actionConfig.actionColumnName, actionConfig.actionRulePart);
		},

		/**
		 * Validates business rule case metaItem.
		 * @private
		 * @param {BPMSoft.BusinessRuleCase} ruleCase Business rule case metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isRuleCaseMetaItem: function(ruleCase) {
			return this.isObjectOfClass(ruleCase, "BusinessRuleCase") &&
				Ext.isObject(ruleCase.condition) &&
				Ext.isObject(ruleCase.action);
		},

		/**
		 * Validates business rule switch metaItem.
		 * @private
		 * @param {BPMSoft.BusinessRuleSwitch} ruleSwitch Business rule switch metaItem.
		 * @return {Boolean} If metaItem is valid, returns true.
		 */
		isRuleSwitchMetaItem: function(ruleSwitch) {
			return this.isObjectOfClass(ruleSwitch, "BusinessRuleSwitch") &&
				Ext.isArray(ruleSwitch.cases) &&
				ruleSwitch.cases.length === 1 &&
				this.isRuleCaseMetaItem(ruleSwitch.cases[0]);
		},

		/**
		 * Validates business rule schema.
		 * @private
		 * @param {BPMSoft.BusinessRuleSchema} rule Business rule schema.
		 * @return {Boolean} If schema is valid, returns true.
		 */
		isRuleSchema: function(rule) {
			return this.isObjectOfClass(rule, "BusinessRuleSchema") && this.isRuleSwitchMetaItem(rule.ruleSwitch);
		},

		/**
		 * Returns true if business rule schema is invalid business rule schema.
		 * @private
		 * @param {BPMSoft.BusinessRuleSchema} rule Business rule schema.
		 * @return {Boolean} True if business rule schema is invalid business rule schema.
		 */
		isInvalidRuleSchema: function(rule) {
			return this.isObjectOfClass(rule, "InvalidBusinessRuleSchema");
		},

		/**
		 * Converts business rule schema to old business rule config.
		 * @private
		 * @param {BPMSoft.BusinessRuleSchema} rule Business rule schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromRuleSchema: function(rule, callback, scope) {
			if (this.isInvalidRuleSchema(rule)) {
				callback.call(scope, {uId: rule.uId, removed: rule.removed}, rule.name, rule.actionColumnName);
				return;
			}
			if (!this.isRuleSchema(rule)) {
				throw new BPMSoft.UnsupportedTypeException();
			}
			var convertedRule = {
				uId: rule.uId,
				enabled: rule.enabled,
				removed: rule.removed
			};
			var columnName;
			var ruleCase = rule.ruleSwitch.cases[0];
			BPMSoft.chain(
				function(next) {
					this.convertFromActionMetaItem(ruleCase.action,
						function(isFiltrationAction, actionColumnName, actionRulePart) {
							Ext.apply(convertedRule, actionRulePart);
							columnName = actionColumnName;
							next(isFiltrationAction);
						}, this);
				},
				function(next, isFiltrationAction) {
					if (!isFiltrationAction) {
						this.convertFromCondiotionGroupMetaItem(ruleCase.condition, function(conditionRulePart) {
							Ext.apply(convertedRule, conditionRulePart);
							next();
						}, this);
					} else {
						next();
					}
				},
				function() {
					callback.call(scope, convertedRule, rule.name, columnName);
				},
				this
			);
		},

		// endregion

		// region Methods: Public

		/**
		 * Converts metaItems to old business rule config.
		 * @param {BPMSoft.BusinessRuleSchema[]} rules Rules.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFromMetaItems: function(rules, callback, scope) {
			var result = {};
			var functions = rules.map(function(rule) {
				return function(next) {
					this.convertFromRuleSchema(rule, function(convertedRule, ruleName, actionColumnName) {
						if (!Ext.isObject(result[actionColumnName])) {
							result[actionColumnName] = {};
						}
						result[actionColumnName][ruleName] = convertedRule;
						BPMSoft.defer(next);
					}, this);
				};
			}, this);
			functions.push(function() {
				callback.call(scope, result);
			});
			BPMSoft.chain.apply(this, functions);
		}

		// endregion

	});
	return BPMSoft.FromMetaItemBusinessRuleConverter;
});
