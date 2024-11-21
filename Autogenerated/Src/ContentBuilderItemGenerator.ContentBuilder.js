define("ContentBuilderItemGenerator", ["ViewGeneratorV2"], function() {

	/**
	 * @class BPMSoft.configuration.ContentBuilderItemGenerator
	 * ##### ########## ######### ContentBuilder.
	 */
	Ext.define("BPMSoft.configuration.ContentBuilderItemGenerator", {
		alternateClassName: "BPMSoft.ContentBuilderItemGenerator",
		extend: "BPMSoft.ViewGenerator",

		/**
		 * ########## ############ ########## ContentBlock.
		 * @protected
		 * @param {Object} config ############, ####### ######## ######## ### ######### ContentBlock.
		 * @return {Object} ############ ########## ContentBlock.
		 */
		generateContentBlock: function(config) {
			var contentBlockConfig = {
				className: "BPMSoft.controls.ContentBlock",
				items: {bindTo: config.items}
			};
			if (config.generateId !== false) {
				Ext.apply(contentBlockConfig, {
					id: config.name + "ContentBlock"
				});
			}
			var serviceProperties = ["generator"];
			var configWithoutServiceProperties = this.getConfigWithoutServiceProperties(config, serviceProperties);
			Ext.apply(contentBlockConfig, configWithoutServiceProperties);
			return contentBlockConfig;
		}
	});

	return Ext.create("BPMSoft.ContentBuilderItemGenerator");
});
