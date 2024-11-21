define("SspSysAdminUnitSection", ["ConfigurationEnums", "ConfigurationConstants", "css!SspAdminUnitSectionCSS"],
	function(ConfigurationEnums, ConfigurationConstants) {
		return {
			entitySchemaName: "SysAdminUnit",
			attributes: {
				"SecurityOperationName": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "CanAdministratePortalUsers"
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "SectionContainer",
					"values": {
						"wrapClass": ["section", "left-el", "ssp-section"]
					}
				},
				{
					"operation": "merge",
					"name": "CardContainer",
					"values": {
						"wrapClass": ["card", "right-el", "ssp-card"]
					}
				},
				{
					"operation": "merge",
					"name": "ActionButtonsContainer",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeActionButtonsSectionContainer",
					"values": {
						"visible": false
					}
				}
			],
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.callParent(arguments);
					filters.add("SspConnectionType", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "ConnectionType", 1));
					return filters;
				},

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#moveToUsersSection
				 * @overridden
				 */
				moveToUsersSection: function() {
					this.sandbox.publish("PushHistoryState", {
						hash: this.BPMSoft.combinePath("SectionModuleV2", "SSPUsersSection"),
						stateObj: {
							module: "SectionModuleV2",
							schemas: ["SSPUsersSection"],
							UsersActiveRow: this.get("UsersActiveRow"),
							FuncRolesActiveRow: this.getActiveFuncRoleId(),
							OrgRolesActiveRow: this.getActiveOrgRoleId()
						}
					});
				},

				/**
				 * @inheritDoc BaseSectionV2#loadView
				 * @overridden
				 */
				loadView: function(dataViewName) {
					this.set("ActiveViewName", dataViewName);
					this.saveActiveViewNameToProfile(dataViewName);
					if (this.Ext.get("SspSysAdminUnitSectionContainer")) {
						this.openCard(this.getEditPageName(), ConfigurationEnums.CardStateV2.EDIT,
							this.getLastGroupId());
					}
					this.getActiveViewGridSettingsProfile(function() {
						this["load" + dataViewName](this.getNeedLoadData());
					}, this);
				},


				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#getLastGroupId
				 * @overridden
				 */
				getLastGroupId: function() {
					var result = this.isOrganizationalRolesDataView()
						? this.getActiveOrgRoleId()
						: this.getActiveFuncRoleId();
					return result || ConfigurationConstants.SysAdminUnit.Id.PortalUsers;
				},

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#filtrateAdditionButtons
				 * @overridden
				 */
				filtrateAdditionButtons: function(primaryColumnValue) {
					var isOrgRoleView = this.isOrganizationalRolesDataView();
					if (this.Ext.isEmpty(primaryColumnValue)) {
						return;
					}
					if (this.getGridData().contains(primaryColumnValue)) {
						this.prepareAdditionButtons(isOrgRoleView);
						var row = this.getGridData().get(primaryColumnValue);
						var type = !isOrgRoleView
							? ConfigurationConstants.SysAdminUnit.Type.FuncRole
							: row.get("SysAdminUnitTypeValue");
						switch (type) {
							case ConfigurationConstants.SysAdminUnit.Type.Organisation:
								this.set("IsOrganisationShowed", true);
								this.set("IsDepartmentShowed", true);
								this.set("IsCommandShowed", true);
								break;
							case ConfigurationConstants.SysAdminUnit.Type.Department:
								this.set("IsDepartmentShowed", true);
								this.set("IsCommandShowed", true);
								break;
							case ConfigurationConstants.SysAdminUnit.Type.FuncRole:
								this.set("IsFuncRoleEnabled", true);
								break;
						}
					}
				},

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#getFuncRolesPageName
				 * @override
				 */
				getFuncRolesPageName: function() {
					return "SspSysAdminUnitFuncRolePage";
				},

				/**
				 * @inheritDoc BPMSoft.SysAdminUnitSectionV2#getSysAdminUnitPageName
				 * @override
				 */
				getSysAdminUnitPageName: function() {
					return "SspSysAdminUnitPage";
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#loadSummaryModule
				 * @override
				 */
				loadSummaryModule: this.BPMSoft.emptyFn
			}
		};
	});
