define("ContentMjRawElementViewModel", ["ContentMjRawElementViewModelResources", "ContentElementBaseViewModel"],
		function(resources) {

	/**
	 * @class BPMSoft.ContentBuilder.ContentMjRawElementViewModel
	 * Raw HTML element view model class.
	 */
	Ext.define("BPMSoft.ContentBuilder.ContentMjRawElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentMjRawElementViewModel",

		/**
		 * Name of view class.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentMjRawElement",

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#sanitizedProperties
		 * @overridde
		 */
		 sanitizedProperties: ["Content"],

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Content"],

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"content": "$Content",
				"placeholder": "$Resources.Strings.Placeholder"
			});
			return config;
		},

		/**
		 * Returns config object for element edit page.
		 * @protected
		 * @returns {Object} Element edit page config.
		 */
		getEditConfig: function() {
			var config = {
				ItemType: this.$ItemType,
				Content: this.$Content,
				ElementInfo: {
					Type: this.ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentMjRawPropertiesPage",
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp
					}
				}
			};
			return config;
		}
	});
});
