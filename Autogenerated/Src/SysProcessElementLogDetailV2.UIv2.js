define("SysProcessElementLogDetailV2", ["ProcessModule", "ConfigurationConstants", "MaskHelper",
		"ProcessModuleUtilities", "SysProcessElementLogDetailV2Resources", "SimpleSourceCodeEditPage",
		"ProcessLogActions", "ProcessTraceDataViewMixin"],
function(ProcessModule, ConfigurationConstants, MaskHelper) {
	return {
		entitySchemaName: "VwSysProcessElementLog",
		attributes: {

			/**
			 * Indicates if "Run Element" button is visible
			 */
			"IsRunElementButtonVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Indicates if "Download error description" button is visible
			 */
			"IsErrorButtonsVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		messages: {

			/**
			 * Get parent process's status
			 */
			"GetProcessStatus": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetModuleInfo.
			 */
			"GetModuleInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: {
			processTraceDataViewMixin: "BPMSoft.ProcessTraceDataViewMixin"
		},
		methods: {

			// region Methods: private

			/**
			 * Saves data into the file on the client.
			 * @private
			 * @param {String} blobData Error description.
			 * @param {String} fileName File name.
			 */
			_saveBlob: function(blobData, fileName) {
				const blobObject = new Blob([blobData], {
					type: "text/plain;charset=UTF-8"
				});
				// BrowserSupport: IE saves the File or Blob to disk
				if (window.navigator.msSaveBlob) {
					window.navigator.msSaveBlob(blobObject, fileName);
					return;
				}
				const txtFile = document.createElement("a");
				txtFile.href = URL.createObjectURL(blobObject);
				txtFile.download = fileName;
				document.body.appendChild(txtFile);
				txtFile.click();
				URL.revokeObjectURL(txtFile.href);
				document.body.removeChild(txtFile);
			},

			/**
			 * @private
			 */
			_getIsFlowIteratorGateway: function(typeName) {
				return typeName === "BPMSoft.Core.Process.FlowIteratorGateway";
			},

			// endregion

			/**
			 * Indicates if active row has trace data
			 * @return {Boolean}
			 */
			getActiveRowHasTraceData: function() {
				const activeRow = this.getActiveRow();
				const activeRowHasTrace = Boolean(activeRow && activeRow.get("HasTraceData"));
				return activeRowHasTrace;
			},

			// region Methods: protected

			/**
			 * @inheritdoc BaseGridDetailV2#addRecordOperationsMenuItems
			 * @overridden
			 */
			addRecordOperationsMenuItems: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @protected
			 */
			initDetailOptions: function() {
				this.set("IsDetailCollapsed", true);
				this.callParent();
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#initQueryColumns
			 * @overridden
			 */
			initQueryColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("SysProcess.SysSchema.UId");
				esq.addColumn("SchemaElementUId");
			},

			/**
			 * @protected
			 */
			getGridDataColumns: function() {
				const gridDataColumns = this.callParent(arguments);
				const columnsConfig = ["ErrorDescription", "SysProcess", "Status", "HasTraceData", "Type"];
				BPMSoft.each(columnsConfig, function(columnName) {
					if (!gridDataColumns[columnName]) {
						gridDataColumns[columnName] = {
							path: columnName
						};
					}
				}, this);
				return gridDataColumns;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#initQueryFilters
			 * @overridden
			 */
			initQueryFilters: function(esq) {
				this.callParent(arguments);
				const filterGroup = BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
				filterGroup.Name = "NotExistsMultiInstance";
				const notExistsSysPrcElMILogFilter = BPMSoft.createNotExistsFilter("[SysPrcElMILog:Id].Id");
				filterGroup.addItem(notExistsSysPrcElMILogFilter);
				const notExistsSysPrcElMIHistoryLogFilter =
					BPMSoft.createNotExistsFilter("[SysPrcElMIHistoryLog:Id].Id");
				filterGroup.addItem(notExistsSysPrcElMIHistoryLogFilter);
				esq.filters.addItem(filterGroup);
			},

			/**
			 * @protected
			 */
			runElement: function(recordId) {
				if (!recordId && this.isSingleSelected()) {
					const activeRow = this.getActiveRow();
					recordId = activeRow.get(this.primaryColumnName);
				}
				const data = {
					procElUId: recordId
				};
				MaskHelper.ShowBodyMask();
				const responseCallback = function(success, pageOpened) {
					MaskHelper.HideBodyMask();
					if (!pageOpened) {
						this.fireDetailChanged({});
					}
				};
				if (BPMSoft.Features.getIsEnabled("UseObsoleteExecuteProcessElement")) {
					ProcessModule.services.callConfigurationServiceMethod(
						"ProcessEngineService/ExecuteProcessElement", data, function() {
							responseCallback(true, false);
						});
					return;
				}
				BPMSoft.ProcessModuleUtilities.executeProcessElementByUId(recordId, responseCallback, this);
			},

			/**
			 * @inheritdoc GridUtilitiesV2#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function() {
				this.callParent(arguments);
				this.set("IsRunElementButtonVisible", this.runElementButtonVisible());
				this.set("IsErrorButtonsVisible", this.getErrorButtonsVisible());
			},

			/*
			 * Row selection handler.
			 * @protected
			 * @param {String} rowId Row identifier.
			 */
			selectRow: function(rowId) {
				this.set("IsRunElementButtonVisible", this.runElementButtonVisible(rowId));
				this.set("IsErrorButtonsVisible", this.getErrorButtonsVisible(rowId));
			},

			/**
			 * Returns if "Run Element" button is visible
			 * @return {Boolean}
			 */
			runElementButtonVisible: function(rowId) {
				const gridData = this.getGridData();
				if (this.get("IsDetailCollapsed") || gridData.getCount() === 0) {
					return false;
				}
				const activeRow = rowId ? gridData.get(rowId) : this.getActiveRow();
				if (!activeRow) {
					return false;
				}
				const typeName = activeRow.get("Type");
				if (this._getIsFlowIteratorGateway(typeName)) {
					return false;
				}
				const status = ConfigurationConstants.SysProcess.Status;
				const elementStatus = activeRow.get("Status");
				if (elementStatus.value === status.Running) {
					return true;
				} else if (elementStatus.value === status.Error) {
					const processStatus = this.sandbox.publish("GetProcessStatus");
					return processStatus.value !== status.Canceled;
				}
			},

			/**
			 * Returns if "Download error description" button is visible
			 * @return {Boolean}
			 */
			getErrorButtonsVisible: function(rowId) {
				const gridData = this.getGridData();
				if (this.get("IsDetailCollapsed") || gridData.getCount() === 0) {
					return false;
				}
				const activeRow = rowId ? gridData.get(rowId) : this.getActiveRow();
				if (activeRow) {
					const status = activeRow.get("Status");
					return status.value === ConfigurationConstants.SysProcess.Status.Error;
				}
				return false;
			},

			/**
			 * Generates "download Error" menu item.
			 * @return {BPMSoft.BaseViewModel}
			 */
			getDownloadErrorMenuItem: function() {
				return this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.DownloadErrorCaption"},
					Click: {"bindTo": "downloadError"},
					Visible: {bindTo: "IsErrorButtonsVisible"}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#initToolsButtonMenu
			 * @overridden
			 */
			initToolsButtonMenu: function() {
				this.callParent(arguments);
				const toolsButtonMenu = this.get("ToolsButtonMenu");
				const downloadError = this.getDownloadErrorMenuItem();
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Type: "BPMSoft.MenuSeparator",
					Caption: ""
				}));
				toolsButtonMenu.addItem(downloadError);
			},

			/**
			 * Takes description of the error, which is saved into the file on the client.
			 * @protected
			 */
			downloadError: function() {
				const activeRow = this.getActiveRow();
				const processName = activeRow.get("SysProcess").displayValue;
				const fileName = processName + "_Error";
				const errorDescription = activeRow.get("ErrorDescription");
				this._saveBlob(errorDescription, fileName);
			},

			/**
			 * Takes description of the error, which is saved into the file on the client.
			 * @protected
			 */
			takeError: function() {
				this.downloadError();
			},

			// endregion

			// region Methods: public

			/**
			 * Opens trace data window
			 * @public
			 */
			openTrace: function() {
				const activeRow = this.getActiveRow();
				const sysSchemaUId = activeRow.get("SysProcess.SysSchema.UId");
				const processElementLogId = activeRow.get("Id");
				const schemaElementUId = activeRow.get("SchemaElementUId");
				const elementTypeName = activeRow.get("Type");
				this.openTracePage({
					sysSchemaUId: sysSchemaUId,
					elementLogId: processElementLogId,
					schemaElementUId: schemaElementUId,
					elementTypeName: elementTypeName
				});
			},

			/**
			 * Shows description of the error.
			 * @public
			 */
			showError: function() {
				const activeRow = this.getActiveRow();
				const errorDescription = activeRow.get("ErrorDescription");
				BPMSoft.ProcessLogActions.tryShowErrorDescription(this.sandbox, errorDescription);
			},

			/**
			 * @inheritdoc GridUtilitiesV2#addColumnLink
			 * @overridden
			 */
			addColumnLink: function(item, column) {
				const itemType = item.get("Type");
				if (column.columnPath !== "Caption") {
					this.callParent(arguments);
					return;
				}
				const recordId = item.get("Id");
				const displayValue = item.get("Caption");
				const link = this.createLink("VwSysProcessLog", "Caption", displayValue, recordId);
				if (this._getIsFlowIteratorGateway(itemType) ||
						itemType === "BPMSoft.Core.Process.ProcessSchemaSubProcess") {
					item.onCaptionLinkClick = function() {
						return link;
					};
				}
			},

			/**
			 * @inheritdoc GridUtilitiesV2#linkClicked
			 * @overridden
			 */
			linkClicked: function(rowId, columnName) {
				let handled = true;
				if (columnName === "Caption") {
					const data = this.getGridData();
					const row = data.get(rowId);
					const processCaption = row.get("Caption");
					const type = row.get("Type");
					if (type === "BPMSoft.Core.Process.FlowIteratorGateway") {
						this.sandbox.publish("PushHistoryState", {
							hash: "SectionModuleV2/SysProcessMultiInstanceLogSection/view/" + rowId,
							stateObj: {
								"processCaption": processCaption
							}
						});
						handled = false;
					}
				}
				return handled;
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "CaptionListedGridColumn",
								"bindTo": "Caption",
								"position": {
									"column": 1,
									"colSpan": 10
								}
							},
							{
								"name": "StatusListedGridColumn",
								"bindTo": "Status",
								"position": {
									"column": 11,
									"colSpan": 4
								}
							},
							{
								"name": "StartDateListedGridColumn",
								"bindTo": "StartDate",
								"position": {
									"column": 15,
									"colSpan": 5
								}
							},
							{
								"name": "CompleteDateListedGridColumn",
								"bindTo": "CompleteDate",
								"position": {
									"column": 20,
									"colSpan": 5
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
								"name": "CaptionTiledGridColumn",
								"bindTo": "Caption",
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 10
								}
							},
							{
								"name": "StatusTiledGridColumn",
								"bindTo": "Status",
								"position": {
									"row": 1,
									"column": 11,
									"colSpan": 4
								}
							},
							{
								"name": "StartDateTiledGridColumn",
								"bindTo": "StartDate",
								"position": {
									"row": 1,
									"column": 15,
									"colSpan": 5
								}
							},
							{
								"name": "CompleteDateTiledGridColumn",
								"bindTo": "CompleteDate",
								"position": {
									"row": 1,
									"column": 20,
									"colSpan": 5
								}
							}
						]
					},
					"selectRow": {"bindTo": "selectRow"}
				}
			},
			{
				"operation": "insert",
				"name": "RunElementButton",
				"parentName": "Detail",
				"index": 2,
				"propertyName": "tools",
				"values":
				{
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"textClass": ["actions-button-margin-right"],
					},
					"caption": {"bindTo": "Resources.Strings.ExecuteElementCaption"},
					"click": {
						"bindTo": "runElement"
					},
					"visible": {
						"bindTo": "IsRunElementButtonVisible"
					}
				}
			}, {
				"operation": "insert",
				"name": "OpenTrace",
				"parentName": "Detail",
				"index": 3,
				"propertyName": "tools",
				"values":
				{
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": { "bindTo": "Resources.Strings.OpenTraceButtonCaption" },
					"click": { "bindTo": "openTrace" },
					"visible": { "bindTo": "getActiveRowHasTraceData" }
				}
			}, {
				"operation": "insert",
				"name": "ShowErrorButton",
				"parentName": "Detail",
				"index": 3,
				"propertyName": "tools",
				"values":
				{
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"textClass": ["actions-button-margin-right"],
					},
					"caption": {"bindTo": "Resources.Strings.TakeErrorCaption"},
					"click": {
						"bindTo": "showError"
					},
					"visible": {
						"bindTo": "IsErrorButtonsVisible"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
