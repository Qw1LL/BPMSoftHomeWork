define("WSViewGeneratorV2", ["BusinessRulesApplierV2", "ext-base", "BPMSoft", "WSViewGeneratorV2Resources",
	"LinkColumnHelper", "GridLayoutUtils"], function(BusinessRulesApplier, Ext, BPMSoft, resources, LinkColumnHelper, GridLayoutUtils) {
		
	Ext.define("BPMSoft.configuration.WSViewGenerator", {
		alternateClassName: "BPMSoft.WSViewGenerator",
		override: "BPMSoft.ViewGenerator",
		
		generateEditControl: function(config) {
			
			if (config.name && !config.bindTo){
				config.bindTo = config.name;
			}
			
			if (config.name && config.bindTo){
				config.name = config.name + "ST" + config.bindTo + "ND";
			}
			return this.callParent(arguments);
		},
	});
});