define("SysAdminUnitPageV2", ["SysAdminUnitPageV2Resources", "ConfigurationConstants", "css!AdministrationCSSV2"],
		function() {
	return {
		details: /**SCHEMA_DETAILS*/{
			ChiefsDetailV2: {
				schemaName: "ChiefsDetailV2",
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
			SysFuncRoleInOrgRoleDetailV2: {
				filter: {
					detailColumn: "OrgRole"
				}
			},
			SysAdminUnitChiefIPRangeDetailV2: {
				schemaName: "SysAdminUnitChiefIPRangeDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "SysAdminUnit"
				}
			},
			SysFuncRoleChiefInOrgRoleDetailV2: {
				schemaName: "SysFuncRoleChiefInOrgRoleDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "OrgRole"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "ViewOptionsButton"
			},
			{
				"operation": "remove",
				"name": "PrintButton"
			},
			{
				"operation": "insert",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1,
				"name": "ChiefsTab",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ChiefsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ChiefsTab",
				"name": "ChiefsControlGroup",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ChiefsControlGroup",
				"propertyName": "items",
				"name": "ChiefExist",
				"values": {
					"bindTo": "IsChiefRoleExist",
					"contentType": this.BPMSoft.ContentType.BOOLEAN,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 10
					},
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.ExistChiefsRoleCaption"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "GroupName",
				"parentName": "ChiefsControlGroup",
				"propertyName": "items",
				"values": {
					"visible": true,
					"enabled": {"bindTo": "IsGroupNameEnable"},
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"caption": {"bindTo": "Resources.Strings.NameChiefRolesCaption"},
					"value": {"bindTo": "GroupName"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ChiefsTab",
				"propertyName": "items",
				"name": "ChiefsDetailV2",
				"values": {"itemType": this.BPMSoft.ViewItemType.DETAIL}
			},
			{
				"operation": "insert",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 2,
				"name": "FuncRolesTab",
				"values": {
					"caption": {"bindTo": "Resources.Strings.RolesTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "FuncRolesTab",
				"propertyName": "items",
				"name": "SysFuncRoleInOrgRoleDetailV2",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "FuncRolesTab",
				"propertyName": "items",
				"name": "SysFuncRoleChiefInOrgRoleDetailV2",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 3,
				"name": "IPRangeTab",
				"values": {
					"caption": {"bindTo": "Resources.Strings.IPRangeTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "IPRangeTab",
				"propertyName": "items",
				"name": "SysAdminUnitIPRangeDetailV2",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "IPRangeTab",
				"propertyName": "items",
				"name": "SysAdminUnitChiefIPRangeDetailV2",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"name": "SessionSettingsGroup",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": {
						"bindTo": "Resources.Strings.SessionGroupCaption"
					}
				},
				"parentName": "IPRangeTab",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "SessionTimeout",
				"parentName": "SessionSettingsGroup",
				"propertyName": "items",
				"values": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"caption": {
						"bindTo": "Resources.Strings.SessionTimeoutTitle"
					},
					"value": {"bindTo": "SessionTimeout"}
				}
			}
		]/**SCHEMA_DIFF*/,
		attributes: {
			/**
			 * ####, ############ ####### #### ############# ### ####### ############### ####.
			 */
			"IsChiefRoleExist": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				dependencies: [
					{
						columns: ["IsChiefRoleExist"],
						methodName: "onIsChiefRoleExistChange"
					}
				]
			},
			/**
			 * ####, ############ ### ########### ####, ### ######## ######### IsChiefRoleExist, #### true - ##
			 * ############, #### false - ########### #########.
			 */
			"IsUserClickCheckbox": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
			},
			"GroupName": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * ####, ############ ##### ## ######## ### ############## #### # ######### ###### #############.
			 */
			"IsGroupNameEnable": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN}
		},
		methods: {
			/**
			 * @inheritdoc BasePageV2#reloadEntity
			 * @overridden
			 */
			reloadEntity: function() {
				this.set("IsUserClickCheckbox", false);
				this.set("IsChiefRoleExist", null);
				this.callParent(arguments);
			},

			/**
			 * ############ ####### ######### ######### checkbox, ########### ## ########/######## ####
			 * ############. ########### ## IsUserClickCheckbox ##########, ### ######## ######### #########
			 * ########, #### true - ## ############, # ######### ###### ######### ############# ######## #
			 * ######### #####-#### ######## ## #####.
			 * @protected
			 */
			onIsChiefRoleExistChange: function() {
				if (!this.get("IsUserClickCheckbox")) {
					this.set("IsUserClickCheckbox", true);
					return;
				}
				if (this.isNewMode()) {
					this.save({
						isSilent: true,
						callback: this.updateChiefDetail,
						callBaseSilentSavedActions: true
					});
					return;
				}
				if (this.get("IsChiefRoleExist")) {
					this.addChiefsRole();
				} else {
					this.checkCanRemoveChiefsRole();
				}
			},

			/**
			 * ######### ########## ###### ############# ##### ####, ### #### ######### ##### ############### ####.
			 * @protected
			 */
			updateChiefDetail: function() {
				this.sandbox.publish("UpdateChiefDetail", null, [this.getDetailId("ChiefsDetailV2")]);
			},

			/**
			 * ######### ######### # ####### ### ######### ########## ############# # ####### ###### #############.
			 * @protected
			 */
			checkCanRemoveChiefsRole: function() {
				var chiefData = this.get("ChiefData");
				var dataSend = {
					roleId: chiefData.Id
				};
				var config = {
					serviceName: "AdministrationService",
					methodName: "GetUsersCount",
					data: dataSend
				};
				this.callService(config, this.onCheckCanRemoveChiefsRoleResponse, this);
			},

			/**
			 * ############ ######### ####### ### ######### ########## ############# # ####### ######. #### #
			 * ###### #### ############, ## ## ####### ######### # ############# ####### ###### # ########## #
			 * ########### ######### checkbox. #### ## # ###### ############# ### #############, ## #########
			 * ##### ########### #### ### ############# ########.
			 * @param {Object} response ##### ## #######.
			 * @protected
			 */
			onCheckCanRemoveChiefsRoleResponse: function(response) {
				if (response && !this.Ext.isEmpty(response.GetUsersCountResult)) {
					if (response.GetUsersCountResult === 0) {
						this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
							this.handleDialogResponse,
							[
								this.BPMSoft.MessageBoxButtons.YES.returnCode,
								this.BPMSoft.MessageBoxButtons.NO.returnCode
							],
							null);

					} else {
						this.showInformationDialog(this.get("Resources.Strings.DeletionErrorMessage"));
						this.setCheckboxState(true);
					}
					this.set("ServiceDataLoaded", true);
				}
			},

			/**
			 * ############ ##### ############ # ########## #### ### ############# ######## ###### #############.
			 * #### ############ ########## ########, ## ######### ########, #### ### - ## ########## checkbox #
			 * ######### 'checked'.
			 * @param {String} returnCode Tag ######, ####### ###### ############.
			 * @protected
			 */
			handleDialogResponse: function(returnCode) {
				if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.removeChiefsRole();
				} else {
					this.setCheckboxState(true);
				}
			},

			/**
			 * ############# ######## ### ######## IsChiefRoleExist ###, ##### ### ######### ######### #########
			 * ## ########### ##########/######## ###### #############.
			 * @param {Boolean} value ########, ####### ##### ########### # ####### IsChiefRoleExist.
			 * @protected
			 */
			setCheckboxState: function(value) {
				if (this.get("IsChiefRoleExist") !== value) {
					this.set("IsUserClickCheckbox", false);
					this.set("IsChiefRoleExist", value);
				}
			},

			/**
			 * ####### ####### ###### #############.
			 * @protected
			 */
			removeChiefsRole: function() {
				var chiefData = this.get("ChiefData");
				this.callService({
					serviceName: "GridUtilitiesService",
					methodName: "DeleteRecords",
					data: {
						primaryColumnValues: [chiefData.Id],
						rootSchema: this.entitySchema.name
					}
				}, this.onRemoveChiefsRole, this);
			},

			/**
			 * ######### ######### ###### ####### ##### ######## ######.
			 * @param {Object} responseObject ##### #######.
			 * @protected
			 */
			onRemoveChiefsRole: function(responseObject) {
				var result = this.Ext.decode(responseObject.DeleteRecordsResult);
				var success = result.Success;
				this.hideBodyMask();
				if (!success) {
					this.showInformationDialog(this.get("Resources.Strings.DependencyWarningMessage"));
				}
				this.publishUpdateChiefDetailAndSave();
			},

			/**
			 * ######### ########## #### ############ ### ####### ############### ####.
			 * @protected
			 */
			addChiefsRole: function() {
				var dataSend = {
					id: this.get("Id"),
					name: this.get("Name")
				};
				var config = {
					serviceName: "AdministrationService",
					methodName: "SaveChiefsRole",
					data: dataSend
				};
				this.callService(config, this.onAddChiefsRole, this);
			},

			/**
			 * ############ ##### ####### ##### ########## ###### #############.
			 * @param {Object} response ##### ## #######.
			 * @protected
			 */
			onAddChiefsRole: function(response) {
				response = this.Ext.decode(response.SaveChiefsRoleResult);
				this.validateServiceResponse(response, response.message, this.publishUpdateChiefDetailAndSave,
					this);
			},

			/**
			 * ######### ####### ### ####, ##### ######## ###### ### ###### ############# # ######### ########.
			 * @protected
			 */
			publishUpdateChiefDetailAndSave: function() {
				this.updateChiefDetail();
				this.save({isSilent: true});
			},

			/**
			 * @inheritdoc SysAdminUnitRoleBasePageV2#saveEntity
			 * @overridden
			 */
			saveEntity: function() {
				if (this.changedValues.GroupName) {
					this.onGroupNameChange();
				}
				this.callParent(arguments);
			},

			/**
			 * ######### ##### ####### # ######### ############ # ###### ####### ######.
			 * @protected
			 * @param {string} response ############ ##### #######.
			 * @param {string} message ######### # ###### ######.
			 * @param {Function} callback ####### ######### ###### # ###### ########## #######.
			 * @param {Object} scope  ######## ####### ######### ######.
			 */
			validateServiceResponse: function(response, message, callback, scope) {
				this.hideBodyMask();
				if (response.success) {
					callback.call(scope);
				} else {
					this.showInformationDialog(message);
				}
			},

			/**
			 * ############ ######### ######## ##### ############# #############. ######### ########## #####
			 * # ####.
			 * @protected
			 */
			onGroupNameChange: function() {
				var chiefData = this.get("ChiefData");
				if (chiefData) {
					chiefData.Name = this.get("GroupName");
					var dataSend = {
						jsonObject: this.Ext.encode(chiefData)
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "SaveRole",
						data: dataSend
					};
					this.callService(config, this.onGroupNameSave, this);
				}
			},

			/**
			 * ############ ######### ########## ###### ##### ### ###### #############. ####### #########, # ######
			 * ## ######### ##########.
			 * @param {Object} response ##### ## #######.
			 */
			onGroupNameSave: function(response) {
				if (response && response.SaveRoleResult) {
					var result = this.Ext.decode(response.SaveRoleResult);
					if (!result.success) {
						this.showInformationDialog(result.message);
					}
				}
			},

			/**
			 * @inheritdoc GridUtilitiesV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.selectChiefsUnits();
			},

			/**
			 * ######### ########## ### #######, ####### ##### ######### ######## # ###### ############# ###
			 * ######## #############.
			 * @protected
			 */
			selectChiefsUnits: function() {
				this.sandbox.subscribe("GetChiefsSysAdminUnits", function(result) {
					this.set("updatedFromDetail", true);
					this.set("ChiefData", result);
					this.set("GroupName", result ? result.Name : "");
					var chiefRoleExist = !this.Ext.isEmpty(result);
					this.setCheckboxState(chiefRoleExist);
					this.set("IsGroupNameEnable", chiefRoleExist);
					delete this.changedValues.GroupName;
				}, this, [this.getDetailId("ChiefsDetailV2")]);
			},

			/**
			 * ########## ######### ########
			 * @protected
			 * @virtual
			 */
			getHeader: function() {
				return this.get("Resources.Strings.HeaderCaption");
			}
		},
		messages: {
			"GetChiefsSysAdminUnits": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"UpdateChiefDetail": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		}
	};
});
