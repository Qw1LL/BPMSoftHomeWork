define("FullPipelineViewConfig", ["FullPipelineModuleResources", "FullPipelineChart", "ContainerList", "ChartModule",
	"css!FullPipelineViewConfig", "css!ChartModule"], function(resources) {

		/**
		 * @class BPMSoft.configuration.FullPipelineViewConfig
		 * The class generates chart view module configuration
		 */
		Ext.define("BPMSoft.configuration.FullPipelineViewConfig", {
			extend: "BPMSoft.ChartViewConfig",
			alternateClassName: "BPMSoft.FullPipelineViewConfig",

			/**
			 * Chart id.
			 * @type {String}
			 */
			chartId: null,

			/**
			 * Generates fullpipeline fixed filters by period view configuration.
			 * @protected
			 * @virtual
			 * @param {Object} filterConfig Filter config.
			 * @param {String} filterConfig.name Filter name.
			 * @return {Object} Funnel filter container view config.
			 */
			getFilterFunnelViewConfig: function(filterConfig) {
				var config = {
					"className": "BPMSoft.Container",
					"id": "fullpipelineFixedFilter" + filterConfig.name + "Container" + this.chartId,
					"selectors": {
						"el": "#fullpipelineFixedFilter" + filterConfig.name + "Container" + this.chartId,
						"wrapEl": "#fullpipelineFixedFilter" + filterConfig.name + "Container" + this.chartId
					},
					"classes": { "wrapClassName": ["row-filter-container"] },
					"tpl": [
						"<span id=\"{id}\" style=\"{wrapStyles}\" class=\"{wrapClassName}\">",
						"{%this.renderItems(out, values)%}",
						"</span>"
					],
					"items": []
				};
				config.items = this.getPeriodFilterViewConfig(filterConfig);
				return config;
			},

			/**
			 * Returns period menu item config.
			 * @protected
			 * @virtual
			 * @param {String} filterName Filter name.
			 * @param {String} caption Filter caption.
			 * @param {Object} periodConfig Period config.
			 * @return {Object} Period menu item config.
			 */
			getPeriodMenuItemConfig: function(filterName, caption, periodConfig) {
				return {
					"className": "BPMSoft.MenuItem",
					"caption": caption,
					"click": { "bindTo": "setPeriod" },
					"tag": {
						"filterName": filterName,
						"periodConfig": periodConfig
					}
				};
			},

			/**
			 * Returns period fixed buttons view config.
			 * @protected
			 * @virtual
			 * @param {String} filterName Filter name.
			 * @param {Object} periodConfig Period config.
			 * @return {Object} Period fixed buttons view config.
			 */
			getPeriodFixedButtonsViewConfig: function(filterName, periodConfig) {
				var localizableStrings = resources.localizableStrings;
				var localizableImages = resources.localizableImages;

				var monthButton = this.getFixedButtonBaseConfig();
				monthButton.imageConfig = localizableImages.MonthPeriodButtonImage;
				monthButton.markerValue = "PeriodButton";
				monthButton.hint = localizableStrings.SelectPeriodHint;
				monthButton.classes = { "imageClass": ["period-fixed-filter-image-class"] };
				monthButton.menu = {
					"items": [
						this.getPeriodMenuItemConfig(filterName + "_Yesterday",
							localizableStrings.YesterdayCaption, periodConfig),
						this.getPeriodMenuItemConfig(filterName + "_Today",
							localizableStrings.TodayCaption, periodConfig),
						this.getPeriodMenuItemConfig(filterName + "_PastWeek",
							localizableStrings.PastWeekCaption, periodConfig),
						this.getPeriodMenuItemConfig(filterName + "_CurrentWeek",
							localizableStrings.CurrentWeekCaption, periodConfig),
						{
							className: "BPMSoft.MenuSeparator"
						},
						this.getPeriodMenuItemConfig(filterName + "_PastMonth",
							localizableStrings.PastMonthCaption, periodConfig),
						this.getPeriodMenuItemConfig(filterName + "_CurrentMonth",
							localizableStrings.CurrentMonthCaption, periodConfig)
					]
				};
				BPMSoft.each(monthButton.menu.items, function(menuItem) {
					menuItem.markerValue = menuItem.caption;
				}, this);
				return monthButton;
			},

			/**
			 * Returns base fixed button config.
			 * @protected
			 * @virtual
			 * @return {Object} Button config.
			 */
			getFixedButtonBaseConfig: function() {
				return {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
				};
			},

			/**
			 * Returns period filter values config.
			 * @protected
			 * @virtual
			 * @param {Object} filterConfig Period config.
			 * @return {Object} Period filter values config.
			 */
			getPeriodFilterValuesConfig: function(filterConfig) {
				var resultConfig = {};
				var startDateColumnName = filterConfig.columnName;
				var startDateDefValue = filterConfig.defValue || new Date();
				var dueDateColumnName = filterConfig.columnName;
				var dueDateDefValue = filterConfig.defValue || new Date();
				if (filterConfig.startDate) {
					startDateColumnName = filterConfig.startDate.columnName || startDateColumnName;
					startDateDefValue = filterConfig.startDate.defValue || startDateDefValue;
					if (filterConfig.dueDate) {
						dueDateColumnName = filterConfig.dueDate.columnName || startDateColumnName || dueDateColumnName;
						dueDateDefValue = filterConfig.dueDate.defValue || startDateDefValue || dueDateDefValue;
					} else {
						dueDateColumnName = startDateColumnName;
						dueDateDefValue = startDateDefValue;
					}
				}
				if (startDateColumnName === dueDateColumnName) {
					dueDateColumnName = startDateColumnName + "Due";
					resultConfig.singleColumn = true;
				}
				resultConfig.startDateColumnName = startDateColumnName;
				resultConfig.startDateDefValue = startDateDefValue;
				resultConfig.dueDateColumnName = dueDateColumnName;
				resultConfig.dueDateDefValue = dueDateDefValue;
				return resultConfig;
			},

			/**
			 * Returns clear filter button config.
			 * @protected
			 * @virtual
			 * @param {Object} periodConfig Period config.
			 * @return {Object} Clear button config.
			 */
			getClearFilterButtonConfig: function(periodConfig) {
				return {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": resources.localizableImages.RemoveButtonImage,
					"classes": { "wrapperClass": "fullpipeline-filter-remove-button" },
					"hint": resources.localizableStrings.RemoveButtonHint,
					"click": { "bindTo": "clearPeriodFilter" },
					"tag": { "periodConfig": periodConfig },
					"markerValue": "ClearPeriodFilter"
				};
			},

			/**
			 * Returns period filters container view config.
			 * @protected
			 * @virtual
			 * @param {String} filterConfig Filter config.
			 * @param {String} filterConfig.name Filter name.
			 * @return {Object[]} Period filters container config.
			 */
			getPeriodFilterViewConfig: function(filterConfig) {
				var periodConfig = this.getPeriodFilterValuesConfig(filterConfig);
				return [
					{
						"className": "BPMSoft.Container",
						"id": "fullpipelineFixedFilter" + filterConfig.name + "ButtonContainer" + this.chartId,
						"selectors": {
							"el": "#fullpipelineFixedFilter" + filterConfig.name + "ButtonContainer" + this.chartId,
							"wrapEl": "#fullpipelineFixedFilter" + filterConfig.name + "ButtonContainer" + this.chartId
						},
						"items": [
							{
								"className": "BPMSoft.Label",
								"classes": {
									"labelClass": ["funnel-filter-inner-container label", "filter-caption-label",
										"filter-element-with-right-space","filter-element-from-label"]
								},
								"caption": resources.localizableStrings.PeriodFromLabelCaption
							},
							this.getPeriodFixedButtonsViewConfig(filterConfig.name, periodConfig),
							this.getDateFilterValueLabelConfig(periodConfig, "startDateColumnName",
								resources.localizableStrings.StartDatePlaceholder),
							{
								"className": "BPMSoft.Label",
								"classes": {
									"labelClass": [
										"fullpipeline-filter-inner-container label", "filter-caption-label",
										"filter-element-with-right-space"
									]
								},
								"caption": resources.localizableStrings.PeriodToLabelCaption
							},
							this.getPeriodFixedButtonsViewConfig(filterConfig.name, periodConfig),
							this.getDateFilterValueLabelConfig(periodConfig, "dueDateColumnName",
								resources.localizableStrings.DueDatePlaceholder),
							this.getClearFilterButtonConfig(periodConfig)
						],
						"classes": { "wrapClassName": "fullpipeline-filter-inner-container filter-cell-filter-container" }
					}
				];
			},

			/**
			 * Returns date filter label value config.
			 * @protected
			 * @virtual
			 * @param {String} periodConfig Period values config.
			 * @param {String} currentColumnName Current filter column name.
			 * @param {String} placeholder Placeholder text.
			 * @return {Object} Date filter label value config.
			 */
			getDateFilterValueLabelConfig: function(periodConfig, currentColumnName, placeholder) {
				var columnName = periodConfig[currentColumnName];
				return {
					"id": "fullpipelineFixedFilter" + columnName + "View" + this.chartId,
					"className": "BPMSoft.LabelDateEdit",
					"classes": {
						"labelClass": [
							"fullpipeline-filter-inner-container label", "filter-value-label",
							"filter-element-with-right-space"
						]
					},
					"value": { "bindTo": columnName },
					"tag": columnName,
					"markerValue": columnName,
					"placeholder": placeholder
				};
			},

			/**
			 * Returns base fullpipeline slice button config.
			 * @protected
			 * @virtual
			 * @param {String} tag Button tag.
			 * @param {String} caption Button caption.
			 * @return {Object} Funnel slice button config.
			 */
			getSliceButtonConfig: function(tag, caption) {
				return {
					"caption": caption,
					"click": { "bindTo": "updatePipelineSliceTypeHandler" },
					"visible": {
						"bindTo": "isDrilledDown",
						"bindConfig": { "converter": "invertBooleanValue" }
					},
					"classes": { "textClass": "fullpipeline-buttons-settings" },
					"pressed": { "bindTo": "getIsPressedButtonSetting" },
					"tag": tag
				};
			},

			/**
			 * Returns fullpipeline slice buttons container config.
			 * @protected
			 * @virtual
			 * @return {Object} Slice buttons container config.
			 */
			getCalcButtonsContainerConfig: function() {
				return {
					"name": "grid-wrapper-calcButtonsId" + this.chartId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "isDrilledDown",
						"bindConfig": { "converter": "invertBooleanValue" }
					},
					"classes": { "wrapClassName": ["fullpipeline-buttons-settings-container"] },
					"items": [
						{
							"name": "SwitchFullPipelineTypeCombobox" + this.chartId,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"caption": {"bindTo":"SwitchFunnelComboboxCaption"},
							"menu": {
								"items": [
									this.getSliceButtonConfig("byNumberConversion",
									resources.localizableStrings.ConversionByCountCaption),
									this.getSliceButtonConfig("stageConversion",
									resources.localizableStrings.StageConversionCaption),
									this.getSliceButtonConfig("toFirstConversion",
									resources.localizableStrings.ToFirstStageConversionCaption)
								]
							}
						}
					]
				};
			},

			/**
			 * Returns fullpipeline chart legend config.
			 * @protected
			 * @virtual
			 * @param {String} chartId Chart identifier.
			 * @return {Object} FullPipeline chart legend container config.
			 */
			getChartLegendContainerConfig: function(chartId) {
				const legendConfig = this.getChartLegendConfig(chartId);
				return {
					"name": "chartLegendContainer-" + chartId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": { "wrapClassName": ["fullpipeline-chart-legend-container"] },
					"items": [legendConfig]
				};
			},

			/**
			 * Returns fullpipeline chart legend item list config.
			 * @protected
			 * @virtual
			 * @param {String} chartId Chart identifier.
			 * @return {Object} FullPipeline chart legend item list config.
			 */
			getChartLegendConfig: function(chartId) {
				return {
					"name": "chartLegend-" + chartId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"className": "BPMSoft.ContainerList",
					"collection": { "bindTo": "ChartLegendItems" },
					"onGetItemConfig": { "bindTo": "onGetLegendItemConfig" },
					"idProperty": "Id",
					"classes": { "wrapClassName": ["fullpipeline-chart-legend"] },
					"defaultItemConfig": {}
				}
			},

			/**
			 * @inheritDoc BPMSoft.ChartViewConfig#getChartControlConfig
			 * @override
			 */
			getChartControlConfig: function(chartId) {
				var config = this.callParent(arguments);
				return Ext.merge(config, {
					"className": "BPMSoft.FullPipelineChart",
					"drillDownMode": {
						"bindTo": "DrillDownMode"
					},
					"expanded": {
						"bindTo": "onExpanded"
					}
				});
			},

			/**
			 * Returns date period filter config.
			 * @protected
			 * @virtual
			 * @return {Object} Date period filter.
			 */
			getDatePeriodFilterConfig: function() {
				return {
					"name": "PeriodFilter",
					"caption": "Period",
					"dataValueType": BPMSoft.DataValueType.DATE,
					"startDate": {
						"columnName": "StartDate",
						"defValue": BPMSoft.startOfMonth(new Date())
					},
					"dueDate": {
						"columnName": "DueDate",
						"defValue": BPMSoft.endOfMonth(new Date())
					}
				};
			},

			/**
			 * Returns filter container config.
			 * @protected
			 * @virtual
			 * @param {String} chartId Chart id.
			 * @return {Object} Filter container config.
			 */
			getFilterContainerConfig: function(chartId) {
				var filterFunnelConfig = this.getDatePeriodFilterConfig();
				var viewMainFunnelFilterViewConfig = this.getFilterFunnelViewConfig(filterFunnelConfig);
				var viewMainFunnelFilterConfig = {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"className": "BPMSoft.Container",
					"id": "viewMainFunnelFilterContainer" + chartId,
					"selectors": {
						"el": "#viewMainFunnelFilterContainer" + chartId,
						"wrapEl": "#viewMainFunnelFilterContainer" + chartId
					},
					"classes": { "wrapClassName": ["main-filter-container"] },
					"controlConfig": { "items": [viewMainFunnelFilterViewConfig] },
					"tpl": [
						"<span id=\"{id}\" style=\"{wrapStyles}\" class=\"{wrapClassName}\">",
						"{%this.renderItems(out, values)%}",
						"</span>"
					]
				};
				return {
					"name": "grid-wrapper-chartFixedAdditionalFilterId" + chartId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-filter-container"],
					"id": "grid-wrapper-chartFixedAdditionalFilterId" + chartId + "Container",
					"items": [viewMainFunnelFilterConfig]
				};
			},

			/**
			 * @inheritDoc BPMSoft.ChartViewConfig#generate
			 * @override
			 */
			generate: function(config) {
				var chartId = this.chartId = "Chart_" + config.sandboxId;
				var chartViewConfig = this.callParent(arguments);
				var filterContainerConfig = this.getFilterContainerConfig(chartId);
				var calcButtonsContainerConfig = this.getCalcButtonsContainerConfig();
				var toolsContainerConfig={
					"name": "grid-wrapper-chartToolsContainerConfigId" + chartId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-tools-container"],
					"id": "grid-wrapper-chartToolsContainerConfigId" + chartId + "Container",
					"items": [filterContainerConfig,calcButtonsContainerConfig]
				};
				var chartViewConfigItems = chartViewConfig[0].items;
				chartViewConfigItems.splice(2, 0, toolsContainerConfig);
				var item = chartViewConfigItems[chartViewConfigItems.length - 1];
				item.wrapClass = !item.wrapClass
					? ["fullpipeline-chart-grid-wrapper"]
					: item.wrapClass.push("fullpipeline-chart-grid-wrapper");
				var legendContainerConfig = this.getChartLegendContainerConfig(chartId);
				chartViewConfigItems.push(legendContainerConfig);
				return [
					{
						"name": "chart-module-wrapper-" + chartId,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": { "wrapClassName": ["fullpipeline-main-container"] },
						"items": chartViewConfig
					}
				];
			}
		});
	}
);
