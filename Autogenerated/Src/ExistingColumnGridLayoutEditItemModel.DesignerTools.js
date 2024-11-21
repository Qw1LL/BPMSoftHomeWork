define("ExistingColumnGridLayoutEditItemModel", ["ColumnGridLayoutEditItemModel"], function() {

	/**
	 * BPMSoft.configuration.ExistingColumnGridLayoutEditItemModel
	 */
	Ext.define("BPMSoft.configuration.ExistingColumnGridLayoutEditItemModel", {
		extend: "BPMSoft.ColumnGridLayoutEditItemModel",
		alternateClassName: "BPMSoft.ExistingColumnGridLayoutEditItemModel",

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#addToDesignSchema
		 * @overridden
		 */
		addToDesignSchema: function(config) {
			this.addItemToDesignSchemaCollection(config.layoutName);
			var existingModelDraggableItems = this.parentViewModel.get("ExistingModelDraggableItems");
			var columnUId = this.column.getPropertyValue("uId");
			var schemaDesignToolItem = existingModelDraggableItems.get(columnUId);
			schemaDesignToolItem.set("IsUsed", true);
		}
	});

	return BPMSoft.ExistingColumnGridLayoutEditItemModel;
});
