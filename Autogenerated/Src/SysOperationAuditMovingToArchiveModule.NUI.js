define("SysOperationAuditMovingToArchiveModule", ["ext-base", "BPMSoft", "sandbox",
		"SysOperationAuditMovingToArchiveModuleResources", "LookupUtilities"],
	function(Ext, BPMSoft, sandbox, resources, LookupUtilities) {

		var view, viewModel;
		var container;

		function moveToArchive(dateFromValue, dateToValue, operationTypeList, returnBack) {
			var provider = BPMSoft.AjaxProvider;
			var data = {
				startDate: dateFromValue,
				endDate: dateToValue,
				operationTypes: operationTypeList
			};
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/AuditService/MoveToArchive";
			provider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function(options, success, response) {
					if (success) {
						var result = BPMSoft.decode(response.responseText);
						var moveToArchiveResult = result.MoveToArchiveResult;
						var message;
						if (moveToArchiveResult === 0) {
							message = resources.localizableStrings.NoRecordToArchive;
						} else {
							message = Ext.String.format(resources.localizableStrings.ArchiveRecordCountCaption,
								moveToArchiveResult);
						}
						this.showInformationDialog(message, function() {
							if (returnBack) {
								sandbox.publish("BackHistoryState");
							}
						});
					}
				},
				scope: this
			});
		}

		function initModel() {
			var startDate = BPMSoft.startOfWeek(Ext.Date.add(new Date(), "d", 0));
			var dueDate = BPMSoft.endOfWeek(startDate);
			viewModel.set("dateFromValue", startDate);
			viewModel.set("dateToValue", dueDate);
			viewModel.set("operationTypeList", []);
		}

		function getView() {
			var container = Ext.create("BPMSoft.Container", {
				id: "generalContainer",
				markerValue: "ArchiveParameters",
				selectors: {
					wrapEl: "#generalContainer"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "SubHeaderCaptionContainer",
						selectors: {
							wrapEl: "#SubHeaderCaptionContainer"
						},
						classes: {
							wrapClassName: ["sub-header-caption-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "SubHeaderLabel",
								caption: resources.localizableStrings.SubHeaderCaption,
								classes: {
									labelClass: ["sub-header-caption"]
								}
							},
						],
					},
					{
						className: "BPMSoft.Container",
						id: "buttonsContainer",
						selectors: {
							wrapEl: "#buttonsContainer"
						},
						classes: {
							wrapClassName: ["buttons-container"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "btnOkContainer",
								selectors: {
									wrapEl: "#btnOkContainer"
								},
								classes: {
									wrapClassName: ["btnOk-container"]
								},
								items: [
									{
										className: "BPMSoft.Button",
										id: "btnOk",
										markerValue: "OkButton",
										caption: resources.localizableStrings.BtnOKCaption,
										style: BPMSoft.controls.ButtonEnums.style.ORANGE,
										click: {
											bindTo: "onOkBtnClick"
										}
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "btnCancelContainer",
								selectors: {
									wrapEl: "#btnCancelContainer"
								},
								classes: {
									wrapClassName: ["btnCancel-container"]
								},
								items: [
									{
										className: "BPMSoft.Button",
										id: "btnCancel",
										markerValue: "CancelButton",
										caption: resources.localizableStrings.BtnCancelCaption,
										style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
										click: {
											bindTo: "onCancelBtnClick"
										}
									}
								]
							}

						]
					},
					{
						className: "BPMSoft.Container",
						id: "inputArchiveContainer",
						selectors: {
							wrapEl: "#inputArchiveContainer"
						},
						classes: {
							wrapClassName: ["input-archive-container"]
						},
						items: [
							
								{
									className: "BPMSoft.Container",
									id: "periodContainer",
									selectors: {
										wrapEl: "#periodContainer"
									},
									classes: {
										wrapClassName: ["period-container"]
									},
									items: [
										{
											className: "BPMSoft.Container",
											id: "caption-dateFrom-label-container",
											selectors: {
												wrapEl: "#caption-dateFrom-label-container"
											},
											classes: {
												wrapClassName: ["caption-label-container"]
											},
											items: [
												{
													className: "BPMSoft.Label",
													id: "dateFromLabel",
													caption: resources.localizableStrings.LblDateFromCaption,
													classes: {
														labelClass: ["required-caption"]
													}
												},
												{
													className: "BPMSoft.DateEdit",
													id: "dateFrom",
													markerValue: "dateFromField",
													value: {
														bindTo: "dateFromValue"
													},
												},
											]
										},
		
										{
											className: "BPMSoft.Container",
											id: "caption-dateTo-label-container",
											selectors: {
												wrapEl: "#caption-dateTo-label-container"
											},
											classes: {
												wrapClassName: ["caption-dateTo-label-container"]
											},
											items: [
												{
													className: "BPMSoft.Label",
													id: "dateToLabel",
													caption: resources.localizableStrings.LblDateToCaption,
													classes: {
														labelClass: ["required-caption"]
													}
												},
												{
													className: "BPMSoft.DateEdit",
													id: "dateTo",
													markerValue: "dateToField",
													value: {
														bindTo: "dateToValue"
													},
												}
											]
										},

									]
								},

								{
									className: "BPMSoft.Container",
									id: "operationTypeContainer",
									selectors: {
										wrapEl: "#operationTypeContainer"
									},
									classes: {
										wrapClassName: ["operation-type-container"]
									},
									items: [
										{
											className: "BPMSoft.Label",
											id: "operationTypeLabel",
											caption: resources.localizableStrings.LblOperationTypeCaption,
										},
										{
											className: "BPMSoft.LookupEdit",
											id: "operationType",
											markerValue: "OperationTypeLookup",
											value: {
												bindTo: "DisplayOperationType"
											},
											list: {
												bindTo: "operationTypeList"
											},
											loadVocabulary: {
												bindTo: "onPrepareOperationTypeList"
											},
											/*change: {
												bindTo: "getLookupQuery"
											},*/
										}
									]
								}
						]
					},
					
				
				]
			});
			return container;
		}

		var columnsForLookup = [];

		function getViewModel() {
			var viewModel = Ext.create("BPMSoft.BaseViewModel", {
				columns: {
					dateFromValue: {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "dateFromValue",
						dataValueType: BPMSoft.DataValueType.DATE_TIME,
						isRequired: true
					},
					dateToValue: {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "dateToValue",
						dataValueType: BPMSoft.DataValueType.DATE_TIME,
						isRequired: true
					}
				},
				validationConfig: {
					dateFromValue: [
						function() {
							var result = {
								isValid: true,
								invalidMessage: ""
							};
							if (this.get("dateFromValue") >= this.get("dateToValue")) {
								result.isValid = false;
								result.invalidMessage = resources.localizableStrings.StartDateValidationMessage;
							} else if (!result.isValid) {
								result.isValid = true;
								result.invalidMessage = "";
							}
							return result;
						}
					],
					dateToValue: [
						function() {
							var result = {
								isValid: true,
								invalidMessage: ""
							};
							if (this.get("dateToValue") <= this.get("dateFromValue")) {
								result.isValid = false;
								result.invalidMessage = resources.localizableStrings.DueDateValidationMessage;
							} else if (!result.isValid) {
								result.isValid = true;
								result.invalidMessage = "";
							}
							return result;
						}
					]
				},
				values: {
					operationTypeList: new BPMSoft.Collection(),
					dateFromValue: BPMSoft.SystemValueType.CURRENT_DATE,
					dateToValue: BPMSoft.SystemValueType.CURRENT_DATE
				},
				methods: {
					onOkBtnClick: function() {
						if (this.validate()) {
							var dateFromValue = viewModel.get("dateFromValue");
							var dateToValue = viewModel.get("dateToValue");

							var dateFromValueLocaleString = dateFromValue.toLocaleString();
							var dateToValueLocaleString = dateToValue.toLocaleString();
							
							var operationTypeList = [];
							BPMSoft.each(viewModel.get("operationTypeCollectionItems"), function(item) {
								operationTypeList.push(item.Code);
							});
							moveToArchive.call(this, dateFromValueLocaleString, dateToValueLocaleString, operationTypeList, true);
						}
					},
					onCancelBtnClick: function() {
						sandbox.publish("BackHistoryState");
					},
					getLookupQuery: function(filterValue, columnName) {
						var esq = this.callParent(arguments);
						var filters = this.getLookupFilters.call(this, columnName);
						BPMSoft.each(columnsForLookup, function(itemName) {
							esq.addColumn(itemName);
						}, this);
						esq.filters.addItem(filters);
						return esq;
					},
					getLookupFilters: function(columnName) {
						var filters = Ext.create("BPMSoft.FilterGroup");
						columnsForLookup = [columnName, "Code"];
						return filters;
					},
					onPrepareOperationTypeList: function() {
						this.scrollTo = document.body.scrollTop || document.documentElement.scrollTop;
						var handler = function(args) {
							var t = {
								displayValue: ""
							};
							this.values.operationTypeList = [];
							BPMSoft.each(args.selectedRows.collection.items, function(item) {
								this.values.operationTypeList.push(item.value);
								t.displayValue += item.displayValue + "; ";
							}, this);
							this.set("DisplayOperationType", t);
							this.set("operationTypeList", this.values.operationTypeList);
							this.set("operationTypeCollectionItems", args.selectedRows.collection.items);
						};
						if (!this.get("DisplayOperationType")) {
							this.values.operationTypeList = [];
						}
						var config = {
							entitySchemaName: "SysOperationType",
							selectedRows: this.values.operationTypeList,
							multiSelect: true
						};
						LookupUtilities.Open(sandbox, config, handler, this, container, true);
					}
				}
			});
			return viewModel;
		}

		var init = function() {
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			var newState = BPMSoft.deepClone(currentState);
			newState.moduleId = sandbox.id;
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
		};

		function render(renderTo) {
			var headerCaption = resources.localizableStrings.WindowCaption;
			let markerValue = "ArchiveSettingsCaption";
			sandbox.publish("ChangeHeaderCaption", {
				caption: headerCaption,
				dataViews: new BPMSoft.Collection()
			});
			sandbox.subscribe("NeedHeaderCaption", function() {
				sandbox.publish("InitDataViews", { caption: headerCaption, markerValue: markerValue});
			}, this);

			view = getView();
			if (!viewModel) {
				viewModel = getViewModel();
				initModel();
			}
			container = renderTo;
			view.bind(viewModel);
			view.render(renderTo);
		}

		return {
			init: init,
			render: render
		};
	});
