define("SectionDashboardsModule", ["DashboardsModule", "SectionDashboardsViewModel", "SectionDashboardBuilder",
	"HistoryStateUtilities"],
function() {
	/**
	 * @class BPMSoft.configuration.SectionDashboardsModule
	 * ##### ########### ###### ######.
	 */
	return Ext.define("BPMSoft.configuration.SectionDashboardsModule", {
		extend: "BPMSoft.DashboardsModule",
		alternateClassName: "BPMSoft.SectionDashboardsModule",
		viewModelClassName: "BPMSoft.SectionDashboardsViewModel",
		builderClassName: "BPMSoft.SectionDashboardBuilder",

		/**
		 *
		 */
		mixins: {
			/**
			 * ######, ########### ###### # HistoryState
			 */
			HistoryStateUtilities: "BPMSoft.HistoryStateUtilities"
		},

		/**
		 * ########### ############# #########, ### ### # ####### ############ ### ######### ######.
		 * @overridden
		 * @protected
		 */
		initHistoryState: BPMSoft.emptyFn,

		/**
		 * ####### ########## ######.
		 */
		render: function() {
			this.callParent(arguments);
			this.sandbox.publish("NeedHeaderCaption");
		},

		/**
		 * @inheritDoc BPMSoft.configuration.DashboardsModule#getDashboardSectionId
		 * @override
		 */
		getDashboardSectionId: function() {
			const sectionInfo = this.getSectionInfo() || {};
			return sectionInfo.moduleId || BPMSoft.GUID_EMPTY;
		}

	});

});
