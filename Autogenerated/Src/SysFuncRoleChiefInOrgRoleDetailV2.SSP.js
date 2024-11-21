define("SysFuncRoleChiefInOrgRoleDetailV2", [],
	function() {
		return {
			entitySchemaName: "SysFuncRoleInOrgRole",
			methods: {

				/**
				 * Returns values of the ViewModel.
				 * @protected
				 * @virtual
				 * @returns {Object} ViewModel column values.
				 */
				getCardColumnValues: function() {
					return this.sandbox.publish("GetColumnsValues", ["ConnectionType"], [this.sandbox.id]);
				},

				/**
				 * Adds filter by connection type column to the existing filter.
				 * @protected
				 * @virtual
				 */
				addConnectionTypeFilter: function(filters) {
					var columnValues = this.getCardColumnValues();
					if (columnValues && columnValues.hasOwnProperty("ConnectionType")) {
						var connectionTypeFilter =  this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"ConnectionType",
							columnValues.ConnectionType);
						filters.addItem(connectionTypeFilter);
					}
				},

				/**
				 * @inheritdoc BPMSoft.SysFuncRoleChiefInOrgRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					var filters = this.callParent(arguments);
					if (this.getIsFeatureEnabled("PortalUserManagementV2")) {
						this.addConnectionTypeFilter(filters);
					}
					return filters;
				}
			}
		};
	});
