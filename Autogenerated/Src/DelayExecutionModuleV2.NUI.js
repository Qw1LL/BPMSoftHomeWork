﻿define("DelayExecutionModuleV2", ["Activity", "DelayExecutionModuleV2Resources", "LookupUtilities",
	"NetworkUtilities", "ProcessModuleUtilities", "BaseModule"],
	function(Activity, resources, LookupUtilities, NetworkUtilities, ProcessModuleUtilities) {

		Ext.define("BPMSoft.configuration.DelayExecutionModule", {
			alternateClassName: "BPMSoft.DelayExecutionModule",
			extend: "BPMSoft.BaseModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			getViewModelClass: function() {
				return this.Ext.define("BPMSoft.configuration.DelayExecutionModel", {
					extend: "BPMSoft.BaseSchemaViewModel",
					entitySchema: Activity,
					Ext: null,
					BPMSoft: null,
					sandbox: null,
					columns: {
						Id: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							name: "Id",
							columnPath: "Id"
						},
						StartDate: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "StartDate",
							caption: Activity.columns.StartDate.caption,
							dataValueType: Activity.columns.StartDate.dataValueType,
							isRequired: Activity.columns.StartDate.isRequired
						},
						Title: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "Title",
							caption: Activity.columns.Title.caption,
							dataValueType: Activity.columns.Title.dataValueType,
							isRequired: Activity.columns.Title.isRequired
						},
						Owner: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "Owner",
							caption: Activity.columns.Owner.caption,
							dataValueType: Activity.columns.Owner.dataValueType,
							isRequired: Activity.columns.Owner.isRequired,
							captionVisible: true
						},
						DueDate: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "DueDate"
						},
						RemindToOwner: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "RemindToOwner",
							dataValueType: Activity.columns.RemindToOwner.dataValueType
						},
						RemindToOwnerDate: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "RemindToOwnerDate",
							dataValueType: Activity.columns.RemindToOwnerDate.dataValueType
						},
						ShowInScheduler: {
							type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
							columnPath: "ShowInScheduler",
							caption: Activity.columns.ShowInScheduler.caption,
							dataValueType: Activity.columns.ShowInScheduler.dataValueType,
							isRequired: Activity.columns.ShowInScheduler.isRequired,
							captionVisible: true
						},
						Duration: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							dataValueType: BPMSoft.DataValueType.ENUM,
							isRequired: true
						},
						RemindBefore: {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							dataValueType: BPMSoft.DataValueType.ENUM,
							isRequired: true
						}
					},

					/**
					 *
					 */
					init: function() {
						this.initDefaultValues();
						this.initProcessExecData();
					},

					initProcessExecData: function() {
						var processExecData = this.sandbox.publish("GetProcessExecData");
						if (this.Ext.isEmpty(processExecData)) {
							throw new this.BPMSoft.ArgumentNullOrEmptyException();
						}
						this.set("ProcessExecData", processExecData);
						this.loadEntity(processExecData.activityRecordId);
					},

					/**
					 *
					 */
					initDefaultValues: function() {
						var strings = resources.localizableStrings;
						var durationInterval = {
							interval5Minutes: {value: "5", displayValue: strings.Minutes5},
							interval10Minutes: {value: "10", displayValue: strings.Minutes10},
							interval30Minutes: {value: "30", displayValue: strings.Minutes30},
							interval1Hour: {value: "60", displayValue: strings.Hours1},
							interval2Hours: {value: "120", displayValue: strings.Hours2},
							interval1Day: {value: "1440", displayValue: strings.Days1}
						};
						var remindInterval = {
							interval5Minutes: {value: "5", displayValue: strings.Before + strings.Minutes5},
							interval10Minutes: {value: "10", displayValue: strings.Before + strings.Minutes10},
							interval30Minutes: {value: "30", displayValue: strings.Before + strings.Minutes30},
							interval1Hour: {value: "60", displayValue: strings.Before + strings.Hours1},
							interval2Hours: {value: "120", displayValue: strings.Before + strings.Hours2},
							interval1Day: {value: "1440", displayValue: strings.Before + strings.Days1}
						};
						this.set("DurationInterval", durationInterval);
						this.set("RemindInterval", remindInterval);
						this.set("Duration", durationInterval.interval1Hour);
						this.set("RemindBefore", remindInterval.interval10Minutes);
						this.set("DurationList", Ext.create("BPMSoft.Collection"));
						this.set("RemindBeforeList", Ext.create("BPMSoft.Collection"));
					},

					/**
					 * ############ ####### ## ###### # ######## ##########.
					 * @return {Boolean} #######, ######## ### ### DOM ########## ####### ## ######.
					 */
					onLinkClick: function() {
						return true;
					},

					/**
					 * ######## ######## ###########.
					 * @protected
					 * @param {String} columnName ######## #######.
					 */
					getLinkUrl: function(columnName) {
						var href = {};
						var column = Activity.columns[columnName];
						if (column) {
							var entitySchema = column.referenceSchemaName;
							var primaryColumn = this.get(columnName);
							if (primaryColumn) {
								href.url = "ViewModule.aspx#" + NetworkUtilities.getEntityUrl(entitySchema, primaryColumn.value);
								href.caption = primaryColumn.displayValue;
							}
						}
						return href;
					},

					/**
					 *
					 */
					loadVocabulary: function(args, tag) {
						var config = {
							entitySchemaName: this.entitySchema.columns[tag].referenceSchemaName,
							multiSelect: false,
							columnName: tag,
							columnValue: this.get(tag),
							searchValue: args.searchValue
						};
						var handler = function(args) {
							if (args.selectedRows.getCount()) {
								this.set(args.columnName, args.selectedRows.getByIndex(0));
							}
						};
						LookupUtilities.Open(this.sandbox, config, handler, this, null, false, false);
					},

					/**
					 *
					 */
					onCancelButtonClick: function() {
						this.sandbox.publish("CloseDelayExecutionModule", null, [this.sandbox.id]);
					},

					/**
					 *
					 */
					getDurationListData: function(filter, list) {
						list.clear();
						list.loadAll(this.get("DurationInterval"));
					},

					/**
					 *
					 */
					getRemindListData: function(filter, list) {
						list.clear();
						list.loadAll(this.get("RemindInterval"));
					},

					/**
					 *
					 */
					onOKButtonClick: function() {
						var startDate = this.get("StartDate");
						var duration = this.get("Duration");
						var remindBefore = this.get("RemindBefore");
						if (!startDate || !duration || !remindBefore) {
							return;
						}
						var dueDate = this.Ext.Date.add(startDate, this.Ext.Date.MINUTE, duration.value);
						this.set("DueDate", dueDate);
						this.set("RemindToOwner", true);
						var remindDate = Ext.Date.subtract(startDate, this.Ext.Date.MINUTE, remindBefore.value);
						this.set("RemindToOwnerDate", remindDate);
						this.saveEntity(function() {
							var currentState = this.sandbox.publish("GetHistoryState");
							var newState = this.BPMSoft.deepClone(currentState.state || {});
							var executionData = newState.executionData;
							delete executionData[executionData.currentProcElUId];
							delete executionData.currentProcElUId;
							this.sandbox.publish("ReplaceHistoryState", {
								stateObj: newState,
								pageTitle: null,
								hash: currentState.hash.historyState,
								silent: true
							});
							if (ProcessModuleUtilities.getProcExecDataCollectionCount(executionData) > 0) {
								this.sandbox.publish("ChangeNextProcExecDataHistoryState", executionData);
							} else {
								this.sandbox.publish("BackHistoryState");
							}
						}, this);
					}
				});
			},

			/**
			 *
			 */
			getViewModel: function() {
				return Ext.create(this.viewModelClass, {
					Ext: this.Ext,
					sandbox: this.sandbox,
					BPMSoft: this.BPMSoft
				});
			},

			/**
			 *
			 */
			config: {
				schema: {
					viewConfig: [{
						name: "name",
						itemType: BPMSoft.ViewItemType.GRID_LAYOUT,
						items: [
							/*{
								name: "Header",
								caption: resources.localizableStrings.HeaderCaption,
								itemType: BPMSoft.ViewItemType.LABEL,
								classes: {labelClass: ["information"]},
								layout: {
									colSpan: 24,
									column: 0,
									row: 0
								}
							},*/
							{
								"name": "StartDate",
								"layout": {
									"column": 0,
									"row": 0,
									"colSpan": 11
								}
							},
							{
								"name": "Owner",
								"layout": {
									"column": 13,
									"row": 0,
									"colSpan": 11
								}
							},
							{
								"name": "Title",
								"contentType": this.BPMSoft.ContentType.LONG_TEXT,
								"layout": {
									"column": 13,
									"row": 1,
									"rowSpan": 2,
									"colSpan": 11
								}
							},
							{
								"name": "Duration",
								"caption": resources.localizableStrings.DelayDurationCaption,
								"controlConfig": {"prepareList": {bindTo: "getDurationListData"}},
								"layout": {
									"column": 0,
									"row": 1,
									"colSpan": 11
								}
							},
							{
								"name": "RemindBefore",
								"caption": resources.localizableStrings.DelayRemindBeforeCaption,
								"controlConfig": {"prepareList": {bindTo: "getRemindListData"}},
								"layout": {
									"column": 0,
									"row": 2,
									"colSpan": 11
								}
							},
							{
								"name": "ShowInScheduler",
								"layout": {
									"column": 0,
									"row": 3,
									"colSpan": 11
								}
							},
							{
								name: "ButtonsContainer",
								itemType: BPMSoft.ViewItemType.CONTAINER,
								items: [{
									name: "OKButton",
									click: {bindTo: "onOKButtonClick"},
									caption: resources.localizableStrings.DelayButtonCaption,
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									itemType: BPMSoft.ViewItemType.BUTTON,
									classes: {textClass: ["button-margin"]}
								}, {
									name: "CancelButton",
									click: {bindTo: "onCancelButtonClick"},
									caption: resources.localizableStrings.CancelButtonCaption,
									itemType: BPMSoft.ViewItemType.BUTTON,
									classes: {textClass: ["button-margin"]}
								}],
								layout: {
									colSpan: 24,
									column: 0,
									row: 5
								}
							}
						]
					}]
				}
			},

			/**
			 *
			 */
			init: function() {
				if (!this.viewModel) {
					this.viewModelClass = this.getViewModelClass();
					this.config.viewModelClass = this.viewModelClass;
					this.viewModel = this.getViewModel(this.viewModelClass);
					this.viewModel.init();
				}
			},

			/**
			 *
			 */
			render: function(renderTo) {
				var viewGenerator = this.Ext.create("BPMSoft.ViewGenerator");
				viewGenerator.generate(this.config, function(viewConfig) {
					var containerName = "DelayExecutionModuleInnerContainer";
					var view = this.Ext.create("BPMSoft.Container", {
						id: containerName,
						selectors: {wrapEl: "#" +  containerName},
						items: this.BPMSoft.deepClone(viewConfig)
					});
					view.bind(this.viewModel);
					view.render(renderTo);
				}, this);
			}
		});

		return BPMSoft.DelayExecutionModule;

	}
);
