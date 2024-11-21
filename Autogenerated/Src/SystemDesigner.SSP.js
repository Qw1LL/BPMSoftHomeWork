define("SystemDesigner", ["SystemDesignerResources", "ConfigurationEnums", "ConfigurationConstants",
		"ProcessModuleUtilities", "PortalClientConstants"],
	function(resources, ConfigurationEnums, ConfigurationConstants, ProcessUtilities, PortalConstants) {
		return {
			properties: {
				/**
				 * @protected
				 */
				organizationPageSchemaUId: PortalConstants.DesignerPages.OrganizationPageSchemaUId,

				/**
				 * @protected
				 */
				profileContactPageSchemaUId: PortalConstants.DesignerPages.ProfileContactPageSchemaUId

			},
			attributes: {
				/**
				 * ########, ########## ########## # ########### ######
				 * ######### ####### ######## ####### ######## ############.
				 */
				"CanManagePortalMainPage": {dataValueType: BPMSoft.DataValueType.BOOLEAN}
			},
			methods: {

				/**
				 * ######### ###### "####### ######## #######" ### ########## ######### # ######.
				 * @private
				 */
				navigateToPortalMainPageModule: function() {
					this.sandbox.publish("PushHistoryState", {hash: "PortalMainPageModule/"});
				},

				/**
				 * Go to "Portal users" section.
				 * @protected
				 */
				navigateToPortalUsers: function() {
					this.openSection("SSPUsersSection");
				},

				/**
				 * @inheritDoc SystemDesigner#getOperationRightsDecoupling.
				 * @overriden
				 * @return {Object} OperationRights object.
				 */
				getOperationRightsDecoupling: function() {
					var baseOperationRights = this.callParent(arguments);
					baseOperationRights.navigateToPortalMainPageModule = "CanManagePortalMainPage";
					baseOperationRights.navigateToPortalUsers = "CanAdministratePortalUsers";
					baseOperationRights.navigateToPortalOrgRoles = "CanAdministratePortalUsers";
					baseOperationRights.navigateToPortalFuncRoles = "CanAdministratePortalUsers";
					baseOperationRights.navigateToPortalOrganizationSetup = "CanManageAdministration";
					baseOperationRights.navigateToSspProfileContactSetup = "CanManageAdministration";
					return baseOperationRights;
				},

				/**
				 * Open UserSection section if user have permission.
				 * @public
				 */
				tryOpenUserSection: function() {
					var operationName = arguments[1] || arguments[0];
					var operationRightsDecoupling = this.getOperationRightsDecoupling();
					var rightsName = operationRightsDecoupling[operationName];
					if (!Ext.isEmpty(rightsName) && !this.get(rightsName) && !this.get("CanViewConfiguration")) {
						var portalOperationName = "navigateToPortalUsers";
						var portalRightName = operationRightsDecoupling[portalOperationName];
						if (!Ext.isEmpty(portalRightName) && !this.get(portalRightName)) {
							this.showPermissionsErrorMessage(portalRightName);
							return false;
						}
					}
					var operation = this[operationName];
					if (!Ext.isEmpty(operation) && Ext.isFunction(operation)) {
						operation.call(this);
					}
					return false;
				},

				/**
				 *  Get PortalSetupInSystemDesigner feature value.
				 * @private
				 */
				_getPortalSetupVisibility: function() {
					return this.getIsFeatureEnabled("PortalSetupInSystemDesigner");
				},

				/**
				 *  Get PortalMainPageManagement link visibility.
				 * @private
				 */
				_getPortalMainPageManagement: function() {
					return !this._getPortalSetupVisibility();
				},

				/**
				 * ######### ############# ############### #### # ####### ################# #############.
				 * @private
				 */
				navigateToPortalOrgRoles: function() {
					this.goToSspSysAdminUnitSection("SspSysAdminUnitPage");
				},

				/**
				 * ######### ############# ############## #### # ####### ################# #############.
				 * @private
				 */
				navigateToPortalFuncRoles: function() {
					this.goToSspSysAdminUnitSection("SspSysAdminUnitFuncRolePage");
				},

				/**
				 * Opens page wizard.
				 * @protected
				 */
				openWizardSetupPage: function(schemaUId) {
					const config = {
						designer: "SspPageWizard",
						type: "PageDesigner",
						schemaUId: schemaUId
					};
					ProcessUtilities.showSchemaDesigner(config);
				},

				/**
				 * Opens organization page wizard.
				 * @protected
				 */
				navigateToPortalOrganizationSetup: function() {
					this.openWizardSetupPage(this.organizationPageSchemaUId);
				},

				/**
				 * Opens contact profile page wizard.
				 * @protected
				 */
				navigateToSspProfileContactSetup: function() {
					this.openWizardSetupPage(this.profileContactPageSchemaUId);
				},

				goToSspSysAdminUnitSection: function(pageName) {
					var primaryId = ConfigurationConstants.SysAdminUnit.Id.PortalUsers;
					this.sandbox.publish("PushHistoryState", {
						hash: BPMSoft.combinePath("SectionModuleV2", "SspSysAdminUnitSection",
							pageName, ConfigurationEnums.CardState.Edit, primaryId),
						stateObj: {
							module: "SectionModuleV2",
							operation: ConfigurationEnums.CardState.Edit,
							primaryColumnValue: primaryId,
							schemas: [
								this.name,
								pageName
							],
							workAreaMode: ConfigurationEnums.WorkAreaMode.COMBINED,
							moduleId: this.sandbox.id,
							skipCardHistoryStateActualization: true
						}
					});
				}

			},
			diff: [
				{
					"operation": "merge",
					"name": "Users",
					"values": {
						"click": {"bindTo": "tryOpenUserSection"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "SystemSettingsTile",
					"name": "PortalMainPageManagement",
					"index": 5,
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.PortalMainPageManagementLinkCaption"},
						"tag": "navigateToPortalMainPageModule",
						"click": {"bindTo": "invokeOperation"},
						"visible": {"bindTo": "_getPortalMainPageManagement"}
					}
				},
				{
					"operation": "insert",
					"name": "PortalAdministrationTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.PortalSetupCaption"},
						"cls": ["midnight-blue-tile", "designer-tile"],
						"icon": resources.localizableImages.PortalIcon,
						"items": [],
						"visible": {"bindTo": "_getPortalSetupVisibility"}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "PortalAdministrationTile",
					"name": "PortalUsers",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.PortalUsersLinkCaption"},
						"tag": "navigateToPortalUsers",
						"click": {"bindTo": "invokeOperation"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "PortalAdministrationTile",
					"name": "PortalOrgRoles",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.PortalOrganizationalRolesLinkCaption"},
						"tag": "navigateToPortalOrgRoles",
						"click": {"bindTo": "invokeOperation"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "PortalAdministrationTile",
					"name": "PortalFuncRoles",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.PortalFunctionalRolesLinkCaption"},
						"tag": "navigateToPortalFuncRoles",
						"click": {"bindTo": "invokeOperation"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "PortalAdministrationTile",
					"name": "PortalMainPageManagementInPortalAdministrationTile",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.PortalMainPageManagementLinkCaption"},
						"tag": "navigateToPortalMainPageModule",
						"click": {"bindTo": "invokeOperation"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "PortalAdministrationTile",
					"name": "SspProfileContactSetup",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.SspProfileContactSetupLinkCaption"},
						"tag": "navigateToSspProfileContactSetup",
						"click": {"bindTo": "invokeOperation"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "PortalAdministrationTile",
					"name": "PortalOrganizationSetup",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.PortalOrganizationSetupLinkCaption"},
						"tag": "navigateToPortalOrganizationSetup",
						"click": {"bindTo": "invokeOperation"}
					}
				}
			]
		};
	});
