define("ContentBuilderNavbarElementViewModel", ["ContentBuilderNavbarElementViewModelResources",
		"ContentBuilderElementViewModel", "ContentBuilderConstants"],
	function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderNavbarElementViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderNavbarElementViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderNavbarElementViewModel",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType"],

		columns: {
			"ClassName": {
				value: "BPMSoft.ContentBuilderElement"
			},
			"ItemType": {
				value: BPMSoft.ContentBuilderBodyItemType.navbar.value
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
			"Items": {
				value: new BPMSoft.BaseViewModelCollection()
			}
		}
	});
});
