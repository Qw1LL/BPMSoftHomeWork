define("ChartModuleHelper", ["ChartModuleHelperResources", "DashboardEnums"], function(resources) {

	/**
	 * @class BPMSoft.configuration.ChartModuleHelper
	 * Class of chart module helper.
	 */
	Ext.define("BPMSoft.configuration.ChartModuleHelper", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.ChartModuleHelper",

		//region Properties: Public

		/**
		 * Chart series kind.
		 * @type {Object}
		 */
		ChartSeriesKind: null,

		//endregion

		//region Methods: Private

		/**
		 * Returns aggregation eval type.
		 * @param {Number} funcType Type of aggregation function.
		 * @return {BPMSoft.AggregationEvalType} Aggregation eval type.
		 */
		addEvalTypeToAggregationFunc: function(funcType) {
			return funcType === BPMSoft.AggregationType.COUNT
				? BPMSoft.AggregationEvalType.DISTINCT
				: BPMSoft.AggregationEvalType.NONE;
		},

		/**
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
		 * @param {String} columnName Column name.
		 * @param {Number} direction Order direction.
		 * @param {Number} position Order position.
		 */
		addOrderByProperties: function(esq, columnName, direction, position) {
			var column = esq.columns.find(columnName);
			if (!column) {
				column = esq.addColumn(columnName);
			}
			column.orderDirection = direction;
			column.orderPosition = position;
		},

		/**
		 * @private
		 * @param {Array} formats Date time formats.
		 * @return {Array} Ordered date time formats.
		 */
		sortDateTimeFormats: function(formats) {
			var allSortedFormats = ["Year", "Month", "Week", "Day", "Hour"];
			return allSortedFormats.filter(function(format) {
				return BPMSoft.contains(formats, format);
			}, this);
		},

		//endregion

		//region Methods: Protected

		/**
		 * Adds ordered column to query.
		 * @param {Object} config Configuration object.
		 */
		addOrderBy: function(config) {
			var orderByConfig = config.orderBy;
			if (orderByConfig) {
				switch (orderByConfig.chartOrderType) {
					case BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD:
						if (BPMSoft.isDateDataValueType(config.xAxis.dataValueType)) {
							var formats = this.sortDateTimeFormats(config.xAxis.dateTimeFormat);
							BPMSoft.each(formats, function(format, position) {
								this.addOrderByProperties(config.entitySchemaQuery, format, orderByConfig.direction,
									position);
							}, this);
						} else {
							this.addOrderByProperties(config.entitySchemaQuery, "xAxis", orderByConfig.direction, 0);
						}
						break;
					case BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN:
						this.addOrderByProperties(config.entitySchemaQuery, "yAxis", orderByConfig.direction, 0);
						break;
					case BPMSoft.DashboardEnums.ChartOrderBy.CUSTOM_COLUMN:
						this.addOrderByProperties(config.entitySchemaQuery, orderByConfig.orderColumn,
							orderByConfig.direction, 0);
						break;
					default:
						break;
				}
			}
		},

		/**
		 * Adds grouped column to query.
		 * @protected
		 * @virtual
		 * @param {Object} config Configuration object.
		 * @param {BPMSoft.EntitySchemaQuery} config.entitySchemaQuery Data query for chart.
		 * @param {String} config.xAxis.column X-axis column.
		 * @param {String} config.xAxis.dataValueType X-axis column data type.
		 * @param {String} config.xAxis.dateTimeFormat X-axis column date format.
		 * @param {String} config.order.by Ordered field.
		 * @param {String} config.order.direction Order direction.
		 */
		addGroupColumn: function(config) {
			var groupByColumns = [];
			var entitySchemaQuery = config.entitySchemaQuery;
			var xAxisColumn = config.xAxis.column;
			var xAxisColumnDataValueType = config.xAxis.dataValueType;
			if (!BPMSoft.isDateDataValueType(xAxisColumnDataValueType)) {
				groupByColumns.push(entitySchemaQuery.addColumn(xAxisColumn, "xAxis"));
			} else {
				var datePartOrderSequence = ["Year", "Month", "Week", "Day", "Hour"];
				var xAxisColumnDateTimeFormat = config.xAxis.dateTimeFormat;
				BPMSoft.each(datePartOrderSequence, function(datePart) {
					if (BPMSoft.contains(xAxisColumnDateTimeFormat, datePart)) {
						var datePartType = this.getDatePartType(datePart);
						groupByColumns.push(
							entitySchemaQuery.addDatePartFunctionColumn(xAxisColumn, datePartType, datePart));
					}
				}, this);
			}
		},

		/**
		 * Adds aggregation column to query.
		 * @protected
		 * @virtual
		 * @param {Object} config Configuration object.
		 * @param {BPMSoft.EntitySchemaQuery} config.entitySchemaQuery Data query for chart.
		 * @param {String} config.func Aggregation function name.
		 * @param {String} config.yAxis.column Y-axis column.
		 * @param {String} config.order.by Ordered field.
		 * @param {String} config.order.direction Order direction.
		 */
		addAggregationColumn: function(config) {
			var entitySchemaQuery = config.entitySchemaQuery;
			var aggregationType = config.func;
			var aggregationColumnName = config.yAxis.column;
			var aggregationFuncEvalType = this.addEvalTypeToAggregationFunc(aggregationType);
			entitySchemaQuery.addAggregationSchemaColumn(aggregationColumnName, aggregationType, "yAxis",
				aggregationFuncEvalType);
		},

		/**
		 * Adds drill down filters to query.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.EntitySchemaQuery} entitySchemaQuery Data query for chart.
		 * @param {BPMSoft.BaseFilter} filters Drill down filters.
		 */
		addDrillDownFilters: function(entitySchemaQuery, filters) {
			BPMSoft.each(filters, function(filter, columnName) {
				if (!filter.datePart) {
					if (filter.isNull) {
						var nullFilter = BPMSoft.createColumnIsNullFilter(columnName);
						entitySchemaQuery.filters.addItem(nullFilter);
					} else {
						var filterValue = filter && (filter.value || filter);
						var esqfilter = BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, columnName, filterValue);
						entitySchemaQuery.filters.addItem(esqfilter);
					}
				} else {
					BPMSoft.each(filter.datePart, function(value, name) {
						var datePartType = this.getDatePartType(name);
						var esqfilter = BPMSoft.createDatePartColumnFilter(
							BPMSoft.ComparisonType.EQUAL, columnName, datePartType, value);
						entitySchemaQuery.filters.addItem(esqfilter);
					}, this);
				}
			}, this);
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			var localizableStrings = resources.localizableStrings;
			var localizableImages = resources.localizableImages;
			this.ChartSeriesKind = {
				spline: {
					value: "spline",
					displayValue: localizableStrings.SplineCaption,
					imageConfig: localizableImages.SplineImage
				},
				line:  {
					value: "line",
					displayValue: localizableStrings.LineCaption,
					imageConfig: localizableImages.LineImage
				},
				bar:  {
					value: "bar",
					displayValue: localizableStrings.BarCaption,
					imageConfig: localizableImages.BarImage
				},
				pie:  {
					value: "pie",
					displayValue: localizableStrings.PieCaption,
					imageConfig: localizableImages.PieImage
				},
				areaspline:  {
					value: "areaspline",
					displayValue: localizableStrings.AreasplineCaption,
					imageConfig: localizableImages.AreasplineImage
				},
				funnel:  {
					value: "funnel",
					displayValue: localizableStrings.FunnelCaption,
					imageConfig: localizableImages.FunnelImage
				},
				column:  {
					value: "column",
					displayValue: localizableStrings.ColumnCaption,
					imageConfig: localizableImages.ColumnImage
				},
				scatter:  {
					value: "scatter",
					displayValue: localizableStrings.ScatterCaption,
					imageConfig: localizableImages.ScatterImage
				}
			};
		},

		/**
		 * Returns chart type.
		 * @param {String} kind Kind of chart.
		 * @return {String} Chart type.
		 */
		getChartType: function(kind) {
			switch (kind) {
				case "0":
					return "area";
				case "1":
					return "line";
				case "2":
					return "bar";
				case "3":
					return "pie";
				case "4":
					return "column";
				case "5":
					return "scatter";
				default:
					return "line";
			}
		},

		/**
		 * Returns aggregation function type.
		 * @param {String} name Function name.
		 * @return {BPMSoft.AggregationType} Aggregation function type.
		 */
		getAggregationType: function(name) {
			switch (name) {
				case "Count":
					return BPMSoft.AggregationType.COUNT;
				case "Max":
					return BPMSoft.AggregationType.MAX;
				case "Min":
					return BPMSoft.AggregationType.MIN;
				case "Avg":
					return BPMSoft.AggregationType.AVG;
				case "Sum":
					return BPMSoft.AggregationType.SUM;
			}
			return BPMSoft.AggregationType.NONE;
		},

		/**
		 * Returns date part value.
		 * @param {String} name String date part value.
		 * @return {BPMSoft.DatePartType} Date part value.
		 */
		getDatePartType: function(name) {
			switch (name) {
				case "Year":
					return BPMSoft.DatePartType.YEAR;
				case "Month":
					return BPMSoft.DatePartType.MONTH;
				case "Week":
					return BPMSoft.DatePartType.WEEK;
				case "Day":
					return BPMSoft.DatePartType.DAY;
				case "Hour":
					return BPMSoft.DatePartType.HOUR;
			}
			return BPMSoft.DatePartType.NONE;
		},

		/**
		 * Adds filters to query.
		 * @param {Object} config Configuration object.
		 * @param {BPMSoft.EntitySchemaQuery} config.entitySchemaQuery Data query for chart.
		 * @param {String} config.xAxis.column X-axis column.
		 * @param {BPMSoft.BaseFilter} config.filters.quickFilters Quick section filter.
		 * @param {BPMSoft.BaseFilter} config.filters.chartFilters Chart filters.
		 * @param {BPMSoft.BaseFilter} config.filters.serializedFilters Serialized filters.
		 * @param {BPMSoft.BaseFilter} config.filters.drillDownFilters Drill down filter.
		 */
		addFilters: function(config) {
			var entitySchemaQuery = config.entitySchemaQuery;
			var filters = config.filters;
			var quickFilters = filters.quickFilters;
			var entitySchemaQueryFilters = entitySchemaQuery.filters;
			if (quickFilters && !quickFilters.isEmpty()) {
				entitySchemaQueryFilters.add("quickFilters", quickFilters);
			}
			var chartFilters = filters.chartFilters;
			if (chartFilters && !chartFilters.isEmpty()) {
				entitySchemaQueryFilters.add("chartFilters", chartFilters);
			}
			var serializedFilters = filters.serializedFilters;
			if (serializedFilters && !serializedFilters.isEmpty()) {
				entitySchemaQueryFilters.add("serializedFilters", serializedFilters);
			}
			var columnIsNotNullFilters = filters.columnIsNotNullFilters;
			if (columnIsNotNullFilters) {
				entitySchemaQueryFilters.add("columnIsNotNullFilter", columnIsNotNullFilters);
			}
			this.addDrillDownFilters(entitySchemaQuery, filters.drillDownFilters);
		},

		/**
		 * Returns data query of chart series.
		 * @param {Object} config Configuration object.
		 * @param {String} config.entitySchemaName Entity schema name.
		 * @param {String} config.func Aggregation function name.
		 * @param {Object} config.xAxis X-axis column options.
		 * @param {String} config.xAxis.column X-axis column.
		 * @param {BPMSoft.DataValueType} config.xAxis.dataValueType X-axis column data type.
		 * @param {String[]} config.xAxis.dateTimeFormat X-axis column dateTime format.
		 * @param {String} config.yAxis.column Y-axis column.
		 * @param {Object} config.filters Filter options.
		 * @param {BPMSoft.BaseFilter} config.filters.quickFilters Quick section filters.
		 * @param {BPMSoft.BaseFilter} config.filters.chartFilters Chart filters.
		 * @param {BPMSoft.BaseFilter} config.filters.serializedFilters Serialized filters.
		 * @param {BPMSoft.BaseFilter} config.filters.drillDownFilters Drill down filters.
		 * @return {BPMSoft.EntitySchemaQuery} Data query for chart.
		 */
		getSeriesQuery: function(config) {
			var entitySchemaName = config.entitySchemaName;
			if (!entitySchemaName) {
				return null;
			}
			var entitySchemaQuery = config.entitySchemaQuery = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: entitySchemaName,
				queryKind: BPMSoft.QueryKind.LIMITED
			});
			this.addGroupColumn(config);
			this.addAggregationColumn(config);
			this.addFilters(config);
			this.addOrderBy(config);
			return entitySchemaQuery;
		}

		//endregion
	});

	return Ext.create("BPMSoft.ChartModuleHelper");
});
