define("SysAdminUnitRoleBasePageV2", ["ConfigurationConstants", "SysAdminUnitRoleBasePageV2Resources"],
	function(ConfigurationConstants, resources) {
		return {
			entitySchemaName: "VwSysAdminUnit",
			details: /**SCHEMA_DETAILS*/{
				UsersDetailV2: {
					schemaName: "UsersDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "[SysUserInRole:SysUser:Id].[SysAdminUnit:Id:SysRole].Id"
					},
					defaultValues: {
						ConnectionType: {
							masterColumn: "ConnectionType"
						},
						IsParentRoleExist: {
							masterColumn: "IsParentRoleExist"
						}
					}
				},
				SysAdminUnitIPRangeDetailV2: {
					schemaName: "SysAdminUnitIPRangeDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysAdminUnit"
					}
				},
				SysFuncRoleInOrgRoleDetailV2: {
					schemaName: "SysFuncRoleInOrgRoleDetailV2",
					filter: {
						masterColumn: "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"name": "UsersTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.UsersTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "UsersTab",
					"propertyName": "items",
					"name": "UsersDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "remove",
					"name": "ESNTab"
				}
			]/**SCHEMA_DIFF*/,
			attributes: {

				/**
				 * ####### ####, ### ############ #### ##########.
				 */
				"IsParentRoleExist": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * ######## ######## ###### ## ####### ###### #### # ############ ### ############# ########.
				 */
				"SecurityOperationName": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "CanManageUsers"
				},

				/**
				 * ######## #### ConnectionType ######, ####### ######## ######### ##
				 * ######### # #######.
				 */
				"ParentRoleConnectionType": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseModulePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					if (this.isAddMode()) {
						var result = this.sandbox.publish("SetRecordInformation", {},
							[this.sandbox.id]);
						this.set("ParentRole", {value: result.parent});
						this.set("SysAdminUnitType", {value: result.type});
						this.set("ParentRoleConnectionType", result.connectionType);
						this.set("ConnectionType", result.connectionType);
					}
					var deleteButtonEnable = this.checkOpportunityForDelete();
					this.set("DeleteButtonEnable", deleteButtonEnable);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					var parentRole = this.get("ParentRole");
					this.set("IsParentRoleExist", !this.Ext.isEmpty(parentRole));
				},

				/**
				 * ######### ######## ## #######. #### ######## ### ########## ##### ######### ########## ######,
				 * ##### - ########## ##### ########.
				 * @param {Function} callback #######, ####### ##### ####### ### ######### ###### ## #######
				 * @param {Object} scope ########, # ####### ##### ####### ####### callback
				 * @inheritDoc BPMSoft.BaseViewModel#saveEntity
				 * @overridden
				 */
				saveEntity: function(callback, scope) {
					var changedColumns = {};
					var systemColumns = ["CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy"];
					this.BPMSoft.each(this.entitySchema.columns,
						function(column) {
							if (this.changedValues.hasOwnProperty(column.name) && systemColumns.indexOf(column.name) < 0) {
								var columnValue = this.get(column.name);
								changedColumns[column.name] =  this.Ext.isEmpty(columnValue) ?
									null:
									columnValue.value || columnValue;
							}
						}, this);
					if (this.BPMSoft.isEmptyObject(changedColumns)) {
						this.cardSaveResponse = {success: true};
						callback.call(scope || this, {success: true});
					} else {
						if (this.Ext.isEmpty(changedColumns.Id)) {
							changedColumns.Id = this.get("Id");
						}
						if (this.Ext.isEmpty(changedColumns.SysAdminUnitType)) {
							changedColumns.SysAdminUnitType = this.get("SysAdminUnitType").value;
						}
						if (this.isAddMode()) {
							changedColumns.ConnectionType = this.get("ConnectionType");
						}
						var dataSend = {
							jsonObject: this.Ext.encode(changedColumns)
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: "SaveRole",
							data: dataSend
						};
						this.callService(config, this.onSaveRoleResponse.bind(scope, callback), this);
					}
				},

				/**
				 * ######### ########### ######## ####### ###### (###### ## ######## ###### "#######" # #### ######
				 * "########").
				 * @return {boolean} ########## true, #### ##### ####### ###### ########.
				 */
				checkOpportunityForDelete: function() {
					var id = this.get("Id");
					if (this.Ext.isEmpty(id)) {
						return false;
					}
					var parent = this.get("ParentRole");
					return !this.Ext.isEmpty(parent) && id !== ConfigurationConstants.SysAdminUnit.Id.SysAdministrators;
				},

				/**
				 * ######## ########## ###### ## ####### # ######## ########## ####### ######### ######.
				 * @private
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} response ##### ## #######.
				 */
				onSaveRoleResponse: function(callback, response) {
					this.validateSaveRoleResponse(response);
					callback.call(this, response);
				},

				/**
				 * ######### ######### ###### ## #######.
				 * @private
				 * @param {Object} response ##### ## #######.
				 */
				validateSaveRoleResponse: function(response) {
					if (response && response.SaveRoleResult) {
						var result = this.Ext.decode(response.SaveRoleResult);
						response.success = result.success;
						if (result.success) {
							response.id = result.roleId;
							response.rowsAffected = 1;
							response.nextPrcElReady = false;
							this.isNew = false;
							this.changedValues = null;
						} else {
							this.showInformationDialog(result.message);
						}
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseViewModel#onSilentSaved
				 * @overridden
				 */
				onSilentSaved: function() {
					this.callParent(arguments);
					var deleteButtonEnable = this.checkOpportunityForDelete();
					this.set("DeleteButtonEnable", deleteButtonEnable);
				},

				/**
				 * ######### ######## ########### ######## ####### ######. #### ######## ######### ########,
				 * ## ######## #######, ####### ## SysAdminUnitSectionV2 ############## ####### ######## ######
				 * #######.
				 */
				canRemoveRecord: function() {
					var dataSend = {
						parentRoleId: this.get("Id")
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetChildAdminUnitsAndUsersCount",
						data: dataSend
					};
					this.callService(config, this.onGetChildAdminUnitsAndUsersCountResponse, this);
				},

				/**
				 * ############ ###### # GetChildAdminUnitsAndUsersCount # ########## ##### ## ######### ########
				 * ###### ### ######## ######### ############ # ############# ########.
				 * @param response {Object} ######, ########## ########.
				 */
				onGetChildAdminUnitsAndUsersCountResponse: function(response) {
					if (response && response.GetChildAdminUnitsAndUsersCountResult) {
						var result = {};
						response.GetChildAdminUnitsAndUsersCountResult.forEach(function(item) {
							result[item.Key] = item.Value;
						});
						if (result.userCount === 0) {
							this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
								function(returnCode) {
									if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
										if (this.get("IsInChain")) {
											this.onCloseClick();
										}
										this.sandbox.publish("RemoveRecordAndGoToParent", {
												deletedItems: result.deletedItems,
												parent: this.get("ParentRole").value,
												IsConfirmedDelete: true
											},
											[this.sandbox.id]);
									}
								},
								[
									this.BPMSoft.MessageBoxButtons.YES.returnCode,
									this.BPMSoft.MessageBoxButtons.NO.returnCode
								],
								null);

						} else {
							this.showInformationDialog(this.get("Resources.Strings.DeletionErrorMessage"));
						}
						this.set("ServiceDataLoaded", true);
					}
				},

				/**
				 * #### # ###### ######### ###### ######## #### ###### ### ######## ## #####, ## ####### ## ## ######.
				 * @param {Object} actionMenuItems ###### ######### ###### ########.
				 * @protected
				 */
				removeSubscribeButton: function(actionMenuItems) {
					var subscribeButtonIndex;
					actionMenuItems.each(function(item, index) {
						if (item.values.Tag === "subscribeUser") {
							subscribeButtonIndex = index;
						}
					});
					if (subscribeButtonIndex) {
						actionMenuItems.removeByIndex(subscribeButtonIndex);
					}
				},

				/**
				 * @inheritdoc BaseModulePageV2#getActions
				 * @overridden
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					this.removeSubscribeButton(actionMenuItems);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.RemoveButtonCaption"},
						"Enabled": { "bindTo": "DeleteButtonEnable" },
						"Tag": "canRemoveRecord"
					}));
					return actionMenuItems;
				}
			},
			messages: {

				/**
				 * ######## ########## # ######## # #### ### ######.
				 */
				"SetRecordInformation": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######## # ############# ####### ######## ## ####### # ####### # ############# ########.
				 */
				"RemoveRecordAndGoToParent": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			}
		};
	});
