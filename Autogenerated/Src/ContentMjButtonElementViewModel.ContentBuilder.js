define("ContentMjButtonElementViewModel", ["ContentMjButtonElementViewModelResources",
		"ContentButtonElementViewModel", "ContentBuilderConstants"], function(resources) {
	Ext.define("BPMSoft.ContentBuilder.ContentMjButtonElementViewModel", {
		extend: "BPMSoft.ContentButtonElementViewModel",
		alternateClassName: "BPMSoft.ContentMjButtonElementViewModel",

		/**
		 * View model element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentMjButtonElement",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles", "WrapperStyles", "Link", "Align",
			"HtmlText", "PlainText"],

		/**
		 * Defines visibility of marco button.
		 * @protected
		 * @type {Boolean}
		 */
		isMacroButtonVisible: false,

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
			this.on("change:SelectedText", this.onSelectedTextChanged, this);
		},

		/**
		 * @inheritDoc BaseContentItemViewModel#getPreparedConfigBeforeCreate
		 */
		getPreparedConfigBeforeCreate: function(config) {
			var changedConfig = this.callParent(arguments);
			changedConfig.Align = config.Align || BPMSoft.Align.CENTER;
			changedConfig.Styles = Ext.apply({
				"height": "auto",
				"vertical-align": config.VerticalAlign || BPMSoft.Valign.MIDDLE,
				"padding-left": "10px",
				"padding-right": "10px",
				"padding-top": "5px",
				"padding-bottom": "5px",
				"border-radius": "3px",
				"font-family": BPMSoft.FontSet.ARIAL,
				"font-size": "13px",
				"color": "#000000",
				"line-height": "22px"
			}, config.Styles);
			changedConfig.WrapperStyles = Ext.apply({
				"padding-left": "10px",
				"padding-right": "10px",
				"padding-top": "5px",
				"padding-bottom": "5px",
				"width": "auto"
			}, config.WrapperStyles) ;
			return changedConfig;
		},

		/**
		 * Returns config object of view model edit page.
		 * @protected
		 * @returns {Object} Full edit page config.
		 */
		getEditConfig: function() {
			var config = {
				ItemType: this.$ItemType,
				Styles: this.$Styles,
				WrapperStyles: this.$WrapperStyles,
				Link: this.$Link,
				Align: this.$Align,
				ElementInfo: {
					Type: this.$ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentMjButtonPropertiesPage",
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp,
						useBackgroundImage: false,
						isStylesVisible: true
					}
				}
			};
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			var macroButtonToRemove = this.isMacroButtonVisible ? "" : "bpmcrmmacros,";
			Ext.apply(config, {
				"markerValue": "$PlainText",
				"align": "$Align",
				"wrapStyle": "$WrapperStyles",
				"buttonStyle": "$Styles",
				"items": [{
					"className": "BPMSoft.InlineTextEdit",
					"macrobuttonclicked": "$onMacroButtonClicked",
					"selectedText": "$SelectedText",
					"value": "$HtmlText",
					"markerValue": "HtmlText",
					"useDefaultFontFamily": false,
					"ckeditorDefaultConfig": {
						"allowedContent": true,
						"removeButtons":
							macroButtonToRemove +
							"Font," +
							"FontSize," +
							"JustifyCenter," +
							"JustifyLeft," +
							"JustifyRight," +
							"Link," +
							"JustifyBlock," +
							"NumberedList," +
							"BulletedList," +
							"Indent," +
							"Outdent," +
							"bpmcrmsource," +
							"indentpanel," +
							"lineheight," +
							"lineheightpanel," +
							"letterspacing," +
							"letterspacingpanel"
					}
				}]
			});
			return config;
		}
	});
});
