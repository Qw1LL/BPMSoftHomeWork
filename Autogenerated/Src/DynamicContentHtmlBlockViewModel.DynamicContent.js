 define("DynamicContentHtmlBlockViewModel", ["DynamicContentHtmlBlockViewModelResources",
		"DynamicContentMjBlockViewModel"], function(resources) {

		/**
		 * @class BPMSoft.controls.DynamicContentHtmlBlockViewModel
		 */
		Ext.define("BPMSoft.DynamicContentHtmlBlockViewModel", {
			extend: "BPMSoft.DynamicContentMjBlockViewModel",

			/**
			 * @inheritdoc BPMSoft.BaseContentBlockViewModel#className
			 * @override
			 */
			className: "BPMSoft.DynamicContentHtmlBlock",

			/**
			 * @inheritdoc BaseContentSerializableViewModelMixin#childItemTypes
			 */
			childItemTypes: {
				mjraw: "BPMSoft.ContentSmartHtmlElementViewModel"
			},

			/**
			 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
			 * @override
			 */
			serializableSlicePropertiesCollection: ["ItemType", "Styles", "Index", "IsDefault", "Priority",
				"Caption", "Attributes"],

			/**
			 * @inheritdoc BPMSoft.BaseContentBlockViewModel#initResourcesValues
			 * @override
			 */
			initResourcesValues: function(resourcesObj) {
				Ext.apply(resourcesObj.localizableImages, resources.localizableImages);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentBlockViewModel#getToolsConfig
			 * @override
			 */
			getToolsConfig: function() {
				return [];
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
			}
		});

		return BPMSoft.DynamicContentHtmlBlockViewModel;
	}
);
