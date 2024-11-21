define("PrintableProcessModule", ["PrintableProcessModuleResources", "ViewUtilities", "BaseProcessViewModelClass",
			"ProcessHelper", "ReportUtilities", "LocalizationUtilities", "SysModuleReport"],
		function(resources, ViewUtilities, BaseProcessViewModelClass, ProcessHelper, ReportUtilities,
				LocalizationUtilities, SysModuleReport) {

			function createConstructor(context) {

				var Ext = context.Ext;
				var sandbox = context.sandbox;
				var BPMSoft = context.BPMSoft;
				var viewModel;
				var viewConfig;
				var processData;

				function getViewModelConfig(config) {
					var viewModelConfig = {
						columns: {},
						values: {
							message: null,
							pageHeader: null
						},
						methods: {
							onPrintClick: function() {
								var sysModuleReportUId = this.get("PrintableId");
								var printablePackageId = this.get("PrintablePackageId");
								if (!BPMSoft.isGUID(sysModuleReportUId) && !BPMSoft.isGUID(printablePackageId)) {
									return;
								}

								var select = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchema: SysModuleReport});
								select.addColumn("Id");
								select.addColumn("Caption", "NonLocalizedCaption");
								LocalizationUtilities.addLocalizableColumn(select, "Caption");
								select.addColumn("Type.Name", "TypeName");
								select.addColumn("SysModule.SysModuleEntity.SysEntitySchemaUId", "SchemaUId");
								select.addColumn("SysReportSchemaUId");

								if (BPMSoft.isGUID(printablePackageId)) {
									select.filters.add("packageFilter",
											BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
													"[SysModuleReportInPackage:SysModuleReport].SysModuleReportPackage",
													printablePackageId));
								} else {
									select.filters.add("primFilter",
											BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
													"Id", sysModuleReportUId));
								}

								select.getEntityCollection(function(response) {
									if (response && response.success) {
										var items = response.collection.getItems();
										BPMSoft.each(items, function(entity) {
											this.onSysReportLoad(entity);
										}, this);
										this.showConfirmationDialog(resources.localizableStrings.NextByProcessConfirm,
												this.onConfirmClick, ["yes", "no"]);
									}
								}, this);
							},

							onSysReportLoad: function(entity) {
								var schemaUId = entity.get("SchemaUId");
								var reportId = entity.get("SysReportSchemaUId");
								var recordId = BPMSoft.deepClone(this.get("PrintedRecordId") || "");
								var filterGroup = BPMSoft.createFilterGroup();
								filterGroup.name = "primaryColumnFilter";
								var filter = BPMSoft.createColumnInFilterWithParameters("Id", [recordId]);
								filterGroup.addItem(filter);
								var reportParameters = {
									Filters: filterGroup.serialize()
								};
								var reportCaption = entity.get("Caption") || entity.get("NonLocalizedCaption");
								var config = {
									caption: reportCaption,
									schemaUId: schemaUId,
									reportId: reportId,
									recordId: recordId,
									reportParameters: reportParameters,
									type: entity.get("TypeName")
								};
								ReportUtilities.generateReport("reportCaption", config);
							},

							onConfirmClick: function(result) {
								if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.onNextClick();
								}
							},

							onNextClick: function() {
								this.acceptProcessElement();
							},

							onLoad: function() {
								var processData = this.processData;
								this.set("pageHeader", (processData && !Ext.isEmpty(processData.recommendation) ?
										processData.recommendation : resources.localizableStrings.DefHeaderCaption));
								if (processData) {
									BPMSoft.each(this.processData.parameters, function(param, name) {
										var value = param;
										if (ProcessHelper.getIsDateTimeDataValueType(param.dataValueType)) {
											value = BPMSoft.parseDate(param.value);
										}
										this.set(name, value);
									}, this);
								}
							}
						}
					};
					Ext.apply(viewModelConfig, config);
					return viewModelConfig;
				}

				function getViewConfig() {
					var headerMainContainer = ViewUtilities.getContainerConfig("header", "header");
					var headerNameContainer = ViewUtilities.getContainerConfig("header-name-container",
							"header-name-container header-name-container-full");
					headerNameContainer.items = [
						{
							className: "BPMSoft.Label",
							id: "captionLabel",
							caption: {
								bindTo: "pageHeader"
							}
						}
					];
					headerMainContainer.items = [
						headerNameContainer
					];

					var labelContainer = ViewUtilities.getContainerConfig("labelMessageContainer", "labelMessageContainer");
					labelContainer.items = [
						{
							className: "BPMSoft.Label",
							id: "messageLabel",
							caption: {
								bindTo: "PrintableDescription"
							}
						}
					];

					var buttonContainer = ViewUtilities.getContainerConfig("buttonContainer", "buttonContainer");
					buttonContainer.items = [
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.PrintButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							click: {
								bindTo: "onPrintClick"
							}
						}, {
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.NextButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
							click: {
								bindTo: "onNextClick"
							}
						}
					];

					var pageConfig = ViewUtilities.getContainerConfig("CardMainContainer", "CardMainContainer");
					pageConfig.items = [
						headerMainContainer,
						buttonContainer,
						labelContainer
					];
					return pageConfig;
				}

				function render(renderTo) {
					processData = ProcessHelper.getProcessElementData(sandbox);
					var viewModelConfig = getViewModelConfig({});
					viewModel = Ext.create("BPMSoft.BaseProcessViewModel", viewModelConfig);
					viewModel.sandbox = sandbox;
					viewModel.processData = processData;
					viewConfig = getViewConfig();

					var config = BPMSoft.deepClone(viewConfig);
					var view = Ext.create("BPMSoft.Container", config);
					view.bind(viewModel);
					view.render(renderTo);
					viewModel.onLoad();
				}

				return Ext.define("PrintableProcessModule", {
					render: function(renderTo) {
						render(renderTo, this);
					}
				});
			}

			return createConstructor;
		});
