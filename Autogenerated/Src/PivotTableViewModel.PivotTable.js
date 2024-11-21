define("PivotTableViewModel", ["PivotTableViewModelResources", "GridUtilitiesV2",
		"DashboardGridViewModel", "PivotTableUtilities"],
	function(resources) {
		Ext.define("BPMSoft.PivotTableViewModel", {
			extend: "BPMSoft.DashboardGridViewModel",

			/**
			 * List of classes to mix into this class.
			 * @type {Object}.
			 */
			mixins: {
				/**
				 * @class GridUtilities.
				 */
				GridUtilities: "BPMSoft.GridUtilities",

				PivotTableUtilities: "BPMSoft.PivotTableUtilities"
			},

			messages: {
				/**
				 * @message GetFiltersCollection
				 */
				"GetFiltersCollection": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			columns: {
				Options: { 
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				TableId: { 
					dataValueType: BPMSoft.DataValueType.TEXT,
				},
				
				DesignPivotRowCount: { 
					dataValueType: BPMSoft.DataValueType.INTEGER,
					value: 50
				}
			},

			/**
			 * @private
			 */
			_initEntitySchema: function(callback, scope) {
				BPMSoft.require([this.$entitySchemaName], function(entitySchema) {
					this.entitySchema = entitySchema;
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#init
			 */
			init: function() {
				this.sandbox.registerMessages(this.messages);
				this.initResourcesValues(resources);
				var parentMethod = this.getParentMethod(this, arguments);
				this._initEntitySchema(parentMethod, this);
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#initQueryOptions
			 */
			initQueryOptions: function(esq) {
				if (this.$isDesigned) {
					esq.rowCount = this.$DesignPivotRowCount;
				} else {
					esq.rowsOffset = -1;
					esq.rowCount = -1;
				}
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#initQuerySorting
			 */
			initQuerySorting: BPMSoft.emptyFn,

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#addTypeColumns
			 */
			addTypeColumns: BPMSoft.emptyFn,

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#getProfileColumns
			 */
			getProfileColumns: function() {
				const columns = this.callParent(arguments);
				const pivotColumns = this._getPivotSettingsColumns();
				const args = [columns].concat(pivotColumns);
				return BPMSoft.pick.apply(this, args);
			},

			/**
			 * @private
			 */
			_getPivotSettingsColumns: function() {
				const aggregationOptions = this._getPivotAggregationOptions();
				if (!aggregationOptions) {
					return [];
				}
				const rows = aggregationOptions.rows || [];
				const columns = aggregationOptions.columns || [];
				const aggregates = aggregationOptions.aggregates || [];
				const aggregatesColumns = BPMSoft.map(aggregates, function(agg) {
					return agg.aggregationField;
				});
				return Ext.Array.merge(rows, columns, aggregatesColumns);
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#loadGridData
			 */
			loadGridData: function() {
				this.$Options = {
					serializeEsq: this._getPivotEsq(),
					viewOptions: this.getPivotViewOptions(this.$gridConfig),
					aggregationOptions: this._getPivotAggregationOptions()
				};
			},

			/**
			 * @private
			 */
			_getPivotEsq: function() {
				const esq = this.getGridDataInitializedEsq();
				return esq.serialize();
			},

			/**
			 * @private
			 */
			_getPivotAggregationOptions: function() {
				return JSON.parse(this.$pivotTableConfig || {});
			},

			/**
			 * On full screen button event handler.
			 */
			onFullScreenBtnClick: function() {
				var moduleId =  arguments && arguments[3];
				const containerSelector = Ext.String.format("#{0}", moduleId);
				BPMSoft.toggleFullScreenMode(containerSelector);
			},

		});
		return {};
});
