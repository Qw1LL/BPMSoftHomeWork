define("PivotTableUtilities", [], function() {
	Ext.define("BPMSoft.configuration.mixins.PivotTableUtilities", {
		alternateClassName: "BPMSoft.PivotTableUtilities",

		statics: {
			/**
			 * Validate pivot table config.
			 * @param {Object} config 
			 */
			validatePivotConfig: function(config) {
				if (!config) {
					return false;
				}
				const hasRows = !BPMSoft.isEmpty(config.rows);
				const hasAggregates = !BPMSoft.isEmpty(config.aggregates);
				return hasRows && hasAggregates;
			},

			/**
			 * Returns true when pivot table is enabled.
			 * Check features and browsers.
			 */
			isEnabledPivotTable: function() {
				const isAvailableBrowser = !Ext.isIEOrEdge;
				const isPivotTableFeatureEnabled = BPMSoft.Features.getIsEnabled("PivotTable");
				const isEnabledOffsetFetch = BPMSoft.useOffsetFetchPaging;
				return isAvailableBrowser && isPivotTableFeatureEnabled && isEnabledOffsetFetch;
			},

			/**
			 * Returns pivot table designer diff configuration.
			 */
			getPivotTableDesignerViewConfig: function() {
				const isEnabledPivotTable = BPMSoft.PivotTableUtilities.isEnabledPivotTable();
				return isEnabledPivotTable
					? {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.PivotTableDesigner",
						"options": {"bindTo": "PivotTableDesignerOptions"},
						"optionsChanged": {"bindTo": "onPivotTableOptionsChanged"}
					}
					: {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					};
			}
		},

		/**
		 * Generates default pivot table configuration.
		 * @protected
		 * @returns {Object} Default pivot table config.
		 */
		getDefaultPivotTableConfig: function() {
			return {
				rows: [],
				columns: [],
				aggregates: []
			}
		},

		/**
		 * Returns pivot table view options.
		 * @protected
		 * @param {Object} gridConfig Dashboard widget grid config.
		 */
		getPivotViewOptions: function(gridConfig) {
			gridConfig = gridConfig || {};
			const gridColumnsConfigs = gridConfig.items || [];
			const fieldsOptions = this._getPivotFieldsOptions(gridColumnsConfigs);
			return {
				fieldsOptions: fieldsOptions
			};
		},

		/**
		 * @private
		 */
		_getPivotFieldsOptions: function(gridColumnsConfigs) {
			return BPMSoft.map(gridColumnsConfigs, function(columnConfig) {
				return { 
					fieldId: columnConfig.bindTo, 
					fieldCaption: columnConfig.caption,
					fieldType: columnConfig.dataValueType,
					fieldExpression: columnConfig.expression || this._getExpression(columnConfig),
				};
			}, this);
		},

		/**
		 * @private
		 */
		_getExpression: function(columnConfig) {
			return {
				definitionId: columnConfig.bindTo,
				type: BPMSoft.FormulaExpressionType.OPERAND,
				operandType: BPMSoft.OperandType.COLUMN,
				columnOperandType: columnConfig.aggregationType 
					? BPMSoft.ColumnOperandType.AGGREGATION
					: BPMSoft.ColumnOperandType.SCHEMACOLUMN,
				columnPath: columnConfig.metaPath || columnConfig.bindTo,
				subFilters: columnConfig.serializedFilter,
				aggregationType: columnConfig.aggregationType,
				dataType: columnConfig.dataValueType
			}
		}
	});
	return Ext.create("BPMSoft.PivotTableUtilities");
});
