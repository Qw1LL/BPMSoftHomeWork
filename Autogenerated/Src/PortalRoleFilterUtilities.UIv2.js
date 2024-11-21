define("PortalRoleFilterUtilities", ["BPMSoft", "ConfigurationConstants"],
	function(BPMSoft, ConfigurationConstants) {
		var portalRoleFilterUtilitiesClass = Ext.define("BPMSoft.configuration.mixins.PortalRoleFilterUtilities", {

				alternateClassName: "BPMSoft.PortalRoleFilterUtilities",

				/**
				 * ########## ###### ######## ### ######### ##### ### #### ############ #######.
				 * @param  {Array} sysAdminUnitTypeList ###### ##### ##### ### ##########.
				 * @return {BPMSoft.FilterGroup} ###### ########.
				 */
				getSysAdminUnitWithoutPortalFilterGroup: function(sysAdminUnitTypeList) {
					var orgRolesFilterGroup = BPMSoft.createFilterGroup();
					orgRolesFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					orgRolesFilterGroup.addItem(BPMSoft.createColumnInFilterWithParameters(
						"SysAdminUnitTypeValue", sysAdminUnitTypeList));
					orgRolesFilterGroup.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL,
						"Id",
						ConfigurationConstants.SysAdminUnit.Id.PortalUsers));
					return orgRolesFilterGroup;
				},

				/**
				 * ########## ###### ######## ### ######### #### ############ #######, #### ### #######.
				 * @return {BPMSoft.FilterGroup} ###### ########.
				 */
				getPortalFilterGroup: function() {
					var portalFilterGroup = BPMSoft.createFilterGroup();
					portalFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					portalFilterGroup.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Active", true));
					portalFilterGroup.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL,
						"Id",
						ConfigurationConstants.SysAdminUnit.Id.PortalUsers));
					return portalFilterGroup;
				},

				/**
				 * ########## ###### ######## ### ######### #####.
				 * @param  {Array} sysAdminUnitTypeList ###### ##### ##### ### ##########.
				 * @return {BPMSoft.FilterGroup} ###### ########.
				 */
				getSysAdminUnitFilterGroup: function(sysAdminUnitTypeList) {
					var orgRolesFilterGroup = this.getSysAdminUnitWithoutPortalFilterGroup(sysAdminUnitTypeList);
					var portalFilterGroup = this.getPortalFilterGroup();
					var filterGroup = BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
					filterGroup.addItem(portalFilterGroup);
					filterGroup.addItem(orgRolesFilterGroup);
					return filterGroup;
				}
			});
		return Ext.create(portalRoleFilterUtilitiesClass);
	});
