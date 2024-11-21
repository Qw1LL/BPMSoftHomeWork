define("ProjectFinanceDetailV2", ["ProjectFinanceDetailV2Resources", "BPMSoft", "ProjectUtilities"],
	function(resources, BPMSoft) {
		return {
			entitySchemaName: "Project",
			mixins: {
				/**
				 * ######## ######## ######## ###### ## #######
				 */
				"ProjectUtilities": "BPMSoft.ProjectUtilities"
			},
			attributes: {
				/**
				 * ####### ######### ##########
				 */
				"Significative": {
					"caption": resources.localizableStrings.SignificativeCaption,
					"dataValueType": BPMSoft.DataValueType.TEXT
				},
				/**
				 * ####### ######### ##########
				 */
				"Plan": {
					"caption": resources.localizableStrings.PlanCaption,
					"dataValueType": BPMSoft.DataValueType.FLOAT
				},
				/**
				 * ####### ############ ##########
				 */
				"Fact": {
					"caption": resources.localizableStrings.FactCaption,
					"dataValueType": BPMSoft.DataValueType.FLOAT
				},
				/**
				 * ####### ########## ##########
				 */
				"Deviation": {
					"caption": resources.localizableStrings.DeviationCaption,
					"dataValueType": BPMSoft.DataValueType.FLOAT
				},
				/**
				 * ####### ########## ########## # %
				 */
				"DeviationProc": {
					"caption": resources.localizableStrings.DeviationProcCaption,
					"dataValueType": BPMSoft.DataValueType.FLOAT
				}
			},
			methods: {

				/**
				 * ############### #######
				 * @protected
				 * @overridden
				 */
				init: function() {
					this.mixins.ProjectUtilities.init.call(this);
					this.callParent(arguments);
				},

				/**
				 * ########## ###### ####### ########, ####### ######## ########, # ## ### #######
				 * @protected
				 * @virtual
				 * @returns {String[]} ########## ###### ####### ########, ####### ######## ########, # ## ### #######
				 */
				getDecouplingValueColumns: function() {
					return ["Significative"];
				},

				/**
				 * ########## ######-######## #### ####### # #######
				 * @protected
				 * @virtual
				 * @returns {Object} ########## ######-######## #### ####### # #######
				 */
				getGridValuesDecoupling: function() {
					return {
						Significative: [
							this.get("Resources.Strings.IncomeCaption"),
							this.get("Resources.Strings.ExternalCostCaption"),
							this.get("Resources.Strings.ExpenseCaption"),
							this.get("Resources.Strings.InternalCostCaption"),
							this.get("Resources.Strings.MarginCaption"),
							this.get("Resources.Strings.MarginPercCaption")
						],
						Plan: ["PlanIncome", "PlanExpense", "PlanExternalCost",
							"PlanInternalCost", "PlanMargin", "PlanMarginPerc"],
						Fact: ["FactIncome", "FactExpense", "FactExternalCost",
							"FactInternalCost", "FactMargin", "FactMarginPerc"],
						Deviation: ["IncomeDev", "ExpenseDev", "ExternalCostDev",
							"InternalCostDev", "MarginDev", ""],
						DeviationProc: ["IncomeDevPerc", "ExpenseDevPerc", "PlanExternalDevPerc",
							"PlanInternalDevPerc", "MarginDevPerc", ""]
					};
				},

				/**
				 * ######### ####### ########## ########### # ######
				 * @protected
				 * @overridden
				 * @param {BPMSoft.EntitySchemaQuery} esq ######, # ####### ##### ################### #######
				 */
				initQueryColumns: function(esq) {
					var decoupling = this.getGridValuesDecoupling();
					var decouplingValueColumns = this.getDecouplingValueColumns();
					BPMSoft.each(decoupling, function(columnDecoupling, decouplingName) {
						if (decouplingValueColumns.indexOf(decouplingName) !== -1) {
							return;
						}
						BPMSoft.each(columnDecoupling, function(columnName) {
							if (columnName && !esq.columns.contains(columnName)) {
								esq.addColumn(columnName);
							}
						}, this);
					}, this);
				},

				/**
				 * ######## ##########
				 * @protected
				 * @overridden
				 */
				initQuerySorting: BPMSoft.emptyFn,

				/**
				 * ######## ##############, #############
				 * @protected
				 * @overridden
				 */
				initQueryOptions: BPMSoft.emptyFn,

				/**
				 * ############ ########### ######. ######### # ###### ############## ######### ########## ###########
				 * # ###### ########### ########.
				 * @protected
				 * @overridden
				 */
				onGridDataLoaded: function(response) {
					this.afterLoadGridData();
					if (!response.success) {
						return;
					}
					var dataCollection = response.collection;
					if (dataCollection.isEmpty()) {
						return;
					}
					var currentProject = dataCollection.getByIndex(0);
					var columnValues = this.prepareGridCollection(currentProject);
					columnValues.each(function(item) {
						BPMSoft.each(item.columns, function(column) {
							column.columnPath = column.caption;
							this.addColumnLink(item, column);
						}, this);
					}, this);
					var gridData = this.getGridData();
					gridData.clear();
					gridData.loadAll(columnValues);
				},

				/**
				 * ######### ######### #########
				 * @protected
				 * @virtual
				 * @param {BPMSoft.BaseViewModel} project ######### #######
				 */
				prepareGridCollection: function(project) {
					var decoupling = this.getGridValuesDecoupling();
					var result = BPMSoft.mapObjectToCollection(decoupling);
					var decouplingValueColumns = this.getDecouplingValueColumns();
					var collection = this.Ext.create("BPMSoft.Collection");
					BPMSoft.each(result, function(columnValues) {
						BPMSoft.each(columnValues, function(columnValue, columnName) {
							if (decouplingValueColumns.indexOf(columnName) !== -1) {
								return;
							}
							columnValues[columnName] = columnValue && (project.get(columnValue) || 0);
						}, this);
						collection.add(BPMSoft.generateGUID(), this.createFinanceItem(columnValues));
					}, this);

					return collection;
				},

				/**
				 * ####### ###### ######
				 * @param {Object} values ###### ######## ######
				 * @returns {BPMSoft.BaseViewModel} ########## ###### ######
				 */
				createFinanceItem: function(values) {
					return this.Ext.create("BPMSoft.BaseViewModel", {
						name: "FinanceItem",
						primaryColumnName: "Id",
						primaryDisplayColumnName: "Significative",
						columns: {
							Id: {dataValueType: BPMSoft.DataValueType.GUID},
							Significative: {caption: "Significative", dataValueType: BPMSoft.DataValueType.TEXT},
							Plan: {caption: "Plan", dataValueType: BPMSoft.DataValueType.FLOAT},
							Fact: {caption: "Fact", dataValueType: BPMSoft.DataValueType.FLOAT},
							Deviation: {caption: "Deviation", dataValueType: BPMSoft.DataValueType.FLOAT},
							DeviationProc: {caption: "DeviationProc", dataValueType: BPMSoft.DataValueType.FLOAT}
						},
						values: values
					});
				},

				/**
				 * ######### ####### ########## ###########
				 * @protected
				 * @virtual
				 */
				calculateProjectCollectionFinance: function() {
					var masterRecordId = this.get("MasterRecordId");
					this.CalculateProjectFinance([masterRecordId], function() {
						this.loadGridData();
					}, this);
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					operation: "remove",
					name: "ToolsButton"
				},
				{
					"operation": "insert",
					"name": "AddTypedRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {
							"bindTo": "Resources.Images.Calculate"
						},
						"classes": {
							"imageClass": ["t-btn-image t-btn-image-left proc-btn-img-top calculate-button-img"],
						},
						"iconAlign": BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
						"click": {"bindTo": "calculateProjectCollectionFinance"},
						"visible": {"bindTo": "getToolsVisible"},
						"hint": {"bindTo": "Resources.Strings.ReCalcButtonCaption"},
						"caption": {"bindTo": "Resources.Strings.CalculateButtonCaption"},
						"markerValue": "CalculateProjectFinance"
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "SignificativeListedGridColumn",
									"bindTo": "Significative",
									"position": {
										"column": 1,
										"colSpan": 8
									}
								},
								{
									"name": "PlanListedGridColumn",
									"bindTo": "Plan",
									"position": {
										"column": 9,
										"colSpan": 4
									}
								},
								{
									"name": "FactListedGridColumn",
									"bindTo": "Fact",
									"position": {
										"column": 13,
										"colSpan": 4
									}
								},
								{
									"name": "DeviationListedGridColumn",
									"bindTo": "Deviation",
									"position": {
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "DeviationProcListedGridColumn",
									"bindTo": "DeviationProc",
									"position": {
										"column": 21,
										"colSpan": 4
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [
								{
									"name": "SignificativeTiledGridColumn",
									"bindTo": "Significative",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 8
									}
								},
								{
									"name": "PlanTiledGridColumn",
									"bindTo": "Plan",
									"position": {
										"row": 1,
										"column": 9,
										"colSpan": 4
									}
								},
								{
									"name": "FactTiledGridColumn",
									"bindTo": "Fact",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 4
									}
								},
								{
									"name": "DeviationTiledGridColumn",
									"bindTo": "Deviation",
									"position": {
										"row": 1,
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "DeviationProcTiledGridColumn",
									"bindTo": "DeviationProc",
									"position": {
										"row": 1,
										"column": 21,
										"colSpan": 4
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
