define("CasePage", ["BusinessRuleModule", "ServiceDeskConstants", "ConfigurationConstants", "EmailMessageConstants",
	"EmailHelper", "CaseMessageHistoryUtility", "BaseFiltersGenerateModule", "CasesEstimateLabel",
	"css!CaseProcessingCSS", "RelationshipsRecordsUtilities", "CaseTermCalculationDescribeUtilities",
	"TermCalculationInformation", "TermCalculationComponent", "css!CasePageTermCalculationCss"],
	function(BusinessRuleModule, ServiceDeskConstants, ConfigurationConstants, EmailMessageConstants, EmailHelper) {
		return {
			entitySchemaName: "Case",
			mixins: {
				CaseMessageHistoryUtility: "BPMSoft.CaseMessageHistoryUtility",
				RelationshipsRecordsUtilities: "BPMSoft.RelationshipsRecordsUtilities",
				CaseTermCalculationDescribeUtilities: "BPMSoft.CaseTermCalculationDescribeUtilities"
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
							"masterColumn": "emailTitle"
						}
					}
				},
				"Calls": {
					"schemaName": "CallDetail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Case"
					}
				},
				"ChildCase": {
					"schemaName": "CaseChildCaseDetail",
					"entitySchemaName": "Case",
					"filter": {
						"detailColumn": "ParentCase",
						"masterColumn": "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			messages: {
				/**
				 * @message SavePublishers
				 * Inform publishers its need to be saved
				 */
				"SavePublishers": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
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
				 * @message LaunchLoadEmailData
				 * Message that launches loading email data.
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
				},
				/**
				 * @message UpdateEmailSender
				 * Tells that email sender has to be updated.
				 */
				"UpdateEmailSender": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				"Contact": {
					"dependencies": [
						{
							"columns": ["Contact"],
							"methodName": "onContactChanged"
						}
					]
				},
				"Category": {
					"dependencies": [
						{
							"columns": ["Category"],
							"methodName": "onCategoryChanged"
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
				},
				"ParentCase": {
					lookupListConfig: {
						filter: function() {
							const masterRecordId = this.get("Id");
							const parentRecord = this.get("ParentCase");
							return this.mixins.RelationshipsRecordsUtilities.getHierarchicalFilter.call(this,
								masterRecordId, parentRecord, "ParentCase");
						}
					}
				},
				/**
				 * Information about terms calculation visibility.
				 */
				"TermCalculationInformationContainerVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},
				/**
				 * Input data for terms calculation.
				 */
				"CaseTermsDataValuePack": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},
				/**
				 * Header for term calculation information alignable container.
				 */
				"TermContainerHeader": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ActionsDashboardModule",
					"parentName": "ActionDashboardContainer",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClassName": ["actions-dashboard-module"]
						},
						"itemType": this.BPMSoft.ViewItemType.MODULE
					}
				},
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
						"isHeaderVisible": {
							"bindTo": "getIsMessageHistoryV2FeatureDisabled"
						},
						"controlConfig": {
							"collapsed": false,
							"collapsedchanged": {
								"bindTo": "onMessageHistoryGroupCollapsedChanged"
							}
						},
						"wrapClass": ["message-history-control-group"]
					},
					"parentName": "ProcessingTab",
					"propertyName": "items",
					"index": 0
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
					"name": "ProcessingTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ProcessingTabCaption"},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
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
						"bindTo": "ParentCase"
					},
					"parentName": "SolutionTab_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ChildCase",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "CaseInformationTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "EmailDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "CaseInformationTab",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "Calls",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "CaseInformationTab",
					"propertyName": "items",
					"index": 6
				},
				{
					"operation": "merge",
					"name": "SolutionDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SolutionDate",
						"generator": "BaseEditWithButtonGenerator.generateEditWithExtraButton",
						"buttonConfig": {
							"click": {"bindTo": "onShowSolutionTermsCalculation"},
							"tag": BPMSoft.configuration.TermCalculationInformationEnums.TermKind.SolutionDate,
							"imageConfig": {"bindTo": "Resources.Images.QuestionMarkIcon"},
							"visible": {"bindTo": "isNotIe"}
						},
						"enabled": false
					},
					"parentName": "TermsControlGroup_GridLayout",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "ResponseDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ResponseDate",
						"generator": "BaseEditWithButtonGenerator.generateEditWithExtraButton",
						"buttonConfig": {
							"click": {"bindTo": "onShowSolutionTermsCalculation"},
							"tag": BPMSoft.configuration.TermCalculationInformationEnums.TermKind.ResponseDate,
							"imageConfig": {"bindTo": "Resources.Images.QuestionMarkIcon"},
							"visible": {"bindTo": "isNotIe"}
						},
						"enabled": false
					},
					"parentName": "TermsControlGroup_GridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "TermCalculationInformationContainer",
					"values": {
						"id": "TermCalculationInformationContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.AlignableContainer",
						"visible": {"bindTo": "TermCalculationInformationContainerVisible"},
						"onKeyDown": {bindTo: "onTermCalculationInformationKeyDown"},
						"alignToEl": null,
						"wrapClass": ["term-alignable-container"],
						"showOverlay": {"bindTo": "TermCalculationInformationContainerVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TermCalculationHeaderImage",
					"parentName": "TermCalculationHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"items": [],
						"visible": {"bindTo": "TermCalculationInformationContainerVisible"},
						"click": {"bindTo": "hideTermCalculationInformation"},
						"imageConfig": {"bindTo": "Resources.Images.CrossImage"},
						"classes": {"wrapperClass": ["cross-image"]},

					},
				},
				{
					"operation": "insert",
					"name": "TermCalculationHeaderContainer",
					"parentName": "TermCalculationInformationContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header-wrap"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TermCalculationHeaderCaption",
					"parentName": "TermCalculationHeaderContainer",
					"propertyName": "items",
					"values": {
						"labelClass": ["label-in-header-container"],
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "TermContainerHeader"},
						"visible": {"bindTo": "TermCalculationInformationContainerVisible"}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "TermCalculationInformation",
					"parentName": "TermCalculationInformationContainer",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "TermCalculationInformationContainerVisible"},
						"className": "BPMSoft.TermCalculationInformation",
						"calculationData": {
							"bindTo": "CaseTermsDataValuePack"
						},
						"adjustWrapperPosition": {
							bindTo: "onCenterCalculationContainer"
						},
						"classes": {
							"wrapClassName": ["term-info"]
						},
						"itemType": BPMSoft.ViewItemType.COMPONENT
					}
				},
				{
					"operation": "insert",
					"name": "EditButtonsContainer",
					"parentName": "TermCalculationInformationContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["term-calculation-edit-button-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TermCalculationInformationCloseButton",
					"parentName": "EditButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
						"visible": {"bindTo": "TermCalculationInformationContainerVisible"},
						"click": {"bindTo": "hideTermCalculationInformation"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,

					}
				}
			], /**SCHEMA_DIFF*/
			methods: {

				/**
				* Check that browser is not IE.
				* @protected
				*/
				isNotIe: function() {
					return !this.Ext.isIE;
				},

				/**
				* Center component container relative to body.
				* @protected
				*/
				onCenterCalculationContainer: function() {
					const alignableContainer = Ext.get("TermCalculationInformationContainer");
					if (alignableContainer) {
						alignableContainer.center(Ext.getBody());
					}
				},
				/**
				 *  Checks if new history of messages enabled.
				 *  @public
				 */
				getIsMessageHistoryV2FeatureDisabled: function() {
					return !this.getIsFeatureEnabled("MessageHistoryV2");
				},
				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#onLookupResult
				 * @overridden
				 */
				onLookupResult: function(args) {
					if (args.columnName !== "ParentCase" || this.isNewMode()) {
						this.callParent(arguments);
					} else {
						const selectedItems = args.selectedRows.getItems();
						if (selectedItems.length !== 0) {
							const serviceArgs = {
								parentElement: selectedItems[0],
								childId: [this.get("Id")],
								schemaName: "Case",
								parentColumnName: "ParentCaseId",
								lookupParentColumnName: "ParentCase"
							};
							this.mixins.RelationshipsRecordsUtilities.callHierarchicalService.call(this, serviceArgs);
						}
					}
				},
				/**
				 * @inheritdoc BPMSoft.BasePageV2#updateDetails
				 * @overridden
				 */
				updateDetails: function() {
					this.callParent(arguments);
					this.sandbox.publish("InitModuleViewModel", null, [this.getMessageHistorySandboxId()]);
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
				 * Returns IDs of email message history module.
				 * @private
				 * @return {Array} Sandbox identifiers for email message history.
				 */
				getEmailMessageHistorySandboxIds: function() {
					const moduleIds = this.getActionsDashboardModuleIds();
					return moduleIds.map(function(id) {
						return id + "_EmailMessagePublisherModule";
					});
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					const id = this.get("PrimaryColumnValue");
					const tags = id ? [id] : null;
					this.sandbox.subscribe("ReloadCard", this.onReloadCard, this, tags);
					this.sandbox.subscribe("GetRecordInfo", this.onGetRecordInfoForHistory,
						this, [this.getMessageHistorySandboxId()]);
					this.sandbox.subscribe("LaunchLoadEmailData", this.onLoadEmailData,
						this, this.getEmailMessageHistorySandboxIds());
					this.callParent(arguments);
				},

				/**
				 * Handles contact changes.
				 * @protected
				 * @virtual
				 */
				onContactChanged: function() {
					const isMultiLanguage = this.getIsFeatureEnabled("EmailMessageMultiLanguage") ||
						this.getIsFeatureEnabled("EmailMessageMultiLanguageV2");
					if (isMultiLanguage) {
						this.updateEmailSender();
					}
				},

				/**
				 * Handles category changes.
				 * @protected
				 * @virtual
				 */
				onCategoryChanged: function() {
					this.mixins.CaseServiceUtility.onCategoryChanged.apply(this, arguments);
					if (this.BPMSoft.Features.getIsEnabled("CategoryFromMailBox")) {
						this.updateEmailSender();
					}
				},

				/**
				 * Fires message to update email sender.
				 * @protected
				 * @virtual
				 */
				updateEmailSender: function() {
					const contact = this.get("Contact");
					const category = this.get("Category");
					this.sandbox.publish("UpdateEmailSender", {
						contactId: contact && contact.value,
						categoryId: category && category.value
					}, this.getEmailMessageHistorySandboxIds());
				},

				/**
				 * Publishes email data.
				 * @private
				 */
				publishListenerEmailData: function() {
					const moduleIds = this.getEmailMessageHistorySandboxIds();
					this.sandbox.publish("SendListenerEmailData", this.get("EmailData"), moduleIds);
				},

				/**
				 * Starts process of getting email data
				 * @private
				 */
				onLoadEmailData: function() {
					this.set("emailTitle", this.getEmailTitle());
					this.getEmailData.call(this, this.publishListenerEmailData);
				},

				/**
				 * Returns title for an email to be sent from case section
				 * @returns {String} Email title
				 */
				getEmailTitle: function() {
					const emailTitleMessage = this.get("Resources.Strings.EmailTitleCaption");
					const title = this.get("Subject");
					const number = this.get("Number");
					return this.Ext.String.format(emailTitleMessage, number, title ? title : "");
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
							const items = response.collection.getItems();
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
						let data = {};
						if (response && response.success) {
							const items = response.collection.getItems();
							const email = items.length >= 1
								? EmailHelper.getEmailWithName(items[0].get("Email"), searchValue)
								: "";
							data = {email: email};
						}
						data.emailTitle = this.get("emailTitle");
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
					const data = {
						email: item.get("Email"),
						searchValue: "",
						emailTitle: this.get("emailTitle")
					};
					this.set("EmailData", data);
				},

				/**
				 * Returns response from database about email of the last history email message.
				 * @virtual
				 * @param {Function} callback Callback function.
				 */
				getHistoryEmailResponse: function(callback) {
					const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName + "MessageHistory",
						rowCount: 1
					});
					const createdOnColumn = esq.addColumn("CreatedOn");
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
					const contact = this.get("Contact");
					const account = this.get("Account");
					if (!contact && !account) {
						callback.call(this);
						return;
					}
					let esq = "";
					let searchValue = "";
					if (contact) {
						const emailColumnName = "Contact.Email";
						esq = this.getEmailQuery(contact.value, "Contact", emailColumnName);
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
				 * @param {String} emailcolumnName emailColumnName.
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getEmailQuery: function(filterValue, filterFieldName, emailcolumnName) {
					const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: filterFieldName + "Communication"
					});
					if (emailcolumnName) {
						esq.addColumn(emailcolumnName, "Email");
					} else {
						esq.addColumn("Number", "Email");
					}
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
					const subscribers = this.callParent(arguments);
					subscribers.push(this.getMessageHistorySandboxId());
					return subscribers;
				},

				/**
				 * Get filter for next steps detail.
				 * @protected
				 */
				getNextStepsDetailFilter: function() {
					const filterGroup = new this.BPMSoft.createFilterGroup();
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
					const config = arguments[1];
					if (this.isNewMode() && !(config && config.isSilent)) {
						this.saveUnsavedMessages();
					}
					this.set("ParentOnSavedArguments", arguments);
					this.checkMessageHistoryExists(true);
				},

				/**
				 * Returns ID of social message publisher module.
				 * @protected
				 * @obsolete
				 * @virtual
				 * @return {String} ID of social message publishers module.
				 */
				getSocialMessagePublisherModuleId: function() {
					const warningMessage = this.Ext.String.Format(
						this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
						"getSocialMessagePublisherModuleId", "");
					this.log(warningMessage, this.BPMSoft.LogMessageType.WARNING);
					return this.sandbox.id + "_module_ActionsDashboardModule_SocialMessagePublisherModule";
				},

				/**
				 * Saves local message in new mode.
				 * @protected
				 * @virtual
				 */
				saveUnsavedMessages: function() {
					this.sandbox.publish("SavePublishers", {
						masterRecordId: this.$Id
					});
				},

				/**
				 * The function of creating filters details email.
				 * @protected
				 * @returns {BPMSoft.FilterGroup} Filters details email.
				 */
				emailDetailFilter: function() {
					const filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					filterGroup.add("CaseFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Case", this.get("Id")));
					filterGroup.add("EmailFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
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
					this.set("emailTitle", this.getEmailTitle());
				},

				/**
				 * Explain Solution terms calculation button click.
				 * @protected
				 */
				onShowSolutionTermsCalculation: function() {
					const tag = arguments[3];
					this.$TermContainerHeader = this.getTermContainerHeader(tag);
					const data = {
						calculationParameters: this.getCaseTermCalculationParameters(),
						additionalData: this.getAdditionalData(tag)
					};
					this.set("CaseTermsDataValuePack", data);
					this.showTermsDescribeModule();
				},

				/**
				 * @protected
				 * Reveal terms calculation explanation.
				 */
				showTermsDescribeModule: function() {
					this.set("TermCalculationInformationContainerVisible", true);
				},

				/**
				 * @protected
				 * On Term calculation information key down handler.
				 */
				onTermCalculationInformationKeyDown: function(event) {
					if (event && event.keyCode === Ext.EventObject.ESC) {
						this.hideTermCalculationInformation();
					}
				},

				/**
				 * @protected
				 * Hide terms calculation explanation.
				 */
				hideTermCalculationInformation: function() {
					this.set("TermCalculationInformationContainerVisible", false);
				}
			},
			rules: {
				"ParentCase": {
					"ParentCaseRequired": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: ServiceDeskConstants.ClosureCode.CanceledAsDouble
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ClosureCode"
								}
							}
						]
					}
				}
			},
			modules: {
				ActionsDashboardModule: {
					"config": {
						"isSchemaConfigInitialized": true,
						"schemaName": "SectionActionsDashboard",
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"entitySchemaName": "Case",
								"actionsConfig": {
									"schemaName": "CaseStatus",
									"columnName": "Status",
									"colorColumnName": "Color",
									"filterColumnName": "IsDisplayed",
									"orderColumnName": "StageNumber",
									"decouplingConfig": {
										"name": "CaseNextStatus",
										"masterColumnName": "Status",
										"referenceColumnName": "NextStatus"
									}
								},
								"dashboardConfig": {
									"Activity": {
										"masterColumnName": "Id",
										"referenceColumnName": "Case"
									}
								}
							}
						}
					}
				}
			}
		};
	}
);
