define("MiniPageEditControlsGenerator", ["ViewGeneratorV2"], function() {
	/**
	 * @class BPMSoft.configuration.MiniPageEditControlsGenerator
	 * Mini Page edit controls generator class.
	 */
	Ext.define("BPMSoft.configuration.MiniPageEditControlsGenerator", {
		extend: "BPMSoft.ViewGenerator",
		alternateClassName: "BPMSoft.MiniPageEditControlsGenerator",

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateModelItem
		 * @protected
		 * @overridden
		 */
		generateModelItem: function(config, generateConfig) {
			this.viewModelClass = generateConfig.viewModelClass;
			delete config.generator;
			var generateModelItem = this.callParent(arguments);
			return generateModelItem;
		}
	});
	return Ext.create("BPMSoft.MiniPageEditControlsGenerator");
});
