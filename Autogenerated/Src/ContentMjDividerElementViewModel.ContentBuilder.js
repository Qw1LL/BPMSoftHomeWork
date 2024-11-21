define("ContentMjDividerElementViewModel", ["ContentMjDividerElementViewModelResources",
		"ContentSeparatorElementViewModel"], function(resources) {
	Ext.define("BPMSoft.ContentBuilder.ContentMjDividerElementViewModel", {
		extend: "BPMSoft.ContentSeparatorElementViewModel",
		alternateClassName: "BPMSoft.ContentMjDividerElementViewModel",

		/**
		 * Content element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentMjDivider",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles", "Thickness", "Color", "Width", "Style"],

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * Returns config object of view model edit page.
		 * @protected
		 * @param {Boolean} withElementInfo Defines if config is extended with properties page info.
		 * @returns {Object} Full edit page config.
		 */
		getEditConfig: function(withElementInfo) {
			var config = {
				ItemType: this.$ItemType,
				Styles: this.$Styles,
				Thickness: this.$Thickness,
				Style: this.$Style,
				Color: this.$Color,
				Width: this.$Width,
				UseBackgroundImage: false,
				IsBordersSettingsEnabled: false
			};
			if (withElementInfo) {
				config.ElementInfo = {
					Type: config.ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentMjDividerPropertiesPage",
						isStylesVisible: true,
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp
					}
				};
			}
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @override
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"width": "$Width"
			});
			return config;
		}
	});
});
