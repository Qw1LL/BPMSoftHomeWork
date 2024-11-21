define("ProjectGridRowViewModel", ["ProjectGridRowViewModelResources", "BaseSectionGridRowViewModel"],
	function(resources) {

	/**
	 * @class BPMSoft.configuration.ProjectGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.ProjectGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.ProjectGridRowViewModel",

		/**
		 * ############## ####### #######
		 * @protected
		 * @overridden
		 */
		initResources: function() {
			this.callParent(arguments);
			BPMSoft.each(resources.localizableStrings, function(item, key) {
				this.set("Resources.Strings." + key, item);
			}, this);
		}
	});

	return BPMSoft.BaseGridRowViewModel;
});
