define("TextMacroListItemViewModel", ["BaseMacroListItemViewModel"], function() {
	/**
	 * @class BPMSoft.configuration.TextMacroListItemViewModel
	 */
	Ext.define("BPMSoft.configuration.TextMacroListItemViewModel", {
		extend: "BPMSoft.BaseMacroListItemViewModel",
		alternateClassName: "BPMSoft.TextMacroListItemViewModel",

		/**
		 * @private
		 */
		_textToHtml: function(text) {
			var html = "";
			for (var counter = 0; counter < text.length; counter++) {
				switch (text[counter]) {
					case "\n":
						html += "<br>";
						break;
					case "\t":
						html += "&nbsp;&nbsp;";
						break;
					case " ":
						if (counter === 0 || text[counter-1] === " " || text[counter+1] === " ") {
							html += "&nbsp;";
						}
						else {
							html += text[counter];
						}
						break;
					case "&":
						html += "&amp;";
						break;
					case '"':
						html += "&quot;";
						break;
					case "'":
						html += "&apos;";
						break;
					case ">":
						html += "&gt;";
						break;
					case "<":
						html += "&lt;";
						break;
					default:
						html += text[counter];
				}
			}
			return html;
		},

		/**
		 * @inheritdoc BaseMacroListItemViewModel#onDisplayValueChanged
		 * @override
		 */
		onDisplayValueChanged: function(model, value) {
			if (Ext.isEmpty(value)) {
				this.$Value = "";
			} else {
				this.$Value = this._textToHtml(value);
			}
		},

		/**
		 * @inheritdoc BaseMacroListItemViewModel#initDisplayValue
		 * @override
		 */
		initDisplayValue: function(config) {
			var value = config.Value;
			if (!Ext.isEmpty(value)) {
				value = value.replace(/<br\s*[\/]?>/ig, "\n");
				value = value.replace(/<[A-Za-z/][^<>]*>/ig, "");
				value = value.replace(/&nbsp;/ig, " ");
				value = value.replace(/&quot;/ig, '"');
				value = value.replace(/&apos;/ig, "'");
				value = value.replace(/&amp;/ig, "&");
				value = value.replace(/&lt;/ig, "<");
				value = value.replace(/&gt;/ig, ">");
			}
			config.DisplayValue = value;
		},

		/**
		 * @inheritdoc BaseMacroListItemViewModel#getMacroInputConfig
		 * @override
		 */
		getMacroInputConfig: function() {
			return [this.getMacroLabelConfig(),
				{
					className: "BPMSoft.MemoEdit",
					value: "$DisplayValue",
					markerValue: this.getControlMarkerValue()
				}
			];
		}
	});
	return BPMSoft.TextMacroListItemViewModel;
});
