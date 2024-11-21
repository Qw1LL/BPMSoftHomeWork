 define("PortalOpportunitySectionV2", [], function() {
	return {
		entitySchemaName: "Opportunity",
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
			 * @override
			 */
			getDefaultDataViews: function() {
				const dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
