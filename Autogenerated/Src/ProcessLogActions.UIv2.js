define("ProcessLogActions", ["RightUtilities", "ProcessModuleUtilities", "ConfigurationConstants", "ProcessModule",
		"ProcessLogActionsResources"],
	function(RightUtilities, ProcessModuleUtilities, ConfigurationConstants, ProcessModule, resources) {
		/**
		 * BPMSoft.configuration.mixins.ProcessLogActions
		 */
		Ext.define("BPMSoft.configuration.mixins.ProcessLogActions", {
			alternateClassName: "BPMSoft.ProcessLogActions",
			statics: {

				/**
				 * Shows error description in modal page if description is not empty.
				 * @param sandbox {Object} Sandbox.
				 * @param errorDescription {String} Error description to show.
				 */
				tryShowErrorDescription: function(sandbox, errorDescription) {
					if (!errorDescription) {
						return;
					}
					sandbox.loadModule("ModalBoxSchemaModule", {
						id: sandbox.id + "_ProcessErrorDataModalBox",
						instanceConfig: {
							moduleInfo: {
								schemaName: "SimpleSourceCodeEditPage",
								content: errorDescription
							},
							initialSize: {width: "80%", height: 800}
						}
					});
				}
			},

			/**
			 * @private
			 */
			_canUserCancelProcess: false,

			// region Methods: Private

			/**
			 * @private
			 */
			_cancelExecutionByIds: function(items) {
				const maskId = BPMSoft.Mask.show();
				const responseCallback = this._cancelResponseCallback.bind(this, items, maskId);
				const processDataIds = items.join(";");
				ProcessModule.services.cancelExecution(this, {
					processDataIds: processDataIds
				}, responseCallback);
			},

			/**
			 * @private
			 */
			_cancelResponseCallback: function(items, maskId) {
				items.forEach(function(item) {
					if (BPMSoft.Features.getIsEnabled("UseBackgroundProcessMode")) {
						this._setCanceledProcessStatus(item);
					} else {
						this.reloadCanceledProcessGridData(item);
					}
				}, this);
				const hasCanceledItems = this.get("MultiSelect") && !Ext.isEmpty(items);
				this.set("HasCanceledItems", hasCanceledItems);
				BPMSoft.Mask.hide(maskId);
			},

			/**
			 * @private
			 */
			_cancelAllSelected: function() {
				const entitySchema = this.getGridEntitySchema();
				const esq = new BPMSoft.EntitySchemaQuery(entitySchema.name);
				esq.addColumn(entitySchema.primaryColumnName);
				this.initQueryFilters(esq);
				const unselectedItems = this.getUnselectedItems();
				if (unselectedItems.length) {
					const unselectedFilter = BPMSoft.createColumnInFilterWithParameters("Id", unselectedItems);
					unselectedFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
					esq.filters.add("UnselectedItems", unselectedFilter);
				}
				esq.filters.add("NotParent", BPMSoft.createColumnIsNullFilter("Parent"));
				const statusEnum = ConfigurationConstants.SysProcess.Status;
				const allowStatuses = [statusEnum.Running, statusEnum.Error];
				esq.filters.add("Status", BPMSoft.createColumnInFilterWithParameters("Status", allowStatuses,
					BPMSoft.DataValueType.GUID));
				esq.execute(function(response) {
					const items = response.collection.getItems().map(function(item) {
						return item.get("Id");
					}, this);
					this._cancelExecutionByIds(items);
				}, this);
			},

			/**
			 * @private
			 */
			_cancelSelected: function() {
				const selectedItems = this.getSelectedItems();
				const runningItems = this._getRunningItems(selectedItems);
				if (runningItems.length  === 0) {
					BPMSoft.showMessage(resources.localizableStrings.ProcessesCancelDeclineMessage);
					return;
				}
				const items = this._getRootItems(runningItems);
				if (items.length === 0) {
					const message = selectedItems.length === 1
						? resources.localizableStrings.SubProcessCancelDeclineMessage
						: resources.localizableStrings.SubProcessesCancelDeclineMessage;
					BPMSoft.showMessage(message);
				} else {
					this._cancelExecutionByIds(items);
				}
			},

			/**
			 * @private
			 */
			_getRunningItems: function(items) {
				const statusEnum = ConfigurationConstants.SysProcess.Status;
				const allowStatuses = [statusEnum.Running, statusEnum.Error];
				const gridData = this.getGridData();
				return _.filter(items, function(id) {
					const row = gridData.get(id);
					const status = row.get("Status");
					return row && BPMSoft.contains(allowStatuses, status && status.value);
				}, this);
			},

			/**
			 * @private
			 */
			_getRootItems: function(items) {
				const gridData = this.getGridData();
				return _.filter(items, function(id) {
					const row = gridData.get(id);
					const parent = row.get("Parent");
					return row && !parent;
				}, this);
			},

			/**
			 * @private
			 */
			_canCancelProcessExecution: function(item) {
				let canCancelProcessExecution = false;
				if (this._canUserCancelProcess) {
					const status = item.get("Status").value;
					const cancelExecutionStatuses = [
						ConfigurationConstants.SysProcess.Status.Running,
						ConfigurationConstants.SysProcess.Status.Error
					];
					canCancelProcessExecution = BPMSoft.contains(cancelExecutionStatuses, status);
				}
				return canCancelProcessExecution;
			},

			/**
			 * @private
			 */
			_getSubProcessGridData: function(id) {
				const gridData = this.getGridData();
				return gridData.filterByFn(function(item) {
					const parent = item.values.Parent;
					return parent && parent.value === id;
				}, this);
			},

			/**
			 * @private
			 */
			_canUpdateStatus: function(currentStatus) {
				const status = ConfigurationConstants.SysProcess.Status2;
				return !currentStatus || currentStatus.value === status.Error.value ||
					currentStatus.value === status.Running.value;
			},

			/**
			 * @private
			 */
			_setCanceledProcessStatus: function(recordId) {
				const gridData = this.getGridData();
				if (gridData.contains(recordId)) {
					const status = ConfigurationConstants.SysProcess.Status2.Cancelling;
					const row = gridData.get(recordId);
					const currentStatus = row.get("Status");
					if (this._canUpdateStatus(currentStatus)) {
						row.set("Status", status);
					}
				}
				const subProcessGridData = this._getSubProcessGridData(recordId);
				subProcessGridData.each(function(item) {
					this._setCanceledProcessStatus(item.values.Id);
				}, this);
			},

			/**
			 * @private
			 */
			_registerCancelExecutionMessages: function() {
				this.sandbox.registerMessages({
					"ExecutionCanceled": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				});
				this.sandbox.subscribe("ExecutionCanceled", this.reloadCanceledProcessGridData, this);
			},

			/**
			 * Initialize user can cancel process property.
			 * @private
			 */
			_initCanCancelProcess: function(callback, scope) {
				RightUtilities.checkCanExecuteOperation({operation: "CanCancelProcess"},
					function(result) {
						this._canUserCancelProcess = result;
						Ext.callback(callback, scope);
					}, this);
			},

			// endregion

			/**
			 * Returns can user cancel process.
			 */
			canUserCancelProcess: function() {
				return this._canUserCancelProcess;
			},

			/**
			 * CancelExecution confirmation handler.
			 */
			cancelExecutionConfirmation: function() {
				if (this.isAnySelected()) {
					const message = resources.localizableStrings.CancelExecutionConfirmation;
					this.showConfirmationDialog(message, this.cancelExecution, ["yes", "no"]);
				}
			},

			/**
			 * Reloads cancel process grid data.
			 * @param {String} recordId Record Id.
			 */
			reloadCanceledProcessGridData: function(recordId) {
				this.loadGridDataRecord(recordId, function() {
					const subProcessGridData = this._getSubProcessGridData(recordId);
					subProcessGridData.each(function(item) {
						this.reloadCanceledProcessGridData(item.values.Id);
					}, this);
					this.trigger("change:ActiveRow", recordId);
				}, this);
			},

			/**
			 * Shows process diagram.
			 * @param {String} primaryColumnValue Primary column value for record.
			 */
			showProcessDiagram: function(primaryColumnValue) {
				let recordId = primaryColumnValue;
				const activeRow = this.getActiveRow();
				if (!recordId && this.isSingleSelected()) {
					recordId = activeRow.get("Id");
				}
				const managerName = activeRow.get("SysSchema.ManagerName");
				if (managerName === "DcmSchemaManager") {
					ProcessModuleUtilities.showDcmDiagram(recordId);
				} else {
					ProcessModuleUtilities.showProcessDiagram(recordId);
				}
			},

			/**
			 * Cancel process execution.
			 */
			cancelExecution: function(result) {
				if (result === "yes") {
					if (this.get("SelectAllMode")) {
						this._cancelAllSelected();
					} else {
						this._cancelSelected();
					}
				}
			},

			/**
			 * Returns whether the menu is displayed to Cancel the execution.
			 * @return {Boolean}
			 */
			getShowCancelExecutionMenuVisible: function() {
				if (!this.canUserCancelProcess()) {
					return false;
				}
				if (this.get("SelectAllMode")) {
					return true;
				}
				const selectedItems = this.getSelectedItems();
				if (!selectedItems) {
					return false;
				}
				if (selectedItems.length > 1) {
					return true;
				}
				const gridData = this.getGridData();
				const id = selectedItems[0];
				const row = gridData.find(id);
				if (!row) {
					return false;
				}
				const statusEnum = ConfigurationConstants.SysProcess.Status;
				const status = row.get("Status").value;
				return status === statusEnum.Running || status === statusEnum.Error;
			},

			/**
			 * Initialize cancel execution methods.
			 * @param {BPMSoft.Collection} collection Rows.
			 */
			initCancelExecution: function(collection) {
				collection.each(function(item) {
					const canCancelProcessExecution = this._canCancelProcessExecution.bind(this, item);
					item.getCancelExecutionVisible = canCancelProcessExecution;
					item.canCancelProcessExecution = canCancelProcessExecution;
				}, this);
			},

			/**
			 * Initializes mixin properties and messages.
			 */
			init: function(callback, scope) {
				this._registerCancelExecutionMessages();
				this._initCanCancelProcess(callback, scope);
			}
		});
		return BPMSoft.ProcessLogUtilities;
	});
