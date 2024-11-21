/**
 * Schema of Marketing email element page
 */
define("MarketingEmailPage", ["MarketingEmailPageResources", "BaseFiltersGenerateModule", "LookupUtilities",
		"MarketingEnums", "CampaignElementMixin", "DropdownLookupMixin"],
	function(resources, BaseFiltersGenerateModule, LookupUtilities, MarketingEnums) {
		return {
			attributes: {
				/**
				 * Bulk email sender name.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"SenderName": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "Sender name"
				},

				/**
				 * Bulk email sender email address.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"SenderEmail": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "Sender email"
				},

				/**
				 * Bulk email template Subject.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Subject": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "Subject"
				},

				/**
				 * Bulk email AudienceSchema.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				"AudienceSchema": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "Audience source"
				},

				/**
				 * Bulk email expiration date.
				 * @type {BPMSoft.dataValueType.DATE}
				 */
				"ExpirationDate": {
					"dataValueType": this.BPMSoft.DataValueType.DATE_TIME,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "ExpirationDate"
				},

				/**
				 * Bulk email status.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				 "Status": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "Status"
				},

				/**
				 * Bulk email priority.
				 * @type {BPMSoft.dataValueType.LOOKUP}
				 */
				 "Priority": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": "Priority"
				},

				/**
				 * Bulk email AudienceSchemaName.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"AudienceSchemaName": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Uses for indicate when clear outgoing connections dialog is active.
				 * @type {Boolean}
				 */
				"IsClearQuestion": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * Outgoing transitions which depend on the current element.
				 * @type {Array[]}
				 */
				"DependentTransitions": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": []
				}
			},
			methods: {

				/**
				 * Returns filters based on linked campaigns for bulkemails.
				 * @private
				 * @returns {BPMSoft.FilterGroup} Filters by campaign id.
				 */
				_getCurrentCampaignBulkEmailFilter: function() {
					var currentElement = this.$ProcessElement;
					var campaignFilterGroup = BPMSoft.createFilterGroup();
					campaignFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
					campaignFilterGroup.addItem(BPMSoft.createColumnIsNullFilter("Campaign"));
					campaignFilterGroup.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Campaign", currentElement.parentSchema.entityId)
					);
					return campaignFilterGroup;
				},

				/**
				 * Returns filters for bulk emails that are in use by other elements of current campaign.
				 * @private
				 * @returns {BPMSoft.InFilter} Filters by used bulkemail ids in current capmaign schema.
				 */
				_getExcludeNeighborsBulkEmailFilter: function() {
					var selectedEmailIds = [];
					var currentElement = this.get("ProcessElement");
					BPMSoft.each(currentElement.parentSchema.flowElements, function(el) {
						if (el instanceof BPMSoft.MarketingEmailSchema
								&& el.marketingEmailId
								&& el.uId !== currentElement.uId) {
							var rightExpression = Ext.create("BPMSoft.ParameterExpression", {
								parameterDataType: BPMSoft.DataValueType.GUID,
								parameterValue: el.marketingEmailId
							});
							selectedEmailIds.push(rightExpression);
						}
					}, this);
					var leftExpression = Ext.create("BPMSoft.ColumnExpression", {
						columnPath: "Id"
					});
					var notInFilter = BPMSoft.createInFilter(leftExpression, selectedEmailIds);
					notInFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
					return notInFilter;
				},

				/**
				 * Shows message box with clear outgoing connections question.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Context.
				 */
				_showWarningMessage: function(message, resolve, reject, scope) {
					var caption = resources.localizableStrings.ClearOutgoingsQuestionTitle;
					var buttons = [BPMSoft.MessageBoxButtons.YES, BPMSoft.MessageBoxButtons.CANCEL];
					var handler = function(returnCode) {
						if (returnCode === "yes") {
							resolve.call(scope);
						}
						if (returnCode === "cancel") {
							reject.call(scope);
						}
					};
					this.showMessageBox(caption, message, buttons, handler, scope);
				},

				/**
				 * @private
				 */
				_getAudienceSchemaVisibility: function() {
					return BPMSoft.Features.getIsEnabled("CampaignAudienceImport") && this.isEntitySelected();
				},

				/**
				 * @private
				 */
				_setAudienceSchemaName: function() {
					if (!this.$AudienceSchema) {
						this.$AudienceSchemaName = null;
						return;
					}
					var audienceSchemaId = this.$AudienceSchema.value;
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmailAudienceSchema"
					});
					esq.addColumn("EntityObject.Name", "SchemaName");
					esq.filters.add("idFilter",
						esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id", audienceSchemaId));
					esq.getEntityCollection(function (result) {
						if (result.success) {
							this.$AudienceSchemaName = result.collection.firstOrDefault().$SchemaName;
						}
					}, this);
				},

				/**
				 * Returns message for clear outgoing connections question.
				 * @protected
				 * @returns {String} Message text.
				 */
				getClearOutgoingTransitionsMessage: function() {
					var message = resources.localizableStrings.ClearOutgoingsQuestion;
					var outgoingsNames = [];
					BPMSoft.each(this.$DependentTransitions, function(element) {
						var caption = Ext.String.format("\"{0}\"", element.getCaption() || "");
						outgoingsNames.push(caption);
					}, this);
					return Ext.String.format(message, outgoingsNames.join(", "));
				},

				/**
				 * Returns message for existing participants on current step.
				 * @protected
				 * @param {Number} participantsCount Number of participants on the current step.
				 * @returns {String} Message text.
				 */
				getHasParticipantsMessage: function(participantsCount) {
					var message = resources.localizableStrings.HasParticipantsMessage;
					return Ext.String.format(message, participantsCount);
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getColumnsForEntitySelect
				 * @override
				 */
				getColumnsForEntitySelect: function() {
					return [
						"Id", "Name", "SenderName", "SenderEmail", "TemplateSubject", "Category", "AudienceSchema",
						"ExpirationDate", "Status", "Priority"
					];
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityRecordIdFromElement
				 * @override
				 */
				getEntityRecordIdFromElement: function(element) {
					return element.marketingEmailId;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setRecordIdToElement
				 * @override
				 */
				setRecordIdToElement: function(element, recordId) {
					element.marketingEmailId = recordId;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setRecordIdToElement
				 * @override
				 */
				saveValues: function() {
					this.callParent(arguments);
					var element = this.$ProcessElement;
					element.audienceSchemaName = this.$AudienceSchemaName;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupCaption
				 * @override
				 */
				getEntityLookupCaption: function() {
					return this.get("Resources.Strings.MarketingEmailText");
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntitySchemaName
				 * @override
				 */
				getEntitySchemaName: function() {
					return "BulkEmail";
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#clearPageParameters
				 * @override
				 */
				clearPageParameters: function() {
					this.callParent(arguments);
					this.$SenderName = null;
					this.$SenderEmail = null;
					this.$Subject = null;
					this.$AudienceSchema = null;
					this.$AudienceSchemaName = null;
					this.$ExpirationDate = null;
					this.$Status = null;
					this.$Priority = null;
				},

				/**
				 * @inheritdoc CampaignBaseAudiencePropertiesPage#getContextHelpCode
				 * @override
				 */
				getContextHelpCode: function() {
					return "CampaignMarketingEmailElement";
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setPageParameters
				 * @override
				 */
				setPageParameters: function(entity) {
					this.callParent(arguments);
					this.$SenderName = entity.$SenderName;
					this.$SenderEmail = entity.$SenderEmail;
					this.$Subject = entity.$TemplateSubject;
					this.$ExpirationDate = entity.$ExpirationDate;
					this.$Status = entity.$Status;
					this.$Priority = entity.$Priority;
					this.$AudienceSchema = entity.$AudienceSchema;
					this._setAudienceSchemaName();
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupFilters
				 * @override
				 */
				getEntityLookupFilters: function() {
					var filters = BPMSoft.createFilterGroup();
					filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					var campaignFilters = this._getCurrentCampaignBulkEmailFilter();
					filters.addItem(campaignFilters);
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Category", MarketingEnums.BulkEmailCategory.TRIGGERED_EMAIL)
					);
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Status", MarketingEnums.BulkEmailStatus.DRAFT)
					);
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Status", MarketingEnums.BulkEmailStatus.STOPPED_MANUALLY)
					);
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Status", MarketingEnums.BulkEmailStatus.EXPIRED)
					);
					var notInUseFilter = this._getExcludeNeighborsBulkEmailFilter();
					filters.addItem(notInUseFilter);
					return filters;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#onEntityLookupSelected
				 * @override
				 */
				onEntityLookupSelected: function(args) {
					var selectedRows = args.selectedRows;
					if (!selectedRows.isEmpty()) {
						var selectedItem = selectedRows.first();
						var bulkEmailId = this.$EntityRecord && this.$EntityRecord.Id;
						if (selectedItem.Id !== bulkEmailId) {
							this.onLookupItemChange(selectedItem, this.$EntityRecord);
						}
					}
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupConfig
				 * @override
				 */
				getEntityLookupConfig: function() {
					var config = this.callParent();
					config.columns = this.getColumnsForEntitySelect();
					return config;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#prepareEntityList
				 * @override
				 */
				prepareEntityList: function(filterParameter, list) {
					if (this.$IsClearQuestion) {
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * Sets MarketingEmail lookup selected value as dropdown list item.
				 * @protected
				 * @param {Object} selectedItem Selected lookup collection item.
				 */
				onEntityLookupChanged: function(selectedItem) {
					var selectedItemId = selectedItem && selectedItem.Id;
					if (!selectedItemId) {
						this.onLookupItemChange(null, this.$EntityRecord);
						this.clearPageParameters();
						return;
					}
					if (!selectedItem.SenderEmail) {
						this.loadEntityRecord(selectedItem);
						return;
					}
					this.$SenderName = selectedItem.SenderName;
					this.$SenderEmail = selectedItem.SenderEmail;
					this.$Subject = selectedItem.TemplateSubject;
					this.$ExpirationDate = selectedItem.ExpirationDate;
					this.$Status = selectedItem.Status;
					this.$Priority = selectedItem.Priority;
					this.$AudienceSchema = selectedItem.AudienceSchema;
					this._setAudienceSchemaName();
				},

				/**
				 * Handles change of selected lookup item.
				 * @protected
				 * @param {Object} selectedItem Selected lookup item.
				 * @param {Object} prevItem Previous selected item.
				 */
				onLookupItemChange: function(selectedItem, prevItem) {
					this.validateElement(function(result) {
						if (result.success) {
							this.$EntityRecord = selectedItem;
						} else {
							this.$IsClearQuestion = true;
							this._showWarningMessage(result.message, function() {
								if (!BPMSoft.isEmpty(this.$DependentTransitions)) {
									this.clearTransitions(this.$DependentTransitions);
								}
								this.$IsClearQuestion = false;
								this.$EntityRecord = selectedItem;
							}, function() {
								this.$EntityRecord = prevItem;
								this.$IsClearQuestion = false;
							}, this);
						}
					}, this);
				},

				/**
				 * Validates campaign element.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution context.
				 */
				validateElement: function(callback, scope) {
					var result = {
						success: true,
						message: ""
					};
					this.validateOutgoingTransitions(result);
					this.validateParticipants(result, function() {
						callback.call(scope, result);
					}, scope);
				},

				/**
				 * Gets select query for campaign participants count on the current step.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery} Query for campaign participants count on the current step.
				 */
				getRecepientsCountQuery: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CampaignParticipant"
					});
					esq.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "ParticipantCount");
					esq.rowCount = 1;
					var elementId = this.$ProcessElement.uId;
					esq.filters.add("filterCampaignItem", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "CampaignItem", elementId));
					esq.filters.add("filterCompleted", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "StepCompleted", true));
					return esq;
				},

				/**
				 * Validates existance of participants on the current step.
				 * @protected
				 * @param {Object} result Validation result.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution context.
				 */
				validateParticipants: function(result, callback, scope) {
					var esq = this.getRecepientsCountQuery();
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var countRow = response.collection.first();
							var participantsCount = countRow && countRow.$ParticipantCount;
							if (participantsCount) {
								result.message += scope.getHasParticipantsMessage(participantsCount) + "\n\n";
								result.success = false;
							}
						}
						callback.call(scope);
					});
				},

				/**
				 * Validates outgoing sequence flows and sets list of dependent transitions.
				 * @protected
				 * @param {Object} result Validation result.
				 */
				validateOutgoingTransitions: function(result) {
					var dependentTransitions = [];
					var currentElement = this.$ProcessElement;
					var outgoings = currentElement.getOutgoingsSequenceFlows();
					BPMSoft.each(outgoings, function(sequenceFlow) {
						if (sequenceFlow instanceof BPMSoft.ProcessEmailConditionalTransitionSchema
								&& !sequenceFlow.checkDependencies()) {
							dependentTransitions.push(sequenceFlow);
						}
					}, this);
					this.$DependentTransitions = dependentTransitions;
					if (!BPMSoft.isEmpty(dependentTransitions)) {
						result.message += this.getClearOutgoingTransitionsMessage() + "\n\n";
						result.success = false;
					}
				},

				/**
				 * Clears outgoing transitions data when selected triggered email changed.
				 * @protected
				 * @param {Array} transitions Outgoing sequence flows to actualize.
				 */
				clearTransitions: function(transitions) {
					BPMSoft.each(transitions, function(sequenceFlow) {
						if (sequenceFlow instanceof BPMSoft.ProcessEmailConditionalTransitionSchema) {
							sequenceFlow.clearDependentData();
						}
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SenderNameLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.SenderNameCaption",
						"classes": {
							"labelClass": ["label-small"]
						},
						"visible": "$isEntitySelected"
					}
				},
				{
					"operation": "insert",
					"name": "SenderName",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$isEntitySelected",
						"controlConfig": {"tag": "SenderName"}
					}
				},
				{
					"operation": "insert",
					"name": "SenderEmailLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.SenderEmailCaption",
						"visible": "$isEntitySelected"
					}
				},
				{
					"operation": "insert",
					"name": "SenderEmail",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$isEntitySelected",
						"controlConfig": {"tag": "SenderEmail"}
					}
				},
				{
					"operation": "insert",
					"name": "SubjectLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"value": "$Subject",
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.SubjectCaption",
						"visible": "$isEntitySelected"
					}
				},
				{
					"operation": "insert",
					"name": "Subject",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$isEntitySelected",
						"controlConfig": {"tag": "Subject"}
					}
				},
				{
					"operation": "insert",
					"name": "AudienceSchemaLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"value": "$AudienceSchema",
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.AudienceSchemaCaption",
						"visible": "$_getAudienceSchemaVisibility"
					}
				},
				{
					"operation": "insert",
					"name": "AudienceSchema",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$_getAudienceSchemaVisibility",
						"controlConfig": {"tag": "AudienceSchema"}
					}
				},
				{
					"operation": "insert",
					"name": "ExpirationDateLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 10,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.ExpirationDateCaption",
						"visible": "$isEntitySelected"
					}
				},
				{
					"operation": "insert",
					"name": "ExpirationDate",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 11,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$isEntitySelected",
						"controlConfig": {"tag": "ExpirationDate"}
					}
				},
				{
					"operation": "insert",
					"name": "StatusLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 12,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.StatusCaption",
						"visible": "$isEntitySelected"
					}
				},
				{
					"operation": "insert",
					"name": "Status",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 13,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$isEntitySelected",
						"controlConfig": {"tag": "Status"}
					}
				},
				{
					"operation": "insert",
					"name": "PriorityLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 14,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.PriorityCaption",
						"visible": "$isEntitySelected"
					}
				},
				{
					"operation": "insert",
					"name": "Priority",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 15,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": "$isEntitySelected",
						"controlConfig": {"tag": "Priority"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
