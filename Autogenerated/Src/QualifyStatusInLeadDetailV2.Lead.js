define("QualifyStatusInLeadDetailV2", function() {
	return {
		entitySchemaName: "LeadInQualifyStatus",
		methods: {
			/**
			 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilters
			 * @override
			 */
			getFilters: function() {
				const filters = this.callParent();
				filters.add("isDisplayedFilter",
					this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "QualifyStatus.IsDisplayed", true
					)
				);
				return filters;
			},

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @override
			 */
			addRecordOperationsMenuItems: this.BPMSoft.emptyFn,

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
			 * @override
			 */
			getAddRecordButtonVisible: function() {
				return false;
			},

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @override
			 */
			getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
			 * @override
			 */
			getFilterDefaultColumnName: function() {
				return "QualifyStatus";
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"primaryDisplayColumnName": "QualifyStatus",
					"type": "listed"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
