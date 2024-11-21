define("PortalCaseSectionActionsDashboard", ["CaseSectionActionsDashboard",
		"PortalCaseSectionActionsDashboardResources", "DcmSectionActionsDashboardMixin"],
	function() {
		return {
			attributes: {},
			messages: {},
			mixins: {
				DcmSectionActionsDashboardMixin: "BPMSoft.DcmSectionActionsDashboardMixin"
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.DcmSectionActionsDashboardMixin#setDcmAvailableStages
				 * @overridden
				 */
				setDcmAvailableStages: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseActionsDashboard#initDefaultTab
				 * @override
				 */
				initDefaultTab: function() {
					this.set("DefaultTabName", "PortalMessageTab");
					this.callParent(arguments);
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
					"name": "SocialMessageTab"
				},
				{
					"operation": "remove",
					"name": "TaskMessageTab"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
