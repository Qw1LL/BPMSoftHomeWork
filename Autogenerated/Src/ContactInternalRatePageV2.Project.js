﻿define("ContactInternalRatePageV2", ["BPMSoft", "BusinessRuleModule", "ext-base", "sandbox", "StorageUtilities"],
		function(BPMSoft, BusinessRuleModule, Ext, sandbox, StorageUtilities) {
			return {
				entitySchemaName: "ContactInternalRate",
				attributes: {
					"StartDate": {
						"dependencies": [
							{
								"columns": ["DueDate"],
								"methodName": "onDueDateChanged"
							}
						]
					},
					"DueDate": {
						"dependencies": [
							{
								"columns": ["StartDate"],
								"methodName": "onStartDateChanged"
							}
						]
					}
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				methods: {
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("Rate", function(value) {
							var invalidMessage = "";
							if (value < 0) {
								invalidMessage = this.get("Resources.Strings.WarningRateLessZero");
							}
							return {
								fullInvalidMessage: invalidMessage,
								invalidMessage: invalidMessage
							};
						});
					},
					onStartDateChanged: function() {
						var startDate = this.get("StartDate");
						if (!startDate) {
							return;
						}
						var dueDate = this.get("DueDate");
						if (dueDate && dueDate < startDate) {
							this.showInformationDialog(this.get("Resources.Strings.dueDateLessStartDate"), function() {
							}, {
								style: BPMSoft.MessageBoxStyles.ORANGE
							});
							this.set("DueDate", startDate);
						}
					},
					onDueDateChanged: function() {
						var dueDate = this.get("DueDate");
						if (!dueDate) {
							return;
						}
						var startDate = this.get("StartDate");
						if (startDate && dueDate < startDate) {
							this.showInformationDialog(this.get("Resources.Strings.dueDateLessStartDate"), function() {
							}, {
								style: BPMSoft.MessageBoxStyles.ORANGE
							});
							this.set("StartDate", dueDate);
						}
					},
					checkOnSave: function(datesChecked) {
						var startDate = this.get("StartDate");
						if (startDate) {
							startDate = new Date(startDate).setHours(0, 0, 0, 0);
						}
						var dueDate = this.get("DueDate");
						if (dueDate) {
							dueDate = new Date(dueDate).setHours(0, 0, 0, 0);
						}
						if (datesChecked === true || !dueDate) {
							this.ckecked = true;
							this.save();
						}
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "ContactInternalRate"});
						select.addColumn("StartDate");
						select.addColumn("DueDate");
						select.filters.add("others", BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Contact", this.get("Contact").value));
						select.filters.add("current", BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL,
								"Id", this.get("Id")));
						select.getEntityCollection(function(response) {
							if (!response.success) {
								return;
							}
							var datesChecked = true;
							response.collection.getItems().forEach(function(item) {
								var itemStartDate = item.get("StartDate");
								var itemDueDate = item.get("DueDate");
								var startDateCondition = startDate >= itemStartDate && startDate <= itemDueDate;
								var dueDateCondition = dueDate >= itemStartDate && dueDate <= itemDueDate;
								var durationCondition = startDate <= itemStartDate && dueDate >= itemDueDate;
								datesChecked = datesChecked && !(startDateCondition || dueDateCondition || durationCondition);
							});
							if (datesChecked) {
								this.ckecked = true;
								this.save();
							} else {
								this.showInformationDialog(this.get("Resources.Strings.PeriodExists"), function() {
								}, {
									style: BPMSoft.MessageBoxStyles.ORANGE
								});
							}
						}, this);
						this.ckecked = false;
					},
					save: function() {
						if (this.ckecked) {
							this.callParent(arguments);
							this.ckecked = false;
						} else { this.checkOnSave(); }
					},
					init: function() {
						this.callParent(arguments);
						var rateCaption = this.get("RateCaption");
						if (!rateCaption) {
							BPMSoft.SysSettings.querySysSettingsItem("PrimaryCurrency", function(sysSettingsId) {
								var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Currency"});
								var primaryColumnFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
										"Id", sysSettingsId.value);
								esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
								esq.addColumn("Symbol");
								esq.filters.add("primaryColumnValue", primaryColumnFilter);
								StorageUtilities.GetESQResultByKey({
									scope: this,
									key: "BaseCurrencyName",
									callback: function(response) {
										var currencyName;
										var currencySymbol;
										if (response.success) {
											var responseCollection = response.collection;
											if (responseCollection) {
												var currency = responseCollection.getItems()[0];
												if (currency) {
													currencyName = currency.get("Name");
													currencySymbol = currency.get("Symbol");
												}
											}
										}
										var rateCaptionTemplate = this.get("Resources.Strings.Rate");
										var baseCurrencyName = currencySymbol || this.get("Resources.Strings.BaseCurrency");
										rateCaption = Ext.String.format(rateCaptionTemplate, baseCurrencyName);
										this.set("RateCaption", rateCaption);
									},
									esq: esq
								});
							}, this);
						}
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "ContactInternalRatePageGeneralTabContainer",
						"values": {
							"itemType": 7,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "ContactInternalRatePageGeneralTabContainer",
						"propertyName": "items",
						"name": "ContactInternalRatePageGeneralBlock",
						"values": {
							"itemType": 0,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Contact",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							},
							"enabled": false
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "StartDate",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "DueDate",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Rate",
						"values": {
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 11
							},
							"caption": { "bindTo": "RateCaption"}
						}
					},
					{
						"operation": "remove",
						"name": "actions"
					}
				]/**SCHEMA_DIFF*/,
				rules: {},
				userCode: {}
			};
		});
