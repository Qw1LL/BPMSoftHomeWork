define("ContentBuilderImageElementViewModel", ["ContentBuilderImageElementViewModelResources",
		"ContentBuilderElementViewModel", "ContentBuilderConstants"],
	function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderImageElementViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderImageElementViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderImageElementViewModel",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "ImageConfig", "Align"],

		columns: {
			"ClassName": {
				value: "BPMSoft.ContentBuilderElement"
			},
			"ItemType": {
				value: BPMSoft.ContentBuilderBodyItemType.mjimage.value
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
			"Align": {
				value: BPMSoft.Align.CENTER
			},
			"GroupName": {
				value: [BPMSoft.ContentBuilder.constants.ElementDropGroup]
			},
			"ImageConfig": {
				value: {
					source: BPMSoft.ImageSources.URL,
					url: resources.localizableStrings.DefaultImageBase64
				}
			}
		}
	});
});
