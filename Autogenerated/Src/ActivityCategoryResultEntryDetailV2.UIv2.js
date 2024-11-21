define("ActivityCategoryResultEntryDetailV2", [],
	function() {
		return {
			entitySchemaName: "ActivityCategoryResultEntry",

			attributes: {
				"MasterDetailColumnName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "ActivityResult"
				},
				
				"RelatedDetailColumnName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "ActivityCategory"
				},
				
				"LookupEntityName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "ActivityCategory"
				}
			},

			messages: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
