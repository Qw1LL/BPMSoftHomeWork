define("PrmPortalFunnelBaseDataProvider", ["FunnelBaseDataProvider"],
	function() {

		/**
		 * @class BPMSoft.configuration.PrmPortalFunnelBaseDataProvider
		 * Base class to build funnel chart.
		 */
		Ext.define("BPMSoft.configuration.PrmPortalFunnelBaseDataProvider", {
			override :  "BPMSoft.FunnelBaseDataProvider",
			alternateClassName: "BPMSoft.PrmPortalFunnelBaseDataProvider",
			
			rootSchemaName: "VwPortalOpportunity"
		});
	});

