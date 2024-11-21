define("CommunicationPanelHelper", ["BaseModule"], function() {

		/**
		 * @class BPMSoft.configuration.CommunicationPanelHelper
		 * ##### ########## ################ ######### ################ ######.
		 */
		Ext.define("BPMSoft.configuration.CommunicationPanelHelper", {
			alternateClassName: "BPMSoft.CommunicationPanelHelper",
			extend: "BPMSoft.BaseModule",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ########## ##### #### ### ################ ######.
			 * @protected
			 * @param {Object} config ######## ######## ### ######### ####### ####.
			 * @return {Object} ############ ###### ####.
			 */
			generateMenuItem: function(config) {
				var imageConfig = Ext.isEmpty(config.imageConfig) ? {bindTo: "getItemImageConfig"} : config.imageConfig;
				var itemCaption = Ext.isEmpty(config.caption) ? {bindTo: config.tag + "Counter"} : config.caption;
				var style = Ext.isEmpty(config.style) ? BPMSoft.controls.ButtonEnums.style.TRANSPARENT : config.style;
				return {
					id: "view-button-" + config.name,
					className: "BPMSoft.Button",
					selectors: {wrapEl: "#view-button-" + config.name},
					caption: itemCaption,
					click: {bindTo: "onMenuItemClick"},
					imageConfig: imageConfig,
					hint: {"bindTo": "getHint"},
					pressed: {bindTo: config.tag + "Active"},
					classes: {
						imageClass: ["communication-panel-menu-images-class"],
						pressedClass: ["pressed-button-view"]
					},
					markerValue: config.markerValue || config.name,
					style: style,
					tag: config.tag,
					visible: Ext.isEmpty(config.visible) || config.visible,
					width: "100%"
				};
			}
		});

		return Ext.create("BPMSoft.CommunicationPanelHelper");
	});
