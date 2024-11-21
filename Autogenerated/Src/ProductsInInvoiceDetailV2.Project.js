define("ProductsInInvoiceDetailV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "VwInvoiceProduct",
			attributes: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [

							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [

							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
