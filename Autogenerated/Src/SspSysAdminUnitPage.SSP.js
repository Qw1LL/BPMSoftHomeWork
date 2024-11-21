define("SspSysAdminUnitPage", [],
	function() {
		return {
			entitySchemaName: "VwSysAdminUnit",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "IPRangeTab"
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"SecurityOperationName": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "CanAdministratePortalUsers"
				}
			},
			methods: {}
		};
	});
