define("MarketingCalendarMktgActivitiesPage", [],
	function() {
		return {
			entitySchemaName: "MktgActivity",
			messages: {},
			attributes: {},
			methods: {
				/*
				* @inheritdoc BaseMarketingCalendarPage#getSchemaName
				* @overridden
				*/
				getSchemaName: function() {
					return "MktgActivityPage";
				},

				getProfileKey: function() {
					return "MktgActivitySectionGridSettingsGridDataView";
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

				getSectionModuleId: function() {
					return "SectionModuleV2_MktgActivitySection";
				},

				/**
				 * Generates quick filter module id.
				 * @protected
				 * @return {String} Module id.
				 */
				getQuickFilterModuleId: function() {
					return "SectionModuleV2_MktgActivitySection_QuickFilterModuleV2";
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
			diff: []
		};
	}
);
