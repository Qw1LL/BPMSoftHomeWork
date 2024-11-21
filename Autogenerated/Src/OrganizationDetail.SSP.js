 define("OrganizationDetail", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "VwSspAdminUnit",
			attributes: {},
			methods: {
				/**
				 * @inheritdoc BaseGridDetailV2#getFilters
				 * @overridden
				 */
				getFilters: function () {
					var filters = this.callParent(arguments);
					filters.add("OrganizationFilter", BPMSoft.createColumnIsNotNullFilter("PortalAccount"));
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitType.Value",
						ConfigurationConstants.SysAdminUnit.Type.Organisation));
					return filters;
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#addDetailWizardMenuItems
				 * @override
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @override
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @override
				 */
				getFilterDefaultColumnName: function() {
					return "Account";
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#addColumnLink
				 * @override
				 */
				addColumnLink: function(item, column) {
					var columnPath = column.columnPath;
					if (columnPath === item.primaryDisplayColumnName) {
						item["on" + columnPath + "LinkClick"] = function() {
							var value = this.get(columnPath);
							return {
								caption: value,
								target: "_self",
								title: value,
								url: window.location.hash
							};
						};
					} else {
						this.callParent(arguments);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
