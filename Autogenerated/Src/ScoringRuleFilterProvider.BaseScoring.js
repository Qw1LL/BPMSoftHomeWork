define("ScoringRuleFilterProvider", ["EntitySchemaFilterProviderModule"],
	function() {

		/**
		 * @class BPMSoft.data.filters.ScoringRuleFilterProvider
		 * Filter provider of the scoring rule.
		 */
		Ext.define("BPMSoft.data.filters.ScoringRuleFilterProvider", {
			extend: "BPMSoft.EntitySchemaFilterProvider",
			alternateClassName: "BPMSoft.ScoringRuleFilterProvider",
			sandbox: null,
			dataValueTypeAggregationFunction: {},

			/**
			 * @inheritdoc BPMSoft.EntitySchemaFilterProvider#getAllowedAggregationOperations
			 * @overridden
			 */
			getAllowedAggregationOperations: function(filter) {
				var leftExpression = filter.leftExpression;
				var isExistsFilter = (filter.filterType === BPMSoft.FilterType.EXISTS);
				var isAggregationTypeCount = (leftExpression.aggregationType === BPMSoft.AggregationType.COUNT);
				if (isExistsFilter || isAggregationTypeCount) {
					var result = [];
					result.push(this.getComparisonTypeCaption(BPMSoft.ComparisonType.EXISTS));
					result.push(this.getComparisonTypeCaption(BPMSoft.ComparisonType.NOT_EXISTS));
					return result;
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.EntitySchemaFilterProvider#getAllowedMacrosTypes
			 * @overridden
			 */
			getAllowedMacrosTypes: function() {
				return [];
			},

			/**
			 * @inheritdoc BPMSoft.EntitySchemaFilterProvider#getLeftExpressionConfig
			 * @overridden
			 */
			getLeftExpressionConfig: function() {
				var config = this.callParent(arguments);
				config.useExists = true;
				config.useCount = false;
				config.displayId = false;
				config.aggregatedDataValueTypes = [];
				return config;
			}
		});

		return BPMSoft.ScoringRuleFilterProvider;
	});
