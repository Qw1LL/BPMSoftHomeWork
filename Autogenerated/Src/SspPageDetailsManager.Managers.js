define("SspPageDetailsManager", ["SspPageDetailsManagerItem", "AnalyticsManager"
], function() {

	/**
	 * @class BPMSoft.SspPageDetailsManager
	 * SSP section edit page details registration.
	 */
	Ext.define("BPMSoft.manager.SspPageDetailsManager", {
		extend: "BPMSoft.manager.AnalyticsManager",
		alternateClassName: "BPMSoft.SspPageDetailsManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.SspPageDetailsManagerItem",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "SspPageDetail",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			cardSchemaUId: "CardSchemaUId",
			entitySchemaUId: "EntitySchemaUId",
			sysDetail: "SysDetail"
		}

		// endregion

	});

	return BPMSoft.SspPageDetailsManager;
});
