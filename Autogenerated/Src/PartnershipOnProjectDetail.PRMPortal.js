define("PartnershipOnProjectDetail", [], function() {
	return {
		entitySchemaName: "Project",
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {
			/**
			 * Checks if current user is Ssp user.
			 * //TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
			 * @private
			 * @return {Boolean} True if type of current user is ssp, otherwise - false.
			 */
			_isSspCurrentUser: function() {
				return BPMSoft.CurrentUser.userType === BPMSoft.UserType.SSP;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#getQuickFilterButton
			 * @overridden
			 */
			getShowQuickFilterButton: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @overridden
			 */
			getDeleteRecordMenuItem: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getExportToExcelFileMenuItem
			 * @overridden
			 */
			getExportToExcelFileMenuItem: function() {
				//TODO replace to !BPMSoft.utils.common.isSspCurrentUser() after release 7.14.2
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getRecordRightsSetupMenuItemVisible
			 * @overridden
			 */
			getRecordRightsSetupMenuItemVisible: function() {
				return this._isSspCurrentUser() ? false : this.callParent(arguments);
			}
		}
	};
});
