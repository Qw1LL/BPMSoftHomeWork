define("AngularWidgetConfigConverter", ["DashboardEnums", "WidgetEnums", "WidgetConfigConverter"], function() {

	Ext.define("BPMSoft.configuration.AngularWidgetConfigConverter", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.AngularWidgetConfigConverter",

		statics: {

			/**
			 * @private
			 */
			_angularToExtSeriesTypeMapping: {
				'area': 'areaspline',
				'bar': 'column',
				'doughnut': 'pie',
				'horizontal-bar': 'bar',
				'line': 'line',
				'scatter': 'scatter',
				'spline': 'spline',
				'tsfunnel': 'funnel',
			},

			/**
			 * @param {AngularIndicatorWidgetConfig} angularConfig
			 * @return {ExtIndicatorWidgetConfig}
			 */
			toExtIndicatorWidgetConfig: function(angularConfig) {
				if (!angularConfig) {
					return {};
				}
				const textConfig = angularConfig.text || {};
				const dataProvidingConfig = angularConfig.data?.providing || {};
				return {
					...this._toExtIndicatorFiltersConfig(dataProvidingConfig.filters),
					...this._toExtIndicatorAggregationConfig(dataProvidingConfig.aggregation),
					caption: angularConfig.title,
					style: angularConfig.layout?.color,
					indicatorTheme: angularConfig.theme,
					entitySchemaName: dataProvidingConfig.schemaName,
					format: this._toExtIndicatorFormat(angularConfig),
					fontStyle: textConfig.fontSizeMode,
				};
			},

			/**
			 * @param {AngularWidgetConfig} angularWidgetConfig
			 * @return {ExtWidgetConfig}
			 */
			toExtChartWidgetConfig: function(angularWidgetConfig) {
				if (this._isEmpty(angularWidgetConfig)) {
					return {};
				}
				const angularSeries = angularWidgetConfig.series || [];
				const firstSeries = angularSeries[0] || {};
				const filterItems = BPMSoft
					.findValueByPath(firstSeries, "data.providing.filters.filter.items");
				const useEmptyValue = filterItems && Boolean(filterItems.columnIsNotNullFilter) === false;
				return {
					...this._toExtOrderConfig(angularWidgetConfig.seriesOrder),
					...this._toExtSeriesConfig(angularSeries.shift()),
					...this._toExtScalesConfig(angularWidgetConfig.scales),
					caption: angularWidgetConfig.title,
					widgetColor: this._toExtStyleColor(angularWidgetConfig.color),
					widgetTheme: angularWidgetConfig?.theme,
					seriesConfig: angularSeries.map(series => this._toExtSeriesConfig(series)),
					useEmptyValue,
					dateTimeFormat: this._getDateTimeFormat(firstSeries),
				};
			},

			/**
			 * @param {AngularFunnelWidgetConfig} angularConfig
			 * @return {ExtFunnelWidgetConfig}
			 */
			toExtFunnelWidgetConfig: function(angularConfig) {
				if (!angularConfig) {
					return {};
				}
				return {
					caption: angularConfig.title,
					widgetColor: this._toExtStyleColor(angularConfig?.color),
					widgetTheme: angularConfig?.theme,
					entities: angularConfig.entities?.map((entity) => {
						const filters = this._toExtSeriesFilters(entity.filters || {
							filterType: BPMSoft.FilterType.FILTER_GROUP,
							isEnabled: true,
							items: {},
							logicalOperation: BPMSoft.LogicalOperatorType.AND,
							rootSchemaName: entity.schemaName
						});
						return {
							schemaName: entity.schemaName,
							calculatedOperations: entity.calculatedOperations,
							connectedWith: entity.connectedWith,
							filters: JSON.stringify(filters)
						}
					})
				};
			},

			/**
			 * @param {Object} angularFiltersConfig
			 * @private
			 */
			_toExtIndicatorFiltersConfig: function(angularFiltersConfig) {
				const filterGroup = angularFiltersConfig?.filter;
				const extFilterGroup = filterGroup && this._toExtSeriesFilters(filterGroup);
				return {
					filterData: JSON.stringify(extFilterGroup),
				};
			},

			/**
			 * @param {Object}  angularAggregationConfig
			 * @private
			 */
			_toExtIndicatorAggregationConfig: function(angularAggregationConfig) {
				const aggregationExpression = angularAggregationConfig?.column?.expression || {};
				const aggregationType = aggregationExpression.aggregationType || BPMSoft.AggregationType.COUNT;
				const aggregationColumn = aggregationExpression.functionArgument?.columnPath;
				const aggregationConfig = {
					aggregationType: aggregationType
				};
				if(aggregationType !== BPMSoft.AggregationType.COUNT) {
					aggregationConfig.columnName = aggregationColumn;
				}
				return aggregationConfig;
			},

			/**
			 * @param {AngularIndicatorWidgetConfig} 
			 * @private
			 */
			 _toExtIndicatorFormat: function(angularConfig) {
				const textConfig = angularConfig.text || {};
				const textDecorator = textConfig.template || "{0}";
				const formattingConfig = angularConfig.data?.formatting || {};
				switch(formattingConfig.type) {
					case "number":
						return {
							textDecorator,
							decimalSeparator: formattingConfig.decimalSeparator,
							decimalPrecision: formattingConfig.decimalPrecision,
							thousandSeparator: formattingConfig.thousandSeparator,
						};
					case "datetime":
						const dateTimeFromat = formattingConfig.format;
						let convertedDateTimeFormat = dateTimeFromat
							&& BPMSoft.WidgetConfigConverter.convertDateTimeFormat(dateTimeFromat, "moment", "ext");
						if (!dateTimeFromat) {
							let format = BPMSoft.Resources.CultureSettings.dateFormat;
							if (formattingConfig?.time?.display) {
								format += ' ' + BPMSoft.Resources.CultureSettings.timeFormat
							}
							convertedDateTimeFormat = format;
						}
						return {
							textDecorator,
							dateFormat: convertedDateTimeFormat || BPMSoft.Resources.CultureSettings.dateFormat,
						};
					default:
						return { textDecorator };
				}
			},

			/**
			 * @param {SeriesConfig} angularScales
			 * @private
			 */
			_toExtScalesConfig: function(angularScales) {
				angularScales = angularScales || {};
				return {
					isStackedChart: angularScales.stacked,
					xAxisFormatting: angularScales.xAxis?.formatting,
					yAxisFormatting: angularScales.yAxis?.formatting,
					xAxisDefaultCaption: angularScales.xAxis?.name,
					yAxisDefaultCaption: angularScales.yAxis?.name,
				};
			},

			/**
			 * @param {SeriesConfig} firstSeries
			 * @private
			 */
			_getDateTimeFormat: function(firstSeries) {
				const datePartColumns = firstSeries?.data?.providing?.grouping?.column;
				if (Array.isArray(datePartColumns)) {
					return datePartColumns
						.map(column => {
							for (const [key, value] of Object.entries(BPMSoft.DatePartType)) {
								if (value === column.expression.datePartType) {
									const datePart = key.toLowerCase().split("");
									datePart[0] = datePart[0].toUpperCase();
									return datePart.join("");
								}
							}
						})
						.join(";");
				}
			},

			/**
			 * @param {Object|null|undefined} val
			 * @return {boolean}
			 * @private
			 */
			_isEmpty: function(val) {
				return Boolean(val) === false || JSON.stringify(val) === JSON.stringify({});
			},

			/**
			 * @private
			 * @param {SeriesOrderConfig} seriesOrder
			 * @return {{orderBy: String, orderDirection: String}}
			 */
			_toExtOrderConfig: function(seriesOrder) {
				if (!seriesOrder) {
					return {};
				}
				const orderDirection = seriesOrder && seriesOrder.direction === 1
					? BPMSoft.DashboardEnums.ChartOrderDirection.ASCENDING
					: BPMSoft.DashboardEnums.ChartOrderDirection.DESCENDING;
				if (seriesOrder.type === "by-grouping-value") {
					return {
						orderBy: BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD,
						orderDirection,
					};
				}
				if (seriesOrder.type === "by-aggregation-value") {
					return {
						orderBy: `${BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN}:${seriesOrder.seriesIndex}`,
						orderDirection,
					};
				}
			},

			/**
			 * @private
			 * @param {SeriesConfig} angularSeries
			 * @return {ExtSeriesConfig}
			 */
			_toExtSeriesConfig: function(angularSeries) {
				if (!angularSeries) {
					return {};
				}
				const dataConfig = angularSeries?.data;
				const dataProvidingConfig = dataConfig?.providing;
				const aggregationExpression = dataProvidingConfig?.aggregation?.column?.expression;
				const aggregationType = aggregationExpression?.aggregationType || BPMSoft.AggregationType.COUNT;
				const aggregationColumn = aggregationExpression?.functionArgument?.columnPath;
				const filterGroup = dataProvidingConfig?.filters && dataProvidingConfig?.filters?.filter;
				const extSeries = {
					filterData: filterGroup && JSON.stringify(this._toExtSeriesFilters(filterGroup)),
					format: this._toExtFormat(dataConfig?.formatting),
					func: aggregationType,
					isLegendEnabled: Boolean(angularSeries?.legend?.enabled),
					primaryColumnName: "Id",
					schemaName: dataProvidingConfig?.schemaName,
					styleColor: this._toExtStyleColor(angularSeries?.color),
					type: this._angularToExtSeriesTypeMapping[angularSeries?.type],
					xAxisColumn: this._getXAxisColumn(dataProvidingConfig?.grouping?.column),
					yAxisConfig: { position: 0 },
					YAxisCaption: angularSeries.label
				};
				if (aggregationType !== BPMSoft.AggregationType.COUNT) {
					extSeries.yAxisColumn = aggregationColumn;
				}
				return extSeries;
			},

			/**
			 * @private
			 * @param {Object} angularNumberFormat
			 * @return {Object}
			 */
			_toExtFormat: function(angularNumberFormat) {
				angularNumberFormat = angularNumberFormat || {};
				return {
					type: 4,
					decimalSeparator: angularNumberFormat.decimalSeparator,
					decimalPrecision: angularNumberFormat.decimalPrecision,
					thousandSeparator: angularNumberFormat.thousandSeparator,
				};
			},

			/**
			 * @param {Object} column
			 * @return {String}
			 * @private
			 */
			_getXAxisColumn: function(column) {
				if (Array.isArray(column)) {
					const firstColumn = [...column].shift();
					return firstColumn?.expression?.functionArgument?.columnPath;
				}
				return column?.expression?.columnPath;
			},

			/**
			 * @param {Object} filterGroup
			 * @return {Object}
			 * @private
			 */
			_toExtSeriesFilters: function(filterGroup) {
				if (this._isEmpty(filterGroup)) {
					return {};
				}
				delete filterGroup?.items.columnIsNotNullFilter;
				this._addExtPropertiesToFilter(filterGroup);
				return filterGroup;
			},

			/**
			 * @param {Object} filter
			 * @private
			 */
			_addExtPropertiesToFilter: function(filter) {
				switch (filter?.filterType) {
					case BPMSoft.FilterType.BETWEEN:
						filter.className = `BPMSoft.BetweenFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						this._addExtPropertiesToExpression(filter.rightLessExpression);
						this._addExtPropertiesToExpression(filter.rightGreaterExpression);
						break;
					case BPMSoft.FilterType.COMPARE:
						filter.className = `BPMSoft.CompareFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						this._addExtPropertiesToExpression(filter.rightExpression);
						break;
					case BPMSoft.FilterType.EXISTS:
						filter.className = `BPMSoft.ExistsFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						this._addExtPropertiesToFilter(filter.subFilters);
						break;
					case BPMSoft.FilterType.FILTER_GROUP:
						filter.className = `BPMSoft.FilterGroup`;
						for (const [, innerFilter] of Object.entries(filter.items || {})) {
							this._addExtPropertiesToFilter(innerFilter);
						}
						break;
					case BPMSoft.FilterType.IN:
						filter.className = `BPMSoft.InFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						filter.rightExpressions
							.forEach(expression => this._addExtPropertiesToExpression(expression))
						break;
					case BPMSoft.FilterType.IS_NULL:
						filter.className = `BPMSoft.IsNullFilter`;
						this._addExtPropertiesToExpression(filter.leftExpression);
						break;
				}
			},

			/**
			 * @param {BPMSoft.BaseExpression} expression
			 * @private
			 */
			_addExtPropertiesToExpression: function(expression) {
				switch (expression?.expressionType) {
					case BPMSoft.ExpressionType.SCHEMA_COLUMN:
						expression.className = "BPMSoft.ColumnExpression";
						break;
					case BPMSoft.ExpressionType.PARAMETER:
						expression.className = "BPMSoft.ParameterExpression";
						if (expression.parameter) {
							expression.parameter.className = "BPMSoft.Parameter";
						}
						if (expression.parentFilter) {
							this._addExtPropertiesToFilter(expression.parentFilter);
						}
						break;
					case BPMSoft.ExpressionType.ARITHMETIC_OPERATION:
						expression.className = "BPMSoft.ArithmeticExpression";
						this._addExtPropertiesToExpression(expression.leftArithmeticOperand);
						this._addExtPropertiesToExpression(expression.rightArithmeticOperand);
						break;
					case BPMSoft.ExpressionType.FUNCTION:
						this._addExtFnPropertiesToExpression(expression);
						break;
					case BPMSoft.ExpressionType.SUBQUERY:
						if (expression.functionType === BPMSoft.FunctionType.AGGREGATION) {
							expression.className = "BPMSoft.AggregationQueryExpression";
						}
						if (expression.functionType === BPMSoft.FunctionType.NONE) {
							expression.className = "BPMSoft.SubQueryExpression";
						}
						if (expression.subFilters) {
							this._addExtPropertiesToFilter(expression.subFilters);
						}
						break;
				}
			},

			/**
			 * @param {BPMSoft.BaseExpression} expression
			 * @private
			 */
			_addExtFnPropertiesToExpression: function(expression) {
				switch (expression?.functionType) {
					case BPMSoft.FunctionType.DATE_ADD:
						expression.className = "BPMSoft.DateAddFunctionExpression";
						this._addExtPropertiesToExpression(expression?.numberExpression);
						this._addExtPropertiesToExpression(expression?.dateTimeExpression);
						break;
					case BPMSoft.FunctionType.DATE_DIFF:
						expression.className = "BPMSoft.DateDiffFunctionExpression";
						this._addExtPropertiesToExpression(expression?.startDateExpression);
						this._addExtPropertiesToExpression(expression?.endDateExpression);
						break;
					default:
						expression.className = "BPMSoft.FunctionExpression";
				}
				if (expression.functionArgument) {
					this._addExtPropertiesToExpression(expression.functionArgument);
				}
				if (expression.functionArguments) {
					expression.functionArguments
						.forEach(functionArgument => this._addExtPropertiesToExpression(functionArgument))
				}
			},

			/**
			 * @param {String} angularStyleColor HEX color
			 * @private
			 */
			_toExtStyleColor: function(angularStyleColor) {
				const colors = BPMSoft.WidgetEnums.WidgetColorSet;
				const defaultColor = colors[0];
				const selectedColor = colors.find(color => color === angularStyleColor);
				return selectedColor || defaultColor;
			}
		},
	});
	return BPMSoft.AngularWidgetConfigConverter;
});
