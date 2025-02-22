﻿define("WorkingWeekDetail", ["WorkingWeekDetailResources", "BusinessRulesApplierV2", "ConfigurationGrid",
	"ConfigurationGridGenerator", "ConfigurationGridUtilities", "MiniPageUtilities",
	"CalendarWorkingTimeUtility"
], function(resources, BusinessRulesApplier) {
	return {
		entitySchemaName: "DayInCalendar",
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ConfigurationGrid",
					"primaryColumnName": "Id",
					"primaryDisplayColumnName": "DayOfWeek",
					"itemType": this.BPMSoft.ViewItemType.GRID,
					"type": "listed",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
					"selectedRows": {"bindTo": "SelectedRows"},
					"activeRow": {"bindTo": "ActiveRow"},
					"changeRow": {"bindTo": "changeRow"},
					"unSelectRow": {"bindTo": "unSelectRow"},
					"isEmpty": {"bindTo": "IsGridEmpty"},
					"multiSelect": {"bindTo": "IsMultiSelect"},
					"isLoading": {"bindTo": "IsGridLoading"},
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onAction"},
					"activeRowActions": [
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "save",
							"markerValue": "save",
							"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
						},
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "card",
							"markerValue": "card",
							"imageConfig": {"bindTo": "Resources.Images.CardIcon"}
						},
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "cancel",
							"markerValue": "cancel",
							"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
						}
					],
					"columnsConfig": [
						{
							"cols": 4,
							"key": [{
								"name": {
									"bindTo": "DayOfWeek"
								}
							}]
						},
						{
							"cols": 4,
							"key": [{
								"name": {
									"bindTo": "DayType"
								}
							}]
						},
						{
							"cols": 16,
							"key": [{
								"name": {
									"bindTo": "WorkingIntervals"
								}
							}]
						}
					],
					"captionsConfig": [
						{
							"cols": 4,
							"name": resources.localizableStrings.DayOfWeekCaption
						},
						{
							"cols": 4,
							"name": resources.localizableStrings.DayTypeCaption
						},
						{
							"cols": 4,
							"name": resources.localizableStrings.WorkingIntervalsCaption
						}
					]
				}
			}
		]/**SCHEMA_DIFF*/,
		mixins: {
			"ConfigurationGridUtilities": "BPMSoft.ConfigurationGridUtilities",
			"MiniPageUtilities": "BPMSoft.MiniPageUtilities",
			"CalendarWorkingTimeUtility": "BPMSoft.CalendarWorkingTimeUtility"
		},
		attributes: {
			"IsEditable": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": true
			},
			"IntervalsConfig": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			"UseGeneratedProfile": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSettingsMenuItem
			 * @overridden
			 */
			getGridSettingsMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
			 * @overridden
			 */
			getAddRecordButtonVisible: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @overridden
			 */
			getDeleteRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
			 * @overridden
			 */
			getGridSortMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#sortColumn
			 * @overridden
			 */
			sortColumn: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.set("IntervalsConfig", {});
				this.set("RowCount", 8);
				this.set("IsPageable", false);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getCellControlsConfig
			 * @overridden
			 */
			getCellControlsConfig: function(entitySchemaColumn) {
				if (!entitySchemaColumn) {
					return;
				}
				var columnName = entitySchemaColumn.name;
				var enabled = (entitySchemaColumn.usageType !== this.BPMSoft.EntitySchemaColumnUsageType.None) &&
					!this.Ext.Array.contains(this.systemColumns, columnName);
				var config = {
					itemType: this.BPMSoft.ViewItemType.MODEL_ITEM,
					name: columnName,
					labelConfig: {visible: false},
					caption: entitySchemaColumn.caption,
					enabled: enabled
				};
				if (columnName === "DayOfWeek") {
					config.enabled = false;
				}
				if (entitySchemaColumn.dataValueType === this.BPMSoft.DataValueType.LOOKUP) {
					config.showValueAsLink = false;
				}
				if (entitySchemaColumn.dataValueType !== this.BPMSoft.DataValueType.DATE_TIME &&
					entitySchemaColumn.dataValueType !== this.BPMSoft.DataValueType.BOOLEAN) {
					config.focused = {"bindTo": "Is" + columnName + "Focused"};
				}
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#initQueryColumns
			 * @overridden
			 */
			initQueryColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("DayType.NonWorking");
				var sortByNumber = esq.addColumn("DayOfWeek.Number");
				sortByNumber.orderPosition = 0;
				sortByNumber.orderDirection = this.BPMSoft.OrderDirection.ASC;
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#generateActiveRowControlsConfig
			 * @overridden
			 */
			loadGridDataRecord: function(primaryColumnValue, callback, scope) {
				this.mixins.CalendarWorkingTimeUtility.loadGridDataRecord.call(this,
					primaryColumnValue, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#updateDetail
			 * @overridden
			 */
			updateDetail: function() {
				this.callParent(arguments);
				this.loadGridData();
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function() {
				if (this.get("CallGridDataParent")) {
					this.callParent(this.get("GridDataParentArguments"));
				} else {
					this.set("GridDataParentArguments", arguments);
					var esq = this.getWorkingIntervalsQuery();
					esq.getEntityCollection(function(result) {
						if (result.success) {
							this.performIntervals(result.collection);
						}
						this.set("CallGridDataParent", true);
						this.onGridDataLoaded();
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#prepareResponseCollectionItem:
			 * @overridden
			 */
			prepareResponseCollectionItem: function(item) {
				this.callParent(arguments);
				this.mixins.CalendarWorkingTimeUtility.prepareResponseCollectionItem.call(this, item,
					resources.localizableStrings.SetWorkingHourCaption);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#generateActiveRowControlsConfig
			 * @overridden
			 */
			generateActiveRowControlsConfig: function(id, columnsConfig, rowConfig) {
				this.columnsConfig = columnsConfig;
				var gridLayoutItems = [];
				var currentColumnIndex = 0;
				this.BPMSoft.each(columnsConfig, function(columnConfig) {
					var columnName = columnConfig.key[0].name.bindTo;
					var column = this.getColumnByColumnName(columnName);
					var cellConfig = this.getCellControlsConfig(column);
					cellConfig = this.Ext.apply({
						layout: {
							colSpan: columnConfig.cols,
							column: currentColumnIndex,
							row: 0,
							rowSpan: 1
						}
					}, cellConfig);
					if (!column) {
						this.applyVirtualColumnsConfig(columnName, cellConfig);
					}
					gridLayoutItems.push(cellConfig);
					currentColumnIndex += columnConfig.cols;
				}, this);
				var gridData = this.getGridData();
				var activeRow = gridData.get(id);
				var rowClass = {prototype: activeRow};
				BusinessRulesApplier.applyRules(rowClass, gridLayoutItems);
				var viewGenerator = this.Ext.create("BPMSoft.ViewGenerator");
				viewGenerator.viewModelClass = {prototype: this};
				var gridLayoutConfig = viewGenerator.generateGridLayout({
					name: this.name,
					items: gridLayoutItems
				});
				rowConfig.push(gridLayoutConfig);
			},

			/**
			 * On active row action handler.
			 * @param {String} buttonTag Clicked button tag.
			 */
			onAction: function(buttonTag) {
				switch (buttonTag) {
					case "card":
						var config = this.getWorkingIntervalMiniPageConfig(this.getDayCaption());
						if (!config) {
							return;
						}
						this.openMiniPage(config);
						break;
					default:
						this.onActiveRowAction.apply(this, arguments);
				}
			},

			saveRowChanges: function(row) {
				if (!this.Ext.isObject(row)) {
					return;
				}
				this.prepareResponseCollectionItem(row);
				if (!this.validateActiveRow(row)) {
					var config = this.getWorkingIntervalMiniPageConfig(this.getDayCaption());
					if (config) {
						this.openMiniPage(config);
					}
					return;
				}
				this.mixins.ConfigurationGridUtilities.saveRowChanges.apply(this, arguments);
			},

			/**
			 * @inheritDoc BPMSoft.MiniPageContainerViewModel#closeMiniPage
			 * @override
			 */
			closeMiniPage: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.CalendarWorkingTimeUtility#getMiniPageSchemaName
			 * @overridden
			 */
			getMiniPageSchemaName: function() {
				return "DayInCalendarMiniPage";
			},

			/**
			 * Returns entity schema query for working time intervals.
			 * @protected
			 * @return {EntitySchemaQuery}
			 */
			getWorkingIntervalsQuery: function() {
				var calendarId = this.get("MasterRecordId");
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "WorkingTimeInterval"
				});
				var sortByFrom = esq.addColumn("From");
				esq.addColumn("To");
				esq.addColumn("DayInCalendar");
				sortByFrom.orderPosition = 0;
				sortByFrom.orderDirection = this.BPMSoft.OrderDirection.ASC;
				esq.filters.add("calendarFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "DayInCalendar.Calendar", calendarId));
				return esq;
			},
			/**
			 * @inheritdoc GridUtilitiesV2#updateLoadedGridData
			 * @overridden
			 */
			updateLoadedGridData: function(response) {
				this.applyCultureBasedDaysOrder(response.collection);
				this.callParent(arguments);
			},
			/**
			 * Sets the order of the days of the week based on current culture settings.
			 * @private
			 * @param {BPMSoft.BaseViewModelCollection} collection Source collection of days rows.
			 */
			applyCultureBasedDaysOrder: function(collection) {
				if (BPMSoft.Resources.CultureSettings.startDay === 1) {
					collection.move(0, collection.getCount() - 1);
				}
			},
			validateActiveRow: function(row) {
				var isValid = true;
				var activeRow = row || this.getActiveRow();
				if (activeRow.get("DayType.NonWorking")) {
					return isValid;
				}
				var intervals = this.get("IntervalsConfig")[this.get("ActiveRow")];
				if (!intervals || intervals.intervals.length === 0) {
					isValid = false;
				}
				return isValid;
			},
			/**
			 * Generate caption for mini card
			 * @return {String} caption
			 */
			getDayCaption: function() {
				var activeRow = this.getActiveRow();
				return activeRow.get("DayOfWeek").displayValue;
			},

			/**
			 * @inheritdoc BaseGridDetailV2#getToolsVisible
			 * @overridden
			 */
			getToolsVisible: function() {
				return false;
			}
		}
	};
});
