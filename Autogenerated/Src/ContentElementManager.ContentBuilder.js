define("ContentElementManager", ["ContentElementManagerResources"], function(resources) {

	/**
	 * Class for ContentElementManager.
	 */
	Ext.define("BPMSoft.configuration.ContentElementManager", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.ContentElementManager",

		// region Methods: Public

		/**
		 * Returns items collection for grid content builder config state.
		 * @return {BPMSoft.core.collections.Collection}
		 */
		getGridItems: function() {
			const localizableStrings = resources.localizableStrings;
			const localizableImages = resources.localizableImages;
			const items = [
				{
					Type: "html",
					DesignTimeConfig: {
						Caption: localizableStrings.HtmlCaption,
						Icon: localizableImages.HtmlIcon,
						Size: {
							ColSpan: 11,
							RowSpan: 1
						}
					},
					Settings: {
						isStylesVisible: true,
						panelIcon: localizableImages.HtmlPanelIcon
					},
					DefaultConfig: {
						Content: localizableStrings.DefaultHtml
					}
				},
				{
					Type: "image",
					DesignTimeConfig: {
						Caption: localizableStrings.ImageCaption,
						Icon: localizableImages.ImageIcon,
						Size: {
							ColSpan: 11,
							RowSpan: 1
						}
					},
					Settings: {
						schemaName: "ContentImagePropertiesPage",
						isStylesVisible: true,
						panelIcon: localizableImages.ImagePanelIcon,
						notImplemented: !BPMSoft.Features.getIsEnabled("ContentBuilderPropertiesPanel")
					},
					DefaultConfig: {
						ImageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: localizableStrings.DefaultImageBase64
						}
					}
				},
				{
					Type: "button",
					NotImplemented: BPMSoft.Features.getIsEnabled("DisableContentButtonPropertiesPage"),
					DesignTimeConfig: {
						Caption: localizableStrings.ButtonCaption,
						Icon: localizableImages.ButtonIcon,
						Size: {
							ColSpan: 6,
							RowSpan: 1
						}
					},
					Settings: {
						schemaName: "ContentButtonPropertiesPage",
						wrapClass: "button-panel content-panel-wrapper",
						isStylesVisible: true,
						useBackgroundImage: false,
						panelIcon: localizableImages.ButtonPanelIcon
					},
					DefaultConfig: {
						HtmlText:
							"<span style=\"font-size: 16px; line-height: 24px;\">" +
							"Кнопка" +
							"</span>",
						PlainText: "Кнопка",
						Align: "center",
						Styles: {
							"padding-top": "8px",
							"padding-right": "20px",
							"padding-bottom": "8px",
							"padding-left": "20px",
							"color": "#FFF",
							"background-color": "#f9763d",
							"border-radius": "8px"
						},
						Padding: {
							"padding-left": "8px",
							"padding-right": "8px",
							"padding-top": "8px",
							"padding-bottom": "8px"
						}
					}
				},
				{
					Type: "text",
					DesignTimeConfig: {
						Caption: localizableStrings.TextCaption,
						Icon: localizableImages.TextIcon,
						Size: {
							ColSpan: 11,
							RowSpan: 1
						}
					},
					Settings: {
						schemaName: "ContentTextPropertiesPage",
						isStylesVisible: true,
						panelIcon: localizableImages.TextPanelIcon,
						notImplemented: !BPMSoft.Features.getIsEnabled("ContentBuilderPropertiesPanel")
					},
					DefaultConfig: {
						Content: localizableStrings.DefaultText,
						Styles: {
							"color": "#252F40",
							"padding-top": "8px",
							"padding-right": "8px",
							"padding-bottom": "8px",
							"padding-left": "8px"
						}
					}
				},
				{
					Type: "separator",
					DesignTimeConfig: {
						Caption: localizableStrings.SeparatorCaption,
						Icon: localizableImages.SeparatorIcon,
						Size: {
							ColSpan: 24,
							RowSpan: 1
						}
					},
					DefaultConfig: {
						Color: "#D8DBE2",
						Thickness: "1px",
						Style: "Solid",
						Styles: {
							"padding-top": "8px",
							"padding-right": "8px",
							"padding-bottom": "8px",
							"padding-left": "8px"
						}
					},
					Settings: {
						schemaName: "ContentSeparatorPropertiesPage",
						isStylesVisible: true,
						panelIcon: localizableImages.SeparatorPanelIcon
					}
				}
			];
			const collection = new BPMSoft.Collection();
			items.forEach(function(item) {
				if (!item.NotImplemented) {
					collection.add(item.Type, item);
				}
			}, this);
			return collection;
		},

		/**
		 * Returns items collection for current content builder config state.
		 * @return {BPMSoft.core.collections.Collection}
		 */
		getItems: function() {
			return this.getGridItems();
		},

		/**
		 * Return content item by type.
		 * @param {String} itemType Item type.
		 * @return {Object} Content item config.
		 */
		findByType: function(itemType) {
			return this.getItems().find(itemType);
		},

		/**
		 * Returns default block config.
		 * @return {Object}
		 */
		getDefaultBlockConfig: function() {
			const items = this.getItems();
			const htmlItem = items.get("html");
			const config = htmlItem.DesignTimeConfig;
			return {
				ItemType: "block",
				Items: [{
					ItemType: "html",
					Column: 0,
					Row: 0,
					ColSpan: config.Size.ColSpan,
					RowSpan: config.Size.RowSpan,
					Content: htmlItem.DefaultConfig.Content
				}]
			};
		}

		// endregion

	});
});

