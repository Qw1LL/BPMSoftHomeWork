define("CommunicationTypeByCommunicationDetailV2", [],
	function() {
		return {
			entitySchemaName: "ComTypebyCommunication",

			attributes: {
				"MasterDetailColumnName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "CommunicationType"
				},
				
				"RelatedDetailColumnName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "Communication"
				},
				
				"LookupEntityName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "Communication"
				}
			},

			messages: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
