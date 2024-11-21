define("VisaHelper", ["VisaProviderFactory", "css!VisaHelper"], function() {
	var visaProviderFactory = Ext.create("BPMSoft.VisaProviderFactory");
	return visaProviderFactory.create();
});
