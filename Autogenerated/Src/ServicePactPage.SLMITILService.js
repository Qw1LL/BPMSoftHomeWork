define("ServicePactPage", ["BaseFiltersGenerateModule", "BusinessRuleModule", "ServiceDeskConstants"],
	function(BaseFiltersGenerateModule, BusinessRuleModule, ServiceDeskConstants) {
		return {
			entitySchemaName: "ServicePact",
			details: /**SCHEMA_DETAILS*/{
				"ServiceObject": {
					"schemaName": "ServiceObjectDetail",
					"entitySchemaName": "ServiceObject",
					"filter": {
						"detailColumn": "ServicePact",
						"masterColumn": "Id"
					}
				},
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "ServicePactFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ServicePact"
					}
				},
				"ServiceItems": {
					"schemaName": "ServiceInServicePactDetail",
					"entitySchemaName": "ServiceInServicePact",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ServicePact"
					}
				},
				"Cases": {
					"schemaName": "CaseInServicePactDetail",
					"entitySchemaName": "Case",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ServicePact"
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
						},
						"caption": {
							"bindTo": "Resources.Strings.NameCaption"
						},
						"textSize": "Default",
						"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
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
					"name": "Type",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Type",
						"caption": {
							"bindTo": "Resources.Strings.TypeCaption"
						},
						"textSize": 0,
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
					"name": "Number",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Number",
						"caption": {
							"bindTo": "Resources.Strings.NumberCaption"
						},
						"textSize": "Default",
						"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
						"labelConfig": {
							"visible": true
						},
						"enabled": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Status",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Status",
						"caption": {
							"bindTo": "Resources.Strings.StatusCaption"
						},
						"textSize": "Default",
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
					"name": "Owner",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Owner",
						"caption": {
							"bindTo": "Resources.Strings.OwnerCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "StartDate",
						"caption": {
							"bindTo": "Resources.Strings.StartDateCaption"
						},
						"textSize": "Default",
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
					"name": "EndDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "EndDate",
						"caption": {
							"bindTo": "Resources.Strings.EndDateCaption"
						},
						"textSize": "Default",
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
					"name": "Calendar",
					"values": {
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Calendar",
						"caption": {
							"bindTo": "Resources.Strings.CalendarCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SupportLevel",
					"values": {
						"layout": {
							"column": 13,
							"row": 4,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SupportLevel",
						"caption": {
							"bindTo": "Resources.Strings.SupportLevelCaption"
						}
					},
					"parentName": "Header",
					"propertyName": "items"
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
					"name": "ServicePactSupportGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.ServicePactSupportGroupCaption"
						},
						"items": [],
						"controlConfig": {
							"collapsed": false
						},
						"visible": {bindTo: "isServicePactSupportGroupVisible"}
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ServicePactSupportGroup_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "ServicePactSupportGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ServiceProvider",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ServiceProvider",
						"caption": {
							"bindTo": "Resources.Strings.ServiceProviderCaption"
						},
						"textSize": 0,
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ServicePactSupportGroup_gridLayout",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ServiceProviderContact",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ServiceProviderContact",
						"caption": {
							"bindTo": "Resources.Strings.ServiceProviderContactCaption"
						},
						"textSize": 0,
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "ServicePactSupportGroup_gridLayout",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ServiceObject",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 0
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
					"name": "Cases",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "HistoryTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "NotesFilesTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.NotesFilesTabCaption"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4
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
					"name": "ServiceItems",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"Owner": {
					lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
				},
				"Calendar": {
					lookupListConfig: {
						hideActions: true
					}
				}
			},
			methods: {

				/*
				 * Returns is service contract support group visible.
				 * @return {Boolean}
				 */
				isServicePactSupportGroupVisible: function() {
					return this.isServicePactTypeUc();
				},

				/*
				 * Returns is current service contract type is "UC"
				 * @return {Boolean}
				 */
				isServicePactTypeUc: function() {
					return this.get("Type") && this.get("Type").value === ServiceDeskConstants.ServicePactType.UC;
				},

				/**
				 * @inheritDoc BPMSoft.BaseDetailV2#initContextHelp
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1062);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					if (this.isAddMode() || this.isCopyMode()) {
						this.getIncrementCode(function(response) {
							this.set("Number", response);
						});
					}
					this.callParent(arguments);
				},
				/**
				 * @inheritdoc BasePageV2#onRender
				 * @overridden
				 * @protected
				 */
				onRender: function() {
					this.callParent(arguments);
					if (this.get("Restored")) {
						this.updateDetail({detail: "ServiceObject"});
					}
				}

			},
			rules: {
				"ServiceProviderContact": {
					"FiltrationServiceProviderContactByServiceProvider": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "ServiceProvider"
					}
				}
			},
			userCode: {}
		};
	});
