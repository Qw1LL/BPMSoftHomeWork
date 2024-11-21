define("ContentButtonElementViewModel", [
	"ContentButtonElementViewModelResources",
	"ContentElementBaseViewModel",
	"ckeditor-base",
	"InlineCodeTextEdit"
], function() {
	Ext.define("BPMSoft.ContentBuilder.ContentButtonElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentButtonElementViewModel",

		/**
		 * View model element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentButtonElement",

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.on("change:HtmlText", this._onHtmlTextChanged, this);
		},

		/**
		 * @private
		 */
		_onHtmlTextChanged: function(model, value) {
			this.$PlainText = this._getPlainText(value);
		},

		/**
		 * @private
		 */
		_getPlainText: function(htmlText) {
			const temp = document.createElement("div");
			temp.innerHTML = htmlText;
			const plainText = temp.textContent || temp.innerText || "";
			Ext.removeNode(temp);
			return plainText;
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"markerValue": "$PlainText",
				"align": "$Align",
				"padding": "$Padding",
				"items": [{
					"className": "BPMSoft.InlineTextEdit",
					"value": "$HtmlText",
					"markerValue": "HtmlText",
					"ckeditorDefaultConfig": {
						"allowedContent": true,
						"removeButtons":
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
							"bpmcrmmacros," +
							"lineheight," +
							"indentpanel"
					}
				}]
			});
			return config;
		}

	});
});
