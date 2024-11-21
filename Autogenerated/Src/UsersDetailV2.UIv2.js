define("UsersDetailV2", ["ConfigurationConstants", "ConfigurationEnums"],
	function(ConfigurationConstants, enums) {
		return {
			entitySchemaName: "VwSysAdminUnit",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"openRecord": {"bindTo": "onGridDoubleClick"},
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "ContactNameListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.ContactNameColumnCaption"},
									"bindTo": "Contact.Name",
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 6
									}
								},
								{
									"name": "JobTitleListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.JobTitleColumnCaption"},
									"bindTo": "Contact.JobTitle",
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 6
									}
								},
								{
									"name": "MobilePhoneListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.MobilePhoneColumnCaption"},
									"bindTo": "Contact.MobilePhone",
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 6
									}
								},
								{
									"name": "NameListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.NameColumnCaption"},
									"bindTo": "Name",
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 6
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 1
							},
							"items": [
								{
									"name": "NameTiledGridColumn",
									"bindTo": "Name",
									"caption": {"bindTo": "Resources.Strings.NameColumnCaption"},
									"type": "text",
									"position": {
										"row": 1,
										"column": 0,
										"colSpan": 11
									},
									"captionConfig": {
										"visible": false
									}
								}
							]
						}
					}
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"click": {"bindTo": "onAddButtonClick"},
						"menu": []
					}
				},
				{
					"operation": "insert",
					"name": "AddExistingRecordButton",
					"parentName": "AddRecordButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddExistingUserButtonCaption"},
						"click": {"bindTo": "onAddExistingUser"}
					}
				},
				{
					"operation": "insert",
					"name": "AddNewRecordButton",
					"parentName": "AddRecordButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddNewUserButtonCaption"},
						"click": {"bindTo": "addRecord"}
					}
				}
			]/**SCHEMA_DIFF*/,
			messages: {
				/**
				 * ######## ########## # ######## # #### ### ######.
				 */
				"SetRecordInformation": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}

			},
			attributes: {
				/**
				 * ####### ####, ######### ## ## ########## ############# ############.
				 */
				"IsAddExistingUser": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
				}
			},
			methods: {
				/**
				 * ########## ######## ##### ## ###### # ####### ######.
				 * @protected
				 */
				onGridDoubleClick: function() {
					this.editRecord();
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				*/
				getAddRecordButtonEnabled: function() {
					return true;
				},

				/**
				 * ########## ##### ## ###### "########".
				 * @returns {boolean} ###### ########## false, #.#. ### ###### ############ ### ######## ####.
				 */
				onAddButtonClick: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BaseSchemaViewModel#initEditPages
				 * @protected
				 * @overridden
				 */
				initEditPages: function() {
					this.callParent(arguments);
					var editPages = this.get("EditPages");
					var typeUId = this.BPMSoft.GUID_EMPTY;
					if (this.Ext.isEmpty(editPages.find(typeUId))) {
						editPages.add(typeUId, this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: typeUId,
								Caption: this.get("Resources.Strings.EditPageCaption"),
								Click: {bindTo: "addRecord"},
								Tag: typeUId,
								SchemaName: "UserPageV2"
							}
						}));
					}
				},

				/**
				 * ########## #######, ####### ###### ########## ########.
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 * @return {Object} ########## ###### ########-############ #######.
				 */
				getGridDataColumns: function() {
					var config = this.callParent(arguments);
					config["Contact.Name"] = {path: "Contact.Name"};
					config["Contact.JobTitle"] = {path: "Contact.JobTitle"};
					config["Contact.MobilePhone"] = {path: "Contact.MobilePhone"};
					return config;
				},

				/**
				 * ######### #### ###### ############ #############.
				 * @protected
				 */
				getUsersList: function() {
					var config = this.prepareLookupConfig();
					this.openLookup(config, this.addCallback, this);
				},

				/**
				 * Creates users lookup config. Only users that do not belong to current role will be shown.
				 * @return {Object} Users lookup config.
				 */
				prepareLookupConfig: function() {
					var config = {
						entitySchemaName: "SysAdminUnit",
						multiSelect: true,
						columns: ["Contact", "Name"],
						hideActions: true,
						lookupPostfix: "_UsersDetail"
					};
					var filters = this.Ext.create("BPMSoft.FilterGroup");
					var currentRoleId = this.getTargetRoleId();
					var currentRoleFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysRole", currentRoleId);
					var usersNotInCurrentRoleFilter = this.BPMSoft.createNotExistsFilter(
						"[SysUserInRole:SysUser:Id].Id", currentRoleFilter);
					filters.addItem(usersNotInCurrentRoleFilter);
					var connectionType = this.getConnectionType();
					var connectionFilter;
					if (!this.Ext.isEmpty(connectionType)) {
						connectionFilter = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"ConnectionType",
							connectionType.value
						);
					} else {
						connectionFilter = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"ConnectionType",
							ConfigurationConstants.UserType.GENERAL
						);
					}
					filters.addItem(connectionFilter);
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitTypeValue",
						ConfigurationConstants.SysAdminUnit.Type.User));
					config.filters = filters;
					return config;
				},

				/**
				 * ## ####### ######## ## ######### ########## ######## # ###### "ConnectionType" ### null.
				 * @return {Object} ### ############ ### null, #### ### ############ ## ###### ##### ########
				 * ## #########.
				 */
				getConnectionType: function() {
					var result = null;
					this.BPMSoft.each(this.get("DefaultValues"), function(value) {
						if (value.name === "ConnectionType") {
							result = value;
						}
					});
					return result;
				},

				/**
				 * ########## ####### ## ###### ######## ######.
				 * @inheritdoc BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					this.set("IsAddExistingUser", false);
					this.callParent([this.BPMSoft.GUID_EMPTY]);
				},

				/**
				 * ########## ####### ## ###### ######## #############.
				 */
				onAddExistingUser: function() {
					this.set("IsAddExistingUser", true);
					var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNew = (cardState.state === enums.CardStateV2.ADD ||
					cardState.state === enums.CardStateV2.COPY);
					if (isNew) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					this.getUsersList();
				},

				/**
				 * @overridden
				 */
				onCardSaved: function() {
					if (this.get("IsAddExistingUser")) {
						this.getUsersList();
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * ########## id ### ######## UserPageV2, ########## ## ###### UsersDetailV2.
				 * @return {string} ############### id
				 */
				getUsersDetailSandboxId: function() {
					return this.sandbox.id + "UserPageV2" + this.BPMSoft.GUID_EMPTY;
				},

				/**
				 * @inheritDoc BaseGridDetail#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DeleteButtonCaption"},
						Click: {"bindTo": "deleteRecords"},
						Enabled: {"bindTo": "canDeleteUserInRole"}
					});
				},

				/**
				 * #########, ##### ## ######### ############ ## ####.
				 * @return {Boolean} True, #### ############ ###### # ## ###### # ######## #### ### ########
				 * ############# #######, ##### False.
				 */
				canDeleteUserInRole: function() {
					var defaultValues = this.get("DefaultValues");
					return this.isAnySelected() && this.getIsParentRoleExist(defaultValues);
				},

				/**
				 * ########## ####### ## ###### #### #######.
				 * @inheritdoc GridUtilitiesV2#deleteRecords
				 * @overridden
				 */
				deleteRecords: function() {
					this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
						function(returnCode) {
							if (returnCode !== this.BPMSoft.MessageBoxButtons.YES.returnCode) {
								return;
							}
							this.onDeleteRecords();
						},
						[this.BPMSoft.MessageBoxButtons.YES.returnCode,
							this.BPMSoft.MessageBoxButtons.NO.returnCode],
						null);
				},

				/**
				 * ######### ######## ###### #######.
				 * @protected
				 * @virtual
				 * @param {Object} response
				 */
				validateResponse: function(response) {
					this.hideBodyMask();
					var isSuccess = response && response.success;
					if (!isSuccess) {
						var errorMessage = response.message;
						if (errorMessage) {
							this.showInformationDialog(errorMessage);
						}
					}
					return isSuccess;
				},

				/**
				 * ######## ####### # ######### ############# ## ####### SysUserInRole,
				 * ### ####### # #### ########### #####.
				 * @protected
				 */
				onDeleteRecords: function() {
					var selectedRows = this.getSelectedItems();
					var dataSend = {
						roleIds: this.Ext.encode(this.get("SelectedNodesPrimaryColumnValues")),
						userIds: this.Ext.encode(selectedRows),
						recordIds: ""
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "RemoveUsersInRoles",
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, this.afterDeleteRecords, this);
				},

				/**
				 * ######### ############# ######## #############.
				 * @private
				 * @param {object} response ##### #######.
				 */
				afterDeleteRecords: function(response) {
					var result = this.Ext.decode(response.RemoveUsersInRolesResult);
					response.message = result.ExceptionMessage;
					response.success = result.Success;
					var deletedItems = result.DeletedItems;
					this.removeGridRecords(deletedItems);
					this.validateResponse(response);
				},

				/**
				 * ######## ############# ### ####, # ############## ####### ##### ####### ######.
				 * @returns {String} ############# ####.
				 */
				getTargetRoleId: function() {
					return this.get("MasterRecordId");
				},

				/**
				 * Callback-#######, ####### ########## ##### ######## #### ###### ## ########### #############.
				 * @virtual
				 * @param {Object} args ######, ########## ######### ######### #######.
				 */
				addCallback: function(args) {
					var dataSend = {
						roleId: this.getTargetRoleId(),
						userIds: this.Ext.encode(args.selectedRows.getKeys())
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "AddUsersInRole",
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, function(response) {
						response.message = response.AddUsersInRoleResult;
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.reloadGridData();
						}
					}, this);
				},

				/**
				 * ######### ###### # ###### ######.
				 * @protected
				 * @inheritdoc GridUtilitiesV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					if (this.get("ServiceDataLoaded")) {
						this.callParent(arguments);
						this.set("ServiceDataLoaded", false);
						return;
					}
					this.selectChildUnits(this.loadGridData);
				},

				/**
				 * ########## #######, #### ### ### # ######, ######### # ############ #######,
				 * ############ ####.
				 * @param {Array} defaultValues ######## ## ######### ########.
				 * @return {boolean} True, #### # ######### ###### # ############ ####### #### ########,
				 * ##### False.
				 */
				getIsParentRoleExist: function(defaultValues) {
					var result = null;
					this.BPMSoft.each(defaultValues, function(value) {
						if (value.name === "IsParentRoleExist") {
							result = value;
						}
					});
					return this.Ext.isEmpty(result) ? false : result.value;
				},

				/**
				 * @inheritdoc BaseGridDetailV2#initData
				 * @overridden
				 */
				initData: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("SetRecordInformation", function() {
						return {
							parent:  this.get("MasterRecordId"),
							defaultValues: this.get("DefaultValues"),
							type: ConfigurationConstants.SysAdminUnit.TypeGuid.User
						};
					}, this, [this.getUsersDetailSandboxId()]);
				},

				/**
				 * ##### ######## ######, ####### ########## ############## ########, ## ######### # ##########,
				 * #############.
				 * @protected
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####, ### ######## ######.
				 */
				selectChildUnits: function(callback) {
					var dataSend = {
						parentRoleId: this.get("MasterRecordId")
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetChildAdminUnits",
						data: dataSend
					};
					this.callService(config, function(response) {
						if (response && response.GetChildAdminUnitsResult) {
							this.set("SelectedNodesPrimaryColumnValues", response.GetChildAdminUnitsResult);
							this.set("ServiceDataLoaded", true);
							if (this.Ext.isFunction(callback)) {
								callback.call(this);
							}
						}
					}, this);
				},

				/**
				 * ########## ###### ### ########## #######.
				 * @protected
				 * @inheritdoc BaseGridDetailV2#getFilters
				 * @overridden
				 * @return {BPMSoft.FilterGroup} ###### ######## filters.
				 **/
				getFilters: function() {
					var filters = this.get("DetailFilters");
					var serializationInfo = filters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					var deserializedFilters = BPMSoft.deserialize(filters.serialize(serializationInfo));
					deserializedFilters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitType.Value",
						ConfigurationConstants.SysAdminUnit.Type.User));
					deserializedFilters.add("Filter", this.get("Filter"));
					return deserializedFilters;
				},

				/**
				 * @overridden
				 * @return {String} ### #######.
				 */
				getFilterDefaultColumnName: function() {
					return "Contact";
				}
			}
		};
	});
