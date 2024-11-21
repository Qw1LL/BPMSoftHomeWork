define("ProjectPageV2", ["BPMSoft", "XRMConstants", "ConfigurationConstants", "BusinessRuleModule"],
	function(BPMSoft, XRMConstants, ConfigurationConstants) {
		return {
			entitySchemaName: "Project",
			attributes: {
				"Opportunity": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							var filterGroup = this.BPMSoft.createFilterGroup();
							filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
							if (this.get("Contact")) {
								filterGroup.add("ContactFilter", this.BPMSoft.createColumnFilterWithParameter(
										this.BPMSoft.ComparisonType.EQUAL,
										"Contact", this.get("Contact").value));
							}
							if (this.get("Account")) {
								filterGroup.add("AccountFilter", this.BPMSoft.createColumnFilterWithParameter(
										this.BPMSoft.ComparisonType.EQUAL,
										"Account", this.get("Account").value));
							}
							return filterGroup;
						},
						columns: ["Account", "Contact"]
					},
					dependencies: [
						{
							columns: ["Opportunity"],
							methodName: "onOpportunityChanged"
						},
						{
							columns: ["Contact", "Account"],
							methodName: "onReferenceEntityChanged"
						}
					]
				}
			},
			messages: {
				"UpdateDetailResource": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"ProjectResourceElement": {
					"schemaName": "ProjectResourceElementDetailV2",
					"filter": {
						"detailColumn": "Project",
						"masterColumn": "Id"
					}
				},
				"Cashflow": {
					"schemaName": "CashflowDetailV2",
					"filter": {
						"detailColumn": "Project",
						"masterColumn": "Id"
					}
				},
				"Finance": {
					"schemaName": "ProjectFinanceDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Id"
					}
				},
				"Activities": {
					"schemaName": "ActivityDetailV2",
					"filter": {
						"detailColumn": "Project",
						"masterColumn": "Id"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"}
					},
					subscriber: function() {
						this.updateDetail({"detail": "ProjectResourceElement"});
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Project"
					},
					filterMethod: "emailDetailFilter"
				}
			}, /**SCHEMA_DETAILS*/
			methods: {
				/**
				 * @inheritdoc BasePageV2#onRender
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					this.updateDetail({"detail": "ProjectResourceElement"});
				},

				/**
				 * @inheritdoc BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.sandbox.subscribe("UpdateDetailResource", function() {
						this.updateDetail({
							detail: "ProjectResourceElement"
						});
					}, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					if ((this.isAddMode() || this.isCopyMode()) && !this.get("ProjectEntryType")) {
						{
							this.loadLookupDisplayValue("ProjectEntryType", XRMConstants.Project.EntryType.Project);
						}
					}
					this.callParent(arguments);
				},

				/**
				 * Refresh detail "ProjectResourceElement".
				 * @protected
				 * @overridden
				 */
				onProjectLaborPlanCalculated: function() {
					this.callParent(arguments);
					this.updateDetail({"detail": "ProjectResourceElement"});
				},

				/**
				 * Refresh detail "ProjectResourceElement".
				 * @protected
				 * @overridden
				 */
				onProjectCollectionActualWorkCalculated: function() {
					this.callParent(arguments);
					this.updateDetail({"detail": "ProjectResourceElement"});
				},

				/**
				 * Creates filter for detail Email.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Group filters.
				 */
				emailDetailFilter: function() {
					var recordId = this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("ProjectNotNull", this.BPMSoft.createColumnIsNotNullFilter("Project"));
					filterGroup.add("ProjectConnection", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Project", recordId));
					filterGroup.add("ActivityType", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				},

				/**
				 * On opportunity changed event handler.
				 */
				onOpportunityChanged: function() {
					var opportunity = this.get("Opportunity");
					if (!opportunity) {
						return;
					}
					var account = this.get("Account");
					var contact = this.get("Contact");
					var refAccount = opportunity && opportunity.Account || null;
					var refContact = opportunity && opportunity.Contact || null;
					if (this.Ext.isEmpty(account) && this.Ext.isEmpty(contact)) {
						if (refAccount) {
							this.set("Account", refAccount);
						}
						if (refContact) {
							this.set("Contact", refContact);
						}
					}
				},

				/**
				 * On reference entity changed event handler.
				 */
				onReferenceEntityChanged: function(argument, attribute) {
					var attributeValue = this.get(attribute);
					if (this.Ext.isEmpty(attributeValue)) {
						return;
					}
					var opportunity = this.get("Opportunity");
					var refValue = opportunity && opportunity[attribute] || null;
					if (!this.Ext.isEmpty(refValue) && refValue !== attributeValue.value) {
						this.set("Opportunity", null);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "FinanceTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2,
					"values": {
						"caption": {"bindTo": "Resources.Strings.FinanceTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "LinksControlBlock",
					"propertyName": "items",
					"name": "Opportunity",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OpportunityTip"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "ProjectResourceElement",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "Type",
					"values": {
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "move",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "IsAutoCalcCompletion",
					"values": {
						"layout": {"column": 0, "row": 2},
						"tip": {
							"content": {"bindTo": "Resources.Strings.IsAutoCalcCompletionTip"}
						}
					}
				},
				{
					"operation": "move",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "StartDate",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "move",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "getDurationByMask",
					"values": {
						"caption": {"bindTo": "Resources.Strings.DurationByMask"},
						"enabled": false,
						"layout": {"column": 13, "row": 3, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.getDurationByMaskTip"}
						}
					}
				},
				{
					"operation": "move",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "EndDate",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 11}
					}
				},
				{
					"operation": "move",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "Deadline",
					"values": {
						"layout": {"column": 13, "row": 4, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "FinanceTab",
					"propertyName": "items",
					"name": "Finance",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "FinanceTab",
					"propertyName": "items",
					"name": "Cashflow",
					"values": {
						itemType: BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "Activities",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "EmailDetailV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
