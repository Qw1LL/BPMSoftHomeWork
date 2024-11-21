define("SectionInWorkplaceManager", ["SectionInWorkplaceManagerItem"], function() {
	/**
	 * @class BPMSoft.SectionInWorkplaceManager
	 * Class of section in workplace manager.
	 */
	Ext.define("BPMSoft.SectionInWorkplaceManager", {
		extend: "BPMSoft.ObjectManager",
		alternateClassName: "BPMSoft.SectionInWorkplaceManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.SectionInWorkplaceManagerItem",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "SysModuleInWorkplace",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			position: "Position",
			workplace: "SysWorkplace",
			section: "SysModule"
		}

		// endregion

	});

	return BPMSoft.SectionInWorkplaceManager;
});
