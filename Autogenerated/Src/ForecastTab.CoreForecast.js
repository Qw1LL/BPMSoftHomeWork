define("ForecastTab", ["ForecastItem", "ForecastTabResources", "ForecastConstants", "RightUtilities", "GoogleTagManagerUtilities", "PivotGrid",
		"ConfigurationGrid", "ConfigurationGridGenerator", "ConfigurationGridUtilities",
		"EntityResponseValidationMixin", "LookupMultiAddMixin", "ForecastServiceRequest", "CalculationTimer", "DatePickerFilterModule", "GridUtilitiesV2"],
	function(ForecastItem, resources, ForecastConstants, RightUtilities, GoogleTagManagerUtilities) {
		return {
			messages: {
				/**
				 * @message GetRecordInfo
				 * ######## ################ ###### ## ##########  ##### ######## # ######## ######### ####.
				 * @param {String} ################ ###### ## ##########  ##### ######## # ######## ######### ####.
				 */
				"GetRecordInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ########## ######### ### ######### #########.
				 */
				"GetHistoryState": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message PushHistoryState
				 * ######### ######### # ####### #########.
				 */
				"PushHistoryState": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetForecastConfig
				 * Returns forecast config.
				 */
				"GetForecastConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message RefreshForecast
				 * Refresh forecast.
				 */
				"RefreshForecast": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateForecast
				 * Update forecast.
				 */
				"UpdateForecast": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message RefreshForecastColumns
				 * Refresh forecast columns.
				 */
				"RefreshForecastColumns": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message RowActionClick
				 * On forecast row action click message.
				 */
				"RowActionClick": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SnapshotDateChanged
				 * On date changed on datepicker.
				 */
				"SnapshotDateChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ValidateDate
				 * Validate date from datepicker.
				 */
				"ValidateDate": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ShowDrilldownSetupColumns
				 * On Fields to display button click (Drilldown - Actions buttons)
				 */
				"ShowDrilldownSetupColumns": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message CellSelected
				 * On forecast cell selected.
				 */
				"CellSelected": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetGridSettingsInfo
				 * GridSettingsPage message published when initGridSettingsParams is called
				 */
				"GetGridSettingsInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GridSettingsChanged
				 * GridSettingsPage message published when _afterSaveUserProfile is called
				 */
				"GridSettingsChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message InitDataViews
				 * GridSettingsPage message published when initHeaderCaption is called
				 */
				"InitDataViews": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}


			},
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities",
				EntityResponseValidationMixin: "BPMSoft.EntityResponseValidationMixin",
				LookupMultiAddMixin: "BPMSoft.LookupMultiAddMixin",
				GridUtilities: "BPMSoft.GridUtilities"
			},
			attributes: {
				/**
				 * Determines if forecast tab has actions.
				 * @type {Boolean}
				 */
				HasCustomActions: {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * ####### ############## #######.
				 * @type {Boolean}
				 */
				IsEditable: {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * ############# ####### ####### ############.
				 * @type {GUID}
				 */
				ForecastId: {dataValueType: this.BPMSoft.DataValueType.GUID},

				/**
				 * ############# ##### ######## ###########.
				 * @type {GUID}
				 */
				EntitySchemaUId: {dataValueType: this.BPMSoft.DataValueType.GUID},

				/**
				 * ############# ######## ###########.
				 * @type {GUID}
				 */
				ForecastDimensionId: {dataValueType: this.BPMSoft.DataValueType.GUID},

				/**
				 * ######## ########### ######## ###########.
				 * @type {TEXT}
				 */
				ForecastDimensionSchemaName: {dataValueType: this.BPMSoft.DataValueType.TEXT},

				/**
				 * ######### ##### #######.
				 * @type {BPMSoft.Collection}
				 */
				Collection: {dataValueType: this.BPMSoft.DataValueType.COLLECTION},

				/**
				 * ######## #### ####### ######## ############.
				 * @type {CUSTOM_OBJECT}
				 */
				ForecastPeriodType: {dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT},

				/**
				 * ##### ##### ####### ############.
				 * @type {CUSTOM_OBJECT}
				 */
				ForecastGridRows: {dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT},

				/**
				 * Caption of filter by period.
				 * @type {String}
				 */
				FilterCaption: {dataValueType: this.BPMSoft.DataValueType.STRING},

				/**
				 * Selected periods.
				 * @type {CUSTOM_OBJECT}
				 */
				FilterPeriods: {dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT},

				/**
				 * Is dimension data loaded.
				 * @type {Boolean}
				 */
				"IsDimensionDataLoaded": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": "false"
				},

				/**
				 * Is forecast ui feature enabled.
				 */
				"ForecastUIV2FeatureEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Is forecast ui feature enabled.
				 */
				"IsForecastSnapshotFeatureEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": BPMSoft.Features.getIsEnabled("ForecastSnapshot")
				},

				/**
				 * Is start forecast calculation button locked.
				 */
				"CalculateButtonLocked": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Is calculation info should be visible.
				 */
				"IsCalculationInfoVisible": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Calculate forecast button caption.
				 */
				"CalculateButtonCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT
				},

				/**
				 * Is fullscreen forecast feature enabled.
				 */
				"FullscreenForecastsEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Is can show columns list.
				 */
				"CanShowColumnsList": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Time for waiting before checking if popups are disabled in browser.
				 */
				"WaitOpenWindowTimeout": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 1000
				},

				/**
				 * Last calculation date time.
				 */
				"LastCalcDateTime": {
					"dataValueType": BPMSoft.DataValueType.DATE_TIME,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * Next calculation date time.
				 */
				"NextCalcDateTime": {
					"dataValueType": BPMSoft.DataValueType.DATE_TIME,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				}
			},
			properties: {
				maxPeriodsCount: 24,
				_drilldownProfileData: null
			},
			methods: {

				// region Methods: Private

				/**
				 * @private
				 */
				_publishRefreshForecast: function(overdueData) {
					this.sandbox.publish("RefreshForecast", overdueData, [this._getForecastAngModuleId()]);
				},

				_publishRefreshHistoryForecast: function() {
					this.sandbox.publish("RefreshForecast", null, [this._getHistoryForecastModuleId()]);
				},

				_saveForecastCell: function(data, callback) {
					var config = {
						serviceName: "ForecastService",
						methodName: "SaveForecastCell",
						data: data
					};
					this.callService(config, callback, this);
				},

				/**
				 * @private
				 */
				_publishRefreshForecastColumns: function() {
					if (!this.getIsFeatureEnabled("ForecastSaveHierarchy")) {
						this.sandbox.publish("RefreshForecast", null, [this._getForecastAngModuleId()]);
						return;
					}
					const moduleId = this._getCurrentLoadedModuleId();
					this.sandbox.publish("RefreshForecastColumns", null, [moduleId]);
				},

				/**
				 * @private
				 */
				_getCurrentLoadedModuleId: function() {
					if (this.$ForecastAngModuleLoaded) {
						return this._getForecastAngModuleId();
					}
					return this._getHistoryForecastModuleId();
				},

				/**
				 * @private
				 */
				_updateSelectedColumns: function(result) {
					const columns = result && result.selectedRows;
					const ids = columns.getKeys();
					const hideQuery = this._getHideColumnsQuery();
					const batchQuery = this.Ext.create("BPMSoft.BatchQuery");
					batchQuery.add(hideQuery);
					if (ids && ids.length > 0) {
						const query = this._getUpdateToShowColumnsQuery(ids);
						batchQuery.add(query);
					}
					batchQuery.execute(function() {
						this._publishRefreshForecastColumns();
					}, this);
				},

				/**
				 * @private
				 */
				_getHideColumnsQuery: function() {
					return this._getUpdateColumnQuery(true);
				},

				/**
				 * @private
				 */
				_getUpdateToShowColumnsQuery: function(ids) {
					const updateQuery = this._getUpdateColumnQuery(false);
					updateQuery.filters.add("ByIds", this.BPMSoft.createColumnInFilterWithParameters("Id", ids));
					return updateQuery;
				},

				/**
				 * @private
				 */
				_getCustomActions: function(viewConfig) {
					if (!viewConfig) {
						return [];
					}
					const forecastTabButtonsContainer = viewConfig
						.find(function(item) {
							return item.id === "buttonContainer";
						});
					if (!forecastTabButtonsContainer) {
						return [];
					}
					const forecastTabActionsButton = forecastTabButtonsContainer.items
						.find(function(item) {
							return item.id === "ForecastTabactionsButtonButton";
						});
					if (!forecastTabActionsButton) {
						return [];
					}
					const customActions = forecastTabActionsButton.menu.items
						.filter(function(item) {
							return item.markerValue !== "factMenuItem";
						});
					return customActions;
				},

				/**
				 * @private
				 */
				_loadColumns: function(callback, scope) {
					const columnsEsq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ForecastColumn"
					});
					columnsEsq.addColumn("Id");
					columnsEsq.addColumn("IsHide");
					columnsEsq.filters.addItem(this._getColumnsFilterGroup());
					columnsEsq.filters.add("IsHide", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "IsHide", false));
					columnsEsq.getEntityCollection(function(response) {
						if (this.validateResponse(response)) {
							const collection = response.collection;
							this.Ext.callback(callback, scope, [collection.getKeys()]);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_getUpdateColumnQuery: function(isHideColumn) {
					const columnsUpdateQuery = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "ForecastColumn"
					});
					columnsUpdateQuery.setParameterValue("IsHide", isHideColumn, this.BPMSoft.DataValueType.BOOLEAN);
					columnsUpdateQuery.filters.addItem(this._getColumnsFilterGroup());
					return columnsUpdateQuery;
				},

				/**
				 * @private
				 */
				_getColumnsFilterGroup: function() {
					const filtersGroup = this.Ext.create("BPMSoft.FilterGroup");
					filtersGroup.add("ByForecastSheet", this._getForecastIdFilter());
					return filtersGroup;
				},

				/**
				 * @private
				 */
				_getForecastIdFilter: function() {
					return this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Sheet", this.$ForecastId);
				},

				/**
				 * @private
				 */
				_addCalculationTimerComponent: function() {
					const renderTo = Ext.get("calculationTimer");
					this.calculationTimerView = Ext.create("BPMSoft.CalculationTimer", {
						lastDateTime: {"bindTo": "LastCalcDateTime"},
						nextDateTime: {"bindTo": "NextCalcDateTime"},
						visible: {"bindTo": "IsCalculationInfoVisible"}
					});
					this.calculationTimerView.bind(this);
					this.calculationTimerView.render(renderTo);
				},

				/**
				 * @return {BPMSoft.ForecastServiceRequest}
				 * @private
				 */
				_getForecastServiceRequest: function() {
					return this.Ext.create("BPMSoft.ForecastServiceRequest", {
						forecastId: this.$ForecastId
					});
				},

				/**
				 * @private
				 */
				_getCellValueByIndicatorAndPeriod: function(cells, indicatorCode, periodId) {
					const cell = this.BPMSoft.findWhere(cells,
						{ForecastIndicatorCode: indicatorCode, PeriodId: periodId});
					return this.Ext.isEmpty(cell) ? 0 : cell.Value;
				},

				/**
				 * @private
				 */
				_getReferencedColumnName: function(referencedSchemaName) {
					const columns = this.BPMSoft.filter(this.entitySchema.columns, function(column) {
						return (column.referenceSchemaName === referencedSchemaName) && (column.usageType === 0);
					});
					return columns[0].name;
				},

				/**
				 * @return {BPMSoft.Filter}
				 * @private
				 */
				_getAlreadyAddedItemsFilter: function() {
					const referenceColumnName = this._getReferenceColumnName(this.get("ForecastDimensionSchemaName"));
					const notExistFilter = this.BPMSoft.createNotExistsFilter(this.Ext.String.format("[{0}:{1}].Id",
						this.$ForecastEntityInCellName, referenceColumnName));
					const subFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"Sheet",
						this.$ForecastId);
					notExistFilter.subFilters.addItem(subFilter);
					return notExistFilter;
				},

				/**
				 * @private
				 */
				_getReferenceColumnName: function(referenceSchemaName) {
					const entitySchema = this.BPMSoft[this.$ForecastEntityInCellName];
					if (this.isEmpty(entitySchema)) {
						return;
					}
					const column = this.BPMSoft.findWhere(entitySchema.columns, {
						referenceSchemaName: referenceSchemaName,
						isInherited: false
					});
					return column.name;
				},

				/**
				 * Returns record information.
				 * @param {Object} The current record.
				 * @return {Object} The record information.
				 * @private
				 */
				_getRecordInfo: function(currentRecord) {
					var recordInfo;
					var displayName = currentRecord ? currentRecord.get("Name") : "";
					if (this.getIsFeatureEnabled("ForecastV2")) {
						recordInfo = {
							entitySchemaName: "ForecastRow",
							primaryColumnValue: currentRecord.get("RowId"),
							primaryDisplayColumnValue: displayName
						};
					} else {
						recordInfo = {
							entitySchemaName: this.entitySchema.name,
							entitySchemaCaption: this.entitySchema.caption,
							primaryColumnValue: currentRecord.get("Id"),
							primaryDisplayColumnValue: displayName
						};
					}
					return recordInfo;
				},

				/**
				 * @private
				 */
				_getCurrentPeriods: function() {
					const columnCaptions = this.get("ColumnCaptionsCollection");
					const periodGroups = this.BPMSoft.groupBy(columnCaptions, function(item) {
						return item.PeriodId;
					});
					return this.BPMSoft.map(periodGroups, function(item, periodId) {
						return periodId;
					});
				},

				/**
				 * @private
				 */
				_getHistoryForecastModuleId: function() {
					return this.sandbox.id + "_HistoryForecastModule";
				},

				/**
				 * @private
				 */
				_getForecastAngModuleId: function() {
					return this.sandbox.id + "_ForecastAngularModule";
				},

				_getSnapshotDatePickerModule: function() {
					return this.sandbox.id + "_DatePickerFilterModule";
				},

				/**
				 * @private
				 */
				_setIsCalculationInfoVisible: function() {
					this.$IsCalculationInfoVisible = this.BPMSoft.Features
						.getIsEnabled("ForecastAutoCalculation");
				},

				/**
				 * @private
				 */
				_deleteForecastItem: function(itemId) {
					const config = {
						serviceName: "forecast.api",
						methodName: "forecast/row/delete",
						data: {
							recordId: itemId,
							forecastId: this.$ForecastId
						}
					};
					this.showBodyMask();
					this.callService(config, this.handleDeleteResponse, this);
				},

				/**
				 * @private
				 */
				_handleDeleteRecordAction: function(rowActionData) {
					const confirmationMessage =
						this.Ext.String.format(this.get("Resources.Strings.DeleteConfirmationMessage"),
							rowActionData.name);
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
								this._deleteForecastItem(rowActionData.recordId);
							}
						},
						[
							this.BPMSoft.MessageBoxButtons.NO.returnCode,
							this.BPMSoft.MessageBoxButtons.YES.returnCode
						]);
				},

				/**
				 * @private
				 */
				_handleSetupRowRightsAction: function(rowActionData) {
					const recordId = rowActionData.recordId;
					const esq = this.getForecastEntityInCellEsq(recordId);
					esq.getEntityCollection(function(response) {
						if (this.validateResponse(response)) {
							const forecastEntityRow = response.collection.first();
							const rowId = forecastEntityRow.get("Row").value;
							const recordInfo = {
								entitySchemaName: "ForecastRow",
								primaryColumnValue: rowId,
								primaryDisplayColumnValue: rowActionData.name
							};
							this.openEditRowRightsPage(recordInfo);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_getFeatureState: function() {
					const settingExists = this.isNotEmpty(this.get("Setting"));
					return this.BPMSoft.Features.getIsEnabled("ForecastUIV2") && settingExists;
				},

				/**
				 * @private
				 */
				_getIsFullscreenModeAvailable: function() {
					const fullscreenForecastsEnabled = this.BPMSoft.Features.getIsEnabled("FullscreenForecasts");
					return this.$ForecastUIV2FeatureEnabled && fullscreenForecastsEnabled;
				},


				/**
				 * @private
				 */
				_getForecastSchemaName: function() {
					if (this.BPMSoft.Features.getIsEnabled("ForecastV2")) {
						return "ForecastSheet";
					} else {
						return "Forecast";
					}
				},

				/**
				 * @private
				 */
				_initForecastEntityInCell: function(uId, callback) {
					this.BPMSoft.EntitySchemaManager.findItemByUId(uId.toLowerCase(), function(schema) {
						this.set("ForecastEntityInCellName", schema.name);
						this.BPMSoft.require([schema.name], function(schema) {
							this.entitySchema = schema;
							this.mixins.LookupMultiAddMixin.init.call(this);
							this.Ext.callback(callback, this);
						}, this);
					}, this);
				},

				/**
				 * @private
				 */
				_handleSnapshotChanged: function(date) {
					if (!this.$ForecastUIV2FeatureEnabled || !this.$IsForecastSnapshotFeatureEnabled) {
						return;
					}
					if (!date) {
						this.unloadHistoryForecastModule();
						if (!this.$ForecastAngModuleLoaded) {
							this._loadForecastAngModule();
						}
					} else {
						this.set("SnapshotId", this._getSnapshotId(date));
						this.unloadForecastModule();
						if (this.$HistoryForecastModuleLoaded) {
							this._publishRefreshHistoryForecast();
						} else {
							this._loadHistoryForecastModule();
						}
					}
					this.set("AddButtonEnabled", this.$HasAddButtonRights && this.$ForecastAngModuleLoaded);
					this.set("CalculateButtonVisible", this.$ForecastUIV2FeatureEnabled && this.$ForecastAngModuleLoaded);
					if (this.get("CalculateButtonVisible")) {
						this._addCalculationTimerComponent();
					}
				},

				/**
				 * @private
				 */
				_getSnapshotId: function(date) {
					var foundSnapshot;
					this.$Snapshots.forEach(function(snapshot) {
						if (this._checkDateEquals(snapshot, date)) {
							foundSnapshot = snapshot;
						}
					}, this);
					return foundSnapshot && foundSnapshot.snapshotId;
				},

				/**
				 * @private
				 */
				_checkDateEquals: function(snapshot, compareDate) {
					const convertedDate = snapshot.date.split(' ')[0];
					return this.BPMSoft.areDatesEqual(new Date(convertedDate), compareDate);
				},

				/**
				 * @private
				 */
				_loadHistoryForecastModule: function() {
					this._loadForecastModule("HistoryForecastModule", "HistoryForecastModuleLoaded");
				},

				/**
				 * @private
				 */
				_loadForecastAngModule: function() {
					this._loadForecastModule("ForecastAngularModule", "ForecastAngModuleLoaded");

				},

				/**
				 * @private
				 */
				_loadForecastModule(moduleName, flagName) {
					this.BPMSoft.require([moduleName], function() {
						this.sandbox.loadModule(moduleName, {
							renderTo: "ForecastApp"
						});
					}, this);
					if (flagName) {
						this.set(flagName, true);
					}
				},

				/**
				 * @private
				 */
				_unloadModule(moduleId, flagName) {
					this.sandbox.unloadModule(moduleId);
					this.set(flagName, false);
				},

				/**
				 * @private
				 */
				_loadDatePickerModule() {
					this.BPMSoft.require(["DatePickerFilterModule"], function() {
						this._loadDatePickerFilterModule("DatePickerFilterModuleLoaded");
					}, this);
				},

				/**
				 * @private
				 */
				_loadDatePickerFilterModule: function(flagName) {
					this.sandbox.loadModule("DatePickerFilterModule", {
						renderTo: "forecastDatetimeFilter"
					});
					if (flagName) {
						this.set(flagName, true);
					}
				},

				/**
				 * @private
				 */
				_addGTMForDatepickerClick: function() {
					var data = this._getGoogleTagManagerData(ForecastConstants.GTMEventActions.ForecastDatepickerClick);
					GoogleTagManagerUtilities.actionModule(data);
				},

				/**
				 * @private
				 */
				_getGoogleTagManagerData: function(action) {
					return {
						action: action,
						moduleName: "ForecastsModule",
						schemaName: "ForecastSheet"
					};
				},

				/**
				 * ##### ######### ###### # ####, ####### ########## ############# ##### ######## ###########
				 * # ########## ### # ####### #####.
				 * @private
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####,
				 * ### ######### ######.
				 * @deprecated
				 */
				getSchemaDimension: function(callback) {
					var forecastId = this.get("ForecastId");
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Dimension"
					});
					select.addColumn("EntitySchemaUId", "EntitySchemaUId");
					var levelColumn = select.addColumn("[ForecastDimension:Dimension:Id].Level");
					levelColumn.orderPosition = 1;
					levelColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
					select.addColumn("[ForecastDimension:Dimension:Id].Id", "ForecastDimensionId");
					select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "[ForecastDimension:Dimension:Id].Forecast", forecastId));
					select.rowCount = 1;
					select.getEntityCollection(function(response) {
						if (response.success) {
							var collection = response.collection;
							if (collection && collection.getCount() > 0) {
								var item = collection.getItems()[0];
								if (item) {
									this.set("EntitySchemaUId", item.get("EntitySchemaUId"));
									this.set("ForecastDimensionId", item.get("ForecastDimensionId"));
								}
								if (callback) {
									callback.call(this);
								}
							}
						}
					}, this);
				},

				/**
				 * ##### ######### ###### # ####, ####### ########## ############ ########### ######## ###########
				 * # ########## ### # ####### #####.
				 * @private
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####,
				 * ### ######### ######.
				 * @deprecated
				 */
				getLookupSchema: function(callback) {
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysSchema"
					});
					select.addColumn("Name");
					select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "UId", this.get("EntitySchemaUId")));
					select.rowCount = 1;
					select.getEntityCollection(function(response) {
						if (response.success) {
							var collection = response.collection;
							if (collection) {
								var item = collection.getItems()[0];
								if (item) {
									this.set("ForecastDimensionSchemaName", item.get("Name"));
								}
								if (callback) {
									callback.call(this);
								}
							}
						}
					}, this);
				},

				/**
				 * ##### ######### ## ########## ###### # ########### ###### ### ##########.
				 * @private
				 * @param {Object} result ######### ###### ## ###########.
				 */
				onChooseDimension: function(result) {
					var listDimension = this.getExistListDimension();
					var listToAddDimension = [];
					if (result && result.selectedRows) {
						var collection = result.selectedRows.getItems();
						BPMSoft.each(collection, function(item) {
							var id = item.Id;
							if (listDimension.indexOf(id) === -1) {
								listToAddDimension.push(item);
							}
						}, this);
					}
					if (this.getIsFeatureEnabled("ForecastV2")) {
						this.addNewForecastItems(listToAddDimension);
					} else {
						this.insertNewForecastItems(listToAddDimension);
					}
				},

				/**
				 * ##### ######### # ####### ####### ############ ##### ###### ## ########### #######.
				 * @private
				 * @param {Array} listToAddDimension ###### ######## ### ##########.
				 * @deprecated
				 */
				insertNewForecastItems: function(listToAddDimension) {
					var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
					var newRows = [];
					for (var i = 0; i < listToAddDimension.length; i++) {
						var item = listToAddDimension[i];
						var insertQuery = Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "ForecastItem"
						});
						var newGuid = this.BPMSoft.generateGUID();
						newRows.push(newGuid);
						insertQuery.setParameterValue("Id", newGuid, this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("DimensionValueId", item.Id, this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("Name", item.Name, this.BPMSoft.DataValueType.TEXT);
						insertQuery.setParameterValue("Forecast", this.get("ForecastId"),
							this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("ForecastDimension", this.get("ForecastDimensionId"),
							this.BPMSoft.DataValueType.GUID);
						batchQuery.add(insertQuery);
					}
					batchQuery.execute(function() {
						this.requestNewForecastRows(newRows, this.getNewRowsResponse);
					}, this);
				},

				/**
				 * ##### ######### # #### ##### ######.
				 * @param {Object} rows ######### ########### #########.
				 * @private
				 */
				addGridRows: function(rows) {
					var collection = this.getGridData();
					if (collection && collection.getCount() === 0) {
						collection.loadAll(rows);
					} else {
						for (var propertyName in rows) {
							if (!rows.hasOwnProperty(propertyName)) {
								continue;
							}
							var newRow = rows[propertyName];
							if (!collection.contains(propertyName)) {
								collection.add(propertyName, newRow);
							}
						}
					}
				},

				/*
				 * ####### ########## ###### ############ ######### # ############.
				 * @private
				 */
				getExistListDimension: function() {
					var listDimension = [];
					var forecastGridRows = this.model.get("ForecastGridRows");
					this.BPMSoft.each(forecastGridRows, function(item) {
						listDimension.push(item.get("DimensionValueId"));
					}, this);
					return listDimension;
				},

				/**
				 * ########## ####### ####### ###### Tab.
				 * @private
				 */
				onTabKeyPressed: function() {
					this.saveAndUnfocusActiveCell();
				},

				/**
				 * ########## ###### ############### ########, ######### # ###### ##########.
				 * @private
				 * @return {Array} ############## ######.
				 */
				getFilterPeriodsArray: function() {
					var filterPeriods = this.get("FilterPeriods");
					var filters = [];
					this.BPMSoft.each(filterPeriods, function(periodItem) {
						filters.push(periodItem.Id);
					}, this);
					return filters;
				},

				/**
				 * ##### ############## ##### ####### ######### ##### ## ######## ############, ###########
				 * ## ###### #######, # ######### ### # #########. ########## ############## ####### #########.
				 * @private
				 * @param {BPMSoft.BaseViewModelCollection} rowsCollection ######### #####.
				 * @param {Object} responseItem ####### ############, ########## # ########## #######.
				 * @return {BPMSoft.BaseViewModel} ####### #########.
				 */
				addNewCollectionItem: function(rowsCollection, responseItem, additionalProperties) {
					var values = {
						"Id": responseItem.Id,
						"DimensionValueId": responseItem.DimensionValueId,
						"Name": responseItem.Name,
						"Forecast": this.get("ForecastId"),
						"Parent": responseItem.ParentId,
						"Enabled": responseItem.CanEdit
					};
					if (additionalProperties && !this.Ext.isEmpty(additionalProperties.values)) {
						this.Ext.merge(values, additionalProperties.values);
					}
					var newItem = rowsCollection.createItem(values);
					newItem.columns = {
						"Id": {
							columnPath: "Id",
							dataValueType: this.BPMSoft.DataValueType.GUID,
							type: 0
						},
						"Name": {
							columnPath: "Name",
							dataValueType: this.BPMSoft.DataValueType.TEXT,
							type: 0
						}
					};
					if (additionalProperties && !this.Ext.isEmpty(additionalProperties.columns)) {
						this.Ext.merge(newItem.columns, additionalProperties.columns);
					}
					rowsCollection.add(responseItem.Id, newItem);
					return newItem;
				},

				// endregion

				// region Methods: Protected

				/**
				 * @inheritdoc BaseSchemaViewModel#onRender
				 * @overridden
				 */
				onRender: function() {
					this.BPMSoft.chain(
						function(next) {
							if (this.getIsFeatureEnabled("ForecastV2")) {
								if (this.$ForecastUIV2FeatureEnabled && !this.$ForecastAngModuleLoaded) {
									this._loadForecastAngModule();
								}
								this.Ext.callback(next, this);
							} else {
								this.getSchemaDimension(function() {
									this.getLookupSchema(next);
								});
							}
							if (this.$IsForecastSnapshotFeatureEnabled && !this.$DatePickerFilterModuleLoaded) {
								this._loadDatePickerModule();
							}
						},
						function() {
							this.set("IsDimensionDataLoaded", true);
							this.selectForecastPeriodType(this.loadGridDataView);
							this._addCalculationTimerComponent();
						},
						this
					);
					this.callParent(arguments);
					this.set("ForecastTabRendered", true);
				},

				/**
				 * @inheritdoc ConfigurationGridUtilities#initActiveRowKeyMap
				 * @overridden
				 */
				initActiveRowKeyMap: function(keyMap) {
					this.mixins.ConfigurationGridUtilites.initActiveRowKeyMap.call(this, keyMap);
					keyMap.push({
						key: Ext.EventObject.ENTER,
						ctrl: false,
						defaultEventAction: "preventDefault",
						fn: this.onEnterKeyPressed,
						scope: this
					});
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getActiveRow
				 * @overridden
				 * @return {object}
				 */
				getActiveRow: function() {
					var activeRow = null;
					var primaryColumnValue = this.get("ActiveRow");
					if (primaryColumnValue) {
						var gridData = this.getGridData();
						activeRow = gridData.find(primaryColumnValue) ? gridData.get(primaryColumnValue) : null;
					}
					return activeRow;
				},

				/**
				 * ########## #### #######.
				 * @protected
				 * @override
				 * @return {String} ####.
				 */
				getProfileKey: function() {
					return "ForecastProfile";
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#getMultiSelectLookupConfig
				 * @override
				 */
				getMultiSelectLookupConfig: function() {
					return {
						rootEntitySchemaName: "ForecastSheet",
						rootColumnName: "Sheet",
						relatedEntitySchemaName: this.$ForecastDimensionSchemaName,
						relatedColumnName: this._getReferencedColumnName(this.$ForecastDimensionSchemaName)
					};
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#getLookupSchemaName
				 * @override
				 */
				getLookupSchemaName: function() {
					return this.$ForecastEntityInCellName;
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#getMasterRecordId
				 * @override
				 */
				getMasterRecordId: function() {
					return this.$ForecastId;
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#handleSuccessAddRecords
				 * @override
				 */
				handleSuccessAddRecords: function() {
					this._publishRefreshForecast();
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#handleAfterInserted
				 * @override
				 */
				handleAfterInserted: function(response) {
					if (this.getIsFeatureDisabled("ForecastGroupEdit")) {
						this.hideBodyMask();
						this._publishRefreshForecast();
						return;
					}
					if (this.Ext.isEmpty(response) || !response.success) {
						this.hideBodyMask();
						return;
					}
					const recordIds = [];
					this.selectedRows.forEach(function(item) {
						recordIds.push(item.value);
					});
					const config = {
						serviceName: "forecast.api",
						methodName: "forecast/recalcgroupcells",
						data: {
							forecastId: this.$ForecastId,
							recordIds: recordIds
						}
					};
					this.callService(config, function() {
						this.hideBodyMask();
						this._publishRefreshForecast();
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#createAlreadyAddedRecordsFilter
				 * @override
				 */
				createAlreadyAddedRecordsFilter: function() {
					return this._getAlreadyAddedItemsFilter();
				},

				/**
				 * @inheritdoc BPMSoft.LookupMultiAddMixin#getAllLookupFilters
				 * @override
				 */
				getAllLookupFilters: function() {
					const filterGroup = this.mixins.LookupMultiAddMixin.getAllLookupFilters.apply(this, arguments);
					if (this.$ForecastDimensionSchemaName === "Contact") {
						const sysAdminUnitFilter = this.BPMSoft.createColumnIsNotNullFilter("[SysAdminUnit:Contact].Id");
						filterGroup.addItem(sysAdminUnitFilter);
					}
					return filterGroup;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function(callback, scope) {
					const calcCaption = "CalculateFactPotentialCaption";
					const resourcePrefix = "Resources.Strings.";
					this.set(calcCaption,
						this.get(resourcePrefix + "CalculateFactPotentialCaption"));
					if (this.getIsFeatureEnabled("ForecastUIV2")) {
						this.set(calcCaption,
							this.get(resourcePrefix + "CalculateFactPotentialCaptionUIV2"));
					}
					this.set("CalculateButtonCaption", this.get(resourcePrefix + "Calculate"));
					var initForecastsFn = this.initForecasts.bind(this, callback, scope);
					this.sandbox.subscribe("UpdateForecast", this.handleForecastChanged, this, [this.sandbox.id]);
					this.sandbox.subscribe("InitDataViews", function(args) {
						this.updateSetupColumnsHeader(args.caption)
					}, this);
					this.callParent([initForecastsFn, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#destroy
				 * @override
				 */
				destroy: function() {
					this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE, this.onMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * Inserts selected items to current forecast entity table.
				 * @protected
				 * @param {Array} listToAddDimension List of selected items.
				 */
				addNewForecastItems: function(listToAddDimension) {
					const batchQuery = this.Ext.create("BPMSoft.BatchQuery");
					const newRows = [];
					const referencedColumnName = this._getReferencedColumnName(this.$ForecastDimensionSchemaName);
					for (let i = 0; i < listToAddDimension.length; i++) {
						const forecastRowId = BPMSoft.generateGUID();
						const forecastRowInsert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "ForecastRow"
						});
						forecastRowInsert.setParameterValue("Id", forecastRowId, this.BPMSoft.DataValueType.GUID);
						batchQuery.add(forecastRowInsert);
						const item = listToAddDimension[i];
						const insertQuery = Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: this.$ForecastEntityInCellName
						});
						const newGuid = this.BPMSoft.generateGUID();
						newRows.push(newGuid);
						insertQuery.setParameterValue("Id", newGuid, this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue(referencedColumnName, item.Id, this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("Sheet", this.$ForecastId, this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("Row", forecastRowId, this.BPMSoft.DataValueType.GUID);
						batchQuery.add(insertQuery);
					}
					batchQuery.execute(function() {
						if (this.$ForecastUIV2FeatureEnabled) {
							this._publishRefreshForecast();
							return;
						}
						this.requestNewForecastRows(newRows, this.getForecastResponse);
					}, this);
				},

				/**
				 * ########## ####### ## ###### ######## ## ######## ############.
				 * @protected
				 */
				onAddButtonClick: function() {
					this.onMultiAddButtonClick();
				},

				/**
				 * Show message after start calculation.
				 * @param {Object} Server response.
				 * @protected
				 */
				calculateFactCallback: function(response) {
					const resourcePrefix = "Resources.Strings.";
					let message = this.get(resourcePrefix + "CalculateFactPotentialCompleteMessage");
					const result = response && response.RecalculateFactResult;
					if (result && result.success) {
						if (this.getIsFeatureEnabled("ForecastUIV2")) {
							message = this.get(resourcePrefix + "CalculateFactPotentialCompleteMessageUIV2");
						}
					} else {
						message = result.errorInfo.message;
					}
					this.showInformationDialog(message);
				},

				/**
				 * Handles websocket "UpdateForecasts" message.
				 * @protected
				 */
				handleSocketUpdateForecasts: function() {
					this._publishRefreshForecast(true);
					this.updateCalculatedStatus(function() {
						this.setCalculateButtonLocked(false);
					}, this);
				},

				/**
				 * Handles websocket "ForecastCalcStarted" message.
				 * @protected
				 */
				handleSocketForecastCalcStarted: function() {
					this.setCalculateButtonLocked(true);
					this.set("LastCalcDateTime", null);
					this.set("NextCalcDateTime", null);
				},

				/**
				 * @protected
				 */
				initForecasts: function(callback, scope) {
					this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onMessageReceived,
						this);
					this.set("Collection", this.Ext.create("BPMSoft.Collection"));
					const forecastObject = this.getForecastObject();
					this.sandbox.subscribe("GetForecastConfig",
						this.getForecastConfig, this, [this._getForecastAngModuleId(), this._getHistoryForecastModuleId()]);
					this.sandbox.subscribe("RowActionClick", this.handleRowActionClicked, this,
						[this._getForecastAngModuleId()]);
					this.sandbox.subscribe("SnapshotDateChanged", this.handleSnapshotDateChanged, this,
						[this._getSnapshotDatePickerModule()]);
					this.sandbox.subscribe("ValidateDate", this.hasSnapshotOnDate, this,
						[this._getSnapshotDatePickerModule()]);
					this.sandbox.subscribe("ShowDrilldownSetupColumns", this.showDrilldownSetupColumns, this,
						[this._getForecastAngModuleId(), this._getHistoryForecastModuleId()]);
					this.sandbox.subscribe("CellSelected", this.setupForecastColumnSchemaData, this,
						[this._getForecastAngModuleId(), this._getHistoryForecastModuleId()]);
					const forecastId = forecastObject.forecastId;
					if (this.Ext.isEmpty(forecastId)) {
						return;
					}
					this.set("ForecastId", forecastId);
					this.set("NeedReload", false);
					this.updateCalculatedStatus();
					const profile = this.getProfile();
					if (profile && forecastId) {
						const forecastProfile = profile[forecastId];
						if (forecastProfile && forecastProfile.filters) {
							this.set("FilterCaption", forecastProfile.filters.filterCaption);
							this.set("FilterPeriods", forecastProfile.filters.filterPeriods);
						}
					}
					const checkRightsFunc = this.checkForecastCanEditRights.bind(this, callback, scope);
					if (this.getIsFeatureEnabled("ForecastV2")) {
						this.set("EntitySchemaUId", forecastObject.forecastEntityId);
						this._setIsCalculationInfoVisible();
						this.set("Setting", forecastObject.forecastSetting);
						this.set("ForecastDimensionSchemaName", forecastObject.forecastEntityName);
						this._initForecastEntityInCell(
							forecastObject.forecastForecastEntityInCellUId,
							checkRightsFunc);
					} else {
						this.entitySchema = ForecastItem;
						this.Ext.callback(checkRightsFunc, scope);
					}
					this.$ForecastUIV2FeatureEnabled = this._getFeatureState();
					this.$FullscreenForecastsEnabled = this._getIsFullscreenModeAvailable();
					this.set("CalculateButtonVisible", this.$ForecastUIV2FeatureEnabled);
					if (scope) {
						const customActions = this._getCustomActions(scope.viewConfig);
						this.$HasCustomActions = (customActions.length > 0 && this.$ForecastUIV2FeatureEnabled) ||
							!this.$ForecastUIV2FeatureEnabled;
					}
					this.loadSnapshots();
				},

				/**
				 * Get config for current forecast page
				 * @protected
				 * @return {Object} Forecast page info config.
				 */
				getForecastObject: function() {
					return this.sandbox.publish("GetForecastInfo", null, [this.sandbox.id]);
				},

				/**
				 * Forms entity schema query for entity forecast cell.
				 * @protected
				 * @virtual
				 * @param {String} recordId Entity identifier.
				 * @return {BPMSoft.EntitySchemaQuery} Entity schema query for entity forecast cell.
				 */
				getForecastEntityInCellEsq: function(recordId) {
					const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.$ForecastEntityInCellName,
						rowCount: 1
					});
					esq.addColumn("Row");
					const forecastObject = this.getForecastObject();
					const columnName = this._getReferenceColumnName(forecastObject.forecastEntityName);
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, columnName, recordId));
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Sheet", this.get("ForecastId")));
					esq.filters.addItem(this.BPMSoft.createIsNullFilter(
						this.Ext.create("BPMSoft.ColumnExpression", {columnPath: "ForecastColumn"})));
					return esq;
				},

				/**
				 * ##### ######### ###### # ####, ####### ########## ### ######## ############ # ########## ###
				 * # ####### #####.
				 * @protected
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####,
				 * ### ######### ######.
				 */
				selectForecastPeriodType: function(callback) {
					var forecastId = this.get("ForecastId");
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this._getForecastSchemaName()
					});
					select.addColumn("Id");
					select.addColumn("Name");
					select.addColumn("PeriodType");
					select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", forecastId));
					select.getEntityCollection(function(response) {
						if (response.success) {
							var responseItems = response.collection.getItems();
							this.set("ForecastPeriodType", responseItems[0].get("PeriodType"));
							if (callback) {
								callback.call(this);
							}
						}
					}, this);
				},

				/**
				 * ######## ######### ###### #######.
				 * @protected
				 */
				getGridData: function() {
					return this.get("Collection");
				},

				/**
				 * ########## ###### ############.
				 * @protected
				 * @return {*|Component}
				 */
				getCurrentGrid: function() {
					return this.Ext.getCmp("ForecastGridId");
				},

				/**
				 * ####### ######### ######## ###### ####### ############.
				 * @protected
				 */
				deactivateGridActiveCell: function() {
					var grid = this.getCurrentGrid();
					if (grid) {
						grid.deactivateActiveCell();
					}
				},

				/**
				 * ####### ######### ####### ###### # ######### ## ######.
				 * @protected
				 */
				saveAndUnfocusActiveCell: function() {
					var activeRow = this.getActiveRow();
					this.unfocusRowControls(activeRow);
					this.saveForecastCellChanges();
					this.deactivateGridActiveCell();
				},

				/**
				 * @inheritdoc ConfigurationGridUtilities#onEnterKeyPressed
				 * @overridden
				 */
				onEnterKeyPressed: function() {
					this.saveAndUnfocusActiveCell();
				},

				/**
				 * @inheritdoc ConfigurationGridUtilities#onCtrlEnterKeyPressed
				 * @overridden
				 */
				onCtrlEnterKeyPressed: this.Ext.emptyFn,

				/**
				 * ##### ######### ######## #### ####### ## ############## #####.
				 * @protected
				 * @param {Function} callback #######, ####### ########## ##### ######### ########### #######.
				 * @param {Object} scope ######## ##########.
				 */
				checkForecastCanEditRights: function(callback, scope) {
					RightUtilities.checkCanEdit({
						schemaName: this._getForecastSchemaName(),
						primaryColumnValue: this.get("ForecastId")
					}, function(result) {
						const isEnabled = Ext.isEmpty(result);
						this.set("HasAddButtonRights", isEnabled)
						this.set("AddButtonEnabled", isEnabled);
						this.set("CalculateFactEnabled", isEnabled);
						this.set("CanShowColumnsList", isEnabled);
						callback.call(scope);
					}, this);
				},

				/**
				 * ######### ######## ############# #######.
				 * @protected
				 */
				loadGridDataView: function() {
					this.initGridColumnsConfig();
					this.loadData();
				},

				/**
				 * ############## ############ ####### # ########## #######.
				 * @protected
				 */
				initGridColumnsConfig: function() {
					var grid = this.getCurrentGrid();
					if (!grid) {
						return;
					}
					var columnsConfig = [{
						"cols": 20,
						"key": [{"name": {"bindTo": "Name"}}],
						"readOnly": true
					}];
					var rowsCaptionsColumnsConfig = [{
						"cols": 0,
						"key": [{"name": {"bindTo": "Name"}}]
					}];
					grid.captionsConfig = [];
					grid.columnsConfig = columnsConfig;
					grid.rowsCaptionsColumnsConfig = rowsCaptionsColumnsConfig;
				},

				/**
				 * ######## ############# ####### # ############ # ##### ############# #######.
				 * @protected
				 */
				initGridBindings: function() {
					var grid = this.getCurrentGrid();
					if (!grid) {
						return;
					}
					var gridListedConfig = {
						columnsConfig: grid.columnsConfig,
						captionsConfig: grid.captionsConfig
					};
					grid.listedConfig = gridListedConfig;
					grid.initBindings(gridListedConfig);
				},

				/**
				 * ######## ## web-####### ##### ######### ###### ## ######## ############.
				 * @protected
				 * @param {Function} callback #######, ####### ########## ##### ######### ########## #######.
				 */
				requestForecastValues: function(callback) {
					this.showBodyMask();
					var filters = this.getFilterPeriodsArray();
					var dataSend = {
						forecastId: this.get("ForecastId"),
						periods: filters
					};
					var config = {
						serviceName: "ForecastService",
						methodName: "GetForecastData",
						data: dataSend
					};
					this.callService(config, callback, this);
				},

				/**
				 * ######## ## web-####### ##### ######### ########### #####.
				 * @protected
				 * @param {Array} rows ###### ############### ##### ##### ####### ############.
				 * @param {Function} callback #######, ####### ########## ##### ######### ########## #######.
				 */
				requestNewForecastRows: function(rows, callback) {
					this.showBodyMask();
					const filters = this.getFilterPeriodsArray();
					const dataSend = {
						forecastId: this.get("ForecastId"),
						periods: filters,
						rows: rows
					};
					const config = {
						serviceName: "ForecastService",
						data: dataSend
					};
					if (BPMSoft.Features.getIsEnabled("ForecastV2")) {
						config.methodName = "GetForecastData";
					} else {
						config.methodName = "GetForecastNewRows";
					}
					this.callService(config, callback, this);
				},

				/**
				 * ######## ######### ####### ## ###### # ####### ######## ############.
				 * @protected
				 * @param {Object} response ######, ########## ##### #######.
				 */
				getForecastResponse: function(response) {
					this.set("NeedReload", false);
					if (response && response.GetForecastDataResult.Success) {
						var rows = this.getGridRowsByResponse(response.GetForecastDataResult.Collection);
						this.initColumnsConfigsByResponse(response.GetForecastDataResult.ColumnCaptions);
						this.initGridBindings();
						var collection = this.getGridData();
						collection.clear();
						collection.loadAll(rows);
					}
					this.hideBodyMask();
				},

				/**
				 * ######## ######### ####### ## ###### # ####### ## ########### #######. ######### ###### # ######.
				 * @protected
				 * @param {Object} response ######, ########## ##### #######.
				 */
				getNewRowsResponse: function(response) {
					if (response && response.GetForecastNewRowsResult.Success) {
						var rows = this.getGridRowsByResponse(response.GetForecastNewRowsResult.Collection);
						this.addGridRows(rows);
					}
					this.hideBodyMask();
				},

				/**
				 * ##### ######### ############ ##### ####### ## ########### ####### ## ###### # #########
				 * ####### ############ #######. ########## ##### ######.
				 * @protected
				 * @param {Object} responseCollection ######### ######### ############, ########## # ########## #######.
				 * @return {Object} ############ ##### #######.
				 */
				getGridRowsByResponse: function(responseCollection) {
					var rows = {};
					var rowsCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.BPMSoft.each(responseCollection, function(item) {
						var forecastValues = item.ForecastItemValues;
						var summary = {
							"Plan": 0,
							"Fact": 0,
							"Potential": 0
						};
						var newItemProperties = {
							"values": {},
							"columns": {}
						};
						this.BPMSoft.each(forecastValues, function(valueItem) {
							var currentPeriodId = valueItem.PeriodId;
							var currentIndicatorCode = valueItem.ForecastIndicatorCode;
							summary[currentIndicatorCode] += valueItem.Value;
							var columnName = currentIndicatorCode + currentPeriodId;
							let value = valueItem.Value;
							if (this.getIsFeatureEnabled("ForecastV2") && currentIndicatorCode === "FactPercent") {
								const plan = this._getCellValueByIndicatorAndPeriod(
									forecastValues, "Plan", currentPeriodId);
								const fact = this._getCellValueByIndicatorAndPeriod(
									forecastValues, "Fact", currentPeriodId);
								value = plan > 0 ? fact * 100 / plan : 0;
							}
							newItemProperties.values[columnName] = value;
							newItemProperties.columns[columnName] = {
								"columnPath": columnName,
								"name": columnName,
								"dataValueType": this.BPMSoft.DataValueType.INTEGER,
								"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
								"caption": valueItem.ForecastIndicatorCode + valueItem.PeriodName
							};
							newItemProperties.columns[columnName].forecastItemValueId = valueItem.Id;
							newItemProperties.columns[columnName].itemPreviousValue = valueItem.Value;
						}, this);
						var newItem = this.addNewCollectionItem(rowsCollection, item, newItemProperties);
						this.Ext.merge(this.entitySchema.columns, newItem.columns);
						newItem.set("RowId", item.RowId);
						this.setSummary(newItem, {silent: true});
						rows[item.Id] = newItem;
					}, this);
					this.Ext.merge(this.columns, this.entitySchema.columns);
					var allRows = this.get("ForecastGridRows") || {};
					this.Ext.merge(allRows, rows);
					this.set("ForecastGridRows", allRows);
					return rows;
				},

				/**
				 * ##### ######### ######### ############ ########## ### ##### ######.
				 * @protected
				 * @param {Object} captionConfig ############ #######.
				 * @param {Array} summaryColumnCaptions ############## ###### ######## ####### ######.
				 */
				fillSummaryColumnCaptions: function(captionConfig, summaryColumnCaptions) {
					switch (captionConfig.tag) {
						case "Plan":
							summaryColumnCaptions.push({
								"cols": 96,
								"key": [{"name": {"bindTo": "SummaryPlan"}}],
								"readOnly": true
							});
							break;
						case "Potential":
							summaryColumnCaptions.push({
								"cols": 96,
								"key": [{"name": {"bindTo": "SummaryPotential"}}],
								"readOnly": true
							});
							break;
						case "Fact":
							summaryColumnCaptions.push({
								"cols": 96,
								"key": [{"name": {"bindTo": "SummaryFact"}}],
								"readOnly": true
							});
							break;
						case "FactPercent":
							summaryColumnCaptions.push({
								"cols": 96,
								"key": [{"name": {"bindTo": "SummaryFactPercent"}}],
								"readOnly": true
							});
							break;
					}
				},

				/**
				 * ##### ####### ############ ####### # ########## ## ########### #######. ########### ##############
				 * ################ ######.
				 * @protected
				 * @param {Object} columnCaptionsResponse ###### ###### ####### # ####### ## ########.
				 */
				initColumnsConfigsByResponse: function(columnCaptionsResponse) {
					this.set("ColumnCaptionsCollection", columnCaptionsResponse);
					var grid = this.getCurrentGrid();
					var captionsConfig = [];
					var columnsConfig = [{
						"cols": 20,
						"key": [{"name": {"bindTo": "Name"}}],
						"readOnly": true
					}];
					if (this.Ext.isEmpty(columnCaptionsResponse) ||
						(columnCaptionsResponse && columnCaptionsResponse.length === 0)) {
						grid.captionsConfig = captionsConfig;
						grid.columnsConfig = columnsConfig;
						return;
					}
					var currentPeriodId = null;
					var currentCaptionsGroup = null;
					this.BPMSoft.each(columnCaptionsResponse, function(columnCaption) {
						columnsConfig.push({
							"cols": 96,
							"key": [{"name": {"bindTo": columnCaption.ColumnName}}],
							"readOnly": columnCaption.IndicatorCode !== "Plan"
						});
						if (currentPeriodId !== columnCaption.PeriodId) {
							if (currentCaptionsGroup) {
								captionsConfig.push(currentCaptionsGroup);
							}
							currentCaptionsGroup = {
								"name": columnCaption.PeriodName,
								"children": []
							};
						}
						currentCaptionsGroup.children.push({
							"cols": 96,
							"name": columnCaption.IndicatorName,
							"tag": columnCaption.IndicatorCode
						});
						currentPeriodId = columnCaption.PeriodId;
					}, this);
					captionsConfig.push(currentCaptionsGroup);
					var summaryConfig = {
						name: resources.localizableStrings.Summary,
						children: this.BPMSoft.deepClone(captionsConfig[0].children)
					};
					var summaryColumnCaptions = [];
					var childrenItems = summaryConfig.children;
					this.BPMSoft.each(childrenItems, function(item) {
						this.fillSummaryColumnCaptions(item, summaryColumnCaptions);
					}, this);
					columnsConfig = columnsConfig.concat(summaryColumnCaptions);
					captionsConfig.push(summaryConfig);
					grid.captionsConfig = captionsConfig;
					grid.columnsConfig = columnsConfig;
				},

				/**
				 * ######### ######### ######## ####### ###### ####### ############.
				 * @protected
				 */
				saveForecastCellChanges: function() {
					var item = this.getActiveRow();
					if (!item) {
						return;
					}
					if (item.get("IsSaving")) {
						return;
					}
					this.BPMSoft.each(item.changedValues, function(value, columnId) {
						if (columnId.indexOf("Plan") !== 0) {
							return;
						}
						if (!value) {
							value = 0;
							item.set(columnId, 0);
						}
						var currentColumn = item.columns[columnId];
						if (!currentColumn) {
							return;
						}
						this.showBodyMask();
						this.setSummary(item);
						var forecastItemValueId = currentColumn.forecastItemValueId;
						currentColumn.itemPreviousValue = value;
						var valuesConfig = this.getForecastItemValuesConfig(item, value, columnId);
						var data = {
							forecastId: item.get("Forecast"),
							recordId: item.get("Id"),
							periodId: valuesConfig.periodId,
							indicatorId: valuesConfig.forecastIndicatorId,
							value: value
						};
						if (forecastItemValueId && (forecastItemValueId !== this.BPMSoft.GUID_EMPTY)) {
							item.set("IsSaving", true);
							if (this.getIsFeatureEnabled("ForecastV2")) {
								this._saveForecastCell(data, function() {
									item.set("IsSaving", false);
									this.hideBodyMask();
								});
							} else {
								this.updateForecastValue(forecastItemValueId, value, function() {
									item.set("IsSaving", false);
									this.hideBodyMask();
								});
							}
						} else {
							if (!value) {
								this.hideBodyMask();
								return;
							}
							item.set("IsSaving", true);
							if (this.getIsFeatureEnabled("ForecastV2")) {
								this._saveForecastCell(data, function() {
									item.set("IsSaving", false);
									this.hideBodyMask();
								});
							} else {
								this.insertForecastValue(valuesConfig, function(response) {
									this.hideBodyMask();
									if (response && response.InsertForecastValueResult.Success) {
										currentColumn.forecastItemValueId =
											response.InsertForecastValueResult.ForecastItemValueId;
									}
									item.set("IsSaving", false);
								});
							}
						}
					}, this);
				},

				/**
				 * Get values config for new forecast item value.
				 * @protected
				 */
				getForecastItemValuesConfig: function(item, value, columnId) {
					var planIndicatorId = ForecastConstants.Indicator.PlanIndicatorId;
					return {
						forecastIndicatorId: planIndicatorId,
						forecastItemId: item.get("Id"),
						periodId: columnId.substring(4),
						value: value
					};
				},

				/**
				 * ######## ## web-####### ##### ######### ############# ######## # ###### ############.
				 * @protected
				 * @param {GUID} forecastItemValueId ############# ######## ######## ############.
				 * @param {Float} value ##### ######## ######## ############.
				 * @param {Function} callback #######, ####### ########## ##### ######### ########## #######.
				 */
				updateForecastValue: function(forecastItemValueId, value, callback) {
					var dataSend = {
						forecastItemValueId: forecastItemValueId,
						value: value
					};
					var config = {
						serviceName: "ForecastService",
						methodName: "UpdateForecastValue",
						data: dataSend
					};
					this.callService(config, callback, this);
				},

				/**
				 * ######## ## web-####### ##### ########## ###### ######## # ####### ############.
				 * @protected
				 * @param {Object} valuesConfig ######, ########## ############## ########## ############,
				 * ######## ############, #######, # ##### ######## ######## ############.
				 * @param {Function} callback #######, ####### ########## ##### ######### ########## #######.
				 */
				insertForecastValue: function(valuesConfig, callback) {
					var dataSend = valuesConfig;
					var config = {
						serviceName: "ForecastService",
						methodName: "InsertForecastValue",
						data: dataSend
					};
					this.callService(config, callback, this);
				},

				/**
				 * ######## ######### ######## ######.
				 * @protected
				 * @param {String} id ############# ######.
				 */
				discardChanges: function(id) {
					if (!id) {
						return;
					}
					var activeRow = this.getActiveRow();
					var activeCellColumnName = this.get("ActiveCellColumnName");
					if (activeCellColumnName) {
						var oldCellValue = activeRow.columns[activeCellColumnName].itemPreviousValue;
						activeRow.set(activeCellColumnName, oldCellValue || 0);
					}
					this.deactivateGridActiveCell();
				},

				// endregion

				// region Methods: Public

				selectPeriod: function() {
					const schemaName = this._getForecastSchemaName();
					const path = Ext.String.format("[{0}:PeriodType:PeriodType].Id", schemaName);
					const forecastId = this.get("ForecastId");
					const filters = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						path, forecastId);
					const selectedRows = [];
					const periods = this.get("FilterPeriods");
					this.BPMSoft.each(periods, function(period) {
						selectedRows.push(period.value);
					}, this);
					const config = {
						entitySchemaName: "Period",
						multiSelect: true,
						columnName: "Name",
						hideActions: true,
						selectedRows: selectedRows,
						filters: filters,
						sortedColumns: [{
							name: "StartDate",
							orderPosition: 2,
							orderDirection: this.BPMSoft.core.enums.OrderDirection.ASC
						}]
					};
					this.openLookup(config, this.setFilterPeriod, this);
				},

				setFilterPeriod: function(result) {
					let items = null;
					let caption = "";
					if (result && result.selectedRows) {
						items = [];
						result.selectedRows.each(function(item) {
							items.push(item);
							caption += item.displayValue + ", ";
						}, this);
					}
					caption = caption.slice(0, -2);
					let filterPeriods = items;
					if (items.length > this.maxPeriodsCount) {
						filterPeriods = items.slice(0, this.maxPeriodsCount);
						const message = Ext.String.format(
							this.get("Resources.Strings.OnlyFirstNItems"),
							this.maxPeriodsCount);
						this.showInformationDialog(message);
					}
					this.set("FilterCaption", caption);
					this.set("FilterPeriods", filterPeriods);
					this.saveForecastProfile();
					this._publishRefreshForecastColumns();
					this.loadData();
				},

				getFilterVisible: function() {
					return !this.Ext.isEmpty(this.get("FilterPeriods"));
				},

				resetFilter: function() {
					this.set("FilterPeriods", null);
					this.saveForecastProfile();
				},

				saveForecastProfile: function() {
					let profile = this.getProfile();
					const profileKey = this.getProfileKey();
					if (this.BPMSoft.isEmptyObject(profile)) {
						profile = {key: profileKey};
					}
					const filterPeriods = this.get("FilterPeriods");
					const filterCaption = this.get("FilterCaption");
					const filters = {
						filterPeriods: filterPeriods,
						filterCaption: filterCaption
					};
					const forecastId = this.get("ForecastId");
					profile[forecastId] = {filters: filters};
					this.BPMSoft.utils.saveUserProfile(profileKey, profile, false);
					this.set("Profile", profile);
				},

				/**
				 * Handles multi adding button click.
				 */
				onMultiAddButtonClick: function() {
					this.openLookupWithMultiSelect();
				},

				/**
				 * ############ ####### "########" ######## ######.
				 * @param {String} buttonTag ### "########".
				 * @param {GUID} primaryColumnValue id ######## ######.
				 */
				onActiveRowAction: function(buttonTag, primaryColumnValue) {
					if (buttonTag === "editRight") {
						this.editRights(primaryColumnValue);
					}
				},

				/**
				 * Prepares record info by record id and opens rights edit page.
				 * @param {String} primaryColumnValue Active row identifier.
				 */
				editRights: function(primaryColumnValue) {
					const gridRows = this.get("ForecastGridRows");
					const currentRecord = gridRows[primaryColumnValue];
					const recordInfo = this._getRecordInfo(currentRecord);
					this.openEditRowRightsPage(recordInfo);
				},

				/**
				 * Opens row rights edit page.
				 * @param {Object} recordInfo
				 */
				openEditRowRightsPage: function(recordInfo) {
					const id = this.sandbox.id + "_Rights";
					this.sandbox.subscribe("GetRecordInfo", function() {
						return recordInfo;
					}, this, [id]);
					const params = this.sandbox.publish("GetHistoryState");
					params.state.foldersManagerOpened = true;
					this.sandbox.publish("PushHistoryState", {
						stateObj: params.state,
						hash: params.hash.historyState,
						silent: true
					});
					this.unloadForecastModule();
					this.unloadHistoryForecastModule();
					this.sandbox.loadModule("Rights", {
						renderTo: "centerPanel",
						id: id,
						keepAlive: true
					});
					this.BPMSoft.utils.dom.setAttributeToBody("is-card-opened", true);
				},

				/**
				 * Unloads ForecastAngularModule if it is loaded
				 */
				unloadForecastModule() {
					if (this.$ForecastAngModuleLoaded) {
						this._unloadModule(this._getForecastAngModuleId(), "ForecastAngModuleLoaded");
					}
				},

				/**
				 * Unloads HistoryForecastAngularModule if it is loaded
				 */
				unloadHistoryForecastModule() {
					if (this.$HistoryForecastModuleLoaded) {
						this._unloadModule(this._getHistoryForecastModuleId(), "HistoryForecastModuleLoaded");
					}
				},

				/**
				 * Calculate forecast columns button click handler.
				 */
				onCalculateFactClick: function() {
					let dataSend;
					let methodName = "RunRecalculateFact";
					let serviceName = "ForecastService";
					if (this.getIsFeatureEnabled("ForecastV2")) {
						methodName = "RecalculateFact";
						let periods = this.getFilterPeriodsArray();
						if (this.isEmpty(periods)) {
							periods = this._getCurrentPeriods();
						}
						if (periods.length > this.maxPeriodsCount) {
							this.showInformationDialog(this.get("Resources.Strings.PeriodsExceededErrorCaption"));
							return;
						}
						dataSend = {
							forecastId: this.get("ForecastId"),
							periods: periods
						};
						if (this.getIsFeatureEnabled("ForecastUIV2") && this.isNotEmpty(this.$Setting)) {
							serviceName = "forecast.api";
							methodName = "forecast/calc";
						}
					} else {
						dataSend = {
							recordId: this.get("ForecastId")
						};
					}
					var config = {
						serviceName: serviceName,
						methodName: methodName,
						data: dataSend
					};
					this.callService(config, this.calculateFactCallback, this);
				},

				/**
				 * Open in new page button click handler
				 */
				onOpenFullscreenClick: function() {
					var forecastId = this.get("ForecastId");
					const url = this.getFullscreenForecastUrl(forecastId);
					const popup = window.open(url);
					setTimeout(function() {
						if (!popup || popup.outerHeight === 0) {
							this.BPMSoft.showInformation(resources.localizableStrings.PopupBlockedMessage);
						}
					}, this.$WaitOpenWindowTimeout);
				},

				/**
				 * Generate url to open forecast sheet in new tab
				 * @param {String} forecastId Id of forecast sheet
				 */
				getFullscreenForecastUrl: function(forecastId) {
					const moduleName = "FullscreenForecastModule";
					return Ext.String.format("ViewModule.aspx?vm=FullscreenViewModule#{0}/{1}", moduleName, forecastId);
				},

				/**
				 * Handles web-socket message receiving.
				 * @param {Object} event
				 * @param {Object} message
				 */
				onMessageReceived: function(event, message) {
					const messageCode = message && message.Header.Sender;
					const json = message.Body || "{}";
					const config = this.BPMSoft.decode(json);
					if (!(this.get("ForecastId") === config.forecastId)) {
						return;
					}
					switch (messageCode) {
						case "UpdateForecasts":
							this.handleSocketUpdateForecasts();
							break;
						case "ForecastCalcStarted":
							this.handleSocketForecastCalcStarted();
							break;
						default:
							break;
					}
				},

				/**
				 * Sets is calculation button locked.
				 * @param {Boolean} value Is calculation button locked.
				 */
				setCalculateButtonLocked: function(value) {
					if (this.getIsFeatureDisabled("ForecastAutoCalculation")) {
						return;
					}
					this.set("CalculateButtonLocked", value);
					if (value) {
						this.set("CalculateButtonCaption", this.get("Resources.Strings.CalculationInProgressCaption"));
					} else {
						this.set("CalculateButtonCaption", this.get("Resources.Strings.Calculate"));
					}
				},

				/**
				 * Handles forecast changed.
				 */
				handleForecastChanged: function() {
					this.updateCalculatedStatus();
				},

				/**
				 * Loads snapshots information.
				 */
				loadSnapshots: function() {
					const config = {
						serviceName: "forecast.history.api",
						methodName: "snapshot",
						data: {
							forecastId: this.$ForecastId
						}
					};
					this.callService(config, function(response) {
						this.$Snapshots = response.snapshots;
					}, this);
				},

				/**
				 * Handles snapshot date changed.
				 */
				handleSnapshotDateChanged: function(date) {
					this.$SnapshotDate = date;
					this._handleSnapshotChanged(date);
					if (date) {
						this._addGTMForDatepickerClick();
					}
				},

				/**
				 * Updates calculated status.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				updateCalculatedStatus: function(callback, scope) {
					const request = this._getForecastServiceRequest();
					request.getCalculatedStatus(function(response) {
						this.handleCalculationStatus(response);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Handle calculation status response.
				 * @param {Object} response Response.
				 */
				handleCalculationStatus: function(response) {
					this.setCalculateButtonLocked(response.isInProgress);
					this.set("LastCalcDateTime", response.lastCalcDateTime);
					this.set("NextCalcDateTime", response.nextCalcDateTime);
				},

				/**
				 * Handles forecast row action clicked.
				 * @param {Object} rowActionData Row action data.
				 */
				handleRowActionClicked: function(rowActionData) {
					if (rowActionData.actionCode === "setup-rights") {
						this._handleSetupRowRightsAction(rowActionData);
					} else if (rowActionData.actionCode === "delete-record") {
						this._handleDeleteRecordAction(rowActionData);
					}
				},

				/**
				 * Handle delete response.
				 * @param {Object} response Delete response.
				 * @public
				 */
				handleDeleteResponse: function(response) {
					this.hideBodyMask();
					const result = response && response.DeleteForecastEntityRowResult;
					if (result && result.success) {
						this._publishRefreshForecast();
						return;
					}
					this.showInformationDialog(result.errorInfo && result.errorInfo.message);
				},

				/**
				 * Returns forecast config.
				 * @return {Object} Forecast config.
				 */
				getForecastConfig: function() {
					return {
						forecastId: this.get("ForecastId"),
						periodsId: this.getFilterPeriodsArray(),
						snapshotId: this.get("SnapshotId"),
						forecastSourceItemName: this.$ForecastDimensionSchemaName,
						maxDisplayedRecords: 500
					};
				},

				/**
				 * Open drilldown columns settings.
				 * @param {Object} data Drilldown profile data.
				 */
				showDrilldownSetupColumns: function(data) {
					this.mixins.GridUtilities.openGridSettings.apply(this, arguments);
					this._drilldownProfileData = data;
				},

				/**
				 * Update header caption on setup columns page
				 * @param {String} caption Header caption.
				 */
				updateSetupColumnsHeader: function(caption) {
					this.sandbox.publish("UpdatePageHeaderCaption", {
						pageHeaderCaption: caption
					});
				},

				/**
				 * Returns grid entity schema.
				 * @public
				 * @return {BPMSoft.EntitySchema} Grid entity schema.
				 */
				getGridEntitySchema: function() {
					return this.BPMSoft[this._drilldownProfileData.entitySchemaName] || null;
				},

				/**
				 * Returns params of opening page grid settings.
				 * @override
				 * @return {Object} Params of opening page grid settings.
				 */
				getGridSettingsInfo: function() {
					var info = this.mixins.GridUtilities.getGridSettingsInfo.apply(this, arguments);
					var forecastId = this._drilldownProfileData.forecastId;
					var columnId = this._drilldownProfileData.columnId;
					var currentCultureId = this.BPMSoft.SysValue.CURRENT_USER_CULTURE.value;
					info.profileKey = `ForecastDrilldownList_${forecastId}_${columnId}_${currentCultureId}`;
					info.useBackwards = false;
					return info;
				},

				/**
				 * Loads data.
				 */
				loadData: function() {
					if (!this.$ForecastUIV2FeatureEnabled) {
						this.requestForecastValues(this.getForecastResponse);
					}
				},

				/**
				 * Sets summary columns values.
				 */
				setSummary: function(item, config) {
					var silent = config ? config.silent : false;
					var code = "Summary";
					var summaryColumns = ["Plan", "Fact", "FactPercent", "Potential"];
					var summaryValues = {
						"Plan": 0,
						"Fact": 0,
						"Potential": 0
					};
					var changed = false;
					this.BPMSoft.each(summaryColumns, function(property) {
						if (!item.columns[code + property]) {
							item.columns[code + property] = {
								columnPath: code + property,
								dataValueType: this.BPMSoft.DataValueType.INTEGER,
								type: this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
							};
						}
					}, this);
					for (var column in item.columns) {
						for (var indicator in summaryValues) {
							if (column.indexOf(indicator) === 0) {
								if (indicator === "Fact" && column.indexOf("FactPercent") === 0) {
									continue;
								}
								summaryValues[indicator] += item.get(column);
							}
						}
					}
					for (var summary in summaryValues) {
						var summaryCode = code + summary;
						if (!changed && item.get(summaryCode) !== summaryValues[summary]) {
							changed = true;
						}
						item.set(code + summary, summaryValues[summary]);
					}
					var summaryFactPercent = Math.round(summaryValues.Fact * 100 * 100 / summaryValues.Plan) / 100;
					item.set("SummaryFactPercent", summaryFactPercent);
					if (!silent && changed) {
						this.set("NeedReload", true);
					}
				},

				/**
				 * Opens columns list lookup.
				 */
				showColumnsList: function() {
					this._loadColumns(function(selectedColumns) {
						const lookupConfig = {
							entitySchemaName: "ForecastColumn",
							columns: ["Title", "IsHide"],
							multiSelect: true,
							selectedValues: selectedColumns || [],
							hideActions: true,
							filters: this._getColumnsFilterGroup()
						};
						this.openLookup(lookupConfig, this._updateSelectedColumns, this);
					}, this);
				},

				/**
				 * Handle snapshot save button press.
				 */
				onSnapshotSave: function() {
					var config = {
						serviceName: "forecast.history.api",
						methodName: "snapshot/save",
						data: {
							"forecastId": this.$ForecastId
						}
					};
					this.callService(config, function(response) {
						this.loadSnapshots();
					}, this);
				},

				/**
				 * Checks if have snapshots for passed date.
				 * @public
				 * @param {Date} date Datepicker date to check for snapshots.
				 * @return {Boolean} Has snapshot on passed date flag.`
				 */
				hasSnapshotOnDate: function(date) {
					return Boolean(this._getSnapshotId(date));
				},

				/**
				 * Gets column schema data from service and loads entity schema.
				 * @param data
				 */
				setupForecastColumnSchemaData: function(data) {
					BPMSoft.debounce(function() {
						const config = this.getForecastColumnSchemaData(this.$ForecastId, data.columnCode);
						this.callService(config, function (response) {
							this.BPMSoft.require([response.entitySchemaName], function() {});
						}, this);
					}.bind(this), 10)();
				},

				/**
				 * Get complete execution service config
				 * @protected
				 * @return {Object} Complete execution service config
				 */
				getForecastColumnSchemaData: function(forecastId, columnId) {
					return {
						serviceName: "forecast.api",
						methodName: "forecast/column/schemadata",
						data: {
							forecastId: forecastId,
							columnId: columnId
						}
					};
				}

				// endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "ForecastModuleContainerMain",
					"values": {
						"id": "ForecastModuleContainerMain",
						"selectors": {"wrapEl": "#ForecastModuleContainerMain"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["forecast-content-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "buttonContainer",
					"parentName": "ForecastModuleContainer",
					"propertyName": "items",
					"values": {
						"id": "buttonContainer",
						"selectors": {"wrapEl": "#buttonContainer"},
						"wrapClass": ["forecast-button-container"],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "IsDimensionDataLoaded"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "addButton",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"caption": resources.localizableStrings.Add,
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onAddButtonClick"},
						"enabled": {"bindTo": "AddButtonEnabled"},
						"markerValue": "addButton",
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {"textClass": ["actions-button-margin-right"]}
					}
				},
				{
					"operation": "insert",
					"name": "reloadButton",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"caption": resources.localizableStrings.Reload,
						"visible": {"bindTo": "NeedReload"},
						"click": {"bindTo": "loadData"},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"markerValue": "reloadButton",
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {"textClass": ["actions-button-margin-right"]}
					}
				},
				{
					"operation": "insert",
					"name": "actionsButton",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"caption": resources.localizableStrings.Actions,
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"markerValue": "actionsButton",
						"selectors": {"wrapEl": "#actionsButton"},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"classes": {"textClass": ["actions-button-margin-right"]},
						"tag": "actionsButton",
						"menu": [],
						"visible": {"bindTo": "HasCustomActions"}
					}
				},
				{
					"operation": "insert",
					"name": "factMenuItem",
					"parentName": "actionsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "CalculateFactPotentialCaption"},
						"itemType": this.BPMSoft.ViewItemType.MENU_ITEM,
						"click": {"bindTo": "onCalculateFactClick"},
						"enabled": {"bindTo": "CalculateFactEnabled"},
						"markerValue": "factMenuItem",
						"selectors": {"wrapEl": "#factMenuItem"},
						"tag": "factMenuItem"
					}
				},
				{
					"operation": "insert",
					"name": "rightToolsContainer",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"id": "rightToolsContainer",
						"wrapClass": ["right-tools-buttons-container-wrapClass"],
						"selectors": {"wrapEl": "#rightToolsContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "fullscreenButton",
					"parentName": "rightToolsContainer",
					"propertyName": "items",
					"values": {
						"classes": {"wrapperClass": ["actions-button-margin-right"]},
						"click": {"bindTo": "onOpenFullscreenClick"},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"markerValue": "fullscreenButton",
						"selectors": {"wrapEl": "#actionsButton"},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"imageConfig": {"bindTo": "Resources.Images.FullscreenIcon"},
						"menu": [],
						"visible": {
							"bindTo": "FullscreenForecastsEnabled"
						}
					}
				},
				{
					"operation": "insert",
					"name": "viewButton",
					"parentName": "rightToolsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"markerValue": "viewButton",
						"selectors": {"wrapEl": "#actionsButton"},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"imageConfig": {"bindTo": "Resources.Images.viewButtonIcon"},
						"menu": []
					}
				},
				{
					"operation": "insert",
					"name": "forecastDatetimeFilter",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"id": "forecastDatetimeFilter",
						"wrapClass": ["forecast-datetime-filter-container"],
						"markerValue": "forecastDatetimeFilter",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "calculateButton",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "CalculateButtonCaption"},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"markerValue": "calculateButton",
						"selectors": {"wrapEl": "#calculateButton"},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {"textClass": ["calculateButton"], "wrapperClass": ["forecast-calculate-button"]},
						"click": {"bindTo": "onCalculateFactClick"},
						"tag": "calculateButton",
						"imageConfig": {"bindTo": "Resources.Images.CalculateIcon"},
						"menu": [],
						"enabled": {
							"bindTo": "CalculateButtonLocked",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						"visible": {
							"bindTo": "CalculateButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"name": "calculationTimer",
					"parentName": "buttonContainer",
					"propertyName": "items",
					"values": {
						"id": "calculationTimer",
						"selectors": {"wrapEl": "#calculationTimer"},
						"wrapClass": ["calculation-timer-container"],
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "CalculateButtonVisible"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "periodMenuItem",
					"parentName": "viewButton",
					"propertyName": "menu",
					"values": {
						"caption": resources.localizableStrings.SetPeriod,
						"itemType": this.BPMSoft.ViewItemType.MENU_ITEM,
						"click": {"bindTo": "selectPeriod"},
						"markerValue": "periodMenuItem"
					}
				},
				{
					"operation": "insert",
					"name": "columnsListMenuItem",
					"parentName": "viewButton",
					"propertyName": "menu",
					"values": {
						"caption": resources.localizableStrings.ColumnsListMenuItem,
						"itemType": this.BPMSoft.ViewItemType.MENU_ITEM,
						"click": {"bindTo": "showColumnsList"},
						"markerValue": "columnsListMenuItem",
						"enabled": {"bindTo": "CanShowColumnsList"},
						"visible": {
							"bindTo": "ForecastUIV2FeatureEnabled"
						}
					}
				},
				{
					"operation": "insert",
					"name": "gridControlGroup",
					"parentName": "ForecastModuleContainer",
					"propertyName": "items",
					"values": {
						"id": "gridControlGroup",
						"selectors": {"wrapEl": "#gridControlGroup"},
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"wrapClass": ["gridControlGroup"],
						"items": [],
						"visible": {
							"bindTo": "ForecastUIV2FeatureEnabled",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
					}
				},
				{
					"operation": "insert",
					"name": "ForecastApp",
					"parentName": "ForecastModuleContainer",
					"propertyName": "items",
					"values": {
						"id": "ForecastApp",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["ng-bpm-forecast"],
						"visible": {"bindTo": "ForecastUIV2FeatureEnabled"},
						"items": [],
						/**
						 * Defines padding between forecast table bottom and next content block
						 * @returns {number}
						 */
						"getBottomPadding": function() {
							const centerPanel = Ext.getCmp('centerPanelContainer');
							const centerPanelDom = centerPanel.getWrapEl().dom;
							const centerPanelDomStyles = window.getComputedStyle(centerPanelDom, null);
							return parseInt(centerPanelDomStyles.paddingBottom || 0);
						},
						/**
						 * Defines extra offset between forecast table bottom and next content block
						 * @returns {number}
						 */
						"getExtraBottomOffset": function() {
							return 0;
						},
						/**
						 * Defines total offset between forecast table bottom and next content block
						 * Used in BPMSoft.BaseForecast
						 * @returns {number}
						 */
						"getBottomOffset": function () {
							return this.getBottomPadding() + this.getExtraBottomOffset();
						}
					}
				},
				{
					"operation": "insert",
					"name": "DataGrid",
					"parentName": "gridControlGroup",
					"propertyName": "items",
					"values": {
						"id": "ForecastGridId",
						"itemType": this.BPMSoft.ViewItemType.GRID,
						"className": "BPMSoft.PivotGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"selectors": {"wrapEl": "#ForecastGridId"},
						"collection": {"bindTo": "Collection"},
						"activeRow": {"bindTo": "ActiveRow"},
						"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
						"changeRow": {"bindTo": "changeRow"},
						"unSelectRow": {"bindTo": "unSelectRow"},
						"onGridClick": {"bindTo": "onGridClick"},
						"listedZebra": true,
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"activeRowCaptionActions": [{
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"className": "BPMSoft.Button",
							"imageConfig": resources.localizableImages.SettingsImage,
							"hint": resources.localizableStrings.ConfigurationButtonHint,
							"markerValue": "activeRowSettingsButton",
							"menu": {
								"items": [{
									"className": "BPMSoft.MenuItem",
									"tag": "editRight",
									"markerValue": resources.localizableStrings.EditRightsMenuItemCaption,
									"caption": resources.localizableStrings.EditRightsMenuItemCaption
								}]
							}
						}],
						"activeCellColumnName": {"bindTo": "ActiveCellColumnName"},
						"cellValueChanged": {"bindTo": "saveForecastCellChanges"},
						"container": "gridControlGroup",
						"multiSelect": false,
						"hierarchical": true,
						"hierarchicalColumnName": "Parent",
						"rowDataItemMarkerColumnName": "Name",
						"expandHierarchyLevels": {"bindTo": "expandHierarchy"},
						"enabled": true,
						"type": "listed",
						"columnsConfig": [],
						"captionsConfig": [],
						"rowsCaptionsColumnsConfig": [],
						"listedConfig": {
							"columnsConfig": [],
							"captionsConfig": []
						}
					}
				}
			]
		};
	});
