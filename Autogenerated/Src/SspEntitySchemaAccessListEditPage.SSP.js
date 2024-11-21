define("SspEntitySchemaAccessListEditPage", [],
	function() {
		return {
			entitySchemaName: "VwSysSSPEntitySchemaAccessList",
			attributes: {
				"SysSchema": {
					lookupListConfig: {
						filter: function() {
							return this.getSysSchemaFilter();
						}
					}
				},
				"Name": {
					isRequired: false
				}
			},
			methods: {

				/**
				 * Returns filter for SysSchema column.
				 * @returns {BPMSoft.FilterGroup} SysSchema column filter.
				 */
				getSysSchemaFilter: function () {
					const filters = this.Ext.create("BPMSoft.FilterGroup");
					filters.add("notExtendParent", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"ExtendParent",
						0
					));
					filters.add("entitySchemaManager", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL,
						"ManagerName",
						"EntitySchemaManager"
					));
					filters.add("notExistingSysSchemaFilter",
						this.BPMSoft.createColumnIsNullFilter(
							">[VwSysSSPEntitySchemaAccessList:EntitySchemaUId:UId].EntitySchemaUId"));
					return filters;
				}
			},
			diff: []
		};
	});
