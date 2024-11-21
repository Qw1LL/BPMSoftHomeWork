define("MiniPageDesignerViewModelGenerator", ["ViewModelSchemaDesignerViewModelGenerator"], function() {

	/**
	 * Mini page designer view model generator.
	 */
	Ext.define("BPMSoft.configuration.MiniPageDesignerViewModelGenerator", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerViewModelGenerator",
		alternateClassName: "BPMSoft.MiniPageDesignerViewModelGenerator"
	});

	return BPMSoft.MiniPageDesignerViewModelGenerator;
});
