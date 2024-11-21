define("IndicatorModule", ["IndicatorModuleResources", "BaseWidgetModule", "BaseWidgetViewModel"],
	function() {

		/**
		 * @class BPMSoft.configuration.IndicatorViewConfig
		 * Class generates configuration of Indicator module view.
		 */
		Ext.define("BPMSoft.configuration.IndicatorViewConfig", {
			extend: "BPMSoft.BaseModel",
			alternateClassName: "BPMSoft.IndicatorViewConfig",

			/**
			 * Generates configuration of Indicator module view.
			 * @protected
			 * @virtual
			 * @param {Object} config Configuration object.
			 * @param {BPMSoft.BaseEntitySchema} config.entitySchema Object schema.
			 * @param {String} config.style View style.
			 * @return {Object[]} Returns configuration of indicator module view.
			 */
			generate: function(config) {
				var style = config.style || "";
				var fontStyle = config.fontStyle || "";	
				var wrapClassName;
				switch (config?.caption) {
					case "Доставлено":
					case "Открытия":
					case "Переходы":
					case "Отписки":
					case "Спам":
						wrapClassName = 'widget-orange';
						break;
						
					default:
						wrapClassName = Ext.String.format("{0}", style);
						break;
				}
				var id = BPMSoft.Component.generateId();
				var result = {
					"name": id,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: [wrapClassName, "indicator-module-wraper"]},
					"items": [
						{
							"name": id + "-wrap",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {wrapClassName: ["indicator-wrap"]},
							"items": [
								{
									"name": "indicator-value" + id,
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {
										"bindTo": "value",
										"bindConfig": {"converter": "valueConverter"}
									},
									"classes": {"labelClass": ["indicator-value " + fontStyle]}
								},
								
								{
									"name": "indicator-caption" + id,
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {"bindTo": "caption"},
									"classes": {"labelClass": ["indicator-caption"]}
								},
								{
									"name": "LoadingMask" + id,
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["dashboard-loading-mask"]},
									"visible": {"bindTo": "DataIsLoading"},
									"items": [
										{
											"name": "Spinner" + id,
											"itemType": BPMSoft.ViewItemType.COMPONENT,
											"className": "BPMSoft.BubbleSpinner"
										}
									]
								}
							]
						}
					]
				};
				return result;
			}
		});

		/**
		 * @class BPMSoft.configuration.IndicatorViewModel
		 * Class of Indicator view model.
		 */
		Ext.define("BPMSoft.configuration.IndicatorViewModel", {
			extend: "BPMSoft.configuration.BaseWidgetViewModel",
			alternateClassName: "BPMSoft.IndicatorViewModel",

			/**
			 * Default format of data view.
			 * {Object}
			 */
			defaultFormat: {
				textDecorator: "{0}",
				thousandSeparator: BPMSoft.Resources.CultureSettings.thousandSeparator,
				dateFormat: BPMSoft.Resources.CultureSettings.dateFormat
			},

			/*
			 * Column is used for adding aggregation column to select query
			 * @protected
			 * @virtual
			 * @type {String}.
			 */
			aggregationColumnName: "columnName",

			/**
			 * Converts value to given format according to value type.
			 * @protected
			 * @virtual
			 * @param {String/Date/Number} value Value to be converted.
			 * @return {String} Returns formatted string.
			 */
			valueConverter: function(value) {
				let result = "";
				const formatConfig = this.get("format") || this.defaultFormat;
				if (Ext.isNumber(value)) {
					formatConfig.decimalPrecision = (Ext.isEmpty(formatConfig.decimalPrecision)) ?
						((formatConfig.type === BPMSoft.DataValueType.INTEGER) ? 0 : 2) :
						formatConfig.decimalPrecision;
					if (formatConfig.decimalPrecision === 0) {
						value = Math.round(value);
					}
					formatConfig.thousandSeparator = this.defaultFormat.thousandSeparator;
					result = BPMSoft.getFormattedNumberValue(value, formatConfig);
				} else if (Ext.isDate(value)) {
					const isShowTime = Ext.Date.formatContainsHourInfo(formatConfig.dateFormat || '');
					var dateFormat = BPMSoft.Resources.CultureSettings.dateFormat;
					if (isShowTime) { 
						dateFormat = `${BPMSoft.Resources.CultureSettings.dateFormat} ${BPMSoft.Resources.CultureSettings.timeFormat}`;
					}
					result = Ext.Date.format(value, dateFormat);
				}
				var textDecorator = formatConfig.textDecorator;
				if (textDecorator) {
					result = Ext.String.format(textDecorator, result);
				}
				return result;
			},

			/**
			 * Prepares indicator parameters
			 * @protected
			 * @virtual
			 * @param {Function} callback The function that will be called upon completion.
			 * @param {Object} scope The context in which the callback function will be called.
			 */
			prepareIndicator: function(callback, scope) {
				this.prepareWidget(callback, scope);
			},

			/**
			 * Perfoms data selection
			 * @protected
			 * @virtual
			 * @return {BPMSoft.EntitySchemaQuery} select Contains selected and filtered data
			 */
			createSelect: function() {
				var selectParameters = {
					queryKind: BPMSoft.QueryKind.LIMITED,
					isBatchable: BPMSoft.Features.getIsEnabled("BatchableDashboardQueryFeature")
				};
				return this.callParent([selectParameters]);
			}
		});

		Ext.define("BPMSoft.configuration.IndicatorModule", {
			extend: "BPMSoft.BaseWidgetModule",
			alternateClassName: "BPMSoft.IndicatorModule",

			/**
			 * Class name of the Indicator module view model.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.IndicatorViewModel",

			/**
			 * Class name of the Indicator module view configuration.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.IndicatorViewConfig",

			/**
			 * Initializes module configuration.
			 * @protected
			 * @virtual
			 */
			initConfig: function() {
				this.callParent(["GetIndicatorConfig", this.sandbox]);
			},

			/**
			 * Subscribes to the parent module posts.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				this.callParent(arguments);
				this.subscribeMessagesInternal("GenerateIndicator");
			},

			/**
			 * Returns model messages. If messages property is null, returns empty object.
			 * @virtual
			 * @protected
			 * @return {Object} Messages columns.
			 */
			getModuleMessages: function() {
				var baseMessages = this.callParent(arguments);
				return this.Ext.apply(baseMessages, {
					/**
					 * @message GetSectionFilterModuleId
					 * For subscription on UpdateFilter
					 */
					"GetSectionFilterModuleId": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				});
			},

			/**
			 * Handles Indicator generation.
			 * @protected
			 * @virtual
			 */
			onGenerateIndicator: function() {
				this.onGenerateWidget();
			}
		});

		return BPMSoft.IndicatorModule;

	});
