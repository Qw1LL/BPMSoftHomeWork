define("FormSubmitDetail", [], function() {
	return {
		entitySchemaName: "FormSubmit",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {
			getAddRecordButtonVisible: function() {
                return false;
                                                },
          	getDeleteRecordMenuItem: function() {
                return false;
                                                },
          	getCopyRecordMenuItem: function() {
                return false;
                                                }
		}
	};
});
