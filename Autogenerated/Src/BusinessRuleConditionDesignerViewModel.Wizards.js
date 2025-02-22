﻿define("BusinessRuleConditionDesignerViewModel", [
	"BusinessRuleConditionDesignerViewModelResources",
	"ConfigurationEnums",
	"BusinessRuleElementDesignerViewModel",
	"ExpressionEdit",
	"ExpressionEditVMMixin",
	"ExpressionEnums",
	"BusinessRuleSchemaManager"
], function(resources, ConfigurationEnums) {

	/**
	 * Class for BusinessRuleConditionDesignerViewModel
	 */
	Ext.define("BPMSoft.Designers.BusinessRuleConditionDesignerViewModel", {
		extend: "BPMSoft.Designers.BusinessRuleElementDesignerViewModel",
		alternateClassName: "BPMSoft.BusinessRuleConditionDesignerViewModel",

		mixins: {
			"ExpressionEditVMMixin": "BPMSoft.ExpressionEditVMMixin"
		},

		columns: {
			/**
			 * Comparison type list.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"ComparisonTypeList": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"value": null
			},
			/**
			 * Comparison type.
			 * @type {BPMSoft.ComparisonType}
			 */
			"ComparisonType": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": null
			},
			/**
			 * Comparison type caption.
			 * @type {String}
			 */
			"ComparisonTypeCaption": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Left expression value.
			 * @type {Object}
			 */
			"LeftExpressionValue": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},
			/**
			 * Left expression type.
			 * @type {String}
			 */
			"LeftExpressionType": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Right expression value.
			 * @type {Object}
			 */
			"RightExpressionValue": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},
			/**
			 * Right expression type.
			 * @type {String}
			 */
			"RightExpressionType": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Expression data value type.
			 * @type {BPMSoft.DataValueType}
			 */
			"ExpressionDataValueType": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": null
			},
			/**
			 * Expression reference schema.
			 * @type {Object}
			 */
			"ReferenceSchema": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},
			/**
			 * Expression column map.
			 * @type {Object}
			 */
			"ExpressionMap": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": {
					"leftExpression": {
						"valuePropertyName": "LeftExpressionValue",
						"typePropertyName": "LeftExpressionType",
						"dataModelName": "LeftExpressionDataModelName"
					},
					"rightExpression": {
						"valuePropertyName": "RightExpressionValue",
						"typePropertyName": "RightExpressionType",
						"dataModelName": "RightExpressionDataModelName"
					}
				}
			},
			/**
			 * Invalid column field message text.
			 * @type {String}
			 */
			"InvalidFieldMessage": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": resources.localizableStrings.InvalidFieldMessage
			},
			/**
			 * Left expression is empty message text.
			 * @type {String}
			 */
			"LeftExpressionIsEmptyMessage": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": resources.localizableStrings.LeftExpressionIsEmptyMessage
			},
			/**
			 * Comparion type is empty message text.
			 * @type {String}
			 */
			"ComparisonTypeIsEmptyMessage": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": resources.localizableStrings.ComparisonTypeIsEmptyMessage
			},
			/**
			 * Right expression is empty message text.
			 * @type {String}
			 */
			"RightExpressionIsEmptyMessage": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": resources.localizableStrings.RightExpressionIsEmptyMessage
			},
			/**
			 * Left expression data model name.
			 * @type {String}
			 */
			"LeftExpressionDataModelName": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			},
			/**
			 * Right expression data model name.
			 * @type {String}
			 */
			"RightExpressionDataModelName": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			}
		},

		// region Methods: Private

		/**
		 * Returns list of available comparison type names.
		 * @private
		 * @return {Array} List of available comparison type names.
		 */
		getAvailableComparisonTypeNames: function() {
			const leftExpressionType = this.get("LeftExpressionType");
			const comparisonTypes = ["EQUAL", "NOT_EQUAL", "GREATER", "LESS"];
			if (leftExpressionType !== BPMSoft.ExpressionEnums.ExpressionType.CONSTANT &&
				leftExpressionType !== BPMSoft.ExpressionEnums.ExpressionType.SYSVALUE) {
				comparisonTypes.push("IS_NULL", "IS_NOT_NULL");
			}
			return comparisonTypes;
		},

		/**
		 * @private
		 */
		_getSupportedDataValueTypes: function() {
			return [
				BPMSoft.DataValueType.TEXT,
				BPMSoft.DataValueType.SHORT_TEXT,
				BPMSoft.DataValueType.MEDIUM_TEXT,
				BPMSoft.DataValueType.MAXSIZE_TEXT,
				BPMSoft.DataValueType.LONG_TEXT,
				BPMSoft.DataValueType.INTEGER,
				BPMSoft.DataValueType.FLOAT,
				BPMSoft.DataValueType.FLOAT1,
				BPMSoft.DataValueType.FLOAT2,
				BPMSoft.DataValueType.FLOAT3,
				BPMSoft.DataValueType.FLOAT4,
				BPMSoft.DataValueType.FLOAT8,
				BPMSoft.DataValueType.DATE_TIME,
				BPMSoft.DataValueType.DATE,
				BPMSoft.DataValueType.TIME,
				BPMSoft.DataValueType.LOOKUP,
				BPMSoft.DataValueType.BOOLEAN
			];
		},

		/**
		 * @private
		 */
		_getSupportedTypesValidator: function() {
			const supportedTypes = this._getSupportedDataValueTypes();
			return function(dataValueType) {
				return BPMSoft.contains(supportedTypes, dataValueType);
			};
		},

		/**
		 * @private
		 */
		_getDefaultValidatorByDataValueType: function(dataValueType) {
			let validator;
			switch (dataValueType) {
				case BPMSoft.DataValueType.INTEGER:
				case BPMSoft.DataValueType.MONEY:
				case BPMSoft.DataValueType.FLOAT:
				case BPMSoft.DataValueType.FLOAT1:
				case BPMSoft.DataValueType.FLOAT2:
				case BPMSoft.DataValueType.FLOAT3:
				case BPMSoft.DataValueType.FLOAT4:
					validator = BPMSoft.isNumberDataValueType;
					break;
				case BPMSoft.DataValueType.DATE_TIME:
					validator = BPMSoft.isValidForMappingOnDateDataValueType;
					break;
				case BPMSoft.DataValueType.TIME:
					validator = function(itemDataValueType) {
						return itemDataValueType === BPMSoft.DataValueType.TIME;
					};
					break;
				default:
					validator = BPMSoft.findDataValueTypeValidator(dataValueType);
			}
			return validator;
		},

		/**
		 * @private
		 */
		_getDefaultValidatorByExpression: function(expressionType, dataValueType) {
			let validator;
			switch (expressionType) {
				case BPMSoft.ExpressionEnums.ExpressionType.COLUMN:
				case BPMSoft.ExpressionEnums.ExpressionType.PARAMETER:
				case BPMSoft.ExpressionEnums.ExpressionType.CONSTANT:
				case BPMSoft.ExpressionEnums.ExpressionType.SYSVALUE:
				case BPMSoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					validator = function(itemDataValueType) {
						return itemDataValueType === dataValueType;
					};
					break;
				default:
					validator = this._getDefaultValidatorByDataValueType(dataValueType);
			}
			return validator;
		},

		/**
		 * Returns list of comparison types.
		 * @private
		 * @return {Array} List of comparison types.
		 */
		getViewModelComparisonTypes: function() {
			var result = {};
			var availableComparisonTypeNames = this.getAvailableComparisonTypeNames();
			BPMSoft.each(availableComparisonTypeNames, function(comparisonTypeName) {
				result[BPMSoft.ComparisonType[comparisonTypeName]] =
					BPMSoft.Resources.ComparisonType[comparisonTypeName];
			}, this);
			return result;
		},

		/**
		 * Initializes comparison type list.
		 * @private
		 */
		initializeComparisonTypeList: function() {
			this.set("ComparisonTypeList", this.Ext.create("BPMSoft.BaseViewModelCollection"));
		},

		/**
		 * Prepares comparison type list.
		 */
		prepareComparisonTypeList: function() {
			const comparisonTypeList = this.get("ComparisonTypeList");
			const list = this.Ext.create("BPMSoft.BaseViewModelCollection");
			const viewModelComparisonTypes = this.getViewModelComparisonTypes();
			BPMSoft.each(viewModelComparisonTypes, function(comparisonTypeCaption, comparisonType) {
				list.addItem(this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Caption: comparisonTypeCaption,
						Tag: {
							"type": parseInt(comparisonType, 10),
							"caption": comparisonTypeCaption
						},
						Click: {bindTo: "onComparisonTypeButtonClick"}
					}
				}));
			}, this);
			comparisonTypeList.reloadAll(list);
		},

		/**
		 * @private
		 */
		_prepareEntityColumnExpression: function(expression, callback, scope) {
			const dataModelName = expression.dataModelName;
			const value = expression.getExpressionValue();
			const config = {
				entitySchemaUId: this.getEntitySchemaUId(dataModelName),
				schemaColumnMetaPath: value
			};
			this.getPathByMetaPath(config, function(result) {
				var referenceSchema = this.getReferenceSchemaLookupValue(result.referenceSchemaUId);
				var expressionValue = {
					value: {
						value: value,
						name: result.columnPath,
						displayValue: result.columnCaptionPath,
						dataValueType: result.dataValueType,
						referenceSchema: referenceSchema
					},
					referenceSchema: referenceSchema,
					dataModelName: dataModelName
				};
				Ext.callback(callback, scope, [expressionValue]);
			}, this);
		},

		/**
		 * @private
		 */
		_prepareLookupParameterExpression: function(value, callback, scope) {
			let parameter;
			const paths = value.split(".");
			const parameterUId = paths[0];
			const columnMetaPath = paths.slice(1).join(".");
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.findParameterByUId({
						schemaUId: this.pageSchemaUId,
						parameterUId: parameterUId
					}, next, this);
				},
				function(next, schemaParameter) {
					parameter = schemaParameter;
					if (!parameter) {
						Ext.callback(callback, scope, [{value: value}]);
						return;
					}
					this.getPathByMetaPath({
						entitySchemaUId: parameter.referenceSchemaUId,
						schemaColumnMetaPath: columnMetaPath
					}, next, this);
				},
				function(next, result) {
					var referenceSchema = this.getReferenceSchemaLookupValue(result.referenceSchemaUId);
					var expressionValue = {
						value: {
							value: value,
							name: parameter.name + "." + result.columnPath,
							displayValue: parameter.getCaption() + "." + result.columnCaptionPath,
							dataValueType: parameter.dataValueType,
							referenceSchema: referenceSchema
						},
						referenceSchema: referenceSchema
					};
					Ext.callback(callback, scope, [expressionValue]);
				}, this
			);
		},

		/**
		 * @private
		 */
		_prepareParameter: function(value, callback, scope) {
			if (Ext.isEmpty(value)) {
				Ext.callback(callback, scope, [{value: value}]);
				return;
			}
			const columnMetaPath = value.columnMetaPath;
			if (BPMSoft.contains(columnMetaPath, ".")) {
				this._prepareLookupParameterExpression(columnMetaPath, callback, scope);
			} else {
				this._prepareParameterExpression(value.attributeName, callback, scope);
			}
		},

		/**
		 * @private
		 */
		_prepareParameterExpression: function(parameterName, callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.findParameterByName({
						schemaUId: this.pageSchemaUId,
						parameterName: parameterName
					}, next, this);
				},
				function(next, parameter) {
					if (!parameter) {
						Ext.callback(callback, scope, [{value: parameterName}]);
						return;
					}
					var referenceSchema = this.getReferenceSchemaLookupValue(parameter.referenceSchemaUId);
					var expressionValue = {
						value: {
							value: parameter.uId,
							name: parameterName,
							displayValue: parameter.caption.getValue() || parameterName,
							dataValueType: parameter.dataValueType,
							referenceSchema: referenceSchema
						},
						referenceSchema: referenceSchema
					};
					Ext.callback(callback, scope, [expressionValue]);
				}, this
			);
		},

		/**
		 * @private
		 */
		_prepareColumnExpression: function(expression, callback, scope) {
			const value = expression.getExpressionValue();
			if (Ext.isEmpty(value)) {
				Ext.callback(callback, scope, [{
					value: value,
					dataModelName: expression.dataModelName
				}]);
				return;
			}
			this._prepareEntityColumnExpression(expression, callback, scope);
		},

		/**
		 * @param {Object} value SysValue.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 * @private
		 */
		_prepareSysValueExpression: function(value, callback, scope) {
			let expressionValue;
			if (Ext.isEmpty(value)) {
				expressionValue = {value: value};
			} else {
				expressionValue = {
					value: {
						value: value,
						displayValue: this.getSysValueCaption(value),
						dataValueType: this.findSysValueDataValueType(value)
					},
					referenceSchema: this.getSysValueReferenceSchema(value)
				};
			}
			Ext.callback(callback, scope, [expressionValue]);
		},

		/**
		 * @private
		 */
		_getExpressionTypeList: function() {
			const Type = BPMSoft.ExpressionEnums.ExpressionType;
			const types = [];
			if (this.isEntitySchemaBased()) {
				types.push(Type.COLUMN);
			} else {
				types.push(Type.PARAMETER);
				const dataSource = BPMSoft.BusinessRuleSchemaManager.getDataSourcesConfig(this.pageSchemaUId);
				if (!BPMSoft.isEmptyObject(dataSource)) {
					types.push(Type.DATASOURCE);
				}
			}
			types.push(Type.CONSTANT, Type.ATTRIBUTE, Type.SYSSETTING, Type.SYSVALUE);
			return types;
		},

		/**
		 * Prepares expression from attribute.
		 * @param {Object} expression Expression value.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 * @private
		 */
		_prepareAttributeExpression: function(expression, callback, scope) {
			const config = {
				attributeName: expression.getExpressionValue(),
				pageSchemaUId: this.pageSchemaUId
			};
			this.getAttributeLookupValue(config, function(lookupValue) {
				callback.call(scope, {value: lookupValue});
			}, this);
		},

		// endregion

		// region Methods: Protected

		/**
		 * Comparison type button click handler.
		 * @throws {BPMSoft.ArgumentNullOrEmptyException}
		 * @param  {Object} tag Tag.
		 */
		onComparisonTypeButtonClick: function(tag) {
			if (!tag) {
				throw new BPMSoft.ArgumentNullOrEmptyException({argumentName: "tag"});
			}
			this.set("ComparisonType", tag.type);
			this.set("ComparisonTypeCaption", tag.caption);
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getConfigForEmptyMetaItem
		 * @override
		 */
		getConfigForEmptyMetaItem: function() {
			var config = this.callParent(arguments);
			var leftExpression;
			if (this.isEntitySchemaBased()) {
				leftExpression = {
					"type": BPMSoft.ExpressionEnums.ExpressionType.COLUMN,
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"columnMetaPath": null,
					"dataModelName": this.getFirstEntitySchemaName()
				};
			} else {
				leftExpression = {
					"type": BPMSoft.ExpressionEnums.ExpressionType.PARAMETER,
					"dataValueType": BPMSoft.DataValueType.TEXT
				};
			}
			Ext.apply(config, {
				"type": "ComparisonBusinessRuleCondition",
				"comparisonType": BPMSoft.ComparisonType.EQUAL,
				"leftExpression": leftExpression,
				"rightExpression": {
					"type": "ConstantBusinessRuleExpression",
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": null
				}
			});
			return config;
		},

		/**
		 * Sets comparison type.
		 * @protected
		 * @param {BPMSoft.ComparisonType} comparisonType Comparison type.
		 */
		setComparisonType: function(comparisonType) {
			this.set("ComparisonType", comparisonType);
			var comparisonTypeName = this.Ext.Object.getKey(BPMSoft.ComparisonType, comparisonType);
			this.set("ComparisonTypeCaption", BPMSoft.Resources.ComparisonType[comparisonTypeName]);
		},

		/**
		 * Prepares comparison type.
		 * @protected
		 */
		prepareComparisonType: function() {
			var metaItem = this.getMetaItem();
			var comparisonType = metaItem.getPropertyValue("comparisonType");
			this.setComparisonType(comparisonType);
		},

		/**
		 * Returns expressions data value type by  condition meta item.
		 * @protected
		 * @param  {BPMSoft.BaseBusinessRuleCondition} metaItem Condition meta item.
		 * @return {BPMSoft.DataValueType} Data value type.
		 */
		getExpressionDataValueType: function(metaItem) {
			var leftExpression = metaItem.getPropertyValue("leftExpression");
			var dataValueType = leftExpression && leftExpression.getPropertyValue("dataValueType");
			if (Ext.isEmpty(dataValueType)) {
				var rightExpression = metaItem.getPropertyValue("rightExpression");
				dataValueType = rightExpression && rightExpression.getPropertyValue("dataValueType");
				if (Ext.isEmpty(dataValueType)) {
					dataValueType = BPMSoft.DataValueType.TEXT;
				}
			}
			return dataValueType;
		},

		/**
		 * Returns expression type by expression meta item.
		 * @protected
		 * @param {BPMSoft.BaseBusinessRuleExpression} expressionMetaItem Expression meta item.
		 * @return {String} Expression type.
		 */
		getExpressionTypeFromMetaItem: function(expressionMetaItem) {
			var typeInfo = expressionMetaItem.getTypeInfo();
			return BPMSoft.BusinessRuleElementHelper.getTypeByClassName(typeInfo.fullTypeName);
		},

		/**
		 * @protected
		 * @param  {BPMSoft.BaseBusinessRuleCondition} metaItem Condition meta item.
		 */
		getExpressionsConfig: function(metaItem) {
			const expressionDataValueType = this.getExpressionDataValueType(metaItem);
			return {
				metaItem: metaItem,
				dataValueType: BPMSoft.getBaseDataValueType(expressionDataValueType)
			};
		},

		/**
		 * Prepares condition expressions.
		 * @protected
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareExpressions: function(callback, scope) {
			const metaItem = this.getMetaItem();
			const config = this.getExpressionsConfig(metaItem);
			BPMSoft.chain(
				function(next) {
					this.prepareLeftExpression(config, next, this);
				},
				function(next) {
					this.prepareRightExpression(config, next, this);
				},
				function(next) {
					config.referenceSchema = config.leftExpressionReferenceSchema ||
						(this.isRequiredRightExpression() && config.rightExpressionReferenceSchema);
					this.prepareLeftExpressionValue(config, next, this);
				},
				function(next) {
					this.prepareRightExpressionValue(config, next, this);
				},
				function() {
					this.setPreparedPropertiesIntoViewModel(config);
					callback.call(scope);
				},
				this);
		},

		/**
		 * Sets prepared properties into condition view model.
		 * @protected
		 * @param {Object} config Prepared properties.
		 * @param {String} config.leftExpressionType Left expression type.
		 * @param {String} config.rightExpressionType Right expression type.
		 * @param {BPMSoft.DataValueType} config.dataValueType Data value type.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {Mixed} config.leftExpressionValue Left expression value.
		 * @param {Mixed} config.rightExpressionValue Right expression value.
		 * @param {String} config.leftExpressionDataModelName Left expression data model name.
		 * @param {String} config.rightExpressionDataModelName Right expression data model name.
		 */
		setPreparedPropertiesIntoViewModel: function(config) {
			this.set("LeftExpressionDataModelName", config.leftExpressionDataModelName);
			this.set("RightExpressionDataModelName", config.rightExpressionDataModelName);
			this.set("LeftExpressionType", config.leftExpressionType);
			this.set("RightExpressionType", config.rightExpressionType);
			this.set("ExpressionDataValueType", config.dataValueType);
			this.set("ReferenceSchema", config.referenceSchema);
			this.set("LeftExpressionValue", config.leftExpressionValue);
			this.set("RightExpressionValue", config.rightExpressionValue);
		},

		/**
		 * Prepares left expression.
		 * @protected
		 * @param {Object} config Left expression prepare config.
		 * @param {BPMSoft.BaseBusinessRuleExpression} config.metaItem Left expression meta item.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareLeftExpression: function(config, callback, scope) {
			var metaItem = config.metaItem;
			var leftExpressionMetaItem = metaItem.getPropertyValue("leftExpression");
			this.prepareExpression(leftExpressionMetaItem, function(response) {
				Ext.apply(config, {
					leftExpressionType: this.getExpressionTypeFromMetaItem(leftExpressionMetaItem),
					leftExpressionReferenceSchema: response.referenceSchema,
					leftExpressionValue: response.value,
					leftExpressionDataModelName: response.dataModelName
				});
				callback.call(scope);
			}, this);
		},

		/**
		 * Prepares right expression.
		 * @protected
		 * @param {Object} config Right expression prepare config.
		 * @param {BPMSoft.BaseBusinessRuleExpression} config.metaItem Right expression meta item.
		 * @param {Function} next Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareRightExpression: function(config, next, scope) {
			const metaItem = config.metaItem;
			const comparisonType = metaItem.getPropertyValue("comparisonType");
			if (comparisonType === BPMSoft.ComparisonType.IS_NULL || comparisonType === BPMSoft.ComparisonType.IS_NOT_NULL) {
				Ext.callback(next, scope, [config]);
				return;
			}
			var rightExpressionMetaItem = metaItem.getPropertyValue("rightExpression");
			this.prepareExpression(rightExpressionMetaItem, function(response) {
				Ext.apply(config, {
					rightExpressionType: this.getExpressionTypeFromMetaItem(rightExpressionMetaItem),
					rightExpressionReferenceSchema: response.referenceSchema,
					rightExpressionValue: response.value,
					rightExpressionDataModelName: response.dataModelName
				});
				Ext.callback(next, scope, [config]);
			}, this);
		},

		/**
		 * Prepares expression.
		 * @protected
		 * @param {BPMSoft.BaseBusinessRuleExpression} expression Expression meta item.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareExpression: function(expression, callback, scope) {
			var type = this.getExpressionTypeFromMetaItem(expression);
			var value = expression.getExpressionValue();
			switch (type) {
				case BPMSoft.ExpressionEnums.ExpressionType.COLUMN:
					this._prepareColumnExpression(expression, callback, scope);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					this._prepareAttributeExpression(expression, callback, scope);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.SYSVALUE:
					this._prepareSysValueExpression(value, callback, scope);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.PARAMETER:
					this._prepareParameter(value, callback, scope);
					break;
				default:
					Ext.callback(callback, scope, [{value: value}]);
			}
		},

		/**
		 * Prepares left expression value.
		 * @protected
		 * @param {Object} config Prepare config.
		 * @param {String} config.leftExpressionType Left expression type.
		 * @param {BPMSoft.DataValueType} config.dataValueType Data value type.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {Mixed} config.leftExpressionValue Left expression value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareLeftExpressionValue: function(config, callback, scope) {
			var internalConfig = {
				expressionType: config.leftExpressionType,
				dataValueType: config.dataValueType,
				referenceSchema: config.referenceSchema,
				value: config.leftExpressionValue
			};
			this.prepareExpressionValue(internalConfig, function(value) {
				config.leftExpressionValue = value;
				callback.call(scope);
			}, this);
		},

		/**
		 * Prepares right expression value.
		 * @protected
		 * @param {Object} config Prepare config.
		 * @param {String} config.rightExpressionType Right expression type.
		 * @param {BPMSoft.DataValueType} config.dataValueType Data value type.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {Mixed} config.rightExpressionValue Right expression value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareRightExpressionValue: function(config, callback, scope) {
			if (!this.isRequiredRightExpression()) {
				callback.call(scope);
				return;
			}
			var internalConfig = {
				expressionType: config.rightExpressionType,
				dataValueType: config.dataValueType,
				referenceSchema: config.referenceSchema,
				value: config.rightExpressionValue
			};
			this.prepareExpressionValue(internalConfig, function(value) {
				config.rightExpressionValue = value;
				callback.call(scope);
			}, this);
		},

		/**
		 * Prepares expression value.
		 * @protected
		 * @param {Object} config Prepare config.
		 * @param {Mixed} config.value Expression value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		prepareExpressionValue: function(config, callback, scope) {
			if (this.isLookupConstantValue(config)) {
				this.requireExpressionValue(config, callback, scope);
			} else {
				callback.call(scope, config.value);
			}
		},

		/**
		 * Requires expression lookup value.
		 * @protected
		 * @param {Object} config Require config.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {GUID} config.value Value.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		requireExpressionValue: function(config, callback, scope) {
			var referenceSchema = config.referenceSchema;
			var value = config.value;
			BPMSoft.chain(
				function(next) {
					next({"entitySchemaName": referenceSchema.name});
				},
				this.getEntitySchemaLookupQueryConfig,
				this.generateEntitySchemaLookupQuery,
				function(next, esq, queryConfig) {
					esq.rowCount = 1;
					if (BPMSoft.isGUID(value)) {
						esq.enablePrimaryColumnFilter(value);
					} else {
						var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							queryConfig.primaryDisplayColumnName, value);
						esq.filters.add("displayFilter", filter);
					}
					esq.getEntityCollection(function(response) {
						var responseValue;
						var collection = response && response.collection;
						var success = response && response.success;
						if (success && collection && collection.getCount()) {
							var entity = collection.getByIndex(0);
							responseValue = {
								"value": entity.get("value"),
								"displayValue": entity.get("displayValue")
							};
						}
						callback.call(scope, responseValue);
					}, this);
				},
				this);
		},

		/**
		 * Returns true, when expression type is constant and data value type is lookup and value is GUID
		 * and reference schema is not empty, false - otherwise.
		 * @protected
		 * @param {Object} config Check config.
		 * @param {Object} config.referenceSchema Reference schema.
		 * @param {String} config.expressionType Expression type.
		 * @param {BPMSoft.DataValueType} config.dataValueType Data value type.
		 * @param {Mixed} config.value Value.
		 * @return {Boolean}
		 */
		isLookupConstantValue: function(config) {
			var referenceSchema = config.referenceSchema;
			var referenceSchemaName = referenceSchema && referenceSchema.name;
			return config.expressionType === BPMSoft.ExpressionEnums.ExpressionType.CONSTANT &&
				BPMSoft.isLookupDataValueType(config.dataValueType) &&
				!Ext.isEmpty(referenceSchemaName);
		},

		/**
		 * Prepares expression value enum list.
		 * @protected
		 * @param {String} expressionType Expression type.
		 * @param {String} filter Filter value.
		 * @param {BPMSoft.Collection} list Value collection.
		 */
		prepareExpressionValueList: function(expressionType, filter, list) {
			var referenceSchema = this.get("ReferenceSchema");
			var referenceSchemaName = referenceSchema && referenceSchema.name;
			this.mixins.ExpressionEditVMMixin.prepareValueList(filter, list, expressionType, referenceSchemaName);
		},

		/**
		 * Prepares left expression value enum list.
		 * @protected
		 * @param {String} filter Filter value.
		 * @param {BPMSoft.Collection} list Value collection.
		 */
		prepareLeftExpressionValueList: function(filter, list) {
			this.prepareExpressionValueList(this.get("LeftExpressionType"), filter, list);
		},

		/**
		 * Prepares right expression value enum list.
		 * @protected
		 * @param {String} filter Filter value.
		 * @param {BPMSoft.Collection} list Value collection.
		 */
		prepareRightExpressionValueList: function(filter, list) {
			this.prepareExpressionValueList(this.get("RightExpressionType"), filter, list);
		},

		/**
		 * Creates expression meta item from view model.
		 * @protected
		 * @param {String} expressionName Expression name.
		 * @return {BPMSoft.BaseBusinessRuleExpression} Business rule expression.
		 */
		createExpressionMetaItemFromViewModel: function(expressionName) {
			const expressionPropertyNameMap = this.get("ExpressionMap")[expressionName];
			const expressionType = this.get(expressionPropertyNameMap.typePropertyName);
			const viewModelValue = this.get(expressionPropertyNameMap.valuePropertyName);
			const className = BPMSoft.BusinessRuleElementHelper.getClassNameByType(expressionType);
			const expression = this.Ext.create(className);
			let expressionDataValueType = this.get("ExpressionDataValueType");
			let expressionValue, dataModelName;
			switch (expressionType) {
				case BPMSoft.ExpressionEnums.ExpressionType.COLUMN:
				case BPMSoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					expressionDataValueType = viewModelValue.dataValueType;
					expressionValue = viewModelValue.value;
					dataModelName = this.get(expressionPropertyNameMap.dataModelName);
					expression.setPropertyValue("dataModelName", dataModelName);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.SYSVALUE:
					expressionValue = viewModelValue.value;
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.CONSTANT:
					if (expressionDataValueType === BPMSoft.DataValueType.LOOKUP) {
						expressionValue = viewModelValue.value;
					} else {
						expressionValue = viewModelValue;
					}
					break;
				default:
					expressionValue = viewModelValue;
			}
			expression.setPropertyValue("dataValueType", expressionDataValueType);
			expression.setExpressionValue(expressionValue);
			return expression;
		},

		/**
		 * Returns true, if require set right expression, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if require set right expression, false - otherwise.
		 */
		isRequiredRightExpression: function() {
			var comparisonType = this.get("ComparisonType");
			return comparisonType !== BPMSoft.ComparisonType.IS_NULL &&
				comparisonType !== BPMSoft.ComparisonType.IS_NOT_NULL;
		},

		/**
		 * Returns true, if can change comparison type, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if can change comparison type, false - otherwise.
		 */
		canDesignComparisonType: function() {
			return !this.Ext.isEmpty(this.get("LeftExpressionValue"));
		},

		/**
		 * Returns true, if can change right expression, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if can change right expression, false - otherwise.
		 */
		canDesignRightExpression: function() {
			const canDesignComparisonType = this.canDesignComparisonType();
			const isComparisonTypeEmpty = Ext.isEmpty(this.get("ComparisonType"));
			const isRequiredRightExpression = this.isRequiredRightExpression();
			return canDesignComparisonType && !isComparisonTypeEmpty && isRequiredRightExpression;
		},

		/**
		 * Returns true, if can change right expression data value type, false - otherwise.
		 * @protected
		 * @return {Boolean} True, if can change right expression data value type, false - otherwise.
		 */
		getCanChangeRightExpressionDataValueType: function() {
			var leftExpressionType = this.get("LeftExpressionType");
			var expressionTypeEnum = BPMSoft.ExpressionEnums.ExpressionType;
			var expressionList = [
				expressionTypeEnum.SYSSETTING,
				expressionTypeEnum.SYSVALUE,
				expressionTypeEnum.ATTRIBUTE
			];
			return Ext.Array.contains(expressionList, leftExpressionType);
		},

		/**
		 * Left expression value change handler.
		 * @protected
		 */
		onLeftExpressionValueChanged: function() {
			if (this.canDesignComparisonType()) {
				if (this.Ext.isEmpty(this.get("ComparisonType"))) {
					this.setComparisonType(BPMSoft.ComparisonType.EQUAL);
				}
				var value = this.get("LeftExpressionValue");
				var typeEnum = BPMSoft.ExpressionEnums.ExpressionType;
				var type = this.get("LeftExpressionType");
				switch (type) {
					case typeEnum.COLUMN:
					case typeEnum.PARAMETER:
					case typeEnum.ATTRIBUTE:
						this.set("ExpressionDataValueType", value.dataValueType);
						this.set("ReferenceSchema", value.referenceSchema);
						this.set("LeftExpressionValue", value);
						break;
					case typeEnum.SYSSETTING:
						this.getSysSettingDataValueType(value, function(dataValueType) {
							this.set("ExpressionDataValueType", dataValueType);
						}, this);
						break;
					case typeEnum.SYSVALUE:
						this.set("ExpressionDataValueType", value.dataValueType);
						this.set("ReferenceSchema", this.getSysValueReferenceSchema(value.value));
						break;
					default:
				}
			} else {
				this.setComparisonType(null);
				this.set("ReferenceSchema", null);
			}
		},

		/**
		 * Returns reference schema for system value.
		 * @private
		 * @param {BPMSoft.SystemValueType} expressionValue System value type.
		 * @return {Object} Data value type.
		 */
		getSysValueReferenceSchema: function(expressionValue) {
			var ACCOUNT_SCHEMA_UID = "25d7c1ab-1de0-4501-b402-02e0e5a72d6e";
			var CONTACT_SCHEMA_UID = "16be3651-8fe2-4159-8dd0-a803d4683dd3";
			var SYS_ADMIN_USER_SCHEMA_UID = "84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c";
			var VW_SYS_FUNCTIONAL_ROLE_UID = "8153ea60-e515-48e8-8ba4-83c5e36c2bb1";
			var VW_SYS_ORGANIZATIONAL_ROLE_UID = "263b1c00-1a76-4348-ae08-757d6a225296";
			var uId;
			switch (expressionValue) {
				case BPMSoft.SystemValueType.CURRENT_USER:
					uId = SYS_ADMIN_USER_SCHEMA_UID;
					break;
				case BPMSoft.SystemValueType.CURRENT_USER_CONTACT:
					uId = CONTACT_SCHEMA_UID;
					break;
				case BPMSoft.SystemValueType.CURRENT_USER_ACCOUNT:
					uId = ACCOUNT_SCHEMA_UID;
					break;
				case BPMSoft.SystemValueType.CURRENT_FUNCTIONAL_ROLES:
					uId = VW_SYS_FUNCTIONAL_ROLE_UID;
					break;
				case BPMSoft.SystemValueType.CURRENT_ORGANIZATIONAL_ROLES:
					uId = VW_SYS_ORGANIZATIONAL_ROLE_UID;
					break;
				default:
					return null;
			}
			var referenceSchema = BPMSoft.EntitySchemaManager.getItem(uId);
			return {
				displayValue: referenceSchema.caption,
				name: referenceSchema.name,
				value: referenceSchema.uId
			};
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
		 * Comparison type change handler.
		 * @protected
		 */
		onComparisonTypeChanged: function() {
			if (!this.canDesignRightExpression()) {
				this.set("RightExpressionValue", null);
				this.set("RightExpressionType", null);
			}
		},

		/**
		 * Validates condition.
		 * @protected
		 * @param  {Function} next Callback method.
		 * @param  {Object} validationInfo Validation info.
		 */
		validateCondition: function(next, validationInfo) {
			var comparisonType = this.get("ComparisonType");
			if (Ext.isEmpty(comparisonType)) {
				validationInfo.isValid = false;
				validationInfo.messageList.push(this.get("ComparisonTypeIsEmptyMessage"));
			}
			next(validationInfo);
		},

		/**
		 * Returns left expression async validate config.
		 * @param {Object} validationInfo Validation info.
		 * @return {Object} Left expression async validate config
		 */
		getAsyncValidateLeftExpressionConfig: function(validationInfo) {
			return {
				"expressionType": this.get("LeftExpressionType"),
				"referenceSchema": this.get("ReferenceSchema"),
				"dataValueType": this.get("ExpressionDataValueType"),
				"value": this.get("LeftExpressionValue"),
				"columnCaption": this.get("LeftExpressionIsEmptyMessage"),
				"validationInfo": validationInfo
			};
		},

		/**
		 * Validates left expression.
		 * @protected
		 * @param  {Function} next Callback method.
		 * @param  {Object} validationInfo Validation info.
		 */
		asyncValidateLeftExpression: function(next, validationInfo) {
			var config = this.getAsyncValidateLeftExpressionConfig(validationInfo);
			this.asyncValidateExpression(config, function() {
				next(validationInfo);
			}, this);
		},

		/**
		 * Returns right expression async validate config.
		 * @param {Object} validationInfo Validation info.
		 * @return {Object} Right expression async validate config
		 */
		getAsyncValidateRightExpressionConfig: function(validationInfo) {
			return {
				"expressionType": this.get("RightExpressionType"),
				"referenceSchema": this.get("ReferenceSchema"),
				"dataValueType": this.get("ExpressionDataValueType"),
				"value": this.get("RightExpressionValue"),
				"columnCaption": this.get("RightExpressionIsEmptyMessage"),
				"validationInfo": validationInfo
			};
		},

		/**
		 * Validates right expression.
		 * @protected
		 * @param  {Function} next Callback method.
		 * @param  {Object} validationInfo Validation info.
		 */
		asyncValidateRightExpression: function(next, validationInfo) {
			var config = this.getAsyncValidateRightExpressionConfig(validationInfo);
			this.asyncValidateExpression(config, function() {
				next(validationInfo);
			}, this);
		},

		/**
		 * @protected
		 * @return {BPMSoft.BaseBusinessRuleExpression} Business rule expression.
		 */
		createLeftExpressionMetaItem: function() {
			return this.createExpressionMetaItemFromViewModel("leftExpression");
		},

		/**
		 * @protected
		 * @return {BPMSoft.BaseBusinessRuleExpression} Business rule expression.
		 */
		createRightExpressionMetaItem: function() {
			let rightExpression = null;
			if (this.isRequiredRightExpression()) {
				rightExpression = this.createExpressionMetaItemFromViewModel("rightExpression");
			}
			return rightExpression;
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getMetaItemUpdaters
		 * @override
		 */
		getMetaItemUpdaters: function() {
			var updaters = this.callParent(arguments);
			updaters.push(function(callback, metaItem) {
				metaItem.setPropertyValue("comparisonType", this.get("ComparisonType"));
				callback();
			});
			updaters.push(function(callback, metaItem) {
				const leftExpression = this.createLeftExpressionMetaItem();
				metaItem.setPropertyValue("leftExpression", leftExpression);
				callback();
			});
			updaters.push(function(callback, metaItem) {
				const rightExpression = this.createRightExpressionMetaItem();
				metaItem.setPropertyValue("rightExpression", rightExpression);
				callback();
			});
			return updaters;
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleElementDesignerViewModel#getAsyncValidateList
		 * @override
		 */
		getAsyncValidators: function() {
			var validationMethods = this.callParent();
			validationMethods.push(this.validateCondition, this.asyncValidateLeftExpression);
			if (this.isRequiredRightExpression()) {
				validationMethods.push(this.asyncValidateRightExpression);
			}
			return validationMethods;
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:LeftExpressionValue", this.onLeftExpressionValueChanged, this);
			this.un("change:ComparisonType", this.onComparisonTypeChanged, this);
			this.un("change:LeftExpressionType", this.onLeftExpressionTypeChanged, this);
			this.un("change:LeftExpressionDataModelName", this.onLeftExpressionDataModelNameChanged, this);
			this.un("change:RightExpressionDataModelName", this.onRightExpressionDataModelNameChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Loads left expression entity schema column structure explorer.
		 * @protected
		 */
		loadLeftExpressionEntitySchemaColumnVocabulary: function() {
			const dataModelName = this.get("LeftExpressionDataModelName");
			const entitySchemaUId = this.getEntitySchemaUId(dataModelName);
			const supportedDataValueTypes = this._getSupportedDataValueTypes();
			const config = {
				entitySchemaUId: entitySchemaUId,
				pageSchemaUId: this.pageSchemaUId,
				expression: this.get("LeftExpressionValue"),
				columnsFiltrationMethod: function(column) {
					const supportedDataValueTypeList = supportedDataValueTypes;
					const isNotUsed = column.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.None;
					const allowedType = BPMSoft.contains(supportedDataValueTypeList, column.dataValueType);
					return !isNotUsed && allowedType;
				},
				displayId: true
			};
			this.mixins.ExpressionEditVMMixin.loadEntitySchemaColumnVocabulary.call(this, config, function(result) {
				result.dataModelName = dataModelName;
				result.dataValueType = BPMSoft.getBaseDataValueType(result.dataValueType);
				this.set("LeftExpressionValue", result);
			}, this);
		},

		/**
		 * Prepares left expression entity schema column list.
		 * @protected
		 * @param {Object} filter Filter config.
		 * @param {BPMSoft.Collection} list List.
		 */
		prepareLeftExpressionEntitySchemaColumnList: function(filter, list) {
			const entitySchemaUId = this.getEntitySchemaUId(this.$LeftExpressionDataModelName);
			const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
			this.mixins.ExpressionEditVMMixin.prepareEntitySchemaColumnList.call(this, {
				entitySchemaUId: entitySchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [builder.buildSupportedDataValueTypeFilter()]
			}, list);
		},

		/**
		 * Prepares left expression system values list.
		 * @param {Object} filter Filter config.
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareLeftExpressionSysValuesList: function(filter, list) {
			this.mixins.ExpressionEditVMMixin.prepareSysValuesList.call(this, filter, list);
		},

		/**
		 * Prepares left expression constants list.
		 * @param {String} filter Control filter.
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with constants.
		 */
		prepareLeftExpressionConstantsList: function(filter, list) {
			const filterConfig = {};
			filterConfig.filterValue = Ext.isString(filter) ? filter : "";
			filterConfig.filterFn = this._getSupportedTypesValidator();
			this.mixins.ExpressionEditVMMixin.prepareConstantList.call(this, filterConfig, list);
		},

		/**
		 * Prepares data source list.
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with data source.
		 */
		loadDataSources: function(list) {
			if (list) {
				const dataSource = BPMSoft.BusinessRuleSchemaManager.getDataSourcesConfig(this.pageSchemaUId);
				list.reloadAll(dataSource);
			}
		},

		/**
		 * Prepares left expression attributes list.
		 * @protected
		 * @param {String} filter Filter
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareLeftExpressionAttributesList: function(filter, list) {
			const pageSchemaUId = this.forceGetPageSchemaUId();
			if (pageSchemaUId) {
				const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
				this.mixins.ExpressionEditVMMixin.prepareAttributesList.call(this, {
					pageSchemaUId: pageSchemaUId
				}, {
					filterValue: filter,
					filterFns: [builder.buildSupportedDataValueTypeFilter()]
				}, list);
			} else {
				BPMSoft.showInformation(resources.localizableStrings.FillPageSchemaWarning);
			}
		},

		/**
		 * Prepares left expression entity schema column list.
		 * @protected
		 * @param {String} filter Search value.
		 * @param {BPMSoft.Collection} list List.
		 */
		prepareLeftExpressionPageSchemaParameterList: function(filter, list) {
			const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
			this.mixins.ExpressionEditVMMixin.preparePageSchemaParameterList.call(this, {
				pageSchemaUId: this.pageSchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [
					builder.buildNonSystemPageSchemaParameterFilter(),
					builder.buildSupportedDataValueTypeFilter()
				]
			}, list);
		},

		/**
		 * Prepares right expression entity schema column list.
		 * @protected
		 * @param {String} filter Search value.
		 * @param {BPMSoft.Collection} list List.
		 */
		prepareRightExpressionPageSchemaParameterList: function(filter, list) {
			const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
			this.mixins.ExpressionEditVMMixin.preparePageSchemaParameterList.call(this, {
				pageSchemaUId: this.pageSchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [
					builder.buildNonSystemPageSchemaParameterFilter(),
					builder.buildSupportedDataValueTypeFilter(),
					builder.buildPageSchemaParameterByDataValueTypeFilter({
						dataValueType: this.$ExpressionDataValueType,
						referenceSchemaUId: this.$ReferenceSchema && this.$ReferenceSchema.value
					})
				]
			}, list);
		},

		/**
		 * Prepares right expression system values list.
		 * @param {String} filter Control filter.
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareRightExpressionSysValuesList: function(filter, list) {
			const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
			const filterConfig = {
				filterValue: Ext.isString(filter) ? filter : "",
				filterFn: builder.buildSysValueByDataValueTypeFilter({
					dataValueType: this.$ExpressionDataValueType,
					referenceSchemaName: this.$ReferenceSchema && this.$ReferenceSchema.name
				})
			};
			this.mixins.ExpressionEditVMMixin.prepareSysValuesList.call(this, filterConfig, list);
		},

		/**
		 * Prepares right expression constants list.
		 * @param {String} filter Control filter.
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with constants.
		 */
		prepareRightExpressionConstantsList: function(filter, list) {
			const filterConfig = {};
			filterConfig.filterValue = Ext.isString(filter) ? filter : "";
			const leftExpressionType = this.get("LeftExpressionType");
			const dataValueType = this.get("ExpressionDataValueType");
			if (leftExpressionType && dataValueType) {
				filterConfig.filterFn = this._getDefaultValidatorByExpression(leftExpressionType, dataValueType);
			} else {
				filterConfig.filterFn = this._getSupportedTypesValidator();
			}
			this.mixins.ExpressionEditVMMixin.prepareConstantList.call(this, filterConfig, list);
		},

		/**
		 * Prepares right expression attributes list.
		 * @protected
		 * @param {String} filter Filter
		 * @param {BPMSoft.core.collections.Collection} list Collection to fill with system values.
		 */
		prepareRightExpressionAttributesList: function(filter, list) {
			const pageSchemaUId = this.forceGetPageSchemaUId();
			if (pageSchemaUId) {
				const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
				this.mixins.ExpressionEditVMMixin.prepareAttributesList.call(this, {
					pageSchemaUId: pageSchemaUId
				}, {
					filterValue: filter,
					filterFns: [
						builder.buildSupportedDataValueTypeFilter(),
						builder.buildPageSchemaAttributeByDataValueTypeFilter({
							dataValueType: this.$ExpressionDataValueType,
							referenceSchemaName: this.$ReferenceSchema && this.$ReferenceSchema.name
						})
					]
				}, list);
			} else {
				BPMSoft.showInformation(resources.localizableStrings.FillPageSchemaWarning);
			}
		},

		/**
		 * Loads right expression entity schema column structure explorer.
		 * @protected
		 */
		loadRightExpressionEntitySchemaColumnVocabulary: function() {
			const dataModelName = this.get("RightExpressionDataModelName");
			const referenceSchema = this.get("ReferenceSchema");
			const dataValueType = this.get("ExpressionDataValueType");
			const entitySchemaUId = this.getEntitySchemaUId(dataModelName);
			const config = {
				entitySchemaUId: entitySchemaUId,
				expression: this.get("RightExpressionValue"),
				displayId: false
			};
			if (referenceSchema) {
				config.allowedReferenceSchemas = [referenceSchema.name];
				config.lookupsColumnsOnly = true;
			} else {
				const validator = this._getDefaultValidatorByDataValueType(dataValueType);
				if (validator) {
					config.columnsFiltrationMethod = function(column) {
						return validator(column.dataValueType);
					};
				}
			}
			this.mixins.ExpressionEditVMMixin.loadEntitySchemaColumnVocabulary.call(this, config, function(result) {
				result.dataModelName = dataModelName;
				this.set("RightExpressionValue", result);
			}, this);
		},

		/**
		 * Prepares right expression entity schema column list.
		 * @protected
		 * @param {String} filter Control filter.
		 * @param {BPMSoft.Collection} list List.
		 */
		prepareRightExpressionEntitySchemaColumnList: function(filter, list) {
			const entitySchemaUId = this.getEntitySchemaUId(this.$RightExpressionDataModelName);
			const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
			this.mixins.ExpressionEditVMMixin.prepareEntitySchemaColumnList.call(this, {
				entitySchemaUId: entitySchemaUId,
				packageUId: this.packageUId
			}, {
				filterValue: filter,
				filterFns: [
					builder.buildSupportedDataValueTypeFilter(),
					builder.buildEntitySchemaColumnByDataValueTypeFilter({
						dataValueType: this.$ExpressionDataValueType,
						referenceSchemaUId: this.$ReferenceSchema && this.$ReferenceSchema.value
					})
				]
			}, list);
		},

		/**
		 * Left expression type change event handler.
		 * @protected
		 */
		onLeftExpressionTypeChanged: function() {
			this.prepareComparisonTypeList();
		},

		/**
		 * Left expression data model change event handler.
		 * @protected
		 */
		onLeftExpressionDataModelNameChanged: function(model, dataModelName) {
			if (dataModelName) {
				this.loadLeftExpressionEntitySchemaColumnVocabulary();
			}
		},

		/**
		 * Right expression data model change event handler.
		 * @protected
		 */
		onRightExpressionDataModelNameChanged: function(model, dataModelName) {
			if (dataModelName) {
				this.loadRightExpressionEntitySchemaColumnVocabulary();
			}
		},

		/**
		 * Returns left expression type list.
		 * @protected
		 * @return {Array}
		 */
		getLeftExpressionTypeList: function() {
			return this._getExpressionTypeList();
		},

		/**
		 * Returns right expression type list.
		 * @protected
		 * @return {Array}
		 */
		getRightExpressionTypeList: function() {
			return this._getExpressionTypeList();
		},

		/**
		 * Returns left expression control config.
		 * @protected
		 * @return {Object} Left expression control config.
		 */
		getLeftExpressionControlConfig: function() {
			return {
				"className": "BPMSoft.ExpressionEdit",
				"loadDataSources": {"bindTo": "loadDataSources"},
				"expressionType": {"bindTo": "LeftExpressionType"},
				"expressionTypeList": this.getLeftExpressionTypeList(),
				"dataValueType": {"bindTo": "ExpressionDataValueType"},
				"referenceSchema": {"bindTo": "ReferenceSchema"},
				"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
				"prepareValueList": {"bindTo": "prepareLeftExpressionValueList"},
				"loadEntitySchemaColumnVocabulary": {"bindTo": "loadLeftExpressionEntitySchemaColumnVocabulary"},
				"prepareEntitySchemaColumnList": {"bindTo": "prepareLeftExpressionEntitySchemaColumnList"},
				"preparePageSchemaParameterList": {"bindTo": "prepareLeftExpressionPageSchemaParameterList"},
				"prepareSysValuesList": {"bindTo": "prepareLeftExpressionSysValuesList"},
				"prepareConstantList": {"bindTo": "prepareLeftExpressionConstantsList"},
				"prepareAttributesList": {"bindTo": "prepareLeftExpressionAttributesList"},
				"value": {"bindTo": "LeftExpressionValue"},
				"wrapClass": "condition-left-expression",
				"dataModelName": {"bindTo": "LeftExpressionDataModelName"}
			};
		},

		/**
		 * Returns right expression control config.
		 * @protected
		 * @return {Object} Right expression control config.
		 */
		getRightExpressionControlConfig: function() {
			return {
				"className": "BPMSoft.ExpressionEdit",
				"loadDataSources": {"bindTo": "loadDataSources"},
				"expressionType": {"bindTo": "RightExpressionType"},
				"expressionTypeList": this.getRightExpressionTypeList(),
				"dataValueType": {"bindTo": "ExpressionDataValueType"},
				"referenceSchema": {"bindTo": "ReferenceSchema"},
				"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
				"prepareValueList": {"bindTo": "prepareRightExpressionValueList"},
				"loadEntitySchemaColumnVocabulary": {"bindTo": "loadRightExpressionEntitySchemaColumnVocabulary"},
				"prepareEntitySchemaColumnList": {"bindTo": "prepareRightExpressionEntitySchemaColumnList"},
				"preparePageSchemaParameterList": {"bindTo": "prepareRightExpressionPageSchemaParameterList"},
				"prepareSysValuesList": {"bindTo": "prepareRightExpressionSysValuesList"},
				"prepareConstantList": {"bindTo": "prepareRightExpressionConstantsList"},
				"prepareAttributesList": {"bindTo": "prepareRightExpressionAttributesList"},
				"value": {"bindTo": "RightExpressionValue"},
				"canChangeReferenceSchema": false,
				"visible": {"bindTo": "canDesignRightExpression"},
				"wrapClass": "condition-right-expression",
				"dataModelName": {"bindTo": "RightExpressionDataModelName"}
			};
		},

		/**
		 * Returns comparison type control config.
		 * @protected
		 * @return {Object} Comparison type control config.
		 */
		getComparisonTypeControlConfig: function() {
			return {
				"className": "BPMSoft.Container",
				"classes": {"wrapClassName": ["case-condition-comparison-type-container"]},
				"items": [{
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"caption": {"bindTo": "ComparisonTypeCaption"},
					"menu": {"items": {"bindTo": "ComparisonTypeList"}},
					"markerValue": "ExpressionComparisonTypeButton"
				}],
				"visible": {"bindTo": "canDesignComparisonType"}
			};
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.prepareExpressions(function() {
				this.on("change:LeftExpressionValue", this.onLeftExpressionValueChanged, this);
				this.on("change:ComparisonType", this.onComparisonTypeChanged, this);
				this.on("change:LeftExpressionType", this.onLeftExpressionTypeChanged, this);
				this.on("change:LeftExpressionDataModelName", this.onLeftExpressionDataModelNameChanged, this);
				this.on("change:RightExpressionDataModelName", this.onRightExpressionDataModelNameChanged, this);
			}, this);
			this.initializeComparisonTypeList();
			this.prepareComparisonTypeList();
			this.prepareComparisonType();
		},

		/**
		 * Returns view config.
		 * @return {Object} View config.
		 */
		getViewConfig: function() {
			return {
				"className": "BPMSoft.Container",
				"items": [
					this.getLeftExpressionControlConfig(),
					this.getComparisonTypeControlConfig(),
					this.getRightExpressionControlConfig()
				]
			};
		}

		// endregion

	});
	return BPMSoft.BusinessRuleConditionDesignerViewModel;
});
