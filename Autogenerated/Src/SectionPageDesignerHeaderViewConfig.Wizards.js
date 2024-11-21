define("SectionPageDesignerHeaderViewConfig", [
	"SectionPageDesignerHeaderViewConfigResources",
	"SectionPageDesignerHeaderModule",
	"PageDesignerHeaderViewConfig"
], function(resources) {

	/**
	 * Class for SectionPageDesignerHeaderViewConfig.
	 */
	Ext.define("BPMSoft.configuration.SectionPageDesignerHeaderViewConfig", {
		extend: "BPMSoft.configuration.PageDesignerHeaderViewConfig",
		alternateClassName: "BPMSoft.SectionPageDesignerHeaderViewConfig",

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.PageDesignerHeaderViewConfig#getUtilsLeftContainerViewConfig
		 * @override
		 */
		getUtilsLeftContainerViewConfig: function() {
			const config = this.callParent();
			const saveButtonConfig = _.find(config.items, {name: "SaveButton"});
			saveButtonConfig.caption = resources.localizableStrings.SaveButtonCaption;
			saveButtonConfig.style = BPMSoft.controls.ButtonEnums.style.ORANGE;
			saveButtonConfig.tips[0].content = resources.localizableStrings.SaveButtonHint;
			return config;
		}

		//endregion
	});

});
