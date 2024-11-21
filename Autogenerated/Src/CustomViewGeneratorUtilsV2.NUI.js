define("CustomViewGeneratorUtilsV2", ["ext-base", "BPMSoft"], function() {
	return {
		generateCustomLabeledControl: function(config) {
			return {
				id: config.name + "_label",
				className: "BPMSoft.Label",
				caption: "Label for " + config.name
			};
		}
	};
});
