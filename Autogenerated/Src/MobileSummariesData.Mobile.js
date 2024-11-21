/**
 * @class BPMSoft.configuration.SummariesData
 */
Ext.define("BPMSoft.configuration.SummariesData", {
	extend: "BPMSoft.core.AbstractSummariesData",

	// region Methods: Private

	/**
	 * @private
	 */
	getCancellationId: function(key) {
		return Ext.String.format("summary{0}{1}_{2}", this.modelName, key, this.$className);
	},

	/**
	 * @private
	 */
	getValue: function(config) {
		return new Promise(function(resolve, reject) {
			if (config.useEmptyValues) {
				resolve(null);
				return;
			}
			var modelName = this.modelName;
			var model = BPMSoft.getModelClass(modelName);
			var columnName = config.columnName;
			var columnConfig = model.ColumnConfigs.get(columnName);
			var functionQueryColumn = Ext.create("BPMSoft.FunctionQueryColumn", {
				alias: columnName,
				columnPath: columnName,
				functionType: BPMSoft.QueryFunctionType.Aggregation,
				aggregationType: config.aggregationType
			});
			var query = Ext.create("BPMSoft.SelectQuery", {
				rootSchemaName: modelName,
				filters: config.filters,
				columns: [functionQueryColumn]
			});
			var summaryCancellationId = this.getCancellationId(columnName + config.aggregationType);
			BPMSoft.QueryExecutor.execute(BPMSoft.QueryType.Select, {
				dataSourceType: BPMSoft.DataUtils.getDataSourceByProxyType(config.proxyType),
				query: query,
				cancellationId: summaryCancellationId,
				success: function(data) {
					var resultRow = data.rows[0];
					if (resultRow) {
						var value = BPMSoft.String.getModelTypedValue(columnConfig.columnType, resultRow[columnName]);
						resolve(value);
					} else {
						resolve();
					}
				},
				failure: function(exception) {
					reject(exception);
				},
				scope: this
			});
		}.bind(this));
	},

	/**
	 * @private
	 */
	getQueryAggregationType: function(queryAggregationTypeString) {
		var result;
		switch(queryAggregationTypeString) {
			case ("SUM"):
				result = BPMSoft.QueryAggregationType.Sum;
				break;
			case ("COUNT"):
				result = BPMSoft.QueryAggregationType.Count;
				break;
			case ("AVG"):
				result = BPMSoft.QueryAggregationType.Avg;
				break;
			case ("MIN"):
				result = BPMSoft.QueryAggregationType.Min;
				break;
			case ("MAX"):
				result = BPMSoft.QueryAggregationType.Max;
				break;
			default:
				result = BPMSoft.QueryAggregationType.None;
		}
		return result;
	},

	// endregion

	/**
	 * Returns default summaries for section (in case if no summary is set on server).
	 * @protected
	 * @return {Object[]} Summary configs.
	 */
	getDefaultSummaryConfigs: function() {
		var model = BPMSoft.getModelClass(this.modelName);
		return [{
			caption: BPMSoft.LS.MobileSummariesDataQuantityCaption,
			columnName: model.PrimaryColumnName,
			aggregationType: BPMSoft.QueryAggregationType.Count,
			value: null
		}];
	},

	// region Methods: Public

	/**
	 * Returns profile key with summary settings.
	 * @return {String} Profile key.
	 */
	getProfileKey: function() {
		return Ext.String.format("Section-{0}-MainGrid-Summary", this.modelName);
	},

	/**
	 * Returns summary configs without data.
	 * @return {Promise<Object[]>} Summary configs without data.
	 */
	getConfigs: function() {
		if (this.configs) {
			return Promise.resolve(this.configs);
		}
		var profileKey = this.getProfileKey();
		return BPMSoft.ProfileData.get(profileKey).then(function(profileData) {
			var decodedProfileData = BPMSoft.decode(profileData, true);
			var configs = [];
			if (!Ext.isEmpty(decodedProfileData) && Ext.isArray(decodedProfileData)) {
				BPMSoft.each(decodedProfileData, function(profileItem) {
					var caption = profileItem.length > 1 ? profileItem[2] : profileItem[0];
					configs.push({
						caption: caption,
						columnName: profileItem[0],
						aggregationType: this.getQueryAggregationType(profileItem[1]),
						value: null
					});
				}, this);
				this.configs = configs;
			} else {
				configs = this.getDefaultSummaryConfigs();
			}
			return configs;
		}.bind(this));
	},

	/**
	 * Returns summary configs with data.
	 * @param {BPMSoft.QueryFilter} config.filters Query filters.
	 * @param {BPMSoft.ProxyType} config.proxyType Proxy type.
	 * @param {Boolean} config.useEmptyValues If true, fill configs with empty values.
	 * @return {Promise<Object[]>} Promise.
	 */
	getValues: function(config) {
		return this.getConfigs().then(function(summaryConfigs) {
			var promises = [];
			BPMSoft.each(summaryConfigs, function(summaryConfig) {
				promises.push(this.getValue({
					columnName: summaryConfig.columnName,
					aggregationType: summaryConfig.aggregationType,
					filters: config.filters,
					useEmptyValues: config.useEmptyValues,
					proxyType: config.proxyType
				}).then(function(value) {
					summaryConfig.value = value;
				}.bind(this)));
			}, this);
			return Promise.all(promises).then(function() {
				return summaryConfigs;
			}.bind(this));
		}.bind(this));
	}

	// endregion

});

BPMSoft.core.constants.SummariesDataClassName = "BPMSoft.configuration.SummariesData";
