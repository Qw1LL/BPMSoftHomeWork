define("DocumentPageV2", ["BaseFiltersGenerateModule", "VisaHelper", "BusinessRuleModule", "ConfigurationConstants"],
	function(BaseFiltersGenerateModule, VisaHelper, BusinessRuleModule, ConfigurationConstants) {
		return {
			entitySchemaName: "Document",
			attributes: {
				"Owner": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"lookupListConfig": {"filter": BaseFiltersGenerateModule.OwnerFilter}
				},
				"State": {
					"lookupListConfig": {
						"orders": [{"columnPath": "Position"}]
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"Activities": {
					"schemaName": "ActivityDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Document"
					},
					defaultValues: {
						"Document": {"masterColumn": "Id"},
						"Account": {"masterColumn": "Account"},
						"Contact": {"masterColumn": "Contact"}
					}
				},
				Documents: {
					"schemaName": "DocumentRelationshipDetailV2",
					"filterMethod": "relationshipDetailFilter",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Document"
					},
					"entitySchemaName": "Document",
					"defaultValues": {
						"Document": {"masterColumn": "Id"},
						"Account": {"masterColumn": "Account"},
						"Contact": {"masterColumn": "Contact"}
					},
					subscriber: function(cfg) {
						if (cfg && cfg.rows && (cfg.action !== "delete")) {
							this.connectedDocuments(cfg.rows[0], this, function() {
								this.sandbox.publish("UpdateDetail", {
									reloadAll: true
								}, [this.getDetailId("Documents")]);
							}, this);
						}
					}
				},
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "DocumentFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Document"
					}
				},
				"EntityConnections": {
					"schemaName": "EntityConnectionsDetailV2",
					"entitySchemaName": "EntityConnection",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "SysModuleEntity"
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Document"
					},
					filterMethod: "emailDetailFilter"
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onGetPageTips
				 * @overridden
				 */
				onGetPageTips: function() {
					return {
						"Contract": this.get("Resources.Strings.ContractTip"),
						"Opportunity": this.get("Resources.Strings.OpportunityTip"),
						"Order": this.get("Resources.Strings.OrderTip"),
						"Project": this.get("Resources.Strings.ProjectTip")
					};
				},

				/**
				 * ####### ######## ######## ###### relationship.
				 * @protected
				 * @returns {createFilterGroup}
				 */
				relationshipDetailFilter: function() {
					var recordId = this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
					filterGroup.add("DocumentAFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "[DocumentRelationship:DocumentA].DocumentB", recordId));
					filterGroup.add("DocumentBFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"[DocumentRelationship:DocumentB].DocumentA", recordId));
					return filterGroup;
				},
				/**
				 * ############# #### #####.
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
				 * ########## ######## ###### #############.
				 * #### ############ ############ ########, ####### ######### # ############# ########## #######.
				 * ##### ########## callback-#######.
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
								this.validateAccountOrContactFilling(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
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
				 * ######### ######### ## ###### #### ## ##### "#######" ### "##########".
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ##########.
				 */
				validateAccountOrContactFilling: function(callback, scope) {
					var account = this.get("Account");
					var contact = this.get("Contact");
					var result = {
						success: true
					};
					if (this.Ext.isEmpty(account) && this.Ext.isEmpty(contact)) {
						var accountColumnCaption = this.getColumnByName("Account").caption;
						var contactColumnCaption = this.getColumnByName("Contact").caption;
						result.message = this.Ext.String.format(
								this.get("Resources.Strings.WarningAccountContactRequire"),
								accountColumnCaption, contactColumnCaption);
						result.success = false;
					}
					callback.call(scope || this, result);
				},

				/**
				 * ######### ######## ## ######### ##### ##########.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ##########.
				 */
				validateUniqueNumber: function(callback, scope) {
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Number)) {
						callback.call(scope, {success: true});
					}
					var id = this.get("Id");
					var number = this.get("Number");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Document"});
					esq.filters.addItem(
						this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", id));
					esq.filters.addItem(
						this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Number", number));
					esq.getEntityCollection(function(response) {
						var result = {success: true};
						if (response.success && response.collection.getCount() > 0) {
							result.message = this.get("Resources.Strings.NumberMustBeUnique");
							result.success = false;
						}
						callback.call(scope || this, result);
					}, this);
				},
				/**
				 * ####### ######### ###### # ####### ######## ##########, #### ##### ##### ### ###.
				 * @param {Guid} recordId ############# ########### ######
				 * @param {Object} scope ######## ##########
				 * @param {Function} callback #######, ####### ##### ####### ##### ####### ######
				 */
				connectedDocuments: function(recordId, scope, callback) {
					if (!recordId) {
						return;
					}
					var currentId = scope.get(scope.primaryColumnName) || scope.get("MasterRecordId");
					var esq = scope.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "DocumentRelationship"
					});
					esq.addColumn("Id");
					esq.filters.addItem(esq.createColumnFilterWithParameter(scope.BPMSoft.ComparisonType.EQUAL,
						"DocumentA", currentId));
					esq.filters.addItem(esq.createColumnFilterWithParameter(scope.BPMSoft.ComparisonType.EQUAL,
						"DocumentB", recordId));
					esq.getEntityCollection(function(response) {
						if (response.success) {
							if (response.collection.getCount() > 0) {
								if (callback) {
									callback.call(scope);
								}
								return;
							}
							var insert = Ext.create("BPMSoft.InsertQuery", {
								rootSchemaName: "DocumentRelationship"
							});
							insert.setParameterValue("DocumentB", recordId, BPMSoft.DataValueType.GUID);
							insert.setParameterValue("DocumentA", currentId, BPMSoft.DataValueType.GUID);
							insert.execute(callback || scope.Ext.emptyFn, scope);
						}
					}, scope);
				},

				/**
				 * Creates filter for detail Email.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Group filters.
				 */
				emailDetailFilter: function() {
					var recordId = this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("DocumentNotNull", this.BPMSoft.createColumnIsNotNullFilter("Document"));
					filterGroup.add("DocumentConnection", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Document", recordId));
					filterGroup.add("ActivityType", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				}
			},
			rules: {
				"Contact": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Number",
					"values": {
						"bindTo": "Number",
						"layout": {"column": 0, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Date",
					"values": {
						"bindTo": "Date",
						"layout": {"column": 13, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Type",
					"values": {
						"bindTo": "Type",
						"layout": {"column": 0, "row": 1},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"bindTo": "Owner",
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						}
					},
					"filter": BaseFiltersGenerateModule.OwnerFilter
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "State",
					"values": {
						"bindTo": "State",
						"layout": {"column": 0, "row": 2},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTabContainer",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTabContainer",
					"name": "GeneralInfoGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"wrapClass": "contract-general-info-group-wrap"
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoGroup",
					"propertyName": "items",
					"name": "GeneralInfoBlock",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "Account",
					"values": {
						"bindTo": "Account",
						"layout": {"column": 0, "row": 0}
					}
				},
				{
					"operation": "insert",
					"name": "Contact",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Contact",
						"layout": {"column": 13, "row": 0}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTabContainer",
					"propertyName": "items",
					"name": "EntityConnections",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "HistoryTabContainer",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.HistoryTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTabContainer",
					"propertyName": "items",
					"name": "Activities",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTabContainer",
					"propertyName": "items",
					"name": "EmailDetailV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTabContainer",
					"propertyName": "items",
					"name": "Documents",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "NotesAndFilesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.NotesFilesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"name": "Files",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"contentType": BPMSoft.ContentType.RICH_TEXT,
						"layout": {"column": 0, "row": 0, "colSpan": 24},
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
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
