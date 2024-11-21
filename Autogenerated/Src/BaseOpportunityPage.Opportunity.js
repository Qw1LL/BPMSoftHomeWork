define("BaseOpportunityPage", ["BaseFiltersGenerateModule", "BusinessRuleModule", "ConfigurationConstants",
		"ProcessModuleUtilities", "OpportunityConfigurationConstants", "CompletenessMixin",
		"ConfigurationCompletenessIndicatorGenerator", "CompletenessIndicator", "TooltipUtilities",
		"css!CompletenessCSSV2", "css!OpportunityCommonCSS", "PartnersOwnerMixin"],
	function(BaseFiltersGenerateModule, BusinessRuleModule, ConfigurationConstants, ProcessModuleUtilities,
			OpportunityConfigurationConstants) {
		return {
			entitySchemaName: "Opportunity",
			messages: {
				"RefreshDecisionMaker": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ReloadDashboardItems
				 * Notify about the action dashboard to be reloaded.
				 */
				"ReloadDashboardItems": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				"CompletenessValue": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					value: 0
				},

				"CreatedOn": {
					dataValueType: BPMSoft.DataValueType.DATE
				},

				"DueDate": {
					dataValueType: BPMSoft.DataValueType.DATE,
					dependencies: [
						{
							columns: ["Stage"],
							methodName: "onStageChangedSetDueDate"
						}
					]
				},

				"Partner": {
					dependencies: [
						{
							columns: ["Stage"],
							methodName: "updatePartnerValue"
						}
					]
				},

				"Owner": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function () {
							return this.getOwnerFilter("Type");
						}
					},
					dependencies: [
						{
							columns: ["ResponsibleDepartment"],
							methodName: "setOpportunityByResponsibleDepartment"
						}
					]
				},

				"CloseReason": {
					dependencies: [
						{
							columns: ["Stage", "Probability"],
							methodName: "clearCloseReason"
						}
					]
				},

				"Stage": {
					lookupListConfig: {
						orders: [{columnPath: "Number"}],
						columns: ["End", "MaxProbability"]
					}
				},

				"Mood": {
					lookupListConfig: {
						orders: [{columnPath: "Position"}]
					}
				},

				"Probability": {
					"dependencies": [
						{
							"columns": ["Stage"],
							"methodName": "setProbabilityByStage"
						}
					]
				},

				"ResponsibleDepartment": {
					lookupListConfig: {
						columns: ["SalesDirector"]
					}
				},

				"Client": {
					"caption": {"bindTo": "Resources.Strings.Client"},
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"multiLookupColumns": ["Contact", "Account"],
					"isRequired": true
				},

				"DecisionMaker": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"name": "DecisionMaker",
					"caption": {"bindTo": "Resources.Strings.DecisionMakerCaption"},
					"usageType": this.BPMSoft.EntitySchemaColumnUsageType.General,
					"isLookup": true,
					"referenceSchemaName": "Contact"
				},

				"DaysInFunnel": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": "0"
				}
			},
			mixins: {
				CompletenessMixin: "BPMSoft.CompletenessMixin",
				TooltipUtilitiesMixin: "BPMSoft.TooltipUtilities",
				PartnersOwnerMixin: "BPMSoft.PartnersOwnerMixin"
			},
			modules: /**SCHEMA_MODULES*/{
				"ActionsDashboardModule": {
					"config": {
						"isSchemaConfigInitialized": true,
						"schemaName": "OpportunityActionsDashboard",
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"entitySchemaName": "Opportunity",
								"actionsConfig": {
									"schemaName": "OpportunityStage",
									"columnName": "Stage",
									"colorColumnName": "Color",
									"filterColumnName": "ShowInProgressBar",
									"orderColumnName": "Number",
									"innerOrderColumnName": "End",
									"decouplingConfig": {
										"name": "OppStageDecoupling",
										"masterColumnName": "CurrentStage",
										"referenceColumnName": "AvailableStage"
									}
								},
								"dashboardConfig": {
									"Activity": {
										"masterColumnName": "Id",
										"referenceColumnName": "Opportunity"
									}
								}
							}
						}
					}
				}
			}/**SCHEMA_MODULES*/,
			details: /**SCHEMA_DETAILS*/{
				OpportunityContacts: {
					schemaName: "OpportunityContactDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					}
				},
				StageInOpportunity: {
					schemaName: "StageInOpportunityDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					}
				},
				OpportunityProduct: {
					schemaName: "OpportunityProductDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					},
					subscriber: {methodName: "onOpportunityProductChanged"}
				},
				OpportunityCompetitor: {
					schemaName: "OpportunityCompetitorDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					}
				},
				Files: {
					schemaName: "FileDetailV2",
					entitySchemaName: "OpportunityFile",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					}
				},
				OpportunityTacticHistory: {
					schemaName: "OpportunityTacticHistoryDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					}
				},
				ContactsAccount: {
					schemaName: "AccountContactsDetailV2",
					filter: {
						masterColumn: "Account",
						detailColumn: "Account"
					},
					defaultValues: {
						Account: {
							masterColumn: "Account"
						}
					},
					useRelationship: true,
					filterMethod: "contactAccountFilter",
					captionName: "CustomerContacts"
				},
				OpportunityAccount: {
					schemaName: "OpportunityDetailV2",
					filter: {
						masterColumn: "Account",
						detailColumn: "Account"
					},
					defaultValues: {
						Account: {
							masterColumn: "Account"
						}
					},
					useRelationship: true,
					filterMethod: "opportunityAccountFilter",
					captionName: "CustomerOpportunitiesCaption"
				},
				ActivitiesAccount: {
					schemaName: "AccountHistoryActivityDetail",
					filter: {
						masterColumn: "Account",
						detailColumn: "Account"
					},
					defaultValues: {
						Account: {
							masterColumn: "Account"
						}
					},
					useRelationship: true,
					captionName: "CustomerActivitiesCaption",
					filterMethod: "contactAccountFilter"
				},
				FilesAccount: {
					schemaName: "FileDetailV2",
					entitySchemaName: "AccountFile",
					filter: {
						masterColumn: "Account",
						detailColumn: "Account"
					},
					captionName: "CustomerFilesCaption",
					filterMethod: "contactAccountFilter"
				},
				OpportunityContact: {
					schemaName: "OpportunityDetailV2",
					filter: {
						masterColumn: "Contact",
						detailColumn: "Contact"
					},
					defaultValues: {
						Contact: {
							masterColumn: "Contact"
						}
					},
					useRelationship: false,
					filterMethod: "opportunityAccountFilter",
					captionName: "CustomerOpportunitiesCaption"
				},
				ActivitiesContact: {
					schemaName: "ContactHistoryActivityDetail",
					filter: {
						masterColumn: "Contact",
						detailColumn: "Contact"
					},
					defaultValues: {
						Contact: {
							masterColumn: "Contact"
						}
					},
					useRelationship: false,
					captionName: "CustomerActivitiesCaption",
					filterMethod: "contactAccountFilter"
				},
				FilesContact: {
					schemaName: "FileDetailV2",
					entitySchemaName: "ContactFile",
					filter: {
						masterColumn: "Contact",
						detailColumn: "Contact"
					},
					captionName: "CustomerFilesCaption",
					filterMethod: "contactAccountFilter"
				}
			}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * Reloads current record.
				 * @private
				 */
				onOpportunityProductChanged: function() {
					this.loadEntity(this.get("Id"));
					this.sendSaveCardModuleResponse(this);
				},

				/**
				 * Creates EntitySchemaQuery entity.
				 * @private
				 * @return {BPMSoft.EntitySchemaQuery} EntitySchemaQuery entity.
				 */
				createOpportunityInStageEsq: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OpportunityInStage"
					});
					var stage = this.get("Stage");
					var stageIdValue = stage.value;
					esq.addColumn("StartDate");
					esq.addColumn("DueDate");
					esq.filters.add("Opportunity", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Opportunity", this.get("Id")));
					esq.filters.add("Stage", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Stage", stageIdValue));
					esq.filters.add("Historical", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Historical", false));
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var actionDashboardModuleId = this.getModuleId("ActionsDashboardModule");
					const opportunityContactsDetailSandboxId = this.getDetailId("OpportunityContacts");
					this.sandbox.subscribe("ReloadCard", this.onReloadCard, this, [actionDashboardModuleId]);
					this.sandbox.subscribe("RefreshDecisionMaker", this.refreshDecisionMaker, this,
						[opportunityContactsDetailSandboxId]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDetailChanged
				 */
				onDetailChanged: function() {
					this.callParent(arguments);
					this.calculateCompleteness();
				},

				/**
				 * Returns array of columns name.
				 * @override
				 * @return {[String]} Array of columns name.
				 */
				getDefQuickAddColumnNames: function() {
					var columns = this.callParent(arguments);
					columns.push("Account");
					return columns;
				},

				/**
				 * Sets addition default value for the cteated activity.
				 * @override
				 * @param {Object} openCardConfig Configuration for opened page.
				 * @param {Function} next Callback function.
				 */
				setAdditionalDefValues: function(openCardConfig, next) {
					if (this.entitySchema.name === "Opportunity") {
						openCardConfig.defaultValues.push({
							name: "Opportunity",
							value: this.get("Id")
						});
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "OpportunityContact"
						});
						esq.addColumn("Contact");
						esq.filters.addItem(esq.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Opportunity", this.get("Id")));
						esq.filters.addItem(esq.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "IsMainContact", 1));
						esq.getEntityCollection(function(result) {
							if (result.success) {
								var entities = result.collection;
								if (entities.getCount() > 0) {
									var entity = entities.getByIndex(0).get("Contact");
									if (entity) {
										openCardConfig.defaultValues.push({
											name: "Contact",
											value: entity.value
										});
									}
								}
							}
							next();
						}, this);
					} else {
						next();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getLookupQuery
				 * @override
				 */
				getLookupQuery: function(filter, columnName) {
					var esq = this.callParent(arguments);
					if (columnName === "Mood") {
						esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_IMAGE_COLUMN, "primaryImageValue");
					}
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getActions
				 * @override
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Type": "BPMSoft.MenuSeparator",
						"Caption": ""
					}));
					return actionMenuItems;
				},

				/**
				 * Filters tab details the history of the customer.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.Filter} Returns the filter of the customer.
				 */
				contactAccountFilter: function() {
					var client = this.get("Client"),
						clientColumn = "Account",
						clientId = this.BPMSoft.GUID_EMPTY,
						filter;
					if (!this.Ext.isEmpty(client)) {
						clientColumn = client.column;
						if (client.value) {
							clientId = client.value;
						}
					}
					filter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, clientColumn, clientId);
					return filter;
				},

				/**
				 * Filters the detail "Customer opportunities".
				 * @protected
				 * @virtual
				 * @return {BPMSoft.FilterGroup} Returns a group of filters.
				 */
				opportunityAccountFilter: function() {
					var customerFilter,
						filterGroup,
						opportunityId;
					customerFilter = this.contactAccountFilter();
					opportunityId = this.get("Id");
					filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					filterGroup.add("CustomerFilter", customerFilter);
					filterGroup.add("OpportunityFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", opportunityId));
					return filterGroup;
				},

				/**
				 * @inheritdoc BPMSoft.CompletenessMixin#calculateCompleteness
				 * @override
				 */
				calculateCompleteness: function() {
					var config = {
						recordId: this.get("Id"),
						schemaName: this.entitySchemaName
					};
					this.mixins.CompletenessMixin.getCompleteness.call(this, config, this.calculateCompletenessResponce, this);
				},

				/**
				 * @inheritdoc BPMSoft.CompletenessMixin#calculateCompletenessResponce
				 * @override
				 */
				calculateCompletenessResponce: function(completenessResponce) {
					if (this.Ext.isEmpty(completenessResponce)) {
						return;
					}
					var missingParametersCollection = completenessResponce.missingParametersCollection;
					var completeness = completenessResponce.completenessValue;
					var scale = completenessResponce.scale;
					if (!this.Ext.isEmpty(missingParametersCollection)) {
						var collection = this.get("MissingParametersCollection");
						collection.clear();
						collection.loadAll(missingParametersCollection);
					}
					if (this.Ext.isObject(scale) && this.Ext.isArray(scale.sectorsBounds)) {
						this.set("CompletenessSectorsBounds", scale.sectorsBounds);
					}
					if (this.Ext.isNumber(completeness)) {
						this.set("CompletenessValue", completeness);
					}
				},

				/**
				 * Changes related activities owner column value after users confirmation.
				 * @private
				 * @param oldOwner
				 */
				changeActivitiesOwner: function(oldOwner) {
					var newOwner = this.get("Owner");
					var questionText = this.Ext.String.format(
						this.get("Resources.Strings.ChangeActivityOwnerQuestion"),
						oldOwner.displayValue,
						newOwner.displayValue);
					var cfg = {
						style: this.BPMSoft.MessageBoxStyles.BLUE,
						scope: this
					};
					this.showConfirmationDialog(questionText, function(returnCode) {
						if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
							var update = this.Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: "Activity"
							});
							this.addRelatedActivitiesFilters(update, oldOwner);
							update.setParameterValue("Owner", newOwner.value, BPMSoft.DataValueType.GUID);
							update.execute();
						}
					}, ["yes", "no"], cfg);
				},

				/**
				 * Appends filters for related activities.
				 * @private
				 * @param {BPMSoft.BaseFilterableQuery} query
				 * @param {Object} owner Activities owner column value.
				 */
				addRelatedActivitiesFilters: function(query, owner) {
					var filters = query.filters;
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"Opportunity", this.get("Id")));
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"Owner", owner.value));
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"Status.Finish", false));
				},

				/**
				 * Returns {@link BPMSoft.EntitySchemaQuery} for count of related activities.
				 * @private
				 * @param {Object} owner Activities owner column value.
				 * @return {BPMSoft.EntitySchemaQuery} Query.
				 */
				getRelatedAcitivitiesEsq: function(owner) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Activity"
					});
					esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
					this.addRelatedActivitiesFilters(esq, owner);
					return esq;
				},

				/**
				 * If related activities are exists, changes their owner after users confirmation.
				 * @protected
				 */
				tryChangeActivitiesOwner: function() {
					var owner = this.get("Owner");
					var oldOwner = this.get("oldOwner");
					if (owner && oldOwner && owner.value && oldOwner.value) {
						if (owner.value !== oldOwner.value) {
							this.set("oldOwner", this.BPMSoft.deepClone(this.get("Owner")));
							var esq = this.getRelatedAcitivitiesEsq(oldOwner);
							esq.getEntityCollection(function(response) {
								if (response.success) {
									var collection = response.collection;
									if (collection && collection.getCount() > 0) {
										if (collection.getByIndex(0).get("Count") > 0) {
											this.changeActivitiesOwner(oldOwner);
										}
									}
								}
							}, this);
						}
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @override
				 */
				onSaved: function() {
					this.callParent(arguments);
					if (!this.isNewMode() && !this.get("IsProcessMode")) {
						this.calculateCompleteness();
					}
					this.updateTacticHistoryDetailVisibility();
					this.updateOpportunityDaysValues();
					this.updateDetail({detail: "OpportunityTacticHistory"});
					var stage = this.get("Stage");
					this.set("isStageEnabled", !stage || !stage.End);
					if (this.getIsFeatureDisabled("ChangeEntityActivitiesAndProcessOwner")) {
						this.tryChangeActivitiesOwner();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.updateTacticHistoryDetailVisibility();
					this.callParent(arguments);
					if (this.isEditMode()) {
						var collection = this.get("MissingParametersCollection");
						collection.clear();
						this.set("CompletenessValue", 0);
						this.calculateCompleteness();
					}
					var stage = this.get("Stage");
					this.set("isStageEnabled", this.isNewMode() || !stage || !stage.End);
					this.set("oldOwner", this.BPMSoft.deepClone(this.get("Owner")));
					this.updateOpportunityDaysValues();
					this.refreshDecisionMaker();
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getDefaultValues
				 * @override
				 */
				getDefaultValues: function() {
					var defaultValues = this.callParent(arguments);
					var stateValue = this.get("Stage");
					if (stateValue) {
						defaultValues.push({
							name: "Stage",
							value: stateValue.value || stateValue
						});
					}
					return defaultValues;
				},

				/**
				 * Publishes message for actions dashboard items reload.
				 * @protected
				 */
				reloadActionsDashboardItems: function() {
					this.sandbox.publish("ReloadDashboardItems", null, [this.sandbox.id]);
				},

				/**
				 * Validation column of Probability.
				 * Checks occupancy from 0 to 100.
				 * @return {{fullInvalidMessage: string, invalidMessage: string}} Validation result.
				 */
				probabilityValidator: function() {
					var invalidMessage = "";
					var probability = this.get("Probability");
					var stage = this.get("Stage");
					var maxProbability = -1;
					if (stage) {
						maxProbability = stage.MaxProbability;
					}
					if (probability && (probability > 100 || probability < 0)) {
						invalidMessage = this.get("Resources.Strings.ProbabilityInvalidCaption");
					}
					if (probability && probability > maxProbability && maxProbability >= 0) {
						invalidMessage = this.get("Resources.Strings.ProbabilityIsGreaterThenMaxProbabilityByStageMessageCaption") +
							maxProbability;
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig
				 * @override
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Probability", this.probabilityValidator);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2ViewModel#init
				 * @override
				 */
				init: function() {
					this.set("MissingParametersCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.callParent(arguments);
					this.on("change:Client", this.updateDetailsOnChange, this);
				},

				/**
				 * Updates details then field Client is changed.
				 * @private
				 * @param {BPMSoft.BaseViewModel} model The model in which the change occurred field.
				 * @param {Object} value New value of field.
				 */
				updateDetailsOnChange: function(model, value) {
					var details = [],
						columnName;
					if (!this.Ext.isEmpty(value)) {
						columnName = value.column;
						if (columnName === "Account") {
							details.push("ContactsAccount");
						}
						details = ["Opportunity" + columnName, "Activities" + columnName, "Files" + columnName];
						this.BPMSoft.each(details, function(detailName) {
							this.updateDetail({detail: detailName});
						}, this);
					}
				},

				/**
				 * Cleares Close reason if current stage is not ending and Probability is great then 0.
				 * @private
				 */
				clearCloseReason: function() {
					var stage = this.get("Stage");
					if (stage && !BPMSoft.isEmptyGUID(stage.value) && !stage.End && this.get("Probability") !== 0) {
						this.set("CloseReason", null);
					}
				},

				/**
				 * Updates Probability column value basing on current stage.
				 * @private
				 */
				setProbabilityByStage: function() {
					var stage = this.get("Stage");
					var stageId;
					if (stage) {
						stageId = stage.value;
					} else {
						return;
					}
					if (stageId === ConfigurationConstants.Opportunity.Stage.RejectedByUs ||
						stageId === ConfigurationConstants.Opportunity.Stage.TranslationIntoAnotherProcess ||
						stageId === ConfigurationConstants.Opportunity.Stage.FinishedWithLoss) {
						this.set("Probability", 0);
					}
				},

				/**
				 * Used to make request to get Stage End status.
				 * @private
				 * @return {BPMSoft.EntitySchemaQuery} OpportunityStage ESQ.
				 */
				getStageEndStatusEsq: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OpportunityStage"
					});
					esq.addColumn("End");
					return esq;
				},

				/**
				 * Updates DueDate column value if current stage is edndig.
				 * @private
				 */
				onStageChangedSetDueDate: function() {
					var stage = this.get("Stage");
					if (stage && stage.value && stage.End === undefined) {
						var esq = this.getStageEndStatusEsq();
						esq.getEntity(stage.value, function(response) {
							var stageItem = response.entity;
							if (!(response.success && stageItem)) {
								return;
							}
							stage.End = Boolean(stageItem.get("End"));
							this.set("Stage", stage);
							this.setCurrentDate();
						}, this);
					} else {
						this.setCurrentDate();
					}
				},

				/**
				 * Sets current date to DueDate.
				 * @private
				 */
				setCurrentDate: function() {
					var stage = this.get("Stage");
					if (stage && stage.End) {
						var currentDateTime = this.getSysDefaultValue(BPMSoft.SystemValueType.CURRENT_DATE_TIME);
						this.set("DueDate", currentDateTime);
					}
				},

				/**
				 * Clear partner value if current opportunity type is not partner sale.
				 * @private
				 */
				updatePartnerValue: function() {
					var type = this.get("Type");
					if (type) {
						var isVisible = type.value === ConfigurationConstants.Opportunity.Type.PartnerSale;
						if (!isVisible) {
							this.set("Partner", null);
						}
					}
				},

				/**
				 * Update owner when responsible department is changed.
				 * @private
				 */
				setOpportunityByResponsibleDepartment: function() {
					var dept = this.get("ResponsibleDepartment");
					var director;
					if (dept && this.get("IsEntityInitialized")) {
						director = dept.SalesDirector;
						if (!director) {
							return;
						}
						this.set("Owner", director);
					}
				},

				/**
				 * Updates visibility of opportunity tactics history detail.
				 * @private
				 */
				updateTacticHistoryDetailVisibility: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OpportunityTacticHist"
					});
					esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
					var filter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Opportunity.Id", this.get("Id"));
					esq.filters.addItem(filter);
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var collection = response.collection;
							if (collection && collection.getCount() > 0) {
								if (collection.getByIndex(0).get("Count") > 0) {
									this.set("OpportunityTacticHistVisible", true);
									return;
								}
							}
						}
						this.set("OpportunityTacticHistVisible", false);
					}, this);
					this.set("OpportunityTacticHistVisible", false);
				},

				/**
				 * Sets visibility of opportunity tactics history detail.
				 * @deprecated
				 * @private
				 */
				getTacticHistoryDetailVisible: function() {
					this.log(this.Ext.String.format(this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
						"getTacticHistoryDetailVisible", "updateTacticHistoryDetailVisibility"));
					this.updateTacticHistoryDetailVisibility.apply(this, arguments);
				},

				/**
				 * Updates days of opportunity visible in funnel.
				 * @protected
				 * @param {Date} dueDate Due date.
				 */
				updateDaysInFunnelValue: function(dueDate) {
					dueDate = dueDate || new Date();
					var createdOnValue = this.get("CreatedOn") || new Date();
					var dateNow = BPMSoft.clearTime(dueDate);
					createdOnValue = BPMSoft.clearTime(createdOnValue);
					var days = BPMSoft.dateDiffDays(createdOnValue, dateNow);
					days = BPMSoft.getFormattedNumberValue(days,
						{
							type: BPMSoft.DataValueType.INTEGER,
							useThousandSeparator: false
						});
					this.set("DaysInFunnel", days > 0 ? days : "0");
				},

				/**
				 * Updates dates of opportunity.
				 * @protected
				 */
				updateOpportunityDaysValues: function() {
					this.set("DaysAtStage", "");
					this.set("DaysAtStageVisible", false);
					var esq = this.createOpportunityInStageEsq();
					esq.getEntityCollection(function(result) {
						var oppHasStages = result.success && !result.collection.isEmpty();
						if (oppHasStages) {
							var oppInStageEntity = result.collection.getByIndex(0);
							this.setOpportunityDaysValues({
								startDate: oppInStageEntity.get("StartDate"),
								dueDate: oppInStageEntity.get("DueDate")
							});
						} else {
							this.updateDaysInFunnelValue();
						}
					}, this);
				},

				/**
				 * Sets days of opportunity.
				 * @protected
				 * @param {Object} [dates] Dates.
				 * @param {Date} dates.startDate Start date.
				 * @param {Date} dates.dueDate Due date.
				 */
				setOpportunityDaysValues: function(dates) {
					dates = dates || {};
					this.updateDaysInFunnelValue(dates.dueDate);
					var stage = this.get("Stage");
					var showLabel = !stage.End && this.Ext.isDefined(dates.startDate);
					if (!showLabel) {
						return;
					}
					var dateNow = BPMSoft.clearTime(new Date());
					var days = BPMSoft.dateDiffDays(dates.startDate, dateNow);
					this.set("DaysAtStageVisible", showLabel);
					days = BPMSoft.getFormattedNumberValue(days,
						{
							type: BPMSoft.DataValueType.INTEGER,
							useThousandSeparator: false
						});
					this.set("DaysAtStage", days > 0 ? days : "0");
				},

				/**
				 * Returns image configuration for bant profile icon.
				 * @protected
				 * @return {Object}
				 */
				getBantIcon: function() {
					var bantIconImage = this.get("Resources.Images.BantIcon");
					if (this.Ext.isEmpty(bantIconImage)) {
						return null;
					}
					return this.BPMSoft.ImageUrlBuilder.getUrl(bantIconImage);
				},

				/**
				 * Fetches desison maker for current opportunity record.
				 * @protected
				 */
				refreshDecisionMaker: function() {
					var decisionMakerEsq = this.getDecisionMakerEsq();
					decisionMakerEsq.getEntityCollection(function(response) {
						var row;
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() > 0) {
								row = collection.getByIndex(0);
							}
						}
						this.onDecisionMakerEsqComplete(row);
					}, this);
				},

				/**
				 * Returns {@link BPMSoft.EntitySchemaQuery} instance for decision maker of current opportunity.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getDecisionMakerEsq: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "OpportunityContact",
						rowCount: 1
					});
					esq.addColumn("Contact", "Contact");
					var createdOnColumn = esq.addColumn("CreatedOn");
					createdOnColumn.orderDirection = this.BPMSoft.OrderDirection.DESC;
					esq.filters.add("Opportunity", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Opportunity", this.get("Id")));
					esq.filters.add("ContactRole", esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Role",
						OpportunityConfigurationConstants.OppContactRole.DecisionMaker));
					return esq;
				},

				/**
				 * Updates decision maker value on the page.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} [opportunityContactRow] Row contains data about decision
				 * maker contact for current opportunity.
				 */
				onDecisionMakerEsqComplete: function(opportunityContactRow) {
					var contact = null;
					if (opportunityContactRow) {
						contact = opportunityContactRow.get("Contact");
					}
					this.set("DecisionMaker", contact);
				},

				/**
				 * Returns true if label metrics container need to be visible.
				 * @protected
				 * @return {Boolean}
				 */
				isLabelMetricsContainerVisible: function() {
					return this.get("DaysAtStageVisible");
				},

				/**
				 * @private
				 * @deprecated
				 */
				isMetricsContainerVisible: function() {
					return this.getIsFeatureEnabled("OpportunityMetrics");
				},

				/**
				 * Returns probability metric value.
				 */
				getProbabilityMetricValue: function() {
					return this.get("Probability");
				},

				/**
				 * Returns probability metric hint.
				 */
				getProbabilityMetricHint: function() {
					return this.get("Resources.Strings.ProbabilityMetricHint");
				},

				/**
				 * Returns probability metric caption.
				 */
				getProbabilityMetricCaption: function() {
					return this.get("Resources.Strings.ProbabilityCaption");
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "BantProfile",
					"parentName": "LeftModulesContainer",
					"propertyName": "items",
					"values": {
						"id": "BantContainer",
						"selectors": {"wrapEl": "#BantContainer"},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["bant-container", "profile-container"]
						},
						"items": [],
						"markerValue": "BantContainer"
					}
				},
				{
					"operation": "insert",
					"name": "ClientProfile",
					"parentName": "LeftModulesContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TacticAndCompetitorTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.TacticAndCompetitorTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ProductsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ProductsTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HistoryTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.HistoryTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.NotesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "StatisticsContainer",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"items": [],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["opportunity-statistics-container"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "StatisticsContainer",
					"propertyName": "items",
					"name": "CreatedByLabel",
					"values": {
						"caption": {"bindTo": "Resources.Strings.StatisticsCaption"},
						"classes": {
							"labelClass": ["opportunity-statistics-caption"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "MetricsContainer",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["ts-metrics-container"]},
						"items": [],
						"visible": {"bindTo": "isMetricsContainerVisible"}
					}
				},
				{
					"operation": "insert",
					"parentName": "MetricsContainer",
					"propertyName": "items",
					"name": "MoodContainer",
					"values": {
						"items": [],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["ts-metric-item", "ts-mood-container"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "MoodContainer",
					"propertyName": "items",
					"name": "OpportunityMood",
					"values": {
						"generator": "ImageListGenerator.generateImageList",
						"bindTo": "Mood",
						"id": "MoodImageList",
						"schemaName": "OpportunityMood",
						"schemaColumn": "Image",
						"caption": {"bindTo": "Resources.Strings.MoodListCaption"},
						"controlConfig": {
							"wrapClasses": ["opportunity-mood-image-list image-list"],
							"modalBoxClasses": ["opportunity-mood-image-list"]
						},
						"markerValue": "OpportunityMood",
						"tips": []
					},
					"alias": {
						"name": "Mood",
						"excludeProperties": ["layout"],
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityMood",
					"propertyName": "tips",
					"name": "MoodTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.MoodTip"}
					}
				},
				{
					"operation": "insert",
					"parentName": "MoodContainer",
					"propertyName": "items",
					"name": "MoodCaption",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.MoodCaption"},
						"classes": {"labelClass": ["ts-metric-item-caption"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "MetricsContainer",
					"propertyName": "items",
					"name": "ProbabilityContainer",
					"values": {
						"items": [],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["ts-metric-item", "ts-probability-container"]},
						"tips": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProbabilityContainer",
					"propertyName": "tips",
					"name": "ProbabilityMetricHint",
					"values": {
						"content": {"bindTo": "getProbabilityMetricHint"},
						"markerValue": {"bindTo": "getProbabilityMetricHint"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProbabilityContainer",
					"propertyName": "items",
					"name": "ProbabilityValue",
					"values": {
						"generator": "ConfigurationRoundProgressBarGenerator.generateProgressBar",
						"controlConfig": {
							"value": {"bindTo": "getProbabilityMetricValue"},
							"size": 64,
							"borderWidth": 4,
							"clockwise": true,
							"classes": ["ts-font-light"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProbabilityContainer",
					"propertyName": "items",
					"name": "ProbabilityCaption",
					"values": {
						"caption": {"bindTo": "getProbabilityMetricCaption"},
						"classes": {"labelClass": ["ts-metric-item-caption"]},
						"itemType": BPMSoft.ViewItemType.LABEL
					}
				},
				{
					"operation": "insert",
					"parentName": "MetricsContainer",
					"propertyName": "items",
					"name": "DaysInFunnelContainer",
					"values": {
						"items": [],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["ts-metric-item", "ts-days-in-funnel-container"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "DaysInFunnelContainer",
					"propertyName": "items",
					"name": "DaysInFunnelValue",
					"values": {
						"generator": "ConfigurationRoundProgressBarGenerator.generateProgressBar",
						"controlConfig": {
							"caption": {"bindTo": "DaysInFunnel"},
							"captionSuffix": "",
							"value": 100,
							"size": 64,
							"borderWidth": 4,
							"classes": ["ts-font-light"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DaysInFunnelContainer",
					"propertyName": "items",
					"name": "DaysInFunnelCaption",
					"values": {
						"caption": {"bindTo": "Resources.Strings.DaysInFunnelCaption"},
						"classes": {"labelClass": ["ts-metric-item-caption"]},
						"itemType": BPMSoft.ViewItemType.LABEL
					}
				},
				{
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "OpportunityClient",
					"values": {
						"bindTo": "Client",
						"wrapClass": ["client-control"],
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ClientTip"}
						},
						"controlWrapConfig": {
							"classes": {"wrapClassName": ["client-edit-field"]}
						},
						"controlConfig": {
							"enableLeftIcon": true,
							"leftIconConfig": {"bindTo": "getMultiLookupIconConfig"}
						}
					},
					"alias": {
						"name": "Client",
						"excludeProperties": ["layout"],
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "OpportunityPageGeneralTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "OpportunityPageGeneralTabContentGroup",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DescriptionGroup",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.DescriptionGroupCaption"},
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralTabContentGroup",
					"propertyName": "items",
					"name": "OpportunityPageGeneralBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"tools": [],
						"caption": {"bindTo": "Resources.Strings.GeneralInfoCaption"},
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralBlock",
					"propertyName": "items",
					"name": "OpportunityPageGeneralContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"markerValue": "OpportunityPageGeneralContainer"
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "OpportunityTitle",
					"values": {
						"bindTo": "Title",
						"layout": {"column": 0, "row": 2, "colSpan": 11}
					},
					"alias": {
						"name": "Title",
						"excludeProperties": ["layout"],
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Amount",
					"values": {"layout": {"column": 13, "row": 2, "colSpan": 11}}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Probability",
					"values": {
						"layout": {"column": 13, "row": 3, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ProbabilityTip"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Category",
					"values": {
						"layout": {"column": 13, "row": 4, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Source",
					"values": {
						"layout": {"column": 0, "row": 5, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "CreatedOn",
					"values": {
						"dataValueType": BPMSoft.DataValueType.DATE,
						"layout": {"column": 0, "row": 6, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Partner",
					"values": {"layout": {"column": 0, "row": 7, "colSpan": 11}}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "CloseReason",
					"values": {
						"layout": {"column": 13, "row": 4, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "DescriptionGroup",
					"propertyName": "items",
					"name": "DescriptionGroupBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "DescriptionGroupBlock",
					"propertyName": "items",
					"name": "Description",
					"values": {
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {"visible": false},
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"parentName": "TacticAndCompetitorTab",
					"name": "OpportunityTacticAndCompetitorTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "TacticAndCompetitorTab",
					"name": "OpportunityTacticAndCompetitorTabControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "TacticAndCompetitorTab",
					"propertyName": "items",
					"name": "OpportunityTacticHistory",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "OpportunityTacticHistVisible"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ProductsTab",
					"propertyName": "items",
					"name": "OpportunityProduct",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "ProductsTab",
					"name": "OpportunityProductsTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityProductsTabContainer",
					"name": "OpportunityProductsTabControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"name": "OpportunityHistoryTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "LablelMetricsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"classes": {"wrapClassName": ["period-items-container"]},
						"visible": {"bindTo": "isLabelMetricsContainerVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "LablelMetricsContainer",
					"propertyName": "items",
					"name": "DaysAtStageMetricContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "DaysAtStageVisible"},
						"classes": {"wrapClassName": ["control-width-15"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "DaysAtStageMetricContainer",
					"propertyName": "items",
					"name": "DaysAtStageCaption",
					"values": {
						"caption": {"bindTo": "Resources.Strings.DaysAtStageCaption"},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["period-item-caption"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "DaysAtStageMetricContainer",
					"propertyName": "items",
					"name": "DaysAtStageValue",
					"values": {
						"caption": {"bindTo": "DaysAtStage"},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["period-item-value"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "OpportunityContacts",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityTacticAndCompetitorTabControlGroup",
					"propertyName": "items",
					"name": "OpportunityTacticAndCompetitorBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityTacticAndCompetitorBlock",
					"propertyName": "items",
					"name": "Weaknesses",
					"values": {
						"layout": {"column": 0, "row": 0, "rowSpan": 1, "colSpan": 11},
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityTacticAndCompetitorBlock",
					"propertyName": "items",
					"name": "Strength",
					"values": {
						"layout": {"column": 13, "row": 0, "rowSpan": 1, "colSpan": 11},
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityTacticAndCompetitorBlock",
					"propertyName": "items",
					"name": "Tactic",
					"values": {
						"layout": {"column": 0, "row": 1, "rowSpan": 1, "colSpan": 24},
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityTacticAndCompetitorBlock",
					"propertyName": "items",
					"name": "CheckDate",
					"values": {"layout": {"column": 0, "row": 2, "colSpan": 11}}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityTacticAndCompetitorTabControlGroup",
					"propertyName": "items",
					"name": "OpportunityCompetitor",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "StageInOpportunity",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "NotesTab",
					"propertyName": "items",
					"name": "Files",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"parentName": "NotesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						contentType: BPMSoft.ContentType.RICH_TEXT,
						"layout": {column: 0, row: 0, colSpan: 24},
						"labelConfig": {"visible": false},
						"controlConfig": {
							"imageLoaded": {"bindTo": "insertImagesToNotes"},
							"images": {"bindTo": "NotesImagesCollection"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ActionsDashboardModule",
					"parentName": "ActionDashboardContainer",
					"propertyName": "items",
					"values": {
						"classes": {wrapClassName: ["actions-dashboard-module"]},
						"itemType": BPMSoft.ViewItemType.MODULE
					}
				},
				{
					"operation": "insert",
					"name": "BantProfileHeaderContainer",
					"parentName": "BantProfile",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"name": "BantIcon",
					"parentName": "BantProfileHeaderContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getBantIcon",
						"onPhotoChange": BPMSoft.emptyFn,
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["bant-icon"]
						},
						"layout": {"column": 0, "row": 0, "colSpan": 3}
					}
				},
				{
					"operation": "insert",
					"name": "BantHeaderCaption",
					"parentName": "BantProfileHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"layout": {"column": 3, "row": 0, "colSpan": 11},
						"classes": {"labelClass": ["bant-header-caption"]},
						"caption": {"bindTo": "Resources.Strings.BantCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "BantProfile",
					"propertyName": "items",
					"name": "OpportunityBudget",
					"values": {
						"bindTo": "Budget",
						"layout": {"column": 0, "row": 1, "colSpan": 24}
					},
					"alias": {
						"name": "Budget",
						"excludeProperties": ["layout"],
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "insert",
					"name": "OpportunityDecisionMaker",
					"values": {
						"layout": {
							"row": 2,
							"column": 0,
							"colSpan": 24
						},
						"bindTo": "DecisionMaker",
						"controlConfig": {
							"enabled": false
						}
					},
					"parentName": "BantProfile",
					"propertyName": "items",
					"alias": {
						"name": "DecisionMaker",
						"excludeProperties": ["layout"],
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "insert",
					"parentName": "BantProfile",
					"propertyName": "items",
					"name": "OpportunityDueDate",
					"values": {
						"bindTo": "DueDate",
						"dataValueType": BPMSoft.DataValueType.DATE,
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"tip": {
							"content": {"bindTo": "Resources.Strings.DueDateTip"}
						},
						"hintLock": {
							"content": {"bindTo": "Resources.Strings.DueDateTip"},
							"displayMode": this.BPMSoft.TipDisplayMode.WIDE
						}
					},
					"alias": {
						"name": "DueDate",
						"excludeProperties": ["layout"],
						"excludeOperations": ["remove", "move"]
					}
				},
				{
					"operation": "move",
					"name": "Header",
					"parentName": "LeftModulesContainer",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "merge",
					"name": "Header",
					"parentName": "LeftModulesContainer",
					"values": {
						"classes": {
							"wrapClassName": ["profile-container", "autofill-layout"]
						}
					}
				}]/**SCHEMA_DIFF*/,

			rules: {
				"CloseReason": {
					"VisibleCloseReasonByStageAndProbability": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.VISIBLE,
						logical: BPMSoft.LogicalOperatorType.AND,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Stage",
									"attributePath": "End"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": true
								}
							},
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Probability"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": 0
								}
							}
						]
					}
				},
				"DueDate": {
					"EnabledDueDateByStage": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"logical": BPMSoft.LogicalOperatorType.OR,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Stage"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Opportunity.Stage.DeterminationOfPotential
								}
							},
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Stage",
									"attributePath": "End"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": false
								}
							}
						]
					}
				},
				"Partner": {
					"VisiblePartnerByType": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Type"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Opportunity.Type.PartnerSale
								}
							}
						]
					}
				},
				"Probability": {
					"EnabledProbabilityByStage": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"logical": BPMSoft.LogicalOperatorType.AND,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Stage"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Opportunity.Stage.RejectedByUs
								}
							},
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Stage"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Opportunity.Stage.TranslationIntoAnotherProcess
								}
							},
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Stage"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Opportunity.Stage.FinishedWithLoss
								}
							}
						]
					}
				}
			}
		};
	});
