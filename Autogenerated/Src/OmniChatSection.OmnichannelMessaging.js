define("OmniChatSection", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "OmniChat",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"visible": false
				}
			},

			{
				"operation": "merge",
				"name": "CombinedModeAddRecordButton",
				"values": {
					"visible": false
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {

			/**
			 * @inheritdoc BaseSectionV2#initFixedFiltersConfig
			 * @overridden
			 */
			initFixedFiltersConfig: function() {
				var fixedFilterConfig = {
					entitySchema: this.entitySchema,
					filters: [{
						name: "PeriodFilter",
						caption: this.get("Resources.Strings.PeriodFilterCaption"),
						dataValueType: this.BPMSoft.DataValueType.DATE,
						columnName: "CreatedOn",
						startDate: {
							defValue: this.BPMSoft.startOfWeek(new Date())
						},
						dueDate: {
							defValue: this.BPMSoft.endOfWeek(new Date())
						}
					}, {
						name: "Owner",
						caption: this.get("Resources.Strings.OwnerFilterCaption"),
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						appendCurrentContactMenuItem: false,
						columnName: "Operator",
						filter: function() {
							var filters = Ext.create("BPMSoft.FilterGroup");
							const employeesFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
									"SysAdminUnitTypeValue",
									ConfigurationConstants.SysAdminUnit.Type.User);
							filters.addItem(employeesFilter);
							return filters;
						}
					}]
				};
				this.set("FixedFilterConfig", fixedFilterConfig);
			}
		}
	};
});
