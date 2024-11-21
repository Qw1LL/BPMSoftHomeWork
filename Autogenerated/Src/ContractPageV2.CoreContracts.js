define("ContractPageV2", ["BPMSoft", "GeneralDetails", "BusinessRuleModule", "ConfigurationConstants",
		"RightUtilities", "VisaHelper", "css!VisaHelper"],
	function(BPMSoft, GeneralDetails, BusinessRuleModule, ConfigurationConstants, RightUtilities, VisaHelper) {
		return {
			entitySchemaName: "Contract",
			details: /**SCHEMA_DETAILS*/{
				"Activities": {
					"schemaName": "ActivityDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Contract"
					},
					"defaultValues": {
						Contract: {
							masterColumn: "Id"
						},
						Account: {
							masterColumn: "Account"
						},
						Contact: {
							masterColumn: "Contact"
						}
					}
				},
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "ContractFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Contract"
					}
				},
				"SubordinateContracts": {
					"schemaName": "ContractDetailV2",
					"entitySchemaName": "Contract",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Parent"
					},
					defaultValues: {
						Account: {
							masterColumn: "Account"
						},
						Contact: {
							masterColumn: "Contact"
						},
						CustomerBillingInfo: {
							masterColumn: "CustomerBillingInfo"
						},
						OurCompany: {
							masterColumn: "OurCompany"
						},
						SupplierBillingInfo: {
							masterColumn: "SupplierBillingInfo"
						}
					}
				},
				Visa: {
					schemaName: "VisaDetailV2",
					entitySchemaName: "ContractVisa",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contract"
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contract"
					},
					filterMethod: "emailDetailFilter"
				}
			}/**SCHEMA_DETAILS*/,
			attributes: {
				"State": {
					lookupListConfig: {
						orders: [{columnPath: "Position"}]
					}
				},
				"Parent": {
					name: "Parent",
					dependencies: [
						{
							columns: ["Account", "OurCompany"],
							methodName: "clearParent"
						}
					]
				},

				/**
				 * ######### ######### #######
				 */
				"CustomerBillingInfo": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					dependencies: [
						{
							columns: ["Account"],
							methodName: "clearBillingInfo"
						}
					],
					lookupListConfig: {
						filter: function() {
							var account = this.get("Account");
							account = account && account.value;
							var filters = this.BPMSoft.createFilterGroup();
							filters.logicalOperation = BPMSoft.LogicalOperatorType.OR;
							filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.EQUAL, "Account", account));
							var filtersRelation = this.BPMSoft.createFilterGroup();
							filtersRelation.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"[VwAccountRelationship:RelatedAccount:Account].RelationType",
								ConfigurationConstants.RelationType.HeadCompany));
							filtersRelation.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"[VwAccountRelationship:RelatedAccount:Account].Account",
								account));
							filters.addItem(filtersRelation);
							return filters;
						}
					}
				},

				/**
				 * ######### ######### ##### ########
				 */
				"SupplierBillingInfo": {
					dependencies: [
						{
							columns: ["OurCompany"],
							methodName: "clearBillingInfo"
						}
					]
				}
			},
			methods: {
				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					if ((this.isAddMode() && this.Ext.isEmpty(this.get("Number"))) || this.isCopyMode()) {
						this.getIncrementCode(function(response) {
							this.set("Number", response);
						});
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": VisaHelper.resources.localizableStrings.SendToVisaCaption,
						"Tag": VisaHelper.SendToVisaMenuItem.methodName,
						"Enabled": {"bindTo": "canEntityBeOperated"}
					}));
					return actionMenuItems;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getUpdateDetailOnSavedConfig
				 * @overridden
				 */
				getUpdateDetailOnSavedConfig: function() {
					var updateConfig = {};
					var parentAccountValue = this.getParentAccountValue();
					var currentAccount = this.get("Account");
					if (parentAccountValue && currentAccount &&
							parentAccountValue !== currentAccount.value) {
						updateConfig.reloadAll = true;
					} else {
						updateConfig.primaryColumnValue = this.get(this.primaryColumnName);
					}
					return updateConfig;
				},

				/**
				 * Returns parent account value.
				 * @private
				 * @return {Guid} Parent account value.
				 */
				getParentAccountValue: function() {
					var result = null;
					var defaultValues = this.get("DefaultValues");
					if (this.isNotEmpty(defaultValues)) {
						var parentAccount = this.BPMSoft.findItem(defaultValues, {name: "Account"});
						if (parentAccount && parentAccount.item) {
							var account = parentAccount.item;
							result = account.value;
						}
					}
					return result;
				},

				/**
				 * Sends current record to sighting.
				 */
				sendToVisa: VisaHelper.SendToVisaMethod,

				/**
				 * Validates number column value.
				 */
				validateUniqueNumber: function(callback, scope) {
					var number = this.get("Number");
					var id = this.get("Id");
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Number)) {
						this.Ext.callback(callback, scope || this, [result]);
					} else {
						var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						select.addColumn("Number");
						select.filters.addItem(select.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", id));
						select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"Number", number));
						select.getEntityCollection(function(response, scope) {
							if (response.success) {
								if (response.collection.getCount() > 0) {
									result.message = this.get("Resources.Strings.NumberMustBeUnique");
									result.success = false;
								}
							} else {
								return;
							}
							Ext.callback(callback, scope || this, [result]);
						}, scope);
					}
				},

				/**
				 * Validates end date column value.
				 * @param {Object} column End date column value.
				 */
				validateEndDate: function(column) {
					var invalidMessage = "";
					if (!this.Ext.isEmpty(column) && this.get("StartDate") > column) {
						invalidMessage = this.get("Resources.Strings.DueDateLowerStartDate");
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * ######## ######### "#### ######" # "#### ##########".
				 * "#### ##########" ###### #### ######/##### "#### ######".
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("EndDate", this.validateEndDate);
				},

				/**
				 * ######### ######## ######## ###### #############.
				 * @protected
				 * @overridden
				 * @param {Function} callback callback-#######
				 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## callback-#######
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						BPMSoft.chain(
							function(next) {
								this.validateUniqueNumber(function(response) {
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
				 * Cleanes field "Parent".
				 */
				clearParent: function() {
					this.set("Parent", "");
				},

				/**
				 * ######## ######## ######### ########## ##### ######## ### #######
				 * @protected
				 */
				clearBillingInfo: function(argument, field) {
					var changedValue = this.changedValues[field];
					var fieldValue = this.get(field) !== null ? this.get(field).value : {};
					if (changedValue && changedValue.value !== fieldValue) {
						if (field === "Account") {
							this.set("CustomerBillingInfo", null);
						}
						if (field === "OurCompany") {
							this.set("SupplierBillingInfo", null);
						}
					}
				},

				/**
				 * ### ######## Account ######### ######## (##### ##### ########) ########## ###### # ######
				 * ##### ############### ######## ####### ########## ## ############# ## ######### ########
				 * @inheritdoc BPMSoft.BaseViewModel#set
				 * @overriden
				 */
				set: function(key, value) {
					if (key === "Account") {
						var currentValue = this.get(key);
						var currentValueId = currentValue ? currentValue.value : "";
						var valueId = value ? value.value : "";
						if (currentValueId === valueId) {
							return;
						}
					}
					this.callParent(arguments);
				},

				/**
				 * Creates filter for detail Email.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Group filters.
				 */
				emailDetailFilter: function() {
					var recordId = this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("ContractNotNull", this.BPMSoft.createColumnIsNotNullFilter("Contract"));
					filterGroup.add("ContractConnection", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Contract", recordId));
					filterGroup.add("ActivityType", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Number",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Number",
						"textSize": 0,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Owner",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						},
						"bindTo": "Owner",
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "StartDate",
						"textSize": 0,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "Type",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Type",
						"textSize": 0,
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "EndDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "EndDate",
						"textSize": 0,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "State",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "State",
						"textSize": 0,
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.GeneralInfoTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "group",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.groupCaption"
						},
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "group_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "group",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Account",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Account",
						"enabled": true
					},
					"parentName": "group_gridLayout",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "CustomerBillingInfo",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.CustomerBillingInfoTip"}
						},
						"bindTo": "CustomerBillingInfo",
						"contentType": this.BPMSoft.ContentType.ENUM,
						"enabled": true
					},
					"parentName": "group_gridLayout",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Contact",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Contact",
						"enabled": true
					},
					"parentName": "group_gridLayout",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "OurCompany",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "OurCompany",
						"textSize": "Default",
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "group_gridLayout",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "SupplierBillingInfo",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.SupplierBillingInfoTip"}
						},
						"bindTo": "SupplierBillingInfo",
						"contentType": this.BPMSoft.ContentType.ENUM,
						"enabled": true
					},
					"parentName": "group_gridLayout",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "ContractConnectionsGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.ContractConnectionsGroupCaption"
						},
						"controlConfig": {
							"collapsed": false
						}
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ContractConnectionsBlock",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "ContractConnectionsGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Parent",
					"values": {
						"bindTo": "Parent",
						"layout": {
							"column": 0,
							"row": 0
						},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ParentTip"}
						}
					},
					"parentName": "ContractConnectionsBlock",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "NotesAndFilesTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.NotesAndFilesTab"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "Files",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ContractNotesControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.NotesGroupCaption"
						},
						"controlConfig": {
							"collapsed": false
						}
					},
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Notes",
					"values": {
						"contentType": this.BPMSoft.ContentType.RICH_TEXT,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"imageLoaded": {
								"bindTo": "insertImagesToNotes"
							},
							"images": {
								"bindTo": "NotesImagesCollection"
							}
						}
					},
					"parentName": "ContractNotesControlGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.HistoryTab"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Activities",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "HistoryTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "EmailDetailV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "SubordinateContracts",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "ContractVisaTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ContractVisaTabCaption"},
						"items": []
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "ContractVisaTab",
					"name": "ContractPageVisaTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ContractVisaTab",
					"propertyName": "items",
					"name": "Visa",
					"lableConfig": {"visible": false},
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "ContractPageVisaTabContainer",
					"propertyName": "items",
					"name": "ContractPageVisaBlock",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"OurCompany": {
					"FiltrationByType": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": false,
						"baseAttributePatch": "Type",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.CONSTANT,
						"value": ConfigurationConstants.AccountType.OurCompany
					}
				},
				"Parent": {
					"FiltrationParentByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Account",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					},
					"FiltrationParentBySupplier": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "OurCompany",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "OurCompany"
					},
					"FiltrationParentByParent": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": false,
						"baseAttributePatch": "Id",
						"comparisonType": this.BPMSoft.ComparisonType.NOT_EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Id"
					}
				},
				"SupplierBillingInfo": {
					"FiltrationSupplierBillingByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Account",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "OurCompany"
					},
					"BindParameterEnabledSupplierBillingInfoToSupplier": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "OurCompany"
								},
								"comparisonType": BPMSoft.ComparisonType.IS_NOT_NULL
							}
						]
					}
				},
				"CustomerBillingInfo": {
					"BindParameterEnabledCustomerBillingInfoToAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Account"
								},
								"comparisonType": BPMSoft.ComparisonType.IS_NOT_NULL
							}
						]
					}
				},
				"Contact": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				}
			}
		};
	});
