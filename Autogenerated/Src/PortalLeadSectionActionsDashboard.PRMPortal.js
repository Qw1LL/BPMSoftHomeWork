define("PortalLeadSectionActionsDashboard", ["LeadSectionActionsDashboard",
		"PortalLeadSectionActionsDashboardResources"],
	function() {
		return {
			attributes: {
				/**
				 * Usage state of dashboard.
				 */
				"UseDashboard": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: this.BPMSoft.Features.getIsEnabled("UsePortalLeadPageDashboard")
				}
			},
			methods: {

				/**
				 * @override BPMSoft.BaseActionsDashboard
				 */
				initDefaultTab: function() {
					if (this.isNeedLockDefaultTab()) {
						this.set("DefaultTabName");
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * Checks if need lock default tab.
				 * @return {Boolean}
				 */
				isNeedLockDefaultTab: function() {
					var defaultTabName = this.getDefaultTabName();
					var dashboardTabName = this.get("DashboardTabName");
					var isFeatureEnabled = this.BPMSoft.Features.getIsEnabled("UsePortalLeadPageDashboard");
					return !isFeatureEnabled && defaultTabName === dashboardTabName;
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "CallMessageTab"
				},
				{
					"operation": "remove",
					"name": "EmailMessageTab"
				},
				{
					"operation": "remove",
					"name": "TaskMessageTab"
				},
				{
					"operation": "remove",
					"name": "SocialMessageTab"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
