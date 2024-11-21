define("PartnershipPageMktgActivityDetail", [], function() {
	return {
		entitySchemaName: "MktgActivity",
		mixins: {},
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

			getEditRecordMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},
			
			getCopyRecordMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},
			
			getDeleteRecordMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},
			
			getRecordRightsSetupMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			
			getSwitchGridModeMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			
			getExportToExcelFileMenuItem: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			},

			
			getShowQuickFilterButton: function() {
				return this._isSspCurrentUser() ? null : this.callParent(arguments);
			}
		}
	};
});
