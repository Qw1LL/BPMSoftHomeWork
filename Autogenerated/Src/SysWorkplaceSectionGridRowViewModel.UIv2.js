define("SysWorkplaceSectionGridRowViewModel", ["ext-base", "SysWorkplaceSectionGridRowViewModelResources",
		"BaseSectionGridRowViewModel"], function(Ext, resources) {
	/**
	 * @class BPMSoft.configuration.SysWorkplaceSectionGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.SysWorkplaceSectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.SysWorkplaceSectionGridRowViewModel",

		/**
		 * ############## #######.
		 * @inheritdoc BPMSoft.configuration.BaseGridRowViewModel#initResources
		 */
		initResources: function(strings) {
			strings = strings || {};
			this.callParent([Ext.apply(BPMSoft.deepClone(strings)), resources.localizableStrings]);
		}
	});
	return BPMSoft.SysWorkplaceSectionGridRowViewModel;
});
