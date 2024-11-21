define("MjmlContentExporter", ["MjmlCore", "MjmlContentExporterResources", "ContentBuilderConfigToMjmlConverter",
		"ContentBuilderConstants"],
	function (mjml) {
		/**
		 * @class BPMSoft.configuration.MjmlContentExporter
		 */
		Ext.define("BPMSoft.configuration.MjmlContentExporter", {
			extend: "BPMSoft.BaseContentExporter",
			alternateClassName: "BPMSoft.MjmlContentExporter",

			/**
			 * Default minification config.
			 * @protected
			 * @type {Object}
			 */
			minificationConfig: {
				collapseBooleanAttributes: true,
				collapseWhitespace: false,
				collapseInlineTagWhitespace: true,
				keepClosingSlash: true,
				html5: false,
				minifyCSS: true,
				removeComments: true,
				removeEmptyAttributes: true,
				removeRedundantAttributes: true,
				caseSensitive: true,
				removeAttributeQuotes: false
			},

			/** Type of exported item.
			 * @protected
			 * @type {Object}
			 */
			ExportedItemType: _.assign({}, BPMSoft.ExportedItemType, {
				HTML: BPMSoft.ContentBuilderBodyItemType.mjraw.value,
				BLOCK: BPMSoft.ContentBuilderBodyItemType.mjblock.value,
				SECTION: BPMSoft.ContentBuilderBodyItemType.section.value,
				COLUMN: BPMSoft.ContentBuilderBodyItemType.column.value
			}),

			/**
			 * Returns converter for content builder config to Mjml config.
			 * @protected
			 * @returns {BPMSoft.converters.ContentBuilderConfigToMjmlConverter}
			 * Content builder template config to MJML config converter.
			 */
			getContentBuilderToMjmlConverter: function() {
				return new BPMSoft.ContentBuilderConfigToMjmlConverter();
			},

			/**
			 * Exports content builder template config to html.
			 * @public
			 * @param config Content builder template config.
			 * @returns {String} Html text.
			 */
			exportData: function(config) {
				var converter = this.getContentBuilderToMjmlConverter();
				var mjmlConfig = converter.convert(config);
				var isMinificationEnabled = BPMSoft.Features.getIsEnabled("MinifyEmailHtml");
				var mjmlResult = isMinificationEnabled
					? mjml(mjmlConfig, { minify: this.minificationConfig })
					: mjml(mjmlConfig);
				return this.sanitizeHTML(mjmlResult.html);
			},
			
			/**
			 * Generate new html with safe content only, using for protect against XSS
			 * @public
			 * @param html Html text.
			 * @returns {String} Html text.
			 */
			sanitizeHTML: function(html) {
				const template = document.createElement('div');
				template.innerHTML = BPMSoft.utils.html.sanitizeHTML(html);
				[...template.childNodes]
					.filter(node => node.nodeName.includes("comment") || node.nodeName.includes("STYLE"))
					.forEach(node => { 
						template.removeChild(node);
						template.appendChild(node);
					});
				return template.innerHTML;
			}
		});
	}
);
