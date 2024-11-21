define("CasePage", ["BusinessRuleModule", "ProcessModuleUtilities", "CasePageResources", "CaseServiceContractUtility",
			"CaseConfItemUtility"],
		function(BusinessRuleModule, ProcessModuleUtilities, resourses) {
			return {
				entitySchemaName: "Case",
				details: /**SCHEMA_DETAILS*/{
					"ConfItemInCase": {
						"schemaName": "ConfItemCaseDetail",
						"entitySchemaName": "ConfItemInCase",
						"filter": {
							"detailColumn": "Case",
							"masterColumn": "Id"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "ConfItem",
						"values": {
							"layout": {
								"column": 0,
								"row": 7,
								"colSpan": 24,
								"rowSpan": 1
							},
							"controlConfig": {
								"prepareList": {"bindTo": "onPrepareConfItem"}
							}
						},
						"parentName": "ProfileContainer",
						"propertyName": "items"
					},
					{
						"operation": "merge",
						"name": "CaseGroup",
						"values": {
							"layout": {
								"column": 0,
								"row": 8,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "CaseOwner",
						"values": {
							"layout": {
								"column": 0,
								"row": 9,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "CaseAssignToMeButton",
						"values": {
							"layout": {
								"column": 0,
								"row": 10,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "insert",
						"name": "SupportLevelLabel",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "getSupportLevelLabel"},
							"markerValue": "SupportLevelLabel",
							"visible": {"bindTo": "isEditMode"}
						},
						"parentName": "CaseProfileInfoContainer",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "SupportLevelValue",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "getSupportLevelValue"},
							"markerValue": "SupportLevelValue",
							"visible": {"bindTo": "isEditMode"}
						},
						"parentName": "CaseProfileInfoContainer",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "merge",
						"name": "NewCaseProfileInfoContainer",
						"values": {
							"layout": {
								"column": 0,
								"row": 11,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "insert",
						"name": "Change",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Change"
						},
						"parentName": "SolutionTab_gridLayout",
						"propertyName": "items"
					},
					{
						"operation": "merge",
						"name": "SolutionFieldContainer",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24,
								"rowSpan": 1
							},
							"wrapClass": ["control-width-15 control-left solution-field-container"]
						}
					},
					{
						"operation": "insert",
						"name": "SolvedOnSupportLevel",
						"values": {
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 24,
								"rowSpan": 1
							},
							"bindTo": "SolvedOnSupportLevel",
							"contentType": this.BPMSoft.ContentType.ENUM,
							"enabled": false
						},
						"parentName": "SolutionTab_gridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "ServicePact",
						"values": {
							"layout": {
								"column": 0,
								"row": 4,
								"colSpan": 24,
								"rowSpan": 1
							},
							"bindTo": "ServicePact",
							"tip": {
								"content": {"bindTo": "Resources.Strings.ServicePactTipMessage"}
							},
							"contentType": this.BPMSoft.ContentType.ENUM
						},
						"parentName": "ProfileContainer",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "SupportLevel",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "SupportLevel",
							"contentType": this.BPMSoft.ContentType.ENUM,
							"enabled": false
						},
						"parentName": "CaseInformation_gridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "ConfItemInCase",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "CaseInformationTab",
						"propertyName": "items",
						"index": 3
					}
				]/**SCHEMA_DIFF*/,
				mixins: {
					/**
					 * @class CaseServiceContractUtility implements work with service contracts on page.
					 */
					CaseServiceContractUtility: "BPMSoft.CaseServiceContractUtility",
					/**
					 * @class CaseConfItemUtility implements work with configuration item on page.
					 */
					CaseConfItemUtility: "BPMSoft.CaseConfItemUtility"
				},
				attributes: {
					"ServicePact": {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							filter: function() {
								var suitableServicePacts = this.get("SuitableServicePacts");
								var availableServicePactIds = [];
								Ext.Array.each(suitableServicePacts, function(item) {
									availableServicePactIds.push(item.Id);
								});
								availableServicePactIds = availableServicePactIds.length
										? availableServicePactIds
										: [BPMSoft.GUID_EMPTY];
								return this.BPMSoft.createColumnInFilterWithParameters("Id", availableServicePactIds);
							}
						},
						dependencies: [
							{
								columns: ["Account", "Contact"],
								methodName: "setServicePact"
							}
						]
					},
					"ServiceItem": {
						lookupListConfig: {
							filter: function() {
								return this.getServiceItemFilters();
							}
						},
						dependencies: [
							{
								columns: ["ServicePact"],
								methodName: "onServicePactChanged"
							},
							{
								columns: ["ServiceCategory"],
								methodName: "onServiceCategoryChanged"
							},
							{
								columns: ["Category"],
								methodName: "onCategoryChanged"
							}
						]
					},
					"ServiceCategory": {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP
					},
					"ConfItem": {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						hideActions: true,
						lookupListConfig: {
							filter: function() {
								return this.getConfItemFilters();
							}
						}
					}
				},
				messages: {
					/**
					 * @message SetParametersInfo
					 * Set parameters info from escalation page.
					 */
					"SetParametersInfo": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message UpdateConfItemOnPage
					 * Set major configuration item from configuartion item detail.
					 */
					"UpdateConfItemOnPage": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message GetCaseStatus
					 * Send information about case status to section.
					 */
					"SendCaseStatusToSection": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {
					/**
					 * Get support level label.
					 * @protected
					 * @virtual
					 * @returns {String} Support level label.
					 */
					getSupportLevelLabel: function() {
						var supportLevel = this.get("SupportLevel");
						var caption = this.get("Resources.Strings.SupportLevelCaption") + ": ";
						return supportLevel ? caption : "";
					},

					/**
					 * Get support level value.
					 * @protected
					 * @virtual
					 * @returns {String} Support level value.
					 */
					getSupportLevelValue: function() {
						var supportLevel = this.get("SupportLevel");
						return supportLevel ? supportLevel.displayValue : "";
					},

					/**
					 * Open service model by case service.
					 * @protected
					 * @virtual
					 */
					openServiceModelModule: function() {
						var serviceItem = this.get("ServiceItem");
						if (!serviceItem) {
							this.save();
							return;
						}
						var defaultValues = [{
							"id": serviceItem.value,
							"schemaName": this.getColumnByName("ServiceItem").name,
							"name": serviceItem.displayValue
						}];
						this.openCardInChain({
							"schemaName": "ServiceModelPage",
							"moduleId": this.sandbox.id + "_ServiceModelPage",
							"isSeparateMode": false,
							"defaultValues": defaultValues
						});
					},

					/**
					 * @inheritdoc this.BPMSoft.CasePage#getCaseColumnNamesToCopy
					 * @overridden
					 */
					getCaseColumnNamesToCopy: function() {
						var columns = this.callParent();
						columns.push("ServicePact");
						return columns;
					},

					/**
					 * @inheritdoc this.BPMSoft.CasePage#addGroupEsqFilters
					 * @overridden
					 */
					addGroupEsqFilters: function(esq) {
						this.callParent(arguments);
						var servicePactFilters = this.mixins.CaseServiceContractUtility.getOwnerDependenceFilters(this);
						if (servicePactFilters.collection.length) {
							esq.filters.add("ServicePactFilters", servicePactFilters);
						}
					},

					/**
					 * @inheritdoc this.BPMSoft.BasePageV2#getActions
					 * @overridden
					 */
					getActions: function() {
						var defaultMenuItems = this.callParent(arguments);
						var actionMenuItems = Ext.create("BPMSoft.BaseViewModelCollection");
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Tag": "runEscalation",
							"Caption": resourses.localizableStrings.EscalationTitle,
							"Enabled": {"bindTo": "RunEscalationEnabled"}
						}));
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Tag": "runReclassification",
							"Caption": resourses.localizableStrings.ReclassificationTitle,
							"Enabled": {"bindTo": "RunReclassificationEnabled"}
						}));
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Tag": "runSearchForSimilarCases",
							"Caption": resourses.localizableStrings.SearchForSimilarCasesButtonCaption,
							"Enabled": !this.isNewMode()
						}));
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Tag": "openServiceModelModule",
							"Caption": resourses.localizableStrings.OpenServiceModelByServiceModuleCaption,
							"Enabled": !this.isNewMode()
						}));
						actionMenuItems.addItem(this.getButtonMenuSeparator());
						defaultMenuItems.each(function(item) {
							actionMenuItems.addItem(item);
						});
						return actionMenuItems;
					},

					/**
					 * Run process "Search for similar cases".
					 * @protected
					 * @virtual
					 */
					runSearchForSimilarCases: function() {
						var parameters = {
							"IncidentId": this.get("Id")
						};
						ProcessModuleUtilities.runProcess("SearchForParent", parameters, function() {
							this.hideBodyMask();
						}, this);
					},

					/**
					 * Run Reclassification.
					 * @protected
					 * @virtual
					 */
					runReclassification: function() {
						var runReclassificationPageConfig = this.getRunReclassificationConfig();
						this.openCardInChain(runReclassificationPageConfig);
					},

					/**
					 * Returns run Reclassification config.
					 * @protected
					 * @virtual
					 * @return {Array} Run Reclassification config.
					 */
					getRunReclassificationConfig: function() {
						var defaultValues = this.getRunReclassificationDefaultValues();
						return {
							"schemaName": "ReclassificationEditPage",
							"operation": "add",
							"primaryColumnValue": null,
							"moduleId": this.sandbox.id + "_ReclassificationEditPage",
							"isSeparateMode": false,
							"isInChain": true,
							"defaultValues": defaultValues
						};
					},

					/**
					 * Returns Reclassification default values.
					 * @protected
					 * @virtual
					 * @return {Array} Reclassification default values.
					 */
					getRunReclassificationDefaultValues: function() {
						var defaultValues = [];
						var propertyNames = this.prepareReclassificationPropertyNames();
						BPMSoft.each(propertyNames, function(name) {
							this.addDefaultValue(defaultValues, name);
						}, this);
						return defaultValues;
					},

					/**
					 * Prepares Reclassification properties name.
					 * @protected
					 * @virtual
					 * @return {Array} Reclassification properties name.
					 */
					prepareReclassificationPropertyNames: function() {
						return ["Id", "Contact", "Account", "Category", "ServiceItem", "ServicePact", "ServiceCategory"];
					},

					/**
					 * Run Escalation.
					 * @protected
					 * @virtual
					 */
					runEscalation: function() {
						var defaultValues = [];
						var scope = this;
						var propertyNames = ["Id", "Group", "Owner", "Contact", "SupportLevel", "ServiceItem"];
						BPMSoft.each(propertyNames, function(name) {
							scope.addDefaultValue(defaultValues, name);
						}, this);
						this.openCardInChain({
							"schemaName": "EscalationEditPage",
							"operation": "add",
							"primaryColumnValue": null,
							"moduleId": this.sandbox.id + "_EscalationEditPage",
							"isSeparateMode": false,
							"isInChain": true,
							"defaultValues": defaultValues
						});
					},

					/**
					 * Run Escalation.
					 * @param {Array} defaultValues Collection default values for page.
					 * @param {String} propertyName Property name of default values.
					 * @protected
					 * @virtual
					 */
					addDefaultValue: function(defaultValues, propertyName) {
						var propertyNameValue = this.get(propertyName);
						if (!propertyNameValue) {
							return;
						}
						defaultValues.push({
							name: propertyName,
							value: propertyNameValue.value
						});
					},

					/**
					 * @inheritdoc this.BPMSoft.BasePageV2#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.initPageMessages();
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onSaved
					 * @overridden
					 */
					onSaved: function() {
						this.callParent(arguments);
						if (!this.get("IsCloseOnSave")) {
							this.publishCaseStatusForSection();
						}
					},

					/**
					 * @inheritdoc this.BPMSoft.BasePageV2#onEntityInitialized
					 * @overridden
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						this.publishCaseStatusForSection();
					},

					/**
					 * Publishes case status for case section.
					 * @protected
					 */
					publishCaseStatusForSection: function() {
						var status = this.get("Status");
						if (!status) {
							return;
						}
						if (this.get("IsSeparateMode")) {
							var runEscalationEnabled = !status.IsFinal && !status.IsResolved;
							this.set("RunEscalationEnabled", runEscalationEnabled);
							this.set("RunReclassificationEnabled", runEscalationEnabled);
						} else {
							this.sandbox.publish("SendCaseStatusToSection", status, [this.sandbox.id]);
						}
					},

					/**
					 * Set parameters info from escalation page.
					 * @param {Object} parameters Property name of default values.
					 */
					setParametersInfo: function(parameters) {
						if (!parameters) {
							return;
						}
						this.BPMSoft.each(parameters, function(value, name) {
							if (this.get(name) !== value) {
								this.set(name, value);
							}
						}, this);
						if (parameters["ServicePact"] || parameters["ServiceItem"]) {
							this.set("NeedSaveAfterRecalculation", true);
							this.recalculateServiceTerms();
						} else {
							this.save();
						}
					},

					/**
					 * Initializes the required messages for the page.
					 * @protected
					 */
					initPageMessages: function() {
						var escalationEditPageId = this.sandbox.id + "_EscalationEditPage";
						var reclassificationEditPageId = this.sandbox.id + "_ReclassificationEditPage";
						this.sandbox.subscribe("SetParametersInfo", this.setParametersInfo, this,
								[escalationEditPageId, reclassificationEditPageId]);
						this.sandbox.subscribe("UpdateConfItemOnPage", this.onUpdateConfItemOnPage, this);
					},

					/**
					 * Updates configuration item value.
					 * @protected
					 * @param {Object} value Major configuration item value.
					 */
					onUpdateConfItemOnPage: function(value) {
						this.set("ConfItem", value);
						this.save();
					},

					/**
					 * @inheritdoc this.BPMSoft.BasePageV2#updateOriginals
					 * @overridden
					 */
					updateOriginals: function(isNull) {
						this.callParent([isNull]);
						this.set("OriginalSolvedOnSupportLevel", isNull ? null : this.get("SolvedOnSupportLevel"));
					},

					/**
					 * Starts recalculating resolution date from pause state.
					 * @protected
					 * @param {Boolean} isResolution Is Resolution state
					 */
					calculateDateAfterPause: function(isResolution) {
						var caseId = this.get("Id");
						var remainsTicks = isResolution ? this.get("SolutionRemains") : this.get("ResponseRemains");
						var config = {
							serviceName: "TermCalculationService",
							methodName: "GetDateAfterPause",
							data: {
								request: {
									RemainsTicks: remainsTicks,
									IsResolution: isResolution,
									CaseId: caseId
								}
							}
						};
						if (!isResolution) {
							return;
						}
						this.callService(config, this.onDateAfterPauseCalculated, this);
					},

					/**
					 * Starts remaining time calculating.
					 * @protected
					 * @param {Boolean} isResolution Is Resolution state
					 */
					calculateRemains: function(isResolution) {
						var caseId = this.get("Id");
						var sourceDateTime = isResolution ? this.get("SolutionDateGetter") : this.get("ResponseDateGetter");
						var config = {
							serviceName: "TermCalculationService",
							methodName: "GetRemainsTicks",
							data: {
								request: {
									SourceDateTime: JSON.parse(this.BPMSoft.encodeDate(sourceDateTime)),
									IsResolution: isResolution,
									CaseId: caseId
								}
							}
						};
						if (!isResolution) {
							return;
						}
						this.callService(config, this.onRemainsCalculated, this);
					},

					/**
					 * Returns determine service pact service config.
					 * @protected
					 * @returns {Object}
					 */
					getCallDetermineServiceConfig: function() {
						var contact = this.get("Contact");
						var account = this.get("Account");
						if (!contact && !account) {
							return null;
						}
						var config = {
							serviceName: "ServicePactService",
							methodName: "GetSuitableServicePacts",
							data: {
								request: {
									ContactId: contact ? contact.value : this.BPMSoft.GUID_EMPTY,
									AccountId: account ? account.value : this.BPMSoft.GUID_EMPTY
								}
							}
						};
						return config;
					},

					/**
					 * Set service pact from mixin.
					 * @protected
					 * @virtual
					 */
					establishServicePact: function() {
						this.setServicePact(arguments);
					},

					/**
					 * @inheritdoc this.BPMSoft.CasePageV2#setInitialValues
					 * @overriden
					 */
					setInitialValues: function() {
						this.callParent(arguments);
						this.set("SuitableServicePacts", []);
						this.establishServicePact();
					},

					/**
					 * On service category field value change handler.
					 * @protected
					 */
					onServiceCategoryChanged: function() {
						var serviceItem = this.get("ServiceItem");
						if ((serviceItem && (this.changedValues.ServiceCategory || !this.isNew)) ||
								(this.changedValues.ServiceCategory && this.changedValues.ServiceItem)) {
							this.set("ServiceItem", null);
						}
					},

					/**
					 * Returns calculating dates service config.
					 * @protected
					 * @returns {Object} Service input config
					 */
					getCallTermCalculationServiceConfig: function() {
						return this.mixins.CaseServiceContractUtility.getCallTermCalculationServiceConfig.call(this);
					},

					/**
					 * @inheritdoc this.BPMSoft.CaseServiceUtility#prepareServiceTermCalcultorConditions
					 * @overriden
					 */
					prepareServiceTermCalcultorConditions: function() {
						var conditions = this.callParent(arguments);
						if (conditions == null) {
							return null;
						}
						var servicePact = this.get("ServicePact");
						if (!servicePact) {
							return conditions;
						}
						conditions.push(this.prepareConditionItem("ServicePact", servicePact.value));
						return conditions;
					}
				},
				rules: {
					"SolvedOnSupportLevel": {
						"EnableSolvedOnSupportLevelOnResolvedState": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status",
									attributePath: "IsResolved"
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: true
								}
							}]
						}
					},
					"ServicePact": {
						"EnableServicePactOnAdd": {
							ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							property: BusinessRuleModule.enums.Property.ENABLED,
							conditions: [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "OriginalServiceItem"
								},
								"comparisonType": this.BPMSoft.ComparisonType.IS_NULL
							}]
						}
					},
					"ServiceItem": {
						"BindingServiceItemToServicePact": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"logical": this.BPMSoft.LogicalOperatorType.AND,
							"property": BusinessRuleModule.enums.Property.ENABLED,
							"conditions": [
								{
									"leftExpression": {
										"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										"attribute": "ServicePact"
									},
									"comparisonType": this.BPMSoft.ComparisonType.IS_NOT_NULL
								},
								{
									"leftExpression": {
										"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										"attribute": "OriginalServiceItem"
									},
									"comparisonType": this.BPMSoft.ComparisonType.IS_NULL
								}
							]
						}
					}
				},
				userCode: {}
			};
		});
