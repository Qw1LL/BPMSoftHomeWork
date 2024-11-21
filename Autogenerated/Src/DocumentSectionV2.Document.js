define("DocumentSectionV2", ["VisaHelper", "BaseFiltersGenerateModule",	"DocumentSectionGridRowViewModel"],
	function(VisaHelper, BaseFiltersGenerateModule) {
		return {
			entitySchemaName: "Document",
			methods: {
				/**
				 * ############# ######## ############## ########### ####### ### ####### "#########"
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1005);
					this.callParent(arguments);
				},

				/**
				 * @overridden
				 * @inheritDoc BaseSectionV2#initFixedFiltersConfig
				 */
				initFixedFiltersConfig: function() {
					var fixedFilterConfig = {
						entitySchema: this.entitySchema,
						filters: [
							{
								name: "PeriodFilter",
								caption: this.get("Resources.Strings.PeriodFilterCaption"),
								dataValueType: BPMSoft.DataValueType.DATE,
								columnName: "Date",
								startDate: {},
								dueDate: {}
							},
							{
								name: "Owner",
								caption: this.get("Resources.Strings.OwnerFilterCaption"),
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								filter: BaseFiltersGenerateModule.OwnerFilter,
								columnName: "Owner"
							}
						]
					};
					this.set("FixedFilterConfig", fixedFilterConfig);
				},

				/**
				 * @overridden
				 */
				getGridRowViewModelClassName: function() {
					return "BPMSoft.DocumentSectionGridRowViewModel";
				},

				/**
				 * overridden
				 */
				getReportFilters: function() {
					var filters = this.getFilters();
					var recordId = this.get("ActiveRow");
					if (recordId) {
						filters.clear();
						filters.name = "primaryColumnFilter";
						var filter = this.BPMSoft.createColumnInFilterWithParameters(
							this.entitySchema.primaryColumnName, [recordId]);
						filters.addItem(filter);
					}
					return filters;
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
