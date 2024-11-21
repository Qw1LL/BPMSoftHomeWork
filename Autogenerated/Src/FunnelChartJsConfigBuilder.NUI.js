define("FunnelChartJsConfigBuilder", ["PieChartJsConfigBuilder"], function() {

	Ext.define("BPMSoft.configuration.FunnelChartJsConfigBuilder", {
		extend: "BPMSoft.PieChartJsConfigBuilder",
		alternateClassName: "BPMSoft.FunnelChartJsConfigBuilder",

		// Fields: Private

		/**
		 * @private
		 */
		_funnelLayoutOptions: {
			padding: {
				left: 5,
				right: 5,
				top: 25,
				bottom: 25
			}
		},

		// endregion

		// region Properties: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		chartJsType: "tsfunnel",

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		getLayoutOptions: function() {
			const layoutOptions = this.callParent(arguments);
			return this.applyOptions(layoutOptions, this._funnelLayoutOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getLabels: function() {
			const series = this.getHighchartsConfigValueOrDefault("series", []);
			if (series.length === 0) {
				return [];
			}
			var serie = series[0];
			var serieData = serie.data;
			var serieFormat = serie.format;
			return serieData.map(function(data) {
				if(data.categoryItem.entitySchemaName==="Opportunity"){
					return Ext.String.format("{0}", data.name);
				}
				return Ext.String.format("{0}",this.getLabelSuffix(data, serieFormat));
			}, this);
		},
		
		/**
		 * Returns label suffix.
		 * @param {Object} serieData Highchart serie data.
		 * @param {Object} format Number presentation format.
		 * @param {BPMSoft.DataValueType} format.type Data value type.
		 * @param {BPMSoft.DataValueType} format.decimalPrecision Decimal precision.
		 * @returns {String} Label suffix.
		 */
		getLabelSuffix: function (serieData, format) {
			return Ext.String.format("{0}", this.formatDataLabel(serieData.y, format));
		},
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getTooltipPercentLabel: function() {
			return BPMSoft.emptyString;
		},
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getPlugins: function() {
			return {
				datalabels: {
					display: false,
				}
			};
		},

		// endregion

	});

	return { };
});
