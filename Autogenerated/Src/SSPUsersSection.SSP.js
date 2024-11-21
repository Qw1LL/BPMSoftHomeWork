define("SSPUsersSection", ["ConfigurationEnums", "ConfigurationConstants"],
	function(ConfigurationEnums, ConfigurationConstants) {
		return {
			entitySchemaName: "SysAdminUnit",
			attributes: {
				"SecurityOperationName": {
					dataValueType: BPMSoft.DataValueType.STRING,
					value: "CanAdministratePortalUsers"
				}
			},
			diff: [
				{
					"operation": "remove",
					"name": "SeparateModeAddPortalUser",
					"parentName": "SeparateModeAddRecordButton",
					"propertyName": "menu"
				},
				{
					"operation": "remove",
					"name": "SeparateModeAddOurCompanyUser",
					"parentName": "SeparateModeAddRecordButton",
					"propertyName": "menu"
				},
				{
					"operation": "merge",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.AddRecordButtonCaption"},
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"controlConfig": {},
						"click": {"bindTo": "onAddPortalUser"}
					}
				}
			],
			methods: {
				/**
				 * @inheritdoc BPMSoft.GridUtilities#initQueryFilters
				 * @overridden
				 */
				initQueryFilters: function(esq) {
					this.callParent(arguments);
					esq.filters.removeByKey("ConnectionType");
					esq.filters.add("ConnectionType",
						BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "ConnectionType", 1));
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#changeDataView
				 * @overridden
				 */
				changeDataView: function(view) {
					if (view.tag !== "GridDataView") {
						this.moveToRolesSection(view.tag);
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.UsersSectionV2#moveToRolesSection
				 * @overridden
				 */
				moveToRolesSection: function(viewName) {
					var pageName = this.getPageNameForRoles(viewName);
					var primaryColumnValue = this.getPrimaryColumnValueForRoles(viewName);
					this.sandbox.publish("PushHistoryState", {
						hash: this.BPMSoft.combinePath("SectionModuleV2", "SspSysAdminUnitSection",
							pageName, "edit", primaryColumnValue),
						stateObj: {
							module: "SectionModuleV2",
							operation: "edit",
							primaryColumnValue: primaryColumnValue,
							schemas: [
								"SspSysAdminUnitSection",
								pageName
							],
							workAreaMode: ConfigurationEnums.WorkAreaMode.COMBINED,
							moduleId: this.sandbox.id,
							UsersActiveRow: this.get("ActiveRow"),
							FuncRolesActiveRow: this.get("FuncRolesActiveRow"),
							OrgRolesActiveRow: this.get("OrganizationalRolesActiveRow")
						}
					});
				},

				/**
				 * @inheritDoc BPMSoft.UsersSectionV2#getPrimaryColumnValueForRoles
				 * @overridden
				 */
				getPrimaryColumnValueForRoles: function(viewName) {
					var id;
					if (viewName === "OrganizationalRolesDataView") {
						id = this.get("OrganizationalRolesActiveRow");
					} else {
						id = this.get("FuncRolesActiveRow");
					}
					return id || ConfigurationConstants.SysAdminUnit.Id.PortalUsers;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultDataViews
				 * @overridden
				 */
				getDefaultDataViews: function() {
					var baseDataViews = {
						GridDataView: {
							index: 0,
							name: "GridDataView",
							caption: this.get("Resources.Strings.UsersHeader"),
							icon: this.get("Resources.Images.UsersDataViewIcon"),
							hint: this.get("Resources.Strings.UsersDataViewHint")
						},
						OrganizationalRolesDataView: {
							index: 1,
							name: "OrganizationalRolesDataView",
							caption: this.get("Resources.Strings.OrganizationalRolesHeader"),
							icon: this.get("Resources.Images.OrgRolesIcon"),
							hint: this.get("Resources.Strings.OrganizationalStructureDataViewHint")
						},
						FuncRolesDataView: {
							index: 2,
							name: "FuncRolesDataView",
							caption: this.get("Resources.Strings.FunctionalRolesHeader"),
							icon: this.get("Resources.Images.FuncRolesIcon"),
							hint: this.get("Resources.Strings.FunctionalRolesDataViewHint")
						}
					};
					return baseDataViews;
				},

				/**
				 * @inheritdoc BPMSoft.UsersSectionV2#addLicDistributionActions
				 * @overridden
				 */
				addLicDistributionActions: BPMSoft.emptyFn,

				getPageNameForRoles: function(viewName) {
					return viewName === "OrganizationalRolesDataView"
						? "SspSysAdminUnitPage"
						: "SspSysAdminUnitFuncRolePage";
				}

			}
		};
	}
);
