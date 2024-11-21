define("EsqTimelineSearchProvider", ["BaseTimelineSearchProvider"], function() {
	/**
	 * ESQ timeline search provider class.
	 */
	Ext.define("BPMSoft.configuration.EsqTimelineSearchProvider", {
		extend: "BPMSoft.BaseTimelineSearchProvider",
		alternateClassName: "BPMSoft.EsqTimelineSearchProvider",

		// region Properties: Private

		/**
		 * Finds all columns of entity that should be used for search.
		 * @private
		 * @param {Object} entityConfig Enitity timeline configuration.
		 * @return {String[]} Names of columns to search.
		 */
		_getEntitySearchColumns: function(entityConfig) {
			var searchColumns = [entityConfig.captionColumnName, entityConfig.messageColumnName];
			var entityColumns = entityConfig.columns || [];
			var additionalSearchColumns = entityColumns
				.filter(function(columnConfig) {
					return columnConfig.isSearchEnabled;
				})
				.map(function(columnConfig) {
					return columnConfig.columnName;
				});
			searchColumns = searchColumns.concat(additionalSearchColumns).filter(function(columnName) {
				return !Ext.isEmpty(columnName) && Ext.isString(columnName);
			});
			return searchColumns;
		},

		/**
		 * Builds ESQ filter group for search by entity timeline configuration.
		 * @private
		 * @param {Object} entityConfig Enitity timeline configuration.
		 * @param {String} searchKey Text to search.
		 * @return {BPMSoft.FilterGroup|null} ESQ filter group instance.
		 */
		_buildEntityEsqFilter: function(entityConfig, searchKey) {
			var searchColumns = this._getEntitySearchColumns(entityConfig);
			if (searchColumns.length === 0) {
				return null;
			}
			var filterGroup = Ext.create("BPMSoft.FilterGroup", {
				logicalOperation: BPMSoft.LogicalOperatorType.OR
			});
			BPMSoft.each(searchColumns, function(columnName) {
				filterGroup.addItem(
					BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.CONTAIN,
						columnName,
						searchKey
					)
				);
			}, this);
			return filterGroup;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseTimelineSearchProvider#performSearch
		 * @override
		 */
		performSearch: function(options) {
			var esqFilters = {};
			var args = Ext.isArray(options.args) ? options.args : [];
			BPMSoft.each(options.entitiesConfig, function(entityConfig) {
				var entityConfigKey = entityConfig.entityConfigKey;
				var esqFilter = this._buildEntityEsqFilter(entityConfig, options.searchKey);
				esqFilters[entityConfigKey] = esqFilter;
			}, this);
			Ext.callback(options.callback, options.scope, [esqFilters].concat(args));
		}

		// endregion

	});
});
