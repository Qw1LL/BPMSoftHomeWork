define("EmailMessageHistoryItemPageV2", [],
	function() {
	return {
		entitySchemaName: "BaseMessageHistory",
		methods: {

			/**
			 * @inheritdoc BPMSoft.EmailMessageHistoryItemPageV2#getEmailActionParams
			 * @override
			 */
			getEmailActionParams: function() {
				const emailConfig = this.callParent(arguments);
				emailConfig.stateObj = {
					useServiceMailBoxLogic: true
				};
				return emailConfig;
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
