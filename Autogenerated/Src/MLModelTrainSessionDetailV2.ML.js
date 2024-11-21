define("MLModelTrainSessionDetailV2", function() {
	return {
		entitySchemaName: "MLTrainSession",
		diff: /**SCHEMA_DIFF*/[
		]/**SCHEMA_DIFF*/,
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn
		}
	};
});
