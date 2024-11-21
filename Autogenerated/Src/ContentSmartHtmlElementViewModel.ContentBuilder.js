define("ContentSmartHtmlElementViewModel", ["ContentSmartHtmlElementViewModelResources",
		"ContentElementBaseViewModel"], function(resources) {
	/**
	 * @class BPMSoft.ContentBuilder.ContentSmartHtmlElementViewModel
	 * Smart HTML element view model class.
	 */
	Ext.define("BPMSoft.ContentBuilder.ContentSmartHtmlElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentSmartHtmlElementViewModel",

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
		 sanitizedProperties: ["HtmlSrc", "Content"],

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Content", "HtmlSrc", "Macros"],

		_onMacrosChanged: function() {
			var macros = Ext.JSON.decode(this.$Macros, true);
			if (macros) {
				this.set("Macros", macros, { silent: true });
				this.replaceMacrosWithValues(macros);
			}
		},

		_prepareHtmlContent: function(sourceHtml) {
			var parser = new DOMParser();
			var serializer = new XMLSerializer();
			var domRoot = parser.parseFromString(sourceHtml, "text/html");
			return serializer.serializeToString(domRoot);
		},

		/**
		 * Replaces macros in html source.
		 * @protected
		 */
		replaceMacrosWithValues: function(macros) {
			var result = this.$HtmlSrc;
			BPMSoft.each(macros, function(macro) {
				var regex = new RegExp("{{#" + macro.Id + "::.*?#}}", "gm");
				result = result.replace(regex, macro.Value);
			}, this);
			this.$Content = this._prepareHtmlContent(result);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
			this.on("change:Macros", this._onMacrosChanged, this);
		},

		/**
		 * @inheritdoc BaseContentItemViewModel#getPreparedConfigBeforeCreate
		 */
		getPreparedConfigBeforeCreate: function(config) {
			var changedConfig = this.callParent(arguments);
			changedConfig.Macros = config.Macros || [];
			changedConfig.HtmlSrc = config.HtmlSrc || config.Content || "";
			return changedConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:Macros", this._onMacrosChanged, this);
			this.callParent(arguments);
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
				HtmlSrc: this.$HtmlSrc,
				Macros: this.$Macros,
				ElementInfo: {
					Type: this.ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentSmartHtmlPropertiesPage",
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp
					}
				}
			};
			return config;
		}
	});
});
