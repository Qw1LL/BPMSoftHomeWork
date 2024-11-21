/**
 * ############### ###### ### ###### # ########.
 */
define("IconHelper", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {

		/**
		 * ####### ############ ###### # #######.
		 * @param config {Object} ############ ###### # #######.
		 * @return {Object} ########## ############ ###### # #######.
		 */
		var createIconButtonConfig = function(config) {
			var buttonConfig = {
				id: "view-button-" + config.name,
				selectors: {
					wrapEl: "#view-button-" + config.name
				},
				tag: config.name,
				hint: config.hint,
				markerValue: config.name,
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
				pressed: {bindTo: config.name + "Active"},
				click: {bindTo: config.func ? config.func : "onViewButtonClick"},
				classes: {
					imageClass: ["view-images-class"],
					pressedClass: ["pressed-button-view"],
					wrapperClass: config.wrapperClass
				}
			};
			if (config.imageClass) {
				buttonConfig.classes.imageClass.push(config.imageClass);
			}
			return buttonConfig;
		};

		return {
			createIconButtonConfig: createIconButtonConfig
		};
	});
