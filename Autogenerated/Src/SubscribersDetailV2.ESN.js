define("SubscribersDetailV2", ["BPMSoft", "LookupUtilities", "ServiceHelper", "ConfigurationEnums",
		"PortalRoleFilterUtilities"],
	function(BPMSoft, LookupUtilities, ServiceHelper, configurationEnums, PortalRoleFilterUtilities) {
		return {
			entitySchemaName: "SocialSubscription",
			messages: {
				/**
				 * @message GetMasterRecordEntitySchemaUId
				 * ######## ############# ######## ########.
				 */
				"GetMasterRecordEntitySchemaUId": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetMasterRecordEntitySchemaUId
				 * ######### ######## "IsSubscribed" - ######### ###### "###########" / "##########" ## ########.
				 */
				"UpdateIsSubscribed": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {},
			methods: {

				/**
				 * ######## ############# ######## ########.
				 * @return {string} ############# ######## ########.
				 */
				getMasterRecordEntitySchemaUId: function() {
					return this.sandbox.publish("GetMasterRecordEntitySchemaUId", null, [this.sandbox.id]);
				},

				/**
				 * ######### ######## "IsSubscribed" - ######### ###### "###########" / "##########" ## ######## ######.
				 */
				updateSocialChannelPage: function() {
					return this.sandbox.publish("UpdateIsSubscribed", null, [this.sandbox.id]);
				},

				/**
				 * ########## ####### ####### ###### "######### #######".
				 */
				allowUnsubscribe: function() {
					this.sendAllowDenyRequest(true);
				},

				/**
				 * ########## ####### ####### ###### "######### #######".
				 */
				denyUnsubscribe: function() {
					this.sendAllowDenyRequest(false);
				},

				/**
				 * ########## ###### ##########/####### ####### ## ######.
				 * @param {boolean} canUnsubscribe #######, ####### ############# ########## ## #######.
				 * @private
				 */
				sendAllowDenyRequest: function(canUnsubscribe) {
					var channelId = this.get("MasterRecordId");
					var selectedRows = this.getSelectedItems();
					this.callService({
						serviceName: "SocialSubscriptionService",
						methodName: "ChangeCanUnsubscribe",
						data: {
							socialSubscriptionIds: selectedRows,
							channelId: channelId,
							canUnsubscribe: canUnsubscribe
						}
					}, this.updateSubscribersDetail, this);
				},

				/**
				 * ######### ###### ######## ######## ####### #############.
				 * @param {Function} callback
				 * @param {Object} scope
				 * @protected
				 */
				deleteSubscription: function(callback, scope) {
					var channelId = scope.get("MasterRecordId");
					var selectedRows = scope.getSelectedItems();
					scope.callService({
						serviceName: "SocialSubscriptionService",
						methodName: "DeleteSubscription",
						data: {socialSubscriptionIds: selectedRows, channelId: channelId}
					}, callback, scope);
				},

				/**
				 * ########## ######### ###### "######### #######".
				 * @returns {boolean}
				 */
				hasAllowPermissionsToUnsubscribe: function() {
					var enabled = false;
					var selectedItems = this.getSelectedItems();
					var gridData = this.getGridData();
					if (selectedItems && selectedItems.length === 1) {
						var record = gridData.get(selectedItems[0]);
						if (record.get("CanUnsubscribe")) {
							return true;
						}
					} else if (selectedItems && selectedItems.length > 1) {
						enabled = true;
						BPMSoft.each(selectedItems, function(item) {
							var record = gridData.get(item);
							if (record.get("CanUnsubscribe")) {
								enabled = true;
								return false;
							} else {
								enabled = false;
							}
						}, this);
					}
					return enabled;
				},

				/**
				 * ########## ######### ###### "######### #######".
				 * @returns {boolean}
				 */
				hasDenyPermissionsToUnsubscribe: function() {
					var enabled = false;
					var selectedItems = this.getSelectedItems();
					var gridData = this.getGridData();
					if (selectedItems && selectedItems.length === 1) {
						return !this.hasAllowPermissionsToUnsubscribe();
					} else if (selectedItems && selectedItems.length > 1) {
						BPMSoft.each(selectedItems, function(item) {
							var record = gridData.get(item);
							if (!record.get("CanUnsubscribe")) {
								enabled = true;
								return false;
							} else {
								enabled = false;
							}
						}, this);
					}
					return enabled;
				},

				/**
				 * ######## #######, ####### ###### ########## ########.
				 * @protected
				 * @overridden
				 * @return {Object} ########## #######, ####### ###### ########## ########.
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					if (!gridDataColumns.SysAdminUnit) {
						gridDataColumns.SysAdminUnit = {
							path: "SysAdminUnit",
							orderPosition: 0,
							orderDirection: BPMSoft.OrderDirection.ASC
						};
					}
					return gridDataColumns;
				},

				/**
				 * ############# ############ ######### ######### ### #######.
				 * @protected
				 * @param collection
				 * @returns {*}
				 */
				prepareResponseCollection: function(collection) {
					this.callParent(arguments);
					collection.each(function(item) {
						var contact = item.get("SysAdminUnit.Contact.Name");
						if (Ext.isEmpty(contact)) {
							var sysAdminUnit = item.get("SysAdminUnit");
							item.set("SysAdminUnit.Contact.Name", sysAdminUnit.displayValue);
						}
					});
				},

				/**
				 * ########### ############ ### ###### ############# ## ####### #####.
				 * @param {String} methodName ### ###### ########### ##### ## ###### ####
				 */
				onAddUsers: function(methodName) {
					var sandbox = this.sandbox;
					var sandboxId = sandbox.id;
					var masterCardState = sandbox.publish("GetCardState", null, [sandboxId]);
					var state = masterCardState.state;
					var isNewRecord = (state === configurationEnums.CardStateV2.ADD ||
						state === configurationEnums.CardStateV2.COPY);
					if (!isNewRecord) {
						this[methodName]();
					} else {
						var args = {
							isSilent: true,
							messageTags: [sandboxId]
						};
						this.set("AddUserMethodName", methodName);
						sandbox.publish("SaveRecord", args, [sandboxId]);
					}
				},

				/**
				 * ########## ############ # ###### ###########.
				 * @param {Object} cardResponse ##### ######## ##############. ########## ### ########## ##### ######.
				 */
				addUser: function(cardResponse) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SocialSubscription"
					});
					var contactIdColumn = esq.addColumn("SysAdminUnit.Contact.Id");
					esq.filters.addItem(this.get("Filter"));
					esq.filters.addItem(this.BPMSoft.createColumnIsNotNullFilter("SysAdminUnit.Contact"));
					esq.getEntityCollection(function(result) {
						var contactIdCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								var contactId = item.get(contactIdColumn.columnPath);
								contactIdCollection.push(contactId);
							});
						}
						if (cardResponse) {
							contactIdCollection.push(this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value);
							this.updateSubscribersDetail({});
						}
						var filters = this.Ext.create("BPMSoft.FilterGroup");
						var config = {
							entitySchemaName: "Contact",
							multiSelect: true,
							hideActions: true,
							columns: ["Name"],
							filters: filters
						};
						filters.addItem(this.BPMSoft.createColumnIsNotNullFilter("[SysAdminUnit:Contact].Id"));
						if (contactIdCollection.length > 0) {
							var existsFilter =
								this.BPMSoft.createColumnInFilterWithParameters("Id", contactIdCollection);
							existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
							filters.addItem(existsFilter);
						}
						LookupUtilities.Open(this.sandbox, config, this.onAddUserComplete, this, null, false, false);
					}, this);
				},

				/**
				 * ########## ###### ############# # ###### ###########.
				 * @param {Object} cardResponse ##### ######## ##############. ########## ### ########## ##### ######.
				 */
				addUserGroup: function(cardResponse) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SocialSubscription"
					});
					var sysAdminUnitIdColumn = esq.addColumn("SysAdminUnit.Id");
					esq.filters.addItem(this.get("Filter"));
					esq.filters.addItem(this.BPMSoft.createColumnIsNullFilter("SysAdminUnit.Contact"));
					esq.getEntityCollection(function(result) {
						var sysAdminUnitIdCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								var sysAdminUnitId = item.get(sysAdminUnitIdColumn.columnPath);
								sysAdminUnitIdCollection.push(sysAdminUnitId);
							});
						}
						if (cardResponse) {
							this.updateSubscribersDetail({});
						}
						var filters = this.Ext.create("BPMSoft.FilterGroup");
						var config = {
							entitySchemaName: "SysAdminUnit",
							multiSelect: true,
							hideActions: true,
							columns: ["Name"],
							filters: filters
						};
						filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contact"));
						if (sysAdminUnitIdCollection.length > 0) {
							var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id",
								sysAdminUnitIdCollection);
							existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
							filters.addItem(existsFilter);
						}
						var activeSysAdminUnitFilter = PortalRoleFilterUtilities.getSysAdminUnitFilterGroup([]);
						filters.add(activeSysAdminUnitFilter);
						LookupUtilities.Open(this.sandbox, config, this.onAddUserGroupComplete, this, null, false,
							false);
					}, this);
				},

				/**
				 * #### ######### ########## ############ # ###### ###########.
				 * @param {Object} users ##### #########.
				 */
				onAddUserComplete: function(users) {
					if (users.selectedRows.getCount() > 0) {
						var usersToSubscribe = users.selectedRows.getKeys();
						this.subscribeUsers(usersToSubscribe, false);
					}
				},

				/**
				 * #### ######### ########## ###### ############# # ###### ###########.
				 * @param users ##### ##########.
				 */
				onAddUserGroupComplete: function(users) {
					if (users.selectedRows.getCount() > 0) {
						var usersToSubscribe = users.selectedRows.getKeys();
						this.subscribeUsers(usersToSubscribe, true);
					}
				},

				/**
				 * ########### #############, ###### ############# ## #####.
				 * @param {Array} primaryColumnValues ############## #########, ############## ##### #############.
				 * @param {Boolean} subscribeGroup #######, ########### ########### ## ## ###### #############.
				 */
				subscribeUsers: function(primaryColumnValues, subscribeGroup) {
					var serviceMethodName;
					var entityId = this.get("MasterRecordId");
					var entitySchemaUId = this.getMasterRecordEntitySchemaUId();
					var config = {
						entityId: entityId,
						entitySchemaUId: entitySchemaUId
					};
					if (subscribeGroup) {
						config.sysAdminUnitIds = primaryColumnValues;
						serviceMethodName = "SubscribeUserGroups";
					} else {
						config.contactIds = primaryColumnValues;
						serviceMethodName = "SubscribeUsers";
					}
					ServiceHelper.callService("SocialSubscriptionService", serviceMethodName,
						function(response) {
							var result = response[serviceMethodName + "Result"];
							if (result) {
								this.showInformationDialog(result);
							} else {
								this.updateDetail({reloadAll: true});
								this.updateSocialChannelPage();
							}
						}, config, this);
				},

				/**
				 * ########## ############# ## ######.
				 * @param {Array} socialSubscriptionIds ############## ####### ####### "########".
				 * @param {Function} callback
				 * @param {Object} scope
				 */
				unsubscribeUsers: function(socialSubscriptionIds, callback, scope) {
					this.callService({
						serviceName: "SocialSubscriptionService",
						methodName: "UnsubscribeUsers",
						data: {socialSubscriptionIds: socialSubscriptionIds}
					}, function(response) {
						var result = response.UnsubscribeUsersResult;
						callback.call(this, result);
					}, scope);
				},

				/**
				 * ######### ###### ## ########.
				 */
				updateSubscribersDetail: function(response) {
					var result = response.ChangeCanUnsubscribeResult;
					if (result) {
						this.showInformationDialog(result);
					} else {
						this.updateDetail({reloadAll: true});
						this.updateSocialChannelPage();
					}
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#deleteRecords
				 * @overridden
				 */
				deleteRecords: function() {
					var items = this.getSelectedItems();
					if (!items || !items.length) {
						this.callParent(arguments);
					}
					this.deleteSubscription(function(response) {
						var result = response.DeleteSubscriptionResult;
						if (result) {
							this.showInformationDialog(this.get("Resources.Strings.RightLevelWarningMessage"));
							return;
						}
						this.updateDetail({reloadAll: true});
						this.updateSocialChannelPage();
					}, this);
				},

				/**
				 * ######### ######## ######## "########### ###### ########".
				 * @param {Array} socialSubscriptionIds ############## ####### ####### "########".
				 * @param {Function} callback
				 * @param {Object} scope
				 */
				checkCanUnsubscribe: function(socialSubscriptionIds, callback, scope) {
					this.callService({
						serviceName: "SocialSubscriptionService",
						methodName: "CheckCanUnsubscribe",
						data: {socialSubscriptionIds: socialSubscriptionIds}
					}, function(response) {
						var result = response.CheckCanUnsubscribeResult;
						callback.call(this, result);
					}, scope);
				},

				/**
				 * ######## ##### ########## ############# ##### ########## ######.
				 * @protected
				 * @overridden
				 * @param {Object} cardResponse ######### ########## ########## ########.
				 */
				onCardSaved: function(cardResponse) {
					var methodName = this.get("AddUserMethodName");
					if (methodName) {
						this.set("AddUserMethodName", null);
						this[methodName](cardResponse);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					toolsButtonMenu.addItem(this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.AllowUnsubscribeCaption"},
						Click: {"bindTo": "allowUnsubscribe"},
						Enabled: {bindTo: "hasDenyPermissionsToUnsubscribe"}
					}));
					toolsButtonMenu.addItem(this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.DenyUnsubscribeCaption"},
						Click: {"bindTo": "denyUnsubscribe"},
						Enabled: {bindTo: "hasAllowPermissionsToUnsubscribe"}
					}));
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * ########## ### ####### ### ########## ## #########.
				 * @overridden
				 * @return {String} ### #######.
				 */
				getFilterDefaultColumnName: function() {
					return "SysAdminUnit";
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"primaryDisplayColumnName": "SysAdminUnit.Contact.Name",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "ContactNameListedGridColumn",
									"bindTo": "SysAdminUnit",
									"position": {
										"column": 0,
										"colSpan": 6
									},
									"type": BPMSoft.GridCellType.TITLE
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 2
							},
							"items": [
								{
									"name": "ContactNameTiledGridColumn",
									"bindTo": "SysAdminUnit",
									"position": {
										"row": 0,
										"column": 0,
										"colSpan": 11
									},
									"type": BPMSoft.GridCellType.TITLE
								}
							]
						}
					}
				},
				{
					"operation": "merge",
					"name": "AddTypedRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"controlConfig": {
							"menu": {
								"items": [{
									"caption": {bindTo: "Resources.Strings.AddUserCaption"},
									"click": {bindTo: "onAddUsers"},
									"tag": "addUser"
								}, {
									"caption": {bindTo: "Resources.Strings.AddUserGroupCaption"},
									"click": {"bindTo": "onAddUsers"},
									"tag": "addUserGroup"
								}]
							}
						},
						"visible": {"bindTo": "getToolsVisible"},
						"enabled": true
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
