define("MoodCustomGeneratorV2", ["MoodCustomGeneratorV2Resources", "ext-base", "BPMSoft"], function() {
	function generateCustomMoodControl(controlConfig) {
		return {
			className: "BPMSoft.ImageView",
			id: controlConfig.name + "ImageView",
			click: {bindTo: controlConfig.onMoodClick},
			imageSrc: {bindTo: controlConfig.getSrcMethod}
		};
	}
	return {
		generateCustomMoodControl: generateCustomMoodControl
	};
});
