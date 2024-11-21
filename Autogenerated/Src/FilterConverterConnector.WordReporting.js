define("FilterConverterConnector", ["ServiceHelper", "ConfigurationEnums", "ext-base", "BPMSoft"], function (ServiceHelper) {
	/**
	 * Class for filter data conversion.
	 */
	Ext.define("BPMSoft.configuration.FilterConverterConnector", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.FilterConverterConnector",
		singleton: true,
		expressionTypes: {
			column: 0,
			macros: 1,
			parameter: 2
		},
		//region Methods: Private


		/**
		 * @private
		 * @param {Object} obj Object.
		 * @param {String} propertyName The name of the property.
		 * @param {Number|String|Date|Object} value New value.
		 */
		_setPropertyIfValueDefined: function (obj, propertyName, value) {
			if (Ext.isDefined(value)) {
				obj[propertyName] = value;
			}
		},

		/**
		 * @private
		 * @param {Number} comparisonType Comparison type value.
		 * @return {String}
		 */
		_getServerComparisonType: function (comparisonType) {
			const ComparisonType = BPMSoft.ComparisonType;
			switch (comparisonType) {
				case ComparisonType.BETWEEN:
					return "Between";
				case ComparisonType.IS_NULL:
					return "IsNull";
				case ComparisonType.IS_NOT_NULL:
					return "IsNotNull";
				case ComparisonType.EQUAL:
					return "Equal";
				case ComparisonType.NOT_EQUAL:
					return "NotEqual";
				case ComparisonType.LESS:
					return "Less";
				case ComparisonType.LESS_OR_EQUAL:
					return "LessOrEqual";
				case ComparisonType.GREATER:
					return "Greater";
				case ComparisonType.GREATER_OR_EQUAL:
					return "GreaterOrEqual";
				case ComparisonType.START_WITH:
					return "StartWith";
				case ComparisonType.NOT_START_WITH:
					return "NotStartWith";
				case ComparisonType.CONTAIN:
					return "Contain";
				case ComparisonType.NOT_CONTAIN:
					return "NotContain";
				case ComparisonType.END_WITH:
					return "EndWith";
				case ComparisonType.NOT_END_WITH:
					return "NotEndWith";
				case ComparisonType.EXISTS:
					return "Exists";
				case ComparisonType.NOT_EXISTS:
					return "NotExists";
				case ComparisonType.INNER_JOIN:
					return "InnerJoin";
				case ComparisonType.LEFT_EXCLUSIVE:
					return "LeftExclusive";
				default:
					return "Equal";
			}
		},

		/**
		 * @private
		 * @param {Number} aggregationType Aggregation type value.
		 * @return {String}
		 */
		_getServerAggregationType: function (aggregationType) {
			const AggregationType = BPMSoft.AggregationType;
			switch (aggregationType) {
				case AggregationType.NONE:
					return "None";
				case AggregationType.COUNT:
					return "Count";
				case AggregationType.SUM:
					return "Sum";
				case AggregationType.AVG:
					return "Avg";
				case AggregationType.MIN:
					return "Min";
				case AggregationType.MAX:
					return "Max";
				default:
					throw new BPMSoft.exceptions.UnsupportedTypeException({
						message: "Converting expression with aggregation type " + aggregationType +
							" is not supported"
					});
			}
		},

		/**
		 * @private
		 * @param {Number} macrosType Macros type value.
		 * @return {String}
		 */
		_getServerMacrosType: function (macrosType) {
			const MacrosType = BPMSoft.QueryMacrosType;
			switch (macrosType) {
				case MacrosType.NONE:
					return "None";
				case MacrosType.CURRENT_USER:
					return "CurrentUser";
				case MacrosType.CURRENT_USER_CONTACT:
					return "CurrentUserContact";
				case MacrosType.YESTERDAY:
					return "Yesterday";
				case MacrosType.TODAY:
					return "Today";
				case MacrosType.TOMORROW:
					return "Tomorrow";
				case MacrosType.PREVIOUS_WEEK:
					return "PreviousWeek";
				case MacrosType.CURRENT_WEEK:
					return "CurrentWeek";
				case MacrosType.NEXT_WEEK:
					return "NextWeek";
				case MacrosType.PREVIOUS_MONTH:
					return "PreviousMonth";
				case MacrosType.CURRENT_MONTH:
					return "CurrentMonth";
				case MacrosType.NEXT_MONTH:
					return "NextMonth";
				case MacrosType.PREVIOUS_QUARTER:
					return "PreviousQuarter";
				case MacrosType.CURRENT_QUARTER:
					return "CurrentQuarter";
				case MacrosType.NEXT_QUARTER:
					return "NextQuarter";
				case MacrosType.PREVIOUS_HALF_YEAR:
					return "PreviousHalfYear";
				case MacrosType.CURRENT_HALF_YEAR:
					return "CurrentHalfYear";
				case MacrosType.NEXT_HALF_YEAR:
					return "NextHalfYear";
				case MacrosType.PREVIOUS_YEAR:
					return "PreviousYear";
				case MacrosType.CURRENT_YEAR:
					return "CurrentYear";
				case MacrosType.PREVIOUS_HOUR:
					return "PreviousHour";
				case MacrosType.CURRENT_HOUR:
					return "CurrentHour";
				case MacrosType.NEXT_HOUR:
					return "NextHour";
				case MacrosType.NEXT_YEAR:
					return "NextYear";
				case MacrosType.NEXT_N_DAYS:
					return "NextNDays";
				case MacrosType.PREVIOUS_N_DAYS:
					return "PreviousNDays";
				case MacrosType.NEXT_N_HOURS:
					return "NextNHours";
				case MacrosType.PREVIOUS_N_HOURS:
					return "PreviousNHours";
				case MacrosType.DAY_OF_YEAR_TODAY:
					return "DayOfYearToday";
				case MacrosType.DAY_OF_YEAR_TODAY_PLUS_DAYS_OFFSET:
					return "DayOfYearTodayPlusDaysOffset";
				case MacrosType.NEXT_N_DAYS_OF_YEAR:
					return "NextNDaysOfYear";
				case MacrosType.PREVIOUS_N_DAYS_OF_YEAR:
					return "PreviousNDaysOfYear";
				default:
					throw new BPMSoft.exceptions.UnsupportedTypeException({
						message: "Converting expression with macros type " + macrosType +
							" is not supported"
					});
			}
		},

		/**
		 * @private
		 * @param {Number} datePartType Date part type.
		 * @return {String}
		 */
		_getServerDatePartType: function (datePartType) {
			const DatePartType = BPMSoft.DatePartType;
			switch (datePartType) {
				case DatePartType.DAY:
					return "DayOfMonth";
				case DatePartType.WEEK_DAY:
					return "DayOfWeek";
				case DatePartType.HOUR:
					return "Hour";
				case DatePartType.HOUR_MINUTE:
					return "HourMinute";
				case DatePartType.MONTH:
					return "Month";
				case DatePartType.YEAR:
					return "Year";
				default:
					return null;
			}
		},

		/**
		 * @private
		 * @param {Number} dataValueTypeValue Data value type value
		 * @returns {String}
		 */
		_getServerFilterDataValueTypeName: function (dataValueTypeValue) {
			const serverDataValueTypeNames = Object.keys(BPMSoft.ServerDataValueTypeName);
			for (let i = 0; i < serverDataValueTypeNames.length; i++) {
				if (BPMSoft.ServerDataValueTypeName[serverDataValueTypeNames[i]] === dataValueTypeValue) {
					return serverDataValueTypeNames[i];
				}
			}
			throw new BPMSoft.exceptions.UnsupportedTypeException({
				message: "Converting expression with data value type " + dataValueTypeValue +
					" is not supported"
			});
		},

		/**
		 * @private
		 * @param {String} dataValueTypeName Converter filter data value name.
		 * @return {*}
		 */
		_getFilterDataValueEditor: function (dataValueTypeName) {
			switch (dataValueTypeName) {
				case "DateTime":
					return {
						controlTypeName: "DateTimeEdit",
						controlXType: "datetimeedit",
						defaultConfiguration: '{kind:"datetime"}'
					};
				case "Date":
					return {
						controlTypeName: "DateTimeEdit",
						controlXType: "datetimeedit",
						defaultConfiguration: '{kind:"date"}'
					};
				case "Time":
					return {
						controlTypeName: "DateTimeEdit",
						controlXType: "datetimeedit",
						defaultConfiguration: '{kind:"time"}'
					};
				case "Integer":
					return {
						controlTypeName: "IntegerEdit",
						controlXType: "integeredit"
					};
				case "Boolean":
					return {
						controlTypeName: "CheckBox",
						controlXType: "checkbox"
					};
				case "Lookup":
					return {
						controlTypeName: "LookupEdit",
						controlXType: "lookupedit"
					};
				case "Float":
				case "Float1":
				case "Float2":
				case "Float3":
				case "Float4":
				case "Money":
					return {
						controlTypeName: "FloatEdit",
						controlXType: "floatedit"
					};
				default:
					return {
						controlTypeName: "TextEdit",
						controlXType: "textedit"
					};
			}
		},

		/**
		 * @private
		 * @param {Number} dataValueType Filter config data value type.
		 * @return {*}
		 */
		_getFilterDataValueType: function (dataValueType) {
			if (isNaN(dataValueType)) {
				return null;
			}
			const id = BPMSoft.convertToServerDataValueType(dataValueType);
			const name = this._getServerFilterDataValueTypeName(dataValueType);
			const isNumeric = BPMSoft.isNumberDataValueType(dataValueType);
			const editor = this._getFilterDataValueEditor(name);
			return {
				id: id,
				name: name,
				isNumeric: isNumeric,
				editor: editor,
				useClientEncoding: true
			};
		},

		/**
		 * @private
		 * @param {Object} filterConfig Filter config.
		 * @return {Boolean}
		 */
		_getIsInFilter: function (filterConfig) {
			const dataValueType = this._getFilterDataValueType(filterConfig.dataValueType);
			return (dataValueType.name === "Lookup" &&
				(!filterConfig.rightExpression || !filterConfig.rightExpression.macrosType));
		},

		/**
		 * @private
		 * @param {String} metaPath Column metaPath.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @param {Object} obj Object, which property should be updated after metaPath resolving.
		 * @param {String} propertyName Name of the property, which should be updated after metaPath resolving.
		 */
		_addColumnPath: function (metaPath, metaPathMapping, parentItemKey, obj,
		                          propertyName) {
			const entitySchemaMapping = metaPathMapping[parentItemKey];
			if (!entitySchemaMapping) {
				throw new BPMSoft.exceptions.ItemNotFoundException();
			}
			entitySchemaMapping.columnPaths.push({
				metaPath: metaPath,
				obj: obj,
				propertyName: propertyName
			});
		},

		/**
		 * @private
		 * @param {Object} parameterValue Parameter value config.
		 * @param {Object} parameterValue.parameter Parameter.
		 * @param {String} parameterValue.parameterValue Value parameter value.
		 * @param {String} parameterValue.parameter.value Value parameter value.
		 * @param {String} dataValueType Data value type.
		 * @return {Object}
		 */
		_getDateTimeParameterExpressionValue: function (parameterValue, dataValueType) {
			if (!parameterValue) {
				return null;
			}
			const parameter = parameterValue.parameterValue || parameterValue.parameter.value;
			if (!parameter) {
				throw new BPMSoft.exceptions.InvalidFormatException({
					message: "Data parameter value should be exist"
				});
			}
			const day = parameter.getDate();
			const month = parameter.getMonth();
			const year = parameter.getFullYear();
			const hour = parameter.getHours();
			const minute = parameter.getMinutes();
			const format = dataValueType === "Time" ? BPMSoft.Resources.CultureSettings.timeFormat :
				BPMSoft.Resources.CultureSettings.dateFormat;
			let displayValue = Ext.Date.format(parameter, format);
			return {
				displayValue: Ext.htmlEncode('"' + displayValue + '"'),
				parameterValue: "new Date(" + year + "," + month + "," + day + "," + hour + "," + minute + ",0)"
			};
		},

		/**
		 * @private
		 * @param {Object} parameterValue Parameter value config.
		 * @param {Object} parameterValue.parameter Parameter
		 * @param {String} parameterValue.parameter.value Value parameter value.
		 * @param {String} parameterValue.parameter.displayValue Value parameter display value.
		 * @return {Object}
		 */
		_getLookupParameterExpressionValue: function (parameterValue) {
			const value = JSON.parse(Ext.htmlDecode(parameterValue.parameter.value));
			const displayValue = JSON.parse(Ext.htmlDecode(parameterValue.parameter.displayValue));
			return {
				value: value,
				displayValue: displayValue
			};
		},

		_escapeJSONInvalidCharacters:  function (value) {
			return value.replace(/\\/g, '\\\\').replace(/"/g, '\\"');
		},

		/**
		 * @private
		 * @param {Object} parameterValue Parameter value config.
		 * @param {Object} parameterValue.parameter Parameter
		 * @param {String} parameterValue.parameter.displayValue Value parameter display value.
		 * @param {String} parameterValue.parameter.value Value parameter value.
		 * @param {String} parameterValue.parameterValue Value parameter value.
		 * @param {String} dataValueType Data value type.
		 * @return {String|Date|Number|Object}
		 */
		_getParameterExpressionValue: function (parameterValue, dataValueType) {
			if (!parameterValue) {
				return null;
			}
			const value = parameterValue.parameterValue || parameterValue.parameter.value;
			switch (dataValueType) {
				case"Lookup":
					return this._getLookupParameterExpressionValue(parameterValue);
				case "DateTime":
				case "Date":
				case "Time":
					return this._getDateTimeParameterExpressionValue(parameterValue, dataValueType);
				case "Float":
				case "Float1":
				case "Float2":
				case "Float3":
				case "Float4":
				case "Integer":
				case "Money":
					return {
						displayValue: Ext.htmlEncode('"' + value + '"'),
						parameterValue: value
					};
				case "Guid":
					return {
						displayValue: Ext.htmlEncode('"' + value + '"'),
						parameterValue: '\"' + value + '\"'
					};
				case "Boolean":
					return {
						parameterValue: value.toString()
					};
				default:
					return {
						displayValue: Ext.htmlEncode('"' + this._escapeJSONInvalidCharacters(value) + '"'),
						parameterValue: Ext.htmlEncode('"' + this._escapeJSONInvalidCharacters(value) + '"')
					};
			}
		},

		/**
		 * @private
		 * @param {Object} config Item config.
		 * @return {String}
		 */
		_getRootSchemaName: function (config) {
			return !config.rootSchemaName ? this._getRootSchemaName(config.parentCollection) :
				config.rootSchemaName;
		},

		/**
		 * @private
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} dataValueType Data value type.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {Object} expression Expression for adding reference schema.
		 */
		_addReferenceSchema: function (filterConfig, dataValueType, referenceSchemaMapping,
		                               expression) {
			if (dataValueType.name === "Lookup") {
				const rootSchema = this._getRootSchemaName(filterConfig);
				if (referenceSchemaMapping[rootSchema]) {
					const lookup = {
						obj: expression
					};
					referenceSchemaMapping[rootSchema].expressions.push(lookup);
				}
			}
		},

		/**
		 * @private
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createColumnExpression: function (filterConfig, metaPathMapping,
		                                   referenceSchemaMapping, parentItemKey) {
			const dataValueType = this._getFilterDataValueType(filterConfig.dataValueType);
			const expression = {
				expressionType: "SchemaColumn",
				caption: filterConfig.leftExpressionCaption,
				dataValueType: dataValueType
			};
			this._addReferenceSchema(filterConfig, dataValueType, referenceSchemaMapping, expression);
			this._addColumnPath(filterConfig.leftExpression.columnPath, metaPathMapping, parentItemKey, expression,
				"metaPath");
			return expression;
		},

		/**
		 * @private
		 * @param {Number} dataValueType Group data value type.
		 * @param {Object} expressionConfig Expression config.
		 * @return {Object}
		 */
		_createParameterExpression: function (dataValueType, expressionConfig) {
			let parameterDataType = "Text";
			if (!isNaN(dataValueType)) {
				parameterDataType = this._getServerFilterDataValueTypeName(dataValueType);
			}
			const dataValueTypeValue = this._getFilterDataValueType(dataValueType);
			const parameterValue = this._getParameterExpressionValue(expressionConfig, parameterDataType);
			return {
				expressionType: "Parameter",
				dataValueType: dataValueTypeValue,
				parameterValues: [parameterValue]
			};
		},

		/**
		 * @private
		 * @param {Object} subFilters Aggregation sub filters.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {String} parentItemKey Parent item key.
		 */
		_addSubFiltersColumnPath: function (subFilters, metaPathMapping, parentItemKey) {
			if (!subFilters) {
				return;
			}
			for (let i = 0; i < subFilters.length; i++) {
				const subFilter = subFilters[i];
				if (subFilter._isFilter) {
					this._addColumnPath(subFilter.leftExpression.columnPath, metaPathMapping, parentItemKey,
						subFilter.leftExpression, "metaPath");
				} else {
					this._addSubFiltersColumnPath(subFilter.collection, metaPathMapping, parentItemKey);
				}
			}
		},

		/**
		 * @private.
		 * @param {Object} expressionConfig Expression config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @return {Object}
		 */
		_getAggregationSubFilters: function (expressionConfig, metaPathMapping,
		                                     referenceSchemaMapping, parentItemKey) {
			let subFilters;
			if (expressionConfig.subFilters) {
				subFilters = this._convertFilterGroup(expressionConfig.subFilters, metaPathMapping,
					referenceSchemaMapping, "");
			} else {
				subFilters = this._convertFilterGroup(expressionConfig.functionArgument.subFilters, metaPathMapping,
					referenceSchemaMapping, "");
			}
			this._addSubFiltersColumnPath(subFilters, metaPathMapping, parentItemKey);
			return subFilters;
		},

		/**
		 * @private
		 * @param {Object} config Parameters.
		 * @param {Object} config.filter Converter filter.
		 * @param {Object} config.filterConfig Filter config.
		 * @param {Object} config.expressionConfig Expression config.
		 * @param {Object} config.metaPathMapping MetaPath mapping object.
		 * @param {String} config.parentItemKey Parent item key.
		 * @param {Object} config.referenceSchemaMapping Lookup reference schema mapping object.
		 * @return {Object}
		 */
		_createAggregationExpression: function (config) {
			const filter = config.filter;
			const metaPathMapping = config.metaPathMapping;
			const filterConfig = config.filterConfig;
			const parentItemKey = config.parentItemKey;
			const expressionConfig = config.expressionConfig;
			const referenceSchemaMapping = config.referenceSchemaMapping;
			if (!filter.subFilters) {
				filter["subFilters"] = this._getAggregationSubFilters(expressionConfig, metaPathMapping,
					referenceSchemaMapping, parentItemKey);
			}
			const dataValueType = this._getFilterDataValueType(filterConfig.dataValueType);
			const expression = {
				expressionType: "Aggregation",
				caption: filterConfig.leftExpressionCaption,
				dataValueType: dataValueType
			};
			if (expressionConfig.aggregationType) {
				expression["aggregationType"] = this._getServerAggregationType(expressionConfig.aggregationType);
			}
			const columnPath = expressionConfig.columnPath ||
				expressionConfig.functionArgument.columnPath;
			if (columnPath) {
				this._addColumnPath(columnPath, metaPathMapping, parentItemKey,
					expression, "metaPath");
			}
			return expression;
		},

		/**
		 * @private
		 * @param {Number} dataValueType Group data value type.
		 * @param {Object} expressionConfig Expression config.
		 * @param {String} datePartType Date part type.
		 * @return {Object}
		 */
		_createMacrosExpression: function (dataValueType, expressionConfig, datePartType) {
			const expression = {
				expressionType: "Macros"
			};
			let parameterDataType;
			let dataValueTypeValue = this._getFilterDataValueType(dataValueType);
			expression["macrosType"] = datePartType ? datePartType :
				this._getServerMacrosType(expressionConfig.macrosType);
			const functionArgument = expressionConfig.functionArgument;
			let parameterValues = [];
			if (functionArgument && functionArgument.parameter) {
				parameterDataType = this._getServerFilterDataValueTypeName(functionArgument.parameter.dataValueType);
				const parameterValue = this._getParameterExpressionValue(functionArgument,
					parameterDataType);
				parameterValues.push(parameterValue);
				dataValueTypeValue = this._getFilterDataValueType(functionArgument.parameter.dataValueType);
			}
			const parameter = expressionConfig.parameter;
			if (parameter) {
				parameterDataType = this._getServerFilterDataValueTypeName(parameter.dataValueType);
				const parameterValue = this._getParameterExpressionValue(expressionConfig,
					parameterDataType);
				parameterValues.push(parameterValue);
				dataValueTypeValue = this._getFilterDataValueType(parameter.dataValueType);
			}
			expression["dataValueType"] = dataValueTypeValue;
			if (parameterValues.length > 0) {
				expression["parameterValues"] = parameterValues;
			}
			return expression;
		},

		/**
		 * @private
		 * @param {Object} filter Converter filter.
		 * @param {Object} filterConfig Expression config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createDatePartExpression: function (filter, filterConfig, metaPathMapping,
		                                     referenceSchemaMapping, parentItemKey) {
			const leftExpression = filterConfig.leftExpression;
			let expression;
			if (filterConfig.isAggregative) {
				expression = this._createAggregationExpression({
					filter: filter,
					parentItemKey: parentItemKey,
					metaPathMapping: metaPathMapping,
					filterConfig: filterConfig,
					referenceSchemaMapping: referenceSchemaMapping,
					expressionConfig: filterConfig.leftExpression
				});
			} else {
				const dataValueType = this._getFilterDataValueType(filterConfig.dataValueType);
				expression = {
					expressionType: "SchemaColumn",
					caption: filterConfig.leftExpressionCaption,
					dataValueType: dataValueType
				};
				this._addReferenceSchema(filterConfig, dataValueType, referenceSchemaMapping, expression);
				const columnPath = leftExpression.functionArgument.columnPath;
				if (columnPath) {
					this._addColumnPath(columnPath, metaPathMapping, parentItemKey, expression,
						"metaPath");
				}
			}

			return expression;
		},

		/**
		 * @private
		 * @param {Number} value Parameter value.
		 * @param {String} datePartType Date part type
		 * @return {Number}
		 */
		_resolveDayOfWeek: function(value, datePartType) {
			if(datePartType === "DayOfWeek") {
				return --value;
			}
			return value;
		},

		/**
		 * @private
		 * @param {Object} config Config.
		 * @param {Object} config.filterConfig Filter config.
		 * @param {Object} config.metaPathMapping MetaPath mapping object.
		 * @param {Object} config.expressionConfig Expression config.
		 * @param {String} config.datePartType Date part type.
		 * @param {Object} config.referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} config.parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createExpression: function (config) {
			const filterConfig = config.filterConfig;
			const datePartType = config.datePartType;
			const parentItemKey = config.parentItemKey;
			const metaPathMapping = config.metaPathMapping;
			const expressionConfig = config.expressionConfig;
			const referenceSchemaMapping = config.referenceSchemaMapping;
			const expressionType = expressionConfig.expressionType;
			let dataValueType;
			if (expressionConfig.parameter && expressionConfig.parameter.dataValueType) {
				dataValueType = expressionConfig.parameter.dataValueType;
				expressionConfig.parameter.value = this._resolveDayOfWeek(expressionConfig.parameter.value, datePartType);
			} else {
				dataValueType = filterConfig.dataValueType;
				expressionConfig.parameterValue = this._resolveDayOfWeek(expressionConfig.parameterValue, datePartType);
			}
			switch (expressionConfig.expressionType) {
				case this.expressionTypes.column:
					return this._createColumnExpression(filterConfig, metaPathMapping, referenceSchemaMapping,
						parentItemKey);
				case  this.expressionTypes.macros:
					return this._createMacrosExpression(dataValueType, expressionConfig, datePartType);
				case  this.expressionTypes.parameter:
					return this._createParameterExpression(dataValueType, expressionConfig);
				default:
					throw new BPMSoft.exceptions.UnsupportedTypeException({
						message: "Converting expression of type " + expressionType + " is not supported"
					});
			}
		},

		/**
		 * @private
		 * @param {Object} rightExpressions Right expressions.
		 * @return {Object}
		 */
		_createExpressions: function (rightExpressions) {
			const dataValueType = this._getFilterDataValueType(rightExpressions[0].parameter.dataValueType);
			const expression = {
				expressionType: "Parameter",
				dataValueType: dataValueType,
				parameterValues: []
			};
			for (let i = 0; i < rightExpressions.length; i++) {
				const rightExpression = rightExpressions[i];
				const escapedDisplayValue = this._escapeJSONInvalidCharacters(rightExpression.parameter.value.displayValue);
				const escapedParameterValue = this._escapeJSONInvalidCharacters(rightExpression.parameter.value.value);
				expression.parameterValues.push({
					displayValue: Ext.htmlEncode('"' + escapedDisplayValue + '"'),
					parameterValue: Ext.htmlEncode('"' + escapedParameterValue + '"')
				});
			}
			return expression;
		},

		/**
		 * @private
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createCompareFilter: function (filterConfig, metaPathMapping, referenceSchemaMapping,
		                                parentItemKey) {
			let rightExpression;
			if (filterConfig.rightExpression) {
				rightExpression = this._createExpression({
					filterConfig: filterConfig,
					metaPathMapping: metaPathMapping,
					parentItemKey: parentItemKey,
					referenceSchemaMapping: referenceSchemaMapping,
					expressionConfig: filterConfig.rightExpression
				});
			}
			return {
				rightExpression: rightExpression
			};
		},

		/**
		 * @private
		 * @param {Object} filterConfig Filter config.
		 * @return {Object}
		 */
		_createInFilter: function (filterConfig) {
			let rightExpression;
			if (filterConfig.rightExpressions) {
				rightExpression = this._createExpressions(filterConfig.rightExpressions);
			}
			return {
				rightExpression: rightExpression
			};
		},

		/**
		 * Creates exists filter.
		 * @private
		 * @param {String} comparisonType Comparison type.
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createExistsFilter: function (comparisonType, filterConfig, metaPathMapping,
		                               referenceSchemaMapping, parentItemKey) {
			let rightExpression;
			if (filterConfig.leftExpression) {
				rightExpression = this._createColumnExpression(filterConfig, metaPathMapping,
					referenceSchemaMapping, parentItemKey);
			}
			const subFilters = this._convertFilterGroup(filterConfig.subFilters, metaPathMapping,
				referenceSchemaMapping, "");
			this._addSubFiltersColumnPath(subFilters, metaPathMapping, parentItemKey);
			return {
				rightExpression: rightExpression,
				comparisonType: comparisonType,
				subFilters: subFilters,
				finished: true
			};
		},

		/**
		 * Creates InnerJoin filter.
		 * @private
		 * @param {String} comparisonType Comparison type.
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createInnerJoinFilter: function (comparisonType, filterConfig, metaPathMapping,
		                               referenceSchemaMapping, parentItemKey) {
			let rightExpression;
			if (filterConfig.leftExpression) {
				rightExpression = this._createColumnExpression(filterConfig, metaPathMapping,
					referenceSchemaMapping, parentItemKey);
			}
			const subFilters = this._convertFilterGroup(filterConfig.subFilters, metaPathMapping,
				referenceSchemaMapping, "");
			this._addSubFiltersColumnPath(subFilters, metaPathMapping, parentItemKey);
			return {
				rightExpression: rightExpression,
				comparisonType: comparisonType,
				subFilters: subFilters,
				finished: true
			};
		},

		/**
		 * @private
		 * @param {String} comparisonType Comparison type.
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_convertFilterByComparisonType: function (comparisonType, filterConfig, metaPathMapping,
		                                          referenceSchemaMapping, parentItemKey) {
			let filter;
			switch (comparisonType) {
				case "Equal":
				case "NotEqual":
				case "Less":
				case "LessOrEqual":
				case "Greater":
				case "GreaterOrEqual":
				case "StartWith":
				case "NotStartWith":
				case "Contain":
				case "NotContain":
				case "EndWith":
				case "NotEndWith":
					if (this._getIsInFilter(filterConfig)) {
						filter = this._createInFilter(filterConfig);
					} else {
						filter = this._createCompareFilter(filterConfig, metaPathMapping, referenceSchemaMapping,
							parentItemKey);
					}
					break;
				case "IsNull":
				case "IsNotNull":
					filter = {};
					break;
				case "Exists":
				case "NotExists":
					filter = this._createExistsFilter(comparisonType, filterConfig, metaPathMapping,
						referenceSchemaMapping, parentItemKey);
					break;
				case "InnerJoin":
				case "LeftExclusive":
					filter = this._createInnerJoinFilter(comparisonType, filterConfig, metaPathMapping,
						referenceSchemaMapping, parentItemKey);
					break;
				default:
					throw new BPMSoft.exceptions.UnsupportedTypeException({
						message: "Converting filter with comparisonType " + comparisonType + " is not supported"
					});
			}
			return filter;
		},

		/**
		 * @private
		 * @param {Object} config Parameters.
		 * @param {String} config.filter Converter filter.
		 * @param {String} config.comparisonType Comparison type.
		 * @param {Object} config.filterConfig Filter config.
		 * @param {Object} config.metaPathMapping MetaPath mapping object.
		 * @param {String} config.parentItemKey Parent item key.
		 * @param {Object} config.referenceSchemaMapping Lookup reference schema mapping object.
		 * @return {Object} If item is datePart type filter, returns new datePart
		 * function compare filter. Otherwise returns null.
		 */
		_createDatePartFunctionFilter: function (config) {
			const filter = config.filter;
			const filterConfig = config.filterConfig;
			const comparisonType = config.comparisonType;
			const metaPathMapping = config.metaPathMapping;
			const parentItemKey = config.parentItemKey;
			const referenceSchemaMapping = config.referenceSchemaMapping;
			if (!filterConfig || !filterConfig.leftExpression) {
				return null;
			}
			let datePartType = this._getServerDatePartType(filterConfig.leftExpression.datePartType);
			if (!datePartType) {
				return null;
			}
			const leftExpression = this._createDatePartExpression(filter, filterConfig,
				metaPathMapping, referenceSchemaMapping, parentItemKey);
			let rightExpression;
			if (filterConfig.rightExpression) {
				filterConfig.rightExpression.expressionType = filterConfig.leftExpression.expressionType;
				rightExpression = this._createExpression({
					filterConfig: filterConfig,
					parentItemKey: parentItemKey,
					datePartType: datePartType,
					metaPathMapping: metaPathMapping,
					referenceSchemaMapping: referenceSchemaMapping,
					expressionConfig: filterConfig.rightExpression
				});
			}
			return {
				leftExpression: leftExpression,
				comparisonType: comparisonType,
				rightExpression: rightExpression
			};
		},

		/**
		 * @private
		 * @param {Object} config Parameters.
		 * @param {Object} config.filter Converter filter..
		 * @param {Object} config.filterConfig Filter config.
		 * @param {Object} config.expression Filter expression.
		 * @param {Object} config.metaPathMapping MetaPath mapping object.
		 * @param {Object} config.referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} config.parentItemKey Parent item key.
		 * @return {Object}
		 */
		_createLeftExpression: function (config) {
			const filter = config.filter;
			const expression = config.expression;
			const filterConfig = config.filterConfig;
			const parentItemKey = config.parentItemKey;
			const metaPathMapping = config.metaPathMapping;
			const referenceSchemaMapping = config.referenceSchemaMapping;
			if (!expression.leftExpression && filterConfig.leftExpression &&
				!expression.finished) {
				if (filterConfig.isAggregative) {
					return this._createAggregationExpression({
						filter: filter,
						parentItemKey: parentItemKey,
						metaPathMapping: metaPathMapping,
						filterConfig: filterConfig,
						referenceSchemaMapping: referenceSchemaMapping,
						expressionConfig: filterConfig.leftExpression
					});
				} else {
					if (filterConfig.rightExpression && filterConfig.rightExpression.parameter &&
						filterConfig.rightExpression.parameter.dataValueType) {
						filter.dataValueType = filterConfig.rightExpression.parameter.dataValueType;
					}
					return this._createExpression({
						filterConfig: filterConfig,
						parentItemKey: parentItemKey,
						metaPathMapping: metaPathMapping,
						referenceSchemaMapping: referenceSchemaMapping,
						expressionConfig: filterConfig.leftExpression
					});
				}
			}
			return expression.leftExpression;
		},

		/**
		 * @private
		 * @param {Object} filterConfig Filter config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} parentItemKey Parent item key.
		 * @return {Object}
		 */
		_convertFilter: function (filterConfig, metaPathMapping, referenceSchemaMapping,
		                          parentItemKey) {
			const comparisonType = this._getServerComparisonType(filterConfig.comparisonType);
			let filter = {
				_isFilter: true,
				uId: filterConfig.key || BPMSoft.utils.guid.generateGUID()
			};
			if (filterConfig.trimDateTimeParameterToDate) {
				this._setPropertyIfValueDefined(filter, "trimDateTimeParameterToDate",
					filterConfig.trimDateTimeParameterToDate);
			}
			if (!filterConfig.isEnabled) {
				this._setPropertyIfValueDefined(filter, "isEnabled", filterConfig.isEnabled);
			}
			let expression = this._createDatePartFunctionFilter({
				filter: filter,
				comparisonType: comparisonType,
				filterConfig: filterConfig,
				metaPathMapping: metaPathMapping,
				referenceSchemaMapping: referenceSchemaMapping,
				parentItemKey: parentItemKey
			});
			if (!expression) {
				expression = this._convertFilterByComparisonType(comparisonType, filterConfig, metaPathMapping,
					referenceSchemaMapping, parentItemKey);
			}
			if (!expression) {
				throw new BPMSoft.exceptions.UnsupportedTypeException({
					message: "Current filter conversion is not supported"
				});
			}
			filter.leftExpression = this._createLeftExpression({
				filter: filter,
				expression: expression,
				filterConfig: filterConfig,
				parentItemKey: parentItemKey,
				metaPathMapping: metaPathMapping,
				referenceSchemaMapping: referenceSchemaMapping
			});
			if (expression.subFilters) {
				filter["subFilters"] = expression.subFilters;
			}
			filter.comparisonType = comparisonType;
			filter.rightExpression = expression.rightExpression;
			return filter;
		},

		/**
		 * @private
		 * @param {String} uId Guid group uid.
		 * @param {String} name Group name.
		 * @return {Object}
		 */
		_createNewGroup: function (uId, name) {
			return {
				_isFilter: false,
				uId: uId,
				name: name,
				items: []
			}
		},

		/**
		 * @private
		 * @param {BPMSoft.FilterGroup} groupConfig Filter group config.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {String} groupName Group name.
		 * @return {Object}
		 */
		_convertFilterGroup: function (groupConfig, metaPathMapping,
		                               referenceSchemaMapping, groupName) {
			if (!groupConfig) {
				return this._createNewGroup(BPMSoft.utils.guid.generateGUID(), groupName);
			}
			const uId = groupConfig.key || BPMSoft.utils.guid.generateGUID();
			let filterGroup = this._createNewGroup(uId, groupName);
			if (groupConfig.logicalOperation !== undefined &&
				groupConfig.logicalOperation === BPMSoft.LogicalOperatorType.OR) {
				filterGroup.logicalOperation = "Or";
			}
			const configItems = groupConfig.getItems();
			let filter, rootSchemaName;
			for (let i = 0; i < configItems.length; i++) {
				let filterConfig = configItems[i];
				rootSchemaName = filterConfig.parentCollection.rootSchemaName;
				if (rootSchemaName && !referenceSchemaMapping[rootSchemaName]) {
					referenceSchemaMapping[rootSchemaName] = {
						expressions: [],
						propertyName: "referenceSchemaUId",
					};
				}
				if (filterConfig.collection) {
					filter = this._convertFilterGroup(filterConfig, metaPathMapping,
						referenceSchemaMapping, "");
					filterGroup.items.push(filter);
					continue;
				}
				if (rootSchemaName && !metaPathMapping[uId]) {
					metaPathMapping[uId] = {
						rootSchemaName: rootSchemaName,
						propertyName: "_filterSchemaUId",
						obj: filterGroup,
						columnPaths: []
					};
				}

				filter = this._convertFilter(filterConfig, metaPathMapping, referenceSchemaMapping, uId);
				filterGroup.items.push(filter);
			}
			return filterGroup;
		},

		/**
		 * @private
		 * @param {[{Key: String, Value: String[]}]} columnMetaPathKeyValues Key-value object, where key is uid of
		 * entity schema and value is array of this schema's column meta paths.
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		_requestColumnPaths: function (columnMetaPathKeyValues,
		                               metaPathMapping, callback, scope) {
			ServiceHelper.callService({
				serviceName: "EntityFilterConverterService",
				methodName: "GetMetaPathsAndEntityNames",
				data: {columnMetaPaths: columnMetaPathKeyValues},
				callback: function (response, success) {
					if (!success || !response) {
						callback(scope);
						return;
					}
					const resolvedPaths = response.columnPaths.reduce(function (previousValue, currentValue) {
						previousValue[currentValue.Key] = currentValue.Value;
						return previousValue;
					}, {});
					for (let groupKey in metaPathMapping) {
						if (!metaPathMapping.hasOwnProperty(groupKey)) {
							continue;
						}
						const groupMapping = metaPathMapping[groupKey];
						groupMapping.rootSchemaName = resolvedPaths[groupMapping.rootSchemaName];
						const columnPaths = groupMapping.columnPaths;
						for (let i = 0, length = columnPaths.length; i < length; i++) {
							const columnMapping = columnPaths[i];
							columnMapping.columnPath = resolvedPaths[columnMapping.metaPath];
						}
					}
					callback.call(scope);
				}
			});
		},

		/**
		 * @private
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		_resolveEntitySchemaMetaPaths: function (metaPathMapping, callback, scope) {
			let columnMetaPathsKeyValues = [];
			for (let groupKey in metaPathMapping) {
				if (!metaPathMapping.hasOwnProperty(groupKey)) {
					continue;
				}
				const groupMapping = metaPathMapping[groupKey];
				const key = groupMapping.rootSchemaName;
				let value = [];
				const columnPaths = groupMapping.columnPaths;
				for (let i = 0, length = columnPaths.length; i < length; i++) {
					const columnMapping = columnPaths[i];
					value.push(columnMapping.metaPath);
				}
				let existingItem = BPMSoft.findWhere(columnMetaPathsKeyValues, {Key: key});
				if (existingItem) {
					existingItem.Value = existingItem.Value.concat(value);
				} else {
					columnMetaPathsKeyValues.push({
						Key: key,
						Value: value
					});
				}
			}
			this._requestColumnPaths(columnMetaPathsKeyValues, metaPathMapping, callback, scope);
		},

		/**
		 * @private
		 * @param {Object} metaPathMapping MetaPath mapping object.
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		_fillColumnPaths: function (metaPathMapping, referenceSchemaMapping, callback, scope) {
			this._resolveEntitySchemaMetaPaths(metaPathMapping, function () {
				for (let groupKey in metaPathMapping) {
					if (!metaPathMapping.hasOwnProperty(groupKey)) {
						continue;
					}
					const groupMapping = metaPathMapping[groupKey];
					const groupMappingFilters = groupMapping.obj.items;
					for (let i = 0, length = groupMappingFilters.length; i < length; i++) {
						let filter = groupMappingFilters[i];
						if (filter._isFilter) {
							filter[groupMapping.propertyName] = groupMapping.rootSchemaName;
						}
					}
					const columnPaths = groupMapping.columnPaths;
					for (let i = 0, length = columnPaths.length; i < length; i++) {
						let columnMapping = columnPaths[i];
						columnMapping.obj[columnMapping.propertyName] = columnMapping.columnPath;
					}
				}
				this._resolveReferenceSchemasUId(referenceSchemaMapping, function () {
					callback.call(scope);
				}, this);
			}, scope);
		},

		/**
		 * @private
		 * @param {[{Key: String, Value: String[]}]} columnMetaSchemaKeyValues Key-value object, where key is root
		 * schema name of entity schema and value is array of this schema's column meta paths.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		_requestColumnReferenceUId: function (columnMetaSchemaKeyValues, callback, scope) {
			ServiceHelper.callService({
				serviceName: "EntityFilterConverterService",
				methodName: "GetColumnReferenceSchemaUIds",
				data: {columnMetaSchema: columnMetaSchemaKeyValues},
				callback: function (response, success) {
					if (!success || !response) {
						callback.call(scope, []);
						return;
					}
					const resolvedPaths = response.columnMetaSchema.reduce(function (previousValue, currentValue) {
						previousValue[currentValue.Key] = currentValue.Value;
						return previousValue;
					}, {});
					callback.call(scope, resolvedPaths);
				}
			});
		},

		/**
		 * @private
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @return {Array}
		 */
		_getColumnMetaSchemaValues: function (referenceSchemaMapping) {
			let columnMetaSchemaValues = [];
			for (let groupKey in referenceSchemaMapping) {
				if (!referenceSchemaMapping.hasOwnProperty(groupKey)) {
					continue;
				}
				const groupMapping = referenceSchemaMapping[groupKey];
				const expressions = groupMapping.expressions;
				let value = [];
				for (let i = 0, length = expressions.length; i < length; i++) {
					const expression = expressions[i];
					value.push(expression.obj.metaPath);
				}
				let existingItem = BPMSoft.findWhere(columnMetaSchemaValues, {Key: groupKey});
				if (existingItem) {
					existingItem.Value = existingItem.Value.concat(value);
				} else {
					columnMetaSchemaValues.push({
						Key: groupKey,
						Value: value
					});
				}
			}
			return columnMetaSchemaValues;
		},

		/**
		 * @private
		 * @param {Object} referenceSchemaMapping Lookup reference schema mapping object.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		_resolveReferenceSchemasUId: function (referenceSchemaMapping, callback, scope) {
			const columnMetaSchemaValues = this._getColumnMetaSchemaValues(referenceSchemaMapping);
			if (Object.keys(columnMetaSchemaValues).length > 0 &&
				columnMetaSchemaValues[0].Value.length > 0) {
				this._requestColumnReferenceUId(columnMetaSchemaValues, function (resolvedPaths) {
					for (let groupKey in referenceSchemaMapping) {
						if (!referenceSchemaMapping.hasOwnProperty(groupKey)) {
							continue;
						}
						const groupMapping = referenceSchemaMapping[groupKey];
						const expressions = groupMapping.expressions;
						for (let i = 0, length = expressions.length; i < length; i++) {
							const expression = expressions[i];
							const key = expression.obj.metaPath;
							expression.obj[groupMapping.propertyName] = resolvedPaths[key];
						}
					}
					callback.call(scope);
				}, scope);
			} else {
				callback.call(scope);
			}
		},

		// endregion

		//region Methods: Public

		/**
		 * Convert 7x filter into 5x filter.
		 * @param {BPMSoft.FilterGroup} filterGroup 7x filter group.
		 * @param {Function} callback Callback function.
		 * @param {String} callback JSON with converter filters.
		 * @param {Object} scope Callback function scope.
		 */
		convert: function (filterGroup, callback, scope) {
			if (!filterGroup) {
				callback("");
				return;
			}
			let metaPathMapping = [], referenceSchemaMapping = [];
			const converterFilterGroup = this._convertFilterGroup(filterGroup, metaPathMapping,
				referenceSchemaMapping, "FilterEdit");
			this._fillColumnPaths(metaPathMapping, referenceSchemaMapping, function () {
				callback(Ext.JSON.encode(converterFilterGroup));
			}, scope || this);
		}

		//endregion
	});

	return BPMSoft.FilterConverterConnector;
});
