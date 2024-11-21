define("SysAdminUnitSectionV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			diff: [],
			attributes: {},
			methods: {

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#addOrganizationalRolesFilter
				 * @overridden
				 */
				addOrganizationalRolesFilter: function(filters) {
					this.callParent(arguments);
					if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
						var portalAccountFilterGroup = BPMSoft.createFilterGroup();
						portalAccountFilterGroup.addItem(BPMSoft.createColumnIsNullFilter("PortalAccount"));
						filters.addItem(portalAccountFilterGroup);
					}
				},

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#getFunctionalRolesFilter
				 * @overridden
				 */
				getFunctionalRolesFilter: function() {
					var filter = this.callParent(arguments);
					if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
						filter.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"Id",
							ConfigurationConstants.SysAdminUnit.Id.PortalUsers));
					}
					return filter;
				},

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#filtrateAdditionButtons
				 * @overridden
				 */
				filtrateAdditionButtons: function(primaryColumnValue) {
					this.callParent(arguments);
					if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
						if (this.Ext.isEmpty(primaryColumnValue)) {
							return;
						}
						const isOrgRoleView = this.isOrganizationalRolesDataView();
						const row = this.getGridData().get(primaryColumnValue);
						if (row.$ConnectionType === ConfigurationConstants.SysAdminUnit.ConnectionType.PortalUsers
								&& isOrgRoleView) {
							this.set("IsDepartmentShowed", false);
						}
					}
				},
			}
		};
	});
