define("SetupCallCenterUtilities", ["BaseModule"], function() {
	/**
	 * @class BPMSoft.configuration.SetupCallCenterUtilities
	 * ##### ########## ################ ######### ####### ######## ########## Call-######.
	 */
	Ext.define("BPMSoft.configuration.SetupCallCenterUtilities", {
		alternateClassName: "BPMSoft.SetupCallCenterUtilities",
		extend: "BPMSoft.BaseModule",
		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * ########## CheckBox #######, ### ####### ######## ########## Call-######.
		 * @protected
		 * @param {Object} config ######## ######## ### ######### ########.
		 * @returns {Object} ############ ########.
		 */
		generateBottomCheckBoxControl: function(config) {
			var control = {
				className: "BPMSoft.Container",
				id: config.name + "Container",
				selectors: {wrapEl: "#" + config.name + "Container"},
				classes: {wrapClassName: ["setup-module-check-box"]},
				visible: Ext.isDefined(config.visible) ? config.visible : true,
				items: [
					{
						id: config.name + "Edit",
						markerValue: config.name,
						className: "BPMSoft.CheckBoxEdit",
						checked: {bindTo: config.name},
						hint: Ext.isDefined(config.hint) ? {bindTo: config.hint} : undefined,
						enabled: Ext.isDefined(config.enabled) ? config.enabled : true
					},
					{
						id: config.name + "Label",
						className: "BPMSoft.Label",
						caption: {bindTo: "Resources.Strings." + config.name + "Caption"},
						classes: {labelClass: "setup-module-caption"}
					}
				]
			};
			return control;
		},

		/**
		 * ########## TextEdit #######, ### ####### ######## ########## Call-######.
		 * @protected
		 * @param {Object} config ######## ######## ### ######### ########.
		 * @returns {Object} ############ ########.
		 */
		generateTextEdit: function(config) {
			var labelClasses = (config.isRequired) ? ["control-caption", "required-caption"] : ["control-caption"];
			return [
				{
					className: "BPMSoft.Label",
					id: config.name + "Label",
					caption: {bindTo: "Resources.Strings." + config.name + "Caption"},
					classes: {labelClass: labelClasses}
				},
				{
					id: config.name + "Edit",
					markerValue: config.name,
					className: "BPMSoft.TextEdit",
					value: {bindTo: config.name},
					protect: config.protect || false
				}
			];
		}

	});
	return Ext.create("BPMSoft.SetupCallCenterUtilities");
});
