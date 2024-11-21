define("SectionManager", ["SectionManagerItem"], function() {

	/**
	 * Class of section manager.
	 */
	Ext.define("BPMSoft.manager.SectionManager", {
		extend: "BPMSoft.manager.ObjectManager",
		alternateClassName: "BPMSoft.SectionManager",
		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.SectionManagerItem",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "SysModule",

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			caption: "Caption",
			code: "Code",
			sysModuleEntity: "SysModuleEntity",
			schemaUId: "SectionSchemaUId",
			moduleSchemaUId: "SectionModuleSchemaUId",
			globalSearchAvailable: "GlobalSearchAvailable",
			leftPanelLogo: "Image32",
			folderMode: "FolderMode",
			attribute: "Attribute",
			sysModuleVisa: "SysModuleVisa",
			isSystem: "IsSystem",
			type: "Type",
			modifiedOn: "ModifiedOn"
		}

		// endregion

	});

	return BPMSoft.SectionManager;
});
