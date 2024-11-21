define("BasePageV2", [], function() {
	return {
		attributes: {

			/**
			 * Predictable column state suffix.
			 * @type {String}
			 */
			"DefaultPredictableColumnStateSuffix": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": "PredictableState"
			}
		},
		methods: {

			/**
			 * Returns predictable model column name.
			 * @private
			 * @param {String} modelKey Predictable model key.
			 * @return {String} Predictable model column name.
			 */
			_getPredictableModelColumnName: function(modelKey) {
				var predictableEntities = BPMSoft.configuration.PredictableEntities;
				var entitySchemaName = (this.entitySchema && this.entitySchema.name) || this.entitySchemaName;
				var model = predictableEntities && predictableEntities[entitySchemaName] &&
					predictableEntities[entitySchemaName].Models[modelKey];
				var modelColumnName = model && model.output && model.output.name;
				return modelColumnName;
			},

			/**
			 * Returns attributes name for column's ML prediction config.
			 * @private
			 * @param {String} columnName Column name used for prediction.
			 */
			_getPredictableStateAttrName: function(columnName) {
				return this.Ext.String.format("{0}{1}", columnName, this.get("DefaultPredictableColumnStateSuffix"));
			},


			/**
			 * Sends usage analytics for predictable column.
			 * @param columnName {String} name of predictable column.
			 */
			sendPredictableColumnAnalytics: function(columnName) {
				if (!this.$IsGoogleTagManagerEnabled) {
					return;
				}
				const data = this.getGoogleTagManagerData();
				this.Ext.apply(data, {
					description: columnName,
					action: "PredictableIconClicked"
				});
				BPMSoft.GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.getPredictableColumnsStates(this.setPredictableColumnsStates, this);
			},

			/**
			 * Sets predictable column state.
			 * @protected
			 * @param {Object} column Entity column configuration.
			 * @param {Object} modelState Predictable column model state.
			 */
			setPredictableColumnState: function(column, modelState) {
				if (modelState.state === BPMSoft.PredictableState.INPROGRESS) {
					return;
				}
				var columnName = column.name;
				var predictableColumnAttrName = this._getPredictableStateAttrName(columnName);
				var columnValue = this.get(columnName);
				var isNotExact = modelState.state === BPMSoft.PredictableState.EXACT &&
					(columnValue && columnValue.value) !== modelState.value.toLowerCase();
				var state = isNotExact ? {
						state: BPMSoft.PredictableState.NOTEXACT,
						value: modelState.value
					} : modelState;
				this.set(predictableColumnAttrName, state);
			},

			/**
			 * Returns mapped predictable columns.
			 * @private
			 * @return {Object} Mapped predictable columns.
			 * Key - entity column value name, value - column configuration.
			 */
			_getMappedPredictableColumns: function() {
				var columnValueNameColumns = {};
				var entitySchemaName = (this.entitySchema && this.entitySchema.name) || this.entitySchemaName;
				BPMSoft.each(this.columns, function(column) {
					if (BPMSoft.getIsPredictableColumn(entitySchemaName, column)) {
						columnValueNameColumns[BPMSoft.getEntityColumnValueName(column)] = column;
					}
				}, this);
				return columnValueNameColumns;
			},

			/**
			 * Sets predictable columns model states.
			 * @protected
			 * @param {Object} modelStates Predictable columns model states.
			 */
			setPredictableColumnsStates: function(modelStates) {
				var predictableColumns = this._getMappedPredictableColumns(modelStates);
				BPMSoft.each(modelStates, function(modelState, modelKey) {
					var column = predictableColumns[this._getPredictableModelColumnName(modelKey)];
					if (!this.Ext.isEmpty(column)) {
						this.setPredictableColumnState(column, modelState);
					}
				}, this);
			},

			/**
			 * Gets predictable columns states.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			getPredictableColumnsStates: function(callback, scope) {
				var entitySchema = this.entitySchema;
				if (this.isEmpty(entitySchema)) {
					Ext.callback(callback, scope || this, null);
					return;
				}
				this.callService({
					serviceName: "MLPredictionStateService",
					methodName: "GetColumnsPredictionStates",
					data: {
						schemaUId: entitySchema && entitySchema.uId,
						entityId: this.get(this.primaryColumnName)
					}
				}, function(response) {
					var result = this.isEmpty(response) ? null : JSON.parse(response);
					Ext.callback(callback, scope || this, [result]);
				}, this);
			},

			/**
			 * Removes all column sorting from entity schema query.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq Predictable lookup query.
			 */
			removeColumnSorting: function(esq) {
				esq.columns.each(function(column) {
					delete column.orderDirection;
					delete column.orderPosition;
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#appendPredictableQueryColumns
			 * @override
			 */
			appendPredictableQueryColumns: function(esq) {
				this.removeColumnSorting(esq);
				const predictableColumn =
					esq.addColumn("[MLClassificationResult:Value:Id].Probability", "predictableValue");
				predictableColumn.orderDirection = BPMSoft.OrderDirection.DESC;
				predictableColumn.orderPosition = 1;
				esq.addColumn("[MLClassificationResult:Value:Id].Significance", "significance");
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#appendPredictableQueryConditions
			 * @override
			 */
			appendPredictableQueryConditions: function(esq, columnName) {
				var predictableStateAttrName = this._getPredictableStateAttrName(columnName);
				var predictableState = this.get(predictableStateAttrName);
				esq.filters.add("ModelFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"[MLClassificationResult:Value:Id].Model", predictableState.modelId));
				esq.filters.add("KeyFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"[MLClassificationResult:Value:Id].Key", this.get(this.primaryColumnName)));
				esq.filters.add("ProbabilityFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.GREATER_OR_EQUAL,
					"[MLClassificationResult:Value:Id].Probability", 0.01));
			}

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/
	};
});
