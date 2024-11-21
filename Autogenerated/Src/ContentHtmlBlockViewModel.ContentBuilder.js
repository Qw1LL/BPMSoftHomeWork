define("ContentHtmlBlockViewModel", ["ContentHtmlBlockViewModelResources", "ContentMjBlockViewModel",
		"ContentSmartHtmlElementViewModel", "ContentHtmlBlock"], function(resources) {
	/**
	 * @class BPMSoft.controls.ContentHtmlBlockViewModel
	 */
	Ext.define("BPMSoft.ContentHtmlBlockViewModel", {
		extend: "BPMSoft.ContentMjBlockViewModel",

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#className
		 * @override
		 */
		className: "BPMSoft.ContentHtmlBlock",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType"],

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#childItemTypes
		 */
		childItemTypes: {
			mjraw: "BPMSoft.ContentSmartHtmlElementViewModel"
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#getViewConfig
		 * @override
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"elementSelectedChange": "$onElementSelected"
			});
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#getToolsConfig
		 * @override
		 */
		getToolsConfig: function() {
			return [];
		}
	});

	return BPMSoft.ContentHtmlBlockViewModel;
});
