define("EntityConnectionManager", ["EntityConnectionManagerItem"], function() {
	Ext.define("BPMSoft.EntityConnectionManager", {
		extend: "BPMSoft.ObjectManager",
		alternateClassName: "BPMSoft.EntityConnectionManager",
		singleton: true,

		//region Properties: Private

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.EntityConnectionManagerItem",

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "EntityConnection",

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			sysEntitySchemaUId: "SysEntitySchemaUId",
			columnUId: "ColumnUId"
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#getPackageSchemaDataName
		 * @overridden
		 */
		getPackageSchemaDataName: function(item) {
			var itemId = item.getPropertyValue("id");
			var dataName = Ext.String.format("{0}_{1}", this.entitySchemaName, itemId.replace(/-/g, ""));
			return dataName;
		}

		// endregion

	});

	return BPMSoft.EntityConnectionManager;
});
