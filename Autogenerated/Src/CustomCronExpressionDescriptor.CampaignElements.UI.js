/**
 * @inheritdoc BPMSoft.CronExpressionDescriptor
 */
Ext.define("BPMSoft.manager.CustomCronExpressionDescriptor", {
	extend: "BPMSoft.manager.CronExpressionDescriptor",
	alternateClassName: "BPMSoft.CustomCronExpressionDescriptor",
	statics: {
		/**
		 * Describes given cron expression object in human readable text.
		 * @param {BPMSoft.CronExpression} cron Cron expression to describe.
		 * @param {Object} config Describe config.
		 * @param {Boolean} config.use24HourTimeFormat Enables 24 hours format description. Uses 12 hours format
		 * by default.
		 * @returns {String|null} Human readable cron description.
		 */
		describe: function(cron, config) {
			var result = null;
			if (cron.isValid()) {
				var descriptor = Ext.create("BPMSoft.CustomCronExpressionDescriptor", {
					parameters: cron.toArray(),
					use24HourTimeFormat: config && config.use24HourTimeFormat
				});
				result = descriptor.tryGetFullDescription();
			}
			return result;
		}
	},

	/**
	 * @inheritdoc BPMSoft.CronExpressionDescriptor#getTimeOfDayDescription
	 * @override
	 */
	getTimeOfDayDescription: function() {
		return "";
	}
});
