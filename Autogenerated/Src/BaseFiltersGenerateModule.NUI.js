define("BaseFiltersGenerateModule", ["BaseFiltersGenerateModuleResources", "ConfigurationConstants"],
	function(resources, ConfigurationConstants) {
		function getIsNotNullFilterGroup(refSchema) {
			const userFilter = BPMSoft.createColumnIsNotNullFilter(refSchema + ".Id");
			const filters = Ext.create("BPMSoft.FilterGroup");
			filters.addItem(userFilter);
			return filters;
		}

		function employeesFilter() {
			const sysAdminUnitRef = "[SysAdminUnit:Contact]";
			const employeesFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					sysAdminUnitRef + ".ConnectionType",
					ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees);
			const filters = getIsNotNullFilterGroup(sysAdminUnitRef);
			filters.addItem(employeesFilter);
			return filters;
		}

		function allUsersFilter() {
			return getIsNotNullFilterGroup("[VwSystemUsers:Contact]");
		}

		function selfFilter() {
			let primaryColumnName = "Id";
			if (this.entitySchema && this.entitySchema.primaryColumnName) {
				primaryColumnName = this.entitySchema.primaryColumnName;
			}
			const primaryColumnValue = this.get(primaryColumnName);
			return BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.NOT_EQUAL, primaryColumnName, primaryColumnValue);
		}

		/**
		 * Returns the users of the specified role filter.
		 * @param {String} roleId Role identifier.
		 * @returns {BPMSoft.FilterGroup}
		 */
		function usersInRoleFilter(roleId) {
			const filters = allUsersFilter();
			if (BPMSoft.isNotEmpty(roleId)) {
				const roleFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"[VwSystemUsers:Contact:Id].[SysAdminUnitInRole:SysAdminUnit:Id].SysAdminUnitRoleId",
					roleId, BPMSoft.DataValueType.GUID);
				filters.addItem(roleFilter);
			}
			return filters;
		}

		/**
		 * Returns the system users of the specified role filter.
		 * @param {String} roleId Role identifier.
		 * @returns {BPMSoft.FilterGroup}
		 */
		function ownersInRoleFilter(roleId) {
			const filters = usersInRoleFilter(roleId);
			const employeesFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"[VwSystemUsers:Contact].ConnectionType",
				ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees);
			filters.addItem(employeesFilter);
			return filters;
		}

		return {
			OwnerFilter: employeesFilter,
			SelfFilter: selfFilter,
			AllUsersFilter: allUsersFilter,
			UsersInRoleFilter: usersInRoleFilter,
			OwnersInRoleFilter: ownersInRoleFilter
		};
	});
