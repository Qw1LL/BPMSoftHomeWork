define("FilterUtilities", [], function() {
	Ext.define("BPMSoft.configuration.FilterUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.FilterUtilities",
		singleton: true,

		/**
		 * Returns an extended filter's display value.
		 * @param {BPMSoft.data.filters.FilterGroup} extendedFilter Filter value.
		 * @returns {string} Extended filter's display value.
		 */
		getExtendedFilterDisplayValue: function(extendedFilter) {
			const comparisonTypeFlipped = BPMSoft.invert(BPMSoft.ComparisonType);
			const logicalOperatorTypeFlipped = BPMSoft.invert(BPMSoft.LogicalOperatorType);
			let displayValue = "";
			// eslint-disable-next-line require-jsdoc
			function getComparisonDisplayValue(comparison) {
				const comparisonType = comparisonTypeFlipped[comparison];
				return BPMSoft.Resources.ComparisonType[comparisonType];
			}
			// eslint-disable-next-line require-jsdoc
			function getLogicalOperatorDisplayValue(operator) {
				const type = logicalOperatorTypeFlipped[operator];
				return BPMSoft.Resources.LogicalOperatorType[type];
			}
			// eslint-disable-next-line require-jsdoc
			function getDisplayValue(filter) {
				if (this.index++ > 0) {
					displayValue = displayValue + " " +
						getLogicalOperatorDisplayValue(this.logicalOperation) + " ";
				}
				if (filter.collection) {
					if (filter.collection.length > 0) {
						const innerScope = {
							level: this.level + 1,
							index: 0,
							logicalOperation: filter.logicalOperation,
							getDisplayValue: this.getDisplayValue
						};
						if (this.level !== 0) {
							displayValue = displayValue + "(";
						}
						filter.each(getDisplayValue, innerScope);
						if (this.level !== 0) {
							displayValue = displayValue + ")";
						}
					}
				} else {
					displayValue = displayValue + filter.leftExpressionCaption + " " +
						getComparisonDisplayValue(filter.comparisonType) + " " +
						BPMSoft.getRightExpressionDisplayValue(filter);
				}
			}

			const scope = {
				level: 0,
				index: 0,
				logicalOperation: 0,
				getDisplayValue: getDisplayValue
			};
			scope.getDisplayValue(extendedFilter);
			return displayValue;
		}

    });
});