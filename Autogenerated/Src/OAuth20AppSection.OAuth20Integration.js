define("OAuth20AppSection", ["RightUtilities", "OAuth20Utilities"], function(RightUtilities) {
	return {
		entitySchemaName: "OAuthApplications",
		attributes: {},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_canManageSolution: function(callback, scope) {
				RightUtilities.checkCanExecuteOperation({operation: "CanManageSolution"}, function(result) {
					callback.call(scope, result);
				}, this);
			},

			/**
			 * @private
			 */
			_performDeleteApplications: function(ids) {
				BPMSoft.MaskHelper.showBodyMask();
				const promiseQueue = ids.map(function(id) {
					return new Promise(this._sendRemoveRequest.bind(this, id));
				}, this);
				Promise.all(promiseQueue).then(this._onAfterRemoveCompleted.bind(this));
			},

			/**
			 * @private
			 */
			_onAfterRemoveCompleted: function() {
				BPMSoft.MaskHelper.hideBodyMask();
				this.reloadGridData();
			},

			/**
			 * @private
			 */
			_sendRemoveRequest: function(id, callback) {
				BPMSoft.AjaxProvider.request({
					url: this._getRemoveApplicationUrl(id),
					method: "POST",
					scope: this,
					callback: callback
				});
			},

			/**
			 * @private
			 */
			_getRemoveApplicationUrl: function(item) {
				return this.BPMSoft.workspaceBaseUrl +
					"/ServiceModel/ServiceOAuthAuthenticatorEndpoint.svc/RemoveOAuthApplication/" + item;
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc GridUtilitiesV2#checkCanDelete
			 * @override
			 */
			checkCanDelete: function(items, callback, scope) {
				this._canManageSolution(function(result) {
					callback.call(scope, result ? null : "RightLevelWarningMessage");
				}, this);
			},

			/**
			 * @inheritodoc BaseSectionV2#getModuleCaption
			 * @override
			 */
			getModuleCaption: function() {
				var moduleStructure = this.getModuleStructure("OAuth20App");
				return moduleStructure && moduleStructure.moduleCaption;
			},

			/**
			 * @inheritodoc BaseSectionV2#getDefaultDataViews
			 * @override
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritodoc GridUtilitiesV2#onDelete
			 * @override
			 */
			onDelete: function(returnCode) {
				if (returnCode !== this.BPMSoft.MessageBoxButtons.YES.returnCode) {
					return;
				}
				const items = this.getSelectedItems();
				this._performDeleteApplications(items);
			},

			/**
			 * Initializes section filters.
			 * @protected
			 */
			initSectionFiltersCollection: function() {
				this.callParent(arguments);
				BPMSoft.OAuth20Utilities.addCustomApplicationFilters(this.$SectionFilters);
			}

			// endregion

		}
	};
});
