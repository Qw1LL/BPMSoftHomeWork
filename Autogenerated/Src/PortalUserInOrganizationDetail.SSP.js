define("PortalUserInOrganizationDetail", ["DefaultProfileHelper", "MaskHelper", "ConfigurationEnums",
		"PortalUserInvitationMixin", "ControlGridModule"],
	function(DefaultProfileHelper, MaskHelper, Enums) {
		return {
			profileKey: null,
			entitySchemaName: "VwSspAdminUnit",
			properties: {

				/**
				 * Unique identifier of user sysAdminUnitType.
				 */
				userSysAdminUnitType: this.BPMSoft.RightsEnums.sysAdminUnitType[4],

				/**
				 * User function roles of the the users organization.
				 */
				userFuncRoles: null

			},
			mixins: {
				PortalUserInvitationMixin: "BPMSoft.PortalUserInvitationMixin"
			},
			attributes: {

				/**
				 * InviteModuleContainer visibility flag.
				 */
				"InviteContainerVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * Is Organization by Account exists.
				 */
				"IsOrganizationExists": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * Indicates whether buttons for creating new Organization is visible.
				 */
				"IsCreateOrganizationButtonVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Indicates add portal user button if new Organization is created.
				 */
				"IsAddPortalUserButtonVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Indicates that the user has SSP connection.
				 */
				"IsSspUser": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Additional column names for control grid.
				 */
				"AdditionalColumnNames": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"propertyName": "tools",
					"name": "AddRecord",
					"parentName": "Detail",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"menu": [],
						"classes": {
							"textClass": "user-portal-add-record-button-text",
						},
						"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
						"visible": {"bindTo": "IsAddPortalUserButtonVisible"},
					}
				},
				{
					"operation": "insert",
					"name": "AddRecordOnSsp",
					"parentName": "Detail",
					"propertyName": "tools",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
						"visible": {"bindTo": "IsSspUser"},
						"click": {"bindTo": "createUsersByEmail"}
					}
				},
				{
					"operation": "insert",
					"name": "AddPortalUserButton",
					"parentName": "AddRecord",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddPortalUser"},
						"click": {"bindTo": "addPortalUser"},
						"visible": {"bindTo": "getIsAddPortalUserButtonVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "InvitePortalUsersButton",
					"parentName": "AddRecord",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CreatePortalUsers"},
						"click": {"bindTo": "createUsersByEmail"}
					}
				},
				{
					"operation": "insert",
					"name": "AlignableInviteContainer",
					"values": {
						"id": "AlignableInviteContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.AlignableContainer",
						"wrapClass": ["invite-alignable-container"],
						"visible": {"bindTo": "InviteContainerVisible"},
						"alignToEl": null,
						"showOverlay": {"bindTo": "InviteContainerVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "InviteModuleContainer",
					"parentName": "AlignableInviteContainer",
					"propertyName": "items",
					"values": {
						"id": "InviteModuleContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["invite-module-container"]
					}
				},
				{
					"name": "DataGrid",
					"operation": "merge",
					"values": {
						"className": "BPMSoft.ControlGrid",
						"applyColumnNames": {"bindTo": "AdditionalColumnNames"},
						"allowedManyControls": true,
						"applyControlConfig": {"bindTo": "applyControlConfig"},
						"needUpdateRow": {"bindTo": "onNeedUpdateRow"}
					}
				},
				{
					"operation": "insert",
					"parentName": "Detail",
					"propertyName": "tools",
					"name": "CreateOrganizationButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.CreateOrganizationButtonCaption"},
						"click": {"bindTo": "onCreateOrganizationButtonClick"},
						"visible": {"bindTo": "IsCreateOrganizationButtonVisible"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
			]/**SCHEMA_DIFF*/,
			messages: {

				/**
				 * Informs that the modal box has been closed.
				 */
				"OnInvitePortalUserFormClosed": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * Informs that need to set container visibility.
				 */
				"SetInviteContainerVisibility": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getOpenCardConfig
				 * @override
				 */
				getOpenCardConfig: function() {
					const config = this.callParent(arguments);
					config.schemaName = "UserPageV2";
					return config;
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#sortColumn
				 * @override
				 */
				sortColumn: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
				 * @override
				 */
				getGridSortMenuItem: this.BPMSoft.emptyFn,

				/**
				 * Check if current user is ssp user.
				 * @returns {boolean} True, if current user is ssp user
				 * @private
				 */
				_isSspUser: function() {
					return this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
				},

				/**
				 * @inheritDoc BaseDetailV2#init
				 * @override
				 */
				init: function(callback, scope) {
					this.userFuncRoles = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.$AdditionalColumnNames = ["Active"];
					this.callParent([callback, scope]);
					this.$IsSspUser = this._isSspUser();
				},

				/**
				 * @inheritDoc BPMSoft.MessageHistoryPage#subscribeSandboxEvents
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("OnInvitePortalUserFormClosed", this.onInviteUserFormClosed, this,
						[this.sandbox.id]);
					this.sandbox.subscribe("SetInviteContainerVisibility", this.onSetInviteContainerVisibility, this,
						[this.sandbox.id]);
				},

				/**
				 * Sets visibility to invite container.
				 * @param {Boolean} value Is container visible.
				 */
				onSetInviteContainerVisibility: function(value) {
					this.set("InviteContainerVisible", value);
				},

				/**
				 * Invite form closed action.
				 * @protected
				 */
				onInviteUserFormClosed: function() {
					this.unloadInvitationModule();
					this.set("InviteContainerVisible", false);
					this._actualizeProfile();
				},

				/**
				 * @private
				 */
				_actualizeProfile: function() {
					this.initializeProfile(function() {
						this.$GridSettingsChanged = true;
						this.reloadGridData();
						this.sandbox.publish("DetailChanged", null, [this.sandbox.id]);
					}, this);
				},

				/**
				 * Unloads invitation module.
				 * @protected
				 */
				unloadInvitationModule: function() {
					const moduleName = "PortalUserInvitationModule";
					this.sandbox.unloadModule(this.sandbox.id + "_" + moduleName);
				},

				/**
				 * @inheritDoc BaseGridDetailV2#getFilters
				 * @override
				 */
				getFilters: function() {
					const filters = this.callParent(arguments);
					filters.add("UserSysAdminUnitTypeFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitType", this.userSysAdminUnitType));
					return filters;
				},

				/**
				 * @inheritDoc BaseGridDetailV2#getExportToExcelFileMenuItem
				 * @override
				 */
				getExportToExcelFileMenuItem: function() {
					return this._isSspUser() ? null : this.callParent(arguments);
				},

				/**
				 * @inheritDoc BaseGridDetailV2#getShowQuickFilterButton
				 * @override
				 */
				getShowQuickFilterButton: function() {
					return this._isSspUser() ? null : this.callParent(arguments);
				},

				/**
				 * Gets is add button visible.
				 * @returns {boolean} Returns true if button visible.
				 */
				getIsAddPortalUserButtonVisible: function() {
					return !this._isSspUser();
				},

				/**
				 * Creates portal users by emails and connects them to the organization.
				 */
				createUsersByEmail: function() {
					if (this.$IsOrganizationExists) {
						this.showInvitationForm();
					} else {
						this.showOrganizationInformationDialog(this.getAccountInfo());
					}
				},

				/**
				 * Add new portal users and connects them to the organization.
				 */
				addPortalUser: function() {
					if (this.$IsOrganizationExists) {
						this.openContactLookup();
					} else {
						this.showOrganizationInformationDialog(this.getAccountInfo());
					}
				},

				/**
				 * Returns account columns values.
				 * @return {Object} Columns values.
				 */
				getAccountInfo: function() {
					return this.sandbox.publish("GetColumnsValues", ["Id", "Name"], [this.sandbox.id]);
				},

				/**
				 * Opens lookup with contacts without organization.
				 * @protected
				 */
				openContactLookup: function() {
					const lookupConfig = {
						entitySchemaName: "Contact",
						multiSelect: true,
						hideActions: true
					};
					const filterGroup = BPMSoft.createFilterGroup();
					filterGroup.add("accountFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Account", this.$MasterRecordId));
					const  accountfilterGroup = BPMSoft.createFilterGroup();
					accountfilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					accountfilterGroup.add("notOrganizationUsers",
						this.BPMSoft.createColumnIsNullFilter("[SysAdminUnit:Contact:Id].PortalAccount"));
					accountfilterGroup.add("notInCurrentOrganization",
						this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.NOT_EQUAL,
							"[SysAdminUnit:Contact:Id].PortalAccount", this.$MasterRecordId));
					filterGroup.add("AdminUnitFilter", accountfilterGroup);
					lookupConfig.filters = filterGroup;
					this.openLookup(lookupConfig, this.onSelectContact, this);
				},

				/**
				 * Callback function that is called after the window for selecting contact is closed.
				 * @protected
				 * @param {Object} selectedItems Selected contacts in lookup.
				 */
				onSelectContact: function(selectedItems) {
					const selectedContactsId = selectedItems.selectedRows
						.getItems()
						.map(function(item) {
							return item.Id;
						});
					if (this.Ext.isEmpty(selectedContactsId)) {
						return;
					}
					this._showBodyMask();
					this.createUsersByContacts(selectedContactsId, function() {
						this._hideBodyMask();
						this._actualizeProfile();
					}, this);
				},

				/**
				 * Shows a mask on the tag content container.
				 * @private
				 */
				_showBodyMask: function() {
					this._maskId = MaskHelper.showBodyMask();
				},

				/**
				 * Hides a mask on the tag content container.
				 * @private
				 */
				_hideBodyMask: function() {
					MaskHelper.hideBodyMask({ maskId: this._maskId});
				},

				/**
				 * Show modal box for inputting emails of portal users.
				 * @protected
				 */
				showInvitationForm: function() {
					const invitationModuleConfig = {
						renderTo: "InviteModuleContainer",
						id: this.sandbox.id + "_PortalUserInvitationModule",
						parameters: {
							PortalAccountId: this.$MasterRecordId
						}
					};
					this.set("InviteContainerVisible", true);
					this.sandbox.loadModule("PortalUserInvitationModule", invitationModuleConfig);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#addDetailWizardMenuItems
				 * @override
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @override
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BaseGridDetailV2#getDeleteRecordMenuItem
				 * @override
				 */
				getDeleteRecordMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DeleteMenuCaption"},
						Click: {"bindTo": "deleteRecords"},
						Enabled: {"bindTo": "isAnySelected"},
						Visible: {"bindTo": "getIsDeleteOperationVisible"}
					});
				},

				/**
				 * Return visibility of Delete operation.
				 * @returns {Boolean} visibility.
				 */
				getIsDeleteOperationVisible: function() {
					return !this.$IsSspUser && this.get("IsEnabled") &&
						(this.get("CanAdministratePortalUsers") || this.get("CanManageUsers"));
				},

				getGridSettingsMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @override
				 */
				getFilterDefaultColumnName: function() {
					return "Contact";
				},

				/**
				 * @inheritDoc BPMSoft.BaseDetailV2#initDetailOptions
				 * @override
				 */
				initDetailOptions: function() {
					this.callParent(arguments);
					this.set("IsDetailCollapsed", false);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#checkNotFoundColumns
				 * @override
				 */
				checkNotFoundColumns: this.BPMSoft.emptyFn,

				/**
				 * Initialize schema profile and add optional functional roles to it.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				initializeProfileWithOppFuncRoles: function(callback, scope) {
					const serviceConfig = {
						serviceName: "SspUserManagementService",
						methodName: "GetOptionalFuncRolesList",
						data: {
							sspAccountId: this.$MasterRecordId
						}
					};
					this.callService(serviceConfig, function(response) {
						this.onUserOptionalFunctionalRolesLoaded(response, callback, scope);
					}, this);
				},

				/**
				 * Creates users optional functional roles collection and apply it to view model property.
				 * @protected
				 * @param {Object} responseResult SspUserManagementService response result.
				 * @param {Array} responseResult.RolesCollection Users optional functional roles collection.
				 *
				 */
				applyUsersOppFuncRoles: function(responseResult) {
					this.userFuncRoles = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.BPMSoft.each(responseResult.RolesCollection, function(role, index) {
						const columnName = "FuncRole_" + index;
						const roleItem = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: role.Key,
								Caption: role.Value,
								Name: columnName
							}
						});
						this.userFuncRoles.add(role.Key, roleItem);
					}, this);
				},

				/**
				 * Handler for SspUserManagementService call.
				 * @param {Object} response Response, which contains optional functional roles for users organization.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				onUserOptionalFunctionalRolesLoaded: function(response, callback, scope) {
					const result = response && response.GetOptionalFuncRolesListResult;
					if (result) {
						this.applyUsersOppFuncRoles(result);
						this.enrichProfile();
						this._updateAdditionalColumnNames();
					}
					this.Ext.callback(callback, scope);
				},

				/**
				 * @private
				 */
				_updateAdditionalColumnNames: function() {
					if (this.isNotEmpty(this.userFuncRoles)) {
						const roles = this.userFuncRoles.mapArrayByAttr("Name");
						const columns = this.BPMSoft.deepClone(this.$AdditionalColumnNames) || [];
						this.set("AdditionalColumnNames", columns.concat(roles));
					}
				},

				/**
				 * Passes optional functional roles control config by reference.
				 * @param {Object} control Configuration object.
				 * @param {Object} item Item of grid row element.
				 * @override
				 */
				applyControlConfig: function(control, item) {
					control.config = {
						"className": "BPMSoft.CheckBoxEdit",
						"checked": {"bindTo": item.columnName.bindTo},
						"markerValue": item.id
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getProfileKey
				 * @override
				 */
				getProfileKey: this.BPMSoft.emptyFn,

				/**
				 * Enrich schema profile by additional columns.
				 * @protected
				 */
				enrichProfile: function() {
					let profile;
					const entitySchema = this.getGridEntitySchema();
					if (entitySchema) {
						const defColumns = this.getGridColumns(entitySchema);
						profile = DefaultProfileHelper.getEntityProfile(this.getProfileKey(),
							entitySchema.name, this.BPMSoft.GridType.LISTED, defColumns);
					} else {
						profile = {};
					}
					const profileColumnName = this.getProfileColumnName();
					this.set(profileColumnName, profile);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#initializeProfile
				 * @override
				 */
				initializeProfile: function(callback, scope) {
					this.initializeProfileWithOppFuncRoles(callback, scope);
				},

				/**
				 * Obtain columns for schema profile.
				 * @protected
				 * @param {BPMSoft.EntitySchema} schema Grid entity schema.
				 * @returns {Array} Profile columns.
				 */
				getGridColumns: function(schema) {
					const columns = [];
					this.addUserColumns(columns, schema);
					this.addFuncRolesColumns(columns);
					this.addUserActivityColumn(columns, schema);
					return columns;
				},

				/**
				 * Add user and contact columns.
				 * @protected
				 * @param {Array} columns Schema columns.
				 * @param {BPMSoft.EntitySchema} schema Grid entity schema.
				 */
				addUserColumns: function(columns, schema) {
					columns.push(schema.columns.Name);
					columns.push(schema.columns.Contact);
				},

				/**
				 * Add user active column.
				 * @protected
				 * @param {Array} columns Schema columns.
				 * @param {BPMSoft.EntitySchema} schema Grid entity schema.
				 */
				addUserActivityColumn: function(columns, schema) {
					columns.push(schema.columns.Active);
				},

				/**
				 * Add users optional functional role columns.
				 * @protected
				 * @param {Array} columns Schema columns.
				 * @returns {Array} Profile columns.
				 */
				addFuncRolesColumns: function(columns) {
					this.BPMSoft.each(this.userFuncRoles, function(role) {
						const roleColumn = {
							uId: role.$Id,
							caption: role.$Caption,
							columnPath: role.$Name,
							isInherited: false,
							isValueCloneable: true,
							name: role.$Name,
							usageType: 0
						};
						columns.push(roleColumn);
					}, this);
					return columns;
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#createViewModel
				 * @override
				 */
				createViewModel: function(config) {
					this.BPMSoft.each(this.userFuncRoles, function(item) {
						if (config.rowConfig[item.$Name]) {
							config.rowConfig[item.$Name].dataValueType = this.BPMSoft.DataValueType.BOOLEAN;
							delete config.rowConfig[item.$Name].isNotFound;
						}
					}, this);
					return this.callParent([config]);
				},

				/**
				 * Return columns array, which should be rendered with custom control.
				 * @protected
				 * @returns {Array}
				 * @deprecated Use attribute AdditionalColumnNames instead.
				 */
				getApplyColumnNames: function() {
					return this.$AdditionalColumnNames;
				},

				/**
				 * Get user by identifier.
				 * @param {Object} users Collection of user base schema view models.
				 * @param id {String} User identifier.
				 * @private
				 */
				_getUserById: function(users, id) {
					return users.find(function(item) {
						return item.$Id === id;
					});
				},

				/**
				 * Get role name by identifier.
				 * @param id
				 * @private
				 */
				_getRoleNameById: function(id) {
					const role = this.userFuncRoles.find(id);
					if (!role) {
						throw new this.BPMSoft.ItemNotFoundException({message: "Functional role does not exist"});
					}
					return role.$Name;
				},

				/**
				 * Get role identifier by name.
				 * @param name
				 * @private
				 */
				_getRoleIdByName: function(name) {
					const role = this.userFuncRoles.findByAttr("Name", name);
					if (!role) {
						throw new this.BPMSoft.ItemNotFoundException({message: "Functional role does not exist"});
					}
					return role.$Id;
				},

				/**
				 * Set users functional roles values in users collection.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} users Users collection.
				 * @param {Object} serviceResponse Response from user management service.
				 */
				setUsersRoles: function(users, serviceResponse) {
					const serviceResult = serviceResponse.GetEnabledFuncRolesForUserResult;
					if (serviceResult.success) {
						this.BPMSoft.each(serviceResult.UsersInRoles, function(userInRole) {
							const user = this._getUserById(users, userInRole.UserId);
							if (user) {
								try {
									const roleName = this._getRoleNameById(userInRole.RoleId);
									user.set(roleName, userInRole.IsRoleApplied, {silent: true});
								} catch (e) {
									this.log(e.message, this.BPMSoft.LogMessageType.ERROR);
								}
							}
						}, this);
					} else {
						this.showInformationDialog(serviceResult.errorInfo && serviceResult.errorInfo.message);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#updateLoadedGridData
				 * @override
				 */
				updateLoadedGridData: function(response, callback, scope) {
					this.mixins.PortalUserInvitationMixin.checkRightsPermission(
						function() {
							if (this.get("CanManageUsers") || this.get("CanAdministratePortalUsers")) {
								const users = response.collection.getItems();
								if (this.Ext.isEmpty(users)) {
									this.Ext.callback(callback, scope || this, [response]);
									return;
								}
								const serviceConfig = {
									serviceName: "SspUserManagementService",
									methodName: "GetEnabledFuncRolesForUser",
									data: {
										userIds: users.map(function(user) {
											return user.$Id;
										})
									}
								};
								this.callService(serviceConfig, function(serviceResponse) {
									this.setUsersRoles(users, serviceResponse);
									this.Ext.callback(callback, scope || this, [response]);
								}, this);
							} else {
								this.Ext.callback(callback, scope || this, [response]);
							}
						},
						scope || this
					);
				},

				/**
				 * Return data for update role query.
				 * @protected
				 * @param {Guid} userId user identifier.
				 * @param {Object} roleValues View model changed values object, which contains user optional.
				 * @returns {Object} data for updateUserInRole service query.
				 */
				getRoleUpdatedData: function(userId, roleValues) {
					const roleName = this.Ext.Object.getKeys(roleValues).pop();
					const roleId = this._getRoleIdByName(roleName);
					const roleValue = roleValues[roleName];
					return {
						usersInRoles: [{
							UserId: userId,
							RoleId: roleId,
							IsRoleApplied: roleValue
						}]
					};
				},

				/**
				 * Return data for update IsActive query.
				 * @protected
				 * @param {Guid} userId user identifier.
				 * @param {Object} changedValues View model changed values object.
				 * @returns {Object} Data for updateUserIsActiveStatus service query.
				 */
				getIsActiveUpdatedData: function(userId, changedValues) {
					return {
						userId: userId,
						isActive: changedValues.Active
					};
				},

				/**
				 * Clear changed values in view model.
				 * @protected
				 * @param {Object} changedValues View model changed values.
				 */
				clearChangedValues: function(changedValues) {
					const dropValue = function(key) {
						delete changedValues[key];
					};
					this.Ext.Object.getKeys(changedValues).every(dropValue);
				},

				/**
				 * Update user optional functional role.
				 * @protected
				 * @param {Array} data Array of data, which contains user and his applied and not applied optional
				 * functional roles.
				 * @param callback
				 * @param scope
				 */
				updateUserInRole: function(data, callback, scope) {
					const serviceConfig = {
						serviceName: "SspUserManagementService",
						methodName: "ApplyOptionalFuncRolesForUsers",
						data: data
					};
					this.callService(serviceConfig, function(serviceResponse) {
						const serviceResult = serviceResponse.ApplyOptionalFuncRolesForUsersResult;
						if (serviceResult.success) {
							this.Ext.callback(callback, scope || this, [serviceResult]);
						} else {
							this.showInformationDialog(serviceResult.errorInfo && serviceResult.errorInfo.message);
						}
					}, this);
				},

				/**
				 * Updates user Active status.
				 * @protected
				 * @param {Object} data Data which contains information about user Active status.
				 * @param callback
				 * @param scope
				 */
				updateUserIsActiveStatus: function(data, callback, scope) {
					const serviceConfig = {
						serviceName: "SspUserManagementService",
						methodName: "ChangeUserActivationStatus",
						data: data
					};
					this.callService(serviceConfig, function(serviceResponse) {
						const serviceResult = serviceResponse.ChangeUserActivationStatusResult;
						if (serviceResult.success) {
							this.Ext.callback(callback, scope || this, [serviceResult]);
						} else {
							this.showInformationDialog(serviceResult.errorInfo && serviceResult.errorInfo.message);
						}
					}, this);
				},

				/**
				 * Handle after updating user functional role value.
				 * @protected
				 * @param {Object} serviceResult Result of the ApplyOptionalFuncRolesForUsers service.
				 */
				onUserRoleUpdated: this.BPMSoft.emptyFn,

				/**
				 * Handler for needUpdateRow event in ControlGrid.
				 * This function handle checkbox checked state in optional functional role that connected with control.
				 * @protected
				 * @param userId user identifier.
				 * @param {Object} changedValues View model changed values object, which contains user optional
				 * functional roles.
				 * @returns {boolean}
				 */
				onNeedUpdateRow: function(userId, changedValues) {
					try {
						this.updateChangedValuesData(userId, changedValues);
					} catch (e) {
						this.log(e.message, this.BPMSoft.LogMessageType.ERROR);
						return false;
					}
					this.clearChangedValues(changedValues);
					return true;
				},

				/**
				 * Updates  detail changed values.
				 * @param {Guid} userId user identifier.
				 * @param {Object} changedValues View model changed values object.
				 */
				updateChangedValuesData: function(userId, changedValues) {
					let updateData;
					switch (true) {
						case changedValues.hasOwnProperty("Active"):
							updateData = this.getIsActiveUpdatedData(userId, changedValues);
							this.updateUserIsActiveStatus(updateData, this.onUserRoleUpdated, this);
							break;
						default:
							updateData = this.getRoleUpdatedData(userId, changedValues);
							this.updateUserInRole(updateData, this.onUserRoleUpdated, this);
							break;
					}
				},

				processCheckMasterRecordEditRights: function() {
					if (this.needDestroy) {
						this.destroy();
					}
				},

				updateDetail: function(config) {
					if (config.reloadAll) {
						this.needDestroy = true;
					}
				},

				/**
				 * Handles click on organization creation button.
				 * @protected
				 */
				onCreateOrganizationButtonClick: function () {
					this.createOrganizationByAccount(this.getAccountInfo());
				},

				/**
				 * Initializes existence of Organization by Account.
				 * @protected
				 */
				initializeIsOrganizationExists: function(callback) {
					const accountId = this.$MasterRecordId;
					this.checkOrganization(accountId, function(response) {
						const result = response && response.isPortalAccountExists;
						this.$IsOrganizationExists = result;
						if (callback) {
							this.Ext.callback(callback, this, [result]);
						}
					}, this);
				},

				/**
				 * Set CreateOrganization button visibility.
				 * @private
				 * @param {boolean} value Boolean value indicates should be button hidden or display.
				 * If comes true than button will be hide, otherwise displayed.
				 */
				_hideCreateOrganizationButton: function(value) {
					if (this._isSspUser() || this.$CardPageName === "OrganizationDetailPage") {
						this.$IsCreateOrganizationButtonVisible = false;
					} else {
						this.$IsCreateOrganizationButtonVisible = !value;
					}
				},

				/**
				 * Set AddPortalUser button visibility.
				 * @private
				 * @param {boolean} value Boolean value indicates should be button hidden or display.
				 * If comes true than button will be hide, otherwise displayed.
				 */
				_hideAddPortalUserButton: function(value) {
					if (this.$CardPageName === "OrganizationDetailPage") {
						this.$IsAddPortalUserButtonVisible = !this._isSspUser();
					} else {
						this.$IsAddPortalUserButtonVisible = !this._isSspUser() && value;
					}
				},

				/**
				 * @private
				 * @param {boolean} value Boolean value indicates should be button hidden or display.
				 */
				_hideButtonsOninitialize: function(value) {
					this._hideCreateOrganizationButton(value);
					this._hideAddPortalUserButton(value);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#onRender
				 * @override
				 */
				onRender: function() {
					this.initializeIsOrganizationExists(this._hideButtonsOninitialize);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
					toolsButtonMenu.addItem(this.getInviteContactsButtonMenuItem());
				},

				/**
				 * Returns an element of combobox list of functional button which is responsible for inviting
				 * users on portal.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.BaseViewModel} An element of combobox list of functional button.
				 */
				getInviteContactsButtonMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.InviteUsersButtonCaption"},
						Click: {"bindTo": "onInviteUsersButtonClick"},
						Enabled: {"bindTo": "isAnySelected"}
					});
				},

				/**
				 * Handles click on invitation button.
				 */
				onInviteUsersButtonClick: function() {
					const selectedUsersId = this.getSelectedItems();
					if (this.Ext.isEmpty(selectedUsersId)) {
						return;
					}
					this._showBodyMask();
					this.inviteUsers(selectedUsersId, function() {
						this._hideBodyMask();
						this._actualizeProfile();
					}, this);
				},

				/**
				 * @inheritDoc GridUtilitiesV2#addColumnLink
				 * @override
				 */
				addColumnLink: function(item, column) {
					const columnName = "Name";
					if (column.columnPath === columnName) {
						const recordId = item.get("Id");
						const displayValue = item.get(columnName);
						const url = "ViewModule.aspx#" + this.BPMSoft.combinePath("CardModuleV2", "UserPageV2",
							Enums.CardStateV2.EDIT, recordId);
						const link = {
							caption: displayValue,
							target: "_self",
							title: displayValue,
							url: url
						};
						item["on" + columnName + "LinkClick"] = function() {
							return link;
						};
						return;
					}
					this.callParent(arguments);
				}
			}
		};
	});
