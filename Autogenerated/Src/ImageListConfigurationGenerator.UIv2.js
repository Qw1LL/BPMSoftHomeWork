define("ImageListConfigurationGenerator", ["ContainerList", "BaseModule"], function() {

	/**
	 * @class BPMSoft.configuration.ImageListConfigurationGenerator
	 * ##### ########## ################ #########
	 */
	Ext.define("BPMSoft.configuration.ImageListConfigurationGenerator", {
		alternateClassName: "BPMSoft.ImageListConfigurationGenerator",
		extend: "BPMSoft.BaseModule",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * ########## ############ ########## ContainerList.
		 * @protected
		 * @param {Object} config ############, ####### ######## ######## ### ######### ContainerList.
		 * @returns {Object} ############ ########## ContainerList.
		 */
		generateContainerList: function(config) {
			var id = this.elementsPrefix ? this.elementsPrefix + config.name + "ContainerList"
				: config.name + "ContainerList";
			var container = {
				className: "BPMSoft.ContainerList",
				id: id,
				selectors: {wrapEl: "#" + id},
				idProperty: config.idProperty,
				isAsync: false,
				collection: {bindTo: config.collection},
				observableRowNumber: config.observableRowNumber,
				onGetItemConfig: {bindTo: config.onGetItemConfig},
				visible: {"bindTo": config.visible},
				itemsRendered: {"bindTo": config.itemsRendered}
			};
			if (!Ext.isEmpty(config.wrapClassName)) {
				container.classes = {
					wrapClassName: config.wrapClassName
				};
			}
			return container;
		}
	});

	return Ext.create("BPMSoft.ImageListConfigurationGenerator");
});
