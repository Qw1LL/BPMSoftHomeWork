define("ContentBuilderSeparatorElementViewModel", ["ContentBuilderSeparatorElementViewModelResources",
		"ContentBuilderElementViewModel", "ContentBuilderConstants"],
	function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderSeparatorElementViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderSeparatorElementViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderSeparatorElementViewModel",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles", "Thickness", "Color", "Width", "Style"],

		columns: {
			"ClassName": {
				value: "BPMSoft.ContentBuilderElement"
			},
			"ItemType": {
				value: BPMSoft.ContentBuilderBodyItemType.mjdivider.value
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
			"Color": {
				value: "#BBBBBB"},
			"Thickness": {
				value: "2px"
			},
			"Width": {
				value: BPMSoft.emptyString
			},
			"Style": {
				value: "Solid"
			},
			"Styles": {
				value: {
					"padding-top": "10px",
					"padding-bottom": "10px",
					"padding-left": "23px",
					"padding-right": "23px"
				}
			}
		}

	});
});
