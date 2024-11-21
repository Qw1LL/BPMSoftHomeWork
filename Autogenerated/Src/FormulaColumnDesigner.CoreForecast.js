define("FormulaColumnDesigner", ["css!FormulaColumnDesigner"], function() {
	return {
		attributes: {
			/**
			 * Column settings.
			 */
			"ColumnSettings": {
				"dataValueType": BPMSoft.DataValueType.OBJECT,
				"value": ""
			},

			/**
			 * Formula value.
			 */
			"FormulaValue": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": ""
			},
			/**
			 * Use in summary.
			 */
			"UseInSummary": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		messages: {
			/**
			 * @message GetColumnConfig
			 * Returns column config from loaded module.
			 */
			"GetColumnConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			/**
			 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this._subscribeMessages();
				this.callParent([function() {
					this._initFormulaValue();
					this.Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @overridden
			 */
			onRender: function() {
				this._addFormulaComponent();
			},

			/**
			 * @private
			 */
			_addFormulaComponent: function() {
				const element = document.createElement("ts-forecast-column-formula");
				element.forecastId = this.$ForecastSheetId;
				element.baseUrl = this.BPMSoft.workspaceBaseUrl;
				element.formulaData = this.$FormulaValue;
				element.useFunctions = this.$IsSummaryColumn && this.getIsFeatureEnabled("ForecastSummaryFormula");
				element.addEventListener("formulaChanged", this.handleFormulaChanged.bind(this));
				document.querySelector("#FormulaContainer").appendChild(element);
			},

			/**
			 * Handles formula changed.
			 * @param {Object} event Event information.
			 */
			handleFormulaChanged: function(event) {
				this.$FormulaValue = event.detail;
			},

			/**
			 * @private
			 */
			_subscribeMessages: function() {
				this.sandbox.subscribe("GetColumnConfig", this.getFormulaValue, this,
					[this.sandbox.id]);
			},

			/**
			 * @private
			 */
			_initFormulaValue: function() {
				const settings = this.$ColumnSettings;
				if (settings) {
					const value = settings.value;
					const summaryValue = settings.summaryValue || value;
					this.$FormulaValue = this.$IsSummaryColumn && this.getIsFeatureEnabled("ForecastSummaryFormula") 
						? summaryValue 
						: value;
					this.$UseInSummary = settings.useInSummary;
				}
			},

			/**
			 * Returns formula value.
			 * @return {Object} Formula value.
			 */
			getFormulaValue: function() {
				const value = this.$ColumnSettings.value;
				const summaryValue = this.$ColumnSettings.summaryValue;
				let result;
				if (this.getIsFeatureEnabled("ForecastSummaryFormula")) {
					result = {
						value: this.$IsSummaryColumn ? value : this.$FormulaValue,
						summaryValue: this.$IsSummaryColumn ? this.$FormulaValue : summaryValue,
						useInSummary: this.$UseInSummary,
					};
				} else {
					result = {
						value: this.$FormulaValue,
						summaryValue: summaryValue,
						useInSummary: this.$UseInSummary,
					};
				}
				return result;
			},

			/**
			 * Return state of "CalcTotalByFormula" enabled state.
			 * @obsolete
			 * @return {Boolean} Feature enabled state.
			 */
			getCalcTotalByFormulaFeatureEnabled: function() {
				return this.getIsFeatureEnabled("CalcTotalByFormula");
			},
			
			/**
			 * Returns is "use in summary container" should be visible.
			 * @return {Boolean} Feature enabled state.
			 */
			isUseInSummaryContainerVisible: function() {
				return !this.getIsFeatureEnabled("ForecastSummaryFormula");
			}
		},
		diff: [
			{
				"name": "ColumnDesigner",
				"operation": "insert",
				"values": {
					"items": [],
					"classes": {"wrapClassName": ["column-designer-container"]},
					"itemType": BPMSoft.ViewItemType.CONTAINER
				}
			},
			{
				"operation": "insert",
				"parentName": "ColumnDesigner",
				"propertyName": "items",
				"name": "FormulaContainer",
				"values": {
					"id": "FormulaContainer",
					"labelConfig": {"visible": false},
					"itemType": BPMSoft.ViewItemType.CONTAINER
				}
			},
			{
				"operation": "insert",
				"name": "UseInSummaryContainer",
				"parentName": "ColumnDesigner",
				"propertyName": "items",
				"values": {
					"items": [],
					"classes": {"wrapClassName": ["use-in-summary-container"]},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"visible": {
						"bindTo": "isUseInSummaryContainerVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "UseInSummaryCaption",
				"parentName": "UseInSummaryContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TIP_LABEL,
					"caption": {
						"bindTo": "Resources.Strings.UseInSummaryCaption"
					},
					"classes": {
						"labelClass": ["use-in-summary-label"]
					},
					"tip": {
						"content": {"bindTo": "Resources.Strings.UseInSummaryTipCaption"}
					},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 22
					}
				}
			},
			{
				"operation": "insert",
				"name": "ToggleUseInSummary",
				"parentName": "UseInSummaryContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "UseInSummary",
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["toggle-use-in-summary-state"],
					"controlConfig": {
						"className": "BPMSoft.ToggleEdit",
						"checked": {
							"bindTo": "UseInSummary"
						},
					},
					"layout": {
						"column": 22,
						"row": 0,
						"colSpan": 2
					}
				}
			}
		]
	};
});
