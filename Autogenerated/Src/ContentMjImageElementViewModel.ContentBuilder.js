define("ContentMjImageElementViewModel", ["ContentMjImageElementViewModelResources", "ContentImageElementViewModel"],
	function(resources) {

	Ext.define("BPMSoft.ContentBuilder.ContentMjImageElementViewModel", {
		extend: "BPMSoft.ContentImageElementViewModel",
		alternateClassName: "BPMSoft.ContentMjImageElementViewModel",

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#className
		 * @override
		 */
		className: "BPMSoft.ContentMjImage",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Link", "ImageConfig",
			"Styles", "ImageTitle", "Alt", "Align", "Width", "Height"],

		/**
		 * Returns config object to init and open an edit page.
		 * @override
		 * @param {Boolean} withElementInfo Defines if config is extended with properties page info.
		 * @returns {Object} Full edit page config.
		 */
		getEditConfig: function(withElementInfo) {
			var config = this.callParent(arguments);
			if (withElementInfo) {
				config.ElementInfo = {
					Type: config.ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentMjmlImagePropertiesPage",
						isStylesVisible: true,
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp
					}
				};
			}
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		}

	});

});
