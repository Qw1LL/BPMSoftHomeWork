define("SectionDashboardBuilder", ["ext-base", "SectionDashboardBuilderResources", "DashboardBuilder"],
function(Ext) {

	/**
	 * @class BPMSoft.configuration.DashboardBuilder
	 * ##### ############### # #### ###### ######### ############# # ###### ###### ############# ### ###### ######.
	 */
	Ext.define("BPMSoft.configuration.SectionDashboardBuilder", {
		extend: "BPMSoft.DashboardBuilder",
		alternateClassName: "BPMSoft.SectionDashboardBuilder",

		/**
		 * ### ####### ###### ############# ### ###### ######.
		 * @type {String}
		 */
		viewModelClass: "BPMSoft.SectionDashboardsViewModel",

		/**
		 * ### ######## ##### ########## ############ ############# ######.
		 * @type {String}
		 */
		viewConfigClass: "BPMSoft.DashboardViewConfig"

	});

	return BPMSoft.SectionDashboardBuilder;

});
