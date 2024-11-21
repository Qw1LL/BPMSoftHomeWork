define("LeadPageV2", ["BusinessRuleModule", "ConfigurationConstants", "BaseFiltersGenerateModule", "css!LeadCSS"],
		function(BusinessRuleModule, ConfigurationConstants, BaseFiltersGenerateModule) {
			return {
				entitySchemaName: "Lead",
				attributes: {
					"SalesOwner": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
					}
				},
				details: /**SCHEMA_DETAILS*/{
					Calls: {
						schemaName: "CallDetail",
						filter: {
							masterColumn: "Id",
							detailColumn: "Lead"
						}
					},
					Activities: {
						schemaName: "ActivityDetailV2",
						filter: {
							detailColumn: "Lead"
						},
						defaultValues: {
							Lead: {
								masterColumn: "Id"
							}
						}
					}
				}/**SCHEMA_DETAILS*/,
				methods: {

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getActions
					 * @overridden
					 */
					getActions: function() {
						var actionMenuItems = this.callParent(arguments);
						var disqualifyMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
						disqualifyMenuItems.addItem(this.getButtonMenuItem({
							Caption: {bindTo: "Resources.Strings.DisqualifyLeadLost"},
							Tag: "disqualifyLost"
						}));
						disqualifyMenuItems.addItem(this.getButtonMenuItem({
							Caption: {bindTo: "Resources.Strings.DisqualifyLeadNoConnection"},
							Tag: "disqualifyNoConnection"
						}));
						disqualifyMenuItems.addItem(this.getButtonMenuItem({
							Caption: {bindTo: "Resources.Strings.DisqualifyLeadNotInterested"},
							Tag: "disqualifyNotInterested"
						}));
						return actionMenuItems;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#save
					 * @overridden
					 */
					save: function() {
						if (!this.checkRequiredActionColumns()) {
							return;
						}
						return this.callParent(arguments);
					},

					/**
					 * Opens lead qualification page.
					 */
					qualifyLead: function() {
						var recordId = this.get("Id");
						var token = "CardModuleV2/LeadQualificationPageV2/edit/" + recordId;
						this.sandbox.publish("PushHistoryState", {hash: token});
					},

					/**
					 * Checks required parameters.
					 * @return {Boolean} Validation result.
					 */
					checkRequiredActionColumns: function() {
						var account = this.get("Account");
						var contact = this.get("Contact");
						if (!account && !contact) {
							this.showInformationDialog(this.get("Resources.Strings.RequiredFieldsMessage"));
							return false;
						}
						return true;
					},

					/**
					 * Saves lead.
					 */
					saveLead: function() {
						this.showBodyMask();
						if (!this.checkRequiredActionColumns()) {
							this.hideBodyMask();
							return;
						}
						this.saveEntity(this.qualifyLead, this);
					},

					/**
					 * Launches "Disqualify" action.
					 * @param {Guid} statusId Qualification status.
					 */
					disqualifyLead: function(statusId) {
						if (!this.checkRequiredActionColumns()) {
							return;
						}
						this.showConfirmationDialog(this.get("Resources.Strings.DisqualifyLeadActionMessage"),
							function(returnCode) {
								if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.loadLookupDisplayValue("Status", statusId);
								}
							}, ["yes", "no"]);
					},

					/**
					 * Launches "Disqualify" action with the "Lost" status.
					 */
					disqualifyLost: function() {
						this.disqualifyLead(ConfigurationConstants.Lead.Status.QualifiedAsLost);
					},

					/**
					 * Launches "Disqualify" action with the "No connection" status.
					 */
					disqualifyNoConnection: function() {
						this.disqualifyLead(ConfigurationConstants.Lead.Status.QualifiedAsNoConnection);
					},

					/**
					 * Launches "Disqualify" action with the "Not interested" status.
					 */
					disqualifyNotInterested: function() {
						this.disqualifyLead(ConfigurationConstants.Lead.Status.QualifiedAsNotInterested);
					},

					/**
					 * Updates links in the related activities.
					 * @param {String} linkColumnName Name of the column to be updated.
					 * @param {Guid} recordId Unique identifier.
					 */
					updateActivitiesLink: function(linkColumnName, recordId) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Activity"
						});
						esq.addColumn("Id");
						esq.filters.add("LeadFilter",
							esq.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Lead", this.get("Id")));
						esq.getEntityCollection(function(result) {
							var batchQuery = Ext.create("BPMSoft.BatchQuery");
							var collection = result.collection;
							collection.each(function(item) {
								var activityId = item.get("Id");
								var update = Ext.create("BPMSoft.UpdateQuery", {
									rootSchemaName: "Activity"
								});
								update.enablePrimaryColumnFilter(activityId);
								update.setParameterValue(linkColumnName, recordId, this.BPMSoft.DataValueType.GUID);
								batchQuery.add(update);
							});
							batchQuery.execute();
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
					 * @overridden
					 */
					onEntityInitialized: function() {
						var account = this.get("Account");
						if (this.BPMSoft.isGUID(account)) {
							this.set("Account", null);
							this.loadLookupDisplayValue("Account", account);
						}
						var contact = this.get("Contact");
						if (this.BPMSoft.isGUID(contact)) {
							this.set("Contact", null);
							this.loadLookupDisplayValue("Contact", contact);
						}
						var queryParams = this.sandbox.publish("GetHistoryState");
						if (queryParams) {
							var createdmessage = "";
							var queryParamsState = queryParams.state;
							if (queryParamsState.Qualified) {
								if (queryParamsState.contactName && queryParamsState.isContactQualifyAsNew) {
									createdmessage += Ext.String.format(this.get("Resources.Strings.CreatedContactMessage"),
										queryParamsState.contactName);
									queryParamsState.contactName = null;
								}
								if (queryParamsState.accountName && queryParamsState.isAccountQualifyAsNew) {
									if (createdmessage) {
										createdmessage += " ";
									}
									createdmessage += Ext.String.format(this.get("Resources.Strings.CreatedAccountMessage"),
										queryParamsState.accountName);
									queryParamsState.accountName = null;
								}
								if (createdmessage) {
									this.showInformationDialog(createdmessage);
								}
								if (queryParamsState.contactId) {
									this.updateActivitiesLink("Contact", queryParamsState.contactId);
								}
								if (queryParamsState.accountId) {
									this.updateActivitiesLink("Account", queryParamsState.accountId);
								}
								queryParamsState.Qualified = false;
								var currentHash = queryParams.hash;
								var newState = this.BPMSoft.deepClone(queryParams);
								this.sandbox.publish("ReplaceHistoryState", {
									stateObj: newState,
									pageTitle: null,
									hash: currentHash.historyState,
									silent: true
								});
							}
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseModulePageV2#getFileEntitySchemaName
					 * @overridden
					 */
					getFileEntitySchemaName: function() {
						return "FileLead";
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "LeadEngagementTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1,
						"values": {
							"caption": {"bindTo": "Resources.Strings.LeadEngagementTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadEngagementTab",
						"name": "LeadEngagementTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadEngagementTabContainer",
						"propertyName": "items",
						"name": "LeadPageSourceGroup",
						"alias": {
							"name": "LeadPageSourceInfo"
						},
						"values": {
							"caption": {bindTo: "Resources.Strings.SourceGroupCaption"},
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "LeadPageGeneralInfoTabContainer",
						"propertyName": "items",
						"name": "LeadPageCategorizationContainer",
						"values": {
							"caption": {"bindTo": "Resources.Strings.LeadPageCategorizationBlockCaption"},
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"controlConfig": {"collapsed": false}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageGeneralInfoTabContainer",
						"propertyName": "items",
						"name": "LeadPageCommunicationContainer",
						"values": {
							"caption": {bindTo: "Resources.Strings.LeadPageCommunicationBlockCaption"},
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"controlConfig": {"collapsed": false}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageGeneralInfoTabContainer",
						"propertyName": "items",
						"name": "LeadPageAddressContainer",
						"values": {
							"caption": {"bindTo": "Resources.Strings.LeadPageAddressBlockCaption"},
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"controlConfig": {"collapsed": false}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageSourceGroup",
						"propertyName": "items",
						"name": "LeadPageSourceInfoBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCategorizationContainer",
						"propertyName": "items",
						"name": "LeadPageCategorizationBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationContainer",
						"propertyName": "items",
						"name": "LeadPageCommunicationBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressContainer",
						"propertyName": "items",
						"name": "LeadPageAddressBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageSourceInfoBlock",
						"propertyName": "items",
						"name": "LeadMedium",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageSourceInfoBlock",
						"propertyName": "items",
						"name": "LeadSource",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageSourceInfoBlock",
						"propertyName": "items",
						"name": "RegisterMethod",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageGeneralBlock",
						"propertyName": "items",
						"name": "Title",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 10
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageGeneralBlock",
						"propertyName": "items",
						"name": "FullJobTitle",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCategorizationBlock",
						"propertyName": "items",
						"name": "Industry",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCategorizationBlock",
						"propertyName": "items",
						"name": "AnnualRevenue",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "MobilePhone",
						"values": {
							"layout": {
								"className": "BPMSoft.PhoneEdit",
								"column": 0,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "Email",
						"values": {
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCategorizationBlock",
						"propertyName": "items",
						"name": "EmployeesNumber",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressBlock",
						"propertyName": "items",
						"name": "Country",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "Website",
						"values": {
							"layout": {
								"column": 0,
								"row": 4,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "BusinesPhone",
						"values": {
							"className": "BPMSoft.PhoneEdit",
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "DoNotUsePhone",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "DoNotUseSMS",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "Fax",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "DoNotUseFax",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageCommunicationBlock",
						"propertyName": "items",
						"name": "DoNotUseEmail",
						"values": {
							"layout": {
								"column": 13,
								"row": 3,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressBlock",
						"propertyName": "items",
						"name": "AddressType",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressBlock",
						"propertyName": "items",
						"name": "Region",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressBlock",
						"propertyName": "items",
						"name": "City",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressBlock",
						"propertyName": "items",
						"name": "Zip",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageAddressBlock",
						"propertyName": "items",
						"name": "Address",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageDealInformationBlock",
						"propertyName": "items",
						"name": "MeetingDate",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageDealInformationBlock",
						"propertyName": "items",
						"name": "DecisionDate",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 6
							},
							"dataValueType": BPMSoft.DataValueType.DATE
						}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "Calls",
						"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "Activities",
						"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
					},
				]/**SCHEMA_DIFF*/,
				rules: {
					"Region": {
						"FiltrationRegionByCountry": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							autoClean: true,
							baseAttributePatch: "Country",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Country"
						},
						"EnabledRegion": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"City": {
						"FiltrationCityByCountry": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							autoClean: true,
							baseAttributePatch: "Country",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Country"
						},
						"FiltrationCityByRegion": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							autoClean: true,
							baseAttributePatch: "Region",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Region"
						},
						"EnabledCity": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"Title": {
						"EnabledTitle": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"Industry": {
						"EnabledIndustry": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"AnnualRevenue": {
						"EnabledAnnualRevenue": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"FullJobTitle": {
						"EnabledFullJobTitle": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"BusinesPhone": {
						"EnabledBusinesPhone": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"DoNotUsePhone": {
						"EnabledDoNotUsePhone": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"DoNotUseSMS": {
						"EnabledDoNotUseSMS": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"Fax": {
						"EnabledFax": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"DoNotUseFax": {
						"EnabledDoNotUseFax": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"DoNotUseEmail": {
						"EnabledDoNotUseEmail": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"AddressType": {
						"EnabledAddressType": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"Zip": {
						"EnabledZip": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					},
					"Address": {
						"EnabledAddress": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ConfigurationConstants.Lead.Status.New
								}
							}]
						}
					}
				}
			};
		});
