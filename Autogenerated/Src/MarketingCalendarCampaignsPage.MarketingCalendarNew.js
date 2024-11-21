define("MarketingCalendarCampaignsPage", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "CampaignPlanner",
			messages: {},
			attributes: {},
			methods: {
				/*
				 * @inheritdoc BaseMarketingCalendarPage#getSchemaName
				 * @overridden
				 */
				getSchemaName: function() {
					return "CampaignPlannerPage";
				},

				getProfileKey: function() {
					return "CampaignPlannerSectionGridSettingsGridDataView";
				},

				/*
				 * Recanculates column rows.
				 * @overridden
				 * @protected
				 */
				reCalcColumnRow: function() {
					var collection = this.get("GridData");
					collection.each(function(item) {
						item.set("Column", this.convertDateToColumn(item.get("StartDate")) - 1);
						item.set("Duration", this.convertDatesToDuration(item.get("StartDate"), item.get("DueDate")));
					}, this);
				},

				addTypeColumns: function(esq) {
					var esqColumns = esq.columns;
					var requiredColumns = ["StartDate", "DueDate", "Name"];
					this.BPMSoft.each(requiredColumns, function(column) {
						if (!esqColumns.contains(column)) {
							esq.addColumn(column);
						}
					});
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "MarketingCalendar",
					"values": {
						"itemConfig": {
							"rowSpan": 1,
							itemId: BPMSoft.generateGUID(),
							content: "Content"
						}
					}
				}
			]
		};
	}
);
