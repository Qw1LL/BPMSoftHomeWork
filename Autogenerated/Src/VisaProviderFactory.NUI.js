define("VisaProviderFactory", ["BaseVisaProvider"], function() {
	Ext.define("BPMSoft.configuration.VisaProviderFactory", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.VisaProviderFactory",

		create: function(config) {
			return Ext.create("BPMSoft.BaseVisaProvider", config);
		}
	});
	return {};
});
