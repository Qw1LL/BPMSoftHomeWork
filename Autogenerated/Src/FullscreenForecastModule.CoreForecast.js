define("FullscreenForecastModule", ["BaseSchemaModuleV2", "FullscreenForecastTab"],
	function() {
		Ext.define("BPMSoft.configuration.FullscreenForecastModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.FullscreenForecastModule",

			/**
			 * @inheritdoc BaseSchemaModule#initSchemaName
			 * @override
			 */
			initSchemaName: function() {
				this.schemaName = "FullscreenForecastTab";
			}

		});
		return BPMSoft.FullscreenForecastModule;
	});
