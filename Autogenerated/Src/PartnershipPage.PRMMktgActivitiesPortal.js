define("PartnershipPage", ["BPMSoft"],
		function() {
			return {
				entitySchemaName: "Partnership",
				details: /**SCHEMA_DETAILS*/{
					"MarketingActivitiesDetail": {
						"schemaName": "PartnershipPageMktgActivityDetail",
						"entitySchemaName": "MktgActivity",
						"filter": {
							"detailColumn": "Partnership",
							"masterColumn": "Id"
						}
					}
				}/**SCHEMA_DETAILS*/,
				attributes: {
					"MarketingActivities": {
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"caption": {
							"bindTo": "Resources.Strings.MarketingActivitiesCaption"
						}
					}
				},
				methods: {

					/**
					 * @inheritdoc BPMSoft.BaseViewModel#getEntitySchemaQuery
					 * @overridden
					 */
					getEntitySchemaQuery: function() {
						var esq = this.callParent(arguments);
						this.addMarketingActivitiesColumn(esq);
						return esq;
					},

					/**
					 * @inheritDoc BaseViewModel#setColumnValues
					 * @overridden
					 */
					setColumnValues: function(entity) {
						this.set("MarketingActivities", entity.get("MarketingActivities"));
						this.callParent(arguments);
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
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "MarketingActivities",
						"values": {
							"layout": {
								"colSpan": 11,
								"column": 0,
								"row": 1
							},
							"enabled": false
						},
						"parentName": "PartnershipGeneralInfoBlock",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "MarketingActivitiesTab",
						"values": {
							"caption": {"bindTo": "Resources.Strings.MarketingActivitiesTabCaption"},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "MarketingActivitiesDetail",
						"values": {
							"itemType": 2,
							"markerValue": "added-detail"
						},
						"parentName": "MarketingActivitiesTab",
						"propertyName": "items",
						"index": 3
					}
				]/**SCHEMA_DIFF*/,
				rules: {},
				userCode: {}
			};
		});
