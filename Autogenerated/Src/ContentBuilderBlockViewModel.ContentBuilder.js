define("ContentBuilderBlockViewModel", ["ContentBuilderBlockViewModelResources", "ContentBuilderConstants",
		"ContentBuilderElementViewModel"],
	function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderBlockViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderBlockViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderBlockViewModel",

		columns: {
			"ClassName": {
				value: "BPMSoft.ContentBuilderBlock"
			},
			"ItemType": {
				value: BPMSoft.ContentBuilderBodyItemType.mjblock.value
			},
			"Caption": {
				value: resources.localizableStrings.Caption
			},
			"Icon": {
				value: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Icon)
				}
			},
			"GroupName": {
				value: ["ContentBlank"]
			}
		}
	});
});
