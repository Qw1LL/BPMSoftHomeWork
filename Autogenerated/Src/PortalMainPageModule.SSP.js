define("PortalMainPageModule", [ "PortalClientConstants", "MainHeaderSchema", "DashboardsModule",
	"PortalMainPageBuilder", "css!PortalMainPageModule"],
	function(PortalClientConstants) {
		/**
		 * @class BPMSoft.configuration.PortalMainPageModule
		 * Portal main page module.
		 */
		Ext.define("BPMSoft.configuration.PortalMainPageModule", {
			extend: "BPMSoft.DashboardsModule",
			alternateClassName: "BPMSoft.PortalMainPageModule",

			/**
			 * Base portal main page view model class name.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.BasePortalMainPageViewModel",

			/**
			 * Portal main page builder class name.
			 * @type {String}
			 */
			builderClassName: "BPMSoft.PortalMainPageBuilder",

			/**
			 * Portal main page view generator class name.
			 * @type {String}
			 */
			viewConfigClass: "BPMSoft.PortalMainPageViewConfig",

			/**
			 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#getProfileKey
			 * @overridden
			 */
			getProfileKey: function() {
				return "PortalMainPageId";
			},

			/**
			 * @inheritDoc BPMSoft.configuration.DashboardsModule#getDashboardSectionId
			 * @override
			 */
			getDashboardSectionId: function() {
				return PortalClientConstants.SysModule.PortalMainPageSectionId;
			}
		});
		return BPMSoft.PortalMainPageModule;
	}
);
