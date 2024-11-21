define("MLPredictionExplanation", ["MLPredictionExplanationResources", "ControlGridModule",
		"css!MLPredictionExplanationCSS", "RectProgressBar"],
	function(resources) {
	return {
		messages: {
			/**
			 * Hides ML explanations module container and returns new predicted value.
			 * @message HideMLExplanationsModule
			 */
			"HideMLExplanationsModule": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Returns entity data for ml prediction & explanation.
			 * @message GetMLExplanationConfig
			 */
			"GetMLExplanationConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Trigger to reload ml explanation data.
			 * @message ReloadMLExplanationsModule
			 */
			"ReloadMLExplanationsModule": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * Entity record description.
			 * @type {String}
			 */
			"RecordDescription": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: ""
			},
			/**
			 * Current predicted value.
			 * @type {String}
			 */
			"PredictedValue": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: null
			},
			/**
			 * Id of the loading mask.
			 * @type {String}
			 */
			"MaskId": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * Collection of the ML features with explanation info list.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"MLFeatureCollection": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION,
				value: null
			},
			/**
			 * Initial config for loading ml explanation info.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"MLExplanationConfig": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},
			/**
			 * Defines that module loaded inside modal box.
			 * @type {Boolean}
			 */
			"IsModalBoxMode": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Defines that predictive value have to be shown.
			 * @type {Boolean}
			 */
			"IsPredictiveValueVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		methods: {
			/**
			 * @param {Object} values View model column values.
			 * @private
			 */
			_createMLFeatureItemViewModel: function(values) {
				return this.Ext.create("BPMSoft.BaseViewModel", {
					columns: {
						"Id": {
							dataValueType: BPMSoft.DataValueType.GUID,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						"Value": {
							dataValueType: BPMSoft.DataValueType.TEXT,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						"Caption": {
							dataValueType: BPMSoft.DataValueType.TEXT,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						"MarkerValue": {
							dataValueType: BPMSoft.DataValueType.TEXT,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						"Weight": {
							dataValueType: BPMSoft.DataValueType.TEXT,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						"IndicatorWeight": {
							dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						},
						"IndicatorMarker": {
							dataValueType: BPMSoft.DataValueType.TEXT,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
						}
					},
					values: values
				});
			},

			/**
			 * @param {Object} contributionInfo ML predictor service response item with feature weight info.
			 * @param {Number} maxModuleWeight Max module weight for in service response collection.
			 * @param {Boolean} [ignoreValues] If true ignores service value when caption filling.
			 * @return {BPMSoft.BaseViewModel} view model item for features data grid.
			 * @private
			 */
			_createMLFeatureWeightedItem: function(contributionInfo, maxModuleWeight, ignoreValues) {
				let featureCaption = !Ext.isEmpty(contributionInfo.caption)
					? contributionInfo.caption
					: contributionInfo.name;
				const value = !Ext.isEmpty(contributionInfo.displayValue)
					? contributionInfo.displayValue
					: contributionInfo.value;
				if (!Ext.isEmpty(value) && !ignoreValues) {
					featureCaption = featureCaption + " = " + BPMSoft.numberToString(value);
				}
				const weight = contributionInfo.weight;
				let indicatorMarker = "near-zero-feature-weight";
				let fixedWeight = weight.toFixed(2);
				if (Math.abs(weight) >= 0.01) {
					indicatorMarker = weight < 0.0 ? "negative-feature-weight" : "positive-feature-weight";
					fixedWeight = (weight < 0.0 ? "" : "+") + fixedWeight;
				} else {
					fixedWeight = "~0";
				}
				return this._createMLFeatureItemViewModel({
					Id: BPMSoft.generateGUID(),
					Caption: featureCaption,
					MarkerValue: contributionInfo.feature,
					Weight: fixedWeight,
					IndicatorMarker: indicatorMarker,
					IndicatorWeight: Math.round(Math.abs(weight) * 100.0 / maxModuleWeight)
				});
			},

			/**
			 * @param {Array} weightedCollection Feature array with localized names and weight.
			 * @param {Boolean} [ignoreValues] If true ignores service value when caption filling.
			 * @private
			 */
			_fillMLFeatureCollection: function(weightedCollection, ignoreValues) {
				const collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				if (BPMSoft.isEmpty(weightedCollection)) {
					return;
				}
				const topElementCount = 15;
				const sortedFeatures = weightedCollection.sort(function(element1, element2) {
					return Math.abs(element1.weight) < Math.abs(element2.weight) ? 1 : -1;
				}).slice(0, topElementCount);
				const maxModuleWeight = Math.abs(BPMSoft.first(sortedFeatures).weight);
				BPMSoft.each(sortedFeatures, function(elem) {
					const item =
						this._createMLFeatureWeightedItem(elem, maxModuleWeight, ignoreValues);
					collection.add(item.$Id, item);
				}, this);
				this.$MLFeatureCollection.loadAll(collection);
			},

			/**
			 * @param {Object} response MLPredictorService response for ScoreAndExplain method.
			 * @private
			 */
			_loadScoreServiceResponse: function(response) {
				const scoreEntityResult = response.result || {};
				const exitCode = scoreEntityResult.exitCode;
				if (this.$MaskId) {
					BPMSoft.Mask.hide(this.$MaskId);
				}
				if (exitCode !== 0) {
					BPMSoft.showErrorMessage(this.get("Resources.Strings.ScoreServiceErrorMessage"), function() {
						this.hideModule();
					}, this);
					return;
				}
				this.$PredictedValue = Math.round(scoreEntityResult.score * 100);
				this._fillMLFeatureCollection(scoreEntityResult.contributions, false);
			},

			/**
			 * Initialize features collection.
			 * @private
			 */
			_initCollection: function() {
				const collection = this.get("MLFeatureCollection");
				if (this.isEmpty(collection)) {
					this.set("MLFeatureCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				}
			},

			/**
			 * @param {Object} [explanationConfig] Config to load ml explanation info.
			 * @private
			 */
			_refreshModuleInfo: function(explanationConfig) {
				const config = explanationConfig ||
					this.sandbox.publish("GetMLExplanationConfig", null, [this.sandbox.id]);
				if (!config) {
					return;
				}
				this.$RecordDescription = config.recordDescription;
				switch (config.operation) {
					case "score":
						this.rescoreWithExplanation(config);
						break;
					case "getModelExplanation":
						this.$IsPredictiveValueVisible = false;
						this.$MLFeatureCollection.clear();
						this._getModelExplanation(config);
						break;
					default:
						throw new BPMSoft.NotImplementedException();
				}
			},

			/**
			 * @param {Object} response MLTrainerService response for GetFeatureImportances method.
			 * @private
			 */
			_loadFeatureImportancesServiceResponse: function(response) {
				const responseResult = response.result || {};
				const featuresImportance = responseResult.value;
				if (!featuresImportance || featuresImportance.length === 0) {
					this.hideModule();
				}
				this._fillMLFeatureCollection(featuresImportance, true);
			},

			/**
			 * @param {Object} explanationConfig Config to load ml explanation info.
			 * @private
			 */
			_getModelExplanation: function(explanationConfig) {
				this.callService({
						serviceName: "MLTrainerService",
						methodName: "GetFeatureImportances",
						data: {
							trainSessionId: explanationConfig.trainSessionId
						}
					},
					this._loadFeatureImportancesServiceResponse, this);
			},
			/**
			 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
			 * @override
			 */
			init: function() {
				this._initCollection();
				this._refreshModuleInfo(this.$MLExplanationConfig);
				this.sandbox.subscribe("ReloadMLExplanationsModule", function() {
					this._refreshModuleInfo();
				}, this);
				this.callParent(arguments);
			},

			/**
			 * Hides module container.
			 * @protected
			 */
			hideModule: function() {
				if (this.$MaskId) {
					BPMSoft.Mask.hide(this.$MaskId);
				}
				this.sandbox.publish("HideMLExplanationsModule", this.$PredictedValue, [this.sandbox.id]);
			},

			/**
			 * @param {Object} control Grid row config.
			 * @protected
			 */
			applyControlConfig: function(control) {
				control.config = {
					className: "BPMSoft.RectProgressBar",
					value: "$IndicatorWeight",
					caption: "$Weight",
					markerValue: "$IndicatorMarker",
					progressColor: null,
					sectorsColors: [],
					horizontal: true
				};
			},

			/**
			 * @param {Object} scoreConfig Entity parameters for re-scoring.
			 * @protected
			 */
			rescoreWithExplanation: function(scoreConfig) {
				this.callService({
						serviceName: "MLPredictorService",
						methodName: "ScoreAndExplain",
						data: {
							entitySchemaUId: scoreConfig.entitySchemaUId,
							entitySchemaTargetColumnUId: scoreConfig.entitySchemaTargetColumnUId,
							entityId: scoreConfig.entityId
						}
					},
					this._loadScoreServiceResponse, this);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MLFeaturesContainerWrapper",
				"values": {
					"id": "MLFeaturesContainerWrapper",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["ml-feature-container-wrapper"],
					"markerValue": "ml-feature-container",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MLFeaturesHeaderContainer",
				"parentName": "MLFeaturesContainerWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["ml-feature-header-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "RecordDescription",
				"parentName": "MLFeaturesHeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$RecordDescription",
					"labelConfig": {
						"classes": ["ml-record-description"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CloseButton",
				"parentName": "MLFeaturesHeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": "$Resources.Images.CloseIcon",
					"click": "$hideModule",
					"visible": "$IsModalBoxMode",
					"classes": {
						"wrapperClass": ["ml-feature-close-button"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "MLFeaturesContainer",
				"parentName": "MLFeaturesContainerWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["ml-feature-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PredictedValueContainer",
				"parentName": "MLFeaturesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["ml-predicted-value-container"],
					"items": [],
					"visible": "$IsPredictiveValueVisible"
				}
			},
			{
				"operation": "insert",
				"name": "PredictedValueCaption",
				"parentName": "PredictedValueContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.PredictedValueCaption",
					"labelConfig": {
						"classes": ["ml-predicted-value-caption"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "PredictedValue",
				"parentName": "PredictedValueContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$PredictedValue",
					"labelConfig": {
						"classes": ["ml-predicted-value"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "DataGrid",
				"parentName": "MLFeaturesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID,
					"className": "BPMSoft.ControlGrid",
					"controlColumnName": "Weight",
					"applyControlConfig": "$applyControlConfig",
					"type": "listed",
					"columnsConfig": [
						{
							"cols": 16,
							"key": [
								{"name": {"bindTo": "Caption"}}
							]
						},
						{
							"cols": 8,
							"key": [
								{"name": {"bindTo": "Weight"}}
							]
						}
					],
					"captionsConfig": [
						{
							"cols": 16,
							"name": resources.localizableStrings.FeatureCaption
						},
						{
							"cols": 8,
							"name": resources.localizableStrings.WeightCaption
						}
					],
					"listedZebra": true,
					"collection": "$MLFeatureCollection",
					"primaryColumnName": "Id",
					"multiSelect": false
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
