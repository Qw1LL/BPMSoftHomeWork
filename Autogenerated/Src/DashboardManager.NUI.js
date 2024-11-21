define("DashboardManager", ["BaseDashboardManager"], function() {

	/**
	 * @class BPMSoft.DashboardManager
	 * @public
	 * Dashboard manager class.
	 */
	Ext.define("BPMSoft.DashboardManager", {
		extend: "BPMSoft.BaseDashboardManager",
		alternateClassName: "BPMSoft.DashboardManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "SysDashboard",

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			caption: "Caption",
			position: "Position",
			viewConfig: "ViewConfig",
			items: "Items",
			sectionId: "Section"
		},

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#lazyLoadingProperties
		 * @overridden
		 */
		lazyLoadingProperties: ["viewConfig", "items"]

		// endregion

	});
	return BPMSoft.DashboardManager;
});
