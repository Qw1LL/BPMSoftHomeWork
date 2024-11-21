define("FunnelByCountDataProvider", ["ext-base", "BPMSoft", "FunnelBaseDataProvider"],
		function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.FunnelByCountDataProvider
	 * Class to prepare filter for funnel by count.
	 */
	Ext.define("BPMSoft.configuration.FunnelByCountDataProvider", {
		extend: "BPMSoft.FunnelBaseDataProvider",
		alternateClassName: "BPMSoft.FunnelByCountDataProvider",

		/**
		 * Symbol for current primary currency.
		 * @protected
		 */
		primaryCurrencySymbol: "",

		/**
		 * @inheritdoc BPMSoft.FunnelBaseDataProvider#addQueryColumns
		 * @protected
		 * @overridden
		 */
		addQueryColumns: function(entitySchemaQuery) {
			this.callParent(arguments);
			entitySchemaQuery.addAggregationSchemaColumn("Budget", BPMSoft.AggregationType.SUM, "Amount");
		},

		/**
		 * @inheritdoc BPMSoft.FunnelBaseDataProvider#addFunnelPeriodFilters
		 * @protected
		 * @overridden
		 */
		applyFunnelPeriodFilters: function(filterGroup) {
			this.callParent(arguments);
			var endStageFilterGroup = BPMSoft.createFilterGroup();
			endStageFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			endStageFilterGroup.addItem(
				BPMSoft.createColumnIsNullFilter(this.getDetailColumnPath("DueDate"))
			);
			endStageFilterGroup.addItem(
				BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					this.getDetailColumnPath("Stage.End"), true, BPMSoft.DataValueType.BOOLEAN)
			);
			filterGroup.addItem(endStageFilterGroup);
		},

		/**
		 * @inheritdoc BPMSoft.FunnelBaseDataProvider#addGridDataColumns
		 * @overridden
		 */
		addGridDataColumns: function(esq) {
			//to form query with where condition instead of exists condition.
			esq.addColumn(this.getDetailColumnPath("Id"), "JoinStage");
		},

		/**
		 * @inheritdoc BPMSoft.FunnelBaseDataProvider#initAdditionalData
		 * @protected
		 * @overridden
		 */
		initAdditionalData: function(callback, scope) {
			this.callParent([function() {
				this.initPrimaryCurrencySymbol(callback, scope);
			}, this]);
		},

		/**
		 * Returns query for currency symbol.
		 * @protected
		 * @return {BPMSoft.EntitySchemaQuery}
		 */
		getCurrencyEntitySchemaQuery: function() {
			var currentCultureId = BPMSoft.SysValue.CURRENT_USER_CULTURE.value;
			var entitySchemaQuery = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "Currency",
				serverESQCacheParameters: {
					cacheLevel: BPMSoft.ESQServerCacheLevels.APPLICATION,
					cacheGroup: "Currency",
					cacheItemName: "CurrencySymbolForOpportunityFunnel" + currentCultureId
				}
			});
			entitySchemaQuery.addColumn("Symbol");
			return entitySchemaQuery;
		},

		/**
		 * Initialize primary currency symbol by current settings.
		 * @private
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope.
		 */
		initPrimaryCurrencySymbol: function(callback, scope) {
			if (this.primaryCurrencySymbol) {
				callback.call(scope);
				return;
			}
			var initSymbolCallback = this.initPrimaryCurrencySymbolById.bind(this, callback, scope);
			BPMSoft.SysSettings.querySysSettingsItem("PrimaryCurrency", initSymbolCallback, this);
		},

		/**
		 * Initialize primary currency symbol by currency id.
		 * @private
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope.
		 * @param {Object} value Currency id.
		 */
		initPrimaryCurrencySymbolById: function(callback, scope, value) {
			if (!value) {
				callback.call(scope);
				return;
			}
			var entitySchemaQuery = this.getCurrencyEntitySchemaQuery();
			var primaryCurrencyId = value.value;
			entitySchemaQuery.getEntity(primaryCurrencyId, function(response) {
				if (response && response.success) {
					var row = response.entity;
					var symbol = row && row.get("Symbol");
					this.primaryCurrencySymbol = symbol;
					if (Ext.isEmpty(symbol)) {
						var warnMessage = Ext.String.format("Can't find symbol for currency: {0}", primaryCurrencyId);
						this.log(warnMessage, BPMSoft.LogMessageType.WARNING);
					}
					callback.call(scope);
				}
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.FunnelBaseDataProvider#getSeriesDataConfigByItem
		 * @overridden
		 */
		getSeriesDataConfigByItem: function(responseItem) {
			var lcz = BPMSoft.FunnelBaseDataProvider.Resources.Strings;
			var config = this.callParent(arguments);
			var name = Ext.String.format("{0}<br/>{1}: {2}", config.menuHeaderValue, lcz.CntOpportunity, config.y);
			var budget = responseItem.get("Amount");
			budget = Ext.isNumber(budget) ? budget : 0;
			budget = BPMSoft.getFormattedNumberValue(budget, {decimalPrecision: 2});
			var primaryCurrencySymbol = this.primaryCurrencySymbol || Ext.emptyString;
			var displayValue = Ext.String.format("<br/>{0} {1} {2}", lcz.Amount, budget, primaryCurrencySymbol);
			return Ext.apply(config, {
				name: name,
				displayValue: displayValue
			});
		}

	});

});
