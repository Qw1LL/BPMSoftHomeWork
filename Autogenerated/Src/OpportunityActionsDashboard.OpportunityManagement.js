define("OpportunityActionsDashboard", [], function() {
	return {
		methods: {

			/**
			 * @inheritdoc BPMSoft.SectionActionsDashboard#onReloadDashboardItems
			 * @overridden
			 */
			onReloadDashboardItems: function() {
				var isMasterEntityUsedInProcess = this.getMasterEntityParameterValue("ByProcess");
				if (isMasterEntityUsedInProcess) {
					this.reloadMasterEntityCard();
				} else {
					this.callParent(arguments);
				}
			}

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
