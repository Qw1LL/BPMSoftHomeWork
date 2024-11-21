define("ClientUnitParameterPropertiesPageModule", [
	"ClientUnitParameterPropertiesPageModuleResources",
	"EntityColumnPropertiesPageModule"
	],
	function(resources) {
	Ext.define("BPMSoft.ClientUnitParameterPropertiesPageModule", {
		extend: "BPMSoft.EntityColumnPropertiesPageModule",

		/**
		 * @inheritDoc BPMSoft.DateTimeColumnPropertiesPageModule
		 * override
		 */
		getPropertiesPageTranslation: function(viewModel) {
			const translation = this.callParent(arguments);
			translation.isRequiredLabel = resources.localizableStrings.isRequiredLabel;
			return translation;
		},

		/**
		 * @inheritDoc BPMSoft.EntityColumnPropertiesPageModule
		 * override
		 */
		getPageItemType: function() {
			return "processParameter";
		},

		/**
		 * @override
		 */
		init: function() {
			this.initResources(resources);
			this.callParent(arguments);
		}

	});
	return BPMSoft.ClientUnitParameterPropertiesPageModule;
});
