define("CenterNotificationSchema", [],
	function() {
		return {
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					var isPortalUser = this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
					if (isPortalUser) {
						this.mixins.TitleNotificationUtilities.blinkIterator = 0;
						this.mixins.TitleNotificationUtilities.blinkInterval = 0;
					}
				},
				/**
				 * @inheritDoc BPMSoft.CenterNotificationSchema#initializeNotifications
				 * @overridden
				 */
				initializeNotifications: function() {
					var isPortalUser = this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
					if (isPortalUser) {
						return;
					}
					this.callParent(arguments);
				}
			}
		};
	});
