define("ConfigurationDiagramGenerator", ["ViewGeneratorV2"], function() {

	/**
	 * @class BPMSoft.configuration.ConfigurationDiagramGenerator
	 * ##### ########## #########.
	 */
	Ext.define("BPMSoft.configuration.ConfigurationDiagramGenerator", {
		alternateClassName: "BPMSoft.ConfigurationDiagramGenerator",
		extend: "BPMSoft.ViewGenerator",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * ########## ############ ########## diagram.
		 * @protected
		 * @param {Object} config ############, ####### ######## ######## ### ######### diagram.
		 * @return {Object} ############ ########## diagram.
		 */
		generateDiagram: function(config) {
			var diagramConfig = {
				className: config.className || "BPMSoft.Diagram",
				items: {bindTo: config.items}
			};
			if (config.generateId !== false) {
				Ext.apply(diagramConfig, {
					id: config.name,
					selectors: {wrapEl: "#" + config.name}
				});
			}
			var serviceProperties = ["generator"];
			var configWithoutServiceProperties = this.getConfigWithoutServiceProperties(config, serviceProperties);
			Ext.apply(diagramConfig, configWithoutServiceProperties);
			return diagramConfig;
		}
	});

	return Ext.create("BPMSoft.ConfigurationDiagramGenerator");
});
