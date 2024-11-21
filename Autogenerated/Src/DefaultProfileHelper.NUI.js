define("DefaultProfileHelper", ["BaseModule"], function() {
	/**
	 * @class BPMSoft.configuration.DefaultProfileHelper
	 * Class for generate entity profile by key.
	 */
	Ext.define("BPMSoft.configuration.DefaultProfileHelper", {
		alternateClassName: "BPMSoft.DefaultProfileHelper",
		extend: "BPMSoft.BaseModule",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * System columns of the object.
		 * @type {Array}
		 */
		systemColumns: ["Id", "CreatedOn", "CreatedBy", "ModifiedOn", "ModifiedBy", "ProcessListeners"],

		/**
		 * Count of the maximum columns in the profile listed or tiled config.
		 * @type {Number}
		 */
		maximumColumnsCount: 4,

		/**
		 * Total number of columns in listed or tiled config.
		 * @type {Number}
		 */
		totalGridColumnsCount: 24,

		/**
		 * Allowed data value types.
		 * @type {Array}
		 */
		allowedDataValueTypes: [
			BPMSoft.DataValueType.DATE,
			BPMSoft.DataValueType.TIME,
			BPMSoft.DataValueType.DATE_TIME,
			BPMSoft.DataValueType.LOOKUP,
			BPMSoft.DataValueType.MONEY,
			BPMSoft.DataValueType.FLOAT,
			BPMSoft.DataValueType.INTEGER,
			BPMSoft.DataValueType.TEXT,
			BPMSoft.DataValueType.BOOLEAN
		],

		//region Methods: Private

		/**
		 * Returns column config.
		 * @param {Object} column Column information.
		 * @param {String} column.name Column name.
		 * @param {String} column.caption Column caption.
		 * @param {Number} column.col Position of the column.
		 * @param {Number} column.colSpan Width of the column.
		 * @param {BPMSoft.DataValueType} column.dataValueType Column value type.
		 * @return {Object} Column config.
		 * @private
		 */
		getColumnConfig: function(column) {
			return {
				"bindTo": column.name,
				"caption": column.caption,
				"position": {
					"column": column.col,
					"colSpan": column.colSpan,
					"row": 1
				},
				"captionConfig": {"visible": true},
				"dataValueType": column.dataValueType,
				"metaPath": column.columnPath,
				"path": column.columnPath
			};
		},

		/**
		 * Returns default grid columns.
		 * @param {String} entitySchemaName Entity schema name.
		 * @return {Array} Default grid columns.
		 * @private
		 */
		getDefaultGridColumns: function(entitySchemaName) {
			var entitySchema = BPMSoft[entitySchemaName];
			var entitySchemaColumns = this.getAllowedEntitySchemaColumns(entitySchema.columns);
			var primaryDisplayColumnName = entitySchema.primaryDisplayColumnName;
			this.sortEntitySchemaColumns(entitySchemaColumns, "name", primaryDisplayColumnName);
			return this.getActualColumns(entitySchemaColumns);
		},

		/**
		 * Calculates column width using integer division.
		 * @private
		 */
		_getDefaultColSpan: function(columnsCount) {
			return Math.floor(this.totalGridColumnsCount / columnsCount);
		},

		/**
		 * Calculates how many columns are remained after integer division.
		 * @private
		 */
		_getColumnWidthRemainder: function(columnsCount) {
			var colSpan = this._getDefaultColSpan(columnsCount);
			var totalColumnsWidth = columnsCount * colSpan;
			return this.totalGridColumnsCount - totalColumnsWidth;
		},

		/**
		 * Calculates column width.
		 * @private
		 */
		_getCurrentColSpan: function(columnsCount, newColumnIndex) {
			var defaultColSpan = this._getDefaultColSpan(columnsCount);
			var columnWidthRemainder = this._getColumnWidthRemainder(columnsCount);
			return columnWidthRemainder > newColumnIndex ? defaultColSpan + 1 : defaultColSpan;
		},

		/**
		 * Returns first available column position in grid.
		 * @private
		 */
		_getColumnStartPosition: function(columnsConfig) {
			if (Ext.isEmpty(columnsConfig)) {
				return 0;
			}
			var lastColumnPositionConfig = columnsConfig[columnsConfig.length - 1].position;
			return lastColumnPositionConfig.column + lastColumnPositionConfig.colSpan;
		},

		/**
		 * Returns grid column config.
		 * @private
		 */
		_generateColumnConfig: function(column, positionConfig) {
			return this.getColumnConfig(Ext.Object.merge(column, positionConfig))
		},

		//endregion

		//region Methods: Protected

		/**
		 * Returns array of the entity schema columns less or equals maximum columns count.
		 * @param {Array} entitySchemaColumns Entity schema columns.
		 * @return {Array} entity schema columns less or equals maximum columns count.
		 */
		getActualColumns: function(entitySchemaColumns) {
			var maximumColumnsCount = this.maximumColumnsCount;
			return (entitySchemaColumns.length > maximumColumnsCount)
					? entitySchemaColumns.slice(0, maximumColumnsCount)
					: entitySchemaColumns;
		},

		/**
		 * Returns allowed entity schema columns.
		 * @param {Array} columns Entity schema columns.
		 * @return {Array} columns Allowed entity schema columns.
		 * @protected
		 * @virtual
		 */
		getAllowedEntitySchemaColumns: function(columns) {
			var allowedEntitySchemaColumns = [];
			BPMSoft.each(columns, function(column) {
				if (Ext.Array.contains(this.systemColumns, column.name) ||
						!Ext.Array.contains(this.allowedDataValueTypes, column.dataValueType)) {
					return;
				}
				allowedEntitySchemaColumns.push(column);
			}, this);
			return allowedEntitySchemaColumns;
		},

		/**
		 * Sorts entity schema columns by column property and column property value.
		 * @param {Array} entitySchemaColumns Entity schema columns.
		 * @param {String} propertyName Column property name for using in the sort.
		 * @param {String} propertyValue Property value for sorting.
		 * @protected
		 * @virtual
		 */
		sortEntitySchemaColumns: function(entitySchemaColumns, propertyName, propertyValue) {
			entitySchemaColumns.sort(function(a, b) {
				if (a[propertyName] === propertyValue) {
					return -1;
				}
				if (b[propertyName] === propertyValue) {
					return 1;
				}
				return 0;
			}, this);
		},

		/**
		 * Returns generated entity profile.
		 * @param {Object} config Configuration object for the entity profile generator.
		 * @param {String} config.profileKey Profile key.
		 * @param {String} config.listedConfig Columns listed config.
		 * @param {BPMSoft.GridType} gridType Grid type.
		 * @return {Object} Entity profile.
		 * @protected
		 * @virtual
		 */
		getGeneratedEntityProfile: function(config, gridType) {
			return {
				"key": config.profileKey,
				"DataGrid": {
					"listedConfig": BPMSoft.encode(config.listedConfig),
					"tiledConfig": BPMSoft.encode(config.tiledConfig),
					"key": config.profileKey,
					"isTiled": false,
					"type": gridType
				}
			};
		},

		/**
		 * Returns listed config of the columns.
		 * @param {Array} columns Columns of the entity.
		 * @return {Object} Listed config of the columns.
		 * @protected
		 * @virtual
		 */
		getGeneratedListedConfig: function(columns) {
			return {
				"items": this.getGridColumnsConfig(columns)
			};
		},

		/**
		 * Returns tiled config of the columns.
		 * @param {Array} columns Columns of the entity.
		 * @return {Object} Listed config of the columns.
		 * @protected
		 * @virtual
		 */
		generateTiledConfig: function(columns) {
			return {
				"grid": {
					"rows": 1,
					"columns": 24
				},
				"items": this.getGridColumnsConfig(columns)
			};
		},

		/**
		 * Returns list of the grid columns config.
		 * @param {Array} columns Columns of the entity.
		 * @return {Array} Grid columns config.
		 * @protected
		 * @virtual
		 */
		getGridColumnsConfig: function(columns) {
			var columnsConfig = [];
			BPMSoft.each(columns, function(column) {
				var positionConfig = {
					col: this._getColumnStartPosition(columnsConfig),
					colSpan: this._getCurrentColSpan(columns.length, columnsConfig.length)
				}
				columnsConfig.push(this._generateColumnConfig(column, positionConfig));
			}, this);
			return columnsConfig;
		},

		//endregion

		//region Methods: Public

		/**
		 * Returns entity profile.
		 * @param {String} profileKey Profile key.
		 * @param {String} entitySchemaName Entity schema name.
		 * @param {BPMSoft.GridType} gridType Grid type.
		 * @param {Object[]} [defColumns] Default visible entity columns.
		 * @return {Object} Entity profile.
		 */
		getEntityProfile: function(profileKey, entitySchemaName, gridType, defColumns) {
			gridType = gridType || BPMSoft.GridType.LISTED;
			var columns = defColumns || this.getDefaultGridColumns(entitySchemaName);
			var profileGeneratorConfig = {
				profileKey: profileKey,
				listedConfig: this.getGeneratedListedConfig(columns),
				tiledConfig: this.generateTiledConfig(columns)
			};
			return this.getGeneratedEntityProfile(profileGeneratorConfig, gridType);
		}

		//endregion
	});

	return Ext.create("BPMSoft.DefaultProfileHelper");
});
