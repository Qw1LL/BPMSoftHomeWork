define("PortalColumnAccessListManager", ["PortalColumnAccessListManagerItem", "AnalyticsManager" ], function() {

	/**
	 * @class BPMSoft.PortalColumnAccessListManager
	 */
	Ext.define("BPMSoft.manager.PortalColumnAccessListManager", {
		extend: "BPMSoft.manager.AnalyticsManager",
		alternateClassName: "BPMSoft.PortalColumnAccessListManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.PortalColumnAccessListManagerItem",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "PortalColumnAccessList",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			columnUId: "ColumnUId",
			portalSchemaList: "PortalSchemaList"
		}

		// endregion

	});

	return BPMSoft.PortalColumnAccessListManager;
});
