define("SysFuncRoleInUserDetailV2", ["BPMSoft", "ConfigurationConstants"],
	function(BPMSoft, ConfigurationConstants) {
		return {
			entitySchemaName: "SysUserInRole",
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSysUserInRoleDetailV2#getSysAdminUnitTypeList
				 * @overridden
				 */
				getSysAdminUnitTypeList: function() {
					return [ConfigurationConstants.SysAdminUnit.Type.FuncRole];
				},

				/**
				 * @inheritdoc BPMSoft.BaseSysUserInRoleDetailV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.callParent(arguments);
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"SysRole.SysAdminUnitTypeValue",
					ConfigurationConstants.SysAdminUnit.Type.FuncRole));
					return filters;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSysUserInRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					var filters = this.callParent(arguments);
					var connectionType = this.sandbox.publish("GetColumnsValues", ["ConnectionType"],
							[this.sandbox.id]);
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"ConnectionType", connectionType.ConnectionType));
					return filters;
				},

				/**
				 * @overridden
				 * @return {String} Column name.
				 */
				getFilterDefaultColumnName: function() {
					return "SysRole";
				}
			}
		};
	});
