define("PortalMktgActivityEditPage", ["BPMSoft", "TimezoneUtils", "PortalMktgActivitiesConstants", "MoneyModule",
		"MultiCurrencyEdit", "MultiCurrencyEditUtilities"],
	function(BPMSoft, TimezoneUtils, PortalMktgActivitiesConstants, MoneyModule) {
		return {
			entitySchemaName: "MktgActivity",
			details: /**SCHEMA_DETAILS*/{
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "MktgActivityFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "MktgActivity"
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {
				MultiCurrencyEditUtilities: "BPMSoft.MultiCurrencyEditUtilities"
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

			methods : {

				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.mixins.MultiCurrencyEditUtilities.init.call(this);
					if (this.isAddMode() || this.isCopyMode()) {
						this.selectDefaultStatus(function(status) {
							this.set("Status", status);
						}, this);
					}
				},

				/**
				 * Select default status.
				 * @param {Function} callback
				 * @param {Object} scope
				 */
				selectDefaultStatus: function(callback, scope) {
					var defaultStatusId = PortalMktgActivitiesConstants.OnApprovalStatusId;
					var select = this.getStatusSelectQuery(defaultStatusId);
					select.getEntityCollection(function(responce) {
						if(responce && responce.success) {
							var items = responce.collection.getItems();
							var status = {
								value: defaultStatusId,
								displayValue: items[0].values.Name
							};
							callback.call(scope, status);
						}
					});
				},

				/**
				 * Return query for select default status.
				 * @param {GUID} defaultStatusId - Default status id.
				 * @returns {BPMSoft.EntitySchemaQuery}
				 */
				getStatusSelectQuery: function(defaultStatusId) {
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "MktgActivityStatus"
					});
					select.addColumn("Name");
					var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id",
							defaultStatusId);
					select.filters.add("IdFilter", filter);
					return select;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#save
				 * @overridden
				 */
				save: function() {
					var startDate = Ext.Date.format(this.get("StartDate"),"Y-m-d");
					var endDate = Ext.Date.format(this.get("DueDate"),"Y-m-d");
					if (!this.validateDate(startDate, endDate)) {
						BPMSoft.utils.showInformation(this.get("Resources.Strings.StartEndDateErrorMessage"));
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * Validate date.
				 * @private
				 * @returns {boolean}
				 */
				validateDate: function(startDate, endDate) {
					if (startDate > endDate) {
						return false;
					}
					return true;
				},

				/**
				 * Lock fields in EditMode
				 * @returns {boolean}
				 */
				isFieldsEditable: function() {
					return !this.isEditMode();
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

				/**
				 * @overriden
				 * Initialize card actions
				 */
				initActionButtonMenu: function() {
					this.set("ActionsButtonVisible", false);
				}
			},
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
						"enabled": {
							"bindTo": "isFieldsEditable"
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
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
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
						},
						"enabled": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 2
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
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
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
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
						}
					},
					"parentName": "GeneralInfoGridLayout",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoGridLayout",
					"propertyName": "items",
					"name": "PlannedBudget",
					"values": {
						"bindTo": "PlannedBudget",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
						},
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
						"layout":  {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"enabled": false,
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
			]/**SCHEMA_DIFF*/,
			rules: {},
			userCode: {}
		};
	});
