define("WidgetDashboardManager", ["BaseDashboardManager"], function() {

	/**
	 * @class BPMSoft.WidgetDashboardManager
	 * @public
	 *Widget dashboard manager class.
	 */
	Ext.define("BPMSoft.WidgetDashboardManager", {
		extend: "BPMSoft.BaseDashboardManager",
		alternateClassName: "BPMSoft.WidgetDashboardManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "SysWidgetDashboard",

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {items: "Items"},

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#lazyLoadingProperties
		 * @overridden
		 */
		lazyLoadingProperties: ["items"],

		/**
		 * @inheritdoc BPMSoft.OutdatedSchemaNotificationMixin#outdatedEventName
		 * @override
		 */
		outdatedEventName: "WidgetDashboardItem_Outdated",

		/**
		 * @inheritdoc BPMSoft.OutdatedSchemaNotificationMixin#useNotification
		 * @override
		 */
		useNotification: true

		// endregion

	});
	return BPMSoft.WidgetDashboardManager;
});
