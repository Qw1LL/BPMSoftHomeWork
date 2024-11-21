define("MarketingCalendarMktgActivitiesModule", ["BaseSchemaModuleV2", "ViewGeneratorV2",
		"MarketingCalendarMktgActivitiesPage"],
	function() {
		Ext.define("BPMSoft.configuration.MarketingCalendarMktgActivitiesModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.MarketingCalendarMktgActivitiesModule",

			/**
			 * @inheritdoc BaseSchemaModuleV2#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "MarketingCalendarMktgActivitiesPage";
				this.entitySchemaName = "MktgActivity";
			},

			/**
			 * @inheritdoc BaseSchemaModuleV2#initHistoryState
			 * @overridden
			 */
			initHistoryState: BPMSoft.emptyFn,

			getProfileKey: function() {
				//return "MarketingCalendar" + this.entitySchemaName + "_GridSettings";
				return "MktgActivitySectionGridSettingsGridDataView";
			}
		});
		return BPMSoft.MarketingCalendarMktgActivitiesModule;
	});
