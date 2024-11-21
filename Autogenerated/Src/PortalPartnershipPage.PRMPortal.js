define("PortalPartnershipPage", ["PRMEnums", "css!PartnershipCommonCSS"], function() {
	return {
		entitySchemaName: "Partnership",
		attributes: {
			/**
			 * Partnership margin.
			 * @type {Float}
			 */
			"Margin": {
				"dataValueType": BPMSoft.DataValueType.FLOAT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {
					"bindTo": "Resources.Strings.MarginCaption"
				}
			},
			"MarketingActivities": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {
					"bindTo": "Resources.Strings.MarketingActivitiesCaption"
				}
			},
			/**
			 * Partnership total sales.
			 * @type {Integer}
			 */
			"TotalSales": {
				"dataValueType": BPMSoft.DataValueType.FLOAT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {
					"bindTo": "Resources.Strings.TotalSalesCaption"
				}
			},
			/**
			 * Partnership certified employees.
			 * @type {Integer}
			 */
			"CertifiedEmployees": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {
					"bindTo": "Resources.Strings.CertifiedEmployeesCaption"
				}
			},
			/**
			 * Partnership current score.
			 * @type {Integer}
			 */
			"CurrentScore": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": 0
			},
			/**
			 * Partnership max current score.
			 * @type {Integer}
			 */
			"MaxCurrentScore": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": 0
			},
			/**
			 * Partnership current level.
			 * @type {Integer}
			 */
			"CurrentLevel": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": 0
			},
			/**
			 * Partnership max current level.
			 * @type {Integer}
			 */
			"MaxCurrentLevel": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": 0
			},
			/**
			 * Partner level.
			 */
			"PartnerLevel": {
				"lookupListConfig": {
					"columns": ["Number", "TargetScore"]
				}
			},
			/**
			 * Partner level.
			 */
			"PartnerType": {
				"dependencies": [
					{
						"columns": ["PartnerType"],
						"methodName": "onPartnerTypeChange"
					}
				]
			},
			/**
			 * Partnership start date.
			 */
			"StartDate": {
				"dependencies": [
					{
						"columns": ["StartDate"],
						"methodName": "onStartDateChange"
					}
				]
			},
			/**
			 * @inheritDoc BaseDataView#UseTagModule
			 */
			"UseTagModule": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"EducationAndCertificate": {
				"schemaName": "EducationAndCertificateDetail",
				"filter": {
					"masterColumn": "Account",
					"detailColumn": "Contact.Account"
				}
			},
			"PartnershipLeadDetail": {
				"schemaName": "PartnershipLeadDetail",
				"entitySchemaName": "Lead",
				"filter": {
					"detailColumn": "Partner",
					"masterColumn": "Account"
				}
			},
			"PartnershipParameterDetail": {
				"schemaName": "PartnershipParameterDetail",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Partnership"
				}
			},
			"PartnershipAttachmentsDetail": {
				"schemaName": "FileDetailV2",
				"entitySchemaName": "PartnershipFile",
				"filter": {
					"detailColumn": "Partnership",
					"masterColumn": "Id"
				}
			},
			"PartnershipOpportunityDetail": {
				"schemaName": "PartnershipOpportunityDetail",
				"entitySchemaName": "Opportunity",
				"filter": {
					"detailColumn": "Partner",
					"masterColumn": "Account"
				},
				"subscriber": {
					"methodName": "updatePRMTransactionDetail"
				}
			},
			"Fund": {
				"schemaName": "FundDetail",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Partnership"
				}
			},
			"PRMTransaction": {
				"schemaName": "PRMTransactionDetail",
				"filter": {
						"masterColumn": "Id",
						"detailColumn": "Partnership"
				}
			},
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {

			/**
			 * Updates PRMTransaction detail.
			 * @protected
			 */
			updatePRMTransactionDetail: function() {
				this.updateDetail({detail: "PRMTransaction"});
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseViewModel#getEntitySchemaQuery
			 * @overridden
			 */
			getEntitySchemaQuery: function() {
				var esq = this.callParent(arguments);
				this.addCurrentScoreColumn(esq);
				this.addMaxCurrentLevelColumn(esq);
				this.addMarginColumn(esq);
				this.addTotalSalesColumn(esq);
				this.addCertifiedEmployeesColumn(esq);
				this.addMarketingActivitiesColumn(esq);
				return esq;
			},

			/**
			 * Adds total Marketing Activities Column to esq.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			addMarketingActivitiesColumn: function(esq) {
				var expressionConfig = {
					columnPath: "[PartnershipParameter:Partnership].IntValue",
					parentCollection: this
				};
				var column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
				var marketingActivityFilter = BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "PartnerParamCategory",
					BPMSoft.PRMEnums.PartnerParamCategory.MarketingActivities);
				column.subFilters.addItem(marketingActivityFilter);
				var partnershipParameterTypeFilter = esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"PartnershipParameterType", BPMSoft.PRMEnums.PartnershipParamType.Current);
				column.subFilters.addItem(partnershipParameterTypeFilter);
				var parameterTypeFilter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"ParameterType", BPMSoft.PRMEnums.ParameterType.Obligation);
				column.subFilters.addItem(parameterTypeFilter);
				var esqColumn = esq.addColumn("MarketingActivities");
				esqColumn.expression = column;
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#setColumnValues
			 * @overridden
			 */
			setColumnValues: function(entity) {
				this.set("MaxCurrentScore", entity.get("PartnerLevel.TargetScore"));
				this.set("CurrentScore", entity.get("CurrentScore"));
				this.set("MaxCurrentLevel", entity.get("MaxCurrentLevel"));
				this.set("CurrentLevel", entity.get("PartnerLevel.Number"));
				this.set("Margin", entity.get("Margin"));
				this.set("TotalSales", entity.get("TotalSales"));
				this.set("CertifiedEmployees", entity.get("CertifiedEmployees"));
				this.set("MarketingActivities", entity.get("MarketingActivities"));
				this.callParent(arguments);
			},

			/**
			 * Returns current date.
			 * @protected
			 * @return {Date}
			 */
			getCurrentDate: function() {
				return this.BPMSoft.clearTime(new Date());
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#setDefaultValues
			 * @overridden
			 */
			setDefaultValues: function(callback, scope) {
				this.callParent([function() {
					var startDate = this.getCurrentDate();
					var currentDate = new Date();
					var currentYear = currentDate.getFullYear();
					var dueDate = new Date(currentYear + 1, 2, 31);
					this.set("DueDate", dueDate);
					this.set("StartDate", startDate);
					callback.call(scope);
				}, this]);
			},

			/**
			 * Adds max current level column to esq.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			addMaxCurrentLevelColumn: function(esq) {
				esq.addAggregationSchemaColumn("[PartnerLevel:PartnerType:PartnerType].Number",
					BPMSoft.AggregationType.MAX, "MaxCurrentLevel");
			},

			/**
			 * Adds margin column to esq.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			addMarginColumn: function(esq) {
				var expressionConfig = {
					columnPath: "[PartnershipParameter:Partnership].FloatValue",
					parentCollection: this
				};
				var column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
				var marginFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"PartnerParamCategory", BPMSoft.PRMEnums.PartnerParamCategory.Margin);
				column.subFilters.addItem(marginFilter);
				var partnershipParameterTypeFilter = esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"PartnershipParameterType", BPMSoft.PRMEnums.PartnershipParamType.Current);
				column.subFilters.addItem(partnershipParameterTypeFilter);
				var parameterTypeFilter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"ParameterType", BPMSoft.PRMEnums.ParameterType.Benefit);
				column.subFilters.addItem(parameterTypeFilter);
				var esqColumn = esq.addColumn("Margin");
				esqColumn.expression = column;
			},

			/**
			 * Adds current score column to esq.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			addCurrentScoreColumn: function(esq) {
				var expressionConfig = {
					columnPath: "[PartnershipParameter:Partnership].Score",
					parentCollection: this,
					aggregationType: BPMSoft.AggregationType.SUM
				};
				var column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
				var partnershipParameterTypeFilter = esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"PartnershipParameterType", BPMSoft.PRMEnums.PartnershipParamType.Current);
				column.subFilters.addItem(partnershipParameterTypeFilter);
				var parameterTypeFilter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"ParameterType", BPMSoft.PRMEnums.ParameterType.Obligation);
				column.subFilters.addItem(parameterTypeFilter);
				var esqColumn = esq.addColumn("CurrentScore");
				esqColumn.expression = column;
			},

			/**
			 * Adds total sales column to esq.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			addTotalSalesColumn: function(esq) {
				var expressionConfig = {
					columnPath: "[PartnershipParameter:Partnership].FloatValue",
					parentCollection: this
				};
				var column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
				var totalSalesFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"PartnerParamCategory", BPMSoft.PRMEnums.PartnerParamCategory.TotalSales);
				column.subFilters.addItem(totalSalesFilter);
				var partnershipParameterTypeFilter = esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"PartnershipParameterType", BPMSoft.PRMEnums.PartnershipParamType.Current);
				column.subFilters.addItem(partnershipParameterTypeFilter);
				var esqColumn = esq.addColumn("TotalSales");
				esqColumn.expression = column;
			},

			/**
			 * Adds certified employees column to esq.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			addCertifiedEmployeesColumn: function(esq) {
				var expressionConfig = {
					columnPath: "[PartnershipParameter:Partnership].IntValue",
					parentCollection: this
				};
				var column = Ext.create("BPMSoft.SubQueryExpression", expressionConfig);
				var certifiedEmployeesFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"PartnerParamCategory", BPMSoft.PRMEnums.PartnerParamCategory.CertifiedEmployees);
				column.subFilters.addItem(certifiedEmployeesFilter);
				var partnershipParameterTypeFilter = esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"PartnershipParameterType", BPMSoft.PRMEnums.PartnershipParamType.Current);
				column.subFilters.addItem(partnershipParameterTypeFilter);
				var parameterTypeFilter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"ParameterType", BPMSoft.PRMEnums.ParameterType.Obligation);
				column.subFilters.addItem(parameterTypeFilter);
				var esqColumn = esq.addColumn("CertifiedEmployees");
				esqColumn.expression = column;
			},

			/**
			 * Handles PartnerType change event.
			 * @protected
			 */
			onPartnerTypeChange: function() {
				var type = this.get("PartnerType");
				if (type && this.isNewMode()) {
					this.setDefaultLevelByType(type.value);
				}
			},

			/**
			 * Handles StartDateChange change event. Sets 'DueDate' attribute value to the last day of the year
			 * from 'StartDate' attribute value.
			 * @protected
			 */
			onStartDateChange: function() {
				var startDate = this.get("StartDate");
				if (this.isNotEmpty(startDate)) {
					var lastDay = this.BPMSoft.endOfYear(BPMSoft.clearTime(startDate));
					this.set("DueDate", lastDay);
				}
			},

			/**
			 * Sets default partnership level by type.
			 * @protected
			 * @param {String} typeValue Partnership type value.
			 */
			setDefaultLevelByType: function(typeValue) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "PartnerLevel"
				});
				var numberColumn = esq.addColumn("Number");
				numberColumn.orderPosition = 0;
				numberColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				var typeFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"PartnerType", typeValue);
				esq.filters.addItem(typeFilter);
				esq.getEntityCollection(function(response) {
					if (response && response.success) {
						var collection = response.collection;
						if (collection && collection.getCount() > 0) {
							var defaultLevel = collection.getByIndex(0);
							this.set("PartnerLevel", {
								value: defaultLevel.get("Id")
							});
						}
					}
				}, this);
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MetricsContainer",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					},
					"itemType": 7,
					"classes": {
						"wrapClassName": [
							"ts-metrics-container"
						]
					},
					"items": []
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CurrentLevelContainer",
				"values": {
					"items": [],
					"itemType": 7,
					"classes": {
						"wrapClassName": [
							"ts-metric-item",
							"ts-days-in-funnel-container"
						]
					}
				},
				"parentName": "MetricsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CurrentLevelValue",
				"values": {
					"generator": "ConfigurationRoundProgressBarGenerator.generateProgressBar",
					"controlConfig": {
						"captionSuffix": "",
						"value": {
							"bindTo": "CurrentLevel"
						},
						"maxValue": {
							"bindTo": "MaxCurrentLevel"
						},
						"size": 90,
						"clockwise": true,
						"borderWidth": 3,
						"classes": [
							"ts-font-light"
						]
					}
				},
				"parentName": "CurrentLevelContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CurrentLevelCaption",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.CurrentLevelCaption"
					},
					"classes": {
						"labelClass": [
							"ts-metric-item-caption"
						]
					},
					"itemType": 6
				},
				"parentName": "CurrentLevelContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CurrentScoreContainer",
				"values": {
					"items": [],
					"itemType": 7,
					"classes": {
						"wrapClassName": [
							"ts-metric-item",
							"ts-days-in-funnel-container"
						]
					}
				},
				"parentName": "MetricsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CurrentScoreValue",
				"values": {
					"generator": "ConfigurationRoundProgressBarGenerator.generateProgressBar",
					"controlConfig": {
						"captionSuffix": "",
						"value": {
							"bindTo": "CurrentScore"
						},
						"maxValue": {
							"bindTo": "MaxCurrentScore"
						},
						"size": 90,
						"clockwise": true,
						"borderWidth": 3,
						"classes": [
							"ts-font-light"
						]
					}
				},
				"parentName": "CurrentScoreContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CurrentScoreCaption",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.CurrentPointCaption"
					},
					"classes": {
						"labelClass": [
							"ts-metric-item-caption"
						]
					},
					"itemType": 6
				},
				"parentName": "CurrentScoreContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "StartDate",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 4
					}
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "DueDate",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 5
					}
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "IsActive",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 6
					}
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 6
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
				"name": "ContactGeneralInfoControlGroup",
				"values": {
					"itemType": 15,
					"items": []
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PartnershipGeneralInfoBlock",
				"values": {
					"itemType": 0,
					"items": [],
					"collapseEmptyRow": true
				},
				"parentName": "ContactGeneralInfoControlGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TotalSales",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					},
					"enabled": false
				},
				"parentName": "PartnershipGeneralInfoBlock",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MarketingActivities",
				"values": {
					"layout": {
						"colSpan": 11,
						"column": 13,
						"row": 0
					},
					"enabled": false
				},
				"parentName": "PartnershipGeneralInfoBlock",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Margin",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					},
					"enabled": false
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "EducationAndCertificate",
				"values": {
					"itemType": 2
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OpportunityAndLeadTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.OpportunityAndLeadTabCaption"
					},
					"items": []
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "PartnershipLeadDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "OpportunityAndLeadTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PartnershipOpportunityDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "OpportunityAndLeadTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "PartnershipParameterDetail",
				"values": {
					"itemType": 2
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "PartnershipAttachmentsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.PartnershipAttachmentsTab"
					},
					"items": []
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "PartnershipAttachmentsDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "PartnershipAttachmentsTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Fund",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "PRMTransaction",
				"values": {
						"itemType": 2
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 4
			},
		]/**SCHEMA_DIFF*/
	};
});
