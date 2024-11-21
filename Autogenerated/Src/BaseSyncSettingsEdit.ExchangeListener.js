define("BaseSyncSettingsEdit", ["ExchangeNUIConstants"],
		function(ExchangeNUIConstants) {
	return {
		attributes: {
			/**
			 * EnableMailSynhronization column attribute.
			 * @private
			 */
			"EnableMailSynhronization": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		methods: {

			//region Methods: Protected

			/**
			 * Returns mail server type.
			 * @protected
			 * @return {String} Mail server type.
			 */
			getMailServerType: function() {
				var servers = this.$ServerListCollection;
				var server = servers.get(this.$MailBoxServerId);
				return server.$Type.value;
			},

			/**
			 * Recreates exchange server subscriptions.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			recreateListener: function(callback, scope) {
				if (this.getIsFeatureEnabled("OldEmailIntegration") ||
						!this.$EnableMailSynhronization || !this.$AllowEmailDownloading) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				this.callService({
					serviceName: "ExchangeEventsService",
					methodName: this.$EnableMailSynhronization ? "RecreateListener" : "StopListener",
					data: {
						"mailboxId": this.$MailboxSyncSettingsId
					}
				}, callback, scope || this);
			},

			/**
			 * Creates email synchronization job.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			createEmailSyncJob: function(callback, scope) {
				if (this.getIsFeatureEnabled("OldEmailIntegration") ||
					!this.$EnableMailSynhronization) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				this.callService({
					serviceName: "MailboxSettingsService",
					methodName: "CreateEmailSyncJob",
					data: {
						create: true,
						interval: 0,
						serverId: this.$MailBoxServerId,
						senderEmailAddress: this.$SenderEmailAddress
					}
				}, this.recreateListener(callback || this.BPMSoft.emptyFn, scope || this),
					scope || this);
			},

			/**
			 * @inheritdoc BaseSyncSettingsEdit#callCreateOrDeleteSyncJob
			 * @protected
			 */
			callCreateOrDeleteSyncJob: function(callback, scope, data) {
				if (!this.getIsFeatureEnabled("OldEmailIntegration")) {
					this.set("AutomaticallyAddNewEmails", false);
				}
				this.callParent([function() {
					this.createEmailSyncJob(callback || this.BPMSoft.emptyFn, scope || this);
				}, this, data]);
			},

			/**
			 * @inheritdoc BaseSyncSettingsEdit#updateSyncJobs
			 * @protected
			 */
			updateSyncJobs: function(callback, scope) {
				this.callParent([function() {
					this.createEmailSyncJob(callback || this.BPMSoft.emptyFn, scope || this);
				}, this]);
			},

			//endregion

		},
		diff: []
	};
});
