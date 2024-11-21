define("SystemNotificationsSchema", [], function() {
	return {
		methods: {
			/**
			 * Returns true if license generation notification.
			 * @protected
			 * @returns {Boolean} True if license generation notification.
			 */
			isLicenseNotification: function() {
				return this.get("LoaderName") === "ExpireLicenseNotificationProcess";
			},

			/**
			 * @inheritdoc BPMSoft.BaseNotificationsSchema#onNotificationSubjectClick
			 * @overridden
			 */
			onNotificationSubjectClick: function() {
				if (!this.isLicenseNotification()) {
					this.callParent(arguments);
					return;
				}
				const url = BPMSoft.combinePath(BPMSoft.workspaceBaseUrl, "ClientApp/#/LicenseManager");
				window.open(url, "_blank");
			},

			/**
			 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationLinkAttributes
			 * @overridden
			 */
			getNotificationLinkAttributes: function() {
				if (!this.isLicenseNotification()) {
					return this.callParent(arguments);
				}
				return { activelink: true };
			},
		},
		diff: []
	};
});
