define("QueueItemSectionViewHelper", ["BPMSoft", "QueueItemSectionViewHelperResources"],
		function(BPMSoft, resources) {
	Ext.define("BPMSoft.configuration.QueueItemSectionViewHelper", {
		singleton: true,
		alternateClassName: "BPMSoft.QueueItemSectionViewHelper",

		/**
		 * Creates a generator function for fixed filter checkbox container.
		 * @param {Object} config The container config.
		 * @param {String} config.name The name of the container.
		 * @param {String} [config.caption] The caption of the checkbox.
		 * @param {String} [config.checked] The checkbox 'checked' event handler name.
		 * @param {String} [config.labelButtonClick] The label button 'click' event handler name.
		 * @return {Object}
		 */
		getFixedFilterCheckboxGenerator: function(config) {
			var editName = config.name + "Edit";
			return {
				className: "BPMSoft.Container",
				id: config.name + "Container",
				selectors: {wrapEl: "#" + config.name + "Container"},
				classes: {
					wrapClassName: ["filters-container-wrapClass fixed-filter-checkbox-container"]
				},
				visible: Ext.isDefined(config.visible) ? config.visible : true,
				items: [
					{
						id: editName,
						markerValue: editName,
						className: "BPMSoft.CheckBoxEdit",
						checked: config.checked
					},
					{
						id: config.name + "LabelButton",
						className: "BPMSoft.Button",
						caption: config.caption,
						markerValue: config.name + "LabelButton",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						click: config.labelButtonClick
					}
				]
			};
		}
	});
	return BPMSoft.configuration.QueueItemSectionViewHelper;
});
