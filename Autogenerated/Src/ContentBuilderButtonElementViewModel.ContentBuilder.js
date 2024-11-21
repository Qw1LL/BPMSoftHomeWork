define("ContentBuilderButtonElementViewModel", ["ContentBuilderButtonElementViewModelResources",
		"ContentBuilderElementViewModel", "ContentBuilderConstants"],
	function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderButtonElementViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderButtonElementViewModel", {
		extend: "BPMSoft.ContentBuilderElementViewModel",
		alternateClassName: "BPMSoft.ContentBuilderButtonElementViewModel",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles", "WrapperStyles", "Align",
			"HtmlText", "PlainText"],

		columns: {
			"ClassName": {
				value: "BPMSoft.ContentBuilderElement"
			},
			"ItemType": {
				value: BPMSoft.ContentBuilderBodyItemType.mjbutton.value
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
			"HtmlText": {
				value:
					"<span>Кнопка</span>"
			},
			"PlainText": {
				value: "Кнопка"
			},
			"Styles": {
				value: { "background-color": "#F9763D", "color": "#FFFFFF", "font-family": "Golos Regular", "font-size": "16px", "border-radius": "8px", "padding": "8px 20px", "line-height": "24px" } 
			}
		}
	});
});
