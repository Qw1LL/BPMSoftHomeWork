define("DashboardDesignerViewGenerator", ["ext-base", "BPMSoft", "ViewGeneratorV2"],
	function() {
		var viewGenerator = Ext.define("BPMSoft.configuration.DashboardDesignerViewGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.DashboardDesignerViewGenerator",

			generateGridLayout: function(config) {
				var result = {
					className: "BPMSoft.GridLayoutEdit",
					items: config.items
				};
				Ext.apply(result, this.getConfigWithoutServiceProperties(config, []));
				delete result.generator;
				return result;
			}
		});
		return Ext.create(viewGenerator);
	});
