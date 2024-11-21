define("DynamicContentGroupMenu", [], function() {
	Ext.define("BPMSoft.controls.DynamicContentGroupMenu", {
		extend: "BPMSoft.Menu",
		alternateClassName: "BPMSoft.DynamicContentGroupMenu",

		ulClass: "dynamic-content-group-menu",

		/**
		 * @inheritdoc BPMSoft.Menu#getMenuItemConfig
		 * @override
		 */
		getMenuItemConfig: function(itemModel) {
			var itemConfig = this.callParent(arguments);
			itemConfig.handler = itemModel.$Handler;
			return itemConfig;
		}
	});
});
