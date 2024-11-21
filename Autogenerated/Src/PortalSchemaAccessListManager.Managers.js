define("PortalSchemaAccessListManager", ["PortalSchemaAccessListManagerItem"], function() {

	/**
	 * @class BPMSoft.PortalSchemaAccessListManager
	 */
	Ext.define("BPMSoft.manager.PortalSchemaAccessListManager", {
		extend: "BPMSoft.manager.ObjectManager",
		alternateClassName: "BPMSoft.PortalSchemaAccessListManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.PortalSchemaAccessListManagerItem",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "PortalSchemaAccessList",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			entitySchemaUId: "SchemaUId",
			entitySchemaName: "AccessEntitySchemaName"
		}

		// endregion

	});

	return BPMSoft.PortalSchemaAccessListManager;
});
