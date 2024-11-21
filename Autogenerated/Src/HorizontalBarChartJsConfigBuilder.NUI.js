define("HorizontalBarChartJsConfigBuilder", ["BarChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.HorizontalBarChartJsConfigBuilder", {
		extend: "BPMSoft.BarChartJsConfigBuilder",
		alternateClassName: "BPMSoft.HorizontalBarChartJsConfigBuilder",

		// region Fields: Private
		
		/**
		 * @private
		 */
		_yAxesTicksLineHeight: 1,

		// endregion

		// region Properties: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		chartJsType: "horizontalBar",

		// endregion

		// region Methods: Private

		/**
		 * @private
		 */
		_setLineHeight: function(scalesOptions) {
			const yAxesTicksConfiguration = scalesOptions.yAxes && scalesOptions.yAxes[0].ticks;
			this.applyOptions(yAxesTicksConfiguration, {
				lineHeight: this._yAxesTicksLineHeight
			});
			return scalesOptions;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		getScalesOptions: function() {
			const scalesOptions = this.callParent(arguments);
			const horizontalBarScalesOptions = {
				xAxes: scalesOptions.yAxes,
				yAxes: scalesOptions.xAxes,
			}
			this._setLineHeight(horizontalBarScalesOptions);
			return horizontalBarScalesOptions;
		}

		// endregion

	});

	return { };
});