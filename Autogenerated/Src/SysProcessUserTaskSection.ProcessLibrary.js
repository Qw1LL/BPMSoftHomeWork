define('SysProcessUserTaskSection', ['GridUtilitiesV2'],
function() {
	return {
		entitySchemaName: 'SysProcessUserTask',
		contextHelpId: '1001',
		diff: /**SCHEMA_DIFF*/[{
			"operation": "remove",
			"name": "DataGridActiveRowCopyAction"
		}]/**SCHEMA_DIFF*/,
		messages: {},
		methods: {
			/**
			 * @overridden
			 * @return {Object} ############# ####### ## #########.
			 */
			getDefaultDataViews: function() {
				var gridDataView = {
					name: "GridDataView",
					active: true,
					caption: this.getDefaultGridDataViewCaption(),
					icon: this.getDefaultGridDataViewIcon()
				};
				return {
					"GridDataView": gridDataView
				};
			},
			/**
			 * @overridden
			 */
			getFilters: function() {
				var filters = this.callParent(arguments);
				var filterName = "IsQuickModel";
				if (!filters.contains(filterName)) {
					filters.add(filterName, BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "IsQuickModel", true));
				}
				return filters;
			}
		}
	};
});
