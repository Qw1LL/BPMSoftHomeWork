define("EducationAndCertificateDetail", [], function() {
	return {
		entitySchemaName: "EducationActivity",
		attributes: {},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {

			/**
			 * Checks if current user is Ssp user.
			 * @private
			 * @return {Boolean} True if type of current user is ssp, otherwise - false.
			 */
			_isSspCurrentUser: function() {
				return BPMSoft.utils.common.isCurrentUserSsp();
			},

			/**
			 * @inheritDoc BaseGridDetailV2#getAddRecordButtonVisible
			 * @protected
			 */
			getAddRecordButtonVisible: function() {
				return !this._isSspCurrentUser();
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#getQuickFilterButton
			 * @overridden
			 */
			getShowQuickFilterButton: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
			 * @overridden
			 */
			getGridSortMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @overridden
			 */
			getDeleteRecordMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getExportToExcelFileMenuItem
			 * @overridden
			 */
			getExportToExcelFileMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			}
		}
	};
});
