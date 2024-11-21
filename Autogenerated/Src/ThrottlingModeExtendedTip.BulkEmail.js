define("ThrottlingModeExtendedTip", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.ThrottlingModeExtendedTip
	 * Class "ThrottlingModeExtendedTip"
	 */
	Ext.define("BPMSoft.configuration.ThrottlingModeExtendedTip", {
		extend: "BPMSoft.controls.Tip",
		alternateClassName: "BPMSoft.ThrottlingModeExtendedTip",


		customToolTipClass: null,
		throttlingSchedulesList: null,
		throttlingSchedulesTableData: null,

		_setThrottlingSchedulesList: function(value) {
			this.throttlingSchedulesList = value;
			this._setThrottlingSchedulesTableData();
		},

		_setThrottlingSchedulesTableData: function() {
			var throttlingSchedules = this.throttlingSchedulesList;
			if (throttlingSchedules == null) {
				return;
			}
			var throttlingSchedulesTableData = '';
			throttlingSchedules.forEach(element => {
				throttlingSchedulesTableData += Ext.String.format('<div class="grid-listed-row">' +
					'<div class="grid-cols-4">{0}</div><div class="grid-cols-9">{1}</div>' +
					'<div class="grid-cols-9">{2}</div></div>', element.day, element.emails_per_day, element.delay_per_email);
			});
			this.throttlingSchedulesTableData = throttlingSchedulesTableData;
		},

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.controls.Tip#getBindConfig
		 * @overridden
		 */
		getBindConfig: function() {
			var bindConfig = this.callParent(arguments);
			var config = {
				throttlingSchedulesList: {
					changeMethod: "_setThrottlingSchedulesList"
				}
			};
			Ext.apply(config, bindConfig);
			return config;
		},		

		/**
		 * @inheritdoc BPMSoft.controls.Tip#getCombinedCssClasses
		 * @overridden
		 */
		getCombinedCssClasses: function() {
			var classes = this.callParent(arguments);
			if (this.customToolTipClass) {
				classes.push(this.customToolTipClass);
			}
			return classes;
		},

		/**
		 * @inheritdoc BPMSoft.controls.Tip#getCombinedCssClasses
		 * @overridden
		 */
		getTplData: function() {
			var templateData = this.callParent(arguments);
			var throttlingScheduleData = this.throttlingSchedulesTableData;
			templateData.content = Ext.String.format(templateData.content, throttlingScheduleData);
			return templateData;
		}

		//endregion

	});
});
