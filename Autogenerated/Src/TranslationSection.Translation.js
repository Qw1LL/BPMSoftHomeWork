define("TranslationSection", ["BPMSoft", "ConfigurationGrid", "ConfigurationGridGenerator",
	"ConfigurationGridUtilities", "css!TranslationCSS", "UntranslatedFilterViewModel",
	"ConfigurationServiceRequest", "FileImportMixin","SysTranslationColumnsCaptionMixin"],function(BPMSoft) {
	return {
		entitySchemaName: "SysTranslation",
		messages: {
			/**
			 * @message GetModuleInfo
			 * Used to provide information for BPMSoft.ModalBoxSchemaModule about modal window.
			 */
			"GetModuleInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetOrderedGridColumns
			 * Returns paths of visible in section grid columns in their display order.
			 */
			"GetOrderedGridColumns": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateRecordInfo
			 * Updates active translation row after changes had been made through translation modal window.
			 */
			"UpdateRecordInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetRowPositionDetails
			 * Sends previous and next objects ids and canLoadMore flag to be used for navigation in modal window.
			 */
			"GetRowPositionDetails": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ModalBoxClosing
			 * Fires when modal box is closing.
			 */
			"ModalBoxClosing": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GridDataUpdated
			 * Fires after loading more data to the grid.
			 */
			"GridDataUpdated": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			GetPredefinedFilters: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetExtendedFilterConfig
			 * Extended filters settings message.
			 */
			"GetExtendedFilterConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		properties: {
			languageColumnName: "Language",
			languageColumnSuffix: "Short"
		},
		attributes: {
			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#IsEditable
			 * @overridden
			 */
			IsEditable: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * ViewButton visibility attribute.
			 */
			ViewOptionsButtonTipVisible: {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Contains primary column value of selected translation row.
			 */
			ModalBoxActiveRow: {
				dataValueType: BPMSoft.DataValueType.GUID,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#SecurityOperationName
			 * @overridden
			 */
			SecurityOperationName: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "CanManageTranslationSection"
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseFolderFilter
			 * @overridden
			 */
			UseFolderFilter: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseStaticFolders
			 * @overridden
			 */
			"UseStaticFolders": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Translation actualized.
			 */
			TranslationActualized: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Translation actualization is in progress.
			 */
			ActualizationInProgress: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		mixins: {
			"ConfigurationGridUtilities": "BPMSoft.ConfigurationGridUtilities",
			"FileImport": "BPMSoft.FileImportMixin",
			"SysTranslationColumnsConfiguration": "BPMSoft.SysTranslationColumnsCaptionMixin"
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_getFilterLanguageShortColumnPath: function(filter) {
				var languageColumns = this.getTranslationColumns();
				var entityColumns = this.entitySchema.columns;
				var columnPath = filter.leftExpression.columnPath;
				if (this.isNotEmpty(languageColumns[columnPath])) {
					var shortColumnPath = columnPath + this.languageColumnSuffix;
					return entityColumns.hasOwnProperty(shortColumnPath) ? shortColumnPath : columnPath;
				} else {
					return columnPath;
				}
			},

			/**
			 * @private
			 */
			_processLanguageFilter: function(filter) {
				var filterType = filter.filterType;
				if (filterType === BPMSoft.FilterType.FILTER_GROUP) {
					filter.each(function(item) {
						this._processLanguageFilter(item);
					}, this);
				} else if (filterType === BPMSoft.FilterType.COMPARE || filterType === BPMSoft.FilterType.IS_NULL) {
					filter.leftExpression.columnPath = this._getFilterLanguageShortColumnPath(filter);
				} else {
					this.log("Not implemented");
				}
			},

			/**
			 * @private
			 */
			_processFolderFilters: function(filters) {
				var folderFilters = filters.find("FolderFilters");
				if (folderFilters) {
					this._processLanguageFilter(folderFilters);
				}
			},

			/**
			 * @private
			 */
			_processCustomFilters: function(filters) {
				var customFilters = filters.find("CustomFilters");
				if (customFilters) {
					this._processLanguageFilter(customFilters);
				}
			},

			/**
			 * Returns page configuration.
			 * @private
			 * @return {Object} Configuration object.
			 * @return {String} return.schemaName Schema name.
			 * @return {String} return.recordId Modal box active row id.
			 * @return {Object} return.modalBoxConfig Modal window configuration object.
			 * @return {String} return.modalBoxConfig.minWidth Minimal initial window width (percentage).
			 * @return {Array} return.modalBoxConfig.boxClasses CSS classes to be attached to the modal window.
			 */
			getPageConfig: function() {
				var activeRowId = this.get("ModalBoxActiveRow");
				if (activeRowId) {
					return {
						schemaName: "TranslationPage",
						recordId: activeRowId,
						modalBoxConfig: {
							minWidth: "45",
							boxClasses: ["translation-modal-box"]
						}
					};
				}
			},

			/**
			 * Returns an index counted from the end of grid array which points to the row that will trigger
			 * more data loading (if set as active).
			 * Should be any reasonable value between zero(including) and expected grid data array length.
			 * @private
			 * @return {Number}
			 */
			getPreloadOffset: function() {
				return 3;
			},

			/**
			 * Returns visible in grid columns sorted by its display order.
			 * @private
			 * @return {Array}
			 */
			getOrderedGridColumns: function() {
				var columns = this.getProfileColumns();
				var columnPaths = [];
				this.BPMSoft.each(columns, function(column) {
					columnPaths.push(column.path);
				}, this);
				return columnPaths;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#onGetFiltersCollection
			 * @override
			 */
			onGetFiltersCollection: function() {
				var result = this.mixins.GridUtilities.onGetFiltersCollection.call(this);
				this.processLanguageColumnFilters(result);
				return result;
			},

			/**
			 * Refreshes record edited in modal window.
			 * @param {Object} updates Object containing data to find and update edited row.
			 * @param {Object} updates.recordId Id of the row that has to be updated.
			 * @param {Object} updates.changedColumnValues Columns to be replaced.
			 * @private
			 */
			onRecordChanged: function(updates) {
				updates = updates || {};
				if (!updates.recordId) {
					throw new BPMSoft.exceptions.ItemNotFoundException();
				}
				var rowId = updates.recordId;
				var gridData = this.getGridData();
				var row = gridData.get(rowId);
				this.BPMSoft.each(updates.changedColumnValues, function(value, columnName) {
					row.set(columnName, value);
				});
				row.changedValues = null;
			},

			/**
			 * Moves focus to the row last shown in the modal box (Makes it active).
			 * @param {Object} closingParameters Object, containing parameters set on modalbox closing.
			 * @param {String} closingParameters.recordId Id of the row last edited in modalbox (to set active).
			 * @private
			 */
			onModalBoxClosing: function(closingParameters) {
				closingParameters = closingParameters || {};
				if (closingParameters.recordId) {
					this.setActiveRow(closingParameters.recordId);
				}
			},

			/**
			 * Constructs an object for GetRowPositionDetails message, calls tryLoadGridData method.
			 * @param {String} rowId Id of the row to create details object for.
			 * @return {Object} Object containing information about surrounding rows and grid status.
			 * @return {String} return.previousId Id of the previous row in the grid.
			 * @return {String} return.nextId Id of the next row in the grid.
			 * @return {Boolean} return.canLoadMore Flag showing if more data could be loaded to the grid.
			 * @private
			 */
			getRowPositionDetails: function(rowId) {
				var keysArray = this.getGridData().getKeys();
				var currentRowIndex = keysArray.indexOf(rowId);
				var canLoadMoreData = this.get("CanLoadMoreData");
				this.tryLoadGridData(currentRowIndex, keysArray.length, canLoadMoreData);
				var rowPositionDetails = {
					previousId: keysArray[currentRowIndex - 1],
					nextId: keysArray[currentRowIndex + 1],
					canLoadMore: canLoadMoreData
				};
				return rowPositionDetails;
			},

			/**
			 * If the row has specific index in the grid array defined to trigger loading more data to the grid
			 * and more data can be loaded, calls a method to load more data. Will not start loading if previous
			 * request is still in progress.
			 * @param {Number} currentRowIndex Position of the current row in the grid.
			 * @param {Number} arrayLength Number of elements that are now in the grid.
			 * @param {Boolean} canLoadMore Flag showing if more data could be loaded to the grid.
			 * @private
			 */
			tryLoadGridData: function(currentRowIndex, arrayLength, canLoadMore) {
				var preloadOffset = this.getPreloadOffset();
				var isGridLoading = this.get("IsGridLoading");
				var needToLoad = (currentRowIndex + 1 + preloadOffset) === arrayLength;
				if (needToLoad && canLoadMore && !isGridLoading) {
					this.loadGridData();
				}
			},

			/**
			 * Loads translation edit modal window.
			 * @param {String} primaryColumnValue Active row primary column value.
			 * @private
			 */
			openTranslationWindow: function(primaryColumnValue) {
				this.set("ModalBoxActiveRow", primaryColumnValue);
				this.sandbox.loadModule("ModalBoxSchemaModule", {
					id: this.getModalBoxWindowId()
				});
			},

			/**
			 * Exports translation.
			 * @private
			 */
			exportTranslation: function() {

			},
			
			/**
			 * Gets predefined filters module identifier.
			 * @private
			 * @return {String}
			 */
			getPredefinedFiltersModuleId: function() {
				return this.sandbox.id + "_PredefinedFiltersModule";
			},

			/**
			 * Get predefined filters.
			 * @private
			 * @return {Object}
			 */
			getPredefinedFilters: function() {
				return [
					{
						className: "BPMSoft.UntranslatedFilter",
						key: "Untranslated",
						caption: this.get("Resources.Strings.UntranslatedRecordsFilter"),
						imageConfig: this.get("Resources.Images.UntranslatedRecordsFilterImage"),
						columns: this.getTranslationColumns(),
						comparisonType: BPMSoft.ComparisonType.IS_NULL,
						primaryColumnPath: this.get("DefaultLanguageColumnName")
					}
				];
			},

			/**
			 * Gets translation columns.
			 * @private
			 * @return {Object}
			 */
			getTranslationColumns: function() {
				var translationColumns = {};
				this.BPMSoft.each(this.entitySchema.columns, function(column) {
					var columnName = column.name;
					var isTranslationColumn = (columnName.indexOf(this.languageColumnName) === 0);
					var isGeneralUsageTypeColumn = (column.usageType === BPMSoft.EntitySchemaColumnUsageType.General);
					if (isTranslationColumn && isGeneralUsageTypeColumn) {
						translationColumns[columnName] = column;
					}
				}, this);
				return translationColumns;
			},

			/**
			 * Checks if translations can be applied.
			 * @private
			 * @param {Function} [callback] Callback.
			 * @param {Object} [scope] Callback execution scope.
			 */
			checkTranslation: function(callback, scope) {
				var request = this.createTranslationServiceRequest("CheckTranslation");
				request.execute(function(response) {
					if (callback) {
						callback.call(scope || this, response);
					}
				}, this);
			},

			/**
			 * Creates translation service request.
			 * @private
			 * @param {String} contractName Contract name.
			 * @return {BPMSoft.ConfigurationServiceRequest}
			 */
			createTranslationServiceRequest: function(contractName) {
				return this.Ext.create(BPMSoft.ConfigurationServiceRequest, {
					serviceName: "TranslationService",
					contractName: contractName
				});
			},

			/**
			 * Applies translations.
			 * @private
			 * @param {Function} [callback] Callback.
			 * @param {Object} [scope] Callback execution scope.
			 */
			applyTranslation: function(callback, scope) {
				var translationApplyingMessage = this.get("Resources.Strings.TranslationApplying");
				this.showBodyMask({caption: translationApplyingMessage});
				var request = this.createTranslationServiceRequest("ApplyTranslation");
				request.execute(function(translationApplyingResponse) {
					var applyingResult = this.processTranslationServiceResponse(translationApplyingResponse);
					if (!applyingResult) {
						this.hideBodyMask();
						return;
					}
					this.checkTranslation(function() {
						this.hideBodyMask();
						this.processTranslationApplyingLog(translationApplyingResponse.operationLog);
						Ext.callback(callback, scope || this, [translationApplyingResponse]);
					}, this);
				}, this);
			},

			/**
			 * Processes translation service response.
			 * @private
			 * @param {BPMSoft.core.BaseResponse} response Response.
			 * @return {Boolean}
			 */
			processTranslationServiceResponse: function(response) {
				if (!response.success) {
					this.showInformationDialog(response.errorInfo.message);
				}
				return response.success;
			},

			/**
			 * Processes translation applying log.
			 * @private
			 * @param {Array} operationLog Log elements.
			 */
			processTranslationApplyingLog: function(operationLog) {
				if (!operationLog.length) {
					var successMessage = this.get("Resources.Strings.TranslationApplyingSuccess");
					this.showInformationDialog(successMessage);
					return;
				}
				var errorMessage = this.get("Resources.Strings.TranslationApplyingError");
				this.showInformationDialog(errorMessage);
				operationLog.forEach(function(logItem) {
					this.log(logItem);
				}, this);
			},

			/**
			 * @private
			 */
			setDefaultColumnPath: function(columnsConfig) {
				var defaultLanguageColumn = BPMSoft.find(columnsConfig, function(columnConfig) {
					return columnConfig.IsDefault;
				}, this);
				if(defaultLanguageColumn) {
					this.set("DefaultLanguageColumnName", defaultLanguageColumn.LanguageColumnPath);
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getGridRowViewModelClassName
			 * @overridden
			 * @protected
			 */
			getGridRowViewModelClassName: function() {
				return this.mixins.GridUtilities.getGridRowViewModelClassName.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
			 * @overridden
			 * @protected
			 */
			getModuleCaption: function() {
				return this.get("Resources.Strings.SectionCaption");
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
			 * @protected
			 * @overridden
			 */
			getSectionActions: function() {
				var actionMenuItems = this.Ext.create(BPMSoft.BaseViewModelCollection);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "actualizeTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ActualizeTranslation"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SelectMultipleRecordsButtonCaption"},
					"Click": {"bindTo": "setMultiSelect"},
					"Visible": {"bindTo": "isMultiSelectVisible"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SelectOneRecordButtonCaption"},
					"Click": {"bindTo": "unSetMultiSelect"},
					"Visible": {"bindTo": "isSingleSelectVisible"},
					"IsEnabledForSelectedAll": true
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.IncludeInFolderButtonCaption"},
					"Click": {"bindTo": "openStaticGroupLookup"},
					"Enabled": {"bindTo": "isAnySelected"},
					"Visible": {"bindTo": "UseStaticFolders"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.ExcludeFromFolderButtonCaption"},
					"Click": {"bindTo": "excludeFromFolder"},
					"Enabled": {"bindTo": "isAnySelected"},
					"Visible": {"bindTo": "UseStaticFolders"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "exportTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ExportCaption"},
					"Tag": "Export",
					"Visible": false
				}));
				var exportToFileMenuItem = this.getExportToFileMenuItem();
				actionMenuItems.addItem(exportToFileMenuItem);
				var exportToExcelMenuItem = this.getExportToExcelFileMenuItem();
				actionMenuItems.addItem(exportToExcelMenuItem);
				var fileImportMenuItem = this.getDataImportMenuItem();
				if (fileImportMenuItem) {
					actionMenuItems.add("FileImportMenuItem", fileImportMenuItem);
				}
				return actionMenuItems;
			},

			/**
			 * Initializes entity schema query columns.
			 * @protected
			 * @virtual
			 * @param {Object} esq Entity schema query
			 */
			initSysCultureQueryColumns: function(esq) {
				esq.addColumn("Name");
				esq.addColumn("Active");
				esq.addColumn("Index");
				esq.addColumn("Language");
			},

			/**
			 * Initializes entity schema query filters.
			 * @protected
			 * @virtual
			 * @param {Object} esq Entity schema query
			 * @param {String} cultureId Culture identifier.
			 */
			initSysCulturePrimaryColumnFilter: function(esq, cultureId) {
				esq.filters.add("primaryColumnFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", cultureId));
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#initActiveRowKeyMap
			 * @overridden
			 * @protected
			 */
			initActiveRowKeyMap: function(keyMap) {
				this.mixins.ConfigurationGridUtilities.initActiveRowKeyMap.apply(this, arguments);
				keyMap.push({
					key: Ext.EventObject.S,
					ctrl: true,
					defaultEventAction: "preventDefault",
					fn: this.onCtrlSKeyPressed,
					scope: this
				});
			},

			/**
			 * Handles Ctrl + S combination press.
			 * @protected
			 * @virtual
			 * @param {Number} keyCode Key code.
			 * @param {Object} event Event.
			 */
			onCtrlSKeyPressed: function(keyCode, event) {
				event.preventDefault();
				this.onCtrlEnterKeyPressed();
			},

			/**
			 * Returns culture.
			 * @protected
			 * @param {Object} response Server response.
			 * @return {Object} Culture info.
			 */
			onCultureInfoLoaded: function(response) {
				var cultures = response.collection;
				return cultures.getByIndex(0);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#loadGridData
			 * @override
			 */
			loadGridData: function() {
				if (this.get("TranslationActualized") && !this.get("ActualizationInProgress")) {
					this.callParent(arguments);
				} else {
					this.set("TranslationActualized", false);
					this.actualizeTranslation(function() {
						this.set("TranslationActualized", true);
						this.loadGridData();
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#initQueryFilters
			 * @override
			 */
			initQueryFilters: function(esq) {
				this.callParent(arguments);
				var filters = esq.filters.first();
				if (!filters) {
					return;
				}
				this.processLanguageColumnFilters(filters);
			},

			/**
			 * @protected
			 * @param {BPMSoft.FilterGroup} filters Group of filters to be processed.
			 */
			processLanguageColumnFilters: function(filters) {
				this._processFolderFilters(filters);
				this._processCustomFilters(filters);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilters
			 * @override
			 */
			getFilters: function() {
				var createFilter = BPMSoft.createColumnFilterWithParameter;
				var notEndWith = BPMSoft.ComparisonType.NOT_END_WITH;
				var endWith = BPMSoft.ComparisonType.END_WITH;
				var notContain = BPMSoft.ComparisonType.NOT_CONTAIN;
				var key = "Key";
				var filters = this.callParent(arguments);
				filters.addItem(createFilter(notEndWith, key, ".EntityFilters.Value"));
				filters.addItem(createFilter(notEndWith, key, ".DataSourceFilters.Value"));
				var baseElementFilter = this.Ext.create("BPMSoft.FilterGroup");
				baseElementFilter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				baseElementFilter.addItem(createFilter(notContain, key, "BaseElements."));
				baseElementFilter.addItem(createFilter(endWith, key, ".Caption"));
				baseElementFilter.addItem(createFilter(endWith, key, ".Recommendation.Value"));
				baseElementFilter.addItem(createFilter(endWith, key, ".Parameters.%.Value"));
				filters.addItem(baseElementFilter);
				var processSchemaFilter = this.Ext.create("BPMSoft.FilterGroup");
				processSchemaFilter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				processSchemaFilter.addItem(createFilter(notEndWith, key, ".Caption"));
				var processSchemaSubFilter = this.Ext.create("BPMSoft.FilterGroup");
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.BaseElements."));
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.Parameters."));
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.LaneSets."));
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.Methods."));
				processSchemaFilter.addItem(processSchemaSubFilter);
				filters.addItem(processSchemaFilter);
				filters.addItem(createFilter(notEndWith, key, ".Parameters.EntityColumnMetaPathes.Value"));
				filters.addItem(createFilter(notEndWith, key, ".Parameters.%.DisplayValue"));
				return filters;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#loadFiltersModule
			 * @override
			 */
			loadFiltersModule: function() {
				this.callParent(arguments);
				this.sandbox.loadModule("PredefinedFiltersModule", {
					renderTo: "PredefinedFiltersContainer",
					id: this.getPredefinedFiltersModuleId()
				});
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterModulesIds
			 * @override
			 */
			getFilterModulesIds: function() {
				var ids = this.callParent(arguments);
				ids.push(this.getPredefinedFiltersModuleId());
				return ids;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#subscribeFilterGetConfigMessages
			 * @override
			 */
			subscribeFilterGetConfigMessages: function() {
				this.callParent(arguments);
				var predefinedFiltersModuleId = this.getPredefinedFiltersModuleId();
				this.sandbox.subscribe("GetPredefinedFilters", this.getPredefinedFilters, this,
						[predefinedFiltersModuleId]);
			},

			/**
			 * Gets extended filter configuration.
			 * @protected
			 */
			onGetExtendedFilterConfig: function() {
				return {
					isFoldersHidden: true,
					hasExtendedMode: true
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				var quickFilterModuleId = this.getQuickFilterModuleId();
				this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfig,
						this, [quickFilterModuleId]);
				this.subscribeModalBoxEvents();
			},

			/**
			 * Returns sandbox id for modal window.
			 * @protected
			 * @return {String} Sandbox id for modal window.
			 */
			getModalBoxWindowId: function() {
				return this.sandbox.id + "_TranslationEditModalBox";
			},

			/**
			 * Initializes subscription on messages used to communicate with modal window.
			 * @protected
			 */
			subscribeModalBoxEvents: function() {
				this.sandbox.subscribe("GetModuleInfo", this.getPageConfig, this, [this.getModalBoxWindowId()]);
				this.sandbox.subscribe("GetOrderedGridColumns", this.getOrderedGridColumns, this,
						[this.getModalBoxWindowId()]);
				this.sandbox.subscribe("UpdateRecordInfo", this.onRecordChanged, this,
						[this.getModalBoxWindowId()]);
				this.sandbox.subscribe("GetRowPositionDetails", this.getRowPositionDetails, this,
						[this.getModalBoxWindowId()]);
				this.sandbox.subscribe("ModalBoxClosing", this.onModalBoxClosing, this,
						[this.getModalBoxWindowId()]);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#afterLoadGridData
			 * @protected
			 * @override
			 */
			afterLoadGridData: function() {
				this.callParent(arguments);
				this.showViewButtonHint();
				this.sandbox.publish("GridDataUpdated", null, [this.getModalBoxWindowId()]);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					BPMSoft.chain(
						function(next) {
							var entityColumns = this.entitySchema.columns;
							this.initSysTranslationColumnsProperties(entityColumns, function(columnsConfig) {
								this.setDefaultColumnPath(columnsConfig);
								next();
							}, this);
						},
						function() {
							if(callback) {
								callback.call(scope);
							}
						},
						this
					);
				}, this]);
				BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.handleServerChannelMessage, this);
			},

			/**
			 * Channel message event handler.
			 * @param {Object} channel Channel.
			 * @param {Object} message Channel message.
			 */
			handleServerChannelMessage: function(channel, message) {
				var messageSenderName = message && BPMSoft.ServerChannel.getSenderName(message);
				if (messageSenderName === "ActualizeTranslationError") {
					var actualizedErrorMessage = this.get("Resources.Strings.ActualizedErrorMessage");
					var errorMessage = Ext.String.format("{0}\n{1}", actualizedErrorMessage, message.Body);
					this.showInformationDialog(errorMessage);
				}
			},
			/**
			 * Handles "Close" button click.
			 */
			onCloseButtonClick: function() {
				this.sandbox.publish("BackHistoryState");
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#onActiveRowAction
			 * @override
			 */
			onActiveRowAction: function(tag, primaryColumnValue) {
				if (tag === "card") {
					this.openTranslationWindow(primaryColumnValue);
				} else {
					this.mixins.ConfigurationGridUtilities.onActiveRowAction.apply(this, arguments);
					this.callParent(arguments);
				}
			},

			/**
			 * Shows view options button hint if translation section is visited for the first time.
			 */
			showViewButtonHint: function() {
				var profile = this.getProfile();
				var key = this.getProfileKey();
				if (profile && key) {
					var isViewButtonTipShown = profile.isViewButtonTipShown;
					if (!isViewButtonTipShown) {
						this.set("ViewOptionsButtonTipVisible", true);
						profile.isViewButtonTipShown = true;
						this.BPMSoft.utils.saveUserProfile(key, profile, false);
					}
				}
			},

			/**
			 * Actualizes translation.
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Callback execution scope.
			 */
			actualizeTranslation: function(callback, scope) {
				this.log("Translation actualization start");
				var translationActualizationMessage = this.get("Resources.Strings.TranslationActualization");
				this.showBodyMask({caption: translationActualizationMessage});
				var request = this.createTranslationServiceRequest("ActualizeTranslation");
				this.set("ActualizationInProgress", true);
				request.execute(function(response) {
					this.log("Translation actualization end");
					this.set("ActualizationInProgress", false);
					this.hideBodyMask();
					Ext.callback(callback, scope || this, [response]);
				}, this);
			},

			/**
			 * Applies translations.
			 */
			onApplyTranslationsButtonClick: function() {
				this.applyTranslation(function() {
					this.reloadGridData();
				});
			},

			/**
			 * Gets "ApplyTranslationsButton" visibility.
			 * @return {Boolean}
			 */
			getIsApplyTranslationsButtonVisible: function() {

				return true;
			},

			/**
			 * Gets section wrapper markerValue.
			 * @return {string}
			 */
			getSectionWrapperMarkerValue: function() {
				return this.get("TranslationActualized") ? "TranslationActualized" : "";
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "SectionWrapContainer",
				"values": {
					"markerValue": {"bindTo": "getSectionWrapperMarkerValue"}
				}
			},
			{
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			},
			{
				"operation": "merge",
				"name": "SeparateModeViewOptionsButton",
				"values": {
					"tips": []
				}
			},
			{
				"operation": "insert",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"name": "PredefinedFiltersContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"id": "PredefinedFiltersContainer",
					"selectors": {wrapEl: "#PredefinedFiltersContainer"},
					"wrapClass": ["predefined-filters-container-wrapClass"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SeparateModeViewOptionsButton",
				"propertyName": "tips",
				"name": "TranslateViewOptionsButtonTip",
				"values": {
					"content": {"bindTo": "Resources.Strings.ViewButtonHint"},
					"visible": {"bindTo": "ViewOptionsButtonTipVisible"},
					"behaviour": {
						"displayEvent": this.BPMSoft.TipDisplayEvent.NONE
					}
				}
			},
			{
				"operation": "insert",
				"index": 0,
				"name": "CloseButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
					"click": {"bindTo": "onCloseButtonClick"},
					"classes": {
						"textClass": ["actions-button-margin-right"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ApplyTranslationButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.ApplyTranslationsButtonCaption"},
					"click": {"bindTo": "onApplyTranslationsButtonClick"},
					"visible": {"bindTo": "getIsApplyTranslationsButtonVisible"},
					"classes": {
						"textClass": ["actions-button-margin-right"]
					}
				}
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
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"type": "listed",
					"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
					"changeRow": {"bindTo": "changeRow"},
					"unSelectRow": {"bindTo": "unSelectRow"},
					"onGridClick": {"bindTo": "onGridClick"},
					"listedZebra": true,
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onActiveRowAction"},
					"rowDataItemMarkerColumnName": "Key",
					"allowScrollToActiveRow": "true"
				}
			},
			{
				"operation": "insert",
				"name": "activeRowActionCard",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"tag": "card",
					"markerValue": "card",
					"imageConfig": {"bindTo": "Resources.Images.CardIcon"}
				}
			},
			{
				"operation": "insert",
				"name": "activeRowActionSave",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"tag": "save",
					"markerValue": "save",
					"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
				}
			},
			{
				"operation": "insert",
				"name": "activeRowActionCancel",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"tag": "cancel",
					"markerValue": "cancel",
					"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
