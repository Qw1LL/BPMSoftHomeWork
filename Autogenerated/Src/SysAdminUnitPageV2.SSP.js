define("SysAdminUnitPageV2", [],
	function() {
		return {
			entitySchemaName: "VwSysAdminUnit",
			details: /**SCHEMA_DETAILS*/{
				"OrganizationDetail": {
					"schemaName": "OrganizationDetail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ParentRole"
					}
				},
				"OptionalFuncSspRolesDetail": {
					"schemaName": "OptionalFuncSspRolesDetail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "OrgRole"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "UsersTab",
					"propertyName": "items",
					"name": "OrganizationDetail",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "OrganizationDetailVisible"}
					}
				},
				{
					"operation": "insert",
					"parentName": "FuncRolesTab",
					"propertyName": "items",
					"name": "OptionalFuncSspRolesDetail",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "OrganizationDetailVisible"}
					}
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				/**
				 * PortalAccount detail visibility flag.
				 */
				"OrganizationDetailVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				}
			},
			methods: {

				/**
				 * Checks if AdminUnit connection type is SSP.
				 * @returns {boolean}
				 * @private
				 */
				_getIsSspConnectionType: function() {
					var connectionType = this.get("ConnectionType");
					return connectionType === 1 && this.getIsFeatureEnabled("PortalUserManagementV2");
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.$OrganizationDetailVisible = this._getIsSspConnectionType();
				}
			}
		};
	});
