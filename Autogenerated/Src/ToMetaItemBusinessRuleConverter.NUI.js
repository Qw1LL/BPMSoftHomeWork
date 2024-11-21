define("ToMetaItemBusinessRuleConverter", ["BusinessRuleModule", "ExpressionEnums"], function(BusinessRuleModule) {
	/**
	 * @class BPMSoft.configuration.ToMetaItemBusinessRuleConverter
	 * ToMetaItemBusinessRuleConverter class.
	 */
	Ext.define("BPMSoft.configuration.ToMetaItemBusinessRuleConverter", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.ToMetaItemBusinessRuleConverter",

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
		 * Returns exception message with argument name.
		 * @private
		 * @param {String} argumentName Argument name.
		 * @return {String} Exception message.
		 */
		getArgumentNullOrEmptyExceptionMessage: function(argumentName) {
			var mask = (!Ext.isEmpty(argumentName))
				? BPMSoft.Resources.Exception.ArgumentNullOrEmptyExceptionWithArgumentName
				: BPMSoft.Resources.Exception.ArgumentNullOrEmptyException;
			return Ext.String.format(mask, argumentName);
		},

		/**
		 * Returns data value type of system setting.
		 * @private
		 * @param {String} sysSettingCode System setting code.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getSysSettingDataValueType: function(sysSettingCode, callback, scope) {
			var request = {sysSettingsNameCollection: [sysSettingCode]};
			BPMSoft.ServiceProvider.executeRequest("QuerySysSettings", request, function(response) {
				var sysSetting = response.values[sysSettingCode];
				callback.call(scope, sysSetting && sysSetting.dataValueType);
			}, this);
		},

		/**
		 * Returns data value type of system value.
		 * @private
		 * @param {BPMSoft.SystemValueType} sysValueType System value type.
		 * @return {String|Null} Data value type.
		 */
		findSysValueDataValueType: function(sysValueType) {
			var pairs = [{
				dataValueType: BPMSoft.DataValueType.TIME,
				sysValueTypes: [BPMSoft.SystemValueType.CURRENT_TIME]
			}, {
				dataValueType: BPMSoft.DataValueType.DATE,
				sysValueTypes: [BPMSoft.SystemValueType.CURRENT_DATE]
			}, {
				dataValueType: BPMSoft.DataValueType.DATE_TIME,
				sysValueTypes: [BPMSoft.SystemValueType.CURRENT_DATE_TIME]
			}, {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				sysValueTypes: [
					BPMSoft.SystemValueType.CURRENT_USER,
					BPMSoft.SystemValueType.CURRENT_USER_CONTACT,
					BPMSoft.SystemValueType.CURRENT_USER_ACCOUNT,
					BPMSoft.SystemValueType.CURRENT_FUNCTIONAL_ROLES,
					BPMSoft.SystemValueType.CURRENT_ORGANIZATIONAL_ROLES
				]
			}];
			for (var i = 0; i < pairs.length; i++) {
				if (BPMSoft.contains(pairs[i].sysValueTypes, sysValueType)) {
					return pairs[i].dataValueType;
				}
			}
			return null;
		},

		/**
		 * Returns entity schema column information by path.
		 * @private
		 * @param {Object} path Path.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		_getEntitySchemaColumnInformationByExpression: function(expression, callback, errorback, scope) {
			const attributeName = expression.attribute;
			const entityColumn = BPMSoft.BusinessRuleSchemaManager.findEntitySchemaColumnByAttribute(attributeName,
				this.pageSchemaUId);
			const path = Ext.String.format("{0}.{1}", entityColumn.name, expression.attributePath);
			const entitySchema = BPMSoft.BusinessRuleSchemaManager.findEntitySchemaByAttribute(attributeName,
				this.pageSchemaUId);
			this._getEntitySchemaColumnInformationByPath(entitySchema.uId, path, callback, errorback, scope);
		},

		/**
		 * @private
		 */
		_getEntitySchemaColumnInformationByPath: function(entitySchemaUId, path, callback, errorback, scope) {
			var request = {
				getSchemaColumnInformation: {
					entitySchemaUId: entitySchemaUId,
					schemaColumnPath: path
				}
			};
			BPMSoft.SchemaDesignerUtilities.execute(request, function(response) {
				var schemaColumnInformation = response && response.getSchemaColumnInformationResponse;
				if (Ext.isEmpty(schemaColumnInformation)) {
					errorback.call(scope, BPMSoft.Resources.Exception.InvalidOperationException);
				} else {
					callback.call(scope, {
						columnMetaPath: schemaColumnInformation.columnMetaPath,
						dataValueType: BPMSoft.ServerDataValueType[schemaColumnInformation.columnDataValueTypeUId]
					});
				}
			}, this);
		},

		/**
		 * @private
		 */
		_getParameterColumnInformationByPath: function(expression, callback, errorback, scope) {
			const parameterName = expression.attribute;
			const path = expression.attributePath;
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.findParameterByName({
						schemaUId: this.pageSchemaUId,
						parameterName: parameterName
					}, next, this);
				},
				function(next, parameter) {
					if (!parameter) {
						const exceptionMessage = BPMSoft.Resources.Exception.ItemNotFoundException;
						const message = Ext.String.format("{0}: {1}", parameterName, exceptionMessage);
						errorback.call(scope, message);
						return;
					}
					var entitySchemaUId = parameter.referenceSchemaUId;
					this._getEntitySchemaColumnInformationByPath(entitySchemaUId, path,
						function(result) {
							result.columnMetaPath = parameter.uId + "." + result.columnMetaPath;
							callback.call(scope, result);
						},
						function(exception) {
							errorback.call(scope, exception);
						}, this);
				}, this
			);
		},

		/**
		 * Returns if entity schema column exist.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {Boolean} If column exist.
		 */
		isEntitySchemaColumnExists: function(attributeName) {
			const entitySchemaColumn = BPMSoft.BusinessRuleSchemaManager
				.findEntitySchemaColumnByAttribute(attributeName, this.pageSchemaUId);
			return Boolean(entitySchemaColumn);
		},

		/**
		 * Returns entity schema column.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {String} Entity schema column.
		 */
		getEntitySchemaColumn: function(attributeName) {
			const entitySchemaColumn = BPMSoft.BusinessRuleSchemaManager
				.findEntitySchemaColumnByAttribute(attributeName, this.pageSchemaUId);
			if (Ext.isEmpty(entitySchemaColumn)) {
				throw new BPMSoft.ItemNotFoundException();
			}
			return entitySchemaColumn;
		},

		/**
		 * Returns entity schema column UId.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {String} Entity schema column UId.
		 */
		getEntitySchemaColumnUId: function(attributeName) {
			var entitySchemaColumn = this.getEntitySchemaColumn(attributeName);
			return entitySchemaColumn.uId;
		},

		/**
		 * Returns entity schema column data value type.
		 * @private
		 * @param {String} attributeName Attribute name.
		 * @return {Number} Entity schema column data value type.
		 */
		getEntitySchemaColumnDataValueType: function(attributeName) {
			var entitySchemaColumn = this.getEntitySchemaColumn(attributeName);
			return entitySchemaColumn.dataValueType;
		},

		/**
		 * Converts old business rule enum type to new enum type.
		 * @private
		 * @param {String} mapName Conversion map name.
		 * @param {Object} oldEnumValue Old enum value.
		 * @return {String[]} New enum values.
		 */
		convertToMetaItemEnumType: function(mapName, oldEnumValue) {
			var result = [];
			BPMSoft.each(this[mapName], function(oldValue, newValue) {
				if (oldValue === oldEnumValue) {
					result.push(newValue);
				}
			}, this);
			return !Ext.isEmpty(result) ? result : null;
		},

		/**
		 * Converts old business rule enum type to action enum type.
		 * @private
		 * @param {Object} actionType Old action type.
		 * @return {String} New action type.
		 */
		convertToActionEnumType: function(actionType) {
			var newActionType = this.convertToMetaItemEnumType("actionTypeMap", actionType);
			return Ext.isArray(newActionType) && newActionType.length > 0 ? newActionType[0] : null;
		},

		/**
		 * Converts old business rule enum type to expression enum type.
		 * @private
		 * @param {Object} expression Old expression.
		 * @return {String} New expression type.
		 */
		convertToExpressionEnumType: function(expression) {
			var expressionTypes = this.convertToMetaItemEnumType("expressionTypeMap", expression && expression.type);
			if (!expressionTypes) {
				return null;
			}
			var resultExpressionType = null;
			if (expressionTypes.length === 1) {
				resultExpressionType = expressionTypes[0];
			} else {
				var expressionType = BPMSoft.ExpressionEnums.ExpressionType;
				var hasExpressions = BPMSoft.contains(expressionTypes, expressionType.COLUMN) &&
					BPMSoft.contains(expressionTypes, expressionType.ATTRIBUTE);
				if (hasExpressions) {
					const attributeName = expression.attribute;
					const dataModelName = BPMSoft.BusinessRuleSchemaManager
						.findDataModelNameByAttribute(attributeName, this.pageSchemaUId);
					if (dataModelName) {
						resultExpressionType = this.isEntitySchemaColumnExists(attributeName)
							? expressionType.COLUMN
							: expressionType.ATTRIBUTE;
					} else {
						resultExpressionType = expression.filterLeftExpression
							? expressionType.PARAMETER
							: expressionType.ATTRIBUTE;
					}
				}
			}
			return resultExpressionType;
		},

		/**
		 * Converts old business rule filtration action condition config to condition metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object} config.action Old business rule action config.
		 * @param {String} config.actionColumnName Action column name.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToFiltrationConditionMetaItem: function(config, callback, errorback, scope) {
			var action = config.action;
			var actionColumnName = config.actionColumnName;
			var result = {
				type: "ComparisonBusinessRuleCondition",
				comparisonType: action.comparisonType
			};
			BPMSoft.chain(
				function(next) {
					const convertConfig = {
						autoClean: Ext.isDefined(action.autoClean) ? action.autoClean : false,
						expression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: actionColumnName,
							attributePath: action.baseAttributePatch,
							filterLeftExpression: true
						}
					};
					this.convertToLeftExpressionMetaItem(convertConfig, next, errorback, this);
				},
				function(next, leftExpression) {
					Ext.apply(result, leftExpression);
					const convertConfig = {
						autocomplete: Ext.isDefined(action.autocomplete) ? action.autocomplete : false,
						expression: action,
						comparisonType: action.comparisonType
					};
					this.convertToRightExpressionMetaItem(convertConfig, next, errorback, this);
				},
				function(next, rightExpression) {
					Ext.apply(result, rightExpression);
					callback.call(scope, result);
				},
				this
			);
		},

		/**
		 * Converts old business rule filtration action config to action metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object} config.action Old business rule action config.
		 * @param {String} config.actionColumnName Action column name.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertFiltrationActionToActionMetaItem: function(config, callback, errorback, scope) {
			this.convertToFiltrationConditionMetaItem(config, function(condition) {
				if (Ext.isEmpty(condition)) {
					errorback.call(scope, this.getArgumentNullOrEmptyExceptionMessage("condition"));
					return;
				}
				callback.call(scope, {
					type: "FiltrationBusinessRuleAction",
					condition: condition
				});
			}, errorback, this);
		},

		_findStorageData: function(prefix, predicate, scope) {
			const cacheKey = prefix + this.pageSchemaUId;
			const data = BPMSoft.ClientPageSessionCache.getItem(cacheKey);
			return BPMSoft.find(data, predicate, scope);
		},

		_findDetailByAttributeNme: function(attributeName) {
			return this._findStorageData("details_", function(item) {
				return item.name === attributeName;
			}, this);
		},

		_findControlGroupByAttributeNme: function(attributeName) {
			return this._findStorageData("groups_", function(item) {
				return item.name === attributeName;
			}, this);
		},

		_findModuleByAttributeNme: function(attributeName) {
			return this._findStorageData("modules_", function(item) {
				return item.name === attributeName;
			}, this);
		},

		_findTabByAttributeNme: function(attributeName) {
			return this._findStorageData("tabs_", function(item) {
				return item.name === attributeName;
			}, this);
		},

		/**
		 * @private
		 */
		_convertBindParameterActionToAttributeActionMetaItem: function(attributeName, callback, scope) {
			if (this.isEntitySchemaColumnExists(attributeName)) {
				const column = this.getEntitySchemaColumn(attributeName);
				const dataModelName = BPMSoft.BusinessRuleSchemaManager.findDataModelNameByAttribute(attributeName, this.pageSchemaUId);
				callback.call(scope, {
					attributeName: column.name,
					sourceType: BPMSoft.BusinessRuleActionSourceType.COLUMN_SOURCE,
					dataModelName: dataModelName
				});
			} else {
				const config = {
					schemaUId: this.pageSchemaUId,
					parameterName: attributeName
				};
				BPMSoft.ClientUnitSchemaManager.findParameterByName(config, function(parameter) {
					if (parameter) {
						callback.call(scope, {
							attributeName: attributeName,
							sourceType: BPMSoft.BusinessRuleActionSourceType.PARAMETER_SOURCE
						});
					} else {
						let sourceType = BPMSoft.BusinessRuleActionSourceType.ATTRIBUTE_SOURCE;
						if (this._findDetailByAttributeNme(attributeName) != null) {
							sourceType = BPMSoft.BusinessRuleActionSourceType.DETAIL_SOURCE;
						} else if (this._findModuleByAttributeNme(attributeName) != null) {
							sourceType = BPMSoft.BusinessRuleActionSourceType.MODULE_SOURCE;
						} else if (this._findTabByAttributeNme(attributeName) != null) {
							sourceType = BPMSoft.BusinessRuleActionSourceType.TAB_SOURCE;
						} else if (this._findControlGroupByAttributeNme(attributeName) != null) {
							sourceType = BPMSoft.BusinessRuleActionSourceType.COUNTROL_GROUP_SOURCE;
						}
						callback.call(scope, {
							attributeName: attributeName,
							sourceType: sourceType
						});
					}
				}, this);
			}
		},

		/**
		 * Converts old business rule bindable parameter action config to action metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {BusinessRuleModule.enums.RuleType} config.actionType Old business rule action type.
		 * @param {String} config.actionColumnName Action column name.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertBindParameterActionToActionMetaItem: function(config, callback, errorback, scope) {
			const actionColumnName = config.actionColumnName;
			const type = this.convertToActionEnumType(config.actionType);
			const result = {type: type};
			if (BPMSoft.contains(this.attributeActions, type)) {
				this._convertBindParameterActionToAttributeActionMetaItem(actionColumnName, function(attributeAction) {
					callback.call(scope, Ext.apply(result, attributeAction));
				}, this);
			} else {
				if (type !== null && this.isEntitySchemaColumnExists(actionColumnName)) {
					const columnUId = this.getEntitySchemaColumnUId(actionColumnName);
					Ext.apply(result, {columnUId: columnUId});
					callback.call(scope, result);
				} else {
					errorback.call(scope, BPMSoft.Resources.Exception.UnsupportedTypeException);
				}
			}
		},

		/**
		 * @private
		 */
		_convertToPopulateAttributeActionMetaItem: function(config, callback, errorback, scope) {
			const actionColumnName = config.actionColumnName;
			const populatedAttributeSource = config.populatedAttributeSource;
			let leftExpression;
			let rightExpression;
			BPMSoft.chain(
				function(next) {
					const oldLeftExpressionConfig = {
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: actionColumnName,
						filterLeftExpression: true
					};
					this.convertToExpressionMetaItem(oldLeftExpressionConfig, function(expression) {
						leftExpression = expression;
						next();
					}, errorback, this);
				},
				function(next) {
					if (!populatedAttributeSource || !populatedAttributeSource.expression) {
						errorback.call(scope, "populatedAttributeSource property is not completed");
					}
					this.convertToExpressionMetaItem(populatedAttributeSource.expression, function(expression) {
						rightExpression = expression;
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, {
						type: "PopulateBusinessRuleAction",
						leftExpression: leftExpression,
						rightExpression: rightExpression
					});
				},
				this
			);
		},

		/**
		 * Converts old business rule expression config to system value expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToSysValueExpressionMetaItem: function(expression, callback, errorback, scope) {
			if (expression.value === BPMSoft.SystemValueType.CURRENT_MAINTAINER) {
				callback.call(scope, {
					type: BPMSoft.ExpressionEnums.ExpressionType.SYSSETTING,
					dataValueType: BPMSoft.DataValueType.TEXT,
					sysSettingCode: "Maintainer"
				});
			} else {
				var dataValueType = this.findSysValueDataValueType(expression.value);
				if (dataValueType !== null) {
					callback.call(scope, {
						dataValueType: dataValueType,
						sysValueType: expression.value
					});
				} else {
					errorback.call(scope, "Unsupported system value type");
				}
			}
		},

		/**
		 * Converts old business rule expression config to system setting expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToSysSettingExpressionMetaItem: function(expression, callback, errorback, scope) {
			this.getSysSettingDataValueType(expression.value, function(dataValueType) {
				if (BPMSoft.contains(BPMSoft.DataValueType, dataValueType)) {
					callback.call(scope, {
						dataValueType: dataValueType,
						sysSettingCode: expression.value
					});
				} else {
					errorback.call(scope, BPMSoft.Resources.Exception.UnsupportedTypeException);
				}
			}, this);
		},

		/**
		 * Converts old business rule expression config to attribute expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToAttributeExpressionMetaItem: function(expression, callback, errorback, scope) {
			const attributes = BPMSoft.ClientPageSessionCache.getItem("attributes_" + this.pageSchemaUId);
			const attribute = attributes && attributes.find(function(x) {
				return x.name === expression.attribute;
			});
			callback.call(scope, {
				type: "AttributeBusinessRuleExpression",
				attributeName: expression.attribute,
				dataValueType: attribute && attribute.dataValueType
			});
		},

		/**
		 * @private
		 */
		_convertToParameterExpressionMetaItem: function(expression, callback, errorback, scope) {
			if (Ext.isEmpty(expression.attributePath)) {
				Ext.callback(callback, scope, [{
					type: "ParameterBusinessRuleExpression",
					attributeName: expression.attribute
				}]);
			} else {
				this._getParameterColumnInformationByPath(expression, callback, errorback, scope);
			}
		},

		/**
		 * @private
		 */
		_convertToFormulaExpressionMetaItem: function(expression, callback, errorback, scope) {
			Ext.callback(callback, scope, [{formula: expression.formula}]);
		},

		/**
		 * Converts old business rule expression config to column expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToColumnExpressionMetaItem: function(expression, callback, errorback, scope) {
			const attributeName = expression.attribute;
			const dataModelName = BPMSoft.BusinessRuleSchemaManager.findDataModelNameByAttribute(attributeName,
				this.pageSchemaUId);
			if (Ext.isEmpty(expression.attributePath)) {
				callback.call(scope, {
					columnMetaPath: this.getEntitySchemaColumnUId(attributeName),
					dataValueType: this.getEntitySchemaColumnDataValueType(attributeName),
					dataModelName: dataModelName
				});
			} else if (BPMSoft.contains(expression.attributePath, "[")) {
				errorback.call(scope, "Unsupported attribute path.");
			} else {
				this._getEntitySchemaColumnInformationByExpression(expression, function(result) {
					result.dataModelName = dataModelName;
					callback.call(scope, result);
				}, errorback, scope);
			}
		},

		/**
		 * Converts old business rule expression config to constant expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToConstantExpressionMetaItem: function(expression, callback, errorback, scope) {
			var expressionValue = expression.value;
			if (Ext.isDefined(expressionValue) && expressionValue !== null) {
				callback.call(scope, {
					dataValueType: expression.dataValueType,
					value: expressionValue
				});
			} else {
				errorback.call(scope, BPMSoft.Resources.Exception.UnsupportedTypeException);
			}
		},

		/**
		 * Converts old business rule expression config to expression metaItem config.
		 * @private
		 * @param {Object} expression Old business rule expression config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToExpressionMetaItem: function(expression, callback, errorback, scope) {
			var expressionType = this.convertToExpressionEnumType(expression);
			var result = {type: expressionType};
			BPMSoft.chain(
				function(next) {
					var expressionTypeEnum = BPMSoft.ExpressionEnums.ExpressionType;
					switch (expressionType) {
						case expressionTypeEnum.CONSTANT:
							this.convertToConstantExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.COLUMN:
							this.convertToColumnExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.PARAMETER:
							this._convertToParameterExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.ATTRIBUTE:
							this.convertToAttributeExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.SYSSETTING:
							this.convertToSysSettingExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.SYSVALUE:
							this.convertToSysValueExpressionMetaItem(expression, next, errorback, this);
							break;
						case expressionTypeEnum.FORMULA:
							this._convertToFormulaExpressionMetaItem(expression, next, errorback, this);
							break;
						default:
							errorback.call(scope, BPMSoft.Resources.Exception.UnsupportedTypeException);
					}
				},
				function(next, convertedExpression) {
					callback.call(scope, Ext.apply(result, convertedExpression));
				},
				this
			);
		},

		/**
		 * Checks nullability of comparison type.
		 * @private
		 * @return {Boolean} True - if comparison type is nullable.
		 */
		isNullableComparisonType: function(comparisonType) {
			var nullableComparisonTypes = [
				BPMSoft.ComparisonType.IS_NULL,
				BPMSoft.ComparisonType.IS_NOT_NULL
			];
			return BPMSoft.contains(nullableComparisonTypes, comparisonType);
		},

		/**
		 * Converts old business rule expression config to left expression metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToLeftExpressionMetaItem: function(config, callback, errorback, scope) {
			this.convertToExpressionMetaItem(config.expression, function(leftExpression) {
				const expression = Ext.apply(leftExpression, {
					autoClean: config.autoClean
				});
				callback.call(scope, { leftExpression: expression });
			}, errorback, this);
		},

		/**
		 * Converts old business rule expression config to right expression metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object} config.expression Old business rule expression config.
		 * @param {BPMSoft.ComparisonType} config.comparisonType Comparison type.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToRightExpressionMetaItem: function(config, callback, errorback, scope) {
			if (this.isNullableComparisonType(config.comparisonType)) {
				callback.call(scope, {rightExpression: null});
			} else {
				this.convertToExpressionMetaItem(config.expression, function(rightExpression) {
					const expression = Ext.apply(rightExpression, {
						autocomplete: config.autocomplete
					});
					callback.call(scope, { rightExpression: expression });
				}, errorback, this);
			}
		},

		/**
		 * Converts old business rule condition config to comparison condition metaItem config.
		 * @private
		 * @param {Object} condition Old business rule condition config.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToComparisonConditionMetaItem: function(condition, callback, errorback, scope) {
			if (!BPMSoft.contains(BPMSoft.ComparisonType, condition.comparisonType)) {
				errorback.call(scope, BPMSoft.Resources.Exception.UnsupportedTypeException);
				return;
			}
			var result = {
				type: "ComparisonBusinessRuleCondition",
				comparisonType: condition.comparisonType
			};
			BPMSoft.chain(
				function(next) {
					this.convertToLeftExpressionMetaItem({ expression: condition.leftExpression, autoClean: false}, function(leftExpression) {
						Ext.apply(result, leftExpression);
						next();
					}, errorback, this);
				},
				function(next) {
					var convertConfig = {
						"expression": condition.rightExpression,
						"comparisonType": condition.comparisonType
					};
					this.convertToRightExpressionMetaItem(convertConfig, function(rightExpression) {
						Ext.apply(result, rightExpression);
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, result);
				},
				this
			);
		},

		/**
		 * Converts old business rule condition config to condition group metaItem config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object[]} config.conditions Old business rule condition config.
		 * @param {BPMSoft.LogicalOperatorType} config.logicalOperation Logical operation.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToConditionGroupMetaItem: function(config, callback, errorback, scope) {
			var conditions = config.conditions;
			if (!Ext.isArray(conditions)) {
				errorback.call(scope, BPMSoft.Resources.Exception.UnsupportedTypeException);
				return;
			}
			var logicalOperation = config.logicalOperation;
			var items = [];
			var functions = conditions.map(function(condition) {
				return function(next) {
					this.convertToComparisonConditionMetaItem(condition, function(result) {
						items.push(result);
						next();
					}, errorback, this);
				};
			}, this);
			functions.push(function() {
				callback.call(scope, {
					type: "BusinessRuleConditionGroup",
					operationType: logicalOperation || BPMSoft.LogicalOperatorType.AND,
					items: items
				});
			});
			BPMSoft.chain.apply(this, functions);
		},

		/**
		 * Returns business rule switch template.
		 * @private
		 * @return {Object} Business rule switch template.
		 */
		getBusinessRuleSwitchTemplate: function() {
			return {
				ruleSwitch: {
					type: "BusinessRuleSwitch",
					cases: [{
						type: "BusinessRuleCase",
						condition: null,
						action: {
							type: "BusinessRuleActionGroup",
							items: []
						}
					}],
					defaultCase: null
				}
			};
		},

		/**
		 * Converts old business rule with filtration action config to rule schema config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object} config.rule Old business rule config.
		 * @param {String} config.actionColumnName Action column name.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToRuleSchemaWithFiltrationAction: function(config, callback, errorback, scope) {
			var result = this.getBusinessRuleSwitchTemplate();
			result.ruleSwitch.cases[0].condition = {type: "BusinessRuleConditionGroup"};
			BPMSoft.chain(
				function(next) {
					var convertConfig = {
						"action": config.rule,
						"actionColumnName": config.actionColumnName
					};
					this.convertFiltrationActionToActionMetaItem(convertConfig, function(action) {
						result.ruleSwitch.cases[0].action.items.push(action);
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, result);
				},
				this
			);
		},

		/**
		 * Converts old business rule with bindable parameter action config to rule schema config.
		 * @private
		 * @param {Object} config Convert config.
		 * @param {Object} config.rule Old business rule config.
		 * @param {String} config.actionColumnName Action column name.
		 * @param {Function} callback Callback function.
		 * @param {Function} errorback Errorback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToRuleSchemaWithBindParameterAction: function(config, callback, errorback, scope) {
			var rule = config.rule;
			var result = this.getBusinessRuleSwitchTemplate();
			BPMSoft.chain(
				function(next) {
					var convertConfig = {
						"conditions": rule.conditions,
						"logicalOperation": rule.logical
					};
					this.convertToConditionGroupMetaItem(convertConfig, function(condition) {
						result.ruleSwitch.cases[0].condition = condition;
						next();
					}, errorback, this);
				},
				function(next) {
					var convertConfig = {
						"actionType": rule.property,
						"actionColumnName": config.actionColumnName
					};
					this.convertBindParameterActionToActionMetaItem(convertConfig, function(action) {
						result.ruleSwitch.cases[0].action.items.push(action);
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, result);
				},
				this
			);
		},

		/**
		 * @private
		 */
		_convertToRuleSchemaWithPopulateAttributeAction: function(config, callback, errorback, scope) {
			const rule = config.rule;
			const result = this.getBusinessRuleSwitchTemplate();
			BPMSoft.chain(
				function(next) {
					const convertConfig = {
						conditions: rule.conditions,
						logicalOperation: rule.logical
					};
					this.convertToConditionGroupMetaItem(convertConfig, function(condition) {
						result.ruleSwitch.cases[0].condition = condition;
						next();
					}, errorback, this);
				},
				function(next) {
					const convertConfig = {
						actionColumnName: config.actionColumnName,
						populatedAttributeSource: rule.populatingAttributeSource
					};
					this._convertToPopulateAttributeActionMetaItem(convertConfig, function(action) {
						result.ruleSwitch.cases[0].action.items.push(action);
						next();
					}, errorback, this);
				},
				function() {
					callback.call(scope, result);
				},
				this
			);
		},

		/**
		 * Converts old business rule config to rule schema config.
		 * @private
		 * @param {Object} rule Old business rule config.
		 * @param {String} ruleName Rule name.
		 * @param {String} actionColumnName Action column name.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToRuleSchema: function(rule, ruleName, actionColumnName, callback, scope) {
			var result = {
				type: "BusinessRule",
				uId: rule.uId || BPMSoft.generateGUID(),
				name: ruleName,
				entitySchemaUId: this.entitySchema && this.entitySchema.uId,
				enabled: Ext.isDefined(rule.enabled) ? rule.enabled : true,
				removed: rule.removed
			};
			BPMSoft.chain(
				function(next) {
					var config = {
						rule: rule,
						actionColumnName: actionColumnName
					};
					var errorback = this._errorCallback.bind(this, next, ruleName, actionColumnName);
					switch (rule.ruleType) {
						case BusinessRuleModule.enums.RuleType.BINDPARAMETER:
							this.convertToRuleSchemaWithBindParameterAction(config, next, errorback, this);
							break;
						case BusinessRuleModule.enums.RuleType.FILTRATION:
							this.convertToRuleSchemaWithFiltrationAction(config, next, errorback, this);
							break;
						case BusinessRuleModule.enums.RuleType.POPULATE_ATTRIBUTE:
							this._convertToRuleSchemaWithPopulateAttributeAction(config, next, errorback, this);
							break;
						default:
							errorback(BPMSoft.Resources.Exception.UnsupportedTypeException);
					}
				},
				function(next, convertedRule) {
					callback.call(scope, Ext.apply(result, convertedRule));
				}, this
			);
		},

		/**
		 * @private
		 */
		_errorCallback: function(next, ruleName, actionColumnName, message) {
			if (message) {
				console.warn(Ext.String.format("{0}: {1}", ruleName, message));
			}
			next({
				type: "InvalidBusinessRule",
				invalid: true,
				actionColumnName: actionColumnName
			});
		},

		// endregion

		// region Methods: Public

		/**
		 * Converts old business rule config to metaItem config.
		 * @param {Object} config Old business rule config.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		convertToMetaItemConfig: function(config, callback, scope) {
			var result = [];
			var chain = [];
			BPMSoft.each(config, function(columnRules, columnName) {
				BPMSoft.each(columnRules, function(rule, ruleName) {
					chain.push(function(next) {
						this.convertToRuleSchema(rule, ruleName, columnName, function(convertedRule) {
							result.push(convertedRule);
							BPMSoft.defer(next);
						}, this);
					});
				}, this);
			}, this);
			chain.push(function() {
				callback.call(scope, result);
			});
			BPMSoft.chain.apply(this, chain);
		}

		// endregion

	});
	return BPMSoft.ToMetaItemBusinessRuleConverter;
});
