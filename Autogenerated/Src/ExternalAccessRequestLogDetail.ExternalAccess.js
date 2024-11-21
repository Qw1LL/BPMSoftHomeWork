define("ExternalAccessRequestLogDetail", [], function() {
	return {
		entitySchemaName: "ExternalAccessRequestLog",
		attributes: {
		},
		properties: {
		},
		methods: {
			/**
			 * @inheritdoc BaseDetailV2#init
			 * @override
			 */
			init: function() {
				this.$IsEnabled = false;
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BaseDetailV2#getDetailInfo
			 * @override
			 */
			getDetailInfo: function() {
				const detailInfo = this.callParent(arguments);
				detailInfo.isEnabled = false;
				return detailInfo;
			}
		},

		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
