define("PartnerParamHistoryDetail", [], function() {
	return {
		entitySchemaName: "PartnerParamHistory",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "AddRecordButton"
			}
		]/**SCHEMA_DIFF*/,
		methods: {
			getCopyRecordMenuItem: BPMSoft.emptyFn,
			getEditRecordMenuItem: BPMSoft.emptyFn,
			getDeleteRecordMenuItem: BPMSoft.emptyFn,
			getGridSettingsMenuItem: BPMSoft.emptyFn,
			addDetailWizardMenuItems: BPMSoft.emptyFn
		}
	};
});
