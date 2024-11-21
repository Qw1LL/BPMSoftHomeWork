define("ConfItemPage", ["BaseFiltersGenerateModule", "BusinessRuleModule", "HierarchicalRecordsUtilities",
		"RelationshipsRecordsUtilities"],
	function(BaseFiltersGenerateModule, BusinessRuleModule) {
		return {
			entitySchemaName: "ConfItem",
			details: /**SCHEMA_DETAILS*/{
				"Activity": {
					"schemaName": "ConfItemActivityDetail",
					"entitySchemaName": "Activity",
					"filter": {
						"detailColumn": "ConfItem",
						"masterColumn": "Id"
					}
				},
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "ConfItemFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ConfItem"
					}
				},
				"Case": {
					"schemaName": "CaseConfItemDetail",
					"entitySchemaName": "ConfItemInCase",
					"filter": {
						"detailColumn": "ConfItem",
						"masterColumn": "Id"
					}
				},
				"User": {
					"schemaName": "ConfItemUserDetail",
					"entitySchemaName": "ConfItemUser",
					"filter": {
						"detailColumn": "ConfItem",
						"masterColumn": "Id"
					}
				},
				"ConfItemAddress": {
					"schemaName": "ConfItemAddressDetail",
					"entitySchemaName": "ConfItemAddress",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ConfItem"
					}
				},
				"Component": {
					"schemaName": "ConfItemComponentDetail",
					"entitySchemaName": "ConfItem",
					"filter": {
						"detailColumn": "ParentConfItem",
						"masterColumn": "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Category",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Category",
						"caption": {
							"bindTo": "Resources.Strings.CategoryCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Type",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Type",
						"caption": {
							"bindTo": "Resources.Strings.TypeCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Model",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Model",
						"caption": {
							"bindTo": "Resources.Strings.ModelCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "SerialNumber",
					"values": {
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SerialNumber",
						"caption": {
							"bindTo": "Resources.Strings.SerialNumberCaption"
						},
						"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "InventoryNumber",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "InventoryNumber",
						"caption": {
							"bindTo": "Resources.Strings.InventoryNumberCaption"
						},
						"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "Owner",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Owner",
						"caption": {
							"bindTo": "Resources.Strings.OwnerCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ActualStatusGroup_GridLayout",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.GeneralInfoTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ActualStatusGroup_GridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Status",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Status",
						"caption": {
							"bindTo": "Resources.Strings.StatusCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "PurchaseDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "PurchaseDate",
						"caption": {
							"bindTo": "Resources.Strings.PurchaseDateCaption"
						},
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ActualStatusGroup_GridLayout",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "CancelDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "CancelDate",
						"enabled": {
							"bindTo": "CancelDateEnabled"
						},
						"caption": {
							"bindTo": "Resources.Strings.CancelDateCaption"
						},
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ActualStatusGroup_GridLayout",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "WarrantyUntil",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "WarrantyUntil",
						"caption": {
							"bindTo": "Resources.Strings.WarrantyUntilCaption"
						},
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ActualStatusGroup_GridLayout",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "ParentConfItem",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ParentConfItem",
						"caption": {
							"bindTo": "Resources.Strings.ParentConfItemCaption"
						},
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ActualStatusGroup_GridLayout",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "HistoryTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.HistoryTabCaption"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Case",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "HistoryTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ConfItemAddress",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "User",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Component",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "NotesFilesTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.NotesFilesTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "Files",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "NotesFilesTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.NotesGroupCaption"
						}
					},
					"parentName": "NotesFilesTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Notes",
					"values": {
						"contentType": this.BPMSoft.ContentType.RICH_TEXT,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
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
					},
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Activity",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "HistoryTab",
					"propertyName": "items",
					"index": 1
				}
			]/**SCHEMA_DIFF*/,
			messages: {
				/**
				 * @message UpdateConfItemPage
				 * Updates configuration item page.
				 */
				"UpdateConfItemPage": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				HierarchicalRecordsUtilities: "BPMSoft.HierarchicalRecordsUtilities",
				RelationshipsRecordsUtilities: "BPMSoft.RelationshipsRecordsUtilities"
			},
			attributes: {
				"Owner": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
				},
				"Status": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					dependencies: [
						{
							columns: ["Status"],
							methodName: "onStatusChanged"
						}
					],
					lookupListConfig: {
						columns: ["IsFinal"]
					}
				},
				"Model": {
					lookupListConfig: {
						filter: function() {
							return this.getModelFilters();
						}
					}
				},
				"ParentConfItem": {
					lookupListConfig: {
						filter: function() {
							var masterRecordId = this.get("Id");
							var parentRecord = this.get("ParentConfItem");
							return this.mixins.RelationshipsRecordsUtilities.getHierarchicalFilter.call(this,
									masterRecordId, parentRecord, "ParentConfItem");
						}
					}
				}
			},
			methods: {
				onLookupResult: function(args) {
					if (args.columnName !== "ParentConfItem" || this.isNewMode()) {
						this.callParent(arguments);
					}  else {
						var selectedItems = args.selectedRows.getItems();
						if(selectedItems.length !== 0) {
							var serviceArgs = {
								parentElement: selectedItems[0],
								childId: [this.get("Id")],
								schemaName: "ConfItem",
								parentColumnName:"ParentConfItemId",
								lookupParentColumnName: "ParentConfItem"
							};
							this.mixins.RelationshipsRecordsUtilities.callHierarchicalService.call(this, serviceArgs);
						}
					}
				},
				/**
				 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 *
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("UpdateConfItemPage", this.onUpdateConfItemPage, this);
				},

				/**
				 * Updates configuration item page.
				 * @private
				 */
				onUpdateConfItemPage: function() {
					this.updateDetail({
						detail: "ConfItemAddress"
					});
					this.save();
				},
				/**
				 * On status field change handler.
				 * @protected
				 */
				onStatusChanged: function() {
					var status = this.get("Status");
					if (!status) {
						return;
					}
					if (status.IsFinal) {
						var cancelDate = this.get("CancelDate");
						if (Ext.isDate(cancelDate)) {
							return;
						}
						cancelDate = new Date();
						cancelDate = new Date(cancelDate.setMilliseconds(0));
						cancelDate = new Date(cancelDate.setSeconds(0));
						cancelDate = new Date(cancelDate.setMinutes(0));
						cancelDate = new Date(cancelDate.setHours(0));
						this.set("CancelDate", cancelDate);
						this.set("CancelDateEnabled", true);
					} else {
						this.set("CancelDate", null);
						this.set("CancelDateEnabled", false);
					}
				},

				/**
				 * Return Model filter group.
				 * @protected
				 * @returns {BPMSoft.FilterGroup}
				 */
				getModelFilters: function() {
					var model = this.get("Model");
					if (!model) {
						return;
					}
					var filtersCollection = this.BPMSoft.createFilterGroup();
					filtersCollection.add("NotAlreadySelectedModelFilter",
						this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.NOT_EQUAL,
							"Id", model.value));
					return filtersCollection;
				},

				/**
				 * Before parent configuration items load.
				 */
				onLoadParentConfItem: function() {
					this.mixins.HierarchicalRecordsUtilities.onLoadParent.call(this);
				},

				/**
				 * On parent configuration items load.
				 */
				onPrepareParentConfItem: function(filter) {
					this.mixins.HierarchicalRecordsUtilities.onPrepareParent.call(this, filter);
				},

				/**
				 * Returns filters for parent configuration item field.
				 * @overridden
				 * @private
				 * @param {String} columnName Column name
				 * @return {BPMSoft.FilterGroup}
				 */
				getLookupQueryFilters: function(columnName) {
					var parentColumnName = this.get("ParentColumnName");
					var parentFilters = this.get(parentColumnName + "Filters");
					var filterGroup = this.callParent([columnName]);
					if (columnName === parentColumnName && parentFilters) {
						filterGroup.add(parentFilters);
					}
					return filterGroup;
				},

				/**
				 * Returns ESQ for lookup columns.
				 * @overridden
				 * @private
				 * @param {String} filterValue PrimaryDisplayColumn filter
				 * @param {String} columnName ViewModel column name
				 * @param {Boolean} isLookup Is Field lookup
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getLookupQuery: function(filterValue, columnName, isLookup) {
					var parentColumnName = this.get("ParentColumnName");
					var parentFilters = this.get(parentColumnName + "Filters");
					var entitySchemaQuery = this.callParent([filterValue, columnName, isLookup]);
					if (columnName === parentColumnName && parentFilters) {
						entitySchemaQuery.filters.add(parentColumnName + "Filter", parentFilters);
					}
					return entitySchemaQuery;
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#initContextHelp
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1065);
					this.callParent(arguments);
				}
			},
			rules: {
				"Model": {
					"FiltrationModelByCategory": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "ConfItemType.ConfItemCategory",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Category"
					},
					"FiltrationModelByType": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "ConfItemType",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Type"
					}
				},
				"Type": {
					"FiltrationTypeByCategory": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "ConfItemCategory",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Category"
					}
				}
			},
			userCode: {}
		};
	});
