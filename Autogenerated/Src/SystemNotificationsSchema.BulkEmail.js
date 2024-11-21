define("SystemNotificationsSchema", ["TagConstantsV2", "ModuleUtils", "FileImportServiceRequest",
		"css!SystemNotificationsSchemaCSS"], function(TagConstantsV2, ModuleUtils) {
	return {
		methods: {

			/**
			 * @inheritdoc BPMSoft.configuration.BaseNotificationSchema#onNotificationSubjectClick
			 * @overridden
			 */
			onNotificationSubjectClick: function() {
				var loaderName = this.get("LoaderName");
				if (loaderName !== "ActualizeActiveContactsProcess") {
					this.callParent(arguments);
					return;
				}
				var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "Nui",
					"ViewModule.aspx#DashboardsModule");
				window.open(url, "_blank");
			}
		
		},
		diff: []
	};
});
