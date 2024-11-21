define("DetailManager", ["DetailManagerItem"], function() {
	/**
	 * @class BPMSoft.DetailManager
	 * Class of detail manager.
	 */
	Ext.define("BPMSoft.DetailManager", {
		extend: "BPMSoft.ObjectManager",
		alternateClassName: "BPMSoft.DetailManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.DetailManagerItem",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "SysDetail",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			caption: "Caption",
			detailSchemaUId: "DetailSchemaUId",
			entitySchemaUId: "EntitySchemaUId",
			detailSchemaName: "[SysSchema:UId:DetailSchemaUId].Name",
			entitySchemaName: "[SysSchema:UId:EntitySchemaUId].Name"
		}

		// endregion

	});
	return BPMSoft.DetailManager;
});
