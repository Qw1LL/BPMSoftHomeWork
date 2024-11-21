define("LDAPServerSettings", ["BPMSoft", "LDAPServerSettingsResources", "ServiceHelper", "BusinessRuleModule",
		"SecurityUtilities", "ContextHelpMixin", "css!DetailModuleV2"],
	function(BPMSoft, resources, ServiceHelper, BusinessRuleModule) {
		return {
			messages: {
				/**
				 * @message ChangeHeaderCaption
				 * Notifies that the header caption was changed.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message BackHistoryState
				 * Notifies that state was returned to previous.
				 */
				"BackHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message InitDataViews
				 * Notifies that the header caption was changed.
				 */
				"InitDataViews": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
			},
			mixins: {
				SecurityUtilitiesMixin: "BPMSoft.SecurityUtilitiesMixin",
				ContextHelpMixin: "BPMSoft.ContextHelpMixin"
			},
			attributes: {
				LDAPServer: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUsersEntry: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPGroupsEntry: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUserCompanyAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				LDAPKeyDistributionCenter: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				LDAPAuthType: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPServerLogin: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPServerPassword: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPEntryModifiedOnAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPSynchInterval: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUserFullNameAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUserLoginAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUserIdentityAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUserEmailAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				LDAPUserPhoneAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				LDAPUserJobTitleAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				LDAPGroupNameAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPGroupIdentityAttribute: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUsersFilter: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPGroupsFilter: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPUsersInGroupFilter: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ""
				},
				LDAPSynchronizeOnlyGroups: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				IsSynchronizeOnlyGroupsVisible: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				LDAPAllowLicenseDistributionDuringLDAPSync: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: ""
				},
				IsAllowLicenseDistributionVisible: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				LDAPUseSecureConnection: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				IsUseSecureConnectionVisible: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
                IsAuthenticationSettingsVisible: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * ######## ########, ###### ## ####### ###### #### # ############ ### ############# ########.
				 */
				"SecurityOperationName": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "CanManageAdministration"
				}
			},
			methods: {
				/**
				 * ########## ## ########## ######.
				 * @protected
				 * @virtual
				 */
				cancel: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * ############# ######### ######## ######### LDAP #######.
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.checkAvailability(function() {
							this.set("LDAPEnumFieldName", "LDAPAuthType");
							const headerConfig = {
								caption: resources.localizableStrings.CaptionLDAPServerSettings,
								isMainMenu: false,
							};
							this.sandbox.publish("ChangeHeaderCaption", headerConfig);
							this.sandbox.publish("InitDataViews", headerConfig);
							var ldapSettingKeys = this.getLDAPSettingKeys();
							BPMSoft.SysSettings.querySysSettings(ldapSettingKeys, this.onGetSysSettingValues, this);
							callback.call(scope);
						});
						this.initContextHelp();
					}, this]);
					if (this.getIsFeatureEnabled("DeactivateExcludedLdapUsers")) {
						this.set("IsSynchronizeOnlyGroupsVisible", true);
					}
					if(this.getIsFeatureEnabled("ControlLicenseDistributionDuringLDAPSync")) {
						this.set("IsAllowLicenseDistributionVisible", true);
					}
					if (this.getIsFeatureEnabled("LDAPUseSecureConnection")) {
						this.set("IsUseSecureConnectionVisible", true);
					}
				},

				/**
				 * @inheritdoc BPMSoft.ContextHelpMixin#getContextHelpCode
				 * @overriden
				 */
				getContextHelpCode: function() {
					return this.name;
				},

				/**
				 * ############# ######## ######### ## ########
				 * @param {BPMSoft.Collection} sysSettingsCollection ######### ######-########
				 */
				onGetSysSettingValues: function(sysSettingsCollection) {
					if (!sysSettingsCollection) {
						return;
					}
					var lDAPEnumFieldName = this.get("LDAPEnumFieldName");
					this.BPMSoft.each(sysSettingsCollection, function(value, key) {
						if (key !== lDAPEnumFieldName) {
							if (key === "LDAPServerPassword") {
								value = null;
							}
							this.set(key, value);
						} else {
							this.getColumnByName(key).referenceSchemaName = key;
							var esq = this.getLookupQuery(null, key, false);
							esq.enablePrimaryColumnFilter(value.value);
							esq.getEntityCollection(function(result) {
								if (result.success && result.collection.getCount()) {
									var entity = result.collection.getByIndex(0);
									var enumConfig = {
										value: entity.values.value,
										displayValue: entity.values.displayValue
									};
									this.set(key, enumConfig);
								}
							}, this);
						}
					}, this);
				},

				/**
				 * ######## ###### ######### ######## LDAP
				 * @param {String} methodName ########## ##### #######
				 * @param {Function} callback ############## #######
				 */
				callLDAPService: function(methodName, callback) {
					ServiceHelper.callService({
						serviceName: "LDAPSysSettingsService",
						methodName: methodName,
						data: {
							request: this.collectValuesOfLDAPSettings()
						},
						callback: callback,
						scope: this
					});
				},

				/**
				 * ######## ######### LDAP ####### #######.
				 * @protected
				 * @overridden
				 */
				save: function() {
					if (this.validate()) {
						this.callLDAPService("SetSysSettingValues", function(response) {
							if (response && response.success) {
								var message = resources.localizableStrings.StartImportMessage;
								this.showInformationDialog(message);
								this.sandbox.publish("BackHistoryState");
							} else {
								this.showInformationDialog(response.errorInfo.message);
							}
						});
					}
				},

				/**
				 * ######## ######## ####### # ######### ######### JSON ########.
				 * @protected
				 * @virtual
				 */
				collectValuesOfLDAPSettings: function() {
					var ldapSettingKeys = this.getLDAPSettingKeys();
					var ldapEnumFieldName = this.get("LDAPEnumFieldName");
					var ldapSettingsCollection = [];
					this.BPMSoft.each(ldapSettingKeys, function(key) {
						var value = this.get(key);
						if (key === ldapEnumFieldName) {
							value = (value && value.value) ? value.value : value;
						}
						var KeyValuePairs = {
							"Key": key,
							"Value": value
						};
						ldapSettingsCollection.push(KeyValuePairs);
					}, this);
					return ldapSettingsCollection;
				},

				/**
				 * Returns LDAP setting keys.
				 * @protected
				 * @virtual
				 */
				getLDAPSettingKeys: function() {
					var columnsCollection = this.columns;
					var filteredColumnsCollection = this.filterForColumns(columnsCollection);
					var ldapEnumFieldName = this.get("LDAPEnumFieldName");
					var ldapSettingKeys = [];
					this.BPMSoft.each(filteredColumnsCollection, function(column) {
						var key = column.name;
						if (key !== ldapEnumFieldName + "List") {
							ldapSettingKeys.push(key);
						}
					}, this);
					return ldapSettingKeys;
				},

				/**
				 * ######### ######## ####### ## ############ ########.
				 * @protected
				 * @virtual
				 */
				filterForColumns: function(element) {
					var filter = "LDAP";
					var filteredCollection = [];
					for (var el in element) {
						if (el.substring(0, 4) === filter) {
							filteredCollection.push(element[el]);
						}
					}
					return (filteredCollection);
				},

				/**
				 * ######## ###### ######## ### ########### ######
				 * @param {String} filter ###### ########### ######
				 */
				onPrepareLDAPAuthType: function(filter) {
					var prepareListColumnName = this.get("LDAPEnumFieldName");
					this.getColumnByName(prepareListColumnName).referenceSchemaName = prepareListColumnName;
					this.set("PrepareListColumnName", prepareListColumnName);
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: prepareListColumnName
					});
					esq.addColumn("Id");
					esq.getEntityCollection(function(result) {
						var existsCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								existsCollection.push(item.get("Id"));
							});
						}
						var filtersCollection = this.BPMSoft.createFilterGroup();
						if (existsCollection.length > 0) {
							filtersCollection.add("existsFilter", this.BPMSoft.createColumnInFilterWithParameters(
								"Id", existsCollection));
						} else {
							filtersCollection.add("emptyFilter", this.BPMSoft.createColumnIsNullFilter("Id"));
						}
						this.set(prepareListColumnName + "Filters", filtersCollection);
						this.loadLookupData(filter, this.get(prepareListColumnName + "List"),
							prepareListColumnName, true);
					}, this);
				},

				/**
				 * ########## ######### EntitySchemaQuery ### ######### ###### lookup #######
				 * @overridden
				 * @private
				 * @param {String} filterValue ###### ### primaryDisplayColumn
				 * @param {String} columnName ### ####### ViewModel
				 * @param {Boolean} isLookup ####### ########### ####
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getLookupQuery: function(filterValue, columnName, isLookup) {
					var prepareListColumnName = this.get("PrepareListColumnName");
					var prepareListFilters = this.get(prepareListColumnName + "Filters");
					var entitySchemaQuery = this.callParent([filterValue, columnName, isLookup]);
					if (columnName === prepareListColumnName && prepareListFilters) {
						entitySchemaQuery.filters.add(prepareListColumnName + "Filter", prepareListFilters);
					}
					return entitySchemaQuery;
				}
			},
			rules: {
                "AuthenticationSettings": {
					"BindParameterVisibleLDAPAuthTypeToAuthenticationSettings": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "LDAPAuthType"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "b64d61cc-882d-461e-b62d-33859edc71ea"
								}
							}
						]
					}
				},
				"LDAPKeyDistributionCenter": {
					"BindParameterVisibleLDAPAuthTypeToLDAPKeyDistributionCenter": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "LDAPAuthType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "5efa56f9-3182-400c-88ed-5b7addc418ef"
								}
							}
						]
					},
					"BindParameterRequireLDAPAuthTypeToLDAPKeyDistributionCenter": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "LDAPAuthType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "5efa56f9-3182-400c-88ed-5b7addc418ef"
								}
							}
						]
					}
				},
				"LDAPServerLogin": {
					"BindParameterRequireLDAPAuthTypeToLDAPServerLogin": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "LDAPAuthType"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "b64d61cc-882d-461e-b62d-33859edc71ea"
								}
							}
						]
					}
				},
				"LDAPServerPassword": {
					"BindParameterRequireLDAPAuthTypeToLDAPServerPassword": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "LDAPAuthType"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "b64d61cc-882d-461e-b62d-33859edc71ea"
								}
							}
						]
					}
				}
			},
			diff: [{
				"operation": "insert",
				"name": "ServerSettingsContainerLDAP",
				"values": {
					"id": "ServerSettingsContainerLDAP",
					"selectors": {
						"wrapEl": "#ServerSettingsContainerLDAP"
					},
					"classes": {
						"textClass": "center-panel"
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "HeaderContainer",
				"parentName": "ServerSettingsContainerLDAP",
				"propertyName": "items",
				"values": {
					"id": "HeaderContainer",
					"selectors": {
						"wrapEl": "#HeaderContainer"
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"name": "SaveButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {
						"bindTo": "Resources.Strings.SaveButtonCaption"
					},
					"classes": {
						"textClass": "actions-button-margin-right"
					},
					"click": {
						"bindTo": "save"
					},
					"style": "orange",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 2
					}
				}
			}, {
				"operation": "insert",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {
						"bindTo": "Resources.Strings.CancelButtonCaption"
					},
					"classes": {
						"textClass": "actions-button-margin-right"
					},
					"click": {
						"bindTo": "cancel"
					},
					"style": "default",
					"layout": {
						"column": 4,
						"row": 0,
						"colSpan": 2
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPProperties",
				"parentName": "ServerSettingsContainerLDAP",
				"propertyName": "items",
				"values": {
					"id": "LDAPProperties",
					"selectors": {
						"wrapEl": "#LDAPProperties"
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "CommonServerSettings",
				"parentName": "LDAPProperties",
				"propertyName": "items",
				"values": {
					"id": "CommonServerSettings",
					"selectors": {
						"wrapEl": "#CommonServerSettings"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.QueryPropertiesLabel"
						}
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "CommonServerSettings_GridLayout",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "CommonServerSettings",
				"propertyName": "items",
				"index": 0
			}, {
				"operation": "insert",
				"name": "LDAPServer",
				"parentName": "CommonServerSettings_GridLayout",
				"propertyName": "items",
				"index": 0,
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPServer",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPServer"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPSynchInterval",
				"parentName": "CommonServerSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 8
					},
					"bindTo": "LDAPSynchInterval",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPSynchInterval"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPAuthType",
				"parentName": "CommonServerSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 8
					},
					"bindTo": "LDAPAuthType",
					"contentType": BPMSoft.ContentType.ENUM,
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPAuthType"
						}
					},
					"controlConfig": {
						"prepareList": {"bindTo": "onPrepareLDAPAuthType"}
					}
				}
			},{
				"operation": "insert",
				"name": "LDAPSynchronizeOnlyGroups",
				"parentName": "CommonServerSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPSynchronizeOnlyGroups",
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.LDAPSynchronizeOnlyGroups"
						}
					},
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.LDAPSynchronizeOnlyGroupsTip"
						}
					},
					"visible": {
						"bindTo": "IsSynchronizeOnlyGroupsVisible"
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPAllowLicenseDistribution",
				"parentName": "CommonServerSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column":10,
						"row": 1,
						"colSpan": 8
					},
					"bindTo": "LDAPAllowLicenseDistributionDuringLDAPSync",
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.LDAPAllowLicenseDistribution"
						}
					},
					"visible": {
						"bindTo": "IsAllowLicenseDistributionVisible"
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUseSecureConnection",
				"parentName": "CommonServerSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 2,
						"colSpan": 8
					},
					"bindTo": "LDAPUseSecureConnection",
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.LDAPUseSecureConnection"
						}
					},
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.LDAPUseSecureConnectionTip"
						}
					},
					"visible": {
						"bindTo": "IsUseSecureConnectionVisible"
					}
				}
			}, {
				"operation": "insert",
				"name": "AuthenticationSettings",
				"parentName": "LDAPProperties",
				"propertyName": "items",
				"values": {
					"id": "AuthenticationSettings",
					"selectors": {
						"wrapEl": "#AuthenticationSettings"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.AuthenticationSettingsLabel"
						}
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "AuthenticationSettings_GridLayout",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "AuthenticationSettings",
				"propertyName": "items",
				"index": 0
			}, {
				"operation": "insert",
				"name": "LDAPServerLogin",
				"parentName": "AuthenticationSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPServerLogin",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPServerLogin"
						}
					},
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.LDAPServerLoginTip"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPServerPassword",
				"parentName": "AuthenticationSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 8
					},
					"bindTo": "LDAPServerPassword",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPServerPassword"
						}
					},
					"controlConfig": {
						"protect": true
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPKeyDistributionCenter",
				"parentName": "AuthenticationSettings_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPKeyDistributionCenter",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.KeyDistributionCenterCaption"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "UserAttributes",
				"parentName": "LDAPProperties",
				"propertyName": "items",
				"values": {
					"id": "UserAttributes",
					"selectors": {
						"wrapEl": "#UserAttributes"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.UserAttributesLabel"
						}
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "UserAttributes_GridLayout",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "UserAttributes",
				"propertyName": "items",
				"index": 0
			}, {
				"operation": "insert",
				"name": "LDAPUsersEntry",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPUsersEntry",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUsersEntry"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserFullNameAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 8
					},
					"bindTo": "LDAPUserFullNameAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserFullNameAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserLoginAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 8
					},
					"bindTo": "LDAPUserLoginAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserLoginAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserCompanyAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPUserCompanyAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserCompanyAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserIdentityAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 1,
						"colSpan": 8
					},
					"bindTo": "LDAPUserIdentityAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserIdentityAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPEntryModifiedOnAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 8
					},
					"bindTo": "LDAPEntryModifiedOnAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPEntryModifiedOnAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserEmailAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 8
					},
					"bindTo": "LDAPUserEmailAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserEmailAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserPhoneAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 2,
						"colSpan": 8
					},
					"bindTo": "LDAPUserPhoneAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserPhoneAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUserJobTitleAttribute",
				"parentName": "UserAttributes_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 3,
						"colSpan": 8
					},
					"bindTo": "LDAPUserJobTitleAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUserJobTitleAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "AttributesGroupOfUsers",
				"parentName": "LDAPProperties",
				"propertyName": "items",
				"values": {
					"id": "AttributesGroupOfUsers",
					"selectors": {
						"wrapEl": "#AttributesGroupOfUsers"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.AttributesGroupOfUsersLabel"
						}
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "AttributesGroupOfUsers_GridLayout",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "AttributesGroupOfUsers",
				"propertyName": "items",
				"index": 0
			}, {
				"operation": "insert",
				"name": "LDAPGroupNameAttribute",
				"parentName": "AttributesGroupOfUsers_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPGroupNameAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPGroupNameAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPGroupsEntry",
				"parentName": "AttributesGroupOfUsers_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 8
					},
					"bindTo": "LDAPGroupsEntry",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPGroupsEntry"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPGroupIdentityAttribute",
				"parentName": "AttributesGroupOfUsers_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 10,
						"row": 0,
						"colSpan": 8
					},
					"bindTo": "LDAPGroupIdentityAttribute",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPGroupIdentityAttribute"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "FilteringCondition",
				"parentName": "LDAPProperties",
				"propertyName": "items",
				"values": {
					"id": "FilteringCondition",
					"selectors": {
						"wrapEl": "#FilteringCondition"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.FilteringConditionLabel"
						}
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "FilteringCondition_GridLayout",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				},
				"parentName": "FilteringCondition",
				"propertyName": "items",
				"index": 0
			}, {
				"operation": "insert",
				"name": "LDAPUsersFilter",
				"parentName": "FilteringCondition_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 18
					},
					"bindTo": "LDAPUsersFilter",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUsersFilter"
						}
					},
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.LDAPUsersFilterTip"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPGroupsFilter",
				"parentName": "FilteringCondition_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 18
					},
					"bindTo": "LDAPGroupsFilter",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPGroupsFilter"
						}
					},
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.LDAPGroupsFilterTip"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "LDAPUsersInGroupFilter",
				"parentName": "FilteringCondition_GridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 18
					},
					"bindTo": "LDAPUsersInGroupFilter",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.LDAPUsersInGroupFilter"
						}
					},
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.LDAPUsersInGroupFilterTip"
						}
					}
				}
			}]
		};
	});