define("OpportunityActionsDashboard", [], function() {
	return {
		methods: {
			/**
			 * @inheritdoc BPMSoft.SectionActionsDashboard#isMenuItem
			 * @overridden
			 */
			isMenuItem: function(item, previousItem) {
				if (this.get("DcmSchema")) {
					return this.callParent(arguments);
				} else {
					var itemInnerOrder = item.get("InnerOrder");
					var prevItemInnerOrder = previousItem && previousItem.get("InnerOrder");
					return Boolean(itemInnerOrder) && Boolean(prevItemInnerOrder);
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
