define("VwDcmLibSectionGridRowViewModel", ["ext-base", "VwDcmLibSectionGridRowViewModelResources",
	"BaseSectionGridRowViewModel"], function(Ext, resources) {

	Ext.define("BPMSoft.configuration.VwDcmLibSectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.VwDcmLibSectionGridRowViewModel",

		columns: {
			"ShowPropertiesButton": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResources(resources.localizableStrings);
		}
	});

	return BPMSoft.VwDcmLibSectionGridRowViewModel;
});
