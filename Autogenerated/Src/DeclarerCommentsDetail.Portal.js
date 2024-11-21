define("DeclarerCommentsDetail", [], function() {
	return {
		entitySchemaName: "VwDeclarerComments",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {
			/**
			 * @inheritdoc BaseGridDetailV2#addRecordOperationsMenuItems
			 * @overridden
			 */
			addRecordOperationsMenuItems: this.BPMSoft.emptyFn
		}
	};
});
