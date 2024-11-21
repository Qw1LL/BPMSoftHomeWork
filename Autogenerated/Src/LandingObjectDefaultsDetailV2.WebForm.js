define("LandingObjectDefaultsDetailV2", function() {
	return {
		entitySchemaName: "LandingObjectDefaults",
		diff: /**SCHEMA_DIFF*/[
		]/**SCHEMA_DIFF*/,
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#getGridSettingsMenuItem
			 * @overridden
			 */
			getGridSettingsMenuItem: BPMSoft.emptyFn,

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
