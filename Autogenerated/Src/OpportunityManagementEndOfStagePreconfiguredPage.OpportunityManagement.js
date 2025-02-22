﻿define("OpportunityManagementEndOfStagePreconfiguredPage", [
			"ConfigurationConstants", "BusinessRuleModule",
			"OppManagementUtils", "ConfigurationEnums", "ProcessModuleUtilities", "OpportunityStage",
			"CustomProcessPageV2Utilities", "css!OppManagementUtils"
		],
		/**
		 * @class BPMSoft.configuration.OpportunityManagementEndOfStagePreconfiguredPage
		 * ############### ######## OpportunityManagment "########## ######"
		 */
		function(ConfigurationConstants, BusinessRuleModule, OppManagementUtils, ConfigurationEnums,
				ProcessModuleUtilities) {
			return {
				messages: {
					/**
					 * @message ReloadGridData
					 * ############ ###### ###########.
					 */
					"ReloadGridData": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetValues
					 * ########### ##### ######## #####.
					 */
					"GetScheduleItemStatus": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				mixins: {
					CustomProcessPageV2Utilities: "BPMSoft.CustomProcessPageV2Utilities"
				},
				attributes: {
					"GotoNextStage": {dataValueType: BPMSoft.DataValueType.BOOLEAN},
					"RepeatStage": {dataValueType: BPMSoft.DataValueType.BOOLEAN},
					"GotoAnotherStage": {dataValueType: BPMSoft.DataValueType.BOOLEAN},
					"SelectedStage": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						caption: BPMSoft.OpportunityStage.caption,
						isLookup: true,
						referenceSchemaName: "OpportunityStage",
						isRequired: {
							"bindTo": "IsSelectedStageVisible"
						},
						lookupListConfig: {
							orders: [
								{
									columnPath: "Number",
									direction: BPMSoft.OrderDirection.ASC
								}
							]
						}
					},
					"CurrentStage": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						isLookup: true,
						referenceSchemaName: "OpportunityStage"
					},
					"Opportunity": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						isLookup: true,
						referenceSchemaName: "Opportunity"
					},
					"NextStage": {
						caption: BPMSoft.OpportunityStage.caption,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						isLookup: true,
						referenceSchemaName: "OpportunityStage"
					},
					"NextStageResult": {dataValueType: BPMSoft.DataValueType.BOOLEAN},
					"IsSelectedStageVisible": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					"RadioGroup": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						dependencies: [
							{
								columns: ["RadioGroup"],
								methodName: "onRadioGroupChanged"
							}
						]
					}
				},
				methods: {
					/**
					 * ######### ######## ## #########, ####### ########### ########.
					 * @overridden
					 */
					subscribeSandboxEvents: function() {
						this.callParent(arguments);
						this.sandbox.subscribe("ReloadGridData", function() {
							this.loadActivities();
						}, this, [this.getCompleteActivityId()]);

					},

					/**
					 * ########## sanbox id ### ######## ########### ##########.
					 * @return {String}
					 */
					getCompleteActivityId: function() {
						return this.sandbox.id + "_CompleteActivity";
					},

					/**
					 * ############## ######### ######## ######.
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.set("extraCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
						this.loadActivities();
					},

					/**
					 * ######### ########## # ######.
					 */
					loadActivities: function() {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Activity"
						});
						esq.addMacrosColumn(this.BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
						esq.addMacrosColumn(this.BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Title");
						esq.addColumn("StartDate");
						esq.addColumn("Type");
						esq.addColumn("ProcessElementId");
						esq.addParameterColumn("Actions", this.BPMSoft.DataValueType.TEXT, "Actions");
						esq.filters.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Opportunity", this.get("OpportunityId")));
						esq.filters.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Status.Finish", false));
						esq.filters.addItem(esq.createIsNullFilter(this.Ext.create("BPMSoft.ColumnExpression", {
							columnPath: "ProcessElementId"
						})));
						esq.getEntityCollection(function(response) {
							if (response.success) {
								response.collection.each(function(item) {
									item.onTitleLinkClick = Ext.emptyFn;
									item.onStartDateLinkClick = Ext.emptyFn;
									item.onActionsLinkClick = Ext.emptyFn;
									item.set("NeedStatusId", ConfigurationConstants.Activity.Status.NotStarted.toLowerCase());
									item.onActivityDoneStatusButtonClick =
											this.onActivityDoneStatusButtonClick.bind(this, item);
									item.onActivityCancelStatusButtonClick =
											this.onActivityCancelStatusButtonClick.bind(this, item);
									item.getActivityStatusButtonImage =
											this.getActivityStatusButtonImage.bind(this, item);
									item.getActivityStatusButtonHint =
											this.getActivityStatusButtonHint.bind(this, item);
								}, this);
								var collection = this.get("extraCollection");
								collection.clear();
								collection.loadAll(response.collection);
								this.set("extraCollectionCount", collection.getCount());
							}
						}, this);
					},

					/**
					 * ########## ######### ############# ###### # ####### ###########.
					 * @return {Object}
					 */
					getButtonConfig: function(tag) {
						return {
							className: "BPMSoft.Button",
							style: this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							classes: {
								imageClass: ["button32x32"],
								wrapperClass: ["noPadding"]
							},
							click: {bindTo: "onActivity" + tag + "StatusButtonClick"},
							imageConfig: {"bindTo": "getActivityStatusButtonImage"},
							tag: tag,
							hint: {"bindTo": "getActivityStatusButtonHint"}
						};
					},

					/**
					 * ########## ######### ######## ######.
					 * @return {Object}
					 */
					getActivityStatusButtonImage: function(item, tag) {
						return this.get("Resources.Images." + tag);
					},

					/**
					 * ########## ######### ######.
					 * @return {String}
					 */
					getActivityStatusButtonHint: function(item, tag) {
						return this.get("Resources.Strings." + tag + "TooltipText");
					},

					/**
					 * ######## ######### ############# ### ####### # ########.
					 * @private
					 */
					onApplyControlConfig: function(control) {
						control.config = {
							className: "BPMSoft.Container",
							items: [
								this.getButtonConfig("Done"),
								this.getButtonConfig("Cancel")
							]
						};
					},

					/**
					 * ######## ####### entitySchema, ############## ####### ######.
					 * @overridden
					 */
					findEntityColumn: function(columnName) {
						var column = this.callParent(arguments);
						if (!column) {
							column = this.getColumnByName(columnName);
						}
						return column;
					},

					/**
					 * ########## ######, #### ####### ########### #####.
					 * retrun {Boolean}
					 */
					getIsActivitiesGridVisible: function() {
						var collectionCount = this.get("extraCollectionCount");
						return !Ext.isEmpty(collectionCount) && collectionCount > 0;
					},

					/**
					 * ########## ######, #### ####### ########### #######.
					 * retrun {Boolean}
					 */
					getIsActivitiesGridInvisible: function() {
						return !this.get("IsStageChangedByProcess") && !this.getIsActivitiesGridVisible();
					},

					/**
					 * ########## ####### ## ###### "######" # ####### ###########.
					 */
					onActivityCancelStatusButtonClick: function(item) {
						var activityId = item.get("Id");
						this.showConfirmationDialog(this.get("Resources.Strings.CancelConfirmMessage"), function(result) {
							if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
								var updateQuery = Ext.create("BPMSoft.UpdateQuery", {
									rootSchemaName: "Activity"
								});
								updateQuery.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
										BPMSoft.ComparisonType.EQUAL, "Id", activityId));
								updateQuery.setParameterValue("Status",
										ConfigurationConstants.Activity.Status.Cancel,
										this.BPMSoft.DataValueType.LOOKUP);
								updateQuery.execute(function() {
									this.loadActivities();
								}, this);
							}
						}, ["yes", "no"]);
					},

					/**
					 * ########## ####### ## ###### "#########" # ####### ###########.
					 */
					onActivityDoneStatusButtonClick: function(item) {
						var activityId = item.get("Id");
						var prcElId = item.get("ProcessElementId");

						if (prcElId) {
							var state = this.sandbox.publish("GetHistoryState");
							this.sandbox.publish("PushHistoryState", {
								hash: state.hash.historyState,
								stateObj: this.BPMSoft.deepClone(state.state),
								silent: true
							});
							if (ProcessModuleUtilities.tryShowProcessCard.call(this, prcElId, activityId)) {
								return;
							}
						}
						var typeId = item.get("Type").value;
						var pageSchemaName = "";
						this.BPMSoft.each(this.BPMSoft.configuration.EntityStructure.Activity.pages, function(page) {
							if (page.UId === typeId) {
								pageSchemaName = page.cardSchema;
								return false;
							}
						});
						var openCardConfig = {
							schemaName: pageSchemaName,
							entitySchemaName: "Activity",
							operation: ConfigurationEnums.CardStateV2.EDIT,
							id: activityId,
							isInChain: true,
							moduleId: this.getCompleteActivityId()
						};
						this.sandbox.subscribe("GetScheduleItemStatus", function() {
							return ConfigurationConstants.Activity.Status.Done;
						}, this, [this.getCompleteActivityId()]);
						this.openCardInChain(openCardConfig);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#initContainersVisibility
					 * @overridden
					 */
					initContainersVisibility: function() {
						this.callParent(arguments);
						this.set("IsPageHeaderVisible", false);
					},

					/**
					 * ########## ######### ########.
					 * @overridden
					 * @return {String}
					 */
					getHeader: function() {
						return this.get("Resources.Strings.PageCaption");
					},
					/**
					 * ####### ######### ############# ########.
					 * @overridden
					 */
					onEntityInitialized: function() {
						this.set("IsStageChangedByProcess", !this.get("IsStageChangedByUser"));
						this.set("RadioGroup", "GotoNextStage");
						if (this.get("CurrentStageId") === ConfigurationConstants.Opportunity.Stage.PreparingQuotation) {
							this.set("PresentationQuotation", null);
						} else {
							this.set("PresentationQuotation",
									ConfigurationConstants.Opportunity.Stage.PresentationQuotation);
						}
						this.loadLookupDisplayValue("SelectedStage",
								ConfigurationConstants.Opportunity.Stage.DeterminationOfPotential);
						this.loadLookupDisplayValue("CurrentStage", this.get("CurrentStageId"));
						this.loadLookupDisplayValue("NextStage", this.get("NextStageId"));
						this.loadLookupDisplayValue("Opportunity", this.get("OpportunityId"));
						this.callParent();
					},

					/**
					 * ######### ######### # ######### # ######### ####### ## #######.
					 * @protected
					 */
					onSelectButtonClick: function() {
						this.asyncValidate(function(result) {
							if (result.success) {
								switch (this.get("RadioGroup")) {
									case "GotoNextStage":
										break;
									case "RepeatStage":
										this.set("NextStageId", this.get("CurrentStageId"));
										break;
									case "GotoAnotherStage":
										this.set("NextStageId", this.get("SelectedStage").value);
										break;
								}
								this.acceptProcessElement("Next");
							} else {
								this.showInformationDialog(result.message);
							}
						}, this);
					},

					/**
					 * ######### ####### ########.
					 * @protected
					 */
					onCancelButtonClick: function() {
						this.sandbox.publish("BackHistoryState");
					},

					/**
					 * ############ ######### ##### ######.
					 * @protected
					 */
					onRadioGroupChanged: function() {
						if (this.get("RadioGroup") === "GotoAnotherStage") {
							this.set("IsSelectedStageVisible", true);
						} else {
							this.set("IsSelectedStageVisible", false);
						}
					},

					/**
					 * ########## ######### ########### "####### ## ######### ######" ### ######### ######## NextStage.
					 * @protected
					 */
					onNextStageChanged: function(value) {
						if (value && value.displayValue) {
							return this.get("Resources.Strings.GotoNextStageCaption") + " \"" + value.displayValue + "\"";
						}
						return this.get("Resources.Strings.GotoNextStageCaption");
					},

					/**
					 * ########## ########### ## #########.
					 * @return {String}
					 */
					getMainRecomendation: function() {
						var currentStage = this.get("CurrentStage");
						var opportunity = this.get("Opportunity");
						if (!currentStage || !opportunity) {
							return null;
						}
						var recomendationTemplate = this.get("IsStageChangedByUser") ?
								this.get("Resources.Strings.FinishedByUserCaption") :
								this.get("Resources.Strings.FinishedByProcessCaption");
						return this.Ext.String.format(recomendationTemplate, currentStage.displayValue,
								opportunity.displayValue);
					}
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "HeaderContainer",
						"values": {
							"visible": true
						}
					},
					{
						"operation": "merge",
						"name": "RecommendationModuleContainer",
						"values": {
							"visible": false
						}
					},
					{
						"operation": "remove",
						"name": "HeaderContainer"
					},
					{
						"operation": "remove",
						"name": "ActionsButton"
					},
					{
						"operation": "remove",
						"name": "SaveButton"
					},
					{
						"operation": "remove",
						"name": "DiscardChangesButton"
					},
					{
						"operation": "remove",
						"name": "DelayExecutionButton"
					},
					{
						"operation": "remove",
						"name": "BackButton"
					},
					{
						"operation": "remove",
						"name": "ViewOptionsButton"
					},
					{
						"operation": "remove",
						"name": "CloseButton"
					},
					{
						"operation": "remove",
						"name": "Tabs"
					},
					{
						"operation": "merge",
						"name": "ActionButtonsContainer",
						"values": {
							visible: true
						}
					},
					{
						"operation": "merge",
						"name": "actions",
						"values": {
							visible: false
						}
					},
					// ########## ######## ########
					{
						"operation": "insert",
						"parentName": "LeftContainer",
						"propertyName": "items",
						"name": "SelectButton",
						"values": {
							"caption": {"bindTo": "Resources.Strings.SelectButtonCaption"},
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"classes": {"textClass": "actions-button-margin-right"},
							"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
							"click": {"bindTo": "onSelectButtonClick"}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeftContainer",
						"propertyName": "items",
						"name": "CancelButton",
						"values": {
							"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"classes": {"textClass": "actions-button-margin-right"},
							"click": {"bindTo": "onCancelButtonClick"}
						}
					},
					{
						"operation": "insert",
						"name": "GeneralInfoTab",
						"parentName": "CardContentContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "GeneralInfoBlock",
						"parentName": "GeneralInfoTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "MainRecomendation",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "getMainRecomendation"}
						}
					},
					{
						"operation": "insert",
						"name": "ControlProcessBlock",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"visible": {"bindTo": "IsStageChangedByProcess"}
						}
					},
					{
						"operation": "insert",
						"name": "RadioGroup",
						"parentName": "ControlProcessBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
							"value": {"bindTo": "RadioGroup"},
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "GotoNextStage",
						"parentName": "RadioGroup",
						"propertyName": "items",
						"values": {
							"caption": {
								"bindTo": "NextStage",
								"bindConfig": {"converter": "onNextStageChanged"}
							},
							"value": "GotoNextStage"
						}
					},
					{
						"operation": "insert",
						"name": "RepeatStage",
						"parentName": "RadioGroup",
						"propertyName": "items",
						"values": {
							"caption": {"bindTo": "Resources.Strings.RepeatStageCaption"},
							"value": "RepeatStage"
						}
					},
					{
						"operation": "insert",
						"name": "GotoAnotherStage",
						"parentName": "RadioGroup",
						"propertyName": "items",
						"values": {
							"caption": {"bindTo": "Resources.Strings.GotoAnotherStageCaption"},
							"value": "GotoAnotherStage"
						}
					},
					{
						"operation": "insert",
						"name": "SelectedStage",
						"parentName": "ControlProcessBlock",
						"propertyName": "items",
						"values": {
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {"column": 0, "row": 1, "colSpan": 11},
							"visible": {"bindTo": "IsSelectedStageVisible"}
						}
					},
					{
						"operation": "insert",
						"name": "ExtraActivitiesBlock",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"visible": {"bindTo": "getIsActivitiesGridVisible"}
						}
					},
					{
						"operation": "insert",
						"name": "CheckExtraSteps",
						"parentName": "ExtraActivitiesBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.CheckExtraStepsCaption"},
							"labelClass": "t-label newLine-vertical-indent"
						}
					},
					{
						"operation": "insert",
						"name": "ExtraActivities",
						"parentName": "ExtraActivitiesBlock",
						"propertyName": "items",
						"values": OppManagementUtils.generateGridViewConfig("extra")
					},
					{
						"operation": "insert",
						"name": "EmptyGridMessage",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.EmptyGridMessage"},
							"labelClass": "t-label newLine-vertical-indent",
							"visible": {"bindTo": "getIsActivitiesGridInvisible"}
						}
					}
				]/**SCHEMA_DIFF*/,
				rules: {
					"SelectedStage": {
						"FilteringSelectedStageByCurrentStage": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							baseAttributePatch: "Id",
							comparisonType: BPMSoft.ComparisonType.NOT_EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "PresentationQuotation"
						}
					}
				}
			};
		});
