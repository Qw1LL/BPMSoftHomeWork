﻿define("UserPageV2", ["UserPageV2Resources", "BusinessRuleModule", "ConfigurationConstants", "EmailHelper",
		"ViewUtilities", "RightUtilities", "css!AdministrationCSSV2"],
	function(resources, BusinessRuleModule, ConfigurationConstants, EmailHelper, ViewUtilities, RightUtilities) {
		return {
			entitySchemaName: "VwSysAdminUnit",
			messages: {

				/**
				 * @message GetChiefId
				 * ############ ### ######## ############## ####### #### ############.
				 */
				"GetChiefId": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SetRecordInformation
				 * ########## ######, ######### ## ####### ######### # ############ ####### ###### #
				 * #### ########### ######.
				 */
				"SetRecordInformation": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateSectionGrid
				 * ######## ####### # ############# ############# ######, ##### ######## ########.
				 * ############## ####### #######
				 */
				"UpdateSectionGrid": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				"UnblockUser": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"DeleteUser": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"UserDeletedSuccessfully": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				"SetIsUserBlocked": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			details: /**SCHEMA_DETAILS*/{
				SysAdminUnitIPRangeDetailV2: {
					schemaName: "SysAdminUnitIPRangeDetailV2",
					filter: {
						masterColumn: "Id"
					}
				},
				SessionDetailV2: {
					schemaName: "SessionDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysUser"
					}
				},
				SysFuncRoleInUserDetailV2: {
					schemaName: "SysFuncRoleInUserDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysUser"
					}
				},
				SysOrgRoleInUserDetailV2: {
					schemaName: "SysOrgRoleInUserDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysUser"
					}
				},
				SysAdminUnitGrantedRightDetailV2: {
					schemaName: "SysAdminUnitGrantedRightDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "GrantorSysAdminUnit"
					},
					filterMethod: "getSysAdminUnitGrantedRightDetailV2Filters"
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "CardContentContainer",
					"values": {
						"wrapClass": ["UserPageV2", "center-main-container"]
					}
				},
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "actions"
				},
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "insert",
					"name": "DeleteButton",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.DeleteButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "onDeleteClick"}
					}
				},
				{
					"operation": "insert",
					"parentName": "CardContentWrapper",
					"propertyName": "items",
					"name": "UserUnblockButtonContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "IsUserBlocked"},
						"wrapClass": ["blocked-user-container"],
						"items":[]
					}
				},
				{
					"operation": "insert",
					"parentName": "UserUnblockButtonContainer",
					"propertyName": "items",
					"name": "UserUnblockButtonLeftSectionContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["blocked-user-left-container"],
						"visible": {"bindTo": "IsUserBlocked"},
						"items":[]
					}
				},
				{
					"operation": "insert",
					"parentName": "UserUnblockButtonLeftSectionContainer",
					"propertyName": "items",
					"name":"UserUnblockButtonLeftSectionInfoImage",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.InfoBlockedUser"},
						"visible": {"bindTo": "IsUserBlocked"}
					}
				},
				{
					"operation": "insert",
					"parentName": "UserUnblockButtonLeftSectionContainer",
					"propertyName": "items",
					"name":"UserUnblockButtonLeftSectionInfoCaption",
					"values": {
						"caption": {"bindTo": "Resources.Strings.InfoblockedUserButtonCaption"},
						"visible": {"bindTo": "IsUserBlocked"}
					}
				},
				{
					"operation": "insert",
					"parentName": "UserUnblockButtonContainer",
					"propertyName": "items",
					"name": "UserUnblockButtonRightSectionContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "IsUserBlocked"},
						"items":[]
					}
				},
				{
					"operation": "insert",
					"name": "UserUnblockButton",
					"parentName": "UserUnblockButtonRightSectionContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.UnblockUserButtonCaption"},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"click": {"bindTo": "onUnblockClick"},
						"visible": {"bindTo": "IsUserBlocked"},
						"hint": {"bindTo": "Resources.Strings.BlockedUserLabelCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "PhotoContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container"],
						"layout": {"column": 0, "row": 0, "rowSpan": 3, "colSpan": 1},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"name": "Photo",
					"values": {
						"getSrcMethod": "getSrcMethod",
						"onPhotoChange": "onPhotoChange",
						"beforeFileSelected": "beforeFileSelected",
						"readonly": true,
						"defaultImage": {"bindTo": "getUserDefaultImageURL"},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1,
					"name": "RolesTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.RolesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "RolesTab",
					"propertyName": "items",
					"name": "SysOrgRoleInUserDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "RolesTab",
					"propertyName": "items",
					"name": "SysFuncRoleInUserDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2,
					"name": "LicenseTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SysLicUserTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 3,
					"name": "GrantedRightsTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.GrantedRightsTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GrantedRightsTab",
					"propertyName": "items",
					"name": "SysAdminUnitGrantedRightDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4,
					"name": "AccessRulesTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AccessRulesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "AccessRulesTab",
					"propertyName": "items",
					"name": "SysAdminUnitIPRangeDetailV2",
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
					"parentName": "AccessRulesTab",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SessionSettingsGroupContainer",
					"parentName": "SessionSettingsGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SessionTimeout",
					"parentName": "SessionSettingsGroupContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"caption": {
							"bindTo": "Resources.Strings.SessionTimeoutTitle"
						},
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"value": {"bindTo": "SessionTimeout"}
					}
				},
				{
					"operation": "insert",
					"parentName": "AccessRulesTab",
					"propertyName": "items",
					"name": "SessionDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "Contact",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"value": {"bindTo": "Contact"},
						"layout": {"column": 1, "row": 0, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "SysCulture",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.ENUM,
						"value": {"bindTo": "SysCulture"},
						"layout": {"column": 13, "row": 0, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "UserConnectionType",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.ENUM,
						"caption": {"bindTo": "Resources.Strings.TypeCaption"},
						"value": {"bindTo": "UserConnectionType"},
						"enabled": { "bindTo": "ActiveAllPortalUsersGroup" },
						"layout": {"column": 1, "row": 1, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "HomePage",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"value": {"bindTo": "HomePage"},
						"layout": {"column": 1, "row": 2, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "Active",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 1, "row": 3, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "DateTimeFormat",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"value": {"bindTo": "DateTimeFormat"},
						"layout": {"column": 13, "row": 1, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "AuthControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.AuthControlGroupCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "LicenseTab",
					"name": "LicenseControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.SysLicUserTabCaption"},
						"items": [],
						"tools": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "ToolsButton",
					"parentName": "LicenseControlGroup",
					"propertyName": "tools",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.ToolsButtonImage"},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"wrapperClass": ["license-tools-button-wrapper", "license-t-btn-wrapper"],
							"menuClass": ["license-tools-button-menu"]
						},
						"menu": []
					}
				},
				{
					"operation": "insert",
					"name": "CheckAllLicenses",
					"parentName": "ToolsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CheckLicensesCaption"},
						"click": {"bindTo": "onCheckAllLicenses"},
						"enabled": {"bindTo": "Active"}
					}
				},
				{
					"operation": "insert",
					"name": "UncheckAllLicenses",
					"parentName": "ToolsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.UncheckLicensesCaption"},
						"click": {"bindTo": "onUncheckAllLicenses"},
						"enabled": {"bindTo": "Active"}
					}
				},
				{
					"operation": "insert",
					"name": "LicenseList",
					"parentName": "LicenseControlGroup",
					"propertyName": "items",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "LicenseCollection",
						"observableRowNumber": 15,
						"onGetItemConfig": "getItemViewConfig",
						"dataItemIdPrefix": "lic-item"
					}
				},
				{
					"operation": "insert",
					"parentName": "AuthControlGroup",
					"name": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"caption": {"bindTo": "Resources.Strings.UserNameCaption"},
						"value": {"bindTo": "Name"},
						"layout": {"column": 0, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "Email",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"caption": {"bindTo": "Resources.Strings.UserEmailCaption"},
						"value": {"bindTo": "Email"},
						"layout": {"column": 13, "row": 0, "colSpan": 11}
					},
					"dependencies": [
					{
						"columns": ["Email"]
					}]
				},
				{
					"operation": "insert",
					"name": "UserPassword",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"id": "new-password",
						"selectors": {"wrapEl": "#new-password"},
						"caption": {"bindTo": "Resources.Strings.PasswordCaption"},
						"value": {"bindTo": "UserPassword"},
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"controlConfig": {
							"protect": true,
							"keyup": {
								"bindTo": "onNewPasswordKeypress"
							}
						},
						"isRequired": {bindTo: "isRequiredFieldsVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "PasswordConfirmation",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"id": "new-password-confirmation",
						"selectors": {"wrapEl": "#new-password-confirmation"},
						"value": {"bindTo": "PasswordConfirmation"},
						"caption": {"bindTo": "Resources.Strings.PasswordConfirmationCaption"},
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"controlConfig": {
							"protect": true,
							"keyup": {
								"bindTo": "onNewPasswordConfirmationKeypress"
							}
						},
						"isRequired": {bindTo: "isRequiredFieldsVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "PasswordExpireDate",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.DATE,
						"value": {"bindTo": "PasswordExpireDate"},
						"layout": {"column": 0, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "AccountBeginTime",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.DATE_TIME,
						"caption": {"bindTo": "Resources.Strings.AccountBeginTimeCaption"},
						"value": {"bindTo": "AccountBeginTime"},
						"enabled": {"bindTo": "isAccountCanBeExpired"},
						"layout": {"column": 0, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "AccountExpireTime",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.DATE_TIME,
						"caption": {"bindTo": "Resources.Strings.AccountExpireDateCaption"},
						"value": {"bindTo": "AccountExpireTime"},
						"enabled": {"bindTo": "isAccountCanBeExpired"},
						"layout": {"column": 13, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "ForceChangePassword",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 5, "colSpan": 11},
						"styles": {
							"margin": "0 0 24px"
						}
					}
				},
				{
					"operation": "insert",
					"name": "Disable2FA",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 11},
						"visible": {"bindTo": "Enable2FA"},
						"styles": {
							"margin": "0 0 24px"
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				/**
				 * User blocked.
				 */
				"UserUnblockButtonLeftSectionInfoCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.InfoblockedUserButtonCaption
				},
				/**
				 * User password.
				 */
				"UserPassword": {
					dataValueType: this.BPMSoft.DataValueType.TEXT
				},
				/**
				 * Password confirmation.
				 */
				"PasswordConfirmation": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.PasswordConfirmationCaption
				},
				/**
				 * Stores value of system setting "MaxPasswordAge".
				 */
				"PasswordDuration": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Current user contact.
				 */
				"Contact": {
					lookupListConfig: {
						columns: ["Photo"],
						orders: [{columnPath: "Name"}],
						filter: function() {
							var filterGroup = this.BPMSoft.createFilterGroup();
							var notExistsFilter = this.BPMSoft.createNotExistsFilter("[SysAdminUnit:Contact].Id");
							filterGroup.addItem(notExistsFilter);
							return filterGroup;
						}
					},
					isRequired: true
				},
				/**
				 * Home page.
				 */
				"HomePage": {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				/**
				 * Password expire date.
				 */
				"PasswordExpireDate": {
					dependencies: [{
						columns: ["PasswordConfirmation"],
						methodName: "onPasswordConfirmationChanged"
					}]
				},
				/**
				 * User password.
				 */
				"AccountBeginTime": {
					dataValueType: this.BPMSoft.DataValueType.DATE_TIME
				},
				"AccountExpireTime": {
					dataValueType: this.BPMSoft.DataValueType.DATE_TYPE
				},
				/**
				 * User connection type.
				 */
				"UserConnectionType": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							var filterGroup = this.BPMSoft.createFilterGroup();
							filterGroup.add("UserValue",
								BPMSoft.createColumnInFilterWithParameters(
									"Value", [
									ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees,
									ConfigurationConstants.SysAdminUnit.ConnectionType.PortalUsers
								]));
							return filterGroup;
						}
					},
					dependencies: [{
						columns: ["UserConnectionType"],
						methodName: "onUserConnectionTypeChanged"
					}],
					isRequired: true
				},
				/**
				 * Value of connection type.
				 */
				"ConnectionType": {
					dependencies: [{
						columns: ["UserConnectionType"],
						methodName: "setConnectionTypeFromUserConnectionType"
					}]
				},
				/**
				 * User culture.
				 */
				"SysCulture": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					isRequired: true
				},
				/**
				 * Date time format.
				 */
				"DateTimeFormat": {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				/**
				 * License collection.
				 */
				"LicenseCollection": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION
				},
				/**
				 * Determines if user is active.
				 */
				"Active": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * Determines if user has license managing right.
				 */
				"CanManageLicUsers": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Determines if licenses were loaded.
				 */
				"IsLicenseDataLoaded": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Current vertical grid record connectionType.
				 */
				"CurrentFolderConnectionType": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Determines if `All Portal Users` role is active.
				 */
				"ActiveAllPortalUsersGroup": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Previous value of user connection type.
				 */
				"PrevUserConnectionType": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsUserBlocked": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"Enable2FA": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			rules: {
				"Contact": {
					"BindParameterEnabledContact": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"logical": this.BPMSoft.LogicalOperatorType.OR,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Operation"
								},
								"comparisonType": this.BPMSoft.core.enums.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": this.BPMSoft.ConfigurationEnums.CardOperation.ADD
								}
							},
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "CurrentFolderConnectionType"
								},
								"comparisonType": this.BPMSoft.core.enums.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.UserType.SSP
								}
							}
						]
					}
				},
				"PasswordExpireDate": {
					"BindParameterEnabledPasswordExpireDate": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "PasswordDuration"
								},
								"comparisonType": this.BPMSoft.ComparisonType.GREATER,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": 0
								}
							}
						]
					}
				}
			},
			methods: {

				/**
				 * Set ConnectionType from UserConnectionType.
				 */
				setConnectionTypeFromUserConnectionType: function() {
					this.$ConnectionType =
						this.$UserConnectionType.value === ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.AllEmployees
							? ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees
							: ConfigurationConstants.SysAdminUnit.ConnectionType.PortalUsers;
				},

				/**
				 * Return true if previous value of UserConnectionType equals value of UserConnectionType.
				 * @returns {bool} true, if previous value of UserConnectionType equals UserConnectionType,
				 * else - false.
				 */
				isPrevUserConnectionTypeEqualUserConnectionType: function() {
					return this.$UserConnectionType && this.$PrevUserConnectionType &&
						this.$PrevUserConnectionType.value === this.$UserConnectionType.value;
				},

				/**
				 * Raises the onchange event for UserConnectionType.
				 */
				onUserConnectionTypeChanged: function() {
					if (this.isAddMode() || this.isPrevUserConnectionTypeEqualUserConnectionType()) {
						return {};
					}
					this.showConfirmationDialog(this.get("Resources.Strings.ChangeUserConnectionTypeMessage"),
						function(returnCode) {
							if (returnCode === this.BPMSoft.MessageBoxButtons.NO.returnCode) {
								this.setUserConnectionType(this.$PrevUserConnectionType);
								return;
							}
							this.setPrevUserConnectionType();
							this.showBodyMask();
							this.changeUserConnectionType();
						},
						[
							this.BPMSoft.MessageBoxButtons.NO.returnCode,
							this.BPMSoft.MessageBoxButtons.YES.returnCode
						],
						null
					);
				},

				/**
				 * Send query of change UserConnectionType to server.
				 */
				changeUserConnectionType: function() {
					var dataSend = {
						userId: this.$Id,
						connectionType: this.$ConnectionType
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getChangeUserConnectionTypeMethodName(),
						data: dataSend
					};
					this.callService(config, this.onChangeUserConnectionType, this);
				},

				/**
				 * Callback-function on query of changing UserConnectionType.
				 * @param {} response ##### #######.
				 */
				onChangeUserConnectionType: function(response) {
					var result = this.Ext.decode(response[this.getChangeUserConnectionTypeMethodName() + "Result"]);
					response.message = result.ExceptionMessage;
					response.success = result.Success;
					this.reloadEntity();
					this.validateResponse(response);
					this.hideBodyMask();
				},

				/**
				 * Get name of method of changing UserConnectionType.
				 * @returns {string} ######## ######.
				 */
				getChangeUserConnectionTypeMethodName: function() {
					return "ChangeUserConnectionType";
				},

				/**
				 * Filter for detail SysAdminUnitGrantedRightDetailV2.
				 * @protected
				 * @return {BPMSoft.FilterGroup} ########## ###### ########.
				 */
				getSysAdminUnitGrantedRightDetailV2Filters: function() {
					var filters = this.BPMSoft.createFilterGroup();
					filters.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "GrantorSysAdminUnit.Id", this.get("Id")));
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "GranteeSysAdminUnit.Id", this.get("Id")));
					return filters;
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.setUserDefaultValues();
					this.changeColumnCaption("Name", this.get("Resources.Strings.UserNameCaption"));
					this.callParent(arguments);
				},

				/**
				 * ############# ### ####### ##### ######## #########.
				 * @param {String} columnName ######## ####### #######.
				 * @param {String} columnCaption ######### ####### #######.
				 */
				changeColumnCaption: function(columnName, columnCaption) {
					var column = this.getColumnByName(columnName);
					column.caption = columnCaption;
				},

				/**
				 * Set specified value of UserConnectionType.
				 * @protected
				 */
				setUserConnectionType: function(value) {
					value = value || ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.AllEmployees;
					this.$UserConnectionType = value;
				},

				/**
				 * Initialize attributes of activity for `All Portal Users` role.
				 */
				initializeActivityAllPortalUsers: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "SysAdminUnit"});
					esq.addColumn("Active");
					esq.getEntity(ConfigurationConstants.SysAdminUnit.Id.PortalUsers, function(data) {
						if (data && data.success && data.entity) {
							this.$ActiveAllPortalUsersGroup = data.entity.values.Active;
						}
					}, this);
				},

				/**
				 * Return true if connection type equals General.
				 * @returns {bool} true, if connection type equals General else - false.
				 */
				isGeneralConnection: function(connectionType) {
					return connectionType === 0;
				},

				/**
				 * Set UserConnectionType to PrevUserConnectionType.
				 */
				setPrevUserConnectionType: function() {
					this.$PrevUserConnectionType = this.$UserConnectionType;
				},

				/**
				 * ############# ######## ## ######### ### ##### viewModel.
				 * @protected
				 */
				setUserDefaultValues: function() {
					this.$ActiveAllPortalUsersGroup = false;
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "SysAdminUnit"});
					esq.addColumn("Active");
					var currentConnectionType = this.$ConnectionType;
					var connectionType = this.Ext.isEmpty(currentConnectionType)
						? this.$CurrentFolderConnectionType
						: currentConnectionType;
					if (this.isAddMode()) {
						var userConnectionType;
						if (this.isGeneralConnection(connectionType)) {
							userConnectionType = this.createLookupValue(
								ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.AllEmployees,
								this.get("Resources.Strings.OurCompanyUserCaption"));
						}
						else {
							userConnectionType = this.createLookupValue(
								ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.PortalUsers,
								this.get("Resources.Strings.PortalUserCaption"));
						}
						this.setUserConnectionType(userConnectionType);
						this.$SysAdminUnitType = ConfigurationConstants.SysAdminUnit.TypeGuid.User;
					} else {
						var passwordMask = this.get("Resources.Strings.PasswordMask");
						this.set("UserPassword", passwordMask);
						this.set("PasswordConfirmation", passwordMask);
						this.setPrevUserConnectionType();
						this.changedValues = {};
						esq.getEntity(ConfigurationConstants.SysAdminUnit.Id.PortalUsers, function(data) {
							if (data && data.success && data.entity) {
								this.$ActiveAllPortalUsersGroup = data.entity.values.Active;
							}
						}, this);
					}
				},

				/**
				 * Create value of lookup.
				 * @param value Value of lookup.
				 * @param displayValue Display value of lookup.
				 * @returns {{value: *, displayValue: *}} value of lookup.
				 */
				createLookupValue: function(value, displayValue) {
					return {
						value: value,
						displayValue: displayValue
					};
				},

				/**
				 * ####### ####### ######### ######### ##############.
				 * @protected
				 * @param {Object} config ###### ###### ######## ##############.
				 * @return {BPMSoft.BaseViewModel} ####### ######### ######### ##############.
				 */
				getLicenseCollectionItem: function(config) {
					var licText;
					if (config.Type === ConfigurationConstants.SysAdminUnit.SysLicType.Server) {
						licText = this.Ext.String.format(
								this.get("Resources.Strings.ServerLicAvailableCountCaption"), config.UsedCount);
					} else {
						licText = this.Ext.String.format(
								this.get("Resources.Strings.LicAvailableCountCaption"),
								config.AvailableCount, config.PaidCount);
					}
					var collectionItem = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Id: config.Id,
							Name: config.Caption,
							Checked: config.Checked,
							Enabled: config.Enabled,
							AvailableCount: config.AvailableCount,
							PaidCount: config.PaidCount,
							AvailableCountCaption: licText
						}
					});
					collectionItem.sandbox = this.sandbox;
					return collectionItem;
				},

				/**
				 * ########## ######### ######## ######## # ###### ########.
				 * @private
				 */
				onCheckChange: function() {
					if (this.get("IsLicenseDataLoaded")) {
						if (this.get("ModifyAllLicenses")) {
							this.updateButtonsVisibility(true);
							this.set("IsChanged", true, {silent: true});
							this.set("Restored", true, {silent: true});
						} else if (this.isEditMode()) {
							this.save({isSilent: true});
						}
					}
				},

				/**
				 * ######## ### ########.
				 * @protected
				 */
				onCheckAllLicenses: function() {
					this.modifyAllLicenses(true);
				},

				/**
				 * ####### ### ########.
				 * @protected
				 */
				onUncheckAllLicenses: function() {
					this.modifyAllLicenses(false);
				},

				/**
				 * ############### ######### ######### ##############.
				 * @private
				 */
				initCollection: function() {
					var collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					collection.on("itemChanged", this.onCheckChange, this);
					this.set("LicenseCollection", collection);
				},

				/**
				 * ######## ######## ######### ######### LicenseCollection.
				 * @param {Boolean} checked ####### ######.
				 * @param {Boolean=} enabled ####### ########### ######## ##########.
				 */
				modifyAllLicenses: function(checked, enabled) {
					var collection = this.get("LicenseCollection");
					this.set("ModifyAllLicenses", true);
					collection.each(function(model) {
						model.set("Checked", checked);
						if (!this.Ext.isEmpty(enabled)) {
							model.set("Enabled", enabled);
						}
					}, this);
					this.set("ModifyAllLicenses", false);
				},

				/**
				 * ######## ###### ######### ##############, ############## ## #######.
				 * @protected
				 * @param {Function=} callback ####### ######### ######.
				 * @param {Object=} scope ######## ####### ######### ######.
				 */
				getAvailableLicenses: function(callback, scope) {
					var userId = this.isAddMode()
						? this.BPMSoft.GUID_EMPTY
						: (this.get("PrimaryColumnValue") || this.get(this.entitySchema.primaryColumnName));
					var dataSend = {
						userId: userId
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetAvailableLicPackages",
						data: dataSend
					};
					this.set("IsLicenseDataLoaded", false);
					this.showMaskOnLicenses();
					this.callService(config, function(response) {
						this.onGetAvailableLicenses(response, callback, scope);
					}, this);
				},

				/**
				 * ######### ######### ######### ##############.
				 * @protected
				 * @param {Object} response ##### #######.
				 * @param {Function} callback ####### ######### ######.
				 * @param {BPMSoft.BaseViewModel} scope ######## ####### ######### ######.
				 */
				onGetAvailableLicenses: function(response, callback, scope) {
					var collection = this.get("LicenseCollection");
					collection.clear();
					if (response && response.GetAvailableLicPackagesResult) {
						var items = this.Ext.decode(response.GetAvailableLicPackagesResult);
						this.BPMSoft.each(items, function(item) {
							var licenseItem = this.getLicenseCollectionItem(item);
							collection.add(item.Id, licenseItem);
						}, this);
					}
					this.set("IsLicenseDataLoaded", true);
					this.hideMaskOnLicenses();
					if (this.Ext.isFunction(callback)) {
						callback.call(scope);
					}
				},

				/**
				 * ########## ##### ### ###### ########.
				 * @private
				 */
				showMaskOnLicenses: function() {
					var maskConfig = {
						selector: "#LicenseListContainerList",
						timeout: 0
					};
					var elements = this.Ext.select(maskConfig.selector);
					if (elements.item(0)) {
						this.licenseListMaskId = this.BPMSoft.Mask.show(maskConfig);
					}
				},

				/**
				 * ######## ##### ### ###### ########.
				 * @private
				 */
				hideMaskOnLicenses: function() {
					this.BPMSoft.Mask.hide(this.licenseListMaskId);
				},

				/**
				 * @private
				 */
				convertToUtcWithSameDay: function(date) {
					if (!this.Ext.isEmpty(date)) {
						return new Date(
							Date.UTC(
								date.getFullYear(),
								date.getMonth(),
								date.getDate()
							)
						);
					}
					return date;
				},

				/**
				 * @private
				 */
				isAccountCanBeExpired: function () {
					if (this.isAddMode())
						return true;
					let userId = this.get("PrimaryColumnValue") || this.get(this.entitySchema.primaryColumnName);
					const supervisorId = "7f3b869f-34f3-4f20-ab4d-7480a5fdf647",
						sysPortalConnectionIdPostgre = "6c5d02a6-63c7-4487-9e4a-df5249be4d60",
						sysPortalConnectionIdMSSQL = "442d1b69-a495-4398-9c8c-3743871c9326";
					return userId !== supervisorId && userId !== sysPortalConnectionIdPostgre && userId !== sysPortalConnectionIdMSSQL;
				},

				/**
				 * ######### viewConfig ### ######## ###### ######### ##############.
				 * @param {Object} itemConfig viewConfig ######## ##########.
				 * @param {BPMSoft.BaseViewModel} item ####### ###### ######### ##############.
				 */
				getItemViewConfig: function(itemConfig, item) {
					var labelClass = ["license-label"];
					if (!item.get("Enabled")) {
						labelClass.push("disabled-label");
					}
					var config = ViewUtilities.getContainerConfig("license-view");
					var labelConfig = {
						className: "BPMSoft.Label",
						caption: {bindTo: "Name"},
						classes: {labelClass: labelClass},
						inputId: item.get("Id") + "-el"
					};
					var editConfig = {
						className: "BPMSoft.CheckBoxEdit",
						id: item.get("Id"),
						checked: {bindTo: "Checked"},
						enabled: {bindTo: "Enabled"}
					};
					var countConfig = {
						className: "BPMSoft.Label",
						caption: {bindTo: "AvailableCountCaption"},
						classes: {labelClass: labelClass.concat(["count-label"])}
					};
					config.items.push(labelConfig, editConfig, countConfig);
					itemConfig.config = config;
				},

				/**
				 * @inheritDoc BasePageV2#getHeader
				 * @protected
				 * @overridden
				 */
				getHeader: function() {
					return this.get("Resources.Strings.UserPageHeader");
				},

				/**
				 * ########## ######### # ######## ###########.
				 * @protected
				 */
				onPhotoChange: this.BPMSoft.emptyFn,

				/**
				 * ########## ##### ####### ########### #### ###### #####.
				 * @protected
				 */
				beforeFileSelected: this.BPMSoft.emptyFn,

				/**
				 * ######## ###### ## ###########.
				 * @protected
				 * @return {String|*} Url ###########.
				 */
				getSrcMethod: function() {
					var contact = this.get("Contact");
					if (contact && contact.Photo) {
						var imageConfig = {
							source: this.BPMSoft.ImageSources.SYS_IMAGE,
							params: {
								primaryColumnValue: contact.Photo.value
							}
						};
						return this.BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
					}
					return this.getUserDefaultImageURL();
				},

				/**
				 * Returns default user photo url.
				 * @return {String} Default user photo url.
				 */
				getUserDefaultImageURL: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultPhoto);
				},

				/**
				 * ########## ######### #### "############# ######".
				 * #### ###### ######### ######### "#### ######## ######", ########## #### "#### #########
				 * ######## ######" ########, ###### ####### #### + ########## ####, ######### # #########
				 * #########.
				 * @protected
				 */
				onPasswordConfirmationChanged: function() {
					var password = this.get("UserPassword");
					var passwordDuration = this.get("PasswordDuration");
					if (!this.Ext.isEmpty(password) && password === this.get("PasswordConfirmation") &&
						passwordDuration > 0) {
						var passwordExpireDate = this.Ext.Date.add(new Date(), this.Ext.Date.DAY, passwordDuration);
						passwordExpireDate = this.Ext.Date.clearTime(passwordExpireDate);
						this.set("PasswordExpireDate", passwordExpireDate);
					}
				},

				/**
				 * ############## ################ ######### ### #### "############# ######".
				 * @inheritDoc BaseSchemaViewModel#setValidationConfig
				 * @protected
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("PasswordConfirmation", function(newPasswordConfirmation) {
						var password = this.get("UserPassword");
						var invalidMessage = "";
						if (!this.Ext.isEmpty(password) && !this.get("SynchronizeWithLDAP")) {
							if (password !== newPasswordConfirmation) {
								invalidMessage = this.get("Resources.Strings.PasswordMissMatchMessageCaption");
							}
						}
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					});
					this.addColumnValidator("UserPassword", function() {
						var password = this.get("UserPassword");
						var invalidMessage = "";
						if (this.Ext.isEmpty(password) && !this.get("SynchronizeWithLDAP")) {
							invalidMessage = this.get("Resources.Strings.SpecifyPasswordMessage");
						}
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					});
					this.addColumnValidator("Email", EmailHelper.getEmailValidator);
				},

				/**
				 * ######## ######## ######### ######### PasswordDuration.
				 * @protected
				 * @param {String} settingCode ### ######### #########.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				initSysSettingsValue: function(settingCode, callback, scope) {
					this.BPMSoft.SysSettings.querySysSettingsItem(settingCode,
						function(value) {
							this.set(settingCode, value);
							if (this.Ext.isFunction(callback)) {
								callback.call(scope);
							}
						},
						this);
				},

				/**
				 * ######### ######## ## ####### GetChiefId # SetRecordInformation.
				 * @protected
				 */
				publishMessages: function() {
					var result = this.sandbox.publish("GetChiefId", {}, [this.sandbox.id]);
					if (this.Ext.isEmpty(result)) {
						result = this.sandbox.publish("SetRecordInformation", {}, [this.sandbox.id]);
					}
					if (!this.Ext.isEmpty(result)) {
						this.set("Parent", result.parent);
						var connectionType = this.getConnectionType(result.defaultValues);
						this.set("CurrentFolderConnectionType", this.Ext.isEmpty(connectionType)
							? null
							: connectionType.value);
					}
				},

				/**
				 * ## ####### ######## ## ######### ########## ######## # ###### "ConnectionType" ### null.
				 * @param {Array} defaultValues ######### ######## ## ######### ###### "############".
				 * @return {Object} ### ############ ### null, #### ### ############ ## ###### ##### ########
				 * ## #########.
				 */
				getConnectionType: function(defaultValues) {
					var result = null;
					this.BPMSoft.each(defaultValues, function(value) {
						if (value.name === "ConnectionType") {
							result = value;
						}
					});
					return result;
				},

				/**
				 * ######### ######### # ############# ######## ########### ###### #######.
				 * @protected
				 */
				publishUpdateSectionGrid: function() {
					if (this.isAddMode()) {
						this.sandbox.publish("UpdateSectionGrid");
					}
				},

				/**
				 * #########, #### ## # ############ ##### ## ########## ########## ########
				 * ######## CanManageLicUsers.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				checkCanManageLicUsers: function(callback, scope) {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageLicUsers"
					}, function(result) {
						this.set("CanManageLicUsers", result);
						if (this.Ext.isFunction(callback)) {
							callback.call(scope);
						}
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#init
				 * @protected
				 * @overridden
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				init: function(callback, scope) {
					this.subscribeEvents();
					this.callParent([
						function() {
							this.publishMessages();
							this.initCollection();
							this.BPMSoft.chain(
								function(next) {
									this.getAvailableLicenses(function() {
										next();
									}, this);
								},
								function(next) {
									this.initSysSettingsValue("PasswordDuration", function() {
										next();
									}, this);
								},
								function(next) {
									this.initSysSettingsValue("AccountTypeForOurCompany", function() {
										next();
									}, this);
								},
								function(next) {
									this.initSysSettingsValue("Enable2FA", function() {
										next();
									}, this);
								},
								function(next) {
									this.checkCanManageLicUsers(function() {
										next();
									}, this);
								},
								function(next) {
									this.getIsUserBlocked(function() {
										next();
									}, this);
								},
								function(next) {
									callback.call(scope);
									next();
								},
								this);
						}, this
					]);
				},

				/**
				 * Performs messages subscriptions.
				 * @private
				 */
				subscribeEvents: function() {
					this.sandbox.subscribe("UnblockUser", this.onUnblockClick, this, []);
					this.sandbox.subscribe("DeleteUser", this.onDeleteClick, this, []);
				},

				/**
				 * @inheritDoc BasePageV2#updateDetails
				 * @overridden
				 */
				updateDetails: function() {
					this.callParent(arguments);
					this.getAvailableLicenses();
				},

				/**
				 * @inheritDoc BasePageV2#fireDiscardChangesEvent
				 * @protected
				 * @overridden
				 */
				fireDiscardChangesEvent: function() {
					var entityInfo = this.onGetEntityInfo();
					this.sandbox.publish("DiscardChanges", entityInfo);
				},

				/**
				 * @inheritDoc BasePageV2#onDiscardChangesClick
				 * @protected
				 * @overridden
				 */
				onDiscardChangesClick: function() {
					if (this.isNew) {
						this.sandbox.publish("BackHistoryState");
						return;
					}

					this.set("IsEntityInitialized", false);
					this.loadEntity(this.get("Id"), function() {
						this.discardPasswordChanges();
						this.resetLicensesCollection();
						this.updateButtonsVisibility(false, {
							force: true
						});
						this.set("IsEntityInitialized", true);
						this.discardDetailChange();
					}, this);
					if (this.get("ForceUpdate")) {
						this.set("ForceUpdate", false);
					}
				},

				/**
				 * ########## #### "######" # "############# ######" # ## ######### ##-#########.
				 */
				discardPasswordChanges: function() {
					var info = {
						invalidMessage: "",
						isValid: true
					};
					this.set("UserPassword", this.get("Resources.Strings.PasswordMask"),
						{preventValidation: true});
					this.set("PasswordConfirmation", this.get("UserPassword"),
						{preventValidation: true});
					this.validationInfo.set("UserPassword", info);
					this.validationInfo.set("PasswordConfirmation", info);
					this.changedValues = {};
				},

				/**
				 * ############### ######## ## ######### ### ######### ########.
				 * @private
				 */
				resetLicensesCollection: function() {
					var collection = this.get("LicenseCollection");
					this.set("ModifyAllLicenses", true);
					collection.each(function(model) {
						if (model.getIsChanged()) {
							model.set("Checked", model.values.Checked);
							model.set("Enabled", model.values.Enabled);
						}
					}, this);
					this.set("ModifyAllLicenses", false);
				},

				/**
				 * #########, ########## ## #### ####### ########, ####### ########### #### "############# ######".
				 * ####### ########## ###### ## ######### ########### ####.
				 * @protected
				 * @overridden
				 * @return {Boolean} ########## true #### #### ######### # ######### ####### ##### ########,
				 * false - # ######## ######
				 */
				isChanged: function() {
					var result = this.callParent(arguments);
					return result || !this.Ext.isEmpty(this.changedValues.PasswordConfirmation);
				},

				/**
				 * #### ### ####### ######, ##### ######### ######### ###### ## ####### ##### #####
				 * ###### ValidatePassword # BPMSoft.Core.PasswordUtilities.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validatePassword: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.UserPassword)) {
						callback.call(scope || this, result);
					} else {
						var dataSend = {
							userName: this.get("Name"),
							password: this.get("UserPassword")
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: "ValidatePassword",
							data: dataSend
						};
						this.callService(config, function(response) {
							if (response) {
								if (!this.Ext.isEmpty(response.ValidatePasswordResult)) {
									result.message = response.ValidatePasswordResult;
									result.success = false;
								}
								callback.call(scope || this, result);
							}
						});
					}
				},

				/**
				 * #### ### ####### ######, ##### ######### ######### ###### ## ####### ##### #####
				 * ###### ValidatePassword # BPMSoft.Core.PasswordUtilities.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validateAccountExpireDate: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.AccountExpireTime)) {
						callback.call(scope || this, result);
					} else {
						let now = new Date(),
							accountExpireTime = new Date(this.changedValues.AccountExpireTime);

						if (this.Ext.isEmpty(this.changedValues.AccountBeginTime)) {
							this.$AccountBeginTime = now;
						}

						result.success = accountExpireTime - now >= 0;
						result.message = this.get("Resources.Strings.AccountExpireTimeCantBeLessThanToday");
						callback.call(scope || this, result);
					}
				},

				validateAccountBeginTime: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.AccountBeginTime)) {
						callback.call(scope || this, result);
					} else {
						let AccountExpireTime = this.$AccountExpireTime,
							AccountBeginTime = new Date(this.changedValues.AccountBeginTime);

						result.success = AccountBeginTime < AccountExpireTime;
						result.message = this.get("Resources.Strings.AccountBeginTimeIsGreaterAccountExpireTime");
						callback.call(scope || this, result);
					}
				},

				validateResponse: function(response) {
					var isSuccess = response && response.success;
					if (!isSuccess) {
						var errorMessage=response.message;
						if (errorMessage) {
							this.showInformationDialog(errorMessage);
						} else {
							this.showInformationDialog("errorMessage is undefined!");
							console.log("errorMessage is undefined!");
						}
					}
					this.hideBodyMask();
					return isSuccess;
				},

				/**
				 * ######## ################ ###### AdministrationService
				 * ### ########## ################ ########.
				 * @param {Function} next
				 */
				saveLicenses: function(next) {
					var licenseItems = {};
					var collection = this.get("LicenseCollection");
					collection.each(function(model) {
						if (this.isAddMode() || model.getIsChanged()) {
							licenseItems[model.get("Id")] = model.get("Checked");
						}
					}, this);
					if (this.BPMSoft.isEmptyObject(licenseItems)) {
						this.cardSaveResponse = {success: true};
						next();
					} else {
						var dataSend = {
							userId: this.get("Id"),
							licenseItems: this.Ext.encode(licenseItems)
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: this.getSaveLicensesMethodName(),
							data: dataSend
						};
						this.callService(config, function(response) {
							this.onSaveLicenses(response, next);
						}, this);
					}
				},

				/**
				 * Returns save license method name
				 * @protected
				 * @return {String} Method name.
				 */
				getSaveLicensesMethodName: function() {
					return "UpdateLicenseInfo";
				},

				/**
				 * ######### ############# ########## ######## ############.
				 * @param {Object} response ##### #######.
				 * @param {Function} next ######### ##### # #######.
				 */
				onSaveLicenses: function(response, next) {
					if (response) {
						response.message = response[this.getSaveLicensesMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.cardSaveResponse = response;
							next();
						} else {
							this.getAvailableLicenses();
						}
					}
				},

				/**
				 * Call configuration service AdministrtionService for save user..
				 * @param {Function} next
				 */
				saveUser: function(next) {
					if(this.changedValues && !this.Ext.isEmpty(this.changedValues.UserPassword) && !this.isNew){
						this.showConfirmationDialog(this.get("Resources.Strings.ChangePasswordWarning"),
						function(returnCode) {
							if (returnCode === this.BPMSoft.MessageBoxButtons.NO.returnCode || returnCode === null) {
								this.cardSaveResponse = {success: true};
								next();
								return;
							}
							this.saveUserOperation(next);
							this.terminateUserSessions();
						},
						[this.BPMSoft.MessageBoxButtons.YES.returnCode, this.BPMSoft.MessageBoxButtons.NO.returnCode],
						null);
					} else if (this.changedValues && !this.isNew && !this.$Active &&
						   (this.changedValues.AccountExpireTime === null && this.changedValues.AccountBeginTime === null ||
							this.changedValues.AccountExpireTime || this.changedValues.AccountBeginTime)) {
						this.showConfirmationDialog(this.get("Resources.Strings.ChangeTimeTempUser"),
							function(returnCode) {
								if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.$Active = true;
								}
								this.saveUserOperation(next);
							},
							[this.BPMSoft.MessageBoxButtons.YES.returnCode, this.BPMSoft.MessageBoxButtons.NO.returnCode],
							null);
					} else {
						this.saveUserOperation(next);
					}
				},
				
				saveUserOperation: function(next){
					var changedColumns = {};
					this.BPMSoft.each(this.entitySchema.columns,
						function(column) {
							if (this.changedValues.hasOwnProperty(column.name)) {
								var columnValue = this.get(column.name);
								if (columnValue) {
									columnValue = columnValue.value || columnValue;
								}
								changedColumns[column.name] = columnValue;
							}
						}, this);
					if (this.BPMSoft.isEmptyObject(changedColumns)) {
						this.cardSaveResponse = {success: true};
						next();
					} else {
						if (this.Ext.isEmpty(changedColumns.Id)) {
							changedColumns.Id = this.get("Id");
						}
						var dataSend = {
							jsonObject: this.Ext.encode(changedColumns),
							roleId: this.get("Parent")
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: this.getSaveUserMethodName(),
							data: dataSend
						};
						this.callService(config, function(response) {
							this.onSaveUser(response, next);
						}, this);
					}
				},
				
				terminateUserSessions:function(){
					var dataSend = {
						userId: this.get("Id")
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "TerminateUserSessions",
						data: dataSend
					};
					this.callService(config, () => {});
				},
				
				/**
				 * Returns save user method name
				 * @protected
				 * @return {String} Method name.
				 */
				getSaveUserMethodName: function() {
					return "UpdateOrCreateUser";
				},

				/**
				 * ######### ############# ##########.
				 * @param {Object} response ##### #######.
				 * @param {Function} next ######### ##### # #######.
				 */
				onSaveUser: function(response, next) {
					if (response) {
						response.message = response[this.getSaveUserMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.isNew = false;
							this.changedValues = null;
							this.cardSaveResponse = response;
							next();
						}
					}
				},

				/**
				 * ######### ########## ############.
				 * @overridden
				 * @param {Object} config
				 */
				save: function(config) {
					this.showBodyMask();
					this.BPMSoft.chain(
						this.saveCheckCanEditRight,
						this.saveAsyncValidate,
						this.saveUser,
						this.saveLicenses,
						function(next) {
							this.saveDetails(function(response) {
								if (this.validateResponse(response)) {
									next();
								}
							}, this);
						},
						function() {
							this.onSaved(this.cardSaveResponse, config);
							this.cardSaveResponse = null;
							delete this.cardSaveResponse;
						},
						this);
				},

				/**
				 * @inheritDoc BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					if (this.isEditMode()) {
						this.getAvailableLicenses();
					}
				},

				/**
				 * ######### ######## ##### ############ ## ############.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validateUniqueUserName: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Name)) {
						callback.call(scope || this, result);
					} else {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						esq.addColumn("Id");
						var primaryColumnValue = this.get("PrimaryColumnValue");
						if (!Ext.isEmpty(primaryColumnValue)) {
							esq.filters.add("primaryColumnFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", primaryColumnValue));
						}
						var uniqueNameAndEmailFilterGroup = Ext.create("BPMSoft.FilterGroup");
						uniqueNameAndEmailFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
						uniqueNameAndEmailFilterGroup.add("emailFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Email", this.get("Name")));
						uniqueNameAndEmailFilterGroup.add("nameFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Name", this.get("Name")));				
						esq.filters.add("uniqueNameAndEmail", uniqueNameAndEmailFilterGroup);
						esq.filters.add("adminUnitEmployeeFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 4));
						esq.filters.add("adminUnitSspFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.LESS_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 5));
						esq.getEntityCollection(function(response) {
							if (response && response.success) {
								if (response.collection.getCount() > 0) {
									result.message = this.get("Resources.Strings.UserNameNotUnique");
									result.success = false;
								}
								callback.call(scope || this, result);
							}
						}, this);
					}
				},

				/**
				 * ######### ######## Email ############ ## ############.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validateUniqueUserEmail: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Email)) {
						callback.call(scope || this, result);
					} else {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						esq.addColumn("Id");
						var primaryColumnValue = this.get("PrimaryColumnValue");
						if (!Ext.isEmpty(primaryColumnValue)) {
							esq.filters.add("primaryColumnFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", primaryColumnValue));
						}
						var uniqueNameAndEmailFilterGroup = Ext.create("BPMSoft.FilterGroup");
						uniqueNameAndEmailFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
						uniqueNameAndEmailFilterGroup.add("emailFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Email", this.get("Email")));
						uniqueNameAndEmailFilterGroup.add("nameFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Name", this.get("Email")));				
						esq.filters.add("uniqueNameAndEmail", uniqueNameAndEmailFilterGroup);
						esq.filters.add("adminUnitEmployeeFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 4));
						esq.filters.add("adminUnitSspFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.LESS_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 5));
						esq.getEntityCollection(function(response) {
							if (response && response.success) {
								if (response.collection.getCount() > 0) {
									result.message = this.get("Resources.Strings.UserNameNotUnique");
									result.success = false;
								}
								callback.call(scope || this, result);
							}
						}, this);
					}
				},

				/**
				 * @inhericDoc BasePageV2#asyncValidate
				 * @protected
				 * @overridden
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						this.BPMSoft.chain(
							function(next) {
								this.validatePassword(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								this.validateUniqueUserName(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								this.validateUniqueUserEmail(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								this.validateAccountBeginTime(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								this.validateAccountExpireDate(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				},

				/**
				 * ########## ##### # #### "######".
				 * ######### ######## ##### ## ############ # ########## UserPassword.
				 * ### ########## ### ####, ##### ######### ###### ########### ###########,
				 * # ## ###### ### ###### ######.
				 * @private
				 */
				onNewPasswordKeypress: function() {
					var newPasswordTextEdit = this.Ext.getCmp("new-password");
					var newPasswordInputValue = newPasswordTextEdit.getTypedValue();
					this.set("UserPassword", newPasswordInputValue);
					this.validate();
				},

				/**
				 * ##########, ##### #### "######" ######## #####.
				 * ####### ######## # ##### "######" # "############# ######".
				 * @private
				 */
				onPasswordGetFocus: function() {
					this.set("UserPassword", null, {preventValidation: true});
					this.set("PasswordConfirmation", null, {preventValidation: true});
				},

				/**
				 * ########## ##### # #### "############# ######".
				 * ######### ######## ##### ## ############ # ########## PasswordConfirmation.
				 * ### ########## ### ####, ##### ######### ###### ########### ###########,
				 * # ## ###### ### ###### ######.
				 * @private
				 */
				onNewPasswordConfirmationKeypress: function() {
					var newPasswordConfirmationTextEdit = this.Ext.getCmp("new-password-confirmation");
					var newPasswordConfirmationInputValue = newPasswordConfirmationTextEdit.getTypedValue();
					this.set("PasswordConfirmation", newPasswordConfirmationInputValue);
				},

				/**
				 * ############ ######## ######## isRequired.
				 * @protected
				 * @virtual
				 */
				isRequiredFieldsVisible: function() {
					return true;
				},

				/**
				 * ######### ###### # ############# ######## ##########.
				 * @protected
				 * @param {Object} args ########## ## ########### ######### ###### {action: "", rows: []}
				 */
				fireUpdateDetail: function(args) {
					this.sandbox.publish("UpdateDetail", args, [this.sandbox.id]);
				},

				/**
				 * @inheritDoc BasePageV2#onCloseCardButtonClick
				 * @protected
				 * @overridden
				 */
				onCloseCardButtonClick: function() {
					this.callParent(arguments);
					this.publishUpdateSectionGrid();
				},

				/**
				 * ######### ##### ####### # ######### ############ # ###### ####### ######.
				 * @protected
				 * @param {String} response ############ ##### #######
				 * @param {String} message ######### # ###### ######
				 * @param {Function} callback ####### ######### ###### # ###### ########## #######.
				 * @param {Object} scope  ######## ####### ######### ######.
				 */
				validateServiceResponse: function(response, message, callback, scope) {
					this.hideBodyMask();
					var result = this.Ext.decode(response);
					var isSuccess = result && result.Success;
					if (isSuccess) {
						callback.call(scope);
					} else if (result.IsSecurityException) {
						this.showInformationDialog(result.ExceptionMessage);
					} else {
						this.showInformationDialog(message);
					}
				},

				/**
				 * ######## ########### ##### ######## ############.
				 * @protected
				 */
				afterUserDeleted: function() {
					this.sandbox.publish("UserDeletedSuccessfully");
					this.fireUpdateDetail({reloadAll: true});
					this.onCloseCardButtonClick();
				},

				/**
				 * ######### # ########## ######## ############ # ###### ######,
				 * ######### ###### "############" # ############# ########## #######
				 * # ######### ######## ### ######## ########.
				 * @param {Object} response ##### #######.
				 * @protected
				 */
				onDeleteUserResponseHandler: function(response) {
					var message = this.get("Resources.Strings.DeleteErrorMessage");
					var responseResult = response[this.getOnDeleteCurrentUserClickMethodName() + "Result"];
					this.validateServiceResponse(responseResult, message, this.afterUserDeleted, this);
				},

				/**
				 * ######## ###### ######## ############# # ######### ######## ### ######## ########.
				 * @protected
				 * @virtual
				 */
				onDeleteCurrentUserClick: function() {
					this.showConfirmationDialog(this.get("Resources.Strings.DeleteUserMessage"),
						function(returnCode) {
							if (returnCode === this.BPMSoft.MessageBoxButtons.NO.returnCode) {
								return;
							}
							var dataSend = {userId: this.get("Id")};
							var config = {
								serviceName: "AdministrationService",
								methodName: this.getOnDeleteCurrentUserClickMethodName(),
								data: dataSend
							};
							this.showBodyMask();
							this.callService(config, this.onDeleteUserResponseHandler, this);
						},
						[
							this.BPMSoft.MessageBoxButtons.YES.returnCode,
							this.BPMSoft.MessageBoxButtons.NO.returnCode
						],
						null
					);
				},

				/**
				 * Returns delete user method name
				 * @protected
				 * @return {String} Method name.
				 */
				getOnDeleteCurrentUserClickMethodName: function() {
					return "DeleteUser";
				},

				/**
				 * ########## ###### "DeleteButton".
				 * @protected
				 * @virtual
				 */
				onDeleteClick: function() {
					this.onDeleteCurrentUserClick();
				},

				getOnUnblockUserClickMethodName: function() {
					return "UnblockUser";
				},

				onUnblockClick: function() {
					var dataSend = {userId: this.get("Id")};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getOnUnblockUserClickMethodName(),
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, this.onUnblockUserResponseHandler, this);
				},

				onUnblockUserResponseHandler: function(response) {
					var message = this.get("Resources.Strings.UnblockErrorMessage");
					var responseResult = response[this.getOnUnblockUserClickMethodName() + "Result"];
					this.validateServiceResponse(responseResult, message, this.afterUserUnblocked, this);
				},

				afterUserUnblocked: function() {
					var message = this.get("Resources.Strings.UnblockSuccessMessage");
					this.showInformationDialog(message);
					this.getIsUserBlocked();
				},

				setIsUserBlocked: function(value) {
					this.set("IsUserBlocked", value);
					this.sandbox.publish("SetIsUserBlocked", {"IsUserBlocked": value});
				},

				getIsUserBlocked: function(callback, scope) {
					this.setIsUserBlocked(false);
					var userId = this.isAddMode()
						? this.BPMSoft.GUID_EMPTY
						: (this.get("PrimaryColumnValue") || this.get(this.entitySchema.primaryColumnName));
					var dataSend = {
						userId: userId
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetIsUserBlocked",
						data: dataSend
					};
					this.callService(config, function(response) {
						this.onGetIsUserBlockedHandler(response, callback, scope);
					}, this);
				},

				onGetIsUserBlockedHandler: function(response, callback, scope) {
					if (response && response.GetIsUserBlockedResult) {
						this.setIsUserBlocked(response.GetIsUserBlockedResult);
					}
					if (this.Ext.isFunction(callback)) {
						callback.call(scope);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getSectionCode
				 * @override
				 */
				getSectionCode: function() {
					return "SystemUsers";
				}
			}
		};
	});
