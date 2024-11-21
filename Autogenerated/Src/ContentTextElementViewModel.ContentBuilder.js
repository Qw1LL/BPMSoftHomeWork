define("ContentTextElementViewModel", ["ContentTextElementViewModelResources", "ContentElementBaseViewModel",
		"InlineCodeTextEdit", "ckeditor-base"], function(resources) {
	Ext.define("BPMSoft.ContentBuilder.ContentTextElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentTextElementViewModel",

		/**
		 * Content element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentTextElement",

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
		 * Handles macros button click.
		 * @protected
		 * @param {Object} event Event info object.
		 */
		onEmailTemplateLinkClicked: function() {
			this.fireEvent("change", this, {
				event: "emailtemplatelinkclicked"
			});
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"items": [{
					"className": "BPMSoft.InlineCodeTextEdit",
					"value": "$Content",
					"placeholder": "$Resources.Strings.Placeholder",
					"macrobuttonclicked": "$onMacroButtonClicked",
					"emailtemplatelinkclicked": "$onEmailTemplateLinkClicked",
					"selectedText": "$SelectedText"
				}],
				"align": "$Align"
			});
			return config;
		}
	});
});
