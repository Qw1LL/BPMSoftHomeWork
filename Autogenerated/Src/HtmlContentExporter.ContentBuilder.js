 define("HtmlContentExporter", ["ContentBuilderConstants"],
	function() {
		/**
		 * @class BPMSoft.configuration.HtmlContentExporter
		 */
		Ext.define("BPMSoft.configuration.HtmlContentExporter", {
			extend: "BPMSoft.BaseContentExporter",
			alternateClassName: "BPMSoft.HtmlContentExporter",

			/** Type of exported item.
			 * @protected
			 * @type {Object}
			 */
			ExportedItemType: _.assign({}, BPMSoft.ExportedItemType, {
				HTML: BPMSoft.ContentBuilderBodyItemType.mjraw.value,
				BLOCK: "htmlblock"
			}),

			/**
			 * @private
			 */
			_findHtmlElement: function(config) {
				if (!config) {
					throw Ext.create("BPMSoft.NullOrEmptyException");
				}
				if (config.ItemType === this.ExportedItemType.HTML) {
					return config;
				}
				return this._findHtmlElement(config.Items && config.Items[0]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentExporter#exportData
			 * @override
			 */
			exportData: function(config) {
				var htmlElement = this._findHtmlElement(config);
				var sanitizedContent = BPMSoft.utils.html.sanitizeHTML(htmlElement.Content);
				return sanitizedContent;
			}
		});
	}
);
