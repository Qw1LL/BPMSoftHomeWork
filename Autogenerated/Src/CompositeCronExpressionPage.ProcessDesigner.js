define("CompositeCronExpressionPage", ["CompositeCronExpressionPageResources", "CronExpressionPageMixin",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function() {
	return {
		mixins: {
			CronExpressionPageMixin : "BPMSoft.CronExpressionPageMixin"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseCronExpressionPage#getDefCronExpressionValue
			 * @protected
			 */
			getDefCronExpressionValue: function () {
				var cron = this.getCompositeCronExpressionValue();
				return cron.toString();
			},

			/**
			 *@protected
			 */
			getCompositeCronExpressionValue: function() {
				return BPMSoft.CronExpression.create();
			},

			/**
			 * @protected
			 */
			onCronExpressionPartChange: function() {
				var cron = this.getCompositeCronExpressionValue();
				if (cron) {
					this.set("CronExpression", cron.toString());
				}
			}
		}
	};
});
