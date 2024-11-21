define("SystemDesignerDashboardsModule", ["ext-base", "DashboardsModule", "SectionDashboardsViewModel",
		"SectionDashboardBuilder", "HistoryStateUtilities"],
	function() {

		/**
		 * @class BPMSoft.configuration.SystemDesignerDashboardsModule
		 * ##### ########### ###### ###### ### ####### ######### #######.
		 */
		return Ext.define("BPMSoft.configuration.SystemDesignerDashboardsModule", {
			extend: "BPMSoft.DashboardsModule",
			alternateClassName: "BPMSoft.SystemDesignerDashboardsModule",
			viewModelClassName: "BPMSoft.SystemDesignerDashboardsViewModel",
			viewConfigClass: "BPMSoft.SystemDesignerDashboardsViewConfig",
			builderClassName: "BPMSoft.SystemDesignerDashboardBuilder",

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
			 * @inheritDoc BPMSoft.configuration.DashboardsModule#getDashboardSectionId
			 * @override
			 */
			getDashboardSectionId: function() {
				const sectionInfo = this.getSectionInfo() || {};
				return sectionInfo.moduleId || BPMSoft.GUID_EMPTY;
			}
		});
	});
