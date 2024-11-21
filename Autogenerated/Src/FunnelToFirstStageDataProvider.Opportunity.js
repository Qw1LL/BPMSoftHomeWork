define("FunnelToFirstStageDataProvider", ["ext-base", "FunnelConversionDataProvider"],
	function(Ext) {

		/**
		 * @class BPMSoft.configuration.FunnelToFirstStageDataProvider
		 * Class to prepare filter for funnel first stage conversion.
		 */
		Ext.define("BPMSoft.configuration.FunnelToFirstStageDataProvider", {
			extend: "BPMSoft.FunnelConversionDataProvider",
			alternateClassName: "BPMSoft.FunnelToFirstStageDataProvider",

			/**
			 * @inheritdoc BPMSoft.FunnelConversionDataProvider#prepareConversionResponse
			 * @overridden
			 */
			prepareConversionResponse: function(responseCollection) {
				this.callParent(arguments);
				var firstStageValue;
				responseCollection.each(function(currentItem) {
					var itemValue = currentItem.get("yAxis") || 0;
					if (firstStageValue === undefined && itemValue !== 0) {
						firstStageValue = itemValue;
					}
					if (firstStageValue !== undefined) {
						currentItem.set("bottomConversionValue", firstStageValue);
					}
				}, this);
			}

		});
	}
);
