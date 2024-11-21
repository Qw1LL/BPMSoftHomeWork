define("UsersSectionV2", ["PortalUsersAdministrationUtilities"],
	function() {
		return {
			entitySchemaName: "SysAdminUnit",
			attributes: {
				"ShowAddOurCompanyUser": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": true
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "CombinedModeAddOurCompanyUser",
					"values": {
						"visible": {"bindTo": "ShowAddOurCompanyUser"}
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeAddOurCompanyUser",
					"values": {
						"visible": {"bindTo": "ShowAddOurCompanyUser"}
					}
				}
			],
			mixins: {
				portalUsersAdministrationUtilities: "BPMSoft.PortalUsersAdministrationUtilities"
			},
			methods: {
				/**
				 * @inheritdoc BaseSectionV2#getDefaultDataViews
				 * @overridden
				 */
				getDefaultDataViews: function() {
					var baseDataViews = this.callParent(arguments);
					if (this.get("CanViewConfiguration")) {
						return baseDataViews;
					}
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						delete baseDataViews.OrganizationalRolesDataView;
						delete baseDataViews.FuncRolesDataView;
					}
					return baseDataViews;
				},

				/**
				 * Checks schema operation availability.
				 * @protected
				 * @param {Object} callback callback function.
				 * @param {Object} scope scope.
				 */
				checkSchemaOperationAvailability: function(callback, scope) {
					this.checkCanAdministratePortalUsers(callback, scope);
				},

				/**
				 * @inheritDoc UsersSectionV2#getOnDeleteAcceptMethodName
				 * @overridden
				 * @return {String} Method name.
				 */
				getOnDeleteAcceptMethodName: function() {
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						return "DeletePortalUser";
					} else {
						return this.callParent();
					}
				},

				/**
				 * @inheritdoc BaseSectionV2#initQueryFilters
				 * @overridden
				 */
				initQueryFilters: function(esq) {
					this.callParent(arguments);
					if (this.get("CanViewConfiguration")) {
						return;
					}
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						if (!esq.columns.collection.containsKey("ConnectionType")) {
							esq.addColumn("ConnectionType");
						}
						esq.filters.removeByKey("ConnectionType");
						esq.filters.add("ConnectionType", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "ConnectionType", 1));
						this.set("ShowAddOurCompanyUser", false);
					}
				}
			}
		};
	}
);
