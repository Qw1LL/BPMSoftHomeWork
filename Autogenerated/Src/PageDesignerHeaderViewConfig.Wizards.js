define("PageDesignerHeaderViewConfig", [
	"PageDesignerHeaderViewConfigResources",
	"PageDesignerHeaderModule"
], function(resources) {
	/**
	 * Class for PageDesignerHeaderViewConfig.
	 */
	Ext.define("BPMSoft.configuration.PageDesignerHeaderViewConfig", {
		extend: "BPMSoft.configuration.WizardHeaderViewConfig",
		alternateClassName: "BPMSoft.PageDesignerHeaderViewConfig",

		/**
		 * @inheritdoc WizardHeaderViewConfig#getUtilsContainerViewConfig
		 * @override
		 */
		getUtilsContainerViewConfig: function() {
			var config = this.callParent();
			config.items.push(this.getUtilsToolsContainerViewConfig());
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.WizardHeaderViewConfig#getUtilsLeftContainerViewConfig
		 * @override
		 */
		getUtilsLeftContainerViewConfig: function() {
			var config = this.callParent();
			config.items.push({
				itemType: BPMSoft.ViewItemType.BUTTON,
				name: "ActionsButton",
				caption: "Actions",
				visible: {bindTo: "isActionsButtonVisible"},
				classes: {
					textClass: ["utils-button"],
					wrapperClass: ["utils-button"]
				},
				menu: [
					{
						caption: "Source Code (Ctrl+K)",
						click: {bindTo: "onOpenSourceCode"}
					},
					{
						caption: "View Metadata (Ctrl+M)",
						click: {bindTo: "onOpenMetaData"}
					},
					{
						caption: "Export Metadata",
						click: {bindTo: "onExportMetaData"}
					}
				]
			});
			return config;
		},

		/**
		 * @protected
		 */
		getUtilsToolsContainerViewConfig: function() {
			return {
				"name": "utilsToolsContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["utils-tools"],
				"items": [{
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"name": "PropertyPageWizardButton",
					"classes": {"wrapperClass": "schema-properties-button"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {"bindTo": "onShowPropertyPage"},
					"markerValue": "SchemaPropertiesButton",
					"imageConfig": resources.localizableImages.PageWizardPropertiesPageIcon,
					"hint": resources.localizableStrings.SchemaPropertiesButtonHint
				}]
			};
		}
	});

});
