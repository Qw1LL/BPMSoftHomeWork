define("MktgActivityPage", ["BPMSoft", "MoneyModule", "MultiCurrencyEdit", "MultiCurrencyEditUtilities"],
		function(BPMSoft, MoneyModule) {
			return {
				entitySchemaName: "MktgActivity",
				mixins: {
					MultiCurrencyEditUtilities: "BPMSoft.MultiCurrencyEditUtilities"
				},
				messages: {
					"SelectedSideBarItemChanged": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {
					/**
					 * Currency
					 */
					"Currency": {
						lookupListConfig: {
							columns: ["Division"]
						}
					},
					/**
					 * Currency rate
					 */
					"CurrencyRate": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						dependencies: [
							{
								columns: ["Currency"],
								methodName: "setCurrencyRate"
							}
						]
					},
					/**
					 * Currency rate list.
					 */
					"CurrencyRateList": {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION,
						value: this.Ext.create("BPMSoft.Collection")
					},
					/**
					 * Currency button menu list.
					 */
					"CurrencyButtonMenuList": {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION,
						value: this.Ext.create("BPMSoft.BaseViewModelCollection")
					},
					/**
					 * Planned budget
					 */
					"PlannedBudget": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						dependencies: [
							{
								columns: ["CurrencyRate"],
								methodName: "recalculatePlannedBudget"
							}
						]
					},
					/**
					 * Planned budget, base currency
					 */
					"PrimaryPlannedBudget": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						dependencies: [
							{
								columns: ["PlannedBudget"],
								methodName: "recalculatePrimaryPlannedBudget"
							}
						]
					},
					/**
					 * Spent budget
					 */
					"SpentBudget": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						dependencies: [
							{
								columns: ["CurrencyRate"],
								methodName: "recalculateSpentBudget"
							}
						]
					},
					/**
					 * Spent budget, base currency
					 */
					"PrimarySpentBudget": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						dependencies: [
							{
								columns: ["SpentBudget"],
								methodName: "recalculatePrimarySpentBudget"
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
						this.mixins.MultiCurrencyEditUtilities.init.call(this);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getHeader
					 * @overridden
					 */
					getHeader: function() {
						return this.entitySchema.caption;
					},

					/**
					 * Sets currency rate value
					 * @protected
					 */
					setCurrencyRate: function() {
						var currentDateTime = this.getSysDefaultValue(BPMSoft.SystemValueType.CURRENT_DATE_TIME);
						MoneyModule.LoadCurrencyRate.call(this, "Currency", "CurrencyRate", currentDateTime);
					},

					/**
					 * Calculates planned budget
					 * @protected
					 */
					recalculatePlannedBudget: function() {
						MoneyModule.RecalcCurrencyValue.call(this, "CurrencyRate", "PlannedBudget", "PrimaryPlannedBudget",
								this.getCurrencyDivision());
					},

					/**
					 * Calculates planned budget in the base currency
					 * @protected
					 */
					recalculatePrimaryPlannedBudget: function() {
						MoneyModule.RecalcBaseValue.call(this, "CurrencyRate", "PlannedBudget", "PrimaryPlannedBudget",
								this.getCurrencyDivision());
					},

					/**
					 * Calculates spent budget
					 * @protected
					 */
					recalculateSpentBudget: function() {
						MoneyModule.RecalcCurrencyValue.call(this, "CurrencyRate", "SpentBudget", "PrimarySpentBudget",
								this.getCurrencyDivision());
					},

					/**
					 * Calculates spent budget in the base currency
					 * @protected
					 */
					recalculatePrimarySpentBudget: function() {
						MoneyModule.RecalcBaseValue.call(this, "CurrencyRate", "SpentBudget", "PrimarySpentBudget",
								this.getCurrencyDivision());
					},

					/**
					 * Returns currency division
					 * @protected
					 */
					getCurrencyDivision: function() {
						var currency = this.get("Currency");
						return currency && currency.Division;
					},

					changeSelectedSideBarMenu: function() {
						var moduleStructure = this.getModuleStructure("CampaignPlanner");
						if (moduleStructure) {
							var hash = moduleStructure.sectionModule + "/";
							if (moduleStructure.sectionSchema) {
								hash += moduleStructure.sectionSchema + "/";
							}
							this.sandbox.publish("SelectedSideBarItemChanged", hash, ["sectionMenuModule"]);
						} else {
							this.callParent(arguments);
						}
					}

				},
				details: /**SCHEMA_DETAILS*/{
					Files: {
						schemaName: "FileDetailV2",
						entitySchemaName: "MktgActivityFile",
						filter: {
							masterColumn: "Id",
							detailColumn: "MktgActivity"
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
						"name": "Channel",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							}
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 1
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
							}
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "Owner",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							}
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 3
					},
					{
						"operation": "insert",
						"name": "CampaignPlanner",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							}
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 4
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
						"name": "group",
						"values": {
							"itemType": 15,
							"caption": {
								"bindTo": "Resources.Strings.groupCaption"
							},
							"items": [],
							"controlConfig": {
								"collapsed": false
							}
						},
						"parentName": "GeneralInfoTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "GeneralInfoGridLayout",
						"values": {
							"itemType": 0,
							"items": []
						},
						"parentName": "group",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "GeneralInfoGridLayout",
						"propertyName": "items",
						"name": "PlannedBudget",
						"values": {
							"bindTo": "PlannedBudget",
							"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1},
							"primaryAmount": "PrimaryPlannedBudget",
							"currency": "Currency",
							"rate": "CurrencyRate",
							"primaryAmountEnabled": false,
							"generator": "MultiCurrencyEditViewGenerator.generate"
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "GeneralInfoGridLayout",
						"propertyName": "items",
						"name": "SpentBudget",
						"values": {
							"bindTo": "SpentBudget",
							"layout": {"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1},
							"primaryAmount": "PrimarySpentBudget",
							"currency": "Currency",
							"rate": "CurrencyRate",
							"primaryAmountEnabled": false,
							"generator": "MultiCurrencyEditViewGenerator.generate"
						},
						"index": 1
					},
					{
						"operation": "insert",
						"name": "StartDate",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							}
						},
						"parentName": "GeneralInfoGridLayout",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "DueDate",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							}
						},
						"parentName": "GeneralInfoGridLayout",
						"propertyName": "items",
						"index": 3
					},
					{
						"operation": "insert",
						"name": "NotesAndFilesTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 3,
						"values": {
							"caption": {"bindTo": "Resources.Strings.NotesAndFilesTabCaption"},
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
				]/**SCHEMA_DIFF*/,
				rules: {},
				userCode: {}
			};
		});
