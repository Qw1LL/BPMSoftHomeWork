define("SysModuleEditManager", ["SysModuleEditManagerItem"], function() {
	/**
	 * Section pages manager.
	 */
	Ext.define("BPMSoft.manager.SysModuleEditManager", {
		extend: "BPMSoft.manager.ObjectManager",
		alternateClassName: "BPMSoft.SysModuleEditManager",

		singleton: true,

		// region Properties: Private

		/**
		 * ######## ###### ######## #########.
		 * @private
		 * {String}
		 */
		itemClassName: "BPMSoft.SysModuleEditManagerItem",

		/**
		 * ######## #####.
		 * @private
		 * {String}
		 */
		entitySchemaName: "SysModuleEdit",

		/**
		 * ###### ############ ####### ########.
		 * @private
		 * @type {Object}
		 */
		propertyColumnNames: {
			sysModuleEntity: "SysModuleEntity",
			cardSchemaUId: "CardSchemaUId",
			typeColumnValue: "TypeColumnValue",
			useModuleDetails: "UseModuleDetails",
			position: "Position",
			helpContextId: "HelpContextId",
			actionKindCaption: "ActionKindCaption",
			actionKindName: "ActionKindName",
			pageCaption: "PageCaption",
			miniPageSchemaUId: "MiniPageSchemaUId",
			miniPageModes: "MiniPageModes"
		}

		// endregion

	});

	return BPMSoft.SysModuleEditManager;
});
