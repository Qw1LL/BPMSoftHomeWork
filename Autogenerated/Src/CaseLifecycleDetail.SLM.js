define("CaseLifecycleDetail", [],
	function() {
		return {
			entitySchemaName: "CaseLifecycle",
			attributes: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "Status"
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				addRecordOperationsMenuItems: BPMSoft.emptyFn
			},
			messages: {}
		};
	}
);