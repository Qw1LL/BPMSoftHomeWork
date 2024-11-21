define("MiniPageDatePeriodGenerator", ["TimezoneGenerator", "ViewGeneratorV2", "css!MiniPageDatePeriodGenerator"],
	function(TimezoneGenerator) {
		Ext.define("BPMSoft.configuration.MiniPageDatePeriodGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.MiniPageDatePeriodGenerator",

			/**
			 * Generate date period config.
			 * @protected
			 * @param {Object} config Element configuration information.
			 * @param {Object} generateConfig Generator configuration information.
			 * @return {Object} Generated element config.
			 */
			generateDatePeriodControl: function(config, generateConfig) {
				this.viewModelClass = generateConfig.viewModelClass;
				var resultConfig = {
					className: "BPMSoft.Container",
					id: config.name + "Container",
					selectors: {wrapEl: "#" + config.name + "Container"},
					classes: {wrapClassName: ["date-period-control-container"]},
					markerValue: config.name + "Container",
					items: [
						this.generateLabel({
							name: config.name,
							caption: {
								bindTo: config.name
							},
							visible: config.viewModeVisible
						}),
						this.generateDatePeriodItem(config.startDateColumn, config.editModeVisible),
						this.generateDatePeriodItem(config.dueDateColumn, config.editModeVisible, config.timeEditConfig)
					]
				};
				var timezoneConfig = TimezoneGenerator.getGeneratedTimezoneButton(generateConfig);
				if (timezoneConfig) {
					if (Ext.isEmpty(timezoneConfig.visible) && config.editModeVisible) {
						timezoneConfig.visible = config.editModeVisible;
					}

					if (config.timeZoneButtonLabel) {
						timezoneConfig.caption = config.timeZoneButtonLabel;
						delete timezoneConfig.imageConfig;
					}
					resultConfig.items.push(timezoneConfig);
				}
				return resultConfig;
			},

			/**
			 * Generate date period item config.
			 * @private
			 * @param {String} itemName Item name.
			 * @param {Object} visible Item visibility config.
			 * @return {Object} Generated date period item config.
			 */
			generateDatePeriodItem: function(itemName, visible, timeEditConfig) {
				return {
					className: "BPMSoft.Container",
					id: itemName + "MiniPageContainer",
					selectors: {wrapEl: "#" + itemName + "MiniPageContainer"},
					classes: {wrapClassName: ["date-period-item-container"]},
					markerValue: itemName + "MiniPageContainer",
					items: [
						this.generateControlLabel({
							bindTo: itemName,
							name: itemName + "MiniPage",
							visible: visible,
							classes: {
								labelClass: ["label-mini-wrap"]
							}
						}),
						this.generateDateTimeEdit({
							bindTo: itemName,
							name: itemName + "MiniPage",
							visible: visible,
							controlConfig: timeEditConfig
						})
					]
				};
			}
		});
		return Ext.create("BPMSoft.MiniPageDatePeriodGenerator");
	});
