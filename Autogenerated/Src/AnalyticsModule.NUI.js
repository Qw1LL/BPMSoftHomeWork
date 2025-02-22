﻿define("AnalyticsModule", ["ext-base", "BPMSoft", "sandbox", "AnalyticsModuleResources", "ConfigurationConstants",
		"LocalizationUtilities"],
		function(Ext, BPMSoft, sandbox, resources, ConfigurationConstants, LocalizationUtilities) {

	var getViewModel = function() {
		return Ext.create("BPMSoft.BaseViewModel", {
			//todo SysModuleAnalyticsChart deleted
			entitySchema: null,
//			columns: {
//				QualifiedAccount: {
//					dataValueType: BPMSoft.DataValueType.LOOKUP,
//					isLookup: true,
//					referenceSchemaName: "Account"
//				},
//				QualifiedContact: {
//					dataValueType: BPMSoft.DataValueType.LOOKUP,
//					isLookup: true,
//					referenceSchemaName: "Contact"
//				}
//			},
			values: {
				analyticsGridData: new BPMSoft.Collection()
			},
			methods: {
				getCurrentModuleCharts: function(recordId) {
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						//todo SysModuleAnalyticsChart deleted
						rootSchema: null
					});
					select.addColumn("Id");
					LocalizationUtilities.addLocalizableColumn(select, "Caption");
					select.addColumn("Logo");
					select.addColumn("SeriesKind");
					var filters = Ext.create("BPMSoft.FilterGroup");
					filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"ModuleSchemaUId", recordId));
					select.filters = filters;
					select.getEntityCollection(function(response) {
						var collection = this.get("analyticsGridData");
						var entities = response.collection;
						entities.each(function(item) {
							item.entitySchema = this.entitySchema;
							collection.add(item.get("Id"), item);
						}, this);
					}, this);
				},
				chartSelected: function(key) {
					sandbox.publish("GenerateChart", key);
				}

			}
		});
	};

	function generateMainView() {
		var leftConfig = Ext.create("BPMSoft.Container", {
			id: "leftContainer",
			classes: {
				wrapClassName: [
					"left-container"
				]
			},
			selectors: {
				wrapEl: "#leftContainer"
			},
			items: [
				Ext.create("BPMSoft.ControlGroup", {
					caption: resources.localizableStrings.graphiscsCaption,
					collapsed: false,
					id: "chartContainer",
					selectors: {
						wrapEl: "#chartContainer"
					},
					items: [
						{
							className: "BPMSoft.Grid",
							type: "tiled",
							selectRow: {
								bindTo: "chartSelected"
							},
							columnsConfig: [
								{
									cols: 20,
									key: [
										{
											name: {
												bindTo: "Caption",
												primaryImageColumnName: "Logo"
											}
										}
									]
								}
							],
							collection: {
								bindTo: "analyticsGridData"
							},
							watchedRowInViewport: {
								bindTo: "loadNext"
							}
						}

					]

				})
			]
		});

		var rightConfig = Ext.create("BPMSoft.Container", {
			id: "rightContainer",
			classes: {
				wrapClassName: [
					"right-container"
				]
			},
			selectors: {
				wrapEl: "#rightContainer"
			}
		});
		return Ext.create("BPMSoft.Container", {
			id: "topContainer",
			selectors: {
				wrapEl: "#topContainer"
			},
			items: [
				leftConfig,
				rightConfig
			]
		});
	}

	var render = function(renderTo) {
		var viewConfig = generateMainView();
		var viewModel = getViewModel();
		var recordId = "c449d832-a4cc-4b01-b9d5-8a12c42a9f89";
		viewModel.getCurrentModuleCharts(recordId);
		viewConfig.bind(viewModel);
		viewConfig.render(renderTo);
		var chartRenderTo = Ext.get("rightContainer");
		sandbox.loadModule("ChartModule", {
			renderTo: chartRenderTo
		});
	};
	return {
		render: render
	};
});
