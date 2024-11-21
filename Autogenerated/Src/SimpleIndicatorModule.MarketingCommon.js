define("SimpleIndicatorModule", ["SimpleIndicatorModuleResources", "SimpleIndicatorModuleResources", "IndicatorModule"],
		function(resources) {

			/**
			 * @class BPMSoft.configuration.SimpleIndicatorViewConfig
			 * ##### ############ ############ ############# ###### ##########.
			 */
			Ext.define("BPMSoft.configuration.SimpleIndicatorViewConfig", {
				extend: "BPMSoft.IndicatorViewConfig",
				alternateClassName: "BPMSoft.SimpleIndicatorViewConfig",

				/**
				 * ########## ############ ############# ###### ##########.
				 * @protected
				 * @overridden
				 * @param {Object} config ###### ############.
				 * @return {Object[]} ########## ############ ############# ###### ##########.
				 */
				generate: function(config) {
					var result = this.callParent(arguments);
					if (config.hint) {
						result.hint = config.hint;
					}
					var imageConfig = config.imageConfig;
					if ((imageConfig !== "") && (typeof imageConfig !== "undefined")) {
						result = this.generateIndicatorWithPicture(result, config);
					} else {
						result = this.generateIndicatorWithOutPicture(result, config);
					}
					return result;
				},

				/**
				 * ########## ############ ############# ###### ########## # #########.
				 * @private
				 * @param {Object} result ###### ############# ###### ########## ## #########.
				 * @return {Object[]} ########## ############ ############# ###### ##########.
				 */
				generateIndicatorWithPicture: function(result) {
					var internalContainer = result.items[0].items;
					var id = BPMSoft.Component.generateId();
					internalContainer[1] = {
						"name": "indicator-image" + id,
						"onPhotoChange": BPMSoft.emptyFn,
						"getSrcMethod": "getSrcMethod",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {"wrapClass": ["indicator-image-container"]},
						"items": []
					};
					return result;
				},

				/**
				 * ########## ############ ############# ###### ########## ### ########.
				 * @private
				 * @param {Object} result ###### ############# ###### ########## ## #########.
				 * @param {Object} config ###### ############
				 * @return {Object[]} ########## ############ ############# ###### ##########.
				 */
				generateIndicatorWithOutPicture: function(result, config) {
					var internalContainer = result.items[0].items;
					var hideTotalAmount = (config.displayTotalAmount === false);
					if (hideTotalAmount) {
						return result;
					}
					var id = BPMSoft.Component.generateId();
					internalContainer[2] = {
						"name": "indicator-total-amount" + id,
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "totalAmount",
							"bindConfig": {"converter": "totalAmountConverter"}
						},
						"classes": {"labelClass": ["indicator-caption"]}
					};
					return result;
				}
			});

			/**
			 * ##### ###### ############# ### ###### ##########
			 */
			Ext.define("BPMSoft.configuration.SimpleIndicatorViewModel", {
				extend: "BPMSoft.IndicatorViewModel",
				alternateClassName: "BPMSoft.SimpleIndicatorViewModel",

				/**
				 * ############ ######## ######## # ############ ###### # ########### ## #### ########.
				 * @protected
				 * @virtual
				 * @param {Number} value ######## ####### ########## ##############.
				 * @return {String} ########## ################# ######.
				 */
				totalAmountConverter: function(value) {
					var result = "";
					var formatConfig = this.get("bottomLabelFormat") || this.defaultFormat;
					if (Ext.isNumber(value)) {
						if (Ext.isEmpty(formatConfig.decimalPrecision)) {
							formatConfig.decimalPrecision =
									(formatConfig.type === BPMSoft.DataValueType.INTEGER) ? 0 : 2;
						}
						if (formatConfig.decimalPrecision === 0) {
							value = Math.round(value);
						}
						result = BPMSoft.getFormattedNumberValue(value, formatConfig);
					} else if (Ext.isDate(value)) {
						var dateFormat = formatConfig.dateFormat || BPMSoft.Resources.CultureSettings.dateFormat;
						result = Ext.Date.format(value, dateFormat);
					}
					var textDecorator = formatConfig.textDecorator;
					if (textDecorator) {
						result = Ext.String.format(textDecorator, result);
					}
					return result;
				},

				/**
				 * ########## ######## ## ########.
				 * @return {String}
				 */
				getSrcMethod: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.IndicatorTargetAchievedImage);
				}

			});

			Ext.define("BPMSoft.configuration.SimpleIndicatorModule", {
				extend: "BPMSoft.IndicatorModule",
				alternateClassName: "BPMSoft.SimpleIndicatorModule",

				/**
				 * ### ###### ###### ############# ### ###### ##########.
				 * @type {String}
				 */
				viewModelClassName: "BPMSoft.SimpleIndicatorViewModel",

				/**
				 * ### ###### ########## ############ ############# ###### ##########.
				 * @type {String}
				 */
				viewConfigClassName: "BPMSoft.SimpleIndicatorViewConfig"

			});

			return BPMSoft.SimpleIndicatorModule;
		});
