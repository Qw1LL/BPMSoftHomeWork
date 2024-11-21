define("ProcessTimerScheduleDetail", ["ProcessTimerScheduleDetailResources", "SortableGridViewModelMixin"],
	function(resources) {
	return {
		mixins: {
			sortableGrid: "BPMSoft.SortableGridViewModelMixin"
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getRowViewModelColumns: function() {
				return {
					Caption: {
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					State: {
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					PreviousFireTime: {
						dataValueType: BPMSoft.DataValueType.DATE_TIME
					},
					NextFireTime: {
						dataValueType: BPMSoft.DataValueType.DATE_TIME
					}
				};
			},

			/**
			 * @private
			 */
			_getRowViewModelValues: function(rowObject) {
				return {
					Caption: rowObject.Caption,
					State: resources.localizableStrings["TimerState" + rowObject.State],
					PreviousFireTime: rowObject.PreviousFireTime && new Date(rowObject.PreviousFireTime),
					NextFireTime: rowObject.NextFireTime && new Date(rowObject.NextFireTime)
				};
			},

			/**
			 * @private
			 */
			_getRowViewModel: function(rowObject) {
				return this.Ext.create("BPMSoft.BaseViewModel", {
					columns: this._getRowViewModelColumns(),
					values: this._getRowViewModelValues(rowObject)
				});
			},

			/**
			 * @private
			 */
			_getRowViewModelId: function(rowObject) {
				return rowObject.UId;
			},

			/**
			 * Provides settings for sorting.
			 * @private
			 */
			_getSortSettingsConfig: function() {
				return {
					columnsToSort: ["Caption", "State", "PreviousFireTime", "NextFireTime"],
					profileKey: this.getProfileKey() + "SortColumns"
				};
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollectionItem
			 * @overriden
			 */
			prepareResponseCollectionItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#onGridDataLoaded
			 * @overriden
			 */
			onGridDataLoaded: function(timerEventsInfo) {
				const result = new BPMSoft.Collection();
				timerEventsInfo.forEach(function(timerEvent) {
					result.add(this._getRowViewModelId(timerEvent), this._getRowViewModel(timerEvent));
				}, this);
				this.callParent([{success: true, collection: result}]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#editCurrentRecord
			 * @override
			 */
			editCurrentRecord: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#initCanLoadMoreData
			 * @override
			 */
			initCanLoadMoreData: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilities#sortColumn
			 * @override
			 */
			sortColumn: function(index) {
				this.sortByColumn(index);
			},

			/**
			 * @inheritdoc BPMSoft.SortableGridViewModelMixin#getDataCollection
			 * @override
			 */
			getDataCollection: function() {
				return this.$Collection;
			},

			//endregion

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#loadGridData
			 * @overriden
			 */
			loadGridData: function() {
				BPMSoft.AjaxProvider.request({
					url: "../ServiceModel/ProcessEngineService.svc/GetTimerEventsInfo",
					method: "POST",
					scope: this,
					jsonData: JSON.stringify(this.$MasterRecordId),
					callback: function(status, result, response) {
						if (result) {
							const json = JSON.parse(response.responseText);
							this.onGridDataLoaded(json.timerEventsInfo);
						}
					}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						this.initSortingSettings(this._getSortSettingsConfig(), callback, scope);
					}, this
				]);
			}

			// endregion

		},
		diff: [
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "Caption",
								"bindTo": "Caption",
								"caption": resources.localizableStrings.ColumnCaption,
								"position": {"column": 0, "colSpan": 6}
							},
							{
								"name": "State",
								"bindTo": "State",
								"caption": resources.localizableStrings.ColumnState,
								"position": {"column": 6, "colSpan": 6}
							},
							{
								"name": "PreviousFireTime",
								"bindTo": "PreviousFireTime",
								"caption": resources.localizableStrings.ColumnPreviousFireTime,
								"position": {"column": 13, "colSpan": 6}
							},
							{
								"name": "NextFireTime",
								"bindTo": "NextFireTime",
								"caption": resources.localizableStrings.ColumnNextFireTime,
								"position": {"column": 18, "colSpan": 6}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {},
						"items": []
					},
					"isEmptyCaption": resources.localizableStrings.EmptyGrid
				}
			},
			{
				"operation": "remove",
				"name": "ToolsButton"
			}
		]
	};
});