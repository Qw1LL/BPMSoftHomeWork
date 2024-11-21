 define("FileImportTemplateLookupSection", [],
	function() {
		return {
			entitySchemaName: "FileImportTemplate",
			methods: {
				getDataImportMenuItemVisible: function() {
					return false;
				}
			},
			diff: /**SCHEMA_DIFF*/[{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"visible": false
				}
			}]/**SCHEMA_DIFF*/
		};
	});
