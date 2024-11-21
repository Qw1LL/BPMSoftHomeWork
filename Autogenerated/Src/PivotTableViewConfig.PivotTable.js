define("PivotTableViewConfig", ["DashboardListedGridViewConfig", "PivotTable"], function() {
	Ext.define("BPMSoft.PivotTableViewConfig", {
		extend: "BPMSoft.DashboardListedGridViewConfig",		

		/**
		 * @inheritDoc
		 * @override
		 */
		getGridToolsViewConfig: function() {
			return null;
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDashboardGridHeaderItems: function() {
			const gridHeaderItems = this.callParent(arguments);
			return BPMSoft.filter(gridHeaderItems, function(item) {
				return !Ext.isEmpty(item);
			});
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDashboardGridViewConfig: function(moduleId) {
			return {
				"id": Ext.String.format("grid-{0}", moduleId),
				"name": "PivotTable",	
				"className": "BPMSoft.PivotTable",
				"options": {"bindTo": "Options"},
				"itemType": BPMSoft.ViewItemType.COMPONENT,
				"tableId": {"bindTo": "TableId"},
			};
		},
		
	});
	return {};
});
