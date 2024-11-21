define("ExtWidgetConfigConverter", ["DashboardEnums", "WidgetEnums", "WidgetConfigConverter"], function() {

	//#region: Types AngularWidgetConfig

	/**
	 * @typedef ThousandAbbreviation
	 * @type {Object}
	 * @property {Boolean} enabled
	 */

	/**
	 * @typedef NumberFormat
	 * @type {Object}
	 * @property {String} decimalSeparator
	 * @property {Number} decimalPrecision
	 * @property {String} thousandSeparator
	 * @property {ThousandAbbreviation} thousandAbbreviation
	 */

	/**
	 * @typedef StringFormat
	 * @type {Object}
	 * @property {Number} maxLineLength
	 * @property {Number} maxLinesCount
	 * @property {String | RegExp} wordSeparator
	 * @property {String} wordConnector
	 */

	/**
	 * @typedef DateFormat
	 * @type {Object}
	 * @property {String} format
	 */
	 
	 /**
	 * @typedef WidgetDataProvidingConfig
	 * @type {Object}
	 * @property {String} schemaName
	 * @property {Object} aggregation
	 * @property {Object} [filters]
	 * @property {Object} [filters.filter]
	 */
	 
	 /**
	 * @typedef WidgetDataConfig
	 * @type {Object}
	 * @property {WidgetDataProvidingConfig} providing
	 * @property {NumberFormat} formatting
	 */

	/**
	 * @typedef SeriesDataProvidingConfig
	 * @type {Object}
	 * @property {String} schemaName
	 * @property {Number} rowCount
	 * @property {Object} grouping
	 * @property {Object} aggregation
	 * @property {Object} [filters]
	 * @property {Object} [filters.filter]
	 */

	/**
	 * @typedef SeriesDataConfig
	 * @type {Object}
	 * @property {SeriesDataProvidingConfig} providing
	 * @property {NumberFormat} formatting
	 */

	/**
	 * @typedef SeriesConfig
	 * @type {Object}
	 * @property {String} type - area | bar | line | etc.
	 * @property {String} label
	 * @property {Boolean} isLegendEnabled
	 * @property {SeriesDataConfig} data
	 */

	/**
	 * @typedef SeriesOrderConfig
	 * @type {Object}
	 * @property {String} type - AggregationColumn | GroupByColumn
	 * @property {Number} direction - None:0, Asc:1, Desc: 2
	 * @property {Number} [seriesIndex]
	 */

	/**
	 * @typedef Axis
	 * @type {Object}
	 * @property {String} name
	 * @property {NumberFormat | StringFormat} formatting
	 */

	/**
	 * @typedef Scale
	 * @type {Object}
	 * @property {Boolean} stacked
	 * @property {Axis} xAxis
	 * @property {Axis} yAxis
	 */

	/**
	 * @typedef AngularChartWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {Array<SeriesConfig>} series
	 * @property {SeriesOrderConfig} seriesOrder
	 * @property {Scale} scales
	 */

	/**
	 * @typedef AngularIndicatorWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {WidgetDataConfig} data
	 * @property {IndicatorText} text
	 * @property {IndicatorLayout} layout
	 */

	/**
	 * @typedef AngularFunnelWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {String} color
	 * @property {Object} entities
	 */

	/**
	 * @typedef IndicatorText
	 * @type {Object}
	 * @property {String} color
	 * @property {String} template
	 * @property {String} metricMacros
	 * @property {String} fontSizeMode - 'medium' | 'large'
	 */

	/**
	 * @typedef IndicatorLayout
	 * @type {Object}
	 * @property {String} color
	 */

	//#endregion

	//#region: Types ExtWidgetConfig

	/**
	 * @typedef ExtSeriesConfig
	 * @type {Object}
	 * @property {String} filterData
	 * @property {Object} format
	 * @property {Number} func
	 * @property {Boolean} isLegendEnabled
	 * @property {String} primaryColumnName - example: Id
	 * @property {String} schemaName
	 * @property {String} styleColor - example: widget-green
	 * @property {String} type - line | bar | etc.
	 * @property {String} xAxisColumn - example: Account
	 * @property {String} [yAxisColumn] - example: Age (if SUM function)
	 * @property {Object} yAxisConfig
	 * @property {String} [XAxisCaption]
	 * @property {String} [YAxisCaption]
	 */

	/**
	 * @typedef ExtChartWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} orderBy - GroupByField | ChartEntityColumn:[seriesIndex]
	 * @property {String} orderDirection - Ascending | Descending
	 * @property {Boolean} useEmptyValue
	 * @property {Boolean} isStackedChart
	 * @property {String} yAxisDefaultCaption
	 * @property {String} xAxisDefaultCaption
	 * @property {Array<ExtSeriesConfig>} seriesConfig
	 * @property {String} filterData
	 * @property {Object} format
	 * @property {Number} func
	 * @property {Boolean} isLegendEnabled
	 * @property {String|null} dateTimeFormat - example: Day;Month;Year
	 * @property {String} primaryColumnName - example: Id
	 * @property {String} schemaName
	 * @property {String} styleColor - example: widget-green
	 * @property {String} type - line | bar | etc.
	 * @property {String} xAxisColumn - example: Account
	 * @property {String} [yAxisColumn] - example: Age (if SUM function)
	 * @property {Object} yAxisConfig
	 * @property {String} [XAxisCaption]
	 * @property {String} [YAxisCaption]
	 */

	/**
	 * @typedef ExtIndicatorWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} filterData
	 * @property {String} columnName
	 * @property {Number} aggregationType
	 * @property {String} entitySchemaName
	 * @property {Object} format
	 * @property {String} style
	 * @property {String} fontStyle
	 */

	/**
	 * @typedef ExtFunnelWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} styleColor
	 * @property {Object} entities
	 */

	//#endregion

	Ext.define("BPMSoft.configuration.ExtWidgetConfigConverter", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.ExtWidgetConfigConverter",

		statics: {

			/**
			 * private
			 */
			_extToAngularSeriesTypeMapping: {
				'areaspline': 'area',
				'column': 'bar',
				'pie': 'doughnut',
				'bar': 'horizontal-bar',
				'line': 'line',
				'scatter': 'scatter',
				'spline': 'spline',
				'funnel': 'tsfunnel',
			},

			/**
			 * @param {ExtIndicatorWidgetConfig} extWidgetConfig
			 * @return {AngularIndicatorWidgetConfig}
			 */
			toAngularIndicatorWidgetConfig: function(extWidgetConfig) {
				return {
					title: extWidgetConfig.caption,
					data: {
						providing: {
							schemaName: extWidgetConfig.entitySchemaName,
							...this._toAngularAggregation({
								aggregationType: extWidgetConfig.aggregationType,
								columnPath: extWidgetConfig.columnName || "Id"
							}),
							...this._toAngularFilters({
								schemaName: extWidgetConfig.entitySchemaName,
								filterData: extWidgetConfig.filterData
							})
						},
						formatting: this._toAngularFormat(extWidgetConfig.format),
					},
					text: {
						template: extWidgetConfig.format?.textDecorator || '{0}',
						metricMacros: '{0}',
						fontSizeMode: extWidgetConfig.fontStyle
					},
					layout: {
						color: extWidgetConfig.style
					},
					theme: extWidgetConfig.indicatorTheme
				};
			},

			/**
			 * @param {ExtChartWidgetConfig} extWidgetConfig
			 * @return {AngularChartWidgetConfig}
			 */
			toAngularChartWidgetConfig: function(extWidgetConfig) {
				if (this._isEmpty(extWidgetConfig)) {
					return {};
				}
				const dateTimeFormat = extWidgetConfig.dateTimeFormat;
				const useEmptyValue = extWidgetConfig.useEmptyValue;
				return {
					title: extWidgetConfig.caption,
					color: extWidgetConfig.widgetColor,
					theme: extWidgetConfig.widgetTheme,
					scales: this._toAngularScales(extWidgetConfig),
					series: [
						this._toAngularSeries(extWidgetConfig, { dateTimeFormat, useEmptyValue }), // for first (in root) series
						...extWidgetConfig.seriesConfig.map(
							extSeries => this._toAngularSeries(extSeries, { dateTimeFormat, useEmptyValue }),
						),
					],
					seriesOrder: this._toAngularSeriesOrder(extWidgetConfig),
				};
			},

			/**
			 * @param {ExtFunnelWidgetConfig} extWidgetConfig
			 * @return {AngularFunnelWidgetConfig}
			 */
			toAngularFunnelWidgetConfig: function(extWidgetConfig) {
				if (this._isEmpty(extWidgetConfig)) {
					return {};
				}
				return {
					title: extWidgetConfig.caption,
					color: extWidgetConfig.widgetColor,
					theme: extWidgetConfig.widgetTheme,
					entities: extWidgetConfig.entities?.map((entity) => {
						const wrappedFilter = this._toAngularFilters({
							schemaName: entity.schemaName,
							filterData: entity.filters
						});
						return {
							schemaName: entity.schemaName,
							calculatedOperations: entity.calculatedOperations,
							connectedWith: entity.connectedWith,
							filters: wrappedFilter.filters.filter
						}
					})
				};
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
			 * @param {ExtChartWidgetConfig} extWidgetConfig
			 * @return {Scale}
			 * @private
			 */
			_toAngularScales: function(extWidgetConfig) {
				const defaultNumberFormat = {
					type: 'number',
					thousandAbbreviation: { enabled: true }
				};
				const defaultStringFormat = {
					type: 'string',
					maxLinesCount: 2,
					maxLineLength: 10,
				};
				return {
					stacked: extWidgetConfig.isStackedChart,
					xAxis: {
						name: extWidgetConfig.xAxisDefaultCaption || '',
						formatting: extWidgetConfig.xAxisFormatting || defaultStringFormat
					},
					yAxis: {
						name: extWidgetConfig.yAxisDefaultCaption || '',
						formatting: extWidgetConfig.yAxisFormatting || defaultNumberFormat
					}
				};
			},

			/**
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {Object} options
			 * @param {String|null} options.dateTimeFormat
			 * @param {Boolean} options.useEmptyValue
			 * @return {SeriesConfig}
			 * @private
			 */
			_toAngularSeries: function(seriesConfig, options) {
				const seriesColor = seriesConfig.styleColor;
				const defaultSeriesOptions = this._getDefaultAngularSeriesOptions(seriesConfig, options);
				switch(defaultSeriesOptions.type) {
					case 'area':
					case 'scatter':
					case 'line':
					case 'spline':
					case 'bar':
					case 'horizontal-bar':
						return {
							color: seriesColor,
							...defaultSeriesOptions,
						};
					case 'pie':
					case 'tsfunnel':
					case 'doughnut':
						return defaultSeriesOptions;
				};
			},

			/**
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {Object} options
			 * @param {String|null} options.dateTimeFormat
			 * @param {Boolean} options.useEmptyValue
			 * @return {SeriesConfig}
			 * @private
			 */
			_getDefaultAngularSeriesOptions: function(seriesConfig, options) {
				return {
					type: this._extToAngularSeriesTypeMapping[seriesConfig.type],
					label: seriesConfig.YAxisCaption || seriesConfig.schemaCaption || seriesConfig.schemaName,
					legend: {
						enabled: Boolean(seriesConfig.isLegendEnabled)
					},
					data: {
						providing: {
							schemaName: seriesConfig.schemaName,
							rowCount: seriesConfig.rowCount || 50,
							...this._toAngularSeriesGrouping(seriesConfig, options.dateTimeFormat),
							...this._toAngularSeriesAggregation(seriesConfig),
							...this._toAngularSeriesFilters(seriesConfig, options.useEmptyValue),
						},
						formatting: seriesConfig.format && this._toAngularNumberFormat(seriesConfig.format),
					},
				};
			},

			/**
			 * @param {Object} extFormat
			 * @return {Object}
			 * @private
			 */
			 _toAngularFormat(extFormat) {
				switch (extFormat.type) {
					case BPMSoft.DataValueType.INTEGER:
					case BPMSoft.DataValueType.FLOAT:
					case BPMSoft.DataValueType.MONEY:
						return this._toAngularNumberFormat(extFormat);
					case BPMSoft.DataValueType.TIME:
					case BPMSoft.DataValueType.DATE_TIME:
					case BPMSoft.DataValueType.DATE:
						return this._toAngularDateTimeFormat(extFormat);
				}
			},

			/**
			 * @param {Object} extFormat
			 * @return {NumberFormat}
			 * @private
			 */
			_toAngularNumberFormat: function(extFormat) {
				const cultureSettings = BPMSoft.Resources.CultureSettings;
				return {
					type: "number",
					decimalSeparator: extFormat.decimalSeparator || cultureSettings.decimalSeparator,
					decimalPrecision: extFormat.decimalPrecision,
					thousandSeparator: extFormat.thousandSeparator || cultureSettings.thousandSeparator,
				};
			},

			/**
			 * @param {Object} extFormat
			 * @return {DateFormat}
			 * @private
			 */
			 _toAngularDateTimeFormat: function(extFormat) {
				const extDateTimeFormat = extFormat.dateFormat || BPMSoft.Resources.CultureSettings.dateFormat;
				const isTimeDisplayEnabled = extDateTimeFormat.includes(BPMSoft.Resources.CultureSettings.timeFormat);
				const angularDateTimeFormat = {
					type: "datetime",
					date: {
						display: true,
					},
					time: {
						display: isTimeDisplayEnabled,
					},
				};
				return angularDateTimeFormat;
			},

			/**
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {String|null} dateTimeFormat
			 * @return {Object}
			 * @private
			 */
			_toAngularSeriesGrouping(seriesConfig, dateTimeFormat) {
				if (dateTimeFormat) {
					const dateFunctions = dateTimeFormat.split(";");
					return {
						grouping: {
							column: dateFunctions.map(dateFunction => {
								return {
									isVisible: true,
									expression: {
										functionType: BPMSoft.FunctionType.DATE_PART,
										datePartType: BPMSoft.DatePartType[dateFunction.toUpperCase()],
										expressionType: BPMSoft.ExpressionType.FUNCTION,
										functionArgument: {
											columnPath: seriesConfig.xAxisColumn,
											expressionType: BPMSoft.ExpressionType.SCHEMA_COLUMN,
										},
									},
								};
							}),
							type: "by-date-part",
						},
					};
				}
				return {
					grouping: {
						column: {
							expression: {
								expressionType: BPMSoft.ExpressionType.SCHEMA_COLUMN,
								columnPath: seriesConfig.xAxisColumn,
							},
						},
						type: "by-value",
					},
				};
			},

			/**
			 * @private
			 * @param {ExtChartWidgetConfig} extWidgetConfig
			 * @return {SeriesOrderConfig}
			 */
			_toAngularSeriesOrder: function(extWidgetConfig) {
				const direction =
					extWidgetConfig.orderDirection === BPMSoft.DashboardEnums.ChartOrderDirection.ASCENDING ? 1 : 2;
				if (extWidgetConfig.orderBy === BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD) {
					return {
						type: "by-grouping-value",
						direction: direction,
					};
				}
				const seriesIndex = extWidgetConfig.orderBy.split(":").pop();
				return {
					type: "by-aggregation-value",
					direction: direction,
					seriesIndex: parseInt(seriesIndex, 10),
				};
			},

			/**
			 * @private
			 * @param {ExtSeriesConfig} seriesConfig
			 * @return {Object}
			 */
			_toAngularSeriesAggregation: function(seriesConfig) {
				return this._toAngularAggregation({
					aggregationType: seriesConfig.func,
					columnPath: seriesConfig.yAxisColumn || seriesConfig.primaryColumnName
				});
			},

			/**
			 * @private
			 * @param {Object} config
			 * @param {BPMSoft.AggregationType} config.aggregationType
			 * @param {String} config.columnPath
			 * @return {Object}
			 */
			_toAngularAggregation: function(config) {
				return {
					aggregation: {
						column: {
							expression: {
								expressionType: BPMSoft.ExpressionType.FUNCTION,
								functionType: BPMSoft.FunctionType.AGGREGATION,
								aggregationType: config.aggregationType,
								aggregationEvalType: this._getAggregationEvalType(config.aggregationType),
								functionArgument: {
									expressionType: BPMSoft.ExpressionType.SCHEMA_COLUMN,
									columnPath: config.columnPath,
								},
							},
						},
					},
				};
			},

			/**
			 * @private
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {Boolean} useEmptyValue
			 * @return {Object}
			 */
			_toAngularSeriesFilters: function(seriesConfig, useEmptyValue) {
				let filters = this._toAngularFilters(seriesConfig);
				if (!useEmptyValue) {
					Object.assign(filters.filters.filter.items, this._getAngularColumnIsNotNullFilter(seriesConfig.xAxisColumn));
				}
				return filters;
			},

			/**
			 * @private
			 * @param {Object} config
			 * @param {String} config.schemaName
			 * @param {String} config.filterData
			 * @return {Object}
			 */
			_toAngularFilters: function(config) {
				const defaultFilterGroup = {
					className: "BPMSoft.FilterGroup",
					filterType: BPMSoft.FilterType.FILTER_GROUP,
					isEnabled: true,
					items: {},
					logicalOperation: BPMSoft.LogicalOperatorType.AND,
					rootSchemaName: config.schemaName,
				};
				const filter  = BPMSoft.deserialize(config.filterData || defaultFilterGroup);
				const ignoredKeys = ["className", "key", "leftExpressionCaption"];
				const filterJson = {};
				filter.serializationInfo = {serializeFilterManagerInfo: true};
				filter.getSerializableObject(filterJson, {});
				let filterDataNormalized = JSON.stringify(filterJson);
				ignoredKeys.forEach(ignoredKey => {
					const regex = new RegExp(`"${ignoredKey}":"[^"]*",`, "g");
					filterDataNormalized = filterDataNormalized.replace(regex, ``);
				});
				const filterGroup = JSON.parse(filterDataNormalized);
				return {
					filters: { filter: filterGroup },
				};
			},

			/**
			 * Use empty value filter.
			 * @param {String} columnPath
			 * @return {Object}
			 * @private
			 */
			_getAngularColumnIsNotNullFilter: function(columnPath) {
				return {
					columnIsNotNullFilter: {
						comparisonType: BPMSoft.ComparisonType.IS_NOT_NULL,
						filterType: BPMSoft.FilterType.IS_NULL,
						isEnabled: true,
						isNull: false,
						trimDateTimeParameterToDate: false,
						leftExpression: {
							expressionType: BPMSoft.ExpressionType.SCHEMA_COLUMN,
							columnPath: columnPath,
						},
					},
				};
			},

			/**
			 * @private
			 * @param {Number} aggregationType
			 * @return {BPMSoft.AggregationEvalType}
			 */
			_getAggregationEvalType: function(aggregationType) {
				return aggregationType === BPMSoft.AggregationType.COUNT
					? BPMSoft.AggregationEvalType.DISTINCT
					: BPMSoft.AggregationEvalType.NONE;
			},
		},
	});
	return BPMSoft.ExtWidgetConfigConverter;
});
