define("VwProcessLibSectionGridRowViewModel", ["ext-base", "VwProcessLibSectionGridRowViewModelResources",
	"BaseSectionGridRowViewModel"], function(Ext, resources) {

	Ext.define("BPMSoft.configuration.VwProcessLibSectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.VwProcessLibSectionGridRowViewModel",

		/**
		 * @inheritdoc BPMSoft.configuration.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResources(resources.localizableStrings);
		},

		/**
		 * Returns flag that indicates visible of run process button.
		 * @return {Boolean}
		 */
		getIsVisibleRunProcessButton: function() {
			return !this.get("isMultiSelectVisible") && this.get("Enabled");
		}
	});
	return BPMSoft.VwProcessLibSectionGridRowViewModel;
});
