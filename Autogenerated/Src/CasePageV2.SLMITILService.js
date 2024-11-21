define("CasePageV2", ["BusinessRuleModule", "HierarchicalRecordsUtilities"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "Case",
			mixins: {
				HierarchicalRecordsUtilities: "BPMSoft.HierarchicalRecordsUtilities"
			},
			details: /**SCHEMA_DETAILS*/{
				"ChildCase": {
					"schemaName": "CaseChildCaseDetail",
					"entitySchemaName": "Case",
					"filter": {
						"detailColumn": "ParentCase",
						"masterColumn": "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ServicePact",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "ServicePact",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "ServiceItem",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "merge",
					"name": "Group",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "merge",
					"name": "Owner",
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
					"name": "AssignToMeButton",
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
					"operation": "insert",
					"name": "ResolutionTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ResolutionTabCaption"},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ResolutionContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["resolutionContainer"]},
						"items": []
					},
					"parentName": "ResolutionTab",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ResolutionContainer_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "ResolutionContainer",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "SupportLevelContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 10,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["caseCreatedOnContainer"]
						},
						"items": []
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SupportLevelValue",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getSupportLevelLabel"},
						"markerValue": "SupportLevelValue",
						"visible": {"bindTo": "isEditMode"}
					},
					"parentName": "SupportLevelContainer",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "CreatedOnContainer",
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
					"operation": "remove",
					"name": "ClosureCode"
				},
				{
					"operation": "insert",
					"name": "ClosureCode",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ClosureCode",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "ResolutionContainer_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ParentCase",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ParentCase",
						"controlConfig": {
							"loadVocabulary": {"bindTo": "onLoadParentCase"},
							"prepareList": {"bindTo": "onPrepareParentCase"}
						}
					},
					"parentName": "ResolutionContainer_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Solution",
					"values": {
						"contentType": this.BPMSoft.ContentType.LONG_TEXT,
						"layout": {
							"column": 0,
							"row": 2,
							"rowSpan": 1,
							"colSpan": 24
						},
						"bindTo": "Solution"
					},
					"parentName": "ResolutionContainer_gridLayout",
					"propertyName": "items"
				},

				{
					"operation": "insert",
					"name": "SolvedOnSupportLevel",
					"values": {
						"layout": {
							"column": 13,
							"row": 5,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SolvedOnSupportLevel",
						"contentType": this.BPMSoft.ContentType.ENUM,
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},

				{
					"operation": "insert",
					"name": "ChildCase",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ParametersTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "move",
					"name": "FeedbackControlGroup",
					"parentName": "ResolutionContainer",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "move",
					"name": "KnowledgeBaseCase",
					"parentName": "ResolutionContainer",
					"propertyName": "items",
					"index": 3
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"ServicePact": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							var suitableServicePacts = this.get("SuitableServicePacts");
							var availableServicePactIds = [];
							this.Ext.Array.each(suitableServicePacts, function(item) {
								availableServicePactIds.push(item.Id);
							});
							availableServicePactIds = availableServicePactIds.length
								? availableServicePactIds
								: [this.BPMSoft.GUID_EMPTY];
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
							columns: ["Category"],
							methodName: "onCategoryChanged"
						}
					]
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.setInitialValues();
				},

				/**
				 * Sets initial values on page init.
				 * @protected
				 */
				setInitialValues: function() {
					this.set("SuitableServicePacts", []);
					this.setServicePact();
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
				 * Sets resolution planned date and reset estimated by resolution.
				 * @protected
				 * @param {Object} responseObject
				 */
				onDateAfterPauseCalculated: function(responseObject) {
					this.set("SolutionDate", new Date(parseInt(responseObject.GetDateAfterPauseResult.substr(6), 10)));
					this.set("SolutionRemainsSetter", null);
				},

				/**
				 * Returns service item filter group by service pact.
				 * @protected
				 * @returns {BPMSoft.FilterGroup} Filter group
				 */
				getServiceItemFilters: function() {
					var filtersCollection = this.BPMSoft.createFilterGroup();
					var servicePact = this.get("ServicePact");
					if (!servicePact) {
						return filtersCollection;
					}
					filtersCollection.add("ServiceItemByServicePactFilter",
						this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"[ServiceInServicePact:ServiceItem].ServicePact", servicePact.value));
					filtersCollection.add("ServiceItemByActiveServiceStatusFilter",
						this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"[ServiceInServicePact:ServiceItem].Status.Active", true));
					var caseCategoryFilter = this.getCaseCategoryFilter();
					if (caseCategoryFilter) {
						filtersCollection.add("ServiceItemByCaseCategory", caseCategoryFilter);
					}
					var serviceCategory = this.get("ServiceCategory");
					if (serviceCategory) {
						filtersCollection.add("ServiceItemByCategory",
							this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Category", serviceCategory.value));
					}
					return filtersCollection;
				},

				/**
				 * Returns service item filter by case category.
				 * @protected
				 * @returns {BPMSoft.Filter} Filter group
				 */
				getCaseCategoryFilter: function() {
					var caseCategory = this.get("Category");
					if (!caseCategory) {
						return null;
					}
					return this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"CaseCategory", caseCategory.value);
				},

				/**
				 * On service pact field change handler.
				 * @protected
				 */
				onServicePactChanged: function() {
					var servicePact = this.get("ServicePact");
					var serviceItem = this.get("ServiceItem");
					if (!servicePact) {
						this.set("ServiceItem", null);
						this.set("ServiceCategory", null);
						return;
					}
					if (this.changedValues.ServicePact && serviceItem) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ServiceItem"
						});
						esq.addColumn("Id");
						esq.filters.add("servicePactAndStatusFilter", this.getServiceItemFilters());
						esq.filters.add("serviceItemId", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Id", serviceItem.value));
						esq.getEntityCollection(function(result) {
							if (result.success && !result.collection.getCount()) {
								this.set("ServiceItem", null);
							} else {
								this.recalculateServiceTerms();
							}
						}, this);
					}
				},

				/**
				 * Category field change handler.
				 * @protected
				 */
				onCategoryChanged: function() {
					if (this.changedValues.Category) {
						this.set("ServiceItem", null);
						this.set("ServiceCategory", null);
					}
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
				 * Returns calculating dates service config.
				 * @protected
				 * @returns {Object} Service input config
				 */
				getCallTermCalculationServiceConfig: function() {
					var servicePact = this.get("ServicePact");
					var serviceItem = this.get("ServiceItem");
					var registrationTime = this.get("RegisteredOn");
					if (!servicePact || !serviceItem || !registrationTime) {
						return null;
					}
					var config = {
						serviceName: "TermCalculationService",
						methodName: "GetServiceTerm",
						data: {
							request: {
								ServicePactId: servicePact.value,
								ServiceItemId: serviceItem.value,
								PriorityId: this.BPMSoft.GUID_EMPTY,
								RegistrationTime: JSON.parse(this.BPMSoft.encodeDate(registrationTime))
							}
						}
					};
					return config;
				},

				/**
				 * Sets service pact value.
				 * @protected
				 */
				setServicePact: function() {
					if (this.get("OriginalServiceItem")) {
						return;
					}
					var config = this.getCallDetermineServiceConfig();
					if (config) {
						this.callService(config, this.onGetSuitableServicePacts, this);
					} else if (this.get("ServicePact")) {
						this.set("ServicePact", null);
						this.set("SuitableServicePacts", []);
					}
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
				 * On get service pacts handler.
				 * @protected
				 * @param {Object} responseObject
				 */
				onGetSuitableServicePacts: function(responseObject) {
					this.hideBodyMask();
					this.set("SuitableServicePacts", responseObject.GetSuitableServicePactsResult || []);
					var mostSuitableServicePact = this.getMostSuitableServicePact();
					this.set("ServicePact", mostSuitableServicePact ? mostSuitableServicePact : null);
				},

				/**
				 * Determine service pact with high priority.
				 * @private
				 * @returns {Object}
				 */
				getMostSuitableServicePact: function() {
					var suitableServicePacts = this.get("SuitableServicePacts");
					var mostSuitableServicePact = this.Ext.Array.min(suitableServicePacts, function(min, item) {
						return item.SuitableLevel < min.SuitableLevel;
					});
					if (!mostSuitableServicePact) {
						return null;
					}
					return {
						value: mostSuitableServicePact.Id,
						displayValue: mostSuitableServicePact.Name
					};
				},

				/**
				 * @inheritdoc BPMSoft.CasePageV2#getOwnerDependenceFilters
				 * @overridden
				 */
				getOwnerDependenceFilters: function(scope) {
					var filterGroup = new scope.BPMSoft.createFilterGroup();
					var serviceItem = scope.get("ServiceItem");
					var supportLevel = scope.get("SupportLevel");
					if (serviceItem) {
						filterGroup.add("ServiceItemFilter", scope.BPMSoft.createColumnFilterWithParameter(
							scope.BPMSoft.ComparisonType.EQUAL, "[ServiceEngineer:Engineer].ServiceItem", serviceItem.value));
					}
					if (supportLevel) {
						filterGroup.add("SupportLevelFilter", scope.BPMSoft.createColumnFilterWithParameter(
							scope.BPMSoft.ComparisonType.EQUAL, "[ServiceEngineer:Engineer].SupportLevel", supportLevel.value));
					}
					return filterGroup;
				},
				/**
				 * Returns Case support level.
				 * @returns {String}
				 */
				getSupportLevelLabel: function() {
					var supportLevel = this.get("SupportLevel");
					var caption = this.get("Resources.Strings.SupportLevelCaption") + ": ";
					return supportLevel ? caption + supportLevel.displayValue : "";
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},

				/**
				 * Initializes hierarchical service config.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.mixins.HierarchicalRecordsUtilities.getConfig.call(this);
					config.data.request.SchemaTableName = "Case";
					config.data.request.ParentIdColumnName = "ParentCaseId";
					this.set("HierarchicalConfig", config);
					this.set("ParentColumnName", "ParentCase");
				},

				/**
				 * Parent cases load handler.
				 */
				onLoadParentCase: function() {
					this.mixins.HierarchicalRecordsUtilities.onLoadParent.call(this);
				},

				/**
				 * On prepare parent cases handler.
				 */
				onPrepareParentCase: function(filter) {
					this.mixins.HierarchicalRecordsUtilities.onPrepareParent.call(this, filter);
				},

				/**
				 * @inheritdoc BPMSoft.CasePageV2#handleResolvedStatus
				 * @overridden
				 */
				handleResolvedStatus: function(status) {
					if (status.IsResolved && !this.get("SolutionProvidedOn")) {
						var originalSolutionProvidedOn = this.get("OriginalSolutionProvidedOn");
						var solutionProvidedOn = originalSolutionProvidedOn ? originalSolutionProvidedOn : new Date();
						this.set("SolutionProvidedOn", solutionProvidedOn);
						var originalSupportLevel = this.get("OriginalSolvedOnSupportLevel");
						var supportLevel = originalSupportLevel ? originalSupportLevel : this.get("SupportLevel");
						this.set("SolvedOnSupportLevel", supportLevel);
					} else if (!status.IsFinal && !status.IsResolved) {
						this.set("SolvedOnSupportLevel", null);
						this.set("SolutionProvidedOn", null);
					}
				},

				/**
				 * @inheritdoc BPMSoft.CasePageV2#handleFinalStatus
				 * @overridden
				 */
				handleFinalStatus: function(status) {
					if (status.IsFinal && !this.get("ClosureDate")) {
						if (this.get("OriginalSolvedOnSupportLevel")) {
							this.set("SolvedOnSupportLevel", this.get("OriginalSolvedOnSupportLevel"));
						}
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#updateOriginals
				 * @overridden
				 */
				updateOriginals: function(isNull) {
					this.callParent(isNull);
					this.set("OriginalSolvedOnSupportLevel", isNull ? null : this.get("SolvedOnSupportLevel"));
				}
			},
			rules: {
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
						"conditions": [{
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
						}]
					},
					"ServiceItemRequired": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.REQUIRED,
						conditions: [{
							leftExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: true
							},
							comparisonType: this.BPMSoft.ComparisonType.EQUAL,
							rightExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: true
							}
						}]
					}
				},
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
				}
			},
			userCode: {}
		};
	});
