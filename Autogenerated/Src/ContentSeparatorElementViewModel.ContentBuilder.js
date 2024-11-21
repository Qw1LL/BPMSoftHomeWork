define("ContentSeparatorElementViewModel", ["ContentHTMLElementViewModel"], function() {
	Ext.define("BPMSoft.ContentBuilder.ContentSeparatorElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentSeparatorElementViewModel",

		/**
		 * Content element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentSeparatorElement",

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#initDefaultStyles
		 * @overridden
		 */
		initDefaultStyles: function() {
			this.$Styles = this.$Styles || {};
			if (_.isUndefined(this.$Styles["padding-left"])) {
				this.$Styles["padding-left"] = "0px";
			}
			if (_.isUndefined(this.$Styles["padding-right"])) {
				this.$Styles["padding-right"] = "0px";
			}
			if (_.isUndefined(this.$Styles["padding-top"])) {
				this.$Styles["padding-top"] = "0px";
			}
			if (_.isUndefined(this.$Styles["padding-bottom"])) {
				this.$Styles["padding-bottom"] = "0px";
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"thickness": "$Thickness",
				"style": "$Style",
				"color": "$Color"
			});
			return config;
		}
	});
});
