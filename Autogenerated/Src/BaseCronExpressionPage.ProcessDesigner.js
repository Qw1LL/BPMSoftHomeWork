define("BaseCronExpressionPage", ["BaseCronExpressionPageResources",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function() {
	return {
		attributes: {
			/**
			 * Custom cron expression.
			 * @private
			 * @type {String}
			 */
			"CronExpression": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			}
		},
		messages: {
			"GetCronExpression": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * @protected
			 */
			getDefCronExpressionValue: function() {
				return null;
			},

			/**
			 * Init section features.
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.sandbox.subscribe("GetCronExpression", function() {
						return this.get("CronExpression");
					}, this, [this.sandbox.id]);
					let cronExpression = this.get("CronExpression");
					let info = BPMSoft.CronExpression.validate(cronExpression);
					let cron;
					if (info.isValid) {
						cron = BPMSoft.CronExpression.from(cronExpression);
					} else {
						cronExpression = this.getDefCronExpressionValue();
						this.$CronExpression = cronExpression;
						cron = BPMSoft.CronExpression.from(cronExpression);
					}
					this.onExpressionInit(cron);
					callback.call(scope);
				}, this]);
			},

			/**
			 * Init view attributes with given cron object
			 * @virtual
			 * @param {Object} cron object.
			 */
			onExpressionInit: BPMSoft.emptyFn

		}
	};
});
