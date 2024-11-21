define("LeadPageV2", ["MLConfigurationConsts", "IconizedProgressBarGenerator", "LeadPageV2Resources",
		"css!LeadPageV2MLCss", "MLPredictionPageMixin"],
		function(MLConfigurationConsts) {
	return {
		entitySchemaName: "Lead",
		messages: {
			/**
			 * Returns entity data for ml prediction & explanation.
			 * @message GetMLExplanationConfig
			 */
			"GetMLExplanationConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Hides ML explanations module container.
			 * @message HideMLExplanationsModule
			 */
			"HideMLExplanationsModule": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: ["BPMSoft.MLPredictionPageMixin"],
		attributes: {
			"TrainedScoreModelExists": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/,
		methods: {
			/**
			 * @private
			 * @return {String} value of predictive score or empty string if score is zero.
			 */
			_getPredictiveScoreCaption: function() {
				return this.$PredictiveScore > 0 ? this.$PredictiveScore : "";
			},
			/**
			 * @private
			 * @return {Boolean} true if predictive score need to be shown.
			 */
			_getIsPredictiveScoreVisible: function() {
				return this.get("TrainedScoreModelExists") && !this.isNewMode();
			},
			/**
			 * Returns column caption for entity column.
			 * @param {String} columnName Entity column name.
			 * @return {String} Caption for entity column.
			 * @private
			 */
			_getEntityColumnCaption: function(columnName) {
				return this.entitySchema.getColumnByName(columnName).caption;
			},

			_sendScoringExplanationAnalytics: function() {
				if (!this.$IsGoogleTagManagerEnabled) {
					return;
				}
				const data = this.getGoogleTagManagerData();
				this.Ext.apply(data, {
					action: "LeadScoringExplanation"
				});
				BPMSoft.GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * Recalculates score value and shows explanation for new predicted value.
			 * @protected
			 */
			getPredictiveScoreWithContributions: function() {
				this._sendScoringExplanationAnalytics();
				this.calcPredictiveScoreWithContributions("PredictiveScore");
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 */
			init: function() {
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.queryWasAnyModelTrained("PredictiveScore", MLConfigurationConsts.ProblemTypes.Scoring);
			}
		},
		modules: {},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "LeadPredictiveScoreContainer",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 0,
						"row": 8,
						"colSpan": 24
					},
					"items": [],
					"tips": [{
						"content": {"bindTo": "Resources.Strings.PredictiveScoreTip"}
					}],
					"wrapClass": ["progress-bar-container"],
					"visible": {
						"bindTo": "_getIsPredictiveScoreVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "LeadPredictiveScoreLabelContainer",
				"parentName": "LeadPredictiveScoreContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["control-width-15"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "LeadPredictiveScoreLabel",
				"parentName": "LeadPredictiveScoreLabelContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.TipLabel",
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "_getEntityColumnCaption"},
					"tag": "PredictiveScore",
					"isRequired": true,
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPredictiveScoreContainer",
				"propertyName": "items",
				"name": "PredictiveScoreBar",
				"values": {
					"generator": "IconizedProgressBarGenerator.generateProgressBar",
					"controlConfig": {
						"value": "$PredictiveScore",
						"caption": {"bindTo": "_getPredictiveScoreCaption"},
						"captionSuffix": "",
						"sectorsBounds": [0, 49, 79, 100]
					},
					"tips": [],
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"click": "$getPredictiveScoreWithContributions"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
