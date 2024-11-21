define("MarketingCalendarCampaignsModule", ["BaseSchemaModuleV2", "ViewGeneratorV2", "MarketingCalendarCampaignsPage"],
	function() {
		Ext.define("BPMSoft.configuration.MarketingCalendarCampaignsModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.MarketingCalendarCampaignsModule",

			/**
			 * @inheritdoc BaseSchemaModuleV2#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "MarketingCalendarCampaignsPage";
				this.entitySchemaName = "CampaignPlanner";
			},

			/**
			 * @inheritdoc BaseSchemaModuleV2#initHistoryState
			 * @overridden
			 */
			initHistoryState: BPMSoft.emptyFn,

			getProfileKey: function() {
				//return "MarketingCalendar" + this.entitySchemaName + "_GridSettings";
				return "CampaignPlannerSectionGridSettingsGridDataView";
			}
		});
		return BPMSoft.MarketingCalendarCampaignsModule;
	});
