define("BaseAudienceSection", ["BaseAudienceSectionResources", "ConfigurationEnums",
		"NetworkUtilities"],
	function(resources, ConfigurationEnums) {
		return {
			entitySchemaName: null,
			mixins: {
				NetworkUtilities: "BPMSoft.NetworkUtilities"
			},
			properties: {
				/**
				 * Suffix to indicate section type for module.
				 * @type {String}
				 */
				sectionModuleSuffix: "SectionV2",
				/**
				 * Suffix to indicate grid view name.
				 * @type {String}
				 */
				gridViewModuleSuffix: "GridSettingsGridDataView",
				/**
				 * Limit for selected records count to process.
				 * @type {Nubmer}
				 */
				selectedRowsLimit: 10000,
				/**
				 * Limit for records count to quick import.
				 * Import for records less then limit will be processed with quick queue.
				 * @type {Number}
				 */
				rowsLimitForQuickQueue: 100,
				/**
				 * Last estimated records count by filter request unique identifier.
				 * @type {String}
				 */
				lastEstimatedCountRequestId: null
			},
			attributes: {
				/**
				 * Unique identifier of current bulk email for audience process.
				 * @type {String}
				 */
				"RecordId": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Name of current bulk email.
				 * @type {String}
				 */
				"RecordName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Caption text for process audience button.
				 * @type {String}
				 */
				"ProcessAudienceButtonCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Flag to indicate process by filter action availability.
				 * @type {Boolean}
				 */
				"CanProcessByFilter": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Estimated records count to process.
				 * @type {Number}
				 */
				"EstimatedRecordsCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 0
				}
			},
			methods: {
				/**
				 * @private
				 */
				_setRecordFields: function() {
					var historyState = this.sandbox.publish("GetHistoryState");
					if (historyState && historyState.state) {
						this.set("RecordId", historyState.state.recordId);
						this.set("RecordName", historyState.state.recordName);
					}
				},

				/**
				 * @private
				 * @param {Array} filtersToSkip List of filter keys to skip.
				 */
				_isAnyFilterSelected: function(filtersToSkip) {
					var filters = this.getFilters();
					var result = filters
						&& !filters.isEmpty()
						&& filters
							.filterByFn(function(filter, key) {
								if (filtersToSkip && filtersToSkip.indexOf(key) > -1) {
									return false;
								}
								return typeof filter.isEmpty === 'function' && !filter.isEmpty();
							})
							.getCount() > 0;
					return Boolean(result);
				},

				/**
				 * @private
				 */
				_isFolderFilterOnly: function() {
					return !this._isAnyFilterSelected(["FolderFilters"]) && this.$CurrentFolder;
				},

				/**
				 * @private
				 */
				_showSelectedRecordsLimitReachedMessage :function() {
					var messageTpl = this.getSelectedRecordsLimitReachedMessage();
					var limitReachedMessage = Ext.String.format(messageTpl, this.selectedRowsLimit);
					this.showInformationDialog(limitReachedMessage);
				},

				/**
				 * @protected
				 */
				isAnyRowSelected: function() {
					return BPMSoft.isNotEmpty(this.$SelectedRows);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#removeCardHistoryState
				 * @override
				 */
				removeCardHistoryState: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getDefaultDataViews
				 * @override
				 */
				getDefaultDataViews: function() {
					var gridDataView = {
						name: this.get("GridDataViewName"),
						caption: this.getDefaultGridDataViewCaption(),
						icon: this.getDefaultGridDataViewIcon()
					};
					return {
						"GridDataView": gridDataView
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#linkClicked
				 * @override
				 */
				linkClicked: function(recordId, columnName) {
					var result = this.callParent(arguments);
					this.set("IsSectionVisible", false);
					this.saveSectionVisibleStateToProfile(false);
					this.hideSection();
					return result;
				},

				/**
				* @inheritdoc BPMSoft.BaseDataView#getQuickFilterModuleId
				* @override
				*/
				getQuickFilterModuleId: function() {
					return this.entitySchemaName + this.sandbox.id + "_QuickFilterModuleV2";
				},

				/**
				* @inheritdoc BPMSoft.BaseDataView#getQuickFilterModuleId
				* @override
				*/
				getHistoryStateInfo: function() {
					var info = this.callParent(arguments);
					info.workAreaMode = ConfigurationEnums.WorkAreaMode.SECTION;
					return info;
				},

				/**
				 * Inits specific section state data for current section.
				 * @protected
				 */
				initSection: function() {
					this.set("MultiSelect", true);
					this.set("IsSectionVisible", true);
					this._setRecordFields();
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getFiltersKey
				 * @override
				 */
				getFiltersKey: function() {
					var key = this.callParent(arguments);
					return this.entitySchemaName + key;
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#getProfileKey
				* @override
				*/
				getProfileKey: function() {
					return this.entitySchemaName + this.sectionModuleSuffix + this.gridViewModuleSuffix;
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#init
				* @override
				*/
				init: function() {
					this.callParent(arguments);
					this.initSection();
				},

				/**
				 * Section close button handler.
				 * @protected
				 */
				onCloseButtonClick: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
				* @override
				*/
				getSectionActions: function() {
					return new BPMSoft.Collection();
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#initPrintButtonsMenu
				* @override
				*/
				initPrintButtonsMenu: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#loadGridData
				 * @override
				 */
				loadGridData: function() {
					this.reloadEstimatedCountAsync();
					this.mixins.GridUtilities.loadGridData.call(this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#onSelectedRowsChange
				 * @override
				 */
				onSelectedRowsChange: function(model, value) {
					this.callParent(arguments);
					this.actualizeProcessAudienceButtonCaption();
					if (value.length > this.selectedRowsLimit) {
						this._showSelectedRecordsLimitReachedMessage();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#onFilterUpdate
				 * @override
				 */
				onFilterUpdate: function() {
					this.callParent(arguments);
					this.set("RecordsCount", 0, { silent: true });
					this.set("EstimatedRecordsCount", 0);
					this.$CanProcessByFilter = this._isAnyFilterSelected();
				},

				/**
				 * Returns unique key for sessioned section filters.
				 * @protected
				 * @returns {String}
				 */
				getSessionFiltersKey: function() {
					return this.entitySchemaName + this.name;
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getSessionFilters
				 * @override
				 */
				getSessionFilters: function() {
					this.callParent(arguments);
					var storageFilters = BPMSoft.configuration.Storage.Filters;
					var key = this.getSessionFiltersKey();
					if (!storageFilters[key]) {
						storageFilters[key] = {};
					}
					return storageFilters[key];
				},

				/**
				 * Cancels previous load estimated records count request.
				 * @private
				 */
				abortPreviousEstimatedCountRequest: function() {
					if (this.lastEstimatedCountRequestId) {
						this.BPMSoft.AjaxProvider.abortRequestByInstanceId(this.lastEstimatedCountRequestId);
					}
				},

				/**
				 * Loads records count by selected filter and sets it as estimated process count.
				 * @protected
				 */
				reloadEstimatedCountAsync: function() {
					this.abortPreviousEstimatedCountRequest();
					var esq = this.getEsqWithFilters();
					esq.columns.clear();
					esq.addAggregationSchemaColumn(this.primaryColumnName,
						this.BPMSoft.AggregationType.COUNT, "Count");
					this.getEntityCollection(esq, function(response) {
						if (response.success) {
							var result = response.collection.first();
							var count = result && result.$Count || 0;
							this.$EstimatedRecordsCount = count;
						}
					}, this);
					this.lastEstimatedCountRequestId = esq.instanceId;
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#initSummarySettingsProfile
				 * @override
				 */
				initSummarySettingsProfile: function(callback, scope) {
					this.set("SummaryHasCount", true);
					this.Ext.callback(callback, scope);
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#onGridDataLoaded
				 * @override
				 */
				onGridDataLoaded: function(response) {
					this.callParent(arguments);
					var dataCollection = response.collection || Ext.create("BPMSoft.Collection");
					this.$RecordsCount = dataCollection.getCount();
					this.reloadGridColumnsConfig(true);
					this.changeGridUtilitiesContainerSize();
				},

				/**
				 * Returns entity schema query to select current filtered records.
				 * @protected
				 * @returns {BPMSoft.EntitySchemaQuery}
				 */
				getEsqWithFilters: function() {
					var esq = this.getGridDataESQ();
					esq.addColumn(this.primaryColumnName);
					this.initQueryFilters(esq);
					return esq;
				},

				/**
				 * Calls audience service to process selected records by ids.
				 * @protected
				 */
				processSelectedRecords: BPMSoft.abstractFn,

				/**
				 * Calls audience service to process filtered records by current folder.
				 * @protected
				 */
				processRecordByFolder: BPMSoft.abstractFn,

				/**
				 * Calls audience service to process records by serialized esq with filters.
				 * @protected
				 */
				processRecordsByFilter: BPMSoft.abstractFn,
				/**
				 * Calls audience service to process filtered records.
				 * @protected
				 */
				processFilteredRecords: function() {
					if (this._isFolderFilterOnly()) {
						this.processRecordByFolder();
						return;
					}
					this.processRecordsByFilter();
				},

				/**
				 * Handler on process audience completed event.
				 * @protected
				 * @param {Object} result Service response result.
				 */
				onProcessAudienceCompleted: function(result) {
					if (result.Success) {
						this.sandbox.publish("BackHistoryState");
					} else {
						this.showInformationDialog(result.Message || this.getProcessAudienceFailedMessage());
					}
				},

				/**
				 * Returns process selected records confirmation message.
				 * @protected
				 * @returns {String}
				 */
				getProcessAudienceFailedMessage: function() {
					return resources.localizableStrings.OnProcessAudienceFailedMessage;
				},

				/**
				 * Returns process selected records confirmation message.
				 * @protected
				 * @returns {String}
				 */
				getProcessSelectedConfirmationMessage: BPMSoft.abstractFn,

				/**
				 * Returns process filtered records confirmation message.
				 * @protected
				 * @returns {String}
				 */
				getProcessByFilterConfirmationMessage: BPMSoft.abstractFn,

				/**
				 * Returns process audience button caption to display.
				 * @protected
				 * @returns {String}
				 */
				getProcessAudienceButtonCaption: BPMSoft.abstractFn,

				/**
				 * Returns selected records limit reached information message.
				 * @protected
				 * @returns {String}
				 */
				getSelectedRecordsLimitReachedMessage: BPMSoft.abstractFn,

				/**
				 * Handler on process selected records button click event.
				 * @protected
				 */
				onProcessSelectedRecordsClick: function() {
					if (this.$SelectedRows.length > this.selectedRowsLimit) {
						this._showSelectedRecordsLimitReachedMessage();
						this.unSelectRecords();
						this.set("SelectAllCheckBox", false);
						this.set("SelectAllListedItemVisible", false);
						this.set("SelectAllTiledItemVisible", false);
						return;
					}
					if (this.$SelectedRows.length <= this.rowsLimitForQuickQueue) {
						this.processSelectedRecords();
						this.unSelectRecords();
						this.set("SelectAllCheckBox", false);
						this.set("SelectAllListedItemVisible", false);
						this.set("SelectAllTiledItemVisible", false);
						return;
					}
					var confirmationMessage = this.getProcessSelectedConfirmationMessage();
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.OK.returnCode) {
								this.processSelectedRecords();
								this.unSelectRecords();
								this.set("SelectAllCheckBox", false);
								this.set("SelectAllListedItemVisible", false);
								this.set("SelectAllTiledItemVisible", false);
							}
						}, ["ok", "cancel"]);
				},

				/**
				 * Handler on process filtered records button click event.
				 * @protected
				 */
				onProcessByFilterClick: function() {
					if (this.$EstimatedRecordsCount && this.$EstimatedRecordsCount <= this.rowsLimitForQuickQueue) {
						this.processFilteredRecords();
						return;
					}
					var confirmationMessage = this.getProcessByFilterConfirmationMessage();
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.OK.returnCode) {
								this.processFilteredRecords();
							}
						}, ["ok", "cancel"]);
				},

				/**
				 * Sets process audience button caption with count of selected records.
				 * @protected
				 */
				actualizeProcessAudienceButtonCaption: function() {
					var caption = this.getProcessAudienceButtonCaption();
					var processCount = this.$SelectedRows.length;
					if (processCount > 0) {
						caption = Ext.String.format("{0} ({1})", caption, processCount);
					}
					this.$ProcessAudienceButtonCaption = caption;
				}
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"name": "CloseAudienceSectionButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"caption": "$Resources.Strings.CloseButtonCaption",
						"classes": { textClass: "actions-button-margin-right" },
						"click": "$onCloseButtonClick"
					}
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"click": "$onCloseButtonClick"
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": BPMSoft.GridType.LISTED,
						"multiSelect": true,
						"canChangeMultiSelectWithGridClick": false
					}
				},
				{
					"operation": "remove",
					"name": "SeparateModeAddRecordButton"
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowOpenAction"
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowDeleteAction"
				},
				{
					"operation": "merge",
					"name": "CloseSectionButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "ToggleSectionButton",
					"values": {
						"visible": false
					}
				}
			]
		};
	}
);
