define("TimelineColumnFiltersBuilder", [], function() {
	/**
	 * Class containing logic for building column filters for Timeline data providers.
	 * See {@link BPMSoft.CompareFilter}.
	 */
	Ext.define("BPMSoft.configuration.TimelineColumnFiltersBuilder", {
		alternateClassName: "BPMSoft.TimelineColumnFiltersBuilder",

		// region Methods: Private

		/**
		 * Builds exists filter by owner for request.
		 * @private
		 * @param {Object} ownerFilterConfig Owner filter config.
		 * @param {Object} owner Value for filtering.
		 * @return {BPMSoft.ExistsFilter} Exists filter.
		 */
		_buildExistsOwnerFilter: function(ownerFilterConfig, owner) {
			var subFilters = BPMSoft.createFilterGroup();
			subFilters.addItem(
				BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					ownerFilterConfig.subFilterColumnName,
					owner.value
				)
			);
			return BPMSoft.createExistsFilter(ownerFilterConfig.existsFilterColumnName, subFilters);
		},

		// endregion

		// region Methods: Public

		/**
		 * Builds filter by period for request.
		 * @param {Object} entityConfig Config for loading data.
		 * @param {Object} userFilters User filter config.
		 * @return {BPMSoft.CompareFilter|null}
		 */
		buildPeriodFilter: function(entityConfig, userFilters) {
			if (!userFilters || !userFilters.periodFilter) {
				return null;
			}
			var periodFilter = userFilters.periodFilter;
			var startDate = periodFilter.startDate;
			var dueDate = periodFilter.dueDate;
			var filterColumnName = entityConfig.orderColumnName;
			var filter = null;
			if (Ext.isDate(startDate) && Ext.isDate(dueDate)) {
				filter = BPMSoft.createColumnBetweenFilterWithParameters(
					filterColumnName,
					BPMSoft.startOfDay(startDate),
					BPMSoft.endOfDay(dueDate)
				);
			} else if (Ext.isDate(startDate)) {
				filter = BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.GREATER_OR_EQUAL,
					filterColumnName,
					BPMSoft.startOfDay(startDate)
				);
			} else if (Ext.isDate(dueDate)) {
				filter = BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.LESS_OR_EQUAL,
					filterColumnName,
					BPMSoft.endOfDay(dueDate)
				);
			}
			return filter;
		},

		/**
		 * Builds filter by owner for request.
		 * @param {Object} entityConfig Config for loading data.
		 * @param {Object} userFilters User filter config.
		 * @return {BPMSoft.FilterGroup|null}
		 */
		buildOwnerFilter: function(entityConfig, userFilters) {
			var filterColumnName = entityConfig.authorColumnName;
			if (!userFilters || !userFilters.ownerFilter || !filterColumnName) {
				return null;
			}
			var ownerFilters = userFilters.ownerFilter;
			var filtersConfig = entityConfig.filters || {};
			var ownerFilterConfig = filtersConfig.ownerFilter || {};
			var isExistsFilter =
				ownerFilterConfig.comparisonType &&
				ownerFilterConfig.comparisonType === BPMSoft.ComparisonType.EXISTS;
			var filterGroup = BPMSoft.createFilterGroup();
			filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			BPMSoft.each(ownerFilters, function(owner) {
				if (!owner.value) {
					return;
				}
				if (isExistsFilter && ownerFilterConfig.existsFilterColumnName &&
					ownerFilterConfig.subFilterColumnName) {
					filterGroup.addItem(this._buildExistsOwnerFilter(ownerFilterConfig, owner));
				} else {
					filterGroup.addItem(
						BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							filterColumnName,
							owner.value
						)
					);
				}
			}, this);
			return filterGroup;
		},

		/**
		 * Builds filter by primary column value.
		 * @param {Object} entityConfig Config for loading data.
		 * @return {BPMSoft.CompareFilter}
		 */
		buildMasterColumnFilter: function(entityConfig) {
			return BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL,
				entityConfig.referenceColumnName,
				entityConfig.masterRecordValue
			);
		},

		/**
		 * Builds filter by type for request.
		 * @param {Object} entityConfig Config for loading data.
		 * @return {BPMSoft.CompareFilter|null}
		 */
		buildTypeFilter: function(entityConfig) {
			var typeFilterConfig = (entityConfig.filters && entityConfig.filters.typeFilter) || {};
			var typeColumnName = typeFilterConfig.columnName || entityConfig.typeColumnName;
			var typeColumnValue = typeFilterConfig.columnValue || entityConfig.typeColumnValue;
			var comparisonType = typeFilterConfig.comparisonType || BPMSoft.ComparisonType.EQUAL;
			return typeColumnName && typeColumnValue
				? BPMSoft.createColumnFilterWithParameter(comparisonType, typeColumnName, typeColumnValue)
				: null;
		},

		/**
		 * Builds custom filter for request.
		 * @param {Object} entityConfig Config for loading data.
		 * @return {BPMSoft.CompareFilter|null}
		 */
		buildCustomFilter: function(entityConfig) {
			var customFilterConfig = entityConfig.filters && entityConfig.filters.customFilter;
			if (!customFilterConfig) {
				return null;
			}
			var comparisonType = customFilterConfig.comparisonType;
			switch (comparisonType) {
				case BPMSoft.ComparisonType.IS_NULL: {
					return BPMSoft.createColumnIsNullFilter(customFilterConfig.columnName);
				}
				case BPMSoft.ComparisonType.EQUAL:
				case BPMSoft.ComparisonType.NOT_EQUAL: {
					return BPMSoft.createColumnFilterWithParameter(
						comparisonType,
						customFilterConfig.columnName,
						customFilterConfig.columnValue
					);
				}
				default: {
					return null;
				}
			}
		},

		/**
		 * Builds filter checking that order column is not empty.
		 * @param {Object} entityConfig Config for loading data.
		 * @return {BPMSoft.CompareFilter|null}
		 */
		buildOrderColumnNotEmptyFilter: function(entityConfig) {
			//TODO: Error on Oracle version below 12. After fix remove the condition.
			return BPMSoft.useOffsetFetchPaging
				? BPMSoft.createColumnIsNotNullFilter(entityConfig.orderColumnName)
				: null;
		},

		/**
		 * Builds primary column value filter for entity schema query.
		 * @param {Object} entityConfig Config for loading data.
		 * @return {BPMSoft.CompareFilter|null}
		 */
		buildPrimaryColumnFilter: function(entityConfig) {
			var primaryColumnFilter = entityConfig.filters && entityConfig.filters.primaryColumnFilter;
			return primaryColumnFilter
				? BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					primaryColumnFilter.primaryColumnName,
					primaryColumnFilter.primaryColumnValue
				)
				: null;
		}

		// endregion

	});

	return Ext.create("BPMSoft.TimelineColumnFiltersBuilder");
});
