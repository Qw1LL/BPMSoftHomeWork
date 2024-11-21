define("SchemaParameterDesignToolItem", [
	"SchemaColumnDesignToolItem",
	"SchemaDesignToolItemResources"
], function(module, resources) {
	Ext.define("BPMSoft.SchemaParameterDesignToolItem", {
		extend: "BPMSoft.SchemaColumnDesignToolItem",

		/**
		 * @inheritdoc BPMSoft.configuration.SchemaDesignToolItem#columns
		 */
		columns: {
			ToolsMenuItems: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			EnableRightIcon: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initToolsMenuItems();
		},

		/**
		 * @protected
		 */
		initToolsMenuItems: function() {
			const menuItems = new BPMSoft.BaseViewModelCollection();
			const removeMenuItem = new BPMSoft.BaseViewModel({
				values: {
					Caption: resources.localizableStrings.RemoveColumnDesignItemMenuItemCaption,
					Click: {"bindTo": "onRemoveMenuItemClick"}
				}
			});
			menuItems.addItem(removeMenuItem);
			this.set("ToolsMenuItems", menuItems);
		},

		/**
		 * @inheritdoc BPMSoft.SchemaColumnDesignToolItem#getDesignItemConfg
		 * @override
		 */
		getDesignItemConfg: function() {
			return Ext.apply({}, {
				schemaModelItemDesignerName: "ClientUnitSchemaModelItemDesigner"
			}, this.callParent(arguments));
		}
	});
	return BPMSoft.SchemaParameterDesignToolItem;
});
