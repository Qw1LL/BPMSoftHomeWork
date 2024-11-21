define("MiniPageDesignerViewGenerator", ["MiniPageDesignerViewGeneratorResources",
	"ViewModelSchemaDesignerViewGenerator"], function() {

	/**
	 * Min page designer view generator.
	 */
	Ext.define("BPMSoft.configuration.MiniPageDesignerViewGenerator", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerViewGenerator",
		alternateClassName: "BPMSoft.MiniPageDesignerViewGenerator",

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerViewGenerator#generateContainer
		 * @override
		 */
		generateContainer: function(config) {
			if (config.showOverlay) {
				delete config.showOverlay;
			}
			if (config.name === "AlignableMiniPageContainer") {
				config.items = BPMSoft.filter(config.items, function(item) {
					return item.name === "MiniPageContentContainer";
				}, this);
			}
			if (config.name === "MiniPageContentContainer") {
				config.items = BPMSoft.filter(config.items, function(item) {
					return item.name === "MiniPage";
				}, this);
			}
			return this.callParent(arguments);
		}

		// endregion

	});

	return BPMSoft.MiniPageDesignerViewGenerator;
});
