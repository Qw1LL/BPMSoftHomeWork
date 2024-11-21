define("UserPageV2", ["PortalUsersAdministrationUtilities"],
	function() {
		return {
			entitySchemaName: "VwSysAdminUnit",
			attributes: {
				/**
				 * Provide information about organization of portal user.
				 */
				"Organization": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"referenceSchemaName": "VwSspAdminUnit",
					"caption": {"bindTo": "Resources.Strings.OrganizationCaption"},
					"lookupListConfig": {
						"hideActions": true,
						"filter": function () {
							return this.getOrganizationFilter();
						}
					}
				}
			},
			properties: {
				"sspConnectionType": 1
			},
			mixins: {
				portalUsersAdministrationUtilities: "BPMSoft.PortalUsersAdministrationUtilities"
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"parentName": "Header",
					"propertyName": "items",
					"name": "PhotoContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"rowSpan": 4,
							"colSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Organization",
					"values": {
						"bindTo": "Organization",
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 8
						},
						"enabled": false,
						"visible": {"bindTo": "getIsOrganizationFieldVisible"}
					}
				}
			],
			methods: {

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
				 * @inheritDoc UserPageV2#getSaveLicensesMethodName
				 * @overridden
				 * @return {String} Method name.
				 */
				getSaveLicensesMethodName: function() {
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						return "UpdatePortalLicenseInfo";
					} else {
						return this.callParent();
					}
				},

				/**
				 * @inheritDoc UserPageV2#getSaveUserMethodName
				 * @overridden
				 * @return {String} Method name.
				 */
				getSaveUserMethodName: function() {
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						return "UpdateOrCreatePortalUser";
					} else {
						return this.callParent();
					}
				},

				/**
				 * @inheritDoc UserPageV2#getOnDeleteCurrentUserClickMethodName
				 * @overridden
				 * @return {String} Method name.
				 */
				getOnDeleteCurrentUserClickMethodName: function() {
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						return "DeletePortalUser";
					} else {
						return this.callParent();
					}
				},

				/**
				* @inheritdoc BPMSoft.BaseViewModel#getEntitySchemaQuery
				* @override
				*/
				getEntitySchemaQuery: function() {
					const esq = this.callParent(arguments);
 					esq.addColumn("[VwSspAdminUnit:Id:Id].PortalAccount", "Organization");
 					return esq;
				},

				/**
				* @inheritdoc BaseViewModel#setColumnValues
				* @override
				*/
				setColumnValues: function(entity) {
					this.callParent(arguments);
					this.set("Organization", entity.get("Organization"));
				},

				/**
				 * Returns filter by portal organization.
				 * @protected
				 */
				getOrganizationFilter: function() {
					const organizationFilter = BPMSoft.createFilterGroup();
					organizationFilter.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					organizationFilter.add("PortalAccountFilter",
						BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"[VwSspAdminUnit:Id:Id].PortalAccount", this.$Organization.value));
					organizationFilter.add("SelfExcludeFilter",
						BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL,
						"[VwSspAdminUnit:Id:Id].Id", this.$Id));
					return organizationFilter;
				},

				/**
				 * Obtains visibility for portal organization field.
				 * @protected
				 */
				getIsOrganizationFieldVisible: function() {
					return this.$ConnectionType === this.sspConnectionType;
				}
			}
		};
	});
