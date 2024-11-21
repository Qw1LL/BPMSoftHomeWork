define("ProcessDesignerFilterEditFilter", [], function () {
	/**
	 * Class for item of filter edit control for Process designer.
	 */
	Ext.define("BPMSoft.controls.ProcessFilterEditFilter", {
		extend: "BPMSoft.FilterEdit.Filter",
		alternateClassName: "BPMSoft.ProcessDesignerFilterEditFilter",

		/**
		 * @inheritdoc BPMSoft.FilterEdit.Filter#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
		},

		/**
		 * Returns menu item for process parameter right expression menu.
		 * @private
		 * @return {Object} Menu item config.
		 */
		applyMenuItems: function(menuItems) {
			menuItems.unshift({
				caption: this.translate.SELECT_PARAMETER,
				handler: function() {
					var config = {
						filter: this.instance
					};
					this.filterEdit.fireEvent("prepareMappingParametersList", config,
						this.onProcessParameterSelected.bind(this, this.instance));
				}.bind(this)
			});
		},

		/**
		 * Handles callback after process parameter selected for right expression.
		 * @private
		 * @param {BPMSoft.data.filters.BaseFilter} filter Current filter.
		 * @param {Object} sourceValue Process schema parameter source value for filter right expression.
		 * @param {String} sourceValue.value Parameter source value.
		 * @param {String} sourceValue.displayValue Parameter source display value.
		 */
		onProcessParameterSelected: function(filter, sourceValue) {
			if (filter.filterType === BPMSoft.FilterType.IN) {
				sourceValue.Id = sourceValue.id || BPMSoft.generateGUID();
				this.filterManager.setRightExpressionsValues(filter, [sourceValue], BPMSoft.DataValueType.MAPPING);
				return;
			}
			this.filterManager.setRightExpressionValue(filter, sourceValue, null, BPMSoft.DataValueType.MAPPING);
		},

		getIsRightExpressionMenuAllowed: function() {
			return true;
		}
	});
});
