define("MLPredictionPageMixin", ["BPMSoft", "ModalBox", "MLPredictionExplanation"],
	function(BPMSoft, ModalBox) {
		/**
		 * @class BPMSoft.configuration.mixins.MLPredictionPageMixin
		 * Mixin for pages with ML prediction features.
		 */
		Ext.define("BPMSoft.configuration.mixins.MLPredictionPageMixin", {
			alternateClassName: "BPMSoft.MLPredictionPageMixin",

			/**
			 * @private
			 */
			_subscribeOnMLPredictionExplanationMessages: function(moduleId, scoreEntityColumnName) {
				this.sandbox.subscribe("GetMLExplanationConfig", function() {
					return {
						operation: "score",
						recordDescription: this.getPrimaryDisplayColumnValue(),
						entitySchemaUId: this.entitySchema.uId,
						entitySchemaTargetColumnUId: this.entitySchema.getColumnByName(scoreEntityColumnName).uId,
						entityId: this.$Id
					};
				}.bind(this), this, [moduleId]);
				this.sandbox.subscribe("HideMLExplanationsModule", function(newPredictedValue) {
					ModalBox.close();
					if (newPredictedValue && newPredictedValue !== this.get(scoreEntityColumnName)) {
						this.set(scoreEntityColumnName, newPredictedValue);
					}
				}, this, [moduleId]);
			},

			/**
			 * Updates predictive score and shows explanation info for ml prediction.
			 * @virtual
			 * @param {String} scoreEntityColumnName Root schema entity attribute name for storing predicted value.
			 */
			calcPredictiveScoreWithContributions: function(scoreEntityColumnName) {
				const moduleId = this.sandbox.id + "MLPredictionExplanation";
				const modalBoxConfig = {
					heightPixels: 400,
					widthPixels: 600,
					boxClasses: ["ml-modal-box"]
				};
				const renderTo = ModalBox.show(modalBoxConfig, function() {
					this.sandbox.unloadModule(moduleId, renderTo);
				}, this);
				const maskId = BPMSoft.Mask.show({
					timeout: 10,
					selector: ".ml-modal-box",
					clearMasks: true,
					showSpinner: true
				});
				this.sandbox.loadModule("BaseSchemaModuleV2", {
					id: moduleId,
					renderTo: renderTo.id,
					instanceConfig: {
						parameters: {
							viewModelConfig: {
								"MaskId": maskId
							}
						},
						schemaName: "MLPredictionExplanation",
						isSchemaConfigInitialized: true,
						useHistoryState: false
					}
				});
				this._subscribeOnMLPredictionExplanationMessages(moduleId, scoreEntityColumnName);
			},

			/**
			 * Checks if any ML model's prediction enabled for current page and give column.
			 * Sets result to TrainedScoreModelExists attribute.
			 * @param {String} predictedColumnName Target prediction column name.
			 * @param {String} problemType ML problem type.
			 */
			queryWasAnyModelTrained: function(predictedColumnName, problemType) {
				const entitySchema = this.entitySchema;
				const rootSchemaUId = BPMSoft.formatGUID(entitySchema.uId, "B");
				const predictiveScoreColumn = entitySchema.getColumnByName(predictedColumnName);
				const targetColumnUId = BPMSoft.formatGUID(predictiveScoreColumn.uId, "B");
				const query = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MLModel",
					clientESQCacheParameters: {
						cacheItemName: this.entitySchemaName + "_" + problemType + "_" + "ModelIsTrained"
					}
				});
				query.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
				const entitySchemaFilter = query.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"RootSchemaUId", rootSchemaUId);
				const targetColumnFilter = query.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"TargetColumnUId", targetColumnUId);
				const predictedResultColumnFilter = query.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "PredictedResultColumnUId", targetColumnUId);
				const predictedResultColumnFilterGroup = BPMSoft.createFilterGroup();
				predictedResultColumnFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
				predictedResultColumnFilterGroup.addItem(targetColumnFilter);
				predictedResultColumnFilterGroup.addItem(predictedResultColumnFilter);
				const predictionEnabledFilter = query.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"PredictionEnabled", 1);
				const instanceFilter = query.createIsNotNullFilter(
					Ext.create("BPMSoft.ColumnExpression", {columnPath: "ModelInstanceUId"}));
				const modelTypeFilter = query.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"MLProblemType", problemType, BPMSoft.DataValueType.GUID);
				query.filters.addItem(entitySchemaFilter);
				query.filters.addItem(predictedResultColumnFilterGroup);
				query.filters.addItem(predictionEnabledFilter);
				query.filters.addItem(instanceFilter);
				query.filters.addItem(modelTypeFilter);
				query.getEntityCollection(function(result) {
					if (result.success) {
						const entity = result.collection.first();
						this.set("TrainedScoreModelExists", entity.get("Count") > 0);
					}
				}, this);
			}
		});
	});
