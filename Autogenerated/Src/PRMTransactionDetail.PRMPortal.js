define("PRMTransactionDetail", [],
		function() {
	return {
		entitySchemaName: "PRMTransaction",
		methods: {

			/**
			 * @inheritDoc BaseGridDetailV2#getAddRecordButtonVisible
			 * @override
			 */
			getAddRecordButtonVisible: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#getQuickFilterButton
			 * @override
			 */
			getShowQuickFilterButton: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
			 * @override
			 */
			getGridSortMenuItem: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @override
			 */
			getSwitchGridModeMenuItem: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @override
			 */
			addDetailWizardMenuItems: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getExportToExcelFileMenuItem
			 * @override
			 */
			getExportToExcelFileMenuItem: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @override
			 */
			addRecordOperationsMenuItems: function() {
				if (BPMSoft.isCurrentUserSsp()){
					return;
				}
				this.callParent(arguments);
			}
		}
	};
});
