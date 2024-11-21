define("CasePageV2", ["BaseFiltersGenerateModule", "ServiceDeskConstants", "CasesEstimateLabel",
	"ConfigurationConstants", "EmailMessageConstants", "BusinessRuleModule", "LocalMessageConstants", "EmailHelper",
		"css!CaseProcessingCSS"],
	function(BaseFiltersGenerateModule, ServiceDeskConstants, CasesEstimateLabel, ConfigurationConstants,
		EmailMessageConstants, BusinessRuleModule, LocalMessageConstants, EmailHelper) {
		return {
			entitySchemaName: "Case",
			messages: {
				/**
				 * @message SavePublishers
				 * Inform publishers its need to be saved
				 */
				"SavePublishers": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SendListenerEmailData
				 * Returns email data.
				 */
				"SendListenerEmailData": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message RerenderModule
				 *  Message of rerender for message history module.
				 */
				"RerenderModule": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message InitModuleViewModel
				 * Initialize message of message history view model.
				 */
				"InitModuleViewModel": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetListenerRecordInfo
				 *  Message of getting the listener record information.
				 */
				"GetListenerRecordInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message LaunchLoadEmailData
				 *  Message that launches loading email data.
				 */
				"LaunchLoadEmailData": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ShowSystemMessages
				 * Inform message history its need show system messages.
				 */
				"ShowSystemMessages": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message HideSystemMessages
				 * Inform message history its need hide system messages.
				 */
				"HideSystemMessages": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Owner column value.
				 */
				"Owner": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
				},
				/**
				 * Group column value.
				 */
				"Group": {
					lookupListConfig: {
						filter: function() {
							return BPMSoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue", [
								ServiceDeskConstants.SysAdminUnitType.Organization.Value,
								ServiceDeskConstants.SysAdminUnitType.Division.Value,
								ServiceDeskConstants.SysAdminUnitType.Managers.Value,
								ServiceDeskConstants.SysAdminUnitType.Team.Value
							]);
						}
					}
				},
				/**
				 * ResponseDate column caption.
				 */
				"ResponseDateCaption": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					dependencies: [
						{
							columns: ["ResponseDate"],
							methodName: "onPlanedDateChanged"
						},
						{
							columns: ["Status"],
							methodName: "onPlanedDateChanged"
						}
					]
				},
				/**
				 * Subject column.
				 */
				"Subject": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"dependencies": [
						{
							"columns": ["Subject"],
							"methodName": "onSubjectChanged"
						}
					]
				},
				/**
				 * IsResponseOverdue column flag.
				 */
				"IsResponseOverdue": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * True, if need show system messages.
				 */
				"NeedShowSystemMessages": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				/**
				 * True, if message history group collapsed.
				 */
				"IsMessageHistoryGroupCollapsed": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				/**
				 * True, if message history exists.
				 */
				"IsMessageHistoryExists": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"EmailDetailV2": {
					"schemaName": "EmailDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Case"
					},
					"filterMethod": "emailDetailFilter",
					"defaultValues": {
						"Title": {
							"masterColumn": "detailEmailTitle"
						}
					}

				},
				"Activity": {
					"schemaName": "CaseActivityDetail",
					"entitySchemaName": "Activity",
					"filter": {
						"detailColumn": "Case",
						"masterColumn": "Id"
					}
				},
				"Calls": {
					"schemaName": "CallDetail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Case"
					}
				},
				"KnowledgeBaseCase": {
					"schemaName": "KnowledgeBaseInCaseDetail",
					"entitySchemaName": "KnowledgeBaseInCase",
					"filter": {
						"detailColumn": "Case",
						"masterColumn": "Id"
					}
				},
				"NextSteps": {
					"schemaName": "NextStepsDetail",
					"entitySchemaName": "Activity",
					"filterMethod": "getNextStepsDetailFilter",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Case"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				// Publishers
				{
					"operation": "insert",
					"parentName": "ProcessingTab",
					"name": "MessagePublishersContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "MessagePublishersContainer",
					"propertyName": "items",
					"name": "MessagePublishers",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "MessagePublishersModule",
						"afterrender": {
							"bindTo": "loadPublishers"
						},
						"afterrerender": {
							"bindTo": "loadPublishers"
						}
					}
				},
				// History
				{
					"operation": "insert",
					"name": "MessageHistoryGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.MessageHistoryGroupCaption"
						},
						"items": [],
						"tools": [],
						"controlConfig": {
							"collapsed": false,
							"collapsedchanged": {
								"bindTo": "onMessageHistoryGroupCollapsedChanged"
							}
						}
					},
					"parentName": "ProcessingTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ShowSystemMessagesLabel",
					"parentName": "MessageHistoryGroup",
					"propertyName": "tools",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ShowSystemMessagesString"
						},
						"labelClass": ["systemMessageVisibilityLabel"],
						"visible": {
							"bindTo": "getShowSystemMessagesLabelVisible"
						},
						"click": {
							"bindTo": "showSystemMessages"
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HideSystemMessagesLabel",
					"parentName": "MessageHistoryGroup",
					"propertyName": "tools",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.HideSystemMessagesString"
						},
						"labelClass": ["systemMessageVisibilityLabel"],
						"visible": {
							"bindTo": "getHideSystemMessagesLabelVisible"
						},
						"click": {
							"bindTo": "hideSystemMessages"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "MessageHistoryGroup",
					"name": "MessageHistoryContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "MessageHistoryContainer",
					"propertyName": "items",
					"name": "MessageHistory",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "MessageHistoryModule",
						"afterrender": {"bindTo": "loadMessage"},
						"afterrerender": {"bindTo": "loadMessage"}
					}
				},
				{
					"operation": "insert",
					"name": "Activity",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ParametersTab",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "Calls",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ParametersTab",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "KnowledgeBaseCase",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ParametersTab",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "EmailDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ParametersTab",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "NextSteps",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ProcessingTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "RespondedOn",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "RespondedOn",
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Group",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Group",
						"controlConfig": {
							"prepareList": {"bindTo": "onPrepareGroup"}
						}
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Owner",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Owner",
						"contentType": BPMSoft.ContentType.LOOKUP,
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareOwner"
							}
						}
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"

				},
				{
					"operation": "insert",
					"name": "AssignToMeButton",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AssignToMeCaption"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": ["caseLinkButton", "assignToButton"]
						},
						"click": {"bindTo": "onAssignToMeClick"}
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				// ResponseLabel
				{
					"operation": "insert",
					"name": "ResponseCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "ResponseCaptionContainer",
						"selectors": {"wrapEl": "#ResponseCaptionContainer"},
						"layout": {
							"column": 4,
							"row": 4,
							"colSpan": 6,
							"rowSpan": 1
						},
						"markerValue": "ResponseCaptionContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["estimate-caption-container"],
						"items": []
					},
					"parentName": "CaseParameters_gridLayout"
				},
				{
					"operation": "insert",
					"name": "ResponseTimerImageContainer",
					"parentName": "ResponseCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "ResponseTimerImageContainer",
						"selectors": {"wrapEl": "#ResponseTimerImageContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["timer-image-container"],
						"visible": {
							"bindTo": "isResponseTimerImageVisible"
						},
						"markerValue": "ResponseTimerImageContainer",
						"afterrerender": {
							"bindTo": "renderCaptionStyle"
						},
						"afterrender": {
							"bindTo": "renderCaptionStyle"
						},
						"items": []
					},
					"index": 10
				},
				{
					"operation": "insert",
					"name": "MinutesCaption",
					"parentName": "ResponseCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "ResponseMinutesCaption",
						"labelClass": ["estimate-caption-label"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getResponseDateMinute"
						},
						"visible": {
							"bindTo": "isResponseHourVisible"
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "EstimateSeconds",
					"parentName": "ResponseCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "ResponseEstimateSeconds",
						"labelClass": ["estimate-caption-label blink"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": ":",
						"visible": {
							"bindTo": "isResponseHourVisible"
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ResponseCaptionLabel",
					"parentName": "ResponseCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "ResponseCaptionLabel",
						"labelClass": ["estimate-caption-label day"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getResponseDateDay"
						},
						"visible": {
							"bindTo": "isResponseCaptionVisible"
						},
						"afterrerender": {"bindTo": "renderCaptionStyle"},
						"afterrender": {"bindTo": "renderCaptionStyle"}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ResponseCaptionPrefix",
					"parentName": "ResponseCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "ResponseCaptionPrefix",
						"labelClass": ["estimate-caption-label prefix"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getResponseCaptionPrefix"
						},
						"visible": {
							"bindTo": "isResponseCaptionVisible"
						}
					},
					"index": 0
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * Forms Owner's collection.
				 * @private
				 * @param {String} filter
				 */
				onPrepareOwner: function(filter) {
					this.getUsersInGroups(function(usersInGroupsCollection, scope) {
						var prepareListColumnName = "Owner";
						scope.set("PrepareListColumnName", prepareListColumnName);
						var esq = scope.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "SysAdminUnit"
						});
						esq.addColumn("Contact");
						var group = scope.get("Group");
						if (!group || group.value === scope.BPMSoft.GUID_EMPTY) {
							var filterGroup = new scope.BPMSoft.createFilterGroup();
							var ownerDependeceFilters = scope.getOwnerDependenceFilters(scope);
							if (ownerDependeceFilters) {
								filterGroup.add(scope.getOwnerDependenceFilters(scope));
							}
							filterGroup.add("ContactExistsFilter", scope.BPMSoft.createColumnIsNotNullFilter("Contact"));
							esq.filters.add(filterGroup);
						}
						esq.filters.logicalOperation = scope.BPMSoft.LogicalOperatorType.OR;
						if (usersInGroupsCollection.length > 0) {
							esq.filters.add("OwnerCollectionFilter",
								scope.BPMSoft.createColumnInFilterWithParameters("Id", usersInGroupsCollection));
						}
						esq.getEntityCollection(function(result) {
							var existsCollection = [];
							if (result.success) {
								result.collection.each(function(item) {
									existsCollection.push(item.get("Contact").value);
								});
							}
							var filtersCollection = scope.BPMSoft.createFilterGroup();
							if (existsCollection.length > 0) {
								filtersCollection.add("existsFilter",
									scope.BPMSoft.createColumnInFilterWithParameters("Id", existsCollection));
							} else {
								filtersCollection.add("emptyFilter", scope.BPMSoft.createColumnIsNullFilter("Id"));
							}
							scope.set(prepareListColumnName + "Filters", filtersCollection);
							scope.loadLookupData(filter, scope.get(prepareListColumnName + "List"),
								prepareListColumnName, true);
						}, scope);
					}, this);
				},

				/**
				 * Forms Group's collection.
				 * @private
				 * @param {String} filter
				 */
				onPrepareGroup: function(filter) {
					var prepareListColumnName = "Group";
					this.set("PrepareListColumnName", prepareListColumnName);
					this.getGroupEsq(function(esq, scope) {
						esq.getEntityCollection(function(result) {
							var existsCollection = [];
							if (result.success) {
								result.collection.each(function(item) {
									existsCollection.push(item.get("Id"));
								});
							}
							var filtersCollection = scope.BPMSoft.createFilterGroup();
							if (existsCollection.length > 0) {
								filtersCollection.add("existsFilter", scope.BPMSoft.createColumnInFilterWithParameters(
									"Id", existsCollection));
							} else {
								filtersCollection.add("emptyFilter", scope.BPMSoft.createColumnIsNullFilter("Id"));
							}
							scope.set(prepareListColumnName + "Filters", filtersCollection);
							scope.loadLookupData(filter, scope.get(prepareListColumnName + "List"),
								prepareListColumnName, true);
						}, scope);
					}, this);
				},

				/**
				 * Forms an instance of EntitySchemaQuery "Object" to select suitable group
				 * @private
				 * @param {Function} callback Function that forms the collection of "Group"
				 * @param {BPMSoft.BaseSchemaViewModel} scope Execution context of callback function
				 */
				getGroupEsq: function(callback, scope) {
					var esq = scope.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysAdminUnit"
					});
					esq.addColumn("Id");
					var ownerDependeceFilters = scope.getOwnerDependenceFilters(scope);
					if (ownerDependeceFilters) {
						esq.filters.add(scope.getOwnerDependenceFilters(scope));
					}
					esq.filters.add("ContactNotExistsFilter", scope.BPMSoft.createColumnIsNullFilter("Contact"));
					callback(esq, scope);
				},

				/**
				 * Returns filters for fields "Owner" and "Group".
				 * @protected
				 * @virtual
				 */
				getOwnerDependenceFilters: this.BPMSoft.emptyFn,

				/**
				 * Forms collection of "Owner"'s within the group "Service Engineer".
				 * @private
				 * @param {Function} callback  Function of Owner's collection for list
				 * @param {BPMSoft.BaseSchemaViewModel} scope Context of callback-function
				 */
				getUsersInGroups: function(callback, scope) {
					scope.getGroupListCollection(function(groupCollection) {
						var prepareListColumnName = "Group";
						scope.set("PrepareListColumnName", prepareListColumnName);
						var esq = scope.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "SysAdminUnit"
						});
						esq.addColumn("Id");
						var group = scope.get("Group");
						if (group && group.value !== scope.BPMSoft.GUID_EMPTY) {
							groupCollection = [group.value];
						}
						if (groupCollection.length > 0) {
							esq.filters.add("GroupCollectionFilter", scope.BPMSoft.createColumnInFilterWithParameters(
								"[SysUserInRole:SysUser].SysRole", groupCollection));
						} else {
							esq.filters.add("emptyFilter", scope.BPMSoft.createColumnIsNullFilter("Id"));
						}
						esq.getEntityCollection(function(result) {
							var existsCollection = [];
							if (result.success) {
								result.collection.each(function(item) {
									existsCollection.push(item.get("Id"));
								});
							}
							callback(existsCollection, scope);
						}, scope);
					}, scope);
				},

				/**
				 * Get list of administrative groups.
				 * @private
                 * @param {Function} callback  Function of Owner's collection for list.
                 * @param {BPMSoft.BaseSchemaViewModel} scope Context of callback-function.
				 */
				getGroupListCollection: function(callback, scope) {
					scope.getGroupEsq(function(esq, scope) {
						esq.getEntityCollection(function(result) {
							var existsCollection = [];
							if (result.success) {
								result.collection.each(function(item) {
									existsCollection.push(item.get("Id"));
								});
							}
							callback(existsCollection);
						}, scope);
					}, scope);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @protected
				 * @overridden
				 */
				init: function() {
					if (this.isEditMode()) {
						this.callParent(arguments);
						return;
					}
					if (this.get("CallParentInit")) {
						this.set("CallParentInit", false);
						this.callParent(arguments);
						return;
					}
					this.set("ParentInitArguments", arguments);
					this.initPublishersCollection(true);
				},

				/**
				 * Entity initialization end event.
				 * @protected
				 * @overriden
				 */
				onEntityInitialized: function() {
					this.onLoadEmailData();
					this.checkMessageHistoryExists();
					this.callParent(arguments);
				},

				/**
				 * Calculation of date difference for ResponseDate.
				 * @protected
				 * @overidden
				 */
				setDateDiff: function() {
					this.callParent(arguments);
					if (!CasesEstimateLabel.isCaptionVisible(this)) {
						return;
					}
					CasesEstimateLabel.calculateDateDiff("ResponseDate", "ResponseDateCaption",
						"IsResponseOverdue", this);
				},

				/**
				 * Sets number of days and time for response date.
				 * @returns {string}
				 */
				getResponseDateDay: function() {
					var isOverdue = this.get("IsResponseOverdue");
					return CasesEstimateLabel.setDayDiff("ResponseDateCaption", isOverdue, this);
				},

				/**
				 * Sets value of remaining minutes for response date.
				 * @returns {string}
				 */
				getResponseDateMinute: function() {
					return CasesEstimateLabel.getDateMinute("ResponseDateCaption", this);
				},

				/**
				 * Displays time.
				 * @returns {boolean|*|*}
				 */
				isResponseHourVisible: function() {
					return (CasesEstimateLabel.isHourVisible("ResponseDateCaption", this) &&
					this.isResponseCaptionVisible());
				},

				/**
				 * Displays image.
				 * @returns {*|boolean}
				 */
				isResponseTimerImageVisible: function() {
					return (this.isTimerImageVisible() && this.isResponseCaptionVisible() &&
					CasesEstimateLabel.isNewRequest(this));
				},

				/**
				 * Gets the value of prefix of response date caption.
				 * @returns {string}
				 */
				getResponseCaptionPrefix: function() {
					return this.get("IsResponseOverdue") ?
						this.get("Resources.Strings.DelayHeaderCaptionSuffix") :
						this.get("Resources.Strings.LeftHeaderCaptionSuffix");
				},

				/**
				 * Displays the value of response date label.
				 * @returns {boolean|*|*}
				 */
				isResponseCaptionVisible: function() {
					var CaseStatus = this.get("Status");
					var responseDate = CasesEstimateLabel.isResponseDate(this);
					return ((CasesEstimateLabel.isCaptionVisible(this) && responseDate && CaseStatus &&
					CasesEstimateLabel.isNewRequest(this)) ||
					(CasesEstimateLabel.isCaptionVisible(this) && this.get("IsResponseOverdue") && responseDate));
				},

				/**
				 * Returns module ID of message publishers.
				 * @private
				 * @return {String} Sandbox identifier for message publishers.
				 */
				getMessagePublishersSandboxId: function() {
					return this.sandbox.id + "_MessagePublishersModule";
				},

				/**
				 * Returns module ID of message history.
				 * @private
				 * @return {String} Sandbox identifier for message history.
				 */
				getMessageHistorySandboxId: function() {
					return this.sandbox.id + "_MessageHistoryModule";
				},

				/**
				 * Returns module ID of email message history.
				 * @private
				 * @return {String} Sandbox identifier for email message history.
				 */
				getEmailMessageHistorySandboxId: function() {
					return this.sandbox.id + "_MessagePublishersModule_EmailMessagePublisherModule";
				},

				/**
				 * Rerenders module of message publishers.
				 * @protected
				 * @virtual
				 */
				loadPublishers: function() {
					var moduleId = this.getMessagePublishersSandboxId();
					var rendered = this.sandbox.publish("RerenderModule", {
						renderTo: "MessagePublishers"
					}, [moduleId]);
					if (!rendered) {
						var messagePublishersModuleConfig = {
							renderTo: "MessagePublishers",
							id: moduleId
						};
						this.sandbox.loadModule("MessagePublishersModule", messagePublishersModuleConfig);
					}
				},

				/**
				 * Rerenders module of history message.
				 * @protected
				 * @virtual
				 */
				loadMessage: function() {
					var moduleId = this.getMessageHistorySandboxId();
					var rendered = this.sandbox.publish("RerenderModule", {
						renderTo: "MessageHistory"
					}, [moduleId]);
					if (!rendered) {
						var messageHistoryModuleConfig = {
							renderTo: "MessageHistory",
							id: moduleId
						};
						this.sandbox.loadModule("MessageHistoryModule", messageHistoryModuleConfig);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#updateDetails
				 * @overridden
				 */
				updateDetails: function() {
					this.callParent(arguments);
					this.sandbox.publish("InitModuleViewModel", null, [this.getMessageHistorySandboxId()]);
					this.sandbox.publish("InitModuleViewModel", null, [this.getMessagePublishersSandboxId()]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					var id = this.get("PrimaryColumnValue");
					var tags = id ? [id] : null;
					this.sandbox.subscribe("ReloadCard", this.onReloadCard, this, tags);
					this.sandbox.subscribe("GetRecordInfo", this.onGetRecordInfoForHistory,
						this, [this.getMessageHistorySandboxId()]);
					this.sandbox.subscribe("GetRecordInfo", this.getSectionId,
						this, [this.getMessagePublishersSandboxId()]);
					this.sandbox.subscribe("GetListenerRecordInfo", this.onGetRecordInfoForPublisher, this);
					this.sandbox.subscribe("LaunchLoadEmailData", this.onLoadEmailData,
						this, [this.getEmailMessageHistorySandboxId()]);
					this.callParent(arguments);
				},

				/**
				 * Returns information about record for message modules.
				 * @protected
				 * @virtual
				 * @return {Object} Record information.
				 */
				getSectionId: function() {
					var moduleConfig = this.BPMSoft.configuration.ModuleStructure[this.entitySchemaName];
					return {
						sectionId: moduleConfig ? moduleConfig.moduleId : null
					};
				},

				/**
				 * Returns information about message history record.
				 * @protected
				 * @virtual
				 * @return {Object} Record information.
				 */
				onGetRecordInfoForHistory: function() {
					var entitySchemaName = this.entitySchema.name;
					var historySchemaName = entitySchemaName + "MessageHistory";
					var primaryColumnValue = this.get("PrimaryColumnValue") || this.get(this.entitySchema.primaryColumnName);
					if (this.isCopyMode()) {
						primaryColumnValue = null;
					}
					var moduleConfig = this.BPMSoft.configuration.ModuleStructure[this.entitySchemaName];
					return {
						relationEntityId: primaryColumnValue,
						historySchemaName: historySchemaName,
						historyRelationColumn: entitySchemaName,
						sectionId: moduleConfig.moduleId
					};
				},

				/**
				 * Sets the message publishers for the current section.
				 * @private
				 */
				initPublishersCollection: function(isNeed) {
					var messagePublishers = [];
					var section = this.getSectionId();
					if (section == null) {
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "MessagePublisherBySection"
					});
					esq.addColumn("MessagePublisher.ClassName", "ModuleName");
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Section", section.sectionId));
					esq.getEntityCollection(function(result) {
						if (!result.success) {
							return;
						}
						var items = result.collection.getItems();
						this.BPMSoft.each(items, function(item) {
							messagePublishers.push(item.get("ModuleName"));
						}, this);
						this.set("MessagePublishers", messagePublishers);
						if (isNeed) {
							this.set("CallParentInit", true);
							this.init.apply(this, this.get("ParentInitArguments"));
						}

					}, this);
				},

				/**
				 * Returns ID of message publisher module.
				 * @protected
				 * @virtual
				 * @return {Array} IDs of message publishers module.
				 */
				getMessagePublishersModuleIds: function() {
					var publishers = this.get("MessagePublishers");
					var messagePublishersSandboxIds = [];
					var sandboxId = this.sandbox.id + "_MessagePublishersModule_";
					this.BPMSoft.each(publishers, function(item) {
						messagePublishersSandboxIds.push(sandboxId + item);
					}, this);
					return messagePublishersSandboxIds;
				},

				/**
				 * @inheritDoc BaseModulePageV2#getSaveRecordMessagePublishers
				 * @overridden
				 */
				getSaveRecordMessagePublishers: function() {
					var publishers = this.callParent(arguments);
					return publishers.concat(this.getMessagePublishersModuleIds());
				},

				/**
				 * Publishes email data.
				 * @private
				 */
				publishListenerEmailData: function() {
					var moduleId = this.getEmailMessageHistorySandboxId();
					this.sandbox.publish("SendListenerEmailData", this.get("EmailData"), [moduleId]);
				},

				/**
				 * Starts process of getting email data
				 * @private
				 */
				onLoadEmailData: function() {
					this.set("detailEmailTitle", this.getEmailTitle());
					this.getEmailData.call(this, this.publishListenerEmailData);
				},

				/**
				 * Returns title for an email to be sent from case section
				 * @returns {String} Email title
				 */
				getEmailTitle: function() {
					var emailTitleMessage = this.get("Resources.Strings.EmailTitleCaption");
					var title = this.get("Subject");
					var number = this.get("Number");
					return this.Ext.String.format(emailTitleMessage, number, title);
				},

				/**
				 * Returns information about record for subscriber message module.
				 * @protected
				 * @virtual
				 * @return {Object} Record information.
				 */
				onGetRecordInfoForPublisher: function() {
					var relationSchemaName = this.entitySchema.name;
					var relationSchemaUId = this.entitySchema.uId;
					var relationSchemaRecordId = this.get(this.primaryColumnName);
					var title = this.getEmailTitle();
					return {
						relationSchemaName: relationSchemaName,
						relationSchemaUId: relationSchemaUId,
						relationSchemaRecordId: relationSchemaRecordId,
						additionalInfo: {
							title: title
						}
					};
				},

				/**
				 * In case of email existence in the history fills email data from history.
				 * Otherwise, finds email from contact and account
				 * @virtual
				 * @param {Function} callback Callback function
				 */
				getEmailData: function(callback) {
					this.getHistoryEmailResponse.call(this, function(response) {
						if (response && response.success) {
							var items = response.collection.getItems();
							if (items.length) {
								this.setEmailDataFromHistory(items[0]);
								callback.call(this);
							} else {
								this.setEmailDataFromProfile(callback);
							}
						}
					}, this);
				},

				/**
				 * Sets email data from contact or account.
				 * @protected
				 * @param {Object} callback The callback function
				 */
				setEmailDataFromProfile: function(callback) {
					this.getProfileEmailResponse.call(this, function(searchValue, response) {
						var data = {};
						if (response && response.success) {
							var items = response.collection.getItems();
							var email = items.length >= 1
									? EmailHelper.getEmailWithName(items[0].get("Email"), searchValue)
									: "";
							data = { email: email};
						}
						this.set("EmailData", data);
						callback.call(this);
					}, this);
				},

				/**
				 * Sets email data from the last history email message.
				 * @private
				 * @param {Object} item History message item
				 */
				setEmailDataFromHistory: function(item) {
					var data = {
						email: item.get("Email"),
						searchValue: ""
					};
					this.set("EmailData", data);
				},

				/**
				 * Returns response from database about email of the last history email message.
				 * @virtual
				 * @param {Function} callback Callback function.
				 */
				getHistoryEmailResponse: function(callback) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName + "MessageHistory",
						rowCount: 1
					});
					var createdOnColumn = esq.addColumn("CreatedOn");
					createdOnColumn.orderPosition = 0;
					createdOnColumn.orderDirection = this.BPMSoft.OrderDirection.DESC;
					esq.addColumn("[Activity:Id:RecordId].Sender", "Email");
					esq.filters.add("CaseFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, this.entitySchemaName, this.get("Id")));
					esq.filters.add("CommunicationFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "MessageNotifier", EmailMessageConstants.MessageNotifier.Email));
					esq.filters.add("EmailTypeFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "[Activity:Id:RecordId].MessageType",
						ConfigurationConstants.Activity.MessageType.Incoming));
					esq.getEntityCollection(function(response) {
						callback.call(this, response);
					}, this);
				},

				/**
				 * Calls email from database from contact or account.
				 * @virtual
				 * @param {Function} callback Callback function.
				 */
				getProfileEmailResponse: function(callback) {
					var contact = this.get("Contact");
					var account = this.get("Account");
					if (!contact && !account) {
						callback.call(this);
						return;
					}
					var esq = "";
					var searchValue = "";
					if (contact) {
						esq = this.getEmailQuery(contact.value, "Contact");
						searchValue = contact.displayValue;
					}
					if (!contact && account) {
						esq = this.getEmailQuery(account.value, "Account");
						searchValue = account.displayValue;
					}
					esq.getEntityCollection(function(response) {
						callback.call(this, searchValue, response);
					}, this);
				},

				/**
				 * Returns email query.
				 * @protected
				 * @param {String} filterValue Filter key.
				 * @param {String} filterFieldName Filter search column.
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getEmailQuery: function(filterValue, filterFieldName) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: filterFieldName + "Communication"
					});
					esq.addColumn("Number", "Email");
					esq.filters.add(filterFieldName + "Filter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, filterFieldName, filterValue));
					esq.filters.add("CommunicationFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "CommunicationType", ConfigurationConstants.CommunicationType.Email));
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getEntityInitializedSubscribers
				 * @overridden
				 */
				getEntityInitializedSubscribers: function() {
					var subscribers = this.callParent(arguments);
					subscribers.push(this.getMessageHistorySandboxId());
					subscribers.push(this.getMessagePublishersSandboxId());
					return subscribers;
				},

				/**
				 * "Assign to me" button handler.
				 * Set owner by current user contact.
				 * @protected
				 */
				onAssignToMeClick: function() {
					this.set("Owner", this.BPMSoft.SysValue.CURRENT_USER_CONTACT);
				},

				/**
				 * Get filter for next steps detail.
				 * @protected
				 */
				getNextStepsDetailFilter: function() {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("CaseFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Case", this.get("Id")));
					filterGroup.add("TypeFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Task));
					filterGroup.add("StatusFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Status.Finish", 0));
					return filterGroup;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					if (this.get("CallParentOnSaved")) {
						this.set("CallParentOnSaved", false);
						this.callParent(arguments);
						return;
					}
					var config = arguments[1];
					if (this.isNewMode() && !(config && config.isSilent)) {
						this.saveUnsavedMessages();
					}
					this.set("ParentOnSavedArguments", arguments);
					this.checkMessageHistoryExists(true);
				},

				/**
				 * Returns ID of social message publisher module.
				 * @protected
				 * @virtual
				 * @return {String} ID of social message publishers module.
				 */
				getSocialMessagePublisherModuleId: function() {
					return this.sandbox.id + "_MessagePublishersModule_SocialMessagePublisherModule";
				},

				/**
				 * Saves local message in new mode.
				 * @protected
				 * @virtual
				 */
				saveUnsavedMessages: function() {
					var socialMessagePublisherModuleId = this.getSocialMessagePublisherModuleId();
					this.sandbox.publish("SavePublishers", null, [socialMessagePublisherModuleId]);
				},

				/**
				 * The function of creating filters details email.
				 * @protected
				 * @returns {BPMSoft.FilterGroup} Filters details email.
				 */
				emailDetailFilter: function() {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					filterGroup.add("CaseFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Case", this.get("Id")));
					filterGroup.add("EmailFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				},

				/**
				 * Checks the number of MessageHistory records.
				 * @private
				 */
				checkMessageHistoryExists: function(isNeed) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName + "MessageHistory"
					});
					esq.addColumn("Id");
					esq.filters.add("EntitySchemaFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, this.entitySchemaName, this.get("Id")));
					esq.filters.add("CommunicationFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "MessageNotifier", LocalMessageConstants.MessageNotifier.Local));

					esq.getEntityCollection(function(response) {
						if (response.success) {
							var rowsCount = response.collection.getCount();
							this.set("IsMessageHistoryExists", rowsCount > 0);
						}
						if (isNeed) {
							this.set("CallParentOnSaved", true);
							this.onSaved.apply(this, this.get("ParentOnSavedArguments"));
						}
					}, this);
				},

				/**
				 * Returns visibility of show system message button.
				 * @private
				 * @return {Boolean} Visibility of hide system message button.
				 */
				getShowSystemMessagesLabelVisible: function() {
					return !this.get("IsMessageHistoryGroupCollapsed") && !this.get("NeedShowSystemMessages") &&
						this.get("IsMessageHistoryExists");
				},

				/**
				 * Returns visibility of hide system message button.
				 * @private
				 * @return {Boolean} Visibility of hide system message button.
				 */
				getHideSystemMessagesLabelVisible: function() {
					return !this.get("IsMessageHistoryGroupCollapsed") && this.get("NeedShowSystemMessages") &&
						this.get("IsMessageHistoryExists");
				},

				/**
				 * Handle collapsed of message history group.
				 * @private
				 * @param {Boolean} isCollapsed Collapsed of message history group.
				 */
				onMessageHistoryGroupCollapsedChanged: function(isCollapsed) {
					return this.set("IsMessageHistoryGroupCollapsed", isCollapsed);
				},

				/**
				 * Hides system message.
				 * @private
				 */
				hideSystemMessages: function() {
					this.set("NeedShowSystemMessages", false);
					this.sandbox.publish("HideSystemMessages", null, [this.getMessageHistorySandboxId()]);
				},

				/**
				 * Shows system message.
				 * @private
				 */
				showSystemMessages: function() {
					this.set("NeedShowSystemMessages", true);
					this.sandbox.publish("ShowSystemMessages", null, [this.getMessageHistorySandboxId()]);
				},

				/**
				 * Fires when subject is changed.
				 * @protected
				 */
				onSubjectChanged: function() {
					this.set("detailEmailTitle", this.getEmailTitle());
				}
			},
			rules: {
				"Category": {
					"CategoryRequired": {
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
				}
			}
		};
	});
