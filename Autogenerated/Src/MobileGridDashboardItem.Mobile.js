/**
 * @class BPMSoft.configuration.controls.GridDashboardItem
 * Provides "Grid" type of dashboards.
 */
Ext.define("BPMSoft.configuration.controls.GridDashboardItem", {
	extend: "BPMSoft.configuration.controls.BaseDashboardItem",
	alternateClassName: "BPMSoft.GridDashboardItem",

	config: {

		/**
		 * @inheritdoc
		 */
		cssSuffix: "grid",

		/**
		 * @cfg {Config[]} columns Columns configuration.
		 */
		columns: null,

		/**
		 * @cfg {Config[]} data Columns values.
		 */
		data: null,

		/**
		 * @cfg {String} gridLayoutClassName Class name of grid layout.
		 * @deprecated
		 */
		gridLayoutClassName: null

	},

	/**
	 * @private
	 */
	grid: null,

	/**
	 * @private
	 */
	getModelName: function() {
		var rawConfig = this.getRawConfig();
		return rawConfig.schemaName;
	},

	/**
	 * @private
	 */
	doRenderGrid: function() {
		var grid = this.grid = this.createGrid({
			prepareDataFn: function(data) {
				return data.Data;
			},
			store: this.createStore(),
			columnsConfig: this.getGridColumnsConfig(),
			listeners: {
				recordlinktap: this.onLinkTap,
				scope: this
			}
		});
		this.innerHtmlElement.appendChild(grid.element);
	},

	/**
	 * @private
	 */
	renderGrid: function() {
		if (this.grid) {
			this.grid.destroy();
		}
		this.initializeGrid(function() {
			this.doRenderGrid();
		});
	},

	/**
	 * @private
	 */
	getStoreData: function() {
		var storeData = [];
		var data = this.getData();
		var columns = this.getColumns();
		var columnsCollection = {};
		for (var j = 0, jln = columns.length; j < jln; j++) {
			var column = columns[j];
			columnsCollection[column.name] = column;
		}
		for (var i = 0, ln = data.length; i < ln; i++) {
			var dataRow = data[i];
			var storeRow = {};
			BPMSoft.each(dataRow, function(value, columnName) {
				var columnConfig = columnsCollection[columnName];
				if (columnConfig && columnConfig.dataValueType !== BPMSoft.DataValueType.Lookup) {
					value = this.convertValue(value, columnConfig.dataValueType);
				}
				storeRow[columnName] = value;
			}, this);
			storeData.push({
				Data: storeRow
			});
		}
		return storeData;
	},

	/**
	 * @private
	 */
	createStore: function() {
		return Ext.create("Ext.data.Store", {
			data: this.getStoreData(),
			model: BPMSoft.model.SimpleModel
		});
	},

	/**
	 * @private
	 */
	initializeGrid: function(callback) {
		BPMSoft.StructureLoader.loadModelsWithDependencies({
			modelNames: [this.getModelName()],
			success: function() {
				Ext.callback(callback, this);
			},
			scope: this
		});
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateData: function() {
		this.renderGrid();
	},

	/**
	 * Gets columns config of grid.
	 * @protected
	 * @virtual
	 * @return {Object[]} Columns config.
	 */
	getGridColumnsConfig: function() {
		var columns = this.getColumns();
		var gridColumnsConfig = [];
		for (var i = 0, ln = columns.length; i < ln; i++) {
			var columnConfig = columns[i];
			var gridColumnConfig = BPMSoft.DashboardUtils.getGridColumnConfig({
				modelName: this.getModelName(),
				columnName: columnConfig.name,
				caption: columnConfig.caption,
				cols: columnConfig.position.colSpan,
				dataValueType: columnConfig.dataValueType,
				columnModelName: columnConfig.referenceSchemaName
			});
			gridColumnsConfig.push(gridColumnConfig);
		}
		return gridColumnsConfig;
	},

	/**
	 * Create grid.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.Grid} Instance of grid.
	 */
	createGrid: function(config) {
		return Ext.factory(Ext.merge({
			xtype: "tsgrid",
			scrollable: null
		}, config));
	},

	/**
	 * @deprecated
	 */
	createGridLayout: function() {
	},

	/**
	 * Called when record link has been tapped.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.Grid} grid Instance of grid.
	 * @param {String} modelName Name of model.
	 * @param {String} recordId Record id.
	 */
	onLinkTap: function(grid, modelName, recordId) {
		this.fireEvent("recordlinktap", modelName, recordId);
	}

});
