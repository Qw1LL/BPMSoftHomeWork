define("OpportunityFunnelViewConfig", ["OpportunityFunnelModuleV2Resources", "OpportunityFunnelChart", "ChartModule",
			"css!OpportunityFunnelViewConfig", "css!ChartModule"], function(resources) {

			/**
			 * @class BPMSoft.configuration.OpportunityFunnelViewConfig
			 * The class generates chart view module configuration
			 */
			Ext.define("BPMSoft.configuration.OpportunityFunnelViewConfig", {
				extend: "BPMSoft.ChartViewConfig",
				alternateClassName: "BPMSoft.OpportunityFunnelViewConfig",

				chartId: null,

				/**
				 * Generates funnel fixed filters by period view configuration
				 * @protected
				 * param {Object} filterConfig ############ #######, ########## ######## #######.
				 * @return {Object} ############ ############# ######## ## #######.
				 */
				getFilterFunnelViewConfig: function(filterConfig) {
					var config = {
						"className": "BPMSoft.Container",
						"id": "funnelFixedFilter" + filterConfig.name + "Container" + this.chartId,
						"selectors": {
							"el": "#funnelFixedFilter" + filterConfig.name + "Container" + this.chartId,
							"wrapEl": "#funnelFixedFilter" + filterConfig.name + "Container" + this.chartId
						},
						"classes": {"wrapClassName": ["row-filter-container"]},
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
				 * ######### ############ ############# ###### ######## ## ####### # ########## ####.
				 * @protected
				 * param {String} filterName ######## #######.
				 * param {Object} periodConfig ############ ####### ## #######.
				 * @return {Object} ############ ############# ###### ######## ## #######.
				 */
				getPeriodFixedButtonsViewConfig: function(filterName, periodConfig) {
					var localizableStrings = resources.localizableStrings;
					var localizableImages = resources.localizableImages;

					var monthButton = this.getFixedButtonBaseConfig();
					monthButton.imageConfig = localizableImages.MonthPeriodButtonImage;
					monthButton.markerValue = "PeriodButton";
					monthButton.hint = localizableStrings.SelectPeriodHint;
					monthButton.classes = {"imageClass": ["period-fixed-filter-image-class"]};
					monthButton.menu = {
						"items": [
							{
								"className": "BPMSoft.MenuItem",
								"caption": localizableStrings.YesterdayCaption,
								"click": {"bindTo": "setPeriod"},
								"tag": {
									"filterName": filterName + "_Yesterday",
									"periodConfig": periodConfig
								}
							},
							{
								"className": "BPMSoft.MenuItem",
								"caption": localizableStrings.TodayCaption,
								"click": {"bindTo": "setPeriod"},
								"tag": {
									"filterName": filterName + "_Today",
									"periodConfig": periodConfig
								}
							},
							{"className": "BPMSoft.MenuSeparator"},
							{
								"className": "BPMSoft.MenuItem",
								"caption": localizableStrings.PastWeekCaption,
								"click": {"bindTo": "setPeriod"},
								"tag": {
									"filterName": filterName + "_PastWeek",
									"periodConfig": periodConfig
								}
							},
							{
								"className": "BPMSoft.MenuItem",
								"caption": localizableStrings.CurrentWeekCaption,
								"click": {"bindTo": "setPeriod"},
								"tag": {
									"filterName": filterName + "_CurrentWeek",
									"periodConfig": periodConfig
								}
							},
							{className: "BPMSoft.MenuSeparator"},
							{
								"className": "BPMSoft.MenuItem",
								"caption": localizableStrings.PastMonthCaption,
								"click": {"bindTo": "setPeriod"},
								"tag": {
									"filterName": filterName + "_PastMonth",
									"periodConfig": periodConfig
								}
							},
							{
								"className": "BPMSoft.MenuItem",
								"caption": localizableStrings.CurrentMonthCaption,
								"click": {"bindTo": "setPeriod"},
								"tag": {
									"filterName": filterName + "_CurrentMonth",
									"periodConfig": periodConfig
								}
							}
						]
					};
					BPMSoft.each(monthButton.menu.items, function(menuItem) {
						menuItem.markerValue = menuItem.caption;
					}, this);
					return monthButton;
				},

				/**
				 * ######### ############ ############# ######.
				 * @protected
				 * @return {Object} ############ ############# ######.
				 */
				getFixedButtonBaseConfig: function() {
					return {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					};
				},

				/**
				 * ######### ############ ######## ####### ###### ## #######.
				 * @protected
				 * param {Object} filterConfig ############ #######, ########## ######## # ######## ##### ##########.
				 * @return {Object} ############ ######## ## #######.
				 */
				getPeriodFilterConfig: function(filterConfig) {
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
				 * ######### ######## ############ ############# ######## ## #######.
				 * @protected
				 * param {Object} filterConfig ############ #######.
				 * @return {Object} ######## ############ ############# ######## ## #######.
				 */
				getPeriodFilterViewConfig: function(filterConfig) {
					var periodConfig = this.getPeriodFilterConfig(filterConfig);
					return [
						{
							"className": "BPMSoft.Container",
							"id": "funnelFixedFilter" + filterConfig.name + "ButtonContainer" + this.chartId,
							"selectors": {
								"el": "#funnelFixedFilter" + filterConfig.name + "ButtonContainer" + this.chartId,
								"wrapEl": "#funnelFixedFilter" + filterConfig.name + "ButtonContainer" + this.chartId
							},
							"items": [
								this.getPeriodFixedButtonsViewConfig(filterConfig.name, periodConfig),
								{
									"className": "BPMSoft.Label",
									"classes": {
										"labelClass": ["funnel-filter-inner-container label", "filter-caption-label",
											"filter-element-with-right-space","filter-element-from-label"]
									},
									"caption": resources.localizableStrings.PeriodFromLabelCaption
								},
								this.getDateFilterValueLabel(periodConfig, "startDateColumnName",
										resources.localizableStrings.StartDatePlaceholder),
								{
									"className": "BPMSoft.Label",
									"classes": {
										"labelClass": [
											"funnel-filter-inner-container label", "filter-caption-label",
											"filter-element-with-right-space", "filter-element-to-label"
										]
									},
									"caption": resources.localizableStrings.PeriodToLabelCaption
								},
								this.getDateFilterValueLabel(periodConfig, "dueDateColumnName",
										resources.localizableStrings.DueDatePlaceholder),
								{
									"className": "BPMSoft.Button",
									"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
									"imageConfig": resources.localizableImages.RemoveButtonImage,
									"classes": {"wrapperClass": "funnel-filter-remove-button"},
									"hint": resources.localizableStrings.RemoveButtonHint,
									"click": {"bindTo": "clearPeriodFilter"},
									"tag": {"periodConfig": periodConfig},
									"markerValue": "ClearPeriodFilter"
								}
							],
							"classes": {"wrapClassName": "funnel-filter-inner-container filter-cell-filter-container"}
						}
					];
				},

				/**
				 * ######### ############ ############# ####### ## ####### ####.
				 * @protected
				 * param {Object} periodConfig ############ #######.
				 * param {String} currentColumnName ######## ####### ####### ####.
				 * param {String} placeholder ######### ####### #### #######
				 * @return {Object} ############ ############# ####### ## ####### ####.
				 */
				getDateFilterValueLabel: function(periodConfig, currentColumnName, placeholder) {
					var columnName = periodConfig[currentColumnName];
					return {
						"id": "funnelFixedFilter" + columnName + "View" + this.chartId,
						"className": "BPMSoft.LabelDateEdit",
						"classes": {
							"labelClass": [
								"funnel-filter-inner-container label", "filter-value-label",
								"filter-element-with-right-space"
							]
						},
						"value": {"bindTo": columnName},
						"tag": columnName,
						"markerValue": columnName,
						"placeholder": placeholder
					};
				},

				/**
				 * ######### ############ ############# ###### ######### #### ########### ####### ######.
				 * @protected
				 * @return {Object} ############ ############# ###### ######### ####.
				 */
				getCalcButtonsContainerConfig: function() {
					return {
						"name": "grid-wrapper-calcButtonsId" + this.chartId,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "isDrilledDown",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						"classes": {"wrapClassName": ["funnel-buttons-settings-container"]},
						"items": [
							{
								"name": "SwitchFunnelTypeCombobox" + this.chartId,
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
								"caption": {
									"bindTo": "SwitchFunnelComboboxCaption",
								},
								"menu": [
									{
										"caption": resources.localizableStrings.ConversionByCountCaption,
										"click": {"bindTo": "updateFunnelType"},
										"visible": {
											"bindTo": "isDrilledDown",
											"bindConfig": {"converter": "invertBooleanValue"}
										},
										"classes": {"textClass": "funnel-buttons-settings"},
										"pressed": {"bindTo": "getIsPressedButtonSetting"},
										"tag": "byNumberConversion"
									},
									{
										"caption": resources.localizableStrings.StageConversionCaption,
										"click": {"bindTo": "updateFunnelType"},
										"controlConfig": {},
										"visible": {
											"bindTo": "isDrilledDown",
											"bindConfig": {"converter": "invertBooleanValue"}
										},
										"classes": {"textClass": "funnel-buttons-settings"},
										"pressed": {"bindTo": "getIsPressedButtonSetting"},
										"tag": "stageConversion"
									},
									{
										"caption": resources.localizableStrings.ToFirstStageConversionCaption,
										"click": {"bindTo": "updateFunnelType"},
										"visible": {
											"bindTo": "isDrilledDown",
											"bindConfig": {"converter": "invertBooleanValue"}
										},
										"classes": {"textClass": "funnel-buttons-settings"},
										"pressed": {"bindTo": "getIsPressedButtonSetting"},
										"tag": "toFirstConversion"
									}
								]
							}
						]
					};
				},

				/**
				 * ########## ############ ############# #######.
				 * @param {Object} config ######### ######## ######.
				 * @return {Object[]} ########## ############ ############# #######.
				 */
				generate: function(config) {
					var chartId = this.chartId = "Chart_" + config.sandboxId;
					var filterFunnelConfig = {
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
					var viewMainFunnelFilterViewConfig = this.getFilterFunnelViewConfig(filterFunnelConfig);
					var viewMainFunnelFilterConfig = {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.Container",
						"id": "viewMainFunnelFilterContainer" + chartId,
						"selectors": {
							"el": "#viewMainFunnelFilterContainer" + chartId,
							"wrapEl": "#viewMainFunnelFilterContainer" + chartId
						},
						"classes": {"wrapClassName": ["main-filter-container"]},
						"controlConfig": {"items": [viewMainFunnelFilterViewConfig]},
						"tpl": [
							"<span id=\"{id}\" style=\"{wrapStyles}\" class=\"{wrapClassName}\">",
							"{%this.renderItems(out, values)%}",
							"</span>"
						]
					};
					var filterContainerConfig = {
						"name": "grid-wrapper-chartFixedAdditionalFilterId" + chartId,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["main-filter-container"],
						"id": "grid-wrapper-chartFixedAdditionalFilterId" + chartId + "Container",
						"items": [viewMainFunnelFilterConfig]
					};
					var calcButtonsContainerConfig = this.getCalcButtonsContainerConfig();
					var chartViewConfig = this.callParent(arguments);
					var chartViewConfigItems = chartViewConfig[0].items;
					// ######## ### ########## #######
					var chartConfig = chartViewConfigItems[2];
					chartConfig.className = "BPMSoft.OpportunityFunnelChart";
					chartConfig.drillDownMode = {
						"bindTo" : "DrillDownMode"
					};
					var toolsContainerConfig={
						"name": "grid-wrapper-chartToolsContainerConfigId" + chartId,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["main-tools-container"],
						"id": "grid-wrapper-chartToolsContainerConfigId" + chartId + "Container",
						"items": [filterContainerConfig,calcButtonsContainerConfig]
					};
					// ######### ##### ########## # ######## ############ ############# ######## ## #######
					// # ###### ######### #### #######
					chartViewConfigItems.splice(2, 0, toolsContainerConfig);
					chartViewConfigItems.forEach(function(item) {
						const wrapClass = item.wrapClass || [];
						if (BPMSoft.contains(wrapClass, "chart-grid-wrapper")) {
							wrapClass.push("funnel-chart-grid-wrapper");
						}
					});
					return [
						{
							"name": "chart-module-wrapper-" + chartId,
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["funnel-main-container"]},
							"items": chartViewConfig
						}
					];
				}
			});
		}
);
