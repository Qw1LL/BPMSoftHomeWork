define("ItemSectionGridRowViewModel", ["ItemSectionGridRowViewModelResources",
		"BaseSectionGridRowViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.QueueGridRowViewModel
		 * ##### ###### ############# ###### #######.
		 */
		Ext.define("BPMSoft.configuration.ItemSectionGridRowViewModel", {
			extend: "BPMSoft.BaseSectionGridRowViewModel",
			alternateClassName: "BPMSoft.ItemSectionGridRowViewModel",

			Ext: null,

			BPMSoft: null,

			sandbox: null,

			columns: {},
			/**
			 * ########## ######### ###### ######## ###.
			 * @returns {String} ######### ######.
			 */
			getOpenServiceModelPageCaption: function() {
				return resources.localizableStrings.OpenServiceModelPageCaption;
			}
		});
	});
