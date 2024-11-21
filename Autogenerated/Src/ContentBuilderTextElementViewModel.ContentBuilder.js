define("ContentBuilderTextElementViewModel", ["ContentBuilderTextElementViewModelResources",
		"ContentBuilderElementViewModel", "ContentBuilderConstants"],
	function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderTextElementViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderTextElementViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderTextElementViewModel",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Content"],

		columns: {
			"ClassName": {
				value: "BPMSoft.ContentBuilderElement"
			},
			"ItemType": {
				value: BPMSoft.ContentBuilderBodyItemType.text.value
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
				value: [BPMSoft.ContentBuilder.constants.ElementDropGroup]
			},
			"Content": {
				value: resources.localizableStrings.DefaultText
			}
		}

	});
});
