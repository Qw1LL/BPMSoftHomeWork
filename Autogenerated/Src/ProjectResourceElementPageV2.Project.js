define("ProjectResourceElementPageV2", ["BPMSoft", "BusinessRuleModule", "ext-base", "sandbox", "ConfigurationEnums",
	"StorageUtilities", "ConfigurationConstants"],
	function(BPMSoft, BusinessRuleModule, Ext, sandbox, ConfigurationEnums, StorageUtilities,
		ConfigurationConstants) {
		return {
			entitySchemaName: "ProjectResourceElement",
			attributes: {
				"Name": {
					"dependencies": [
						{
							columns: ["Contact"],
							methodName: "onContactChangeSetDefaultName"
						}
					]
				},
				"InternalRate": {
					"dependencies": [
						{
							columns: ["Contact"],
							methodName: "onContactChangeSetInternalRate"
						}
					]
				},
				"ExternalRate": {
					"dependencies": [
						{
							columns: ["Contact"],
							methodName: "onContactChangeSetExternalRate"
						}
					]
				},
				"Project": {
					lookupListConfig: {
						columns: ["StartDate"]
					}
				},
				"Contact": {
					lookupListConfig: {
						filter: function() {
							return this.createContactFilter();
						}
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * Creates contact type default filter
				 */
				createContactFilter: function() {
					return this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Type", ConfigurationConstants.ContactType.Employee);
				},

				onContactChangeSetDefaultName: function() {
					if (this.get("Operation") === ConfigurationEnums.CardState.Add && this.get("Name") == null) {
						this.set("Name", this.get("Contact").displayValue);
					}
				},

				onContactChangeSetInternalRate: function() {
					if (this.get("Operation") === ConfigurationEnums.CardState.Add) {
						var contact = this.get("Contact");
						if (contact && this.get("IsChanged")) {
							var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "ContactInternalRate"
							});
							esq.addColumn("Rate");
							var filters = Ext.create("BPMSoft.FilterGroup");
							var contactFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Contact", contact.value);
							filters.addItem(contactFilter);
							var startDateFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.LESS_OR_EQUAL, "StartDate", new Date(this.get("Project").StartDate));
							filters.addItem(startDateFilter);
							var dueDateFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, "DueDate", new Date(this.get("Project").StartDate));
							filters.addItem(dueDateFilter);
							esq.filters = filters;
							esq.getEntityCollection(function(response) {
								if (response.success) {
									if (response.collection.getCount() > 0) {
										this.set("InternalRate", (response.collection.collection.items[0].values.Rate));
									}
								}
							}, this);
						} else { this.set("InternalRate", null); }
					}
				},

				onContactChangeSetExternalRate: function() {
					if (this.get("Operation") === ConfigurationEnums.CardState.Add) {
						var contact = this.get("Contact");
						if (contact && this.get("IsChanged")) {
							var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "ContactExternalRate"
							});
							esq.addColumn("Rate");
							var filters = Ext.create("BPMSoft.FilterGroup");
							var contactFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Contact", contact.value);
							filters.addItem(contactFilter);
							var startDateFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.LESS_OR_EQUAL, "StartDate", new Date(this.get("Project").StartDate));
							filters.addItem(startDateFilter);
							var dueDateFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, "DueDate", new Date(this.get("Project").StartDate));
							filters.addItem(dueDateFilter);
							esq.filters = filters;
							esq.getEntityCollection(function(response) {
								if (response.success) {
									if (response.collection.getCount() > 0) {
										this.set("ExternalRate", (response.collection.collection.items[0].values.Rate));
									}
								}
							}, this);
						} else { this.set("ExternalRate", null); }
					}
				},

				getWorkVisible: function() {
					return this.get("Operation") !== ConfigurationEnums.CardState.Add;
				},

				setRateCaption: function(boundRate) {
					BPMSoft.SysSettings.querySysSettingsItem("PrimaryCurrency", function(sysSettingsId) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", { rootSchemaName: "Currency" });
						var primaryColumnFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Id", sysSettingsId.value);
						esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
						esq.addColumn("Symbol");
						esq.filters.add("primaryColumnValue", primaryColumnFilter);
						StorageUtilities.GetESQResultByKey({
							scope: this,
							key: "BaseCurrencyName",
							callback: function(response) {
								var currencySymbol;
								if (response.success) {
									var responseCollection = response.collection;
									if (responseCollection) {
										var currency = responseCollection.getItems()[0];
										if (currency) {
											currencySymbol = currency.get("Symbol");
										}
									}
								}
								var rateCaptionTemplate = this.get("Resources.Strings." + boundRate);
								var baseCurrencyName = currencySymbol || this.get("Resources.Strings.BaseCurrency");
								var rateCaption = Ext.String.format(rateCaptionTemplate, baseCurrencyName);
								this.set(boundRate, rateCaption);
							},
							esq: esq
						});
					}, this);
				},

				init: function() {
					this.callParent(arguments);
					var rateInternalCaption = this.get("RateInternalCaption");
					var rateExternalCaption = this.get("RateExternalCaption");
					if (!rateInternalCaption) {
						this.setRateCaption("RateInternalCaption");
					}
					if (!rateExternalCaption) {
						this.setRateCaption("RateExternalCaption");
					}
				},

				onLookupResult: function(args) {
					var columnName = args.columnName;
					var selectedRows = args.selectedRows;
					var oldValue = this.get(columnName);
					if (!selectedRows.isEmpty()) {
						if (oldValue && oldValue.value === selectedRows.getByIndex(0).value && columnName === "Contact") {
							this.onContactChangeSetInternalRate();
							this.onContactChangeSetExternalRate();
							return;
						}
					}
					this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "actions"
				},
				{
					"operation": "insert",
					"name": "ProjectResourceElementPageGeneralTabContainer",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": 7,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ProjectResourceElementPageGeneralTabContainer",
					"name": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"itemType": 0,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Project",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"layout": {
							"row": 0,
							"column": 0,
							"colSpan": 24
						},
						"controlConfig": {
							"enabled": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"layout": {
							"row": 1,
							"column": 0,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "Contact",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"layout": {
							"row": 2,
							"column": 0,
							"colSpan": 24
						},
						"bindTo": "Contact"
					}
				},
				{
					"operation": "insert",
					"name": "InternalRate",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"layout": {
							"row": 3,
							"column": 0,
							"colSpan": 24
						},
						"caption": { "bindTo": "RateInternalCaption" }
					}
				},
				{
					"operation": "insert",
					"name": "ExternalRate",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"layout": {
							"row": 4,
							"column": 0,
							"colSpan": 24
						},
						"caption": { "bindTo": "RateExternalCaption" }
					}
				},
				{
					"operation": "insert",
					"name": "PlanningWork",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "getWorkVisible"
						},
						"layout": {
							"row": 5,
							"column": 0,
							"colSpan": 24
						},
						"controlConfig": {
							"enabled": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "ActualWork",
					"parentName": "ProjectResourceElementPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "getWorkVisible"
						},
						"layout": {
							"row": 6,
							"column": 0,
							"colSpan": 24
						},
						"controlConfig": {
							"enabled": false
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
