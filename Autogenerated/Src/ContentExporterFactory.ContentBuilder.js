define("ContentExporterFactory", ["MjmlContentExporter", "HtmlContentExporter"],
	function () {
		Ext.define("BPMSoft.configuration.ContentExporterFactory", {
			alternateClassName: "BPMSoft.ContentExporterFactory",
			defaultExporterName: "BPMSoft.EmailContentExporter",

			/**
			 * Defines an instance of applicable email content exporter by first item from template.
			 * @private
			 * @param {Array} items Array of items from template config.
			 * @returns {BPMSoft.BaseContentExporter} An instance of exporter or undefined.
			 */
			_getExporterByItems: function(items) {
				if (items && items.length > 0) {
					switch (items[0].ItemType) {
						case "mjblock":
							return Ext.create("BPMSoft.MjmlContentExporter");
						case "blockgroup":
							return this._getExporterByItems(items[0].Items);
						case "block":
							return Ext.create("BPMSoft.EmailContentExporter");
						case "htmlblock":
							return Ext.create("BPMSoft.HtmlContentExporter");
					}
				}
				return Ext.create(this.defaultExporterName);
			},

			/**
			 * Defines an instance of content exporter.
			 * @public
			 * @param {Object} config Content builder template config.
			 * @returns {BPMSoft.BaseContentExporter} Instance of exporter or undefined.
			 */
			getExporter: function(config) {
				if (config) {
					return this._getExporterByItems(config.Items);
				}
				return Ext.create(this.defaultExporterName);
			}
		});
	}
);
