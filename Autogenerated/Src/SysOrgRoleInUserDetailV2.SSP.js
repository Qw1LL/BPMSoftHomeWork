define("SysOrgRoleInUserDetailV2", [],
	function() {
		return {
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSysUserInRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					let filters = this.callParent(arguments);
					filters.addItem(this.BPMSoft.createColumnIsNullFilter("PortalAccount"));
					return filters;
				}

			}
		};
	});
